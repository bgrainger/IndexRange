## About

This package lets you use the C# 8.0 [index and range features](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#indices-and-ranges) in projects that target .NET Framework.

For projects that target `netstandard2.0` or .NET Framework 4.6.2 or later, use the [Microsoft.Bcl.Memory](https://www.nuget.org/packages/Microsoft.Bcl.Memory/) package instead. This package should be considered deprecated for those target frameworks.

This library is not necessary nor recommended when targeting versions of .NET that include the relevant support.

## Using Range with Arrays

The C# compiler needs the `RuntimeHelpers.GetSubArray<T>` method to be available to create subranges from arrays. This method is only available in `netstandard2.1` and .NET Core 3.0, so creating subranges from arrays will fail to compile in .NET Framework.

### Use Span\<T>

A workaround is to add a reference to [System.Memory](https://www.nuget.org/packages/System.Memory/) and use `Span<T>`. Not only does this compile, it's much more efficient as it doesn't create a new array and copy the sliced data to it:

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
