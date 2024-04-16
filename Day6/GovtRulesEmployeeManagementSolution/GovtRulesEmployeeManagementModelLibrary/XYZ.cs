using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtRulesEmployeeManagementModelLibrary
{
    public class XYZ : IGovtRules
    {
        public double CalculateEmployeePF(double basicSalary)
        {
            return basicSalary * 0.12; // Employee contribution: 12% of basic salary
        }

        public string GetLeaveDetails()
        {
            return "Leave Details for XYZ: \n2 days of Casual Leave per month\n5 days of Sick Leave per year\n5 days of Privilege Leave per year";
        }

        public double CalculateGratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0; // Gratuity not applicable for XYZ
        }
    }
}
