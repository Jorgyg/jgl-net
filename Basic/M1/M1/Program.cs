using System;

namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Milestone 1 - Fase 1
            string nom = "Jordi";
            string cognom1 = "Gras";
            string cognom2 = "Lorenzo";

            int dia = 1;
            int mes = 1;
            int any = 2002;

            Console.WriteLine(cognom1 + " " + cognom2 + ", " + nom);
            Console.WriteLine(dia + "/" + mes + "/" + any);

            // Milestone 1 - Fase 2
            const int anyTraspas = 1948;
            int anysTraspas = (any - anyTraspas) / 4;
            Console.WriteLine("Anys de traspàs entre 1948 i el teu any de naixement: " + anysTraspas);

            // Milestone 1 - Fase 3
            bool esAnyTraspas = (any % 4 == 0 && (any % 100 != 0 || any % 400 == 0));
            string fraseTraspas = "El meu any de naixement és de traspàs.";
            string fraseNoTraspas = "El meu any de naixement no és de traspàs.";

            for (int i = anyTraspas; i <= any; i += 4)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(esAnyTraspas ? fraseTraspas : fraseNoTraspas);

            // Milestone 1 - Fase 4
            string nomComplet = nom + " " + cognom1 + " " + cognom2;
            string dataNaixement = dia + "/" + mes + "/" + any;
            Console.WriteLine("El meu nom és " + nomComplet);
            Console.WriteLine("Vaig néixer el " + dataNaixement);
            Console.WriteLine(esAnyTraspas ? fraseTraspas : fraseNoTraspas);

            // Milestone 2
            double valorDouble = 123.4567;
            int valorInt = (int)valorDouble;
            float valorFloat = (float)valorDouble;
            string valorString = valorDouble.ToString();

            Console.WriteLine("Valor double: " + valorDouble);
            Console.WriteLine("Valor int: " + valorInt);
            Console.WriteLine("Valor float: " + valorFloat);
            Console.WriteLine("Valor string: " + valorString);

            // Milestone 3
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int temp = array[array.Length - 1];
            for (int i = array.Length - 1; i > 0; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = temp;

            Console.Write("Array rotado: ");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}