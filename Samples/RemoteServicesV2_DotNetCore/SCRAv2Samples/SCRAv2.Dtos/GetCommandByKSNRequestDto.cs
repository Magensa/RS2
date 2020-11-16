namespace SCRAv2.Dtos
{
    public class GetCommandByKSNRequestDto
    {
        public string CustomerCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BillingLabel { get; set; }
        public string CustomerTransactionId { get; set; }
        public int CommandID { get; set; }
        public string KSN { get; set; }
        public int KeyID { get; set; }
    }
}
