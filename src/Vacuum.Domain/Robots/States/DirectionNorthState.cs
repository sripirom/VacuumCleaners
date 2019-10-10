using System;

namespace Vacuum.Domain.Robots.States
{
    public class DirectionNorthState : State
    {
        public DirectionNorthState()
        {
        }

        public override EnumDirectionStatus Status => EnumDirectionStatus.North;

        public override void TurnRight(IRobot robot)
        {
            robot.Positioning.Direction = EnumDirectionStatus.East;
            robot.SetState(DirectionStates.East);
        }
        
        public override void TurnLeft(IRobot robot)
        {
            robot.Positioning.Direction = EnumDirectionStatus.West;
            robot.SetState(DirectionStates.West);
        }
        
        public override void Forward(IRobot robot)
        {
            if (!robot.Positioning.IsDirectionToTheWall())
            {
                robot.Positioning.Y++;
            }
        }
    }
}
