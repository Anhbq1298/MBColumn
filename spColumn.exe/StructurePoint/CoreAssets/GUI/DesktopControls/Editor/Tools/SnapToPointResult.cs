using System;
using System.Collections.Generic;
using System.Linq;
using devDept.Geometry;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools
{
	// Token: 0x02000AE9 RID: 2793
	public sealed class SnapToPointResult
	{
		// Token: 0x06005AB1 RID: 23217 RVA: 0x0004B797 File Offset: 0x00049997
		public SnapToPointResult(Enum snapToPointOrigin, Point3D point)
		{
			this.SecondarySnapToPointOrigins = new HashSet<Enum>();
			this.Point = point;
			this.SnapToPointOrigin = snapToPointOrigin;
			this.NoSnappingPerformed = (snapToPointOrigin == null);
			this.SnappingPerformed = !this.NoSnappingPerformed;
		}

		// Token: 0x06005AB2 RID: 23218 RVA: 0x0004B7D1 File Offset: 0x000499D1
		public SnapToPointResult(Enum snapToPointOrigin, Point3D point, string snapToPointOriginInfo, ISet<Enum> secondarySnapToPointOrigins) : this(snapToPointOrigin, point)
		{
			this.SnapPointOriginInfo = snapToPointOriginInfo;
			if (secondarySnapToPointOrigins != null)
			{
				this.SecondarySnapToPointOrigins = secondarySnapToPointOrigins;
			}
		}

		// Token: 0x17001992 RID: 6546
		// (get) Token: 0x06005AB3 RID: 23219 RVA: 0x0004B7EE File Offset: 0x000499EE
		public Enum SnapToPointOrigin { get; }

		// Token: 0x17001993 RID: 6547
		// (get) Token: 0x06005AB4 RID: 23220 RVA: 0x0004B7F6 File Offset: 0x000499F6
		public string SnapPointOriginInfo { get; }

		// Token: 0x17001994 RID: 6548
		// (get) Token: 0x06005AB5 RID: 23221 RVA: 0x0004B7FE File Offset: 0x000499FE
		public Point3D Point { get; }

		// Token: 0x17001995 RID: 6549
		// (get) Token: 0x06005AB6 RID: 23222 RVA: 0x0004B806 File Offset: 0x00049A06
		public bool NoSnappingPerformed { get; }

		// Token: 0x17001996 RID: 6550
		// (get) Token: 0x06005AB7 RID: 23223 RVA: 0x0004B80E File Offset: 0x00049A0E
		public bool SnappingPerformed { get; }

		// Token: 0x17001997 RID: 6551
		// (get) Token: 0x06005AB8 RID: 23224 RVA: 0x0004B816 File Offset: 0x00049A16
		public ISet<Enum> SecondarySnapToPointOrigins { get; }

		// Token: 0x06005AB9 RID: 23225 RVA: 0x0004B81E File Offset: 0x00049A1E
		public bool IsOfOrigin(params Enum[] origins)
		{
			return origins != null && (origins.Any((Enum item) => this.SnapToPointOrigin == item) || origins.Any((Enum item) => this.SecondarySnapToPointOrigins.Contains(item)));
		}
	}
}
