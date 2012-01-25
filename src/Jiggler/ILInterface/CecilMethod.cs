using System;
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
            var cecilMethodDefinition = cecilMethod._methodDefinition;
            var existingInstructions = _methodDefinition.Body.Instructions.ToArray();
            _methodDefinition.Body.Instructions.Clear();
            var importedJiggleMethod = _methodDefinition.Module.Import(cecilMethodDefinition);
            _methodDefinition.Body.Instructions.Add(Instruction.Create(OpCodes.Call, importedJiggleMethod));
            foreach(var existingInstruction in existingInstructions)
                _methodDefinition.Body.Instructions.Add(existingInstruction);
        }
    }
}