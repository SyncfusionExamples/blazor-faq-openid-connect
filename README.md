# Blazor OpenID Connect Authentication

## Overview

This sample demonstrates how to implement OpenID Connect (OIDC) authentication in a Blazor application. The project shows how authentication is configured, how users sign in through an external identity provider, and how authenticated access is managed within the application. This scenario is commonly used when integrating enterprise identity systems and securing application resources through standardized authentication protocols. The repository is focused on Blazor authentication concepts and OpenID Connect integration. 

## Key Features

- Uses the `AuthorizeView` component to conditionally render content based on the user's authentication state.
- Displays the authenticated user's identity through `@context.User.Identity.Name` within the `Authorized` template.
- Shows alternative content through the `NotAuthorized` template when a user is not authenticated.
- Implements OpenID Connect (OIDC) authentication using `HttpContext.ChallengeAsync()` in `Pages/Login.cshtml.cs`.
- Initiates the OIDC sign-in flow with the `"oidc"` authentication scheme.
- Preserves the requested return location after successful authentication using `AuthenticationProperties.RedirectUri`.
- Provides a dedicated login endpoint through the Razor Page `Pages/Login.cshtml`.
- Implements user sign-out functionality using `HttpContext.SignOutAsync()` in `Pages/Logout.cshtml.cs`.
- Redirects users to the application's home page after logout using `Redirect("/")`.
- Demonstrates integration between Blazor authorization components and ASP.NET Core authentication middleware.
- Shows a complete authentication lifecycle including sign-in, authenticated content rendering, authorization checks, and sign-out.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) compatible with the project's target framework

## How to Run the Project

**Visual Studio 2022**

1. Clone the repository to your local machine.
2. Open `BlazorOidcAuthentication.sln`.
3. Restore NuGet packages.
4. Verify and update OpenID Connect configuration values if required.
5. Build the solution.
6. Run the application using `Ctrl+F5`.

**Visual Studio Code**

1. Clone the repository.
2. Open the repository folder in Visual Studio Code.
3. Navigate to the project directory.

```bash
dotnet restore
dotnet run
```

4. Open the application in a browser using the URL displayed in the console output.

## Project Structure

- `Program.cs` - Configures application services, authentication, authorization, and OpenID Connect integration.
- `Pages/Index.razor` - Home page that uses `AuthorizeView` to display authenticated user information and unauthorized content.
- `Pages/Login.cshtml` - Razor Page endpoint that initiates the OpenID Connect sign-in process.
- `Pages/Login.cshtml.cs` - Contains the `LoginModel` class and calls `HttpContext.ChallengeAsync()` using the `"oidc"` authentication scheme.
- `Pages/Logout.cshtml` - Razor Page endpoint used for user sign-out.
- `Pages/Logout.cshtml.cs` - Contains the `LogoutModel` class and signs out authenticated users through `HttpContext.SignOutAsync()`.
- `wwwroot/` - Static web assets such as stylesheets, scripts, and images.

## Support and Feedback

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- official Blazor documentation : https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app

## License

This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.