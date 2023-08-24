using System;

namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Manager manager = new Manager("Alice", 3500);
                Boss boss = new Boss("John", 9000);
                Senior senior = new Senior("Carol", 3000);
                Mid mid = new Mid("David", 2000);
                Volunteer volunteer = new Volunteer("Eva");
                Junior junior = new Junior("Jorge", 1500);

                junior.PrintSalaryDetails();
                manager.PrintSalaryDetails();
                boss.PrintSalaryDetails();
                senior.PrintSalaryDetails();
                mid.PrintSalaryDetails();
                volunteer.PrintSalaryDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    class Employees
    {
        public string name;
        public double baseSalary;

        public Employees(string name, double baseSalary)
        {
            this.name = name;
            this.baseSalary = baseSalary;
        }

        public virtual void PrintSalaryDetails()
        {
            Console.WriteLine($"Empleado: {name}");
            Console.WriteLine($"Salario base: {baseSalary:C}");
        }
    }

    class Manager : Employees
    {
        public Manager(string name, double baseSalary) : base(name, baseSalary)
        {
            if (baseSalary <= 3000 || baseSalary >= 5000)
            {
                throw new ArgumentException("El salario del Manager debe estar entre 3000 y 5000 euros.");
            }
        }

        public override void PrintSalaryDetails()
        {
            base.PrintSalaryDetails();
            Console.WriteLine($"Tipo: Manager");
            double bonus = baseSalary * 0.10;
            Console.WriteLine($"Bonus: {bonus:C}");
            Console.WriteLine();
        }
    }

    class Boss : Employees
    {
        public Boss(string name, double baseSalary) : base(name, baseSalary)
        {
            if (baseSalary <= 8000)
            {
                throw new ArgumentException("El salario del Boss debe ser mayor a 8000 euros.");
            }
        }

        public override void PrintSalaryDetails()
        {
            base.PrintSalaryDetails();
            Console.WriteLine($"Tipo: Boss");
            double bonus = baseSalary * 0.50;
            Console.WriteLine($"Bonus: {bonus:C}");
            Console.WriteLine();
        }
    }

    class Senior : Employees
    {
        public Senior(string name, double baseSalary) : base(name, baseSalary)
        {
            if (baseSalary <= 2700 || baseSalary >= 4000)
            {
                throw new ArgumentException("El salario del Senior debe estar entre 2700 y 4000 euros.");
            }
        }

        public override void PrintSalaryDetails()
        {
            base.PrintSalaryDetails();
            Console.WriteLine($"Tipo: Senior");
            double salary = baseSalary * 0.95;
            Console.WriteLine($"Saldo reducido: {salary:C}");
            Console.WriteLine();
        }
    }

    class Mid : Employees
    {
        public Mid(string name, double baseSalary) : base(name, baseSalary)
        {
            if (baseSalary <= 1800 || baseSalary >= 2500)
            {
                throw new ArgumentException("El salario del Mid debe estar entre 1800 y 2500 euros.");
            }
        }

        public override void PrintSalaryDetails()
        {
            base.PrintSalaryDetails();
            Console.WriteLine($"Tipo: Mid");
            double salary = baseSalary * 0.90;
            Console.WriteLine($"Saldo reducido: {salary:C}");
            Console.WriteLine();
        }
    }

    class Volunteer : Employees
    {
        public Volunteer(string name) : base(name, 0) { }

        public override void PrintSalaryDetails()
        {
            base.PrintSalaryDetails();
            Console.WriteLine($"Tipo: Volunteer");
            Console.WriteLine("Sin salario");
            Console.WriteLine();
        }
    }

    class Junior : Employees
    {
        public Junior(string name, double baseSalary) : base(name, baseSalary)
        {
            if (baseSalary <= 900 || baseSalary >= 1600)
            {
                throw new ArgumentException("El salario del Junior debe estar entre 900 y 1600 euros.");
            }
        }

        public override void PrintSalaryDetails()
        {
            base.PrintSalaryDetails();
            Console.WriteLine($"Tipo: Junior");
            double salary = baseSalary * 0.85;
            Console.WriteLine($"Saldo reducido: {salary:C}");
            Console.WriteLine();
        }
    }
}