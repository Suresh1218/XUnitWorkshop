using Calculator.Services;
using FluentAssertions;

namespace Calculator.ServiceTests
{
    public class StringManipulatorServiceTests
    {
        [Fact]
        public void ReverseString_ValidInput_Success()
        {
            // Arrange
            StringManipulatorService service = new StringManipulatorService();
            string input = "abc";
            string output = "cba";

            //Act
            var result = service.ReverseString(input);

            //Assert
            result.Should().Be(output);

        }

        [Fact]
        public void ReverseString_EmptyInput_Fail()
        {
            // Arrange
            StringManipulatorService service = new StringManipulatorService();

            //Act
            Action result = () => service.ReverseString(string.Empty);

            //Assert
            result.Should().Throw<ArgumentException>().WithMessage("Input string cannot be null or empty.");
        }
    }
}