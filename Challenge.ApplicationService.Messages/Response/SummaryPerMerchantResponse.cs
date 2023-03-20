namespace Challenge.ApplicationService.Messages.Response
{
    public class SummaryPerMerchantResponse
    {
        public decimal Balance { get; set; }
        public long PurchaseCount { get; set; }
        public string MerchantName { get; set; } = null!;
    }
}
