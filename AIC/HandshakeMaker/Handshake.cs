using EndfieldClient.AIC.Primitives;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

using EndfieldClient.AIC.AICDB;
using EndfieldClient.AIC.RhodesIslandLoggingUtility;
using EndfieldClient.AIC.OutboundService;

namespace EndfieldClient.AIC.Handshaker;

internal static class Handshake
{
    public static MemoryStream _MemoryStream = new MemoryStream();
    public static async void _Crystallize()
    {
        VarIntWriter.WriteVarInt(_MemoryStream, 0x00); // Handshake ID
        VarIntWriter.WriteVarInt(_MemoryStream, 772);  // Protocol Version
    }

    public static async Task Send(NetworkStream _networkStream, string _ServerAddress, int? _ServerPort)
    {
        int RI_ServerPort;
        if (_ServerPort == null)
        {
            Logger._Log("Server Port not supplied, using Default 25565...");
            RI_ServerPort = 25565;
        }
        //else
        //{
        //    RI_ServerPort = _ServerPort.Value;
        //}

        RI_ServerPort = _ServerPort ?? 25565;
        
        using MemoryStream packet = new();

        VarIntWriter.WriteVarInt(packet, 0x00);
        VarIntWriter.WriteVarInt(packet, AICDatabase._ProtocolVersion);

        StringCrystallizer.CrystallizeString(
            packet,
            _ServerAddress
        );

        packet.WriteByte((byte)(RI_ServerPort >> 8));
        packet.WriteByte((byte)RI_ServerPort);

        VarIntWriter.WriteVarInt(packet, 2);

        await PacketSender.Send(_networkStream, packet);
    }
}
