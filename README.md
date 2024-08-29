# XperienceCommunity.OutputCache

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Build Status](https://github.com/brandonhenricks/xperience-community-outputcache/actions/workflows/dotnet.yml/badge.svg)](https://github.com/brandonhenricks/xperience-community-outputcache/actions)

## Overview

**XperienceCommunity.OutputCache** is a .NET library designed to seamlessly integrate output caching with Xperience by Kentico, supporting .NET 7 / 8. This library facilitates efficient cache invalidation, triggered by content updates within the Kentico CMS, ensuring that your application's content remains fresh and up-to-date without compromising on performance. Output caching can significantly improve the responsiveness of your web applications by storing the rendered output of pages, reducing the need for repeated processing of requests for the same content.

### Why Use Output Caching?

- **Improved Performance**: Reduces server load and response times by serving content from the cache.
- **Dynamic Content Updates**: Ensures users see the most current content without manual cache clearing, thanks to automatic invalidation.

## Features

- **Seamless Integration**: Easily integrates with .NET 7 / 8 output cache, enhancing your Kentico Xperience projects.
- **Cache Invalidation**: Automatically invalidates cached content upon updates to pages within Kentico, ensuring content freshness.
- **High Performance**: Leverages .NET's advanced caching mechanisms for optimal performance.

## Getting Started

### Prerequisites

- .NET 7 or 8 installed on your development machine.
- An existing project with Xperience by Kentico (28.2.0 or higher).

### Installation

To integrate **XperienceCommunity.OutputCache** into your project, follow these steps:

#### Via NuGet Package Manager Console

Open the NuGet Package Manager Console in Visual Studio and run:


```powershell
Install-Package XperienceCommunity.OutputCache
```

### Configuration

1. **Register the services**: Add the necessary services to your application's `Startup.cs` or `Program.cs`.

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        
        // Add Xperience Output Cache services
        services.AddXperienceOutputCache();
        
        // Other Xperience Output Cache Policy.
        services.AddOutputCache(options =>
        {
            options.AddXperienceOutputCachePolicy("KenticoPolicy", TimeSpan.FromMinutes(5));
        });        
    }
    ```

2. **Configure the middleware**: Ensure the middleware is configured in your request pipeline.

    ```csharp
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Use Output Cache middleware
        app.UseOutputCache();
    }
    ```

### Usage
Output caching is now enabled for your application. The library will automatically handle caching and invalidation based on updates within Xperience by Kentico.
To add output caching to your views, use the `OutputCache` attribute on your controller actions:

```csharp
[OutputCache(PolicyName = "KenticoPolicy")]
public async Task<IActionResult> Index()
{
    return View();
}
```

### Helper Methods:

The library includes the AddDependencyKeys() extension method for use with HttpContext. This method is intended for use on controllers and view components to enhance cache dependency management, ensuring more precise and efficient cache invalidation.

## Built With

* [Xperience By Kentico](https://www.kentico.com) - Kentico Xperience
* [NuGet](https://nuget.org/) - Dependency Management

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/brandonhenricks/xperience-community-health-checks/tags). 

## Authors

* **Brandon Henricks** - *Initial work* - [Brandon Henricks](https://github.com/brandonhenricks)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
