using System;
using Xunit;

namespace MarkI.Login.Tests
{
    public class LoginTests
    {
        Login _login;
        public LoginTests()
        {
            _login = new Login();
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

        [Fact]
        public void ShouldThrowExceptionWhenSendEmptyCredentials()
        {
            Assert.Throws<ArgumentException>(()=>_login.Autorize(string.Empty,string.Empty));
        }

        [Fact]
        public void ShouldThrowExceptionWhenSendNullCredentials()
        {
            Assert.Throws<ArgumentException>(()=>_login.Autorize(null,null));
        }

        [Fact]
        public void ShouldThrowExceptionWhenSendUserNameNullCredentials()
        {
            const string badPassword = "BadPassword";
            Assert.Throws<ArgumentException>(()=>_login.Autorize(null, badPassword));
        }
    }
}