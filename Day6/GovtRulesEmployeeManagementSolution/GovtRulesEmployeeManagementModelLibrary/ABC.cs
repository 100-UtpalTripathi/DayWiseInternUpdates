using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtRulesEmployeeManagementModelLibrary
{
    /// <summary>
    /// Represents an employee managed by the ABC company, implementing government rules.
    /// </summary>
    public class ABC : Employee, IGovtRules
    {
        /// <summary>
        /// Initializes a new instance of the ABC class with specified employee details.
        /// </summary>
        /// <param name="empId">The employee ID.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="department">The department of the employee.</param>
        /// <param name="designation">The designation of the employee.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        public ABC(int empId, string name, string department, string designation, double basicSalary)
            : base(empId, name, department, designation, basicSalary)
        {
            EmployerName = "ABC";
        }

        /// <summary>
        /// Calculates the employee's Provident Fund (PF) contribution.
        /// </summary>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The calculated PF amount.</returns>
        public double CalculateEmployeePF(double basicSalary)
        {
            return basicSalary * 0.12; // Employee contribution: 12% of basic salary
        }

        /// <summary>
        /// Retrieves the leave details for employees of the ABC company.
        /// </summary>
        /// <returns>A string containing leave details.</returns>
        public string GetLeaveDetails()
        {
            return "Leave Details for ABC: \n1 day of Casual Leave per month\n12 days of Sick Leave per year\n10 days of Privilege Leave per year";
        }

        /// <summary>
        /// Calculates the gratuity amount based on the completed years of service and basic salary.
        /// </summary>
        /// <param name="serviceCompleted">The number of years of service completed by the employee.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The calculated gratuity amount.</returns>
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

        /// <summary>
        /// Prints the details of the employee, including the employer name.
        /// </summary>
        public override void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine("Employer Name : " + EmployerName);
        }
    }
}
