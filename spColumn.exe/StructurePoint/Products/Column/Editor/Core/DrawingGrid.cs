using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using #3Qb;
using #7hc;
using #eU;
using #f7;
using #RJb;
using devDept.Eyeshot;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Core
{
	// Token: 0x02000668 RID: 1640
	internal sealed class DrawingGrid : Grid
	{
		// Token: 0x06003723 RID: 14115 RVA: 0x0010C370 File Offset: 0x0010A570
		public DrawingGrid(ISettingsManager settingsManager, #oW projectContext)
		{
			if (settingsManager == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381742));
			}
			this.#g = settingsManager;
			this.#h = projectContext;
			this.#e = new EntityGraphicsData();
			this.#f = new EntityGraphicsData();
			base.AlwaysBehind = true;
			base.Step = double.MaxValue;
			base.AutoSize = false;
			base.AutoStep = false;
			base.MajorLinesEvery = 0;
			base.MaxNumberOfLines = 0;
		}

		// Token: 0x17001121 RID: 4385
		// (get) Token: 0x06003724 RID: 14116 RVA: 0x000300A9 File Offset: 0x0002E2A9
		private ColumnModel Model
		{
			get
			{
				return this.#h.Model;
			}
		}

		// Token: 0x06003725 RID: 14117 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #9Jb()
		{
		}

		// Token: 0x06003726 RID: 14118 RVA: 0x0010C3F0 File Offset: 0x0010A5F0
		protected void #6bb(RenderContextBase #ib, Viewport #fe)
		{
			if (this.#h.Model.Options.SectionType != SectionType.Irregular)
			{
				return;
			}
			#GKb #GKb = this.#sKb();
			this.#g.RuntimeSettings.DrawingGridParams = #GKb;
			if (!#GKb.Enabled || !this.#g.RuntimeSettings.DrawDrawingGrid)
			{
				return;
			}
			this.#dKb(#ib, #GKb);
			#ib.PushShader();
			#ib.SetShader(shaderType.NoLights, null, true);
			#ib.PushModelView();
			Color color = #GKb.LineColor;
			Color color2 = #GKb.MainLineColor;
			Color color3 = Color.FromArgb((int)color.R, (int)color.G, (int)color.B);
			Color color4 = Color.FromArgb((int)color2.R, (int)color2.G, (int)color2.B);
			#ib.SetLineSize(#GKb.LineWidth, true, false);
			#ib.SetColorWireframe(color3, false);
			#ib.Draw(this.#e, primitiveType.Undefined);
			#ib.SetColorWireframe(color4, false);
			#ib.Draw(this.#f, primitiveType.Undefined);
			this.#fKb(#ib, #GKb);
			#ib.PopModelView();
			#ib.PopShader();
		}

		// Token: 0x06003727 RID: 14119 RVA: 0x0010C4FC File Offset: 0x0010A6FC
		public static double #aKb(ColumnModel #Od, double #bKb)
		{
			if (#Od == null)
			{
				return #bKb;
			}
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = #Od.Shapes.SelectMany(new Func<ShapeModel, IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point>>(DrawingGrid.<>c.<>9.#fcc)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			if (!list.Any<StructurePoint.CoreAssets.Infrastructure.Data.Point>())
			{
				return #bKb * DrawingGrid.#cKb(#Od);
			}
			BoundingBoxData boundingBoxData = new BoundingBoxData(list);
			double[] source = new double[]
			{
				boundingBoxData.MinX,
				boundingBoxData.MaxX,
				boundingBoxData.MinY,
				boundingBoxData.MaxY
			};
			double num = source.Select(new Func<double, double>(DrawingGrid.<>c.<>9.#gcc)).Max();
			double val = #bKb * DrawingGrid.#cKb(#Od);
			double val2 = num * 2.0 * 1.25;
			return Math.Max(val, val2);
		}

		// Token: 0x06003728 RID: 14120 RVA: 0x0010C5D8 File Offset: 0x0010A7D8
		private static double #cKb(ColumnModel #Od)
		{
			if (#Od == null)
			{
				return 1.0;
			}
			LengthConverter lengthConverter = new LengthConverter();
			LengthUnit #B = #Od.Units.Section.Width.UnitType;
			return lengthConverter.#Pb(LengthUnit.Inch, #B, 1.0);
		}

		// Token: 0x06003729 RID: 14121 RVA: 0x0010C620 File Offset: 0x0010A820
		private void #dKb(RenderContextBase #ib, #GKb #eKb)
		{
			if (!this.#tKb(#eKb, this.#i))
			{
				return;
			}
			ValueTuple<List<float>, List<float>> valueTuple = this.#hKb(#eKb);
			List<float> item = valueTuple.Item1;
			List<float> item2 = valueTuple.Item2;
			ValueTuple<List<float>, List<float>> valueTuple2 = this.#iKb(#eKb);
			List<float> item3 = valueTuple2.Item1;
			List<float> item4 = valueTuple2.Item2;
			float[] myParams = item.Concat(item3).ToArray<float>();
			float[] myParams2 = item2.Concat(item4).ToArray<float>();
			#ib.Compile(this.#e, new DrawEntityCallBack(this.#gKb), myParams);
			#ib.Compile(this.#f, new DrawEntityCallBack(this.#gKb), myParams2);
			this.#i = #eKb;
			this.#qKb(#eKb);
		}

		// Token: 0x0600372A RID: 14122 RVA: 0x0010C6C4 File Offset: 0x0010A8C4
		private void #fKb(RenderContextBase #ib, #GKb #eKb)
		{
			ValueTuple<Point2D, Point2D> valueTuple = this.#rKb(#eKb);
			Point2D item = valueTuple.Item1;
			Point2D item2 = valueTuple.Item2;
			#ib.DrawLine(item, new Point2D(item2.X, item.Y));
			#ib.DrawLine(new Point2D(item.X, item2.Y), item2);
			#ib.DrawLine(item, new Point2D(item.X, item2.X));
			#ib.DrawLine(new Point2D(item2.X, item.Y), item2);
		}

		// Token: 0x0600372B RID: 14123 RVA: 0x0010C748 File Offset: 0x0010A948
		private void #gKb(RenderContextBase #7Ib, object #Sb)
		{
			float[] array = (float[])#Sb;
			if (array.Length != 0)
			{
				#7Ib.DrawLines(array);
			}
		}

		// Token: 0x0600372C RID: 14124 RVA: 0x0010C768 File Offset: 0x0010A968
		private ValueTuple<List<float>, List<float>> #hKb(#GKb #eKb)
		{
			List<float> list = new List<float>();
			List<float> list2 = new List<float>();
			ValueTuple<List<float>, List<float>> valueTuple = this.#jKb(#eKb, true, true);
			List<float> item = valueTuple.Item1;
			List<float> item2 = valueTuple.Item2;
			ValueTuple<List<float>, List<float>> valueTuple2 = this.#jKb(#eKb, false, true);
			List<float> item3 = valueTuple2.Item1;
			List<float> item4 = valueTuple2.Item2;
			list.AddRange(item);
			list.AddRange(item3);
			list2.AddRange(item2);
			list2.AddRange(item4);
			return new ValueTuple<List<float>, List<float>>(list, list2);
		}

		// Token: 0x0600372D RID: 14125 RVA: 0x0010C7D4 File Offset: 0x0010A9D4
		private ValueTuple<List<float>, List<float>> #iKb(#GKb #eKb)
		{
			List<float> list = new List<float>();
			List<float> list2 = new List<float>();
			ValueTuple<List<float>, List<float>> valueTuple = this.#jKb(#eKb, true, false);
			List<float> item = valueTuple.Item1;
			List<float> item2 = valueTuple.Item2;
			ValueTuple<List<float>, List<float>> valueTuple2 = this.#jKb(#eKb, false, false);
			List<float> item3 = valueTuple2.Item1;
			List<float> item4 = valueTuple2.Item2;
			list.AddRange(item);
			list.AddRange(item3);
			list2.AddRange(item2);
			list2.AddRange(item4);
			return new ValueTuple<List<float>, List<float>>(list, list2);
		}

		// Token: 0x0600372E RID: 14126 RVA: 0x0010C840 File Offset: 0x0010AA40
		private ValueTuple<List<float>, List<float>> #jKb(#GKb #eKb, bool #kKb, bool #lKb)
		{
			List<float> list = new List<float>();
			List<float> list2 = new List<float>();
			ValueTuple<Point2D, Point2D> valueTuple = this.#rKb(#eKb);
			Point2D item = valueTuple.Item1;
			Point2D item2 = valueTuple.Item2;
			double num = #lKb ? #eKb.SpacingY : #eKb.SpacingX;
			int num2 = (int)(#eKb.Size / num / 2.0);
			double #pKb = #kKb ? -1.0 : 1.0;
			for (int i = 0; i <= num2; i++)
			{
				List<float> list3 = (i % #eKb.MainLineEvery == 0) ? list2 : list;
				float[] collection = this.#mKb(item, item2, #pKb, num, i, #lKb);
				list3.AddRange(collection);
				if (i > 5000)
				{
					break;
				}
			}
			return new ValueTuple<List<float>, List<float>>(list, list2);
		}

		// Token: 0x0600372F RID: 14127 RVA: 0x0010C904 File Offset: 0x0010AB04
		private float[] #mKb(Point2D #nKb, Point2D #oKb, double #pKb, double #NP, int #Ttb, bool #lKb)
		{
			float num = #lKb ? ((float)#nKb.X) : ((float)(#pKb * (double)#Ttb * #NP));
			float num2 = #lKb ? ((float)(#pKb * (double)#Ttb * #NP)) : ((float)#nKb.Y);
			float num3 = #lKb ? ((float)#oKb.X) : num;
			float num4 = #lKb ? num2 : ((float)#oKb.Y);
			float[] array = new float[6];
			array[0] = num;
			array[1] = num2;
			array[3] = num3;
			array[4] = num4;
			return array;
		}

		// Token: 0x06003730 RID: 14128 RVA: 0x0010C974 File Offset: 0x0010AB74
		private void #qKb(#GKb #eKb)
		{
			ValueTuple<Point2D, Point2D> valueTuple = this.#rKb(#eKb);
			Point2D item = valueTuple.Item1;
			Point2D item2 = valueTuple.Item2;
			base.Min = item;
			base.Max = item2;
		}

		// Token: 0x06003731 RID: 14129 RVA: 0x0010C9A4 File Offset: 0x0010ABA4
		private ValueTuple<Point2D, Point2D> #rKb(#GKb #eKb)
		{
			double num = #eKb.Size / 2.0;
			Point2D item = new Point2D(-num, -num);
			Point2D item2 = new Point2D(num, num);
			return new ValueTuple<Point2D, Point2D>(item, item2);
		}

		// Token: 0x06003732 RID: 14130 RVA: 0x0010C9DC File Offset: 0x0010ABDC
		private #GKb #sKb()
		{
			#GKb #GKb = new #GKb();
			#j7 #j = this.#g.DrawingGrid;
			#qRb #qRb = this.#g.CurrentColorSettings;
			#GKb.Enabled = #j.GridEnabled;
			#GKb.SpacingX = #j.SpacingX;
			#GKb.SpacingY = #j.SpacingY;
			#GKb.MainLineColor = #qRb.MainGridLineColor.ToDrawingColor();
			#GKb.LineColor = #qRb.GridLineColor.ToDrawingColor();
			#GKb.Size = DrawingGrid.#aKb(this.Model, #GKb.DefaultSize);
			int num = (int)(#GKb.Size / 2.0 / #GKb.SpacingX);
			if (num > 5000)
			{
				#GKb.Size -= (double)(num - 5000) * #GKb.SpacingX * 2.0;
			}
			double num2 = (double)((int)#GKb.Size) / 2.0 / #GKb.SpacingY;
			if (num2 > 5000.0)
			{
				#GKb.Size -= (num2 - 5000.0) * #GKb.SpacingY * 2.0;
			}
			return #GKb;
		}

		// Token: 0x06003733 RID: 14131 RVA: 0x0010CB00 File Offset: 0x0010AD00
		private bool #tKb(#GKb #uKb, #GKb #vKb)
		{
			return #uKb == null || #vKb == null || #uKb.Enabled != #vKb.Enabled || #uKb.SpacingX != #vKb.SpacingX || #uKb.SpacingY != #vKb.SpacingY || #uKb.Size != #vKb.Size;
		}

		// Token: 0x040016FB RID: 5883
		private const double #a = 0.25;

		// Token: 0x040016FC RID: 5884
		private const double #b = 1.0;

		// Token: 0x040016FD RID: 5885
		private const LengthUnit #c = LengthUnit.Inch;

		// Token: 0x040016FE RID: 5886
		private const int #d = 5000;

		// Token: 0x040016FF RID: 5887
		private readonly EntityGraphicsData #e;

		// Token: 0x04001700 RID: 5888
		private readonly EntityGraphicsData #f;

		// Token: 0x04001701 RID: 5889
		private readonly ISettingsManager #g;

		// Token: 0x04001702 RID: 5890
		private readonly #oW #h;

		// Token: 0x04001703 RID: 5891
		private #GKb #i;
	}
}
