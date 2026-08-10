This is Box3D-CS, C# bindings for the Box3D physics engine.

License
-------
Box3D and Box3D-CS are released under the MIT license. See LICENSE for details.

About Box3D
----------
For more information about Box3D, visit the Box3D repository:

https://github.com/erincatto/box3d

About the interop bindings
---------------------
The bindings are auto-generated from the GenerateBindings subproject.
The generator depends on JSON output from the c2ffi project: https://github.com/rpav/c2ffi

box3d.Core.cs contains CoreCLR-specific bindings that will only work with .NET 8+. 

The headers themselves do not provide enough information to generate complete interop bindings.
If you update the bindings, search "WARN_" in generated files for unhandled definitions or those that require manual intervention.

About the idiomatic bindings
---
Box3D-CS.csproj provides structures that wrap the interop bindings in idiomatic C#. These are currently a work-in-progress and contributions are welcome!
