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
    // Recursive function to calculate the maximum depth of the binary tree.
    public int MaxDepth(TreeNode root) {
        // Base case: If the root is null, the tree is empty, so depth is 0.
        if (root == null) return 0;

        // Recursively calculate the depth of the left subtree.
        var left = MaxDepth(root.left);
        // Recursively calculate the depth of the right subtree.
        var right = MaxDepth(root.right);

        // The depth of the current node is 1 (for the current node itself)
        // plus the maximum depth of its left and right subtrees.
        return Math.Max(left, right) + 1;
    }
}