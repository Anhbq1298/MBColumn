# Reference Source Notes

## Overview

The `_ref/spColumn_Source` folder contains a decompiled export of the StructurePoint `spColumn.exe` .NET desktop application. The `_ref/spColumn_App` folder contains the original application binaries for reference. These were used as behavioral references during development of MBColumn to understand general user-facing workflow expectations and diagram behavior. The MBColumn implementation in `src/` is independently written using public structural engineering theory.

The decompiled source is not buildable. The project metadata has been inspected and the startup object identified, but source-level syntax damage from obfuscated identifiers prevents compilation.

## Application type and framework

- Application type: WPF desktop application.
- Target framework: .NET Framework 4.8.
- Project style: legacy MSBuild/C# project, Visual Studio 2019 solution format.
- UI stack: WPF with Telerik controls, generated `IComponentConnector` classes, compiled resources, and no recovered `.xaml` source files in the current export.

## Entry point and startup flow

Current compiler entry point:

- `StructurePoint.Products.Column.App.Main(string[] args)`

Startup behavior:

1. Rejects unsupported command-line usage through `CommandlineParametersParser`.
2. Creates `App`.
3. Calls `InitializeComponent()`.
4. Calls the existing `#Llf.#eb(false)` initialization hook.
5. Runs the WPF application.
6. Calls `#Llf.#db()` in a `finally` block.

Application startup then flows through:

1. `App.OnStartup(StartupEventArgs e)`
2. `App.Configure()`
3. `ColumnApplicationStartupHandler.#UQb(...)`
4. `#SQb` dependency registration
5. `MainWindow` and related WPF views/view models

## Main modules/classes and responsibilities

- `StructurePoint.Products.Column.App`: WPF application object, startup configuration, global exception handling, and process shutdown behavior.
- `StructurePoint.Products.Column.Core.Application.ColumnApplicationStartupHandler`: logging setup, splash/load flow, DI bootstrap, and optional project-file open on startup.
- `#wQb.#SQb`: dependency registration/root composition for application services, views, view models, editor modules, reporting modules, ETABS import, settings, and validators.
- `StructurePoint.Products.Column.Views.MainWindow`: main Telerik ribbon window, docking panes, drag/drop, validation event routing, initialization progress animation, and application shutdown trigger.
- `StructurePoint.Products.Column.Editor.*`: editor/project/section workflows.
- `StructurePoint.Products.Column.FailureSurface.*`: failure-surface visualization, diagrams, and related UI.
- `StructurePoint.Products.Column.ViewModels.*`: WPF view models for definitions, loads, settings, slenderness, solver, status bar, reporting, and ETABS import.
- `StructurePoint.CoreAssets.AppManager.Column.*`: column storage model, validation, reporting, engineering/runtime model, templates, diagrams, and storage.
- `StructurePoint.CoreAssets.GUI.*`: shared WPF GUI framework, desktop controls, reporter UI, docking, model editor, 2D/3D visualization, and common controls.

## Dependency list

Declared project references include:

- WPF/framework: `PresentationCore`, `PresentationFramework`, `WindowsBase`, `WindowsFormsIntegration`, `System.Xaml`, `System.Windows.Forms`.
- UI/vendor: Telerik WPF controls/documents/themes, Ab2d, Ab3d, HelixToolkit, devDept Eyeshot.
- Data/reporting: Aspose.Words, ClosedXML, CsvHelper, PdfSharp, Newtonsoft.Json, Svg.
- Geometry/CAD: netDxf, NetTopologySuite, Triangle, clipper_library, Microsoft.SqlServer.Types.
- Infrastructure: SimpleInjector, log4net, FluentValidation, FluentCommandLineParser, Jint, AlphaFS, Vanara P/Invoke.
- Product/local assemblies: `spGUI.Assets`, `spLocalizer`, `VMDetector`, `ETABSv1`.
- Native/runtime files present in the adjacent binary folder include `lsapiw32.dll`, `lsapiw64.dll`, and other transitive DLLs.

All declared HintPath references in the decompiled source originally resolved to a neighboring `spColumn` folder (now available locally in `_ref/spColumn_App`).

## Data/UI/service flow

The reference application is a desktop engineering/design tool for column workflows. The main UI is a Telerik ribbon window with docked editor and diagram surfaces. The dependency resolver wires project management, storage, settings, validation, editor services, reporting, diagrams, templates, load/slenderness/section views, ETABS import, and solver window services.

Settings are loaded from XML-backed settings providers under the user's application data folder. Project/input storage uses XML schemas and storage providers in `StructurePoint.CoreAssets.Storage` and `StructurePoint.CoreAssets.AppManager.Column.Storage`.

## Known decompiler artifacts

- Invalid C# identifiers such as `#wQb`, `#vQb`, `#uQb`, `#50c`, and many `#...` namespaces/classes/members.
- Nonstandard file and directory names, including control-character-looking names and duplicate suffixes such as `.2.cs`.
- Generated WPF code exists as C# `IComponentConnector` classes, but original XAML source files are not present.
- Compiled resources are present as `.resources`, GUID-named embedded files, `.licenses`, and `.settings`, rather than clean source resource trees.
- Compiler-generated state and connector code is mixed with business code.
- Obfuscated string/resource accessors such as `#Phc.#3hc(...)`.
- Original project metadata had `OutputType=Module` even though the project has a WPF startup path.

## Build status

The decompiled source is not buildable. The project fails during C# parsing because the decompiler export contains invalid C# identifiers. Representative errors include `CS1040`, `CS1041`, `CS1001`, and related syntax errors in files such as `#00c\#50c.cs`, `#5Fd\#sHd.cs`, and `#A9d\#kae.cs`.

No license checks, authentication, activation, encryption, DRM, trial limits, security controls, or anti-tamper logic were examined or documented beyond what is needed to understand general application structure.
