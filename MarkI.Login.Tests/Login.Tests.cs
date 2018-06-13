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
            //SetUp

            //SUT
            
            var currentResult = _login.Autorize("Paul","EsponjaSexi69");
            //Assert
            Assert.True(currentResult);
        }

        [Fact]
        public void ShouldReturnFalseWhenISendInvalidCredentials()
        {
            var currentResult = new Login().Autorize("BadUserName","BadPassword");
            Assert.False(currentResult);
        }

        [Fact]
        public void ShouldThrowExceptionWhenSendEmptyCredentials()
        {
            Assert.Throws<ArgumentException>(()=>new Login().Autorize("",""));
        }

        [Fact]
        public void ShouldThrowExceptionWhenSendNullCredentials()
        {
            Assert.Throws<ArgumentException>(()=>new Login().Autorize(null,null));
        }

        [Fact]
        public void ShouldThrowExceptionWhenSendUserNameNullCredentials()
        {
            Assert.Throws<ArgumentException>(()=>new Login().Autorize(null,"BadPassword"));
        }
    }
}