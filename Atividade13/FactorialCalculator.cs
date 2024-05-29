namespace Atividade13
{
    public class FactorialCalculator
    {
        public int Calculate(int n)
        {
            if (n < 0)
                throw new ArgumentException("Number must be non-negative");

            if (n == 0 || n == 1)
                return 1;

            return n * Calculate(n - 1);
        }
    }
}
