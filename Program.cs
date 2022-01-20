using System;

namespace moveRobot
{
    class Program
    {

        static void Main(string[] args)
        {
            string gridSize;
            string directions;


            string result = String.Empty;

            try
            {
                Console.WriteLine("Enter the grid size in the format XxY");
                gridSize = Console.ReadLine();

                Console.WriteLine("Enter the diretion commands using the following letters: F=Forward, R=Right, L=Left");
                directions = Console.ReadLine().ToUpper();


                IRobotMover mover = new RobotMover(gridSize: gridSize, commands: directions);

                result = mover.Move();

                Console.WriteLine(result);
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine("moveRobot Error: " + ex.Message);
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }

        }

    }
}
