# Build Notes

## What compiles

- Project restore phase completes; there are no NuGet packages to restore.
- Project metadata now advances past the previous `CS2017` startup/module error.
- Declared HintPath references in `spColumn.exe.csproj` resolve to the adjacent `..\spColumn` binary folder.
- The standalone PMM smoke project at `tools\PmmChartSmoke\PmmChartSmoke.csproj` builds successfully.

## What does not compile

The project currently fails during C# parsing because the decompiler export contains invalid C# identifiers. The most visible pattern is `#...` names in namespaces, types, members, locals, and file paths.

Representative first errors from `dotnet build spColumn.sln --no-restore -v:minimal`:

```text
#00c\#50c.cs(4,7): error CS1040: Preprocessor directives must appear as the first non-whitespace character on a line
#00c\#50c.cs(5,1): error CS1041: Identifier expected; 'using' is a keyword
#5Fd\#sHd.cs(6,7): error CS1040: Preprocessor directives must appear as the first non-whitespace character on a line
#A9d\#kae.cs(5,11): error CS1040: Preprocessor directives must appear as the first non-whitespace character on a line
```

The compiler stops in the syntax-error layer, so missing type/member/reference errors have not yet been reached.

## Missing dependencies

No declared HintPath reference is currently missing.

Important runtime/transitive dependencies are present in `..\spColumn`, including vendor WPF/3D/reporting assemblies, product-local assemblies, and native licensing/runtime DLLs.

## Manual steps required

1. Generate a stable symbol map for invalid decompiled names.
2. Apply conservative mechanical sanitization to invalid identifiers and matching filenames/project includes.
3. Rebuild and address the next compiler layer.
4. Recover or document WPF XAML/BAML resources.
5. Verify that licensing, activation, encryption, VM detection, and related protection/runtime code remains functionally unchanged.
6. Add smoke tests only after compileable pure services can be isolated.

## PMM smoke fixture

A standalone PMM exploration project was added at `tools\PmmChartSmoke`. It models a 700 mm x 700 mm square column with 28-D25 bars equally spaced around the perimeter and produces CSV, OBJ, control-point CSV, and HTML chart outputs.

The smoke generator ran successfully through the built DLL:

```text
Surface points: 2520 (70 axial/depth rows x 36 angles)
P range: -5772.7 to 16974.0 kN
Mx range: -2179.4 to 2179.4 kN-m
My range: -2179.4 to 2179.4 kN-m
```

The HTML output now uses a reference-style two-chart layout:

- `PM at 0.0 [deg]`
- `MM at P=0.0 [kN]`

It draws red dashed nominal curves, blue solid factored curves, Pmax/Pmin guide lines on the PM chart, and includes an `Export control points CSV` button.

`dotnet run --project tools\PmmChartSmoke\PmmChartSmoke.csproj` attempted NuGet repository signature lookup in this environment and failed with `NU1301`, even though the project has no package dependencies. Use `dotnet tools\PmmChartSmoke\bin\Debug\net8.0\PmmChartSmoke.dll` after building to avoid that restore path.

## Assumptions made

- The nearest behavioral entry point is the obfuscated wrapper that performs command-line validation and `#Llf` setup/cleanup.
- Moving that wrapper behavior into `App.Main(string[] args)` preserves startup behavior while giving MSBuild a compiler-valid startup object.
- The application should build as a WPF `WinExe`, not as a module.
- The current repository contains the decompiled reference source alongside the independently developed `src/` application.
