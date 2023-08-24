using System;

namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Electrodomestico[] electrodomesticos = new Electrodomestico[10];
            electrodomesticos[0] = new Electrodomestico(150, "negro", 'A', 20);
            electrodomesticos[1] = new Lavadora(6, 200, "blanco", 'B', 35);
            electrodomesticos[2] = new Television(50, true, 300, "gris", 'C', 40);
            electrodomesticos[3] = new Electrodomestico(120, "azul", 'E', 10);
            electrodomesticos[4] = new Lavadora(7, 180);
            electrodomesticos[5] = new Television();
            electrodomesticos[6] = new Lavadora(8, 230, "rojo", 'F', 45);
            electrodomesticos[7] = new Television(42, true, 400, "negro", 'A', 55);
            electrodomesticos[8] = new Lavadora(5, 170);
            electrodomesticos[9] = new Electrodomestico(90, 10);

            double totalElectrodomesticos = 0;
            double totalLavadoras = 0;
            double totalTelevisiones = 0;

            foreach (Electrodomestico electrodomestico in electrodomesticos)
            {
                if (electrodomestico is Lavadora)
                {
                    totalLavadoras += electrodomestico.PrecioFinal();
                }
                else if (electrodomestico is Television)
                {
                    totalTelevisiones += electrodomestico.PrecioFinal();
                }

                totalElectrodomesticos += electrodomestico.PrecioFinal();
            }

            Console.WriteLine($"Precio total de electrodomésticos: {totalElectrodomesticos}");
            Console.WriteLine($"Precio total de lavadoras: {totalLavadoras}");
            Console.WriteLine($"Precio total de televisiones: {totalTelevisiones}");
        }
    }
    class Electrodomestico
    {
        protected double precioBase;
        protected string color;
        protected char consumoEnergetico;
        protected double peso;

        public const string COLOR_DEFECTO = "blanco";
        public const char CONSUMO_DEFECTO = 'F';
        public const double PRECIO_BASE_DEFECTO = 100;
        public const double PESO_DEFECTO = 5;

        public const string COLORES_PERMITIDOS = "blanco negro rojo azul gris";

        public Electrodomestico()
        {
            color = COLOR_DEFECTO;
            consumoEnergetico = CONSUMO_DEFECTO;
            precioBase = PRECIO_BASE_DEFECTO;
            peso = PESO_DEFECTO;
        }

        public Electrodomestico(double precioBase, double peso)
        {
            this.precioBase = precioBase;
            this.peso = peso;
            color = COLOR_DEFECTO;
            consumoEnergetico = CONSUMO_DEFECTO;
        }

        public Electrodomestico(double precioBase, string color, char consumoEnergetico, double peso)
        {
            this.precioBase = precioBase;
            this.color = ComprobarColor(color);
            this.consumoEnergetico = ComprobarConsumoEnergetico(consumoEnergetico);
            this.peso = peso;
        }

        public double PrecioFinal()
        {
            double precio = precioBase;

            switch (consumoEnergetico)
            {
                case 'A':
                    precio += 100;
                    break;
                case 'B':
                    precio += 80;
                    break;
                case 'C':
                    precio += 60;
                    break;
                case 'D':
                    precio += 50;
                    break;
                case 'E':
                    precio += 30;
                    break;
                case 'F':
                    precio += 10;
                    break;
            }

            if (peso >= 0 && peso < 20)
            {
                precio += 10;
            }
            else if (peso >= 20 && peso < 50)
            {
                precio += 50;
            }
            else if (peso >= 50 && peso < 80)
            {
                precio += 80;
            }
            else if (peso >= 80)
            {
                precio += 100;
            }

            return precio;
        }

        private char ComprobarConsumoEnergetico(char letra)
        {
            if (letra >= 'A' && letra <= 'F')
            {
                return letra;
            }
            return CONSUMO_DEFECTO;
        }

        private string ComprobarColor(string color)
        {
            string colorMinusculas = color.ToLower();
            if (COLORES_PERMITIDOS.Contains(colorMinusculas))
            {
                return colorMinusculas;
            }
            return COLOR_DEFECTO;
        }

        public override string ToString()
        {
            return $"Precio base: {precioBase}, Color: {color}, Consumo: {consumoEnergetico}, Peso: {peso}";
        }
    }

    class Lavadora : Electrodomestico
    {
        private int carga;

        public const int CARGA_DEFECTO = 5;

        public Lavadora() : base()
        {
            carga = CARGA_DEFECTO;
        }

        public Lavadora(double precioBase, double peso) : base(precioBase, peso)
        {
            carga = CARGA_DEFECTO;
        }

        public Lavadora(int carga, double precioBase, string color, char consumoEnergetico, double peso) :
            base(precioBase, color, consumoEnergetico, peso)
        {
            this.carga = carga;
        }

        public int GetCarga()
        {
            return carga;
        }

        public new double PrecioFinal()
        {
            double precio = base.PrecioFinal();

            if (carga > 30)
            {
                precio += 50;
            }

            return precio;
        }
    }

    class Television : Electrodomestico
    {
        private int resolucion;
        private bool sintonizadorTDT;

        public const int RESOLUCION_DEFECTO = 20;
        public const bool SINTONIZADOR_DEFECTO = false;

        public Television() : base()
        {
            resolucion = RESOLUCION_DEFECTO;
            sintonizadorTDT = SINTONIZADOR_DEFECTO;
        }

        public Television(double precioBase, double peso) : base(precioBase, peso)
        {
            resolucion = RESOLUCION_DEFECTO;
            sintonizadorTDT = SINTONIZADOR_DEFECTO;
        }

        public Television(int resolucion, bool sintonizadorTDT, double precioBase, string color, char consumoEnergetico, double peso) :
            base(precioBase, color, consumoEnergetico, peso)
        {
            this.resolucion = resolucion;
            this.sintonizadorTDT = sintonizadorTDT;
        }

        public int GetResolucion()
        {
            return resolucion;
        }

        public bool TieneSintonizadorTDT()
        {
            return sintonizadorTDT;
        }

        public new double PrecioFinal()
        {
            double precio = base.PrecioFinal();

            if (resolucion > 40)
            {
                precio *= 1.30;
            }

            if (sintonizadorTDT)
            {
                precio += 50;
            }

            return precio;
        }
    }

}
