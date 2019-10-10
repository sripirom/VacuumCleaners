using System;

namespace Vacuum.Domain.Robots.States
{
    public class DirectionWestState : State
    {
        public DirectionWestState()
        {
        }

        public override EnumDirectionStatus Status => EnumDirectionStatus.West;

        public override void TurnRight(IRobot robot)
        {
            robot.Positioning.Direction = EnumDirectionStatus.North;
            robot.SetState(DirectionStates.North);
        }
        
        public override void TurnLeft(IRobot robot)
        {
            robot.Positioning.Direction = EnumDirectionStatus.South;
            robot.SetState(DirectionStates.South);
        }
        
        public override void Forward(IRobot robot)
        {
            if (!robot.Positioning.IsDirectionToTheWall())
            {
                robot.Positioning.X--;
            }
        }
    }
}
