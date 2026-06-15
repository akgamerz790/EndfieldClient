using System;
using System.Collections.Generic;
using System.Text;

namespace EndfieldClient.AIC.RhodesIslandLoggingUtility;

internal static class Logger
{
    public static void _Log(string message)
    {
        Console.WriteLine("[!] " + message + "... #");
    }
}
