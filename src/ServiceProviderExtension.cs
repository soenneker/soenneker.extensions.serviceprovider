using System;
using Microsoft.Extensions.DependencyInjection;

namespace Soenneker.Extensions.ServiceProvider;

/// <summary>
/// A collection of useful IServiceProvider methods
/// </summary>
public static class ServiceProviderExtension
{
    /// <summary>
    /// Wraps <see cref="IServiceProvider.GetService"/> with null forgiving operand... <para/>
    /// Microsoft.Extensions.DependencyInjection namespace isn't correctly auto detected in Visual Studio...
    /// </summary>
    public static T Get<T>(this IServiceProvider serviceProvider)
    {
        var service = serviceProvider.GetService<T>();

        if (service == null)
        {
            throw new NullReferenceException($@"Service ({typeof(T).Name}) is not currently registered on the provider.
                1. Check to see if the service is registered
                2. Verify the collection on the test class is correct
                3. Verify the constructor has the correct fixture
                4. Verify the base class is using the correct Startup ('IntegrationTest<Startup>')
                5. Verify the factory on the base constructor is correct");
        }

        return service;
    }
}