using System.ComponentModel.DataAnnotations;
namespace Joo_Jeana_HW2.Models
{
    public class IndividualOrder : Order
    {
        //naming constants
        public const Decimal SALES_TAX_RATE = 0.0875m;
        public const Decimal SWEATSHIRT_FEE = 2.50m;
        public const Decimal TSHIRT_FEE = 2.00m;

        //properties
        [Display(Name = "Customer Name:")]
        public string? CustomerName { get; set; }
        [Display(Name = "Processing Fee:")]
        public decimal ProcessingFee { get; set; }
        [Display(Name = "Sales Tax:")]
        public decimal SalesTax { get; set; }
        //calculations of properties for ind. order
        public void CalcTotals()
        {
            base.CalcTotals();
            ProcessingFee = (NumberOfSweatshirts * SWEATSHIRT_FEE) + (NumberOfTShirts * TSHIRT_FEE);
            SalesTax = Subtotal * SALES_TAX_RATE;
            Total = Subtotal + ProcessingFee + SalesTax;
        }
    }
}