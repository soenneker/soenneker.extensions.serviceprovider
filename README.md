[![](https://img.shields.io/nuget/v/Soenneker.Extensions.ServiceProvider.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.ServiceProvider/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.serviceprovider/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.serviceprovider/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Extensions.ServiceProvider.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.ServiceProvider/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.serviceprovider/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.serviceprovider/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.ServiceProvider
A collection of useful IServiceProvider methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.ServiceProvider
```

## Quick start

```csharp
using Soenneker.Extensions.ServiceProvider;

// Given an existing IServiceProvider named serviceProvider:
var result = serviceProvider.Get();
```

## Common operations

- `Get()` - Retrieves a service of the specified type from the service provider. Throws an exception if the service is not registered. Returns an instance of type T obtained from the service provider.
