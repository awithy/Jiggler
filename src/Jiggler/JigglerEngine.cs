namespace Jiggler
{
    public interface IJigglerEngine
    {
        void Jiggle(JigglerArguments jigglerArguments);
    }

    public class JigglerEngine : IJigglerEngine
    {
        public IAssemblyUpdaterFactory AssemblyUpdaterFactory = new AssemblyUpdaterFactory();
        
        public void Jiggle(JigglerArguments jigglerArguments)
        {
            var assemblyUpdater = AssemblyUpdaterFactory.Load(jigglerArguments.AssemblyPath);
            assemblyUpdater.ApplyJiggleToAllMethodsInNamespace(jigglerArguments.NamespaceToUpdate, jigglerArguments.JiggleMethod);
        }
    }
}