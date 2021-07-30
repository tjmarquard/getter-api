namespace GetterApiServicesTests
{
    using GetterApiServices;
    using Xunit;

    public class DomainServiceTest
    {
        [Fact]
        public void ShouldReturnString()
        {
            var subjectUnderTest = new DomainService();
            var expected = "[{\"Name\":\"Weather\",\"AvailableEndPoints\":[{\"Name\":\"alerts\",\"Uri\":\"https://api.weather.gov/alerts\",\"Default\":false},{\"Name\":\"activeAlerts\",\"Uri\":\"https://api.weather.gov/alerts/active\",\"Default\":true},{\"Name\":\"alertTypes\",\"Uri\":\"https://api.weather.gov/alerts/types\",\"Default\":false}]}]";

            var actual = subjectUnderTest.GetDomains();

            Assert.Equal(expected, actual);
        }
    }
}
