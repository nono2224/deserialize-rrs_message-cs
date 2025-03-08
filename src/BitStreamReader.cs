using System;
using System.IO;

public class BitStreamReader
{
    private byte[] stream;
    private int index;

    public BitStreamReader(byte[] stream)
    {
        this.stream = stream;
        this.index = 0;
    }
    public BitStreamReader(Stream inputstream)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            inputstream.CopyTo(ms);
            this.stream = ms.ToArray();
        }
        this.index = 0;
    }

    public int GetBits(int len)
    {
        if (stream.Length * 8 < index + len)
        {
            throw new IndexOutOfRangeException("ArrayIndexOutOfBoundsException");
        }

        int val = 0;
        for (int i = 0; i < len; i++)
        {
            int byteIndex = (int)Math.Floor((double)index / 8);
            int bitOffset = 7 - (index % 8);
            int num = (stream[byteIndex] >> bitOffset) & 0x1;
            val = (val << 1) | num;
            index++;
        }
        return val;
    }

    public void WriteBack(int len)
    {
        index -= len;
        if (index < 0) // indexが負にならないようにする
        {
            index = 0; // または例外をスロー
        }
    }

    public void WriteForward(int len)
    {
        index += len;
        if (index > stream.Length * 8)
        {
            index = stream.Length * 8; // indexが範囲外にならないようにする
        }
    }

    public int GetIndex()
    {
        return index;
    }

    public int GetRemainBuffer()
    {
        return stream.Length * 8 - index;
    }

    public byte ReadByte()
    {
        if (index + 8 > stream.Length * 8)
        {
            throw new IndexOutOfRangeException("Cannot read beyond the end of the stream.");
        }
        byte value = (byte)GetBits(8);
        return value;

    }

    public short ReadShort()
    {
        if (index + 16 > stream.Length * 8)
        {
            throw new IndexOutOfRangeException("Cannot read beyond the end of the stream.");
        }
        // GetBits を 8 ビットずつ 2 回呼び出して、short (16 ビット) を読み取る
        int highByte = GetBits(8);
        int lowByte = GetBits(8);

        // C# では、バイトオーダーは通常リトルエンディアンなので、
        // 上位バイトと下位バイトを適切に結合する
        short value = (short)((highByte << 8) | lowByte);

        return value;
    }

    public int ReadInt()
    {
        if (index + 32 > stream.Length * 8)
        {
            throw new IndexOutOfRangeException("Cannot read beyond the end of the stream.");
        }
        // GetBits を 8 ビットずつ 4 回呼び出して、int (32 ビット) を読み取る
        int byte1 = GetBits(8);
        int byte2 = GetBits(8);
        int byte3 = GetBits(8);
        int byte4 = GetBits(8);

        // バイトを結合して int 値を作成
        return (byte1 << 24) | (byte2 << 16) | (byte3 << 8) | byte4;
    }

}