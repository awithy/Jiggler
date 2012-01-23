namespace Jiggler
{
    public class JigglerArgumentsParser
    {
        public JigglerArguments Parse(string[] args)
        {
            return new JigglerArguments
                       {
                           AssemblyPath = args[0],
                           Namespace = args[1],
                           JiggleMethod = args[2],
                       };
        }
    }
}