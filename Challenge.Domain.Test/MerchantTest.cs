using Challenge.Domain.Models;
using FluentAssertions;

namespace Challenge.Domain.Test
{
    [TestFixture]
    public class MerchantTest
    {
        [Test]
        public void ShouldCreateMerchantSuccessfully()
        {
            var merchantName = "Merchant Name";

            var merchant = new Merchant(merchantName);

            merchant.Should().NotBeNull();
            merchant.Name.Should().Be(merchantName);
            merchant.Purchases.Should().HaveCount(0);
            merchant.Balance.Should().Be(0);
        }

        [Test]
        public void ShouldAddTransaction()
        {
            var merchant = new Merchant("Merchant Name");

            var transaction = new Purchase(100);

            merchant.AddPurchase(transaction);

            merchant.Purchases.Should().Contain(transaction);
        }

        [Test]
        public void ShouldCalculateBalance()
        {
            var merchant = new Merchant("Merchant Name");

            var transactions = new List<Purchase>()
            {
                new Purchase(10,DateTime.Now),
                new Purchase(20,DateTime.Now),
                new Purchase(30,DateTime.Now),
                new Purchase(40,DateTime.Now),
                new Purchase(50,DateTime.Now),
                new Purchase(60,DateTime.Now),
                new Purchase(10,DateTime.Now),
                new Purchase(90,DateTime.Now),
                new Purchase(20,DateTime.Now),

            };
            transactions.ForEach(t => merchant.AddPurchase(t));

            merchant.Balance.Should().Be(330);
        }
    }
}
