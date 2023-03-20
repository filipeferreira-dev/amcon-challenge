using System.ComponentModel.DataAnnotations;

namespace Challenge.Domain.Models
{
    public class Merchant
    {
        [Key]
        public long Id { get; private set; }

        [Required]
        public string Name { get; private set; } = null!;

        public ICollection<Purchase> Purchases { get; private set; } = new HashSet<Purchase>();

        public decimal Balance => GetBalance();

        [Obsolete("Only for EF", true)]
        public Merchant()
        {
        }

        public Merchant(string name)
        {
            Name = name;
        }

        public void AddPurchase(Purchase transaction)
        {
            Purchases.Add(transaction);
        }

        private decimal GetBalance()
        {
            if(Purchases.Count == 0) return 0;
            return Purchases.Sum(i => i.Amount);
        }

    }
}
