using System.ComponentModel.DataAnnotations;
namespace Joo_Jeana_HW2.Models
{
    public class GroupOrder : Order
    {
        [Display(Name = "Preferred Customer:")]
        public Boolean PreferredCustomer { get; set; }

        [Display(Name = "Setup Fee:")]
        [Range(0, 175, ErrorMessage = "Setup fee must be between 0 and 175.")]
        public Decimal SetupFee { get; set; }

        public new void CalcTotals()
        {
            // 1. Calculate base items and subtotal from Order.cs logic
            base.CalcTotals();

            // 2. Rule: If Subtotal > 5000, they ARE preferred automatically
            if (Subtotal > 5000)
            {
                PreferredCustomer = true;
            }

            // 3. Rule: Preferred customers pay $0 setup fee
            if (PreferredCustomer)
            {
                SetupFee = 0.00m;
            }

            // 4. Group orders have no sales tax, so Total is just Subtotal + SetupFee
            Total = Subtotal + SetupFee;
        }
    }
}