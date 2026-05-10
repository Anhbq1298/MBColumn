using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #UYd;
using ClipperLib;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007D7 RID: 2007
	public static class PointsConverter
	{
		// Token: 0x060040AB RID: 16555 RVA: 0x0012EE34 File Offset: 0x0012D034
		[SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = "Because it is cleaner.")]
		static PointsConverter()
		{
			if (5 != 0)
			{
				PointsConverter.#c = #Emc.#a;
				PointsConverter.#a = \u0011\u0002.\u0088\u0004(10.0, (double)PointsConverter.#c);
				if (!false)
				{
					double num = 1.0;
					double num2;
					do
					{
						num2 = (num /= PointsConverter.#a);
					}
					while (5 == 0);
					PointsConverter.#b = num2;
				}
			}
		}

		// Token: 0x060040AC RID: 16556 RVA: 0x0012EE8C File Offset: 0x0012D08C
		public static List<Point> #ksc(IEnumerable<Point> #lsc, IEnumerable<Point> #msc)
		{
			PointsConverter.#xTb #xTb = new PointsConverter.#xTb();
			#xTb.#a = #msc;
			#X0d.#V0d(#lsc, #Phc.#3hc(107462285), Component.Geometry, #Phc.#3hc(107462272));
			#X0d.#V0d(#xTb.#a, #Phc.#3hc(107462219), Component.Geometry, #Phc.#3hc(107462238));
			return #lsc.Where(new Func<Point, bool>(#xTb.#Wxc)).ToList<Point>();
		}

		// Token: 0x060040AD RID: 16557 RVA: 0x0012EF1C File Offset: 0x0012D11C
		public static IEnumerable<Point> #nsc(this IEnumerable<Point> #lsc, IEnumerable<Point> #msc)
		{
			do
			{
				if (false)
				{
					goto IL_47;
				}
				IEnumerable<Point> #a = #msc;
				#X0d.#V0d(#lsc, #Phc.#3hc(107462285), Component.Geometry, #Phc.#3hc(107462153));
			}
			while (4 == 0);
			#X0d.#V0d(#MZb.#a, #Phc.#3hc(107462219), Component.Geometry, #Phc.#3hc(107462644));
			IL_47:
			return #lsc.Where(new Func<Point, bool>(#MZb.#Zxc));
		}

		// Token: 0x060040AE RID: 16558 RVA: 0x0012EFB0 File Offset: 0x0012D1B0
		public static bool #osc(IEnumerable<Point> #lsc, IEnumerable<Point> #msc)
		{
			do
			{
				if (false)
				{
					goto IL_47;
				}
				IEnumerable<Point> #a = #msc;
				#X0d.#V0d(#lsc, #Phc.#3hc(107462285), Component.Geometry, #Phc.#3hc(107462591));
			}
			while (4 == 0);
			#X0d.#V0d(#ITb.#a, #Phc.#3hc(107462219), Component.Geometry, #Phc.#3hc(107462506));
			IL_47:
			return #lsc.Any(new Func<Point, bool>(#ITb.#2xc));
		}

		// Token: 0x060040AF RID: 16559 RVA: 0x0012F044 File Offset: 0x0012D244
		public static List<Point> #psc(IEnumerable<Point> #lsc, IEnumerable<Point> #msc)
		{
			PointsConverter.#92b #92b2;
			if (7 != 0 && !false)
			{
				PointsConverter.#92b #92b = new PointsConverter.#92b();
				if (!false)
				{
					#92b2 = #92b;
				}
				#92b2.#a = #msc;
			}
			#X0d.#V0d(#lsc, #Phc.#3hc(107462285), Component.Geometry, #Phc.#3hc(107462485));
			#X0d.#V0d(#92b2.#a, #Phc.#3hc(107462219), Component.Geometry, #Phc.#3hc(107462400));
			return #lsc.Where(new Func<Point, bool>(#92b2.#5xc)).Distinct<Point>().ToList<Point>();
		}

		// Token: 0x060040B0 RID: 16560 RVA: 0x00036712 File Offset: 0x00034912
		public static bool #qsc(double #4gb, double #5gb)
		{
			return \u0006\u0002.\u0006\u0004(#4gb - #5gb) < PointsConverter.#b;
		}

		// Token: 0x060040B1 RID: 16561 RVA: 0x00036734 File Offset: 0x00034934
		public static bool #qsc(double #4gb, double #5gb, double #cmc)
		{
			return \u0006\u0002.\u0006\u0004(#4gb - #5gb) < #cmc;
		}

		// Token: 0x060040B2 RID: 16562 RVA: 0x0012F0EC File Offset: 0x0012D2EC
		public static bool #uC(Point #mcb, Point #ncb, double #cmc)
		{
			bool flag;
			int num = (flag = PointsConverter.#qsc(#mcb.X, #ncb.X, #cmc)) ? 1 : 0;
			bool result;
			bool flag2;
			for (;;)
			{
				if (!false)
				{
					if (flag)
					{
						break;
					}
					num = 0;
				}
				flag2 = (result = (num != 0));
				if (flag2)
				{
					return result;
				}
				num = (flag2 ? 1 : 0);
				flag = flag2;
				if (!flag2)
				{
					goto Block_4;
				}
			}
			result = PointsConverter.#qsc(#mcb.Y, #ncb.Y, #cmc);
			return result;
			Block_4:
			result = flag2;
			if (!flag2)
			{
				return flag2;
			}
			return result;
		}

		// Token: 0x060040B3 RID: 16563 RVA: 0x0012F154 File Offset: 0x0012D354
		public static bool #uC(Point #mcb, Point #ncb)
		{
			if (4 != 0)
			{
				double #4gb = #mcb.X;
				double #5gb = #ncb.X;
				bool result;
				for (;;)
				{
					IL_0B:
					bool flag = PointsConverter.#qsc(#4gb, #5gb);
					while (flag && !false)
					{
						double #4gb2 = #4gb = #mcb.Y;
						double #5gb2 = #5gb = #ncb.Y;
						if (6 == 0)
						{
							goto IL_0B;
						}
						result = (flag = PointsConverter.#qsc(#4gb2, #5gb2));
						if (!false)
						{
							return result;
						}
					}
					return false;
				}
				return result;
			}
			return false;
		}

		// Token: 0x060040B4 RID: 16564 RVA: 0x00036756 File Offset: 0x00034956
		public static bool #rsc(Point3D #mcb, Point3D #ncb)
		{
			return Point3D.#E3d(#mcb, #ncb);
		}

		// Token: 0x060040B5 RID: 16565 RVA: 0x0012F1B0 File Offset: 0x0012D3B0
		public static bool #uC(Point3D #mcb, Point3D #ncb)
		{
			double #4gb;
			if (false || PointsConverter.#qsc(#mcb.X, #ncb.X))
			{
				#4gb = #mcb.Y;
				goto IL_13;
			}
			goto IL_2C;
			IL_19:
			int num;
			while (num != 0)
			{
				double #4gb2 = #4gb = #mcb.Z;
				if (false)
				{
					goto IL_13;
				}
				bool result = (num = (PointsConverter.#qsc(#4gb2, #ncb.Z) ? 1 : 0)) != 0;
				if (!false)
				{
					return result;
				}
			}
			goto IL_2C;
			IL_13:
			num = (PointsConverter.#qsc(#4gb, #ncb.Y) ? 1 : 0);
			goto IL_19;
			IL_2C:
			int num2 = num = 0;
			if (num2 == 0)
			{
				return num2 != 0;
			}
			goto IL_19;
		}

		// Token: 0x060040B6 RID: 16566 RVA: 0x0012F22C File Offset: 0x0012D42C
		public static bool #uC(Point3D #mcb, Point3D #ncb, double #cmc)
		{
			double #4gb3;
			double #4gb2;
			double #4gb = #4gb2 = (#4gb3 = #mcb.X);
			double #5gb3;
			double #5gb2;
			double #5gb = #5gb2 = (#5gb3 = #ncb.X);
			double #cmc3;
			if (6 != 0)
			{
				double #cmc2 = #cmc;
				#cmc3 = #cmc;
				if (!false)
				{
					if (false)
					{
						goto IL_37;
					}
					if (!PointsConverter.#qsc(#4gb, #5gb, #cmc))
					{
						goto IL_3D;
					}
					#4gb3 = (#4gb2 = #mcb.Y);
					if (false)
					{
						goto IL_2F;
					}
					#5gb3 = #ncb.Y;
					#cmc2 = #cmc;
				}
				int result;
				bool flag = (result = (PointsConverter.#qsc(#4gb3, #5gb3, #cmc2) ? 1 : 0)) != 0;
				if (false)
				{
					return result != 0;
				}
				if (!flag)
				{
					goto IL_3D;
				}
				#4gb2 = #mcb.Z;
				IL_2F:
				#5gb2 = #ncb.Z;
				goto IL_36;
				IL_3D:
				result = 0;
				return result != 0;
			}
			IL_36:
			#cmc3 = #cmc;
			IL_37:
			return PointsConverter.#qsc(#4gb2, #5gb2, #cmc3);
		}

		// Token: 0x060040B7 RID: 16567 RVA: 0x0003676B File Offset: 0x0003496B
		public static double #ssc(double #f)
		{
			return \u0012\u0002.\u008C\u0004(#f, PointsConverter.#c);
		}

		// Token: 0x060040B8 RID: 16568 RVA: 0x0012F2B0 File Offset: 0x0012D4B0
		public static Point3D #ssc(Point3D #HAb)
		{
			double x;
			double #f = x = #HAb.X;
			if (8 != 0)
			{
				x = PointsConverter.#ssc(#f);
			}
			double y;
			double #f2 = y = #HAb.Y;
			if (!false && 5 != 0)
			{
				y = PointsConverter.#ssc(#f2);
			}
			double #f3 = #HAb.Z;
			double z;
			do
			{
				z = (#f3 = PointsConverter.#ssc(#f3));
			}
			while (false);
			return new Point3D(x, y, z);
		}

		// Token: 0x060040B9 RID: 16569 RVA: 0x00036785 File Offset: 0x00034985
		public static Point #ssc(Point #Ng)
		{
			return new Point(PointsConverter.#ssc(#Ng.X), PointsConverter.#ssc(#Ng.Y));
		}

		// Token: 0x060040BA RID: 16570 RVA: 0x0012F310 File Offset: 0x0012D510
		public static Point #ssc(Point #Ng, int #tsc)
		{
			return new Point(\u0012\u0002.\u008C\u0004(#Ng.X, #tsc), \u0012\u0002.\u008C\u0004(#Ng.Y, #tsc));
		}

		// Token: 0x060040BB RID: 16571 RVA: 0x0012F364 File Offset: 0x0012D564
		public static bool #uC(Point #usc, Point3D #HAb)
		{
			if (4 != 0)
			{
				double #4gb = #usc.X;
				double #5gb = #HAb.X;
				bool result;
				for (;;)
				{
					IL_0B:
					bool flag = PointsConverter.#qsc(#4gb, #5gb);
					while (flag && !false)
					{
						double #4gb2 = #4gb = #usc.Y;
						double #5gb2 = #5gb = #HAb.Y;
						if (6 == 0)
						{
							goto IL_0B;
						}
						result = (flag = PointsConverter.#qsc(#4gb2, #5gb2));
						if (!false)
						{
							return result;
						}
					}
					return false;
				}
				return result;
			}
			return false;
		}

		// Token: 0x060040BC RID: 16572 RVA: 0x0012F3C0 File Offset: 0x0012D5C0
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DXZ", Justification = "Reviewed. OK.")]
		public static List<Point> #vsc(IReadOnlyCollection<Point3D> #wsc)
		{
			List<Point> list;
			do
			{
				#X0d.#V0d(#wsc, #Phc.#3hc(107461835), Component.Geometry, #Phc.#3hc(107461854));
				int capacity;
				int num = capacity = #wsc.Count;
				if (7 != 0)
				{
					capacity = num + 1;
				}
				list = new List<Point>(capacity);
				IEnumerator<Point3D> enumerator = #wsc.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Point3D point3D = enumerator.Current;
						list.Add(new Point(point3D.X, point3D.Y));
					}
				}
				finally
				{
					if (enumerator == null)
					{
						goto IL_78;
					}
					IL_72:
					enumerator.Dispose();
					IL_78:
					if (2 == 0)
					{
						goto IL_72;
					}
				}
			}
			while (3 == 0);
			return list;
		}

		// Token: 0x060040BD RID: 16573 RVA: 0x0012F4AC File Offset: 0x0012D6AC
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DXZ", Justification = "Reviewed. OK.")]
		public static List<Point> #vsc(IList<Point3D> #wsc)
		{
			List<Point> list;
			do
			{
				#X0d.#V0d(#wsc, #Phc.#3hc(107461835), Component.Geometry, #Phc.#3hc(107461854));
				int capacity;
				int num = capacity = #wsc.Count;
				if (7 != 0)
				{
					capacity = num + 1;
				}
				list = new List<Point>(capacity);
				IEnumerator<Point3D> enumerator = #wsc.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Point3D point3D = enumerator.Current;
						list.Add(new Point(point3D.X, point3D.Y));
					}
				}
				finally
				{
					if (enumerator == null)
					{
						goto IL_78;
					}
					IL_72:
					enumerator.Dispose();
					IL_78:
					if (2 == 0)
					{
						goto IL_72;
					}
				}
			}
			while (3 == 0);
			return list;
		}

		// Token: 0x060040BE RID: 16574 RVA: 0x0012F598 File Offset: 0x0012D798
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DXZ", Justification = "Reviewed. OK.")]
		public static List<Point> #vsc(List<Point3D> #wsc)
		{
			List<Point> list;
			do
			{
				if (4 != 0)
				{
					#X0d.#V0d(#wsc, #Phc.#3hc(107461835), Component.Geometry, #Phc.#3hc(107461854));
					list = new List<Point>(#wsc.Count + 1);
				}
			}
			while (7 == 0);
			List<Point3D>.Enumerator enumerator = #wsc.GetEnumerator();
			try
			{
				if (4 != 0)
				{
					while (enumerator.MoveNext())
					{
						Point3D point3D = enumerator.Current;
						list.Add(new Point(point3D.X, point3D.Y));
					}
				}
			}
			finally
			{
				do
				{
					((IDisposable)enumerator).Dispose();
				}
				while (6 == 0 || 2 == 0);
			}
			return list;
		}

		// Token: 0x060040BF RID: 16575 RVA: 0x000367B8 File Offset: 0x000349B8
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DXZ", Justification = "Reviewed. OK.")]
		public static Point #vsc(Point3D #HAb)
		{
			return new Point(#HAb.X, #HAb.Y);
		}

		// Token: 0x060040C0 RID: 16576 RVA: 0x000367D9 File Offset: 0x000349D9
		public static Point3D #vsc(Point #Ng)
		{
			return new Point3D(#Ng.X, #Ng.Y, 0.0);
		}

		// Token: 0x060040C1 RID: 16577 RVA: 0x00036803 File Offset: 0x00034A03
		public static Point3D #vsc(Point #Ng, double #xsc)
		{
			return new Point3D(#Ng.X, #Ng.Y, #xsc);
		}

		// Token: 0x060040C2 RID: 16578 RVA: 0x0012F68C File Offset: 0x0012D88C
		public static List<Point3D> #vsc(IEnumerable<Point> #BP, double #xsc)
		{
			PointsConverter.#ZXb #ZXb = new PointsConverter.#ZXb();
			#ZXb.#a = #xsc;
			return #BP.Select(new Func<Point, Point3D>(#ZXb.#8xc)).ToList<Point3D>();
		}

		// Token: 0x060040C3 RID: 16579 RVA: 0x0012F6E0 File Offset: 0x0012D8E0
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DXZ", Justification = "Reviewed. OK.")]
		public static List<Point3D> #vsc(IEnumerable<Point> #uzb)
		{
			List<Point3D> list;
			do
			{
				if (!false && -1 != 0)
				{
					#X0d.#V0d(#uzb, #Phc.#3hc(107461769), Component.Geometry, #Phc.#3hc(107461788));
				}
				list = new List<Point3D>();
			}
			while (false);
			using (IEnumerator<Point> enumerator = #uzb.GetEnumerator())
			{
				for (;;)
				{
					Point point;
					if (4 != 0)
					{
						if (!enumerator.MoveNext())
						{
							if (4 != 0)
							{
								break;
							}
						}
						else
						{
							point = enumerator.Current;
						}
					}
					list.Add(new Point3D(point.X, point.Y, 0.0));
				}
			}
			return list;
		}

		// Token: 0x060040C4 RID: 16580 RVA: 0x0012F7CC File Offset: 0x0012D9CC
		internal static List<IntPoint> #ysc(IReadOnlyCollection<Point> #BP)
		{
			List<IntPoint> list;
			do
			{
				#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107461703));
				list = new List<IntPoint>(#BP.Count);
				IEnumerator<Point> enumerator = #BP.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Point point = enumerator.Current;
						list.Add(new IntPoint(PointsConverter.#Pb(point.X), PointsConverter.#Pb(point.Y)));
					}
				}
				finally
				{
					if (enumerator == null)
					{
						goto IL_7D;
					}
					IL_77:
					enumerator.Dispose();
					IL_7D:
					if (2 == 0)
					{
						goto IL_77;
					}
				}
			}
			while (3 == 0);
			return list;
		}

		// Token: 0x060040C5 RID: 16581 RVA: 0x0012F8BC File Offset: 0x0012DABC
		internal static List<Point> #ysc(IReadOnlyCollection<IntPoint> #BP)
		{
			List<Point> list;
			do
			{
				#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107461682));
				list = new List<Point>(#BP.Count);
				IEnumerator<IntPoint> enumerator = #BP.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						IntPoint intPoint = enumerator.Current;
						list.Add(new Point(PointsConverter.#Pb(intPoint.X), PointsConverter.#Pb(intPoint.Y)));
					}
				}
				finally
				{
					if (enumerator == null)
					{
						goto IL_7B;
					}
					IL_75:
					enumerator.Dispose();
					IL_7B:
					if (2 == 0)
					{
						goto IL_75;
					}
				}
			}
			while (3 == 0);
			return list;
		}

		// Token: 0x060040C6 RID: 16582 RVA: 0x0012F9AC File Offset: 0x0012DBAC
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Temporary.")]
		internal static List<IntPoint> #Pb(IEnumerable<Point3D> #wsc)
		{
			if (3 != 0)
			{
				#X0d.#V0d(#wsc, #Phc.#3hc(107461835), Component.Geometry, #Phc.#3hc(107462141));
			}
			List<IntPoint> list = new List<IntPoint>();
			IEnumerator<Point3D> enumerator = #wsc.GetEnumerator();
			try
			{
				while (enumerator.MoveNext() && !false)
				{
					Point3D point3D = enumerator.Current;
					list.Add(new IntPoint(PointsConverter.#Pb(point3D.X), PointsConverter.#Pb(point3D.Y)));
				}
			}
			finally
			{
				if (!false && enumerator != null)
				{
					enumerator.Dispose();
				}
			}
			return list;
		}

		// Token: 0x060040C7 RID: 16583 RVA: 0x0012FA94 File Offset: 0x0012DC94
		internal static List<Point3D> #Pb(IEnumerable<IntPoint> #zsc)
		{
			List<Point3D> list;
			if (4 != 0)
			{
				#X0d.#V0d(#zsc, #Phc.#3hc(107462056), Component.Geometry, #Phc.#3hc(107462075));
				list = new List<Point3D>();
			}
			IEnumerator<IntPoint> enumerator = #zsc.GetEnumerator();
			goto IL_3B;
			try
			{
				for (;;)
				{
					IL_3B:
					while (enumerator.MoveNext())
					{
						if (7 != 0)
						{
							IntPoint intPoint = enumerator.Current;
							if (4 == 0)
							{
								break;
							}
							list.Add(new Point3D(PointsConverter.#Pb(intPoint.X), PointsConverter.#Pb(intPoint.Y), 0.0));
						}
					}
					break;
				}
			}
			finally
			{
				for (;;)
				{
					if (enumerator != null)
					{
						goto IL_81;
					}
					IL_87:
					if (6 != 0)
					{
						if (2 != 0)
						{
							break;
						}
						continue;
					}
					IL_81:
					enumerator.Dispose();
					goto IL_87;
				}
			}
			return list;
		}

		// Token: 0x060040C8 RID: 16584 RVA: 0x00036829 File Offset: 0x00034A29
		public static long #Pb(double #f)
		{
			return (long)(#f * PointsConverter.#a);
		}

		// Token: 0x060040C9 RID: 16585 RVA: 0x00036837 File Offset: 0x00034A37
		public static double #Pb(long #f)
		{
			return (double)#f / PointsConverter.#a;
		}

		// Token: 0x060040CA RID: 16586 RVA: 0x0012FB8C File Offset: 0x0012DD8C
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static List<Point> #Asc(List<Point> #BP)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107461990));
			if (#BP.Count > 1 && Point.#E3d(#BP.First<Point>(), #BP.Last<Point>()))
			{
				#BP.RemoveAt(#BP.Count - 1);
			}
			return #BP;
		}

		// Token: 0x060040CB RID: 16587 RVA: 0x00036845 File Offset: 0x00034A45
		public static Point3D #Bsc(Point3D #HAb, double #f)
		{
			return new Point3D(#HAb.X, #HAb.Y, #HAb.Z + #f);
		}

		// Token: 0x060040CC RID: 16588 RVA: 0x0012FC04 File Offset: 0x0012DE04
		public static List<Point3D> #Bsc(IEnumerable<Point3D> #BP, double #f)
		{
			PointsConverter.#p6b #p6b = new PointsConverter.#p6b();
			do
			{
				#p6b.#a = #f;
				#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107461969));
			}
			while (false);
			return #BP.Select(new Func<Point3D, Point3D>(#p6b.#9xc)).ToList<Point3D>();
		}

		// Token: 0x060040CD RID: 16589 RVA: 0x00036877 File Offset: 0x00034A77
		public static Point3D #Csc(Point3D #HAb, double #f)
		{
			return new Point3D(#HAb.X, #HAb.Y, #f);
		}

		// Token: 0x060040CE RID: 16590 RVA: 0x0012FC78 File Offset: 0x0012DE78
		public static List<Point3D> #Csc(IEnumerable<Point3D> #BP, double #f)
		{
			PointsConverter.#EZb #EZb = new PointsConverter.#EZb();
			do
			{
				#EZb.#a = #f;
				#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107461916));
			}
			while (false);
			return #BP.Select(new Func<Point3D, Point3D>(#EZb.#ayc)).ToList<Point3D>();
		}

		// Token: 0x060040CF RID: 16591 RVA: 0x0012FCEC File Offset: 0x0012DEEC
		public static void #bmc(IList<Point> #BP, double #cmc = 1E-05)
		{
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107370786));
			for (int i = #BP.Count - 1; i > 0; i--)
			{
				Point #ncb = #BP[i];
				if (PointsConverter.#uC(#BP[i - 1], #ncb, #cmc))
				{
					#BP.RemoveAt(i);
				}
			}
		}

		// Token: 0x060040D0 RID: 16592 RVA: 0x0012FD6C File Offset: 0x0012DF6C
		public unsafe static void #bmc(this IList<Point3D> #BP, double #cmc = 1E-05)
		{
			for (;;)
			{
				void* ptr = stackalloc byte[5];
				if (!false)
				{
					#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107370786));
					*(byte*)(ptr + 4) = 1;
					goto IL_96;
				}
				goto IL_54;
				IL_7F:
				if (2 != 0)
				{
					*(int*)ptr = *(int*)ptr - 1;
					goto IL_8B;
				}
				continue;
				IL_56:
				Point3D #ncb = #BP[*(int*)ptr];
				if (PointsConverter.#uC(#BP[*(int*)ptr - 1], #ncb, #cmc))
				{
					#BP.RemoveAt(*(int*)ptr);
					goto IL_7A;
				}
				goto IL_7F;
				IL_96:
				int num;
				bool flag = (num = (int)(*(sbyte*)((byte*)ptr + 4))) != 0;
				if (!true)
				{
					goto IL_93;
				}
				if (!flag)
				{
					break;
				}
				if (5 != 0)
				{
					*(byte*)(ptr + 4) = 0;
					*(int*)ptr = #BP.Count - 1;
					goto IL_54;
				}
				goto IL_56;
				IL_7A:
				((byte*)ptr)[4] = 1;
				goto IL_7F;
				IL_8B:
				if (false)
				{
					goto IL_7F;
				}
				if (-1 != 0)
				{
					num = *(int*)ptr;
					goto IL_93;
				}
				goto IL_7A;
				IL_54:
				goto IL_8B;
				IL_93:
				if (num <= 0)
				{
					goto IL_96;
				}
				goto IL_56;
			}
		}

		// Token: 0x060040D1 RID: 16593 RVA: 0x0012FE60 File Offset: 0x0012E060
		internal static string #Dsc(this IList<IntPoint> #BP)
		{
			return string.Join(Environment.NewLine, #BP.Select(new Func<IntPoint, string>(PointsConverter.<>c.<>9.#byc)));
		}

		// Token: 0x04001D28 RID: 7464
		public static readonly double #a;

		// Token: 0x04001D29 RID: 7465
		public static readonly double #b;

		// Token: 0x04001D2A RID: 7466
		public static readonly int #c;

		// Token: 0x020007D9 RID: 2009
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x060040D6 RID: 16598 RVA: 0x000368E9 File Offset: 0x00034AE9
			internal Point3D #8xc(Point #Rf)
			{
				return PointsConverter.#vsc(#Rf, this.#a);
			}

			// Token: 0x04001D2D RID: 7469
			public double #a;
		}

		// Token: 0x020007DA RID: 2010
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x060040D8 RID: 16600 RVA: 0x00036903 File Offset: 0x00034B03
			internal Point3D #9xc(Point3D #Rf)
			{
				return PointsConverter.#Bsc(#Rf, this.#a);
			}

			// Token: 0x04001D2E RID: 7470
			public double #a;
		}

		// Token: 0x020007DB RID: 2011
		[CompilerGenerated]
		private sealed class #EZb
		{
			// Token: 0x060040DA RID: 16602 RVA: 0x0003691D File Offset: 0x00034B1D
			internal Point3D #ayc(Point3D #Rf)
			{
				return PointsConverter.#Csc(#Rf, this.#a);
			}

			// Token: 0x04001D2F RID: 7471
			public double #a;
		}

		// Token: 0x020007DC RID: 2012
		[CompilerGenerated]
		private sealed class #xTb
		{
			// Token: 0x060040DC RID: 16604 RVA: 0x0012FEAC File Offset: 0x0012E0AC
			internal bool #Wxc(Point #Rf)
			{
				PointsConverter.#zTb #zTb = new PointsConverter.#zTb();
				#zTb.#a = #Rf;
				return this.#a.Any(new Func<Point, bool>(#zTb.#Xxc));
			}

			// Token: 0x04001D30 RID: 7472
			public IEnumerable<Point> #a;
		}

		// Token: 0x020007DD RID: 2013
		[CompilerGenerated]
		private sealed class #zTb
		{
			// Token: 0x060040DE RID: 16606 RVA: 0x00036937 File Offset: 0x00034B37
			internal bool #Xxc(Point #Yxc)
			{
				return PointsConverter.#uC(this.#a, #Yxc);
			}

			// Token: 0x04001D31 RID: 7473
			public Point #a;
		}

		// Token: 0x020007DE RID: 2014
		[CompilerGenerated]
		private sealed class #MZb
		{
			// Token: 0x060040E0 RID: 16608 RVA: 0x0012FEFC File Offset: 0x0012E0FC
			internal bool #Zxc(Point #Rf)
			{
				PointsConverter.#1xc #1xc;
				do
				{
					if (4 != 0 && 2 != 0)
					{
						#1xc = new PointsConverter.#1xc();
						#1xc.#a = #Rf;
					}
				}
				while (7 == 0);
				bool result;
				bool flag = result = this.#a.Any(new Func<Point, bool>(#1xc.#0xc));
				if (!false)
				{
					result = !flag;
				}
				return result;
			}

			// Token: 0x04001D32 RID: 7474
			public IEnumerable<Point> #a;
		}

		// Token: 0x020007DF RID: 2015
		[CompilerGenerated]
		private sealed class #1xc
		{
			// Token: 0x060040E2 RID: 16610 RVA: 0x00036951 File Offset: 0x00034B51
			internal bool #0xc(Point #Yxc)
			{
				return PointsConverter.#uC(this.#a, #Yxc);
			}

			// Token: 0x04001D33 RID: 7475
			public Point #a;
		}

		// Token: 0x020007E0 RID: 2016
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x060040E4 RID: 16612 RVA: 0x0012FF58 File Offset: 0x0012E158
			internal bool #2xc(Point #mcb)
			{
				PointsConverter.#4xc #4xc = new PointsConverter.#4xc();
				#4xc.#a = #mcb;
				return this.#a.Any(new Func<Point, bool>(#4xc.#3xc));
			}

			// Token: 0x04001D34 RID: 7476
			public IEnumerable<Point> #a;
		}

		// Token: 0x020007E1 RID: 2017
		[CompilerGenerated]
		private sealed class #4xc
		{
			// Token: 0x060040E6 RID: 16614 RVA: 0x0003696B File Offset: 0x00034B6B
			internal bool #3xc(Point #ncb)
			{
				return PointsConverter.#uC(this.#a, #ncb);
			}

			// Token: 0x04001D35 RID: 7477
			public Point #a;
		}

		// Token: 0x020007E2 RID: 2018
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x060040E8 RID: 16616 RVA: 0x0012FFA8 File Offset: 0x0012E1A8
			internal bool #5xc(Point #mcb)
			{
				PointsConverter.#7xc #7xc = new PointsConverter.#7xc();
				#7xc.#a = #mcb;
				return this.#a.Any(new Func<Point, bool>(#7xc.#6xc));
			}

			// Token: 0x04001D36 RID: 7478
			public IEnumerable<Point> #a;
		}

		// Token: 0x020007E3 RID: 2019
		[CompilerGenerated]
		private sealed class #7xc
		{
			// Token: 0x060040EA RID: 16618 RVA: 0x00036985 File Offset: 0x00034B85
			internal bool #6xc(Point #ncb)
			{
				return PointsConverter.#uC(this.#a, #ncb);
			}

			// Token: 0x04001D37 RID: 7479
			public Point #a;
		}
	}
}
