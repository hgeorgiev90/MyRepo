using System;
using System.Collections.Generic;

public class EightQueens
{
    const int Size = 8;

    // Entry point
    public static void Main()
    {
        List<int[]> solutions = new List<int[]>();
        int[] board = new int[Size];
        Solve(0, board, solutions);
        Console.WriteLine($"Found {solutions.Count} solutions.");
        PrintSolutions(solutions);
    }

    // Solve recursively using backtracking
    private static void Solve(int row, int[] board, List<int[]> solutions)
    {
        if (row == Size)
        {
            // Found a solution
            int[] snapshot = new int[Size];
            Array.Copy(board, snapshot, Size);
            solutions.Add(snapshot);
            return;
        }

        for (int col = 0; col < Size; col++)
        {
            if (IsSafe(row, col, board))
            {
                board[row] = col;
                Solve(row + 1, board, solutions);
            }
        }
    }

    // Check if position is safe for a queen
    private static bool IsSafe(int row, int col, int[] board)
    {
        for (int i = 0; i < row; i++)
        {
            int otherCol = board[i];
            if (otherCol == col ||
                otherCol - i == col - row ||
                otherCol + i == col + row)
            {
                return false;
            }
        }
        return true;
    }

    // Print all solutions
    private static void PrintSolutions(List<int[]> solutions)
    {
        int solutionNumber = 1;
        foreach (var solution in solutions)
        {
            Console.WriteLine($"Solution {solutionNumber++}:");
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (solution[row] == col)
                        Console.Write("Q ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
