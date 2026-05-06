using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;

public class Lc1861Tests {
    public static TheoryData<char[][], char[][]> Lc1861Data => new()
    {
        // boxGrid, expectedResult
        { [['#', '.', '#']], [['.'],['#'],['#']] },
        {
            [
                ['#', '.', '*', '.'],
                ['#', '#', '*', '.']
            ],
            [
                ['#', '.'],
                ['#', '#'],
                ['*', '*'],
                ['.', '.']
            ]
        },
    };
    
    [Theory]
    [MemberData(nameof(Lc1861Data))]
    public void Test_RotateTheBox(char[][] boxGrid, char[][] expected) {
        // Arrange
        var solution = new Lc1861Solution();

        // Act
        var result = solution.RotateTheBox(boxGrid);

        // Assert
        Assert.Equal(expected, result);
    }
}