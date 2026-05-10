using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using #aHb;
using #eU;
using #Fmc;
using #hR;
using #o1d;
using #RJb;
using #xKe;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using Microsoft.SqlServer.Types;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x02000603 RID: 1539
	internal sealed class ColumnShapesHelper
	{
		// Token: 0x0600348F RID: 13455 RVA: 0x00105080 File Offset: 0x00103280
		public static IList<devDept.Geometry.Point3D> #rHb(#oW #xn, ISettingsManager #ng, ShapeModel #sHb, IReadOnlyCollection<StructurePoint.CoreAssets.Infrastructure.Data.Point> #4Ab, StructurePoint.CoreAssets.Infrastructure.Data.Point #qAb)
		{
			ColumnShapesHelper.#GTb #GTb = new ColumnShapesHelper.#GTb();
			#GTb.#a = #4Ab;
			#GTb.#b = #qAb;
			if (#sHb.FigureType != PolygonFigureType.Circle)
			{
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point> source = #sHb.#fxc();
				return source.Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, devDept.Geometry.Point3D>(#GTb.#pbc)).ToList<devDept.Geometry.Point3D>();
			}
			if (#sHb.CircleCenter != null && #sHb.CircleRadius != null)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng = StructurePoint.CoreAssets.Infrastructure.Data.Point.#G3d(#sHb.CircleCenter.Value, #GTb.#b);
				int numberOfSides = #4ai.#3ai(#xn.Model.Options.Unit, #sHb.CircleRadius.Value, 40);
				return EyeshotHelper.ConstructRegularPolygon(#Ng.#TW(), #sHb.CircleRadius.Value, numberOfSides, 0.0, true);
			}
			return null;
		}

		// Token: 0x06003490 RID: 13456 RVA: 0x00105180 File Offset: 0x00103380
		public static bool #pHb(#cLb #FR, ICollection<ShapeModel> #6Y, IReadOnlyCollection<StructurePoint.CoreAssets.Infrastructure.Data.Point> #4Ab, StructurePoint.CoreAssets.Infrastructure.Data.Point #qAb)
		{
			ColumnShapesHelper.#v0b #v0b = new ColumnShapesHelper.#v0b();
			#v0b.#a = #FR;
			Dictionary<IList<devDept.Geometry.Point3D>, bool> dictionary = new Dictionary<IList<devDept.Geometry.Point3D>, bool>();
			foreach (ShapeModel shapeModel in #6Y)
			{
				IList<devDept.Geometry.Point3D> list = ColumnShapesHelper.#rHb(#v0b.#a.ProjectContext, #v0b.#a.Settings, shapeModel, #4Ab, #qAb);
				if (list != null)
				{
					bool value = true;
					if (shapeModel.FigureType != PolygonFigureType.Circle)
					{
						value = (ColumnModelHelper.#9W(list) && ColumnShapesHelper.#tHb(#v0b.#a.Snapping, #6Y, #4Ab, #qAb));
					}
					dictionary[list] = value;
				}
			}
			bool flag = dictionary.All(new Func<KeyValuePair<IList<devDept.Geometry.Point3D>, bool>, bool>(ColumnShapesHelper.<>c.<>9.#rbc));
			#v0b.#b = (flag ? #qHb.#d : #qHb.#e);
			dictionary.#I1d(new Action<KeyValuePair<IList<devDept.Geometry.Point3D>, bool>>(#v0b.#qbc));
			return flag;
		}

		// Token: 0x06003491 RID: 13457 RVA: 0x00105298 File Offset: 0x00103498
		public static bool #tHb(#2Lb #uHb, ICollection<ShapeModel> #6Y, IReadOnlyCollection<StructurePoint.CoreAssets.Infrastructure.Data.Point> #4Ab, StructurePoint.CoreAssets.Infrastructure.Data.Point #qAb)
		{
			if (#qAb.#I3d().Length <= 0.0001)
			{
				return true;
			}
			double #WLb = #uHb.#NLb();
			foreach (ShapeModel shapeModel in #6Y)
			{
				ColumnShapesHelper.#wbc #wbc = new ColumnShapesHelper.#wbc();
				#wbc.#a = shapeModel.#fxc().OrderBy(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, double>(ColumnShapesHelper.<>c.<>9.#sbc)).ThenBy(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, double>(ColumnShapesHelper.<>c.<>9.#tbc)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
				List<StructurePoint.CoreAssets.Infrastructure.Data.Point> other = #4Ab.Where(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, bool>(#wbc.#vbc)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
				HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point> hashSet = #wbc.#a.ToHashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
				hashSet.ExceptWith(other);
				foreach (StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng in #4Ab)
				{
					StructurePoint.CoreAssets.Infrastructure.Data.Point point = StructurePoint.CoreAssets.Infrastructure.Data.Point.#G3d(#Ng, #qAb);
					if (SnappingProviderHelper.#Uqc(#wbc.#a, new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(point.X, point.Y), #WLb) != null)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06003492 RID: 13458 RVA: 0x00105440 File Offset: 0x00103640
		public static void #vHb(#oW #xn, StructurePoint.CoreAssets.Infrastructure.Data.Point #qAb, ShapeModel #sHb)
		{
			ColumnShapesHelper.#dZb #dZb = new ColumnShapesHelper.#dZb();
			#dZb.#a = #qAb;
			if (#sHb.FigureType == PolygonFigureType.Circle)
			{
				if (#sHb.CircleCenter != null && #sHb.CircleRadius != null)
				{
					StructurePoint.CoreAssets.Infrastructure.Data.Point point = new StructurePoint.CoreAssets.Infrastructure.Data.Point(#sHb.CircleCenter.Value.X + #dZb.#a.X, #sHb.CircleCenter.Value.Y + #dZb.#a.Y);
					StructurePoint.CoreAssets.Infrastructure.Data.Point3D #wob = new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(point);
					int #Znc = #4ai.#3ai(#xn.Model.Options.Unit, #sHb.CircleRadius.Value, 40);
					List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points3D = GeometryHelper.#2nc(#wob, #sHb.CircleRadius.Value, #Znc, 0.0, true);
					#sHb.#o0(new StructurePoint.CoreAssets.Infrastructure.Data.Point?(point));
					#sHb.#8wc(new PolygonData(points3D, PolygonType.Circle));
					return;
				}
			}
			else if (#sHb.Polygons.Any<PolygonData>())
			{
				List<PolygonData> #9wc = #sHb.Polygons.Select(new Func<PolygonData, PolygonData>(#dZb.#xbc)).ToList<PolygonData>();
				#sHb.#8wc(#9wc);
			}
		}

		// Token: 0x06003493 RID: 13459 RVA: 0x00105598 File Offset: 0x00103798
		public static void #wHb(#cLb #FR, ICollection<ShapeModel> #eAb, StructurePoint.CoreAssets.Infrastructure.Data.Point #qAb)
		{
			foreach (ShapeModel #sHb in #eAb)
			{
				ColumnShapesHelper.#vHb(#FR.ProjectContext, #qAb, #sHb);
			}
		}

		// Token: 0x06003494 RID: 13460 RVA: 0x001055F4 File Offset: 0x001037F4
		public static bool #xHb(PolygonData #yHb, ShapeModel #Rf, StructurePoint.CoreAssets.Infrastructure.Data.Point #oBb, StructurePoint.CoreAssets.Infrastructure.Data.Point #pBb)
		{
			if (!BooleanOperationsHelper.#7lc(#Rf, #yHb))
			{
				return false;
			}
			if (ColumnShapesHelper.#UHb(#Rf.#cxc(0), #oBb) && ColumnShapesHelper.#UHb(#Rf.#cxc(0), #pBb))
			{
				return true;
			}
			HashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point> hashSet = #Rf.#cxc(0).Points2D.ToHashSet<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			return ((!ColumnShapesHelper.#WHb(#Rf, #oBb) || hashSet.Contains(#oBb)) && (!ColumnShapesHelper.#WHb(#Rf, #pBb) || hashSet.Contains(#pBb))) || ((!ColumnShapesHelper.#WHb(#Rf, #oBb) || hashSet.Contains(#oBb)) && ColumnShapesHelper.#UHb(#Rf.#cxc(0), #pBb)) || ((!ColumnShapesHelper.#WHb(#Rf, #pBb) || hashSet.Contains(#pBb)) && ColumnShapesHelper.#UHb(#Rf.#cxc(0), #oBb));
		}

		// Token: 0x06003495 RID: 13461 RVA: 0x001056CC File Offset: 0x001038CC
		public static void #zHb(IEnumerable<devDept.Geometry.Point3D> #AHb, #cLb #FR)
		{
			devDept.Geometry.Point3D[] array;
			if ((array = (#AHb as devDept.Geometry.Point3D[])) == null)
			{
				array = #AHb.ToArray<devDept.Geometry.Point3D>();
			}
			devDept.Geometry.Point3D[] #AHb2 = array;
			ColumnShapesHelper.#ZHb(#AHb2, #FR, #qHb.#a, false);
		}

		// Token: 0x06003496 RID: 13462 RVA: 0x00105700 File Offset: 0x00103900
		public static devDept.Geometry.Point3D[] #BHb(devDept.Geometry.Point3D #Xrb, devDept.Geometry.Point3D #Yrb, bool #CHb)
		{
			devDept.Geometry.Point3D point3D = new devDept.Geometry.Point3D(Math.Min(#Xrb.X, #Yrb.X), Math.Max(#Xrb.Y, #Yrb.Y));
			devDept.Geometry.Point3D point3D2 = new devDept.Geometry.Point3D(Math.Min(#Xrb.X, #Yrb.X), Math.Min(#Xrb.Y, #Yrb.Y));
			devDept.Geometry.Point3D point3D3 = new devDept.Geometry.Point3D(Math.Max(#Xrb.X, #Yrb.X), Math.Max(#Xrb.Y, #Yrb.Y));
			devDept.Geometry.Point3D point3D4 = new devDept.Geometry.Point3D(Math.Max(#Xrb.X, #Yrb.X), Math.Min(#Xrb.Y, #Yrb.Y));
			if (!#CHb)
			{
				return new devDept.Geometry.Point3D[]
				{
					point3D,
					point3D2,
					point3D4,
					point3D3
				};
			}
			return new devDept.Geometry.Point3D[]
			{
				point3D,
				point3D2,
				point3D4,
				point3D3,
				point3D
			};
		}

		// Token: 0x06003497 RID: 13463 RVA: 0x00105800 File Offset: 0x00103A00
		public static List<devDept.Geometry.Point3D> #DHb(#oW #xn, ISettingsManager #ng, ShapeModel #rP, devDept.Geometry.Point3D #EHb = null)
		{
			List<devDept.Geometry.Point3D> list = new List<devDept.Geometry.Point3D>();
			if (#rP.FigureType == PolygonFigureType.Circle && #rP.CircleRadius != null && #rP.CircleCenter != null)
			{
				devDept.Geometry.Point3D center = new devDept.Geometry.Point3D(#rP.CircleCenter.Value.X, #rP.CircleCenter.Value.Y);
				int numberOfSides = #4ai.#3ai(#xn.Model.Options.Unit, #rP.CircleRadius.Value, 40);
				list = EyeshotHelper.ConstructRegularPolygon(center, #rP.CircleRadius.Value, numberOfSides, 0.0, false);
			}
			else
			{
				list.AddRange(#rP.#fxc().Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, devDept.Geometry.Point3D>(ColumnShapesHelper.<>c.<>9.#ubc)));
			}
			if (#EHb != null)
			{
				foreach (devDept.Geometry.Point3D point3D in list)
				{
					point3D.X += #EHb.X;
					point3D.Y += #EHb.Y;
					point3D.Z += #EHb.Z;
				}
			}
			return list;
		}

		// Token: 0x06003498 RID: 13464 RVA: 0x0002E3C0 File Offset: 0x0002C5C0
		public static void #FHb(devDept.Geometry.Point3D #rG, double #HS, #cLb #FR, #qHb #GHb)
		{
			ColumnShapesHelper.#HHb(new List<devDept.Geometry.Point3D>
			{
				#rG
			}, #HS, #FR, #GHb);
		}

		// Token: 0x06003499 RID: 13465 RVA: 0x00105990 File Offset: 0x00103B90
		public static void #HHb(IList<devDept.Geometry.Point3D> #KJ, double #HS, #cLb #FR, #qHb #GHb)
		{
			if (#KJ.Count <= 0)
			{
				return;
			}
			EyeshotEditor editor = #FR.Editor;
			Color color = Color.Black;
			if (#GHb == #qHb.#a || #GHb == #qHb.#b)
			{
				color = #FR.Settings.CurrentColorSettings.BarAreaColor.Convert();
			}
			if (#GHb == #qHb.#c)
			{
				color = #KT.#o;
			}
			if (#GHb == #qHb.#f)
			{
				color = #KT.#0;
			}
			RenderContextBase renderContext = #FR.Editor.renderContext;
			renderContext.PushBlendState();
			renderContext.PushShader();
			renderContext.SetState(blendStateType.Blend);
			renderContext.SetShader(shaderType.NoLights, null, false);
			renderContext.SetColorWireframe(color, false);
			IList<devDept.Geometry.Point3D> list = new List<devDept.Geometry.Point3D>(#KJ.Count);
			devDept.Geometry.Point3D[] array = #bIb.Instance.#7Hb(#HS, true);
			array = editor.WorldToScreen(array);
			object obj = array.Clone();
			devDept.Geometry.Point3D b = editor.WorldToScreen(new devDept.Geometry.Point3D());
			for (int i = 0; i < #KJ.Count; i++)
			{
				devDept.Geometry.Point3D point3D = #KJ[i];
				devDept.Geometry.Point3D point3D2 = (devDept.Geometry.Point3D)point3D.Clone();
				list.Add(new devDept.Geometry.Point3D(point3D2.X, point3D2.Y));
				point3D2 = editor.WorldToScreen(point3D2);
				devDept.Geometry.Point3D b2 = point3D2 - b;
				for (int j = 0; j < array.Length; j++)
				{
					devDept.Geometry.Point3D[] array2 = array;
					int num = j;
					array2[num] += b2;
				}
				renderContext.DrawTriangles(array, new Vector3D(0.0, 0.0, 1.0));
				for (int k = 0; k < array.Length; k++)
				{
					devDept.Geometry.Point3D[] array2 = array;
					int num = k;
					array2[num] -= b2;
				}
			}
			renderContext.SetPointSize(#KT.#1, true, false);
			devDept.Geometry.Point3D[] points = editor.WorldToScreen(list);
			renderContext.SetColorWireframe(Color.Black, false);
			renderContext.DrawPoints(points);
			renderContext.PopShader();
			renderContext.PopBlendState();
		}

		// Token: 0x0600349A RID: 13466 RVA: 0x00105B8C File Offset: 0x00103D8C
		public static void #HHb(IList<ReinforcementBar> #KJ, #cLb #FR, #qHb #GHb, devDept.Geometry.Point3D #qAb = null)
		{
			if (#KJ.Count <= 0)
			{
				return;
			}
			EyeshotEditor editor = #FR.Editor;
			Color color = Color.Black;
			if (#GHb == #qHb.#a || #GHb == #qHb.#b)
			{
				color = #FR.Settings.CurrentColorSettings.BarAreaColor.Convert();
			}
			if (#GHb == #qHb.#c)
			{
				color = #KT.#o;
			}
			if (#GHb == #qHb.#f)
			{
				color = #KT.#0;
			}
			RenderContextBase renderContext = #FR.Editor.renderContext;
			renderContext.PushBlendState();
			renderContext.PushShader();
			renderContext.SetState(blendStateType.Blend);
			renderContext.SetShader(shaderType.NoLights, null, false);
			renderContext.SetColorWireframe(color, false);
			IList<devDept.Geometry.Point3D> list = new List<devDept.Geometry.Point3D>(#KJ.Count);
			for (int i = 0; i < #KJ.Count; i++)
			{
				ReinforcementBar reinforcementBar = #KJ[i];
				if ((double)reinforcementBar.Area > 0.001)
				{
					double #HS = CircleHelper.#wmc((double)reinforcementBar.Area);
					devDept.Geometry.Point3D point3D = (devDept.Geometry.Point3D)reinforcementBar.Point.Clone();
					if (#qAb != null)
					{
						point3D += #qAb;
					}
					list.Add(point3D);
					devDept.Geometry.Point3D[] array = #bIb.Instance.#7Hb(#HS, true);
					for (int j = 0; j < array.Length; j++)
					{
						devDept.Geometry.Point3D[] array2 = array;
						int num = j;
						array2[num] += point3D;
						array[j].Z = #KT.#b + 0.001;
					}
					array = editor.WorldToScreen(array);
					renderContext.DrawTriangles(array, new Vector3D(0.0, 0.0, 1.0));
				}
			}
			renderContext.SetPointSize(#KT.#1, true, false);
			devDept.Geometry.Point3D[] points = editor.WorldToScreen(list);
			renderContext.SetColorWireframe(Color.Black, false);
			renderContext.DrawPoints(points);
			renderContext.PopShader();
			renderContext.PopBlendState();
		}

		// Token: 0x0600349B RID: 13467 RVA: 0x00105D78 File Offset: 0x00103F78
		public static void #IHb(IEnumerable<devDept.Geometry.Point3D> #AHb, #cLb #FR, #qHb #GHb, PolygonApplication #C)
		{
			devDept.Geometry.Point3D[] array;
			if ((array = (#AHb as devDept.Geometry.Point3D[])) == null)
			{
				array = #AHb.ToArray<devDept.Geometry.Point3D>();
			}
			devDept.Geometry.Point3D[] #AHb2 = array;
			bool flag = #FR.Editor.IsCameraInDefaultPosition() && (#GHb == #qHb.#a || #GHb == #qHb.#b);
			if (flag)
			{
				ColumnShapesHelper.#1Hb(#AHb2, #FR, #GHb, #C);
			}
			ColumnShapesHelper.#ZHb(#AHb2, #FR, #GHb, true);
		}

		// Token: 0x0600349C RID: 13468 RVA: 0x0002E3E2 File Offset: 0x0002C5E2
		public static IEnumerable<devDept.Geometry.Point3D> #JHb(devDept.Geometry.Point3D #wob, float #HS, List<float> #KHb)
		{
			ColumnShapesHelper.#Abc #Abc = new ColumnShapesHelper.#Abc(-2);
			#Abc.#g = #wob;
			#Abc.#i = #HS;
			#Abc.#e = #KHb;
			return #Abc;
		}

		// Token: 0x0600349D RID: 13469 RVA: 0x00105DD4 File Offset: 0x00103FD4
		public static CircleDirection #LHb(devDept.Geometry.Point3D #wob, devDept.Geometry.Point3D #MHb, devDept.Geometry.Point3D #NHb)
		{
			double num = (#MHb.X - #wob.X) * (#NHb.Y - #wob.Y) - (#MHb.Y - #wob.Y) * (#NHb.X - #wob.X);
			if (num < 0.0)
			{
				return CircleDirection.Clockwise;
			}
			if (num > 0.0)
			{
				return CircleDirection.CounterClockwise;
			}
			return CircleDirection.None;
		}

		// Token: 0x0600349E RID: 13470 RVA: 0x00105E44 File Offset: 0x00104044
		public static bool #OHb(devDept.Geometry.Point3D #wob, devDept.Geometry.Point3D #Mzb, devDept.Geometry.Point3D #Yrb)
		{
			Vector3D vector3D = new Vector3D(#wob, #Mzb);
			Vector3D vector3D2 = new Vector3D(#wob, #Yrb);
			vector3D.Normalize();
			vector3D2.Normalize();
			double value = Vector3D.AngleBetween(vector3D, vector3D2);
			return Math.Abs(value) > 0.0;
		}

		// Token: 0x0600349F RID: 13471 RVA: 0x00105E98 File Offset: 0x00104098
		private static SqlGeometry #PHb(double #QHb, double #RHb)
		{
			SqlGeometryBuilder sqlGeometryBuilder = new SqlGeometryBuilder();
			sqlGeometryBuilder.SetSrid(0);
			ColumnShapesHelper.#SHb(sqlGeometryBuilder, #QHb, #RHb);
			return sqlGeometryBuilder.ConstructedGeometry;
		}

		// Token: 0x060034A0 RID: 13472 RVA: 0x0002E400 File Offset: 0x0002C600
		private static void #SHb(SqlGeometryBuilder #THb, double #QHb, double #RHb)
		{
			#THb.BeginGeometry(OpenGisGeometryType.Point);
			#THb.BeginFigure(#QHb, #RHb);
			#THb.EndFigure();
			#THb.EndGeometry();
		}

		// Token: 0x060034A1 RID: 13473 RVA: 0x00105ECC File Offset: 0x001040CC
		private static bool #UHb(PolygonData #VHb, StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng)
		{
			ColumnShapesHelper.#i9b #i9b = new ColumnShapesHelper.#i9b();
			#i9b.#a = #Ng;
			return #VHb.Segments.Any(new Func<SegmentData, bool>(#i9b.#Bbc));
		}

		// Token: 0x060034A2 RID: 13474 RVA: 0x00105F0C File Offset: 0x0010410C
		private static bool #WHb(ShapeModel #XHb, StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng)
		{
			if (!#XHb.Polygons.Any<PolygonData>())
			{
				return false;
			}
			SqlGeometry #YHb = ColumnShapesHelper.#PHb(#Ng.X, #Ng.Y);
			return ColumnShapesHelper.#WHb(#XHb, #YHb);
		}

		// Token: 0x060034A3 RID: 13475 RVA: 0x00105F50 File Offset: 0x00104150
		private static bool #WHb(ShapeModel #XHb, SqlGeometry #YHb)
		{
			ColumnShapesHelper.#uZb #uZb = new ColumnShapesHelper.#uZb();
			ColumnShapesHelper.#uZb #uZb2;
			if (!false)
			{
				#uZb2 = #uZb;
			}
			#uZb2.#a = #YHb;
			bool value = #XHb.#cxc(0).SqlGeometry.STContains(#uZb2.#a).Value;
			if (#XHb.PolygonsCount == 1)
			{
				return value;
			}
			return value && !#XHb.Polygons.Skip(1).Any(new Func<PolygonData, bool>(#uZb2.#Cbc));
		}

		// Token: 0x060034A4 RID: 13476 RVA: 0x00105FC8 File Offset: 0x001041C8
		private static void #ZHb(devDept.Geometry.Point3D[] #AHb, #cLb #FR, #qHb #GHb, bool #0Hb = true)
		{
			EyeshotEditor editor = #FR.Editor;
			RenderContextBase renderContext = editor.renderContext;
			renderContext.SetColorWireframe((#GHb == #qHb.#a) ? #KT.#h : ((#GHb == #qHb.#b) ? #KT.#x : ((#GHb == #qHb.#c) ? #KT.#n : ((#GHb == #qHb.#d) ? #KT.#A : #KT.#B))), false);
			renderContext.SetLineSizeExt((#GHb == #qHb.#b) ? #KT.#u : #KT.#r);
			for (int i = 0; i < #AHb.Length; i++)
			{
				if (#0Hb || i != #AHb.Length - 1)
				{
					renderContext.DrawLine(editor.WorldToScreen(#AHb[i]), editor.WorldToScreen(#AHb[(i == #AHb.Length - 1) ? 0 : (i + 1)]));
				}
			}
		}

		// Token: 0x060034A5 RID: 13477 RVA: 0x0010608C File Offset: 0x0010428C
		private static void #1Hb(devDept.Geometry.Point3D[] #AHb, #cLb #FR, #qHb #GHb, PolygonApplication #2Hb)
		{
			if (#AHb.Length < 2)
			{
				return;
			}
			if (#AHb[0] == #AHb[1])
			{
				return;
			}
			EyeshotEditor editor = #FR.Editor;
			RenderContextBase renderContext = #FR.Editor.renderContext;
			Mesh mesh = UtilityEx.Triangulate(#AHb.ToList<devDept.Geometry.Point3D>(), null, null, null);
			List<devDept.Geometry.Point3D> list = mesh.Vertices.Select(new Func<devDept.Geometry.Point3D, devDept.Geometry.Point3D>(editor.WorldToScreen)).ToList<devDept.Geometry.Point3D>();
			List<devDept.Geometry.Point3D> list2 = new List<devDept.Geometry.Point3D>();
			foreach (IndexTriangle indexTriangle in mesh.Triangles)
			{
				list2.Add(list[indexTriangle.V1]);
				list2.Add(list[indexTriangle.V2]);
				list2.Add(list[indexTriangle.V3]);
			}
			renderContext.PushBlendState();
			renderContext.PushShader();
			renderContext.SetShader(shaderType.NoLights, null, false);
			renderContext.SetState(blendStateType.Blend);
			Color color;
			if (#GHb == #qHb.#a)
			{
				color = #KT.#k;
			}
			else
			{
				color = ((#2Hb == PolygonApplication.Solid) ? #FR.Settings.CurrentColorSettings.SolidColor.Convert() : #FR.Settings.CurrentColorSettings.OpeningColor.Convert());
				if (#GHb == #qHb.#b)
				{
					color = Color.FromArgb(150, (int)color.R, (int)color.G, (int)color.B);
				}
			}
			renderContext.SetColorWireframe(color, false);
			renderContext.DrawTriangles(list2.ToArray(), new Vector3D(0.0, 0.0, 1.0));
			renderContext.PopShader();
			renderContext.PopBlendState();
		}

		// Token: 0x02000605 RID: 1541
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x060034AE RID: 13486 RVA: 0x00106238 File Offset: 0x00104438
			internal devDept.Geometry.Point3D #pbc(StructurePoint.CoreAssets.Infrastructure.Data.Point #Rf)
			{
				if (this.#a.Contains(#Rf))
				{
					return new devDept.Geometry.Point3D(#Rf.X + this.#b.X, #Rf.Y + this.#b.Y);
				}
				return #Rf.#TW();
			}

			// Token: 0x040015C5 RID: 5573
			public IReadOnlyCollection<StructurePoint.CoreAssets.Infrastructure.Data.Point> #a;

			// Token: 0x040015C6 RID: 5574
			public StructurePoint.CoreAssets.Infrastructure.Data.Point #b;
		}

		// Token: 0x02000606 RID: 1542
		[CompilerGenerated]
		private sealed class #i9b
		{
			// Token: 0x060034B0 RID: 13488 RVA: 0x0002E467 File Offset: 0x0002C667
			internal bool #Bbc(SegmentData #Rf)
			{
				return #jsc.#vlc(#Rf, this.#a, true);
			}

			// Token: 0x040015C7 RID: 5575
			public StructurePoint.CoreAssets.Infrastructure.Data.Point #a;
		}

		// Token: 0x02000607 RID: 1543
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x060034B2 RID: 13490 RVA: 0x0002E482 File Offset: 0x0002C682
			internal void #qbc(KeyValuePair<IList<devDept.Geometry.Point3D>, bool> #Rf)
			{
				ColumnShapesHelper.#IHb(#Rf.Key, this.#a, this.#b, PolygonApplication.Solid);
			}

			// Token: 0x040015C8 RID: 5576
			public #cLb #a;

			// Token: 0x040015C9 RID: 5577
			public #qHb #b;
		}

		// Token: 0x02000608 RID: 1544
		[CompilerGenerated]
		private sealed class #uZb
		{
			// Token: 0x060034B4 RID: 13492 RVA: 0x00106294 File Offset: 0x00104494
			internal bool #Cbc(PolygonData #Rf)
			{
				return #Rf.SqlGeometry.STContains(this.#a).Value;
			}

			// Token: 0x040015CA RID: 5578
			public SqlGeometry #a;
		}

		// Token: 0x02000609 RID: 1545
		[CompilerGenerated]
		private sealed class #wbc
		{
			// Token: 0x060034B6 RID: 13494 RVA: 0x0002E4A9 File Offset: 0x0002C6A9
			internal bool #vbc(StructurePoint.CoreAssets.Infrastructure.Data.Point #Rf)
			{
				return this.#a.Contains(#Rf);
			}

			// Token: 0x040015CB RID: 5579
			public List<StructurePoint.CoreAssets.Infrastructure.Data.Point> #a;
		}

		// Token: 0x0200060A RID: 1546
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x060034B8 RID: 13496 RVA: 0x0002E4C3 File Offset: 0x0002C6C3
			internal PolygonData #xbc(PolygonData #Rf)
			{
				return #Rf.#mwc(this.#a);
			}

			// Token: 0x040015CC RID: 5580
			public StructurePoint.CoreAssets.Infrastructure.Data.Point #a;
		}
	}
}
