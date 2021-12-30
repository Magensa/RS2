using System.Collections.Generic;
using System.Text.Json;

namespace PPSCRAv2.Dtos
{
    public class GetKeyLoadCommandResponseDto
    {
        public Command Command { get; set; }
        public KeyValuePair<string, string>[] AdditionalOutputData { get; set; }
        public string CustomerTransactionId { get; set; }
        public string MagTranId { get; set; }
        public string BaseKCV { get; set; }
        public string DukptKCV { get; set; }
        public string KeyPrefix { get; set; }
        public string KeyType { get; set; }
        public override string ToString()
        {
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return json;
        }
    }
}
