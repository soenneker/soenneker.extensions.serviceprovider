using System;
using AwesomeAssertions;
using Moq;
using Soenneker.Extensions.ServiceProvider.Tests.Abstract;
using Xunit;

namespace Soenneker.Extensions.ServiceProvider.Tests;

public class ServiceProviderExtensionTests
{
    [Fact]
    public void Get_ShouldReturnService_WhenServiceIsRegistered()
    {
        // Arrange
        var serviceMock = new Mock<IService>();
        var serviceProviderMock = new Mock<IServiceProvider>();
        serviceProviderMock.Setup(sp => sp.GetService(typeof(IService))).Returns(serviceMock.Object);

        // Act
        var result = serviceProviderMock.Object.Get<IService>();

        // Assert
        result.Should().NotBeNull()
            .And.BeAssignableTo<IService>();
    }

    [Fact]
    public void Get_ShouldThrowException_WhenServiceIsNotRegistered()
    {
        // Arrange
        var serviceProviderMock = new Mock<IServiceProvider>();
        serviceProviderMock.Setup(sp => sp.GetService(typeof(IService))).Returns(null);

        // Act
        Action act = () => serviceProviderMock.Object.Get<IService>();

        // Assert
        act.Should()
           .Throw<InvalidOperationException>();
    }
}