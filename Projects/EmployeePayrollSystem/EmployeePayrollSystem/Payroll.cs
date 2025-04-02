namespace EmployeePayrollSystem
{
    public class Payroll
    {
        public static double CalculateNetSalary(Employee emp)
        {
            double deductions = emp.Salary * 0.1;
            return emp.Salary - deductions + emp.Bonus;
        }
    }
}
