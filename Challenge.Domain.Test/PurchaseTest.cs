using Challenge.Domain.Models;
using FluentAssertions;

namespace Challenge.Domain.Test
{
    [TestFixture]
    public class PurchaseTest
    {

        [Test]
        public void ShouldCreatePurchaseSuccessfully()
        {
            var PurchaseDate = DateTime.Now;
            var PurchaseAmount = 100;
         
            var Purchase = new Purchase(PurchaseAmount, PurchaseDate);

            Purchase.Should().NotBeNull();
            Purchase.Date.Should().Be(PurchaseDate);
            Purchase.Amount.Should().Be(PurchaseAmount);
        }
    }
}
