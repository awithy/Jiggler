namespace Jiggler
{
    public class JigglerArgumentsParser
    {
        public JigglerArguments Parse(string[] args)
        {
            return new JigglerArguments
                       {
                           AssemblyToUpdatePath = args[0],
                           NamespaceToUpdate = args[1],
                           JiggleAssemblyPath = args[2],
                           JiggleMethod = args[3],
                       };
        }
    }
}