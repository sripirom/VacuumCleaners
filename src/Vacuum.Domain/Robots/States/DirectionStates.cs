using System;

namespace Vacuum.Domain.Robots.States
{
    public class DirectionStates
    {
        public static IState North = new DirectionNorthState();
        public static IState West = new DirectionWestState();
        public static IState South = new DirectionSouthState();
        public static IState East = new DirectionEastState();
        
        public static IState MappingState(EnumDirectionStatus directionStatus)
        {
            switch (directionStatus)
            {
                case EnumDirectionStatus.North:
                    return DirectionStates.North;
                case EnumDirectionStatus.East:
                    return DirectionStates.East;
                case EnumDirectionStatus.South:
                    return DirectionStates.South;
                case EnumDirectionStatus.West:
                    return DirectionStates.West;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}