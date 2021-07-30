namespace GetterApiTests.ControllerTests
{
    using System.Linq;
    using AutoFixture;
    using GetterApiServices;
    using global::GetterApi.Controllers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NSubstitute;
    using Xunit;

    public class QueryControllerTest
    {
        private IQueryService _queryServiceMock;
        private Fixture _fixture;
        private readonly string _weatherDomain = "weather";
        private readonly string _notImplementedDomain = "notImplemented";

        public QueryControllerTest()
        {
            _queryServiceMock = Substitute.For<IQueryService>();
            _fixture = new Fixture();
        }


        [Fact]
        public async void ShouldReturnResultWhenGivenAValidDomain()
        {
            var services = _fixture.CreateMany<string>().ToArray();
            var expected = _fixture.Create<string>();

            _queryServiceMock.GetWeatherApiEndPoints(Arg.Any<string[]>()).Returns(expected);
            var subjectUnderTest = new QueryController(_queryServiceMock);
            var result = await subjectUnderTest.Get(_weatherDomain, services);
            var okResult = result as OkObjectResult;

            Assert.Equal(expected, okResult.Value);
            Assert.IsType<string>(okResult.Value);
        }

        [Fact]
        public async void ShouldReturnBadRequestWhenGivenAnInvalidDomain()
        {
            var services = _fixture.CreateMany<string>().ToArray();
            var expected = _fixture.Create<string>();

            var subjectUnderTest = new QueryController(_queryServiceMock);
            var result = await subjectUnderTest.Get(_notImplementedDomain, services);
            var badRequestResult = result as BadRequestResult;

            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.IsType<BadRequestResult>(badRequestResult);
        }
    }
}
