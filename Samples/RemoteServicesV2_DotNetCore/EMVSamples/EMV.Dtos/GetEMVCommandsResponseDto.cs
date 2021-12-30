using System.Collections.Generic;

namespace EMV.Dtos
{
    public class GetEMVCommandsResponseDto
    {
        public List<Command> Commands { get; set; }
        public KeyValuePair<string, string>[] AdditionalOutputData { get; set; }
        public string CustomerTransactionId { get; set; }
        public string MagTranId { get; set; }
        public List<Command> PostloadCommands { get; set; }
        public List<Command> PreloadCommands { get; set; }
    }
}
