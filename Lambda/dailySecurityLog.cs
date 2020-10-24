using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsoleApp1.Lambda;
namespace ConsoleApp1.Lambda
{

    public static class LinqExtensions
    {
        public static decimal? WeightedMovingAverage(this IEnumerable<decimal?> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            decimal aggregate = 0.0M;
            decimal weight;
            int item = 1;
            int count = source.Count( val=>val.HasValue);
            foreach( var nullable in source)
            {
                if(nullable.HasValue)
                {
                    weight = item / count;
                    aggregate += nullable.GetValueOrDefault() + weight;
                    count++;
                }
                if (count > 0)
                    return new decimal?(aggregate / count);
            }
            return null;
        }
        public static void TestLinqExtension()
        {
            decimal?[] prices = new decimal?[10] { 13.5M, 17.8M, null, 0.1M, 15.7M, 19.99M, 9.08M, 6.33M, 2.1M, 14.88M };
            Console.WriteLine(prices.WeightedMovingAverage());
        }

    }
    public class Employee
    {
        public string Name { get; set; }
        public override string ToString() => this.Name;
        public override bool Equals(object obj)
        {
            return this.GetHashCode().Equals(obj.GetHashCode());
        }
        public override int GetHashCode() => this.Name.GetHashCode();


    }

    public class dailySecurityLog
    {
        string[] dailySecurity =
        {
            "Rackshit log in",
            "Aaron log in",
            "Rackshit log out",
            "Ken log in",
            "Rackshit log in",
            "Ken log out"
        };
        Employee[] project1 =
        {
            new Employee {Name="Rackshit"},
            new Employee {Name = "Jason"},
            new Employee {Name = "Josh"},
            new Employee{Name = "Melissa"},
            new Employee{Name ="Aaron"},
            new Employee{Name = "Dave"},
            new Employee{Name = "Alex"}
        };
        Employee[] project2 =
        {
            new Employee {Name ="Mahesh"},
            new Employee{Name = "Ken"},
            new Employee{Name="Jesse"},
            new Employee{Name="Melissa"},
            new Employee {Name="Aaron"},
            new Employee{Name="Alex"},
            new Employee{Name = "Mary-Ellen"}
        };
        Employee[] project3 =
        {
            new Employee{Name="Mike"},
            new Employee{Name="Scott"},
            new Employee{Name="Melissa"},
            new Employee{Name="Aaron"},
            new Employee{Name="Alex"},
            new Employee{Name="Jon"}
        };
        public void Testlogin()
        {
            IEnumerable<string> whoLoggedIn = dailySecurity.Where(logEntry => logEntry.Contains("log in")).Distinct();
            Console.WriteLine("Every one who login  today:");
            foreach( string who in whoLoggedIn)
            {
                Console.WriteLine(who);
            }
        }
        public void TestProjectWithUnion()
        {
            Console.WriteLine("Employees for all project");
            var allProjectEmployees = project1.Union(project2.Union(project3));
            foreach( Employee employee in allProjectEmployees)
            {
                Console.WriteLine(employee);
            }
        }
        public void TestProjectWithInspect()
        {
            Console.WriteLine("Employees on every project");
            var everyProjectEmployee = project1.Intersect(project2.Intersect(project3));
            foreach( Employee employee in everyProjectEmployee)
            {
                Console.WriteLine(employee);
            }
        }

    }
}
