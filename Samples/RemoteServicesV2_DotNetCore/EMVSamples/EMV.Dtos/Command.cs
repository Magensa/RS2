namespace EMV.Dtos
{
    public class Command
    {

        public int CommandType { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string ExecutionTypeEnum { get; set; }
    }
}
