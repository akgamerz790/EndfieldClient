using EndfieldClient.AIC.Primitives;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace EndfieldClient.AIC.OutboundService;

internal static class PacketSender
{

    public static async Task Send(
        NetworkStream _networkStream,
        MemoryStream _packet)
        {
            byte[] payload = _packet.ToArray();

            VarIntWriter.WriteVarInt(
                _networkStream,
                payload.Length
            );

            await _networkStream.WriteAsync(payload);
        }
}