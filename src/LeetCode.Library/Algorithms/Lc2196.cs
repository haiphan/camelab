using LeetCode.Library.DataStructures;

namespace LeetCode.Library.Algorithms;

public class Lc2196Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        TreeNode[] nodes = new TreeNode[100001];
        bool[] isChild = new bool[100001];

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
                nodes[parentVal].left = nodes[childVal];
            } else {
                nodes[parentVal].right = nodes[childVal];
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

        return nodes[rootVal];
    }
}