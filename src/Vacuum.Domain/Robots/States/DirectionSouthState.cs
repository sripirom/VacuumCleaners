using System;

namespace Vacuum.Domain.Robots.States
{
    public class DirectionSouthState : State
    {
        public DirectionSouthState()
        {
        }

        public override EnumDirectionStatus Status => EnumDirectionStatus.South;

        public override void TurnRight(IRobot robot)
        {
            robot.Positioning.Direction = EnumDirectionStatus.West;
            robot.SetState(DirectionStates.West);
        }
        
        public override void TurnLeft(IRobot robot)
        {
            robot.Positioning.Direction = EnumDirectionStatus.East;
            robot.SetState(DirectionStates.East);
        }
        
        public override void Forward(IRobot robot)
        {
            if (!robot.Positioning.IsDirectionToTheWall())
            {
                robot.Positioning.Y--;
            }
        }
    }
}
