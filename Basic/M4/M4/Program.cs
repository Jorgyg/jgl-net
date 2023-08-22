using System;
using System.Collections.Generic;

namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Milestone 1 - Fase 1
            int[] bitllets = { 5, 10, 20, 50, 100, 200, 500 };
            int preuTotal = 0;

            string[] menu = { "Pizza", "Hamburguesa", "Pasta", "Ensalada" };
            int[] preus = { 8, 6, 7, 5 };

            // Milestone 1 - Fase 2
            List<string> comanda = new List<string>();
            int seguirDemanant = 1;

            while (seguirDemanant == 1)
            {
                Console.WriteLine("Menú:");
                for (int i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i]} - {preus[i]}€");
                }

                Console.Write("Què vols menjar? (Introdueix el número del plat): ");
                int opcio = int.Parse(Console.ReadLine()) - 1;

                if (opcio >= 0 && opcio < menu.Length)
                {
                    comanda.Add(menu[opcio]);
                    preuTotal += preus[opcio];
                }
                else
                {
                    Console.WriteLine("Opció incorrecta. No existeix aquest plat.");
                }

                Console.Write("Vols seguir demanant? (1: Si / 0: No): ");
                seguirDemanant = int.Parse(Console.ReadLine());
            }

            // Milestone 1 - Fase 3
            Console.WriteLine("Comanda:");
            foreach (string plat in comanda)
            {
                Console.WriteLine(plat);
            }
            Console.WriteLine($"Preu total: {preuTotal}€");

            // Milestone 2
            try
            {
                int opcio = 1;
                while (opcio == 1)
                {
                    Console.WriteLine("Menú:");
                    for (int i = 0; i < menu.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {menu[i]} - {preus[i]}€");
                    }

                    Console.Write("Què vols menjar? (Introdueix el número del plat): ");
                    int platIndex = int.Parse(Console.ReadLine()) - 1;

                    if (platIndex >= 0 && platIndex < menu.Length)
                    {
                        comanda.Add(menu[platIndex]);
                        preuTotal += preus[platIndex];
                    }
                    else
                    {
                        throw new ProductNotFoundException("Aquest plat no existeix.");
                    }

                    Console.Write("Vols seguir demanant? (1: Si / 0: No): ");
                    opcio = int.Parse(Console.ReadLine());
                }
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Opció incorrecta. Introdueix un número.");
            }

            // Milestone 3
            try
            {
                int opcio = 1;
                while (opcio == 1)
                {
                    Console.WriteLine("Menú:");
                    for (int i = 0; i < menu.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {menu[i]} - {preus[i]}€");
                    }

                    Console.Write("Què vols menjar? (Introdueix el número del plat): ");
                    int platIndex = int.Parse(Console.ReadLine()) - 1;

                    if (platIndex >= 0 && platIndex < menu.Length)
                    {
                        comanda.Add(menu[platIndex]);
                        preuTotal += preus[platIndex];
                    }
                    else
                    {
                        throw new ProductNotFoundException("Aquest plat no existeix.");
                    }

                    Console.Write("Vols seguir demanant? (1: Si / 0: No): ");
                    opcio = int.Parse(Console.ReadLine());
                }
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Opció incorrecta. Introdueix un número.");
            }
        }
    }

    class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message) { }
    }

}