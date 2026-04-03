using System.Data;

namespace LeetCode.Library.Algorithms;

public class Lc3661Solution {
    public record struct Robot(int Position, int Distance);
    public int MaxWalls(int[] robots, int[] distance, int[] walls) {
        if (robots.Length == 0 || walls.Length == 0) {
            return 0;
        }

        int n = robots.Length;
        Robot[] arr = new Robot[n + 1];
        for (int i = 0; i < n; i++) {
            arr[i] = new Robot(robots[i], distance[i]);
        }
        arr[n] = new Robot(1000000000, 0);
        Array.Sort(arr, (a, b) => a.Position.CompareTo(b.Position));
        Array.Sort(walls);

        HashSet<int> leftBoundaries = [];
        HashSet<int> rightBoundaries = [];

        void addInterval(int left, int right) {
            if (left > right) {
                return;
            }

            leftBoundaries.Add(left);
            rightBoundaries.Add(right);
        }

        addInterval(arr[0].Position - arr[0].Distance, arr[0].Position);
        if (n > 1) {
            addInterval(arr[0].Position, Math.Min(arr[0].Position + arr[0].Distance, arr[1].Position - 1));
        } else {
            addInterval(arr[0].Position, arr[0].Position + arr[0].Distance);
        }

        for (int i = 1; i < n; i++) {
            int maxR = Math.Min(arr[i].Position + arr[i].Distance, arr[i + 1].Position - 1);
            int maxL = Math.Max(arr[i].Position - arr[i].Distance, arr[i - 1].Position + 1);
            int lStart = Math.Max(arr[i].Position - arr[i].Distance, arr[i - 1].Position + 1);
            int lEnd = arr[i].Position;
            int overlapStart = lStart;
            int overlapEnd = Math.Min(arr[i - 1].Position + arr[i - 1].Distance, lEnd - 1);

            addInterval(arr[i].Position, maxR);
            addInterval(maxL, arr[i].Position);
            addInterval(lStart, lEnd);
            addInterval(overlapStart, overlapEnd);
        }

        int[] sortedLeftBoundaries = [.. leftBoundaries];
        Array.Sort(sortedLeftBoundaries);
        Dictionary<int, int> wallsBefore = new(sortedLeftBoundaries.Length);
        int wallIndex = 0;

        foreach (int boundary in sortedLeftBoundaries) {
            while (wallIndex < walls.Length && walls[wallIndex] < boundary) {
                wallIndex++;
            }

            wallsBefore[boundary] = wallIndex;
        }

        int[] sortedRightBoundaries = [.. rightBoundaries];
        Array.Sort(sortedRightBoundaries);
        Dictionary<int, int> wallsAtOrBefore = new(sortedRightBoundaries.Length);
        wallIndex = 0;

        foreach (int boundary in sortedRightBoundaries) {
            while (wallIndex < walls.Length && walls[wallIndex] <= boundary) {
                wallIndex++;
            }

            wallsAtOrBefore[boundary] = wallIndex;
        }

        // count items in walls that are in range [l, r]
        int countWalls(int l, int r) {
            if (l > r) return 0;

            return wallsAtOrBefore[r] - wallsBefore[l];
        }

        int previousLeft = countWalls(arr[0].Position - arr[0].Distance, arr[0].Position);
        int previousRight;
        if (n > 1)
        {
            previousRight = countWalls(arr[0].Position, Math.Min(arr[0].Position + arr[0].Distance, arr[1].Position - 1));
        } else
        {
            previousRight = countWalls(arr[0].Position, arr[0].Position + arr[0].Distance);
        }

        for (int i = 1; i < n; i++) {
            int maxR = Math.Min(arr[i].Position + arr[i].Distance, arr[i + 1].Position - 1);
            int maxL = Math.Max(arr[i].Position - arr[i].Distance, arr[i - 1].Position + 1);
            int currentRight = Math.Max(previousLeft, previousRight) + countWalls(arr[i].Position, maxR);
            int currentLeft = previousLeft + countWalls(maxL, arr[i].Position);
            int lStart = Math.Max(arr[i].Position - arr[i].Distance, arr[i - 1].Position + 1);
            int lEnd = arr[i].Position;
            int overlapStart = lStart;
            int overlapEnd = Math.Min(arr[i - 1].Position + arr[i - 1].Distance, lEnd - 1);

            currentLeft = Math.Max(currentLeft, previousRight + countWalls(lStart, lEnd) - countWalls(overlapStart, overlapEnd));
            previousLeft = currentLeft;
            previousRight = currentRight;
        }

        return Math.Max(previousLeft, previousRight);
    }
}