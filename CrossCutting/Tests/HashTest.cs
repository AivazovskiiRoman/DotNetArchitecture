using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Security;

namespace Solution.CrossCutting.Tests
{
    [TestClass]
    public class HashTest
    {
        public HashTest()
        {
            Hash = DependencyInjector.GetService<IHash>();
        }

        private IHash Hash { get; }

        [TestMethod]
        public void HashCreate()
        {
            var hash = Hash.Create(nameof(Hash));

            Assert.IsNotNull(hash);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashCreateEmpty()
        {
            Hash.Create(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashCreateNull()
        {
            Hash.Create(null);
        }
    }
}
