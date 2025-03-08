public class CommandPolice : Message
{
    public int To { get; set; } = -1;
    public int Target { get; set; } = -1;
    public string? Action { get; set; } = null;
    public bool? Broadcast { get; set; } = null;

    public CommandPolice(BitStreamReader reader)
    {
        To = reader.GetBits(1) == 1 ? reader.GetBits(32) : -1;
        Target = reader.GetBits(1) == 1 ? reader.GetBits(32) : -1;
        int actionNum = reader.GetBits(4);
        Broadcast = To == -1;

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
            Action = "CLEAR";
        }
        else if (actionNum == 3)
        {
            Action = "AUTONOMY";
        }
    }
}
