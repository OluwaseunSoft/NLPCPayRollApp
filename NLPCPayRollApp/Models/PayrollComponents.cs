using System.ComponentModel;
using System.Text.Json.Serialization;

namespace NLPCPayRollApp.Models
{
    public class PayrollComponents
    {
        public int Id { get; set; }
        [DisplayName("Basic Salary")]
        public double BasicSalary { get; set; }
        public double Housing { get; set; }
        public double Transport { get; set; }
        public double Furniture { get; set; }
        public double Entertainment { get; set; }
        public double Lunch { get; set; }
        public double Passage { get; set; }
        public double Dressing { get; set; }
        public double Bonus { get; set; }
        [DisplayName("13th Month")]
        public double ThirteenthMonth { get; set; }
        public double Utility { get; set; }
        [DisplayName("Other Allowances")]
        public double OtherAllowances { get; set; }
        public double NHF { get; set; }
        public double NHIS { get; set; }
        [DisplayName("National Pension Scheme")]
        public double NPS { get; set; }
        [DisplayName("Life Assurance")]
        public double LifeAssurance { get; set; }
        [DisplayName("Gross Income")]
        public double GrossIncome { get; set; }
        [DisplayName("Tax Payable")]
        public double TaxPayable { get; set; }
        public int CadreLevelId { get; set; }

    }
}
