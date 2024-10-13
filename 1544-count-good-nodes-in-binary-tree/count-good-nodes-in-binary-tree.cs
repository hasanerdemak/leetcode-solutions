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
    public int GoodNodes(TreeNode root) {
        // Base case: if the root is the only node, return 1
        if (root.left == null && root.right == null) {
            return 1;
        }

        // Initialize the count of good nodes
        int count = 0;
        
        // Start recursion from the root node, with the current max value as the root's value
        CountGoodNodes(root, root.val, ref count);

        // Return the total count of good nodes
        return count;
    }

    // Helper method to count good nodes in the tree recursively
    private void CountGoodNodes(TreeNode root, int currentMax, ref int count) {
        // If the node is null, stop recursion
        if (root == null) {
            return;
        }

        // Check if the current node is a good node (its value is greater than or equal to currentMax)
        if (root.val >= currentMax) {
            // Update the current max value and increase the count
            currentMax = root.val;
            count++;
        }

        // Recursively check the left and right children
        CountGoodNodes(root.left, currentMax, ref count);
        CountGoodNodes(root.right, currentMax, ref count);
    }
}