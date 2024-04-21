using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public List<Employee> GetEmployeesByDepartment(string departmentName)
        {
            List<Employee> employees = new List<Employee>();

            foreach(var emp in _data.Values)
            {
                if(emp.dept.Name == departmentName)
                {
                    employees.Add(emp);
                }
            }
            return employees;
        }
    }
    }
