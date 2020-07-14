using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using EnumTreino.Entities.Enums;

namespace EnumTreino.Entities
{
    class Woker
    {
        public string Name { get; set; }
        public WokerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department{ get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Woker() 
        { }

        public Woker(string name, WokerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract) //Acessar a lista de contrado e acessar o parametro de entrada
        {
            Contracts.Add(contract); //adiconar o contrado para o trabalhador.
        }

        public void RemoveContract(HourContract contract) 
        {
            Contracts.Remove(contract);
        }

        public double Income(int year,int month)
        {
            double sum = BaseSalary;

            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year==year && contract.Date.Month==month )
                {
                    sum += contract.TotalValue();
                }
            }

            return sum;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nDepartment: {Department.Name}";
        }
    }
}
