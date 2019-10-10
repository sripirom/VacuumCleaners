using Vacuum.Domain.Robots.Impl;
using Vacuum.Domain.Robots.States;
using Vacuum.Domain.Rooms;

namespace Vacuum.Domain.Robots
{
    public class RobotFactory
    {
        public static IRobot CreateRobot(int id, IRoom room, IPosition positioning)
        {
            return new Robot(id, positioning);
        }
        
        public static IRobot CreateRobot(int id, IRoom room, int x, int y, EnumDirectionStatus direction)
        {
            return new Robot(id, new Position(room, x, y, direction));
        }
    }
}