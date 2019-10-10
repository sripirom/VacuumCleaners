using System;
using System.Linq;
using Vacuum.Core.Domain;
using Vacuum.Domain.Robots.States;

namespace Vacuum.Domain.Robots.Impl
{
    public class Robot : Entity<int>, IRobot
    {
         private IState _state;
         private Action<string> _writeLine;
         public Robot(int id, IPosition positioning, Action<string> writeLine = null)
            :base(id)
         {
             _writeLine = writeLine??Console.WriteLine;
             Positioning = positioning;
             SetState(DirectionStates.MappingState(positioning.Direction));
         }

         public IPosition Positioning { get; }

         public void RunCommand(char command)
         {
             _writeLine($"Command:{command}");
             _writeLine($"Current:{Positioning}");
             switch (command)
             {
                 case 'L':
                     _state.TurnLeft(this);
                     break;
                 case 'R' :
                     _state.TurnRight(this);
                     break;
                 case 'M':
                     _state.Forward(this);
                     break;
                
                 default: throw new ArgumentException("invalid command");
             }
             _writeLine($"MovedTo:{Positioning}");
         }
        public void RunCommand(string command)
        {
            foreach (var singleCommand in command.Split(',').Select(a=> Convert.ToChar(a.Trim())))
            {
                RunCommand(singleCommand);
            }
        }

        public void SetState(IState state)
        {
            _state = state;
        }
    }
}
