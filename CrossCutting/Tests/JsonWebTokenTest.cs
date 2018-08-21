using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Security;

namespace Solution.CrossCutting.Tests
{
    [TestClass]
    public class JsonWebTokenTest
    {
        public JsonWebTokenTest()
        {
            JsonWebToken = DependencyInjector.GetService<IJsonWebToken>();
        }

        private IJsonWebToken JsonWebToken { get; }

        [TestMethod]
        public void JsonWebTokenEncodeDecode()
        {
            var encoded = JsonWebToken.Encode("sub", new[] { "admin" });
            var decoded = JsonWebToken.Decode(encoded);

            Assert.IsNotNull(decoded);
        }

        [TestMethod]
        public void JsonWebTokenGetTokenValidationParameters()
        {
            var parameters = JsonWebToken.TokenValidationParameters;

            Assert.IsNotNull(parameters);
        }
    }
}
