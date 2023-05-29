using System.ComponentModel;
using System.Text.Json.Serialization;

namespace NLPCPayRollApp.Models
{
    public class PayrollComponents
    {
        public int Id { get; set; }
        [DisplayName("Basic Salary")]
        public int BasicSalary { get; set; }
        public int Housing { get; set; }
        public int Transport { get; set; }
        public int Furniture { get; set; }
        public int Entertainment { get; set; }
        public int Lunch { get; set; }
        public int Passage { get; set; }
        public int Dressing { get; set; }
        public int Bonus { get; set; }
        [DisplayName("13th Month")]
        public int ThirteenthMonth { get; set; }
        public int Utility { get; set; }
        [DisplayName("Other Allowances")]
        public int OtherAllowances { get; set; }
        public int NHF { get; set; }
        public int NHIS { get; set; }
        [DisplayName("National Pension Scheme")]
        public int NPS { get; set; }
        [DisplayName("Life Assurance")]
        public int LifeAssurance { get; set; }
        [DisplayName("Gross Income")]
        public int GrossIncome { get; set; }
        [DisplayName("Tax Payable")]
        public int TaxPayable { get; set; }
        public int CadreLevelId { get; set; }

    }
}
