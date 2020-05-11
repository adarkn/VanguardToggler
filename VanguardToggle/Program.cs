using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace VanguardToggle
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("[?]VanguardToggler V1");
            Console.WriteLine("[?]created by adarkn");
            Console.WriteLine("[*]Checking if Vanguard is enabled or disabled");
            if (File.Exists(@"C:\Program Files\Riot Vanguard\vgk.sys")) 
            {
                Console.WriteLine("[!]Vanguard is enabled, disabling");
                try
                {
                    File.Move(@"C:\Program Files\Riot Vanguard\vgk.sys", @"C:\Program Files\Riot Vanguard\vgk1.sys");
                    Console.WriteLine("[!]Vanguard disabled, restart is required, press enter to restart.");
                    Console.ReadLine();
                    Process.Start("shutdown.exe", "-r -t 0");
                }
                catch (System.UnauthorizedAccessException)
                {
                    Console.WriteLine("[!]Access Unauthorized, run program as admin");
                }
            }else if(File.Exists(@"C:\Program Files\Riot Vanguard\vgk1.sys"))
            {
                Console.WriteLine("[!]Vanguard is disabled, enabling");
                try
                {
                    File.Move(@"C:\Program Files\Riot Vanguard\vgk1.sys", @"C:\Program Files\Riot Vanguard\vgk.sys");
                    Console.WriteLine("[!]Vanguard enabled, restart is required, press enter to restart.");
                    Console.ReadLine();
                    Process.Start("shutdown.exe", "r -t 0");
                }catch(System.UnauthorizedAccessException)
                {
                    Console.WriteLine("[!]Access Unauthorized, run program as admin");
                }
            }else
            {
                Console.WriteLine("[*]vgk.sys/vgk1.sys doesn't exist, Valorant may not be installed, install it and run the program");
                Console.WriteLine("[*]Exitting software...");
                System.Threading.Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
    }
}
