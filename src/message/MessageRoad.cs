public class MessageRoad : Message
{
    public int Id { get; set; } = -1;
    public int BlockadeId { get; set; } = -1;
    public int Cost { get; set; } = -1;
    public int? X { get; set; } = null;
    public int? Y { get; set; } = null;
    public int? Passable { get; set; } = null;

    public MessageRoad(BitStreamReader reader)
    {
        Id = reader.GetBits(32);

        BlockadeId = reader.GetBits(1) == 1 ? reader.GetBits(32) : -1;
        Cost = reader.GetBits(1) == 1 ? reader.GetBits(32) : -1;
        X = reader.GetBits(1) == 1 ? reader.GetBits(32) : null;
        Y = reader.GetBits(1) == 1 ? reader.GetBits(32) : null;
        Passable = reader.GetBits(1) == 1 ? reader.GetBits(1) : null;
    }
}
