using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMover.Implementation
{
    public class TableTop
    {
        public int[,] array2D { get; }

        public TableTop(int[,] newArray2D)
        {
            array2D = newArray2D;
        }
    }
}
