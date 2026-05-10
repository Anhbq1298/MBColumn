using System;
using #12e;
using #hZe;
using #wUe;
using #X7e;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012BB RID: 4795
	internal sealed class #jQe
	{
		// Token: 0x0600A07E RID: 41086 RVA: 0x0007DFB3 File Offset: 0x0007C1B3
		public #jQe(InputModel #hMe, RuntimeModel #iMe, #38e #jMe)
		{
			this.#c = #hMe;
			this.#e = #iMe;
			this.#f = #jMe;
			this.#b = new #5Ne(#hMe, #jMe);
			this.#d = new #GPe(#iMe, #hMe);
		}

		// Token: 0x17002E32 RID: 11826
		// (get) Token: 0x0600A07F RID: 41087 RVA: 0x0007DFEA File Offset: 0x0007C1EA
		// (set) Token: 0x0600A080 RID: 41088 RVA: 0x0007DFF7 File Offset: 0x0007C1F7
		public #s5e SlendernessX
		{
			get
			{
				return this.#e.SlendernessX;
			}
			private set
			{
				this.#e.SlendernessX = value;
			}
		}

		// Token: 0x17002E33 RID: 11827
		// (get) Token: 0x0600A081 RID: 41089 RVA: 0x0007E005 File Offset: 0x0007C205
		// (set) Token: 0x0600A082 RID: 41090 RVA: 0x0007E012 File Offset: 0x0007C212
		public #s5e SlendernessY
		{
			get
			{
				return this.#e.SlendernessY;
			}
			private set
			{
				this.#e.SlendernessY = value;
			}
		}

		// Token: 0x17002E34 RID: 11828
		// (get) Token: 0x0600A083 RID: 41091 RVA: 0x0007E020 File Offset: 0x0007C220
		private float StiffnessReductionFactorPhi
		{
			get
			{
				return this.#c.StiffnessReductionFactorPhi;
			}
		}

		// Token: 0x17002E35 RID: 11829
		// (get) Token: 0x0600A084 RID: 41092 RVA: 0x0007E02D File Offset: 0x0007C22D
		// (set) Token: 0x0600A085 RID: 41093 RVA: 0x0007E03A File Offset: 0x0007C23A
		private float StiffnessX
		{
			get
			{
				return this.#e.StiffnessX;
			}
			set
			{
				this.#e.StiffnessX = value;
			}
		}

		// Token: 0x17002E36 RID: 11830
		// (get) Token: 0x0600A086 RID: 41094 RVA: 0x0007E048 File Offset: 0x0007C248
		// (set) Token: 0x0600A087 RID: 41095 RVA: 0x0007E055 File Offset: 0x0007C255
		private float StiffnessY
		{
			get
			{
				return this.#e.StiffnessY;
			}
			set
			{
				this.#e.StiffnessY = value;
			}
		}

		// Token: 0x17002E37 RID: 11831
		// (get) Token: 0x0600A088 RID: 41096 RVA: 0x0007E063 File Offset: 0x0007C263
		private float[][] LoadFactors
		{
			get
			{
				return this.#c.LoadFactors;
			}
		}

		// Token: 0x17002E38 RID: 11832
		// (get) Token: 0x0600A089 RID: 41097 RVA: 0x0007E070 File Offset: 0x0007C270
		private float[][] ServiceLoads
		{
			get
			{
				return this.#c.ServiceLoads;
			}
		}

		// Token: 0x17002E39 RID: 11833
		// (get) Token: 0x0600A08A RID: 41098 RVA: 0x0007E07D File Offset: 0x0007C27D
		private #3Ze Depth
		{
			get
			{
				return this.#e.Depth;
			}
		}

		// Token: 0x17002E3A RID: 11834
		// (get) Token: 0x0600A08B RID: 41099 RVA: 0x0007E08A File Offset: 0x0007C28A
		private #b0e FactoredLoads
		{
			get
			{
				return this.#e.FactoredLoads;
			}
		}

		// Token: 0x17002E3B RID: 11835
		// (get) Token: 0x0600A08C RID: 41100 RVA: 0x0007E097 File Offset: 0x0007C297
		private #x0e GeometryProperties
		{
			get
			{
				return this.#e.GeometryProperties;
			}
		}

		// Token: 0x17002E3C RID: 11836
		// (get) Token: 0x0600A08D RID: 41101 RVA: 0x0007E0A4 File Offset: 0x0007C2A4
		private Options Options
		{
			get
			{
				return this.#c.Options;
			}
		}

		// Token: 0x17002E3D RID: 11837
		// (get) Token: 0x0600A08E RID: 41102 RVA: 0x0007E0B1 File Offset: 0x0007C2B1
		private #K1e ReinforcementBars
		{
			get
			{
				return this.#e.ReinforcementBars;
			}
		}

		// Token: 0x17002E3E RID: 11838
		// (get) Token: 0x0600A08F RID: 41103 RVA: 0x0007E0BE File Offset: 0x0007C2BE
		private #X3 DesignedColumnX
		{
			get
			{
				return this.#c.DesignedColumnX;
			}
		}

		// Token: 0x17002E3F RID: 11839
		// (get) Token: 0x0600A090 RID: 41104 RVA: 0x0007E0CB File Offset: 0x0007C2CB
		private #X3 DesignedColumnY
		{
			get
			{
				return this.#c.DesignedColumnY;
			}
		}

		// Token: 0x17002E40 RID: 11840
		// (get) Token: 0x0600A091 RID: 41105 RVA: 0x0007E0D8 File Offset: 0x0007C2D8
		private #Lce[][] SlendernessFactors
		{
			get
			{
				return this.#e.SlendernessFactors;
			}
		}

		// Token: 0x0600A092 RID: 41106 RVA: 0x00222E14 File Offset: 0x00221014
		public #L6e #1Pe()
		{
			#L6e #L6e = #L6e.#a;
			if (this.#bQe())
			{
				return #L6e.#a;
			}
			if (this.Options.ShouldConsiderSlenderness)
			{
				this.#uOe();
			}
			this.FactoredLoads.NumberOfLoads = 0;
			int num = 0;
			for (int i = 0; i < this.Options.NumberOfServiceLoads; i++)
			{
				for (int j = 0; j < this.Options.NumberOfLoadCombinations; j++)
				{
					float #ivb = #dOe.#cOe(this.LoadFactors[j], this.ServiceLoads[i]);
					#L6e |= this.#6Pe(j, i, num, #ivb);
					if (this.Options.ShouldConsiderSlenderness)
					{
						num = this.#8Pe(i, j, num, #ivb);
					}
				}
				if (!this.Options.ShouldConsiderSlenderness)
				{
					num += 2 * this.Options.NumberOfLoadCombinations;
				}
			}
			this.FactoredLoads.NumberOfLoads = num;
			return #L6e;
		}

		// Token: 0x0600A093 RID: 41107 RVA: 0x00222EE8 File Offset: 0x002210E8
		private int #2Pe(int #Kpb, int #Lpb, int #1f, float #ivb, #Lce[] #jdd)
		{
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc[#Lpb][0], #jdd[1].Mc0[#Lpb][0], #Kpb, #Lpb);
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc0[#Lpb][0], #jdd[1].Mc[#Lpb][0], #Kpb, #Lpb);
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc[#Lpb][1], #jdd[1].Mc0[#Lpb][1], #Kpb, #Lpb);
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc0[#Lpb][1], #jdd[1].Mc[#Lpb][1], #Kpb, #Lpb);
			return #1f;
		}

		// Token: 0x0600A094 RID: 41108 RVA: 0x00222FB4 File Offset: 0x002211B4
		private int #3Pe(int #Kpb, int #Lpb, int #1f, float #ivb, #Lce[] #jdd)
		{
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc[#Lpb][0], #jdd[1].Mc0[#Lpb][0], #Kpb, #Lpb);
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc0[#Lpb][0], #jdd[1].Mc[#Lpb][0], #Kpb, #Lpb);
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc[#Lpb][1], #jdd[1].Mc[#Lpb][1], #Kpb, #Lpb);
			return #1f;
		}

		// Token: 0x0600A095 RID: 41109 RVA: 0x00223050 File Offset: 0x00221250
		private int #4Pe(int #Kpb, int #Lpb, int #1f, float #ivb, #Lce[] #jdd)
		{
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc[#Lpb][0], #jdd[1].Mc[#Lpb][0], #Kpb, #Lpb);
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc[#Lpb][1], #jdd[1].Mc0[#Lpb][1], #Kpb, #Lpb);
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc0[#Lpb][1], #jdd[1].Mc[#Lpb][1], #Kpb, #Lpb);
			return #1f;
		}

		// Token: 0x0600A096 RID: 41110 RVA: 0x002230EC File Offset: 0x002212EC
		private int #5Pe(int #Kpb, int #Lpb, int #1f, float #ivb, #Lce[] #jdd)
		{
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc[#Lpb][0], #jdd[1].Mc[#Lpb][0], #Kpb, #Lpb);
			this.FactoredLoads.#8Pe(#1f++, #ivb, #jdd[0].Mc[#Lpb][1], #jdd[1].Mc[#Lpb][1], #Kpb, #Lpb);
			return #1f;
		}

		// Token: 0x0600A097 RID: 41111 RVA: 0x00223158 File Offset: 0x00221358
		private #L6e #6Pe(int #Lpb, int #Kpb, int #1f, float #ivb)
		{
			if (this.Options.ConsideredAxis != #C6e.#c)
			{
				return this.#7Pe((int)this.Options.ConsideredAxis, #Lpb, #Kpb, #1f, #ivb);
			}
			#L6e result = this.#7Pe(0, #Lpb, #Kpb, #1f, #ivb) | this.#7Pe(1, #Lpb, #Kpb, #1f, #ivb);
			#LQe.#mQe(#Lpb, this.SlendernessFactors[#Kpb], this.#f);
			return result;
		}

		// Token: 0x0600A098 RID: 41112 RVA: 0x002231B8 File Offset: 0x002213B8
		private #L6e #7Pe(int #6gb, int #Lpb, int #Kpb, int #1f, float #ivb)
		{
			#L6e #L6e = #L6e.#a;
			float num = #LQe.#kQe(#6gb, 0, false, this.LoadFactors[#Lpb], this.ServiceLoads[#Kpb]);
			float num2 = #LQe.#kQe(#6gb, 0, true, this.LoadFactors[#Lpb], this.ServiceLoads[#Kpb]);
			float num3 = num + num2;
			float num4 = #LQe.#kQe(#6gb, 1, false, this.LoadFactors[#Lpb], this.ServiceLoads[#Kpb]);
			float num5 = #LQe.#kQe(#6gb, 1, true, this.LoadFactors[#Lpb], this.ServiceLoads[#Kpb]);
			float num6 = num4 + num5;
			if (!this.Options.ShouldConsiderSlenderness)
			{
				int #sP = #1f + 2 * #Lpb;
				this.FactoredLoads.#8Pe(#sP, #6gb, #ivb, num3, num6, this.Options.ConsideredAxis);
			}
			else
			{
				float #4Ne = this.#iQe(#6gb);
				float #vQe = this.#hQe(#6gb);
				#X3 #X = this.#gQe(#6gb);
				float #wQe = this.#dQe(#6gb);
				this.#b.#ZNe(#Lpb, this.SlendernessFactors[#Kpb][#6gb], this.LoadFactors[#Lpb], this.ServiceLoads[#Kpb], #X, #4Ne);
				int num7 = #LQe.#rQe(#ivb, num3, num6, #X.IsBraced, #vQe, this.#c, this.#e, this.#f, #wQe);
				if (num7 == 32)
				{
					#L6e |= #L6e.#f;
				}
				this.SlendernessFactors[#Kpb][#6gb].Flags[#Lpb] = 0;
				if (!this.#fQe(#ivb, #Kpb, #6gb, #Lpb, #X))
				{
					return #L6e | this.#eQe(#Kpb, #6gb, #Lpb, #ivb);
				}
				#vRe.#6Qe(num7, #ivb, num, num4, num2, num5, this.#dQe(#6gb), #Lpb, this.SlendernessFactors[#Kpb][#6gb], this.GeometryProperties.SecondMomentOfInertia[#6gb], #X, this.#c, this.#f);
				if (!#xke.#U3(this.SlendernessFactors[#Kpb][#6gb].Flags[#Lpb] & 4096))
				{
					return #L6e;
				}
				#L6e |= this.#cQe(#X, #Lpb, #Kpb, #6gb);
			}
			return #L6e;
		}

		// Token: 0x0600A099 RID: 41113 RVA: 0x00223390 File Offset: 0x00221590
		private int #8Pe(int #Kpb, int #Lpb, int #1f, float #ivb)
		{
			bool flag = this.#aQe(#Kpb, #Lpb);
			bool flag2 = this.#9Pe(#Kpb, #Lpb);
			#Lce[] #jdd = this.SlendernessFactors[#Kpb];
			if (flag && flag2)
			{
				return this.#2Pe(#Kpb, #Lpb, #1f, #ivb, #jdd);
			}
			if (flag)
			{
				return this.#3Pe(#Kpb, #Lpb, #1f, #ivb, #jdd);
			}
			if (flag2)
			{
				return this.#4Pe(#Kpb, #Lpb, #1f, #ivb, #jdd);
			}
			return this.#5Pe(#Kpb, #Lpb, #1f, #ivb, #jdd);
		}

		// Token: 0x0600A09A RID: 41114 RVA: 0x0007E0E5 File Offset: 0x0007C2E5
		private bool #9Pe(int #Kpb, int #Lpb)
		{
			return (this.SlendernessFactors[#Kpb][0].EndFlags[#Lpb][1] & 32768) == 32768;
		}

		// Token: 0x0600A09B RID: 41115 RVA: 0x0007E107 File Offset: 0x0007C307
		private bool #aQe(int #Kpb, int #Lpb)
		{
			return (this.SlendernessFactors[#Kpb][0].EndFlags[#Lpb][0] & 32768) == 32768;
		}

		// Token: 0x0600A09C RID: 41116 RVA: 0x0007E129 File Offset: 0x0007C329
		private bool #bQe()
		{
			return this.Options.Loads[(int)this.Options.ProblemType] != Load.Service;
		}

		// Token: 0x0600A09D RID: 41117 RVA: 0x002233F8 File Offset: 0x002215F8
		internal void #uOe()
		{
			this.SlendernessX.#mg(this.#d.#vPe());
			this.StiffnessX = #LQe.#GQe(this.GeometryProperties.SecondMomentOfInertia[0], true, this.GeometryProperties.Ybar[1], this.ReinforcementBars, this.#c);
			this.#g = #LQe.#zQe(this.Options.Unit, this.Depth.OfConcrete[0]);
			this.SlendernessX.MinEccentricy = this.#g;
			this.SlendernessX.MinEccentricyInModelUnit = this.#g * ((this.#c.Options.Unit == #D6e.#a) ? 12f : 1000f);
			this.SlendernessX.Stiffness = this.StiffnessX;
			this.SlendernessY.#mg(this.#d.#wPe());
			this.StiffnessY = #LQe.#GQe(this.GeometryProperties.SecondMomentOfInertia[1], false, this.GeometryProperties.Ybar[0], this.ReinforcementBars, this.#c);
			this.#h = #LQe.#zQe(this.Options.Unit, this.Depth.OfConcrete[1]);
			this.SlendernessY.MinEccentricy = this.#h;
			this.SlendernessY.MinEccentricyInModelUnit = this.#h * ((this.#c.Options.Unit == #D6e.#a) ? 12f : 1000f);
			this.SlendernessY.Stiffness = this.StiffnessY;
		}

		// Token: 0x0600A09E RID: 41118 RVA: 0x00223580 File Offset: 0x00221780
		private #L6e #cQe(#X3 #U6, int #Lpb, int #Kpb, int #6gb)
		{
			#L6e #L6e = #LQe.#cQe(#U6.IsBraced, this.LoadFactors[#Lpb], this.SlendernessFactors[#Kpb][#6gb].DeltaS[#Lpb], this.#f);
			#L6e |= #NRe.#KRe(this.SlendernessFactors[#Kpb][#6gb].EndFlags[#Lpb]);
			this.SlendernessFactors[#Kpb][#6gb].Flags[#Lpb] |= (int)#L6e;
			return #L6e;
		}

		// Token: 0x0600A09F RID: 41119 RVA: 0x0007E148 File Offset: 0x0007C348
		private float #dQe(int #6gb)
		{
			if (#6gb != 0)
			{
				return this.#h;
			}
			return this.#g;
		}

		// Token: 0x0600A0A0 RID: 41120 RVA: 0x002235F0 File Offset: 0x002217F0
		private #L6e #eQe(int #Kpb, int #6gb, int #Lpb, float #QEe)
		{
			this.SlendernessFactors[#Kpb][#6gb].UltimateAxialLoad[#Lpb] = #QEe;
			this.SlendernessFactors[#Kpb][#6gb].DeltaB[#Lpb] = 99.999f;
			this.SlendernessFactors[#Kpb][#6gb].DeltaS[#Lpb] = 99.999f;
			this.SlendernessFactors[#Kpb][#6gb].Flags[#Lpb] |= 16;
			return #L6e.#e;
		}

		// Token: 0x0600A0A1 RID: 41121 RVA: 0x0022365C File Offset: 0x0022185C
		private bool #fQe(float #fC, int #Kpb, int #6gb, int #Lpb, #X3 #U6)
		{
			return #LQe.#fQe(#fC, this.StiffnessReductionFactorPhi, this.SlendernessFactors[#Kpb][#6gb].Pcb[#Lpb], #U6.IsBraced, #U6.SumPu, #U6.SumPc, this.SlendernessFactors[#Kpb][#6gb].Pcs[#Lpb]);
		}

		// Token: 0x0600A0A2 RID: 41122 RVA: 0x0007E15A File Offset: 0x0007C35A
		private #X3 #gQe(int #6gb)
		{
			if (#6gb != 0)
			{
				return this.DesignedColumnY;
			}
			return this.DesignedColumnX;
		}

		// Token: 0x0600A0A3 RID: 41123 RVA: 0x0007E16C File Offset: 0x0007C36C
		private float #hQe(int #6gb)
		{
			if (#6gb != 0)
			{
				return this.SlendernessY.Klur;
			}
			return this.SlendernessX.Klur;
		}

		// Token: 0x0600A0A4 RID: 41124 RVA: 0x0007E188 File Offset: 0x0007C388
		private float #iQe(int #6gb)
		{
			if (#6gb != 0)
			{
				return this.StiffnessY;
			}
			return this.StiffnessX;
		}

		// Token: 0x04004640 RID: 17984
		private const short #a = 0;

		// Token: 0x04004641 RID: 17985
		private readonly #5Ne #b;

		// Token: 0x04004642 RID: 17986
		private readonly InputModel #c;

		// Token: 0x04004643 RID: 17987
		private readonly #GPe #d;

		// Token: 0x04004644 RID: 17988
		private readonly RuntimeModel #e;

		// Token: 0x04004645 RID: 17989
		private readonly #38e #f;

		// Token: 0x04004646 RID: 17990
		private float #g;

		// Token: 0x04004647 RID: 17991
		private float #h;
	}
}
