namespace LeetCode.Library.Algorithms;

public class Lc2409Solution {
    private int[] daysInMonth = [0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    private int ToDayOfYear(string date) {
        // fixed "MM-DD" layout, so index digits directly instead of Split + int.Parse
        int month = (date[0] - '0') * 10 + (date[1] - '0');
        int day = (date[3] - '0') * 10 + (date[4] - '0');
        for (int i = 1; i < month; i++) {
            day += daysInMonth[i];
        }
        return day;
    }
    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob) {
        int startAlice = ToDayOfYear(arriveAlice);
        int endAlice = ToDayOfYear(leaveAlice);
        int startBob = ToDayOfYear(arriveBob);
        int endBob = ToDayOfYear(leaveBob);

        int start = Math.Max(startAlice, startBob);
        int end = Math.Min(endAlice, endBob);

        return Math.Max(0, end - start + 1);
    }
}