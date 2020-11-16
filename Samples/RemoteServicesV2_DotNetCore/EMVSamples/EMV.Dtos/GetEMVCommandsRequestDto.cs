using System.Collections.Generic;

namespace EMV.Dtos
{
    public class GetEMVCommandsRequestDto
    {
        public string CustomerCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BillingLabel { get; set; }
        public string CustomerTransactionId { get; set; }
        public List<KeyValuePair<string, string>> AdditionalRequestData { get; set; }
        public string DeviceType { get; set; }
        public string EMVCommandType { get; set; }
        public string KSN { get; set; }
        public string KeyName { get; set; }
        public string SerialNumber { get; set; }
        public string XMLString { get; set; }
    }
}
