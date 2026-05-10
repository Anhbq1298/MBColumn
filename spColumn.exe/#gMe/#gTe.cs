using System;
using System.Linq;
using #12e;
using #hZe;
using #X7e;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012D0 RID: 4816
	internal sealed class #gTe
	{
		// Token: 0x0600A132 RID: 41266 RVA: 0x0007E79C File Offset: 0x0007C99C
		public #gTe(#l4e #Kwe, InputModel #hMe, RuntimeModel #iMe, #dTe #P6, #38e #jMe)
		{
			this.#c = #Kwe;
			this.#b = #hMe;
			this.#f = #iMe;
			this.#a = new #QOe(#hMe, #Kwe, this.#f);
			this.#d = #P6;
			this.#e = #jMe;
		}

		// Token: 0x0600A133 RID: 41267 RVA: 0x00225DBC File Offset: 0x00223FBC
		public bool #eTe(int #MOe, int #NOe)
		{
			#f0e[] source = this.#a.#LOe(#MOe, #NOe, this.#f.FactoredLoads.NumberOfLoads);
			Options options = this.#b.Options;
			if (source.Any<#f0e>())
			{
				#f0e #f0e = source.First<#f0e>();
				if (#f0e.MessageCode != null)
				{
					this.#fTe(#f0e.MessageCode.Value, null);
				}
				return false;
			}
			if (!this.#e.#q8e(this.#b.MaterialProperties))
			{
				object[] #Pc = new object[]
				{
					this.#b.MaterialProperties.Eyt,
					this.#e.#WWi()
				};
				this.#fTe(#M6e.#a, #Pc);
				this.#c.#vzc(Message.#qn(#M6e.#a, #Pc));
				return false;
			}
			if (!#LSe.#KSe(this.#b.MaterialProperties, options.Unit))
			{
				float num = (options.Unit == #D6e.#a) ? 0.25f : 1.72375f;
				object[] #Pc2 = new object[]
				{
					this.#b.MaterialProperties.Fc,
					num,
					this.#b.MaterialProperties.Fcp
				};
				this.#c.#vzc(Message.#qn(#M6e.#b, #Pc2));
				this.#fTe(#M6e.#b, #Pc2);
				return false;
			}
			if (options.ProblemType == #z6e.#a)
			{
				if (this.#f.GeometryProperties.Ag < 0.0001f)
				{
					this.#c.#vzc(Message.#qn(#M6e.#c, Array.Empty<object>()));
					this.#fTe(#M6e.#c, null);
					return false;
				}
				if (!this.#d.#YSe())
				{
					this.#c.BarsOutsideSectionPresent = true;
					if (!this.#f.MessageBus.#b7e())
					{
						return false;
					}
				}
				if (this.#f.GeometryProperties.Rho > 8f)
				{
					bool flag = !this.#f.SilentRun;
					this.#c.#vzc(flag ? Message.#qn(#M6e.#e, Array.Empty<object>()) : Message.#ZSc(#M6e.#e, Array.Empty<object>()));
					if (!this.#f.MessageBus.#c7e())
					{
						return false;
					}
				}
				else if (this.#f.GeometryProperties.Rho < 1f)
				{
					bool flag2 = this.#f.MessageBus.#d7e();
					options.IsColumnConsideredArchitectural = flag2;
				}
			}
			else
			{
				float[] array = this.#b.DesignDimensions;
				#c6e #c6e = this.#b.DesignReinforcement;
				float num2;
				float num3;
				if (options.SectionType == #G6e.#a)
				{
					num2 = array[0] * array[1];
					num3 = array[2] * array[3];
				}
				else
				{
					num2 = array[0] * array[0] * 3.1415927f / 4f;
					num3 = array[2] * array[2] * 3.1415927f / 4f;
				}
				num2 *= this.#b.ReinforcementRatios.MinReinforcementRatio;
				num3 *= this.#b.ReinforcementRatios.MaxReinforcementRatio;
				float num4 = (float)#c6e.AmountOfBars[0];
				float num5 = (float)#c6e.AmountOfBars[1];
				if (options.ReinforcementType[1] == ReinforcementType.Different)
				{
					num4 += (float)#c6e.AmountOfBars[2];
					num5 += (float)#c6e.AmountOfBars[3];
				}
				num4 *= this.#b.Bars[#c6e.BarNumber[0]].Area;
				num5 *= this.#b.Bars[#c6e.BarNumber[1]].Area;
				if (num4 > num3)
				{
					this.#c.#vzc(Message.#qn(#M6e.#g, Array.Empty<object>()));
					this.#fTe(#M6e.#g, null);
					return false;
				}
				if (num5 < num2)
				{
					this.#c.#vzc(Message.#qn(#M6e.#f, Array.Empty<object>()));
					this.#fTe(#M6e.#f, null);
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600A134 RID: 41268 RVA: 0x0007E7DC File Offset: 0x0007C9DC
		private void #fTe(#M6e #3, object[] #Pc = null)
		{
			this.#f.MessageBus.#rne(Message.#qn(#3, #Pc), #Pc);
		}

		// Token: 0x04004678 RID: 18040
		private readonly #QOe #a;

		// Token: 0x04004679 RID: 18041
		private readonly InputModel #b;

		// Token: 0x0400467A RID: 18042
		private readonly #l4e #c;

		// Token: 0x0400467B RID: 18043
		private readonly #dTe #d;

		// Token: 0x0400467C RID: 18044
		private readonly #38e #e;

		// Token: 0x0400467D RID: 18045
		private readonly RuntimeModel #f;
	}
}
