using System;
using System.Collections.Generic;
using #12e;
using #hZe;
using #wUe;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012B3 RID: 4787
	internal sealed class #QOe
	{
		// Token: 0x0600A03C RID: 41020 RVA: 0x0007DC7B File Offset: 0x0007BE7B
		public #QOe(InputModel #hMe, #l4e #Kwe, RuntimeModel #iMe)
		{
			this.#k = #hMe;
			this.#l = #Kwe;
			this.#m = #iMe;
		}

		// Token: 0x17002E14 RID: 11796
		// (get) Token: 0x0600A03D RID: 41021 RVA: 0x0007DC98 File Offset: 0x0007BE98
		private Options Options
		{
			get
			{
				return this.#k.Options;
			}
		}

		// Token: 0x17002E15 RID: 11797
		// (get) Token: 0x0600A03E RID: 41022 RVA: 0x0007DCA5 File Offset: 0x0007BEA5
		private #X3 DesignedColumnX
		{
			get
			{
				return this.#k.DesignedColumnX;
			}
		}

		// Token: 0x17002E16 RID: 11798
		// (get) Token: 0x0600A03F RID: 41023 RVA: 0x0007DCB2 File Offset: 0x0007BEB2
		private #X3 DesignedColumnY
		{
			get
			{
				return this.#k.DesignedColumnY;
			}
		}

		// Token: 0x0600A040 RID: 41024 RVA: 0x002210B0 File Offset: 0x0021F2B0
		public #f0e[] #LOe(int #MOe, int #NOe, int #OOe)
		{
			List<#f0e> list = new List<#f0e>();
			if (#xke.#U3(#MOe & 1))
			{
				this.#l.#vzc(Message.#qn(#M6e.#r, Array.Empty<object>()));
				list.Add(new #f0e(false, new #M6e?(#M6e.#r)));
			}
			if (#xke.#U3(#MOe & 2))
			{
				this.#l.#vzc(Message.#qn(#M6e.#c, Array.Empty<object>()));
				list.Add(new #f0e(false, new #M6e?(#M6e.#c)));
			}
			if (#xke.#U3(#MOe & 4) || (this.Options.ProblemType == #z6e.#a && this.#m.ReinforcementBars.NumberOfBars <= 0))
			{
				this.#l.#vzc(Message.#qn(#M6e.#s, Array.Empty<object>()));
				list.Add(new #f0e(false, new #M6e?(#M6e.#s)));
			}
			if (!this.Options.ShouldConsiderSlenderness && this.Options.ProblemType == #z6e.#b && #xke.#U3(#MOe & 8))
			{
				this.#l.#vzc(Message.#qn(#M6e.#t, Array.Empty<object>()));
				list.Add(new #f0e(false, new #M6e?(#M6e.#t)));
			}
			if (!this.Options.ShouldConsiderSlenderness && this.Options.ProblemType == #z6e.#b && #xke.#dke(#MOe & 8) && this.Options.Loads[(int)this.Options.ProblemType] == Load.Service && this.Options.NumberOfServiceLoads == 0)
			{
				this.#l.#vzc(Message.#qn(#M6e.#t, Array.Empty<object>()));
				list.Add(new #f0e(false, new #M6e?(#M6e.#t)));
			}
			if (!this.Options.ShouldConsiderSlenderness && this.Options.ProblemType == #z6e.#b && #xke.#dke(#MOe & 8) && this.Options.Loads[(int)this.Options.ProblemType] == Load.Factored && #OOe == 0)
			{
				this.#l.#vzc(Message.#qn(#M6e.#t, Array.Empty<object>()));
				list.Add(new #f0e(false, new #M6e?(#M6e.#t)));
			}
			if (this.Options.ShouldConsiderSlenderness)
			{
				#f0e #f0e = this.#POe(#MOe, #NOe);
				if (#f0e != null)
				{
					list.Add(#f0e);
				}
			}
			if (#xke.#U3(#MOe & 8))
			{
				this.#l.#vzc(Message.#qn(#M6e.#t, Array.Empty<object>()));
				list.Add(new #f0e(false, new #M6e?(#M6e.#t)));
			}
			return list.ToArray();
		}

		// Token: 0x0600A041 RID: 41025 RVA: 0x00221308 File Offset: 0x0021F508
		private #f0e #POe(int #MOe, int #NOe)
		{
			bool flag = true;
			#M6e? #g0e = null;
			if (this.Options.ConsideredAxis == #C6e.#a || this.Options.ConsideredAxis == #C6e.#c)
			{
				if (#xke.#U3(#NOe & 1))
				{
					flag = false;
					#g0e = new #M6e?(#M6e.#u);
					this.#l.#vzc(Message.#qn(#M6e.#u, Array.Empty<object>()));
				}
				else if (this.DesignedColumnX.Kmode == 0 && #xke.#U3(#NOe & 4))
				{
					flag = false;
					#g0e = new #M6e?(#M6e.#v);
					this.#l.#vzc(Message.#qn(#M6e.#v, Array.Empty<object>()));
				}
				else if (this.DesignedColumnX.Kmode == 0 && #xke.#U3(#NOe & 8))
				{
					flag = false;
					#g0e = new #M6e?(#M6e.#w);
					this.#l.#vzc(Message.#qn(#M6e.#w, Array.Empty<object>()));
				}
			}
			if (flag && (this.Options.ConsideredAxis == #C6e.#b || this.Options.ConsideredAxis == #C6e.#c))
			{
				if (#xke.#U3(#NOe & 2))
				{
					flag = false;
					#g0e = new #M6e?(#M6e.#u);
					this.#l.#vzc(Message.#qn(#M6e.#u, Array.Empty<object>()));
				}
				else if (this.DesignedColumnY.Kmode == 0 && #xke.#U3(#NOe & 4))
				{
					flag = false;
					#g0e = new #M6e?(#M6e.#v);
					this.#l.#vzc(Message.#qn(#M6e.#v, Array.Empty<object>()));
				}
				else if (this.DesignedColumnY.Kmode == 0 && #xke.#U3(#NOe & 16))
				{
					flag = false;
					#g0e = new #M6e?(#M6e.#w);
					this.#l.#vzc(Message.#qn(#M6e.#w, Array.Empty<object>()));
				}
			}
			if (flag && #xke.#U3(#MOe & 16))
			{
				flag = false;
				#g0e = new #M6e?(#M6e.#t);
				this.#l.#vzc(Message.#qn(#M6e.#t, Array.Empty<object>()));
			}
			if (flag)
			{
				return null;
			}
			return new #f0e(false, #g0e);
		}

		// Token: 0x04004619 RID: 17945
		private const int #a = 1;

		// Token: 0x0400461A RID: 17946
		private const int #b = 2;

		// Token: 0x0400461B RID: 17947
		private const int #c = 4;

		// Token: 0x0400461C RID: 17948
		private const int #d = 8;

		// Token: 0x0400461D RID: 17949
		private const int #e = 16;

		// Token: 0x0400461E RID: 17950
		private const int #f = 1;

		// Token: 0x0400461F RID: 17951
		private const int #g = 2;

		// Token: 0x04004620 RID: 17952
		private const int #h = 4;

		// Token: 0x04004621 RID: 17953
		private const int #i = 8;

		// Token: 0x04004622 RID: 17954
		private const int #j = 16;

		// Token: 0x04004623 RID: 17955
		private readonly InputModel #k;

		// Token: 0x04004624 RID: 17956
		private readonly #l4e #l;

		// Token: 0x04004625 RID: 17957
		private readonly RuntimeModel #m;
	}
}
