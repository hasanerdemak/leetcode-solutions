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
    // Variable to keep track of the maximum ZigZag path length found so far.
    private int maxLength = 0;

    public int LongestZigZag(TreeNode root) {
        // Start DFS from the root node in both directions:
        DFS(root, true, 0);  // Check ZigZag path starting with a left direction.
        DFS(root, false, 0); // Check ZigZag path starting with a right direction.

        return maxLength;
    }

    // Helper function to perform DFS. It takes three parameters:
    // - node: The current node being visited.
    // - isLeft: A boolean flag indicating the current node's direction (true means left child, false means right child).
    // - length: The current length of the ZigZag path.
    private void DFS(TreeNode node, bool isLeft, int length) {
        // Base case: If the node is null, return as there's no more path to explore.
        if (node == null) return;

        // Update the maximum length with the current path length if it's greater than the previous max.
        maxLength = Math.Max(maxLength, length);

        // Recursively traverse to the left and right children:
        // - If the current node's direction is left, the next direction should be right, and vice versa.
        // - Depending on the current node's direction (isLeft), we either reset the length to 1 (continue in the same direction) 
        //   or increment the length (switch direction).
        
        // Move to the left child:
        DFS(node.left, true, isLeft ? 1 : length + 1);  // If the node is right child, continue the ZigZag; otherwise, reset.

        // Move to the right child:
        DFS(node.right, false, isLeft ? length + 1 : 1); // If the node is left child, continue the ZigZag; otherwise, reset.
    }
}