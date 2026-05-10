using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #klc;
using #UYd;
using Microsoft.SqlServer.Types;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Data
{
	// Token: 0x0200038E RID: 910
	public class ShapeData
	{
		// Token: 0x06001D8A RID: 7562 RVA: 0x0001C505 File Offset: 0x0001A705
		protected ShapeData()
		{
			this.#a = new List<PolygonData>(1);
			this.DetermineRelationshipsState = #jlc.#a;
		}

		// Token: 0x06001D8B RID: 7563 RVA: 0x0001C520 File Offset: 0x0001A720
		protected ShapeData(#jlc determineRelationships)
		{
			this.#a = new List<PolygonData>(1);
			this.DetermineRelationshipsState = determineRelationships;
		}

		// Token: 0x06001D8C RID: 7564 RVA: 0x0001C53B File Offset: 0x0001A73B
		protected ShapeData(PolygonData polygon) : this()
		{
			#X0d.#V0d(polygon, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107457557));
			this.DetermineRelationshipsState = #jlc.#a;
			this.#Ovc(new PolygonData[]
			{
				polygon
			});
		}

		// Token: 0x06001D8D RID: 7565 RVA: 0x0001C575 File Offset: 0x0001A775
		protected ShapeData(PolygonData polygon, #jlc determineRelationships) : this()
		{
			#X0d.#V0d(polygon, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107457557));
			this.DetermineRelationshipsState = determineRelationships;
			this.#Ovc(new PolygonData[]
			{
				polygon
			});
		}

		// Token: 0x06001D8E RID: 7566 RVA: 0x0001C5AF File Offset: 0x0001A7AF
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected ShapeData(IEnumerable<PolygonData> polygons) : this()
		{
			#X0d.#V0d(polygons, #Phc.#3hc(107457984), Component.Geometry, #Phc.#3hc(107457967));
			this.DetermineRelationshipsState = #jlc.#a;
			this.#Ovc(polygons);
		}

		// Token: 0x06001D8F RID: 7567 RVA: 0x0001C5E0 File Offset: 0x0001A7E0
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected ShapeData(IEnumerable<PolygonData> polygons, #jlc determineRelationships) : this()
		{
			#X0d.#V0d(polygons, #Phc.#3hc(107457984), Component.Geometry, #Phc.#3hc(107457967));
			this.DetermineRelationshipsState = determineRelationships;
			this.#Ovc(polygons);
		}

		// Token: 0x06001D90 RID: 7568 RVA: 0x0001C611 File Offset: 0x0001A811
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected ShapeData(ShapeData shape) : this()
		{
			#X0d.#V0d(shape, #Phc.#3hc(107371956), Component.Geometry, #Phc.#3hc(107457946));
			this.DetermineRelationshipsState = #jlc.#a;
			this.#pR(shape.Polygons, false);
		}

		// Token: 0x06001D91 RID: 7569 RVA: 0x0001C648 File Offset: 0x0001A848
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		protected ShapeData(ShapeData shape, #jlc determineRelationships) : this()
		{
			#X0d.#V0d(shape, #Phc.#3hc(107371956), Component.Geometry, #Phc.#3hc(107457946));
			this.DetermineRelationshipsState = determineRelationships;
			this.#pR(shape.Polygons, false);
		}

		// Token: 0x17000A52 RID: 2642
		// (get) Token: 0x06001D92 RID: 7570 RVA: 0x0001C67F File Offset: 0x0001A87F
		public IReadOnlyList<PolygonData> Polygons
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17000A53 RID: 2643
		// (get) Token: 0x06001D93 RID: 7571 RVA: 0x0001C68B File Offset: 0x0001A88B
		// (set) Token: 0x06001D94 RID: 7572 RVA: 0x0001C697 File Offset: 0x0001A897
		public double Area { get; private set; }

		// Token: 0x17000A54 RID: 2644
		// (get) Token: 0x06001D95 RID: 7573 RVA: 0x0001C6A8 File Offset: 0x0001A8A8
		// (set) Token: 0x06001D96 RID: 7574 RVA: 0x0001C6B4 File Offset: 0x0001A8B4
		public #jlc DetermineRelationshipsState { get; set; }

		// Token: 0x17000A55 RID: 2645
		// (get) Token: 0x06001D97 RID: 7575 RVA: 0x0001C6C5 File Offset: 0x0001A8C5
		public int PolygonsCount
		{
			get
			{
				return this.#a.Count;
			}
		}

		// Token: 0x06001D98 RID: 7576 RVA: 0x0001C6DA File Offset: 0x0001A8DA
		public static ShapeData #6wc(IEnumerable<PolygonData> #yP)
		{
			#X0d.#V0d(#yP, #Phc.#3hc(107372425), Component.Geometry, #Phc.#3hc(107457861));
			return new ShapeData(#yP);
		}

		// Token: 0x06001D99 RID: 7577 RVA: 0x000C183C File Offset: 0x000BFA3C
		public static ShapeData #6wc(IEnumerable<PolygonData> #yP, #jlc #7wc)
		{
			if (true)
			{
				#X0d.#V0d(#yP, #Phc.#3hc(107372425), Component.Geometry, #Phc.#3hc(107457861));
			}
			return new ShapeData(#yP, #7wc);
		}

		// Token: 0x06001D9A RID: 7578 RVA: 0x0001C715 File Offset: 0x0001A915
		public static ShapeData #6wc()
		{
			return new ShapeData();
		}

		// Token: 0x06001D9B RID: 7579 RVA: 0x0001C720 File Offset: 0x0001A920
		public static ShapeData #6wc(PolygonData #JP, #jlc #7wc = #jlc.#b)
		{
			return new ShapeData(#JP, #7wc);
		}

		// Token: 0x06001D9C RID: 7580 RVA: 0x000C188C File Offset: 0x000BFA8C
		public void #8wc(IList<PolygonData> #9wc)
		{
			#X0d.#V0d(#9wc, #Phc.#3hc(107457984), Component.Geometry, #Phc.#3hc(107457840));
			this.#yl();
			this.#pR(#9wc);
			this.#t3h();
		}

		// Token: 0x06001D9D RID: 7581 RVA: 0x000C18EC File Offset: 0x000BFAEC
		public void #8wc(PolygonData #JP)
		{
			if (#JP == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399958));
			}
			this.#yl();
			this.#pR(new List<PolygonData>
			{
				#JP
			});
			this.#t3h();
		}

		// Token: 0x06001D9E RID: 7582 RVA: 0x000C1950 File Offset: 0x000BFB50
		public virtual void #pR(IEnumerable<PolygonData> #9wc)
		{
			do
			{
				if (3 != 0)
				{
					#X0d.#V0d(#9wc, #Phc.#3hc(107457984), Component.Geometry, #Phc.#3hc(107457275));
					this.#a.AddRange(#9wc);
					while (3 != 0)
					{
						if (this.DetermineRelationshipsState != #jlc.#a)
						{
							goto IL_33;
						}
						if (!false)
						{
							this.#ixc();
							goto IL_33;
						}
					}
					continue;
				}
				IL_33:;
			}
			while (7 == 0);
		}

		// Token: 0x06001D9F RID: 7583 RVA: 0x000C19C4 File Offset: 0x000BFBC4
		public virtual void #axc(int #4jb, PolygonData #JP)
		{
			string #R0d = #Phc.#3hc(107399958);
			Component #x6c = Component.Geometry;
			string #Qic = #Phc.#3hc(107457190);
			if (!false)
			{
				#X0d.#V0d(#JP, #R0d, #x6c, #Qic);
			}
			this.#a[#4jb] = #JP;
		}

		// Token: 0x06001DA0 RID: 7584 RVA: 0x000C1A20 File Offset: 0x000BFC20
		public virtual void #pR(IEnumerable<PolygonData> #9wc, bool #bxc)
		{
			for (;;)
			{
				#X0d.#V0d(#9wc, #Phc.#3hc(107457984), Component.Geometry, #Phc.#3hc(107457169));
				while (7 != 0)
				{
					if (false)
					{
						return;
					}
					this.#a.AddRange(#9wc);
					if (!#bxc)
					{
						return;
					}
					while (!false)
					{
						if (this.DetermineRelationshipsState != #jlc.#a)
						{
							return;
						}
						if (!false)
						{
							goto Block_4;
						}
					}
				}
			}
			Block_4:
			this.#ixc();
		}

		// Token: 0x06001DA1 RID: 7585 RVA: 0x0001C735 File Offset: 0x0001A935
		public virtual PolygonData #cxc(int #4jb)
		{
			return this.#a[#4jb];
		}

		// Token: 0x06001DA2 RID: 7586 RVA: 0x000C1A98 File Offset: 0x000BFC98
		public void #dxc(ShapeData #rP)
		{
			for (;;)
			{
				#X0d.#V0d(#rP, #Phc.#3hc(107371527), Component.Geometry, #Phc.#3hc(107457116));
				if (!false)
				{
					#rP.#8wc(this.#a);
					if (!false)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06001DA3 RID: 7587 RVA: 0x000C1AF0 File Offset: 0x000BFCF0
		public bool #lwc(Point #Ng)
		{
			ShapeData.#AZb #AZb = new ShapeData.#AZb();
			#AZb.#a = #Ng;
			return this.#a.Any(new Func<PolygonData, bool>(#AZb.#Xyc));
		}

		// Token: 0x06001DA4 RID: 7588 RVA: 0x000C1B40 File Offset: 0x000BFD40
		public bool #Lnc(Point #Ng)
		{
			ShapeData.#jac #jac = new ShapeData.#jac();
			#jac.#a = #Ng;
			int num;
			int num2;
			if (!false)
			{
				num = this.PolygonsCount;
				num2 = 0;
				goto IL_27;
			}
			goto IL_7F;
			IL_52:
			int num3;
			bool result;
			while (!false)
			{
				if (num3 <= 1)
				{
					goto IL_7F;
				}
				int num4 = num = (num3 = ((result = this.Polygons.Skip(1).Any(new Func<PolygonData, bool>(#jac.#0yc))) ? 1 : 0));
				if (-1 != 0)
				{
					int num5 = num2 = 0;
					if (num5 == 0)
					{
						return num4 == num5;
					}
					goto IL_27;
				}
			}
			return result;
			IL_27:
			if (num <= num2)
			{
				return false;
			}
			bool flag = this.#a[0].#Lnc(#jac.#a);
			if (flag)
			{
				result = ((num3 = this.PolygonsCount) != 0);
				goto IL_52;
			}
			IL_7F:
			bool result2 = (num3 = ((result = flag) ? 1 : 0)) != 0;
			if (2 != 0)
			{
				return result2;
			}
			goto IL_52;
		}

		// Token: 0x06001DA5 RID: 7589 RVA: 0x0001C74F File Offset: 0x0001A94F
		public virtual void #yl()
		{
			this.#a.Clear();
			this.#t3h();
		}

		// Token: 0x06001DA6 RID: 7590 RVA: 0x0001C772 File Offset: 0x0001A972
		public List<Point> #fxc()
		{
			return this.#a.SelectMany(new Func<PolygonData, IEnumerable<Point>>(ShapeData.<>c.<>9.#1yc)).ToList<Point>();
		}

		// Token: 0x06001DA7 RID: 7591 RVA: 0x000C1C14 File Offset: 0x000BFE14
		public Point? #gxc()
		{
			if (!this.Polygons.Any<PolygonData>())
			{
				return null;
			}
			SqlGeometry sqlGeometry = this.#cxc(0).SqlGeometry.STCentroid();
			if (sqlGeometry.IsNull)
			{
				return null;
			}
			return new Point?(new Point(sqlGeometry.STX.Value, sqlGeometry.STY.Value));
		}

		// Token: 0x06001DA8 RID: 7592 RVA: 0x000C1CC4 File Offset: 0x000BFEC4
		public double? #Gvc()
		{
			if (this.Polygons.Any<PolygonData>())
			{
				double value;
				double num = value = (double)this.#cxc(0).SqlGeometry.STArea();
				if (true)
				{
					value = num;
				}
				return new double?(value);
			}
			return null;
		}

		// Token: 0x06001DA9 RID: 7593 RVA: 0x000C1D2C File Offset: 0x000BFF2C
		protected void #t3h()
		{
			double num = 0.0;
			double num2;
			if (!false)
			{
				num2 = num;
			}
			if (!this.Polygons.Any<PolygonData>())
			{
				goto IL_55;
			}
			SqlDouble sqlDouble;
			if (!false)
			{
				SqlGeometry sqlGeometry = this.#cxc(0).SqlGeometry;
				if (sqlGeometry == null)
				{
					goto IL_38;
				}
				sqlDouble = sqlGeometry.STArea();
				goto IL_4D;
			}
			int num5;
			int num4;
			for (;;)
			{
				IL_91:
				int num3 = num4 = num5;
				if (-1 == 0 || -1 == 0)
				{
					goto IL_56;
				}
				if (num3 >= this.PolygonsCount)
				{
					break;
				}
				double num7;
				double num6 = num7 = num2;
				SqlGeometry sqlGeometry2 = this.#cxc(num5).SqlGeometry;
				double num8;
				if (sqlGeometry2 != null)
				{
					sqlDouble = sqlGeometry2.STArea();
					num8 = sqlDouble.Value;
					goto IL_85;
				}
				if (2 != 0)
				{
					num8 = 0.0;
					goto IL_85;
				}
				IL_86:
				num2 = num7;
				if (false)
				{
					goto IL_4D;
				}
				if (true)
				{
					num5++;
					continue;
				}
				goto IL_38;
				IL_85:
				num7 = num6 - num8;
				goto IL_86;
			}
			this.Area = num2;
			return;
			IL_38:
			double num9 = 0.0;
			goto IL_54;
			IL_4D:
			num9 = sqlDouble.Value;
			IL_54:
			num2 = num9;
			IL_55:
			num4 = 1;
			IL_56:
			num5 = num4;
			goto IL_91;
		}

		// Token: 0x06001DAA RID: 7594 RVA: 0x0001C7AF File Offset: 0x0001A9AF
		private void #Ovc(IEnumerable<PolygonData> #4lc)
		{
			this.#pR(#4lc);
			if (this.DetermineRelationshipsState == #jlc.#a)
			{
				this.#ixc();
			}
		}

		// Token: 0x06001DAB RID: 7595 RVA: 0x0001C7E2 File Offset: 0x0001A9E2
		protected void #ixc()
		{
			GeometryHelper.#Onc(this);
			this.#t3h();
		}

		// Token: 0x04000BCF RID: 3023
		private readonly List<PolygonData> #a;

		// Token: 0x04000BD0 RID: 3024
		[CompilerGenerated]
		private double #b;

		// Token: 0x04000BD1 RID: 3025
		[CompilerGenerated]
		private #jlc #c;

		// Token: 0x02000390 RID: 912
		[CompilerGenerated]
		private sealed class #AZb
		{
			// Token: 0x06001DB0 RID: 7600 RVA: 0x0001C820 File Offset: 0x0001AA20
			internal bool #Xyc(PolygonData #Rf)
			{
				return #Rf.#lwc(this.#a);
			}

			// Token: 0x04000BD4 RID: 3028
			public Point #a;
		}

		// Token: 0x02000391 RID: 913
		[CompilerGenerated]
		private sealed class #jac
		{
			// Token: 0x06001DB2 RID: 7602 RVA: 0x0001C83A File Offset: 0x0001AA3A
			internal bool #0yc(PolygonData #Rf)
			{
				return #Rf.#Lnc(this.#a);
			}

			// Token: 0x04000BD5 RID: 3029
			public Point #a;
		}
	}
}
