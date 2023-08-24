using System;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
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

                Console.WriteLine("\nIssuing bonuses:");
                junior.IssueBonus();
                manager.IssueBonus();
                boss.IssueBonus();
                senior.IssueBonus();
                mid.IssueBonus();
            
        }
    }

    class Employees
    {
        public string name;
        public double baseSalary;
        public double netMonthlySalary;
        public double grossMonthlySalary;
        public double netAnnualSalary;
        public double grossAnnualSalary;

        public Employees(string name, double baseSalary)
        {
            this.name = name;
            this.baseSalary = baseSalary;
            CalculateSalaries();
        }

        protected virtual double CalculateIRPFPercentage()
        {
            return 0;
        }

        protected virtual double CalculateBonusPercentage()
        {
            return 0;
        }

        public virtual void CalculateSalaries()
        {
            CalculateNetMonthlySalary();
            CalculateGrossMonthlySalary();
            CalculateNetAnnualSalary();
            CalculateGrossAnnualSalary();
        }

        protected virtual void CalculateNetMonthlySalary()
        {
            netMonthlySalary = baseSalary * (1 - CalculateIRPFPercentage());
        }

        protected virtual void CalculateGrossMonthlySalary()
        {
            grossMonthlySalary = baseSalary;
        }

        protected virtual void CalculateNetAnnualSalary()
        {
            netAnnualSalary = netMonthlySalary * 12;
        }

        protected virtual void CalculateGrossAnnualSalary()
        {
            grossAnnualSalary = grossMonthlySalary * 12;
        }

        public virtual void PrintSalaryDetails()
        {
            Console.WriteLine($"Empleado: {name}");
            Console.WriteLine($"Salario base mensual: {baseSalary:C}");
            Console.WriteLine($"Salario neto mensual: {netMonthlySalary:C}");
            Console.WriteLine($"Salario bruto mensual: {grossMonthlySalary:C}");
            Console.WriteLine($"Salario neto anual: {netAnnualSalary:C}");
            Console.WriteLine($"Salario bruto anual: {grossAnnualSalary:C}");
        }

        public void IssueBonus()
        {
            double bonusPercentage = CalculateBonusPercentage();
            double bonus = grossAnnualSalary * bonusPercentage;
            Console.WriteLine($"Se ha emitido un bonus de {bonus:C} para {name}");
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

        protected override double CalculateIRPFPercentage()
        {
            return 0.26;
        }

        protected override double CalculateBonusPercentage()
        {
            return 0.10;
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

        protected override double CalculateIRPFPercentage()
        {
            return 0.32;
        }

        protected override double CalculateBonusPercentage()
        {
            return 0.10;
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

        protected override double CalculateIRPFPercentage()
        {
            return 0.24;
        }

        protected override double CalculateBonusPercentage()
        {
            return 0.10;
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

        protected override double CalculateIRPFPercentage()
        {
            return 0.15;
        }

        protected override double CalculateBonusPercentage()
        {
            return 0.10;
        }
    }

    class Volunteer : Employees
    {
        public bool hasGovernmentAid;

        public Volunteer(string name) : base(name, 0)
        {
            hasGovernmentAid = false;
        }

        public override void CalculateSalaries()
        {
            base.CalculateSalaries();
            CalculateNetMonthlySalary();
        }

        protected override void CalculateNetMonthlySalary()
        {
            if (hasGovernmentAid)
            {
                netMonthlySalary = 300;
            }
            else
            {
                netMonthlySalary = 0;
            }
        }

        public void ApplyGovernmentAid()
        {
            hasGovernmentAid = true;
            CalculateSalaries();
            Console.WriteLine($"{name} ha recibido un apoyo del gobierno.");
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

        protected override double CalculateIRPFPercentage()
        {
            return 0.02;
        }

        protected override double CalculateBonusPercentage()
        {
            return 0.10;
        }
    }
}
