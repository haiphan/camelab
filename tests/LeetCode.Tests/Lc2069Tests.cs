using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc2069Tests {
    public record RobotOp(string Op, int width, int height, int num, int x, int y, string dir);
    public static TheoryData<RobotOp[]> Lc2069Data => new()
    {
        // robotOps
        { new RobotOp[]
            {
                new RobotOp("Robot", 6, 3, 0, 0, 0, "North"),
                new RobotOp("Step", 0, 0, 2, 0, 4, "North"),
                new RobotOp("Step", 0, 0, 2, 0, 4, "North"),
                new RobotOp("GetPos", 0, 0, 0, 4, 0, "North"),
                new RobotOp("GetDir", 0, 0, 0, 4, 0, "East"),
                new RobotOp("Step", 0, 0, 2, 6, 0, "East"),
                new RobotOp("Step", 0, 0, 1, 6, 0, "East"),
                new RobotOp("Step", 0, 0, 4, 6, 0, "East"),
                new RobotOp("GetPos", 0, 0, 0, 1, 2, "East"),
                new RobotOp("GetDir", 0, 0, 0, 1, 2, "West"),
            }
        },
    };
    
    [Theory]
    [MemberData(nameof(Lc2069Data))]
    public void Test_Robot(RobotOp[] robotOps) {
        // Arrange
        var solution = new Lc2069Solution();
        for (int i = 0; i < robotOps.Length; i++) {
            var op = robotOps[i];
            if (op.Op == "Robot") {
                solution.Robot(op.width, op.height);
            } else if (op.Op == "Step") {
                solution.Step(op.num);
            } else if (op.Op == "GetPos") {
                var pos = solution.GetPos();
                Assert.Equal([op.x, op.y], pos);
            } else if (op.Op == "GetDir") {
                var dir = solution.GetDir();
                Assert.Equal(op.dir, dir);
            } else {
                throw new InvalidOperationException($"Unknown operation: {op.Op}");
            }
        }
    }
}