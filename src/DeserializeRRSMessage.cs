using System;
using System.Text;
using System.IO;

public class DeserializeRRSMessage
{
    public string? RawData { get; set; } = null;
    public int Channel { get; set; } = -1;
    public int MessageType { get; set; } = -1;
    public int Ttl { get; set; } = -1;
    public Message? Message { get; set; } = null;

    public DeserializeRRSMessage(string rawData, int channel)
    {
        RawData = rawData;
        Channel = channel;
        Deserialize();
    }

    public void Deserialize()
    {
        if (RawData == null || Channel == -1) return;

        try
        {
            byte[] bytes = Convert.FromBase64String(RawData);
            string message = Encoding.UTF8.GetString(bytes);

            if (message.ToLower() == "help" || message.ToLower() == "ouch")
            {
                Message = new ShoutCivilian(message);
            }
            else
            {
                BitStreamReader reader = new BitStreamReader(bytes);

                MessageType = reader.GetBits(5);

                if (Channel == 0)
                {
                    Ttl = reader.GetBits(3);
                }

                switch (MessageType)
                {
                    case 1:
                        Message = new MessageAmbulanceTeam(reader);
                        break;
                    case 2:
                        Message = new MessageBuilding(reader);
                        break;
                    case 3:
                        Message = new MessageCivilian(reader);
                        break;
                    case 4:
                        Message = new MessageFireBrigade(reader);
                        break;
                    case 5:
                        Message = new MessagePoliceForce(reader);
                        break;
                    case 6:
                        Message = new MessageRoad(reader);
                        break;
                    case 7:
                        Console.Error.WriteLine("未知ではないメッセージです");
                        break;
                    case 8:
                        Console.Error.WriteLine("未知ではないメッセージです");
                        break;
                    case 9:
                        Message = new CommandPolice(reader);
                        break;
                    case 10:
                        Console.Error.WriteLine("未知ではないメッセージです");
                        break;
                    case 11:
                        Console.Error.WriteLine("未知ではないメッセージです");
                        break;
                    default:
                        Console.Error.WriteLine("未知のメッセージです");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("えらー: " + e);
        }
    }

    public string? GetRawData() => RawData;

    public int GetChannel() => Channel;

    public int GetMessageType() => MessageType;

    public int GetTtl() => Ttl;

    public Message? GetMessage() => Message;
}
