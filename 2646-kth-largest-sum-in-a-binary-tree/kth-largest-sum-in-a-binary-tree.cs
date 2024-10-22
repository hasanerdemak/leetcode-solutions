/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    // Change the dictionary to store long sums to avoid overflow
    private Dictionary<int, long> levelSums = new Dictionary<int, long>();

    public long KthLargestLevelSum(TreeNode root, int k) {
        DFS(root, 0);

        // If there are fewer levels than k, return -1
        if (levelSums.Count < k) return -1;

        return levelSums.Values.OrderByDescending(x => x).Skip(k - 1).FirstOrDefault();
    }

    private void DFS(TreeNode node, int level) {
        if (node == null) return;

        // Accumulate the sum of node values at each level
        if (!levelSums.ContainsKey(level)) {
            levelSums[level] = 0;
        }
        levelSums[level] += node.val;

        // Continue DFS on left and right children
        DFS(node.left, level + 1);
        DFS(node.right, level + 1);
    }
}