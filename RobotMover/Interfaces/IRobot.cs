using RobotMover.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RobotMover.Implementation.Constants;

namespace RobotMover.Interfaces
{
    public interface IRobot
    {
        RobotResponse SetPlacement(int x, int y, Direction dir);
        RobotResponse RotateDirectionLeft();
        RobotResponse RotateDirectionRight();
        RobotResponse MovePlacementForward();
        RobotResponse Report();
        bool isValid();
    }
}
