using System;
using System.Collections.Generic;
using System.Linq;
using Jiggler.ILInterface;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Jiggler
{
    public interface IAssemblyUpdater
    {
        void ApplyJiggleToAllMethodsInNamespace(string namespaceToUpdate, string jiggleMethodName);
    }

    public class AssemblyUpdater : IAssemblyUpdater
    {
        private readonly IAssemblyILInterface _assemblyIlInterface;
        private readonly string _assemblyPath;
        private AssemblyDefinition _assemblyDefinition;

        public AssemblyUpdater(string assemblyPath)
        {
            _assemblyPath = assemblyPath;
            _assemblyDefinition = AssemblyDefinition.ReadAssembly(_assemblyPath);
        }

        public AssemblyUpdater(IAssemblyILInterface assemblyILInterface)
        {
            _assemblyIlInterface = assemblyILInterface;
        }

        public void ApplyJiggleToAllMethodsInNamespace(string namespaceToUpdate, string jiggleMethodName)
        {
            Console.WriteLine("Applying jiggle");

            var jiggleMethod = _assemblyIlInterface.FindMethod(jiggleMethodName);
            var methodsToUpdate = _assemblyIlInterface.FindAllNonCtorMethodsWithPrefix(namespaceToUpdate);
            foreach(var methodToUpdate in methodsToUpdate)
                methodToUpdate.InsertCallAtStart(jiggleMethod);

            _assemblyIlInterface.SaveToDisk();

            //var typeMethodsToUpdate = _MethodsToUpdate(namespaceToUpdate);
            //foreach (var typeMethodToUpdate in typeMethodsToUpdate)
            //_InsertJiggleInstructions(typeMethodToUpdate, jiggleMethod);
            //_SaveToDisk();
        }

        private IEnumerable<MethodDefinition> _MethodsToUpdate(string namespaceToUpdate)
        {
            var typeDefinitions = _assemblyDefinition.MainModule.Types;
            var typesInNamespaceToUpdate = typeDefinitions.Where(x => x.FullName.StartsWith(namespaceToUpdate));
            var typeMethodsToUpdate = typesInNamespaceToUpdate.SelectMany(x => x.Methods).Where(x => x.Name != ".ctor");
            return typeMethodsToUpdate;
        }

        private void _InsertJiggleInstructions(MethodDefinition typeMethodToUpdate, string jiggleMethod)
        {
            Console.WriteLine("Updating " + typeMethodToUpdate.Name);
            var jiggleMethodDefinition = _GetJiggleMethodDefinition(jiggleMethod);
            var existingInstructions = typeMethodToUpdate.Body.Instructions.ToArray();
            typeMethodToUpdate.Body.Instructions.Clear();
            typeMethodToUpdate.Body.Instructions.Add(Instruction.Create(OpCodes.Call, jiggleMethodDefinition));
            foreach(var existingInstruction in existingInstructions)
                typeMethodToUpdate.Body.Instructions.Add(existingInstruction);
        }

        private MethodDefinition _GetJiggleMethodDefinition(string jiggleMethod)
        {
            var jiggleMethodDefinition =
                _assemblyDefinition.MainModule.Types.SelectMany(x => x.Methods).Where(
                    x => x.DeclaringType + "." + x.Name == jiggleMethod).Single();
            return jiggleMethodDefinition;
        }

        private void _SaveToDisk()
        {
            Console.WriteLine("Saving to disk.");
            _assemblyDefinition.Write(_assemblyPath);
        }
    }
}