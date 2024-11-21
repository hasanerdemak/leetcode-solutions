public class Solution {
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls) {
        // Directions: up, down, left, right
        int[][] directions = new int[][] {
            new int[] { -1, 0 }, // up
            new int[] { 1, 0 },  // down
            new int[] { 0, -1 }, // left
            new int[] { 0, 1 }   // right
        };
        
        // Grid states: 
        // 0 - unoccupied and unguarded
        // 1 - guard
        // 2 - wall
        // 3 - guarded
        int[,] grid = new int[m, n];
        
        // Mark guards on the grid
        foreach (var guard in guards) {
            grid[guard[0], guard[1]] = 1; // Mark guard
        }
        
        // Mark walls on the grid
        foreach (var wall in walls) {
            grid[wall[0], wall[1]] = 2; // Mark wall
        }
        
        // Function to guard cells in a given direction
        void GuardDirection(int x, int y, int dx, int dy) {
            while (true) {
                x += dx;
                y += dy;
                
                // Break if out of bounds
                if (x < 0 || x >= m || y < 0 || y >= n) break;
                
                // Stop if we hit a wall or another guard
                if (grid[x, y] == 2 || grid[x, y] == 1) break;
                
                // Mark cell as guarded if it's not already
                if (grid[x, y] == 0) {
                    grid[x, y] = 3; // Mark as guarded
                }
            }
        }
        
        // For each guard, guard all reachable cells in all directions
        foreach (var guard in guards) {
            int x = guard[0];
            int y = guard[1];
            
            foreach (var dir in directions) {
                GuardDirection(x, y, dir[0], dir[1]);
            }
        }
        
        // Count unoccupied and unguarded cells
        int unguardedCount = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i, j] == 0) {
                    unguardedCount++;
                }
            }
        }
        
        return unguardedCount;
    }
}
