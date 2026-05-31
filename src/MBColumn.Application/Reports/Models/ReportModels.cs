using MBColumn.Application.DTOs;

namespace MBColumn.Application.Reports.Models;

/// <summary>
/// Carries the raw ShearResultDto so the HTML renderer can build
/// the full step-by-step KaTeX shear block matching the Results tab visual.
/// </summary>
public sealed record Ec2ShearDetailBlock(ShearResultDto Shear, string ForceUnit) : ReportBlock;

/// <summary>
/// Carries a single EC2 slenderness load-case result and batch metadata so
/// the HTML renderer can build the step-by-step slenderness KaTeX block.
/// </summary>
public sealed record Ec2SlendernessDetailBlock(
    Ec2SlendernessLoadCaseResultDto LoadCase,
    Ec2SlendernessBatchResultDto Batch,
    bool IsMetric,
    string MomentUnit) : ReportBlock;
