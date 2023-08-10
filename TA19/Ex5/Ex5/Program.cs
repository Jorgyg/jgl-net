namespace ConsoleAplication5
{

    class Program
    {

        static void Main(string[] args)
        {
            int A = 1;
            int B = 2;
            int C = 3;
            int D = 4;

            Console.WriteLine($"Valores iniciales: A = {A}, B = {B}, C = {C}, D = {D}");

            int temp = B;
            B = C;
            C = A;
            A = D;
            D = temp;

            Console.WriteLine($"Valores intercambiados: A = {A}, B = {B}, C = {C}, D = {D}");
        }
    }

}
