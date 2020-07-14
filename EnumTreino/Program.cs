using System;
using System.Globalization;
using EnumTreino.Entities;
using EnumTreino.Entities.Enums;

namespace EnumTreino
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter department's name: ");
            string derpartment = Console.ReadLine();
            Console.Write("Enter woker data: ");
            Console.Write("\nName: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WokerLevel level = Enum.Parse<WokerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(derpartment);
            Woker woker = new Woker(name, level, baseSalary, dept);

            Console.Write("How manny contracts to this woker? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter #{i + 1} contract data: ");

                Console.Write("Date(DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration(hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);

                woker.AddContract(contract); //adicionar o contrato, do trabalhador do "woker".(Dentro da memoria, vai ter o trabalhador e os contradros separados)
            }

            Console.Write("\nEnter month  and year to calcule income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine($"\n{woker}");
            Console.Write($"Income for: {monthAndYear}: {woker.Income(year, month)} ");


        }
    }
}
