using System;

namespace Vacuum.Domain.Robots.States
{
    public interface IState
    {
        EnumDirectionStatus Status { get; }
        void TurnLeft(IRobot robot);
        void TurnRight(IRobot robot);
        void Forward(IRobot robot);
    }
}