namespace Jiggler
{
    public interface IJigglerEngine
    {
        void Jiggle(JigglerArguments jigglerArguments);
    }

    public class JigglerEngine : IJigglerEngine
    {
        private readonly IAssemblyUpdaterFactory _assemblyUpdaterFactory;
        private readonly IJiggleMethodFactory _jiggleMethodFactory;

        public JigglerEngine(IAssemblyUpdaterFactory assemblyUpdaterFactory, IJiggleMethodFactory jiggleMethodFactory)
        {
            _assemblyUpdaterFactory = assemblyUpdaterFactory;
            _jiggleMethodFactory = jiggleMethodFactory;
        }

        public void Jiggle(JigglerArguments jigglerArguments)
        {
            var jiggleMethod = _jiggleMethodFactory.Create(jigglerArguments.JiggleAssemblyPath, jigglerArguments.JiggleMethod);
            var assemblyUpdater = _assemblyUpdaterFactory.Create(jigglerArguments.AssemblyToUpdatePath);
            assemblyUpdater.ApplyJiggleToAllMethodsInNamespace(jigglerArguments.NamespaceToUpdate, jiggleMethod);
        }
    }
}