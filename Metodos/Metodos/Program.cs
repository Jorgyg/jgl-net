using System;
using System.Linq;

namespace ConsoleAplication5
{
    class Program
    {
        // Ejercicio 1
        static double CalcularAreaCirculo(double radio)
        {
            const double PI = 3.14159;
            return Math.Pow(radio, 2) * PI;
        }

        static double CalcularAreaTriangulo(double baseTriangulo, double altura)
        {
            return (baseTriangulo * altura) / 2;
        }

        static double CalcularAreaCuadrado(double lado)
        {
            return lado * lado;
        }

        // Ejercicio 2
        static int GenerarNumeroAleatorio(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

        // Ejercicio 3
        static bool EsPrimo(int numero)
        {
            if (numero <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(numero); ++i)
            {
                if (numero % i == 0) return false;
            }
            return true;
        }

        // Ejercicio 4
        static int CalcularFactorial(int numero)
        {
            if (numero <= 1) return 1;
            return numero * CalcularFactorial(numero - 1);
        }

        // Ejercicio 5
        static string DecimalABinario(int numero)
        {
            string binario = "";
            while (numero > 0)
            {
                binario = (numero % 2) + binario;
                numero /= 2;
            }
            return binario;
        }

        // Ejercicio 6
        static int ContarCifras(int numero)
        {
            int cifras = 0;
            while (numero > 0)
            {
                numero /= 10;
                cifras++;
            }
            return cifras;
        }

        // Ejercicio 7
        static void ConvertirMoneda(double cantidad, string moneda)
        {
            double cambio = 0;
            switch (moneda)
            {
                case "libras":
                    cambio = 0.86;
                    break;
                case "dolares":
                    cambio = 1.28611;
                    break;
                case "yenes":
                    cambio = 129.852;
                    break;
                default:
                    Console.WriteLine("Moneda no válida.");
                    return;
            }
            Console.WriteLine($"{cantidad} euros son {cantidad * cambio} {moneda}");
        }

        // Ejercicio 8
        static void CrearArrayPosiciones(int longitud)
        {
            int[] array = new int[longitud];
            for (int i = 0; i < longitud; ++i)
            {
                array[i] = i;
            }
            Console.Write("Contenido del array de posiciones: ");
            foreach (int num in array)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        // Ejercicio 9
        static void CrearArrayNumeros(int longitud)
        {
            int[] array = new int[longitud];
            for (int i = 0; i < longitud; ++i)
            {
                Console.Write($"Introduce un número para la posición {i}: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Contenido del array de números: ");
            foreach (int num in array)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        // Ejercicio 10
        static void TablaMultiplicar(int numero)
        {
            for (int i = 0; i <= 10; ++i)
            {
                Console.WriteLine($"{numero} * {i} = {numero * i}");
            }
        }

        // Ejercicio 11
        static void SumaArray(int[] array)
        {
            int suma = 0;
            foreach (int num in array)
            {
                suma += num;
            }
            Console.WriteLine($"La suma total es: {suma}");
        }

        // Ejercicio 12
        static void MediaArray(int[] array)
        {
            int suma = 0;
            foreach (int num in array)
            {
                suma += num;
            }
            double media = (double)suma / array.Length;
            Console.WriteLine($"La media es: {media}");
        }

        // Ejercicio 13
        static void RellenarArrayAleatorio(int[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = rand.Next(1, 11);
            }
        }

        // Ejercicio 14
        static bool ExisteEnArray(int numero, int[] array)
        {
            return array.Contains(numero);
        }

        // Ejercicio 15
        static int[] InvertirArray(int[] array)
        {
            int[] invertido = new int[array.Length];
            for (int i = 0; i < array.Length; ++i)
            {
                invertido[i] = array[array.Length - i - 1];
            }
            return invertido;
        }

        // Ejercicio 16
        static bool EsCapicua(int[] array)
        {
            for (int i = 0; i < array.Length / 2; ++i)
            {
                if (array[i] != array[array.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        // Ejercicio 17
        static void MostrarArray(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine($"Índice {i}: {array[i]}");
            }
        }

        // Ejercicio 18
        static int GenerarNumeroAleatorioEntre(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max + 1);
        }

        static void Ejercicio18()
        {
            Console.Write("Introduce la longitud del array: ");
            int longitud = int.Parse(Console.ReadLine());

            int[] array = new int[longitud];
            int suma = 0;

            for (int i = 0; i < longitud; ++i)
            {
                array[i] = GenerarNumeroAleatorioEntre(0, 9);
                suma += array[i];
            }

            Console.Write("Contenido del array: ");
            foreach (int num in array)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            Console.WriteLine($"Suma de los valores: {suma}");
        }

        // Ejercicio 19
        static bool EsPrimo2(int numero)
        {
            if (numero <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(numero); ++i)
            {
                if (numero % i == 0) return false;
            }
            return true;
        }

        static void Ejercicio19()
        {
            Console.Write("Introduce la longitud del array: ");
            int longitud = int.Parse(Console.ReadLine());

            int[] array = new int[longitud];
            int maxPrimo = -1;

            for (int i = 0; i < longitud; ++i)
            {
                do
                {
                    array[i] = GenerarNumeroAleatorioEntre(1, 300);
                } while (!EsPrimo2(array[i]));

                if (array[i] > maxPrimo)
                {
                    maxPrimo = array[i];
                }
            }

            Console.Write("Contenido del array: ");
            foreach (int num in array)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            Console.WriteLine($"El número primo más grande es: {maxPrimo}");
        }

        // Ejercicio 20
        static void Ejercicio20()
        {
            Console.Write("Introduce la longitud de los arrays: ");
            int longitud = int.Parse(Console.ReadLine());

            int[] array1 = new int[longitud];
            int[] array2 = new int[longitud];
            int[] resultado = new int[longitud];

            for (int i = 0; i < longitud; ++i)
            {
                array1[i] = GenerarNumeroAleatorioEntre(1, 100);
                array2[i] = array1[i];
                resultado[i] = array1[i] * array2[i];
            }

            Console.Write("Contenido del primer array: ");
            foreach (int num in array1)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            Console.Write("Contenido del segundo array: ");
            foreach (int num in array2)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            Console.Write("Resultado de la multiplicación: ");
            foreach (int num in resultado)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        // Ejercicio 21
        static void Ejercicio21()
        {
            Console.Write("Introduce la longitud del array: ");
            int longitud = int.Parse(Console.ReadLine());

            int[] array = new int[longitud];
            int digito;

            Console.Write("Introduce un dígito: ");
            digito = int.Parse(Console.ReadLine());

            int count = 0;
            for (int i = 0; i < longitud; ++i)
            {
                array[i] = GenerarNumeroAleatorioEntre(1, 300);
                if (array[i] % 10 == digito)
                {
                    Console.Write($"{array[i]} ");
                    count++;
                }
            }
            Console.WriteLine();

            Console.WriteLine($"Se encontraron {count} números que terminan en {digito}");
        }

        // Resto de ejercicios...

        static void Main(string[] args)
        {
            // Llama a las funciones de cada ejercicio y muestra los resultados

            Console.WriteLine("Ejercicio 1: Áreas");
            Console.WriteLine($"Área de un círculo (radio 5): {CalcularAreaCirculo(5)}");
            Console.WriteLine($"Área de un triángulo (base 6, altura 8): {CalcularAreaTriangulo(6, 8)}");
            Console.WriteLine($"Área de un cuadrado (lado 4): {CalcularAreaCuadrado(4)}");

            Console.WriteLine("\nEjercicio 2: Números aleatorios");
            for (int i = 0; i < 5; ++i)
            {
                Console.WriteLine($"Número aleatorio entre 10 y 20: {GenerarNumeroAleatorio(10, 20)}");
            }

            Console.WriteLine("\nEjercicio 3: Números primos");
            Console.Write("Introduce un número: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"{num} {(EsPrimo(num) ? "es primo" : "no es primo")}");

            Console.WriteLine("\nEjercicio 8: Crear array de posiciones");
            Console.Write("Introduce la longitud del array de posiciones: ");
            int longitudArrayPosiciones = int.Parse(Console.ReadLine());
            CrearArrayPosiciones(longitudArrayPosiciones);

            Console.WriteLine("\nEjercicio 9: Crear array de números");
            Console.Write("Introduce la longitud del array de números: ");
            int longitudArrayNumeros = int.Parse(Console.ReadLine());
            CrearArrayNumeros(longitudArrayNumeros);

            Console.WriteLine("\nEjercicio 10: Tabla de multiplicar");
            Console.Write("Introduce un número para mostrar su tabla de multiplicar: ");
            int numTabla = int.Parse(Console.ReadLine());
            TablaMultiplicar(numTabla);

            Console.WriteLine("\nEjercicio 11: Suma de elementos en array");
            int[] arraySuma = { 1, 2, 3, 4, 5 };
            SumaArray(arraySuma);

            Console.WriteLine("\nEjercicio 12: Media de elementos en array");
            int[] arrayMedia = { 10, 20, 30, 40, 50 };
            MediaArray(arrayMedia);

            Console.WriteLine("\nEjercicio 13: Rellenar array con números aleatorios");
            int[] arrayAleatorio = new int[10];
            RellenarArrayAleatorio(arrayAleatorio);
            Console.Write("Contenido del array aleatorio: ");
            foreach (int num in arrayAleatorio)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            Console.WriteLine("\nEjercicio 14: Buscar número en array");
            Console.Write("Introduce un número para buscar en el array aleatorio: ");
            int numBuscar = int.Parse(Console.ReadLine());
            Console.WriteLine(ExisteEnArray(numBuscar, arrayAleatorio) ? "El número existe en el array" : "El número no existe en el array");

            Console.WriteLine("\nEjercicio 15: Invertir elementos en array");
            int[] arrayInvertir = { 5, 10, 15, 20, 25 };
            int[] arrayInvertido = InvertirArray(arrayInvertir);
            Console.Write("Contenido del array invertido: ");
            foreach (int num in arrayInvertido)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            Console.WriteLine("\nEjercicio 16: Verificar si array es capicúa");
            int[] arrayCapicua = { 1, 2, 3, 2, 1 };
            Console.WriteLine(EsCapicua(arrayCapicua) ? "El array es capicúa" : "El array no es capicúa");

            Console.WriteLine("\nEjercicio 17: Mostrar contenido de array");
            int[] arrayMostrar = { 10, 20, 30, 40, 50 };
            MostrarArray(arrayMostrar);

            Console.WriteLine("\nEjercicio 18: Rellenar array aleatorio y calcular suma");
            Ejercicio18();

            Console.WriteLine("\nEjercicio 19: Rellenar array de números primos y encontrar el mayor");
            Ejercicio19();

            Console.WriteLine("\nEjercicio 20: Multiplicación de elementos de dos arrays");
            Ejercicio20();

            Console.WriteLine("\nEjercicio 21: Filtrar números que terminan en dígito");
            Ejercicio21();
        }



    }
}