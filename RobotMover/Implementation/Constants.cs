using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMover.Implementation
{
    public class Constants
    {
        // Enums
        public enum Direction
        {
            Undefined,
            North,
            East,
            South,
            West
        }

        public enum CommandResult
        {
            Success,
            Failed
        }
    }
}
