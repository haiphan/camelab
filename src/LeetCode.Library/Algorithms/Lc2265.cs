using LeetCode.Library.DataStructures;

namespace LeetCode.Library.Algorithms;

public class Lc2265Solution {
    public int AverageOfSubtree(TreeNode root) {
        int ans = 0;
        void Dfs(TreeNode? node, out int sum, out int count) {
            if (node == null) {
                sum = 0;
                count = 0;
                return;
            }
            Dfs(node.left, out int leftSum, out int leftCount);
            Dfs(node.right, out int rightSum, out int rightCount);
            sum = node.val + leftSum + rightSum;
            count = 1 + leftCount + rightCount;
            if (sum / count == node.val) ans++;
        }
        Dfs(root, out _, out _);
        return ans;
    }
}