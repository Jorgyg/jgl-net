using System;

namespace ConsoleAplication5
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Pon la cantidad de contraseñas a generar: ");
            int cantidad = int.Parse(Console.ReadLine());

            Password[] passwords = new Password[cantidad];
            bool[] esFuerteArray = new bool[cantidad];

            Console.Write("Pon la longitud de las contraseñas: ");
            int longitud = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                passwords[i] = new Password(longitud);
                esFuerteArray[i] = passwords[i].EsFuerte();
            }

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"{passwords[i].GetContraseña()} {esFuerteArray[i]}");
            }
        }
    }

    class Password
    {
        private int longitud;
        private string contraseña;

        public Password()
        {
            longitud = 8;
            GenerarPassword();
        }

        public Password(int longitud)
        {
            this.longitud = longitud;
            GenerarPassword();
        }

        public bool EsFuerte()
        {
            int mayusculas = 0;
            int minusculas = 0;
            int numeros = 0;

            foreach (char caracter in contraseña)
            {
                if (char.IsUpper(caracter))
                {
                    mayusculas++;
                }
                else if (char.IsLower(caracter))
                {
                    minusculas++;
                }
                else if (char.IsDigit(caracter))
                {
                    numeros++;
                }
            }

            return mayusculas > 2 && minusculas > 1 && numeros > 5;
        }

        public void GenerarPassword()
        {
            Random random = new Random();
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            char[] passwordArray = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                passwordArray[i] = caracteres[random.Next(caracteres.Length)];
            }

            contraseña = new string(passwordArray);
        }

        public string GetContraseña()
        {
            return contraseña;
        }

        public int GetLongitud()
        {
            return longitud;
        }

        public void SetLongitud(int longitud)
        {
            this.longitud = longitud;
            GenerarPassword();
        }
    }
}
