public class Solution {
    public int OrangesRotting(int[][] grid) {
        // Get the number of rows and columns in the grid
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        // Create a 2D array to track visited cells and a queue for BFS
        var visited = new bool[rows, cols];
        var queue = new Queue<(int row, int col, int time)>();

        // Initialize fresh orange count and minimum time
        int freshCount = 0, minTime = 0;

        // Traverse the grid to find initial rotten oranges and fresh orange count
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (grid[i][j] == 2) {
                    // Add rotten oranges to the queue with time 0 and mark as visited
                    queue.Enqueue((i, j, 0));
                    visited[i, j] = true;
                } else if (grid[i][j] == 1) {
                    // Count fresh oranges
                    freshCount++;
                }
            }
        }

        // Define movement directions: right, down, left, up
        int[] directions = new int[] { 0, 1, 0, -1, 0 };

        // BFS to process the rotting of fresh oranges
        while (queue.Count > 0) {
            // Dequeue the current rotten orange's position and time
            var (row, col, time) = queue.Dequeue();
            
            // Track the maximum time taken for the last rotting process
            minTime = Math.Max(minTime, time);

            // Check all 4-directional neighbors for fresh oranges
            for (int k = 0; k < 4; k++) {
                int newRow = row + directions[k];
                int newCol = col + directions[k + 1];

                // Check bounds and ensure the neighboring cell is a fresh orange
                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols 
                    && grid[newRow][newCol] == 1 && !visited[newRow, newCol]) {

                    // Rot the fresh orange and add it to the queue with incremented time
                    grid[newRow][newCol] = 2;
                    queue.Enqueue((newRow, newCol, time + 1));

                    // Mark the cell as visited and reduce the fresh orange count
                    visited[newRow, newCol] = true;
                    freshCount--;
                }
            }
        }

        // If no fresh oranges are left, return the time taken, otherwise return -1
        return freshCount == 0 ? minTime : -1;
    }
}
