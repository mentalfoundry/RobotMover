using RobotMover.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RobotMover.Implementation.Constants;

namespace RobotMover.Interfaces
{
    // This interface defines the basic methods a robot needs to have.
    public interface IRobot
    {
        RobotResponse SetPlacement(int x, int y, Direction dir);
        RobotResponse RotateDirectionLeft();
        RobotResponse RotateDirectionRight();
        RobotResponse MovePlacementForward();

        // Report the current location of the robot
        RobotResponse Report();

        // Is the current position of the robot valid?
        bool isValid();
    }
}
