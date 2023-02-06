using RobotMover.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMover.Interfaces
{
    public interface IRobotService
    {
        RobotResponse ExecuteCommand(string command);
    }
}
