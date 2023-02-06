using RobotMover.Interfaces;
using System;

namespace RobotMover.Implementation
{
    public class RobotConsole : IRobotConsole
    {
        IRobot _robot;

        public RobotConsole(TableTop tableTop)
        {
            _robot = new Basic2DGridRobot(tableTop);
        }

        private bool TryPlaceRobot(string placementParameters)
        {
            // Split parameters out of string
            var parameters = placementParameters.Split(',');
            
            if(!Int32.TryParse(parameters[0], out int x))
            {
                return false;
            }

            if(!Int32.TryParse(parameters[1], out int y))
            {
                return false;
            }

            if (!Enum.TryParse<Direction>(parameters[2], true, out Direction direction)) 
            {
                return false;
            }

            // Set placement
            return _robot.SetPlacement(x, y, direction);
        }

        public CommandResult ExecuteCommand(string command)
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

            // Always try place the robot...
            if (action == "place" && index != -1)
            {
                var placementParameters = command.Substring(index);
                var placedRobotSuccessfully = TryPlaceRobot(placementParameters);
                
                if(placedRobotSuccessfully)
                { 
                    return CommandResult.Success; 
                }
                else
                {
                    return CommandResult.Failed;
                }
            }

            // Otherwise check if robot is placed properly before trying anything else.
            else if (_robot.isValid())
            {
                switch (action)
                {
                    case "move":
                        _robot.MovePlacementForward();                        
                        break;

                    case "left":
                        _robot.RotateDirectionLeft();
                        break;

                    case "right":
                        _robot.RotateDirectionRight();                        
                        break;

                    case "report":
                        _robot.Report();                        
                        break;
                    default: 
                        return CommandResult.Failed;
                }

                return CommandResult.Success;
            }

            return CommandResult.Failed;
        }
    }

}
