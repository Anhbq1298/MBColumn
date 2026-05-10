using System;
using #12e;
using #gMe;
using #hZe;
using #X7e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #7Xe
{
	// Token: 0x0200130A RID: 4874
	internal sealed class #6Xe : #iYe
	{
		// Token: 0x0600A2DA RID: 41690 RVA: 0x0007F534 File Offset: 0x0007D734
		public #6Xe(#l4e #Kwe, InputModel #hMe, RuntimeModel #iMe, #3Qe #IXe, CriticalCapacity #XMe, #fNe #xMe, #38e #jMe) : base(#Kwe, #hMe, #iMe, #IXe, #XMe, #xMe, #jMe)
		{
		}

		// Token: 0x0600A2DB RID: 41691 RVA: 0x0022CAC0 File Offset: 0x0022ACC0
		protected override void #TXe(#iYe.#lif #Ptb)
		{
			if (base.Options.ShouldConsiderSlenderness)
			{
				LoadsExt[] array = base.RuntimeModel.FactoredLoads.Loads;
				#Ptb.ServiceLoadIndex = array[#Ptb.LoadIndex].ServiceLoadIdx + 1;
				#Ptb.CombinationIndex = array[#Ptb.LoadIndex].LoadCombinationIndex + 1;
			}
		}

		// Token: 0x0600A2DC RID: 41692 RVA: 0x0022CB18 File Offset: 0x0022AD18
		protected override bool #UXe(int #Kpb)
		{
			if (base.Options.ShouldConsiderSlenderness)
			{
				LoadsExt[] array = base.RuntimeModel.FactoredLoads.Loads;
				return #Kpb == 0 || (#Kpb > 0 && (array[#Kpb].ServiceLoadIdx != array[#Kpb - 1].ServiceLoadIdx || array[#Kpb].LoadCombinationIndex != array[#Kpb - 1].LoadCombinationIndex));
			}
			return #Kpb % 2 == 0;
		}

		// Token: 0x0600A2DD RID: 41693 RVA: 0x0022CB84 File Offset: 0x0022AD84
		protected override #iYe.#hif #VXe(#S0e #WXe, #iYe.#lif #Ptb, #u3e.#zif #XXe, #iYe.#hif #YXe)
		{
			if (#WXe.UltimateSafeFactor > 0f)
			{
				float #1Xe = #WXe.UltimateMomentX;
				float #2Xe = #WXe.UltimateMomentY;
				float value = #WXe.UltimateSafeFactor;
				this.#0Xe(#Ptb, #WXe, #XXe, #1Xe, #2Xe, new float?(value), #u3e.#xif.#a);
			}
			else if (#WXe.Success)
			{
				float #1Xe2 = #WXe.UltimateMinMomentX;
				float #2Xe2 = #WXe.UltimateMinMomentY;
				this.#0Xe(#Ptb, #WXe, #XXe, #1Xe2, #2Xe2, null, #u3e.#xif.#b);
				this.#0Xe(#Ptb, #WXe, #u3e.#xif.#c);
			}
			else
			{
				this.#4Xe(#Ptb.LoadIndex, new int?(#Ptb.ServiceLoadIndex), new int?(#Ptb.CombinationIndex), #WXe, #XXe, #YXe);
			}
			return #YXe;
		}

		// Token: 0x0600A2DE RID: 41694 RVA: 0x0022CC28 File Offset: 0x0022AE28
		protected override #iYe.#hif #ZXe(#S0e #WXe, #iYe.#lif #Ptb, #u3e.#zif #XXe, #iYe.#hif #YXe)
		{
			float num = #WXe.UltimateSafeFactor;
			if (num > 0f)
			{
				float #1Xe = #WXe.UltimateMomentX;
				float #2Xe = #WXe.UltimateMomentY;
				this.#0Xe(#Ptb.LoadIndex, #WXe, #XXe, #1Xe, #2Xe, new float?(num), #u3e.#xif.#a);
			}
			else if (#WXe.Success)
			{
				float #1Xe2 = #WXe.UltimateMinMomentX;
				float #2Xe2 = #WXe.UltimateMinMomentY;
				this.#0Xe(#Ptb.LoadIndex, #WXe, #XXe, #1Xe2, #2Xe2, null, #u3e.#xif.#b);
				this.#0Xe(#Ptb.LoadIndex, #WXe, #u3e.#xif.#c);
			}
			else
			{
				this.#4Xe(#Ptb.LoadIndex, null, null, #WXe, #XXe, #YXe);
			}
			return #YXe;
		}

		// Token: 0x0600A2DF RID: 41695 RVA: 0x0022CCD4 File Offset: 0x0022AED4
		private void #0Xe(#iYe.#lif #Ptb, #S0e #WXe, #u3e.#zif #XXe, float #1Xe, float #2Xe, float? #lTe, #u3e.#xif #mye = #u3e.#xif.#a)
		{
			float? phi = base.#dYe(#WXe.BarMaximumStrain);
			LoadsExt loadsExt = base.RuntimeModel.FactoredLoads.Loads[#Ptb.LoadIndex];
			BiaxialServiceLoad biaxialServiceLoad = new BiaxialServiceLoad(new int?(#Ptb.LoadIndex + 1), new int?(#Ptb.ServiceLoadIndex), new int?(#Ptb.CombinationIndex), new float?(loadsExt.AxialLoad), new float?(loadsExt.MomentX), new float?(loadsExt.MomentY), new float?(#1Xe), new float?(#2Xe), #lTe, new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), phi, new #u3e.#zif?(#XXe), null)
			{
				MinMax = #mye
			};
			#WXe.#77c(biaxialServiceLoad);
			base.OutputModel.#vzc(biaxialServiceLoad);
		}

		// Token: 0x0600A2E0 RID: 41696 RVA: 0x0022CDAC File Offset: 0x0022AFAC
		private void #0Xe(#iYe.#lif #Ptb, #S0e #WXe, #u3e.#xif #mye = #u3e.#xif.#a)
		{
			float? phi = base.#dYe(#WXe.BarMaximumStrain);
			BiaxialServiceLoad #g4e = new BiaxialServiceLoad(new int?(#Ptb.LoadIndex + 1), new float?(#WXe.UltimateMaxMomentX), new float?(#WXe.UltimateMaxMomentY), new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), phi)
			{
				MinMax = #mye
			};
			base.OutputModel.#vzc(#g4e);
		}

		// Token: 0x0600A2E1 RID: 41697 RVA: 0x0022CE24 File Offset: 0x0022B024
		private void #0Xe(int #Kpb, #S0e #WXe, #u3e.#xif #mye = #u3e.#xif.#a)
		{
			float? phi = base.#dYe(#WXe.BarMaximumStrain);
			BiaxialServiceLoad #g4e = new BiaxialServiceLoad(new int?(#Kpb + 1), new float?(#WXe.UltimateMaxMomentX), new float?(#WXe.UltimateMaxMomentY), new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), phi)
			{
				MinMax = #mye
			};
			base.OutputModel.#vzc(#g4e);
		}

		// Token: 0x0600A2E2 RID: 41698 RVA: 0x0022CE98 File Offset: 0x0022B098
		private void #0Xe(int #Kpb, #S0e #WXe, #u3e.#zif #XXe, float #1Xe, float #2Xe, float? #3Xe, #u3e.#xif #mye = #u3e.#xif.#a)
		{
			LoadsExt loadsExt = base.RuntimeModel.FactoredLoads.Loads[#Kpb];
			float? phi = base.#dYe(#WXe.BarMaximumStrain);
			BiaxialServiceLoad biaxialServiceLoad = new BiaxialServiceLoad(new int?(#Kpb + 1), null, null, new float?(loadsExt.AxialLoad), new float?(loadsExt.MomentX), new float?(loadsExt.MomentY), new float?(#1Xe), new float?(#2Xe), #3Xe, new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), phi, new #u3e.#zif?(#XXe), null)
			{
				MinMax = #mye
			};
			#WXe.#77c(biaxialServiceLoad);
			base.OutputModel.#vzc(biaxialServiceLoad);
		}

		// Token: 0x0600A2E3 RID: 41699 RVA: 0x0022CF64 File Offset: 0x0022B164
		private void #4Xe(int #Kpb, int? #5Xe, int? #Lpb, #S0e #WXe, #u3e.#zif #XXe, #iYe.#hif #YXe)
		{
			LoadsExt loadsExt = base.RuntimeModel.FactoredLoads.Loads[#Kpb];
			#u3e.#yif #yif = #u3e.#yif.#a;
			if (#WXe.UltimateSafeFactor < -0.1001f)
			{
				#yif |= base.CodeExpert.#P8e();
			}
			else if (loadsExt.AxialLoad >= 0f)
			{
				#YXe.PrintMaxAxialLoad = true;
				#yif |= base.CodeExpert.#O8e();
			}
			else
			{
				#YXe.PrintMinAxialLoad = true;
				#yif |= base.CodeExpert.#N8e();
			}
			BiaxialServiceLoad #g4e = new BiaxialServiceLoad(new int?(#Kpb + 1), #5Xe, #Lpb, new float?(loadsExt.AxialLoad), new float?(loadsExt.MomentX), new float?(loadsExt.MomentY), null, null, null, null, null, null, null, new #u3e.#zif?(#XXe), new #u3e.#yif?(#yif));
			base.OutputModel.#vzc(#g4e);
		}
	}
}
