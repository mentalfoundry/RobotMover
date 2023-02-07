using RobotMover.Implementation;
using System;
using TechTalk.SpecFlow;
using static RobotMover.Implementation.Constants;

namespace SpecFlowRobot.Specs.StepDefinitions
{
    [Binding]
    public class Basic2DGridRobotStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private Basic2DGridRobot basic2DGridRobot;

        private RobotResponse robotResponse;

        // Array maximums
        private int xMax;
        private int yMax;

        public Basic2DGridRobotStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"A (.*) by (.*) square Grid")]
        public void GivenAGrid(int p0, int p1)
        {
            basic2DGridRobot = new Basic2DGridRobot(new TableTop(new int[p0, p1]));
            xMax = p0 - 1;
            yMax = p1 - 1;
        }

        [When(@"We place the robot within the grid")]
        public void WhenWePlaceTheRobotWithinTheGrid()
        {
            robotResponse = basic2DGridRobot.SetPlacement(xMax-1, yMax-1, Constants.Direction.North);
        }

        [Then(@"The robot executes the command successfully")]
        public void ThenTheRobotIsPlacedSuccessfully()
        {
            robotResponse.result.Should().Be(CommandResult.Success);
        }

        [When(@"We place the robot outside the grid")]
        public void WhenWePlaceTheRobotOutsideTheGrid()
        {
            robotResponse = basic2DGridRobot.SetPlacement(xMax + 2, yMax + 2, Constants.Direction.North);
        }

        [Then(@"The robot does not execute the command successfully")]
        public void ThenTheRobotIsNotPlacedSuccessfully()
        {
            robotResponse.result.Should().Be(CommandResult.Failed);
        }

        [When(@"We place the robot outside the grid along the x-axis")]
        public void WhenWePlaceTheRobotOutsideTheGridAlongTheX_Axis()
        {
            robotResponse = basic2DGridRobot.SetPlacement(xMax + 2, 0, Constants.Direction.North);
        }

        [When(@"We place the robot outside the grid along the y-axis")]
        public void WhenWePlaceTheRobotOutsideTheGridAlongTheY_Axis()
        {
            robotResponse = basic2DGridRobot.SetPlacement(0, yMax + 2, Constants.Direction.North);
        }

        [When(@"We place the robot inside the grid with no direction")]
        public void WhenWePlaceTheRobotInsideTheGridWithNoDirection()
        {
            robotResponse = basic2DGridRobot.SetPlacement(xMax, yMax, Constants.Direction.Undefined);
        }

        [When(@"We turn the robot left")]
        public void WhenWeTurnTheRobotLeft()
        {
            robotResponse = basic2DGridRobot.RotateDirectionLeft();
        }

        [Then(@"The robot stays directionless")]
        public void ThenTheRobotStaysDirectionless()
        {
            basic2DGridRobot.direction.Should().Be(Direction.Undefined);
        }

        [When(@"We turn the robot right")]
        public void WhenWeTurnTheRobotRight()
        {
            robotResponse = basic2DGridRobot.RotateDirectionRight();
        }

        [When(@"We place the robot inside the grid pointing North")]
        public void WhenWePlaceTheRobotInsideTheGridPointingNorth()
        {
            robotResponse = basic2DGridRobot.SetPlacement(xMax, yMax, Constants.Direction.North);
        }

        [When(@"We place the robot inside the grid pointing East")]
        public void WhenWePlaceTheRobotInsideTheGridPointingEast()
        {
            robotResponse = basic2DGridRobot.SetPlacement(xMax, yMax, Constants.Direction.East);
        }

        [When(@"We place the robot inside the grid pointing South")]
        public void WhenWePlaceTheRobotInsideTheGridPointingSouth()
        {
            robotResponse = basic2DGridRobot.SetPlacement(xMax, yMax, Constants.Direction.South);
        }

        [When(@"We place the robot inside the grid pointing West")]
        public void WhenWePlaceTheRobotInsideTheGridPointingWest()
        {
            robotResponse = basic2DGridRobot.SetPlacement(xMax, yMax, Constants.Direction.West);
        }


        [Then(@"The robot points North")]
        public void ThenTheRobotPointsNorth()
        {
            basic2DGridRobot.direction.Should().Be(Direction.North);
        }

        [Then(@"The robot points South")]
        public void ThenTheRobotPointsSouth()
        {
            basic2DGridRobot.direction.Should().Be(Direction.South);
        }

        [Then(@"The robot points East")]
        public void ThenTheRobotPointsEast()
        {
            basic2DGridRobot.direction.Should().Be(Direction.East);
        }

        [Then(@"The robot points West")]
        public void ThenTheRobotPointsWest()
        {
            basic2DGridRobot.direction.Should().Be(Direction.West);
        }

        [When(@"We move the robot")]
        public void WhenWeMoveTheRobot()
        {
            robotResponse = basic2DGridRobot.MovePlacementForward();
        }

        [When(@"We report on the robot")]
        public void WhenWeReportOnTheRobot()
        {
            robotResponse = basic2DGridRobot.Report();
        }

        [When(@"We place the robot inside the grid \((.*),(.*),South\)")]
        public void WhenWePlaceTheRobotInsideTheGridSouth(int p0,int p1)
        {
            robotResponse = basic2DGridRobot.SetPlacement(p0, p1, Constants.Direction.South);
        }

        [Then(@"The robot reports its location as '([^']*)'")]
        public void ThenTheRobotReportsItsLocationAs(string p0)
        {
            robotResponse.message.Should().Be(p0);
        }


    }
}
