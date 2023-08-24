using System;

namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Libro libro1 = new Libro("978-0451450524", "Neuromancer", "William Gibson", 271);
            Libro libro2 = new Libro("978-0099464464", "1984", "George Orwell", 328);

            Console.WriteLine(libro1);
            Console.WriteLine(libro2);

            if (libro1.NumeroPaginas > libro2.NumeroPaginas)
            {
                Console.WriteLine("El libro con más páginas es: " + libro1.Titulo);
            }
            else if (libro1.NumeroPaginas < libro2.NumeroPaginas)
            {
                Console.WriteLine("El libro con más páginas es: " + libro2.Titulo);
            }
            else
            {
                Console.WriteLine("Los libros tienen la misma cantidad de páginas.");
            }
        }
    }

    class Libro
    {
        private string isbn;
        private string titulo;
        private string autor;
        private int numeroPaginas;

        public Libro(string isbn, string titulo, string autor, int numeroPaginas)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.numeroPaginas = numeroPaginas;
        }

        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public int NumeroPaginas
        {
            get { return numeroPaginas; }
            set { numeroPaginas = value; }
        }

        public override string ToString()
        {
            return $"El libro con ISBN {ISBN} creado por {Autor} tiene {NumeroPaginas} páginas.";
        }
    }
}
