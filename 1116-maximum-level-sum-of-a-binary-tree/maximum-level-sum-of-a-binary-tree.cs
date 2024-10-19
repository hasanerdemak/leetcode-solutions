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
    // A dictionary to store the sum of node values at each level.
    private readonly Dictionary<int, int> levelSums = new Dictionary<int, int>();

    public int MaxLevelSum(TreeNode root) {
        // Start a Depth-First Search (DFS) from the root node at level 1.
        DFS(root, 1);

        // Find the level with the maximum sum. If multiple levels have the same sum,
        // the smallest level number is returned.
        return levelSums.MaxBy(x => x.Value).Key;
    }

    // Helper function to perform DFS traversal of the tree.
    private void DFS(TreeNode node, int level) {
        // Base case: If the node is null, return.
        if (node == null) return;

        // If this is the first time visiting this level, initialize its sum to 0.
        if (!levelSums.ContainsKey(level)) {
            levelSums[level] = 0;
        }
        // Add the value of the current node to the sum for its level.
        levelSums[level] += node.val;

        // Recursively process the left and right childs respectively, increasing the level by 1.
        DFS(node.left, level + 1);
        DFS(node.right, level + 1);
    }
}