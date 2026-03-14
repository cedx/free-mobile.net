# Installation

## Requirements
Before installing **Free Mobile for .NET**, you need to make sure you have the [.NET SDK](https://learn.microsoft.com/en-us/dotnet/core/sdk)
and/or [PowerShell](https://learn.microsoft.com/en-us/powershell) up and running.
		
You can verify if you're already good to go with the following commands:

```shell
dotnet --version
# 10.0.200

pwsh --version
# PowerShell 7.5.5
```

## Installing the .NET library with NuGet package manager

### 1. Install it
From a command prompt, run:

```shell
dotnet add package Belin.FreeMobile
```

### 2. Import it
Now in your [C#](https://learn.microsoft.com/en-us/dotnet/csharp) code, you can use:

```cs
using Belin.FreeMobile;
```

## Installing the PowerShell module with PSResourceGet package manager

### 1. Install it
From a command prompt, run:

```pwsh
Install-PSResource -Name FreeMobile -Repository PSGallery
```

### 2. Import it
Now in your [PowerShell](https://learn.microsoft.com/en-us/powershell) code, you can use:

```pwsh
Import-Module -Name FreeMobile
```
