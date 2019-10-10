using System;

namespace Vacuum.Domain.Robots.States
{
    public abstract class State : IState
    {
        protected State()
        {

        }

        public abstract EnumDirectionStatus Status { get; }
        
        public abstract void Forward(IRobot robot);

        public abstract void TurnRight(IRobot robot);

        public abstract void TurnLeft(IRobot robot);

    }
}
