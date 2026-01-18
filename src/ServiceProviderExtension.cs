using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.ServiceProvider;

/// <summary>
/// A collection of useful IServiceProvider methods
/// </summary>
public static class ServiceProviderExtension
{
    private const string _notRegistered =
        "Service is not currently registered on the provider.\n" +
        "1. Check to see if the service is registered\n" +
        "2. Verify the collection on the test class is correct\n" +
        "3. Verify the constructor has the correct fixture\n" +
        "4. Verify the base class is using the correct Startup ('IntegrationTest<Startup>')\n" +
        "5. Verify the factory on the base constructor is correct";

    /// <summary>
    /// Retrieves a service of the specified type from the service provider. Throws an exception if the service is not
    /// registered.
    /// </summary>
    /// <remarks>Use this method to obtain required services from an IServiceProvider instance. If the
    /// requested service type is not registered, an exception is thrown instead of returning null. This method is
    /// intended for scenarios where the service is expected to be available.</remarks>
    /// <typeparam name="T">The type of service to retrieve. Must be a non-nullable reference or value type.</typeparam>
    /// <param name="serviceProvider">The service provider from which to retrieve the service. Cannot be null.</param>
    /// <returns>An instance of type T obtained from the service provider.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Get<T>(this IServiceProvider serviceProvider) where T : notnull
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        object? obj = serviceProvider.GetService(typeof(T));

        if (obj is T typed)
            return typed;

        ThrowNotRegistered<T>();
        return default!; // unreachable
    }

    [DoesNotReturn]
    private static void ThrowNotRegistered<T>()
    => throw new InvalidOperationException($"Service ({typeof(T).FullName}) {_notRegistered}");
}