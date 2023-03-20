using Challenge.ApplicationService.Messages.Request;
using Challenge.ApplicationService.Messages.Response;
using Challenge.Domain.Models;

namespace Challenge.ApplicationService.Maps
{
    public static class MerchantMapper
    {
        public static MerchantResponse MapToResponse(this Merchant entity)
        => new()
        {
            Id = entity.Id,
            Balance = entity.Balance,
            Name = entity.Name,
            Purchases = entity.Purchases.MapToResponse(),
        };

        public static IEnumerable<MerchantResponse> MapToResponse(this IEnumerable<Merchant> entities) => entities.Select(e => e.MapToResponse());

        public static Merchant MapToEntity(this MerchantRequest request) => new(request.Name);
    }
}
