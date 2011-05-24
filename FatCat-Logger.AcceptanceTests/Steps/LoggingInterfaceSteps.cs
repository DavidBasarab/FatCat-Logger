using System;
using System.Linq;
using System.Reflection;
using FatCat.Logger;
using NBehave.Narrator.Framework;
using NUnit.Framework;

namespace FatCat_Logger.AcceptanceTests.Steps
{
    [ActionSteps]
    public class LoggingInterfaceSteps
    {
        public Type FatCatLoggerType { get; set; }

        [Given("I want to log a message")]
        public void GivenWantToLogAMessage()
        {
        }

        [When("I load the FatCat-Logger .dll")]
        public void WhenLoadFatCatLoggerDll()
        {
            FatCatLoggerType = Logger.Log.GetType();
        }

        [Then("I should have a method to log a message")]
        public void ThenIShouldHaveALogMessage()
        {
            Assert.That(FatCatLoggerType, Is.Not.Null);
            Assert.That(FatCatLoggerType.GetMethod("Message"), Is.Not.Null);
            MethodInfo temp = null;
        }

        [Then("I should have a method to log a message taking a string")]
        public void ThenLogMessageWithStringMessage()
        {
            var parameters = FatCatLoggerType.GetMethod("Message").GetParameters();

            var haveMessageParameter = parameters
                                           .Where(i => i.Name == "message" && i.ParameterType == typeof (string))
                                           .Count() == 1;

            Assert.That(haveMessageParameter);
        }

        [Then("I should have a method to log a message taking a arguments")]
        public void ThenMessageWithArguements()
        {
            var parameters = FatCatLoggerType.GetMethod("Message").GetParameters();

            var haveMessageParameter = parameters
                                           .Where(i => i.Name == "args" && i.ParameterType == typeof(object[]))
                                           .Count() == 1;

            Assert.That(haveMessageParameter);
        }
    }
}