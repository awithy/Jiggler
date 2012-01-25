namespace Jiggler.ILInterface
{
    public interface IILAssemblyFactory
    {
        IILAssembly Create(string assemblyPath);
    }

    public class CecilILAssemblyFactory : IILAssemblyFactory
    {
        public IILAssembly Create(string assemblyPath)
        {
            return new CecilAssembly(assemblyPath);
        }
    }
}