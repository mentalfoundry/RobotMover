using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMover.Interfaces
{
    public enum CommandResult
    {
        Success,
        Failed
    }

    public interface IRobotConsole
    {
        CommandResult ExecuteCommand(string command);
    }
}
