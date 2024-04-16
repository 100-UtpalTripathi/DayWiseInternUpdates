using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtRulesEmployeeManagementModelLibrary
{
    /// <summary>
    /// Represents the interface for implementing government rules related to employee management.
    /// </summary>
    public interface IGovtRules
    {
        /// <summary>
        /// Calculates the employee's Provident Fund (PF) contribution.
        /// </summary>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The calculated PF amount.</returns>
        double CalculateEmployeePF(double basicSalary);

        /// <summary>
        /// Retrieves the leave details for employees according to government rules.
        /// </summary>
        /// <returns>A string containing leave details.</returns>
        string GetLeaveDetails();

        /// <summary>
        /// Calculates the gratuity amount for the employee based on completed years of service and basic salary.
        /// </summary>
        /// <param name="serviceCompleted">The number of years of service completed by the employee.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        /// <returns>The calculated gratuity amount.</returns>
        double CalculateGratuityAmount(float serviceCompleted, double basicSalary);
    }
}
