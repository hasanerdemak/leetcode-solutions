public class Solution {
    public int EqualPairs(int[][] grid) {
        var n = grid.GetLength(0);
        // Dictionary to store row representations and their counts
        var rowDict = new Dictionary<string, int>();
        var result = 0;
        
        // Build the row representation and store it in the dictionary
        for (int i = 0; i < n; i++) {
            var rowStr = string.Join(",", grid[i]);
            if (!rowDict.TryAdd(rowStr, 1)) {
                rowDict[rowStr]++;
            }
        }

        // Now we need to create the column representation and check it against rows
        for (int i = 0; i < n; i++) {
            // Create a column representation
            var col = new int[n];
            for (int j = 0; j < n; j++) {
                col[j] = grid[j][i];
            }
            var colStr = string.Join(",", col);
            
            // Check if this column matches any row
            if (rowDict.TryGetValue(colStr, out int count)) {
                result += count;
            }
        }

        return result;
    }
}
