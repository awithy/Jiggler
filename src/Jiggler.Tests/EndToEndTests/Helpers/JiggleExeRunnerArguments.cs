namespace Jiggler.Tests.EndToEndTests.Helpers
{
    public class JiggleExeRunnerArguments
    {
        public string AssemblyPath { get; set; }
        public string Namespace { get; set; }
        public string JiggleAssemblyPath { get; set; }
        public string JiggleMethod { get; set; }
        public string WorkingDirectory { get; set; }

        public string ToArgumentsString()
        {
            return AssemblyPath + " " + Namespace + " " + JiggleAssemblyPath + " " + JiggleMethod;
        }
    }
}
