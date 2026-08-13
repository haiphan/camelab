namespace LeetCode.Library.Algorithms;

public class Lc2213Solution {
    public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices) {
        char[] chars = s.ToCharArray();
        SegmentTree tree = new SegmentTree(chars);

        int k = queryIndices.Length;
        int[] ans = new int[k];
        for (int i = 0; i < k; i++) {
            int idx = queryIndices[i];
            char ch = queryCharacters[i];
            if (chars[idx] != ch) {
                chars[idx] = ch;
                tree.Update(idx, ch);
            }
            ans[i] = tree.Root.Best;
        }

        return ans;
    }

    private sealed class SegmentTree {
        private readonly Node[] tree;
        private readonly int size;

        public SegmentTree(char[] s) {
            int n = s.Length;
            size = 1;
            while (size < n) {
                size <<= 1;
            }

            tree = new Node[size << 1];
            for (int i = 0; i < n; i++) {
                tree[size + i] = new Node(s[i]);
            }

            for (int i = size - 1; i > 0; i--) {
                tree[i] = Merge(tree[2 * i], tree[2 * i + 1]);
            }
        }

        public Node Root => tree[1];

        public void Update(int idx, char ch) {
            int pos = size + idx;
            tree[pos] = new Node(ch);
            for (pos >>= 1; pos >= 1; pos >>= 1) {
                tree[pos] = Merge(tree[2 * pos], tree[2 * pos + 1]);
            }
        }

        private static Node Merge(Node left, Node right) {
            // Empty leaves pad the array to a power-of-two size; treat them as the merge identity.
            if (left.Len == 0) {
                return right;
            }
            if (right.Len == 0) {
                return left;
            }

            Node result = new Node {
                Len = left.Len + right.Len,
                LeftChar = left.LeftChar,
                RightChar = right.RightChar,
                Prefix = left.Prefix,
                Suffix = right.Suffix,
                Best = Math.Max(left.Best, right.Best),
            };

            if (left.Prefix == left.Len && left.RightChar == right.LeftChar) {
                result.Prefix += right.Prefix;
            }

            if (right.Suffix == right.Len && right.LeftChar == left.RightChar) {
                result.Suffix += left.Suffix;
            }

            if (left.RightChar == right.LeftChar) {
                result.Best = Math.Max(result.Best, left.Suffix + right.Prefix);
            }

            return result;
        }

        public struct Node {
            public int Len;
            public char LeftChar;
            public char RightChar;
            public int Prefix;
            public int Suffix;
            public int Best;

            public Node(char c) {
                Len = 1;
                LeftChar = c;
                RightChar = c;
                Prefix = 1;
                Suffix = 1;
                Best = 1;
            }
        }
    }
}