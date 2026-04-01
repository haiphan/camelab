namespace LeetCode.Library.Algorithms;

public class Lc2751Solution {
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions) {
        int n = positions.Length;
        int[] idx = new int[n];
        for (int i = 0; i < n; i++) {
            idx[i] = i;
        }
        Array.Sort(idx, (a, b) => positions[a] - positions[b]);
        Stack<int> stack = new Stack<int>(n);
        for (int i = 0; i < n; i++) {
            int j = idx[i];
            if (directions[j] == 'R') {
                stack.Push(j);
            } else {
                while (stack.Count > 0 && healths[j] > 0) {
                    int top = stack.Peek();
                    if (healths[top] == healths[j]) {
                        healths[top] = 0;
                        healths[j] = 0;
                        stack.Pop();
                        break;
                    } else if (healths[top] > healths[j]) {
                        healths[top]--;
                        healths[j] = 0;
                        break;
                    } else {
                        healths[top] = 0;
                        healths[j]--;
                        stack.Pop();
                    }
                }
            }
        }
        List<int> res = new List<int>(n);
        for (int i = 0; i < n; i++) {
            if (healths[i] > 0) {
                res.Add(healths[i]);
            }
        }
        return res;
    }
}