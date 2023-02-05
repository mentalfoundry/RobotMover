using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RobotMover.Program;

namespace RobotMover.Interfaces
{
    public enum CommandResult
    {
        Success,
        Failed
    }

    public interface IRobot
    {
        CommandResult ExecuteCommand(string command);
    }
}
