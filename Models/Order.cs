using System.ComponentModel.DataAnnotations;
namespace Joo_Jeana_HW2.Models
{
    public enum CustomerTypeEnum
    {
        Individual,
        Group
    }
    public abstract class Order
    {
        //naming constants
        public const Decimal SWEATSHIRT_PRICE = 15.00m;
        public const Decimal TSHIRT_PRICE = 10.00m;
        //properties
        [Display(Name = "Organization Code:")]
        [Required(ErrorMessage = "Please make sure you have entered valid data!")]
        [RegularExpression(@"^[A-Za-z]{4,6}$",
            ErrorMessage = "Organization code must be 4-6 letters.")]
        public string OrganizationCode { get; set; }
        [Display(Name = "Customer Type:")]
        public CustomerTypeEnum CustomerType { get; set; }
        [Range (0,int.MaxValue,
            ErrorMessage = "The value '{1}' is invalid.")]
        [Display(Name = "Number of Sweatshirts:")]
        public Int32 NumberOfSweatshirts { get; set; }
        [Display(Name = "Number of TShirts:")]
        [Range (0, int.MaxValue,
            ErrorMessage = "The value '{1}' is invalid.")]
        public Int32 NumberOfTShirts { get; set; }

        //no user input
        [Display(Name = "Total Items:")]
        public Int32 TotalItems { get; set; }
        [Display(Name = "Sweatshirt Subtotal:")]
        public Decimal SweatshirtSubtotal { get; set; }
        [Display(Name = "T-Shirt Subtotal:")]
        public Decimal TShirtSubtotal { get; set; }
        [Display(Name = "Subtotal:")]
        public Decimal Subtotal { get; set; }
        [Display(Name = "Total:")]
        public Decimal Total   { get; set; }

        //methods are calculations
        public void CalcTotals()
        {
        TotalItems = NumberOfSweatshirts + NumberOfTShirts;

        SweatshirtSubtotal = NumberOfSweatshirts * SWEATSHIRT_PRICE;
        TShirtSubtotal = NumberOfTShirts * TSHIRT_PRICE;
        Subtotal = SweatshirtSubtotal + TShirtSubtotal;
        }
    }
}