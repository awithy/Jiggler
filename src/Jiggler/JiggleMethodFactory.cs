using Jiggler.ILInterface;

namespace Jiggler
{
    public interface IJiggleMethodFactory
    {
        IILMethod Create(string assemblyPath, string methodName);
    }

    public class JiggleMethodFactory : IJiggleMethodFactory
    {
        private readonly IILAssemblyFactory _assemblyFactory;

        public JiggleMethodFactory(IILAssemblyFactory assemblyFactory)
        {
            _assemblyFactory = assemblyFactory;
        }

        public IILMethod Create(string assemblyPath, string methodName)
        {
            var ilAssembly = _assemblyFactory.Create(assemblyPath);
            var jiggleMethod = ilAssembly.FindMethod(methodName);
            return jiggleMethod;
        }
    }
}