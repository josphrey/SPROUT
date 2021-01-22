using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPROUT.Entities;

namespace SPROUT.Data
{
    public class DbInitializer
    {
        public static void Initialize(EmployeeDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employee.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
                new Employee() { Name="John Koenig", Birthday = new DateTime(1975, 10, 17), Tin=10001, EmployeeType="Regular"  },
                new Employee() { Name="Joseph", Birthday = new DateTime(1988, 08, 29), Tin=10002, EmployeeType="Regular" },
                new Employee() { Name="Dylan Hunt", Birthday = new DateTime(2000, 10, 2), Tin=10003, EmployeeType="Regular" },
                new Employee() { Name="Leela Turanga", Birthday = new DateTime(1999, 3, 28), Tin=10004, EmployeeType="Regular" },
                new Employee() { Name="John Crichton", Birthday = new DateTime(1999, 3, 19), Tin=10005, EmployeeType="Contractual" },
                new Employee() { Name="Dave Lister", Birthday = new DateTime(1988, 2, 15), Tin =10006, EmployeeType="Contractual" },
            };
            foreach (Employee e in employees)
            {
                context.Employee.Add(e);
            }
            context.SaveChanges();
        }
    }
}
