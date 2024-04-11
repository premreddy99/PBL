using Xunit;
using StudentManagementAPI.Controllers;

namespace StudentManagement.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void GiveStudent_ReturnsExpectedString()
        {
            // Arrange
            var controller = new StudentController();

            // Act
            var result = controller.GiveStudent();

            // Assert
            Assert.Equal("ac", result);
        }
    }
}
