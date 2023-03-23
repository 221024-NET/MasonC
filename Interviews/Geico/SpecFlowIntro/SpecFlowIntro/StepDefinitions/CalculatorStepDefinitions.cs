using NUnit.Framework;
using TechTalk.SpecFlow.CommonModels;

namespace SpecFlowIntro.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        //int ans = 0;
        //int num1 = 0;
        //int num2 = 0;
        Calculator c;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            //throw new PendingStepException();
            Console.WriteLine("Number 1: " + number);
            //num1 = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic

            //throw new PendingStepException();
            Console.WriteLine("Number 2: " + number);
            //num2 = number;
        }


        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            //throw new PendingStepException();
            Console.WriteLine("Adding the two nums together");
            //ans = num1 + num2;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            //throw new PendingStepException();
            //Console.WriteLine("Result: " + result);
            Assert.IsTrue(result.Equals(c.ans));

        }

        [Then(@"the result should not be (.*)")]
        public void ThenTheResultShouldNotBe(int result)
        {
            Assert.IsFalse(result.Equals(c.ans));
        }

        [Given(@"that I have a Calculator")]
        public void GivenThatIHaveACalculator()
        {
            Console.WriteLine("Create Calculator Object ....");
            c = new Calculator();
        }

        [When(@"(.*) and (.*) are added")]
        public void WhenAndAreAdded(int p0, int p1)
        {
            c.add2Nums(p0, p1);
        }




    }
}