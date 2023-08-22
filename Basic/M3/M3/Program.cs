using System;
using System.Linq;
namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Milestone 1 - Fase 1
            string[] ciutats = new string[6];

            Console.WriteLine("Introduce los nombres de 6 ciudades:");
            for (int i = 0; i < ciutats.Length; i++)
            {
                Console.Write($"Ciudad {i + 1}: ");
                ciutats[i] = Console.ReadLine();
            }

            Console.WriteLine("Nombres de las ciudades:");
            foreach (string ciutat in ciutats)
            {
                Console.WriteLine(ciutat);
            }

            // Milestone 1 - Fase 2
            Array.Sort(ciutats);

            Console.WriteLine("Nombres de las ciudades ordenados alfabéticamente:");
            foreach (string ciutat in ciutats)
            {
                Console.WriteLine(ciutat);
            }

            // Milestone 1 - Fase 3
            string[] ciutatsModificades = new string[ciutats.Length];

            for (int i = 0; i < ciutats.Length; i++)
            {
                ciutatsModificades[i] = ciutats[i].Replace('a', '4');
            }

            Array.Sort(ciutatsModificades);

            Console.WriteLine("Nombres de las ciudades modificados y ordenados:");
            foreach (string ciutat in ciutatsModificades)
            {
                Console.WriteLine(ciutat);
            }

            // Milestone 1 - Fase 4
            char[][] arrayCiutatsInvertides = new char[ciutats.Length][];
            for (int i = 0; i < ciutats.Length; i++)
            {
                arrayCiutatsInvertides[i] = ciutats[i].ToCharArray();
                Array.Reverse(arrayCiutatsInvertides[i]);
            }

            Console.WriteLine("Nombres de las ciudades invertidos:");
            foreach (char[] ciutat in arrayCiutatsInvertides)
            {
                Console.WriteLine(new string(ciutat));
            }

            // Milestone 2
            double[][] notesAlumnes = new double[5][];
            for (int i = 0; i < notesAlumnes.Length; i++)
            {
                notesAlumnes[i] = new double[3];
                Console.WriteLine($"Alumne {i + 1}:");
                for (int j = 0; j < notesAlumnes[i].Length; j++)
                {
                    Console.Write($"Introduce la nota {j + 1}: ");
                    notesAlumnes[i][j] = double.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < notesAlumnes.Length; i++)
            {
                double mitjana = notesAlumnes[i].Average();
                string resultat = mitjana >= 5 ? "aprovat" : "suspès";
                Console.WriteLine($"Alumne {i + 1} - Mitjana: {mitjana:F2} - {resultat}");
            }

            // Milestone 3
            Console.Write("Introduce el número N para la secuencia de Fibonacci: ");
            int n = int.Parse(Console.ReadLine());
            int a = 0, b = 1;
            Console.Write("Secuencia de Fibonacci: " + a + " " + b + " ");
            for (int i = 2; i < n; i++)
            {
                int c = a + b;
                Console.Write(c + " ");
                a = b;
                b = c;
            }
        }
    }
}