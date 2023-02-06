using RobotMover.Interfaces;
using System;
using static RobotMover.Implementation.Constants;

namespace RobotMover.Implementation
{
    public class RobotService : IRobotService
    {
        IRobot _robot;

        public RobotService(IRobot robot)
        {
            _robot = robot;
        }

        private RobotResponse TryPlaceRobot(string placementParameters)
        {
            // Split parameters out of string
            var parameters = placementParameters.Split(',');
            
            if(!Int32.TryParse(parameters[0], out int x))
            {
                return new RobotResponse(CommandResult.Failed);
            }

            if(!Int32.TryParse(parameters[1], out int y))
            {
                return new RobotResponse(CommandResult.Failed);
            }

            if (!Enum.TryParse<Direction>(parameters[2], true, out Direction direction)) 
            {
                return new RobotResponse(CommandResult.Failed);
            }

            // Set placement
            return _robot.SetPlacement(x, y, direction);
        }

        public RobotResponse ExecuteCommand(string command)
        {
            // Get action from command
            var action = "";
            int index = command.IndexOf(' ');
            if (index != -1)
            {
                action = command.Substring(0, index).ToLower();
            }
            else
            {
                action = command.ToLower();
            }

            // Always try to place the robot
            if (action == "place" && index != -1)
            {
                var placementParameters = command.Substring(index);
                return TryPlaceRobot(placementParameters);                
            }

            // Otherwise check if robot is placed properly before trying anything else.
            else if (_robot.isValid())
            {
                switch (action)
                {
                    case "move":
                        return _robot.MovePlacementForward();                                                

                    case "left":
                        return _robot.RotateDirectionLeft();

                    case "right":
                        return _robot.RotateDirectionRight();

                    case "report":
                        return _robot.Report();
                }
            }

            return new RobotResponse(CommandResult.Failed);
        }
    }

}
