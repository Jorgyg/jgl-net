using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleAplication5
{
    class Program
    {

        static void Main(string[] args)
        {
            // Milestone 1 - Fase 1
            string nom = "Jordi";
            char[] nomArray = nom.ToCharArray();

            foreach (char c in nomArray)
            {
                Console.WriteLine(c);
            }

            // Milestone 1 - Fase 2
            List<char> nomList = new List<char>(nomArray);

            foreach (char c in nomList)
            {
                if (char.IsDigit(c))
                {
                    Console.WriteLine("Els noms de persones no contenen números!");
                }
                else if ("aeiouAEIOU".Contains(c))
                {
                    Console.WriteLine("VOCAL");
                }
                else
                {
                    Console.WriteLine("CONSONTANT");
                }
            }

            // Milestone 1 - Fase 3
            Dictionary<char, int> freqMap = new Dictionary<char, int>();

            foreach (char c in nomList)
            {
                if (char.IsLetter(c))
                {
                    if (freqMap.ContainsKey(c))
                    {
                        freqMap[c]++;
                    }
                    else
                    {
                        freqMap[c] = 1;
                    }
                }
            }

            foreach (KeyValuePair<char, int> entry in freqMap)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} vegades");
            }

            // Milestone 1 - Fase 4
            string cognom = "Gras";
            List<char> cognomList = new List<char>(cognom.ToCharArray());

            List<char> fullNameList = new List<char>(nomList);
            fullNameList.Add(' ');
            fullNameList.AddRange(cognomList);

            Console.Write("FullName: ");
            foreach (char c in fullNameList)
            {
                Console.Write($"'{c}' ");
            }
            Console.WriteLine();

            // Milestone 2 - Escala de números
            Console.Write("Introduce la altura de la escala: ");
            int alturaEscala = int.Parse(Console.ReadLine());

            for (int i = 1; i <= alturaEscala; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }

            // Milestone 2 - Pirámide invertida
            Console.Write("Introduce la altura de la pirámide invertida: ");
            int alturaPiramide = int.Parse(Console.ReadLine());

            for (int i = alturaPiramide; i >= 1; i--)
            {
                for (int j = 1; j <= alturaPiramide - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            // Milestone 3 - Reloj digital
            int hour = 0, minutes = 0, seconds = 0;
            while (true)
            {
                Console.WriteLine($"{hour:D2}:{minutes:D2}:{seconds:D2}");
                Thread.Sleep(1000);

                seconds++;
                if (seconds == 60)
                {
                    seconds = 0;
                    minutes++;
                    if (minutes == 60)
                    {
                        minutes = 0;
                        hour++;
                        if (hour == 24)
                        {
                            hour = 0;
                        }
                    }
                }
            }
        }
    }
}