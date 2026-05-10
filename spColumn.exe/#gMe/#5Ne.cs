using System;
using #hZe;
using #X7e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;

namespace #gMe
{
	// Token: 0x020012A8 RID: 4776
	internal sealed class #5Ne
	{
		// Token: 0x06009FF2 RID: 40946 RVA: 0x0007D9BC File Offset: 0x0007BBBC
		public #5Ne(InputModel #hMe, #38e #jMe)
		{
			this.#a = #hMe;
			this.#b = #jMe;
		}

		// Token: 0x17002E03 RID: 11779
		// (get) Token: 0x06009FF3 RID: 40947 RVA: 0x0007D9D2 File Offset: 0x0007BBD2
		private float[] SustainedLoadFactor
		{
			get
			{
				return this.#a.SustainedLoadFactor;
			}
		}

		// Token: 0x17002E04 RID: 11780
		// (get) Token: 0x06009FF4 RID: 40948 RVA: 0x0007D9DF File Offset: 0x0007BBDF
		private Options Options
		{
			get
			{
				return this.#a.Options;
			}
		}

		// Token: 0x06009FF5 RID: 40949 RVA: 0x0021FE9C File Offset: 0x0021E09C
		public void #ZNe(int #0Ne, #Lce #1Ne, float[] #LF, float[] #2Ne, #X3 #3Ne, float #4Ne)
		{
			#1Ne.Betadb[#0Ne] = #dOe.#6Ne(#LF, #2Ne, this.SustainedLoadFactor);
			float num = this.Options.#55e();
			float num2 = #3Ne.Kbraced * #3Ne.Height * num;
			float num3 = 1f + #1Ne.Betadb[#0Ne];
			#1Ne.Pcb[#0Ne] = 9.869605f * #4Ne / (num3 * (num2 * num2));
			if (#3Ne.IsBraced)
			{
				#1Ne.Pcs[#0Ne] = 0f;
				return;
			}
			num2 = #3Ne.Ksway * #3Ne.Height * num;
			#1Ne.Betads[#0Ne] = #dOe.#9Ne(#LF, this.SustainedLoadFactor, #2Ne, this.#b);
			num3 = 1f + #1Ne.Betads[#0Ne];
			#1Ne.Pcs[#0Ne] = 9.869605f * #4Ne / (num3 * (num2 * num2));
		}

		// Token: 0x040045EA RID: 17898
		private readonly InputModel #a;

		// Token: 0x040045EB RID: 17899
		private readonly #38e #b;
	}
}
