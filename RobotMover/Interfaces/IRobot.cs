using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RobotMover.Program;

namespace RobotMover.Interfaces
{
    public interface IRobot
    {
        CommandResult ActionPlace(RobotPlacement newplacement);
        CommandResult ActionLeft(Direction currentDirection);
        CommandResult ActionRight(Direction currentDirection);
        CommandResult ActionMove(RobotPlacement currentPlacement);
        CommandResult ExecuteCommand(string command);
    }
}
