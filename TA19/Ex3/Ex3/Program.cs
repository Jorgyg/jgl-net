namespace ConsoleAplication5
{

    class Program
    {

        static void Main(string[] args)
        {
            int X = 10;
            int Y = 3;
            double N = 5.5;
            double M = 2.0;

            Console.WriteLine("Valor de X = " + X);
            Console.WriteLine("Valor de Y = " + Y);
            Console.WriteLine("Valor de N = " + N);
            Console.WriteLine("Valor de M = " + M);

            Console.WriteLine($"{X} + {Y} = {X + Y}");
            Console.WriteLine($"{X} - {Y} = {X - Y}");
            Console.WriteLine($"{X} * {Y} = {X * Y}");
            Console.WriteLine($"{X} / {Y} = {X / (double)Y}"); // Realizamos un casting a double para obtener la división decimal
            Console.WriteLine($"{X} % {Y} = {X % Y}");

            Console.WriteLine($"{N} + {M} = {N + M}");
            Console.WriteLine($"{N} - {M} = {N - M}");
            Console.WriteLine($"{N} * {M} = {N * M}");
            Console.WriteLine($"{N} / {M} = {N / M}");
            Console.WriteLine($"{N} % {M} = {N % M}");

            Console.WriteLine($"{X} + {N} = {X + N}");
            Console.WriteLine($"{Y} / {M} = {Y / M}");
            Console.WriteLine($"{Y} % {M} = {Y % (int)M}");

            Console.WriteLine($"Doble de X = {2 * X}");
            Console.WriteLine($"Doble de Y = {2 * Y}");
            Console.WriteLine($"Doble de N = {2 * N}");
            Console.WriteLine($"Doble de M = {2 * M}");

            Console.WriteLine($"Suma de todas las variables = {X + Y + N + M}");
            Console.WriteLine($"Producto de todas las variables = {X * Y * N * M}");
        }
    }

}
