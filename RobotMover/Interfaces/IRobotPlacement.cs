using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMover.Interfaces
{
    public enum Direction
    {
        Undefined,
        North,
        East,
        South,
        West
    }

    public interface IRobotPlacement
    {
        bool SetPlacement(int x, int y, Direction dir);
        void RotateDirectionLeft();
        void RotateDirectionRight();
        void MovePlacementForward();
        void Report();
        bool isValid();
    }
}
