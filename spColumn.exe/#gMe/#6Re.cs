using System;
using System.Collections.Generic;
using #g7e;
using #hZe;
using #wUe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012C8 RID: 4808
	internal sealed class #6Re
	{
		// Token: 0x0600A0EB RID: 41195 RVA: 0x0007E475 File Offset: 0x0007C675
		public #6Re(RuntimeModel #iMe)
		{
			this.#a = #iMe;
		}

		// Token: 0x17002E51 RID: 11857
		// (get) Token: 0x0600A0EC RID: 41196 RVA: 0x0007E48F File Offset: 0x0007C68F
		private #YZe BalancedCondition
		{
			get
			{
				return this.#a.BalancedCondition;
			}
		}

		// Token: 0x17002E52 RID: 11858
		// (get) Token: 0x0600A0ED RID: 41197 RVA: 0x0007E49C File Offset: 0x0007C69C
		private #YZe MaxCompression
		{
			get
			{
				return this.#a.MaxCompression;
			}
		}

		// Token: 0x17002E53 RID: 11859
		// (get) Token: 0x0600A0EE RID: 41198 RVA: 0x0007E4A9 File Offset: 0x0007C6A9
		private #YZe MaxTension
		{
			get
			{
				return this.#a.MaxTension;
			}
		}

		// Token: 0x17002E54 RID: 11860
		// (get) Token: 0x0600A0EF RID: 41199 RVA: 0x0007E4B6 File Offset: 0x0007C6B6
		private #YZe YieldSteelStrengthFyEqualToHalf
		{
			get
			{
				return this.#a.YieldSteelStrengthFyEqualToHalf;
			}
		}

		// Token: 0x17002E55 RID: 11861
		// (get) Token: 0x0600A0F0 RID: 41200 RVA: 0x0007E4C3 File Offset: 0x0007C6C3
		private #YZe YieldSteelStrengthFyEqualToZero
		{
			get
			{
				return this.#a.YieldSteelStrengthFyEqualToZero;
			}
		}

		// Token: 0x17002E56 RID: 11862
		// (get) Token: 0x0600A0F1 RID: 41201 RVA: 0x0007E4D0 File Offset: 0x0007C6D0
		private #YZe ZeroCompression
		{
			get
			{
				return this.#a.ZeroCompression;
			}
		}

		// Token: 0x17002E57 RID: 11863
		// (get) Token: 0x0600A0F2 RID: 41202 RVA: 0x0007E4DD File Offset: 0x0007C6DD
		private #nW MessageBus
		{
			get
			{
				return this.#a.MessageBus;
			}
		}

		// Token: 0x0600A0F3 RID: 41203 RVA: 0x0007E4EA File Offset: 0x0007C6EA
		public #r1e #bpb(float #ivb, Func<float, #D2e> #SPe, int #MOe)
		{
			return this.#bpb(#ivb, #SPe, #MOe, new #fSe());
		}

		// Token: 0x0600A0F4 RID: 41204 RVA: 0x002243F0 File Offset: 0x002225F0
		public #r1e #bpb(float #ivb, Func<float, #D2e> #SPe, int #MOe, #fSe #VRe)
		{
			if (#MOe > 0)
			{
				if (#ivb >= this.MaxCompression.AxialLoad)
				{
					return this.#5Re(#SPe);
				}
				if (#ivb <= this.MaxTension.AxialLoad)
				{
					return this.#4Re(#SPe);
				}
				this.#2Re(#VRe, #ivb);
			}
			return this.#3Re(#ivb, #SPe, #VRe);
		}

		// Token: 0x0600A0F5 RID: 41205 RVA: 0x00224440 File Offset: 0x00222640
		private static #r1e #WRe(Func<float, #D2e> #SPe, float #uYb)
		{
			#D2e #D2e = #SPe(#uYb);
			return new #r1e(#D2e.MaxSteelStrain, #uYb, #D2e.ColumnLoad);
		}

		// Token: 0x0600A0F6 RID: 41206 RVA: 0x0007E4FA File Offset: 0x0007C6FA
		private static float #XRe(float #YRe, float #ZRe, float #0Re, float #1Re, float #7W)
		{
			if ((double)#xke.#hke(#1Re - #ZRe) > 1E-30)
			{
				return #YRe + (#0Re - #YRe) * (#7W - #ZRe) / (#1Re - #ZRe);
			}
			return (#YRe + #0Re) / 2f;
		}

		// Token: 0x0600A0F7 RID: 41207 RVA: 0x0022446C File Offset: 0x0022266C
		private void #2Re(#fSe #Pc, float #ivb)
		{
			if (#ivb <= this.ZeroCompression.AxialLoad)
			{
				#Pc.Cl = this.ZeroCompression.DepthOfNeutralAxis;
				#Pc.Pl = this.ZeroCompression.AxialLoad;
				#Pc.Cs = this.MaxTension.DepthOfNeutralAxis;
				#Pc.Ps = this.MaxTension.AxialLoad;
				return;
			}
			if (#ivb <= this.BalancedCondition.AxialLoad)
			{
				#Pc.Cl = this.BalancedCondition.DepthOfNeutralAxis;
				#Pc.Pl = this.BalancedCondition.AxialLoad;
				#Pc.Cs = this.ZeroCompression.DepthOfNeutralAxis;
				#Pc.Ps = this.ZeroCompression.AxialLoad;
				return;
			}
			if (#ivb <= this.YieldSteelStrengthFyEqualToHalf.AxialLoad)
			{
				#Pc.Cl = this.YieldSteelStrengthFyEqualToHalf.DepthOfNeutralAxis;
				#Pc.Pl = this.YieldSteelStrengthFyEqualToHalf.AxialLoad;
				#Pc.Cs = this.BalancedCondition.DepthOfNeutralAxis;
				#Pc.Ps = this.BalancedCondition.AxialLoad;
				return;
			}
			if (#ivb <= this.YieldSteelStrengthFyEqualToZero.AxialLoad)
			{
				#Pc.Cl = this.YieldSteelStrengthFyEqualToZero.DepthOfNeutralAxis;
				#Pc.Pl = this.YieldSteelStrengthFyEqualToZero.AxialLoad;
				#Pc.Cs = this.YieldSteelStrengthFyEqualToHalf.DepthOfNeutralAxis;
				#Pc.Ps = this.YieldSteelStrengthFyEqualToHalf.AxialLoad;
				return;
			}
			#Pc.Cl = this.MaxCompression.DepthOfNeutralAxis;
			#Pc.Pl = this.MaxCompression.AxialLoad;
			#Pc.Cs = this.YieldSteelStrengthFyEqualToZero.DepthOfNeutralAxis;
			#Pc.Ps = this.YieldSteelStrengthFyEqualToZero.AxialLoad;
		}

		// Token: 0x0600A0F8 RID: 41208 RVA: 0x0022460C File Offset: 0x0022280C
		private #r1e #3Re(float #ivb, Func<float, #D2e> #SPe, #fSe #Pc)
		{
			#D2e #D2e = #D2e.Empty;
			float num = 0f;
			float num2 = #xke.#ske(0.05f, 1E-05f * #xke.#hke(#ivb));
			for (int i = 0; i < 100; i++)
			{
				num = #6Re.#XRe(#Pc.Cs, #Pc.Ps, #Pc.Cl, #Pc.Pl, #ivb);
				#D2e = #SPe(num);
				if (#xke.#hke(#D2e.ColumnLoad.AxialLoad - #ivb) < num2)
				{
					return new #r1e(#D2e.MaxSteelStrain, num, #D2e.ColumnLoad);
				}
				if (#D2e.ColumnLoad.AxialLoad < #ivb)
				{
					#Pc.Cs = num;
					#Pc.Ps = #D2e.ColumnLoad.AxialLoad;
				}
				else
				{
					#Pc.Cl = num;
					#Pc.Pl = #D2e.ColumnLoad.AxialLoad;
				}
			}
			num2 = #xke.#ske(0.05f, 1E-06f * #xke.#hke(this.MaxCompression.AxialLoad - this.MaxTension.AxialLoad));
			for (int j = 0; j < 200; j++)
			{
				num = #6Re.#XRe(#Pc.Cs, #Pc.Ps, #Pc.Cl, #Pc.Pl, #ivb);
				#D2e = #SPe(num);
				if (#xke.#hke(#D2e.ColumnLoad.AxialLoad - #ivb) < num2)
				{
					return new #r1e(#D2e.MaxSteelStrain, num, #D2e.ColumnLoad);
				}
				if (#D2e.ColumnLoad.AxialLoad < #ivb)
				{
					#Pc.Cs = num;
					#Pc.Ps = #D2e.ColumnLoad.AxialLoad;
				}
				else
				{
					#Pc.Cl = num;
					#Pc.Pl = #D2e.ColumnLoad.AxialLoad;
				}
			}
			if (!this.#b.Contains(#ivb))
			{
				this.#b.Add(#ivb);
				this.MessageBus.#rne(Message.#ZSc(#M6e.#y, new object[]
				{
					#ivb
				}), new object[]
				{
					#ivb
				});
			}
			return new #r1e(#D2e.MaxSteelStrain, num, #D2e.ColumnLoad);
		}

		// Token: 0x0600A0F9 RID: 41209 RVA: 0x0007E528 File Offset: 0x0007C728
		private #r1e #4Re(Func<float, #D2e> #SPe)
		{
			return #6Re.#WRe(#SPe, this.MaxTension.DepthOfNeutralAxis);
		}

		// Token: 0x0600A0FA RID: 41210 RVA: 0x0007E53B File Offset: 0x0007C73B
		private #r1e #5Re(Func<float, #D2e> #SPe)
		{
			return #6Re.#WRe(#SPe, this.MaxCompression.DepthOfNeutralAxis);
		}

		// Token: 0x04004666 RID: 18022
		private readonly RuntimeModel #a;

		// Token: 0x04004667 RID: 18023
		private readonly HashSet<float> #b = new HashSet<float>();
	}
}
