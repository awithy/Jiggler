using System.Collections.Generic;

namespace Jiggler.ILInterface
{
    public interface IILAssembly
    {
        IEnumerable<IILMethod> FindAllNonCtorMethodsWithPrefix(string prefix);
        IILMethod FindMethod(string methodName);
        void SaveToDisk();
    }
}