using System;
using System.Runtime.CompilerServices;
using #12e;
using #g7e;
using #gMe;
using #hZe;
using #wUe;
using #X7e;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #7Xe
{
	// Token: 0x0200130B RID: 4875
	internal abstract class #iYe
	{
		// Token: 0x0600A2E4 RID: 41700 RVA: 0x0007F547 File Offset: 0x0007D747
		protected #iYe(#l4e #Kwe, InputModel #hMe, RuntimeModel #iMe, #3Qe #IXe, CriticalCapacity #XMe, #fNe #xMe, #38e #jMe)
		{
			this.OutputModel = #Kwe;
			this.InputModel = #hMe;
			this.RuntimeModel = #iMe;
			this.MomentCapacityEx = #IXe;
			this.CompressionAndTension = #xMe;
			this.CodeExpert = #jMe;
			this.CriticalCapacity = #XMe;
		}

		// Token: 0x17002EB6 RID: 11958
		// (get) Token: 0x0600A2E5 RID: 41701 RVA: 0x0007F584 File Offset: 0x0007D784
		// (set) Token: 0x0600A2E6 RID: 41702 RVA: 0x0007F58C File Offset: 0x0007D78C
		private #fNe CompressionAndTension { get; set; }

		// Token: 0x17002EB7 RID: 11959
		// (get) Token: 0x0600A2E7 RID: 41703 RVA: 0x0007F595 File Offset: 0x0007D795
		// (set) Token: 0x0600A2E8 RID: 41704 RVA: 0x0007F59D File Offset: 0x0007D79D
		private InputModel InputModel { get; set; }

		// Token: 0x17002EB8 RID: 11960
		// (get) Token: 0x0600A2E9 RID: 41705 RVA: 0x0007F5A6 File Offset: 0x0007D7A6
		// (set) Token: 0x0600A2EA RID: 41706 RVA: 0x0007F5AE File Offset: 0x0007D7AE
		private #3Qe MomentCapacityEx { get; set; }

		// Token: 0x17002EB9 RID: 11961
		// (get) Token: 0x0600A2EB RID: 41707 RVA: 0x0007F5B7 File Offset: 0x0007D7B7
		private #K2 MaterialProperties
		{
			get
			{
				return this.InputModel.MaterialProperties;
			}
		}

		// Token: 0x17002EBA RID: 11962
		// (get) Token: 0x0600A2EC RID: 41708 RVA: 0x0007F5C4 File Offset: 0x0007D7C4
		private #Fce ReductionFactors
		{
			get
			{
				return this.RuntimeModel.ReductionFactors;
			}
		}

		// Token: 0x17002EBB RID: 11963
		// (get) Token: 0x0600A2ED RID: 41709 RVA: 0x0007F5D1 File Offset: 0x0007D7D1
		// (set) Token: 0x0600A2EE RID: 41710 RVA: 0x0007F5D9 File Offset: 0x0007D7D9
		private protected #l4e OutputModel { protected get; private set; }

		// Token: 0x17002EBC RID: 11964
		// (get) Token: 0x0600A2EF RID: 41711 RVA: 0x0007F5E2 File Offset: 0x0007D7E2
		// (set) Token: 0x0600A2F0 RID: 41712 RVA: 0x0007F5EA File Offset: 0x0007D7EA
		private protected RuntimeModel RuntimeModel { protected get; private set; }

		// Token: 0x17002EBD RID: 11965
		// (get) Token: 0x0600A2F1 RID: 41713 RVA: 0x0007F5F3 File Offset: 0x0007D7F3
		protected Options Options
		{
			get
			{
				return this.InputModel.Options;
			}
		}

		// Token: 0x17002EBE RID: 11966
		// (get) Token: 0x0600A2F2 RID: 41714 RVA: 0x0007F600 File Offset: 0x0007D800
		// (set) Token: 0x0600A2F3 RID: 41715 RVA: 0x0007F608 File Offset: 0x0007D808
		private protected #38e CodeExpert { protected get; private set; }

		// Token: 0x17002EBF RID: 11967
		// (get) Token: 0x0600A2F4 RID: 41716 RVA: 0x0007F611 File Offset: 0x0007D811
		// (set) Token: 0x0600A2F5 RID: 41717 RVA: 0x0007F619 File Offset: 0x0007D819
		private protected CriticalCapacity CriticalCapacity { protected get; private set; }

		// Token: 0x0600A2F6 RID: 41718
		protected abstract #iYe.#hif #ZXe(#S0e #WXe, #iYe.#lif #Ptb, #u3e.#zif #XXe, #iYe.#hif #YXe);

		// Token: 0x0600A2F7 RID: 41719
		protected abstract #iYe.#hif #VXe(#S0e #WXe, #iYe.#lif #Ptb, #u3e.#zif #XXe, #iYe.#hif #YXe);

		// Token: 0x0600A2F8 RID: 41720
		protected abstract bool #UXe(int #Kpb);

		// Token: 0x0600A2F9 RID: 41721
		protected abstract void #TXe(#iYe.#lif #Ptb);

		// Token: 0x0600A2FA RID: 41722 RVA: 0x0022D068 File Offset: 0x0022B268
		public void #sWe()
		{
			#iYe.#hif #hif = this.#hYe();
			if (#hif.PrintFootNote)
			{
				Message # = Message.#qn(#M6e.#h, Array.Empty<object>());
				this.OutputModel.#vzc(#);
				this.RuntimeModel.MessageBus.#rne(#, null);
			}
			if (#hif.PrintMaxAxialLoad)
			{
				float value = this.RuntimeModel.ReductionFactors.#E1e(this.InputModel, this.RuntimeModel, this.CodeExpert) * this.RuntimeModel.AxialLoads.Maximum;
				this.OutputModel.Variables.Pmax = new float?(value);
			}
			if (#hif.PrintMinAxialLoad)
			{
				this.OutputModel.Variables.Pmin = new float?(this.RuntimeModel.AxialLoads.Minimum);
			}
		}

		// Token: 0x0600A2FB RID: 41723 RVA: 0x0007F622 File Offset: 0x0007D822
		protected #u3e.#zif #cYe(#S0e #WXe, #iYe.#hif #YXe)
		{
			if (this.#qTe(#WXe.Success, #WXe.UltimateSafeFactor))
			{
				#YXe.PrintFootNote = true;
				return #u3e.#zif.#b;
			}
			return #u3e.#zif.#a;
		}

		// Token: 0x0600A2FC RID: 41724 RVA: 0x0007F642 File Offset: 0x0007D842
		protected float? #dYe(float #eYe)
		{
			return this.CodeExpert.#s8e(#eYe, this.MaterialProperties.Eyt, this.ReductionFactors.B, this.ReductionFactors.C);
		}

		// Token: 0x0600A2FD RID: 41725 RVA: 0x0007F671 File Offset: 0x0007D871
		private bool #qTe(bool #hW, float #rTe)
		{
			return #ZLe.#qTe(#hW, #rTe, this.InputModel.Options.ProblemType, this.InputModel.DesignToRequiredRatio);
		}

		// Token: 0x0600A2FE RID: 41726 RVA: 0x0022D12C File Offset: 0x0022B32C
		private #S0e #fYe(#VMe #gYe, #S0e #WXe, LoadsExt #ivb, #y0e #Jte)
		{
			if (#WXe == null)
			{
				return #gYe.#bpb(#Jte, this.InputModel.Options.CapacityCalculationType, #ivb, 0f, 0f, 0f);
			}
			return #gYe.#bpb(#Jte, this.InputModel.Options.CapacityCalculationType, #ivb, #WXe.BarMaximumStrain, #WXe.NeutralAxisDepth, #WXe.TensionDistance);
		}

		// Token: 0x0600A2FF RID: 41727 RVA: 0x0022D190 File Offset: 0x0022B390
		private #iYe.#hif #hYe()
		{
			#iYe.#hif #hif = new #iYe.#hif();
			#S0e #WXe = null;
			#vZe #uZe = this.CompressionAndTension.#bpb();
			this.RuntimeModel.AxialLoads.#tZe(#uZe);
			int num = 0;
			#VMe #VMe = new #VMe(this.MomentCapacityEx, this.CriticalCapacity);
			#y0e #y0e = null;
			#x6e #TMe = this.InputModel.Options.CapacityCalculationType;
			LoadsExt[] array = this.RuntimeModel.FactoredLoads.Loads;
			#iYe.#lif #lif = new #iYe.#lif();
			while (#lif.LoadIndex < this.RuntimeModel.FactoredLoads.NumberOfLoads)
			{
				if (this.Options.ProblemType == #z6e.#a || !this.RuntimeModel.RunFlag.HasFlag(#J6e.#a))
				{
					this.RuntimeModel.MessageBus.#76e(#q7e.#Mif.#c, #lif.LoadIndex + 1, this.RuntimeModel.FactoredLoads.NumberOfLoads);
				}
				#y0e = (#y0e ?? #VMe.#YJe(#TMe));
				#WXe = this.#fYe(#VMe, #WXe, array[#lif.LoadIndex], #y0e);
				LoadsExt loadsExt = array[#lif.LoadIndex];
				#VMe.#MWi(this.RuntimeModel.FactoredInteractionDiagram, (double)loadsExt.MomentX, (double)loadsExt.MomentY);
				#u3e.#zif #XXe = this.#cYe(#WXe, #hif);
				int num2;
				if (this.#UXe(#lif.LoadIndex))
				{
					if (#xke.#U3(num))
					{
						num = this.Options.NumberOfLoadCombinations;
						#iYe.#lif #lif2 = #lif;
						num2 = #lif2.ServiceLoadIndex;
						#lif2.ServiceLoadIndex = num2 + 1;
						#lif.CombinationIndex = 0;
					}
					#iYe.#lif #lif3 = #lif;
					num2 = #lif3.CombinationIndex;
					#lif3.CombinationIndex = num2 + 1;
					num--;
					this.#TXe(#lif);
					#hif = this.#VXe(#WXe, #lif, #XXe, #hif);
				}
				else
				{
					#hif = this.#ZXe(#WXe, #lif, #XXe, #hif);
				}
				#iYe.#lif #lif4 = #lif;
				num2 = #lif4.LoadIndex;
				#lif4.LoadIndex = num2 + 1;
			}
			return #hif;
		}

		// Token: 0x04004763 RID: 18275
		protected const int #a = 2;

		// Token: 0x04004764 RID: 18276
		[CompilerGenerated]
		private #fNe #b;

		// Token: 0x04004765 RID: 18277
		[CompilerGenerated]
		private InputModel #c;

		// Token: 0x04004766 RID: 18278
		[CompilerGenerated]
		private #3Qe #d;

		// Token: 0x04004767 RID: 18279
		[CompilerGenerated]
		private #l4e #e;

		// Token: 0x04004768 RID: 18280
		[CompilerGenerated]
		private RuntimeModel #f;

		// Token: 0x04004769 RID: 18281
		[CompilerGenerated]
		private #38e #g;

		// Token: 0x0400476A RID: 18282
		[CompilerGenerated]
		private CriticalCapacity #h;

		// Token: 0x0200130C RID: 4876
		protected sealed class #hif
		{
			// Token: 0x17002EC0 RID: 11968
			// (get) Token: 0x0600A300 RID: 41728 RVA: 0x0007F695 File Offset: 0x0007D895
			// (set) Token: 0x0600A301 RID: 41729 RVA: 0x0007F69D File Offset: 0x0007D89D
			public bool PrintMaxAxialLoad { get; set; }

			// Token: 0x17002EC1 RID: 11969
			// (get) Token: 0x0600A302 RID: 41730 RVA: 0x0007F6A6 File Offset: 0x0007D8A6
			// (set) Token: 0x0600A303 RID: 41731 RVA: 0x0007F6AE File Offset: 0x0007D8AE
			public bool PrintMinAxialLoad { get; set; }

			// Token: 0x17002EC2 RID: 11970
			// (get) Token: 0x0600A304 RID: 41732 RVA: 0x0007F6B7 File Offset: 0x0007D8B7
			// (set) Token: 0x0600A305 RID: 41733 RVA: 0x0007F6BF File Offset: 0x0007D8BF
			public bool PrintFootNote { get; set; }

			// Token: 0x0400476B RID: 18283
			[CompilerGenerated]
			private bool #a;

			// Token: 0x0400476C RID: 18284
			[CompilerGenerated]
			private bool #b;

			// Token: 0x0400476D RID: 18285
			[CompilerGenerated]
			private bool #c;
		}

		// Token: 0x0200130D RID: 4877
		protected sealed class #lif
		{
			// Token: 0x0600A307 RID: 41735 RVA: 0x0007F6C8 File Offset: 0x0007D8C8
			public #lif()
			{
				this.LoadIndex = 0;
				this.ServiceLoadIndex = 0;
				this.CombinationIndex = 0;
			}

			// Token: 0x17002EC3 RID: 11971
			// (get) Token: 0x0600A308 RID: 41736 RVA: 0x0007F6E5 File Offset: 0x0007D8E5
			// (set) Token: 0x0600A309 RID: 41737 RVA: 0x0007F6ED File Offset: 0x0007D8ED
			public int LoadIndex { get; set; }

			// Token: 0x17002EC4 RID: 11972
			// (get) Token: 0x0600A30A RID: 41738 RVA: 0x0007F6F6 File Offset: 0x0007D8F6
			// (set) Token: 0x0600A30B RID: 41739 RVA: 0x0007F6FE File Offset: 0x0007D8FE
			public int ServiceLoadIndex { get; set; }

			// Token: 0x17002EC5 RID: 11973
			// (get) Token: 0x0600A30C RID: 41740 RVA: 0x0007F707 File Offset: 0x0007D907
			// (set) Token: 0x0600A30D RID: 41741 RVA: 0x0007F70F File Offset: 0x0007D90F
			public int CombinationIndex { get; set; }

			// Token: 0x0400476E RID: 18286
			[CompilerGenerated]
			private int #a;

			// Token: 0x0400476F RID: 18287
			[CompilerGenerated]
			private int #b;

			// Token: 0x04004770 RID: 18288
			[CompilerGenerated]
			private int #c;
		}
	}
}
