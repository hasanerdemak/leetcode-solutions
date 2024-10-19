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
    // A list to store the values of the rightmost nodes visible at each level.
    private List<int> res = new List<int>();

    public IList<int> RightSideView(TreeNode root) {
        // Start a depth-first search (DFS) from the root node, at depth 0.
        DFS(root, 0);

        // Return the list of right-side view values.
        return res;
    }

    // DFS helper function to traverse the tree.
    private void DFS(TreeNode node, int depth) {
        // Base case: If the current node is null, return.
        if (node == null) return;

        // If this is the first node we're visiting at this depth,
        // it means it's the rightmost node at this level, so add it to the result.
        if (depth == res.Count) {
            res.Add(node.val);
        }

        // First, traverse the right subtree. This ensures that rightmost nodes are processed first.
        DFS(node.right, depth + 1);

        // Then, traverse the left subtree. This is done after the right subtree to ensure
        // that left nodes at each depth only appear in the result if no right node exists.
        DFS(node.left, depth + 1);
    }
}