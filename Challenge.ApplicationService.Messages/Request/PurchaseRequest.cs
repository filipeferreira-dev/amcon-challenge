using System.ComponentModel.DataAnnotations;

namespace Challenge.ApplicationService.Messages.Request
{
    public class PurchaseRequest
    {
        public DateTime? Date { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
