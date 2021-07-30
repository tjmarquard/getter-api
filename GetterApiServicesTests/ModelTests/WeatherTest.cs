namespace GetterApiServicesTests.ModelTests
{
    using System.Linq;
    using AutoFixture;
    using FluentAssertions;
    using GetterApiServices.Models;
    using Xunit;

    public class WeatherTest
    {
        private readonly Fixture fixture;

        public WeatherTest()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void ShouldHaveAvailableEndpoints()
        {
            var numberOfAvailableEndpoints = Weather.AvailableEndpoints.Count();
            numberOfAvailableEndpoints.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ShouldSetDefaultEndpointsWhenGivenNoMatchingServices()
        {
            var services = fixture.CreateMany<string>().ToArray();
            var subjectUnderTest = new Weather(services);

            var isEqual = Enumerable.SequenceEqual(
                Weather.AvailableEndpoints.Where(endpoint => endpoint.Default).Select(endpoint => endpoint.Name).OrderBy(name => name),
                subjectUnderTest.SelectedEndpoints.Select(endpoint => endpoint.Name).OrderBy(name => name));

            Assert.True(isEqual);
        }

        [Fact]
        public void ShouldReturnRequestedEndpointsWhenGivenMatchingService()
        {
            var services = new string[] { "alerts" };
            var subjectUnderTest = new Weather(services);

            var isEqual = Enumerable.SequenceEqual(
                services.OrderBy(name => name),
                subjectUnderTest.SelectedEndpoints.Select(endpoint => endpoint.Name).OrderBy(name => name));

            Assert.Equal(subjectUnderTest.SelectedEndpoints.Count, services.Length);
            Assert.True(isEqual);
        }
    }
}
