using Sample.Specs.Support;
using System;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace Sample.Specs.StepDefinitions
{
    [Binding]
    public sealed class DisposeInstanceSteps : IDisposable
    {
        private ITestOutputHelper Output { get; }
        private static int DisposeCallCount { get; set; }
        private static int InstanciationCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dependency">Use BoDi container for fallback (nested dependency)</param>
        /// <param name="context">Use BoDi container for fallback</param>
        public DisposeInstanceSteps(Dependency dependency, FeatureContext context)
        {
            Output = dependency.Output;
            InstanciationCount++;
        }

        [Then(@"Dispose should have been called the right number of times")]
        public void ThenDisposeShouldHaveBeenCalledTimes()
        {
            Output.WriteLine($"{nameof(InstanciationCount)} : {InstanciationCount}");
            Output.WriteLine($"{nameof(DisposeCallCount)}   : {DisposeCallCount}");
            var expected = InstanciationCount - 1;
            Assert.Equal(expected, DisposeCallCount);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            DisposeCallCount++;
        }
    }
}
