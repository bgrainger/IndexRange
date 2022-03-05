// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System;

public static class AssertExtensions
{
    public static T Throws<T>(string expectedParamName, Func<object> testCode)
        where T : ArgumentException
    {
        T exception = Assert.Throws<T>(testCode);

        Assert.Equal(expectedParamName, exception.ParamName);

        return exception;
    }
}
