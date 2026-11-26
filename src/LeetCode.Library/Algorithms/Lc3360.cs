namespace LeetCode.Library.Algorithms;

public class Lc3360Solution {
    // After t successful turns, the total removed is the triangular sum
    // S(t) = 10 + 9 + ... + (11-t) = t(21-t)/2. Alice wins iff the number of
    // successful turns t is odd (the player facing the (t+1)-th, failing turn
    // loses, and Alice moves on odd turns). Solving S(t) <= n for the largest
    // integer t reduces to the quadratic t^2 - 21t + 2n >= 0, giving
    // t = floor((21 - sqrt(441 - 8n)) / 2). Once n >= 55 (= S(10)), the
    // removal amount would reach 0 on turn 11, which is never a valid move,
    // so t saturates at 10 (even) regardless of how large n is.
    public bool CanAliceWin(int n) {
        long disc = 441L - 8L * n;
        if (disc <= 0) {
            return false;
        }

        long r = (long)Math.Sqrt(disc);
        while ((r + 1) * (r + 1) <= disc) {
            r++;
        }
        while (r * r > disc) {
            r--;
        }

        long t = (21 - r) / 2;
        while (t * (21 - t) / 2 > n) {
            t--;
        }
        while (t + 1 <= 10 && (t + 1) * (21 - (t + 1)) / 2 <= n) {
            t++;
        }

        return t % 2 == 1;
    }

    public bool CanAliceWinIter(int n) {
        int remove = 10;
        bool alice = true;
        while (n > 0) {
            if (n < remove) {
                return !alice;
            }
            n -= remove;
            remove--;
            alice = !alice;
        }
        return !alice;
    }
}