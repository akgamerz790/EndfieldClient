using System;
using System.Collections.Generic;
using System.Text;

namespace EndfieldClient.AIC.Primitives;

internal static class VarIntWriter
{
    public static void WriteVarInt(Stream stream, int value)
    {
        while (true)
        {
            if ((value & ~0x7F) == 0)
            {
                stream.WriteByte((byte)value);
                return;
            }

            stream.WriteByte((byte)((value & 0x7F) | 0x80));
            value >>= 7;
        }
    }
}
