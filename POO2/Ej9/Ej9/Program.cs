using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Pelicula pelicula = new Pelicula("Pelicula de Accion", 120, 16, "Director 1");
            Cine cine = new Cine(pelicula, 8.5); // Precio de entrada

            Random random = new Random();

            for (int i = 0; i < 50; i++) // Simulamos 50 espectadores
            {
                string nombre = "Espectador" + i;
                int edad = random.Next(5, 70);
                double dinero = random.Next(10, 100);
                Espectador espectador = new Espectador(nombre, edad, dinero);

                cine.SentarEspectador(espectador);
            }

            cine.MostrarEstadoSala();
        }
    }

    class Pelicula
    {
        public string Titulo { get; }
        public int Duracion { get; }
        public int EdadMinima { get; }
        public string Director { get; }

        public Pelicula(string titulo, int duracion, int edadMinima, string director)
        {
            Titulo = titulo;
            Duracion = duracion;
            EdadMinima = edadMinima;
            Director = director;
        }
    }

    class Espectador
    {
        public string Nombre { get; }
        public int Edad { get; }
        public double Dinero { get; set; }

        public Espectador(string nombre, int edad, double dinero)
        {
            Nombre = nombre;
            Edad = edad;
            Dinero = dinero;
        }
    }

    class Asiento
    {
        public bool Ocupado { get; set; }
        public Espectador Espectador { get; set; }

        public Asiento()
        {
            Ocupado = false;
            Espectador = null;
        }
    }

    class Cine
    {
        private Pelicula peliculaActual;
        private double precioEntrada;
        private Asiento[,] asientos;

        public Cine(Pelicula pelicula, double precio)
        {
            peliculaActual = pelicula;
            precioEntrada = precio;
            asientos = new Asiento[8, 9];
            InicializarAsientos();
        }

        private void InicializarAsientos()
        {
            for (int fila = 0; fila < 8; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    asientos[fila, columna] = new Asiento();
                }
            }
        }

        public void SentarEspectador(Espectador espectador)
        {
            int fila = 0;
            int columna = 0;

            Random random = new Random();
            do
            {
                fila = random.Next(8);
                columna = random.Next(9);
            } while (asientos[fila, columna].Ocupado);

            if (espectador.Dinero >= precioEntrada && espectador.Edad >= peliculaActual.EdadMinima)
            {
                asientos[fila, columna].Espectador = espectador;
                asientos[fila, columna].Ocupado = true;
                espectador.Dinero -= precioEntrada;
            }
        }

        public void MostrarEstadoSala()
        {
            Console.WriteLine($"Película: {peliculaActual.Titulo}");
            Console.WriteLine("Estado de la sala:");

            for (int fila = 0; fila < 8; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    if (asientos[fila, columna].Ocupado)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("O ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

}