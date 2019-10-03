# IndexRange

This repository provides implementations (copied [from corefx](https://github.com/dotnet/corefx/tree/d152d19f0be3dcea1a32f452e9d9940e990574d7/src/Common/src/CoreLib/System))
of `System.Index` and `System.Range` for `netstandard2.0`.

This lets you use the new C# 8.0 [index and range features](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#indices-and-ranges) in projects that target
.NET Framework or `netstandard2.0`.

## Installing

[![NuGet Pre Release](https://img.shields.io/nuget/v/IndexRange.svg)](https://www.nuget.org/packages/IndexRange/)

The package is available [on NuGet](https://www.nuget.org/packages/IndexRange). To install, run:

```
dotnet add package IndexRange --version 1.0.0-beta3
```

## Build Status

[![Build Status](https://dev.azure.com/bgrainger/Public/_apis/build/status/bgrainger.IndexRange?branchName=master)](https://dev.azure.com/bgrainger/Public/_build/latest?definitionId=3&branchName=master)

## Using Range with Arrays

The C# compiler needs the `RuntimeHelpers.GetSubArray<T>` method to be available to create subranges from arrays. This method is only available in `netstandard2.1`
and .NET Core 3.0, so creating subranges from arrays will fail to compile in .NET Framework.

### Use Span\<T>

A workaround is to add a reference to [System.Memory](https://www.nuget.org/packages/System.Memory/) and use `Span<T>`. Not only does this compile, it's much more
efficient as it doesn't create a new array and copy the sliced data to it:

```csharp
int[] array = new[] { 1, 2, 3, 4, 5, 6 };

// don't do this:
// var slice = array[1..^1];

// do this:
var slice = array.AsSpan()[1..^1];
```

### Define GetSubArray\<T>

The other fix is to define the necessary method in your source code. Copy the following code into your project:

https://gist.github.com/bgrainger/fb2c18659c2cdfce494c82a8c4803360

That type is not in this NuGet package so that the C# compiler doesn't warn that `The predefined type 'RuntimeHelpers' is defined in multiple assemblies`.
