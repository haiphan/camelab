namespace LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;

public class Lc110Solution {
    public bool good = true;
    public int dfs(TreeNode? root) {
        if (root == null) return 0;
        int l = dfs(root.left);
        int r = dfs(root.right);
        if (Math.Abs(l - r) > 1) good = false;
        return Math.Max(l, r) + 1;
    }
    public bool IsBalanced(TreeNode root) {
        dfs(root);
        return good;
    }
}