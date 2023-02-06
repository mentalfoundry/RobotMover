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
            var tableTop = new TableTop(new int[5, 5]); // Todo: tablesize can be added to appsettings
            var robot = new Basic2DGridRobot(tableTop);
            var robotService = new RobotService(robot);


            Console.WriteLine("Done!");
            Console.WriteLine("Please enter commands. Type END to exit.");

            var command = "";
            while(command != "end")
            {
                command = Console.ReadLine().ToLower();                
                var result = robotService.ExecuteCommand(command);
                if (result == CommandResult.Success)
                {
                    Console.WriteLine("> ...ok");
                }
                else if (command != "end")
                {
                    Console.WriteLine("> ...invalid command!");
                }
            }

            Console.WriteLine("> Press any key to quit.");
            Console.ReadKey();
        }
    }
}
