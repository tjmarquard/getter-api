namespace GetterApiServicesTests
{
    using AutoFixture;
    using FluentAssertions;
    using GetterApiServices;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public class WeatherServiceTest
    {
        private Fixture fixture;

        public WeatherServiceTest()
        {
            Fixture = new Fixture();
        }

        public Fixture Fixture { get => fixture; set => fixture = value; }

        [Fact]
        public async Task GetEndpointsShouldReturnDefaultEndpFointJsonStringWhenGivenInvalidEndpoints()
        {
            var services = Fixture.CreateMany<string>().ToArray();
            var httpClient = new HttpClient();

            var subjectUnderTest = new WeatherService(httpClient);
            var response = await subjectUnderTest.GetEndpoints(services);

            response.Should().NotBeNull();
        }

        [Fact]
        public async Task GetEndpointsShouldReturnMultipleEndpointJsonStringWhenGivenValidEndpoints()
        {
            var services = new string[] { "alerts", "activeAlerts"};
            var httpClient = new HttpClient();

            var subjectUnderTest = new WeatherService(httpClient);
            var response = await subjectUnderTest.GetEndpoints(services);

            response.Should().NotBeNull();
        }
    }
}
