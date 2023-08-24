using System;

namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                
                Console.WriteLine("¿Qué vehículo desea crear?");
                Console.WriteLine("1. Coche");
                Console.WriteLine("2. Moto");
                Console.WriteLine("0. Salir");
                int opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    Console.Write("Ingrese la matrícula del coche: ");
                    string matricula = Console.ReadLine();
                    Console.Write("Ingrese la marca del coche: ");
                    string marca = Console.ReadLine();
                    Console.Write("Ingrese el color del coche: ");
                    string color = Console.ReadLine();

                    if (compMatricula(matricula))
                    {
                        Coche coche = new Coche(matricula, marca, color);
                        AgregarRuedas(coche, 4);
                        coche.MostrarInfo();
                        coche.MostrarRuedas();
                    }
                    else
                    {
                        Console.WriteLine("Matrícula no válida.");
                    }
                }
                else if (opcion == 2)
                {
                    Console.Write("Ingrese la matrícula de la moto: ");
                    string matricula = Console.ReadLine();
                    Console.Write("Ingrese la marca de la moto: ");
                    string marca = Console.ReadLine();
                    Console.Write("Ingrese el color de la moto: ");
                    string color = Console.ReadLine();

                    if (compMatricula(matricula))
                    {
                        Moto moto = new Moto(matricula, marca, color);
                        AgregarRuedas(moto, 2);
                        moto.MostrarInfo();
                        moto.MostrarRuedas();
                    }
                    else
                    {
                        Console.WriteLine("Matrícula no válida.");
                    }
                }
            }


        }
        static public Boolean compMatricula(string matricula)
        {
            int contadorDigitos = 0;
            int contadorLetras = 0;

            for (int i = 0; i < matricula.Length; i++)
            {
                if (char.IsDigit(matricula[i]))
                {
                    contadorDigitos++;
                }
                else if (char.IsLetter(matricula[i]))
                {
                    contadorLetras++;
                }
                else
                {
                    return false; // Si no es ni letra ni dígito, la matrícula es inválida
                }
            }
            if (contadorDigitos == 4 && (contadorLetras == 2 || contadorLetras == 3))
            {
                return true;
            }

            return false;
        }
        static void AgregarRuedas(Vehiculo vehiculo, int ruedas)
        {
            for (int i = 0; i < ruedas; i++)
            {
                Console.Write($"Ingrese la marca de la rueda {i + 1}: ");
                string marca = Console.ReadLine();
                double diametro = -1;

                while (diametro < 0.4 || diametro > 4)
                {
                    Console.Write($"Ingrese el diámetro de la rueda {i + 1} (entre 0.4 y 4): ");
                    if (!double.TryParse(Console.ReadLine(), out diametro))
                    {
                        Console.WriteLine("¡Valor inválido! Por favor, ingrese un número.");
                    }
                    else if (diametro < 0.4 || diametro > 4)
                    {
                        Console.WriteLine("¡El diámetro debe estar entre 0.4 y 4!");
                    }
                }
                Rueda rueda = new Rueda(marca, diametro);
                vehiculo.AgregarRueda(rueda);
            }
        }
    }

    class Vehiculo
    {
        public string Matricula { get; }
        public string Marca { get; }
        public string Color { get; }
        public Rueda[] Ruedas { get; private set; }

        public Vehiculo(string matricula, string marca, string color)
        {
            Matricula = matricula;
            Marca = marca;
            Color = color;
        }
        public void AgregarRueda(Rueda rueda)
        {
            if (Ruedas == null)
            {
                Ruedas = new Rueda[4];
            }

            for (int i = 0; i < Ruedas.Length; i++)
            {
                if (Ruedas[i] == null)
                {
                    Ruedas[i] = rueda;
                    break;
                }
            }
        }
        public void MostrarInfo()
        {
            Console.WriteLine($"Matrícula: {Matricula}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Color: {Color}");
        }

        public void MostrarRuedas()
        {
            Console.WriteLine("Ruedas:");
            foreach (var rueda in Ruedas)
            {
                if (rueda != null)
                {
                    Console.WriteLine($"Marca: {rueda.Marca}, Diámetro: {rueda.Diametro}");
                }
            }
        }
    }

    class Rueda
    {
        public string Marca { get; }
        public double Diametro { get; }

        public Rueda(string marca, double diametro)
        {
            Marca = marca;
            Diametro = diametro;
        }
    }

    class Coche : Vehiculo
    {
        public Coche(string matricula, string marca, string color) : base(matricula, marca, color)
        {
         
        }
    }

    class Moto : Vehiculo
    {
        public Moto(string matricula, string marca, string color) : base(matricula, marca, color)
        {
          
        }
    }

}