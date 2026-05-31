namespace LeetCode.Library.Algorithms;

public class Lc2126Solution {
    public bool AsteroidsDestroyed(int mass, int[] asteroids) {
        int[] ac = new int[100001];
        int maxv = 0;
        foreach (int a in asteroids) {
            ac[a]++;
            maxv = Math.Max(maxv, a);
        }
        long sum = mass;
        for (int i = 1; i <= maxv; i++)
        {
            if (sum < i) {
                return false;
            }
            sum += (long)ac[i] * i;
        }
        return true;
    }
}