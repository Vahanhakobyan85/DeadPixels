using System;

namespace DeadPixelsGroup
{
    /// <summary>
    /// A class for calculating the number of groups of dead pixels in matrix.
    /// </summary>
    public class DeadPixels
    {
        static void Main(string[] args)
        {
            var matrix1 = new int[3][];
            matrix1[0] = new[] { 1, 0, 1 };
            matrix1[1] = new[] { 0, 0, 0 };
            matrix1[2] = new[] { 1, 0, 1 };

            var matrix2 = new int[3][];
            matrix2[0] = new[] { 1, 1, 1 };
            matrix2[1] = new[] { 1, 0, 1 };
            matrix2[2] = new[] { 1, 0, 1 };

            var matrix3 = new int[3][];
            matrix3[0] = new[] { 1, 1, 1 };
            matrix3[1] = new[] { 1, 0, 0 };
            matrix3[2] = new[] { 1, 0, 1 };

            var matrix4 = new int[4][];
            matrix4[0] = new[] { 1, 0, 1 };
            matrix4[1] = new[] { 0, 1, 0 };
            matrix4[2] = new[] { 1, 0, 1 };
            matrix4[3] = new[] { 0, 1, 0 };

            var matrix5 = new int[4][];
            matrix5[0] = new[] { 0, 1, 0 };
            matrix5[1] = new[] { 1, 1, 0 };
            matrix5[2] = new[] { 0, 1, 1 };
            matrix5[3] = new[] { 0, 1, 0 };

            var matrix6 = new int[2][];
            matrix6[0] = new[] { 0, 0 };
            matrix6[1] = new[] { 0, 0 };

            var matrix7 = new int[1][];
            matrix7[0] = new[] { 1 };

            var matrix8 = new int[1][]; // an empty one

            Console.WriteLine("matrix1: " + CountGroups(matrix1));
            Console.WriteLine("matrix2: " + CountGroups(matrix2));
            Console.WriteLine("matrix3: " + CountGroups(matrix3));
            Console.WriteLine("matrix4: " + CountGroups(matrix4));
            Console.WriteLine("matrix5: " + CountGroups(matrix5));
            Console.WriteLine("matrix6: " + CountGroups(matrix6));
            Console.WriteLine("matrix7: " + CountGroups(matrix7));
            Console.WriteLine("matrix8: " + CountGroups(matrix8));

            Console.ReadLine();
        }

        /// <summary>
        /// Parses the group of dead pixels either my destroying them or we can keep additional boolean matrix to keep the parsed ones.
        /// </summary>
        /// <param name="monitor"> Given matrix </param>
        /// <param name="row"> Current row </param>
        /// <param name="col"> Current column </param>
        public static void ParseDeadPixelGroup(int[][] monitor, int row, int col)
        {
            // Handling corner cases
            if (row < 0 || col < 0 || row >= monitor.Length || col >= monitor[row].Length)
            {
                return;

            }

            if (monitor[row][col] == 0)
            {
                return;
            }

            monitor[row][col] = 0; // here we are destroying the matrix, if it is not OK we can keep additional boolean[][] matrix with already passed cells.

            for (int r = row - 1; r <= row + 1; r++)
            {
                if (r == row)
                {
                    continue;
                }

                ParseDeadPixelGroup(monitor, r, col);
            }

            for (int c = col - 1; c <= col + 1; c++)
            {
                if (c == col)
                {
                    continue;
                }

                ParseDeadPixelGroup(monitor, row, c);
            }
        }

        /// <summary>
        /// Gets the count of groups of dead pixels inside matrix.
        /// </summary>
        /// <param name="matrix"> Given matrix </param>
        /// <returns> The count of dead pixel groups </returns>
        public static int CountGroups(int[][] matrix)
        {
            int groupsCount = 0;
            for (int row = 0; row < matrix.Length; row++)
                for (int col = 0; matrix[row] != null && col < matrix[row].Length; col++)
                    if (matrix[row][col] == 1) // if !boolean[col][row]  // if this cell we have not already passed
                    {
                        ParseDeadPixelGroup(matrix, row, col);
                        groupsCount++;
                    }

            return groupsCount;
        }
    }
}
