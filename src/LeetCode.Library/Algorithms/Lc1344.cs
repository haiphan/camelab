namespace LeetCode.Library.Algorithms;

public class Lc1344Solution {
    public double AngleClock(int hour, int minutes) {
        int numMinutes = (hour % 12) * 60 + minutes;
        double angleH = numMinutes * 0.5; // Hour hand moves 0.5 degrees per minute
        double angleM = minutes * 6;       // Minute hand moves 6 degrees per minute
        double angle = Math.Abs(angleH - angleM);
        return Math.Min(angle, 360 - angle);
    }
}