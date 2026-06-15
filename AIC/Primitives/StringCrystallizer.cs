using System;
using System.Collections.Generic;
using System.Text;

namespace EndfieldClient.AIC.Primitives;

internal static class StringCrystallizer
{
    public static void WriteString(Stream stream, string value)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(value);

        VarIntWriter.WriteVarInt(stream, bytes.Length);
        stream.Write(bytes, 0, bytes.Length);
    }
    public static void CrystallizeString(Stream stream, string value)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(value);

        VarIntWriter.WriteVarInt(stream, bytes.Length);
        stream.Write(bytes, 0, bytes.Length);
    }
}
