using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RobotMover.Implementation.Constants;

namespace RobotMover.Implementation
{
    #nullable enable
    public class RobotResponse
    {
        public CommandResult result { get; set; }

        public string? message { get; set; }

        public RobotResponse(CommandResult newResult, string? newMessage = null)
        {
            result = newResult;
            message = newMessage;
        }
    }
}
