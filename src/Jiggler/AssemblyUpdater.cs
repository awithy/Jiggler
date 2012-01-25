using System;
using Jiggler.ILInterface;

namespace Jiggler
{
    public interface IAssemblyUpdater
    {
        void ApplyJiggleToAllMethodsInNamespace(string namespaceToUpdate, IILMethod jiggleMethod);
    }

    public class AssemblyUpdater : IAssemblyUpdater
    {
        private readonly IILAssembly _assemblyIlInterface;

        public AssemblyUpdater(IILAssembly assemblyILInterface)
        {
            _assemblyIlInterface = assemblyILInterface;
        }

        public void ApplyJiggleToAllMethodsInNamespace(string namespaceToUpdate, IILMethod jiggleMethod)
        {
            Console.WriteLine("Applying jiggle");
            var methodsToUpdate = _assemblyIlInterface.FindAllNonCtorMethodsWithPrefix(namespaceToUpdate);
            foreach(var methodToUpdate in methodsToUpdate)
                methodToUpdate.InsertCallAtStart(jiggleMethod);
            _assemblyIlInterface.SaveToDisk();
        }
    }
}