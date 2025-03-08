using System;
using System.Text.Json;

public class Example
{
    public static void Main(string[] args)
    {
        // AK_SPEAKコマンドには，送信したエージェントのエンティティIDと，送信したStep(Time)，送信に使用したチャンネル，送信した生データの4つが含まれます
        int entityId = 11111111; //送信したエージェントのエンティティID
        int step = 99; //送信したステップ
        int channel = 1; //送信に使用したチャンネル
        string rawData = "MAAAbwhg"; //送信した生データ

        // 生データとチャンネルと渡すと，メッセージの内容を解読してくれます
        DeserializeRRSMessage message = new DeserializeRRSMessage(rawData, channel);

        Console.WriteLine("DeserializeRRSMessage:");
        Console.WriteLine($"  RawData: {message.RawData}"); // 送信した生データ
        Console.WriteLine($"  Channel: {message.Channel}"); // 送信に使用したチャンネル
        Console.WriteLine($"  MessageType: {message.MessageType}"); // メッセージが市民の叫び以外だった場合に格納されるメッセージの種類 詳しくはadf-core-javaのStandardMessageBundle.javaより
        Console.WriteLine($"  Ttl: {message.Ttl}"); // Channelが0だった場合（音声通信）に格納される Time to Live -> ネットワーク内のパケットやレコードが破棄されるまでの時間を表す値

        if (message.Message != null)
        {
            if (message.Message is ShoutCivilian shout)
            {
                Console.WriteLine($"    shout: {shout.shout}");
            }

            // MessageCivilian の場合、プロパティを表示
            if (message.Message is MessageCivilian civilian)
            {
                Console.WriteLine($"    Id: {civilian.Id}"); // 市民のエンティティID
                Console.WriteLine($"    Hp: {civilian.Hp}"); // 市民の体力
                Console.WriteLine($"    Buriedness: {civilian.Buriedness}"); // 市民の埋没度
                Console.WriteLine($"    Damage: {civilian.Damage}"); // 市民のダメージ
                Console.WriteLine($"    Position: {civilian.Position}"); // 市民のいる場所 市民のいる建物や道路のエンティティIDが格納される
            }

            if (message.Message is MessageFireBrigade fb)
            {
                Console.WriteLine($"    Id: {fb.Id}");
                Console.WriteLine($"    Hp: {fb.Hp}");
                Console.WriteLine($"    Buriedness: {fb.Buriedness}");
                Console.WriteLine($"    Damage: {fb.Damage}");
                Console.WriteLine($"    Position: {fb.Position}");
                Console.WriteLine($"    Target: {fb.Target}");
                Console.WriteLine($"    Water: {fb.Water}");
                Console.WriteLine($"    Action: {fb.Action}");
            }

            if (message.Message is MessageRoad road)
            {
                Console.WriteLine($"    Id: {road.Id}");
                Console.WriteLine($"    BlockadeId: {road.BlockadeId}");
                Console.WriteLine($"    Cost: {road.Cost}");
                Console.WriteLine($"    X: {road.X}");
                Console.WriteLine($"    Y: {road.Y}");
                Console.WriteLine($"    Passable: {road.Passable}");
            }
        }
    }
}
