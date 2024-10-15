using System;

class Program
{
    static int N = 8;

    static void Main()
    {
        int[,] board = new int[N, N];
        SolveNQueens(board, 0);
    }

    static bool IsSafe(int[,] board, int row, int col)
    {
        for (int i = 0; i < col; i++)
            if (board[row, i] == 1)
                return false;

        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 1)
                return false;

        for (int i = row, j = col; i < N && j >= 0; i++, j--)
            if (board[i, j] == 1)
                return false;

        return true;
    }

    static bool SolveNQueens(int[,] board, int col)
    {
        if (col >= N)
        {
            PrintBoard(board);
            return true;
        }

        for (int i = 0; i < N; i++)
        {
            if (IsSafe(board, i, col))
            {
                board[i, col] = 1;

                if (SolveNQueens(board, col + 1))
                    return true;

                board[i, col] = 0;
            }
        }

        return false;
    }

    static void PrintBoard(int[,] board)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write(board[i, j] + " ");
            Console.WriteLine();
        }
    }
}
