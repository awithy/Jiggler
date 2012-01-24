using System.Collections.Generic;

namespace Jiggler.ILInterface
{
    public interface IAssemblyILInterface
    {
        IEnumerable<IMethodILInterface> FindAllNonCtorMethodsWithPrefix(string prefix);
        IMethodILInterface FindMethod(string methodName);
        void SaveToDisk();
    }
}