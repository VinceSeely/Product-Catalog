using NUnit.Framework;
using System;

namespace UnitTests
{
    public abstract class Tests
    {
        [SetUp]
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