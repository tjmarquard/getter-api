namespace GetterApiServicesTests
{
    using System.Linq;
    using AutoFixture;
    using GetterApiServices;
    using Xunit;

    public class QueryServiceTest
    {
        private Fixture fixture;

        public QueryServiceTest()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void ShouldReturnString()
        {
            var subjectUnderTest = new QueryService();
            var services = fixture.CreateMany<string>().ToArray();
            var expected = "empty";

            var actual = subjectUnderTest.GetWeatherApiEndPoints(services);

            Assert.Equal(expected, actual);
        }
    }
}
