using System;
using System.Runtime.ConstrainedExecution;

namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Titular titular = CrearTitular(); // Crear titular fuera del bucle
            Console.WriteLine("¿Qué vehículo desea crear?");
            Console.WriteLine("1. Coche");
            Console.WriteLine("2. Moto");
            Console.WriteLine("3. Camión");
            Console.WriteLine("0. Salir");

            int opcion = int.Parse(Console.ReadLine());

            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        CrearCoche(titular);
                        CrearConductor(titular, "coche");
                        break;
                    case 2:
                        CrearMoto(titular);
                        CrearConductor(titular, "moto");
                        break;
                    case 3:
                        CrearCamion(titular);
                        CrearConductor(titular, "camion");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                Console.WriteLine("¿Qué vehículo desea crear?");
                Console.WriteLine("1. Coche");
                Console.WriteLine("2. Moto");
                Console.WriteLine("3. Camión");
                Console.WriteLine("0. Salir");
                opcion = int.Parse(Console.ReadLine());
            }
            
        }

        static Titular CrearTitular()
        {
            // Lógica para crear un titular y retornarlo
            Console.WriteLine("Nombre del titular: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Apellidos del titular: ");
            string apellidos = Console.ReadLine();
            Console.WriteLine("Fecha de nacimiento del titular (dd/mm/yyyy): ");
            DateTime dataN = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.WriteLine("ID de la licencia: ");
            int ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Tipo de licencia: ");
            string tipoL = Console.ReadLine();
            Console.WriteLine("Data de caducidad del carnet (dd/mm/yyyy): ");
            DateTime dataC = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("¿Tiene seguro? (Si/No): ");
            bool tieneSeguro = Console.ReadLine().ToLower() == "si";
            Console.Write("¿Tiene garaje propio? (Si/No): ");
            bool tieneGaraje = Console.ReadLine().ToLower() == "si";

            Licencia licencia = new Licencia(ID, tipoL, nombre + " " + apellidos, dataC);
            Titular titular = new Titular(nombre, apellidos, dataN, licencia, tieneSeguro, tieneGaraje);

            return titular;
        }

        static Conductor CrearConductor(Titular titular, string veiculo)
        {
            Console.Write("¿El titular será el conductor? (Si/No): ");
            bool mismoConductor = Console.ReadLine().ToLower() == "si";

            if (mismoConductor)
            {
                if (titular.Licencia.PermisoConducir(titular.getLicencia(), veiculo))
                {
                    return new Conductor(titular.Nombre, titular.Apellidos, titular.DataNacimiento, titular.Licencia);
                }
                else
                {
                    Console.WriteLine("El titular no tiene el permiso de conducir adecuado.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Datos del conductor:");
                Console.WriteLine("Nombre del conductor: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Apellidos del conductor: ");
                string apellidos = Console.ReadLine();
                Console.WriteLine("Fecha de nacimiento del conductor (dd/mm/yyyy): ");
                DateTime dataN = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                Console.WriteLine("ID de la licencia del conductor: ");
                int ID = int.Parse(Console.ReadLine());
                Console.WriteLine("Tipo de licencia del conductor: ");
                string tipoL = Console.ReadLine();
                Console.WriteLine("Data de caducidad del carnet del conductor (dd/mm/yyyy): ");
                DateTime dataC = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Licencia licencia = new Licencia(ID, tipoL, nombre + " " + apellidos, dataC);
                return new Conductor(nombre, apellidos, dataN, licencia);
            }
        }

        static void CrearCoche(Titular titular)
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

        static void CrearMoto(Titular titular)
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

        static void CrearCamion(Titular titular)
        {
            Console.Write("Ingrese la matrícula del camión: ");
            string matricula = Console.ReadLine();
            Console.Write("Ingrese la marca del camión: ");
            string marca = Console.ReadLine();
            Console.Write("Ingrese el color del camión: ");
            string color = Console.ReadLine();

            if (compMatricula(matricula))
            {
                Camion camion = new Camion(matricula, marca, color);
                AgregarRuedas(camion, 6);
                camion.MostrarInfo();
                camion.MostrarRuedas();
            }
            else
            {
                Console.WriteLine("Matrícula no válida.");
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

    class Camion : Vehiculo
    {
        public Camion(string matricula, string marca, string color) : base(matricula, marca, color)
        {

        }
    }

    class Persona
    {
        public string Nombre { get; }
        public string Apellidos { get; }
        public DateTime DataNacimiento { get; }
        public Licencia Licencia { get; }

        public Persona(string nombre, string apellidos, DateTime dataNacimiento, Licencia licencia)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            DataNacimiento = dataNacimiento;
            Licencia = licencia;
        }

        public string getLicencia()
        {
            return Licencia.TipoLicencia;
        }
    }

    class Licencia
    {
        public int ID { get; }
        public string TipoLicencia { get; }
        public string NombreC { get; }
        public DateTime DataCaducidad { get; }

        public Licencia(int id, string tipoLicencia, string nombreC, DateTime dataCaducidad)
        {
            ID = id;
            TipoLicencia = tipoLicencia;
            NombreC = nombreC;
            DataCaducidad = dataCaducidad;
        }

        public bool PermisoConducir(string tipoLicencia, string tipoVehiculo)
        {

            // Convertir el tipo de vehículo a minúsculas
            tipoVehiculo = tipoVehiculo.ToLower();

            // Verificar si el titular tiene el permiso adecuado para el tipo de vehículo
            if (tipoLicencia == "b" && tipoVehiculo == "coche")
            {
                return true;
            }
            else if(tipoLicencia == "a" && tipoVehiculo == "moto")
            {
                return true;
            }
            else if (tipoLicencia == "c" && tipoVehiculo == "camion")
            {
                return true;
            }

            return false; 
        }
    }
    

    class Conductor : Persona
    {
        public Conductor(string nombre, string apellidos, DateTime dataNacimiento, Licencia licencia) : base(nombre, apellidos, dataNacimiento, licencia) { }
    }

    class Titular : Persona
    {
        public bool TieneSeguro { get; }
        public bool TieneGaraje { get; }

        public Titular(string nombre, string apellidos, DateTime dataNacimiento, Licencia licencia, bool tieneSeguro, bool tieneGaraje) : base(nombre, apellidos, dataNacimiento, licencia)
        {
            TieneSeguro = tieneSeguro;
            TieneGaraje = tieneGaraje;
        }

      
    }
}
