using System;
using #12e;
using #gMe;
using #hZe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #7Xe
{
	// Token: 0x0200130E RID: 4878
	internal sealed class #qYe : #iYe
	{
		// Token: 0x0600A30E RID: 41742 RVA: 0x0007F534 File Offset: 0x0007D734
		public #qYe(#l4e #Kwe, InputModel #hMe, RuntimeModel #iMe, #3Qe #IXe, CriticalCapacity #XMe, #fNe #xMe, #38e #jMe) : base(#Kwe, #hMe, #iMe, #IXe, #XMe, #xMe, #jMe)
		{
		}

		// Token: 0x0600A30F RID: 41743 RVA: 0x00009E6A File Offset: 0x0000806A
		protected override void #TXe(#iYe.#lif #Ptb)
		{
		}

		// Token: 0x0600A310 RID: 41744 RVA: 0x00072A3E File Offset: 0x00070C3E
		protected override bool #UXe(int #Kpb)
		{
			return #Kpb % 2 == 0;
		}

		// Token: 0x0600A311 RID: 41745 RVA: 0x0022D368 File Offset: 0x0022B568
		protected override #iYe.#hif #VXe(#S0e #WXe, #iYe.#lif #jYe, #u3e.#zif #XXe, #iYe.#hif #YXe)
		{
			if (#WXe.UltimateSafeFactor > 0f)
			{
				float #lYe = this.#oYe(#WXe);
				this.#kYe(#jYe, #WXe, #XXe, #lYe, new float?(#WXe.UltimateSafeFactor), #u3e.#xif.#a);
			}
			else if (#WXe.Success)
			{
				float #lYe2 = this.#nYe(#WXe);
				this.#kYe(#jYe, #WXe, #XXe, #lYe2, null, #u3e.#xif.#b);
				this.#kYe(#WXe, #u3e.#xif.#c);
			}
			else
			{
				int value = #jYe.ServiceLoadIndex;
				int value2 = #jYe.CombinationIndex;
				this.#4Xe(#jYe.LoadIndex, new int?(value), new int?(value2), #XXe, #YXe);
			}
			return #YXe;
		}

		// Token: 0x0600A312 RID: 41746 RVA: 0x0022D400 File Offset: 0x0022B600
		protected override #iYe.#hif #ZXe(#S0e #WXe, #iYe.#lif #Ptb, #u3e.#zif #XXe, #iYe.#hif #YXe)
		{
			float num = #WXe.UltimateSafeFactor;
			if (num > 0f)
			{
				float #lYe = this.#oYe(#WXe);
				this.#kYe(#Ptb.LoadIndex, #WXe, #XXe, #lYe, new float?(num), #u3e.#xif.#a);
			}
			else if (#WXe.Success)
			{
				float #lYe2 = this.#nYe(#WXe);
				this.#kYe(#Ptb.LoadIndex, #WXe, #XXe, #lYe2, null, #u3e.#xif.#b);
				this.#kYe(#WXe, #u3e.#xif.#c);
			}
			else
			{
				this.#4Xe(#Ptb.LoadIndex, null, null, #XXe, #YXe);
			}
			return #YXe;
		}

		// Token: 0x0600A313 RID: 41747 RVA: 0x0022D494 File Offset: 0x0022B694
		private void #kYe(#iYe.#lif #jYe, #S0e #WXe, #u3e.#zif #XXe, float #lYe, float? #lTe, #u3e.#xif #mye = #u3e.#xif.#a)
		{
			LoadsExt loadsExt = base.RuntimeModel.FactoredLoads.Loads[#jYe.LoadIndex];
			float? phi = base.#dYe(#WXe.BarMaximumStrain);
			UniaxialServiceLoad uniaxialServiceLoad = new UniaxialServiceLoad(new int?(#jYe.LoadIndex + 1), new int?(#jYe.ServiceLoadIndex), new int?(#jYe.CombinationIndex), new float?(loadsExt.AxialLoad), new float?(this.#pYe(loadsExt)), new float?(#lYe), #lTe, new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), phi, new #u3e.#zif?(#XXe), null)
			{
				MinMax = #mye
			};
			#WXe.#77c(uniaxialServiceLoad);
			base.OutputModel.#vzc(uniaxialServiceLoad);
		}

		// Token: 0x0600A314 RID: 41748 RVA: 0x0022D55C File Offset: 0x0022B75C
		private void #kYe(#S0e #WXe, #u3e.#xif #mye = #u3e.#xif.#a)
		{
			float? phi = base.#dYe(#WXe.BarMaximumStrain);
			UniaxialServiceLoad uniaxialServiceLoad = new UniaxialServiceLoad(null, null, null, null, null, new float?(this.#mYe(#WXe)), null, new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), phi, null, null)
			{
				MinMax = #mye
			};
			#WXe.#77c(uniaxialServiceLoad);
			base.OutputModel.#vzc(uniaxialServiceLoad);
		}

		// Token: 0x0600A315 RID: 41749 RVA: 0x0022D610 File Offset: 0x0022B810
		private void #kYe(int #Kpb, #S0e #WXe, #u3e.#zif #XXe, float #lYe, float? #lTe, #u3e.#xif #mye = #u3e.#xif.#a)
		{
			LoadsExt loadsExt = base.RuntimeModel.FactoredLoads.Loads[#Kpb];
			float? phi = base.#dYe(#WXe.BarMaximumStrain);
			UniaxialServiceLoad uniaxialServiceLoad = new UniaxialServiceLoad(new int?(#Kpb + 1), null, null, new float?(loadsExt.AxialLoad), new float?(this.#pYe(loadsExt)), new float?(#lYe), #lTe, new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), phi, new #u3e.#zif?(#XXe), null)
			{
				MinMax = #mye
			};
			#WXe.#77c(uniaxialServiceLoad);
			base.OutputModel.#vzc(uniaxialServiceLoad);
		}

		// Token: 0x0600A316 RID: 41750 RVA: 0x0022D6CC File Offset: 0x0022B8CC
		private void #kYe(int #Kpb, int? #5Xe, int? #Lpb, #u3e.#zif #XXe, #u3e.#Aif #VTe)
		{
			LoadsExt loadsExt = base.RuntimeModel.FactoredLoads.Loads[#Kpb];
			UniaxialServiceLoad #f4e = new UniaxialServiceLoad(new int?(#Kpb + 1), #5Xe, #Lpb, new float?(loadsExt.AxialLoad), new float?(this.#pYe(loadsExt)), null, null, null, null, null, null, new #u3e.#zif?(#XXe), new #u3e.#Aif?(#VTe));
			base.OutputModel.#vzc(#f4e);
		}

		// Token: 0x0600A317 RID: 41751 RVA: 0x0022D764 File Offset: 0x0022B964
		private void #4Xe(int #Kpb, int? #5Xe, int? #Lpb, #u3e.#zif #XXe, #iYe.#hif #YXe)
		{
			LoadsExt loadsExt = base.RuntimeModel.FactoredLoads.Loads[#Kpb];
			#u3e.#Aif #Aif = #u3e.#Aif.#a;
			if (loadsExt.AxialLoad >= 0f)
			{
				#YXe.PrintMaxAxialLoad = true;
				#Aif |= base.CodeExpert.#M8e();
			}
			else
			{
				#YXe.PrintMinAxialLoad = true;
				#Aif |= base.CodeExpert.#L8e();
			}
			this.#kYe(#Kpb, #5Xe, #Lpb, #XXe, #Aif);
		}

		// Token: 0x0600A318 RID: 41752 RVA: 0x0007F718 File Offset: 0x0007D918
		private float #mYe(#S0e #Rfb)
		{
			if (base.Options.ConsideredAxis == #C6e.#a)
			{
				return #Rfb.UltimateMaxMomentX;
			}
			return #Rfb.UltimateMaxMomentY;
		}

		// Token: 0x0600A319 RID: 41753 RVA: 0x0007F734 File Offset: 0x0007D934
		private float #nYe(#S0e #Rfb)
		{
			if (base.Options.ConsideredAxis == #C6e.#a)
			{
				return #Rfb.UltimateMinMomentX;
			}
			return #Rfb.UltimateMinMomentY;
		}

		// Token: 0x0600A31A RID: 41754 RVA: 0x0007F750 File Offset: 0x0007D950
		private float #oYe(#S0e #Rfb)
		{
			if (base.Options.ConsideredAxis == #C6e.#a)
			{
				return #Rfb.UltimateMomentX;
			}
			return #Rfb.UltimateMomentY;
		}

		// Token: 0x0600A31B RID: 41755 RVA: 0x0007F76C File Offset: 0x0007D96C
		private float #pYe(LoadsExt #ivb)
		{
			if (base.Options.ConsideredAxis == #C6e.#a)
			{
				return #ivb.MomentX;
			}
			return #ivb.MomentY;
		}
	}
}
