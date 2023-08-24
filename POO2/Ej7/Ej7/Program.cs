using System;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Raices ecuacion1 = new Raices(1, -5, 6);
            Raices ecuacion2 = new Raices(2, 4, 2);
            Raices ecuacion3 = new Raices(1, 0, -4);

            Console.WriteLine("Ecuación 1:");
            ecuacion1.Calcular();

            Console.WriteLine("\nEcuación 2:");
            ecuacion2.Calcular();

            Console.WriteLine("\nEcuación 3:");
            ecuacion3.Calcular();
        }
    }

    class Raices
    {
        private double a;
        private double b;
        private double c;

        public Raices(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public void Calcular()
        {
            double discriminante = GetDiscriminante();

            if (discriminante > 0)
            {
                double raiz1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
                double raiz2 = (-b - Math.Sqrt(discriminante)) / (2 * a);
                Console.WriteLine($"Dos posibles soluciones: {raiz1}, {raiz2}");
            }
            else if (discriminante == 0)
            {
                double raiz = -b / (2 * a);
                Console.WriteLine($"Una única solución: {raiz}");
            }
            else
            {
                Console.WriteLine("No tiene soluciones reales.");
            }
        }

        public double GetDiscriminante()
        {
            return Math.Pow(b, 2) - 4 * a * c;
        }

        public bool TieneRaices()
        {
            double discriminante = GetDiscriminante();
            return discriminante >= 0;
        }

        public bool TieneRaiz()
        {
            double discriminante = GetDiscriminante();
            return discriminante == 0;
        }
    }
}
