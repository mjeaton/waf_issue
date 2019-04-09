using Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace SentryOne.PlanExplorer.Web.Api.Tests.VersioningTests
{
    [TestClass]
    public class WhenAccessingTheVersionEndpoint
    {
        private static WebApplicationFactory<Startup> _Factory;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _Factory = new WebApplicationFactory<Startup>();
        }

        //If these tests are failing you need to set the Test Settings file by
        //going to Test menu > Test Settings > Select Test Settings File and choosing
        //'copyallfilestotestfolder.runsettings' in this project root.
        [TestMethod]
        public async Task AndNoVersionIsSpecifiedInTheUrlThenVersion1IsReturned()
        {
            const string expectedVersionNumber = "[\"1.0\"]";
            //var client = _Factory
            var client = new WebApplicationFactory<Startup>()
               .CreateClient();

            var response = await client.GetAsync("api/queryplan/version");

            Assert.IsTrue(response.IsSuccessStatusCode);
            var actualVersionNumber = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(expectedVersionNumber, actualVersionNumber);
        }

        [TestMethod]
        [Ignore]
        public async Task AndVersion1IsSpecifiedInTheUrlThenVersion1IsReturned()
        {
            const string expectedVersionNumber = "[\"1.0\"]";
            var client = _Factory.CreateClient();

            var response = await client.GetAsync("api/v1/queryplan/version");

            Assert.IsTrue(response.IsSuccessStatusCode);
            var actualVersionNumber = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(expectedVersionNumber, actualVersionNumber);
        }
    }
}
