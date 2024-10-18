/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // Base case: If root is null, there's no ancestor, so return null.
        if (root == null) return null;

        // If the current node is either p or q, return this node as it might be the LCA.
        if (root == p || root == q) return root;

        // Recursively search for LCA in the left subtree.
        TreeNode left = LowestCommonAncestor(root.left, p, q);
        // Recursively search for LCA in the right subtree.
        TreeNode right = LowestCommonAncestor(root.right, p, q);

        // If both left and right are non-null, it means p is in one subtree and q is in the other,
        // so the current root is their lowest common ancestor.
        if (left != null && right != null) return root;

        // If either left or right is null, return the non-null value.
        // This means the LCA (or one of the nodes) was found in one of the subtrees.
        if (left == null) return right;
        else return left;
    }
}