using System;
using Xunit;
using Vacuum.Domain.Robots;
using Vacuum.Domain.Helpers;
using Vacuum.Domain.Robots.Impl;
using Vacuum.Domain.Robots.States;
using Vacuum.Domain.Rooms;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Vacuum.Domain.Tests.Robots
{
    /// <summary>
    /// It can be controller 
    /// L  = spin 90 degrees left
    /// R = spin 90 degrees right
    /// M = forward 1 grid
    /// If forward to hit the wall , It will be continue to next command.
    /// It can be set initial state : such as (1, 2, N)  or (2, 2, W)
    /// It can be given a series of instructions.
    /// It can be know current position.
    /// </summary>
    public class RobotTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public RobotTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        [Fact]
        public void Robot_DefaultPosition()
        {
            //Given
            Room room = new Room(6, 6);
            Position position = new Position(room);
           
            //When
            Robot robot = new Robot(1, position);

            //Then
            Assert.Equal($"Position: 0, 0, North", robot.Positioning.ToString());
        }
        
        [Theory]
        [InlineData(1, 2, "N", 6, 6)]
        public void Robot_Can_Initial(int x, int y, string direction, int roomX, int roomY)
        {
            EnumDirectionStatus en = DirectionHelper.GetDirection(direction);
            //Given
            Room room = new Room(roomX, roomY);
            Position position = new Position(room, x, y, en);
           
            //When
            Robot robot = new Robot(1, position);

            //Then
             Assert.Equal($"Position: {x}, {y}, {EnumDirectionStatus.North}", robot.Positioning.ToString());
        }

        [Theory]
        [InlineData("1, 2, N", 6, 6, 1, 2, EnumDirectionStatus.North)]
        public void Robot_Can_Initial_stringCommand(string initialCommand, int roomX, int roomY, int x, int y, EnumDirectionStatus direction)
        {
            //Given
            Room room = new Room(roomX, roomY);
            Position position = new Position(room);
           
            //When
            Robot robot = new Robot(1, position);
            robot.Positioning.Initial(initialCommand);

            //Then
            Assert.Equal($"Position: {x}, {y}, {direction}", robot.Positioning.ToString());
        }

        [Theory]
        [InlineData(0, 0, "N", 6, 6, "L", EnumDirectionStatus.West)]
        [InlineData(0, 0, "N", 6, 6, "R", EnumDirectionStatus.East)]
        public void Robot_Can_Spin(int initX, int initY, string direction, int roomX, int roomY, string command, EnumDirectionStatus expected)
        {
            //Given

            EnumDirectionStatus enumDirection = DirectionHelper.GetDirection(direction);
            Room room = new Room(roomX, roomY);
            Position position = new Position(room, initX, initY, enumDirection);
           
            //When
            Robot robot = new Robot(1, position);
            robot.RunCommand(command);

            //Then
            Assert.Equal($"Position: {initX}, {initY}, {expected}", robot.Positioning.ToString());
        }
        
        [Theory]
        [InlineData(1, 2, "N", 6, 6, "M")]
        public void Robot_Can_Forward_one_grid(int x, int y, string direction, int roomX, int roomY, string command)
        {
            EnumDirectionStatus en = DirectionHelper.GetDirection(direction);
            //Given
            Room room = new Room(roomX, roomY);
            Position position = new Position(room, x, y, en);
           
            //When
            Robot robot = new Robot(1, position);
            robot.RunCommand(command);

            //Then
            Assert.Equal($"Position: {x}, {y+1}, {EnumDirectionStatus.North}", robot.Positioning.ToString());
        }
        
        [Theory]
        [InlineData(5, 5, "N", 6, 6, "M")]
        public void Robot_Can_Forward_to_wall(int x, int y, string direction, int roomX, int roomY, string command)
        {
            EnumDirectionStatus en = DirectionHelper.GetDirection(direction);
            //Given
            Room room = new Room(roomX, roomY);
            Position position = new Position(room, x, y, en);
           
            //When
            Robot robot = new Robot(1, position);
            robot.RunCommand(command);

            //Then
            Assert.Equal($"Position: {x}, {y}, {EnumDirectionStatus.North}", robot.Positioning.ToString());
        }
        
        
        [Theory]
        [InlineData(6, 6, "1, 2, N", "L, M, L, M, L, M, L, M, M")]
        public void Robot_Can_RunMultipleCommand(int roomX, int roomY, string initial, string command)
        {
            _outputHelper.WriteLine("Start");
            //Given
            Room room = new Room(roomX, roomY);
            Position position = new Position(room);
           
            //When
            Robot robot = new Robot(1, position, _outputHelper.WriteLine);
            robot.Positioning.Initial(initial);
            robot.RunCommand(command);

            //Then Final state: (1, 3, N)
            Assert.Equal($"Position: 1, 3, {EnumDirectionStatus.North}", robot.Positioning.ToString());
        }
        

    }
}
