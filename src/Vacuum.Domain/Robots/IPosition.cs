using Vacuum.Domain.Robots.States;

namespace Vacuum.Domain.Robots
{
    public interface IPosition
    {
        /// <summary>
        /// 
        /// </summary>
        int X { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        int Y { get; set; }
        EnumDirectionStatus Direction { get; set; }
        /// <summary>
        /// such as '1, 2, N'
        /// </summary>
        /// <param name="initial"></param>
        void Initial(string initial);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsDirectionToTheWall();
    }
}