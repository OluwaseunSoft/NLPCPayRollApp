using System.ComponentModel;

namespace NLPCPayRollApp.Models
{
    public class PaySlip
    {
        public string EmployeeName { get; set; }
        public string CadreLevelName { get; set; }
        public double Earnings { get; set; }
        public double Deductions { get; set; }
        public decimal NetSalary { get; set; }        
        public double GrossIncome { get; set; }
    }
}
