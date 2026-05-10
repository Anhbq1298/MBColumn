using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using #NHe;
using #oFe;
using #rCe;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Svg;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Helpers
{
	// Token: 0x0200125B RID: 4699
	internal sealed class GridLinesCreator
	{
		// Token: 0x06009DC0 RID: 40384 RVA: 0x0007C363 File Offset: 0x0007A563
		public GridLinesCreator(#ZIe drawingStyle, #zDe data)
		{
			#X0d.#V0d(data, #Phc.#3hc(107376321), Component.ColumnReporter, #Phc.#3hc(107314646));
			this.#c = data;
			this.#d = drawingStyle;
		}

		// Token: 0x06009DC1 RID: 40385 RVA: 0x00217938 File Offset: 0x00215B38
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public IEnumerable<SvgLine> #1Ie(#0Ie #pNb, bool #FFe)
		{
			float num = this.#c.AxisIntervalX / (float)this.#d.GridLinesDivision;
			return this.#7Ie((float)#ZIe.#f - num, this.#c.DiagramBorderMinX, -num, #pNb, new Func<float, float, bool>(GridLinesCreator.<>c.<>9.#Rff), new Func<float, SvgLine>(this.#bJe), new Func<float, #0Ie, SvgLine>(this.#fJe), #FFe);
		}

		// Token: 0x06009DC2 RID: 40386 RVA: 0x002179B4 File Offset: 0x00215BB4
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public IEnumerable<SvgLine> #2Ie(#0Ie #pNb, bool #FFe)
		{
			float num = this.#c.AxisIntervalX / (float)this.#d.GridLinesDivision;
			return this.#7Ie((float)#ZIe.#f + num, this.#c.DiagramBorderMaxX, num, #pNb, new Func<float, float, bool>(GridLinesCreator.<>c.<>9.#Uff), new Func<float, SvgLine>(this.#bJe), new Func<float, #0Ie, SvgLine>(this.#fJe), #FFe);
		}

		// Token: 0x06009DC3 RID: 40387 RVA: 0x00217A30 File Offset: 0x00215C30
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public IEnumerable<SvgLine> #3Ie(#0Ie #pNb, bool #FFe)
		{
			float num = this.#c.AxisIntervalY / (float)this.#d.GridLinesDivision;
			return this.#7Ie((float)#ZIe.#g - num, this.#c.DiagramBorderMinY, -num, #pNb, new Func<float, float, bool>(GridLinesCreator.<>c.<>9.#Vff), new Func<float, SvgLine>(this.#dJe), new Func<float, #0Ie, SvgLine>(this.#hJe), #FFe);
		}

		// Token: 0x06009DC4 RID: 40388 RVA: 0x00217AAC File Offset: 0x00215CAC
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public IEnumerable<SvgLine> #4Ie(#0Ie #pNb, bool #FFe)
		{
			float num = this.#c.AxisIntervalY / (float)this.#d.GridLinesDivision;
			return this.#7Ie((float)#ZIe.#g + num, this.#c.DiagramBorderMaxY, num, #pNb, new Func<float, float, bool>(GridLinesCreator.<>c.<>9.#Wff), new Func<float, SvgLine>(this.#dJe), new Func<float, #0Ie, SvgLine>(this.#hJe), #FFe);
		}

		// Token: 0x06009DC5 RID: 40389 RVA: 0x00217B28 File Offset: 0x00215D28
		public SvgLine #5Ie()
		{
			return new SvgLine
			{
				StartX = (float)#ZIe.#f,
				StartY = #ZIe.#UIe(this.#c.DiagramBorderMinY, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				EndX = (float)#ZIe.#f,
				EndY = #ZIe.#UIe(this.#c.DiagramBorderMaxY, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				Stroke = this.#d.MainAxisStroke,
				StrokeWidth = this.#d.MainAxesThickness,
				Fill = this.#d.Fill,
				StrokeDashArray = this.#d.MainAxesDashArray,
				ID = #kJe.VerticalMainGridLineId
			}.#ZGe();
		}

		// Token: 0x06009DC6 RID: 40390 RVA: 0x00217C18 File Offset: 0x00215E18
		public SvgLine #6Ie()
		{
			return new SvgLine
			{
				StartX = this.#c.DiagramBorderMinX,
				StartY = #ZIe.#UIe((float)#ZIe.#g, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				EndX = this.#c.DiagramBorderMaxX,
				EndY = #ZIe.#UIe((float)#ZIe.#g, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				Stroke = this.#d.MainAxisStroke,
				StrokeWidth = this.#d.MainAxesThickness,
				Fill = this.#d.Fill,
				StrokeDashArray = this.#d.MainAxesDashArray,
				ID = #kJe.HorizontalMainGridLineId
			}.#ZGe();
		}

		// Token: 0x06009DC7 RID: 40391 RVA: 0x00217D08 File Offset: 0x00215F08
		private IEnumerable<SvgLine> #7Ie(float #Akb, float #Bkb, float #jEd, #0Ie #pNb, Func<float, float, bool> #8Ie, Func<float, SvgLine> #9Ie, Func<float, #0Ie, SvgLine> #aJe, bool #FFe)
		{
			List<SvgLine> list = new List<SvgLine>();
			int num = 1;
			float num2 = #Akb;
			while (#8Ie(num2, #Bkb))
			{
				if (num % this.#d.GridLinesDivision == 0 && #FFe)
				{
					list.Add(#9Ie(num2));
				}
				if (num % this.#d.GridLinesDivision == 0)
				{
					list.Add(#aJe(num2, #pNb));
				}
				num++;
				num2 += #jEd;
			}
			return list;
		}

		// Token: 0x06009DC8 RID: 40392 RVA: 0x00217D78 File Offset: 0x00215F78
		private SvgLine #bJe(float #cJe)
		{
			return new SvgLine
			{
				StartX = #cJe,
				StartY = #ZIe.#UIe(this.#c.DiagramBorderMinY, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				EndX = #cJe,
				EndY = #ZIe.#UIe(this.#c.DiagramBorderMaxY, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				Stroke = this.#d.GridLineStroke,
				StrokeWidth = this.#d.GridLineThickness,
				Fill = this.#d.GridLineStroke,
				FillOpacity = 0f,
				StrokeDashArray = this.#d.GridLineDashArray,
				StrokeDashOffset = #ZIe.#i
			}.#ZGe();
		}

		// Token: 0x06009DC9 RID: 40393 RVA: 0x00217E70 File Offset: 0x00216070
		private SvgLine #dJe(float #eJe)
		{
			return new SvgLine
			{
				StartX = this.#c.DiagramBorderMinX,
				StartY = #ZIe.#UIe(#eJe, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				EndX = this.#c.DiagramBorderMaxX,
				EndY = #ZIe.#UIe(#eJe, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				Stroke = this.#d.GridLineStroke,
				StrokeWidth = this.#d.GridLineThickness,
				Fill = this.#d.GridLineStroke,
				FillOpacity = 0f,
				StrokeDashArray = this.#d.GridLineDashArray,
				StrokeDashOffset = #ZIe.#i
			}.#ZGe();
		}

		// Token: 0x06009DCA RID: 40394 RVA: 0x00217F68 File Offset: 0x00216168
		private SvgLine #fJe(float #cJe, #0Ie #pNb)
		{
			return new SvgLine
			{
				ID = GridLinesCreator.#gJe(false),
				StartX = #cJe,
				StartY = #ZIe.#UIe(-this.#d.LabeledTickLength, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				EndX = #cJe,
				EndY = #ZIe.#UIe(this.#d.LabeledTickLength, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				Stroke = this.#d.MainAxisStroke,
				StrokeWidth = this.#d.TicksThickness,
				Fill = this.#d.GridLineStroke
			}.#ZGe();
		}

		// Token: 0x06009DCB RID: 40395 RVA: 0x00218040 File Offset: 0x00216240
		private static string #gJe(bool #xfb)
		{
			int num = GridLinesCreator.#b++;
			if (!#xfb)
			{
				return string.Format(#Phc.#3hc(107314561), num);
			}
			return string.Format(#Phc.#3hc(107314536), num);
		}

		// Token: 0x06009DCC RID: 40396 RVA: 0x0021808C File Offset: 0x0021628C
		private SvgLine #hJe(float #eJe, #0Ie #pNb)
		{
			float value = -this.#d.LabeledTickLength;
			float value2 = this.#d.LabeledTickLength;
			if (#pNb == #0Ie.#c)
			{
				value2 = 0f;
			}
			if (#pNb == #0Ie.#b)
			{
				value = 0f;
			}
			return new SvgLine
			{
				ID = GridLinesCreator.#gJe(true),
				StartX = value,
				StartY = #ZIe.#UIe(#eJe, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				EndX = value2,
				EndY = #ZIe.#UIe(#eJe, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY),
				Stroke = this.#d.MainAxisStroke,
				StrokeWidth = this.#d.TicksThickness,
				Fill = this.#d.GridLineStroke
			}.#ZGe();
		}

		// Token: 0x04004440 RID: 17472
		private const float #a = 1f;

		// Token: 0x04004441 RID: 17473
		private static int #b;

		// Token: 0x04004442 RID: 17474
		private readonly #zDe #c;

		// Token: 0x04004443 RID: 17475
		private readonly #ZIe #d;
	}
}
