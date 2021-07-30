namespace GetterApiTests.ControllerTests
{
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using AutoFixture;
    using GetterApi.Controllers;
    using GetterApiServices;
    using Microsoft.AspNetCore.Mvc;
    using NSubstitute;
    using Xunit;

    public class WeatherControllerTest
    {
        private readonly IWeatherService weatherServiceMock;
        private readonly Fixture fixture;

        public WeatherControllerTest()
        {
            weatherServiceMock = Substitute.For<IWeatherService>();
            fixture = new Fixture();
        }

        [Fact]
        public async Task ShouldReturnOkResponse()
        {
            var subjectUnderTest = new WeatherController(weatherServiceMock);
            var services = fixture.CreateMany<string>().ToArray();
            var responseMock = fixture.Create<string>();

            weatherServiceMock.GetEndpoints(Arg.Any<string[]>()).Returns(responseMock);

            var result = await subjectUnderTest.Get(services);
            var okResult = result as OkObjectResult;

            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task ShouldReturnReponseFromService()
        {
            var subjectUnderTest = new WeatherController(weatherServiceMock);
            var services = fixture.CreateMany<string>().ToArray();
            var expected = fixture.Create<string>();

            weatherServiceMock.GetEndpoints(Arg.Any<string[]>()).Returns(expected);

            var result = await subjectUnderTest.Get(services);
            var okResult = result as OkObjectResult;

            Assert.Equal(expected, okResult.Value);
            Assert.IsType<string>(okResult.Value);
        }
    }
}
