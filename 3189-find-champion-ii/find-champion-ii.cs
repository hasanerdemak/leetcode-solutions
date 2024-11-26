public class Solution {
    public int FindChampion(int n, int[][] edges) {
        // Initialize in-degree array
        int[] inDegree = new int[n];
        
        // Populate in-degree based on edges
        foreach (var edge in edges) {
            int from = edge[0];
            int to = edge[1];
            inDegree[to]++;
        }
        
        // Find all nodes with in-degree 0
        int champion = -1;
        int count = 0;
        for (int i = 0; i < n; i++) {
            if (inDegree[i] == 0) {
                champion = i;
                count++;
                if (count > 1) {
                    // More than one node with in-degree 0, no unique champion
                    return -1;
                }
            }
        }
        
        // If exactly one node has in-degree 0, return it; else, -1
        return count == 1 ? champion : -1;
    }
}