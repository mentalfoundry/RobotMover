using RobotMover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMover.Implementation
{
    public class RobotPlacement : IRobotPlacement
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

        public bool SetPlacement(int x, int y, Direction dir)
        {
            // Check if placement value is valid;            
            if (x >= 0 && x < _tabletop.array2D.GetLength(0) &&
                y >= 0 && y < _tabletop.array2D.GetLength(1) &&
                dir != Direction.Undefined)
            {
                // Set placement
                xcoordinate = x;
                ycoordinate = y;
                direction = dir;
                return true;
            }
            else return false;
        }

        public void RotateDirectionLeft()
        {
            switch (direction)
            {
                case Direction.North:
                    direction = Direction.West;
                    break;
                case Direction.West:
                    direction = Direction.South;
                    break;
                case Direction.South:
                    direction = Direction.East;
                    break;
                case Direction.East:
                    direction = Direction.North;
                    break;
            }
        }

        public void RotateDirectionRight() 
        {
            switch (direction)
            {
                case Direction.North:
                    direction = Direction.East;
                    break;
                case Direction.West:
                    direction = Direction.North;
                    break;
                case Direction.South:
                    direction = Direction.West;
                    break;
                case Direction.East:
                    direction = Direction.South;
                    break;
            }
        }

        public void MovePlacementForward()
        {
            switch (direction)
            {
                case Direction.North:
                    if (ycoordinate < _tabletop.array2D.GetLength(1) - 1)
                    {
                        ycoordinate++;
                    }
                    break;
                case Direction.West:
                    if (xcoordinate > 0)
                    {
                        xcoordinate--;
                    }
                    break;
                case Direction.South:
                    if (ycoordinate > 0)
                    {
                        ycoordinate--;
                    }
                    break;
                case Direction.East:
                    if (xcoordinate < _tabletop.array2D.GetLength(0) - 1)
                    {
                        xcoordinate++;
                    }
                    break;
            }
        }

        public void Report()
        {
            Console.WriteLine($"X:{xcoordinate},Y:{ycoordinate},F:{direction.ToString()}");
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
}
