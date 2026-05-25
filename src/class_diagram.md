# Project Class Diagram & Overview

This document provides an overview of the classes, interfaces, records, and enums in the MBColumn project.

## MBColumn.Application

### DTOs

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ReportVerificationPointRow** | Data structure representing a row for ReportVerificationPoint. Key properties: StrainDescription, Note, PointCode. | `ReportVerificationPointRow.cs` |
| `enum` | **ControlPointThetaSelectionMode** | Enumeration defining states/types for ControlPointThetaSelectionMode. Key properties: ThetaDeg, NeutralAxisDepth, IntegrationMethod. | `ControlPointExportRow.cs` |
| `enum` | **IrregularRebarModeType** | Enumeration defining states/types for IrregularRebarModeType. | `IrregularRebarModeType.cs` |
| `enum` | **RebarLayoutType** | Enumeration defining states/types for RebarLayoutType. | `RebarLayoutType.cs` |
| `enum` | **ValidationSeverity** | Enumeration defining states/types for ValidationSeverity. | `ValidationIssue.cs` |
| `record` | **CalculationResultDto** | Data transfer object carrying CalculationResult data. Key properties: SevenPointValidationRows, CirclePolygonSegmentCount, SectionHeightMm. | `CalculationResultDto.cs` |
| `record` | **CapacityDebugPointDto** | Data transfer object carrying CapacityDebugPoint data. | `CapacityDebugPointDto.cs` |
| `record` | **ChartReferenceLineDto** | Data transfer object carrying ChartReferenceLine data. | `ChartReferenceLineDto.cs` |
| `record` | **ColumnInputDto** | Data transfer object carrying ColumnInput data. Key properties: Ec2Solver, RebarLayoutType, AlphaCc. | `ColumnInputDto.cs` |
| `record` | **ControlPointDto** | Data transfer object carrying ControlPoint data. Key properties: IsSpecialPoint. | `ControlPointDto.cs` |
| `record` | **ControlPointExportRow** | Data structure representing a row for ControlPointExport. Key properties: ThetaDeg, NeutralAxisDepth, IntegrationMethod. | `ControlPointExportRow.cs` |
| `record` | **ControlPointPreviewResult** | Represents the ControlPointPreviewResult component. | `ControlPointExportRow.cs` |
| `record` | **ControlPointTableDto** | Data transfer object carrying ControlPointTable data. | `ControlPointTableDto.cs` |
| `record` | **ControlPointTableRowDto** | Data transfer object carrying ControlPointTableRow data. | `ControlPointTableDto.cs` |
| `record` | **ControlPointValidationRow** | Represents the ControlPointValidationRow component. | `ControlPointValidationRow.cs` |
| `record` | **DiagramDataDto** | Data transfer object carrying DiagramData data. | `DiagramDataDto.cs` |
| `record` | **HandCalcValidationReport** | Represents the HandCalcValidationReport record. Key methods: NotSupported. Key properties: ComparisonNote. | `HandCalcValidationReport.cs` |
| `record` | **InsetLineDto** | Data transfer object carrying InsetLine data. | `PmChartInsetFigureDto.cs` |
| `record` | **InsetPointDto** | Data transfer object carrying InsetPoint data. | `PmChartInsetFigureDto.cs` |
| `record` | **IrregularBoundaryPointDto** | Data transfer object carrying IrregularBoundaryPoint data. | `IrregularBoundaryPointDto.cs` |
| `record` | **IrregularRebarCoordinateDto** | Data transfer object carrying IrregularRebarCoordinate data. | `IrregularRebarCoordinateDto.cs` |
| `record` | **IrregularRebarInputDto** | Data transfer object carrying IrregularRebarInput data. | `IrregularRebarInputDto.cs` |
| `record` | **IrregularSectionInputDto** | Data transfer object carrying IrregularSectionInput data. | `IrregularSectionInputDto.cs` |
| `record` | **IrregularSectionValidationResult** | Encapsulates the result of IrregularSectionValidation operations. Key methods: Errors. | `IrregularSectionValidationResult.cs` |
| `record` | **LoadCaseDto** | Data transfer object carrying LoadCase data. | `LoadCaseDto.cs` |
| `record` | **LoadCaseResultDto** | Data transfer object carrying LoadCaseResult data. Key properties: CapacityMxDisplay, CapacityMyDisplay, CapacityPDisplay. | `LoadCaseResultDto.cs` |
| `record` | **MmDiagramDto** | Data transfer object carrying MmDiagram data. | `MmDiagramDto.cs` |
| `record` | **MxMyDiagramDto** | Data transfer object carrying MxMyDiagram data. | `MxMyDiagramDto.cs` |
| `record` | **PmAngleDiagramDto** | Data transfer object carrying PmAngleDiagram data. Key properties: NominalCapacityPoints, SpecialCapacityPoints, ReducedCapacityPoints. | `PmAngleDiagramDto.cs` |
| `record` | **PmChartInsetFigureDto** | Data transfer object carrying PmChartInsetFigure data. | `PmChartInsetFigureDto.cs` |
| `record` | **PmChartInsetSelectedStateDto** | Data transfer object carrying PmChartInsetSelectedState data. | `PmChartInsetFigureDto.cs` |
| `record` | **PmDiagramDto** | Data transfer object carrying PmDiagram data. | `PmDiagramDto.cs` |
| `record` | **PmValidationReportDto** | Data transfer object carrying PmValidationReport data. | `PmValidationReportDto.cs` |
| `record` | **PmmSurfaceDto** | Data transfer object carrying PmmSurface data. Key properties: SpecialCapacityPoints. | `PmmSurfaceDto.cs` |
| `record` | **RebarCoordinateDto** | Data transfer object carrying RebarCoordinate data. | `RebarCoordinateDto.cs` |
| `record` | **RebarLayoutInputDto** | Data transfer object carrying RebarLayoutInput data. | `RebarLayoutInputDto.cs` |
| `record` | **RebarSideInputDto** | Data transfer object carrying RebarSideInput data. | `RebarSideInputDto.cs` |
| `record` | **ReportFormulaBlock** | Represents the ReportFormulaBlock component. | `ReportFormulaBlock.cs` |
| `record` | **SevenPointValidationRowDto** | Data transfer object carrying SevenPointValidationRow data. | `SevenPointValidationRowDto.cs` |
| `record` | **ValidationIssue** | Represents the ValidationIssue component. | `ValidationIssue.cs` |
| `record` | **ValidationResultDto** | Data transfer object carrying ValidationResult data. | `ValidationResultDto.cs` |

### DTOs/Etabs

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **EtabsBindingValidationResult** | Encapsulates the result of EtabsBindingValidation operations. Key properties: CurrentModelName, ObjectKey, ModelChanged. | `EtabsBindingValidationResult.cs` |
| `class` | **EtabsColumnObjectKey** | Represents the EtabsColumnObjectKey class. Key properties: UniqueName, X, Story. | `EtabsColumnObjectKey.cs` |
| `class` | **EtabsDesignForceRecord** | Represents the EtabsDesignForceRecord class. | `EtabsDesignForceRecord.cs` |
| `class` | **EtabsDesignForceTable** | Represents the EtabsDesignForceTable class. Key properties: TableVersion. | `EtabsDesignForceTable.cs` |
| `class` | **EtabsForceRefreshPreview** | Represents the EtabsForceRefreshPreview class. Key properties: AddedRows, RemapRequired, MissingObjects. | `EtabsForceRefreshPreview.cs` |
| `class` | **EtabsForceRefreshRequest** | Represents the EtabsForceRefreshRequest class. Key properties: ImportBottom, RefreshAllSections, SelectedLoadCombinations. | `EtabsForceRefreshRequest.cs` |
| `class` | **EtabsForceRowChange** | Represents the EtabsForceRowChange class. Key properties: Status, Location, LoadCaseName. | `EtabsForceRowChange.cs` |
| `class` | **EtabsImportMetadataDto** | Data transfer object carrying EtabsImportMetadata data. Key properties: PierName, OpeningCount, EtabsSectionName. | `EtabsImportMetadataDto.cs` |
| `class` | **EtabsIrregularBoundaryDto** | Data transfer object carrying EtabsIrregularBoundary data. Key properties: SourceSectionProperties, PierLabel, StoryName. | `EtabsIrregularBoundaryDto.cs` |
| `class` | **EtabsModelFingerprint** | Represents the EtabsModelFingerprint class. Key properties: ModelFilePath, ImportedAt, ModelFileName. | `EtabsModelFingerprint.cs` |
| `class` | **EtabsObjectBindingHealth** | Represents the EtabsObjectBindingHealth class. Key properties: CurrentModelName, ObjectKey, ModelChanged. | `EtabsBindingValidationResult.cs` |
| `class` | **EtabsPierObjectKey** | Represents the EtabsPierObjectKey class. Key properties: PierName, X1, CenterY. | `EtabsPierObjectKey.cs` |
| `class` | **EtabsSectionBinding** | Represents the EtabsSectionBinding class. Key properties: MbColumnSectionId, PierObjects, MbColumnSectionName. | `EtabsSectionBinding.cs` |
| `class` | **EtabsSectionRefreshSummary** | Represents the EtabsSectionRefreshSummary class. Key properties: AddedRows, RecommendedAction, MissingObjects. | `EtabsSectionRefreshSummary.cs` |
| `class` | **EtabsSourceObjectRefDto** | Data transfer object carrying EtabsSourceObjectRef data. Key properties: SourceModelPath, MBColumnUnitsAtImport, StoryFrom. | `EtabsTierImportMetadataDto.cs` |
| `class` | **EtabsTierImportMetadataDto** | Data transfer object carrying EtabsTierImportMetadata data. Key properties: SourceModelPath, MBColumnUnitsAtImport, StoryFrom. | `EtabsTierImportMetadataDto.cs` |
| `class` | **ImportedEtabsForceDatabase** | Data storage/cache handler for ImportedEtabsForceDatabase. Key properties: DatabaseUnits. | `ImportedEtabsForceDatabase.cs` |
| `class` | **MbColumnMappedForceRow** | Data structure representing a row for MbColumnMappedForce. Key properties: Mx, Location, My. | `MbColumnMappedForceRow.cs` |
| `class` | **MbColumnSectionImport** | Represents the MbColumnSectionImport class. Key properties: SelectedItems, SectionName. | `MbColumnSectionImport.cs` |
| `class` | **MbColumnSectionImportItem** | Represents the MbColumnSectionImportItem class. Key properties: Story, ObjectType, Label. | `MbColumnSectionImportItem.cs` |
| `enum` | **EtabsBindingHealthStatus** | Enumeration defining states/types for EtabsBindingHealthStatus. | `EtabsBindingHealthStatus.cs` |
| `enum` | **EtabsForceRowChangeStatus** | Enumeration defining states/types for EtabsForceRowChangeStatus. Key properties: Status, Location, LoadCaseName. | `EtabsForceRowChange.cs` |
| `enum` | **EtabsImportedObjectType** | Enumeration defining states/types for EtabsImportedObjectType. | `EtabsImportedObjectType.cs` |
| `enum` | **EtabsResultState** | Enumeration defining states/types for EtabsResultState. | `EtabsResultState.cs` |
| `enum` | **EtabsSectionRefreshAction** | Enumeration defining states/types for EtabsSectionRefreshAction. Key properties: AddedRows, RecommendedAction, MissingObjects. | `EtabsSectionRefreshSummary.cs` |
| `enum` | **MbColumnForceSourceMode** | Enumeration defining states/types for MbColumnForceSourceMode. | `MbColumnForceSourceMode.cs` |
| `record` | **EtabsColumnImportDto** | Data transfer object carrying EtabsColumnImport data. | `EtabsColumnImportDto.cs` |
| `record` | **EtabsConnectionResultDto** | Data transfer object carrying EtabsConnectionResult data. | `EtabsConnectionResultDto.cs` |
| `record` | **EtabsForceCacheBuildResult** | Represents the EtabsForceCacheBuildResult component. | `EtabsForceCacheBuildResult.cs` |
| `record` | **EtabsForceCacheQuery** | Represents the EtabsForceCacheQuery component. | `EtabsForceCacheQuery.cs` |
| `record` | **EtabsForceResultDto** | Data transfer object carrying EtabsForceResult data. | `EtabsForceResultDto.cs` |
| `record` | **EtabsImportSummaryDto** | Data transfer object carrying EtabsImportSummary data. | `EtabsImportSummaryDto.cs` |
| `record` | **EtabsModelInfoDto** | Data transfer object carrying EtabsModelInfo data. | `EtabsModelInfoDto.cs` |
| `record` | **EtabsPierShellSegmentDto** | Data transfer object carrying EtabsPierShellSegment data. | `EtabsPierShellSegmentDto.cs` |
| `record` | **EtabsSectionMappingDto** | Data transfer object carrying EtabsSectionMapping data. | `EtabsSectionMappingDto.cs` |

### DTOs/ImportExport

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **DxfSectionImportResult** | Encapsulates the result of DxfSectionImport operations. Key properties: BoundaryVertices, BoundaryPolylineCount, BoundaryVertexCount. | `DxfSectionImportResult.cs` |
| `record` | **DxfRebarImportItem** | Represents the DxfRebarImportItem component. | `DxfRebarImportItem.cs` |
| `record` | **DxfSectionImportRequest** | Represents the DxfSectionImportRequest component. | `DxfSectionImportRequest.cs` |
| `record` | **IrregularBoundaryPointCsvDto** | Data transfer object carrying IrregularBoundaryPointCsv data. | `IrregularBoundaryPointCsvDto.cs` |
| `record` | **IrregularRebarCsvDto** | Data transfer object carrying IrregularRebarCsv data. | `IrregularRebarCsvDto.cs` |

### DTOs/Persistence

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ColumnInputSnapshot** | Represents the ColumnInputSnapshot class. Key properties: BoundaryPoints, Muy, Pu. | `ColumnInputSnapshot.cs` |
| `class` | **SnapshotBoundaryPoint** | Represents the SnapshotBoundaryPoint class. Key properties: BoundaryPoints, Muy, Pu. | `ColumnInputSnapshot.cs` |
| `class` | **SnapshotLoadCase** | Represents the SnapshotLoadCase class. Key properties: BoundaryPoints, Muy, Pu. | `ColumnInputSnapshot.cs` |
| `class` | **SnapshotRebar** | Represents the SnapshotRebar class. Key properties: BoundaryPoints, Muy, Pu. | `ColumnInputSnapshot.cs` |

### Interfaces

| Type | Name | Description | File |
|---|---|---|---|
| `interface` | **IPmValidationReportService** | Provides service logic and operations for IPmValidationReport. | `IPmValidationReportService.cs` |

### Mappers

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **IrregularSectionMapper** | Maps data structures for IrregularSection. Key methods: ValidateAndMap. | `IrregularSectionMapper.cs` |

### Services

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ColumnCalculationService** | Provides service logic and operations for ColumnCalculation. Key methods: Calculate. | `ColumnCalculationService.cs` |
| `class` | **CompressionZonePolygonBuilder** | Represents the CompressionZonePolygonBuilder class. Key methods: ClipByNeutralAxis, ClipTensionSideByNeutralAxis. | `CompressionZonePolygonBuilder.cs` |
| `class` | **ControlPointBuilderService** | Provides service logic and operations for ControlPointBuilder. Key methods: Build. | `ControlPointBuilderService.cs` |
| `class` | **ControlPointCsvExportService** | Provides service logic and operations for ControlPointCsvExport. Key methods: Export. | `ControlPointCsvExportService.cs` |
| `class` | **ControlPointPreviewService** | Provides service logic and operations for ControlPointPreview. Key methods: BuildPreview. | `ControlPointPreviewService.cs` |
| `class` | **ControlPointTableBuilderService** | Builds the design-code control-point table for each of the four principal bending axes: X, Y, -X, -Y. | `ControlPointTableBuilderService.cs` |
| `class` | **DiagramDataService** | Provides service logic and operations for DiagramData. Key methods: BuildSurfaceMesh, CleanAndSortMmBoundaryPoints, BuildPmmSurfaceRenderDataAtPLevels, BuildPmDiagramRenderData, BuildMxMyDiagramData. | `DiagramDataService.cs` |
| `class` | **InputValidationService** | Provides service logic and operations for InputValidation. Key methods: Validate. | `InputValidationService.cs` |
| `class` | **InteractionSurfaceService** | Provides service logic and operations for InteractionSurface. Key methods: Build. | `InteractionSurfaceService.cs` |
| `class` | **IrregularSectionValidationService** | Provides service logic and operations for IrregularSectionValidation. Key methods: ValidateRebars, ValidateBoundary, TryResolveDiameter. | `IrregularSectionValidationService.cs` |
| `class` | **PmChartInsetBuilderService** | Provides service logic and operations for PmChartInsetBuilder. | `PmChartInsetBuilderService.cs` |
| `class` | **PmChartInsetStateResolverService** | Provides service logic and operations for PmChartInsetStateResolver. Key methods: FromCapacityPoint, FromNavigation, FromLoadCase. | `PmChartInsetStateResolverService.cs` |
| `class` | **PmCurveBuilderService** | Provides service logic and operations for PmCurveBuilder. Key methods: BuildPmInteractionDebugCsv, BuildPmAngleReferenceLines, ValidatePmCapacityPolyline, ValidateStraightTrimSegment, BuildPmAngleCurve. | `PmCurveBuilderService.cs` |
| `class` | **PmSevenPointReportMapper** | Maps data structures for PmSevenPointReport. Key methods: FormatPctOrNa, FormatOrNa, Map. | `PmSevenPointReportMapper.cs` |
| `class` | **RatioCheckService** | Provides service logic and operations for RatioCheck. Key methods: Cross, Length, Normalize, Check, CheckBatch. | `RatioCheckService.cs` |
| `class` | **RebarCoordinateBuilderService** | Provides service logic and operations for RebarCoordinateBuilder. Key methods: BuildCircular, Build. | `RebarCoordinateBuilderService.cs` |
| `class` | **ReportHandCalcService** | Independently calculates selected PMM control points using transparent hand-calculation formulas and compares results against the solver surface. Supports ACI 318 (Whitney rectangular stress block) and EC2 (simplified rectangular block, λ/η). Only rectangular sections are supported. | `ReportHandCalcService.cs` |
| `class` | **SpecialCapacityPointsService** | Generates five structurally significant capacity points for every neutral-axis angle on an interaction surface: max compression, balanced, tension-controlled, pure bending, and max tension. The source InteractionSurface is searched/interpolated; no additional solver passes are performed. | `SpecialCapacityPointsService.cs` |
| `enum` | **CurveAxis** | Represents the CurveAxis component. | `PmCurveBuilderService.cs` |
| `enum` | **PmDebugMomentAxis** | Validates that the ACI compression trim segment of a design PM curve is a clean straight horizontal line at exactly <paramref name="designPMaxDisplay"/>. Returns a list of defect descriptions (empty = valid). | `PmCurveBuilderService.cs` |
| `interface` | **IControlPointCsvExportService** | Provides service logic and operations for IControlPointCsvExport. | `IControlPointCsvExportService.cs` |
| `interface` | **IControlPointPreviewService** | Provides service logic and operations for IControlPointPreview. | `IControlPointPreviewService.cs` |
| `interface` | **IIrregularSectionValidationService** | Provides service logic and operations for IIrregularSectionValidation. | `IIrregularSectionValidationService.cs` |
| `interface` | **IProjectService** | Service handling operations for IProject. | `IProjectService.cs` |
| `interface` | **IRebarCoordinateBuilderService** | Provides service logic and operations for IRebarCoordinateBuilder. | `IRebarCoordinateBuilderService.cs` |
| `record` | **ColumnRecord** | Represents the ColumnRecord record. | `IProjectService.cs` |
| `record` | **GroupRecord** | Represents the GroupRecord component. | `IProjectService.cs` |
| `record` | **PmCurveBuildDiagnostics** | Represents the PmCurveBuildDiagnostics component. | `PmCurveBuilderService.cs` |
| `record` | **SpecialCapacityEntry** | Represents the SpecialCapacityEntry component. | `SpecialCapacityPointsService.cs` |

### Services/Etabs

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **EtabsForceCacheIdentity** | Represents the EtabsForceCacheIdentity class. Key properties: SelectedCombos, ObjectType, CachedAt. | `IEtabsForceCacheStore.cs` |
| `class` | **EtabsForceRefreshResult** | Encapsulates the result of EtabsForceRefresh operations. Key properties: Message, Success. | `IEtabsForceRefreshService.cs` |
| `class` | **EtabsForceScope** | Represents the EtabsForceScope class. Key properties: ImportBottom, LoadCombinations, ImportTop. | `IEtabsForceSelectionService.cs` |
| `class` | **EtabsSectionForceFilterService** | Provides service logic and operations for EtabsSectionForceFilter. Key methods: FilterForcesForSection, FindMissingItems. | `EtabsSectionForceFilterService.cs` |
| `interface` | **IEtabsBindingReconciliationService** | Provides service logic and operations for IEtabsBindingReconciliation. | `IEtabsBindingReconciliationService.cs` |
| `interface` | **IEtabsColumnImportService** | Provides service logic and operations for IEtabsColumnImport. | `IEtabsColumnImportService.cs` |
| `interface` | **IEtabsConnectionService** | Provides service logic and operations for IEtabsConnection. | `IEtabsConnectionService.cs` |
| `interface` | **IEtabsDesignForceImportService** | Provides service logic and operations for IEtabsDesignForceImport. | `IEtabsDesignForceImportService.cs` |
| `interface` | **IEtabsForceCacheResolver** | Defines the contract for EtabsForceCacheResolver. | `IEtabsForceCacheResolver.cs` |
| `interface` | **IEtabsForceCacheService** | Provides service logic and operations for IEtabsForceCache. | `IEtabsForceCacheService.cs` |
| `interface` | **IEtabsForceCacheStore** | Defines the contract for EtabsForceCacheStore. Key properties: SelectedCombos, ObjectType, CachedAt. | `IEtabsForceCacheStore.cs` |
| `interface` | **IEtabsForceChangeDetector** | Defines the contract for EtabsForceChangeDetector. | `IEtabsForceChangeDetector.cs` |
| `interface` | **IEtabsForceImportService** | Provides service logic and operations for IEtabsForceImport. | `IEtabsForceImportService.cs` |
| `interface` | **IEtabsForceMapper** | Maps data structures for IEtabsForce. | `IEtabsForceMapper.cs` |
| `interface` | **IEtabsForceRefreshService** | Provides service logic and operations for IEtabsForceRefresh. Key properties: Message, Success. | `IEtabsForceRefreshService.cs` |
| `interface` | **IEtabsForceSelectionService** | Provides service logic and operations for IEtabsForceSelection. Key properties: ImportBottom, LoadCombinations, ImportTop. | `IEtabsForceSelectionService.cs` |
| `interface` | **IEtabsPierShellImportService** | Provides service logic and operations for IEtabsPierShellImport. | `IEtabsPierShellImportService.cs` |
| `interface` | **IEtabsResultStateService** | Provides service logic and operations for IEtabsResultState. | `IEtabsResultStateService.cs` |
| `interface` | **IEtabsSectionForceFilterService** | Provides service logic and operations for IEtabsSectionForceFilter. | `IEtabsSectionForceFilterService.cs` |
| `interface` | **IEtabsSectionImportMapper** | Maps data structures for IEtabsSectionImport. | `IEtabsSectionImportMapper.cs` |
| `interface` | **IImportedEtabsForceCache** | Data storage/cache handler for IImportedEtabsForceCache. | `IImportedEtabsForceCache.cs` |
| `interface` | **IIrregularPierGeometryBuilder** | Defines the contract for IrregularPierGeometryBuilder. | `IIrregularPierGeometryBuilder.cs` |

### Services/Geometry

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **PolygonGeometry** | Represents the PolygonGeometry class. Key methods: Centroid, MoveToCentroidOrigin, SignedArea, EnsureClockwise, SegmentsIntersect. | `PolygonGeometry.cs` |

### Services/ImportExport

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **DxfImportService** | Provides service logic and operations for DxfImport. Key methods: ImportSection, GetLayerNames. | `DxfImportService.cs` |
| `class` | **IrregularSectionCsvService** | Provides service logic and operations for IrregularSectionCsv. Key methods: ImportBoundary, ExportBoundary, ParseBoundary, ExportRebars, SerializeBoundary. | `IrregularSectionCsvService.cs` |
| `interface` | **IDxfImportService** | Provides service logic and operations for IDxfImport. | `IDxfImportService.cs` |
| `interface` | **IIrregularSectionCsvService** | Provides service logic and operations for IIrregularSectionCsv. | `IIrregularSectionCsvService.cs` |
| `record` | **DxfCircleEntity** | Represents the DxfCircleEntity component. | `DxfImportService.cs` |
| `record` | **DxfEntity** | Represents the DxfEntity component. | `DxfImportService.cs` |
| `record` | **DxfGenericEntity** | Represents the DxfGenericEntity component. | `DxfImportService.cs` |
| `record` | **DxfPolylineEntity** | Represents the DxfPolylineEntity component. | `DxfImportService.cs` |

### Validators

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ColumnInputValidator** | Validation logic for ColumnInput. Key methods: Validate. | `ColumnInputValidator.cs` |

## MBColumn.Domain

### Entities

| Type | Name | Description | File |
|---|---|---|---|
| `record` | **CircularSection** | Represents the CircularSection record. | `CircularSection.cs` |
| `record` | **ColumnSection** | Represents the ColumnSection record. | `ColumnSection.cs` |
| `record` | **ConcreteMaterial** | Represents the ConcreteMaterial component. | `ConcreteMaterial.cs` |
| `record` | **ControlPoint** | Represents the ControlPoint record. Key properties: IsSpecialPoint. | `ControlPoint.cs` |
| `record` | **DiagramControlPointSet** | Represents the DiagramControlPointSet record. Key properties: SpecialCapacityPoints. | `DiagramControlPointSet.cs` |
| `record` | **InteractionPoint** | Represents the InteractionPoint record. Key properties: IsSpecialPoint, ThetaRad. | `InteractionPoint.cs` |
| `record` | **InteractionSurface** | Represents the InteractionSurface record. | `InteractionSurface.cs` |
| `record` | **IrregularSection** | Represents the IrregularSection record. | `IrregularSection.cs` |
| `record` | **LoadDemand** | Represents the LoadDemand component. | `LoadDemand.cs` |
| `record` | **NominalCapacity** | Represents the NominalCapacity component. | `InteractionPoint.cs` |
| `record` | **RatioResult** | Encapsulates the result of Ratio operations. Key properties: CapacityMny, CapacityMnx, DemandMagnitude. | `RatioResult.cs` |
| `record` | **Rebar** | Represents the Rebar component. | `Rebar.cs` |
| `record` | **RebarLayout** | Represents the RebarLayout component. | `RebarLayout.cs` |
| `record` | **RectangularSection** | Represents the RectangularSection record. | `RectangularSection.cs` |
| `record` | **ReducedCapacity** | Represents the ReducedCapacity component. | `InteractionPoint.cs` |
| `record` | **SteelMaterial** | Represents the SteelMaterial component. | `SteelMaterial.cs` |
| `record` | **StrainState** | Represents the StrainState component. | `InteractionPoint.cs` |

### Enums

| Type | Name | Description | File |
|---|---|---|---|
| `enum` | **CapacityStatus** | Enumeration defining states/types for CapacityStatus. | `CapacityStatus.cs` |
| `enum` | **DesignCodeType** | Enumeration defining states/types for DesignCodeType. | `DesignCodeType.cs` |
| `enum` | **DiagramType** | Enumeration defining states/types for DiagramType. | `DiagramType.cs` |
| `enum` | **Ec2SolverType** | Enumeration defining states/types for Ec2SolverType. | `Ec2SolverType.cs` |
| `enum` | **ForceUnit** | Enumeration defining states/types for ForceUnit. | `ForceUnit.cs` |
| `enum` | **LengthUnit** | Enumeration defining states/types for LengthUnit. | `LengthUnit.cs` |
| `enum` | **MomentUnit** | Enumeration defining states/types for MomentUnit. | `MomentUnit.cs` |
| `enum` | **RebarUnitType** | Enumeration defining states/types for RebarUnitType. | `RebarUnitType.cs` |
| `enum` | **SectionIntegrationMethod** | Enumeration defining states/types for SectionIntegrationMethod. | `SectionIntegrationMethod.cs` |
| `enum` | **SectionShapeType** | Enumeration defining states/types for SectionShapeType. | `SectionShapeType.cs` |
| `enum` | **StressUnit** | Enumeration defining states/types for StressUnit. | `StressUnit.cs` |
| `enum` | **UnitSystem** | Enumeration defining states/types for UnitSystem. | `UnitSystem.cs` |

### Interfaces

| Type | Name | Description | File |
|---|---|---|---|
| `interface` | **ICircularInteractionSolver** | Defines the contract for CircularInteractionSolver. | `ICircularInteractionSolver.cs` |
| `interface` | **IControlPointBuilder** | Defines the contract for ControlPointBuilder. | `IControlPointBuilder.cs` |
| `interface` | **IDesignCodeService** | Provides service logic and operations for IDesignCode. | `IDesignCodeService.cs` |
| `interface` | **IDesignCodeServiceFactory** | Defines the contract for DesignCodeServiceFactory. | `IDesignCodeServiceFactory.cs` |
| `interface` | **IInteractionSolver** | Defines the contract for InteractionSolver. | `IInteractionSolver.cs` |
| `interface` | **IInteractionSolverFactory** | Defines the contract for InteractionSolverFactory. | `IInteractionSolverFactory.cs` |
| `interface` | **IIrregularInteractionSolver** | Defines the contract for IrregularInteractionSolver. | `IIrregularInteractionSolver.cs` |
| `interface` | **IRatioCheckService** | Provides service logic and operations for IRatioCheck. | `IRatioCheckService.cs` |
| `interface` | **IRebarDatabase** | Represents the IRebarDatabase component. | `IRebarDatabase.cs` |
| `interface` | **IUnitConversionService** | Provides service logic and operations for IUnitConversion. | `IUnitConversionService.cs` |
| `record` | **RebarDefinition** | Represents the RebarDefinition record. | `IRebarDatabase.cs` |

## MBColumn.Infrastructure

### DesignCodes

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **Aci318DesignCodeService** | Provides service logic and operations for Aci318DesignCode. Key methods: ConcreteEffectiveStrengthFactor, NominalCompressionLimit, ConcretePeakStrain, Phi, CompressionDesignLimit. Key properties: AlphaCc. | `Aci318DesignCodeService.cs` |
| `class` | **DesignCodeServiceFactory** | Represents the DesignCodeServiceFactory class. Key methods: Get. | `DesignCodeServiceFactory.cs` |
| `class` | **Ec2DesignCodeService** | Eurocode 2 (EN 1992-1-1:2004) implementation of IDesignCodeService. Material partial factors: γc = 1.5, γs = 1.15 (Table 2.1N). Strength coefficient: αcc = 0.85 (Singapore/UK National Annex, clause 3.1.6(1)P). Concrete strain limits and parabolic parameters follow Table 3.1 with piecewise-linear interpolation for 50 MPa &lt; fck ≤ 90 MPa. | `Ec2DesignCodeService.cs` |

### Etabs

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **AreaScanCache** | Represents the AreaScanCache component. | `EtabsPierShellImportService.cs` |
| `class` | **EtabsBindingReconciliationService** | Provides service logic and operations for EtabsBindingReconciliation. Key methods: ReconcilePierObject, ReconcileColumnObject, ValidateBindings. | `EtabsBindingReconciliationService.cs` |
| `class` | **EtabsColumnImportService** | Provides service logic and operations for EtabsColumnImport. Key methods: GetCandidateColumns, GetLoadCombinations. | `EtabsColumnImportService.cs` |
| `class` | **EtabsConnectionService** | Provides service logic and operations for EtabsConnection. Key methods: Disconnect, ConnectToRunningEtabs. | `EtabsConnectionService.cs` |
| `class` | **EtabsDesignForceImportService** | Preloads raw Design Forces - Columns and Design Forces - Piers tables from ETABS into <see cref="ImportedEtabsForceDatabase"/> without filtering or unit conversion, so the data can later be parsed on demand by the Force Filter without additional COM calls. | `EtabsDesignForceImportService.cs` |
| `class` | **EtabsForceCacheResolver** | Resolves the correct cached force rows by source mode and object type. Design Forces use the preloaded ImportedEtabsForceDatabase. Element Forces require ETABS connection (live COM) and are not pre-cached. | `EtabsForceCacheResolver.cs` |
| `class` | **EtabsForceCacheService** | Provides service logic and operations for EtabsForceCache. Key methods: Query, Clear, Dispose, Build. Key properties: StatusText. | `EtabsForceCacheService.cs` |
| `class` | **EtabsForceChangeDetector** | Represents the EtabsForceChangeDetector class. Key methods: CompareSectionForces. | `EtabsForceChangeDetector.cs` |
| `class` | **EtabsForceImportService** | Provides service logic and operations for EtabsForceImport. Key methods: GetForces, GetElementForces, GetPierElementForces, GetPierForces. | `EtabsForceImportService.cs` |
| `class` | **EtabsForceMapper** | Maps data structures for EtabsForce. Key methods: ToLoadCases, MapPierForces, MapColumnForces. | `EtabsForceMapper.cs` |
| `class` | **EtabsForceRefreshService** | Provides service logic and operations for EtabsForceRefresh. Key methods: RunEtabsDesign, RunEtabsAnalysis, Apply, BuildPreview, CheckResultState. | `EtabsForceRefreshService.cs` |
| `class` | **EtabsForceSelectionService** | Provides service logic and operations for EtabsForceSelection. Key methods: BuildColumnScope. | `EtabsForceSelectionService.cs` |
| `class` | **EtabsPierShellImportService** | Provides service logic and operations for EtabsPierShellImport. Key methods: GetSegments, GetStoryNames. | `EtabsPierShellImportService.cs` |
| `class` | **EtabsResultStateService** | Provides service logic and operations for EtabsResultState. Key methods: CheckDesignForceAvailability, CheckElementForceAvailability. | `EtabsResultStateService.cs` |
| `class` | **ImportedEtabsForceCache** | In-memory singleton cache for the raw ETABS design force database preloaded during Import ETABS. The cache is invalidated whenever the model file path changes or <see cref="Clear"/> is called. | `ImportedEtabsForceCache.cs` |
| `class` | **IrregularPierGeometryBuilder** | Represents the IrregularPierGeometryBuilder class. Key methods: BuildBoundary. | `IrregularPierGeometryBuilder.cs` |
| `record` | **AreaRecord** | Represents the AreaRecord record. Key methods: GetSegments, GetStoryNames. | `EtabsPierShellImportService.cs` |

### Math

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **GeometryHelper** | Represents the GeometryHelper class. Key methods: MomentMagnitude, DegreesToRadians. | `GeometryHelper.cs` |
| `class` | **LinearInterpolationService** | Provides service logic and operations for LinearInterpolation. Key methods: Lerp. | `LinearInterpolationService.cs` |
| `class` | **PolygonClipper** | Represents the PolygonClipper class. | `PolygonClipper.cs` |
| `class` | **UnitConversionService** | Provides service logic and operations for UnitConversion. Key methods: MomentToNmm, ForceFromN, MomentFromNmm, LengthToMm, ConvertLength. | `UnitConversionService.cs` |

### Persistence

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ColumnInputRow** | Represents the ColumnInputRow component. | `ProjectService.cs` |
| `class` | **ColumnRow** | Represents the ColumnRow component. | `ProjectService.cs` |
| `class` | **DatabaseSchema** | Represents the DatabaseSchema class. Key methods: Open, OpenResultDb, EnsureCreated. | `DatabaseSchema.cs` |
| `class` | **GroupRow** | Represents the GroupRow component. | `ProjectService.cs` |
| `class` | **ProjectRow** | Represents the ProjectRow component. | `ProjectService.cs` |
| `class` | **ProjectService** | Provides service logic and operations for Project. Key methods: SaveProjectAs, AddGroup, OpenProject, RenameProject, MoveColumn. Key properties: ProjectName, Id, InputJson. | `ProjectService.cs` |
| `class` | **ResultCacheRow** | Represents the ResultCacheRow component. | `ProjectService.cs` |

### Rebar

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ImperialRebarDatabase** | Data storage/cache handler for ImperialRebarDatabase. Key methods: TryGet, GetBars. | `ImperialRebarDatabase.cs` |
| `class` | **SingaporeRebarDatabase** | Data storage/cache handler for SingaporeRebarDatabase. Key methods: TryGet, GetBars. | `SingaporeRebarDatabase.cs` |

### Root

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **Program** | Represents the Program component. | `test_flow.cs` |

### Solvers

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **Aci318DesignAdapter** | Represents the Aci318DesignAdapter class. Key methods: Create, ApplyDesignRules. | `DesignCodeAdapters.cs` |
| `class` | **CircularFiberInteractionSolver** | Circular RC interaction solver using strain compatibility and numerical concrete fibers. Concrete is integrated over the circular area and reinforcing bars are handled as discrete steel fibers at centroid-based coordinates. | `CircularFiberInteractionSolver.cs` |
| `class` | **DesignCodeAdapterFactory** | Represents the DesignCodeAdapterFactory class. Key methods: Create, ApplyDesignRules. | `DesignCodeAdapters.cs` |
| `class` | **Eurocode2DesignAdapter** | Represents the Eurocode2DesignAdapter class. Key methods: Create, ApplyDesignRules. | `DesignCodeAdapters.cs` |
| `class` | **InteractionSolverFactory** | Represents the InteractionSolverFactory class. Key methods: Get, GetCircular, GetLegacy, GetIrregular. | `InteractionSolverFactory.cs` |
| `class` | **NeutralAxisSweepStrategy** | Represents the NeutralAxisSweepStrategy class. Key methods: GenerateStates, ProjectExtreme. | `NeutralAxisSweepStrategy.cs` |
| `class` | **PmmInteractionSolver** | Represents the PmmInteractionSolver class. Key methods: Solve. Key properties: CirclePolygonSegmentCount, NeutralAxisSamples, CircularAngularFiberCount. | `PmmInteractionSolver.cs` |
| `class` | **PmmSolver** | Represents the PmmSolver class. Key methods: Solve. | `PmmSolver.cs` |
| `interface` | **IDesignCodeAdapter** | Defines the contract for DesignCodeAdapter. Key properties: NominalMx, ConcreteMy, MaxSteelStrain. | `PmmModels.cs` |
| `interface` | **ISectionIntegrator** | Defines the contract for SectionIntegrator. Key properties: NominalMx, ConcreteMy, MaxSteelStrain. | `PmmModels.cs` |
| `interface` | **ISweepStrategy** | Represents the ISweepStrategy component. | `PmmModels.cs` |
| `record` | **ConcreteFiber** | Represents the ConcreteFiber component. | `CircularFiberInteractionSolver.cs` |
| `record` | **DesignCapacityPoint** | Represents the DesignCapacityPoint record. Key properties: NominalMx, ConcreteMy, MaxSteelStrain. | `PmmModels.cs` |
| `record` | **NeutralAxisState** | Represents the NeutralAxisState component. | `PmmModels.cs` |
| `record` | **PmmInput** | Represents the PmmInput record. Key properties: NominalMx, ConcreteMy, MaxSteelStrain. | `PmmModels.cs` |
| `record` | **PmmResult** | Represents the PmmResult component. | `PmmModels.cs` |
| `record` | **SectionIntegrationResult** | Encapsulates the result of SectionIntegration operations. Key properties: NominalMx, ConcreteMy, MaxSteelStrain. | `PmmModels.cs` |
| `record` | **SolverSettings** | Represents the SolverSettings component. | `PmmModels.cs` |

### Solvers/Integration

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **FiberSectionIntegrator** | Represents the FiberSectionIntegrator class. Key methods: Integrate. | `FiberSectionIntegrator.cs` |
| `class` | **PolygonSectionIntegrator** | Represents the PolygonSectionIntegrator class. Key methods: Integrate. | `PolygonSectionIntegrator.cs` |
| `class` | **SectionIntegratorFactory** | Represents the SectionIntegratorFactory class. Key methods: Create. | `SectionIntegratorFactory.cs` |

### Solvers/Legacy

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **AciFiberInteractionSolver** | Represents the AciFiberInteractionSolver class. Key methods: Solve. Key properties: ConcreteGridDivisions, AngleStepDegrees, NeutralAxisSamples. | `AciFiberInteractionSolver.cs` |
| `class` | **Ec2BoundaryInteractionSolver** | Represents the Ec2BoundaryInteractionSolver class. Key methods: Solve. Key properties: AngleStepDegrees, NeutralAxisSamples. | `Ec2BoundaryInteractionSolver.cs` |
| `class` | **Ec2FiberInteractionSolver** | Represents the Ec2FiberInteractionSolver class. Key methods: Solve. Key properties: ConcreteGridDivisions, AngleStepDegrees, NeutralAxisSamples. | `Ec2FiberInteractionSolver.cs` |
| `class` | **Ec2SimplifiedStressBlockInteractionSolver** | Eurocode 2 (EN 1992-1-1:2004) §3.1.7 — simplified rectangular concrete stress block. Uses Sutherland-Hodgman analytical polygon clipping (no fiber grid). Block stress = η × fcd, block depth = λ × c. All material parameters are read from IDesignCodeService; no local hardcoded constants. Moment sign: Mnx = Σ(force × y), Mny = Σ(force × x). Phi = 1.0. | `Ec2SimplifiedStressBlockInteractionSolver.cs` |
| `class` | **EcPmmFiberAnalyticSolver** | Represents the EcPmmFiberAnalyticSolver class. Key methods: Solve. Key properties: FiberCount, AngleStepDegrees, NeutralAxisSamples. | `EcPmmFiberAnalyticSolver.cs` |
| `class` | **StrainCompatibilityInteractionSolver** | Represents the StrainCompatibilityInteractionSolver class. Key methods: Solve. Key properties: ConcreteGridDivisions, AngleStepDegrees, NeutralAxisSamples. | `StrainCompatibilityInteractionSolver.cs` |
| `record` | **Fiber** | Represents the Fiber component. | `Ec2FiberInteractionSolver.cs` |
| `record` | **Point** | Represents the Point component. | `StrainCompatibilityInteractionSolver.cs` |
| `record` | **SectionPoint** | Represents the SectionPoint component. | `Ec2SimplifiedStressBlockInteractionSolver.cs` |

### Solvers/StrainPoints

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **Aci318StrainLimitAdapter** | Represents the Aci318StrainLimitAdapter class. Key methods: GetStrengthReductionFactor, GetPureCompressionCapacityLimit, GetSteelDesignStressLimit, GetConcreteDesignStress, GetSteelTensionStrainLimit. | `Aci318StrainLimitAdapter.cs` |
| `class` | **Ec2StrainLimitAdapter** | Represents the Ec2StrainLimitAdapter class. Key methods: GetStrengthReductionFactor, GetPureCompressionCapacityLimit, GetSteelDesignStressLimit, GetConcreteDesignStress, GetSteelTensionStrainLimit. | `Ec2StrainLimitAdapter.cs` |
| `class` | **PmComparisonService** | Provides service logic and operations for PmComparison. Key methods: Compare. Key properties: PassFail, NeutralAxisAngle, Mn_Polygon. | `PmComparisonService.cs` |
| `class` | **PmValidationReportService** | Provides service logic and operations for PmValidationReport. Key methods: BuildReport. | `PmValidationReportService.cs` |
| `class` | **RebarStrainStressResult** | Encapsulates the result of RebarStrainStress operations. Key properties: XMm, NominalAxialForceN, ExtremeCompressionStrain. | `StrainControlledPmModels.cs` |
| `class` | **StrainControlledPmPointResult** | Encapsulates the result of StrainControlledPmPoint operations. Key properties: XMm, NominalAxialForceN, ExtremeCompressionStrain. | `StrainControlledPmModels.cs` |
| `class` | **StrainControlledSevenPointStrategy** | Represents the StrainControlledSevenPointStrategy class. Key methods: GeneratePoints. | `StrainControlledSevenPointStrategy.cs` |
| `class` | **StrainPointDefinition** | Represents the StrainPointDefinition class. Key properties: XMm, NominalAxialForceN, ExtremeCompressionStrain. | `StrainControlledPmModels.cs` |
| `class` | **StrainStateResult** | Encapsulates the result of StrainState operations. Key properties: XMm, NominalAxialForceN, ExtremeCompressionStrain. | `StrainControlledPmModels.cs` |
| `class` | **StrengthReductionResult** | Encapsulates the result of StrengthReduction operations. Key properties: Phi, StrengthEffectivenessFactor, Classification. | `IStrainLimitDesignCodeAdapter.cs` |
| `class` | **StressBlockParameters** | Represents the StressBlockParameters class. Key properties: Phi, StrengthEffectivenessFactor, Classification. | `IStrainLimitDesignCodeAdapter.cs` |
| `enum` | **StrainPointType** | Enumeration defining states/types for StrainPointType. Key properties: XMm, NominalAxialForceN, ExtremeCompressionStrain. | `StrainControlledPmModels.cs` |
| `interface` | **IStrainLimitDesignCodeAdapter** | Defines the contract for StrainLimitDesignCodeAdapter. Key properties: Phi, StrengthEffectivenessFactor, Classification. | `IStrainLimitDesignCodeAdapter.cs` |
| `record` | **PmComparisonPointResult** | Encapsulates the result of PmComparisonPoint operations. Key methods: Compare. Key properties: PassFail, NeutralAxisAngle, Mn_Polygon. | `PmComparisonService.cs` |

## MBColumn.Presentation.Wpf

### Collections

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **BulkObservableCollection** | ObservableCollection that supports batch adds via AddRange, firing a single Reset notification instead of one per item. | `BulkObservableCollection.cs` |

### Commands

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **AsyncRelayCommand** | Represents the AsyncRelayCommand class. Key methods: Execute, RaiseCanExecuteChanged, CanExecute. | `RelayCommand.cs` |
| `class` | **RelayCommand** | Represents the RelayCommand class. Key methods: Execute, RaiseCanExecuteChanged, CanExecute. | `RelayCommand.cs` |
| `class` | **RelayCommand** | Represents the RelayCommand class. Key methods: Execute, RaiseCanExecuteChanged, CanExecute. | `RelayCommand.cs` |

### Composition

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **AppComposition** | Represents the AppComposition class. Key methods: Create, CreateMainWindowViewModel, Dispose. Key properties: EtabsImportDialogService, EtabsForceRefreshDialogService, MessageService. | `AppComposition.cs` |

### Controls

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **AxisRenderer2D** | Represents the AxisRenderer2D class. Key methods: Draw. | `AxisRenderer2D.cs` |
| `class` | **AxisTickService** | Service handling operations for AxisTick. | `AxisTickService.cs` |
| `class` | **ChartInteractionState** | Represents the ChartInteractionState class. Key methods: Reset. | `ChartInteractionState.cs` |
| `class` | **ChartTransformHelper** | Represents the ChartTransformHelper class. Key methods: ToData, AxisTicksX, AutoFit2D, TicksY, AxisTicksY. Key properties: MaxX, MinX, Plot. | `ChartTransformHelper.cs` |
| `class` | **DiagramCanvas2D** | Represents the DiagramCanvas2D class. Key methods: ClipClosedPolylineBelowYForTesting, ResetView, ClipOpenPolylineAboveYForTesting. Key properties: ResetVersion, ShowCapacityControlPoints, ShowDemandPoint. | `DiagramCanvas2D.cs` |
| `class` | **InteractionViewport3D** | Represents the InteractionViewport3D class. Key methods: BuildEngineeringAxesForTesting, From, ResetCamera. Key properties: ResetVersion, ShowSurface, ShowDemandPoint. | `InteractionViewport3D.cs` |
| `class` | **ReportPaginator** | Paginates a FrameworkElement across multiple printed pages by slicing it vertically after scaling to fit the page width. | `ReportPaginator.cs` |
| `class` | **SectionPreviewCanvas** | Represents the SectionPreviewCanvas class. Key properties: RebarLabel, SectionLabel, Cover. | `SectionPreviewCanvas.cs` |
| `class` | **SectionStateInsetCanvas** | Sidebar panel that renders a PmChartInsetFigureDto (section with NA, compression/tension zones). Fills its available area; legend sits at the bottom. | `SectionStateInsetCanvas.cs` |
| `class` | **TooltipRenderer** | Represents the TooltipRenderer class. Key methods: Build. | `TooltipRenderer.cs` |
| `record` | **AxisTicks** | Represents the AxisTicks record. Key methods: Format, GenerateFixed, Generate. | `AxisTickService.cs` |
| `record` | **Bounds3D** | Represents the Bounds3D record. Key methods: BuildEngineeringAxesForTesting, From, ResetCamera. Key properties: ResetVersion, ShowSurface, ShowDemandPoint. | `InteractionViewport3D.cs` |
| `record` | **CachedScene** | Represents the CachedScene component. | `InteractionViewport3D.cs` |

### Converters

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **BoolToVisibilityConverter** | Represents the BoolToVisibilityConverter class. Key methods: Convert, ConvertBack. | `BoolToVisibilityConverter.cs` |
| `class` | **InverseBoolToVisibilityConverter** | Represents the InverseBoolToVisibilityConverter class. Key methods: Convert, ConvertBack. | `BoolToVisibilityConverter.cs` |
| `class` | **NonZeroToVisibilityConverter** | Represents the NonZeroToVisibilityConverter class. Key methods: Convert, ConvertBack. | `BoolToVisibilityConverter.cs` |
| `class` | **NullOrEmptyToCollapsedConverter** | Represents the NullOrEmptyToCollapsedConverter class. Key methods: Convert, ConvertBack. | `BoolToVisibilityConverter.cs` |

### Root

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **App** | Represents the App class. | `App.xaml.cs` |
| `class` | **ControlPointsWindow** | User interface component for ControlPointsWindow. | `ControlPointsWindow.xaml.cs` |
| `class` | **ExportControlPointsWindow** | User interface component for ExportControlPointsWindow. | `ExportControlPointsWindow.xaml.cs` |
| `class` | **MainWindow** | User interface component for MainWindow. | `MainWindow.xaml.cs` |
| `record` | **ControlPointRow** | Represents the ControlPointRow component. | `ControlPointsWindow.xaml.cs` |

### Services

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ControlPointExportDialogService** | Provides service logic and operations for ControlPointExportDialog. Key methods: ShowDialog. | `ControlPointExportDialogService.cs` |
| `class` | **DxfImportDialogService** | Provides service logic and operations for DxfImportDialog. | `DxfImportDialogService.cs` |
| `class` | **EtabsForceRefreshDialogService** | Provides service logic and operations for EtabsForceRefreshDialog. | `EtabsForceRefreshDialogService.cs` |
| `class` | **EtabsImportDialogService** | Provides service logic and operations for EtabsImportDialog. | `EtabsImportDialogService.cs` |
| `class` | **MessageBoxService** | Provides service logic and operations for MessageBox. Key methods: ConfirmWarning, ShowWarning, ShowInformation, ShowError. | `IMessageService.cs` |
| `class` | **ProjectFileDialogService** | Provides service logic and operations for ProjectFileDialog. | `IProjectFileDialogService.cs` |
| `class` | **ProjectNameDialogService** | Provides service logic and operations for ProjectNameDialog. | `IProjectNameDialogService.cs` |
| `class` | **ProjectSession** | Represents the ProjectSession class. Key methods: StoreColumnResult, ClearResults, SelectColumn, CurrentColumnHasResult, TryGetCurrentColumnResult. | `ProjectSession.cs` |
| `class` | **RecentProjectsService** | Provides service logic and operations for RecentProjects. Key methods: ClearRecent, AddRecent, GetRecent. | `RecentProjectsService.cs` |
| `interface` | **IControlPointExportDialogService** | Provides service logic and operations for IControlPointExportDialog. | `IControlPointExportDialogService.cs` |
| `interface` | **IDxfImportDialogService** | Provides service logic and operations for IDxfImportDialog. | `IDxfImportDialogService.cs` |
| `interface` | **IEtabsForceRefreshDialogService** | Provides service logic and operations for IEtabsForceRefreshDialog. | `IEtabsForceRefreshDialogService.cs` |
| `interface` | **IEtabsImportDialogService** | Provides service logic and operations for IEtabsImportDialog. | `IEtabsImportDialogService.cs` |
| `interface` | **IMessageService** | Provides service logic and operations for IMessage. Key methods: ConfirmWarning, ShowWarning, ShowInformation, ShowError. | `IMessageService.cs` |
| `interface` | **IProjectFileDialogService** | Provides service logic and operations for IProjectFileDialog. | `IProjectFileDialogService.cs` |
| `interface` | **IProjectNameDialogService** | Provides service logic and operations for IProjectNameDialog. | `IProjectNameDialogService.cs` |
| `record` | **EtabsImportDialogResult** | Represents the EtabsImportDialogResult component. | `EtabsImportDialogResult.cs` |
| `record` | **EtabsImportedSectionInput** | Represents the EtabsImportedSectionInput component. | `EtabsImportDialogResult.cs` |

### ViewModels

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **A4ReportPageViewModel** | View model representing state and commands for A4ReportPage UI. Key methods: MmToDip, Paginate, InchToDip. Key properties: HandCalcPDisplay, SolverPDisplay, KeepTogether. | `A4ReportModels.cs` |
| `class` | **CadPointViewModel** | View model representing state and commands for CadPoint UI. Key properties: X, Y. | `CadPointViewModel.cs` |
| `class` | **CadRebarViewModel** | View model representing state and commands for CadRebar UI. Key properties: X, BarSize, Y. | `CadRebarViewModel.cs` |
| `class` | **CadSnapService** | Provides service logic and operations for CadSnap. Key methods: Snap. | `CadSnapService.cs` |
| `class` | **ColumnItemViewModel** | View model representing state and commands for ColumnItem UI. Key properties: MoveToGroupOptions, DuplicateCommand, Status. | `ColumnItemViewModel.cs` |
| `class` | **DxfImportViewModel** | View model binding the DxfImport UI component. | `DxfImportViewModel.cs` |
| `class` | **EtabsColumnImportRowViewModel** | View model representing state and commands for EtabsColumnImportRow UI. Key properties: EtabsSectionName, LinkedSection, IsSelected. | `EtabsColumnImportRowViewModel.cs` |
| `class` | **EtabsForceImportRowViewModel** | View model representing state and commands for EtabsForceImportRow UI. Key properties: M2, V2, IsSelected. | `EtabsForceImportRowViewModel.cs` |
| `class` | **EtabsForceRefreshSectionRowViewModel** | View model representing state and commands for EtabsForceRefreshSectionRow UI. Key methods: SetAvailableCombinations. Key properties: LoadComboFilterText, BusyText, StatusText. | `EtabsForceRefreshViewModel.cs` |
| `class` | **EtabsForceRefreshViewModel** | View model representing state and commands for EtabsForceRefresh UI. Key methods: SetAvailableCombinations. Key properties: LoadComboFilterText, BusyText, StatusText. | `EtabsForceRefreshViewModel.cs` |
| `class` | **EtabsImportSummaryRowViewModel** | View model representing state and commands for EtabsImportSummaryRow UI. Key methods: SetSelectedSilently, DeleteMbColumnSection, RemoveItemFromSection, ApplyPreloadData, GenerateSectionForceRows. Key properties: IsConnected, SelectedForceRowCount, Elevation. | `EtabsImportViewModel.cs` |
| `class` | **EtabsImportViewModel** | View model representing state and commands for EtabsImport UI. Key methods: SetSelectedSilently, DeleteMbColumnSection, RemoveItemFromSection, ApplyPreloadData, GenerateSectionForceRows. Key properties: IsConnected, SelectedForceRowCount, Elevation. | `EtabsImportViewModel.cs` |
| `class` | **EtabsLoadCombinationViewModel** | View model representing state and commands for EtabsLoadCombination UI. Key methods: SetSelectedSilently, DeleteMbColumnSection, RemoveItemFromSection, ApplyPreloadData, GenerateSectionForceRows. Key properties: IsConnected, SelectedForceRowCount, Elevation. | `EtabsImportViewModel.cs` |
| `class` | **EtabsPreloadData** | Represents the EtabsPreloadData class. Key properties: Columns, PresentUnits, FrameObjectCount. | `EtabsPreloadData.cs` |
| `class` | **EtabsPreloadStep** | Represents the EtabsPreloadStep component. | `EtabsPreloadStep.cs` |
| `class` | **EtabsPreloadViewModel** | View model representing state and commands for EtabsPreload UI. Key methods: Cancel. Key properties: CancelCommand, AvailableCombinations, IsComplete. | `EtabsPreloadViewModel.cs` |
| `class` | **EtabsSectionMappingViewModel** | View model representing state and commands for EtabsSectionMapping UI. Key properties: EtabsSectionName, TieDiameter, TotalBars. | `EtabsSectionMappingViewModel.cs` |
| `class` | **EtabsStoryOptionViewModel** | View model representing state and commands for EtabsStoryOption UI. Key methods: SetSelectedSilently, DeleteMbColumnSection, RemoveItemFromSection, ApplyPreloadData, GenerateSectionForceRows. Key properties: IsConnected, SelectedForceRowCount, Elevation. | `EtabsImportViewModel.cs` |
| `class` | **EtabsUniqueSectionOptionViewModel** | View model representing state and commands for EtabsUniqueSectionOption UI. Key methods: SetSelectedSilently, DeleteMbColumnSection, RemoveItemFromSection, ApplyPreloadData, GenerateSectionForceRows. Key properties: IsConnected, SelectedForceRowCount, Elevation. | `EtabsImportViewModel.cs` |
| `class` | **ExplorerNodeViewModel** | View model representing state and commands for ExplorerNode UI. Key properties: IsRenaming, Id, IsSelected. | `ExplorerNodeViewModel.cs` |
| `class` | **ExportControlPointsViewModel** | View model representing state and commands for ExportControlPoints UI. Key methods: RefreshPreview. Key properties: EmptyStateMessage, PreviewSummary, IsCustomThetaSelected. | `ExportControlPointsViewModel.cs` |
| `class` | **GoverningChartPreviewViewModel** | View model representing state and commands for GoverningChartPreview UI. Key methods: MmToDip, Paginate, InchToDip. Key properties: HandCalcPDisplay, SolverPDisplay, KeepTogether. | `A4ReportModels.cs` |
| `class` | **GroupActionViewModel** | View model representing state and commands for GroupAction UI. Key properties: Name, Command. | `GroupActionViewModel.cs` |
| `class` | **GroupItemViewModel** | View model representing state and commands for GroupItem UI. Key properties: Columns, AddSectionCommand, AddExistingSectionsCommand. | `GroupItemViewModel.cs` |
| `class` | **InputViewModel** | View model representing state and commands for Input UI. Key methods: ToDto, UpdateSectionPreview, ApplyDxfImportResult, StressValue, ToSnapshot. Key properties: PreviewIyyText, IsRectangularSection, GenerateEqualSpacingRebarsCommand. | `InputViewModel.cs` |
| `class` | **IrregularBoundaryPointViewModel** | View model representing state and commands for IrregularBoundaryPoint UI. Key properties: PtIndex, X, Y. | `IrregularBoundaryPointViewModel.cs` |
| `class` | **IrregularRebarRowViewModel** | View model representing state and commands for IrregularRebarRow UI. Key properties: X, BarSize, RebarIndex. | `IrregularRebarRowViewModel.cs` |
| `class` | **IrregularSectionInputViewModel** | View model representing state and commands for IrregularSectionInput UI. Key methods: ExportBoundaryFile, ImportBoundaryFile, ToDto, LoadDefaultLShape, ImportRebarFile. Key properties: RebarMode, BoundaryPoints, AddBoundaryRowCommand. | `IrregularSectionInputViewModel.cs` |
| `class` | **LoadCaseViewModel** | View model representing state and commands for LoadCase UI. Key methods: ToDto. Key properties: HasValidationError, Source, Muy. | `LoadCaseViewModel.cs` |
| `class` | **MM3DViewModel** | View model representing state and commands for MM3D UI. Key methods: Load. Key properties: ResetVersion, ShowSurface, ShowWireframe. | `MM3DViewModel.cs` |
| `class` | **MMDiagramViewModel** | View model representing state and commands for MMDiagram UI. Key methods: Load. Key properties: ResetVersion, ResetViewCommand, BoundaryPoints. | `MMDiagramViewModel.cs` |
| `class` | **MainWindowViewModel** | View model representing state and commands for MainWindow UI. Key properties: CalculateCommand, IsCalculating, IsSaving. | `MainWindowViewModel.cs` |
| `class` | **MbColumnMappedForceRowViewModel** | View model representing state and commands for MbColumnMappedForceRow UI. Key properties: Mx, Location, My. | `MbColumnMappedForceRowViewModel.cs` |
| `class` | **MbColumnSectionSummaryViewModel** | View model representing state and commands for MbColumnSectionSummary UI. Key properties: ObjectType, SectionName, SelectedItems. | `MbColumnSectionSummaryViewModel.cs` |
| `class` | **MbColumnSectionViewModel** | View model representing state and commands for MbColumnSection UI. Key methods: RemoveItem, AddItem. Key properties: Items, CancelRenameCommand, CommitRenameCommand. | `MbColumnSectionViewModel.cs` |
| `class` | **PM3DViewModel** | View model representing state and commands for PM3D UI. Key methods: Load. Key properties: ToggleAxialLoadSliceCommand, SelectedAxialLoad, ToggleSurfaceCommand. | `PM3DViewModel.cs` |
| `class` | **PMDiagramViewModel** | View model representing state and commands for PMDiagram UI. Key methods: LoadPmAngle. Key properties: ResetVersion, ResetViewCommand, YAxisLabel. | `PMDiagramViewModel.cs` |
| `class` | **PolylineDraft** | Represents the PolylineDraft class. Key methods: Clear. | `PolylineDraft.cs` |
| `class` | **ProjectExplorerViewModel** | View model representing state and commands for ProjectExplorer UI. Key methods: ClearSectionStatuses, SetSectionStatus, RefreshMoveToGroupOptions, SelectNode, CommitRename. Key properties: AddColumnCommand, ProjectName, Nodes. | `ProjectExplorerViewModel.cs` |
| `class` | **ProjectGroupOptionViewModel** | View model binding the ProjectGroupOption UI component. | `EtabsImportViewModel.cs` |
| `class` | **RebarLayoutViewModel** | View model representing state and commands for RebarLayout UI. Key properties: Top, Right, Left. | `RebarLayoutViewModel.cs` |
| `class` | **RebarSideInputViewModel** | View model representing state and commands for RebarSideInput UI. Key methods: SetWarning, SetBarCountSilently, ToDto, SetGlobalInputs. Key properties: Cover, BarCount, BarCountWarning. | `RebarSideInputViewModel.cs` |
| `class` | **ReportBlockViewModel** | View model representing state and commands for ReportBlock UI. Key methods: MmToDip, Paginate, InchToDip. Key properties: HandCalcPDisplay, SolverPDisplay, KeepTogether. | `A4ReportModels.cs` |
| `class` | **ReportPaginatorService** | Provides service logic and operations for ReportPaginator. Key methods: MmToDip, Paginate, InchToDip. Key properties: HandCalcPDisplay, SolverPDisplay, KeepTogether. | `A4ReportModels.cs` |
| `class` | **ReportPm7RowViewModel** | View model representing state and commands for ReportPm7Row UI. Key methods: MmToDip, Paginate, InchToDip. Key properties: HandCalcPDisplay, SolverPDisplay, KeepTogether. | `A4ReportModels.cs` |
| `class` | **ReportTabViewModel** | View model representing state and commands for ReportTab UI. Key methods: MarkOutdated, LoadFromCurrentWorkspace, Clear. Key properties: ResultStatusText, BoundaryPoints, GeneratePreviewCommand. | `ReportTabViewModel.cs` |
| `class` | **ReportUnitConverter** | Represents the ReportUnitConverter class. Key methods: MmToDip, Paginate, InchToDip. Key properties: HandCalcPDisplay, SolverPDisplay, KeepTogether. | `A4ReportModels.cs` |
| `class` | **ResultViewModel** | View model representing state and commands for Result UI. Key methods: CloseViewport, ToggleViewport. Key properties: SelectedPointNeutralAxisDepthDisplay, SelectedPointTypeDisplay, ViewportDropdownText. | `ResultViewModel.cs` |
| `class` | **SectionCadEditorViewModel** | View model representing state and commands for SectionCadEditor UI. Key methods: AddPolylinePoint, AddRebar, UpdatePolylinePreview, ApplyToSource, CancelPolyline. Key properties: ToolMode, GridSpacing, BoundaryPoints. | `SectionCadEditorViewModel.cs` |
| `class` | **SnapResult** | Represents the SnapResult component. | `SnapResult.cs` |
| `class` | **ViewModelBase** | Represents the ViewModelBase class. | `ViewModelBase.cs` |
| `class` | **ViewportOptionViewModel** | View model binding the ViewportOption UI component. | `ViewportOptionViewModel.cs` |
| `enum` | **CadToolMode** | Enumeration defining states/types for CadToolMode. | `CadToolMode.cs` |
| `enum` | **DiagramViewportType** | Enumeration defining states/types for DiagramViewportType. Key properties: IsSelected, DisplayName, Type. | `ViewportOptionViewModel.cs` |
| `enum` | **EtabsDuplicateHandlingMode** | Enumeration defining states/types for EtabsDuplicateHandlingMode. Key methods: SetSelectedSilently, DeleteMbColumnSection, RemoveItemFromSection, ApplyPreloadData, GenerateSectionForceRows. Key properties: IsConnected, SelectedForceRowCount, Elevation. | `EtabsImportViewModel.cs` |
| `enum` | **MaterialLibraryType** | Represents the MaterialLibraryType component. | `InputViewModel.cs` |
| `enum` | **PreloadStepStatus** | Enumeration defining states/types for PreloadStepStatus. Key methods: UpdateDetail, SetRunning, SetError, SetDone. Key properties: Status, Detail, IsSubStep. | `EtabsPreloadStep.cs` |
| `enum` | **SectionStatus** | Enumeration defining states/types for SectionStatus. | `SectionStatus.cs` |
| `enum` | **SnapKind** | Enumeration defining states/types for SnapKind. Key properties: X, Kind, Y. | `SnapResult.cs` |
| `record` | **DesignCodeOption** | Represents the DesignCodeOption record. Key methods: ToDto, UpdateSectionPreview, ApplyDxfImportResult, StressValue, ToSnapshot. Key properties: PreviewIyyText, IsRectangularSection, GenerateEqualSpacingRebarsCommand. | `InputViewModel.cs` |
| `record` | **Ec2SolverOption** | Represents the Ec2SolverOption component. | `InputViewModel.cs` |
| `record` | **EtabsDuplicateHandlingOption** | Represents the EtabsDuplicateHandlingOption record. Key methods: SetSelectedSilently, DeleteMbColumnSection, RemoveItemFromSection, ApplyPreloadData, GenerateSectionForceRows. Key properties: IsConnected, SelectedForceRowCount, Elevation. | `EtabsImportViewModel.cs` |
| `record` | **IrregularRebarModeOption** | Represents the IrregularRebarModeOption component. | `IrregularSectionInputViewModel.cs` |
| `record` | **LoadCaseResultRowViewModel** | View model representing state and commands for LoadCaseResultRow UI. Key methods: CloseViewport, ToggleViewport. Key properties: SelectedPointNeutralAxisDepthDisplay, SelectedPointTypeDisplay, ViewportDropdownText. | `ResultViewModel.cs` |
| `record` | **MaterialGradeOption** | Represents the MaterialGradeOption record. Key methods: ToDto, UpdateSectionPreview, ApplyDxfImportResult, StressValue, ToSnapshot. Key properties: PreviewIyyText, IsRectangularSection, GenerateEqualSpacingRebarsCommand. | `InputViewModel.cs` |
| `record` | **MaterialLibraryOption** | Represents the MaterialLibraryOption component. | `InputViewModel.cs` |
| `record` | **PreviewBoundaryPoint** | Represents the PreviewBoundaryPoint component. | `PreviewBoundaryPoint.cs` |
| `record` | **PreviewRebarPoint** | Represents the PreviewRebarPoint component. | `PreviewRebarPoint.cs` |
| `record` | **PreviewRebarVm** | Represents the PreviewRebarVm record. Key properties: FilePath, SelectedRebarLayerName, SummaryText. | `DxfImportViewModel.cs` |
| `record` | **RebarLayoutTypeOption** | Represents the RebarLayoutTypeOption component. | `RebarLayoutTypeOption.cs` |
| `record` | **ReportDemandCaseRowViewModel** | View model representing state and commands for ReportDemandCaseRow UI. Key methods: MarkOutdated, LoadFromCurrentWorkspace, Clear. Key properties: ResultStatusText, BoundaryPoints, GeneratePreviewCommand. | `ReportTabViewModel.cs` |
| `record` | **SectionIntegrationMethodOption** | Represents the SectionIntegrationMethodOption component. | `InputViewModel.cs` |
| `record` | **SevenPointValidationRowViewModel** | View model representing state and commands for SevenPointValidationRow UI. Key methods: CloseViewport, ToggleViewport. Key properties: SelectedPointNeutralAxisDepthDisplay, SelectedPointTypeDisplay, ViewportDropdownText. | `ResultViewModel.cs` |

### Views

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **DxfImportWindow** | User interface component for DxfImportWindow. | `DxfImportWindow.xaml.cs` |
| `class` | **EtabsForceRefreshWindow** | User interface component for EtabsForceRefreshWindow. | `EtabsForceRefreshWindow.xaml.cs` |
| `class` | **EtabsImportWindow** | User interface component for EtabsImportWindow. | `EtabsImportWindow.xaml.cs` |
| `class` | **EtabsPreloadWindow** | User interface component for EtabsPreloadWindow. | `EtabsPreloadWindow.xaml.cs` |
| `class` | **InputTabView** | User interface component for InputTabView. | `InputTabView.xaml.cs` |
| `class` | **MM3DView** | User interface component for MM3DView. | `MM3DView.xaml.cs` |
| `class` | **MMDiagramView** | User interface component for MMDiagramView. | `MMDiagramView.xaml.cs` |
| `class` | **PM3DView** | User interface component for PM3DView. | `PM3DView.xaml.cs` |
| `class` | **PMDiagramView** | User interface component for PMDiagramView. | `PMDiagramView.xaml.cs` |
| `class` | **ProjectNameDialog** | User interface component for ProjectNameDialog. Key properties: ProjectName. | `ProjectNameDialog.xaml.cs` |
| `class` | **RecentFileItem** | Represents the RecentFileItem class. Key properties: FilePath. | `StartUpWindow.xaml.cs` |
| `class` | **ReportTabView** | User interface component for ReportTabView. | `ReportTabView.xaml.cs` |
| `class` | **ResultTabView** | User interface component for ResultTabView. | `ResultTabView.xaml.cs` |
| `class` | **SectionCadEditorWindow** | User interface component for SectionCadEditorWindow. | `SectionCadEditorWindow.xaml.cs` |
| `class` | **SectionSelectionItem** | Represents the SectionSelectionItem class. Key methods: GetSelectedIds. Key properties: Name, IsSelected, Id. | `SelectSectionsDialog.xaml.cs` |
| `class` | **SelectSectionsDialog** | User interface component for SelectSectionsDialog. Key methods: GetSelectedIds. Key properties: Name, IsSelected, Id. | `SelectSectionsDialog.xaml.cs` |
| `class` | **StartUpWindow** | User interface component for StartUpWindow. Key properties: FilePath. | `StartUpWindow.xaml.cs` |

