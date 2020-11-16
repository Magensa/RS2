using System.Collections.Generic;

namespace PPSCRAv2.Dtos
{
    public class GetCommandListByDeviceRequestDto
    {
        public string CustomerCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BillingLabel { get; set; }
        public string CustomerTransactionId { get; set; }
        public List<KeyValuePair<string, string>> AdditionalRequestData { get; set; }
        public string DeviceType { get; set; }

    }
}
