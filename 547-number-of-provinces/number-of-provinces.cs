public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        int count = 0;
        var hashSet = new HashSet<int>();
        for (int i = 0; i < isConnected.Length; i++)
        {
            if (!hashSet.Contains(i))
            {
                hashSet.Add(i);
                DFS(isConnected, i, hashSet);
                count++;
            }
        }
        
        return count;
    }
    
    private void DFS(int[][] graph, int i, HashSet<int> hashSet)
    {
        for (int j = 0; j < graph[i].Length; j++)
        {
            if (i != j && graph[i][j] == 1 && !hashSet.Contains(j))
            {
                hashSet.Add(j);
                DFS(graph, j, hashSet);
            }
        }
    }
}