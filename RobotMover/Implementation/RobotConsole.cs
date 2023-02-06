using RobotMover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static RobotMover.Program;

namespace RobotMover.Implementation
{
    public class RobotConsole : IRobotConsole
    {
        IRobotPlacement _currentPlacement;

        public RobotConsole(TableTop tableTop)
        {
            _currentPlacement = new RobotPlacement(tableTop);
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
            return _currentPlacement.SetPlacement(x, y, direction);
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
            else if (_currentPlacement.isValid())
            {
                switch (action)
                {
                    case "move":
                        _currentPlacement.MovePlacementForward();                        
                        break;

                    case "left":
                        _currentPlacement.RotateDirectionLeft();
                        break;

                    case "right":
                        _currentPlacement.RotateDirectionRight();                        
                        break;

                    case "report":
                        _currentPlacement.Report();                        
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
