using Challenge.ApplicationService.Maps;
using Challenge.Domain.Models;
using FluentAssertions;

namespace Challenge.ApplicationService.Test.Maps
{
    [TestFixture]
    public class PurchaseMapperTest
    {

        [Test]
        public void ShouldMapToResponse()
        {
            var entity = new Purchase(100);

            var response = entity.MapToResponse();

            response.Should().NotBeNull();
            response.Id.Should().Be(entity.Id);
            response.Amount.Should().Be(entity.Amount);
            response.Date.Should().Be(entity.Date);
        }

        [Test]
        public void ShouldMapListToResponse()
        {
            var entities = new List<Purchase>();
            var entity1 = new Purchase(100);
            var entity2 = new Purchase(100);

            entities.Add(entity1);
            entities.Add(entity2);

            var response = entities.MapToResponse();
            response.Should().NotBeNull();
            response.Should().HaveCount(2);
        }
    }
}
