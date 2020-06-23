namespace Sample
{
    public interface ICalculator
    {
        int Result { get; }

        void Add();

        void Enter(int operand);

        void Multiply();
    }
}
