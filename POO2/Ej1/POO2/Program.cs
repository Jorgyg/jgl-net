using System;

namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {

            Cuenta cuenta = new Cuenta("John Doe", 1000);
            Console.WriteLine(cuenta);

            cuenta.Ingresar(500);
            Console.WriteLine("Después de ingresar 500: " + cuenta);

            cuenta.Retirar(200);
            Console.WriteLine("Después de retirar 200: " + cuenta);

            cuenta.Retirar(2000);
            Console.WriteLine("Después de retirar 2000: " + cuenta);



        }
    }
    class Cuenta
    {
        // Atributos
        private string titular;
        private double cantidad;

        // Constructor con titular obligatorio y cantidad opcional
        public Cuenta(string titular, double cantidad = 0)
        {
            this.titular = titular;
            this.cantidad = cantidad;
        }

        // Propiedades
        public string Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        // Método para ingresar dinero a la cuenta
        public void Ingresar(double cantidad)
        {
            if (cantidad > 0)
            {
                this.cantidad += cantidad;
            }
        }

        // Método para retirar dinero de la cuenta
        public void Retirar(double cantidad)
        {
            if (cantidad > 0)
            {
                if (this.cantidad - cantidad < 0)
                {
                    this.cantidad = 0;
                }
                else
                {
                    this.cantidad -= cantidad;
                }
            }
        }

        // Método ToString para mostrar la información de la cuenta
        public override string ToString()
        {
            return $"Titular: {titular}, Cantidad: {cantidad}";
        }
    }
}

