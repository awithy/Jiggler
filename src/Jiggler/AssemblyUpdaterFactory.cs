using Jiggler.ILInterface;

namespace Jiggler
{
    public interface IAssemblyUpdaterFactory
    {
        IAssemblyUpdater Create(string assemblyPath);
    }

    public class AssemblyUpdaterFactory : IAssemblyUpdaterFactory
    {
        public IAssemblyUpdater Create(string assemblyPath)
        {
            return new AssemblyUpdater(new CecilAssembly(assemblyPath));
        }
    }
}