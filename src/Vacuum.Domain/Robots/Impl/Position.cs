using System;
using System.Globalization;
using Vacuum.Core.Domain;
using Vacuum.Domain.Helpers;
using Vacuum.Domain.Robots.States;
using Vacuum.Domain.Rooms;

namespace Vacuum.Domain.Robots.Impl
{
    public class Position : IPosition
    {
        private readonly IRoom _room;
        public Position(IRoom room, int x = 0, int y = 0, EnumDirectionStatus direction = EnumDirectionStatus.North)
        {
            _room = room;
            X = x;
            Y = y;
            Direction = direction;
        }
        
        public void Initial(string initial)
        {
            int x, y;
            string[] commands = initial.Split(',');
            if ( (commands.Length != 3) 
                 || !Int32.TryParse(commands[0].Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out x)
                 || !Int32.TryParse(commands[1].Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out y))
            {
                throw new ArgumentException($"invalid parameter: {nameof(initial)}");
            }

            X = x;
            Y = y;
            Direction = DirectionHelper.GetDirection(commands[2].Trim());
        }
        public int X { get; set; }
        public int Y { get; set; }
        public EnumDirectionStatus Direction { get; set; }
        
        public bool IsDirectionToTheWall()
        {
            return (X == 0 && Direction == EnumDirectionStatus.West)
                   || (Y == 0 && Direction == EnumDirectionStatus.South)
                   || (X == (_room.X - 1) && Direction == EnumDirectionStatus.East)
                   || (Y == (_room.Y - 1) && Direction == EnumDirectionStatus.North);
        }

        public override string ToString()
        {
            return $"Position: {X}, {Y}, {Direction}";
        }
    }
}
