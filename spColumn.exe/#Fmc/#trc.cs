using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #Fmc
{
	// Token: 0x020007D4 RID: 2004
	internal sealed class #trc
	{
		// Token: 0x06004066 RID: 16486 RVA: 0x000365D7 File Offset: 0x000347D7
		public #trc(Point3D #urc, #jrc #vrc)
		{
			this.#a = #urc;
			this.#b = #vrc;
			this.#krc();
			this.SecondarySnapToPointOrigins = new HashSet<#huc>();
		}

		// Token: 0x06004067 RID: 16487 RVA: 0x0012CCC8 File Offset: 0x0012AEC8
		public void #krc()
		{
			while (8 != 0 && 5 != 0)
			{
				this.#c = null;
				if (!false)
				{
					this.#f = null;
					if (2 != 0)
					{
						this.#d = double.MaxValue;
					}
					this.#e = #huc.#i;
					break;
				}
			}
		}

		// Token: 0x06004068 RID: 16488 RVA: 0x0012CD1C File Offset: 0x0012AF1C
		public void #Qfb(#fuc #lrc, #huc #mrc)
		{
			if (#lrc != null)
			{
				goto IL_0B;
			}
			IL_04:
			if (false)
			{
				goto IL_29;
			}
			if (!false)
			{
				return;
			}
			IL_0B:
			if (8 == 0)
			{
				goto IL_04;
			}
			Point3D value = PointsConverter.#vsc(#lrc.Point);
			IL_16:
			this.#Qfb(new Point3D?(value), #mrc, #lrc.SnapToEdgeOriginInfo);
			IL_29:
			if (3 != 0)
			{
				return;
			}
			goto IL_16;
		}

		// Token: 0x06004069 RID: 16489 RVA: 0x0012CD7C File Offset: 0x0012AF7C
		public #Atc #nrc()
		{
			int #mrc;
			do
			{
				bool flag = (#mrc = ((this.#c != null) ? 1 : 0)) != 0;
				if (7 == 0)
				{
					goto IL_12;
				}
				if (flag && !false)
				{
					goto Block_2;
				}
			}
			while (4 == 0);
			#mrc = 8;
			IL_12:
			return new #Atc((#huc)#mrc, this.#a);
			Block_2:
			return new #Atc(this.#e, this.#c.Value, this.#f, this.SecondarySnapToPointOrigins);
		}

		// Token: 0x0600406A RID: 16490 RVA: 0x000365FE File Offset: 0x000347FE
		public void #Qfb(Point3D? #Ng, #huc #mrc)
		{
			this.#Qfb(#Ng, #mrc, null);
		}

		// Token: 0x0600406B RID: 16491 RVA: 0x0012CDF4 File Offset: 0x0012AFF4
		public void #Qfb(Point3D? #Ng, #huc #mrc, string #orc)
		{
			if (#Ng == null)
			{
				return;
			}
			bool flag2;
			bool flag = flag2 = (this.#c != null);
			double num;
			if (!false)
			{
				if (!flag)
				{
					this.#c = #Ng;
					this.#d = GeometryHelper.#lcb(#Ng.Value, this.#a);
					this.#e = #mrc;
					if (-1 == 0)
					{
						goto IL_BD;
					}
					if (!false)
					{
						this.#f = #orc;
						return;
					}
				}
				else
				{
					num = GeometryHelper.#lcb(#Ng.Value, this.#a);
				}
				while (4 != 0)
				{
					if (num >= this.#d)
					{
						goto IL_BD;
					}
					if (!false)
					{
						flag2 = #Emc.#zmc(num, this.#d);
						goto IL_93;
					}
				}
				goto IL_9C;
			}
			goto IL_D7;
			IL_93:
			if (flag2)
			{
				goto IL_BD;
			}
			this.#c = #Ng;
			IL_9C:
			this.#d = num;
			this.#e = #mrc;
			this.#f = #orc;
			this.SecondarySnapToPointOrigins.Clear();
			return;
			IL_BD:
			if (!#Emc.#zmc(num, this.#d))
			{
				return;
			}
			flag2 = this.SecondarySnapToPointOrigins.Add(#mrc);
			IL_D7:
			if (6 == 0)
			{
				goto IL_93;
			}
		}

		// Token: 0x17001348 RID: 4936
		// (get) Token: 0x0600406C RID: 16492 RVA: 0x00036619 File Offset: 0x00034819
		// (set) Token: 0x0600406D RID: 16493 RVA: 0x00036625 File Offset: 0x00034825
		public HashSet<#huc> SecondarySnapToPointOrigins { get; private set; }

		// Token: 0x17001349 RID: 4937
		// (get) Token: 0x0600406E RID: 16494 RVA: 0x00036636 File Offset: 0x00034836
		public bool ShouldCollect
		{
			get
			{
				int result;
				if (4 != 0)
				{
					if (this.#b == #jrc.#a)
					{
						bool flag = (result = ((this.#c != null) ? 1 : 0)) != 0;
						if (false)
						{
							return result != 0;
						}
						if (!flag)
						{
							goto IL_28;
						}
					}
					if (!false)
					{
						return this.#b == #jrc.#b;
					}
				}
				IL_28:
				result = 1;
				return result != 0;
			}
		}

		// Token: 0x1700134A RID: 4938
		// (get) Token: 0x0600406F RID: 16495 RVA: 0x00036671 File Offset: 0x00034871
		public bool HasValidResult
		{
			get
			{
				return this.#c != null;
			}
		}

		// Token: 0x04001D21 RID: 7457
		private readonly Point3D #a;

		// Token: 0x04001D22 RID: 7458
		private readonly #jrc #b;

		// Token: 0x04001D23 RID: 7459
		private Point3D? #c;

		// Token: 0x04001D24 RID: 7460
		private double #d;

		// Token: 0x04001D25 RID: 7461
		private #huc #e;

		// Token: 0x04001D26 RID: 7462
		private string #f;

		// Token: 0x04001D27 RID: 7463
		[CompilerGenerated]
		private HashSet<#huc> #g;
	}
}
