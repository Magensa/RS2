using System.Collections.Generic;

namespace PPSCRAv2.Dtos
{
    public class GetKeyLoadCommandRequestDto
    {
        public string CustomerCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BillingLabel { get; set; }
        public string CustomerTransactionId { get; set; }
        public List<KeyValuePair<string, string>> AdditionalRequestData { get; set; }
        public string Challenge { get; set; }
        public string DeviceCert { get; set; }
        public string DeviceType { get; set; }
        public string KSI { get; set; }
        public string KSN { get; set; }
        public string KeyType { get; set; }

    }
}
