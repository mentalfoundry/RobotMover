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
using static RobotMover.Implementation.Constants;

namespace RobotMover
{
    internal class Program
    {          
        static void Main(string[] args)
        {
            Console.Write("Initializing robot... ");

            // Setting TableTop size
            var tableTop = new TableTop(new int[5, 5]); // Todo: tablesize can be added to appsettings
            var robot = new Basic2DGridRobot(tableTop);
            var robotService = new RobotService(robot);
            Console.WriteLine("Done!");


            // Starting input loop
            Console.WriteLine("Please enter commands. Type END to exit.");
            Console.WriteLine("");

            var command = "";
            while(command != "end")
            {
                command = Console.ReadLine().ToLower();                
                robotService.RecieveInput(command);                
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
