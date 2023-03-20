using Challenge.ApplicationService.Maps;
using Challenge.Domain.Models;
using FluentAssertions;

namespace Challenge.ApplicationService.Test.Maps
{
    [TestFixture]
    public class MerchantMapperTest
    {

        [Test]
        public void ShouldMapToResponse()
        {
            var merchant = new Merchant("Merchant Name");
            var Purchase = new Purchase(100);
            merchant.AddPurchase(Purchase);

            var response = merchant.MapToResponse();

            response.Should().NotBeNull();
            response.Id.Should().Be(merchant.Id);
            response.Balance.Should().Be(merchant.Balance);
            response.Name.Should().Be(merchant.Name);
            response.Purchases.Should().NotBeNull();
            response.Purchases.Count().Should().Be(merchant.Purchases.Count());
        }

        [Test]
        public void ShouldMapListToResponse()
        {
            var merchants = new List<Merchant>();
            var merchant1 = new Merchant("Merchant Name");
            var Purchase1 = new Purchase(100);
            merchant1.AddPurchase(Purchase1);

            var merchant2 = new Merchant("Merchant Name");
            var Purchase2 = new Purchase(100);
            merchant2.AddPurchase(Purchase2);

            merchants.Add(merchant1);
            merchants.Add(merchant2);

            var response = merchants.MapToResponse();
            response.Should().NotBeNull();
            response.Should().HaveCount(2);
        }
    }
}
