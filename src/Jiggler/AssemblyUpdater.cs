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
        private ILogger Log = LoggerProvider.GetLogger(typeof (AssemblyUpdater));

        public AssemblyUpdater(IILAssembly assemblyILInterface)
        {
            _assemblyIlInterface = assemblyILInterface;
        }

        public void ApplyJiggleToAllMethodsInNamespace(string namespaceToUpdate, IILMethod jiggleMethod)
        {
            Log.Info("Applying Jiggle.");
            var methodsToUpdate = _assemblyIlInterface.FindAllNonCtorMethodsWithPrefix(namespaceToUpdate);
            foreach(var methodToUpdate in methodsToUpdate)
                methodToUpdate.InsertCallAtStart(jiggleMethod);
            _assemblyIlInterface.SaveToDisk();
        }
    }
}