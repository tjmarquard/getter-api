namespace GetterApiTests.ControllerTests
{
    using AutoFixture;
    using GetterApi.Controllers;
    using GetterApiServices;
    using Microsoft.AspNetCore.Mvc;
    using NSubstitute;
    using Xunit;

    public class DomainControllerTest
    {
        private IDomainService domainServiceMock;
        private Fixture fixture;

        public DomainControllerTest()
        {
            domainServiceMock = Substitute.For<IDomainService>();
            fixture = new Fixture();
        }

        [Fact]
        public void ShouldReturnResultWhenGivenAValidDomain()
        {
            var expected = fixture.Create<string>();

            domainServiceMock.GetDomains().Returns(expected);
            var subjectUnderTest = new DomainController(domainServiceMock);
            var result = subjectUnderTest.Get();
            var okResult = result as OkObjectResult;

            Assert.Equal(expected, okResult.Value);
            Assert.IsType<string>(okResult.Value);
        }
    }
}
