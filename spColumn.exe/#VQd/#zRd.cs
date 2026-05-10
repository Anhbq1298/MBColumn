using System;
using System.IO;
using System.Runtime.CompilerServices;
using #o1d;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Generation.API;

namespace #VQd
{
	// Token: 0x02000E0C RID: 3596
	internal class #zRd : IReportData
	{
		// Token: 0x17002698 RID: 9880
		// (get) Token: 0x06008179 RID: 33145 RVA: 0x00069774 File Offset: 0x00067974
		// (set) Token: 0x0600817A RID: 33146 RVA: 0x00069780 File Offset: 0x00067980
		public bool IsEmpty { get; set; }

		// Token: 0x17002699 RID: 9881
		// (get) Token: 0x0600817B RID: 33147 RVA: 0x00069791 File Offset: 0x00067991
		// (set) Token: 0x0600817C RID: 33148 RVA: 0x0006979D File Offset: 0x0006799D
		public bool IsShown { get; set; }

		// Token: 0x1700269A RID: 9882
		// (get) Token: 0x0600817D RID: 33149 RVA: 0x000697AE File Offset: 0x000679AE
		// (set) Token: 0x0600817E RID: 33150 RVA: 0x000697BA File Offset: 0x000679BA
		public bool IsValid { get; set; }

		// Token: 0x1700269B RID: 9883
		// (get) Token: 0x0600817F RID: 33151 RVA: 0x000697CB File Offset: 0x000679CB
		// (set) Token: 0x06008180 RID: 33152 RVA: 0x000697D7 File Offset: 0x000679D7
		public bool IsDisplayContentAvailable { get; set; }

		// Token: 0x1700269C RID: 9884
		// (get) Token: 0x06008181 RID: 33153 RVA: 0x000697E8 File Offset: 0x000679E8
		// (set) Token: 0x06008182 RID: 33154 RVA: 0x000697F4 File Offset: 0x000679F4
		public virtual Stream ReportContent { get; set; }

		// Token: 0x1700269D RID: 9885
		// (get) Token: 0x06008183 RID: 33155 RVA: 0x00069805 File Offset: 0x00067A05
		public virtual Stream DisplayContent
		{
			get
			{
				return this.ReportContent;
			}
		}

		// Token: 0x06008184 RID: 33156 RVA: 0x00069815 File Offset: 0x00067A15
		public virtual void #yJ()
		{
			this.IsEmpty = true;
			this.IsShown = false;
			this.IsValid = false;
			this.ReportContent = null;
		}

		// Token: 0x06008185 RID: 33157 RVA: 0x0006983F File Offset: 0x00067A3F
		public void #yRd()
		{
			Stream stream = this.ReportContent;
			if (stream != null)
			{
				stream.#i2d();
			}
			Stream stream2 = this.DisplayContent;
			if (stream2 == null)
			{
				return;
			}
			stream2.#i2d();
		}

		// Token: 0x04003526 RID: 13606
		[CompilerGenerated]
		private bool #a;

		// Token: 0x04003527 RID: 13607
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04003528 RID: 13608
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04003529 RID: 13609
		[CompilerGenerated]
		private bool #d = true;

		// Token: 0x0400352A RID: 13610
		[CompilerGenerated]
		private Stream #e;
	}
}
