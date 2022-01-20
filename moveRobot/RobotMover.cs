using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moveRobot
{
    // enum with the compass directions
    public enum compassDirection { North, South, East, West }

    /// <summary>
    /// The RobotMover class, implements IRobotMover
    /// </summary>
    public class RobotMover : IRobotMover
    {
        private string _gridSize;
        private string _commands;

        private int _maxX, _maxY, _currentX, _currentY;

        private compassDirection _facing;

        /// <summary>
        /// Default class constructor
        /// </summary>
        public RobotMover()
        {
            _maxX = _maxY = _currentX = _currentY = 1;

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gridSize">The grid size</param>
        /// <param name="commands">the movement commands</param>
        public RobotMover(string gridSize, string commands) : this()
        {
            GridSize = gridSize;
            Commands = commands;

            // get the grid size
            setGridSize(gridSize);

        }

        /// <summary>
        /// Sets the grid size
        /// </summary>
        public string GridSize
        {
            get
            {
                return _gridSize;
            }
            set
            {
                _gridSize = value;
                setGridSize(_gridSize);
            }
        }

        public string Commands { get => _commands; set => _commands = value; }

        /// <summary>
        /// Sets the grid size
        /// </summary>
        /// <param name="gridSize">A string containing the grid size</param>
        private void setGridSize(string gridSize)
        {
            int xPos = gridSize.IndexOf("x");
            _maxX = Convert.ToInt32(gridSize.Substring(0, xPos));
            _maxY = Convert.ToInt32(gridSize.Substring(xPos + 1, (gridSize.Length - xPos - 1)));
        }

        /// <summary>
        /// Moves the Robot
        /// </summary>
        /// <returns>A string containing the current co-ordinates and direction</returns>
        public string Move()
        {
            string result;
            try
            {
                foreach (char c in Commands)
                {
                    moveRobot(c);
                }

                result = _currentX.ToString() + "," + _currentY.ToString() + "," + _facing.ToString();
            }
            catch(Exception)
            {
                result = string.Empty;
            }
            return result;

        }

        /// <summary>
        /// Moves the robot in the direction specified
        /// </summary>
        /// <param name="direction">The direction to move, F, L or R</param>
        /// <remarks>If the robot reaches the limits of the plateau then the command must be ignored.
        /// Does this mean the current command or the the rest of the command?  This implementation will just
        /// ignore the current command</remarks>
        private void moveRobot(char direction)
        {

            switch (_facing)
            {
                // facing north so turning left is going in the negative x direcetion
                // and forward is going in the positive y direction
                case compassDirection.North:
                    {
                        switch (direction)
                        {
                            case 'L':
                                {
                                    if (_currentX > 1)
                                    {
                                        _facing = compassDirection.West;
                                    }

                                }
                                break;

                            case 'R':
                                {
                                    if (_currentX < _maxX)
                                    {
                                        _facing = compassDirection.East;
                                    }

                                }
                                break;

                            case 'F':
                                {
                                    if (_currentY < _maxY)
                                    {
                                        _currentY++;
                                    }
                                }

                                break;
                        }

                    }
                    break;

                // facing south so turning left is going in the positive x direcetion
                // and forward is going in the negative y direction
                case compassDirection.South:
                    {
                        switch (direction)
                        {
                            case 'L':
                                {
                                    if (_currentX < _maxX)
                                    {
                                        _facing = compassDirection.East;
                                    }

                                }
                                break;

                            case 'R':
                                {
                                    if (_currentX > 1)
                                    {
                                        _facing = compassDirection.West;
                                    }

                                }
                                break;

                            case 'F':
                                {
                                    if (_currentY > 1)
                                    {
                                        _currentY--;
                                    }
                                }

                                break;
                        }

                    }
                    break;

                // facing east so turning left is going in the positive y direcetion
                // and forward is going in the positive x direction
                case compassDirection.East:
                    {
                        switch (direction)
                        {
                            case 'L':
                                {
                                    if (_currentY < _maxY)
                                    {
                                        _facing = compassDirection.North;
                                    }

                                }
                                break;

                            case 'R':
                                {
                                    if (_currentY > 1)
                                    {
                                        _facing = compassDirection.South;
                                    }

                                }
                                break;

                            case 'F':
                                {
                                    if (_currentX < _maxX)
                                    {
                                        _currentX++;
                                    }
                                }

                                break;
                        }

                    }
                    break;

                // facing west so turning left is going in the negative y direcetion
                // and forward is going in the negative x direction
                case compassDirection.West:
                    {
                        switch (direction)
                        {
                            case 'L':
                                {
                                    if (_currentY > 1)
                                    {
                                        _facing = compassDirection.South;
                                    }

                                }
                                break;

                            case 'R':
                                {
                                    if (_currentY < _maxY)
                                    {
                                        _facing = compassDirection.North;
                                    }

                                }
                                break;

                            case 'F':
                                {
                                    if (_currentX > 1)
                                    {
                                        _currentX--;
                                    }
                                }

                                break;
                        }

                    }
                    break;

                default:
                    break;
            }

        }
    }

}

