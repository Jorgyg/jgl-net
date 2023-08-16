using System;

namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex1();
            Ex2();
            Ex3();
            Ex4();
            Ex5();
            Ex6();
            Ex7();
            Ex8();
            Ex9();
            Ex10();
            Ex11();
            Ex12();
            Ex13();
            Ex14();
            Ex15();
            Ex16();
            Ex17();
            Ex18();
            Ex19();
            Ex20();
            Ex21();
            Ex22();
            Ex23();

        }
        static void Ex1()
        {
            int num1 = 5;
            int num2 = 10;
            int num3 = 3;
            int suma = num1 + num2 + num3;
            Console.WriteLine(suma);
        }
        static void Ex2()
        {
            Console.Write("Dime tu nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Dime el nombre de una ciudad: ");
            string ciudad = Console.ReadLine();
            Console.WriteLine($"Hola {nombre} bienvenido/a a {ciudad}");
        }
        static void Ex3()
        {
            Console.Write("Dime tu nombre: ");
            string tuNombre = Console.ReadLine();
            Console.Write("Dime tu edad: ");
            int tuEdad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($" Te llamas {tuNombre} y tienes {tuEdad} años");
        }
        static void Ex4()
        {
            Console.Write("Dime un numero: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Dime otro numero: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            if(num1 > num2)
            {
                Console.WriteLine("El primer numero es mayor");
            } else if (num1 < num2)
            {
                Console.WriteLine("El segundo numero es mayor");
            } else
            {
                Console.WriteLine("Los dos numeros son iguales");
            }
        }
        static void Ex5()
        {
            Console.Write("Dime el nombre de un dia de la semana: ");
            string diaSemana = Console.ReadLine();
            if (diaSemana.ToLower() == "sabado" || diaSemana.ToLower() == "domingo")
            {
                Console.WriteLine("Es fin de semana");
            }
            else if (diaSemana.ToLower() == "lunes" || diaSemana.ToLower() == "martes" || diaSemana.ToLower() == "miercoles" || diaSemana.ToLower() == "jueves" || diaSemana.ToLower() == "viernes")
            {
                Console.WriteLine(" No es fin de semana");
            }
            else
            {
                Console.WriteLine("Dia no reconocido");
            }
        }
        static void Ex6()
        {
            Console.Write("Pon el precio del producto: ");
            double precioProducto = Convert.ToDouble(Console.ReadLine());
            Console.Write("Pon la forma de pago (efectivo o tarjeta): ");
            string formaPago = Console.ReadLine();
            if (formaPago.ToLower() == "tarjeta")
            {
                Console.Write("Pon el numero de cuenta: ");
                string numCuenta = Console.ReadLine();
            }
        }
        static void Ex7()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        static void Ex8()
        {
            int i = 1;
            while (i <= 100)
            {
                Console.Write(i + " ");
                i++;
            }
        }
        static void Ex9()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                    Console.Write(i + " ");
            }
        }
        static void Ex10()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0 || i % 3 == 0)
                    Console.Write(i + " ");
            }
        }
        static void Ex11()
        {
            int num1 = 5;
            int num2 = 7;

            if (num1 > num2)
            {
                Console.WriteLine("El primer numero es mayor");
            }
            else if (num1 < num2)
            {
                Console.WriteLine("El segundo numero es mayor");
            }
            else
            {
                Console.WriteLine("Los dos numeros son iguales");
            }
        }
        static void Ex12()
        {
            string name = "Fernando";
            Console.WriteLine($"Bienvenido {name}");
        }
        static void Ex13()
        {
            Console.Write("Escribe tu nombre: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Bienvenido {name}");
        }
        static void Ex14()
        {
            const double PI = Math.PI;
            Console.Write("Pon el radio del círculo: ");
            double radio = Convert.ToDouble(Console.ReadLine());
            double area = PI * Math.Pow(radio, 2);
            Console.WriteLine($" El area del circulo es {area}");
        }
        static void Ex15()
        {
            Console.Write("Pon un numero: ");
            int num8 = Convert.ToInt32(Console.ReadLine());
            if (num8 % 2 == 0)
            {
                Console.WriteLine($"El numero {num8} es divisible entre 2");
            }
            else
            {
                Console.WriteLine($"El numero {num8} no es divisible entre 2");
            }
        }
        static void Ex16()
        {
            const double IVA = 0.21;
            Console.Write("Dime el precio del producto: ");
            double precio = Convert.ToDouble(Console.ReadLine());
            double precioFinal = precio * (1 + IVA);
            Console.WriteLine($"El precio final con IVA es {precioFinal}");
        }
        static void Ex17()
        {
            int i = 1;
            while (i <= 100)
            {
                Console.Write($"{i} ");
                i++;
            }
        }
        static void Ex18()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.Write($"{i} ");
            }
        }
        static void Ex19()
        {
            int i = 1;
            while (i <= 100)
            {
                if (i % 2 == 0 && i % 3 == 0)
                    Console.Write($"{i} ");
                i++;
            }
        }
        static void Ex20()
        {
            Console.Write("Pon el numero de ventas: ");
            int numVentas = Convert.ToInt32(Console.ReadLine());
            int sumaVentas = 0;
            for (int i = 1; i <= numVentas; i++)
            {
                Console.Write($"Pon la venta {i}: ");
                sumaVentas += Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"La suma de las ventas es {sumaVentas}");
        }

        static void Ex21()
        {
            Console.Write("Ingrese un dia de la semana: ");
            string diaSemana2 = Console.ReadLine();
            switch (diaSemana2.ToLower())
            {
                case "lunes":
                case "martes":
                case "miércoles":
                case "miercoles":
                case "jueves":
                case "viernes":
                    Console.WriteLine("Es un dia laboral");
                    break;
                case "sábado":
                case "sabado":
                case "domingo":
                    Console.WriteLine(" No es un dia laboral");
                    break;
                default:
                    Console.WriteLine("Dia no reconocido");
                    break;
            }
        }
        static void Ex22()
        {
            string contraseña = "secreto";
            int intentos = 3;
            bool accesoConcedido = false;

            while (intentos > 0)
            {
                Console.Write("Ingrese la contraseña: ");
                string contraseñaIngresada = Console.ReadLine();
                if (contraseñaIngresada == contraseña)
                {
                    accesoConcedido = true;
                    Console.WriteLine(" Enhorabuena");
                    break;
                }
                else
                {
                    intentos--;
                    Console.WriteLine($"Contraseña incorrecta, intentos restantes: {intentos}");
                }
            }

            if (!accesoConcedido)
                Console.WriteLine("Agoto los intentos, acceso denegado");

        }
        static void Ex23()
        {
            Console.Write("Pon el primer operando: ");
            int operando1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Pon el segundo operando: ");
            int operando2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Pon un signo aritmetico (+, -, *, /, ^, %): ");
            string signo = Console.ReadLine();

            double resultado = 0;

            switch (signo)
            {
                case "+":
                    resultado = operando1 + operando2;
                    break;
                case "-":
                    resultado = operando1 - operando2;
                    break;
                case "*":
                    resultado = operando1 * operando2;
                    break;
                case "/":
                    resultado = (double)operando1 / operando2;
                    break;
                case "^":
                    resultado = Math.Pow(operando1, operando2);
                    break;
                case "%":
                    resultado = operando1 % operando2;
                    break;
                default:
                    Console.WriteLine("Signo aritmetico no reconocido");
                    break;
            }

            Console.WriteLine($"El resultado de la operación es {resultado}");
        }

    }
}
