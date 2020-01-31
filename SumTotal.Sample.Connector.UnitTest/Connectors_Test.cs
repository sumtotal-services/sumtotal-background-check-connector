using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace SumTotal.Sample.Connector.UnitTest
{
    public class Connectors_Test
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Connectors_Test()
        {
        }

        /// <summary>
        /// sample method for unit test
        /// </summary>
        [Fact]
        public void Test_BackgroundCheckConnector_TestUnitTest()
        {
            var mockTestProcessor = new Mock<TestProcessor>().Object;
            var outputValue = mockTestProcessor.TestMethod("Test Value");
            //Assert
            Assert.Equal("Test Value", outputValue);
        }
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }

        /// <summary>
        /// Get package details
        /// </summary>
        /// <returns> package details</returns>
        [Fact]
        public void Test_BackgroundCheckConnector_GetPackagesForCheckr()
        {
            var config = InitConfiguration();
            var  checkrBaseUrl = config["Settings:vendors:1:VendorOAuthSettings:BaseUrl"];
            var data = new TestProcessor().CheckrGetPackages(checkrBaseUrl + "GetPackages");            
            Assert.Equal("1234", data[0].Id);
        }

        /// <summary>
        /// Get package details by Id
        /// </summary>
        /// <returns> package details</returns>
        [Fact]
        public void Test_BackgroundCheckConnector_GetPackageByIdForGoodHire()
        {
            int id = 1;
            var config = InitConfiguration();
            var goodHireBaseUrl = config["Settings:vendors:1:VendorOAuthSettings:BaseUrl"];
            var data = new TestProcessor().CheckrGetPackageById(goodHireBaseUrl + "GetPackageById/" + id);
            Assert.Equal("Choice", data.Name);
        }

    }
}
