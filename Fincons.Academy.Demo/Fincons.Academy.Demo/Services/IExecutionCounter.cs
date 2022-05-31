namespace Fincons.Academy.Demo.Services
{
    public interface IExecutionCounter
    {
        int Increment();
    }

    public class ExecutionCounter : IExecutionCounter
    {
        private int _counter;

        public int Increment()
        {
            _counter++;

            return _counter;
        }
    }
}
