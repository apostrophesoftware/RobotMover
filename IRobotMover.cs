
namespace moveRobot
{
    /// <summary>
    /// Interface definition for RobotMover
    /// </summary>
    public interface IRobotMover
    {
        string Move();

        string GridSize { get; set; }
        string Commands { get; set; }
    }
}
