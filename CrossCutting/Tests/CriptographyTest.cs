using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Security;

namespace Solution.CrossCutting.Tests
{
    [TestClass]
    public class CriptographyTest
    {
        public CriptographyTest()
        {
            Criptography = DependencyInjector.GetService<ICriptography>();
            Criptography.SetKey("8800A390DCF24C9087F8AAE870FCFE02");
        }

        private ICriptography Criptography { get; }

        [TestMethod]
        public void CriptographyEncryptDecrypt()
        {
            var encrypted = Criptography.Encrypt(nameof(Criptography));
            var decrypted = Criptography.Decrypt(encrypted);

            Assert.AreEqual(nameof(Criptography), decrypted);
        }
    }
}
