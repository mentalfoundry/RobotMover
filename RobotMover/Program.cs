using RobotMover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace RobotMover
{
    internal class Program
    {
        public enum CommandResult
        {
            Success,
            Failed,
            Error
        }

        public enum Direction
        {
            Undefined,
            North,
            East,
            South,
            West            
        }

        public class TableTop
        {
            public int[,] array2D {get;}

            public TableTop(int[,] newTableTop)
            {
                array2D = newTableTop;
            }
        }

        public class RobotPlacement
        {
            // Current Placement is dependent on a Grid
            TableTop _tabletop;

            // Current Robot Placement Values
            public int xcoordinate { get; set; }
            public int ycoordinate { get; set; }
            public Direction direction { get; set; }

            public RobotPlacement(TableTop newTableTop)
            {
                _tabletop = newTableTop;
                xcoordinate = -1;
                ycoordinate = -1;
                direction = Direction.Undefined;
            }

            public void SetPlacement(int x, int y, Direction dir)
            {
                if (xcoordinate >= 0 && xcoordinate <= _tabletop.array2D.GetLength(0) &&
                    ycoordinate >= 0 && ycoordinate <= _tabletop.array2D.GetLength(1) &&
                    direction != Direction.Undefined)
                {
                    xcoordinate = x;
                    ycoordinate = y;
                    direction = dir;
                }
            }

            public bool isValid()
            {
                // direction is only undefined if placement has never been set
                if (direction != Direction.Undefined)
                {
                    return true;
                }
                return false;
            }
        }        

        public class Robot : IRobot
        {
            RobotPlacement _currentPlacement;

            public Robot(TableTop tableTop)
            {
                _currentPlacement = new RobotPlacement(tableTop);
            }

            public CommandResult ExecuteCommand(string command)
            {
                // Get action from command
                int index = command.IndexOf(' ');
                var action = command.Substring(0, index).ToLower();

                switch (action)
                {
                    case "place":
                        Console.WriteLine("placing");
                        // Check if value is on the board;

                        // If valid then set placement
                        _currentPlacement.SetPlacement(0,0,Direction.North);
                        break;

                    case "move":
                        if(_currentPlacement.isValid())
                        {
                            //Do thing
                        }
                        Console.WriteLine("");
                        break;

                    case "left":
                        Console.WriteLine("");
                        break;

                    case "right":
                        Console.WriteLine("");
                        break;

                    case "report":
                        Console.WriteLine("");
                        break;
                    default:
                        return CommandResult.Failed;
                }

                return CommandResult.Success;                
            }
        }

        static void Main(string[] args)
        {

            // TheGrid
            int[,] array = new int[5, 5];

            Console.WriteLine("HelloWorld");
            Console.ReadKey();
        }
    }
}
