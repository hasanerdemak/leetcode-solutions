public class Solution {
    public int MinimumObstacles(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        
        // Directions for moving up, down, left, right
        int[] dirs = new int[] { -1, 0, 1, 0, 0, -1, 0, 1 };
        
        // Priority Queue to simulate Dijkstra's algorithm
        var pq = new PriorityQueue<(int obstaclesRemoved, int x, int y), int>();
        
        // Visited array to keep track of the minimum obstacles removed to reach each cell
        int[,] visited = new int[m, n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                visited[i, j] = int.MaxValue;  // Initialize with a very large number
            }
        }
        
        // Start at the top-left corner (0, 0), with 0 obstacles removed
        pq.Enqueue((0, 0, 0), 0);
        visited[0, 0] = 0;
        
        while (pq.Count > 0) {
            var (obstaclesRemoved, x, y) = pq.Dequeue();
            
            // If we reach the bottom-right corner, return the number of obstacles removed
            if (x == m - 1 && y == n - 1) {
                return obstaclesRemoved;
            }
            
            // Explore the 4 neighboring cells
            for (int i = 0; i < 4; i++) {
                int nx = x + dirs[i * 2];
                int ny = y + dirs[i * 2 + 1];
                
                // Check if the new cell is within bounds
                if (nx >= 0 && nx < m && ny >= 0 && ny < n) {
                    int newObstaclesRemoved = obstaclesRemoved + grid[nx][ny];
                    
                    // If we found a better way to reach (nx, ny), update and enqueue it
                    if (newObstaclesRemoved < visited[nx, ny]) {
                        visited[nx, ny] = newObstaclesRemoved;
                        pq.Enqueue((newObstaclesRemoved, nx, ny), newObstaclesRemoved);
                    }
                }
            }
        }
        
        // If no path is found, return -1 (though this won't happen due to the problem constraints)
        return -1;
    }
}