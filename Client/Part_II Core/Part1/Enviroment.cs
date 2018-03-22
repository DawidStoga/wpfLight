using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.CoreCSProgramming
{
    partial class CoreCSPart1
    {

        /// <summary>
        /// System.Enviroment Class
        /// </summary>
        /// <remarks>
        /// Example of using static methods of Enviriment class
        /// Example of using Start from System.Diagnostic class
        /// </remarks>
        private static void Enviroment()
        {
            Console.WriteLine("\n------------3.2  System.Enviroment Class------------\n ");
            Console.WriteLine($@"
                Environment.CommandLine:            {Environment.CommandLine} 
                Environment.CurrentDirectory:       { Environment.CurrentDirectory}
                Environment.Is64BitOperatingSystem: { Environment.Is64BitOperatingSystem}
                Environment.MachineName:            { Environment.MachineName}
                Environment.OSVersion:              { Environment.OSVersion}          
                Environment.ProcessorCount:         { Environment.ProcessorCount}    
                Environment.SystemDirectory:        { Environment.SystemDirectory}
                Environment.SystemPageSize:         { Environment.SystemPageSize}   Gets the number of bytes in the operating system's memory page.
                Environment.TickCount:              { Environment.TickCount}        Gets the number of milliseconds elapsed since the system started.
                Environment.UserDomainName:         { Environment.UserDomainName}  Gets the network domain name associated with the current user.
                Environment.Version:                { Environment.Version}
                ");
            Console.WriteLine("GetCommandLineArgs:");
            foreach (var r in Environment.GetCommandLineArgs())
            {
                Console.Write(r + ", ");
            }
            Console.WriteLine("\nGetLogicalDrives:\n   ");
            foreach (var r in Environment.GetLogicalDrives())
            {
                Console.Write(r + ",");
            }


            //System.Diagnostic

            Process wpfProc = null;
          //  wpfProc = Process.Start(@"E:\Projecty NET\wpfLight\AirBusWPF\bin\Debug\AirBusWPF.exe");
            Console.WriteLine("\nClose WPF asap to get exit Code");
          //  wpfProc.WaitForExit(30000);
          //  Console.WriteLine("WPF exit Code: {0}", wpfProc.ExitCode );

            global::System.Console.WriteLine($"{Environment.StackTrace}   \n Processors {Environment.ProcessorCount}  sys Dir {Environment.SystemDirectory}");

            /*
            ------------3.2  System.Enviroment Class------------


                    Environment.CommandLine:            "E:\Projecty NET\wpfLight\Client\bin\Debug\Client.exe" daw kto jest
                    Environment.CurrentDirectory:       E:\Projecty NET\wpfLight\Client\bin\Debug
                    Environment.Is64BitOperatingSystem: True
                    Environment.MachineName:            DAWID-KOMPUTER
                    Environment.OSVersion:              Microsoft Windows NT 6.1.7601 Service Pack 1
                    Environment.ProcessorCount:         4
                    Environment.SystemDirectory:        C:\Windows\system32
                    Environment.SystemPageSize:         4096   Gets the number of bytes in the operating system's memory page.
                    Environment.TickCount:              21068824        Gets the number of milliseconds elapsed since the system started.
                    Environment.UserDomainName:         Dawid-Komputer  Gets the network domain name associated with the current user.
                    Environment.Version:                4.0.30319.42000

    GetCommandLineArgs:
            E:\Projecty NET\wpfLight\Client\bin\Debug\Client.exe, daw, kto, jest,
    GetLogicalDrives:
            C:\,D:\,E:\,F:\,G:\,H:\,I:\,
    Close WPF asap to get exit Code

    WPF exit Code: 532
       at System.Environment.GetStackTrace(Exception e, Boolean needFileInfo)
       at System.Environment.get_StackTrace()
       at Client.CoreCSProgramming.CoreCSPart1.Enviroment() in E:\Projecty NET\wpfLight\Client\Part_II Core\CoreCSPart1.cs:line 58
       at Client.CoreCSProgramming.CoreCSPart1.RunExamples(Examples ex) in E:\Projecty NET\wpfLight\Client\Part_II Core\CoreCSPart1Usr.cs:line 29
       at Client.CSharpBook.Main(String[] args) in E:\Projecty NET\wpfLight\Client\C SharpBook.cs:line 39
     Processors 4  sys Dir C:\Windows\system32
*/
        }
    }
}
