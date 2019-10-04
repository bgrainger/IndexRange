# Version History

### 1.0.0-beta5

* Add `net45` and `net471` packages for broader .NET Framework support.

### 1.0.0-beta4

* Create a `netstandard2.1` package that type-forwards to `System.Index` and `System.Range`.
  * This should make it less painful to consume this package from clients that multi-target.

### 1.0.0-beta3

* Add package icon.

### 1.0.0-beta2

* Assembly is now strong-named: [#1](https://github.com/bgrainger/IndexRange/issues/1).

### 1.0.0-beta1

* Initial release of `System.Index` and `System.Range`.
