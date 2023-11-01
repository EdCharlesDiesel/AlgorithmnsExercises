using System.Reflection.Emit;

namespace BreakCamelCase.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Should_be_assigned_different_values()
        {
            var actual = BreakCamelCaseClass.BreakCamelCase("camelCasing");
            Assert.Equal("camel Casing",actual);            
        }

        [Fact]
        public void Should_be_assigned_Different_values()
        {
            var actual = BreakCamelCaseClass.BreakCamelCase("khotsoCharles");
            Assert.Equal("khotso Charles", actual);
        }
    }
}