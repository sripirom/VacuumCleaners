using System;
using Vacuum.Domain.Robots.States;

namespace Vacuum.Domain.Robots
{
    public interface IRobot
    { 
        IPosition Positioning { get; }

        void RunCommand(string command);

        void SetState(IState state);
    }
}
