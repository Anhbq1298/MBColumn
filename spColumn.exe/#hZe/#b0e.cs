using System;
using System.Runtime.CompilerServices;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #hZe
{
	// Token: 0x02001329 RID: 4905
	internal sealed class #b0e
	{
		// Token: 0x0600A3C6 RID: 41926 RVA: 0x0022EDBC File Offset: 0x0022CFBC
		public #b0e(LoadsExt[] #tk, int #c0e)
		{
			if (#tk.Length != 10000)
			{
				LoadsExt[] array = #tk;
				#tk = new LoadsExt[10000];
				Array.Copy(array, 0, #tk, 0, array.Length);
				for (int i = array.Length; i < 10000; i++)
				{
					#tk[i] = new LoadsExt(0f, 0f, 0f);
				}
			}
			this.Loads = #tk;
			this.NumberOfLoads = #c0e;
		}

		// Token: 0x17002EF9 RID: 12025
		// (get) Token: 0x0600A3C7 RID: 41927 RVA: 0x0007FF02 File Offset: 0x0007E102
		// (set) Token: 0x0600A3C8 RID: 41928 RVA: 0x0007FF0A File Offset: 0x0007E10A
		public LoadsExt[] Loads { get; private set; }

		// Token: 0x17002EFA RID: 12026
		// (get) Token: 0x0600A3C9 RID: 41929 RVA: 0x0007FF13 File Offset: 0x0007E113
		// (set) Token: 0x0600A3CA RID: 41930 RVA: 0x0007FF1B File Offset: 0x0007E11B
		public int NumberOfLoads { get; set; }

		// Token: 0x0600A3CB RID: 41931 RVA: 0x0007FF24 File Offset: 0x0007E124
		public void #8Pe(int #sP, float #JMe, float #1Xe, float #2Xe, int #RC, int #nQe)
		{
			if (#sP >= 0 && #sP < 10000)
			{
				this.Loads[#sP].#5Pe(#RC, #nQe, #JMe, #1Xe, #2Xe);
			}
		}

		// Token: 0x0600A3CC RID: 41932 RVA: 0x0022EE2C File Offset: 0x0022D02C
		public void #8Pe(int #sP, int #6gb, float #Tdb, float #HRe, float #IRe, #C6e #Tye)
		{
			if (#Tye < #C6e.#c)
			{
				this.Loads[#sP].AxialLoad = #Tdb;
				this.Loads[#sP + 1].AxialLoad = #Tdb;
				if (#6gb == 0)
				{
					this.Loads[#sP].MomentX = #HRe;
					this.Loads[#sP].MomentY = 0f;
					this.Loads[#sP + 1].MomentX = #IRe;
					this.Loads[#sP + 1].MomentY = 0f;
					return;
				}
				this.Loads[#sP].MomentX = 0f;
				this.Loads[#sP].MomentY = #HRe;
				this.Loads[#sP + 1].MomentX = 0f;
				this.Loads[#sP + 1].MomentY = #IRe;
				return;
			}
			else
			{
				if (#6gb == 0)
				{
					this.Loads[#sP].AxialLoad = #Tdb;
					this.Loads[#sP + 1].AxialLoad = #Tdb;
					this.Loads[#sP].MomentX = #HRe;
					this.Loads[#sP + 1].MomentX = #IRe;
					return;
				}
				this.Loads[#sP].MomentY = #HRe;
				this.Loads[#sP + 1].MomentY = #IRe;
				return;
			}
		}

		// Token: 0x040047C2 RID: 18370
		private const int #a = 10000;

		// Token: 0x040047C3 RID: 18371
		[CompilerGenerated]
		private LoadsExt[] #b;

		// Token: 0x040047C4 RID: 18372
		[CompilerGenerated]
		private int #c;
	}
}
