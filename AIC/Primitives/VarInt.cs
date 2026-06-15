using System;
using System.Collections.Generic;
using System.Text;

namespace EndfieldClient.AIC.Primitives
{
    internal class VarInt
    {
        public static void Write(Stream _stream, int _value)
        {
            while (true)
            {
                if ((_value & ~0x7F) == 0)
                {
                    _stream.WriteByte((byte)_value);
                    return;
                }

                _stream.WriteByte((byte)((_value & 0x7F) | 0x80));
                _value >>= 7;
            }
        }
    }
}
