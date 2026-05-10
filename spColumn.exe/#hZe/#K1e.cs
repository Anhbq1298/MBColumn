using System;
using System.Runtime.CompilerServices;
using #wUe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #hZe
{
	// Token: 0x02001338 RID: 4920
	internal sealed class #K1e
	{
		// Token: 0x0600A46F RID: 42095 RVA: 0x0022FAA8 File Offset: 0x0022DCA8
		public #K1e(ReinforcementBar[] #KJ, int #Dbe)
		{
			if (#KJ.Length != 10000)
			{
				ReinforcementBar[] array = #KJ;
				#KJ = new ReinforcementBar[10000];
				Array.Copy(array, 0, #KJ, 0, array.Length);
				for (int i = array.Length; i < 10000; i++)
				{
					#KJ[i] = new ReinforcementBar();
				}
			}
			this.Bars = #KJ;
			this.NumberOfBars = #Dbe;
		}

		// Token: 0x17002F3C RID: 12092
		// (get) Token: 0x0600A470 RID: 42096 RVA: 0x000807C6 File Offset: 0x0007E9C6
		// (set) Token: 0x0600A471 RID: 42097 RVA: 0x000807CE File Offset: 0x0007E9CE
		public ReinforcementBar[] Bars { get; private set; }

		// Token: 0x17002F3D RID: 12093
		// (get) Token: 0x0600A472 RID: 42098 RVA: 0x000807D7 File Offset: 0x0007E9D7
		// (set) Token: 0x0600A473 RID: 42099 RVA: 0x000807DF File Offset: 0x0007E9DF
		public int NumberOfBars { get; set; }

		// Token: 0x0600A474 RID: 42100 RVA: 0x0022FB08 File Offset: 0x0022DD08
		public void #H1e(#I6e #tEb)
		{
			for (int i = 0; i < this.NumberOfBars; i++)
			{
				this.Bars[i].#VWi(#tEb);
			}
		}

		// Token: 0x0600A475 RID: 42101 RVA: 0x0022FB34 File Offset: 0x0022DD34
		public float #I1e()
		{
			float num = 0f;
			for (int i = 0; i < this.NumberOfBars; i++)
			{
				num += this.Bars[i].Area;
			}
			return num;
		}

		// Token: 0x0600A476 RID: 42102 RVA: 0x0022FB6C File Offset: 0x0022DD6C
		public bool #J1e()
		{
			bool result = true;
			for (int i = 0; i < this.NumberOfBars; i++)
			{
				#I6e #I6e = this.Bars[i].Location;
				if (#I6e == #I6e.#b || #I6e == #I6e.#c)
				{
					result = false;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600A477 RID: 42103 RVA: 0x0022FBA8 File Offset: 0x0022DDA8
		public void #cBb(float #Udb)
		{
			#Udb = #Udb * 3.1415927f / 180f;
			float num = #xke.#oke(#Udb);
			float num2 = #xke.#qke(#Udb);
			ReinforcementBar[] array = this.Bars;
			for (int i = 0; i < this.NumberOfBars; i++)
			{
				array[i].Z = -array[i].X * num2 + array[i].Y * num;
			}
		}

		// Token: 0x0400480F RID: 18447
		public const int #a = 10000;

		// Token: 0x04004810 RID: 18448
		[CompilerGenerated]
		private ReinforcementBar[] #b;

		// Token: 0x04004811 RID: 18449
		[CompilerGenerated]
		private int #c;
	}
}
