using System;

namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 1");
            Console.WriteLine("");

            // Ejercicio 1
            Alumno alumno = new Alumno("Juan", 20);
            alumno.ImprimirDatos();
            alumno.MensajeMayorEdad();


            // Ejercicio 2
            Console.WriteLine("");
            Console.WriteLine("Ejercicio 2");
            Console.WriteLine("");
            Empleado empleado = new Empleado("Ana", 3500);
            empleado.ImprimirDatos();
            empleado.MensajeImpuestos();

            // Ejercicio 3
            Console.WriteLine("");
            Console.WriteLine("Ejercicio 3");
            Console.WriteLine("");
            Operaciones operaciones = new Operaciones(10, 5);
            operaciones.ImprimirResultados();

            // Ejercicio 4
            Console.WriteLine("");
            Console.WriteLine("Ejercicio 4");
            Console.WriteLine("");
            PruebaPersona.main();

            // Ejercicio 5
            Console.WriteLine("");
            Console.WriteLine("Ejercicio 5");
            Console.WriteLine("");
            Libro libro = new Libro();
            libro.SetTitulo("El Señor de los Anillos");
            libro.SetAutor("J.R.R. Tolkien");
            libro.SetUbicacion("Estantería A");
            libro.MostrarDatos();

            // Ejercicio 6
            Console.WriteLine("");
            Console.WriteLine("Ejercicio 6");
            Console.WriteLine("");
            Coche coche = new Coche();
            coche.Marca = "Toyota";
            coche.Modelo = "Corolla";
            coche.Cilindrada = 1600;
            coche.Potencia = 120.5;
            coche.MostrarDatos();

            // Ejercicio 7
            Console.WriteLine("");
            Console.WriteLine("Ejercicio 7");
            Console.WriteLine("");
            Persona persona1 = new Persona();
            Persona persona2 = new Persona("María", 25, "12345678X", Persona.Genero.Mujer);
            Persona persona3 = new Persona("Carlos", 30, "87654321Y", Persona.Genero.Hombre, 75, 180);
            persona1.MostrarDatos();
            persona2.MostrarDatos();
            persona3.MostrarDatos();

            // Ejercicio 8
            Console.WriteLine("");
            Console.WriteLine("Ejercicio 8");
            Console.WriteLine("");
            Password password1 = new Password();
            Password password2 = new Password(10);
            password1.MostrarPassword();
            password2.MostrarPassword();

            // Ejercicio 9
            Console.WriteLine("");
            Console.WriteLine("Ejercicio 9");
            Console.WriteLine("");
            Electrodomestico electrodomestico1 = new Electrodomestico();
            Electrodomestico electrodomestico2 = new Electrodomestico(300, 10);
            Electrodomestico electrodomestico3 = new Electrodomestico(200, "rojo", "D", 5);
            electrodomestico1.MostrarDatos();
            electrodomestico2.MostrarDatos();
            electrodomestico3.MostrarDatos();

            // Ejercicio 10
            Console.WriteLine("");
            Console.WriteLine("Ejercicio 10");
            Console.WriteLine("");
            Serie serie1 = new Serie();
            Serie serie2 = new Serie("Game of Thrones", "George R.R. Martin");
            Serie serie3 = new Serie("Stranger Things", 5, "Duffer Brothers", Serie.Genero.Fantasia);
            serie1.MostrarDatos();
            serie2.MostrarDatos();
            serie3.MostrarDatos();
        }
    }

    class Alumno
    {
        private string nombre;
        private int edad;

        public Alumno(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Edad: {edad}");
        }

        public void MensajeMayorEdad()
        {
            if (edad >= 18)
            {
                Console.WriteLine("Es mayor de edad.");
            }
            else
            {
                Console.WriteLine("No es mayor de edad.");
            }
        }
    }

    class Empleado
    {
        private string nombre;
        private double sueldo;

        public Empleado(string nombre, double sueldo)
        {
            this.nombre = nombre;
            this.sueldo = sueldo;
        }

        public void ImprimirDatos()
        {
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Sueldo: {sueldo}");
        }

        public void MensajeImpuestos()
        {
            if (sueldo > 3000)
            {
                Console.WriteLine("Debe pagar impuestos.");
            }
            else
            {
                Console.WriteLine("No debe pagar impuestos.");
            }
        }
    }

    class Operaciones
    {
        private int num1;
        private int num2;

        public Operaciones(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        public void ImprimirResultados()
        {
            Console.WriteLine($"Suma: {Sumar()}");
            Console.WriteLine($"Resta: {Restar()}");
            Console.WriteLine($"Multiplicación: {Multiplicar()}");
            Console.WriteLine($"División: {Dividir()}");
        }

        private int Sumar()
        {
            return num1 + num2;
        }

        private int Restar()
        {
            return num1 - num2;
        }

        private int Multiplicar()
        {
            return num1 * num2;
        }

        private double Dividir()
        {
            if (num2 != 0)
            {
                return (double)num1 / num2;
            }
            else
            {
                return double.NaN;
            }
        }
    }

    class Persona
    {
        public enum Genero { Hombre, Mujer }

        private string nombre;
        private int edad;
        private string DNI;
        private Genero sexo;
        private double peso;
        private double altura;

        public Persona()
        {
            nombre = "";
            edad = 0;
            DNI = GenerarDNI();
            sexo = Genero.Hombre;
            peso = 0;
            altura = 0;
        }

        public Persona(string nombre, int edad, string DNI, Genero sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.DNI = DNI;
            this.sexo = sexo;
            peso = 0;
            altura = 0;
        }

        public Persona(string nombre, int edad, string DNI, Genero sexo, double peso, double altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.DNI = DNI;
            this.sexo = sexo;
            this.peso = peso;
            this.altura = altura;
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Edad: {edad}");
            Console.WriteLine($"DNI: {DNI}");
            Console.WriteLine($"Sexo: {sexo}");
            Console.WriteLine($"Peso: {peso} kg");
            Console.WriteLine($"Altura: {altura} cm");
        }

        private string GenerarDNI()
        {
            Random rnd = new Random();
            string dni = "";
            for (int i = 0; i < 8; i++)
            {
                dni += rnd.Next(0, 10);
            }
            dni += (char)rnd.Next('A', 'Z' + 1);
            return dni;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public void Saludar()
        {
            Console.WriteLine($"Hola, soy {nombre}");
        }
    }

    // Continuación del Ejercicio 5
    class Libro
    {
        private string autor;
        private string titulo;
        private string ubicacion;

        public void SetAutor(string autor)
        {
            this.autor = autor;
        }

        public void SetTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public void SetUbicacion(string ubicacion)
        {
            this.ubicacion = ubicacion;
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Título: {titulo}");
            Console.WriteLine($"Ubicación: {ubicacion}");
        }
    }

    // Continuación del Ejercicio 6
    class Coche
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Cilindrada { get; set; }
        public double Potencia { get; set; }

        public void MostrarDatos()
        {
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Cilindrada: {Cilindrada}");
            Console.WriteLine($"Potencia: {Potencia}");
        }
    }

    class Password
    {
        private int longitud;
        private string contrasenia;

        public Password()
        {
            longitud = 8;
            contrasenia = GenerarContrasenia();
        }

        public Password(int longitud)
        {
            this.longitud = longitud;
            contrasenia = GenerarContrasenia();
        }

        public void MostrarPassword()
        {
            Console.WriteLine($"Contraseña: {contrasenia}");
        }

        private string GenerarContrasenia()
        {
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            string contrasenia = "";
            for (int i = 0; i < longitud; i++)
            {
                contrasenia += caracteres[rnd.Next(caracteres.Length)];
            }
            return contrasenia;
        }
    }

    class Electrodomestico
    {
        public enum Color { Blanco, Negro, Rojo, Azul, Gris }
        public enum ConsumoEnergetico { A, B, C, D, E, F }

        private double precioBase;
        private Color color;
        private ConsumoEnergetico consumoEnergetico;
        private double peso;

        public Electrodomestico()
        {
            precioBase = 100;
            color = Color.Blanco;
            consumoEnergetico = ConsumoEnergetico.F;
            peso = 5;
        }

        public Electrodomestico(double precioBase, double peso)
        {
            this.precioBase = precioBase;
            this.peso = peso;
            color = Color.Blanco;
            consumoEnergetico = ConsumoEnergetico.F;
        }

        public Electrodomestico(double precioBase, string color, string consumoEnergetico, double peso)
        {
            this.precioBase = precioBase;
            this.peso = peso;
            SetColor(color);
            SetConsumoEnergetico(consumoEnergetico);
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Precio base: {precioBase}€");
            Console.WriteLine($"Color: {color}");
            Console.WriteLine($"Consumo energético: {consumoEnergetico}");
            Console.WriteLine($"Peso: {peso} kg");
        }

        public void SetColor(string color)
        {
            switch (color.ToLower())
            {
                case "negro":
                    this.color = Color.Negro;
                    break;
                case "rojo":
                    this.color = Color.Rojo;
                    break;
                case "azul":
                    this.color = Color.Azul;
                    break;
                case "gris":
                    this.color = Color.Gris;
                    break;
                default:
                    this.color = Color.Blanco;
                    break;
            }
        }

        public void SetConsumoEnergetico(string consumoEnergetico)
        {
            switch (consumoEnergetico.ToUpper())
            {
                case "A":
                    this.consumoEnergetico = ConsumoEnergetico.A;
                    break;
                case "B":
                    this.consumoEnergetico = ConsumoEnergetico.B;
                    break;
                case "C":
                    this.consumoEnergetico = ConsumoEnergetico.C;
                    break;
                case "D":
                    this.consumoEnergetico = ConsumoEnergetico.D;
                    break;
                case "E":
                    this.consumoEnergetico = ConsumoEnergetico.E;
                    break;
                case "F":
                    this.consumoEnergetico = ConsumoEnergetico.F;
                    break;
                default:
                    this.consumoEnergetico = ConsumoEnergetico.F;
                    break;
            }
        }
    }

    class Serie
    {
        public enum Genero { Accion, Comedia, Drama, Fantasia, Terror }

        private string titulo;
        private int numTemporadas;
        private bool entregado;
        private string genero;
        private string creador;

        public Serie()
        {
            titulo = "";
            numTemporadas = 3;
            entregado = false;
            genero = Genero.Drama.ToString();
            creador = "";
        }

        public Serie(string titulo, string creador)
        {
            this.titulo = titulo;
            this.creador = creador;
            numTemporadas = 3;
            entregado = false;
            genero = Genero.Drama.ToString();
        }

        public Serie(string titulo, int numTemporadas, string creador, Genero genero)
        {
            this.titulo = titulo;
            this.numTemporadas = numTemporadas;
            entregado = false;
            this.genero = genero.ToString();
            this.creador = creador;
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Título: {titulo}");
            Console.WriteLine($"Número de temporadas: {numTemporadas}");
            Console.WriteLine($"Entregado: {entregado}");
            Console.WriteLine($"Género: {genero}");
            Console.WriteLine($"Creador: {creador}");
        }
    }

    class PruebaPersona
    {
        public static void main()
        {
            Persona persona1 = new Persona();
            Persona persona2 = new Persona();

            persona1.SetNombre("Juan");
            persona2.SetNombre("María");

            persona1.Saludar();
            persona2.Saludar();
        }
    }
}