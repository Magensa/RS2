using System.Collections.Generic;
using System.Text.Json;

namespace SCRAv2.Dtos
{
    public class GetKeyListResponseDto
    {
        public string CustomerTransactionId { get; set; }
        public string MagTranId { get; set; }
        public List<SCRAvkey> ScravKeys { get; set; }
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
