using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #Fmc
{
	// Token: 0x020007F6 RID: 2038
	internal sealed class #Atc
	{
		// Token: 0x06004181 RID: 16769 RVA: 0x00037023 File Offset: 0x00035223
		public #Atc(#huc #mrc, Point3D #Ng)
		{
			this.SecondarySnapToPointOrigins = new HashSet<#huc>();
			this.Point = #Ng;
			this.SnapToPointOrigin = #mrc;
			this.NoSnappingPerformed = (#mrc == #huc.#i);
			this.SnappingPerformed = !this.NoSnappingPerformed;
		}

		// Token: 0x06004182 RID: 16770 RVA: 0x0003705D File Offset: 0x0003525D
		public #Atc(#huc #mrc, Point3D #Ng, string #Btc, ISet<#huc> #Ctc) : this(#mrc, #Ng)
		{
			this.SnapPointOriginInfo = #Btc;
			if (#Ctc != null)
			{
				this.SecondarySnapToPointOrigins = #Ctc;
			}
		}

		// Token: 0x06004183 RID: 16771 RVA: 0x00132934 File Offset: 0x00130B34
		public bool #otc(params #huc[] #ptc)
		{
			if (#ptc != null)
			{
				while (!false)
				{
					if (#ptc.Any(new Func<#huc, bool>(this.#ytc)))
					{
						if (!false)
						{
							return true;
						}
						goto IL_37;
					}
					IL_24:
					if (!#ptc.Any(new Func<#huc, bool>(this.#ztc)))
					{
						if (-1 != 0)
						{
							return false;
						}
						continue;
					}
					IL_37:
					if (!false)
					{
						return true;
					}
					goto IL_24;
				}
			}
			int result;
			int num = result = 0;
			if (num == 0)
			{
				return num != 0;
			}
			return result != 0;
		}

		// Token: 0x17001366 RID: 4966
		// (get) Token: 0x06004184 RID: 16772 RVA: 0x0003707A File Offset: 0x0003527A
		// (set) Token: 0x06004185 RID: 16773 RVA: 0x00037086 File Offset: 0x00035286
		public #huc SnapToPointOrigin { get; private set; }

		// Token: 0x17001367 RID: 4967
		// (get) Token: 0x06004186 RID: 16774 RVA: 0x00037097 File Offset: 0x00035297
		// (set) Token: 0x06004187 RID: 16775 RVA: 0x000370A3 File Offset: 0x000352A3
		public string SnapPointOriginInfo { get; private set; }

		// Token: 0x17001368 RID: 4968
		// (get) Token: 0x06004188 RID: 16776 RVA: 0x000370B4 File Offset: 0x000352B4
		// (set) Token: 0x06004189 RID: 16777 RVA: 0x000370C0 File Offset: 0x000352C0
		public Point3D Point { get; private set; }

		// Token: 0x17001369 RID: 4969
		// (get) Token: 0x0600418A RID: 16778 RVA: 0x000370D1 File Offset: 0x000352D1
		// (set) Token: 0x0600418B RID: 16779 RVA: 0x000370DD File Offset: 0x000352DD
		public bool NoSnappingPerformed { get; private set; }

		// Token: 0x1700136A RID: 4970
		// (get) Token: 0x0600418C RID: 16780 RVA: 0x000370EE File Offset: 0x000352EE
		// (set) Token: 0x0600418D RID: 16781 RVA: 0x000370FA File Offset: 0x000352FA
		public bool SnappingPerformed { get; private set; }

		// Token: 0x1700136B RID: 4971
		// (get) Token: 0x0600418E RID: 16782 RVA: 0x0003710B File Offset: 0x0003530B
		// (set) Token: 0x0600418F RID: 16783 RVA: 0x00037117 File Offset: 0x00035317
		public ISet<#huc> SecondarySnapToPointOrigins { get; private set; }

		// Token: 0x06004190 RID: 16784 RVA: 0x00037128 File Offset: 0x00035328
		[CompilerGenerated]
		private bool #ytc(#huc #Rf)
		{
			return this.SnapToPointOrigin == #Rf;
		}

		// Token: 0x06004191 RID: 16785 RVA: 0x0003713F File Offset: 0x0003533F
		[CompilerGenerated]
		private bool #ztc(#huc #Rf)
		{
			return this.SecondarySnapToPointOrigins.Contains(#Rf);
		}

		// Token: 0x04001D78 RID: 7544
		[CompilerGenerated]
		private #huc #a;

		// Token: 0x04001D79 RID: 7545
		[CompilerGenerated]
		private string #b;

		// Token: 0x04001D7A RID: 7546
		[CompilerGenerated]
		private Point3D #c;

		// Token: 0x04001D7B RID: 7547
		[CompilerGenerated]
		private bool #d;

		// Token: 0x04001D7C RID: 7548
		[CompilerGenerated]
		private bool #e;

		// Token: 0x04001D7D RID: 7549
		[CompilerGenerated]
		private ISet<#huc> #f;
	}
}
