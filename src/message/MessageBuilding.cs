public class MessageBuilding : Message
{
    public int Id { get; set; } = -1;
    public int Brokeness { get; set; } = -1;
    public int Fireryness { get; set; } = -1;
    public int Temperature { get; set; } = -1;

    public MessageBuilding(BitStreamReader reader)
    {
        Id = reader.GetBits(32);

        Brokeness = reader.GetBits(1) == 1 ? reader.GetBits(32) : -1;
        Fireryness = reader.GetBits(1) == 1 ? reader.GetBits(32) : -1;
        Temperature = reader.GetBits(1) == 1 ? reader.GetBits(32) : -1;
    }
}
