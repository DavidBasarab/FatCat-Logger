using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NBehave.Narrator.Framework;
using NBehave.Spec.NUnit;

namespace FatCat_Logger.AcceptanceTests.Hookup.Steps
{
    [ActionSteps]
    public class HookUpSteps
    {
        private int _hookUpNumber;

        [Given("I want to test my hook up")]
        public void GivenIWantToTestMyHookUp()
        {
            _hookUpNumber = 42;
        }

        [When("hook up my tests")]
        public void WhenHookUpMyTests()
        {
            _hookUpNumber = 42 + 10;
        }

        [Then("my hook up should pass")]
        public void ThenMyHookUpShouldPass()
        {
            _hookUpNumber.ShouldEqual(52);
        }

    }
}
