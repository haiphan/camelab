using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1622Tests {
    public record FancyOp(string type, int val, int expected);
    public static TheoryData<FancyOp[]> Lc1622Data => new()
    {
        // ops
        { new FancyOp[] {
            new FancyOp("Append", 2, 0),
            new FancyOp("AddAll", 3, 0),
            new FancyOp("Append", 7, 0),
            new FancyOp("MultAll", 2, 0),
            new FancyOp("GetIndex", 0, 10),
            new FancyOp("AddAll", 3, 0),
            new FancyOp("Append", 10, 0),
            new FancyOp("MultAll", 2, 0),
            new FancyOp("GetIndex", 0, 26),
            new FancyOp("GetIndex", 1, 34),
            new FancyOp("GetIndex", 2, 20),
        } },
    };
    
    [Theory]
    [MemberData(nameof(Lc1622Data))]
    public void Test_Fancy(FancyOp[] ops) {
        // Arrange
        var solution = new Lc1622Solution();

        // Act
        foreach (var op in ops) {
            switch (op.type) {
                case "Append":
                    solution.Append(op.val);
                    break;
                case "AddAll":
                    solution.AddAll(op.val);
                    break;
                case "MultAll":
                    solution.MultAll(op.val);
                    break;
                case "GetIndex":
                    var result = solution.GetIndex(op.val);
                    Assert.Equal(op.expected, result);
                    break;
            }
        }
    }
}