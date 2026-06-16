using LeetCode.Library.DataStructures;

namespace LeetCode.Library.Algorithms;

public class Lc2196Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        int maxVal = 0;
        foreach (int[] desc in descriptions) {
            if (desc[0] > maxVal) maxVal = desc[0];
            if (desc[1] > maxVal) maxVal = desc[1];
        }

        TreeNode?[] nodes = new TreeNode?[maxVal + 1];
        bool[] isChild = new bool[maxVal + 1];

        foreach (int[] desc in descriptions) {
            int parentVal = desc[0];
            int childVal = desc[1];
            bool isLeft = desc[2] == 1;

            if (nodes[parentVal] == null) {
                nodes[parentVal] = new TreeNode(parentVal);
            }
            if (nodes[childVal] == null) {
                nodes[childVal] = new TreeNode(childVal);
            }

            if (isLeft) {
                nodes[parentVal]!.left = nodes[childVal];
            } else {
                nodes[parentVal]!.right = nodes[childVal];
            }

            isChild[childVal] = true;
        }

        int rootVal = -1;
        foreach (int[] desc in descriptions) {
            int parentVal = desc[0];
            if (!isChild[parentVal]) {
                rootVal = parentVal;
                break;
            }
        }

        return nodes[rootVal]!;
    }
}