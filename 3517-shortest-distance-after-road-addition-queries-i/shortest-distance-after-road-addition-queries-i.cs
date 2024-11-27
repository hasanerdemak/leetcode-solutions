public class Solution {
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries) {
        // Step 1: Initialize the graph with direct roads from i to i+1
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) {
            graph[i] = new List<int>();
        }
        
        // Add initial roads from i to i+1 (unidirectional)
        for (int i = 0; i < n - 1; i++) {
            graph[i].Add(i + 1);
        }
        
        // Step 2: Process each query and compute shortest path after each addition
        List<int> results = new List<int>();
        
        foreach (var query in queries) {
            int u = query[0], v = query[1];
            
            // Add the new road from u to v
            graph[u].Add(v);
            
            // Perform BFS to find the shortest path from city 0 to city n-1
            int shortestPath = BFS(graph, n);
            results.Add(shortestPath);
        }
        
        return results.ToArray();
    }
    
    // BFS to find the shortest path from 0 to n-1
    private int BFS(List<int>[] graph, int n) {
        Queue<int> queue = new Queue<int>();
        int[] distances = new int[n];
        Array.Fill(distances, -1);  // -1 indicates not visited
        
        // Start BFS from city 0
        queue.Enqueue(0);
        distances[0] = 0;
        
        while (queue.Count > 0) {
            int current = queue.Dequeue();
            
            // If we reach city n-1, return the distance
            if (current == n - 1) {
                return distances[current];
            }
            
            // Explore all neighbors of the current city
            foreach (int neighbor in graph[current]) {
                if (distances[neighbor] == -1) {  // Not visited
                    distances[neighbor] = distances[current] + 1;
                    queue.Enqueue(neighbor);
                }
            }
        }
        
        // If we can't reach city n-1, return -1
        return -1;
    }
}