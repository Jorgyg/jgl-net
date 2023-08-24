using System;

namespace ConsoleAplication5
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la edad: ");
            int edad = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el sexo (H/M): ");
            char sexo = char.ToUpper(Console.ReadKey().KeyChar);
            Console.ReadLine();
            Console.WriteLine();

            Console.Write("Ingrese el peso en kg: ");
            double peso = double.Parse(Console.ReadLine());

            Console.Write("Ingrese la altura en metros: ");
            double altura = double.Parse(Console.ReadLine());

            Persona persona1 = new Persona(nombre, edad, sexo, peso, altura);
            Persona persona2 = new Persona(nombre, edad, sexo);
            Persona persona3 = new Persona();

            Console.WriteLine("\nInformación de persona1:");
            MostrarInformacion(persona1);

            Console.WriteLine("\nInformación de persona2:");
            MostrarInformacion(persona2);

            Console.WriteLine("\nInformación de persona3:");
            MostrarInformacion(persona3);
        }

        static void MostrarInformacion(Persona persona)
        {
            Console.WriteLine(persona);
            int resultadoIMC = persona.CalcularIMC();

            switch (resultadoIMC)
            {
                case -1:
                    Console.WriteLine("Estado IMC: Debajo del peso ideal");
                    break;
                case 0:
                    Console.WriteLine("Estado IMC: Peso ideal");
                    break;
                case 1:
                    Console.WriteLine("Estado IMC: Sobrepeso");
                    break;
            }

            Console.WriteLine($"Es mayor de edad: {persona.EsMayorDeEdad()}");
        }
    }
    class Persona
    {
        private string nombre;
        private int edad;
        private string DNI;
        private char sexo;
        private double peso;
        private double altura;

        private const char SEXO_POR_DEFECTO = 'H';
        private const int IMC_DEBAJO_PESO_IDEAL = -1;
        private const int IMC_PESO_IDEAL = 0;
        private const int IMC_SOBREPESO = 1;

        public Persona()
        {
            nombre = "";
            edad = 0;
            DNI = GenerarDNI();
            sexo = SEXO_POR_DEFECTO;
            peso = 0;
            altura = 0;
        }

        public Persona(string nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.DNI = GenerarDNI();
            this.sexo = ComprobarSexo(sexo);
            this.peso = 0;
            this.altura = 0;
        }

        public Persona(string nombre, int edad, char sexo, double peso, double altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.DNI = GenerarDNI();
            this.sexo = ComprobarSexo(sexo);
            this.peso = peso;
            this.altura = altura;
        }

        public int CalcularIMC()
        {
            double imc = peso / (altura * altura);

            if (imc < 20)
            {
                return IMC_DEBAJO_PESO_IDEAL;
            }
            else if (imc >= 20 && imc <= 25)
            {
                return IMC_PESO_IDEAL;
            }
            else
            {
                return IMC_SOBREPESO;
            }
        }

        public bool EsMayorDeEdad()
        {
            return edad >= 18;
        }

        private char ComprobarSexo(char sexo)
        {
            if (sexo == 'H' || sexo == 'M')
            {
                return sexo;
            }
            else
            {
                return SEXO_POR_DEFECTO;
            }
        }

        private string GenerarDNI()
        {
            Random random = new Random();
            int numero = random.Next(10000000, 99999999);
            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            int indice = numero % 23;
            char letra = letras[indice];

            return numero.ToString() + letra;
        }

        public override string ToString()
        {
            return $"Nombre: {nombre}\nEdad: {edad}\nDNI: {DNI}\nSexo: {sexo}\nPeso: {peso}\nAltura: {altura}";
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public char Sexo
        {
            get { return sexo; }
            set { sexo = ComprobarSexo(value); }
        }

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }
    }

}