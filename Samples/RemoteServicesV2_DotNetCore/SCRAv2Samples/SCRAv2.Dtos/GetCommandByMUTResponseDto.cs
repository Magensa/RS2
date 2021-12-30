using System.Text.Json;

namespace SCRAv2.Dtos
{
    public class GetCommandByMUTResponseDto
    {
        //public string PageContent { get; set; }
        public Command Command { get; set; }
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
