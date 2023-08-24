using ConsoleAplication5;
using System;

namespace ConsoleAplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager("Alice", 3000);
            Boss boss = new Boss("John", 5000);
            Employee employee = new Employee("Bob", 2000);
            Volunteer volunteer = new Volunteer("Eva");

            employee.PrintSalaryDetails();
            manager.PrintSalaryDetails();
            boss.PrintSalaryDetails();
            volunteer.PrintSalaryDetails();
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
            Console.WriteLine($"Salario base: {baseSalary}");
        }
    }

    class Manager : Employees
    {
        public Manager(string name, double baseSalary) : base(name, baseSalary) { }

        public override void PrintSalaryDetails()
        {
            base.PrintSalaryDetails();
            Console.WriteLine($"Tipo: Manager");
            double bonus = baseSalary * 0.10;
            Console.WriteLine($"Bonus: {bonus}");
            Console.WriteLine();
        }
    }

    class Boss : Employees
    { 

        public Boss(string name, double baseSalary) : base(name, baseSalary) { }

        public override void PrintSalaryDetails()
        {
            base.PrintSalaryDetails();
            Console.WriteLine($"Tipo: Boss");
            double bonus = baseSalary * 0.50;
            Console.WriteLine($"Bonus: {bonus}");
            Console.WriteLine();

        }
    }

    class Employee : Employees
    {
        public Employee(string name, double baseSalary) : base(name, baseSalary) { }

        public override void PrintSalaryDetails()
        {
            base.PrintSalaryDetails();
            Console.WriteLine($"Tipo: Employee");
            double salary = baseSalary * 0.85;
            Console.WriteLine($"Saldo reducido: {salary}");
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
            Console.WriteLine("No Salary");
            Console.WriteLine();

        }
    }
}