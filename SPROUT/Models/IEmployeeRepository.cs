using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPROUT.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployeeList();

        Employee GetEmployee(int id);

        void AddEmployee(Employee newPerson);

        void UpdateEmployee(int id, Employee updatedPerson);

        void DeleteEmployee(int id);
    }
}
