using RobotMover.Implementation;
using RobotMover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace RobotMover
{
    internal class Program
    {          
        static void Main(string[] args)
        {
            Console.Write("Initializing robot...");

            // Setting TableTop size
            var tableTop = new TableTop(new int[5, 5]);
            var Robot = new RobotConsole(tableTop);

            Console.WriteLine("Done!");
            Console.WriteLine("Please enter commands. Type END to exit.");

            var command = "";
            while(command.ToLower() != "end")
            {
                command = Console.ReadLine();                
                var result = Robot.ExecuteCommand(command);
                Console.CursorTop--;
                Console.CursorLeft = command.Length;
                if (result == CommandResult.Success)
                {
                    Console.WriteLine(" ...ok!");
                }
                else
                {
                    Console.WriteLine(" ...invalid command!");
                }
            }

            Console.WriteLine("Robot shut down. Press any key to quit.");
            Console.ReadKey();
        }
    }
}
