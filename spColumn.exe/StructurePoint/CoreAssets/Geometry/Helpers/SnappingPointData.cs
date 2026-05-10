using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007F0 RID: 2032
	public sealed class SnappingPointData
	{
		// Token: 0x1700134F RID: 4943
		// (get) Token: 0x0600410B RID: 16651 RVA: 0x00036A7C File Offset: 0x00034C7C
		// (set) Token: 0x0600410C RID: 16652 RVA: 0x00036A88 File Offset: 0x00034C88
		public Point Point { get; private set; }

		// Token: 0x17001350 RID: 4944
		// (get) Token: 0x0600410D RID: 16653 RVA: 0x00036A99 File Offset: 0x00034C99
		// (set) Token: 0x0600410E RID: 16654 RVA: 0x00036AA5 File Offset: 0x00034CA5
		public #juc SnapDataOrigin { get; private set; }

		// Token: 0x17001351 RID: 4945
		// (get) Token: 0x0600410F RID: 16655 RVA: 0x00036AB6 File Offset: 0x00034CB6
		// (set) Token: 0x06004110 RID: 16656 RVA: 0x00036AC2 File Offset: 0x00034CC2
		public string OriginInfo { get; private set; }

		// Token: 0x06004111 RID: 16657 RVA: 0x00130A00 File Offset: 0x0012EC00
		public void #1sc(string #6h)
		{
			bool flag;
			bool flag3;
			for (;;)
			{
				IL_00:
				bool flag2;
				flag = (flag2 = \u0003.\u0004(#6h));
				while (2 != 0)
				{
					if (flag2)
					{
						if (4 != 0)
						{
							return;
						}
						goto IL_00;
					}
					else
					{
						flag3 = (flag2 = (flag = this.#d.Add(#6h)));
						if (2 != 0)
						{
							goto Block_3;
						}
					}
				}
				goto IL_30;
			}
			return;
			Block_3:
			if (!flag3)
			{
				goto IL_5F;
			}
			IL_25:
			flag = \u0003.\u0004(this.OriginInfo);
			IL_30:
			if (flag)
			{
				if (8 != 0)
				{
					this.OriginInfo = #6h;
				}
				return;
			}
			this.OriginInfo = \u0010.\u0092(this.OriginInfo, #Phc.#3hc(107376612), #6h);
			IL_5F:
			if (5 != 0)
			{
				return;
			}
			goto IL_25;
		}

		// Token: 0x06004112 RID: 16658 RVA: 0x00036AD3 File Offset: 0x00034CD3
		public SnappingPointData(Point point, #juc snapDataOrigin, string originInfo) : this(point, snapDataOrigin)
		{
			this.OriginInfo = originInfo;
		}

		// Token: 0x06004113 RID: 16659 RVA: 0x00036AE4 File Offset: 0x00034CE4
		public SnappingPointData(Point point, #juc snapDataOrigin)
		{
			this.Point = point;
			this.SnapDataOrigin = snapDataOrigin;
		}

		// Token: 0x06004114 RID: 16660 RVA: 0x00036B05 File Offset: 0x00034D05
		public SnappingPointData(Point point) : this(point, #juc.#a)
		{
		}

		// Token: 0x04001D48 RID: 7496
		[CompilerGenerated]
		private Point #a;

		// Token: 0x04001D49 RID: 7497
		[CompilerGenerated]
		private #juc #b;

		// Token: 0x04001D4A RID: 7498
		[CompilerGenerated]
		private string #c;

		// Token: 0x04001D4B RID: 7499
		private readonly HashSet<string> #d = new HashSet<string>();
	}
}
