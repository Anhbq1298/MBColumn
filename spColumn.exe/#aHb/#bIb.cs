using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;

namespace #aHb
{
	// Token: 0x02000613 RID: 1555
	internal sealed class #bIb
	{
		// Token: 0x1700107F RID: 4223
		// (get) Token: 0x060034C9 RID: 13513 RVA: 0x0002E583 File Offset: 0x0002C783
		public static #bIb Instance { get; } = new #bIb();

		// Token: 0x060034CA RID: 13514 RVA: 0x0010648C File Offset: 0x0010468C
		public Point3D[] #7Hb(double #HS, bool #8Hb)
		{
			#HS = Math.Round(#HS, 3) * 1.01;
			#bIb.#Fbc #Fbc = this.#aIb(#HS);
			if (#Fbc == null)
			{
				Point3D point3D = new Point3D();
				#Fbc = new #bIb.#Fbc();
				#Fbc.Points = EyeshotHelper.ConstructRegularPolygon(point3D, #HS, 20, 0.0, true);
				#bIb.#9Hb(#Fbc.Points, point3D);
				#Fbc.Radius = #HS;
				if (this.#b.Count > 50)
				{
					this.#b.Clear();
				}
				this.#b[#HS] = #Fbc;
			}
			if (#8Hb)
			{
				Point3D[] array = new Point3D[#Fbc.Points.Count];
				for (int i = 0; i < #Fbc.Points.Count; i++)
				{
					Point3D point3D2 = #Fbc.Points[i];
					array[i] = new Point3D(point3D2.X, point3D2.Y);
				}
				return array;
			}
			return #Fbc.Points.ToArray();
		}

		// Token: 0x060034CB RID: 13515 RVA: 0x00106590 File Offset: 0x00104790
		private static void #9Hb(List<Point3D> #AHb, Point3D #wob)
		{
			for (int i = 1; i < #AHb.Count; i += 3)
			{
				#AHb.Insert(i, new Point3D(#wob.X, #wob.Y));
				#AHb.Insert(i + 2, new Point3D(#AHb[i + 1].X, #AHb[i + 1].Y));
			}
		}

		// Token: 0x060034CC RID: 13516 RVA: 0x001065FC File Offset: 0x001047FC
		private #bIb.#Fbc #aIb(double #HS)
		{
			#bIb.#92b #92b = new #bIb.#92b();
			#92b.#a = #HS;
			#bIb.#Fbc #Fbc;
			if (!this.#b.TryGetValue(#92b.#a, out #Fbc))
			{
				return null;
			}
			if (Math.Abs(#Fbc.Radius - #92b.#a) <= 1E-05)
			{
				return #Fbc;
			}
			return this.#b.Values.FirstOrDefault(new Func<#bIb.#Fbc, bool>(#92b.#Gbc));
		}

		// Token: 0x040015DE RID: 5598
		private const int #a = 50;

		// Token: 0x040015DF RID: 5599
		private readonly Dictionary<double, #bIb.#Fbc> #b = new Dictionary<double, #bIb.#Fbc>();

		// Token: 0x040015E0 RID: 5600
		[CompilerGenerated]
		private static readonly #bIb #c;

		// Token: 0x02000614 RID: 1556
		private sealed class #Fbc
		{
			// Token: 0x17001080 RID: 4224
			// (get) Token: 0x060034CF RID: 13519 RVA: 0x0002E5AD File Offset: 0x0002C7AD
			// (set) Token: 0x060034D0 RID: 13520 RVA: 0x0002E5B9 File Offset: 0x0002C7B9
			public double Radius { get; set; }

			// Token: 0x17001081 RID: 4225
			// (get) Token: 0x060034D1 RID: 13521 RVA: 0x0002E5CA File Offset: 0x0002C7CA
			// (set) Token: 0x060034D2 RID: 13522 RVA: 0x0002E5D6 File Offset: 0x0002C7D6
			public List<Point3D> Points { get; set; }

			// Token: 0x040015E1 RID: 5601
			[CompilerGenerated]
			private double #a;

			// Token: 0x040015E2 RID: 5602
			[CompilerGenerated]
			private List<Point3D> #b;
		}

		// Token: 0x02000615 RID: 1557
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x060034D5 RID: 13525 RVA: 0x0002E5E7 File Offset: 0x0002C7E7
			internal bool #Gbc(#bIb.#Fbc #Rf)
			{
				return Math.Abs(#Rf.Radius - this.#a) <= 1E-05;
			}

			// Token: 0x040015E3 RID: 5603
			public double #a;
		}
	}
}
