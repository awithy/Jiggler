namespace Jiggler.ILInterface
{
    public interface IAssemblyILInterfaceFactory
    {
        IILAssembly Create(string assemblyPath);
    }

    public class CecilAssemblyIlInterfaceFactory : IAssemblyILInterfaceFactory
    {
        public IILAssembly Create(string assemblyPath)
        {
            return new CecilAssembly(assemblyPath);
        }
    }
}