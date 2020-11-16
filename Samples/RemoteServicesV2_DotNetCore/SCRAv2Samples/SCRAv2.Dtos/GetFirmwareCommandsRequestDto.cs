namespace SCRAv2.Dtos
{
    public class GetFirmwareCommandsRequestDto
    {
        public string CustomerCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BillingLabel { get; set; }
        public string CustomerTransactionId { get; set; }
        public string AdditionalRequestData_Key { get; set; }
        public string AdditionalRequestData_Value { get; set; }
        public string DeviceType { get; set; }
        public string Firmware { get; set; }
        public string KSN { get; set; }
        public int KeyID { get; set; }
        public string SerialNumber { get; set; }
    }
}
