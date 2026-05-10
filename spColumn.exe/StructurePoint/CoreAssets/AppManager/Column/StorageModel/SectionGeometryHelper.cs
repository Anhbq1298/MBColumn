using System;
using System.Collections.Generic;
using System.Linq;
using #P6e;
using #xKe;
using devDept.Geometry;
using NetTopologySuite.Geometries;
using NetTopologySuite.Operation.Union;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02001118 RID: 4376
	public static class SectionGeometryHelper
	{
		// Token: 0x0600942A RID: 37930 RVA: 0x00076649 File Offset: 0x00074849
		public static bool #Pai(this SectionType #C)
		{
			return #C == SectionType.Irregular || #C == SectionType.IrregularTemplate;
		}

		// Token: 0x0600942B RID: 37931 RVA: 0x000765AB File Offset: 0x000747AB
		public static bool #Qai(this SectionType #C)
		{
			return #C == SectionType.Rectangle || #C == SectionType.Circle;
		}

		// Token: 0x0600942C RID: 37932 RVA: 0x001F9C28 File Offset: 0x001F7E28
		public static devDept.Geometry.Point3D #gxc(IList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point> #BP)
		{
			if (#BP == null || #BP.Count < 3)
			{
				return null;
			}
			if (#BP[0] != #BP[#BP.Count - 1])
			{
				#BP = #BP.ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>();
				#BP.Add(#BP[0]);
			}
			NetTopologySuite.Geometries.Point centroid = new Polygon(new LinearRing(#BP.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, Coordinate>(SectionGeometryHelper.<>c.<>9.#Bbf)).ToArray<Coordinate>())).Centroid;
			if (!(centroid != null) || centroid.IsEmpty)
			{
				return null;
			}
			return new devDept.Geometry.Point3D(centroid.X, centroid.Y);
		}

		// Token: 0x0600942D RID: 37933 RVA: 0x001F9CD0 File Offset: 0x001F7ED0
		public static devDept.Geometry.Point3D #gxc(ColumnStorageModel #Od)
		{
			if (#Od.Options.SectionType != SectionType.Irregular && #Od.Options.SectionType != SectionType.IrregularTemplate)
			{
				return null;
			}
			List<SectionPolygon> #BAb = #Od.Polygons.Where(new Func<SectionPolygon, bool>(SectionGeometryHelper.<>c.<>9.#Qbi)).ToList<SectionPolygon>();
			List<SectionPolygon> #CAb = #Od.Polygons.Where(new Func<SectionPolygon, bool>(SectionGeometryHelper.<>c.<>9.#Rbi)).ToList<SectionPolygon>();
			if (!new IrregularSectionValidator(#Od.CreateContext()).Validate(#Od).IsValid)
			{
				return null;
			}
			return SectionGeometryHelper.#gxc(#BAb, #CAb);
		}

		// Token: 0x0600942E RID: 37934 RVA: 0x001F9D7C File Offset: 0x001F7F7C
		public static devDept.Geometry.Point3D #gxc(List<SectionPolygon> #BAb, List<SectionPolygon> #CAb)
		{
			List<Geometry> list = #BAb.Select(new Func<SectionPolygon, Geometry>(SectionGeometryHelper.<>c.<>9.#Sbi)).ToList<Geometry>();
			List<Geometry> list2 = #CAb.Select(new Func<SectionPolygon, Geometry>(SectionGeometryHelper.<>c.<>9.#Tbi)).ToList<Geometry>();
			Geometry geometry = null;
			Geometry geometry2 = null;
			if (list.Any<Geometry>())
			{
				geometry = new UnaryUnionOp(list).Union();
			}
			if (list2.Any<Geometry>())
			{
				geometry2 = new UnaryUnionOp(list2).Union();
			}
			NetTopologySuite.Geometries.Point point = null;
			if (geometry != null && geometry2 != null && !geometry.IsEmpty && !geometry2.IsEmpty)
			{
				Geometry geometry3 = geometry.Difference(geometry2);
				point = ((geometry3 != null && !geometry3.IsEmpty) ? geometry3.Centroid : null);
			}
			else if (geometry != null && !geometry.IsEmpty)
			{
				point = geometry.Centroid;
			}
			else if (geometry2 != null && !geometry2.IsEmpty)
			{
				point = geometry2.Centroid;
			}
			if (point != null && !point.IsEmpty)
			{
				return new devDept.Geometry.Point3D(point.X, point.Y);
			}
			return null;
		}

		// Token: 0x0600942F RID: 37935 RVA: 0x001F9EB8 File Offset: 0x001F80B8
		public static void #BT(ColumnStorageModel #X, float #R1, float #S1, out List<devDept.Geometry.Point3D> #AT, out List<SectionPolygon> #yP, bool #2pe = false)
		{
			#AT = new List<devDept.Geometry.Point3D>();
			#yP = new List<SectionPolygon>();
			double num;
			double #Tc;
			double #ZW;
			double #0W;
			SectionGeometryHelper.#qP(#X, out num, out #Tc, out #ZW, out #0W);
			switch (#X.Options.SectionType)
			{
			case SectionType.Undefined:
				break;
			case SectionType.Rectangle:
				if (#R1 > 0f && #S1 > 0f)
				{
					SectionGeometryHelper.#XW(#AT, (double)#R1, (double)#S1, num, #Tc, #ZW, #0W);
					#yP.Add(new SectionPolygon
					{
						Application = PolygonApplication.Solid,
						Points = new List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>
						{
							new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(-#R1 / 2f, -#S1 / 2f),
							new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(#R1 / 2f, -#S1 / 2f),
							new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(#R1 / 2f, #S1 / 2f),
							new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(-#R1 / 2f, #S1 / 2f)
						}
					});
					if (#2pe)
					{
						#yP.Last<SectionPolygon>().Points.Add(#yP.Last<SectionPolygon>().Points.First<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>());
						return;
					}
				}
				break;
			case SectionType.Circle:
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point #wob = new StructurePoint.CoreAssets.Infrastructure.Data.Point(0.0, 0.0);
				float num2 = #R1 / 2f;
				if (#R1 > 0f)
				{
					int num3 = #4ai.#3ai(#X.Options.Unit, (double)num2, 40);
					if (#X.Options.ActiveReinforcement == ReinforcementType.AllEqual)
					{
						#AT = EyeshotHelper.ConstructRegularPolygon(new devDept.Geometry.Point3D(#wob.X, #wob.Y), (double)num2 - num, Math.Max(num3, 80), 0.0, true);
					}
					List<SectionPolygon> list = #yP;
					SectionPolygon sectionPolygon = new SectionPolygon();
					sectionPolygon.Application = PolygonApplication.Solid;
					sectionPolygon.Points = GeometryHelper.#1nc(#wob, (double)num2, num3, 0.0, #2pe).Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>(SectionGeometryHelper.<>c.<>9.#Ubi)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>();
					list.Add(sectionPolygon);
					return;
				}
				break;
			}
			case SectionType.Irregular:
			case SectionType.IrregularTemplate:
				#yP = #X.Polygons;
				return;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06009430 RID: 37936 RVA: 0x001FA0EC File Offset: 0x001F82EC
		public static void #2W(ColumnStorageModel #X, bool #Rai = true)
		{
			if (#X.Options.SectionType != SectionType.Rectangle && #X.Options.SectionType != SectionType.Circle)
			{
				return;
			}
			DesignEngine designEngine = new DesignEngine(#X, new #O6e());
			designEngine.#tOe();
			float #R = designEngine.OutputModel.InvestigationDimensions[0];
			float #S = designEngine.OutputModel.InvestigationDimensions[1];
			#X.Polygons.Clear();
			List<devDept.Geometry.Point3D> list;
			List<SectionPolygon> collection;
			SectionGeometryHelper.#BT(#X, #R, #S, out list, out collection, true);
			#X.Polygons.AddRange(collection);
			#X.ReAssignShapeId();
			if (#Rai)
			{
				#X.ReinforcementBars.Clear();
				#X.ReinforcementBars.AddRange(designEngine.OutputModel.ReinforcementBars.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>(SectionGeometryHelper.<>c.<>9.#Vbi)));
			}
		}

		// Token: 0x06009431 RID: 37937 RVA: 0x001FA1B8 File Offset: 0x001F83B8
		private static void #qP(ColumnStorageModel #X, out double #3pe, out double #4pe, out double #5pe, out double #6pe)
		{
			#3pe = (#4pe = (#5pe = (#6pe = 0.0)));
			ProblemType problemType = #X.Options.ProblemType;
			if (problemType != ProblemType.Investigation)
			{
				if (problemType != ProblemType.Design)
				{
					throw new ArgumentOutOfRangeException();
				}
				switch (#X.Options.ActiveReinforcement)
				{
				case ReinforcementType.Undefined:
				case ReinforcementType.Irregular:
					break;
				case ReinforcementType.AllEqual:
				case ReinforcementType.EqualSpace:
					#3pe = (#4pe = (#5pe = (#6pe = (double)#X.DesignReinforcement.AllEqual.ClearCover)));
					return;
				case ReinforcementType.Different:
					#3pe = (double)#X.DesignReinforcement.Different.LeftRightClearCover;
					#4pe = (double)#X.DesignReinforcement.Different.LeftRightClearCover;
					#5pe = (double)#X.DesignReinforcement.Different.TopBottomClearCover;
					#6pe = (double)#X.DesignReinforcement.Different.TopBottomClearCover;
					return;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			else
			{
				switch (#X.Options.ActiveReinforcement)
				{
				case ReinforcementType.Undefined:
				case ReinforcementType.Irregular:
					break;
				case ReinforcementType.AllEqual:
				case ReinforcementType.EqualSpace:
					#3pe = (#4pe = (#5pe = (#6pe = (double)#X.InvestigationReinforcement.AllEqual.ClearCover)));
					return;
				case ReinforcementType.Different:
					#3pe = (double)#X.InvestigationReinforcement.Different.LeftClearCover;
					#4pe = (double)#X.InvestigationReinforcement.Different.RightClearCover;
					#5pe = (double)#X.InvestigationReinforcement.Different.TopClearCover;
					#6pe = (double)#X.InvestigationReinforcement.Different.BottomClearCover;
					return;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		// Token: 0x06009432 RID: 37938 RVA: 0x001FA348 File Offset: 0x001F8548
		private static void #XW(IList<devDept.Geometry.Point3D> #En, double #6Q, double #YW, double #Sc, double #Tc, double #ZW, double #0W)
		{
			#En.#pR(new devDept.Geometry.Point3D[]
			{
				new devDept.Geometry.Point3D(-#6Q / 2.0 + #Sc, -#YW / 2.0 + #0W),
				new devDept.Geometry.Point3D(#6Q / 2.0 - #Tc, -#YW / 2.0 + #0W),
				new devDept.Geometry.Point3D(#6Q / 2.0 - #Tc, #YW / 2.0 - #ZW),
				new devDept.Geometry.Point3D(-#6Q / 2.0 + #Sc, #YW / 2.0 - #ZW),
				new devDept.Geometry.Point3D(-#6Q / 2.0 + #Sc, -#YW / 2.0 + #0W)
			});
		}
	}
}
