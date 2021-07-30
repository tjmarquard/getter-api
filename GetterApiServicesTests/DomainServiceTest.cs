namespace GetterApiServicesTests
{
    using System.Linq;
    using AutoFixture;
    using GetterApiServices;
    using Xunit;

    public class DomainServiceTest
    {
        private Fixture fixture;

        public DomainServiceTest()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void ShouldReturnString()
        {
            var subjectUnderTest = new DomainService();
            var expected = "empty";

            var actual = subjectUnderTest.GetDomains();

            Assert.Equal(expected, actual);
        }
    }
}
