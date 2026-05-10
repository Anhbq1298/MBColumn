using System;
using System.Runtime.CompilerServices;
using #NHe;

namespace #rCe
{
	// Token: 0x0200122B RID: 4651
	internal sealed class #7De
	{
		// Token: 0x06009BE1 RID: 39905 RVA: 0x002105D8 File Offset: 0x0020E7D8
		public #7De()
		{
			this.CurrentUniCurveDrawingMode = #0Ie.#a;
			this.IsNominalDiagramDrawnInColumn = true;
			this.WasNominalIncludedInLastSolve = true;
			this.AreLoadLabelsDrawn = true;
			this.IsGridDrawn = false;
			this.Parameter = 0f;
			this.AxialLoadUnit = string.Empty;
			this.MomentUnit = string.Empty;
		}

		// Token: 0x17002D35 RID: 11573
		// (get) Token: 0x06009BE2 RID: 39906 RVA: 0x0007B26E File Offset: 0x0007946E
		// (set) Token: 0x06009BE3 RID: 39907 RVA: 0x0007B276 File Offset: 0x00079476
		public #0Ie CurrentUniCurveDrawingMode { get; set; }

		// Token: 0x17002D36 RID: 11574
		// (get) Token: 0x06009BE4 RID: 39908 RVA: 0x0007B27F File Offset: 0x0007947F
		// (set) Token: 0x06009BE5 RID: 39909 RVA: 0x0007B287 File Offset: 0x00079487
		public bool IsNominalDiagramDrawnInColumn { get; set; }

		// Token: 0x17002D37 RID: 11575
		// (get) Token: 0x06009BE6 RID: 39910 RVA: 0x0007B290 File Offset: 0x00079490
		// (set) Token: 0x06009BE7 RID: 39911 RVA: 0x0007B298 File Offset: 0x00079498
		public bool WasNominalIncludedInLastSolve { get; set; }

		// Token: 0x17002D38 RID: 11576
		// (get) Token: 0x06009BE8 RID: 39912 RVA: 0x0007B2A1 File Offset: 0x000794A1
		public bool IsNominalDiagramDrawn
		{
			get
			{
				return this.WasNominalIncludedInLastSolve && this.IsNominalDiagramDrawnInColumn;
			}
		}

		// Token: 0x17002D39 RID: 11577
		// (get) Token: 0x06009BE9 RID: 39913 RVA: 0x0007B2B3 File Offset: 0x000794B3
		// (set) Token: 0x06009BEA RID: 39914 RVA: 0x0007B2BB File Offset: 0x000794BB
		public bool IsFactoredDiagramDrawn { get; set; }

		// Token: 0x17002D3A RID: 11578
		// (get) Token: 0x06009BEB RID: 39915 RVA: 0x0007B2C4 File Offset: 0x000794C4
		// (set) Token: 0x06009BEC RID: 39916 RVA: 0x0007B2CC File Offset: 0x000794CC
		public bool AreLoadLabelsDrawn { get; set; }

		// Token: 0x17002D3B RID: 11579
		// (get) Token: 0x06009BED RID: 39917 RVA: 0x0007B2D5 File Offset: 0x000794D5
		// (set) Token: 0x06009BEE RID: 39918 RVA: 0x0007B2DD File Offset: 0x000794DD
		public bool AreLoadPointsDrawn { get; set; }

		// Token: 0x17002D3C RID: 11580
		// (get) Token: 0x06009BEF RID: 39919 RVA: 0x0007B2E6 File Offset: 0x000794E6
		// (set) Token: 0x06009BF0 RID: 39920 RVA: 0x0007B2EE File Offset: 0x000794EE
		public bool AreSpliceLinesDrawn { get; set; }

		// Token: 0x17002D3D RID: 11581
		// (get) Token: 0x06009BF1 RID: 39921 RVA: 0x0007B2F7 File Offset: 0x000794F7
		// (set) Token: 0x06009BF2 RID: 39922 RVA: 0x0007B2FF File Offset: 0x000794FF
		public bool IsDiagramTopDrawn { get; set; }

		// Token: 0x17002D3E RID: 11582
		// (get) Token: 0x06009BF3 RID: 39923 RVA: 0x0007B308 File Offset: 0x00079508
		// (set) Token: 0x06009BF4 RID: 39924 RVA: 0x0007B310 File Offset: 0x00079510
		public bool IsGridDrawn { get; set; }

		// Token: 0x17002D3F RID: 11583
		// (get) Token: 0x06009BF5 RID: 39925 RVA: 0x0007B319 File Offset: 0x00079519
		// (set) Token: 0x06009BF6 RID: 39926 RVA: 0x0007B321 File Offset: 0x00079521
		public float Parameter { get; set; }

		// Token: 0x17002D40 RID: 11584
		// (get) Token: 0x06009BF7 RID: 39927 RVA: 0x0007B32A File Offset: 0x0007952A
		// (set) Token: 0x06009BF8 RID: 39928 RVA: 0x0007B332 File Offset: 0x00079532
		public string AxialLoadUnit
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.#a = #7De.#6De(value);
			}
		}

		// Token: 0x17002D41 RID: 11585
		// (get) Token: 0x06009BF9 RID: 39929 RVA: 0x0007B340 File Offset: 0x00079540
		// (set) Token: 0x06009BFA RID: 39930 RVA: 0x0007B348 File Offset: 0x00079548
		public string MomentUnit
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.#b = #7De.#6De(value);
			}
		}

		// Token: 0x17002D42 RID: 11586
		// (get) Token: 0x06009BFB RID: 39931 RVA: 0x0007B356 File Offset: 0x00079556
		// (set) Token: 0x06009BFC RID: 39932 RVA: 0x0007B35E File Offset: 0x0007955E
		public #uCe TypeOfDrawing { get; set; }

		// Token: 0x17002D43 RID: 11587
		// (get) Token: 0x06009BFD RID: 39933 RVA: 0x0007B367 File Offset: 0x00079567
		// (set) Token: 0x06009BFE RID: 39934 RVA: 0x0007B36F File Offset: 0x0007956F
		public string HorizontalAxisLabel { get; set; }

		// Token: 0x17002D44 RID: 11588
		// (get) Token: 0x06009BFF RID: 39935 RVA: 0x0007B378 File Offset: 0x00079578
		// (set) Token: 0x06009C00 RID: 39936 RVA: 0x0007B380 File Offset: 0x00079580
		public string VerticalAxisLabel { get; set; }

		// Token: 0x17002D45 RID: 11589
		// (get) Token: 0x06009C01 RID: 39937 RVA: 0x0007B389 File Offset: 0x00079589
		// (set) Token: 0x06009C02 RID: 39938 RVA: 0x0007B391 File Offset: 0x00079591
		public string AxialLoadLabelForMomentMomentDiagram { get; set; }

		// Token: 0x17002D46 RID: 11590
		// (get) Token: 0x06009C03 RID: 39939 RVA: 0x0007B39A File Offset: 0x0007959A
		// (set) Token: 0x06009C04 RID: 39940 RVA: 0x0007B3A2 File Offset: 0x000795A2
		public string AngleLabelForAxialLoadMomentDiagram { get; set; }

		// Token: 0x06009C05 RID: 39941 RVA: 0x0007B3AB File Offset: 0x000795AB
		private static string #6De(string #f)
		{
			if (!string.IsNullOrWhiteSpace(#f))
			{
				string text = #f.Trim();
				char[] array = new char[3];
				array[0] = '\r';
				array[1] = '\n';
				return text.Trim(array);
			}
			return string.Empty;
		}

		// Token: 0x0400434B RID: 17227
		private string #a;

		// Token: 0x0400434C RID: 17228
		private string #b;

		// Token: 0x0400434D RID: 17229
		[CompilerGenerated]
		private #0Ie #c;

		// Token: 0x0400434E RID: 17230
		[CompilerGenerated]
		private bool #d;

		// Token: 0x0400434F RID: 17231
		[CompilerGenerated]
		private bool #e;

		// Token: 0x04004350 RID: 17232
		[CompilerGenerated]
		private bool #f;

		// Token: 0x04004351 RID: 17233
		[CompilerGenerated]
		private bool #g;

		// Token: 0x04004352 RID: 17234
		[CompilerGenerated]
		private bool #h;

		// Token: 0x04004353 RID: 17235
		[CompilerGenerated]
		private bool #i;

		// Token: 0x04004354 RID: 17236
		[CompilerGenerated]
		private bool #j;

		// Token: 0x04004355 RID: 17237
		[CompilerGenerated]
		private bool #k;

		// Token: 0x04004356 RID: 17238
		[CompilerGenerated]
		private float #l;

		// Token: 0x04004357 RID: 17239
		[CompilerGenerated]
		private #uCe #m;

		// Token: 0x04004358 RID: 17240
		[CompilerGenerated]
		private string #n;

		// Token: 0x04004359 RID: 17241
		[CompilerGenerated]
		private string #o;

		// Token: 0x0400435A RID: 17242
		[CompilerGenerated]
		private string #p;

		// Token: 0x0400435B RID: 17243
		[CompilerGenerated]
		private string #q;
	}
}
