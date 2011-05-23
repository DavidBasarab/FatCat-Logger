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

        [Given]
        public void Given_I_want_to_test_my_hook_up()
        {
            _hookUpNumber = 42;
        }

        [When]
        public void When_hook_up_my_tests()
        {
            _hookUpNumber = 42 + 10;
        }

        [Then]
        public void Then_my_hook_up_should_pass()
        {
            _hookUpNumber.ShouldEqual(52);
        }

    }
}
