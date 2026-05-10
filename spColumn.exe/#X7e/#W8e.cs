using System;
using System.Collections.Generic;
using #12e;
using #7hc;
using #gMe;
using #hZe;
using #IWe;
using #MYe;
using #wUe;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #X7e
{
	// Token: 0x02001394 RID: 5012
	internal class #W8e : #38e
	{
		// Token: 0x0600A7A1 RID: 42913 RVA: 0x00082456 File Offset: 0x00080656
		public #W8e(#N5e #is)
		{
			if (!#is.IsCodeAci)
			{
				throw new ArgumentException(#Phc.#3hc(107309733));
			}
			this.#c = #is;
		}

		// Token: 0x0600A7A2 RID: 42914 RVA: 0x000035C3 File Offset: 0x000017C3
		protected #W8e()
		{
		}

		// Token: 0x0600A7A3 RID: 42915 RVA: 0x002330AC File Offset: 0x002312AC
		public float #Y7e(float #Z7e, float #07e, float #17e, float #27e, float #37e)
		{
			float #5gb = #Z7e * #07e * #17e / #27e;
			return #xke.#rke(#37e, #5gb);
		}

		// Token: 0x0600A7A4 RID: 42916 RVA: 0x0008247D File Offset: 0x0008067D
		public float #WSe(float #47e, float #57e, #B6e #c8, float #67e)
		{
			if (#c8 == #B6e.#b && #67e < 1f)
			{
				return #47e * #67e;
			}
			return #47e;
		}

		// Token: 0x0600A7A5 RID: 42917 RVA: 0x00082492 File Offset: 0x00080692
		public #vZe #77e(float #Qje, float #87e, #x0e #VIb, #Fce #Vne, float #97e, InputModel #a8e, bool #NSe)
		{
			return #W8e.#T8e(#Qje, #87e, #VIb, #Vne, #97e);
		}

		// Token: 0x0600A7A6 RID: 42918 RVA: 0x002330CC File Offset: 0x002312CC
		public virtual bool #y7e(bool #uQe, float[] #0Ne)
		{
			bool flag = #0Ne[2] == 0f && #0Ne[3] == 0f;
			return !#uQe && flag;
		}

		// Token: 0x0600A7A7 RID: 42919 RVA: 0x0000C78B File Offset: 0x0000A98B
		public virtual int #A7e(float #TRe)
		{
			return 0;
		}

		// Token: 0x0600A7A8 RID: 42920 RVA: 0x000824A0 File Offset: 0x000806A0
		public float #b8e(float #OQe, float #c8e, #Fce #Vne, float #MSe, bool #NSe, InputModel #a8e)
		{
			return this.#dYe(#OQe, #c8e, #Vne.B, #Vne.C);
		}

		// Token: 0x0600A7A9 RID: 42921 RVA: 0x000824B6 File Offset: 0x000806B6
		public float #d8e(float #MSe)
		{
			return 1f;
		}

		// Token: 0x0600A7AA RID: 42922 RVA: 0x000824BD File Offset: 0x000806BD
		public virtual #L6e #B7e(#L6e #PE)
		{
			#PE &= ~#L6e.#h;
			return #PE;
		}

		// Token: 0x0600A7AB RID: 42923 RVA: 0x000824C9 File Offset: 0x000806C9
		protected virtual float #z7e(float #2je)
		{
			return 0.005f;
		}

		// Token: 0x0600A7AC RID: 42924 RVA: 0x002330F8 File Offset: 0x002312F8
		public float #dYe(float #e8e, float #2je, float #USe, float #f8e)
		{
			float num = this.#z7e(#2je);
			if (#e8e >= num)
			{
				return #USe;
			}
			if (#e8e <= #2je)
			{
				return #f8e;
			}
			return (#f8e * (num - #e8e) + #USe * (#e8e - #2je)) / (num - #2je);
		}

		// Token: 0x0600A7AD RID: 42925 RVA: 0x00038482 File Offset: 0x00036682
		public float #g8e(float #Qje, float #57e)
		{
			return #Qje;
		}

		// Token: 0x0600A7AE RID: 42926 RVA: 0x000824D0 File Offset: 0x000806D0
		public float #h8e(float #ivb, float #i8e, bool #uQe, float #TRe, InputModel #a8e)
		{
			if (#uQe)
			{
				return 34f - 12f * #TRe;
			}
			return 22f;
		}

		// Token: 0x0600A7AF RID: 42927 RVA: 0x0023312C File Offset: 0x0023132C
		public virtual bool #C7e(float #Tdb, float #IPe, #X3 #Nwb, InputModel #hMe, ref float #D7e, ref int #ri)
		{
			#D7e = #JRe.#zRe(#Tdb, #hMe.MaterialProperties.Fcp, #IPe, false, #Nwb.Height, #hMe.Options.Unit);
			bool flag = #JRe.#ARe(#D7e);
			if (flag)
			{
				#ri |= 512;
			}
			return flag;
		}

		// Token: 0x0600A7B0 RID: 42928 RVA: 0x000824E9 File Offset: 0x000806E9
		public virtual float #E7e(float #mRe, float[] #eRe, float #gRe)
		{
			return #xke.#ske(#mRe, 0.4f);
		}

		// Token: 0x0600A7B1 RID: 42929 RVA: 0x000824F6 File Offset: 0x000806F6
		public float #j8e(InputModel #hMe, RuntimeModel #iMe, float #k8e, float #l8e)
		{
			return #W8e.#U8e(#hMe.Options.Confinement, #k8e);
		}

		// Token: 0x0600A7B2 RID: 42930 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #m8e(float #USe, ref float #n8e, ref float #o8e)
		{
		}

		// Token: 0x0600A7B3 RID: 42931 RVA: 0x00038482 File Offset: 0x00036682
		public float #p8e(float #Qje, float #57e)
		{
			return #Qje;
		}

		// Token: 0x0600A7B4 RID: 42932 RVA: 0x00082509 File Offset: 0x00080709
		public float #WWi()
		{
			if (this.#c.Code != #A5e.#i)
			{
				return 0.005f;
			}
			return 0.01f;
		}

		// Token: 0x0600A7B5 RID: 42933 RVA: 0x0023317C File Offset: 0x0023137C
		public bool #q8e(#K2 #OQ)
		{
			bool flag = #OQ.Eyt < 0f;
			bool flag2 = #OQ.Eyt > this.#WWi();
			return !flag && !flag2;
		}

		// Token: 0x0600A7B6 RID: 42934 RVA: 0x00082524 File Offset: 0x00080724
		public float #r8e()
		{
			return 1.5f;
		}

		// Token: 0x0600A7B7 RID: 42935 RVA: 0x00003375 File Offset: 0x00001575
		public virtual bool #F7e()
		{
			return true;
		}

		// Token: 0x0600A7B8 RID: 42936 RVA: 0x0008252B File Offset: 0x0008072B
		public virtual #rXe #J7e(#l4e #Kwe, RuntimeModel #iMe)
		{
			return new #NXe(#Kwe, #iMe);
		}

		// Token: 0x0600A7B9 RID: 42937 RVA: 0x00082534 File Offset: 0x00080734
		public float #0je()
		{
			return 0.003f;
		}

		// Token: 0x0600A7BA RID: 42938 RVA: 0x0008253B File Offset: 0x0008073B
		public float #Wje(#D6e #6jb, float #3Q)
		{
			if (#3Q <= 0f)
			{
				return 0f;
			}
			return 0.85f * #3Q;
		}

		// Token: 0x0600A7BB RID: 42939 RVA: 0x00082552 File Offset: 0x00080752
		public float #Xje(#D6e #6jb, float #3Q)
		{
			if (#3Q <= 0f)
			{
				return 0f;
			}
			if (#6jb == #D6e.#a)
			{
				return 1802.5f * #xke.#eke(#3Q);
			}
			return 4700f * #xke.#eke(#3Q);
		}

		// Token: 0x0600A7BC RID: 42940 RVA: 0x002331AC File Offset: 0x002313AC
		public float #Zje(#D6e #6jb, float #3Q)
		{
			if (#3Q == 0f)
			{
				return 0f;
			}
			float num = 1.05f - 0.05f * #3Q * ((#6jb == #D6e.#b) ? 0.145033f : 1f);
			if (num < 0.65f)
			{
				return 0.65f;
			}
			if (num > 0.85f)
			{
				return 0.85f;
			}
			return num;
		}

		// Token: 0x0600A7BD RID: 42941 RVA: 0x00233204 File Offset: 0x00231404
		public float #Lje(float #Mje, float #qLe)
		{
			float num = 0.002f;
			if (#qLe > 0f)
			{
				num = #Mje / #qLe;
			}
			if (num >= this.#WWi())
			{
				return 0.002f;
			}
			return num;
		}

		// Token: 0x0600A7BE RID: 42942 RVA: 0x00082414 File Offset: 0x00080614
		public virtual NaNullableFloat #K7e(float #L7e, ref FactoredMoment.#wif #M7e)
		{
			return NaNullableFloat.#FSd();
		}

		// Token: 0x0600A7BF RID: 42943 RVA: 0x0008257E File Offset: 0x0008077E
		public float? #s8e(float #e8e, float #2je, float #USe, float #f8e)
		{
			return new float?(this.#dYe(#e8e, #2je, #USe, #f8e));
		}

		// Token: 0x0600A7C0 RID: 42944 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #t8e(#i5e #u8e, float #MSe, InputModel #hMe, bool #NSe)
		{
		}

		// Token: 0x0600A7C1 RID: 42945 RVA: 0x00233234 File Offset: 0x00231434
		public void #v8e(#l4e #Kwe, #S0e #Rfb, int #4jb, #u3e.#zif #XXe, LoadsExt #ivb, float #c8e, #Fce #Vne)
		{
			float value = this.#dYe(#Rfb.BarMaximumStrain, #c8e, #Vne.B, #Vne.C);
			BiaxialFactoredLoad biaxialFactoredLoad = new BiaxialFactoredLoad(new int?(#4jb + 1), new float?(#ivb.AxialLoad), new float?(#ivb.MomentX), new float?(#ivb.MomentY), new float?(#Rfb.UltimateMinMomentX), new float?(#Rfb.UltimateMinMomentY), null, new float?(#Rfb.NeutralAxisDepth), new float?(#Rfb.TensionDistance), new float?(#Rfb.BarMaximumStrain), new float?(value), new #u3e.#zif?(#XXe), null)
			{
				MinMax = #u3e.#xif.#b
			};
			#Rfb.#77c(biaxialFactoredLoad);
			#Kwe.#vzc(biaxialFactoredLoad);
			biaxialFactoredLoad = new BiaxialFactoredLoad(new float?(#Rfb.UltimateMaxMomentX), new float?(#Rfb.UltimateMaxMomentY), new float?(#Rfb.NeutralAxisDepth), new float?(#Rfb.TensionDistance), new float?(#Rfb.BarMaximumStrain), new float?(value))
			{
				MinMax = #u3e.#xif.#c
			};
			#Rfb.#77c(biaxialFactoredLoad);
			#Kwe.#vzc(biaxialFactoredLoad);
		}

		// Token: 0x0600A7C2 RID: 42946 RVA: 0x00233354 File Offset: 0x00231554
		public void #w8e(#l4e #Kwe, #S0e #Rfb, int #4jb, #u3e.#zif #XXe, LoadsExt #ivb, float #c8e, #Fce #Vne)
		{
			float value = this.#dYe(#Rfb.BarMaximumStrain, #c8e, #Vne.B, #Vne.C);
			BiaxialFactoredLoad biaxialFactoredLoad = new BiaxialFactoredLoad(new int?(#4jb + 1), new float?(#ivb.AxialLoad), new float?(#ivb.MomentX), new float?(#ivb.MomentY), new float?(#Rfb.UltimateMomentX), new float?(#Rfb.UltimateMomentY), new float?(#Rfb.UltimateSafeFactor), new float?(#Rfb.NeutralAxisDepth), new float?(#Rfb.TensionDistance), new float?(#Rfb.BarMaximumStrain), new float?(value), new #u3e.#zif?(#XXe), null);
			#Rfb.#77c(biaxialFactoredLoad);
			#Kwe.#vzc(biaxialFactoredLoad);
		}

		// Token: 0x0600A7C3 RID: 42947 RVA: 0x00233418 File Offset: 0x00231618
		public void #x8e(#l4e #Kwe, #S0e #WXe, int #4jb, float #FYe, #u3e.#zif #XXe, LoadsExt #ivb, float #y8e, float #z8e, float #c8e, #Fce #Vne)
		{
			float value = this.#dYe(#WXe.BarMaximumStrain, #c8e, #Vne.B, #Vne.C);
			UniaxialFactoredLoad uniaxialFactoredLoad = new UniaxialFactoredLoad(new int?(#4jb + 1), new float?(#ivb.AxialLoad), new float?(#FYe), new float?(#y8e), null, new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), new float?(value), new #u3e.#zif?(#XXe), null)
			{
				MinMax = #u3e.#xif.#b
			};
			#WXe.#77c(uniaxialFactoredLoad);
			#Kwe.#vzc(uniaxialFactoredLoad);
			uniaxialFactoredLoad = new UniaxialFactoredLoad(new float?(#z8e), new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), new float?(value))
			{
				MinMax = #u3e.#xif.#c
			};
			#WXe.#77c(uniaxialFactoredLoad);
			#Kwe.#vzc(uniaxialFactoredLoad);
		}

		// Token: 0x0600A7C4 RID: 42948 RVA: 0x00233508 File Offset: 0x00231708
		public void #A8e(#S0e #WXe, int #4jb, float #FYe, #u3e.#zif #XXe, LoadsExt #ivb, float #lYe, #l4e #Kwe, float #c8e, #Fce #Vne)
		{
			float value = this.#dYe(#WXe.BarMaximumStrain, #c8e, #Vne.B, #Vne.C);
			UniaxialFactoredLoad uniaxialFactoredLoad = new UniaxialFactoredLoad(new int?(#4jb + 1), new float?(#ivb.AxialLoad), new float?(#FYe), new float?(#lYe), new float?(#WXe.UltimateSafeFactor), new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), new float?(value), new #u3e.#zif?(#XXe), null);
			#WXe.#77c(uniaxialFactoredLoad);
			#Kwe.#vzc(uniaxialFactoredLoad);
		}

		// Token: 0x0600A7C5 RID: 42949 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #B8e(List<ControlPoint.#uif> #QLb)
		{
		}

		// Token: 0x0600A7C6 RID: 42950 RVA: 0x00082590 File Offset: 0x00080790
		public void #C8e(ControlPoint #c4e, float #c8e, #Fce #Vne)
		{
			#c4e.Phi = new float?(this.#dYe(#c4e.Eps, #c8e, #Vne.B, #Vne.C));
		}

		// Token: 0x0600A7C7 RID: 42951 RVA: 0x002335AC File Offset: 0x002317AC
		public virtual bool #N7e(int #O7e, int #P7e, int #Q7e, #Lce[][] #R7e, int #S7e)
		{
			for (int i = #O7e; i <= #P7e; i++)
			{
				for (int j = 0; j < #Q7e; j++)
				{
					for (int k = 0; k < #S7e; k++)
					{
						if (#R7e[j][i].UltimateAxialLoad[k] > 0f)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600A7C8 RID: 42952 RVA: 0x000825B6 File Offset: 0x000807B6
		public virtual NaNullableFloat #T7e(int #Lpb, #Lce #jdd, bool #U7e)
		{
			if (#U7e)
			{
				return new NaNullableFloat(new float?(#jdd.Kplur[#Lpb]));
			}
			return NaNullableFloat.#FSd();
		}

		// Token: 0x0600A7C9 RID: 42953 RVA: 0x000825D3 File Offset: 0x000807D3
		public virtual bool #G7e(bool #H7e, int #I7e)
		{
			return #xke.#dke(#I7e & 512);
		}

		// Token: 0x0600A7CA RID: 42954 RVA: 0x000825E1 File Offset: 0x000807E1
		public #2Ye #D8e(#l4e #Od)
		{
			return new #XYe(#Od);
		}

		// Token: 0x0600A7CB RID: 42955 RVA: 0x000825E9 File Offset: 0x000807E9
		public #2Ye #E8e(#l4e #Od)
		{
			return new #UYe(#Od, this);
		}

		// Token: 0x0600A7CC RID: 42956 RVA: 0x000825F2 File Offset: 0x000807F2
		public #2Ye #F8e()
		{
			return new #LYe();
		}

		// Token: 0x0600A7CD RID: 42957 RVA: 0x000825F9 File Offset: 0x000807F9
		public #u3e.#yif? #G8e()
		{
			return new #u3e.#yif?(#u3e.#yif.#d);
		}

		// Token: 0x0600A7CE RID: 42958 RVA: 0x00082601 File Offset: 0x00080801
		public #u3e.#yif? #H8e()
		{
			return new #u3e.#yif?(#u3e.#yif.#b);
		}

		// Token: 0x0600A7CF RID: 42959 RVA: 0x00082609 File Offset: 0x00080809
		public #u3e.#yif? #I8e()
		{
			return new #u3e.#yif?(#u3e.#yif.#f);
		}

		// Token: 0x0600A7D0 RID: 42960 RVA: 0x00082612 File Offset: 0x00080812
		public #u3e.#Aif? #J8e()
		{
			return new #u3e.#Aif?(#u3e.#Aif.#d);
		}

		// Token: 0x0600A7D1 RID: 42961 RVA: 0x0008261A File Offset: 0x0008081A
		public #u3e.#Aif? #K8e()
		{
			return new #u3e.#Aif?(#u3e.#Aif.#b);
		}

		// Token: 0x0600A7D2 RID: 42962 RVA: 0x00051809 File Offset: 0x0004FA09
		public #u3e.#Aif #L8e()
		{
			return #u3e.#Aif.#d;
		}

		// Token: 0x0600A7D3 RID: 42963 RVA: 0x00003375 File Offset: 0x00001575
		public #u3e.#Aif #M8e()
		{
			return #u3e.#Aif.#b;
		}

		// Token: 0x0600A7D4 RID: 42964 RVA: 0x00051809 File Offset: 0x0004FA09
		public #u3e.#yif #N8e()
		{
			return #u3e.#yif.#d;
		}

		// Token: 0x0600A7D5 RID: 42965 RVA: 0x00003375 File Offset: 0x00001575
		public #u3e.#yif #O8e()
		{
			return #u3e.#yif.#b;
		}

		// Token: 0x0600A7D6 RID: 42966 RVA: 0x000149D8 File Offset: 0x00012BD8
		public #u3e.#yif #P8e()
		{
			return #u3e.#yif.#f;
		}

		// Token: 0x0600A7D7 RID: 42967 RVA: 0x00082622 File Offset: 0x00080822
		public virtual float #G2(#K2 #Nwb)
		{
			return 0.005f / #Nwb.Eps;
		}

		// Token: 0x0600A7D8 RID: 42968 RVA: 0x00082630 File Offset: 0x00080830
		public float #QRe(float #ivb, float #sQe, float #tQe, float #wQe)
		{
			return #URe.#QRe(#sQe, #tQe);
		}

		// Token: 0x0600A7D9 RID: 42969 RVA: 0x002335F8 File Offset: 0x002317F8
		public bool #Q8e(RuntimeModel #iMe, #fMe #wMe, #K2 #OQ, float #Udb)
		{
			float num = #iMe.Depth.OfReinforcement[2];
			float #7Le = num / (1f + #OQ.#I2());
			float num2 = #wMe.#8Le(#7Le, #Udb).ColumnLoad.AxialLoad;
			#7Le = num / (1f + this.#G2(#OQ));
			return #wMe.#8Le(#7Le, #Udb).ColumnLoad.AxialLoad > num2;
		}

		// Token: 0x0600A7DA RID: 42970 RVA: 0x00082639 File Offset: 0x00080839
		public float #R8e(#G6e #jce, float[] #S8e, float #l8e)
		{
			return 0f;
		}

		// Token: 0x0600A7DB RID: 42971 RVA: 0x00233668 File Offset: 0x00231868
		private static #vZe #T8e(float #Qje, float #87e, #x0e #VIb, #Fce #Vne, float #97e)
		{
			float #wZe = (#Qje * (#VIb.Ag - #VIb.AreaOfSteelWithinSection) + #87e * #VIb.AreaOfSteel) * #Vne.C;
			float #xZe = -#VIb.AreaOfSteel * #Vne.B * #97e;
			return new #vZe(#wZe, #xZe);
		}

		// Token: 0x0600A7DC RID: 42972 RVA: 0x00082640 File Offset: 0x00080840
		private static float #U8e(#H6e #sce, float #V8e)
		{
			if (#sce == #H6e.#b)
			{
				return #V8e;
			}
			if (#sce != #H6e.#a)
			{
				return 0.85f;
			}
			return 0.8f;
		}

		// Token: 0x04004A3A RID: 19002
		public const float #a = 0.005f;

		// Token: 0x04004A3B RID: 19003
		public const float #b = 0.01f;

		// Token: 0x04004A3C RID: 19004
		private readonly #N5e #c;
	}
}
