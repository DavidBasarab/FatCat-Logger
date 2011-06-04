using System;
using System.Linq;
using FatCat.Logger;
using NBehave.Narrator.Framework;
using NUnit.Framework;

namespace FatCat_Logger.AcceptanceTests.Steps
{
    [ActionSteps]
    public class LoggingInterfaceSteps
    {
        private Type FatCatLoggerType { get; set; }

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
            var haveMessageParameter = MethodHasAParameter<object[]>("Message", "args");

            Assert.That(haveMessageParameter);
        }

        private bool MethodHasAParameter<T>(string methodName, string parameterName)
        {
            var parameters = FatCatLoggerType.GetMethod(methodName).GetParameters();

            var parameterType = typeof (T);

            return parameters
                       .Where(i => i.Name == parameterName && i.ParameterType == parameterType)
                       .Count() == 1;
        }

        [Given("I want to log an exception")]
        public void GivenIWantToLogAnException()
        {
        }

        [Then("I should have a method to log an exception")]
        public void ThenIShouldHaveAMethodToLogAnException()
        {
            Assert.That(FatCatLoggerType, Is.Not.Null);
            Assert.That(FatCatLoggerType.GetMethod("Exception"), Is.Not.Null);
        }

        [Then("I should have a method to log an exception and accepts an exception")]
        public void ThenIShouldHaveAMethodToLogAnExceptionAndAcceptsAnException()
        {
            var exceptionParameter = MethodHasAParameter<Exception>("Exception", "ex");

            Assert.That(exceptionParameter);
        }
    }
}