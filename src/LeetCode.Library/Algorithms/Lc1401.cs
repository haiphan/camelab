namespace LeetCode.Library.Algorithms;

public class Lc1401Solution {
    public bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2) {
        int closestX = Math.Clamp(xCenter, x1, x2);
        int closestY = Math.Clamp(yCenter, y1, y2);
        long dx = closestX - (long)xCenter;
        long dy = closestY - (long)yCenter;

        return dx * dx + dy * dy <= (long)radius * radius;
    }
}