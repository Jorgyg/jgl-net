using System;

namespace ConsoleAplication5
{

    class Program
    {
        static void Main(string[] args)
        {
            Serie[] series = new Serie[5];
            Videojuego[] videojuegos = new Videojuego[5];

            series[0] = new Serie("Serie 1", "Creador 1");
            series[1] = new Serie("Serie 2", 8, "Drama", "Creador 2");
            series[2] = new Serie("Serie 3", 5, "Comedia", "Creador 3");
            series[3] = new Serie("Serie 4", 4, "Acción", "Creador 4");
            series[4] = new Serie("Serie 5", 6, "Ciencia ficción", "Creador 5");

            videojuegos[0] = new Videojuego("Videojuego 1", 15);
            videojuegos[1] = new Videojuego("Videojuego 2", 10, "Aventura", "Compañía 1");
            videojuegos[2] = new Videojuego("Videojuego 3", 30, "Estrategia", "Compañía 2");
            videojuegos[3] = new Videojuego("Videojuego 4", 20, "Rol", "Compañía 3");
            videojuegos[4] = new Videojuego("Videojuego 5", 12, "Deporte", "Compañía 4");

            series[1].Entregar();
            series[3].Entregar();
            videojuegos[0].Entregar();
            videojuegos[3].Entregar();
            videojuegos[4].Entregar();

            int seriesEntregadas = ContarEntregados(series);
            int videojuegosEntregados = ContarEntregados(videojuegos);

            Console.WriteLine($"Número de series entregadas: {seriesEntregadas}");
            Console.WriteLine($"Número de videojuegos entregados: {videojuegosEntregados}");

            Serie serieMasTemporadas = ObtenerSerieMasTemporadas(series);
            Videojuego videojuegoMasHoras = ObtenerVideojuegoMasHoras(videojuegos);

            Console.WriteLine("Serie con más temporadas:");
            Console.WriteLine(serieMasTemporadas);

            Console.WriteLine("Videojuego con más horas estimadas:");
            Console.WriteLine(videojuegoMasHoras);
        }

        static int ContarEntregados(IEntregable[] entregables)
        {
            int count = 0;
            foreach (var entregable in entregables)
            {
                if (entregable.IsEntregado())
                {
                    count++;
                }
            }
            return count;
        }

        static Serie ObtenerSerieMasTemporadas(Serie[] series)
        {
            Serie maxSerie = series[0];
            foreach (Serie serie in series)
            {
                if (serie.getTemporadas() > maxSerie.getTemporadas())
                {
                    maxSerie = serie;
                }
            }
            return maxSerie;
        }

        static Videojuego ObtenerVideojuegoMasHoras(Videojuego[] videojuegos)
        {
            Videojuego maxVideojuego = videojuegos[0];
            foreach (Videojuego videojuego in videojuegos)
            {
                if (videojuego.getHoras() > maxVideojuego.getHoras())
                {
                    maxVideojuego = videojuego;
                }
            }
            return maxVideojuego;
        }

    }

    interface IEntregable
    {
        void Entregar();
        void Devolver();
        bool IsEntregado();
        int CompareTo(Object a);
    }

    class Serie : IEntregable
    {
        private string titulo;
        private int numeroTemporadas;
        private bool entregado;
        private string genero;
        private string creador;

        public Serie(string titulo, string creador)
        {
            this.titulo = titulo;
            this.creador = creador;
            this.numeroTemporadas = 3;
            this.entregado = false;
            this.genero = "";
        }

        public Serie(string titulo, int numeroTemporadas, string genero, string creador)
        {
            this.titulo = titulo;
            this.numeroTemporadas = numeroTemporadas;
            this.genero = genero;
            this.creador = creador;
            this.entregado = false;
        }

        public void Entregar()
        {
            entregado = true;
        }

        public void Devolver()
        {
            entregado = false;
        }

        public int getTemporadas()
        {
            return numeroTemporadas;
        }
        public bool IsEntregado()
        {
            return entregado;
        }

        public int CompareTo(Object a)
        {
            if (a is Serie)
            {
                Serie serie = (Serie)a;
                return this.numeroTemporadas.CompareTo(serie.numeroTemporadas);
            }
            return 0;
        }

        public override string ToString()
        {
            return $"Título: {titulo}, Número de temporadas: {numeroTemporadas}, " +
                   $"Entregado: {entregado}, Género: {genero}, Creador: {creador}";
        }
    }

    class Videojuego : IEntregable
    {
        private string titulo;
        private int horasEstimadas;
        private bool entregado;
        private string genero;
        private string compania;

        public Videojuego(string titulo, int horasEstimadas)
        {
            this.titulo = titulo;
            this.horasEstimadas = horasEstimadas;
            this.entregado = false;
            this.genero = "";
            this.compania = "";
        }

        public Videojuego(string titulo, int horasEstimadas, string genero, string compania)
        {
            this.titulo = titulo;
            this.horasEstimadas = horasEstimadas;
            this.genero = genero;
            this.compania = compania;
            this.entregado = false;
        }

        public void Entregar()
        {
            entregado = true;
        }

        public void Devolver()
        {
            entregado = false;
        }
        
        public int getHoras()
        {
            return horasEstimadas;
        }

        public bool IsEntregado()
        {
            return entregado;
        }

        public int CompareTo(Object a)
        {
            if (a is Videojuego)
            {
                Videojuego videojuego = (Videojuego)a;
                return this.horasEstimadas.CompareTo(videojuego.horasEstimadas);
            }
            return 0;
        }

        public override string ToString()
        {
            return $"Título: {titulo}, Horas estimadas: {horasEstimadas}, " +
                   $"Entregado: {entregado}, Género: {genero}, Compañía: {compania}";
        }
    }

}
