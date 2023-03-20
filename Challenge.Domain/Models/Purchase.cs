using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Domain.Models
{
    public class Purchase
    {
        [Key]
        public long Id { get; private set; }

        [ForeignKey("Merchant")]
        public long MerchantId { get; private set; }

        public DateTime Date { get; private set; }

        public decimal Amount { get; private set; }

        public Purchase(decimal amount, DateTime? date = null)
        {
            Date = date ?? DateTime.Now;
            Amount = amount;
        }

        [Obsolete("Only for EF", true)]
        public Purchase()
        {
        }

    }
}
