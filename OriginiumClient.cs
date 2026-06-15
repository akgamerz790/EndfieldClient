using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

using EndfieldClient.AIC.Primitives;
using EndfieldClient.AIC.Handshaker;
using EndfieldClient.AIC.OutboundService;

namespace Endfield;

internal class OriginiumClient
{
    public static TcpClient _OriginiumClient = new TcpClient();
    public static string _ServerAddress = "127.0.0.1";
    public static int _ServerPort = 25565;

    public static async Task Main(string[] args)
    {
        await _OriginiumClient.ConnectAsync(_ServerAddress, _ServerPort);
        NetworkStream _NetworkStream = _OriginiumClient.GetStream();
        Console.WriteLine("[*] Connected.");

        await Handshake.Send(_NetworkStream, _ServerAddress, _ServerPort);
        Console.WriteLine("[!] Handshake packets sent...");
        await LoginSender.Send(_NetworkStream, "akgamerz_790");
        Console.WriteLine("[+] Login Start sent.");
        Console.WriteLine("[!] Login packets sent...");






        //int packetLength = VarIntReader.ReadVarInt(networkStream);

        //Console.WriteLine(
        //    $"Incoming Packet Length: {packetLength}");
    }
}
