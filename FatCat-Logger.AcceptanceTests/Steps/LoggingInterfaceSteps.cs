using System;
using System.Linq;
using System.Reflection;
using FatCat.Logger.Implementation;
using FatCat.Logger.Interface;
using NBehave.Narrator.Framework;
using NUnit.Framework;

namespace FatCat_Logger.AcceptanceTests.Steps
{
    [ActionSteps]
    public class LoggingInterfaceSteps
    {
        private string _foundName;
        private Type FatCatLoggerType { get; set; }
        private Type LogLevelType { get; set; }

        private Assembly FatCatLoggerAssembly { get; set; }

        [Given("I want to log a message")]
        public void GivenWantToLogAMessage()
        {
        }

        [When("I load the FatCat-Logger .dll")]
        public void WhenLoadFatCatLoggerDll()
        {
            FatCatLoggerType = Logger.Log.GetType();
            FatCatLoggerAssembly = Assembly.Load("FatCat-Logger");
        }

        [Then("I should have a method to log a message")]
        public void ThenIShouldHaveALogMessage()
        {
            CheckMethodExists("Message");
        }

        private void CheckMethodExists(string methodName)
        {
            Assert.That(FatCatLoggerType, Is.Not.Null);
            Assert.That(FatCatLoggerType.GetMethod(methodName), Is.Not.Null);
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
            var parameterType = typeof (T);

            return MethodHasAParameter(methodName, parameterName, parameterType);
        }

        private bool MethodHasAParameter(string methodName, string parameterName, Type parameterType)
        {
            Console.WriteLine("@@@@@@@@@@@ Testing MethodName: {0} | ParameterName: {1} | Type: {2}", methodName, parameterName, parameterType);

            var parameters = FatCatLoggerType.GetMethod(methodName).GetParameters();

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
            CheckMethodExists("Exception");
        }

        [Then("I should have a method to log an exception and accepts an exception")]
        public void ThenIShouldHaveAMethodToLogAnExceptionAndAcceptsAnException()
        {
            var exceptionParameter = MethodHasAParameter<Exception>("Exception", "ex");

            Assert.That(exceptionParameter);
        }

        [Given("I want to log an event viewer message")]
        public void GivenWantToLogAnEventVeiwerMessage()
        {
        }

        [Then("I should have a method to log to the event viewer")]
        public void ThenShouldHaveAMethodToLogToEventViewer()
        {
            CheckMethodExists("EventViewer");
        }

        [Then("I should have a method to log to the event viewer accepting $argument with type $type")]
        public void ThenEventViewerAcceptEventViewIdMessageArguments(string argument, string type)
        {
            var parameterType = Type.GetType(type) ?? FatCatLoggerAssembly.GetType(type);

            Assert.That(MethodHasAParameter("EventViewer", argument, parameterType));
        }

        [Given("I have an enumeration named LogLevel")]
        public void GivenLoadLogLevelEnumartionType()
        {
            LogLevelType = typeof (LogLevel);
        }

        [When("I select $value")]
        public void WhenFindEnumNameBasedOnValue(int value)
        {
            _foundName = Enum.GetName(LogLevelType, value);
        }

        [Then("the name is $name")]
        public void ThenVerifyName(string name)
        {
            Assert.That(_foundName, Is.EqualTo(name));
        }

        [Then("I should have a method to log a message taking a LogLevel")]
        public void ThenVerifyLogMessageAcceptsLogLevel()
        {
            Assert.That(MethodHasAParameter<LogLevel>("Message", "level"));
        }
    }
}