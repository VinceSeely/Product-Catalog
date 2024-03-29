using NUnit.Framework;
using System;

namespace UnitTests
{

    [TestFixture]
    public abstract class BaseUnitTest
    {
        [OneTimeSetUp]
        public void TestSetup()
        {
            Mock();
            Setup();
            Run();
        }

        protected abstract void Run();
        protected abstract void Setup();
        protected abstract void Mock();
    }
}