public class Solution {
    public int SlidingPuzzle(int[][] board) {
        // Convert the board to a string representation
        string start = "";
        foreach (var row in board) {
            foreach (var num in row) {
                start += num.ToString();
            }
        }
        
        // Define the target state
        string target = "123450";
        
        // Define the neighbors for each position
        int[][] neighbors = new int[][] {
            new int[] {1, 3},    // 0
            new int[] {0, 2, 4}, // 1
            new int[] {1, 5},    // 2
            new int[] {0, 4},    // 3
            new int[] {1, 3, 5}, // 4
            new int[] {2, 4}     // 5
        };
        
        // Initialize BFS
        Queue<string> queue = new Queue<string>();
        HashSet<string> visited = new HashSet<string>();
        
        queue.Enqueue(start);
        visited.Add(start);
        int moves = 0;
        
        while (queue.Count > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                string current = queue.Dequeue();
                
                // Check if the current state is the target
                if (current.Equals(target)) {
                    return moves;
                }
                
                // Find the index of '0'
                int zeroIndex = current.IndexOf('0');
                
                // Iterate through all possible neighbors
                foreach (int neighbor in neighbors[zeroIndex]) {
                    char[] newBoard = current.ToCharArray();
                    // Swap '0' with the neighbor
                    newBoard[zeroIndex] = newBoard[neighbor];
                    newBoard[neighbor] = '0';
                    string nextState = new string(newBoard);
                    
                    // If the new state hasn't been visited, enqueue it
                    if (!visited.Contains(nextState)) {
                        queue.Enqueue(nextState);
                        visited.Add(nextState);
                    }
                }
            }
            moves++;
        }
        
        // If the target state wasn't reached
        return -1;
    }
}