using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace Sample.Specs.StepDefinitions
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

        [Given(@"I have entered the following numbers")]
        public void GivenIHaveEnteredTheFollowingNumbers(Table table)
        {
            foreach (var number in table.Rows.Select(r => int.Parse(r["number"])))
            {
                _calculator.Enter(number);
            }
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            Assert.Equal(expectedResult, _calculator.Result);
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            _calculator.Multiply();
        }
    }
}
