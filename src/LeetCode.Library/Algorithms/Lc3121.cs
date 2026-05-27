namespace LeetCode.Library.Algorithms;

public class Lc3121Solution {
    public int NumberOfSpecialChars(string word) {
        int n = word.Length;
        int count = 0;
        int[] lowPos = new int[26];
        int[] upPos = new int[26];
        for (int i = 0; i < 26; i++) {
            lowPos[i] = -1;
            upPos[i] = -1;
        }
        for (int i = 0; i < n; i++) {
            char c = word[i];
            int code = (c | (char)32) - 'a';
            if ((c & (char)32) == 0) {
                if (upPos[code] == -1) {
                    upPos[code] = i;
                }
            } else {
                lowPos[code] = i;
            }
        }
        for (int i = 0; i < 26; i++) {
            if (lowPos[i] != -1 && upPos[i] != -1 && lowPos[i] < upPos[i]) {
                count++;
            }
        }
        return count;
    }
}