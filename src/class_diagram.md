# Project Class Diagram & Overview

This document provides an overview of the classes, interfaces, records, and enums in the MBColumn project.

## MBColumn.Application

### DTOs

| Type | Name | Description | File |
|---|---|---|---|
| `record` | **CalculationResultDto** | Data transfer object carrying CalculationResult data. Key properties: LoadCaseResults, GoverningLoadCaseId, ControlPointTable, SectionShape. | `CalculationResultDto.cs` |
| `record` | **CapacityDebugPointDto** | Data transfer object carrying CapacityDebugPoint data. | `CapacityDebugPointDto.cs` |
| `record` | **ChartReferenceLineDto** | Data transfer object carrying ChartReferenceLine data. | `ChartReferenceLineDto.cs` |
| `record` | **ColumnInputDto** | Data transfer object carrying ColumnInput data. Key properties: LoadCases, RebarLayoutType, SectionShape, Diameter. | `ColumnInputDto.cs` |
| `record` | **ComplianceCheck** | /// A single pass/fail code-compliance check item. /// | `RebarComplianceResult.cs` |
| `record` | **ControlPointDto** | Data transfer object carrying ControlPoint data. Key properties: IsSpecialPoint, CpNumber. | `ControlPointDto.cs` |
| `record` | **ControlPointExportRow** | Data structure representing a row for ControlPointExport. Key properties: ThetaDeg, PointIndex, P, MxPositive. | `ControlPointExportRow.cs` |
| `record` | **ControlPointPreviewResult** | Encapsulates the result of ControlPointPreview operations. | `ControlPointExportRow.cs` |
| `record` | **ControlPointTableDto** | Data transfer object carrying ControlPointTable data. | `ControlPointTableDto.cs` |
| `record` | **ControlPointTableRowDto** | Data transfer object carrying ControlPointTableRow data. | `ControlPointTableDto.cs` |
| `enum` | **ControlPointThetaSelectionMode** | Enumeration defining states/types for ControlPointThetaSelectionMode. | `ControlPointExportRow.cs` |
| `record` | **ControlPointValidationRow** | Data structure representing a row for ControlPointValidation. | `ControlPointValidationRow.cs` |
| `record` | **DiagramDataDto** | Data transfer object carrying DiagramData data. | `DiagramDataDto.cs` |
| `record` | **Ec2ConcreteMaterialDto** | Data transfer object carrying Ec2ConcreteMaterial data. Key properties: Fcd, Fcm, Ecm. | `Ec2SlendernessDtos.cs` |
| `record` | **Ec2SlendernessAxisResultDto** | Data transfer object carrying Ec2SlendernessAxisResult data. | `Ec2SlendernessDtos.cs` |
| `record` | **Ec2SlendernessBatchResultDto** | Data transfer object carrying Ec2SlendernessBatchResult data. Key properties: Empty. | `Ec2SlendernessDtos.cs` |
| `record` | **Ec2SlendernessLoadCaseResultDto** | Data transfer object carrying Ec2SlendernessLoadCaseResult data. Key properties: MxUsedNmm, MyUsedNmm. | `Ec2SlendernessDtos.cs` |
| `record` | **Ec2SlendernessSectionValuesDto** | Data transfer object carrying Ec2SlendernessSectionValues data. | `Ec2SlendernessDtos.cs` |
| `record` | **Ec2SlendernessSettingsDto** | Data transfer object carrying Ec2SlendernessSettings data. | `Ec2SlendernessDtos.cs` |
| `record` | **HandCalcValidationReport** | Represents the HandCalcValidationReport record. Key methods: NotSupported. Key properties: ComparisonNote. | `HandCalcValidationReport.cs` |
| `record` | **InsetLineDto** | Data transfer object carrying InsetLine data. | `PmChartInsetFigureDto.cs` |
| `record` | **InsetPointDto** | Data transfer object carrying InsetPoint data. | `PmChartInsetFigureDto.cs` |
| `record` | **IrregularBoundaryPointDto** | Data transfer object carrying IrregularBoundaryPoint data. | `IrregularBoundaryPointDto.cs` |
| `record` | **IrregularRebarCoordinateDto** | Data transfer object carrying IrregularRebarCoordinate data. | `IrregularRebarCoordinateDto.cs` |
| `record` | **IrregularRebarInputDto** | Data transfer object carrying IrregularRebarInput data. | `IrregularRebarInputDto.cs` |
| `enum` | **IrregularRebarModeType** | Enumeration defining states/types for IrregularRebarModeType. | `IrregularRebarModeType.cs` |
| `record` | **IrregularSectionInputDto** | Data transfer object carrying IrregularSectionInput data. | `IrregularSectionInputDto.cs` |
| `record` | **IrregularSectionValidationResult** | Encapsulates the result of IrregularSectionValidation operations. Key methods: Errors. | `IrregularSectionValidationResult.cs` |
| `record` | **LoadCaseDto** | Data transfer object carrying LoadCase data. Key properties: Vux, Vuy, MxTop, MxBottom. | `LoadCaseDto.cs` |
| `record` | **LoadCaseResultDto** | Data transfer object carrying LoadCaseResult data. Key properties: CapacityPDisplay, CapacityMxDisplay, CapacityMyDisplay, SlendernessStatus. | `LoadCaseResultDto.cs` |
| `record` | **MemberGeometryInputDto** | Data transfer object carrying MemberGeometryInput data. | `Ec2SlendernessDtos.cs` |
| `record` | **MmDiagramDto** | Data transfer object carrying MmDiagram data. | `MmDiagramDto.cs` |
| `record` | **MxMyDiagramDto** | Data transfer object carrying MxMyDiagram data. | `MxMyDiagramDto.cs` |
| `record` | **PmAngleDiagramDto** | Data transfer object carrying PmAngleDiagram data. Key properties: ReferenceLines, NominalCapacityPoints, ReducedCapacityPoints, SpecialCapacityPoints. | `PmAngleDiagramDto.cs` |
| `record` | **PmChartInsetFigureDto** | Data transfer object carrying PmChartInsetFigure data. | `PmChartInsetFigureDto.cs` |
| `record` | **PmChartInsetSelectedStateDto** | Data transfer object carrying PmChartInsetSelectedState data. | `PmChartInsetFigureDto.cs` |
| `record` | **PmDiagramDto** | Data transfer object carrying PmDiagram data. | `PmDiagramDto.cs` |
| `record` | **PmValidationReportDto** | Data transfer object carrying PmValidationReport data. | `PmValidationReportDto.cs` |
| `record` | **PmmSurfaceDto** | Data transfer object carrying PmmSurface data. Key properties: SpecialCapacityPoints, XAxisLabel, YAxisLabel, ZAxisLabel. | `PmmSurfaceDto.cs` |
| `record` | **RebarComplianceResult** | /// Collected reinforcement code-compliance check results for one column section. /// Covers longitudinal reinforcement (§9.5.1-9.5.2) and transverse links (§9.5.3). ///. Key properties: AllPass, FailCount. | `RebarComplianceResult.cs` |
| `record` | **RebarCoordinateDto** | Data transfer object carrying RebarCoordinate data. | `RebarCoordinateDto.cs` |
| `record` | **RebarLayoutInputDto** | Data transfer object carrying RebarLayoutInput data. Key properties: StirrupDiameterMm. | `RebarLayoutInputDto.cs` |
| `enum` | **RebarLayoutType** | Enumeration defining states/types for RebarLayoutType. | `RebarLayoutType.cs` |
| `record` | **RebarSideInputDto** | Data transfer object carrying RebarSideInput data. | `RebarSideInputDto.cs` |
| `record` | **ReportFormulaBlock** | Represents the ReportFormulaBlock record. | `ReportFormulaBlock.cs` |
| `class` | **ReportVerificationPointRow** | Data structure representing a row for ReportVerificationPoint. Key properties: Index, PointCode, PointName, StrainDescription. | `ReportVerificationPointRow.cs` |
| `record` | **SevenPointValidationRowDto** | Data transfer object carrying SevenPointValidationRow data. | `SevenPointValidationRowDto.cs` |
| `record` | **ShearResultDto** | /// Display-ready shear check result for one load case, values converted to the user's unit system. /// Force values in the user's ForceUnit; lengths and stresses remain in mm / MPa. ///. Key properties: GoverningStatus, GoverningUtilisation, HasDemand, HasLinks. | `ShearResultDto.cs` |
| `record` | **ValidationIssue** | Represents the ValidationIssue record. | `ValidationIssue.cs` |
| `record` | **ValidationResultDto** | Data transfer object carrying ValidationResult data. Key properties: Valid. | `ValidationResultDto.cs` |
| `enum` | **ValidationSeverity** | Enumeration defining states/types for ValidationSeverity. | `ValidationIssue.cs` |

### DTOs/Etabs

| Type | Name | Description | File |
|---|---|---|---|
| `enum` | **EtabsBindingHealthStatus** | Enumeration defining states/types for EtabsBindingHealthStatus. | `EtabsBindingHealthStatus.cs` |
| `class` | **EtabsBindingValidationResult** | Encapsulates the result of EtabsBindingValidation operations. Key properties: ModelChanged, CurrentModelPath, CurrentModelName, ObjectHealthList. | `EtabsBindingValidationResult.cs` |
| `record` | **EtabsColumnImportDto** | Data transfer object carrying EtabsColumnImport data. | `EtabsColumnImportDto.cs` |
| `class` | **EtabsColumnObjectKey** | Represents the EtabsColumnObjectKey class. Key properties: Story, Label, UniqueName, X. | `EtabsColumnObjectKey.cs` |
| `record` | **EtabsConnectionResultDto** | Data transfer object carrying EtabsConnectionResult data. | `EtabsConnectionResultDto.cs` |
| `class` | **EtabsDesignForceRecord** | Represents the EtabsDesignForceRecord class. Key properties: SourceTableKey. | `EtabsDesignForceRecord.cs` |
| `class` | **EtabsDesignForceTable** | Represents the EtabsDesignForceTable class. Key properties: TableKey, TableVersion, FieldKeys, Records. | `EtabsDesignForceTable.cs` |
| `record` | **EtabsForceCacheBuildResult** | Encapsulates the result of EtabsForceCacheBuild operations. | `EtabsForceCacheBuildResult.cs` |
| `record` | **EtabsForceCacheQuery** | Represents the EtabsForceCacheQuery record. | `EtabsForceCacheQuery.cs` |
| `class` | **EtabsForceRefreshPreview** | Represents the EtabsForceRefreshPreview class. Key properties: SectionsAffected, LoadCombinationsSelected, ExistingLoadRows, NewLoadRows. | `EtabsForceRefreshPreview.cs` |
| `class` | **EtabsForceRefreshRequest** | Represents the EtabsForceRefreshRequest class. Key properties: Bindings, SelectedLoadCombinations, ForceSource, ImportTop. | `EtabsForceRefreshRequest.cs` |
| `record` | **EtabsForceResultDto** | Data transfer object carrying EtabsForceResult data. | `EtabsForceResultDto.cs` |
| `class` | **EtabsForceRowChange** | Represents the EtabsForceRowChange class. Key properties: LoadCaseName, Location, OldP, NewP. | `EtabsForceRowChange.cs` |
| `enum` | **EtabsForceRowChangeStatus** | Enumeration defining states/types for EtabsForceRowChangeStatus. | `EtabsForceRowChange.cs` |
| `class` | **EtabsImportMetadataDto** | Data transfer object carrying EtabsImportMetadata data. Key properties: SourceModelPath, SourceModelName, EtabsObjectName, PierName. | `EtabsImportMetadataDto.cs` |
| `record` | **EtabsImportSummaryDto** | Data transfer object carrying EtabsImportSummary data. | `EtabsImportSummaryDto.cs` |
| `enum` | **EtabsImportedObjectType** | Enumeration defining states/types for EtabsImportedObjectType. | `EtabsImportedObjectType.cs` |
| `class` | **EtabsIrregularBoundaryDto** | Data transfer object carrying EtabsIrregularBoundary data. Key properties: ClockwisePolylines, OpeningPolylines, PierLabel, StoryName. | `EtabsIrregularBoundaryDto.cs` |
| `class` | **EtabsModelFingerprint** | Represents the EtabsModelFingerprint class. Key properties: ModelFilePath, ModelFileName, ImportedAt. | `EtabsModelFingerprint.cs` |
| `record` | **EtabsModelInfoDto** | Data transfer object carrying EtabsModelInfo data. | `EtabsModelInfoDto.cs` |
| `class` | **EtabsObjectBindingHealth** | Represents the EtabsObjectBindingHealth class. Key properties: SectionName, ObjectKey, Status, SuggestedRemapKey. | `EtabsBindingValidationResult.cs` |
| `class` | **EtabsPierObjectKey** | Represents the EtabsPierObjectKey class. Key properties: Story, PierName, X1, Y1. | `EtabsPierObjectKey.cs` |
| `record` | **EtabsPierShellSegmentDto** | Data transfer object carrying EtabsPierShellSegment data. | `EtabsPierShellSegmentDto.cs` |
| `enum` | **EtabsResultState** | /// Describes why a section result is outdated or unavailable, giving the UI /// enough context to show a specific message rather than a generic "Outdated" label. /// | `EtabsResultState.cs` |
| `class` | **EtabsSectionBinding** | Represents the EtabsSectionBinding class. Key properties: MbColumnSectionId, MbColumnSectionName, ObjectType, ForceSource. | `EtabsSectionBinding.cs` |
| `record` | **EtabsSectionMappingDto** | Data transfer object carrying EtabsSectionMapping data. | `EtabsSectionMappingDto.cs` |
| `enum` | **EtabsSectionRefreshAction** | Enumeration defining states/types for EtabsSectionRefreshAction. | `EtabsSectionRefreshSummary.cs` |
| `class` | **EtabsSectionRefreshSummary** | Represents the EtabsSectionRefreshSummary class. Key properties: SectionName, Status, OldRowCount, NewRowCount. | `EtabsSectionRefreshSummary.cs` |
| `class` | **EtabsSourceObjectRefDto** | Data transfer object carrying EtabsSourceObjectRef data. Key properties: ObjectName, Label, Story, SectionName. | `EtabsTierImportMetadataDto.cs` |
| `class` | **EtabsTierImportMetadataDto** | Data transfer object carrying EtabsTierImportMetadata data. Key properties: SourceModelPath, SourceModelName, ImportedUnits, MBColumnUnitsAtImport. | `EtabsTierImportMetadataDto.cs` |
| `class` | **ImportedEtabsForceDatabase** | Represents the ImportedEtabsForceDatabase class. Key properties: ModelFilePath, ModelName, ImportedAt. | `ImportedEtabsForceDatabase.cs` |
| `enum` | **MbColumnForceSourceMode** | Enumeration defining states/types for MbColumnForceSourceMode. | `MbColumnForceSourceMode.cs` |
| `class` | **MbColumnMappedForceRow** | Data structure representing a row for MbColumnMappedForce. Key properties: MbColumnSectionName, LoadCaseName, ObjectType, Story. | `MbColumnMappedForceRow.cs` |
| `class` | **MbColumnSectionImport** | Represents the MbColumnSectionImport class. Key properties: SectionName, SelectedItems. | `MbColumnSectionImport.cs` |
| `class` | **MbColumnSectionImportItem** | Represents the MbColumnSectionImportItem class. Key properties: ObjectType, Story, Label, Key. | `MbColumnSectionImportItem.cs` |
| `enum` | **value** | Enumeration defining states/types for value. Key properties: DatabaseUnits, ColumnForces, PierForces, ColumnElementForces. | `ImportedEtabsForceDatabase.cs` |

### DTOs/Etabs/Forces

| Type | Name | Description | File |
|---|---|---|---|
| `record` | **EtabsDesignForceRowDto** | /// Raw design force row from the ETABS concrete design module. /// Already post-processed by ETABS — combo name and station/location are preserved /// as source metadata so they can be tracked through to DemandCase. /// | `EtabsDesignForceRowDto.cs` |
| `record` | **EtabsElementForceRowDto** | /// Raw element force row from ETABS analysis output (frame/pier station forces). /// P, M2, M3, V2, V3 are in ETABS axis convention — mapping to MBColumn axes /// is done by EtabsForceComponentMapper in Infrastructure. /// | `EtabsElementForceRowDto.cs` |
| `record` | **EtabsForceImportRequestDto** | Data transfer object carrying EtabsForceImportRequest data. | `EtabsForceImportRequestDto.cs` |
| `record` | **EtabsForceImportResultDto** | Data transfer object carrying EtabsForceImportResult data. | `EtabsForceImportResultDto.cs` |
| `enum` | **EtabsForceLocationType** | Enumeration defining states/types for EtabsForceLocationType. | `EtabsForceLocationType.cs` |
| `record` | **EtabsForceSourceMetadataDto** | /// Metadata attached to each demand case that records exactly where its forces came from. /// Stored alongside DemandCase so force refresh can detect what changed. /// | `EtabsForceSourceMetadataDto.cs` |
| `enum` | **EtabsForceSourceType** | /// Distinguishes whether forces originate from raw analysis output (element forces) /// or from the ETABS concrete design module (design forces). /// Integer values are pinned to match MbColumnForceSourceMode to prevent silent /// wrong-branch errors if code ever casts between the two types. /// | `EtabsForceSourceType.cs` |
| `record` | **EtabsForceUnitContextDto** | Carries the unit system that the ETABS force values were read in. | `EtabsForceUnitContextDto.cs` |
| `record` | **EtabsMappedLoadCaseDto** | /// MBColumn-ready demand row produced by the ETABS force mapper. /// This is the common output regardless of whether the source was element forces /// or design forces — source metadata is preserved so the UI and DB can display it. /// | `EtabsMappedLoadCaseDto.cs` |

### DTOs/ImportExport

| Type | Name | Description | File |
|---|---|---|---|
| `record` | **DxfRebarImportItem** | Represents the DxfRebarImportItem record. | `DxfRebarImportItem.cs` |
| `record` | **DxfSectionImportRequest** | Represents the DxfSectionImportRequest record. | `DxfSectionImportRequest.cs` |
| `class` | **DxfSectionImportResult** | Encapsulates the result of DxfSectionImport operations. Key properties: BoundaryVertices, Rebars, Warnings, Errors. | `DxfSectionImportResult.cs` |
| `record` | **IrregularBoundaryPointCsvDto** | Data transfer object carrying IrregularBoundaryPointCsv data. | `IrregularBoundaryPointCsvDto.cs` |
| `record` | **IrregularRebarCsvDto** | Data transfer object carrying IrregularRebarCsv data. | `IrregularRebarCsvDto.cs` |

### DTOs/Persistence

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ColumnInputSnapshot** | Represents the ColumnInputSnapshot class. Key properties: UnitSystem, DesignCode, Ec2Solver, IntegrationMethod. | `ColumnInputSnapshot.cs` |
| `class` | **SnapshotBoundaryPoint** | Represents the SnapshotBoundaryPoint class. Key properties: PtIndex, X, Y. | `ColumnInputSnapshot.cs` |
| `class` | **SnapshotLoadCase** | Represents the SnapshotLoadCase class. Key properties: Id, Label, OriginalLoadCaseName, SourceObjectName. | `ColumnInputSnapshot.cs` |
| `class` | **SnapshotRebar** | Represents the SnapshotRebar class. Key properties: RebarIndex, X, Y, BarSize. | `ColumnInputSnapshot.cs` |

### Interfaces

| Type | Name | Description | File |
|---|---|---|---|
| `interface` | **IPmValidationReportService** | Provides service logic and operations for IPmValidationReport. | `IPmValidationReportService.cs` |

### Interfaces/Etabs

| Type | Name | Description | File |
|---|---|---|---|
| `interface` | **IEtabsDesignForceImportGateway** | Implemented in Infrastructure.Etabs — Application has no ETABSv1 dependency. | `IEtabsDesignForceImportGateway.cs` |
| `interface` | **IEtabsElementForceImportGateway** | Implemented in Infrastructure.Etabs — Application has no ETABSv1 dependency. | `IEtabsElementForceImportGateway.cs` |
| `interface` | **for** | Pure gateway | `IEtabsDesignForceImportGateway.cs` |
| `interface` | **for** | Pure gateway | `IEtabsElementForceImportGateway.cs` |

### Mappers

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **IrregularSectionMapper** | Maps data structures for IrregularSection. Key methods: ValidateAndMap. | `IrregularSectionMapper.cs` |

### Reports/Builders

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **CalculationReportBuilder** | /// Builds a complete ReportData with all 10 report sections /// from project metadata and a CalculationResultDto. ///. Key methods: Build. | `CalculationReportBuilder.cs` |
| `class` | **CircularSevenPointBuilder** | /// Generates the 7-point independent verification for circular sections /// using the circular compression segment method. /// Correct centroid formula: ybar = (2/3)(R²-y_a²)^(3/2) / Aseg ///. Key methods: Build. | `CircularSevenPointBuilder.cs` |
| `class` | **ConclusionSectionBuilder** | Represents the ConclusionSectionBuilder class. Key methods: Build. | `ConclusionSectionBuilder.cs` |
| `class` | **DemandCaseSectionBuilder** | Represents the DemandCaseSectionBuilder class. Key methods: BuildAppliedDemand, BuildDemandResults. | `DemandCaseSectionBuilder.cs` |
| `class` | **GeometryMaterialSectionBuilder** | Represents the GeometryMaterialSectionBuilder class. Key methods: Build. | `GeometryMaterialSectionBuilder.cs` |
| `class` | **PmmAngleSweepSectionBuilder** | Represents the PmmAngleSweepSectionBuilder class. Key methods: Build. | `PmmAngleSweepSectionBuilder.cs` |
| `class` | **PmmMethodologySectionBuilder** | Represents the PmmMethodologySectionBuilder class. Key methods: Build. | `PmmMethodologySectionBuilder.cs` |
| `class` | **PmmSummarySectionBuilder** | Represents the PmmSummarySectionBuilder class. Key methods: Build. | `PmmSummarySectionBuilder.cs` |
| `class` | **ProjectInfoSectionBuilder** | Represents the ProjectInfoSectionBuilder class. Key methods: Build. | `ProjectInfoSectionBuilder.cs` |
| `class` | **RebarComplianceSectionBuilder** | /// Builds Section 3 — "Reinforcement Code Compliance" — covering: /// EC2 EN 1992-1-1:2004 §9.5.1/9.5.2 — longitudinal reinforcement limits /// EC2 EN 1992-1-1:2004 §9.5.3 — transverse link detailing /// ACI 318-19 §10.6/§25.7.2 — stub (TODO) ///. Key methods: Build. | `RebarComplianceSectionBuilder.cs` |
| `class` | **RectangularSevenPointBuilder** | Represents the RectangularSevenPointBuilder class. Key methods: BuildTheta0, BuildTheta90. | `RectangularSevenPointBuilder.cs` |
| `class` | **ShearCheckSectionBuilder** | /// Builds Section 6 — "Shear Check (EC2 §6.2)" — following the two-step flow /// from the EC2 column design procedure (analogous to ACI §22.5 / §22.6). ///. Key methods: Build. | `ShearCheckSectionBuilder.cs` |

### Reports/Interfaces

| Type | Name | Description | File |
|---|---|---|---|
| `interface` | **ICalculationReportBuilder** | Defines the contract for ICalculationReportBuilder. | `ICalculationReportBuilder.cs` |
| `interface` | **IReportRenderer** | Defines the contract for IReportRenderer. | `IReportRenderer.cs` |

### Reports/Models

| Type | Name | Description | File |
|---|---|---|---|
| `record` | **DiagramBlock** | Represents the DiagramBlock record. | `ReportBlock.cs` |
| `record` | **DividerBlock** | Represents the DividerBlock record. | `ReportBlock.cs` |
| `record` | **FormulaBlock** | Represents the FormulaBlock record. | `ReportBlock.cs` |
| `record` | **FormulaStep** | Represents the FormulaStep record. | `FormulaStep.cs` |
| `record` | **HeadingBlock** | Represents the HeadingBlock record. | `ReportBlock.cs` |
| `record` | **ImageBlock** | Represents the ImageBlock record. | `ReportBlock.cs` |
| `record` | **NoteBlock** | Represents the NoteBlock record. | `ReportBlock.cs` |
| `record` | **PageBreakBlock** | Represents the PageBreakBlock record. | `ReportBlock.cs` |
| `record` | **ParagraphBlock** | Represents the ParagraphBlock record. | `ReportBlock.cs` |
| `record` | **RebarContributionRow** | Data structure representing a row for RebarContribution. | `RebarContributionRow.cs` |
| `record` | **ReportBlock** | Represents the ReportBlock record. Key properties: KeepTogether, CanSplitByRows, EstimatedHeight. | `ReportBlock.cs` |
| `record` | **ReportData** | Represents the ReportData record. Key properties: ProjectName, GroupName, DesignTierName, GeneratedAt. | `ReportData.cs` |
| `record` | **ReportSection** | Represents the ReportSection record. | `ReportSection.cs` |
| `record` | **SectionPreviewBlock** | Represents the SectionPreviewBlock record. Key properties: SectionWidth, SectionHeight, Cover, UnitSystem. | `SectionPreviewBlock.cs` |
| `record` | **SteelTableBlock** | Represents the SteelTableBlock record. | `ReportBlock.cs` |
| `record` | **SummaryBoxBlock** | Represents the SummaryBoxBlock record. | `ReportBlock.cs` |
| `record` | **TableBlock** | Represents the TableBlock record. | `ReportBlock.cs` |

### Root

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **DependencyInjection** | Represents the DependencyInjection class. Key methods: AddApplication. | `DependencyInjection.cs` |

### Services

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ColumnCalculationService** | Provides service logic and operations for ColumnCalculation. Key methods: Calculate. | `ColumnCalculationService.cs` |
| `record` | **ColumnRecord** | Represents the ColumnRecord record. | `IProjectService.cs` |
| `class` | **CompressionZonePolygonBuilder** | Represents the CompressionZonePolygonBuilder class. Key methods: ClipByNeutralAxis, ClipTensionSideByNeutralAxis. | `CompressionZonePolygonBuilder.cs` |
| `class` | **ControlPointBuilderService** | Provides service logic and operations for ControlPointBuilder. Key methods: Build. | `ControlPointBuilderService.cs` |
| `class` | **ControlPointCsvExportService** | Provides service logic and operations for ControlPointCsvExport. Key methods: Export. | `ControlPointCsvExportService.cs` |
| `class` | **ControlPointPreviewService** | Provides service logic and operations for ControlPointPreview. Key methods: BuildPreview. | `ControlPointPreviewService.cs` |
| `class` | **ControlPointTableBuilderService** | /// Builds the design-code control-point table /// for each of the four principal bending axes: X, Y, -X, -Y. ///. Key methods: Build. | `ControlPointTableBuilderService.cs` |
| `enum` | **CurveAxis** | Enumeration defining states/types for CurveAxis. | `PmCurveBuilderService.cs` |
| `class` | **DiagramDataService** | Provides service logic and operations for DiagramData. Key methods: BuildMm, BuildSurface, BuildPmDiagramRenderData, BuildMmDiagramRenderData. | `DiagramDataService.cs` |
| `class` | **Ec2NominalCurvatureService** | Provides service logic and operations for Ec2NominalCurvature. Key methods: Calculate. | `Ec2NominalCurvatureService.cs` |
| `record` | **GroupRecord** | Represents the GroupRecord record. | `IProjectService.cs` |
| `interface` | **IControlPointCsvExportService** | Provides service logic and operations for IControlPointCsvExport. | `IControlPointCsvExportService.cs` |
| `interface` | **IControlPointPreviewService** | Provides service logic and operations for IControlPointPreview. | `IControlPointPreviewService.cs` |
| `interface` | **IEc2NominalCurvatureService** | Provides service logic and operations for IEc2NominalCurvature. | `Ec2NominalCurvatureService.cs` |
| `interface` | **IIrregularSectionValidationService** | Provides service logic and operations for IIrregularSectionValidation. | `IIrregularSectionValidationService.cs` |
| `interface` | **IProjectService** | Provides service logic and operations for IProject. | `IProjectService.cs` |
| `interface` | **IRebarCoordinateBuilderService** | Provides service logic and operations for IRebarCoordinateBuilder. | `IRebarCoordinateBuilderService.cs` |
| `class` | **InputValidationService** | Provides service logic and operations for InputValidation. Key methods: Validate. | `InputValidationService.cs` |
| `class` | **InteractionSurfaceService** | Provides service logic and operations for InteractionSurface. Key methods: Build. | `InteractionSurfaceService.cs` |
| `class` | **IrregularSectionValidationService** | Provides service logic and operations for IrregularSectionValidation. Key methods: ValidateBoundary, ValidateRebars, TryResolveDiameter. | `IrregularSectionValidationService.cs` |
| `class` | **PmChartInsetBuilderService** | Provides service logic and operations for PmChartInsetBuilder. Key methods: Build. | `PmChartInsetBuilderService.cs` |
| `class` | **PmChartInsetStateResolverService** | Provides service logic and operations for PmChartInsetStateResolver. Key methods: FromLoadCase, FromNavigation, FromCapacityPoint. | `PmChartInsetStateResolverService.cs` |
| `record` | **PmCurveBuildDiagnostics** | Represents the PmCurveBuildDiagnostics record. | `PmCurveBuilderService.cs` |
| `class` | **PmCurveBuilderService** | Provides service logic and operations for PmCurveBuilder. Key methods: BuildPmAngleCurve, BuildPmAngleReferenceLines, BuildPmInteractionDebugCsv, ExportPmInteractionDebugCsv. Key properties: EnableDebugDiagnostics, LastDiagnostics. | `PmCurveBuilderService.cs` |
| `enum` | **PmDebugMomentAxis** | Enumeration defining states/types for PmDebugMomentAxis. | `PmCurveBuilderService.cs` |
| `class` | **PmSevenPointReportMapper** | Maps data structures for PmSevenPointReport. Key methods: Map, FormatOrNa, FormatPctOrNa. | `PmSevenPointReportMapper.cs` |
| `class` | **RatioCheckService** | Provides service logic and operations for RatioCheck. Key methods: Check, CheckBatch. | `RatioCheckService.cs` |
| `class` | **RebarComplianceCheckService** | /// Transverse links (§9.5.3): dsw ≥ max(6, 0.25 dsmax) — §9.5.3(1) minimum link diameter s ≤ min(20 dsmin, bmin, 400) — §9.5.3(3) maximum link spacing gap ≤ 150 mm between restrained bars — §9.5.3(6) /// ACI 318-19 checks (stubs — TODO): 0.01 Ag ≤ Ast ≤ 0.08 Ag — §10.6.1.1 nBars ≥ 4 (ties) / ≥ 6 (spirals) — §10.7.3.1 Tie diameter and spacing — §25.7.2. Key methods: Check. | `RebarComplianceCheckService.cs` |
| `class` | **RebarCoordinateBuilderService** | Provides service logic and operations for RebarCoordinateBuilder. Key methods: Build, BuildCircular. | `RebarCoordinateBuilderService.cs` |
| `class` | **ReportHandCalcService** | /// Independently calculates selected PMM control points using transparent hand-calculation /// formulas and compares results against the solver surface. /// Supports ACI 318 (Whitney rectangular stress block) and EC2 (simplified rectangular block, λ/η). /// Only rectangular sections are supported. ///. Key methods: Build. | `ReportHandCalcService.cs` |
| `class` | **ShearCheckService** | /// Orchestrates the shear capacity check (EC2 §6.2 / ACI §22.5-22.6) for a column section /// against one or more load cases. Capacity is always computed even when VEd = 0. /// | `ShearCheckService.cs` |
| `record` | **SpecialCapacityEntry** | Represents the SpecialCapacityEntry record. | `SpecialCapacityPointsService.cs` |
| `class` | **SpecialCapacityPointsService** | /// Generates five structurally significant capacity points for every neutral-axis angle /// on an interaction surface: max compression, balanced, tension-controlled, pure bending, /// and max tension. The source InteractionSurface is searched/interpolated; no additional /// solver passes are performed. ///. Key methods: Build. | `SpecialCapacityPointsService.cs` |
| `record` | **struct** | Represents the struct record. | `PmCurveBuilderService.cs` |
| `record` | **struct** | Represents the struct record. | `PmCurveBuilderService.cs` |
| `record` | **struct** | Represents the struct record. | `PmCurveBuilderService.cs` |
| `record` | **struct** | Represents the struct record. | `PmCurveBuilderService.cs` |
| `record` | **struct** | Represents the struct record. | `PmCurveBuilderService.cs` |
| `record` | **struct** | Represents the struct record. | `PmCurveBuilderService.cs` |
| `record` | **struct** | Represents the struct record. Key methods: Cross, Length, Normalize, Dot. | `RatioCheckService.cs` |

### Services/Etabs

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **EtabsForceCacheIdentity** | Represents the EtabsForceCacheIdentity class. Key properties: ForceSource, ObjectType, SelectedCombos, Model. | `IEtabsForceCacheStore.cs` |
| `class` | **EtabsForceRefreshResult** | Encapsulates the result of EtabsForceRefresh operations. Key properties: Success, Message, Preview. | `IEtabsForceRefreshService.cs` |
| `class` | **EtabsForceScope** | Represents the EtabsForceScope class. Key properties: Bindings, LoadCombinations, ForceSource, ImportTop. | `IEtabsForceSelectionService.cs` |
| `class` | **EtabsSectionForceFilterService** | Provides service logic and operations for EtabsSectionForceFilter. Key methods: FilterForcesForSection, FindMissingItems. | `EtabsSectionForceFilterService.cs` |
| `interface` | **IEtabsBindingReconciliationService** | Provides service logic and operations for IEtabsBindingReconciliation. | `IEtabsBindingReconciliationService.cs` |
| `interface` | **IEtabsColumnImportService** | Provides service logic and operations for IEtabsColumnImport. | `IEtabsColumnImportService.cs` |
| `interface` | **IEtabsConnectionService** | Provides service logic and operations for IEtabsConnection. | `IEtabsConnectionService.cs` |
| `interface` | **IEtabsDesignForceImportService** | Provides service logic and operations for IEtabsDesignForceImport. | `IEtabsDesignForceImportService.cs` |
| `interface` | **IEtabsForceCacheResolver** | Defines the contract for IEtabsForceCacheResolver. | `IEtabsForceCacheResolver.cs` |
| `interface` | **IEtabsForceCacheService** | Provides service logic and operations for IEtabsForceCache. | `IEtabsForceCacheService.cs` |
| `interface` | **IEtabsForceCacheStore** | Defines the contract for IEtabsForceCacheStore. | `IEtabsForceCacheStore.cs` |
| `interface` | **IEtabsForceChangeDetector** | Defines the contract for IEtabsForceChangeDetector. | `IEtabsForceChangeDetector.cs` |
| `interface` | **IEtabsForceImportService** | Provides service logic and operations for IEtabsForceImport. | `IEtabsForceImportService.cs` |
| `interface` | **IEtabsForceMapper** | Maps data structures for IEtabsForce. | `IEtabsForceMapper.cs` |
| `interface` | **IEtabsForceRefreshService** | Provides service logic and operations for IEtabsForceRefresh. | `IEtabsForceRefreshService.cs` |
| `interface` | **IEtabsForceSelectionService** | Provides service logic and operations for IEtabsForceSelection. | `IEtabsForceSelectionService.cs` |
| `interface` | **IEtabsPierShellImportService** | Provides service logic and operations for IEtabsPierShellImport. | `IEtabsPierShellImportService.cs` |
| `interface` | **IEtabsResultStateService** | Provides service logic and operations for IEtabsResultState. | `IEtabsResultStateService.cs` |
| `interface` | **IEtabsSectionForceFilterService** | Provides service logic and operations for IEtabsSectionForceFilter. | `IEtabsSectionForceFilterService.cs` |
| `interface` | **IEtabsSectionImportMapper** | Maps data structures for IEtabsSectionImport. | `IEtabsSectionImportMapper.cs` |
| `interface` | **IImportedEtabsForceCache** | Defines the contract for IImportedEtabsForceCache. | `IImportedEtabsForceCache.cs` |
| `interface` | **IIrregularPierGeometryBuilder** | Defines the contract for IIrregularPierGeometryBuilder. | `IIrregularPierGeometryBuilder.cs` |

### Services/Geometry

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **PolygonGeometry** | Represents the PolygonGeometry class. Key methods: SignedArea, Area, Centroid, IsClockwise. | `PolygonGeometry.cs` |

### Services/ImportExport

| Type | Name | Description | File |
|---|---|---|---|
| `record` | **DxfCircleEntity** | Represents the DxfCircleEntity record. | `DxfImportService.cs` |
| `record` | **DxfEntity** | Represents the DxfEntity record. | `DxfImportService.cs` |
| `class` | **DxfExportService** | Provides service logic and operations for DxfExport. Key methods: Export. | `DxfExportService.cs` |
| `record` | **DxfGenericEntity** | Represents the DxfGenericEntity record. | `DxfImportService.cs` |
| `class` | **DxfImportService** | Provides service logic and operations for DxfImport. Key methods: GetLayerNames, ImportSection. | `DxfImportService.cs` |
| `record` | **DxfPolylineEntity** | Represents the DxfPolylineEntity record. | `DxfImportService.cs` |
| `interface` | **IDxfImportService** | Provides service logic and operations for IDxfImport. | `IDxfImportService.cs` |
| `interface` | **IIrregularSectionCsvService** | Provides service logic and operations for IIrregularSectionCsv. | `IIrregularSectionCsvService.cs` |
| `class` | **IrregularSectionCsvService** | Provides service logic and operations for IrregularSectionCsv. Key methods: ImportBoundary, ImportRebars, ParseBoundary, ParseRebars. | `IrregularSectionCsvService.cs` |
| `record` | **struct** | Represents the struct record. | `DxfImportService.cs` |

### Validators

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ColumnInputValidator** | Validation logic for ColumnInput. Key methods: Validate. | `ColumnInputValidator.cs` |
| `class` | **LoadCaseValidator** | Validation logic for LoadCase. Key methods: Validate. | `LoadCaseValidator.cs` |
| `class` | **MaterialValidator** | Validation logic for Material. Key methods: Validate. | `MaterialValidator.cs` |
| `class` | **RebarValidator** | Validation logic for Rebar. Key methods: Validate. | `RebarValidator.cs` |
| `class` | **SectionGeometryValidator** | Validation logic for SectionGeometry. Key methods: Validate. | `SectionGeometryValidator.cs` |
| `class` | **SlendernessValidator** | Validation logic for Slenderness. Key methods: Validate. | `SlendernessValidator.cs` |
| `class` | **ValidationContext** | /// Collects validation errors during a validation pass. /// Replaces the raw List&lt;string&gt; pattern so each error carries field and row context. /// Only errors are collected — warnings are not surfaced by ValidationResultDto and /// would be silently dropped, so Warning() is intentionally absent here. ///. Key methods: Error, ToResult. Key properties: Issues, HasErrors. | `ValidationContext.cs` |
| `class` | **ValidatorHelpers** | Represents the ValidatorHelpers class. Key methods: GetActiveCasesOrFallback. | `ValidatorHelpers.cs` |

## MBColumn.Domain

### Entities

| Type | Name | Description | File |
|---|---|---|---|
| `record` | **CircularSection** | Represents the CircularSection record. Key properties: RadiusMm, WidthMm, HeightMm, AreaMm2. | `CircularSection.cs` |
| `record` | **ColumnSection** | Represents the ColumnSection record. | `ColumnSection.cs` |
| `record` | **ConcreteMaterial** | Represents the ConcreteMaterial record. | `ConcreteMaterial.cs` |
| `record` | **ControlPoint** | Represents the ControlPoint record. Key properties: IsSpecialPoint, CpNumber. | `ControlPoint.cs` |
| `record` | **DiagramControlPointSet** | Represents the DiagramControlPointSet record. Key properties: SpecialCapacityPoints. | `DiagramControlPointSet.cs` |
| `record` | **InteractionPoint** | Represents the InteractionPoint record. Key properties: ThetaRad, IsSpecialPoint, SpecialPointType, DesignP. | `InteractionPoint.cs` |
| `record` | **InteractionSurface** | Represents the InteractionSurface record. Key properties: RowLength. | `InteractionSurface.cs` |
| `record` | **IrregularSection** | Represents the IrregularSection record. Key properties: WidthMm, HeightMm, AreaMm2. | `IrregularSection.cs` |
| `record` | **LoadDemand** | Represents the LoadDemand record. | `LoadDemand.cs` |
| `record` | **NominalCapacity** | Represents the NominalCapacity record. | `InteractionPoint.cs` |
| `record` | **RatioResult** | Encapsulates the result of Ratio operations. Key properties: DemandMagnitude, CapacityMagnitude, CapacityPn, CapacityMnx. | `RatioResult.cs` |
| `record` | **Rebar** | Represents the Rebar record. | `Rebar.cs` |
| `record` | **RebarLayout** | Represents the RebarLayout record. | `RebarLayout.cs` |
| `record` | **RectangularSection** | Represents the RectangularSection record. Key properties: WidthMm, HeightMm, AreaMm2. | `RectangularSection.cs` |
| `record` | **ReducedCapacity** | Represents the ReducedCapacity record. | `InteractionPoint.cs` |
| `record` | **ShearCheckResult** | /// Result of an EC2 §6.2 (or ACI §22.5/22.6) shear capacity check in both principal directions. /// VEd positive by convention. All forces in Newtons, lengths in mm, stresses in MPa. /// | `ShearCheckResult.cs` |
| `record` | **ShearLinkReinforcement** | /// Describes the transverse link (stirrup) reinforcement geometry used in shear checks. /// TotalLegsX = links resisting shear in the X direction (legs spanning in the Y direction). /// TotalLegsY = links resisting shear in the Y direction (legs spanning in the X direction). /// For circular sections set IsCircularHoop = true and provide HoopCentrelineDiameterMm (D'). ///. Key properties: HoopAhMm2. | `ShearLinkReinforcement.cs` |
| `record` | **SteelMaterial** | Represents the SteelMaterial record. | `SteelMaterial.cs` |
| `record` | **StrainState** | Represents the StrainState record. | `InteractionPoint.cs` |
| `record` | **struct** | Represents the struct record. | `Point2D.cs` |
| `record` | **struct** | Represents the struct record. Key properties: Width, Height, MaxDimension, CenterX. | `Rect2D.cs` |

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
| `enum` | **RebarSetLibraryType** | Enumeration defining states/types for RebarSetLibraryType. | `RebarSetLibraryType.cs` |
| `enum` | **RebarUnitType** | Enumeration defining states/types for RebarUnitType. | `RebarUnitType.cs` |
| `enum` | **SectionIntegrationMethod** | Enumeration defining states/types for SectionIntegrationMethod. | `SectionIntegrationMethod.cs` |
| `enum` | **SectionShapeType** | Enumeration defining states/types for SectionShapeType. | `SectionShapeType.cs` |
| `enum` | **StressUnit** | Enumeration defining states/types for StressUnit. | `StressUnit.cs` |
| `enum` | **UnitSystem** | Enumeration defining states/types for UnitSystem. | `UnitSystem.cs` |

### Interfaces

| Type | Name | Description | File |
|---|---|---|---|
| `interface` | **ICircularInteractionSolver** | Defines the contract for ICircularInteractionSolver. | `ICircularInteractionSolver.cs` |
| `interface` | **IControlPointBuilder** | Defines the contract for IControlPointBuilder. | `IControlPointBuilder.cs` |
| `interface` | **IDesignCodeService** | Provides service logic and operations for IDesignCode. | `IDesignCodeService.cs` |
| `interface` | **IDesignCodeServiceFactory** | Defines the contract for IDesignCodeServiceFactory. | `IDesignCodeServiceFactory.cs` |
| `interface` | **IInteractionSolver** | Defines the contract for IInteractionSolver. | `IInteractionSolver.cs` |
| `interface` | **IInteractionSolverFactory** | Defines the contract for IInteractionSolverFactory. | `IInteractionSolverFactory.cs` |
| `interface` | **IIrregularInteractionSolver** | Defines the contract for IIrregularInteractionSolver. | `IIrregularInteractionSolver.cs` |
| `interface` | **IRatioCheckService** | Provides service logic and operations for IRatioCheck. | `IRatioCheckService.cs` |
| `interface` | **IRebarDatabase** | Defines the contract for IRebarDatabase. | `IRebarDatabase.cs` |
| `interface` | **IShearDesignService** | /// Code-specific shear design check for a rectangular (or circular) column cross-section. /// Implementations: EC2 §6.2, ACI §22.5/22.6. /// | `IShearDesignService.cs` |
| `interface` | **IShearDesignServiceFactory** | /// Returns the code-specific IShearDesignService for a given design code. /// Returns null when the code's shear check is not yet implemented. /// | `IShearDesignServiceFactory.cs` |
| `interface` | **IUnitConversionService** | Provides service logic and operations for IUnitConversion. | `IUnitConversionService.cs` |
| `record` | **RebarDefinition** | Represents the RebarDefinition record. | `IRebarDatabase.cs` |

## MBColumn.Infrastructure

### DesignCodes

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **Aci318DesignCodeService** | Provides service logic and operations for Aci318DesignCode. Key methods: ConcreteUltimateStrain, ConcretePeakStrain, ConcreteParabolicExponent, ConcreteEffectiveStrengthFactor. Key properties: ConcreteStressBlockFactor, AlphaCc, UseLetterControlPoints, SupportsNominalReferenceCurve. | `Aci318DesignCodeService.cs` |
| `class` | **Aci318ShearDesignService** | ACI 318-19 shear capacity check — PLACEHOLDER. Key methods: Check. | `Aci318ShearDesignService.cs` |
| `record` | **CircularShearInput** | Represents the CircularShearInput record. | `EurocodeCircularColumnShearCalculator.cs` |
| `record` | **CircularShearResult** | Encapsulates the result of CircularShear operations. | `EurocodeCircularColumnShearCalculator.cs` |
| `class` | **DesignCodeServiceFactory** | Represents the DesignCodeServiceFactory class. Key methods: Get. | `DesignCodeServiceFactory.cs` |
| `class` | **Ec2DesignCodeService** | /// Eurocode 2 (EN 1992-1-1:2004) implementation of IDesignCodeService. /// Material partial factors: γc = 1.5, γs = 1.15 (Table 2.1N). /// Strength coefficient: αcc = 0.85 (Singapore/UK National Annex, clause 3.1.6(1)P). /// Concrete strain limits and parabolic parameters follow Table 3.1 with /// piecewise-linear interpolation for 50 MPa &lt; fck ≤ 90 MPa. ///. Key methods: ConcreteUltimateStrain, ConcretePeakStrain, ConcreteParabolicExponent, ConcreteRectangularUltimateStrain. Key properties: ConcreteStressBlockFactor, EpsilonUd, AlphaCc, UseLetterControlPoints. | `Ec2DesignCodeService.cs` |
| `class` | **Ec2ShearDesignService** | /// Effective depth (Fix 1 — from real geometry, not a fixed 60 mm): d_eff = section_dim − cover_nominal − link_dia − main_bar_dia / 2 /// Sign convention (b × h section): VEdX → bw = h, d = b − cover_eff, legs = TotalLegsX VEdY → bw = b, d = h − cover_eff, legs = TotalLegsY /// Circular: Caller passes bMm = 0.8 D for VRd,c/VRd,max and hMm = D. VRd,s uses the Orr-Bath circular hoop model: VRd,s = (π/2) · (Ah/s) · D' · fywd · cot θ. Internal diameter ties are ignored in VRd,s. Key methods: Check. | `Ec2ShearDesignService.cs` |
| `class` | **EurocodeCircularColumnShearCalculator** | Represents the EurocodeCircularColumnShearCalculator class. Key methods: Calculate. | `EurocodeCircularColumnShearCalculator.cs` |
| `class` | **ShearDesignServiceFactory** | Represents the ShearDesignServiceFactory class. Key methods: Get. | `ShearDesignServiceFactory.cs` |
| `record` | **struct** | Represents the struct record. | `Ec2ShearDesignService.cs` |

### Etabs

| Type | Name | Description | File |
|---|---|---|---|
| `record` | **AreaRecord** | Represents the AreaRecord record. | `EtabsPierShellImportService.cs` |
| `class` | **AreaScanCache** | Represents the AreaScanCache class. Key methods: GetOrFetchThickness. | `EtabsPierShellImportService.cs` |
| `class` | **EtabsBindingReconciliationService** | Provides service logic and operations for EtabsBindingReconciliation. Key methods: ValidateBindings, ReconcileColumnObject, ReconcilePierObject. | `EtabsBindingReconciliationService.cs` |
| `class` | **EtabsColumnImportService** | Provides service logic and operations for EtabsColumnImport. Key methods: GetCandidateColumns, GetLoadCombinations. | `EtabsColumnImportService.cs` |
| `class` | **EtabsConnectionService** | Provides service logic and operations for EtabsConnection. Key methods: ConnectToRunningEtabs, Disconnect. Key properties: IsConnected. | `EtabsConnectionService.cs` |
| `class` | **EtabsDesignForceImportService** | /// Preloads raw Design Forces - Columns and Design Forces - Piers tables from ETABS /// into ImportedEtabsForceDatabase without filtering or unit conversion, /// so the data can later be parsed on demand by the Force Filter without additional COM calls. ///. Key methods: ImportDesignForces, HasDesignResults, LoadColumnElementForcesTable, LoadPierElementForcesTable. | `EtabsDesignForceImportService.cs` |
| `class` | **EtabsForceCacheResolver** | /// Resolves the correct cached force rows by source mode and object type. /// Design Forces use the preloaded ImportedEtabsForceDatabase. /// Element Forces require ETABS connection (live COM) and are not pre-cached. ///. Key methods: Resolve, HasData. | `EtabsForceCacheResolver.cs` |
| `class` | **EtabsForceCacheService** | Provides service logic and operations for EtabsForceCache. Key methods: Build, Query, Clear, Dispose. Key properties: IsBuilt, StatusText. | `EtabsForceCacheService.cs` |
| `class` | **EtabsForceChangeDetector** | Represents the EtabsForceChangeDetector class. Key methods: CompareSectionForces. | `EtabsForceChangeDetector.cs` |
| `class` | **EtabsForceImportService** | Provides service logic and operations for EtabsForceImport. Key methods: GetForces, GetPierForces, GetElementForces, GetPierElementForces. | `EtabsForceImportService.cs` |
| `class` | **EtabsForceMapper** | Maps data structures for EtabsForce. Key methods: MapColumnForces, MapPierForces, ToLoadCases. | `EtabsForceMapper.cs` |
| `class` | **EtabsForceRefreshService** | Provides service logic and operations for EtabsForceRefresh. Key methods: CheckResultState, RunEtabsAnalysis, RunEtabsDesign, BuildPreview. | `EtabsForceRefreshService.cs` |
| `class` | **EtabsForceSelectionService** | Provides service logic and operations for EtabsForceSelection. Key methods: BuildColumnScope. | `EtabsForceSelectionService.cs` |
| `class` | **EtabsPierShellImportService** | Provides service logic and operations for EtabsPierShellImport. Key methods: GetStoryNames, GetSegments. | `EtabsPierShellImportService.cs` |
| `class` | **EtabsResultStateService** | Provides service logic and operations for EtabsResultState. Key methods: CheckElementForceAvailability, CheckDesignForceAvailability. | `EtabsResultStateService.cs` |
| `class` | **ImportedEtabsForceCache** | /// In-memory singleton cache for the raw ETABS design force database preloaded during Import ETABS. /// The cache is invalidated whenever the model file path changes or Clear is called. ///. Key methods: HasValidCache, Set, Clear. Key properties: Current, HasCache. | `ImportedEtabsForceCache.cs` |
| `class` | **IrregularPierGeometryBuilder** | Represents the IrregularPierGeometryBuilder class. Key methods: BuildBoundary. | `IrregularPierGeometryBuilder.cs` |
| `record` | **in** | Represents the in record. Key methods: ParsePierForces. | `EtabsDesignForceImportService.cs` |
| `record` | **in** | Represents the in record. Key methods: ParseAllColumnForces. | `EtabsDesignForceImportService.cs` |
| `record` | **in** | Represents the in record. Key methods: ParseAllPierForces. | `EtabsDesignForceImportService.cs` |
| `record` | **in** | Represents the in record. Key methods: ParseColumnElementForces. | `EtabsDesignForceImportService.cs` |
| `record` | **in** | Represents the in record. Key methods: ParsePierElementForces. | `EtabsDesignForceImportService.cs` |
| `record` | **in** | Represents the in record. | `EtabsDesignForceImportService.cs` |
| `record` | **struct** | Represents the struct record. | `EtabsColumnImportService.cs` |

### Math

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **GeometryHelper** | Represents the GeometryHelper class. Key methods: DegreesToRadians, MomentMagnitude. | `GeometryHelper.cs` |
| `class` | **LinearInterpolationService** | Provides service logic and operations for LinearInterpolation. Key methods: Lerp. | `LinearInterpolationService.cs` |
| `class` | **PolygonClipper** | Represents the PolygonClipper class. | `PolygonClipper.cs` |
| `class` | **UnitConversionService** | Provides service logic and operations for UnitConversion. Key methods: LengthToMm, LengthFromMm, ConvertLength, ForceToN. | `UnitConversionService.cs` |

### Persistence

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ColumnInputRow** | Data structure representing a row for ColumnInput. Key properties: InputJson. | `ProjectService.cs` |
| `class` | **ColumnRow** | Data structure representing a row for Column. Key properties: Id, GroupId, Name, SortOrder. | `ProjectService.cs` |
| `class` | **DatabaseSchema** | Represents the DatabaseSchema class. Key methods: EnsureCreated, Open, OpenResultDb. | `DatabaseSchema.cs` |
| `class` | **GroupRow** | Data structure representing a row for Group. Key properties: Id, Name, SortOrder. | `ProjectService.cs` |
| `class` | **ProjectRow** | Data structure representing a row for Project. Key properties: Name. | `ProjectService.cs` |
| `class` | **ProjectService** | Provides service logic and operations for Project. Key methods: Dispose, NewProject, RenameProject, OpenProject. Key properties: CurrentFilePath, ProjectName, IsModified. | `ProjectService.cs` |
| `class` | **ResultCacheRow** | Data structure representing a row for ResultCache. Key properties: InputHash, ResultJson. | `ProjectService.cs` |

### Persistence/Migrations

| Type | Name | Description | File |
|---|---|---|---|
| `interface` | **IDatabaseMigration** | Defines the contract for IDatabaseMigration. | `IDatabaseMigration.cs` |
| `class` | **Migration002_SectionGroups** | Represents the Migration002_SectionGroups class. Key methods: Apply. Key properties: Version. | `Migration002_SectionGroups.cs` |
| `class` | **Migration003_ProjectAppVersion** | Represents the Migration003_ProjectAppVersion class. Key methods: Apply. Key properties: Version. | `Migration003_ProjectAppVersion.cs` |
| `class` | **Migration004_ResultJson** | Represents the Migration004_ResultJson class. Key methods: Apply. Key properties: Version. | `Migration004_ResultJson.cs` |
| `class` | **Migration005_DemandCase** | Represents the Migration005_DemandCase class. Key methods: Apply. Key properties: Version. | `Migration005_DemandCase.cs` |
| `class` | **Migration006_TopBottomMomentsAndShear** | Represents the Migration006_TopBottomMomentsAndShear class. Key methods: Apply. Key properties: Version. | `Migration006_TopBottomMomentsAndShear.cs` |
| `class` | **Migration007_ForceSourceMetadata** | /// Adds force source traceability columns to DemandCase so each load case knows /// whether it came from ETABS element forces or design forces, and which combination/location. ///. Key methods: Apply. Key properties: Version. | `Migration007_ForceSourceMetadata.cs` |
| `class` | **MigrationRunner** | Represents the MigrationRunner class. Key methods: Run. | `MigrationRunner.cs` |

### Rebar

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ImperialRebarDatabase** | Represents the ImperialRebarDatabase class. Key methods: GetBars, TryGet. | `ImperialRebarDatabase.cs` |
| `class` | **SingaporeRebarDatabase** | Represents the SingaporeRebarDatabase class. Key methods: GetBars, TryGet. | `SingaporeRebarDatabase.cs` |

### Reports/Graphics

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ApproxEqualityComparer** | Represents the ApproxEqualityComparer class. Key methods: Equals, GetHashCode. | `SectionGeometryRenderer.cs` |
| `class` | **InteractionDiagramSvgRenderer** | /// Renders P-M and Mx-My interaction diagrams as standalone SVG strings. ///. Key methods: RenderPmDiagram, RenderMmDiagram. | `InteractionDiagramSvgRenderer.cs` |
| `class` | **SectionGeometryRenderer** | /// Generates SVG diagrams for section geometry and rebar layout. /// All coordinates in mm; SVG output is scaled to fit a fixed viewport. ///. Key methods: RenderRectangularSection, RenderCircularSection, RenderSection. | `SectionGeometryRenderer.cs` |

### Reports/Html

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **HtmlCalculationReportRenderer** | /// Generates a self-contained HTML calculation report with inline CSS, /// embedded SVG, and print-friendly A4 page styling. ///. Key methods: RenderToFile, RenderToBytes. | `HtmlCalculationReportRenderer.cs` |
| `class` | **ReportWebViewRenderer** | /// Generates a single self-contained HTML string for the in-app WebView2 preview. /// Embeds KaTeX inline so every formula field renders as proper math. ///. Key methods: CanRender, BuildHtml. | `ReportWebViewRenderer.cs` |

### Reports/Pdf

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **QuestPdfCalculationReportRenderer** | /// Renders a ReportData to an A4 PDF using QuestPDF. /// No content is clipped. Formula blocks keep together. Tables split by complete rows only. ///. Key methods: RenderToFile, RenderToBytes. | `QuestPdfCalculationReportRenderer.cs` |

### Reports/Svg

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **DiagramSvgRenderer** | Represents the DiagramSvgRenderer class. Key methods: Render. | `DiagramSvgRenderer.cs` |

### Root

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **DependencyInjection** | Represents the DependencyInjection class. Key methods: AddInfrastructure. | `DependencyInjection.cs` |
| `class` | **Program** | Represents the Program class. | `test_flow.cs` |

### Solvers

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **Aci318DesignAdapter** | Represents the Aci318DesignAdapter class. Key methods: ApplyDesignRules. | `DesignCodeAdapters.cs` |
| `class` | **CircularFiberInteractionSolver** | /// Circular RC interaction solver using strain compatibility and numerical concrete fibers. /// Concrete is integrated over the circular area and reinforcing bars are handled as /// discrete steel fibers at centroid-based coordinates. ///. Key methods: Solve. Key properties: AngleStepDegrees, NeutralAxisSamples, ConcreteGridDivisions. | `CircularFiberInteractionSolver.cs` |
| `record` | **ConcreteFiber** | Represents the ConcreteFiber record. | `CircularFiberInteractionSolver.cs` |
| `record` | **DesignCapacityPoint** | Represents the DesignCapacityPoint record. | `PmmModels.cs` |
| `class` | **DesignCodeAdapterFactory** | Represents the DesignCodeAdapterFactory class. Key methods: Create. | `DesignCodeAdapters.cs` |
| `class` | **Eurocode2DesignAdapter** | Represents the Eurocode2DesignAdapter class. Key methods: ApplyDesignRules. | `DesignCodeAdapters.cs` |
| `interface` | **IDesignCodeAdapter** | Represents the IDesignCodeAdapter class. | `PmmModels.cs` |
| `interface` | **ISectionIntegrator** | Defines the contract for ISectionIntegrator. | `PmmModels.cs` |
| `interface` | **ISweepStrategy** | Defines the contract for ISweepStrategy. | `PmmModels.cs` |
| `class` | **InteractionSolverFactory** | Represents the InteractionSolverFactory class. Key methods: Get, GetLegacy, GetCircular, GetIrregular. | `InteractionSolverFactory.cs` |
| `record` | **NeutralAxisState** | Represents the NeutralAxisState record. Key properties: DepthIndex, AngleIndex, ThetaRad, NeutralAxisDepth. | `PmmModels.cs` |
| `class` | **NeutralAxisSweepStrategy** | Represents the NeutralAxisSweepStrategy class. Key methods: GenerateStates, ProjectExtreme. | `NeutralAxisSweepStrategy.cs` |
| `record` | **PmmInput** | Represents the PmmInput record. | `PmmModels.cs` |
| `class` | **PmmInteractionSolver** | Represents the PmmInteractionSolver class. Key methods: Solve. Key properties: AngleStepDegrees, NeutralAxisSamples, RectangularFiberCountX, RectangularFiberCountY. | `PmmInteractionSolver.cs` |
| `record` | **PmmResult** | Encapsulates the result of Pmm operations. | `PmmModels.cs` |
| `class` | **PmmSolver** | Represents the PmmSolver class. Key methods: Solve. | `PmmSolver.cs` |
| `record` | **SectionIntegrationResult** | Encapsulates the result of SectionIntegration operations. Key properties: NominalP, NominalMx, NominalMy, ConcreteForce. | `PmmModels.cs` |
| `record` | **SolverSettings** | Represents the SolverSettings record. Key properties: AngleStepDegrees, NeutralAxisSamples, RectangularFiberCountX, RectangularFiberCountY. | `PmmModels.cs` |
| `record` | **struct** | Represents the struct record. | `PmmModels.cs` |

### Solvers/Integration

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **FiberSectionIntegrator** | Represents the FiberSectionIntegrator class. Key methods: Integrate. | `FiberSectionIntegrator.cs` |
| `class` | **PolygonSectionIntegrator** | Represents the PolygonSectionIntegrator class. Key methods: Integrate. | `PolygonSectionIntegrator.cs` |
| `class` | **SectionIntegratorFactory** | Represents the SectionIntegratorFactory class. Key methods: Create. | `SectionIntegratorFactory.cs` |
| `record` | **struct** | Represents the struct record. | `FiberSectionIntegrator.cs` |
| `record` | **struct** | Represents the struct record. | `FiberSectionIntegrator.cs` |
| `record` | **struct** | Represents the struct record. | `PolygonSectionIntegrator.cs` |

### Solvers/Legacy

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **AciFiberInteractionSolver** | Represents the AciFiberInteractionSolver class. Key methods: Solve. Key properties: AngleStepDegrees, NeutralAxisSamples, ConcreteGridDivisions. | `AciFiberInteractionSolver.cs` |
| `class` | **Ec2BoundaryInteractionSolver** | Represents the Ec2BoundaryInteractionSolver class. Key methods: Solve. Key properties: AngleStepDegrees, NeutralAxisSamples. | `Ec2BoundaryInteractionSolver.cs` |
| `class` | **Ec2FiberInteractionSolver** | Represents the Ec2FiberInteractionSolver class. Key methods: Solve. Key properties: AngleStepDegrees, NeutralAxisSamples, ConcreteGridDivisions. | `Ec2FiberInteractionSolver.cs` |
| `class` | **Ec2SimplifiedStressBlockInteractionSolver** | /// Eurocode 2 (EN 1992-1-1:2004) §3.1.7 — simplified rectangular concrete stress block. /// Uses Sutherland-Hodgman analytical polygon clipping (no fiber grid). /// Block stress = η × fcd, block depth = λ × c. /// All material parameters are read from IDesignCodeService; no local hardcoded constants. /// Moment sign: Mnx = Σ(force × y), Mny = Σ(force × x). Phi = 1.0. ///. Key methods: Solve, LambdaFor, EtaFor. Key properties: AngleStepDegrees, NeutralAxisSamples. | `Ec2SimplifiedStressBlockInteractionSolver.cs` |
| `class` | **EcPmmFiberAnalyticSolver** | Represents the EcPmmFiberAnalyticSolver class. Key methods: Solve. Key properties: AngleStepDegrees, NeutralAxisSamples, FiberCount. | `EcPmmFiberAnalyticSolver.cs` |
| `record` | **Fiber** | Represents the Fiber record. | `Ec2FiberInteractionSolver.cs` |
| `record` | **Point** | Represents the Point record. | `StrainCompatibilityInteractionSolver.cs` |
| `record` | **SectionPoint** | Represents the SectionPoint record. | `Ec2SimplifiedStressBlockInteractionSolver.cs` |
| `class` | **StrainCompatibilityInteractionSolver** | Represents the StrainCompatibilityInteractionSolver class. Key methods: Solve. Key properties: AngleStepDegrees, NeutralAxisSamples, ConcreteGridDivisions. | `StrainCompatibilityInteractionSolver.cs` |
| `record` | **struct** | Represents the struct record. | `AciFiberInteractionSolver.cs` |

### Solvers/StrainPoints

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **Aci318StrainLimitAdapter** | Represents the Aci318StrainLimitAdapter class. Key methods: GetConcreteUltimateCompressionStrain, GetSteelYieldStrain, GetSteelTensionStrainLimit, GetStressBlockParameters. Key properties: CodeName. | `Aci318StrainLimitAdapter.cs` |
| `class` | **Ec2StrainLimitAdapter** | Represents the Ec2StrainLimitAdapter class. Key methods: GetConcreteUltimateCompressionStrain, GetSteelYieldStrain, GetSteelTensionStrainLimit, GetStressBlockParameters. Key properties: CodeName. | `Ec2StrainLimitAdapter.cs` |
| `interface` | **IStrainLimitDesignCodeAdapter** | Represents the IStrainLimitDesignCodeAdapter class. | `IStrainLimitDesignCodeAdapter.cs` |
| `record` | **PmComparisonPointResult** | Encapsulates the result of PmComparisonPoint operations. Key properties: PointName, TargetStrainState, NeutralAxisDepth, NeutralAxisAngle. | `PmComparisonService.cs` |
| `class` | **PmComparisonService** | Provides service logic and operations for PmComparison. Key methods: Compare. | `PmComparisonService.cs` |
| `class` | **PmValidationReportService** | Provides service logic and operations for PmValidationReport. Key methods: BuildReport. | `PmValidationReportService.cs` |
| `class` | **RebarStrainStressResult** | Encapsulates the result of RebarStrainStress operations. Key properties: Strain, StressMpa, ForceN, AreaMm2. | `StrainControlledPmModels.cs` |
| `class` | **StrainControlledPmPointResult** | Encapsulates the result of StrainControlledPmPoint operations. Key properties: CodeName, PointName, TargetTensileSteelStrain, NeutralAxisDepthMm. | `StrainControlledPmModels.cs` |
| `class` | **StrainControlledSevenPointStrategy** | Represents the StrainControlledSevenPointStrategy class. Key methods: GeneratePoints. | `StrainControlledSevenPointStrategy.cs` |
| `class` | **StrainPointDefinition** | Represents the StrainPointDefinition class. Key properties: PointName, PointType, TargetTensileSteelStrain, Description. | `StrainControlledPmModels.cs` |
| `enum` | **StrainPointType** | Enumeration defining states/types for StrainPointType. | `StrainControlledPmModels.cs` |
| `class` | **StrainStateResult** | Encapsulates the result of StrainState operations. Key properties: ExtremeCompressionStrain, ExtremeTensionSteelStrain, RegionClassification. | `StrainControlledPmModels.cs` |
| `class` | **StrengthReductionResult** | Encapsulates the result of StrengthReduction operations. Key properties: Phi, Classification. | `IStrainLimitDesignCodeAdapter.cs` |
| `class` | **StressBlockParameters** | Represents the StressBlockParameters class. Key properties: DepthFactorBeta, StrengthEffectivenessFactor. | `IStrainLimitDesignCodeAdapter.cs` |

## MBColumn.Presentation.Wpf

### Collections

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **BulkObservableCollection** | /// ObservableCollection that supports batch adds via AddRange, /// firing a single Reset notification instead of one per item. ///. Key methods: AddRange. | `BulkObservableCollection.cs` |

### Commands

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **AsyncRelayCommand** | Represents the AsyncRelayCommand class. Key methods: CanExecute, Execute, RaiseCanExecuteChanged. | `RelayCommand.cs` |
| `class` | **RelayCommand** | Represents the RelayCommand class. Key methods: CanExecute, Execute, RaiseCanExecuteChanged. | `RelayCommand.cs` |
| `class` | **RelayCommand** | Represents the RelayCommand class. Key methods: CanExecute, Execute, RaiseCanExecuteChanged. | `RelayCommand.cs` |

### Composition

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **AppComposition** | Represents the AppComposition class. Key methods: Create, CreateMainWindowViewModel, Dispose. Key properties: ProjectService, MessageService, ProjectFileDialogService, ProjectNameDialogService. | `AppComposition.cs` |

### Controls

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **AxisRenderer2D** | Represents the AxisRenderer2D class. Key methods: Draw. | `AxisRenderer2D.cs` |
| `class` | **AxisTickService** | Provides service logic and operations for AxisTick. Key methods: Generate, GenerateFixed, Format. | `AxisTickService.cs` |
| `record` | **AxisTicks** | Represents the AxisTicks record. | `AxisTickService.cs` |
| `record` | **Bounds3D** | Represents the Bounds3D record. | `InteractionViewport3D.cs` |
| `record` | **CachedScene** | Represents the CachedScene record. | `InteractionViewport3D.cs` |
| `class` | **ChartInteractionState** | Represents the ChartInteractionState class. Key methods: Reset. | `ChartInteractionState.cs` |
| `class` | **ChartTransformHelper** | Represents the ChartTransformHelper class. Key methods: AutoFit2D, ToScreen, ToData, TicksX. Key properties: MinX, MaxX, MinY, MaxY. | `ChartTransformHelper.cs` |
| `class` | **DiagramCanvas2D** | Represents the DiagramCanvas2D class. Key methods: ResetView, ClipClosedPolylineBelowYForTesting, ClipOpenPolylineAboveYForTesting. Key properties: Points, ReferenceLines, XAxisLabel, YAxisLabel. | `DiagramCanvas2D.cs` |
| `class` | **InteractionViewport3D** | Represents the InteractionViewport3D class. Key methods: ResetCamera, BuildEngineeringAxesForTesting. Key properties: Points, DemandPoint, DemandPoints, GoverningPoint. | `InteractionViewport3D.cs` |
| `class` | **MomentDiagramControl** | /// Renders a bending moment diagram (BMD) for a column member end. /// Shows a vertical column stick with horizontal moment axes at top (y=0) /// and bottom (y=-L). Moment values are plotted as dots on the axes, /// scaled proportionally, with hatch-filled polygon area. /// Left = negative, Right = positive. ///. Key properties: MomentTop, MomentBottom, DiagramColor, Title. | `MomentDiagramControl.cs` |
| `class` | **ReportBlockTemplateSelector** | Represents the ReportBlockTemplateSelector class. Key methods: SelectTemplate. Key properties: HeadingTemplate, ParagraphTemplate, NoteTemplate, FormulaTemplate. | `ReportBlockTemplateSelector.cs` |
| `class` | **ReportPaginator** | /// Paginates a FrameworkElement across multiple printed pages by slicing it /// vertically after scaling to fit the page width. ///. Key methods: GetPage. Key properties: IsPageCountValid, PageCount, PageSize, Source. | `ReportPaginator.cs` |
| `class` | **ReportTableControl** | /// Renders a TableBlock (string[][] rows) as a WPF Grid with headers and data rows. ///. Key properties: Block. | `ReportTableControl.cs` |
| `class` | **SafeFormulaControl** | /// Renders a LaTeX formula through the enhanced math view while preserving the old simple API. /// Falls back to readable plain text if WebView2 or KaTeX cannot render the formula. ///. Key properties: Formula, Scale, FormulaForeground, DisplayMode. | `SafeFormulaControl.cs` |
| `class` | **SectionPreviewCanvas** | Represents the SectionPreviewCanvas class. Key properties: SectionWidth, SectionHeight, SectionShape, Cover. | `SectionPreviewCanvas.cs` |
| `class` | **SectionStateInsetCanvas** | /// Sidebar panel that renders a PmChartInsetFigureDto (section with NA, compression/tension zones). /// Fills its available area; legend sits at the bottom. ///. Key properties: InsetFigure. | `SectionStateInsetCanvas.cs` |
| `class` | **SvgImageControl** | /// Renders an SVG string as a WPF image using SharpVectors. /// Rendering is deferred to background priority so it never blocks the UI thread. ///. Key properties: SvgContent, MaxDisplayWidth. | `SvgImageControl.cs` |
| `class` | **TooltipRenderer** | Represents the TooltipRenderer class. Key methods: Build. | `TooltipRenderer.cs` |
| `record` | **struct** | Represents the struct record. | `InteractionViewport3D.cs` |
| `record` | **struct** | Represents the struct record. Key methods: From. | `InteractionViewport3D.cs` |
| `record` | **struct** | Represents the struct record. | `InteractionViewport3D.cs` |
| `record` | **struct** | Represents the struct record. | `InteractionViewport3D.cs` |
| `record` | **struct** | Represents the struct record. | `InteractionViewport3D.cs` |
| `record` | **struct** | Represents the struct record. Key properties: IsValid. | `InteractionViewport3D.cs` |

### Controls/Math

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **MathEquationView** | Represents the MathEquationView class. Key properties: IsRenderComplete, RenderCompletion, Latex, FallbackText. | `MathEquationView.xaml.cs` |
| `class` | **MathEquationViewModel** | Represents the MathEquationViewModel class. Key properties: Latex, FallbackText, RenderMode, FontSize. | `MathEquationViewModel.cs` |
| `enum` | **MathRenderMode** | Enumeration defining states/types for MathRenderMode. | `MathRenderMode.cs` |
| `class` | **MathRenderService** | Provides service logic and operations for MathRender. Key methods: BuildHtml, HasLocalAssets, NormalizeLatex. | `MathRenderService.cs` |

### Converters

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **BoolToGridLengthConverter** | Represents the BoolToGridLengthConverter class. Key methods: Convert, ConvertBack. | `BoolToVisibilityConverter.cs` |
| `class` | **BoolToVisibilityConverter** | Represents the BoolToVisibilityConverter class. Key methods: Convert, ConvertBack. | `BoolToVisibilityConverter.cs` |
| `class` | **InverseBoolToVisibilityConverter** | Represents the InverseBoolToVisibilityConverter class. Key methods: Convert, ConvertBack. | `BoolToVisibilityConverter.cs` |
| `class` | **NonZeroToVisibilityConverter** | Represents the NonZeroToVisibilityConverter class. Key methods: Convert, ConvertBack. | `BoolToVisibilityConverter.cs` |
| `class` | **NullOrEmptyToCollapsedConverter** | Represents the NullOrEmptyToCollapsedConverter class. Key methods: Convert, ConvertBack. | `BoolToVisibilityConverter.cs` |
| `class` | **PctOf720Converter** | Converts a WidthPct value (e.g. 60.0) to pixels relative to a 720px content area. Key methods: Convert, ConvertBack. | `BoolToVisibilityConverter.cs` |

### Root

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **App** | Represents the App class. | `App.xaml.cs` |
| `record` | **ControlPointRow** | Data structure representing a row for ControlPoint. | `ControlPointsWindow.xaml.cs` |
| `class` | **ControlPointsWindow** | Represents the ControlPointsWindow class. | `ControlPointsWindow.xaml.cs` |
| `class` | **ExportControlPointsWindow** | Represents the ExportControlPointsWindow class. | `ExportControlPointsWindow.xaml.cs` |
| `class` | **MainWindow** | Represents the MainWindow class. | `MainWindow.xaml.cs` |

### Services

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **ControlPointExportDialogService** | Provides service logic and operations for ControlPointExportDialog. Key methods: ShowDialog. | `ControlPointExportDialogService.cs` |
| `class` | **DxfImportDialogService** | Provides service logic and operations for DxfImportDialog. Key methods: ShowDialog. | `DxfImportDialogService.cs` |
| `class` | **EtabsForceRefreshDialogService** | Provides service logic and operations for EtabsForceRefreshDialog. Key methods: ShowDialog. | `EtabsForceRefreshDialogService.cs` |
| `record` | **EtabsImportDialogResult** | Encapsulates the result of EtabsImportDialog operations. | `EtabsImportDialogResult.cs` |
| `class` | **EtabsImportDialogService** | Provides service logic and operations for EtabsImportDialog. Key methods: ShowDialog. | `EtabsImportDialogService.cs` |
| `record` | **EtabsImportedSectionInput** | Represents the EtabsImportedSectionInput record. | `EtabsImportDialogResult.cs` |
| `interface` | **IControlPointExportDialogService** | Provides service logic and operations for IControlPointExportDialog. | `IControlPointExportDialogService.cs` |
| `interface` | **IDxfImportDialogService** | Provides service logic and operations for IDxfImportDialog. | `IDxfImportDialogService.cs` |
| `interface` | **IEtabsForceRefreshDialogService** | Provides service logic and operations for IEtabsForceRefreshDialog. | `IEtabsForceRefreshDialogService.cs` |
| `interface` | **IEtabsImportDialogService** | Provides service logic and operations for IEtabsImportDialog. | `IEtabsImportDialogService.cs` |
| `interface` | **IMessageService** | Provides service logic and operations for IMessage. | `IMessageService.cs` |
| `interface` | **IProjectFileDialogService** | Provides service logic and operations for IProjectFileDialog. | `IProjectFileDialogService.cs` |
| `interface` | **IProjectNameDialogService** | Provides service logic and operations for IProjectNameDialog. | `IProjectNameDialogService.cs` |
| `class` | **MessageBoxService** | Provides service logic and operations for MessageBox. Key methods: ShowError, ShowInformation, ShowWarning, ConfirmWarning. | `IMessageService.cs` |
| `class` | **ProjectFileDialogService** | Provides service logic and operations for ProjectFileDialog. Key methods: ShowOpenProjectDialog, ShowSaveProjectAsDialog. | `IProjectFileDialogService.cs` |
| `class` | **ProjectNameDialogService** | Provides service logic and operations for ProjectNameDialog. Key methods: PromptProjectName, PromptColumnName, PromptSelectSections. | `IProjectNameDialogService.cs` |
| `class` | **ProjectSession** | Represents the ProjectSession class. Key methods: SelectColumn, StoreCurrentColumnResult, StoreColumnResult, TryGetCurrentColumnResult. Key properties: CurrentColumnId. | `ProjectSession.cs` |
| `class` | **RecentProjectsService** | Provides service logic and operations for RecentProjects. Key methods: GetRecent, ClearRecent, AddRecent. | `RecentProjectsService.cs` |

### ViewModels

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **A4ReportPageViewModel** | Represents the A4ReportPageViewModel class. Key properties: PageNumber, PageWidthMm, PageHeightMm, MarginMm. | `A4ReportModels.cs` |
| `class` | **CadPointViewModel** | Represents the CadPointViewModel class. Key properties: X, Y. | `CadPointViewModel.cs` |
| `class` | **CadRebarViewModel** | Represents the CadRebarViewModel class. Key properties: X, Y, BarSize, AreaMm2. | `CadRebarViewModel.cs` |
| `class` | **CadSnapService** | Provides service logic and operations for CadSnap. Key methods: Snap. | `CadSnapService.cs` |
| `enum` | **CadToolMode** | Enumeration defining states/types for CadToolMode. | `CadToolMode.cs` |
| `class` | **ColumnItemViewModel** | Represents the ColumnItemViewModel class. Key properties: GroupId, MoveToGroupOptions, Status, StatusText. | `ColumnItemViewModel.cs` |
| `record` | **ComplianceCheckRowViewModel** | Represents the ComplianceCheckRowViewModel record. Key properties: Reference, Description, Provided, Limit. | `RebarComplianceViewModel.cs` |
| `record` | **DesignCodeOption** | Represents the DesignCodeOption record. | `InputViewModel.cs` |
| `enum` | **DiagramViewportType** | Enumeration defining states/types for DiagramViewportType. | `ViewportOptionViewModel.cs` |
| `class` | **DxfImportViewModel** | Represents the DxfImportViewModel class. Key properties: LayerNames, PreviewRebars, BrowseFileCommand, RefreshLayersCommand. | `DxfImportViewModel.cs` |
| `record` | **Ec2SolverOption** | Represents the Ec2SolverOption record. | `InputViewModel.cs` |
| `class` | **EtabsColumnImportRowViewModel** | Represents the EtabsColumnImportRowViewModel class. Key properties: IsSelected, ObjectName, Pier, Story. | `EtabsColumnImportRowViewModel.cs` |
| `enum` | **EtabsDuplicateHandlingMode** | Enumeration defining states/types for EtabsDuplicateHandlingMode. | `EtabsImportViewModel.cs` |
| `record` | **EtabsDuplicateHandlingOption** | Represents the EtabsDuplicateHandlingOption record. | `EtabsImportViewModel.cs` |
| `class` | **EtabsForceImportRowViewModel** | Represents the EtabsForceImportRowViewModel class. Key properties: IsSelected, ObjectName, Pier, Story. | `EtabsForceImportRowViewModel.cs` |
| `class` | **EtabsForceRefreshSectionRowViewModel** | Represents the EtabsForceRefreshSectionRowViewModel class. Key properties: SectionName, StatusText, OldRows, NewRows. | `EtabsForceRefreshViewModel.cs` |
| `class` | **EtabsForceRefreshViewModel** | Represents the EtabsForceRefreshViewModel class. Key methods: SetAvailableCombinations. Key properties: Result, ExistingBindings, LoadCombinations, SectionRows. | `EtabsForceRefreshViewModel.cs` |
| `class` | **EtabsImportSummaryRowViewModel** | Represents the EtabsImportSummaryRowViewModel class. Key properties: SourceColumn, Mapping, NewSectionName, Pier. | `EtabsImportViewModel.cs` |
| `class` | **EtabsImportViewModel** | Represents the EtabsImportViewModel class. Key methods: ApplyPreloadData, AssignSelectedItemsToSection, RemoveItemFromSection, DeleteMbColumnSection. Key properties: ImportResult, Columns, FilteredColumns, TierObjectCandidatesView. | `EtabsImportViewModel.cs` |
| `class` | **EtabsLoadCombinationViewModel** | Represents the EtabsLoadCombinationViewModel class. Key methods: SetSelectedSilently. Key properties: Name, IsSelected. | `EtabsImportViewModel.cs` |
| `class` | **EtabsPreloadData** | Represents the EtabsPreloadData class. Key properties: ModelName, ModelPath, PresentUnits, StoryCount. | `EtabsPreloadData.cs` |
| `class` | **EtabsPreloadStep** | Represents the EtabsPreloadStep class. Key methods: SetRunning, SetDone, SetError, UpdateDetail. Key properties: Label, IsSubStep, Status, Detail. | `EtabsPreloadStep.cs` |
| `class` | **EtabsPreloadViewModel** | Represents the EtabsPreloadViewModel class. Key methods: StartAsync, Cancel. Key properties: Steps, AvailableCombinations, FilteredCombinations, CompletedCount. | `EtabsPreloadViewModel.cs` |
| `class` | **EtabsSectionMappingViewModel** | Represents the EtabsSectionMappingViewModel class. Key properties: SectionTypes, EtabsSectionName, UniqueSection, SectionType. | `EtabsSectionMappingViewModel.cs` |
| `class` | **EtabsStoryOptionViewModel** | Represents the EtabsStoryOptionViewModel class. Key properties: StoryName, Elevation, SortIndex, DisplayName. | `EtabsImportViewModel.cs` |
| `class` | **EtabsUniqueSectionOptionViewModel** | Represents the EtabsUniqueSectionOptionViewModel class. Key properties: SectionName, SourceSectionName, ShapeType, ObjectCount. | `EtabsImportViewModel.cs` |
| `class` | **ExplorerNodeViewModel** | Represents the ExplorerNodeViewModel class. Key properties: Id, IsChecked, Name, IsSelected. | `ExplorerNodeViewModel.cs` |
| `class` | **ExportControlPointsViewModel** | Represents the ExportControlPointsViewModel class. Key methods: RefreshPreview. Key properties: PreviewRows, RefreshPreviewCommand, ExportCsvCommand, CloseCommand. | `ExportControlPointsViewModel.cs` |
| `class` | **GoverningChartPreviewViewModel** | Represents the GoverningChartPreviewViewModel class. Key properties: CriticalThetaDeg, UtilizationRatio, DemandP, DemandMx. | `A4ReportModels.cs` |
| `class` | **GroupActionViewModel** | Represents the GroupActionViewModel class. Key properties: Name, Command. | `GroupActionViewModel.cs` |
| `class` | **GroupItemViewModel** | Represents the GroupItemViewModel class. Key methods: UpdateCheckStateFromChildren. Key properties: Columns, AddSectionCommand, AddExistingSectionsCommand. | `GroupItemViewModel.cs` |
| `class` | **InputViewModel** | Represents the InputViewModel class. Key methods: ToDto, UpdateSectionPreview, ResetToDefaults, ApplyDxfImportResult. Key properties: UnitSystems, GenerateIrregularRebarsCommand, GenerateEqualSpacingRebarsCommand, ImportDxfCommand. | `InputViewModel.cs` |
| `class` | **IrregularBoundaryPointViewModel** | Represents the IrregularBoundaryPointViewModel class. Key properties: PtIndex, X, Y. | `IrregularBoundaryPointViewModel.cs` |
| `record` | **IrregularRebarModeOption** | Represents the IrregularRebarModeOption record. | `IrregularSectionInputViewModel.cs` |
| `class` | **IrregularRebarRowViewModel** | Represents the IrregularRebarRowViewModel class. Key properties: RebarIndex, X, Y, BarSize. | `IrregularRebarRowViewModel.cs` |
| `class` | **IrregularSectionInputViewModel** | Represents the IrregularSectionInputViewModel class. Key methods: LoadDefaultLShape, ImportBoundaryFile, ImportRebarFile, ExportBoundaryFile. Key properties: BoundaryPoints, Rebars, RebarMode, BoundaryValidationMessage. | `IrregularSectionInputViewModel.cs` |
| `record` | **LoadCaseResultRowViewModel** | Represents the LoadCaseResultRowViewModel record. Key properties: PDisplay, MxDisplay, MyDisplay, AngleDisplay. | `ResultViewModel.cs` |
| `class` | **LoadCaseViewModel** | Represents the LoadCaseViewModel class. Key methods: ToDto, ClearEc2SlendernessResults. Key properties: Id, Name, Pu, Mux. | `LoadCaseViewModel.cs` |
| `class` | **MM3DViewModel** | Represents the MM3DViewModel class. Key methods: Load. Key properties: MmSliceContours, SurfaceMesh, DemandPoint, GoverningPoint. | `MM3DViewModel.cs` |
| `class` | **MMDiagramViewModel** | Represents the MMDiagramViewModel class. Key methods: Load. Key properties: DiagramTitle, XAxisLabel, YAxisLabel, BoundaryPoints. | `MMDiagramViewModel.cs` |
| `class` | **MainWindowViewModel** | Represents the MainWindowViewModel class. Key properties: Input, Result, Report, Explorer. | `MainWindowViewModel.cs` |
| `record` | **MaterialGradeOption** | Represents the MaterialGradeOption record. Key methods: StressValue, ModulusValue. | `InputViewModel.cs` |
| `record` | **MaterialLibraryOption** | Represents the MaterialLibraryOption record. | `InputViewModel.cs` |
| `enum` | **MaterialLibraryType** | Enumeration defining states/types for MaterialLibraryType. | `InputViewModel.cs` |
| `class` | **MbColumnMappedForceRowViewModel** | Represents the MbColumnMappedForceRowViewModel class. Key properties: MbColumnSectionName, LoadCaseName, ObjectType, Story. | `MbColumnMappedForceRowViewModel.cs` |
| `class` | **MbColumnSectionSummaryViewModel** | Represents the MbColumnSectionSummaryViewModel class. Key properties: SectionName, ObjectType, SelectedItems, MatchedForceRows. | `MbColumnSectionSummaryViewModel.cs` |
| `class` | **MbColumnSectionViewModel** | Represents the MbColumnSectionViewModel class. Key methods: AddItem, RemoveItem. Key properties: Items, SectionName, EditName, IsRenaming. | `MbColumnSectionViewModel.cs` |
| `class` | **PM3DViewModel** | Represents the PM3DViewModel class. Key methods: Load. Key properties: SurfacePoints, SpecialCapacityPoints, SurfaceMesh, WireframeLines. | `PM3DViewModel.cs` |
| `class` | **PMDiagramViewModel** | Represents the PMDiagramViewModel class. Key methods: LoadPmAngle. Key properties: DiagramTitle, XAxisLabel, YAxisLabel, CapacityPoints. | `PMDiagramViewModel.cs` |
| `class` | **PolylineDraft** | Represents the PolylineDraft class. Key methods: Clear. Key properties: IsActive. | `PolylineDraft.cs` |
| `enum` | **PreloadStepStatus** | Enumeration defining states/types for PreloadStepStatus. | `EtabsPreloadStep.cs` |
| `record` | **PreviewBoundaryPoint** | Represents the PreviewBoundaryPoint record. | `PreviewBoundaryPoint.cs` |
| `record` | **PreviewRebarPoint** | Represents the PreviewRebarPoint record. Key properties: Area. | `PreviewRebarPoint.cs` |
| `record` | **PreviewRebarVm** | Represents the PreviewRebarVm record. | `DxfImportViewModel.cs` |
| `class` | **ProjectExplorerViewModel** | Represents the ProjectExplorerViewModel class. Key methods: SetSectionStatus, ClearSectionStatuses, SelectNode, SelectColumnById. Key properties: ProjectName, Nodes, SelectedNode, SelectedColumn. | `ProjectExplorerViewModel.cs` |
| `class` | **ProjectGroupOptionViewModel** | Represents the ProjectGroupOptionViewModel class. Key properties: GroupId, GroupName, CreateGroup, DisplayName. | `EtabsImportViewModel.cs` |
| `class` | **RebarComplianceViewModel** | /// Exposes the rebar code-compliance check results for the Results tab sidebar panel. ///. Key methods: Load. Key properties: HasResult, AllPass, HasFails, StatusText. | `RebarComplianceViewModel.cs` |
| `record` | **RebarLayoutTypeOption** | Represents the RebarLayoutTypeOption record. | `RebarLayoutTypeOption.cs` |
| `class` | **RebarLayoutViewModel** | Represents the RebarLayoutViewModel class. Key properties: Top, Bottom, Left, Right. | `RebarLayoutViewModel.cs` |
| `record` | **RebarSetLibraryOption** | Represents the RebarSetLibraryOption record. | `InputViewModel.cs` |
| `class` | **RebarSideInputViewModel** | Represents the RebarSideInputViewModel class. Key methods: ToDto, SetGlobalInputs, SetBarCountSilently, SetWarning. Key properties: Name, IsBarSizeEditable, IsCoverEditable, BarCount. | `RebarSideInputViewModel.cs` |
| `class` | **ReportBlockViewModel** | Represents the ReportBlockViewModel class. Key properties: BlockType, Title, EstimatedHeightMm, KeepTogether. | `A4ReportModels.cs` |
| `record` | **ReportDemandCaseRowViewModel** | Represents the ReportDemandCaseRowViewModel record. Key properties: IsFailing. | `ReportTabViewModel.cs` |
| `class` | **ReportPaginatorService** | Provides service logic and operations for ReportPaginator. Key methods: Paginate. | `A4ReportModels.cs` |
| `class` | **ReportPm7RowViewModel** | Represents the ReportPm7RowViewModel class. Key properties: Index, PointCode, PointName, StrainDescription. | `A4ReportModels.cs` |
| `class` | **ReportSectionToggleViewModel** | Represents the ReportSectionToggleViewModel class. Key properties: Title, SectionNumber, IsVisible. | `ReportTabViewModel.cs` |
| `class` | **ReportTabViewModel** | Represents the ReportTabViewModel class. Key methods: Clear, MarkOutdated, LoadFromCurrentWorkspace. Key properties: WebViewScrollToAnchor, GeneratePreviewCommand, RevealReportPreviewCommand, HideReportPreviewCommand. | `ReportTabViewModel.cs` |
| `class` | **ReportUnitConverter** | Represents the ReportUnitConverter class. Key methods: MmToDip, InchToDip. | `A4ReportModels.cs` |
| `class` | **ResultViewModel** | Represents the ResultViewModel class. Key methods: ToggleViewport, CloseViewport. Key properties: PM, MM, PM3D, MM3D. | `ResultViewModel.cs` |
| `class` | **SectionCadEditorViewModel** | Represents the SectionCadEditorViewModel class. Key methods: AddBoundaryPoint, AddRebar, AddPolylinePoint, UpdatePolylinePreview. Key properties: BoundaryPoints, Rebars, Draft, ToolMode. | `SectionCadEditorViewModel.cs` |
| `record` | **SectionIntegrationMethodOption** | Represents the SectionIntegrationMethodOption record. | `InputViewModel.cs` |
| `enum` | **SectionStatus** | Enumeration defining states/types for SectionStatus. | `SectionStatus.cs` |
| `record` | **SevenPointValidationRowViewModel** | Represents the SevenPointValidationRowViewModel record. Key properties: CDisplay, Pn7Display, Mn7Display, PnSolverDisplay. | `ResultViewModel.cs` |
| `record` | **ShearEnvelopeSummaryRowViewModel** | Represents the ShearEnvelopeSummaryRowViewModel record. Key properties: DemandText, CapacityText, RatioText, StatusText. | `ShearResultViewModel.cs` |
| `class` | **ShearResultViewModel** | /// Display ViewModel for the governing shear check result (Results tab sidebar). /// All force values in the user's display unit; lengths/stresses in mm / MPa. ///. Key methods: Load. Key properties: HasResult, EnvelopeSummaryRows, HasEnvelopeSummary, HasDemand. | `ShearResultViewModel.cs` |
| `enum` | **SnapKind** | Enumeration defining states/types for SnapKind. | `SnapResult.cs` |
| `class` | **SnapResult** | Encapsulates the result of Snap operations. Key properties: X, Y, Kind, HasSnap. | `SnapResult.cs` |
| `class` | **ViewModelBase** | Represents the ViewModelBase class. | `ViewModelBase.cs` |
| `class` | **ViewportOptionViewModel** | Represents the ViewportOptionViewModel class. Key properties: Type, DisplayName, IsSelected. | `ViewportOptionViewModel.cs` |
| `record` | **fields** | Represents the fields record. Key methods: GenerateSectionForceRows. | `EtabsImportViewModel.cs` |
| `record` | **in** | Represents the in record. Key methods: RefreshMoveToGroupOptions, GetSelectedColumnIds. | `ProjectExplorerViewModel.cs` |

### Views

| Type | Name | Description | File |
|---|---|---|---|
| `class` | **AddSectionDialog** | Represents the AddSectionDialog class. Key properties: SectionName, SelectedGroupId. | `AddSectionDialog.xaml.cs` |
| `class` | **CalculationProgressWindow** | Represents the CalculationProgressWindow class. Key properties: StatusText, ProgressValue, ProgressMax. | `CalculationProgressWindow.xaml.cs` |
| `class` | **DxfImportWindow** | Represents the DxfImportWindow class. | `DxfImportWindow.xaml.cs` |
| `class` | **EtabsForceRefreshWindow** | Represents the EtabsForceRefreshWindow class. | `EtabsForceRefreshWindow.xaml.cs` |
| `class` | **EtabsImportWindow** | Represents the EtabsImportWindow class. | `EtabsImportWindow.xaml.cs` |
| `class` | **EtabsPreloadWindow** | Represents the EtabsPreloadWindow class. | `EtabsPreloadWindow.xaml.cs` |
| `class` | **GroupOption** | Represents the GroupOption class. Key properties: Id, Name. | `AddSectionDialog.xaml.cs` |
| `class` | **InputTabView** | Represents the InputTabView class. | `InputTabView.xaml.cs` |
| `class` | **MM3DView** | Represents the MM3DView class. | `MM3DView.xaml.cs` |
| `class` | **MMDiagramView** | Represents the MMDiagramView class. | `MMDiagramView.xaml.cs` |
| `class` | **PM3DView** | Represents the PM3DView class. | `PM3DView.xaml.cs` |
| `class` | **PMDiagramView** | Represents the PMDiagramView class. | `PMDiagramView.xaml.cs` |
| `class` | **ProjectNameDialog** | Represents the ProjectNameDialog class. Key properties: ProjectName. | `ProjectNameDialog.xaml.cs` |
| `class` | **RebarComplianceDetailView** | Represents the RebarComplianceDetailView class. | `RebarComplianceDetailView.xaml.cs` |
| `class` | **RecentFileItem** | Represents the RecentFileItem class. Key properties: FilePath, FileName, FolderPath, LastModified. | `StartUpWindow.xaml.cs` |
| `class` | **ReportTabView** | Represents the ReportTabView class. | `ReportTabView.xaml.cs` |
| `class` | **ResultDetailWindow** | Represents the ResultDetailWindow class. | `ResultDetailWindow.xaml.cs` |
| `class` | **ResultTabView** | Represents the ResultTabView class. | `ResultTabView.xaml.cs` |
| `class` | **SectionCadEditorWindow** | Represents the SectionCadEditorWindow class. | `SectionCadEditorWindow.xaml.cs` |
| `class` | **SectionSelectionItem** | Represents the SectionSelectionItem class. Key methods: GetSelectedIds. Key properties: Id, Name, IsSelected. | `SelectSectionsDialog.xaml.cs` |
| `class` | **SelectSectionsDialog** | Represents the SelectSectionsDialog class. | `SelectSectionsDialog.xaml.cs` |
| `class` | **ShearDetailView** | Represents the ShearDetailView class. | `ShearDetailView.xaml.cs` |
| `class` | **StartUpWindow** | Represents the StartUpWindow class. | `StartUpWindow.xaml.cs` |
