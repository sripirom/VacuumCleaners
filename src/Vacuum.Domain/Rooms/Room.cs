using System;
using Vacuum.Core.Domain;

namespace Vacuum.Domain.Rooms
{
    public class Room : Entity<int>, IRoom
    {
        public Room(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }
    }
}
