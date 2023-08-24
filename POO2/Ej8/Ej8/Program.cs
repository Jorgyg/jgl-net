using System;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Aula aula = new Aula(1, 30, Materia.Matematicas);
            Profesor profesor = new Profesor("Profesor X", 40, Sexo.Masculino, Materia.Matematicas);
            Estudiante[] estudiantes = new Estudiante[30];

            for (int i = 0; i < estudiantes.Length; i++)
            {
                estudiantes[i] = new Estudiante($"Estudiante{i + 1}", 18, (Sexo)(i % 2), CalificacionAleatoria());
            }

            aula.AsignarProfesor(profesor);
            aula.AsignarEstudiantes(estudiantes);

            if (aula.PuedeDarClase())
            {
                Console.WriteLine("La clase puede ser impartida.");

                int aprobadosMasculinos = aula.ContarAprobados(Sexo.Masculino);
                int aprobadosFemeninos = aula.ContarAprobados(Sexo.Femenino);

                Console.WriteLine($"Aprobados masculinos: {aprobadosMasculinos}");
                Console.WriteLine($"Aprobados femeninos: {aprobadosFemeninos}");

                foreach (var estudiante in estudiantes)
                {
                    bool aprobado = estudiante.Calificacion >= 5.0;
                    Console.WriteLine($"Estudiante: {estudiante.Nombre}, Aprobado: {aprobado}");
                }
            }
            else
            {
                Console.WriteLine("La clase no puede ser impartida debido a las condiciones.");
            }
        }

        static double CalificacionAleatoria()
        {
            Random random = new Random();
            return random.Next(0, 11);
        }
    }

    enum Sexo
    {
        Masculino,
        Femenino
    }

    enum Materia
    {
        Matematicas,
        Filosofia,
        Fisica
    }

    class Estudiante
    {
        public string Nombre { get; }
        public int Edad { get; }
        public Sexo Sexo { get; }
        public double Calificacion { get; }

        public Estudiante(string nombre, int edad, Sexo sexo, double calificacion)
        {
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
            Calificacion = calificacion;
        }
    }

    class Profesor
    {
        public string Nombre { get; }
        public int Edad { get; }
        public Sexo Sexo { get; }
        public Materia Materia { get; }

        public Profesor(string nombre, int edad, Sexo sexo, Materia materia)
        {
            Nombre = nombre;
            Edad = edad;
            Sexo = sexo;
            Materia = materia;
        }

        public bool Disponible()
        {
            Random random = new Random();
            return random.NextDouble() > 0.2; 
        }

    }

    class Aula
    {
        private int identificador;
        private int numeroMaxEstudiantes;
        private Materia materiaDestinada;
        private Profesor profesor;
        private Estudiante[] estudiantes;

        public Aula(int identificador, int numeroMaxEstudiantes, Materia materiaDestinada)
        {
            this.identificador = identificador;
            this.numeroMaxEstudiantes = numeroMaxEstudiantes;
            this.materiaDestinada = materiaDestinada;
        }

        public void AsignarProfesor(Profesor profesor)
        {
            this.profesor = profesor;
        }

        public void AsignarEstudiantes(Estudiante[] estudiantes)
        {
            this.estudiantes = estudiantes;
        }

        public bool PuedeDarClase()
        {
            if (profesor == null || !profesor.Disponible() || profesor.Materia != materiaDestinada)
            {
                return false;
            }

            int numEstudiantes = estudiantes.Length;
            int aprobados = 0;

            foreach (Estudiante estudiante in estudiantes)
            {
                if (estudiante.Calificacion >= 5)
                    aprobados++;
            }

            return (aprobados * 2) > numEstudiantes;
        }

        public int ContarAprobados(Sexo sexo)
        {
            int count = 0;

            foreach (Estudiante estudiante in estudiantes)
            {
                if (estudiante.Sexo == sexo && estudiante.Calificacion >= 5)
                    count++;
            }

            return count;
        }
    }
}
