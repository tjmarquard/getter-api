namespace GetterApiTests.Models
{
    using System.Linq;
    using AutoFixture;
    using FluentAssertions;
    using GetterApiServices.Models;
    using Xunit;

    public class WeatherTest
    {
        private Fixture fixture;

        public WeatherTest()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void ShouldHaveAvailableEndPoints()
        {
            var numberOfAvailableEndPoints = Weather.AvailableEndPoints.Count();
            numberOfAvailableEndPoints.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ShouldSetDefaultEndPointsWhenGivenNoMatchingServices()
        {
            var services = fixture.CreateMany<string>().ToArray();
            var subjectUnderTest = new Weather(services);

            var isEqual = Enumerable.SequenceEqual(
                Weather.AvailableEndPoints.Where(endpoint => endpoint.Default).Select(endpoint => endpoint.Name).OrderBy(name => name),
                subjectUnderTest.SelectedEndPoints.Select(endpoint => endpoint.Name).OrderBy(name => name));

            Assert.True(isEqual);
        }

        [Fact]
        public void ShouldReturnRequestedEndPointsWhenGivenMatchingService()
        {
            var services = new string[] { "alerts" };
            var subjectUnderTest = new Weather(services);

            var isEqual = Enumerable.SequenceEqual(
                services.OrderBy(name => name),
                subjectUnderTest.SelectedEndPoints.Select(endpoint => endpoint.Name).OrderBy(name => name));

            Assert.Equal(subjectUnderTest.SelectedEndPoints.Count, services.Length);
            Assert.True(isEqual);
        }
    }
}
