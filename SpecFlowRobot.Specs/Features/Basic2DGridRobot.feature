Feature: Basic2DGridRobot

Simple robot with commands for moving around in a 2D grid.

Link to a feature: [Basic2DGridRobot](SpecFlowRobot.Specs/Features/Basic2DGridRobot.feature)

@RobotPlacement
Scenario: Placing a robot on valid grid space will be successful
	Given A 5 by 5 square Grid
	When We place the robot within the grid
	Then The robot executes the command successfully

Scenario: Placing a robot on an invalid grid space will fail (x-axis)
	Given A 5 by 5 square Grid
	When We place the robot outside the grid along the x-axis
	Then The robot does not execute the command successfully

Scenario: Placing a robot on an invalid grid space will fail (y-axis)
	Given A 5 by 5 square Grid
	When We place the robot outside the grid along the y-axis
	Then The robot does not execute the command successfully

@RobotRotation
Scenario: Robot will not rotate left when it has no direction
	Given A 5 by 5 square Grid
	When We place the robot inside the grid with no direction
	And We turn the robot left
	Then The robot stays directionless

Scenario: Robot will not rotate right when it has no direction
	Given A 5 by 5 square Grid
	When We place the robot inside the grid with no direction
	And We turn the robot right
	Then The robot stays directionless

Scenario: Robot will rotate right correctly when pointing North
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing North
	And We turn the robot right
	Then The robot points East

Scenario: Robot will rotate right correctly when pointing East
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing East
	And We turn the robot right
	Then The robot points South

Scenario: Robot will rotate right correctly when pointing South
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing South
	And We turn the robot right
	Then The robot points West

Scenario: Robot will rotate right correctly when pointing West
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing West
	And We turn the robot right
	Then The robot points North

Scenario: Robot will rotate left correctly when pointing North
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing North
	And We turn the robot left
	Then The robot points West
	
Scenario: Robot will rotate left correctly when pointing East
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing East
	And We turn the robot left
	Then The robot points North
	
Scenario: Robot will rotate left correctly when pointing South
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing South
	And We turn the robot left
	Then The robot points East

Scenario: Robot will rotate left correctly when pointing West
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing West
	And We turn the robot left
	Then The robot points South

@RobotMovement
Scenario: Robot will not move out of bounds (x-axis)
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing East
	And We move the robot
	Then The robot does not execute the command successfully

Scenario: Robot will move in bounds (x-axis)
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing West
	And We move the robot
	Then The robot executes the command successfully

Scenario: Robot will not move out of bounds (y-axis)
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing North
	And We move the robot
	Then The robot does not execute the command successfully

Scenario: Robot will move in bounds (y-axis)
	Given A 5 by 5 square Grid
	When We place the robot inside the grid pointing South
	And We move the robot
	Then The robot executes the command successfully

@RobotReport
Scenario: Robot will not report out of bounds
	Given A 5 by 5 square Grid
	When We place the robot outside the grid along the x-axis
	And We report on the robot
	Then The robot does not execute the command successfully

Scenario: Robot will report in bounds
	Given A 5 by 5 square Grid
	When We place the robot inside the grid (1,1,South)
	And We report on the robot
	Then The robot reports its location as 'X:1,Y:1,F:South'
