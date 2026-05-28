using MBColumn.Application.DTOs.Etabs;

namespace MBColumn.Application.DTOs.Persistence;

public sealed class ColumnInputSnapshot
{
    public string UnitSystem { get; set; } = "Metric";
    public string DesignCode { get; set; } = "Aci318Style";
    public string Ec2Solver { get; set; } = "Fiber";
    public string IntegrationMethod { get; set; } = "Fiber";
    public double AlphaCc { get; set; } = 0.85;

    public string SectionShape { get; set; } = "Rectangular";
    public double Width { get; set; } = 700;
    public double Height { get; set; } = 700;
    public double Diameter { get; set; } = 700;
    public double Cover { get; set; } = 55;

    public double Fc { get; set; } = 28;
    public double Fy { get; set; } = 420;
    public double Es { get; set; } = 200000;
    public string MaterialLibrary { get; set; } = "";

    public string BarSize { get; set; } = "T25";
    public string RebarSetLibrary { get; set; } = "";
    public int BarCount { get; set; } = 28;
    public double Spacing { get; set; } = 150;
    public double StirrupDiameterMm { get; set; } = 10.0;
    public string StirrupBarSize { get; set; } = "";
    public double LinkSpacingMm { get; set; } = 200.0;
    public int InnerLegsX { get; set; } = 0;
    public int InnerLegsY { get; set; } = 0;
    public string RebarLayoutType { get; set; } = "AllSidesEqual";
    public int TopBarCount { get; set; } = 8;
    public int BottomBarCount { get; set; } = 8;
    public int LeftBarCount { get; set; } = 6;
    public int RightBarCount { get; set; } = 6;

    public string IrregularBarSize { get; set; } = "T25";
    public double IrregularSpacing { get; set; } = 150;
    public string IrregularRebarMode { get; set; } = "EqualSpacing";
    public List<SnapshotBoundaryPoint> BoundaryPoints { get; set; } = [];
    // Each inner list is one void/hole boundary (CCW, centroid-origin mm).
    public List<List<SnapshotBoundaryPoint>> OpeningPoints { get; set; } = [];
    public List<SnapshotRebar> Rebars { get; set; } = [];

    public double Pu { get; set; }
    public double Mux { get; set; }
    public double Muy { get; set; }
    public double PmAngleDegrees { get; set; }
    public double AxialLoad { get; set; }
    public List<SnapshotLoadCase> LoadCases { get; set; } = [];

    public string DesignTierName { get; set; } = "";
    public string DesignTierSource { get; set; } = "";
    public EtabsTierImportMetadataDto? EtabsTierMetadata { get; set; }
    public EtabsImportMetadataDto? EtabsMetadata { get; set; }

    // ETABS binding map — stored so forces can be refreshed without re-importing geometry
    public EtabsSectionBinding? EtabsBinding { get; set; }
    public DateTime? LastEtabsRefreshAt { get; set; }
    public string? LastEtabsRefreshSummary { get; set; }
}

public sealed class SnapshotBoundaryPoint
{
    public int PtIndex { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
}

public sealed class SnapshotRebar
{
    public string RebarIndex { get; set; } = "";
    public double X { get; set; }
    public double Y { get; set; }
    public string? BarSize { get; set; }
    public double? AreaMm2 { get; set; }
}

public sealed class SnapshotLoadCase
{
    public string Id { get; set; } = "";
    public string Label { get; set; } = "";
    public string OriginalLoadCaseName { get; set; } = "";
    public string SourceObjectName { get; set; } = "";
    public string SourceObjectLabel { get; set; } = "";
    public string Story { get; set; } = "";
    public string Station { get; set; } = "";
    public string Source { get; set; } = "Manual";
    public double Pu { get; set; }
    public double Mux { get; set; }
    public double Muy { get; set; }
    /// <summary>Shear force in X direction in the snapshot's force unit. Defaults to 0.</summary>
    public double Vux { get; set; } = 0.0;
    /// <summary>Shear force in Y direction in the snapshot's force unit. Defaults to 0.</summary>
    public double Vuy { get; set; } = 0.0;
    public bool IsActive { get; set; } = true;
}
