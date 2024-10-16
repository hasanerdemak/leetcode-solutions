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
    public TreeNode SearchBST(TreeNode root, int val) {
        if (root == null || root.val == val) // Base case: if root is null or root's value equals val
            return root;
        else if (root.val > val) // If val is smaller than root's value, search in the left subtree
            return SearchBST(root.left, val);
        else // Otherwise, search in the right subtree
            return SearchBST(root.right, val);
    }
}