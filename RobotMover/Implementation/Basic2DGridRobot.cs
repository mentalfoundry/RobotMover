using RobotMover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RobotMover.Implementation.Constants;

namespace RobotMover.Implementation
{
    public class Basic2DGridRobot : IRobot
    {
        // Grid for bounds reference.
        TableTop _tabletop;

        // Current Robot Placement Values
        public int xcoordinate { get; set; }
        public int ycoordinate { get; set; }
        public Direction direction { get; set; }

        public Basic2DGridRobot(TableTop newTableTop)
        {
            _tabletop = newTableTop;
            xcoordinate = -1;
            ycoordinate = -1;
            direction = Direction.Undefined;
        }

        public RobotResponse SetPlacement(int x, int y, Direction dir)
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
                return new RobotResponse(CommandResult.Success);
            }
            
            return new RobotResponse(CommandResult.Failed);
        }

        public RobotResponse RotateDirectionLeft()
        {
            switch (direction)
            {
                case Direction.North:
                    direction = Direction.West;
                    return new RobotResponse(CommandResult.Success);
                case Direction.West:
                    direction = Direction.South;
                    return new RobotResponse(CommandResult.Success);
                case Direction.South:
                    direction = Direction.East;
                    return new RobotResponse(CommandResult.Success);
                case Direction.East:
                    direction = Direction.North;
                    return new RobotResponse(CommandResult.Success);
            }

            return new RobotResponse(CommandResult.Failed);
        }

        public RobotResponse RotateDirectionRight() 
        {
            switch (direction)
            {
                case Direction.North:
                    direction = Direction.East;
                    return new RobotResponse(CommandResult.Success);
                case Direction.West:
                    direction = Direction.North;
                    return new RobotResponse(CommandResult.Success);
                case Direction.South:
                    direction = Direction.West;
                    return new RobotResponse(CommandResult.Success);
                case Direction.East:
                    direction = Direction.South;
                    return new RobotResponse(CommandResult.Success);
            }

            return new RobotResponse(CommandResult.Failed);
        }

        public RobotResponse MovePlacementForward()
        {
            switch (direction)
            {
                case Direction.North:
                    if (ycoordinate < _tabletop.array2D.GetLength(1) - 1)
                    {
                        ycoordinate++;
                    }
                    return new RobotResponse(CommandResult.Success);
                case Direction.West:
                    if (xcoordinate > 0)
                    {
                        xcoordinate--;
                    }
                    return new RobotResponse(CommandResult.Success);
                case Direction.South:
                    if (ycoordinate > 0)
                    {
                        ycoordinate--;
                    }
                    return new RobotResponse(CommandResult.Success);
                case Direction.East:
                    if (xcoordinate < _tabletop.array2D.GetLength(0) - 1)
                    {
                        xcoordinate++;
                    }
                    return new RobotResponse(CommandResult.Success);
            }

            return new RobotResponse(CommandResult.Failed);
        }

        public RobotResponse Report()
        {
            // Direction is only set when a valid move has been made
            if (isValid())
            {
                return new RobotResponse(CommandResult.Success, $"X:{xcoordinate},Y:{ycoordinate},F:{direction.ToString()}");
            }

            return new RobotResponse(CommandResult.Failed);
        }

        public bool isValid()
        {
            // Check if current position values are valid for the given board            
            if (direction != Direction.Undefined &&
                (xcoordinate >= 0 && xcoordinate < _tabletop.array2D.GetLength(0) - 1) &&
                (ycoordinate >= 0 && ycoordinate < _tabletop.array2D.GetLength(1) - 1))
            {
                return true;
            }

            return false;
        }
    }
}
