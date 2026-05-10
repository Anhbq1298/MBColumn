using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using #3Rd;
using #7hc;
using #o1d;
using #oFe;
using #wqe;
using #Wse;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Data;
using Svg;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.GraphicalReport
{
	// Token: 0x0200117A RID: 4474
	public sealed class SectionPreviewGenerator
	{
		// Token: 0x060097B5 RID: 38837 RVA: 0x001FECDC File Offset: 0x001FCEDC
		public SectionPreviewGenerator(double desiredWidth, double desiredHeight, #3se colors, bool drawLabels = false)
		{
			this.#c = drawLabels;
			this.#Kue(colors);
			this.#d = new StructurePoint.CoreAssets.Infrastructure.Data.Size(desiredWidth, desiredHeight);
		}

		// Token: 0x060097B6 RID: 38838 RVA: 0x001FEDA4 File Offset: 0x001FCFA4
		public SectionPreviewGenerator(double desiredWidth, double desiredHeight, #3se colors, int strokeWidth, bool drawLabels = false)
		{
			this.#d = new StructurePoint.CoreAssets.Infrastructure.Data.Size(desiredWidth, desiredHeight);
			this.#Kue(colors);
			this.#m = (float)strokeWidth;
			this.#c = drawLabels;
		}

		// Token: 0x17002C11 RID: 11281
		// (get) Token: 0x060097B7 RID: 38839 RVA: 0x0007897C File Offset: 0x00076B7C
		private StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point CoordinateSystemOrigin
		{
			get
			{
				return this.#o[0];
			}
		}

		// Token: 0x17002C12 RID: 11282
		// (get) Token: 0x060097B8 RID: 38840 RVA: 0x0007898A File Offset: 0x00076B8A
		// (set) Token: 0x060097B9 RID: 38841 RVA: 0x00078992 File Offset: 0x00076B92
		public bool MagnifyCoordinateSystemSign { get; set; }

		// Token: 0x060097BA RID: 38842 RVA: 0x001FEE74 File Offset: 0x001FD074
		public static BoundingBoxData #Gue(#lte #Od, bool #Hue = false)
		{
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			SectionPreviewGenerator sectionPreviewGenerator = new SectionPreviewGenerator(0.0, 0.0, #Od.ColorSettings, false);
			sectionPreviewGenerator.#yl();
			sectionPreviewGenerator.#Uue(#Od);
			return SectionPreviewGenerator.#Gue(#Od, #Hue, false);
		}

		// Token: 0x060097BB RID: 38843 RVA: 0x001FEEC8 File Offset: 0x001FD0C8
		public #sTd #fp(#lte #Od)
		{
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.#yl();
			BoundingBoxData boundingBoxData = SectionPreviewGenerator.#Gue(#Od, true, true);
			if (boundingBoxData == null)
			{
				return null;
			}
			this.#Uue(#Od);
			Rect rect = boundingBoxData.Rect;
			float num = (float)this.#due(this.#d, rect.Size);
			if (#Od.Input.Options.SectionType != SectionType.Circle)
			{
				boundingBoxData = this.#Zue(#Od, num);
				if (boundingBoxData == null)
				{
					return null;
				}
				if (boundingBoxData.BottomLeft.X <= 0.0)
				{
					this.#mwc((float)Math.Abs(boundingBoxData.BottomLeft.X), 0f);
				}
				if (boundingBoxData.BottomLeft.Y <= 0.0)
				{
					this.#mwc(0f, (float)Math.Abs(boundingBoxData.BottomLeft.Y));
				}
			}
			else
			{
				if (boundingBoxData.TopLeft.X <= 0.0)
				{
					this.#mwc((float)Math.Abs(boundingBoxData.TopLeft.X), 0f);
				}
				if (boundingBoxData.TopLeft.Y >= 0.0)
				{
					this.#mwc(0f, (float)Math.Abs(boundingBoxData.TopLeft.Y));
				}
			}
			this.#pwc(num);
			this.#mwc(5f, 5f);
			StructurePoint.CoreAssets.Infrastructure.Data.Size size = this.#Lue(#Od);
			BoundingBoxData boundingBoxData2 = this.#Zue(#Od, num);
			if (boundingBoxData2 == null)
			{
				return null;
			}
			float num2 = (float)Math.Ceiling(boundingBoxData2.Width + size.Width) + 10f;
			float num3 = (float)Math.Ceiling(boundingBoxData2.Height + size.Height) + 10f;
			SvgDocument svgDocument = new SvgDocument();
			svgDocument.Width = this.#wae(num2);
			svgDocument.Height = this.#wae(num3);
			svgDocument.ViewBox = new SvgViewBox(0f, 0f, num2, num3);
			SvgGroup svgGroup = new SvgGroup();
			svgDocument.Children.Add(svgGroup);
			this.#6bb(#Od, svgGroup, num);
			return new #sTd(svgDocument, (double)num2, (double)num3);
		}

		// Token: 0x060097BC RID: 38844 RVA: 0x001FF108 File Offset: 0x001FD308
		private static BoundingBoxData #Iue(List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point> #BP, IEnumerable<CircleData> #mAc)
		{
			foreach (CircleData circleData in #mAc)
			{
				double num = circleData.Radius;
				#BP.Add(new StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point((float)(circleData.Center.X + num), (float)(circleData.Center.Y - num)));
				#BP.Add(new StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point((float)(circleData.Center.X + num), (float)(circleData.Center.Y + num)));
				#BP.Add(new StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point((float)(circleData.Center.X - num), (float)(circleData.Center.Y - num)));
				#BP.Add(new StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point((float)(circleData.Center.X - num), (float)(circleData.Center.Y + num)));
			}
			if (#BP.Count < 2)
			{
				return null;
			}
			return new BoundingBoxData(#BP.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point, StructurePoint.CoreAssets.Infrastructure.Data.Point>(SectionPreviewGenerator.<>c.<>9.#Jbf)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>());
		}

		// Token: 0x060097BD RID: 38845 RVA: 0x001FF244 File Offset: 0x001FD444
		private static BoundingBoxData #Gue(#lte #Od, bool #Hue, bool #Jue)
		{
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point> list = new List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(#Od.BasicProperties.Polygons.Sum(new Func<SectionPolygon, int>(SectionPreviewGenerator.<>c.<>9.#Kbf)) + #Od.BasicProperties.Bars.Count * 4);
			if (#Od.Input.Options.SectionType == SectionType.IrregularTemplate || #Od.Input.Options.SectionType == SectionType.Irregular || #Od.Input.Options.SectionType == SectionType.Rectangle)
			{
				list.AddRange(#Od.BasicProperties.Polygons.SelectMany(new Func<SectionPolygon, IEnumerable<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>>(SectionPreviewGenerator.<>c.<>9.#Lbf)));
			}
			List<CircleData> list2 = new List<CircleData>();
			if (#Od.Input.Options.SectionType == SectionType.Circle)
			{
				double radius = (double)#Od.BasicProperties.DimensionA / 2.0;
				list2.Add(new CircleData(new StructurePoint.CoreAssets.Infrastructure.Data.Point(0.0, 0.0), radius));
			}
			List<CircleData> list3;
			if (!#Hue)
			{
				list3 = list2;
			}
			else
			{
				list3 = list2.Union(#Od.BasicProperties.Bars.Where(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, bool>(SectionPreviewGenerator.<>c.<>9.#Nbf)).Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, CircleData>(SectionPreviewGenerator.<>c.<>9.#Obf))).ToList<CircleData>();
			}
			list2 = list3;
			if (#Jue)
			{
				list.Add(new StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point(0f, 0f));
			}
			return SectionPreviewGenerator.#Iue(list, list2);
		}

		// Token: 0x060097BE RID: 38846 RVA: 0x001FF3E0 File Offset: 0x001FD5E0
		private void #Kue(#3se #pRb)
		{
			this.#i = new SvgColourServer(#pRb.SectionColor.ToDrawingColor());
			this.#h = new SvgColourServer(#pRb.OpeningColor.ToDrawingColor());
			this.#j = new SvgColourServer(#pRb.BarColor.ToDrawingColor());
			this.#k = new SvgColourServer(#pRb.LeftRightBarColor.ToDrawingColor());
		}

		// Token: 0x060097BF RID: 38847 RVA: 0x001FF448 File Offset: 0x001FD648
		private StructurePoint.CoreAssets.Infrastructure.Data.Size #Lue(#lte #Od)
		{
			BoundingBoxData boundingBoxData = SectionPreviewGenerator.#Gue(#Od, true, false);
			float num = this.#Pue(this.#d);
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 6f;
			float num7 = 10f;
			float num8 = 0.3f;
			float num9 = num + num6;
			float num10 = num + num7;
			if (boundingBoxData.MinX >= 0.0)
			{
				num9 = num * num8;
			}
			if (boundingBoxData.MinY >= 0.0)
			{
				num10 = num * num8;
			}
			if (this.CoordinateSystemOrigin.X < num9)
			{
				num2 = (num4 = num9 - this.CoordinateSystemOrigin.X);
			}
			else if (boundingBoxData.MaxX <= 0.0)
			{
				num2 += 0f;
				num4 += num + num6;
			}
			else if (boundingBoxData.MinX >= 0.0)
			{
				num2 += 0f;
				num4 += num + num6;
			}
			if (this.CoordinateSystemOrigin.Y < num10)
			{
				num3 = (num5 = num10 - this.CoordinateSystemOrigin.Y);
			}
			else if (boundingBoxData.MaxY <= 0.0)
			{
				num3 += 0f;
				num5 += num;
			}
			else if (boundingBoxData.MinY >= 0.0)
			{
				num3 += 0f;
				num5 += num;
			}
			this.#mwc(num2, num3);
			return new StructurePoint.CoreAssets.Infrastructure.Data.Size((double)num4, (double)num5);
		}

		// Token: 0x060097C0 RID: 38848 RVA: 0x001FF5C4 File Offset: 0x001FD7C4
		private void #6bb(#lte #Od, SvgGroup #Mue, float #Nue)
		{
			SectionPreviewGenerator.#yZb #yZb = new SectionPreviewGenerator.#yZb();
			#yZb.#a = this;
			#yZb.#b = #Mue;
			#yZb.#c = #Od;
			if (#yZb.#c.Input.Options.SectionType == SectionType.Circle)
			{
				double #HS = (double)(#yZb.#c.BasicProperties.DimensionA * #Nue) / 2.0;
				StructurePoint.CoreAssets.Infrastructure.Data.Point #wob = new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)this.CoordinateSystemOrigin.X, (double)this.CoordinateSystemOrigin.Y);
				this.#Rue(#yZb.#b, this.#i, #wob, #HS, new float?(this.#m));
			}
			else
			{
				this.#e.OrderBy(new Func<SectionPreviewGenerator.Figure, bool>(SectionPreviewGenerator.<>c.<>9.#Pbf)).#I1d(new Action<SectionPreviewGenerator.Figure>(#yZb.#Xbf));
			}
			if (this.#f.Any<CircleData>())
			{
				List<CircleData> list = this.#f;
				double num;
				if (!list.Any<CircleData>())
				{
					num = 0.0;
				}
				else
				{
					num = list.Min(new Func<CircleData, double>(SectionPreviewGenerator.<>c.<>9.#Qbf));
				}
				double num2 = num;
				double num3;
				if (!list.Any<CircleData>())
				{
					num3 = 0.0;
				}
				else
				{
					num3 = list.Max(new Func<CircleData, double>(SectionPreviewGenerator.<>c.<>9.#Rbf));
				}
				double num4 = num3;
				bool flag = list.Count > 1 && num2 != num4 && #Uqe.#Tqe(#yZb.#c.Input);
				foreach (CircleData circleData in this.#f)
				{
					SvgColourServer #BR = (flag && circleData.Center.Y > num2 && circleData.Center.Y < num4) ? this.#k : this.#j;
					this.#Rue(#yZb.#b, #BR, circleData.Center, circleData.Radius, null);
				}
			}
			this.#Que(#yZb.#b);
		}

		// Token: 0x060097C1 RID: 38849 RVA: 0x001FF810 File Offset: 0x001FDA10
		private void #nT(SvgGroup #Mue, string #hvb, float #9o, float #7W, int #Cvb = 8, SvgTextAnchor #Oue = SvgTextAnchor.Start)
		{
			#Mue.Children.Add(new SvgText(#hvb)
			{
				X = #1Ge.#ul(new SvgUnit[]
				{
					#9o
				}),
				Y = #1Ge.#ul(new SvgUnit[]
				{
					#7W
				}),
				Fill = this.#l,
				Color = this.#l,
				FontFamily = #Phc.#3hc(107356910),
				FontSize = (float)#Cvb,
				Stroke = new SvgColourServer(Color.Black),
				StrokeLineCap = SvgStrokeLineCap.Butt,
				StrokeLineJoin = SvgStrokeLineJoin.Miter,
				FillOpacity = 1f,
				StrokeOpacity = 1f,
				StrokeWidth = this.#n,
				TextAnchor = #Oue
			});
		}

		// Token: 0x060097C2 RID: 38850 RVA: 0x001FF8F0 File Offset: 0x001FDAF0
		private float #Pue(StructurePoint.CoreAssets.Infrastructure.Data.Size #3oc)
		{
			float num = this.MagnifyCoordinateSystemSign ? 0.09f : 0.05f;
			return (float)(#3oc.Width + #3oc.Height) / 2f * num;
		}

		// Token: 0x060097C3 RID: 38851 RVA: 0x001FF92C File Offset: 0x001FDB2C
		private void #Que(SvgGroup #Mue)
		{
			float num = this.#Pue(this.#d);
			StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point point = this.CoordinateSystemOrigin;
			double num2 = (double)num * 0.25;
			int #Cvb = this.MagnifyCoordinateSystemSign ? 40 : 8;
			float num3 = this.MagnifyCoordinateSystemSign ? 3f : 1f;
			SvgLine svgLine = new SvgLine
			{
				StartX = this.#wae(point.X),
				StartY = this.#wae((double)point.Y + num2),
				EndX = this.#wae(point.X),
				EndY = this.#wae((double)point.Y + num2 - (double)num),
				Color = this.#g,
				Stroke = this.#g,
				StrokeWidth = this.#n * num3
			};
			#Mue.Children.Add(svgLine);
			this.#nT(#Mue, #Phc.#3hc(107427359), svgLine.EndX - 2.5f, svgLine.EndY - 3f, #Cvb, SvgTextAnchor.Start);
			svgLine = new SvgLine
			{
				StartX = this.#wae((double)point.X - num2),
				StartY = this.#wae(point.Y),
				EndX = this.#wae((double)point.X - num2 + (double)num),
				EndY = this.#wae(point.Y),
				Color = this.#g,
				Stroke = this.#g,
				StrokeWidth = this.#n * num3
			};
			#Mue.Children.Add(svgLine);
			this.#nT(#Mue, #Phc.#3hc(107380695), svgLine.EndX + 2f, svgLine.EndY + 2f, #Cvb, SvgTextAnchor.Start);
		}

		// Token: 0x060097C4 RID: 38852 RVA: 0x001FFB40 File Offset: 0x001FDD40
		private void #Rue(SvgGroup #Sue, SvgColourServer #BR, StructurePoint.CoreAssets.Infrastructure.Data.Point #wob, double #HS, float? #Tue = null)
		{
			SvgEllipse svgEllipse = new SvgEllipse
			{
				CenterX = (float)#wob.X,
				CenterY = (float)#wob.Y,
				RadiusX = (float)#HS,
				RadiusY = (float)#HS,
				Fill = #BR
			};
			if (#Tue != null)
			{
				svgEllipse.Stroke = this.#g;
				svgEllipse.StrokeWidth = #Tue.Value;
			}
			#Sue.Children.Add(svgEllipse);
		}

		// Token: 0x060097C5 RID: 38853 RVA: 0x001FFBD0 File Offset: 0x001FDDD0
		private void #Uue(#lte #Wdb)
		{
			#Vse #Vse = #Wdb.BasicProperties;
			if (#Wdb.Input.Options.SectionType != SectionType.Circle)
			{
				foreach (SectionPolygon sectionPolygon in #Vse.Polygons)
				{
					this.#e.Add(new SectionPreviewGenerator.Figure(sectionPolygon.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(SectionPreviewGenerator.<>c.<>9.#Sbf)), sectionPolygon.Application == PolygonApplication.Opening, sectionPolygon.DisplayId));
				}
			}
			this.#f.AddRange(#Vse.Bars.Where(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, bool>(SectionPreviewGenerator.<>c.<>9.#Tbf)).Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, CircleData>(SectionPreviewGenerator.<>c.<>9.#Ubf)));
		}

		// Token: 0x060097C6 RID: 38854 RVA: 0x001FFCD8 File Offset: 0x001FDED8
		private void #pwc(float #jdd)
		{
			SectionPreviewGenerator.#CZb #CZb = new SectionPreviewGenerator.#CZb();
			#CZb.#a = #jdd;
			this.#e.ForEach(new Action<SectionPreviewGenerator.Figure>(#CZb.#Zyc));
			for (int i = 0; i < this.#f.Count; i++)
			{
				CircleData circleData = this.#f[i];
				this.#f[i] = new CircleData(new StructurePoint.CoreAssets.Infrastructure.Data.Point(circleData.Center.X * (double)#CZb.#a, circleData.Center.Y * (double)#CZb.#a), circleData.Radius * (double)#CZb.#a);
			}
			for (int j = 0; j < this.#o.Count; j++)
			{
				StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point point = this.#o[j];
				this.#o[j] = new StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point(point.X * #CZb.#a, point.Y * #CZb.#a);
			}
		}

		// Token: 0x060097C7 RID: 38855 RVA: 0x0007899B File Offset: 0x00076B9B
		private void #yl()
		{
			this.#e.Clear();
			this.#f.Clear();
			this.#o.Clear();
			this.#o.Add(new StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point(0f, 0f));
		}

		// Token: 0x060097C8 RID: 38856 RVA: 0x001FFDD4 File Offset: 0x001FDFD4
		private void #mwc(float #9o, float #7W)
		{
			SectionPreviewGenerator.#fWb #fWb = new SectionPreviewGenerator.#fWb();
			#fWb.#a = #9o;
			#fWb.#b = #7W;
			this.#e.ForEach(new Action<SectionPreviewGenerator.Figure>(#fWb.#Yyc));
			for (int i = 0; i < this.#f.Count; i++)
			{
				CircleData circleData = this.#f[i];
				this.#f[i] = new CircleData(new StructurePoint.CoreAssets.Infrastructure.Data.Point(circleData.Center.X + (double)#fWb.#a, circleData.Center.Y + (double)#fWb.#b), circleData.Radius);
			}
			for (int j = 0; j < this.#o.Count; j++)
			{
				StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point point = this.#o[j];
				this.#o[j] = new StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point(point.X + #fWb.#a, point.Y + #fWb.#b);
			}
		}

		// Token: 0x060097C9 RID: 38857 RVA: 0x001FFED0 File Offset: 0x001FE0D0
		private void #Vue(SvgGroup #Sue, SvgColourServer #BR, SectionPreviewGenerator.Figure #Wue, bool #Xue)
		{
			#Sue.Children.Add(new SvgPolygon
			{
				Points = this.#Yue(#Wue.Points).#ZGe(),
				Color = #BR,
				Fill = #BR,
				Stroke = this.#g,
				StrokeWidth = this.#wae(this.#m)
			});
			if (this.#c && #Xue)
			{
				devDept.Geometry.Point3D point3D = SectionGeometryHelper.#gxc(#Wue.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>(SectionPreviewGenerator.<>c.<>9.#Vbf)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>());
				if (point3D != null)
				{
					float #9o = (float)point3D.X;
					float num = (float)point3D.Y;
					if (#Wue.IsOpening)
					{
						num += 5f;
					}
					else
					{
						num -= 5f;
					}
					this.#nT(#Sue, #Wue.Label, #9o, num, 8, SvgTextAnchor.Middle);
				}
			}
		}

		// Token: 0x060097CA RID: 38858 RVA: 0x000789D8 File Offset: 0x00076BD8
		private float #wae(float #f)
		{
			return #1Ge.#wae(#f);
		}

		// Token: 0x060097CB RID: 38859 RVA: 0x000789E0 File Offset: 0x00076BE0
		private float #wae(double #f)
		{
			return #1Ge.#wae((float)#f);
		}

		// Token: 0x060097CC RID: 38860 RVA: 0x001FFFBC File Offset: 0x001FE1BC
		private SvgPointCollection #Yue(List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point> #BP)
		{
			SvgPointCollection svgPointCollection = new SvgPointCollection();
			for (int i = 0; i < #BP.Count - 1; i++)
			{
				StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point point = #BP[i];
				svgPointCollection.Add(this.#wae(point.X));
				svgPointCollection.Add(this.#wae(point.Y));
			}
			return svgPointCollection;
		}

		// Token: 0x060097CD RID: 38861 RVA: 0x000789E9 File Offset: 0x00076BE9
		private double #due(StructurePoint.CoreAssets.Infrastructure.Data.Size #eue, StructurePoint.CoreAssets.Infrastructure.Data.Size #fme)
		{
			return Math.Min(#eue.Width / #fme.Width, #eue.Height / #fme.Height);
		}

		// Token: 0x060097CE RID: 38862 RVA: 0x0020001C File Offset: 0x001FE21C
		private BoundingBoxData #Zue(#lte #Od, float #Nue)
		{
			List<CircleData> list = this.#f.ToList<CircleData>();
			if (#Od.Input.Options.SectionType == SectionType.Circle)
			{
				double radius = (double)#Od.BasicProperties.DimensionA / 2.0 * (double)#Nue;
				StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point point = this.CoordinateSystemOrigin;
				list.Add(new CircleData(new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)point.X, (double)point.Y), radius));
			}
			return SectionPreviewGenerator.#Iue(this.#e.SelectMany(new Func<SectionPreviewGenerator.Figure, IEnumerable<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>>(SectionPreviewGenerator.<>c.<>9.#Wbf)).Union(this.#o).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(), list);
		}

		// Token: 0x0400412D RID: 16685
		private const float #a = 5f;

		// Token: 0x0400412E RID: 16686
		private const int #b = 8;

		// Token: 0x0400412F RID: 16687
		private readonly bool #c;

		// Token: 0x04004130 RID: 16688
		private readonly StructurePoint.CoreAssets.Infrastructure.Data.Size #d;

		// Token: 0x04004131 RID: 16689
		private readonly List<SectionPreviewGenerator.Figure> #e = new List<SectionPreviewGenerator.Figure>();

		// Token: 0x04004132 RID: 16690
		private readonly List<CircleData> #f = new List<CircleData>();

		// Token: 0x04004133 RID: 16691
		private SvgColourServer #g = new SvgColourServer(Color.Black);

		// Token: 0x04004134 RID: 16692
		private SvgColourServer #h = new SvgColourServer(Color.White);

		// Token: 0x04004135 RID: 16693
		private SvgColourServer #i = new SvgColourServer(Color.LightGray);

		// Token: 0x04004136 RID: 16694
		private SvgColourServer #j = new SvgColourServer(Color.Black);

		// Token: 0x04004137 RID: 16695
		private SvgColourServer #k = new SvgColourServer(Color.Black);

		// Token: 0x04004138 RID: 16696
		private SvgColourServer #l = new SvgColourServer(Color.Black);

		// Token: 0x04004139 RID: 16697
		private readonly float #m = 1f;

		// Token: 0x0400413A RID: 16698
		private readonly float #n = 0.5f;

		// Token: 0x0400413B RID: 16699
		private readonly List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point> #o = new List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>();

		// Token: 0x0400413C RID: 16700
		[CompilerGenerated]
		private bool #p;

		// Token: 0x0200117B RID: 4475
		private sealed class Figure
		{
			// Token: 0x060097CF RID: 38863 RVA: 0x00078A0E File Offset: 0x00076C0E
			public Figure(IEnumerable<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point> points, bool isOpening, string label)
			{
				this.IsOpening = isOpening;
				this.Label = label;
				this.Points.AddRange(points);
			}

			// Token: 0x17002C13 RID: 11283
			// (get) Token: 0x060097D0 RID: 38864 RVA: 0x00078A3B File Offset: 0x00076C3B
			public bool IsOpening { get; }

			// Token: 0x17002C14 RID: 11284
			// (get) Token: 0x060097D1 RID: 38865 RVA: 0x00078A43 File Offset: 0x00076C43
			public string Label { get; }

			// Token: 0x17002C15 RID: 11285
			// (get) Token: 0x060097D2 RID: 38866 RVA: 0x00078A4B File Offset: 0x00076C4B
			public List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point> Points { get; } = new List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>();

			// Token: 0x060097D3 RID: 38867 RVA: 0x002000CC File Offset: 0x001FE2CC
			public void #mwc(float #9o, float #7W)
			{
				for (int i = 0; i < this.Points.Count; i++)
				{
					this.Points[i] = new StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point(this.Points[i].X + #9o, this.Points[i].Y + #7W);
				}
			}

			// Token: 0x060097D4 RID: 38868 RVA: 0x0020012C File Offset: 0x001FE32C
			public void #pwc(float #jdd)
			{
				for (int i = 0; i < this.Points.Count; i++)
				{
					this.Points[i] = new StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point(this.Points[i].X * #jdd, this.Points[i].Y * #jdd);
				}
			}

			// Token: 0x0400413D RID: 16701
			[CompilerGenerated]
			private readonly bool #a;

			// Token: 0x0400413E RID: 16702
			[CompilerGenerated]
			private readonly string #b;

			// Token: 0x0400413F RID: 16703
			[CompilerGenerated]
			private readonly List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point> #c;
		}

		// Token: 0x0200117D RID: 4477
		[CompilerGenerated]
		private sealed class #yZb
		{
			// Token: 0x060097E6 RID: 38886 RVA: 0x002001A8 File Offset: 0x001FE3A8
			internal void #Xbf(SectionPreviewGenerator.Figure #Wue)
			{
				this.#a.#Vue(this.#b, #Wue.IsOpening ? this.#a.#h : this.#a.#i, #Wue, this.#c.Input.Options.SectionType == SectionType.Irregular);
			}

			// Token: 0x0400414F RID: 16719
			public SectionPreviewGenerator #a;

			// Token: 0x04004150 RID: 16720
			public SvgGroup #b;

			// Token: 0x04004151 RID: 16721
			public #lte #c;
		}

		// Token: 0x0200117E RID: 4478
		[CompilerGenerated]
		private sealed class #CZb
		{
			// Token: 0x060097E8 RID: 38888 RVA: 0x00078B44 File Offset: 0x00076D44
			internal void #Zyc(SectionPreviewGenerator.Figure #FI)
			{
				#FI.#pwc(this.#a);
			}

			// Token: 0x04004152 RID: 16722
			public float #a;
		}

		// Token: 0x0200117F RID: 4479
		[CompilerGenerated]
		private sealed class #fWb
		{
			// Token: 0x060097EA RID: 38890 RVA: 0x00078B52 File Offset: 0x00076D52
			internal void #Yyc(SectionPreviewGenerator.Figure #FI)
			{
				#FI.#mwc(this.#a, this.#b);
			}

			// Token: 0x04004153 RID: 16723
			public float #a;

			// Token: 0x04004154 RID: 16724
			public float #b;
		}
	}
}
