using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soduku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},

                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},

                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };


            int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };

            int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };

            int[][] badSudoku2 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {1}
            };
            int[][] badSudoku3 = {
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {3,5,4}
            };
            //// if (ValidateSudoku(badSudoku1))
            //     Console.WriteLine("True");
            // else
            //     Console.WriteLine("False");
            //Console.WriteLine(badSudoku2[3][3]);
            // ValidateSudoku(goodSudoku1);
            //Debug.Assert(true,(goodSudoku1[2][1].ToString()));
            if (ValidateSudoku(goodSudoku1))
                Console.WriteLine("This is supposed to validate! It's a good sudoku!");
            else
                Console.WriteLine("This isn't supposed to validate! It's a bad sudoku!");
        }

        static bool ValidateSudoku(int[][] puzzle)
        {
            int Size = puzzle.GetLength(0);
            for (int i = 0; i < Size; i++)
            {
                if (CheckRow(i, puzzle) && CheckCol(i, puzzle))
                    continue;
                else
                    return false;
            }
            return true;
        }

        static bool CheckRow(int row, int[][] sudoku)
        {
            int Size = sudoku.GetLength(0);
            int[] arr = new int[Size];
            for (int i = 0; i < Size; i++)
            {
                arr[i] = sudoku[row][i];
            }
            quickSort(arr, 0, Size - 1);
            for (int i = 0; i < Size; i++)
            {
                if (i + 1 == arr[i])
                    continue;
                else
                    return false;
            }
            return true;
            // Console.WriteLine(arr);
        }
        static bool CheckCol(int col, int[][] sudoku)
        {
            int Size = sudoku.GetLength(0);
            int[] arr = new int[Size];
            for (int i = 0; i < Size; i++)
            {
                arr[i] = sudoku[i][col];
            }
            quickSort(arr, 0, Size - 1);
            for (int i = 0; i < Size; i++)
            {
                if (i + 1 == arr[i])
                    continue;
                else
                    return false;
            }
            return true;
            // Console.WriteLine(arr);
        }
        //static bool CheckSquare(int col, int[][] sudoku)
        //{
        //    int[] arr = new int[9];
        //    int j = 0;
        //    for (int i = 0; i < 9; i++)
        //    {
        //        arr[i] = sudoku[i][col];
        //    }
        //    quickSort(arr, 0, 8);
        //    for (int i = 0; i < 9; i++)
        //    {
        //        if (i + 1 == arr[i])
        //            continue;
        //        else
        //            return false;
        //    }
        //    return true;
        //    // Console.WriteLine(arr);
        //}
        static void quickSort(int[] arr, int left, int right)
        {
            int i = left, j = right;
            int tmp;
            int pivot = arr[(left + right) / 2];

            while (i <= j)
            {

                while (arr[i] < pivot)
                    i++;

                while (arr[j] > pivot)
                    j--;

                if (i <= j)
                {
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                }
            };
            if (left < j)
                quickSort(arr, left, j);
            if (i < right)
                quickSort(arr, i, right);

        }
    }
}
