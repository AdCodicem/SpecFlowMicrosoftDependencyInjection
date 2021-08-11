using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Sample.MsTests.Specs.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Multiplication")]
    public class MultiplicationSteps
    {
        private readonly ICalculator _calculator;

        public MultiplicationSteps(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int operand)
        {
            _calculator.Enter(operand);
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            _calculator.Multiply();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            Assert.AreEqual(expectedResult, _calculator.Result);
        }
    }
}
