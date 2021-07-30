namespace GetterApiServicesTests
{
    using GetterApiServices;
    using Xunit;

    public class DomainServiceTest
    {
        [Fact]
        public void GetDomainsShouldReturnString()
        {
            var subjectUnderTest = new DomainService();
            var expected = "[{\"Name\":\"Weather\",\"AvailableEndpoints\":[{\"Name\":\"alerts\",\"Uri\":\"https://api.weather.gov/alerts\",\"Default\":false},{\"Name\":\"activeAlerts\",\"Uri\":\"https://api.weather.gov/alerts/active\",\"Default\":true},{\"Name\":\"alertTypes\",\"Uri\":\"https://api.weather.gov/alerts/types\",\"Default\":false}]}]";

            var actual = subjectUnderTest.GetDomains();

            Assert.Equal(expected, actual);
        }
    }
}
