using DatabaseDeployment;
using NUnit.Framework;

namespace WebApi.Tests
{
    [SetUpFixture]
    public class Setup
    {
        [OneTimeSetUp]
        public void Deploy()
        {
            Deployer.Deploy(false);
        }

        [OneTimeTearDown]
        public void TearDownDatabase()
        {
            /*Deployer.Delete();*/
        }
    }
}
