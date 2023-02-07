using RobotMover.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMover.Interfaces
{
    // This interface is for how users interact with a robot.
    public interface IRobotConsoleService
    {
        // Method for accepting console input commands from the user.
        // Prints out any relevant replies from the robot
        void RecieveInput(string command);

        // Sanitizes user input and triggers robot command execution.
        RobotResponse ExecuteCommand(string command);

        
    }
}
