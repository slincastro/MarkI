using System;
using Xunit;

namespace MarkI.Departments.Tests
{
    internal static  class AssertExtension
    {
        internal static  void WithMessage(this ArgumentException exception ,string expectedMessage)
        {
           Assert.True(exception.Message.Equals(expectedMessage),userMessage:$"Expected message '{expectedMessage}'");
        }
    }
}