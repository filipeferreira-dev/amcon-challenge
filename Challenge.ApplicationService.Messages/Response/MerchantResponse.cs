namespace Challenge.ApplicationService.Messages.Response
{
    public class MerchantResponse
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public IEnumerable<PurchaseResponse> Purchases { get; set; } = new HashSet<PurchaseResponse>();

        public decimal Balance { get; set; }
    }
}
