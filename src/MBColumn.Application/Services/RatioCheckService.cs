using System;
using System.Collections.Generic;
using System.Linq;
using MBColumn.Domain.Entities;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;

namespace MBColumn.Application.Services;

public sealed class RatioCheckService : IRatioCheckService
{
    private const double NearZero = 1e-9;

    public RatioResult Check(InteractionSurface surface, LoadDemand demand)
    {
        var triangles = BuildTriangles(surface);
        return CheckDemand(surface, demand, triangles);
    }

    public IReadOnlyList<RatioResult> CheckBatch(InteractionSurface surface, IReadOnlyList<LoadDemand> demands)
    {
        if (demands.Count == 0) return Array.Empty<RatioResult>();

        var results = new RatioResult[demands.Count];
        var triangles = BuildTriangles(surface);

        for (int i = 0; i < demands.Count; i++)
        {
            results[i] = CheckDemand(surface, demands[i], triangles);
        }

        return results;
    }

    private static List<SurfaceTriangle> BuildTriangles(InteractionSurface surface)
    {
        var grid = new InteractionPoint[surface.AngleCount, surface.DepthCount];
        foreach (var p in surface.Points)
        {
            if (p.AngleIndex >= 0 && p.AngleIndex < surface.AngleCount &&
                p.DepthIndex >= 0 && p.DepthIndex < surface.DepthCount)
            {
                grid[p.AngleIndex, p.DepthIndex] = p;
            }
        }

        var triangles = new List<SurfaceTriangle>(surface.AngleCount * surface.DepthCount * 2);
        for (int a = 0; a < surface.AngleCount; a++)
        {
            int nextA = (a + 1) % surface.AngleCount;
            for (int d = 0; d < surface.DepthCount - 1; d++)
            {
                var p00 = grid[a, d];
                var p10 = grid[nextA, d];
                var p01 = grid[a, d + 1];
                var p11 = grid[nextA, d + 1];

                if (p00 == null || p10 == null || p01 == null || p11 == null) continue;

                triangles.Add(new SurfaceTriangle(p00, p10, p01));
                triangles.Add(new SurfaceTriangle(p10, p11, p01));
            }
        }

        return triangles;
    }

    private static RatioResult CheckDemand(InteractionSurface surface, LoadDemand demand, IReadOnlyList<SurfaceTriangle> triangles)
    {
        var demandVec = new Vec3(demand.MuxNmm, demand.MuyNmm, demand.PuN);
        double demandMagnitude = demandVec.Length();

        if (demandMagnitude < NearZero)
        {
            return new RatioResult(0.0, CapacityStatus.Pass, null, 0.0, 0.0, "Zero demand.")
            {
                DemandMagnitude = 0.0,
                CapacityMagnitude = double.PositiveInfinity,
                CapacityPn = 0.0,
                CapacityMnx = 0.0,
                CapacityMny = 0.0,
                CriticalThetaDegrees = 0.0
            };
        }

        double demandMoment = Math.Sqrt(demandVec.X * demandVec.X + demandVec.Y * demandVec.Y);
        if (demandMoment < NearZero)
        {
            double pCapacity = demand.PuN >= 0
                ? surface.Points.Max(p => p.PhiPn)
                : surface.Points.Min(p => p.PhiPn);

            double capacityMag = Math.Abs(pCapacity);
            double r = capacityMag <= NearZero ? double.PositiveInfinity : demandMagnitude / capacityMag;
            var gov = demand.PuN >= 0
                ? surface.Points.MaxBy(p => p.PhiPn)
                : surface.Points.MinBy(p => p.PhiPn);

            return new RatioResult(r, r <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail, gov, 0.0, 0.0, "Pure axial demand.")
            {
                DemandMagnitude = demandMagnitude,
                CapacityMagnitude = capacityMag,
                CapacityPn = pCapacity,
                CapacityMnx = 0.0,
                CapacityMny = 0.0,
                CriticalThetaDegrees = 0.0
            };
        }

        var dir = demandVec.Normalize();
        double demandAngle = Math.Atan2(demand.MuyNmm, demand.MuxNmm) * 180.0 / Math.PI;
        if (demandAngle < 0) demandAngle += 360.0;

        double minT = double.PositiveInfinity;
        SurfaceTriangle bestTri = default;
        double bestU = 0, bestV = 0, bestW = 0;

        var rayOrigin = new Vec3(0, 0, 0);
        foreach (var tri in triangles)
        {
            if (IntersectRayTriangle(rayOrigin, dir, tri.V0, tri.Edge1, tri.Edge2, out double t, out double u, out double v) && t > NearZero && t < minT)
            {
                minT = t;
                bestTri = tri;
                bestU = 1 - u - v;
                bestV = u;
                bestW = v;
            }
        }

        if (double.IsInfinity(minT))
        {
            // Fallback for edge cases where ray barely misses the mesh due to numerical gaps or sparse angles
            return FallbackToClosestRayPoint(surface, demandVec, demandMagnitude, dir, demandAngle);
        }

        double capacityMagnitude = minT;
        double ratio = demandMagnitude / capacityMagnitude;
        var govPoint = InterpolatePoint(bestTri.A!, bestTri.B!, bestTri.C!, bestU, bestV, bestW);
        var capacityVec = dir * capacityMagnitude;

        double capMomentMag = Math.Sqrt(capacityVec.X * capacityVec.X + capacityVec.Y * capacityVec.Y);

        return new RatioResult(ratio, ratio <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail, govPoint, demandMoment, capMomentMag, "Radial 3D capacity check.")
        {
            DemandMagnitude = demandMagnitude,
            CapacityMagnitude = capacityMagnitude,
            CapacityPn = capacityVec.Z,
            CapacityMnx = capacityVec.X,
            CapacityMny = capacityVec.Y,
            CriticalThetaDegrees = demandAngle
        };
    }

    private static RatioResult FallbackToClosestRayPoint(InteractionSurface surface, Vec3 demandVec, double demandMagnitude, Vec3 dir, double demandAngle)
    {
        double maxProj = 0.0;
        InteractionPoint? govPoint = null;

        foreach (var p in surface.Points)
        {
            var v = PointToVec3(p);
            double proj = Vec3.Dot(v, dir);
            if (proj > maxProj)
            {
                // Verify alignment is somewhat close to avoid picking points far off the ray
                var dirP = v.Normalize();
                if (Vec3.Dot(dirP, dir) > 0.95)
                {
                    maxProj = proj;
                    govPoint = p;
                }
            }
        }

        if (maxProj <= NearZero)
        {
            return new RatioResult(double.PositiveInfinity, CapacityStatus.Fail, surface.Points.FirstOrDefault(), demandMagnitude, 0, "No capacity found along demand direction.")
            {
                DemandMagnitude = demandMagnitude,
                CapacityMagnitude = 0.0,
                CapacityPn = 0.0,
                CapacityMnx = 0.0,
                CapacityMny = 0.0,
                CriticalThetaDegrees = demandAngle
            };
        }

        double capacityMagnitude = maxProj;
        double ratio = demandMagnitude / capacityMagnitude;
        var capacityVec = dir * capacityMagnitude;
        double capMomentMag = Math.Sqrt(capacityVec.X * capacityVec.X + capacityVec.Y * capacityVec.Y);
        double demandMomentMag = Math.Sqrt(demandVec.X * demandVec.X + demandVec.Y * demandVec.Y);

        return new RatioResult(ratio, ratio <= 1.0 ? CapacityStatus.Pass : CapacityStatus.Fail, govPoint, demandMomentMag, capMomentMag, "Fallback radial capacity check.")
        {
            DemandMagnitude = demandMagnitude,
            CapacityMagnitude = capacityMagnitude,
            CapacityPn = capacityVec.Z,
            CapacityMnx = capacityVec.X,
            CapacityMny = capacityVec.Y,
            CriticalThetaDegrees = demandAngle
        };
    }

    private static bool IntersectRayTriangle(Vec3 rayOrigin, Vec3 rayDir, Vec3 v0, Vec3 edge1, Vec3 edge2, out double t, out double u, out double v)
    {
        t = u = v = 0;
        var h = Vec3.Cross(rayDir, edge2);
        double a = Vec3.Dot(edge1, h);

        if (a > -NearZero && a < NearZero)
            return false;

        double f = 1.0 / a;
        var s = rayOrigin - v0;
        u = f * Vec3.Dot(s, h);

        if (u < 0.0 || u > 1.0)
            return false;

        var q = Vec3.Cross(s, edge1);
        v = f * Vec3.Dot(rayDir, q);

        if (v < 0.0 || u + v > 1.0)
            return false;

        t = f * Vec3.Dot(edge2, q);
        return t > NearZero;
    }

    private static Vec3 PointToVec3(InteractionPoint p) => new(p.PhiMnx, p.PhiMny, p.PhiPn);

    private static InteractionPoint InterpolatePoint(InteractionPoint a, InteractionPoint b, InteractionPoint c, double u, double v, double w)
    {
        return new InteractionPoint(
            a.DepthIndex,
            a.AngleIndex,
            a.ThetaDegrees, // Approximate
            Linear(a.NeutralAxisDepthMm, b.NeutralAxisDepthMm, c.NeutralAxisDepthMm, u, v, w),
            Linear(a.Pn, b.Pn, c.Pn, u, v, w),
            Linear(a.Mnx, b.Mnx, c.Mnx, u, v, w),
            Linear(a.Mny, b.Mny, c.Mny, u, v, w),
            Linear(a.Phi, b.Phi, c.Phi, u, v, w),
            Linear(a.MaxTensionSteelStrain, b.MaxTensionSteelStrain, c.MaxTensionSteelStrain, u, v, w),
            Linear(a.ConcretePn, b.ConcretePn, c.ConcretePn, u, v, w),
            Linear(a.SteelPn, b.SteelPn, c.SteelPn, u, v, w),
            Linear(a.ConcreteMnx, b.ConcreteMnx, c.ConcreteMnx, u, v, w),
            Linear(a.ConcreteMny, b.ConcreteMny, c.ConcreteMny, u, v, w),
            Linear(a.SteelMnx, b.SteelMnx, c.SteelMnx, u, v, w),
            Linear(a.SteelMny, b.SteelMny, c.SteelMny, u, v, w),
            Linear(a.MaxConcreteStrain, b.MaxConcreteStrain, c.MaxConcreteStrain, u, v, w),
            Linear(a.MinConcreteStrain, b.MinConcreteStrain, c.MinConcreteStrain, u, v, w),
            Linear(a.MaxSteelStrain, b.MaxSteelStrain, c.MaxSteelStrain, u, v, w),
            Linear(a.MinSteelStrain, b.MinSteelStrain, c.MinSteelStrain, u, v, w),
            a.StateLabel)
        {
            IntegrationMethod = a.IntegrationMethod
        };
    }

    private static double Linear(double a, double b, double c, double u, double v, double w) => a * u + b * v + c * w;

    private readonly record struct Vec3(double X, double Y, double Z)
    {
        public static Vec3 operator -(Vec3 a, Vec3 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vec3 operator +(Vec3 a, Vec3 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vec3 operator *(Vec3 a, double d) => new(a.X * d, a.Y * d, a.Z * d);
        public static Vec3 Cross(Vec3 a, Vec3 b) => new(
            a.Y * b.Z - a.Z * b.Y,
            a.Z * b.X - a.X * b.Z,
            a.X * b.Y - a.Y * b.X);
        public double Length() => Math.Sqrt(X * X + Y * Y + Z * Z);
        public Vec3 Normalize()
        {
            double len = Length();
            return len > 0 ? new Vec3(X / len, Y / len, Z / len) : this;
        }
        public static double Dot(Vec3 a, Vec3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    }

    private readonly struct SurfaceTriangle
    {
        public readonly InteractionPoint A;
        public readonly InteractionPoint B;
        public readonly InteractionPoint C;
        public readonly Vec3 V0;
        public readonly Vec3 Edge1;
        public readonly Vec3 Edge2;

        public SurfaceTriangle(InteractionPoint a, InteractionPoint b, InteractionPoint c)
        {
            A = a;
            B = b;
            C = c;
            V0 = PointToVec3(a);
            Vec3 v1 = PointToVec3(b);
            Vec3 v2 = PointToVec3(c);
            Edge1 = v1 - V0;
            Edge2 = v2 - V0;
        }
    }
}
