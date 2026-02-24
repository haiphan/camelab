namespace LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;

public class Lc1022Solution {
    public int ans = 0;
    public void dfs(TreeNode root, int cur) {
        int nxt = (cur << 1) + root.val;
        if (root.left == null && root.right == null) {
            ans += nxt;
            return;
        }
        if (root.left != null) dfs(root.left, nxt);
        if (root.right != null) dfs(root.right, nxt);
    }
    public int SumRootToLeaf(TreeNode root) {
        dfs(root, 0);
        return ans;
    }
}