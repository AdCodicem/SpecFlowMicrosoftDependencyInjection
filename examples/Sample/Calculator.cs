using System.Collections.Generic;

namespace Sample
{
    public class Calculator : ICalculator
    {
        private readonly Stack<int> _operands = new Stack<int>();

        public void Add()
        {
            _operands.Push(_operands.Pop() + _operands.Pop());
        }

        public void Enter(int operand)
        {
            _operands.Push(operand);
        }

        public void Multiply()
        {
            _operands.Push(_operands.Pop() * _operands.Pop());
        }

        public int Result
        {
            get => _operands.Peek();
        }
    }
}
