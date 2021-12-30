using System.Collections.Generic;
using System.Text.Json;

namespace SCRAv2.Dtos
{
    public class GetCommandListResponseDto
    {
        //public string PageContent { get; set; }
        public string CustomerTransactionId { get; set; }
        public List<Command> Commands { get; set; }
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
