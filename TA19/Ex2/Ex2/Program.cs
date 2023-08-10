namespace ConsoleAplication5
{

    class Program
    {

        static void Main(string[] args)
        {
            int N = 5;
            double A = 4.56;
            char C = 'a';

            Console.WriteLine("Variable N = " + N);
            Console.WriteLine("Variable A = " + A);
            Console.WriteLine("Variable C = " + C);
            Console.WriteLine($"{N} + {A} = {N + A}");
            Console.WriteLine($"{A} - {N} = {A - N}");
            Console.WriteLine($"Valor numérico del carácter {C} = {(int)C}");
        }
    }

}
