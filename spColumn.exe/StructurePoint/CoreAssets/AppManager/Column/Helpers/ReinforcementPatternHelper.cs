using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #xKe;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.AppManager.Column.Helpers
{
	// Token: 0x02001281 RID: 4737
	public static class ReinforcementPatternHelper
	{
		// Token: 0x06009EC0 RID: 40640 RVA: 0x0021AACC File Offset: 0x00218CCC
		public static List<devDept.Geometry.Point3D> #qP(SectionPolygon #rP, double #sP, bool #vP)
		{
			List<devDept.Geometry.Point3D> list = new List<devDept.Geometry.Point3D>();
			if (#sP <= 0.0 || #rP == null)
			{
				return list;
			}
			IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> list2 = BooleanOperationsHelper.#Rlc(#rP.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.Infrastructure.Data.Point>(ReinforcementPatternHelper.<>c.<>9.#ngf)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>(), (#vP ? -1.0 : 1.0) * #sP);
			if (list2 != null && list2.Count >= 2)
			{
				if (StructurePoint.CoreAssets.Infrastructure.Data.Point.#F3d(list2.First<StructurePoint.CoreAssets.Infrastructure.Data.Point>(), list2.Last<StructurePoint.CoreAssets.Infrastructure.Data.Point>()))
				{
					list2.Add(list2.First<StructurePoint.CoreAssets.Infrastructure.Data.Point>());
				}
				list.AddRange(list2.Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, devDept.Geometry.Point3D>(ReinforcementPatternHelper.<>c.<>9.#ogf)));
			}
			return list;
		}

		// Token: 0x06009EC1 RID: 40641 RVA: 0x0021AB98 File Offset: 0x00218D98
		public static IEnumerable<devDept.Geometry.Point3D> #Xfe(int #Yfe, int #Nfe, double #9fe, devDept.Geometry.Point3D #Xrb, #CLe #pKb, devDept.Geometry.Point3D #DLe, bool #5fe, bool #6fe, bool #7fe)
		{
			bool flag = #pKb == #CLe.#b || #pKb == #CLe.#a;
			devDept.Geometry.Point3D point3D = flag ? new devDept.Geometry.Point3D(#Xrb.X, #DLe.Y) : new devDept.Geometry.Point3D(#DLe.X, #Xrb.Y);
			#9fe = ((#pKb == #CLe.#b || #pKb == #CLe.#d) ? (-#9fe) : #9fe);
			int num;
			for (int i = 0; i < #Nfe; i = num + 1)
			{
				bool flag2 = i != 0 && i != #Nfe - 1;
				if (flag2 || (i == 0 && #5fe) || (i == #Nfe - 1 && #6fe))
				{
					if (#Yfe == 1)
					{
						yield return #Xrb + Vector3D.Subtract(point3D, #Xrb) * 0.5;
					}
					else
					{
						List<devDept.Geometry.Point3D> list = ReinforcementPatternHelper.#MLe(#Xrb, point3D, #Yfe).ToList<devDept.Geometry.Point3D>();
						if (flag2 && !#7fe)
						{
							list = list.Take(1).Union(list.Skip(list.Count - 1)).ToList<devDept.Geometry.Point3D>();
						}
						foreach (devDept.Geometry.Point3D point3D2 in list)
						{
							yield return point3D2;
						}
						List<devDept.Geometry.Point3D>.Enumerator enumerator = default(List<devDept.Geometry.Point3D>.Enumerator);
					}
				}
				if (flag)
				{
					#Xrb.X += #9fe;
					point3D.X += #9fe;
				}
				else
				{
					#Xrb.Y += #9fe;
					point3D.Y += #9fe;
				}
				num = i;
			}
			yield break;
			yield break;
		}

		// Token: 0x06009EC2 RID: 40642 RVA: 0x0007CE3F File Offset: 0x0007B03F
		public static IEnumerable<devDept.Geometry.Point3D> #8fe(int #Yfe, double #9fe, devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Yrb, devDept.Geometry.Point3D #DLe, bool #5fe, bool #6fe)
		{
			EyeshootGeneralLineEquation eyeshootGeneralLineEquation = new EyeshootGeneralLineEquation(#Xrb, #Yrb);
			EyeshootGeneralLineEquation generalLineEquation = eyeshootGeneralLineEquation.Normal(#DLe).Normal(#DLe);
			devDept.Geometry.Point3D a = eyeshootGeneralLineEquation.Normal(#Xrb).Intersection(generalLineEquation).#RLe();
			devDept.Geometry.Point3D a2 = eyeshootGeneralLineEquation.Normal(#Yrb).Intersection(generalLineEquation).#RLe();
			int num;
			for (int i = 0; i < #Yfe; i = num + 1)
			{
				devDept.Geometry.Point3D #Akb;
				devDept.Geometry.Point3D #Bkb;
				if (#Yfe == 1)
				{
					#Akb = #Xrb + Vector3D.Subtract(a, #Xrb) * 0.5;
					#Bkb = #Yrb + Vector3D.Subtract(a2, #Yrb) * 0.5;
				}
				else
				{
					#Akb = #Xrb + Vector3D.Subtract(a, #Xrb) * 1.0 * (double)i / (double)(#Yfe - 1);
					#Bkb = #Yrb + Vector3D.Subtract(a2, #Yrb) * 1.0 * (double)i / (double)(#Yfe - 1);
				}
				List<devDept.Geometry.Point3D> list = ReinforcementPatternHelper.#NLe(#Akb, #Bkb, #9fe).ToList<devDept.Geometry.Point3D>();
				if (!#5fe)
				{
					list = list.Skip(1).ToList<devDept.Geometry.Point3D>();
				}
				if (!#6fe)
				{
					list = list.Take(list.Count - 1).ToList<devDept.Geometry.Point3D>();
				}
				foreach (devDept.Geometry.Point3D point3D in list)
				{
					yield return point3D;
				}
				List<devDept.Geometry.Point3D>.Enumerator enumerator = default(List<devDept.Geometry.Point3D>.Enumerator);
				num = i;
			}
			yield break;
			yield break;
		}

		// Token: 0x06009EC3 RID: 40643 RVA: 0x0007CE7C File Offset: 0x0007B07C
		public static IEnumerable<devDept.Geometry.Point3D> #ELe(devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Yrb, double #hge, double #ige)
		{
			devDept.Geometry.Point3D #Akb = new devDept.Geometry.Point3D(#Xrb.X, 0.0);
			devDept.Geometry.Point3D #Bkb = new devDept.Geometry.Point3D(#Yrb.X, 0.0);
			int num = ReinforcementPatternHelper.#ULe(#Akb, #Bkb, #hge);
			devDept.Geometry.Point3D point3D = ReinforcementPatternHelper.#SLe(#Akb, #Bkb, num);
			#Akb = new devDept.Geometry.Point3D(0.0, #Xrb.Y);
			#Bkb = new devDept.Geometry.Point3D(0.0, #Yrb.Y);
			int num2 = ReinforcementPatternHelper.#ULe(#Akb, #Bkb, #ige);
			devDept.Geometry.Point3D point3D2 = ReinforcementPatternHelper.#SLe(#Akb, #Bkb, num2);
			int num3;
			for (int i = 0; i < num2; i = num3 + 1)
			{
				for (int j = 0; j < num; j = num3 + 1)
				{
					if (j == 0 || i == 0 || j == num - 1 || i == num2 - 1)
					{
						yield return new devDept.Geometry.Point3D(#Xrb.X + point3D.X * (double)j, #Xrb.Y + point3D2.Y * (double)i);
					}
					num3 = j;
				}
				num3 = i;
			}
			yield break;
		}

		// Token: 0x06009EC4 RID: 40644 RVA: 0x0007CEA1 File Offset: 0x0007B0A1
		public static IEnumerable<devDept.Geometry.Point3D> #FLe(devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Yrb, int #GLe, int #HLe)
		{
			double num = (#GLe > 1) ? ((#Yrb.X - #Xrb.X) / (double)(#GLe - 1)) : 0.0;
			double num2 = (#HLe > 1) ? ((#Yrb.Y - #Xrb.Y) / (double)(#HLe - 1)) : 0.0;
			int num3;
			for (int i = 0; i < #GLe; i = num3 + 1)
			{
				yield return new devDept.Geometry.Point3D(#Xrb.X + num * (double)i, #Xrb.Y);
				yield return new devDept.Geometry.Point3D(#Xrb.X + num * (double)i, #Yrb.Y);
				num3 = i;
			}
			for (int i = 0; i < #HLe; i = num3 + 1)
			{
				yield return new devDept.Geometry.Point3D(#Xrb.X, #Xrb.Y + num2 * (double)i);
				yield return new devDept.Geometry.Point3D(#Yrb.X, #Xrb.Y + num2 * (double)i);
				num3 = i;
			}
			yield break;
		}

		// Token: 0x06009EC5 RID: 40645 RVA: 0x0007CEC6 File Offset: 0x0007B0C6
		public static IEnumerable<devDept.Geometry.Point3D> #ILe(devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Yrb, double #hge, double #ige, bool #Pfe = true)
		{
			devDept.Geometry.Point3D #Akb = new devDept.Geometry.Point3D(#Xrb.X, 0.0);
			devDept.Geometry.Point3D #Bkb = new devDept.Geometry.Point3D(#Yrb.X, 0.0);
			int num = ReinforcementPatternHelper.#ULe(#Akb, #Bkb, #hge);
			devDept.Geometry.Point3D point3D = ReinforcementPatternHelper.#SLe(#Akb, #Bkb, num);
			#Akb = new devDept.Geometry.Point3D(0.0, #Xrb.Y);
			#Bkb = new devDept.Geometry.Point3D(0.0, #Yrb.Y);
			int num2 = ReinforcementPatternHelper.#ULe(#Akb, #Bkb, #ige);
			devDept.Geometry.Point3D point3D2 = ReinforcementPatternHelper.#SLe(#Akb, #Bkb, num2);
			int num3;
			for (int i = 0; i < num2; i = num3 + 1)
			{
				for (int j = 0; j < num; j = num3 + 1)
				{
					if (j == 0 || j == num - 1 || i == 0 || i == num2 - 1 || #Pfe)
					{
						yield return new devDept.Geometry.Point3D(#Xrb.X + point3D.X * (double)j, #Xrb.Y + point3D2.Y * (double)i);
					}
					num3 = j;
				}
				num3 = i;
			}
			yield break;
		}

		// Token: 0x06009EC6 RID: 40646 RVA: 0x0007CEF3 File Offset: 0x0007B0F3
		public static IEnumerable<devDept.Geometry.Point3D> #JLe(devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Yrb, int #GLe, int #HLe, bool #Pfe = true)
		{
			double num = (#GLe > 1) ? ((#Yrb.X - #Xrb.X) / (double)(#GLe - 1)) : 0.0;
			double num2 = (#HLe > 1) ? ((#Yrb.Y - #Xrb.Y) / (double)(#HLe - 1)) : 0.0;
			devDept.Geometry.Point3D point3D = #Xrb + Vector3D.Subtract(#Yrb, #Xrb) * 0.5;
			if (#GLe == 1 && #HLe == 1)
			{
				yield return point3D;
				yield break;
			}
			if (#GLe == 1)
			{
				IEnumerable<devDept.Geometry.Point3D> enumerable = ReinforcementPatternHelper.#MLe(new devDept.Geometry.Point3D(point3D.X, #Xrb.Y), new devDept.Geometry.Point3D(point3D.X, #Yrb.Y), #HLe);
				foreach (devDept.Geometry.Point3D point3D2 in enumerable)
				{
					yield return point3D2;
				}
				IEnumerator<devDept.Geometry.Point3D> enumerator = null;
				yield break;
			}
			if (#HLe == 1)
			{
				IEnumerable<devDept.Geometry.Point3D> enumerable2 = ReinforcementPatternHelper.#MLe(new devDept.Geometry.Point3D(#Xrb.X, point3D.Y), new devDept.Geometry.Point3D(#Yrb.X, point3D.Y), #GLe);
				foreach (devDept.Geometry.Point3D point3D3 in enumerable2)
				{
					yield return point3D3;
				}
				IEnumerator<devDept.Geometry.Point3D> enumerator = null;
				yield break;
			}
			int num3;
			for (int i = 0; i < #HLe; i = num3 + 1)
			{
				for (int j = 0; j < #GLe; j = num3 + 1)
				{
					if (j == 0 || j == #GLe - 1 || i == 0 || i == #HLe - 1 || #Pfe)
					{
						yield return new devDept.Geometry.Point3D(#Xrb.X + (double)j * num, #Xrb.Y + (double)i * num2);
					}
					num3 = j;
				}
				num3 = i;
			}
			yield break;
			yield break;
		}

		// Token: 0x06009EC7 RID: 40647 RVA: 0x0021ABF0 File Offset: 0x00218DF0
		public static IEnumerable<devDept.Geometry.Point3D> #Mfe(int #Nfe, int #Ofe, devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Yrb, bool #Pfe, bool #Qfe, bool #Rfe, bool #Sfe, bool #Tfe)
		{
			double x = Math.Min(#Xrb.X, #Yrb.X);
			double x2 = Math.Max(#Xrb.X, #Yrb.X);
			double y = Math.Min(#Xrb.Y, #Yrb.Y);
			double y2 = Math.Max(#Xrb.Y, #Yrb.Y);
			devDept.Geometry.Point3D #Akb = new devDept.Geometry.Point3D(x, y);
			devDept.Geometry.Point3D #Bkb = new devDept.Geometry.Point3D(x, y2);
			List<devDept.Geometry.Point3D> list = ReinforcementPatternHelper.#MLe(#Akb, #Bkb, #Nfe).ToList<devDept.Geometry.Point3D>();
			int num;
			for (int i = 0; i < #Nfe; i = num + 1)
			{
				devDept.Geometry.Point3D point3D = list[i];
				devDept.Geometry.Point3D #Bkb2 = new devDept.Geometry.Point3D(x2, point3D.Y);
				List<devDept.Geometry.Point3D> #BP = ReinforcementPatternHelper.#MLe(point3D, #Bkb2, #Ofe).ToList<devDept.Geometry.Point3D>();
				if (i == 0)
				{
					foreach (devDept.Geometry.Point3D point3D2 in ReinforcementPatternHelper.#PLe(#BP, true, #Pfe || #Tfe, true))
					{
						yield return point3D2;
					}
					IEnumerator<devDept.Geometry.Point3D> enumerator = null;
				}
				else if (i == #Nfe - 1)
				{
					foreach (devDept.Geometry.Point3D point3D3 in ReinforcementPatternHelper.#PLe(#BP, true, #Pfe || #Sfe, true))
					{
						yield return point3D3;
					}
					IEnumerator<devDept.Geometry.Point3D> enumerator = null;
				}
				else
				{
					foreach (devDept.Geometry.Point3D point3D4 in ReinforcementPatternHelper.#PLe(#BP, #Pfe || #Qfe, #Pfe, #Pfe || #Rfe))
					{
						yield return point3D4;
					}
					IEnumerator<devDept.Geometry.Point3D> enumerator = null;
				}
				num = i;
			}
			yield break;
			yield break;
		}

		// Token: 0x06009EC8 RID: 40648 RVA: 0x0021AC48 File Offset: 0x00218E48
		public static IEnumerable<devDept.Geometry.Point3D> #KLe(devDept.Geometry.Point3D #wob, double #HS, double #Xjc, double #NP)
		{
			double num = 6.283185307179586 * #HS / #NP + 2.0;
			int num2 = (int)num;
			if (Math.Abs((double)num2 - num) < 0.001)
			{
				num2--;
			}
			return ReinforcementPatternHelper.#LLe(#wob, #HS, #Xjc, num2);
		}

		// Token: 0x06009EC9 RID: 40649 RVA: 0x0007CF20 File Offset: 0x0007B120
		public static IEnumerable<devDept.Geometry.Point3D> #LLe(devDept.Geometry.Point3D #wob, double #HS, double #Xjc, int #AWc)
		{
			double num = 6.283185307179586 / (double)#AWc;
			double x = #wob.X;
			double y = #wob.Y;
			int num2;
			for (int i = #AWc - 1; i >= 0; i = num2 - 1)
			{
				double x2 = x + #HS * Math.Cos((double)i * num + #Xjc);
				double y2 = y + #HS * Math.Sin((double)i * num + #Xjc);
				yield return new devDept.Geometry.Point3D(x2, y2, #wob.Z);
				num2 = i;
			}
			yield break;
		}

		// Token: 0x06009ECA RID: 40650 RVA: 0x0021AC94 File Offset: 0x00218E94
		public static IEnumerable<devDept.Geometry.Point3D> #MLe(devDept.Geometry.Point3D #Akb, devDept.Geometry.Point3D #Bkb, int #AWc)
		{
			ReinforcementPatternHelper.#oWb #oWb = new ReinforcementPatternHelper.#oWb();
			#oWb.#a = #AWc;
			#oWb.#b = #Akb;
			#oWb.#c = #Bkb;
			return Enumerable.Range(0, #oWb.#a).Select(new Func<int, double>(#oWb.#ygf)).Select(new Func<double, devDept.Geometry.Point3D>(#oWb.#zgf));
		}

		// Token: 0x06009ECB RID: 40651 RVA: 0x0007CF45 File Offset: 0x0007B145
		public static IEnumerable<devDept.Geometry.Point3D> #NLe(devDept.Geometry.Point3D #Akb, devDept.Geometry.Point3D #Bkb, double #NP)
		{
			int num = ReinforcementPatternHelper.#ULe(#Akb, #Bkb, #NP);
			devDept.Geometry.Point3D p = ReinforcementPatternHelper.#SLe(#Akb, #Bkb, num);
			int num2;
			for (int i = 0; i < num; i = num2 + 1)
			{
				yield return #Akb + p * (double)i;
				num2 = i;
			}
			yield break;
		}

		// Token: 0x06009ECC RID: 40652 RVA: 0x0021ACEC File Offset: 0x00218EEC
		public static IEnumerable<devDept.Geometry.Point3D> #mge(devDept.Geometry.Point3D #wob, devDept.Geometry.Point3D #Akb, double #Udb, double #NP)
		{
			devDept.Geometry.Point3D point3D = #Akb - #wob;
			double num = (double)GeometryHelper.#Knc(point3D.Y, point3D.X);
			double num2 = num + #Udb;
			List<double> list = new List<double>();
			double num3 = Math.Abs(num2 - num);
			double num4 = num3 / 360.0;
			double num5 = 6.283185307179586 * #wob.DistanceTo(#Akb);
			double num6 = num4 * num5;
			int num7 = Math.Sign(#Udb);
			double num8 = num6 / #NP + 2.0;
			int num9 = (int)num8;
			if (Math.Abs((double)num9 - num8) <= 0.0)
			{
				num9--;
			}
			#NP = num6 / (double)(num9 - 1);
			for (int i = 0; i < num9; i++)
			{
				double num10 = (double)i * #NP / num6;
				#Udb = (double)((float)(num + num10 * num3 * (double)num7));
				list.Add(#Udb);
			}
			return ReinforcementPatternHelper.#JHb(#wob, #wob.DistanceTo(#Akb), list);
		}

		// Token: 0x06009ECD RID: 40653 RVA: 0x0021ADCC File Offset: 0x00218FCC
		public static IEnumerable<devDept.Geometry.Point3D> #lge(devDept.Geometry.Point3D #wob, devDept.Geometry.Point3D #Akb, double #Udb, int #AWc)
		{
			devDept.Geometry.Point3D point3D = #Akb - #wob;
			float num = GeometryHelper.#Knc(point3D.Y, point3D.X);
			double num2 = (double)num + #Udb;
			List<double> list = new List<double>();
			int num3 = #AWc - 1;
			double num4 = (num3 > 0) ? ((num2 - (double)num) / (double)num3) : 1.0;
			for (int i = 0; i <= num3; i++)
			{
				#Udb = (double)((float)((double)num + (double)i * num4));
				list.Add(#Udb);
			}
			return ReinforcementPatternHelper.#JHb(#wob, #wob.DistanceTo(#Akb), list);
		}

		// Token: 0x06009ECE RID: 40654 RVA: 0x0007CF63 File Offset: 0x0007B163
		public static IEnumerable<devDept.Geometry.Point3D> #JHb(devDept.Geometry.Point3D #wob, double #HS, List<double> #KHb)
		{
			foreach (double #Udb in #KHb)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point point = GeometryHelper.#4nc(new StructurePoint.CoreAssets.Infrastructure.Data.Point(#wob.X, #wob.Y), #HS, #Udb);
				yield return new devDept.Geometry.Point3D(point.X, point.Y);
			}
			List<double>.Enumerator enumerator = default(List<double>.Enumerator);
			yield break;
			yield break;
		}

		// Token: 0x06009ECF RID: 40655 RVA: 0x0021AE50 File Offset: 0x00219050
		public static ValueTuple<float, float> #OLe(devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Mzb, devDept.Geometry.Point3D #Yrb)
		{
			devDept.Geometry.Point3D point3D = #Mzb - #Xrb;
			devDept.Geometry.Point3D point3D2 = #Yrb - #Xrb;
			float item = GeometryHelper.#Knc(point3D.Y, point3D.X);
			float item2 = GeometryHelper.#Knc(point3D2.Y, point3D2.X);
			return new ValueTuple<float, float>(item, item2);
		}

		// Token: 0x06009ED0 RID: 40656 RVA: 0x0007CF81 File Offset: 0x0007B181
		private static IEnumerable<devDept.Geometry.Point3D> #PLe(IList<devDept.Geometry.Point3D> #BP, bool #5fe, bool #QLe, bool #6fe)
		{
			int num;
			for (int i = 0; i < #BP.Count; i = num + 1)
			{
				if (i == 0)
				{
					if (#5fe)
					{
						yield return #BP[i];
					}
				}
				else if (i == #BP.Count - 1)
				{
					if (#6fe)
					{
						yield return #BP[i];
					}
				}
				else if (#QLe)
				{
					yield return #BP[i];
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06009ED1 RID: 40657 RVA: 0x0007CFA6 File Offset: 0x0007B1A6
		private static devDept.Geometry.Point3D #RLe(this Point2D #Ng)
		{
			return new devDept.Geometry.Point3D(#Ng.X, #Ng.Y);
		}

		// Token: 0x06009ED2 RID: 40658 RVA: 0x0007CFB9 File Offset: 0x0007B1B9
		private static devDept.Geometry.Point3D #SLe(devDept.Geometry.Point3D #Akb, devDept.Geometry.Point3D #Bkb, int #TLe)
		{
			return (#Bkb - #Akb) / (double)(#TLe - 1);
		}

		// Token: 0x06009ED3 RID: 40659 RVA: 0x0021AE98 File Offset: 0x00219098
		private static int #ULe(devDept.Geometry.Point3D #Akb, devDept.Geometry.Point3D #Bkb, double #NP)
		{
			double num = #Akb.DistanceTo(#Bkb) / #NP + 2.0;
			int num2 = (int)num;
			if (Math.Abs((double)num2 - num) <= 0.0)
			{
				num2--;
			}
			return num2;
		}

		// Token: 0x06009ED4 RID: 40660 RVA: 0x0007CFCB File Offset: 0x0007B1CB
		private static devDept.Geometry.Point3D #VLe(devDept.Geometry.Point3D #3r, devDept.Geometry.Point3D #4r, double #WLe)
		{
			return (1.0 - #WLe) * #3r + #WLe * #4r;
		}

		// Token: 0x02001283 RID: 4739
		[CompilerGenerated]
		private sealed class #oWb
		{
			// Token: 0x06009EDA RID: 40666 RVA: 0x0007D00B File Offset: 0x0007B20B
			internal double #ygf(int #4jb)
			{
				return (double)#4jb * (1.0 / ((double)this.#a - 1.0));
			}

			// Token: 0x06009EDB RID: 40667 RVA: 0x0007D02B File Offset: 0x0007B22B
			internal devDept.Geometry.Point3D #zgf(double #WLe)
			{
				return ReinforcementPatternHelper.#VLe(this.#b, this.#c, #WLe);
			}

			// Token: 0x040044B5 RID: 17589
			public int #a;

			// Token: 0x040044B6 RID: 17590
			public devDept.Geometry.Point3D #b;

			// Token: 0x040044B7 RID: 17591
			public devDept.Geometry.Point3D #c;
		}
	}
}
