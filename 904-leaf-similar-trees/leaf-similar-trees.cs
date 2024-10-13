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
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        // Create lists to store the leaf sequences for both trees
        List<int> leaves1 = new List<int>();
        List<int> leaves2 = new List<int>();
        
        // Populate leaf sequences using helper method
        GetLeaves(root1, leaves1);
        GetLeaves(root2, leaves2);
        
        // Compare the leaf sequences of the two trees
        return leaves1.SequenceEqual(leaves2);
    }

    // Helper method to collect leaf values using DFS
    private void GetLeaves(TreeNode node, List<int> leaves) {
        // Base case: if the node is null, return
        if (node == null) return;
        
        // Check if it's a leaf node (both left and right children are null)
        if (node.left == null && node.right == null) {
            leaves.Add(node.val); // Add leaf node value to the list
        }
        
        // Recursively collect leaves from the left and right subtrees
        GetLeaves(node.left, leaves);
        GetLeaves(node.right, leaves);
    }
}