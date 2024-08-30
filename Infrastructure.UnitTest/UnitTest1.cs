using CleanDesign.Application.ViewModels;
using CleanDesign.Infrastructure.Services;

namespace Infrastructure.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            // Arrange & Act
            var exception = Assert.Throws<ArgumentNullException>(() => new EmailSender(null));

            // Assert
            Assert.Equal("appSettings", exception.ParamName);
        }
    }
}