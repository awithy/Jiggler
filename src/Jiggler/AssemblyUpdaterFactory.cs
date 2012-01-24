using Jiggler.ILInterface;

namespace Jiggler
{
    public interface IAssemblyUpdaterFactory
    {
        IAssemblyUpdater Load(string assemblyPath);
    }

    public class AssemblyUpdaterFactory : IAssemblyUpdaterFactory
    {
        public IAssemblyUpdater Load(string assemblyPath)
        {
            return new AssemblyUpdater(new CecilAssembly(assemblyPath));
        }
    }
}