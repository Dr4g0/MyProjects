using System;
using System.Text;

namespace ConsoleChess
{
    class ChessGame
    {
        static string[,] playfield = new string[8, 8];
        static bool whiteTurn = true;
        //static Figures newFigure = new Figures();

        static void Main()
        {
            //Console.CursorVisible = false;
            PrintPlayfield();
            InitialPositions(playfield);
            PrintFigures(playfield);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(100, 1);
            Console.Write("White(Red)");
            Console.SetCursorPosition(112, 1);
            Console.Write("Black");
            Console.SetCursorPosition(99, 3);
            Console.Write("1.");
            string nextMove = Console.ReadLine();
            string initialPosition = nextMove.Substring(0, 2);
            //int initialPostionMatrixCol = nextMove[0] - 97;
            //int initialPositionMatrixRow = 8 - nextMove[1] - '0';
            string finalPosition = nextMove.Substring(2, 2);
            CheckForCorrectMove(initialPosition, finalPosition);
            //int finalPostionMatrixCol = nextMove[2] - 97;
            //int finalPositionMatrixRow = 8 - nextMove[3] - '0';
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine(newFigure.whiteFigures[3]);
            //Console.ForegroundColor = ConsoleColor.DarkMagenta;
            //Console.WriteLine(newFigure.blackFigures[1]);
        }

        static void InitialPositions(string[,] playfield)
        {
            for (int i = 0; i < 8; i++)
            {
                playfield[6, i] = Figures.whiteFigures[0];
                playfield[1, i] = Figures.blackFigures[0];
                if (i==0||i==7)
                {
                    playfield[7, i] = Figures.whiteFigures[3];
                    playfield[0, i] = Figures.blackFigures[3];
                }
                else if (i == 1 || i == 6)
                {
                    playfield[7, i] = Figures.whiteFigures[1];
                    playfield[0, i] = Figures.blackFigures[1];
                }
                else if (i == 2 || i == 5)
                {
                    playfield[7, i] = Figures.whiteFigures[2];
                    playfield[0, i] = Figures.blackFigures[2];
                }
                else if (i == 3)
                {
                    playfield[7, i] = Figures.whiteFigures[4];
                    playfield[0, i] = Figures.blackFigures[4];
                }
                else if (i == 4)
                {
                    playfield[7, i] = Figures.whiteFigures[5];
                    playfield[0, i] = Figures.blackFigures[5];
                }
            }
        }

        static void PrintPlayfield()
        {
            Console.Clear();
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowHeight = Console.LargestWindowHeight;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(@"
 ╔═══════════╦═══════════╦═══════════╦═══════════╦═══════════╦═══════════╦═══════════╦═══════════╗
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
8║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ╠═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╣
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
7║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ╠═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╣
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
6║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ╠═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╣
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
5║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ╠═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╣
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
4║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ╠═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╣
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
3║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ╠═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╣
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
2║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ║           ║███████████║           ║███████████║           ║███████████║           ║███████████║
 ╠═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╬═══════════╣
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
1║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ║███████████║           ║███████████║           ║███████████║           ║███████████║           ║
 ╚═══════════╩═══════════╩═══════════╩═══════════╩═══════════╩═══════════╩═══════════╩═══════════╝
       a           b           c           d           e           f           g           h      
");
        }

        static void PrintFigures(string[,] FiguresPositions)
        {
            for (int rows = 0; rows < FiguresPositions.GetLength(0); rows++)
            {
                for (int columns = 0; columns < FiguresPositions.GetLength(1); columns++)
                {
                    if (FiguresPositions[rows,columns]!=String.Empty)
                    {
                        int firstSymbolRow = 0;
                        int whiteFigureIndex = Array.IndexOf(Figures.whiteFigures, FiguresPositions[rows, columns]);
                        int blackFigureIndex = Array.IndexOf(Figures.blackFigures, FiguresPositions[rows, columns]);
                        if (whiteFigureIndex == -1 && blackFigureIndex < 4 || blackFigureIndex == -1 && whiteFigureIndex < 4)
                        {
                            firstSymbolRow = 1;
                        }
                        int firstColumn = columns * 12 + 6;
                        int firstRow = rows * 6 + firstSymbolRow + 2;
                        if (whiteFigureIndex>-1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            PrintCurrentFigure(FiguresPositions[rows,columns],firstColumn,firstRow);
                        }
                        if (blackFigureIndex > -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            PrintCurrentFigure(FiguresPositions[rows, columns], firstColumn, firstRow);
                        } 
                    }
                }
            }
        }

        static void PrintCurrentFigure(string currentFigure, int col, int row)
        {
            Console.SetCursorPosition(col, row);
            for (int i = 0; i < currentFigure.Length; i++)
            {
                if ((int)currentFigure[i] == 13)
                {
                    if (i != 0)
                    {
                        Console.SetCursorPosition(col, ++row);
                    }
                    i++;
                }
                else
                {
                    Console.Write(currentFigure[i]);
                }
            }
            Console.WriteLine();
        }

        

        static bool CheckForCorrectMove(string initialPosition, string finalPosition)
        {
            bool correctMove = true;
            int initialPosMatrixRow=ConvertWrritenPositionToMatrixRow(initialPosition);
            int initialPosMatrixCol=ConvertWrritenPositionToMatrixColumn(initialPosition);
            int finalPosMatrixRow = ConvertWrritenPositionToMatrixRow(finalPosition);
            int finalPosMatrixCol = ConvertWrritenPositionToMatrixColumn(finalPosition); 
            int indexOfMovingWhiteFigure=Array.IndexOf(Figures.whiteFigures,playfield[initialPosMatrixRow,initialPosMatrixCol]);
            int indexOfMovingBlackFigure=Array.IndexOf(Figures.blackFigures,playfield[initialPosMatrixRow,initialPosMatrixCol]);
            if (indexOfMovingWhiteFigure>-1&&whiteTurn)
            {
                switch (indexOfMovingWhiteFigure)
                {
                    case 0:
                        if (finalPosMatrixRow - initialPosMatrixRow > 2 || finalPosMatrixCol - initialPosMatrixCol>1)
                        {
                            correctMove = false;
                        }
                        else if (finalPosMatrixRow - initialPosMatrixRow == 2&&initialPosMatrixRow!=2)
                        {
                            correctMove = false;
                        }
                        else if ((finalPosMatrixCol - initialPosMatrixCol==1)&&Array.IndexOf(Figures.blackFigures,playfield[finalPosMatrixRow,finalPosMatrixCol])<=-1)
                        {
                            correctMove = false;
                        }
                        else if (!CheckForAnyFiguresBetweenPositions(initialPosition,finalPosition))
                        {
                            playfield[finalPosMatrixRow, finalPosMatrixCol] = playfield[initialPosMatrixRow, initialPosMatrixCol];
                            playfield[initialPosMatrixRow, initialPosMatrixCol] = String.Empty;
                        }
                        break;
                    default:
                        break;
                }
                PrintPlayfield();
                PrintFigures(playfield);
            }
            return correctMove;
        }

        static bool CheckForAnyFiguresBetweenPositions(string initialPosition, string finalPosition)
        {
            bool anyFiguresBetweenPositions = false;
            return anyFiguresBetweenPositions;
        }

        static int ConvertWrritenPositionToMatrixRow(string position)
        {
            int positionMatrixRow = 8 - (position[1] - '0');
            return positionMatrixRow;
        }

        static int ConvertWrritenPositionToMatrixColumn(string position)
        {
            int postionMatrixCol = position[0] - 97;
            return postionMatrixCol;
        }
    }
}
