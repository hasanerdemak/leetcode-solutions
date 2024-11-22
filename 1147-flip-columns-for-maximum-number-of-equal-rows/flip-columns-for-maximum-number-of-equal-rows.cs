public class Solution {
    public int MaxEqualRowsAfterFlips(int[][] matrix) {
        // Dictionary to store the transformation pattern and its frequency
        Dictionary<string, int> patternCount = new Dictionary<string, int>();

        foreach (var row in matrix) {
            // Compute the transformation pattern for the current row
            var pattern = new List<int>();
            var flipPattern = new List<int>();

            foreach (var cell in row) {
                pattern.Add(cell ^ row[0]);  // XOR with the first cell to normalize to 0 or 1
                flipPattern.Add(1 - cell ^ row[0]);  // Complement for flip equivalence
            }

            // Convert the pattern to a string for dictionary storage
            string patternKey = string.Join(",", pattern);

            // Count the pattern
            if (!patternCount.ContainsKey(patternKey)) {
                patternCount[patternKey] = 0;
            }
            patternCount[patternKey]++;
        }

        // Find the maximum count
        int maxRows = 0;
        foreach (var count in patternCount.Values) {
            maxRows = Math.Max(maxRows, count);
        }

        return maxRows;
    }
}