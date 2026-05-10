using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000893 RID: 2195
	public static class BasicGeometryExtensions
	{
		// Token: 0x0600453D RID: 17725 RVA: 0x0013CC40 File Offset: 0x0013AE40
		public static System.Windows.Media.Media3D.Point3D CalculateCenter(this System.Windows.Media.Media3D.Rect3D systemRect)
		{
			return new System.Windows.Media.Media3D.Point3D(systemRect.X + systemRect.SizeX / 2.0, systemRect.Y + systemRect.SizeY / 2.0, systemRect.Z + systemRect.SizeZ / 2.0);
		}

		// Token: 0x0600453E RID: 17726 RVA: 0x00039AA0 File Offset: 0x00037CA0
		public static System.Windows.Media.Media3D.Point3D Convert(this StructurePoint.CoreAssets.Infrastructure.Data.Point3D point)
		{
			return new System.Windows.Media.Media3D.Point3D(point.X, point.Y, point.Z);
		}

		// Token: 0x0600453F RID: 17727 RVA: 0x00039AC8 File Offset: 0x00037CC8
		public static System.Windows.Point Convert(this StructurePoint.CoreAssets.Infrastructure.Data.Point point)
		{
			return new System.Windows.Point(point.X, point.Y);
		}

		// Token: 0x06004540 RID: 17728 RVA: 0x00039AE9 File Offset: 0x00037CE9
		public static IList<System.Windows.Media.Media3D.Point3D> Convert(this IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points)
		{
			return (from point in points
			select new System.Windows.Media.Media3D.Point3D(point.X, point.Y, point.Z)).ToList<System.Windows.Media.Media3D.Point3D>();
		}

		// Token: 0x06004541 RID: 17729 RVA: 0x00039B21 File Offset: 0x00037D21
		public static IList<System.Windows.Point> Convert(this IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point> points)
		{
			return (from point in points
			select new System.Windows.Point(point.X, point.Y)).ToList<System.Windows.Point>();
		}

		// Token: 0x06004542 RID: 17730 RVA: 0x00039B59 File Offset: 0x00037D59
		public static Vector3D Convert(this #c4d vector)
		{
			return new Vector3D(vector.X, vector.Y, vector.Z);
		}

		// Token: 0x06004543 RID: 17731 RVA: 0x00039B81 File Offset: 0x00037D81
		public static #c4d Convert(this Vector3D vector)
		{
			return new #c4d(vector.X, vector.Y, vector.Z);
		}

		// Token: 0x06004544 RID: 17732 RVA: 0x00039BA9 File Offset: 0x00037DA9
		public static StructurePoint.CoreAssets.Infrastructure.Data.Point3D Convert(this System.Windows.Media.Media3D.Point3D point)
		{
			return new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(point.X, point.Y, point.Z);
		}

		// Token: 0x06004545 RID: 17733 RVA: 0x00039BD1 File Offset: 0x00037DD1
		public static StructurePoint.CoreAssets.Infrastructure.Data.Point Convert(this System.Windows.Point point)
		{
			return new StructurePoint.CoreAssets.Infrastructure.Data.Point(point.X, point.Y);
		}

		// Token: 0x06004546 RID: 17734 RVA: 0x00039BF2 File Offset: 0x00037DF2
		public static IList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> Convert(this IEnumerable<System.Windows.Media.Media3D.Point3D> points)
		{
			return (from point in points
			select new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(point.X, point.Y, point.Z)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>();
		}

		// Token: 0x06004547 RID: 17735 RVA: 0x00039C2A File Offset: 0x00037E2A
		public static IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> Convert(this IEnumerable<System.Windows.Point> points)
		{
			return (from point in points
			select new StructurePoint.CoreAssets.Infrastructure.Data.Point(point.X, point.Y)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
		}

		// Token: 0x06004548 RID: 17736 RVA: 0x0013CCAC File Offset: 0x0013AEAC
		public static StructurePoint.CoreAssets.Infrastructure.Data.Rect3D Convert(this System.Windows.Media.Media3D.Rect3D rect)
		{
			return new StructurePoint.CoreAssets.Infrastructure.Data.Rect3D(rect.Location.Convert(), new #03d(rect.Size.X, rect.Size.Y, rect.Size.Z));
		}

		// Token: 0x06004549 RID: 17737 RVA: 0x0013CD08 File Offset: 0x0013AF08
		public static System.Windows.Rect Convert(this StructurePoint.CoreAssets.Infrastructure.Data.Rect rect)
		{
			return new System.Windows.Rect(rect.Location.Convert(), new System.Windows.Size(rect.Size.Width, rect.Size.Height));
		}

		// Token: 0x0600454A RID: 17738 RVA: 0x00039C62 File Offset: 0x00037E62
		public static System.Windows.Size Convert(this StructurePoint.CoreAssets.Infrastructure.Data.Size size)
		{
			return new System.Windows.Size(size.Width, size.Height);
		}

		// Token: 0x0600454B RID: 17739 RVA: 0x00039C83 File Offset: 0x00037E83
		public static StructurePoint.CoreAssets.Infrastructure.Data.Size Convert(this System.Windows.Size size)
		{
			return new StructurePoint.CoreAssets.Infrastructure.Data.Size(size.Width, size.Height);
		}

		// Token: 0x0600454C RID: 17740 RVA: 0x00039CA4 File Offset: 0x00037EA4
		public static Size3D Convert(this #03d size3D)
		{
			return new Size3D(size3D.X, size3D.Y, size3D.Z);
		}

		// Token: 0x0600454D RID: 17741 RVA: 0x00039CCC File Offset: 0x00037ECC
		public static #03d Convert(this Size3D size3D)
		{
			return new #03d(size3D.X, size3D.Y, size3D.Z);
		}

		// Token: 0x0600454E RID: 17742 RVA: 0x0013CD58 File Offset: 0x0013AF58
		public static StructurePoint.CoreAssets.Infrastructure.Data.Rect Convert(this System.Windows.Rect rect)
		{
			return new StructurePoint.CoreAssets.Infrastructure.Data.Rect(rect.Location.Convert(), new StructurePoint.CoreAssets.Infrastructure.Data.Size(rect.Size.Width, rect.Size.Height));
		}

		// Token: 0x0600454F RID: 17743 RVA: 0x0013CDA8 File Offset: 0x0013AFA8
		public static System.Windows.Media.Media3D.Rect3D Convert(this StructurePoint.CoreAssets.Infrastructure.Data.Rect3D rect)
		{
			return new System.Windows.Media.Media3D.Rect3D(rect.Location.Convert(), new Size3D(rect.Size.X, rect.Size.Y, rect.Size.Z));
		}
	}
}
