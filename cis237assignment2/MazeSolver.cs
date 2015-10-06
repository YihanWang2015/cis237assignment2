//CIS237Assignment2   
//Yihan Wang
//10/05/2015


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;


        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        { }


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            maze[yStart, xStart] = 'X';

            //Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal();
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        /// 

        //This method starts [0, 0] and checks direction down( row + 1), up (row - 1), left (column - 1), right (column +1). Try catch is used to jump out of array which means the maze is completed.
        private void mazeTraversal()
        {
            try
            {

                //Implement maze traversal recursive call
                //Move to the path, check where are the walls

                //check down (row + 1)
                if (maze[yStart + 1, xStart] == '.')
                {
                    yStart++;
                    maze[yStart, xStart] = 'X';
                    //	printMaze();
                    //  check up (row - 1)
                }
                else if (maze[yStart - 1, xStart] == '.')
                {
                    yStart--;
                    maze[yStart, xStart] = 'X';
                    //	printMaze();
                    //check left (column - 1)
                }
                else if (maze[yStart, xStart + 1] == '.')
                {
                    xStart++;
                    maze[yStart, xStart] = 'X';
                    //printMaze();
                    // check right (column +1)
                }
                else if (maze[yStart, xStart - 1] == '.')
                {
                    xStart--;
                    maze[yStart, xStart] = 'X';
                    //printMaze();
                    //Check if we are at a dead end
                }
                else if (maze[yStart, xStart] == 'O')
                {
                    //Go back to where we came from
                    if (maze[yStart, xStart - 1] == 'X')
                    {
                        xStart--;
                    }
                    else if (maze[yStart, xStart + 1] == 'X')
                    {
                        xStart++;
                    }
                    else if (maze[yStart - 1, xStart] == 'X')
                    {
                        yStart--;
                    }
                    else if (maze[yStart + 1, xStart] == 'X')
                    {
                        yStart++;
                    }
                    //printMaze();

                }
                else
                {
                    maze[yStart, xStart] = 'O';
                    //printMaze();
                }
                mazeTraversal();

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Maze completed");
                //print the maze
                printMaze();
                return;
            }
        }
        // This methos is to print 2D array.
        private void printMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j] + ", ");
                }
                Console.Write("\n");
            }
        }


    }

}
