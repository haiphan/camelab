namespace LeetCode.Library.Algorithms;

public class Lc1111Solution {
    public int[] MaxDepthAfterSplit(string seq) {
        var result = new int[seq.Length];
        int depth = 0;
        for (int i = 0; i < seq.Length; i++) {
            if (seq[i] == '(') {
                depth++;
                result[i] = depth % 2;
            } else {
                result[i] = depth % 2;
                depth--;
            }
        }
        return result;
    }
}