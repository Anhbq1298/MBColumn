using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using Svg;

namespace #rCe
{
	// Token: 0x02001224 RID: 4644
	internal sealed class #tCe
	{
		// Token: 0x06009B71 RID: 39793 RVA: 0x00210214 File Offset: 0x0020E414
		public #tCe(SvgDocument #bFd, #zDe #kcb)
		{
			this.DrawnLoadPoints = new List<LoadPointDrawingData>();
			this.Document = #bFd;
			this.DrawingData = #kcb;
			if (#kcb != null)
			{
				this.MinX = #bFd.ViewBox.MinX / #kcb.MomentsScalingFactor;
				this.MaxX = (#bFd.ViewBox.MinX + #bFd.ViewBox.Width) / #kcb.MomentsScalingFactor;
				this.MinY = #bFd.ViewBox.MinY / #kcb.AxialLoadScalingFactor;
				this.MaxY = (#bFd.ViewBox.MinY + #bFd.ViewBox.Height) / #kcb.AxialLoadScalingFactor;
				this.Width = #bFd.ViewBox.Width;
				this.Height = #bFd.ViewBox.Height;
				return;
			}
			this.MinX = -1f;
			this.MaxX = 1f;
			this.MinY = -1f;
			this.MaxY = 1f;
			this.Width = 2f;
			this.Height = 2f;
		}

		// Token: 0x17002CFE RID: 11518
		// (get) Token: 0x06009B72 RID: 39794 RVA: 0x0007AE68 File Offset: 0x00079068
		// (set) Token: 0x06009B73 RID: 39795 RVA: 0x0007AE70 File Offset: 0x00079070
		public #zDe DrawingData { get; private set; }

		// Token: 0x17002CFF RID: 11519
		// (get) Token: 0x06009B74 RID: 39796 RVA: 0x0007AE79 File Offset: 0x00079079
		// (set) Token: 0x06009B75 RID: 39797 RVA: 0x0007AE81 File Offset: 0x00079081
		public SvgDocument Document { get; private set; }

		// Token: 0x17002D00 RID: 11520
		// (get) Token: 0x06009B76 RID: 39798 RVA: 0x0007AE8A File Offset: 0x0007908A
		// (set) Token: 0x06009B77 RID: 39799 RVA: 0x0007AE92 File Offset: 0x00079092
		public List<LoadPointDrawingData> DrawnLoadPoints { get; private set; }

		// Token: 0x17002D01 RID: 11521
		// (get) Token: 0x06009B78 RID: 39800 RVA: 0x0007AE9B File Offset: 0x0007909B
		// (set) Token: 0x06009B79 RID: 39801 RVA: 0x0007AEA3 File Offset: 0x000790A3
		public float MinX { get; private set; }

		// Token: 0x17002D02 RID: 11522
		// (get) Token: 0x06009B7A RID: 39802 RVA: 0x0007AEAC File Offset: 0x000790AC
		// (set) Token: 0x06009B7B RID: 39803 RVA: 0x0007AEB4 File Offset: 0x000790B4
		public float MaxX { get; private set; }

		// Token: 0x17002D03 RID: 11523
		// (get) Token: 0x06009B7C RID: 39804 RVA: 0x0007AEBD File Offset: 0x000790BD
		// (set) Token: 0x06009B7D RID: 39805 RVA: 0x0007AEC5 File Offset: 0x000790C5
		public float MinY { get; private set; }

		// Token: 0x17002D04 RID: 11524
		// (get) Token: 0x06009B7E RID: 39806 RVA: 0x0007AECE File Offset: 0x000790CE
		// (set) Token: 0x06009B7F RID: 39807 RVA: 0x0007AED6 File Offset: 0x000790D6
		public float MaxY { get; private set; }

		// Token: 0x17002D05 RID: 11525
		// (get) Token: 0x06009B80 RID: 39808 RVA: 0x0007AEDF File Offset: 0x000790DF
		// (set) Token: 0x06009B81 RID: 39809 RVA: 0x0007AEE7 File Offset: 0x000790E7
		public float Width { get; private set; }

		// Token: 0x17002D06 RID: 11526
		// (get) Token: 0x06009B82 RID: 39810 RVA: 0x0007AEF0 File Offset: 0x000790F0
		// (set) Token: 0x06009B83 RID: 39811 RVA: 0x0007AEF8 File Offset: 0x000790F8
		public float Height { get; private set; }

		// Token: 0x0400430E RID: 17166
		[CompilerGenerated]
		private #zDe #a;

		// Token: 0x0400430F RID: 17167
		[CompilerGenerated]
		private SvgDocument #b;

		// Token: 0x04004310 RID: 17168
		[CompilerGenerated]
		private List<LoadPointDrawingData> #c;

		// Token: 0x04004311 RID: 17169
		[CompilerGenerated]
		private float #d;

		// Token: 0x04004312 RID: 17170
		[CompilerGenerated]
		private float #e;

		// Token: 0x04004313 RID: 17171
		[CompilerGenerated]
		private float #f;

		// Token: 0x04004314 RID: 17172
		[CompilerGenerated]
		private float #g;

		// Token: 0x04004315 RID: 17173
		[CompilerGenerated]
		private float #h;

		// Token: 0x04004316 RID: 17174
		[CompilerGenerated]
		private float #i;
	}
}
