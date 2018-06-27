using System;
using MarkI.Domain;
using Xunit;
using Xunit.Abstractions;

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
            var credentials = new Credentials{UserName = "Paul",Password = "EsponjaSexi69"};
            
            var currentResult = _login.Autorize(credentials);
            
            Assert.True(currentResult);
        }

        [Fact]
        public void ShouldReturnFalseWhenISendInvalidCredentials()
        {   
            var credentials = new Credentials{UserName = "BadUserName",Password = "BadPassword"};

            var currentResult = _login.Autorize(credentials);
            
            Assert.False(currentResult);
        }

        [Theory]
        [InlineData("","")]
        [InlineData(null,null)]
        [InlineData(null,"BadPassword")]
        [InlineData("BadUserName",null)]
        public void ShouldThrowExceptionWhenSendEmptyOrNullCredentials(string userName,string password)
        {
            var credentials = new Credentials{UserName = userName,Password = password};

            const string expectedMessage = "Invalid Credentials";
            
            Assert.Throws<ArgumentException>(()=> _login.Autorize(credentials))
                                .WithMessage(expectedMessage);
        }        
    }
}