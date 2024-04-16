using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtRulesEmployeeManagementModelLibrary
{
    public class ABC : Employee, IGovtRules
    {
        
        public ABC(int empId, string name, string department, string designation, double basicSalary)
            : base(empId, name, department, designation, basicSalary)
        {
            EmployerName = "ABC";
        }

        public double CalculateEmployeePF(double basicSalary)
        {
            return basicSalary * 0.12; // Employee contribution: 12% of basic salary
        }

        public string GetLeaveDetails()
        {
            return "Leave Details for ABC: \n1 day of Casual Leave per month\n12 days of Sick Leave per year\n10 days of Privilege Leave per year";
        }

        public double CalculateGratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 20)
            {
                return 3 * basicSalary;
            }
            else if (serviceCompleted > 10)
            {
                return 2 * basicSalary;
            }
            else if (serviceCompleted > 5)
            {
                return basicSalary;
            }
            else
            {
                return 0;
            }
        }
    }
}
