namespace LeetCode.Library.Algorithms;

public class Lc836Solution {
    public bool IsRectangleOverlap(int[] rec1, int[] rec2) {
        // overlap if the rectangles are not completely to the left, right, above, or below each other
        return rec1[0] < rec2[2] && rec1[2] > rec2[0] && rec1[1] < rec2[3] && rec1[3] > rec2[1];
    }
}