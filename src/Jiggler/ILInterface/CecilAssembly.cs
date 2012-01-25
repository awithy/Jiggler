using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace Jiggler.ILInterface
{
    public class CecilAssembly : IILAssembly
    {
        private readonly AssemblyDefinition _assemblyDefinition;
        private readonly string _assemblyPath;

        public CecilAssembly(string assemblyPath)
        {
            _assemblyPath = assemblyPath;
            _assemblyDefinition = AssemblyDefinition.ReadAssembly(assemblyPath);
        }

        public IEnumerable<IILMethod> FindAllNonCtorMethodsWithPrefix(string prefix)
        {
            var typeDefinitions = _assemblyDefinition.MainModule.Types;
            var typesInNamespaceToUpdate = typeDefinitions.Where(x => x.FullName.StartsWith(prefix));
            var typeMethodsToUpdate = typesInNamespaceToUpdate.SelectMany(x => x.Methods).Where(x => x.Name != ".ctor");
            return typeMethodsToUpdate.Select(x => new CecilMethod(x));
        }

        public IILMethod FindMethod(string methodName)
        {
            var methodDefinition =
                _assemblyDefinition.MainModule.Types.SelectMany(x => x.Methods).Where(
                    x => x.DeclaringType + "." + x.Name == methodName).Single();
            return new CecilMethod(methodDefinition);
        }

        public void SaveToDisk()
        {
            _assemblyDefinition.Write(_assemblyPath);
        }
    }
}