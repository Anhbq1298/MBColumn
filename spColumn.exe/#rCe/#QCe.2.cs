using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.Infrastructure.Data;
using Svg;

namespace #rCe
{
	// Token: 0x02001228 RID: 4648
	internal sealed class #QCe
	{
		// Token: 0x06009BA2 RID: 39842 RVA: 0x0007AFF1 File Offset: 0x000791F1
		public #QCe(#tCe #RCe, #uCe #SCe, string #sH)
		{
			this.Diagram = #RCe;
			this.VisibleLoadPoints = ((#RCe != null) ? #RCe.DrawnLoadPoints : new List<LoadPointDrawingData>());
			this.TypeOfDrawing = #SCe;
			this.Title = #sH;
		}

		// Token: 0x17002D16 RID: 11542
		// (get) Token: 0x06009BA3 RID: 39843 RVA: 0x0007B024 File Offset: 0x00079224
		public #uCe TypeOfDrawing { get; }

		// Token: 0x17002D17 RID: 11543
		// (get) Token: 0x06009BA4 RID: 39844 RVA: 0x0007B02C File Offset: 0x0007922C
		public string Title { get; }

		// Token: 0x17002D18 RID: 11544
		// (get) Token: 0x06009BA5 RID: 39845 RVA: 0x0007B034 File Offset: 0x00079234
		public SvgDocument DrawingContent
		{
			get
			{
				#tCe #tCe = this.Diagram;
				if (#tCe == null)
				{
					return null;
				}
				return #tCe.Document;
			}
		}

		// Token: 0x17002D19 RID: 11545
		// (get) Token: 0x06009BA6 RID: 39846 RVA: 0x0007B047 File Offset: 0x00079247
		public List<LoadPointDrawingData> VisibleLoadPoints { get; }

		// Token: 0x17002D1A RID: 11546
		// (get) Token: 0x06009BA7 RID: 39847 RVA: 0x0007B04F File Offset: 0x0007924F
		public #tCe Diagram { get; }

		// Token: 0x06009BA8 RID: 39848 RVA: 0x0007B057 File Offset: 0x00079257
		public string #OCe()
		{
			SvgDocument svgDocument = this.DrawingContent;
			if (svgDocument == null)
			{
				return null;
			}
			return svgDocument.GetXML();
		}

		// Token: 0x06009BA9 RID: 39849 RVA: 0x0021045C File Offset: 0x0020E65C
		public Point #PCe(Point #7qc)
		{
			float num = Math.Abs(this.Diagram.MaxX - this.Diagram.MinX) / this.Diagram.Width;
			float num2 = Math.Abs(this.Diagram.MaxY - this.Diagram.MinY) / this.Diagram.Height;
			float num3 = Math.Abs(this.Diagram.MinX);
			float num4 = Math.Abs(this.Diagram.MaxY);
			return new Point((double)((float)(#7qc.X * (double)num - (double)num3)), (double)((float)(-(float)(#7qc.Y * (double)num2 - (double)num4))));
		}

		// Token: 0x0400432E RID: 17198
		[CompilerGenerated]
		private readonly #uCe #a;

		// Token: 0x0400432F RID: 17199
		[CompilerGenerated]
		private readonly string #b;

		// Token: 0x04004330 RID: 17200
		[CompilerGenerated]
		private readonly List<LoadPointDrawingData> #c;

		// Token: 0x04004331 RID: 17201
		[CompilerGenerated]
		private readonly #tCe #d;
	}
}
