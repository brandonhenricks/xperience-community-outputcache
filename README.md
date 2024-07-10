```markdown
# XperienceCommunity.OutputCache

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Build Status](https://github.com/XperienceCommunity/OutputCache/actions/workflows/build.yml/badge.svg)](https://github.com/XperienceCommunity/OutputCache/actions)

## Overview

**XperienceCommunity.OutputCache** is a .NET library designed to integrate Xperience by Kentico with .NET 7 / 8 output caching. This library enables efficient cache invalidation triggered by content updates within the Kentico CMS, ensuring that your application's content remains up-to-date without compromising on performance.

## Features

- **Seamless Integration**: Easily integrates Xperience by Kentico with .NET 7 / 8 output cache.
- **Cache Invalidation**: Automatically invalidates cached content when updates are made to pages within Kentico.
- **High Performance**: Optimized for high performance, leveraging .NET's advanced caching mechanisms.

## Getting Started

### Prerequisites

- .NET 7 or 8
- Xperience by Kentico

### Installation

You can install the package via NuGet:

```bash
dotnet add package XperienceCommunity.OutputCache
```

Or via the NuGet Package Manager in Visual Studio:

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
        
        // Other service registrations...
    }
    ```

2. **Configure the middleware**: Ensure the middleware is configured in your request pipeline.

    ```csharp
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        // Use Xperience Output Cache middleware
        app.UseXperienceOutputCache();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
    ```

### Usage

The library will automatically handle caching and invalidation based on updates within Xperience by Kentico. For advanced configuration and customization, refer to the [documentation](docs/Configuration.md).

## Contributing

Contributions are welcome! Please read the [contributing guidelines](CONTRIBUTING.md) for more details.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

Special thanks to the Xperience by Kentico community for their support and contributions.

## Contact

For further information, issues, or support, please open an issue on the [GitHub repository](https://github.com/XperienceCommunity/OutputCache/issues).

```
