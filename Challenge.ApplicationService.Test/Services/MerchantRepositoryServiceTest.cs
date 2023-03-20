using Challenge.ApplicationService.Messages.Request;
using Challenge.ApplicationService.Services;
using Challenge.ApplicationService.Services.Contracts;
using Challenge.Domain.Models;
using Challenge.Domain.Repositories;
using FakeItEasy;

namespace Challenge.ApplicationService.Test.Services
{
    [TestFixture]
    public class MerchantApplicationServiceTest
    {
        MerchantApplicationService Sut { get; set; }

        IMerchantRepository MerchantRepository { get; set; }

        ISyncService SyncService { get; set; }

        [SetUp]
        public void SetUp()
        {
            MerchantRepository = A.Fake<IMerchantRepository>();
            SyncService = A.Fake<ISyncService>();
            Sut = new MerchantApplicationService(MerchantRepository, SyncService);
        }

        [Test]
        public async Task ShouldGetAddMerchant()
        {
            var merchant = new MerchantRequest();
            await Sut.AddAsync(merchant);

            A.CallTo(() => MerchantRepository.AddAsync(A<Merchant>._)).MustHaveHappened();
        }

    }
}
