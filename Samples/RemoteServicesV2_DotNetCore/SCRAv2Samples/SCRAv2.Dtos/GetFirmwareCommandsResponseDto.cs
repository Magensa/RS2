using System.Collections.Generic;
using System.Text.Json;

namespace SCRAv2.Dtos
{
    public class GetFirmwareCommandsResponseDto
    {
        //public string PageContent { get; set; }
        public string CustomerTransactionId { get; set; }
        public string MagTranId { get; set; }
        public List<string> Commands { get; set; }
        public List<FirmwareCommand> PostloadCommands { get; set; }
        public List<FirmwareCommand> PreloadCommands { get; set; }
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
