using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Jiggler.ILInterface
{
    public class CecilMethod : IILMethod
    {
        private readonly MethodDefinition _methodDefinition;

        public CecilMethod(MethodDefinition methodDefinition)
        {
            _methodDefinition = methodDefinition;
        }

        public void InsertCallAtStart(IILMethod method)
        {
            var cecilMethod = method as CecilMethod;
            var existingInstructions = _methodDefinition.Body.Instructions.ToArray();
            _methodDefinition.Body.Instructions.Clear();
            _methodDefinition.Body.Instructions.Add(Instruction.Create(OpCodes.Call, cecilMethod._methodDefinition));
            foreach(var existingInstruction in existingInstructions)
                _methodDefinition.Body.Instructions.Add(existingInstruction);
        }
    }
}