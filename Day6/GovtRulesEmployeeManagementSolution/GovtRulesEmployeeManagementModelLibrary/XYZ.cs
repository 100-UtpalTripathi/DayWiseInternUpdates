using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtRulesEmployeeManagementModelLibrary
{
    /// <summary>
    /// Represents an employee managed by the XYZ company, implementing government rules.
    /// </summary>
    public class XYZ : Employee, IGovtRules
    {
        /// <summary>
        /// Initializes a new instance of the XYZ class with specified employee details.
        /// </summary>
        /// <param name="empId">The employee ID.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="department">The department of the employee.</param>
        /// <param name="designation">The designation of the employee.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        public XYZ(int empId, string name, string department, string designation, double basicSalary)
            : base(empId, name, department, designation, basicSalary)
        {
            EmployerName = "XYZ";
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
        /// Retrieves the leave details for employees of the XYZ company.
        /// </summary>
        /// <returns>A string containing leave details.</returns>
        public string GetLeaveDetails()
        {
            return "Leave Details for XYZ: \n2 days of Casual Leave per month\n5 days of Sick Leave per year\n5 days of Privilege Leave per year";
        }

        /// <summary>
        /// Calculates the gratuity amount.
        /// </summary>
        /// <param name="serviceCompleted">The number of years of service completed by the employee.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>Gratuity amount, which is always 0 for employees of XYZ company.</returns>
        public double CalculateGratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0; // Gratuity NA
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
