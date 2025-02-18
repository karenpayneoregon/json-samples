# About

This project demonstrates how to use the NuGet package [ConsoleConfigurationLibrary](https://www.nuget.org/packages/ConsoleConfigurationLibrary/1.0.0.8?_src=template) to read a connection string from appsettings.json and property to determine if the database needs to be recreated.

Using the provided NuGet package in each project makes maintenance easy and consistent across desktop projects, such as Console and WPF.

## Setup

Add ConsoleConfigurationLibrary package to a project.

Call `SetupServices.Setup` in the `Main` method of the project.

```csharp
internal partial class Program
{
    static async Task Main(string[] args)
    {
        await SetupServices.Setup();
```

## Usage

Access main connection string

```csharp
AppConnections.Instance.MainConnection
```

Access property to determine if the database needs to be recreated
```csharp
EntitySettings.Instance.CreateNew
```
