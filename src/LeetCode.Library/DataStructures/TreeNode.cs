namespace LeetCode.Library.DataStructures;

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    // Standard constructors required by LeetCode
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}