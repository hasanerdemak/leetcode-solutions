public class Solution {
    private readonly List<List<int>> adj = new List<List<int>>();
    private readonly HashSet<(int, int)> directedEdges = new HashSet<(int, int)>();

    public int MinReorder(int n, int[][] connections) {
        // Create an adjacency list to represent the graph
        for (int i = 0; i < n; i++) {
            adj.Add(new List<int>());
        }
        
        // Store original directed edges in a hashset for quick lookup
        foreach (var connection in connections) {
            int u = connection[0], v = connection[1];
            // Add undirected edges for traversal purposes
            adj[u].Add(v);
            adj[v].Add(u);
            // Track the original direction of the edge (u -> v)
            directedEdges.Add((u, v));
        }
        
        // Variable to count the number of reversals
        int reversals = 0;

        // Start DFS from city 0
        bool[] visited = new bool[n];
        DFS(0, visited, ref reversals);

        return reversals;
    }

    private void DFS(int node, bool[] visited, ref int reversals) {
        visited[node] = true;

        // Traverse all neighbors of the current node
        foreach (int neighbor in adj[node]) {
            if (!visited[neighbor]) {
                // If the edge is in the direction away from city 0, we need to reverse it
                if (directedEdges.Contains((node, neighbor))) {
                    reversals++;
                }
                // Continue DFS on the neighbor
                DFS(neighbor, visited, ref reversals);
            }
        }
    }
}
