using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovtRulesEmployeeManagementModelLibrary
{
    public interface IGovtRules
    {
        double CalculateEmployeePF(double basicSalary);
        string GetLeaveDetails();
        double CalculateGratuityAmount(float serviceCompleted, double basicSalary);
    }
}
