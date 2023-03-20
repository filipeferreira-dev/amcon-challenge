using Challenge.ApplicationService.Messages.Request;
using Challenge.ApplicationService.Messages.Response;
using Challenge.Domain.Models;

namespace Challenge.ApplicationService.Maps
{
    public static class PurchaseMapper
    {
        public static PurchaseResponse MapToResponse(this Purchase entity) => new PurchaseResponse
        {
            Id = entity.Id,
            Date = entity.Date,
            Amount = entity.Amount,
        };

        public static IEnumerable<PurchaseResponse> MapToResponse(this IEnumerable<Purchase> entities) => entities.Select(e => e.MapToResponse());

        public static Purchase MapToEntity(this PurchaseRequest request) => new Purchase(request.Amount, request.Date);
    }
}
