public class MessageAmbulanceTeam : Message
{
    public int Id { get; set; } = -1;
    public int Hp { get; set; } = -1;
    public int Buriedness { get; set; } = -1;
    public int Damage { get; set; } = -1;
    public int Position { get; set; } = -1;
    public int Target { get; set; } = -1;
    public string? Action { get; set; } = null;

    public MessageAmbulanceTeam(BitStreamReader reader)
    {
        Id = reader.GetBits(32);

        Hp = reader.GetBits(1) == 1 ? reader.GetBits(14) : -1;
        Buriedness = reader.GetBits(1) == 1 ? reader.GetBits(13) : -1;
        Damage = reader.GetBits(1) == 1 ? reader.GetBits(14) : -1;
        Position = reader.GetBits(1) == 1 ? reader.GetBits(32) : -1;
        Target = reader.GetBits(1) == 1 ? reader.GetBits(32) : -1;
        int actionNum = reader.GetBits(4);

        if (actionNum == 0)
        {
            Action = "REST";
        }
        else if (actionNum == 1)
        {
            Action = "MOVE";
        }
        else if (actionNum == 2)
        {
            Action = "RESCUE";
        }
        else if (actionNum == 3)
        {
            Action = "LOAD";
        }
        else if (actionNum == 4)
        {
            Action = "UNLOAD";
        }
    }
}
