public class Solution {
    public int NearestExit(char[][] maze, int[] entrance) {
        int rows = maze.Length;
        int cols = maze[0].Length;
        int[] directions = new int[] {0, 1, 0, -1, 0}; // for moving in 4 directions (right, down, left, up)

        // Create a queue for BFS
        Queue<(int row, int col, int steps)> queue = new Queue<(int, int, int)>();
        queue.Enqueue((entrance[0], entrance[1], 0));

        // Mark the entrance as visited by turning it into a wall
        maze[entrance[0]][entrance[1]] = '+';

        while (queue.Count > 0) {
            var (currentRow, currentCol, currentSteps) = queue.Dequeue();

            // Try moving in all 4 directions
            for (int i = 0; i < 4; i++) {
                int newRow = currentRow + directions[i];
                int newCol = currentCol + directions[i + 1];

                // Check if the new position is within the maze bounds and is an empty cell
                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && maze[newRow][newCol] == '.') {
                    // Check if it's an exit (but not the entrance)
                    if (newRow == 0 || newRow == rows - 1 || newCol == 0 || newCol == cols - 1) {
                        return currentSteps + 1;
                    }

                    // Mark this cell as visited by turning it into a wall
                    maze[newRow][newCol] = '+';

                    // Add the new cell to the queue for further exploration
                    queue.Enqueue((newRow, newCol, currentSteps + 1));
                }
            }
        }

        // No exit was found
        return -1;
    }
}