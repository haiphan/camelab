namespace LeetCode.Library.Algorithms;
using LeetCode.Library.DataStructures;

public class Lc1382Solution {
    public List<TreeNode> nodeList = new();
    public void Inorder(TreeNode root) {
        if (root == null) return;
        Inorder(root.left);
        nodeList.Add(root);
        Inorder(root.right);
    }
    public TreeNode Build(int l, int r) {
        if (l > r) return null;
        int m = (l + r) >> 1;
        TreeNode cur = nodeList[m];
        cur.left = Build(l, m - 1);
        cur.right = Build(m + 1, r);
        return cur;
    }
    public TreeNode BalanceBST(TreeNode root) {
        Inorder(root);
        return Build(0, nodeList.Count - 1);
    }
}