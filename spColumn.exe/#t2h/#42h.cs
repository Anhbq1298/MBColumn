using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #01h;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;

namespace #t2h
{
	// Token: 0x020007A3 RID: 1955
	internal sealed class #42h : #y2h
	{
		// Token: 0x06003EBE RID: 16062 RVA: 0x00121DD4 File Offset: 0x0011FFD4
		public #42h(List<List<#Z1h>> #c2h) : base(#c2h[0])
		{
			this.Points = new List<#n3h>(#c2h.Count);
			foreach (#Z1h #Z1h in #c2h[0])
			{
				int num = #Z1h.GroupCode;
				if (num <= 41)
				{
					if (num != 40)
					{
						if (num == 41)
						{
							this.EndWidth = DxfHelper.#e2h(#Z1h.#W1h());
						}
					}
					else
					{
						this.StartWidth = DxfHelper.#e2h(#Z1h.#W1h());
					}
				}
				else if (num != 70)
				{
					if (num == 75)
					{
						this.CurvesFlag = DxfHelper.#f2h(#Z1h.#W1h());
					}
				}
				else
				{
					this.PolylineFlag = DxfHelper.#f2h(#Z1h.#W1h());
				}
			}
			for (int i = 1; i < #c2h.Count; i++)
			{
				this.Points.Add(new #n3h(#c2h[i]));
			}
			this.IsClosed = ((this.PolylineFlag & 1) == 1);
		}

		// Token: 0x17001309 RID: 4873
		// (get) Token: 0x06003EBF RID: 16063 RVA: 0x0003566C File Offset: 0x0003386C
		// (set) Token: 0x06003EC0 RID: 16064 RVA: 0x00035674 File Offset: 0x00033874
		public List<#n3h> Points { get; private set; }

		// Token: 0x1700130A RID: 4874
		// (get) Token: 0x06003EC1 RID: 16065 RVA: 0x0003567D File Offset: 0x0003387D
		// (set) Token: 0x06003EC2 RID: 16066 RVA: 0x00035685 File Offset: 0x00033885
		public bool IsClosed { get; private set; }

		// Token: 0x1700130B RID: 4875
		// (get) Token: 0x06003EC3 RID: 16067 RVA: 0x0003568E File Offset: 0x0003388E
		// (set) Token: 0x06003EC4 RID: 16068 RVA: 0x00035696 File Offset: 0x00033896
		public int PolylineFlag { get; private set; }

		// Token: 0x1700130C RID: 4876
		// (get) Token: 0x06003EC5 RID: 16069 RVA: 0x0003569F File Offset: 0x0003389F
		// (set) Token: 0x06003EC6 RID: 16070 RVA: 0x000356A7 File Offset: 0x000338A7
		public int CurvesFlag { get; private set; }

		// Token: 0x1700130D RID: 4877
		// (get) Token: 0x06003EC7 RID: 16071 RVA: 0x000356B0 File Offset: 0x000338B0
		// (set) Token: 0x06003EC8 RID: 16072 RVA: 0x000356B8 File Offset: 0x000338B8
		public double StartWidth { get; private set; }

		// Token: 0x1700130E RID: 4878
		// (get) Token: 0x06003EC9 RID: 16073 RVA: 0x000356C1 File Offset: 0x000338C1
		// (set) Token: 0x06003ECA RID: 16074 RVA: 0x000356C9 File Offset: 0x000338C9
		public double EndWidth { get; private set; }

		// Token: 0x04001C96 RID: 7318
		[CompilerGenerated]
		private List<#n3h> #a;

		// Token: 0x04001C97 RID: 7319
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04001C98 RID: 7320
		[CompilerGenerated]
		private int #c;

		// Token: 0x04001C99 RID: 7321
		[CompilerGenerated]
		private int #d;

		// Token: 0x04001C9A RID: 7322
		[CompilerGenerated]
		private double #e;

		// Token: 0x04001C9B RID: 7323
		[CompilerGenerated]
		private double #f;
	}
}
