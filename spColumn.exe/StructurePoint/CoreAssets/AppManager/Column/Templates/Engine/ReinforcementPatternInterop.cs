using System;
using System.Collections.Generic;
using System.Linq;
using #xKe;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine
{
	// Token: 0x0200107A RID: 4218
	internal static class ReinforcementPatternInterop
	{
		// Token: 0x0600902B RID: 36907 RVA: 0x001E80E8 File Offset: 0x001E62E8
		public static ReinforcementPatternInterop.MyPoint[] #Mfe(int #Nfe, int #Ofe, double #1mc, double #2mc, double #3mc, double #4mc, bool #Pfe, bool #Qfe, bool #Rfe, bool #Sfe, bool #Tfe)
		{
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#Mfe(#Nfe, #Ofe, new devDept.Geometry.Point3D(#1mc, #2mc), new devDept.Geometry.Point3D(#3mc, #4mc), #Pfe, #Qfe, #Rfe, #Sfe, #Tfe));
		}

		// Token: 0x0600902C RID: 36908 RVA: 0x00074776 File Offset: 0x00072976
		public static ReinforcementPatternInterop.MyPoint[] #Ufe(double #1mc, double #2mc, double #3mc, double #4mc, double #NP)
		{
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#NLe(new devDept.Geometry.Point3D(#1mc, #2mc), new devDept.Geometry.Point3D(#3mc, #4mc), #NP));
		}

		// Token: 0x0600902D RID: 36909 RVA: 0x00074792 File Offset: 0x00072992
		public static ReinforcementPatternInterop.MyPoint[] #Vfe(double #1mc, double #2mc, double #3mc, double #4mc, double #NP)
		{
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#MLe(new devDept.Geometry.Point3D(#1mc, #2mc), new devDept.Geometry.Point3D(#3mc, #4mc), (int)#NP));
		}

		// Token: 0x0600902E RID: 36910 RVA: 0x001E811C File Offset: 0x001E631C
		public static ReinforcementPatternInterop.MyPoint[] #Wfe(double #Wmc, double #Xmc, double #1mc, double #2mc, double #NP)
		{
			double #Xjc = GeometryHelper.#lnc(#Wmc, #Xmc, #1mc, #2mc);
			double #HS = GeometryHelper.#lcb(new Point(#Wmc, #Xmc), new Point(#NP, #2mc));
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#KLe(new devDept.Geometry.Point3D(#Wmc, #Xmc), #HS, #Xjc, #NP));
		}

		// Token: 0x0600902F RID: 36911 RVA: 0x001E8160 File Offset: 0x001E6360
		public static ReinforcementPatternInterop.MyPoint[] #Xfe(int #Yfe, int #Zfe, double #0fe, double #1fe, double #2fe, int #pKb, double #3fe, double #4fe, bool #5fe, bool #6fe, bool #7fe)
		{
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#Xfe(#Yfe, #Zfe, #0fe, new devDept.Geometry.Point3D(#1fe, #2fe), (#CLe)#pKb, new devDept.Geometry.Point3D(#3fe, #4fe), #5fe, #6fe, #7fe));
		}

		// Token: 0x06009030 RID: 36912 RVA: 0x000747AF File Offset: 0x000729AF
		public static ReinforcementPatternInterop.MyPoint[] #8fe(int #Yfe, double #9fe, double #1fe, double #2fe, double #age, double #bge, double #3fe, double #4fe, bool #5fe, bool #6fe)
		{
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#8fe(#Yfe, #9fe, new devDept.Geometry.Point3D(#1fe, #2fe), new devDept.Geometry.Point3D(#age, #bge), new devDept.Geometry.Point3D(#3fe, #4fe), #5fe, #6fe));
		}

		// Token: 0x06009031 RID: 36913 RVA: 0x001E8194 File Offset: 0x001E6394
		public static ReinforcementPatternInterop.MyPoint[] #cge(double #Wmc, double #Xmc, double #1mc, double #2mc, double #AWc)
		{
			double #Xjc = GeometryHelper.#lnc(#Wmc, #Xmc, #1mc, #2mc);
			double #HS = GeometryHelper.#lcb(new Point(#Wmc, #Xmc), new Point(#AWc, #2mc));
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#LLe(new devDept.Geometry.Point3D(#Wmc, #Xmc), #HS, #Xjc, (int)#AWc));
		}

		// Token: 0x06009032 RID: 36914 RVA: 0x000747DA File Offset: 0x000729DA
		public static ReinforcementPatternInterop.MyPoint[] #dge(double #1mc, double #2mc, double #3mc, double #4mc, double #ege, double #fge)
		{
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#FLe(new devDept.Geometry.Point3D(#1mc, #2mc), new devDept.Geometry.Point3D(#3mc, #4mc), (int)#ege, (int)#fge));
		}

		// Token: 0x06009033 RID: 36915 RVA: 0x000747FA File Offset: 0x000729FA
		public static ReinforcementPatternInterop.MyPoint[] #gge(double #1mc, double #2mc, double #3mc, double #4mc, double #hge, double #ige)
		{
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#ELe(new devDept.Geometry.Point3D(#1mc, #2mc), new devDept.Geometry.Point3D(#3mc, #4mc), #hge, #ige));
		}

		// Token: 0x06009034 RID: 36916 RVA: 0x00074818 File Offset: 0x00072A18
		public static ReinforcementPatternInterop.MyPoint[] #jge(double #1mc, double #2mc, double #3mc, double #4mc, double #ege, double #fge, bool #Pfe)
		{
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#JLe(new devDept.Geometry.Point3D(#1mc, #2mc), new devDept.Geometry.Point3D(#3mc, #4mc), (int)#ege, (int)#fge, #Pfe));
		}

		// Token: 0x06009035 RID: 36917 RVA: 0x0007483A File Offset: 0x00072A3A
		public static ReinforcementPatternInterop.MyPoint[] #kge(double #1mc, double #2mc, double #3mc, double #4mc, double #hge, double #ige, bool #Pfe)
		{
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#ILe(new devDept.Geometry.Point3D(#1mc, #2mc), new devDept.Geometry.Point3D(#3mc, #4mc), #hge, #ige, #Pfe));
		}

		// Token: 0x06009036 RID: 36918 RVA: 0x0007485A File Offset: 0x00072A5A
		public static ReinforcementPatternInterop.MyPoint[] #lge(double #Wmc, double #Xmc, double #1mc, double #2mc, double #Udb, double #AWc)
		{
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#lge(new devDept.Geometry.Point3D(#Wmc, #Xmc), new devDept.Geometry.Point3D(#1mc, #2mc), #Udb, (int)#AWc));
		}

		// Token: 0x06009037 RID: 36919 RVA: 0x00074879 File Offset: 0x00072A79
		public static ReinforcementPatternInterop.MyPoint[] #mge(double #Wmc, double #Xmc, double #1mc, double #2mc, double #Udb, double #AWc)
		{
			return ReinforcementPatternInterop.#Pb(ReinforcementPatternHelper.#mge(new devDept.Geometry.Point3D(#Wmc, #Xmc), new devDept.Geometry.Point3D(#1mc, #2mc), #Udb, #AWc));
		}

		// Token: 0x06009038 RID: 36920 RVA: 0x001E81D8 File Offset: 0x001E63D8
		public static ReinforcementPatternInterop.MyPoint[] #nge(double #Wmc, double #Xmc, double #1mc, double #2mc, double #Udb)
		{
			devDept.Geometry.Point3D point3D = new devDept.Geometry.Point3D(#Wmc, #Xmc);
			devDept.Geometry.Point3D point3D2 = new devDept.Geometry.Point3D(#1mc, #2mc);
			devDept.Geometry.Point3D point3D3 = point3D2 - point3D;
			float num = GeometryHelper.#Knc(point3D3.Y, point3D3.X);
			int #AWc = (int)(40.0 * Math.Abs(#Udb - (double)num) / 360.0);
			List<devDept.Geometry.Point3D> list = ReinforcementPatternHelper.#lge(point3D, point3D2, #Udb, #AWc).ToList<devDept.Geometry.Point3D>();
			list.Insert(0, point3D);
			list.Add(point3D);
			return ReinforcementPatternInterop.#Pb(list);
		}

		// Token: 0x06009039 RID: 36921 RVA: 0x00074897 File Offset: 0x00072A97
		private static ReinforcementPatternInterop.MyPoint[] #Pb(IEnumerable<devDept.Geometry.Point3D> #BP)
		{
			return #BP.Select(new Func<devDept.Geometry.Point3D, ReinforcementPatternInterop.MyPoint>(ReinforcementPatternInterop.<>c.<>9.#zaf)).ToArray<ReinforcementPatternInterop.MyPoint>();
		}

		// Token: 0x0200107B RID: 4219
		public sealed class MyPoint
		{
			// Token: 0x0600903A RID: 36922 RVA: 0x000748C3 File Offset: 0x00072AC3
			public MyPoint(double x, double y)
			{
				this.x = x;
				this.y = y;
			}

			// Token: 0x04003C88 RID: 15496
			public double x;

			// Token: 0x04003C89 RID: 15497
			public double y;
		}
	}
}
