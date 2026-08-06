namespace LeetCode.Library.Algorithms;

public class Lc3345Solution {
    private int  GetDiGitProduct(int n) {
        int product = 1;
        while (n > 0) {
            product *= n % 10;
            if (product == 0) {
                return 0;
            }
            n /= 10;
        }
        return product;
    }
    public int SmallestNumber(int n, int t) {
        for (int i = n; i <= 200; i++) {
            if (GetDiGitProduct(i) % t == 0) {
                return i;
            }
        }
        return -1;
    }
}