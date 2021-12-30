using System.Text.Json;

namespace SCRAv2.Dtos
{
    public class GetCommandByKSNResponseDto
    {
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
