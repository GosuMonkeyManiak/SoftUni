namespace EightQueensProblem
{
    using System;

    public class Program
    {
        private const char QueenCharacter = '*';
        private const char Empty = '-';

        public static void Solve(char[,] chessBoard, int row, int col, int queens)
        {
            if (queens == 0)
            {
                return;
            }
            else
            {
                if (CanPutQueen(chessBoard, row, col))
                {
                    chessBoard[row, col] = QueenCharacter;
                    queens--;
                }

                var (newRow, newCol) = IncreaseRowAndCol(row, col);

                bool inArray = IsInArray(newRow, newCol);

                if (!inArray)
                {
                    return;
                }

                Solve(chessBoard, newRow, newCol, queens);


            }
        }

        public static bool CanPutQueen(char[,] chessBoard, int row, int col)
        {
            //check row
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                if (chessBoard[i, col] == QueenCharacter)
                {
                    return false;
                }
            }

            //check col
            for (int i = 0; i < chessBoard.GetLength(1); i++)
            {
                if (chessBoard[row, i] == QueenCharacter)
                {
                    return false;
                }
            }

            //check diagonals

            //upRight
            int colUpRight = col;

            for (int rowIndex = row; rowIndex >= 0; rowIndex--)
            {
                if (!IsInArray(rowIndex, colUpRight))
                {
                    break;
                }

                if (chessBoard[rowIndex, colUpRight] == QueenCharacter)
                {
                    return false;
                }

                colUpRight++;
            }

            //upLeft
            int colUpLeft = col;

            for (int rowIndex = row; rowIndex >= 0; rowIndex--)
            {
                if (!IsInArray(rowIndex, colUpLeft))
                {
                    break;
                }

                if (chessBoard[rowIndex, colUpLeft] == QueenCharacter)
                {
                    return false;
                }

                colUpLeft--;
            }

            //bottomRight
            int colBottomRight = col;

            for (int rowIndex = row; rowIndex < chessBoard.GetLength(0); rowIndex++)
            {
                if (!IsInArray(rowIndex, colBottomRight))
                {
                    break;
                }

                if (chessBoard[rowIndex, colBottomRight] == QueenCharacter)
                {
                    return false;
                }

                colBottomRight++;
            }

            //bottomLeft
            int colBottomLeft = col;

            for (int rowIndex = row; rowIndex < chessBoard.GetLength(0); rowIndex++)
            {
                if (!IsInArray(rowIndex, colBottomLeft))
                {
                    break;
                }

                if (chessBoard[rowIndex, colBottomLeft] == QueenCharacter)
                {
                    return false;
                }

                colBottomLeft--;
            }

            return true;
        }

        public static bool IsInArray(int row, int col)
        {
            if (row < 0 || row > 7)
            {
                return false;
            }

            if (col < 0 || col > 7)
            {
                return false;
            }

            return true;
        }

        public static (int, int) IncreaseRowAndCol(int row, int col)
        {
            if (col + 1 > 7)
            {
                col = 0;
                row++;
            }
            else
            {
                col++;
            }

            return (row, col);
        }

        public static void Main()
        {
            char[,] chessBoard = new char[,]
            {
                { '-', '-', '-', '-', '-', '-', '-', '-', },
                { '-', '-', '-', '-', '-', '-', '-', '-', },
                { '-', '-', '-', '-', '-', '-', '-', '-', },
                { '-', '-', '-', '-', '-', '-', '-', '-', },
                { '-', '-', '-', '-', '-', '-', '-', '-', },
                { '-', '-', '-', '-', '-', '-', '-', '-', },
                { '-', '-', '-', '-', '-', '-', '-', '-', },
                { '-', '-', '-', '-', '-', '-', '-', '-', }
            };

            //2, 5

            Solve(chessBoard, 0, 0, 8);

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    Console.Write($"{chessBoard[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}