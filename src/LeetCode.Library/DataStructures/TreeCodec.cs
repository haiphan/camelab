using System.Text;
namespace LeetCode.Library.DataStructures;

public class TreeCodec 
{
    private const string NullMarker = "#";
    private const string Separator = ",";

    // Encodes a tree to a single string.
    public string Serialize(TreeNode? root) 
    {
        StringBuilder sb = new();
        BuildString(root, sb);
        return sb.ToString().TrimEnd(',');
    }

    private void BuildString(TreeNode? node, StringBuilder sb) 
    {
        if (node == null) 
        {
            sb.Append(NullMarker).Append(Separator);
            return;
        }

        sb.Append(node.val).Append(Separator);
        BuildString(node.left, sb);
        BuildString(node.right, sb);
    }

    // Decodes your encoded data to tree.
    public TreeNode? Deserialize(string data) 
    {
        if (string.IsNullOrEmpty(data)) return null;

        // Split data and put into a Queue for O(1) access to the next element
        Queue<string> nodes = new(data.Split(Separator));
        return BuildTree(nodes);
    }

    private TreeNode? BuildTree(Queue<string> nodes) 
    {
        string val = nodes.Dequeue();

        if (val == NullMarker) return null;

        TreeNode node = new TreeNode(int.Parse(val));
        node.left = BuildTree(nodes);
        node.right = BuildTree(nodes);
        
        return node;
    }
}