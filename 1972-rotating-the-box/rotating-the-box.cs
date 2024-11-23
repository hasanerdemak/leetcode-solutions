public class Solution
{
    public char[][] RotateTheBox(char[][] box)
    {
        int m = box.Length;    // Number of rows
        int n = box[0].Length; // Number of columns

        // Apply gravity to each row
        for (int i = 0; i < m; i++)
        {
            int empty = n - 1; // Track the position of the last empty cell
            for (int j = n - 1; j >= 0; j--)
            {
                if (box[i][j] == '#')
                {
                    // Move stone to the empty position
                    box[i][j] = '.';
                    box[i][empty] = '#';
                    empty--;
                }
                else if (box[i][j] == '*')
                {
                    // Reset empty position to be above the obstacle
                    empty = j - 1;
                }
            }
        }

        // Rotate the box 90 degrees clockwise
        char[][] rotatedBox = new char[n][];
        for (int j = 0; j < n; j++)
        {
            rotatedBox[j] = new char[m];
            for (int i = 0; i < m; i++)
            {
                rotatedBox[j][i] = box[m - 1 - i][j];
            }
        }

        return rotatedBox;
    }
}
