public class Solution {
    // Dictionary to represent the graph where each node points to its neighbors and the division values.
    private Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();

    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        // Step 1: Build the graph
        BuildGraph(equations, values);

        // Step 2: Answer the queries
        double[] results = new double[queries.Count];
        
        for (int i = 0; i < queries.Count; i++) {
            string dividend = queries[i][0];
            string divisor = queries[i][1];

            // If either the dividend or divisor is not in the graph, return -1.0
            if (!graph.ContainsKey(dividend) || !graph.ContainsKey(divisor)) {
                results[i] = -1.0;
            } else if (dividend == divisor) {
                // If dividend and divisor are the same, the result is 1.0
                results[i] = 1.0;
            } else {
                // Perform DFS to find the result
                HashSet<string> visited = new HashSet<string>();
                results[i] = DFS(dividend, divisor, visited);
            }
        }

        return results;
    }

    // Helper method to build the graph from equations and values
    private void BuildGraph(IList<IList<string>> equations, double[] values) {
        for (int i = 0; i < equations.Count; i++) {
            string A = equations[i][0];
            string B = equations[i][1];
            double value = values[i];

            // Add the edge A / B = value
            if (!graph.ContainsKey(A)) {
                graph[A] = new Dictionary<string, double>();
            }
            graph[A][B] = value;

            // Add the reverse edge B / A = 1 / value
            if (!graph.ContainsKey(B)) {
                graph[B] = new Dictionary<string, double>();
            }
            graph[B][A] = 1.0 / value;
        }
    }

    // DFS method to find the division result from dividend to divisor
    private double DFS(string dividend, string divisor, HashSet<string> visited) {
        // If there's a direct edge between dividend and divisor
        if (graph[dividend].ContainsKey(divisor)) {
            return graph[dividend][divisor];
        }

        // Mark the current node as visited
        visited.Add(dividend);

        // Try all neighbors
        foreach (var neighbor in graph[dividend]) {
            if (!visited.Contains(neighbor.Key)) {
                double result = DFS(neighbor.Key, divisor, visited);
                if (result != -1.0) {
                    return neighbor.Value * result;
                }
            }
        }

        // If no path is found, return -1.0
        return -1.0;
    }
}
