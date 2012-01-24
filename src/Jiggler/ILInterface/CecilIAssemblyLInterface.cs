using System.Collections.Generic;

namespace Jiggler.ILInterface
{
    public class CecilIAssemblyLInterface : IAssemblyILInterface
    {
        public IEnumerable<IMethodILInterface> FindAllNonCtorMethodsWithPrefix(string prefix)
        {
            return new List<IMethodILInterface>();
        }

        public IMethodILInterface FindMethod(string methodName)
        {
            return new CecilMethodILInterface();
        }

        public void SaveToDisk()
        {
        }
    }
}