using System;
using Xunit;

namespace MarkI.Login.Tests
{
    public class LoginTests
    {
        Autorizer _login;
        public LoginTests()
        {
            _login = new Autorizer( new UsersRepositoryTest());
        }

        [Fact]
        public void ShouldReturnTrueWhenISendAvalidCredentials()
        {
            const string userName = "Paul";
            const string password = "EsponjaSexi69";
            
            var currentResult = _login.Autorize(userName, password);
            
            Assert.True(currentResult);
        }

        [Fact]
        public void ShouldReturnFalseWhenISendInvalidCredentials()
        {
            const string badUserName = "BadUserName";
            const string badPassword = "BadPassword";
            
            var currentResult = _login.Autorize(badUserName, badPassword);
            
            Assert.False(currentResult);
        }

        [Theory]
        [InlineData("","")]
        [InlineData(null,null)]
        public void ShouldThrowExceptionWhenSendEmptyOrNull(string userName,string password)
        {
            Assert.Throws<ArgumentException>(()=>_login.Autorize(userName,password));
        }

        [Fact]
        public void ShouldThrowExceptionWhenSendUserNameNullCredentials()
        {
            const string badPassword = "BadPassword";
            Assert.Throws<ArgumentException>(()=>_login.Autorize(null, badPassword));
        }
    }
}