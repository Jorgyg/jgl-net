using System;
using System.Runtime.ConstrainedExecution;

namespace ConsoleApplication5
{
    class Program
    {
        static List<Persona> personas = new List<Persona>();
        static List<Vehiculo> vehiculos = new List<Vehiculo>();

        static void Main(string[] args)
        {
            int opcion = -1;
            while (opcion != 0)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Crear Persona");
                Console.WriteLine("2. Crear Vehiculo");
                Console.WriteLine("0. Salir");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CrearPersona();
                        break;
                    case 2:
                        CrearVehiculo();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } 
        }

        static void CrearPersona()
        {
            Console.Write("¿Crear Titular o Conductor? (T/C): ");
            string tipoPersona = Console.ReadLine().ToLower();

            Console.WriteLine("Datos de la persona:");
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Apellidos: ");
            string apellidos = Console.ReadLine();
            Console.WriteLine("Fecha de nacimiento (dd/mm/yyyy): ");
            DateTime dataN = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.WriteLine("ID de la licencia: ");
            int ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Tipo de licencia: ");
            string tipoL = Console.ReadLine();
            Console.WriteLine("Data de caducidad del carnet (dd/mm/yyyy): ");
            DateTime dataC = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Licencia licencia = new Licencia(ID, tipoL, nombre + " " + apellidos, dataC);
            Persona persona;

            if (tipoPersona == "t")
            {
                Console.Write("¿Tiene seguro? (Si/No): ");
                bool tieneSeguro = Console.ReadLine().ToLower() == "si";
                Console.Write("¿Tiene garaje propio? (Si/No): ");
                bool tieneGaraje = Console.ReadLine().ToLower() == "si";
                persona = new Titular(nombre, apellidos, dataN, licencia, tieneSeguro, tieneGaraje);
            }
            else if (tipoPersona == "c")
            {
                persona = new Conductor(nombre, apellidos, dataN, licencia);
            }
            else
            {
                Console.WriteLine("Tipo de persona no válido.");
                return;
            }

            personas.Add(persona);
            Console.WriteLine("Persona creada exitosamente.");
        }

        static void CrearVehiculo()
        {
            if (personas.Count == 0)
            {
                Console.WriteLine("¡No se han creado personas aún!");
                return;
            }

            Console.WriteLine("Seleccione el titular del vehículo:");

            for (int i = 0; i < personas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {personas[i].Nombre} {personas[i].Apellidos}");
            }

            int seleccion = int.Parse(Console.ReadLine()) - 1;

            if (seleccion < 0 || seleccion >= personas.Count)
            {
                Console.WriteLine("Selección inválida.");
                return;
            }

            Titular titular = personas[seleccion] as Titular;

            Console.WriteLine("¿Qué vehículo desea crear?");
            Console.WriteLine("1. Coche");
            Console.WriteLine("2. Moto");
            Console.WriteLine("3. Camión");
            int opcion = int.Parse(Console.ReadLine());

            Vehiculo vehiculo = null;

            switch (opcion)
            {
                case 1:
                    vehiculo = CrearCoche(titular);
                    break;
                case 2:
                    vehiculo = CrearMoto(titular);
                    break;
                case 3:
                    vehiculo = CrearCamion(titular);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (vehiculo != null)
            {
                vehiculo.Titular = titular;
                vehiculos.Add(vehiculo);
                Console.WriteLine("Vehículo creado exitosamente.");
            }
        }

        static Coche CrearCoche(Titular titular)
        {
            Console.Write("Ingrese la matrícula del coche: ");
            string matricula = Console.ReadLine();
            Console.Write("Ingrese la marca del coche: ");
            string marca = Console.ReadLine();
            Console.Write("Ingrese el color del coche: ");
            string color = Console.ReadLine();

            if (compMatricula(matricula))
            {
                Coche coche = new Coche(matricula, marca, color, titular);
                AgregarRuedas(coche, 4);
                return coche;
            }
            else
            {
                Console.WriteLine("Matrícula no válida.");
                return null;
            }
        }

        static Moto CrearMoto(Titular titular)
        {
            Console.Write("Ingrese la matrícula de la moto: ");
            string matricula = Console.ReadLine();
            Console.Write("Ingrese la marca de la moto: ");
            string marca = Console.ReadLine();
            Console.Write("Ingrese el color de la moto: ");
            string color = Console.ReadLine();

            if (compMatricula(matricula))
            {
                Moto moto = new Moto(matricula, marca, color, titular);
                AgregarRuedas(moto, 2);
                return moto;
            }
            else
            {
                Console.WriteLine("Matrícula no válida.");
                return null;
            }
        }

        static Camion CrearCamion(Titular titular)
        {
            Console.Write("Ingrese la matrícula del camión: ");
            string matricula = Console.ReadLine();
            Console.Write("Ingrese la marca del camión: ");
            string marca = Console.ReadLine();
            Console.Write("Ingrese el color del camión: ");
            string color = Console.ReadLine();

            if (compMatricula(matricula))
            {
                Camion camion = new Camion(matricula, marca, color, titular);
                AgregarRuedas(camion, 6);
                return camion;
            }
            else
            {
                Console.WriteLine("Matrícula no válida.");
                return null;
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
        public Titular Titular { get; set; }
        public Vehiculo(string matricula, string marca, string color, Titular titular)
        {
            Matricula = matricula;
            Marca = marca;
            Color = color;
            Titular = titular;
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
        public Coche(string matricula, string marca, string color, Titular titular) : base(matricula, marca, color, titular)
        {

        }
    }

    class Moto : Vehiculo
    {
        public Moto(string matricula, string marca, string color, Titular titular) : base(matricula, marca, color, titular)
        {
    
        }
    }

    class Camion : Vehiculo
    {
        public Camion(string matricula, string marca, string color, Titular titular) : base(matricula, marca, color, titular)
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
            else if (tipoLicencia == "a" && tipoVehiculo == "moto")
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
