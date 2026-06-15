using EndfieldClient.AIC.Primitives;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace EndfieldClient.AIC.OutboundService
{
    internal static class LoginSender
    {
        public static async Task Send(
        NetworkStream networkStream,
        string username)
        {
            using MemoryStream packet = new();

            VarIntWriter.WriteVarInt(packet, 0x00);

            StringCrystallizer.CrystallizeString(
                packet,
                username
            );

            await PacketSender.Send(networkStream, packet);
        }
    }
}
