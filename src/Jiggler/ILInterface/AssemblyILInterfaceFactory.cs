namespace Jiggler.ILInterface
{
    public interface IAssemblyILInterfaceFactory
    {
        IAssemblyILInterface Create(string assemblyPath);
    }

    public class AssemblyIlInterfaceFactory : IAssemblyILInterfaceFactory
    {
        public IAssemblyILInterface Create(string assemblyPath)
        {
            return null;
        }
    }
}