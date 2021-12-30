using System.Collections.Generic;

namespace SCRAv2.Dtos
{
    public class Firmware
    {
        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public string Description { get; set; }

        public string File { get; set; }

        public int ID { get; set; }

        public string Name { get; set; }

        public string PartNumber { get; set; }

        public List<FirmwareCommand> PostloadCommands { get; set; }

        public List<FirmwareCommand> PreloadCommands { get; set; }

        public byte TargetID { get; set; }

        public string Type { get; set; }

        public string Version { get; set; }
    }

}
