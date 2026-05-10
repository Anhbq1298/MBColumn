using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;

namespace #oFe
{
	// Token: 0x0200123F RID: 4671
	internal sealed class #YFe
	{
		// Token: 0x06009C83 RID: 40067 RVA: 0x0007B885 File Offset: 0x00079A85
		public #YFe()
		{
		}

		// Token: 0x06009C84 RID: 40068 RVA: 0x0007B898 File Offset: 0x00079A98
		public #YFe(List<LoadPointDrawingData> #8f, int #GEe)
		{
			this.DrawnPoints = #8f;
			this.TotalNoOfPoints = #GEe;
		}

		// Token: 0x17002D4D RID: 11597
		// (get) Token: 0x06009C85 RID: 40069 RVA: 0x0007B8B9 File Offset: 0x00079AB9
		public List<LoadPointDrawingData> DrawnPoints { get; } = new List<LoadPointDrawingData>();

		// Token: 0x17002D4E RID: 11598
		// (get) Token: 0x06009C86 RID: 40070 RVA: 0x0007B8C1 File Offset: 0x00079AC1
		// (set) Token: 0x06009C87 RID: 40071 RVA: 0x0007B8C9 File Offset: 0x00079AC9
		public int TotalNoOfPoints { get; set; }

		// Token: 0x17002D4F RID: 11599
		// (get) Token: 0x06009C88 RID: 40072 RVA: 0x0007B8D2 File Offset: 0x00079AD2
		public static #YFe Empty
		{
			get
			{
				return new #YFe();
			}
		}

		// Token: 0x04004399 RID: 17305
		[CompilerGenerated]
		private readonly List<LoadPointDrawingData> #a;

		// Token: 0x0400439A RID: 17306
		[CompilerGenerated]
		private int #b;
	}
}
