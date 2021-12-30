using System.Collections.Generic;
using System.Text.Json;

namespace PPSCRAv2.Dtos
{
    public class GetCertLoadCommandResponseDto
    {
        public Command Command { get; set; }
        public KeyValuePair<string, string>[] AdditionalOutputData { get; set; }
        public string CustomerTransactionId { get; set; }
        public string MagTranId { get; set; }
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
