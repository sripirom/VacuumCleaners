using System;
using Vacuum.Domain.Robots;
using Vacuum.Domain.Robots.States;

namespace Vacuum.Domain.Helpers
{
    public class DirectionHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction">default North</param>
        /// <returns></returns>
        public static EnumDirectionStatus GetDirection(string direction){
            switch(direction.Trim().ToUpper())
            {
                
                case "E": return EnumDirectionStatus.East;
                case "S": return EnumDirectionStatus.South;
                case "W": return EnumDirectionStatus.West;
                case "N": 
                default: return EnumDirectionStatus.North;
            }
        }
    }
}
