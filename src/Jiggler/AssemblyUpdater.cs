namespace Jiggler
{
    public interface IAssemblyUpdater
    {
        void ApplyJiggleToAllMethodsInNamespace(string namespaceToUpdate, string jiggleMethod);
    }

    public class AssemblyUpdater : IAssemblyUpdater
    {
        //public AssemblyUpdater(IMethodUpdater methodUpdater, I
        //{
            
        //}

        public void ApplyJiggleToAllMethodsInNamespace(string namespaceToUpdate, string jiggleMethod)
        {
            //var jiggleMethodInstructions = _GetJiggleMethodInstructions();
            //var methodUpdaters = _GetMethodUpdaters();
            //foreach (var methodUpdater in methodUpdaters)
            //    methodUpdater.InsertInstructionsAtStart(jiggleMethodInstructions);
            //_SaveToDisk();
        }
    }
}