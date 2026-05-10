using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using #7hc;
using #cYd;
using #UYd;
using Microsoft.SqlServer.Types;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #Fmc
{
	// Token: 0x02000804 RID: 2052
	internal static class #0uc
	{
		// Token: 0x060041D5 RID: 16853 RVA: 0x00134450 File Offset: 0x00132650
		public static bool? #2lc(SqlGeometry #Nuc)
		{
			if (#Nuc == null)
			{
				goto IL_19;
			}
			IL_04:
			SqlBoolean sqlBoolean = #Nuc.STIsValid();
			IL_0D:
			if (8 == 0)
			{
				goto IL_29;
			}
			bool? result;
			if (false)
			{
				return result;
			}
			SqlGeometry sqlGeometry;
			if (!sqlBoolean.Value)
			{
				if (!false)
				{
					sqlGeometry = #Nuc.MakeValid();
					goto IL_27;
				}
				goto IL_04;
			}
			IL_19:
			if (false)
			{
				goto IL_0D;
			}
			sqlGeometry = #Nuc;
			IL_27:
			#Nuc = sqlGeometry;
			IL_29:
			if (#Nuc != null)
			{
				SqlDouble sqlDouble = #Nuc.STArea();
				if (2 != 0)
				{
					return new bool?(#Emc.#Bmc(sqlDouble.Value));
				}
			}
			result = null;
			return result;
		}

		// Token: 0x060041D6 RID: 16854 RVA: 0x001344E4 File Offset: 0x001326E4
		public static bool #7tc(SqlGeometry #Ouc, SqlGeometry #Puc)
		{
			do
			{
				IL_00:
				#X0d.#V0d(#Ouc, #Phc.#3hc(107459556), Component.Geometry, #Phc.#3hc(107459535));
				do
				{
					#X0d.#V0d(#Puc, #Phc.#3hc(107459514), Component.Geometry, #Phc.#3hc(107459461));
					if (!\u001E\u0002.\u0013\u0005(\u0013\u0002.~\u008D\u0004(#Ouc, #Puc)))
					{
						goto IL_68;
					}
					if (false || 2 == 0)
					{
						goto IL_00;
					}
				}
				while (false);
			}
			while (5 == 0);
			return true;
			IL_68:
			double value = \u007F\u0002.~\u0015\u0005(\u001F\u0002.~\u0014\u0005(#Ouc, #Puc)).Value;
			double value2 = \u007F\u0002.~\u0015\u0005(#Puc).Value;
			return #Emc.#Amc(value, value2);
		}

		// Token: 0x060041D7 RID: 16855 RVA: 0x001345E0 File Offset: 0x001327E0
		public static SqlGeometry #PHb(IList<Point> #Quc, bool #Ruc)
		{
			#X0d.#V0d(#Quc, #Phc.#3hc(107459440), Component.Geometry, #Phc.#3hc(107459395));
			if (#Quc.Count == 0)
			{
				throw new #jYd(#Phc.#3hc(107459440), #Phc.#3hc(107459342), Component.Geometry);
			}
			int count = #Quc.Count;
			SqlGeometry result;
			if (count != 1)
			{
				if (count != 2)
				{
					result = #0uc.#Yuc(#Quc, #Ruc);
				}
				else
				{
					result = #0uc.#PHb(#Quc[0], #Quc[1]);
				}
			}
			else
			{
				result = #0uc.#PHb(#Quc[0]);
			}
			return result;
		}

		// Token: 0x060041D8 RID: 16856 RVA: 0x00037398 File Offset: 0x00035598
		public static SqlGeometry #PHb(Point #Ng)
		{
			return #0uc.#PHb(#Ng.X, #Ng.Y);
		}

		// Token: 0x060041D9 RID: 16857 RVA: 0x000373B9 File Offset: 0x000355B9
		public static SqlGeometry #PHb(double #QHb, double #RHb)
		{
			\u0080\u0002 ~_u0016_u = \u0080\u0002.~\u0016\u0005;
			SqlGeometryBuilder sqlGeometryBuilder = #0uc.#Zuc();
			#0uc.#SHb(sqlGeometryBuilder, #QHb, #RHb);
			return ~_u0016_u(sqlGeometryBuilder);
		}

		// Token: 0x060041DA RID: 16858 RVA: 0x000373DE File Offset: 0x000355DE
		public static SqlGeometry #PHb(Point #Suc, Point #Mzb)
		{
			return #0uc.#PHb(#Suc.X, #Suc.Y, #Mzb.X, #Mzb.Y);
		}

		// Token: 0x060041DB RID: 16859 RVA: 0x001346C4 File Offset: 0x001328C4
		public static SqlGeometry #PHb(double #Tuc, double #Uuc, double #Vuc, double #Wuc)
		{
			for (;;)
			{
				if (!false)
				{
					double num = #Tuc;
					for (;;)
					{
						IL_05:
						double num2 = #Vuc;
						while (num == num2)
						{
							num = #Uuc;
							if (false)
							{
								goto IL_05;
							}
							num2 = #Wuc;
							if (!false)
							{
								goto Block_3;
							}
						}
						goto IL_32;
					}
					Block_3:
					if (#Uuc == #Wuc)
					{
						break;
					}
				}
				IL_32:
				if (!false)
				{
					goto Block_5;
				}
			}
			throw new #hYd(#Phc.#3hc(107458809), \u008E.\u009A\u0002().#z2d(), #Phc.#3hc(107458760), Component.Geometry, #IYd.#c);
			Block_5:
			\u0080\u0002 ~_u0016_u = \u0080\u0002.~\u0016\u0005;
			SqlGeometryBuilder sqlGeometryBuilder = #0uc.#Zuc();
			#0uc.#SHb(sqlGeometryBuilder, #Tuc, #Uuc, #Vuc, #Wuc);
			return ~_u0016_u(sqlGeometryBuilder);
		}

		// Token: 0x060041DC RID: 16860 RVA: 0x00134750 File Offset: 0x00132950
		public static bool #Xuc(SqlGeometry #Nuc)
		{
			int result;
			for (;;)
			{
				string #R0d = #Phc.#3hc(107458739);
				Component #x6c = Component.Geometry;
				string #Qic = #Phc.#3hc(107458690);
				if (!false)
				{
					#X0d.#V0d(#Nuc, #R0d, #x6c, #Qic);
				}
				if (7 != 0)
				{
					int num2;
					int num = num2 = (result = \u0081\u0002.~\u0017\u0005(#Nuc).Value);
					if (5 == 0)
					{
						goto IL_B3;
					}
					if (num != 1)
					{
						goto IL_B7;
					}
					IL_4B:
					SqlBoolean sqlBoolean = \u0083\u0002.~\u0019\u0005(\u0082\u0002.~\u0018\u0005(#Nuc, 1));
					if (!sqlBoolean.Value)
					{
						goto IL_B7;
					}
					if (false)
					{
						goto IL_AC;
					}
					num2 = (\u0083\u0002.~\u001A\u0005(\u0082\u0002.~\u0018\u0005(#Nuc, 1)).Value ? 1 : 0);
					IL_90:
					if (num2 != 0)
					{
						goto IL_B7;
					}
					if (4 != 0)
					{
						sqlBoolean = \u0083\u0002.~\u001B\u0005(\u0082\u0002.~\u0018\u0005(#Nuc, 1));
						goto IL_AC;
					}
					goto IL_4B;
					IL_B3:
					if (!false)
					{
						break;
					}
					goto IL_90;
					IL_AC:
					result = (num2 = (sqlBoolean.Value ? 1 : 0));
					goto IL_B3;
				}
				IL_B7:
				if (5 != 0)
				{
					return false;
				}
			}
			return result != 0;
		}

		// Token: 0x060041DD RID: 16861 RVA: 0x00134868 File Offset: 0x00132A68
		internal static bool #Zxb(IEnumerable<PolygonData> #yP, out List<PolygonData> #Fuc)
		{
			#X0d.#V0d(#yP, #Phc.#3hc(107372425), Component.Geometry, #Phc.#3hc(107458637));
			#Fuc = new List<PolygonData>();
			using (IEnumerator<PolygonData> enumerator = #yP.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					List<PolygonData> collection;
					if (!#0uc.#Zxb(enumerator.Current, out collection))
					{
						#Fuc.Clear();
						return false;
					}
					#Fuc.AddRange(collection);
				}
			}
			return true;
		}

		// Token: 0x060041DE RID: 16862 RVA: 0x0013493C File Offset: 0x00132B3C
		internal unsafe static bool #Zxb(PolygonData #JP, out List<PolygonData> #Fuc)
		{
			void* ptr = stackalloc byte[8];
			#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107458616));
			#Fuc = new List<PolygonData>();
			SqlGeometry sqlGeometry = #JP.SqlGeometry;
			if (#0uc.#Xuc(sqlGeometry))
			{
				#Fuc.Add(#JP);
			}
			else
			{
				if (sqlGeometry.STNumGeometries().Value <= 1)
				{
					#Fuc.Clear();
					return false;
				}
				*(int*)ptr = 1;
				while (*(int*)ptr <= sqlGeometry.STNumGeometries().Value)
				{
					SqlGeometry sqlGeometry2 = sqlGeometry.STGeometryN(*(int*)ptr);
					if (sqlGeometry2.STIsClosed().Value)
					{
						List<Point> list = new List<Point>();
						*(int*)((byte*)ptr + 4) = 1;
						while (*(int*)((byte*)ptr + 4) <= sqlGeometry2.STNumPoints().Value)
						{
							SqlGeometry sqlGeometry3 = sqlGeometry2.STPointN(*(int*)((byte*)ptr + 4));
							list.Add(new Point(sqlGeometry3.STX.Value, sqlGeometry3.STY.Value));
							*(int*)((byte*)ptr + 4) = *(int*)((byte*)ptr + 4) + 1;
						}
						#Fuc.Add(new PolygonData(PointsConverter.#vsc(list)));
					}
					*(int*)ptr = *(int*)ptr + 1;
				}
			}
			IL_11B:
			if (7 != 0)
			{
				return true;
			}
			goto IL_11B;
		}

		// Token: 0x060041DF RID: 16863 RVA: 0x00134AC0 File Offset: 0x00132CC0
		private static SqlGeometry #Yuc(IList<Point> #Quc, bool #Ruc)
		{
			if (true)
			{
				int i = #Quc.Count;
				while (i < 3)
				{
					int num = i = 107459440;
					if (num != 0)
					{
						i = num;
						if (num != 0)
						{
							i = num;
							if (num != 0)
							{
								throw new #jYd(#Phc.#3hc(num), #Phc.#3hc(107459043), Component.Geometry);
							}
						}
					}
				}
			}
			SqlGeometryBuilder sqlGeometryBuilder = #0uc.#Zuc();
			#0uc.#SHb(sqlGeometryBuilder, #Quc, #Ruc);
			return sqlGeometryBuilder.ConstructedGeometry.MakeValid();
		}

		// Token: 0x060041E0 RID: 16864 RVA: 0x00134B38 File Offset: 0x00132D38
		private static void #SHb(SqlGeometryBuilder #THb, double #QHb, double #RHb)
		{
			for (;;)
			{
				\u0084\u0002.~\u001C\u0005(#THb, OpenGisGeometryType.Point);
				\u0086\u0002.~\u001D\u0005(#THb, #QHb, #RHb);
				\u0007.~\u0011(#THb);
				while (!false)
				{
					\u0007.~\u0012(#THb);
					if (!false)
					{
						if (false)
						{
							break;
						}
						if (5 != 0)
						{
							return;
						}
					}
				}
			}
		}

		// Token: 0x060041E1 RID: 16865 RVA: 0x00134BA4 File Offset: 0x00132DA4
		private static void #SHb(SqlGeometryBuilder #THb, double #Tuc, double #Uuc, double #Vuc, double #Wuc)
		{
			while (-1 != 0)
			{
				\u0084\u0002.~\u001C\u0005(#THb, OpenGisGeometryType.LineString);
				\u0086\u0002.~\u001D\u0005(#THb, #Tuc, #Uuc);
				\u0086\u0002.~\u001E\u0005(#THb, #Vuc, #Wuc);
				if (false || false)
				{
					return;
				}
				if (-1 != 0)
				{
					\u0007.~\u0011(#THb);
					break;
				}
			}
			\u0007.~\u0012(#THb);
		}

		// Token: 0x060041E2 RID: 16866 RVA: 0x00134C20 File Offset: 0x00132E20
		private static void #SHb(SqlGeometryBuilder #THb, IList<Point> #Quc, bool #Ruc)
		{
			int num2;
			int num3;
			if (#Quc.Count < 3)
			{
				int num = num2 = 107459440;
				if (num != 0)
				{
					num3 = num;
					if (num != 0)
					{
						throw new #jYd(#Phc.#3hc(num), #Phc.#3hc(107458990), Component.Geometry);
					}
					goto IL_36;
				}
			}
			else
			{
				num2 = (#Ruc ? 1 : 0);
			}
			OpenGisGeometryType openGisGeometryType;
			if (num2 != 0)
			{
				openGisGeometryType = OpenGisGeometryType.Polygon;
				goto IL_3F;
			}
			num3 = 2;
			IL_36:
			int num5;
			int num4 = num5 = num3;
			if (num4 == 0)
			{
				goto IL_60;
			}
			openGisGeometryType = (OpenGisGeometryType)num4;
			int num6 = num4;
			if (num4 == 0)
			{
				goto IL_54;
			}
			IL_3F:
			OpenGisGeometryType type = openGisGeometryType;
			#THb.BeginGeometry(type);
			num6 = 0;
			IL_54:
			int num7 = num6;
			goto IL_93;
			IL_60:
			if (num5 == 0)
			{
				Point point;
				#THb.BeginFigure(point.X, point.Y);
			}
			else
			{
				if (false)
				{
					goto IL_D3;
				}
				Point point;
				#THb.AddLine(point.X, point.Y);
			}
			num7++;
			IL_93:
			if (num7 < #Quc.Count)
			{
				Point point = #Quc[num7];
				num5 = num7;
				goto IL_60;
			}
			if (Point.#F3d(#Quc.First<Point>(), #Quc.Last<Point>()))
			{
				#THb.AddLine(#Quc[0].X, #Quc[0].Y);
			}
			IL_D3:
			#THb.EndFigure();
			#THb.EndGeometry();
		}

		// Token: 0x060041E3 RID: 16867 RVA: 0x00037415 File Offset: 0x00035615
		private static SqlGeometryBuilder #Zuc()
		{
			SqlGeometryBuilder sqlGeometryBuilder = new SqlGeometryBuilder();
			sqlGeometryBuilder.SetSrid(0);
			return sqlGeometryBuilder;
		}
	}
}
