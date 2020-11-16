namespace SCRAv2.Dtos
{
    public class GetCommandListRequestDto
    {
        public string CustomerCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BillingLabel { get; set; }
        public string CustomerTransactionId { get; set; }
        public string ExecutionType { get; set; }
    }
}
