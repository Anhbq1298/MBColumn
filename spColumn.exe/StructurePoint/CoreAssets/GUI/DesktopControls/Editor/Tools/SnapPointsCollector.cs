using System;
using System.Collections.Generic;
using #Fmc;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools
{
	// Token: 0x02000AE8 RID: 2792
	public sealed class SnapPointsCollector
	{
		// Token: 0x06005AA9 RID: 23209 RVA: 0x0004B6CC File Offset: 0x000498CC
		public SnapPointsCollector(Point3D snappingTarget, SnapPointsCollectorMode collectorMode)
		{
			this.snappingTarget = snappingTarget;
			this.collectorMode = collectorMode;
			this.ResetResults();
			this.SecondarySnapToPointOrigins = new HashSet<Enum>();
		}

		// Token: 0x1700198F RID: 6543
		// (get) Token: 0x06005AAA RID: 23210 RVA: 0x0004B6F3 File Offset: 0x000498F3
		public HashSet<Enum> SecondarySnapToPointOrigins { get; }

		// Token: 0x17001990 RID: 6544
		// (get) Token: 0x06005AAB RID: 23211 RVA: 0x0004B6FB File Offset: 0x000498FB
		public bool ShouldCollect
		{
			get
			{
				return (this.collectorMode == SnapPointsCollectorMode.FirstMatch && this.currentSnappedPoint == null) || this.collectorMode == SnapPointsCollectorMode.ClosestMatch;
			}
		}

		// Token: 0x17001991 RID: 6545
		// (get) Token: 0x06005AAC RID: 23212 RVA: 0x0004B71E File Offset: 0x0004991E
		public bool HasValidResult
		{
			get
			{
				return this.currentSnappedPoint != null;
			}
		}

		// Token: 0x06005AAD RID: 23213 RVA: 0x0004B72C File Offset: 0x0004992C
		public void ResetResults()
		{
			this.currentSnappedPoint = null;
			this.currentOriginInfo = null;
			this.currentDistanceToTarget = double.MaxValue;
			this.currentSnapToPointOrigin = null;
		}

		// Token: 0x06005AAE RID: 23214 RVA: 0x0004B752 File Offset: 0x00049952
		public SnapToPointResult RetrieveResult()
		{
			if (!(this.currentSnappedPoint != null))
			{
				return new SnapToPointResult(null, this.snappingTarget);
			}
			return new SnapToPointResult(this.currentSnapToPointOrigin, this.currentSnappedPoint, this.currentOriginInfo, this.SecondarySnapToPointOrigins);
		}

		// Token: 0x06005AAF RID: 23215 RVA: 0x0004B78C File Offset: 0x0004998C
		public void Collect(Point3D point, Enum snapToPointOrigin)
		{
			this.Collect(point, snapToPointOrigin, null);
		}

		// Token: 0x06005AB0 RID: 23216 RVA: 0x0016F4A0 File Offset: 0x0016D6A0
		public void Collect(Point3D point, Enum snapToPointOrigin, string originInfo)
		{
			if (point == null)
			{
				return;
			}
			if (this.currentSnappedPoint == null)
			{
				this.currentSnappedPoint = point;
				this.currentDistanceToTarget = point.DistanceTo(this.snappingTarget);
				this.currentSnapToPointOrigin = snapToPointOrigin;
				this.currentOriginInfo = originInfo;
				return;
			}
			double num = point.DistanceTo(this.snappingTarget);
			if (num < this.currentDistanceToTarget && !#Emc.#zmc(num, this.currentDistanceToTarget))
			{
				this.currentSnappedPoint = point;
				this.currentDistanceToTarget = num;
				this.currentSnapToPointOrigin = snapToPointOrigin;
				this.currentOriginInfo = originInfo;
				this.SecondarySnapToPointOrigins.Clear();
				return;
			}
			if (#Emc.#zmc(num, this.currentDistanceToTarget))
			{
				this.SecondarySnapToPointOrigins.Add(snapToPointOrigin);
			}
		}

		// Token: 0x040025E5 RID: 9701
		private readonly Point3D snappingTarget;

		// Token: 0x040025E6 RID: 9702
		private readonly SnapPointsCollectorMode collectorMode;

		// Token: 0x040025E7 RID: 9703
		private Point3D currentSnappedPoint;

		// Token: 0x040025E8 RID: 9704
		private double currentDistanceToTarget;

		// Token: 0x040025E9 RID: 9705
		private Enum currentSnapToPointOrigin;

		// Token: 0x040025EA RID: 9706
		private string currentOriginInfo;
	}
}
