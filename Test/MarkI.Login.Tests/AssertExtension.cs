using System;
using Xunit;

namespace MarkI.Login.Tests
{
    public static  class AssertExtension
    {
        public static  void WithMessage(this ArgumentException exception ,string expectedMessage)
        {
           Assert.True(exception.Message.Equals(expectedMessage),userMessage:$"Expected message '{expectedMessage}'");
        }
    }
}