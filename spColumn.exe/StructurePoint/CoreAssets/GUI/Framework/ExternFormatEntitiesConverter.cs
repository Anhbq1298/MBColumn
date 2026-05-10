using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using #2ic;
using #7hc;
using #ezc;
using #IDc;
using #UYd;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.Framework
{
	// Token: 0x02000B44 RID: 2884
	public sealed class ExternFormatEntitiesConverter : #wAc
	{
		// Token: 0x06005E2D RID: 24109 RVA: 0x00176C4C File Offset: 0x00174E4C
		public ExternFormatEntitiesConverter(#6Gc settingsManager, IDrawingResultsFactory drawingResultsFactory)
		{
			#X0d.#V0d(settingsManager, #Phc.#3hc(107381742), Component.GUIFramework, #Phc.#3hc(107419264));
			#X0d.#V0d(drawingResultsFactory, #Phc.#3hc(107451628), Component.GUIFramework, #Phc.#3hc(107419211));
			this.#b = settingsManager;
			this.#c = drawingResultsFactory;
		}

		// Token: 0x06005E2E RID: 24110 RVA: 0x00176CA8 File Offset: 0x00174EA8
		public IMultilineDrawingResult #Pb(IEnumerable<ILine> #Usb, double #kAc)
		{
			string #R0d = #Phc.#3hc(107358379);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107419190);
			if (!false)
			{
				#X0d.#V0d(#Usb, #R0d, #x6c, #Qic);
			}
			if (!#Usb.Any<ILine>())
			{
				return null;
			}
			IEnumerable<Point3D> enumerable = ExternFormatEntitiesConverter.#lpc(#Usb.SelectMany(new Func<ILine, IEnumerable<IPoint>>(ExternFormatEntitiesConverter.<>c.<>9.#v8c)));
			IEnumerable<Point3D> enumerable2;
			if (4 != 0)
			{
				enumerable2 = enumerable;
			}
			IEnumerable<Point3D> enumerable3 = PointsConverter.#Csc(enumerable2, #kAc);
			if (!false)
			{
				enumerable2 = enumerable3;
			}
			IMultilineDrawingResult multilineDrawingResult = this.#c.CreateMultilineDrawingResult();
			multilineDrawingResult.LineColor = ExternFormatEntitiesConverter.#Pb(#Usb.First<ILine>().Layer.Color);
			multilineDrawingResult.LineThickness = this.#b.VisualizationDefaultLinearObjectThickness;
			IEnumerable<Point3D> positions = enumerable2;
			if (!false)
			{
				multilineDrawingResult.Positions = positions;
			}
			return multilineDrawingResult;
		}

		// Token: 0x06005E2F RID: 24111 RVA: 0x00176D70 File Offset: 0x00174F70
		public IPolygonsDrawingResult #Pb(IEnumerable<#pjc> #lAc, double #kAc)
		{
			string #R0d = #Phc.#3hc(107419617);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107419636);
			if (!false)
			{
				#X0d.#V0d(#lAc, #R0d, #x6c, #Qic);
			}
			if (!#lAc.Any<#pjc>())
			{
				return null;
			}
			IPolygonsDrawingResult polygonsDrawingResult = this.#c.CreatePolygonsDrawingResult();
			IPolygonsDrawingResult polygonsDrawingResult2;
			if (3 != 0)
			{
				polygonsDrawingResult2 = polygonsDrawingResult;
			}
			IPolygonsDrawingResult polygonsDrawingResult3 = polygonsDrawingResult2;
			Visibility surfacesVisibility = Visibility.Collapsed;
			if (4 != 0)
			{
				polygonsDrawingResult3.SurfacesVisibility = surfacesVisibility;
			}
			IEnumerator<#pjc> enumerator = #lAc.GetEnumerator();
			IEnumerator<#pjc> enumerator2;
			if (8 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					#pjc #pjc = enumerator2.Current;
					#pjc #pjc2;
					if (true)
					{
						#pjc2 = #pjc;
					}
					IEnumerable<Point3D> enumerable = ExternFormatEntitiesConverter.#sAc(#pjc2);
					IEnumerable<Point3D> enumerable2;
					if (!false)
					{
						enumerable2 = enumerable;
					}
					enumerable2 = PointsConverter.#Csc(enumerable2, #kAc);
					IPolylineDrawingResult polylineDrawingResult = this.#pAc(#pjc2.Layer);
					polylineDrawingResult.Positions = enumerable2;
					polygonsDrawingResult2.AddOuterEdge(polylineDrawingResult);
				}
			}
			finally
			{
				do
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				while (false);
			}
			return polygonsDrawingResult2;
		}

		// Token: 0x06005E30 RID: 24112 RVA: 0x00176E58 File Offset: 0x00175058
		public IPointsDrawingResult #Pb(IEnumerable<IPoint> #BP, double #kAc)
		{
			string #R0d = #Phc.#3hc(107358670);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107419583);
			if (!false)
			{
				#X0d.#V0d(#BP, #R0d, #x6c, #Qic);
			}
			if (!#BP.Any<IPoint>())
			{
				return null;
			}
			IEnumerable<Point3D> enumerable2;
			do
			{
				if (!false)
				{
					IEnumerable<Point3D> enumerable = ExternFormatEntitiesConverter.#lpc(#BP);
					if (!false)
					{
						enumerable2 = enumerable;
					}
				}
				IEnumerable<Point3D> enumerable3 = PointsConverter.#Csc(enumerable2, #kAc);
				if (7 != 0)
				{
					enumerable2 = enumerable3;
				}
			}
			while (false);
			IPointsDrawingResult pointsDrawingResult = this.#c.CreatePointsDrawingResult();
			pointsDrawingResult.PointColor = ExternFormatEntitiesConverter.#Pb(#BP.First<IPoint>().Layer.Color);
			pointsDrawingResult.PointSize = this.#b.VisualizationDefaultCustomNodeSize;
			IEnumerable<Point3D> points = enumerable2;
			if (3 != 0)
			{
				pointsDrawingResult.Points = points;
			}
			return pointsDrawingResult;
		}

		// Token: 0x06005E31 RID: 24113 RVA: 0x00176EFC File Offset: 0x001750FC
		public IPolygonsDrawingResult #Pb(IEnumerable<#tjc> #mAc, double #kAc)
		{
			string #R0d = #Phc.#3hc(107451907);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107419498);
			if (2 != 0)
			{
				#X0d.#V0d(#mAc, #R0d, #x6c, #Qic);
			}
			if (!#mAc.Any<#tjc>())
			{
				return null;
			}
			IPolygonsDrawingResult polygonsDrawingResult = this.#c.CreatePolygonsDrawingResult();
			IPolygonsDrawingResult polygonsDrawingResult2;
			if (!false)
			{
				polygonsDrawingResult2 = polygonsDrawingResult;
			}
			IPolygonsDrawingResult polygonsDrawingResult3 = polygonsDrawingResult2;
			Visibility surfacesVisibility = Visibility.Collapsed;
			if (5 != 0)
			{
				polygonsDrawingResult3.SurfacesVisibility = surfacesVisibility;
			}
			IEnumerator<#tjc> enumerator = #mAc.GetEnumerator();
			IEnumerator<#tjc> enumerator2;
			if (6 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					#tjc #tjc = enumerator2.Current;
					#tjc #tjc2;
					if (!false)
					{
						#tjc2 = #tjc;
					}
					IEnumerable<Point3D> enumerable = ExternFormatEntitiesConverter.#sAc(#tjc2, this.#b.VisualizationCircleByDiameterToolNumberOfSides);
					IEnumerable<Point3D> enumerable2;
					if (!false)
					{
						enumerable2 = enumerable;
					}
					enumerable2 = PointsConverter.#Csc(enumerable2, #kAc);
					IPolylineDrawingResult polylineDrawingResult = this.#pAc(#tjc2.Layer);
					polylineDrawingResult.Positions = enumerable2;
					polygonsDrawingResult2.AddOuterEdge(polylineDrawingResult);
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			return polygonsDrawingResult2;
		}

		// Token: 0x06005E32 RID: 24114 RVA: 0x00176FF0 File Offset: 0x001751F0
		public IPolygonsDrawingResult #Pb(IEnumerable<#fjc> #nAc, double #kAc)
		{
			string #R0d = #Phc.#3hc(107419477);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107419432);
			if (2 != 0)
			{
				#X0d.#V0d(#nAc, #R0d, #x6c, #Qic);
			}
			if (!#nAc.Any<#fjc>())
			{
				return null;
			}
			IPolygonsDrawingResult polygonsDrawingResult = this.#c.CreatePolygonsDrawingResult();
			IPolygonsDrawingResult polygonsDrawingResult2;
			if (!false)
			{
				polygonsDrawingResult2 = polygonsDrawingResult;
			}
			IPolygonsDrawingResult polygonsDrawingResult3 = polygonsDrawingResult2;
			Visibility surfacesVisibility = Visibility.Collapsed;
			if (5 != 0)
			{
				polygonsDrawingResult3.SurfacesVisibility = surfacesVisibility;
			}
			IEnumerator<#fjc> enumerator = #nAc.GetEnumerator();
			IEnumerator<#fjc> enumerator2;
			if (6 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					#fjc #fjc = enumerator2.Current;
					#fjc #fjc2;
					if (!false)
					{
						#fjc2 = #fjc;
					}
					IEnumerable<Point3D> enumerable = ExternFormatEntitiesConverter.#sAc(#fjc2, this.#b.VisualizationCircleByDiameterToolNumberOfSides);
					IEnumerable<Point3D> enumerable2;
					if (!false)
					{
						enumerable2 = enumerable;
					}
					enumerable2 = PointsConverter.#Csc(enumerable2, #kAc);
					IPolylineDrawingResult polylineDrawingResult = this.#pAc(#fjc2.Layer);
					polylineDrawingResult.Positions = enumerable2;
					polygonsDrawingResult2.AddOuterEdge(polylineDrawingResult);
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			return polygonsDrawingResult2;
		}

		// Token: 0x06005E33 RID: 24115 RVA: 0x001770E4 File Offset: 0x001752E4
		public IEnumerable<IMultilineDrawingResult> #Pb(IEnumerable<#sjc> #oAc, double #kAc)
		{
			string #R0d = #Phc.#3hc(107419411);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107418858);
			if (!false)
			{
				#X0d.#V0d(#oAc, #R0d, #x6c, #Qic);
			}
			if (!#oAc.Any<#sjc>())
			{
				return null;
			}
			List<IMultilineDrawingResult> list = new List<IMultilineDrawingResult>();
			List<IMultilineDrawingResult> list2;
			if (3 != 0)
			{
				list2 = list;
			}
			IEnumerator<#sjc> enumerator = #oAc.GetEnumerator();
			IEnumerator<#sjc> enumerator2;
			if (4 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					#sjc #sjc = enumerator2.Current;
					#sjc #sjc2;
					if (8 != 0)
					{
						#sjc2 = #sjc;
					}
					IEnumerable<Point3D> enumerable = ExternFormatEntitiesConverter.#sAc(#sjc2, this.#b.VisualizationCircleByDiameterToolNumberOfSides);
					IEnumerable<Point3D> enumerable2;
					if (true)
					{
						enumerable2 = enumerable;
					}
					IEnumerable<Point3D> enumerable3 = PointsConverter.#Csc(enumerable2, #kAc);
					if (!false)
					{
						enumerable2 = enumerable3;
					}
					IMultilineDrawingResult multilineDrawingResult = this.#qAc(#sjc2.Layer);
					multilineDrawingResult.Positions = ExternFormatEntitiesConverter.#rAc(enumerable2.ToList<Point3D>());
					list2.Add(multilineDrawingResult);
				}
			}
			finally
			{
				do
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				while (false);
			}
			return list2;
		}

		// Token: 0x06005E34 RID: 24116 RVA: 0x001771D0 File Offset: 0x001753D0
		public static Color #Pb(#1ic #BR)
		{
			string #R0d = #Phc.#3hc(107418837);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107418796);
			if (-1 != 0)
			{
				#X0d.#V0d(#BR, #R0d, #x6c, #Qic);
			}
			if (#BR.R != 255)
			{
				goto IL_56;
			}
			byte b = #BR.G;
			int num = 255;
			IL_36:
			if ((int)b != num)
			{
				goto IL_56;
			}
			int num2 = (int)(b = #BR.B);
			IL_3E:
			int num3 = num = 255;
			if (num3 == 0)
			{
				goto IL_36;
			}
			if (num2 == num3)
			{
				return Color.FromArgb(byte.MaxValue, 0, 0, 0);
			}
			IL_56:
			byte b2 = b = (byte)(num2 = 255);
			if (b2 != 0)
			{
				return Color.FromArgb(b2, #BR.R, #BR.G, #BR.B);
			}
			goto IL_3E;
		}

		// Token: 0x06005E35 RID: 24117 RVA: 0x0004E63F File Offset: 0x0004C83F
		private static IEnumerable<Point3D> #lpc(IEnumerable<IPoint> #BP)
		{
			return #BP.Select(new Func<IPoint, Point3D>(ExternFormatEntitiesConverter.<>c.<>9.#w8c));
		}

		// Token: 0x06005E36 RID: 24118 RVA: 0x0004E666 File Offset: 0x0004C866
		private IPolylineDrawingResult #pAc(#jjc #rR)
		{
			IPolylineDrawingResult polylineDrawingResult = this.#c.CreatePolylineDrawingResult();
			polylineDrawingResult.LineColor = ExternFormatEntitiesConverter.#Pb(#rR.Color);
			double lineThickness = this.#b.VisualizationDefaultLinearObjectThickness;
			if (!false)
			{
				polylineDrawingResult.LineThickness = lineThickness;
			}
			return polylineDrawingResult;
		}

		// Token: 0x06005E37 RID: 24119 RVA: 0x0004E69C File Offset: 0x0004C89C
		private IMultilineDrawingResult #qAc(#jjc #rR)
		{
			IMultilineDrawingResult multilineDrawingResult = this.#c.CreateMultilineDrawingResult();
			multilineDrawingResult.LineColor = ExternFormatEntitiesConverter.#Pb(#rR.Color);
			double lineThickness = this.#b.VisualizationDefaultLinearObjectThickness;
			if (!false)
			{
				multilineDrawingResult.LineThickness = lineThickness;
			}
			return multilineDrawingResult;
		}

		// Token: 0x06005E38 RID: 24120 RVA: 0x0017725C File Offset: 0x0017545C
		private static IEnumerable<Point3D> #rAc(IList<Point3D> #pkc)
		{
			List<Point3D> list2;
			for (;;)
			{
				List<Point3D> list = new List<Point3D>();
				if (!false)
				{
					list2 = list;
				}
				int num = 0;
				int num2;
				if (!false)
				{
					num2 = num;
				}
				while (4 != 0)
				{
					IL_39:
					while (8 != 0)
					{
						int i = num2;
						int num3 = #pkc.Count<Point3D>();
						while (i < num3 - 1)
						{
							List<Point3D> list3 = list2;
							Point3D item = #pkc[num2];
							if (4 != 0)
							{
								list3.Add(item);
							}
							List<Point3D> list4 = list2;
							Point3D item2 = #pkc[num2 + 1];
							if (7 != 0)
							{
								list4.Add(item2);
							}
							int num4 = i = num2;
							int num5 = num3 = 1;
							if (num5 != 0)
							{
								int num6 = num4 + num5;
								if (false)
								{
									goto IL_39;
								}
								num2 = num6;
								goto IL_39;
							}
						}
						return list2;
					}
				}
			}
			return list2;
		}

		// Token: 0x06005E39 RID: 24121 RVA: 0x001772C8 File Offset: 0x001754C8
		private static IEnumerable<Point3D> #sAc(#pjc #tAc)
		{
			List<Point3D> list = ExternFormatEntitiesConverter.#lpc(#tAc.Vertexes.Select(new Func<IVertex, IPoint>(ExternFormatEntitiesConverter.<>c.<>9.#x8c))).ToList<Point3D>();
			List<Point3D> list2;
			if (!false)
			{
				list2 = list;
			}
			if (#tAc.IsClosed)
			{
				Point3D point3D = list2.Last<Point3D>();
				Point3D point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				double num = point3D2.X;
				Point3D point3D3 = list2[0];
				Point3D point3D4;
				if (!false)
				{
					point3D4 = point3D3;
				}
				if (num == point3D4.X)
				{
					double num2 = point3D2.Y;
					Point3D point3D5 = list2[0];
					if (3 != 0)
					{
						point3D4 = point3D5;
					}
					if (num2 == point3D4.Y)
					{
						return list2;
					}
				}
				List<Point3D> list3 = list2;
				Point3D item = list2[0];
				if (3 != 0)
				{
					list3.Add(item);
				}
			}
			return list2;
		}

		// Token: 0x06005E3A RID: 24122 RVA: 0x00177378 File Offset: 0x00175578
		private static IEnumerable<Point3D> #sAc(#tjc #uAc, int #Znc)
		{
			List<Point3D> list = new List<Point3D>();
			List<Point3D> list2;
			if (!false)
			{
				list2 = list;
			}
			int num = 0;
			int num2;
			if (8 != 0)
			{
				num2 = num;
			}
			if (5 != 0)
			{
				goto IL_9D;
			}
			IL_80:
			List<Point3D> list3 = list2;
			double x;
			double y;
			Point3D item = new Point3D(x, y, #uAc.CenterPoint.Z);
			if (6 != 0)
			{
				list3.Add(item);
			}
			int num3 = num2;
			IL_9A:
			num2 = num3 + 1;
			IL_9D:
			int num4 = num3 = num2;
			if (-1 == 0)
			{
				goto IL_9A;
			}
			if (num4 > #Znc)
			{
				return list2;
			}
			if (!true)
			{
				goto IL_59;
			}
			double num5 = 6.283185307179586 * (double)num2 / (double)#Znc;
			double num6;
			if (!false)
			{
				num6 = num5;
			}
			double num7 = #uAc.Radius * Math.Cos(num6);
			IL_42:
			double num8 = Math.Round(num7 + #uAc.CenterPoint.X, 10);
			if (true)
			{
				x = num8;
			}
			IL_59:
			double num9 = num7 = #uAc.Radius * Math.Sin(num6);
			if (false)
			{
				goto IL_42;
			}
			double num10 = Math.Round(num9 + #uAc.CenterPoint.Y, 10);
			if (5 == 0)
			{
				goto IL_80;
			}
			y = num10;
			goto IL_80;
		}

		// Token: 0x06005E3B RID: 24123 RVA: 0x00177450 File Offset: 0x00175650
		private static IEnumerable<Point3D> #sAc(#fjc #vAc, int #Znc)
		{
			List<Point3D> list = new List<Point3D>();
			List<Point3D> list2;
			if (!false)
			{
				list2 = list;
			}
			double num2;
			double num = num2 = #vAc.StartAngle;
			double num4;
			int num7;
			if (!false)
			{
				double num3 = Math.Abs(num - #vAc.EndAngle);
				if (!false)
				{
					num4 = num3;
				}
				double num5 = (num4 <= 0.001) ? 360.0 : num4;
				if (!false)
				{
					num4 = num5;
				}
				int num6 = (int)((double)#Znc * (num4 / 360.0));
				if (!false)
				{
					num7 = num6;
				}
				if (false)
				{
					goto IL_71;
				}
				num2 = #vAc.StartAngle;
			}
			int num8;
			if (num2 >= #vAc.EndAngle)
			{
				num8 = -1;
				goto IL_72;
			}
			IL_71:
			num8 = 1;
			IL_72:
			int num9;
			if (!false)
			{
				num9 = num8;
			}
			double num10 = #vAc.MajorAxisAngle * 3.141592653589793 / 180.0;
			double num11;
			if (-1 != 0)
			{
				num11 = num10;
			}
			for (int i = 0; i <= num7; i++)
			{
				double num12 = #vAc.StartAngle;
				double num13 = num4;
				double x;
				double num21;
				double num22;
				for (;;)
				{
					double num14;
					object obj = num14 = num12 + num13 * (double)i / (double)num7 * (double)num9;
					double num16;
					double num15 = num16 = 3.141592653589793;
					object obj2;
					double num17;
					if (!false)
					{
						obj2 = obj * num15;
						num17 = 180.0;
						goto IL_CA;
					}
					IL_F7:
					double num18 = num16;
					double num19 = num12 = num14;
					double num20 = num13 = num19 * Math.Cos(num11);
					if (8 == 0)
					{
						continue;
					}
					x = Math.Round(num20 - num18 * Math.Sin(num11) + #vAc.CenterPoint.X, 10);
					num21 = (obj2 = num19 * Math.Sin(num11));
					num22 = (num17 = num18);
					if (7 != 0)
					{
						break;
					}
					IL_CA:
					double num23 = obj2 / num17;
					num14 = Math.Round(#vAc.MajorAxisLength * Math.Cos(num23), 10);
					num16 = Math.Round(#vAc.MinorAxisLength * Math.Sin(num23), 10);
					goto IL_F7;
				}
				double y = Math.Round(num21 + num22 * Math.Cos(num11) + #vAc.CenterPoint.Y, 10);
				list2.Add(new Point3D(x, y, #vAc.CenterPoint.Z));
			}
			return list2;
		}

		// Token: 0x06005E3C RID: 24124 RVA: 0x001775FC File Offset: 0x001757FC
		private static IEnumerable<Point3D> #sAc(#sjc #Kkc, int #Znc)
		{
			List<Point3D> list = new List<Point3D>();
			List<Point3D> list2;
			if (true)
			{
				list2 = list;
			}
			while (#Kkc != null && #Kkc.Radius != 0.0)
			{
				double num = #Kkc.Radius;
				double num2;
				if (6 != 0)
				{
					num2 = num;
				}
				double value;
				double num3 = value = Math.Abs(#Kkc.StartAngle - #Kkc.EndAngle);
				double num4;
				double num5;
				if (4 != 0)
				{
					if (!false)
					{
						num4 = num3;
					}
					num5 = #Kkc.StartAngle;
					goto IL_54;
				}
				goto IL_D7;
				IL_103:
				int num6;
				double num10;
				if (num6 > #Znc)
				{
					if (8 != 0)
					{
						return list2;
					}
					continue;
				}
				else
				{
					double num7 = num5 = #Kkc.StartAngle;
					if (-1 != 0)
					{
						int num9;
						double num8 = (num7 + num4 * (double)num6 / (double)#Znc * (double)num9) * 3.141592653589793 / 180.0;
						if (7 != 0)
						{
							num10 = num8;
						}
						double x = Math.Round(num2 * Math.Cos(num10) + #Kkc.CenterPoint.X, 10);
						goto IL_C2;
					}
				}
				IL_54:
				int num11 = (num5 < #Kkc.EndAngle) ? 1 : -1;
				if (true)
				{
					int num9 = num11;
				}
				int num12 = 0;
				if (6 != 0)
				{
					num6 = num12;
				}
				goto IL_103;
				IL_D7:
				double y = Math.Round(value, 10);
				if (!false)
				{
					double x;
					list2.Add(new Point3D(x, y, #Kkc.CenterPoint.Z));
					num6++;
					goto IL_103;
				}
				IL_C2:
				value = num2 * Math.Sin(num10) + #Kkc.CenterPoint.Y;
				goto IL_D7;
			}
			return list2;
		}

		// Token: 0x04002710 RID: 10000
		private const byte #a = 255;

		// Token: 0x04002711 RID: 10001
		private readonly #6Gc #b;

		// Token: 0x04002712 RID: 10002
		private readonly IDrawingResultsFactory #c;
	}
}
