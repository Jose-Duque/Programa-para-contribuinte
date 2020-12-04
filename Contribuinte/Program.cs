using System;
using System.Collections.Generic;
using System.Globalization;
using Contribuinte.Entities;

namespace Contribuinte
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of tax payers:");
            int n = int.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            List<TaxPayer> taxPayers = new List<TaxPayer>(); 

            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (type == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double health = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    taxPayers.Add(new Individual(name, anualIncome, health));
                }
                else
                {
                    Console.Write("Number of employees:");
                    int numberEmployee = int.Parse(Console.ReadLine());
                    taxPayers.Add(new Company(name, anualIncome, numberEmployee));
                }

                Console.WriteLine();
            }

            Console.WriteLine("TAXES PAID:");
            foreach (TaxPayer taxPayer in taxPayers)
            {
                Console.WriteLine(taxPayer.Name + " $ " + taxPayer.Tax().ToString("F2"),CultureInfo.InvariantCulture);
                sum += taxPayer.Tax(); 
            }
            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: " + sum.ToString("F2",CultureInfo.InvariantCulture));
        }
    }
}
