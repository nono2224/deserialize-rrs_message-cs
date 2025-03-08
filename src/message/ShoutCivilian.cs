public class ShoutCivilian : Message
{
    public string? shout { get; set; } = null;

    public ShoutCivilian(string shout)
    {
        this.shout = shout;
    }
}
