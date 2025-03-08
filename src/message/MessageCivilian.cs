public class MessageCivilian : Message
{
    public int Id { get; set; } = -1;
    public int Hp { get; set; } = -1;
    public int Buriedness { get; set; } = -1;
    public int Damage { get; set; } = -1;
    public int Position { get; set; } = -1;

    public MessageCivilian(BitStreamReader reader)
    {
        Id = reader.GetBits(32);

        Hp = reader.GetBits(1) == 1 ? reader.GetBits(14) : -1;
        Buriedness = reader.GetBits(1) == 1 ? reader.GetBits(13) : -1;
        Damage = reader.GetBits(1) == 1 ? reader.GetBits(14) : -1;
        Position = reader.GetBits(1) == 1 ? reader.GetBits(32) : -1;
    }
}
