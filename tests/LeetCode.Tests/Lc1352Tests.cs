using LeetCode.Library.Algorithms;
using Xunit;

namespace LeetCode.Tests;
public record ProductOfNumbersOperation(string Operation, int? Argument, int? Expected);
public class Lc1352Tests {
    public static TheoryData<ProductOfNumbersOperation[]> Lc1352Data => new()
    {
        { new ProductOfNumbersOperation[] {
            new ProductOfNumbersOperation("Add", 3, null),
            new ProductOfNumbersOperation("Add", 0, null),
            new ProductOfNumbersOperation("Add", 2, null),
            new ProductOfNumbersOperation("Add", 5, null),
            new ProductOfNumbersOperation("Add", 4, null),
            new ProductOfNumbersOperation("GetProduct", 2, 20),
            new ProductOfNumbersOperation("GetProduct", 3, 40),
            new ProductOfNumbersOperation("GetProduct", 4, 0),
            new ProductOfNumbersOperation("Add", 8, null),
            new ProductOfNumbersOperation("GetProduct", 2, 32)
        } },
    };
    
    [Theory]
    [MemberData(nameof(Lc1352Data))]
    public void Test_ProductOfNumbers(ProductOfNumbersOperation[] operations) {
        // Arrange
        var solution = new Lc1352Solution();

        foreach (var op in operations) {
            if (op.Operation == "Add" && op.Argument.HasValue) {
                solution.Add(op.Argument.Value);
            } else if (op.Operation == "GetProduct" && op.Argument.HasValue) {
                var result = solution.GetProduct(op.Argument.Value);
                Assert.Equal(op.Expected, result);
            }
        }
    }
}