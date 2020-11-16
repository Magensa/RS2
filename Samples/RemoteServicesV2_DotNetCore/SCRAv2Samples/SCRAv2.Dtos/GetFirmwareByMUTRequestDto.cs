namespace SCRAv2.Dtos
{
    public class GetFirmwareByMUTRequestDto
    {
        public string CustomerCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BillingLabel { get; set; }
        public string CustomerTransactionId { get; set; }
        public int FirmwareID { get; set; }
        public string KSN { get; set; }
        public string UpdateToken { get; set; }
    }
}
