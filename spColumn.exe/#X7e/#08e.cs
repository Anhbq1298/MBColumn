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
	// Token: 0x02001396 RID: 5014
	internal sealed class #08e : #38e
	{
		// Token: 0x0600A814 RID: 43028 RVA: 0x00082656 File Offset: 0x00080856
		public #08e(#N5e #is)
		{
			if (!#is.IsCodeCsa)
			{
				throw new ArgumentException(#Phc.#3hc(107309700));
			}
			this.#a = #is;
		}

		// Token: 0x0600A815 RID: 43029 RVA: 0x00082639 File Offset: 0x00080839
		public float #G2(#K2 #Nwb)
		{
			return 0f;
		}

		// Token: 0x0600A816 RID: 43030 RVA: 0x002336AC File Offset: 0x002318AC
		public float #QRe(float #ivb, float #sQe, float #tQe, float #wQe)
		{
			float result = #URe.#QRe(#sQe, #tQe);
			if (this.#a.Code == #A5e.#j)
			{
				float num = #ivb * #wQe;
				if (Math.Max(Math.Abs(#sQe), Math.Abs(#tQe)) < num)
				{
					result = 1f;
				}
			}
			return result;
		}

		// Token: 0x0600A817 RID: 43031 RVA: 0x0000C78B File Offset: 0x0000A98B
		public bool #Q8e(RuntimeModel #iMe, #fMe #wMe, #K2 #OQ, float #Udb)
		{
			return false;
		}

		// Token: 0x0600A818 RID: 43032 RVA: 0x0008267D File Offset: 0x0008087D
		public float #Y7e(float #Z7e, float #07e, float #17e, float #27e, float #37e)
		{
			return -1E+20f;
		}

		// Token: 0x0600A819 RID: 43033 RVA: 0x00082684 File Offset: 0x00080884
		public float #WSe(float #47e, float #57e, #B6e #c8, float #67e)
		{
			return #57e * #47e;
		}

		// Token: 0x0600A81A RID: 43034 RVA: 0x002336F0 File Offset: 0x002318F0
		public #vZe #77e(float #Qje, float #87e, #x0e #VIb, #Fce #Vne, float #97e, InputModel #a8e, bool #NSe)
		{
			float num = #Qje * (#VIb.Ag - #VIb.AreaOfSteelWithinSection) + #Vne.B * #87e * #VIb.AreaOfSteel;
			float num2 = -#VIb.AreaOfSteel * #Vne.B * #97e;
			float num3 = #OSe.#bpb(#VIb.Rho, #a8e, #NSe, this);
			if (num3 < 1f)
			{
				num *= num3;
				num2 *= num3;
			}
			return new #vZe(num, num2);
		}

		// Token: 0x0600A81B RID: 43035 RVA: 0x0023375C File Offset: 0x0023195C
		public bool #y7e(bool #uQe, float[] #0Ne)
		{
			bool flag = #0Ne[2] == 0f && #0Ne[3] == 0f;
			bool flag2 = !#uQe && flag;
			if (this.#a.Code == #A5e.#b)
			{
				flag2 &= (#0Ne[0] == 1.25f);
				flag2 &= (#0Ne[1] == 1.5f);
				flag2 &= (#0Ne[4] == 1.5f || #0Ne[4] == 0f);
			}
			return flag2;
		}

		// Token: 0x0600A81C RID: 43036 RVA: 0x0000C78B File Offset: 0x0000A98B
		public int #A7e(float #TRe)
		{
			return 0;
		}

		// Token: 0x0600A81D RID: 43037 RVA: 0x002337CC File Offset: 0x002319CC
		public float #b8e(float #OQe, float #c8e, #Fce #Vne, float #MSe, bool #NSe, InputModel #a8e)
		{
			float num = #OSe.#bpb(#MSe, #a8e, #NSe, this);
			if (num >= 1f)
			{
				return 1f;
			}
			return num;
		}

		// Token: 0x0600A81E RID: 43038 RVA: 0x002337F8 File Offset: 0x002319F8
		public float #d8e(float #MSe)
		{
			#A5e #A5e = this.#a.Code;
			if (#A5e <= #A5e.#d)
			{
				if (#A5e == #A5e.#b)
				{
					return #MSe;
				}
				if (#A5e != #A5e.#d)
				{
					goto IL_35;
				}
			}
			else if (#A5e != #A5e.#h && #A5e != #A5e.#j)
			{
				goto IL_35;
			}
			return 0.5f * (1f + #MSe);
			IL_35:
			return 1f;
		}

		// Token: 0x0600A81F RID: 43039 RVA: 0x000824BD File Offset: 0x000806BD
		public #L6e #B7e(#L6e #PE)
		{
			#PE &= ~#L6e.#h;
			return #PE;
		}

		// Token: 0x0600A820 RID: 43040 RVA: 0x000824B6 File Offset: 0x000806B6
		public float #dYe(float #e8e, float #2je, float #USe, float #f8e)
		{
			return 1f;
		}

		// Token: 0x0600A821 RID: 43041 RVA: 0x00082689 File Offset: 0x00080889
		public float #g8e(float #Qje, float #57e)
		{
			return #Qje * #57e;
		}

		// Token: 0x0600A822 RID: 43042 RVA: 0x00233840 File Offset: 0x00231A40
		public float #h8e(float #ivb, float #i8e, bool #uQe, float #TRe, InputModel #a8e)
		{
			if (!#uQe)
			{
				return 0f;
			}
			float num = #ivb / (#a8e.MaterialProperties.Fcp * #i8e);
			if (#a8e.Options.Unit == #D6e.#b)
			{
				num *= 1000f;
			}
			num = #xke.#eke(num);
			return (25f - 10f * #TRe) / num;
		}

		// Token: 0x0600A823 RID: 43043 RVA: 0x0023312C File Offset: 0x0023132C
		public bool #C7e(float #Tdb, float #IPe, #X3 #Nwb, InputModel #hMe, ref float #D7e, ref int #ri)
		{
			#D7e = #JRe.#zRe(#Tdb, #hMe.MaterialProperties.Fcp, #IPe, false, #Nwb.Height, #hMe.Options.Unit);
			bool flag = #JRe.#ARe(#D7e);
			if (flag)
			{
				#ri |= 512;
			}
			return flag;
		}

		// Token: 0x0600A824 RID: 43044 RVA: 0x00233898 File Offset: 0x00231A98
		public float #E7e(float #mRe, float[] #eRe, float #gRe)
		{
			#mRe = #xke.#ske(#mRe, 0.4f);
			if (this.#a.Code == #A5e.#j)
			{
				float num = 0f;
				for (int i = 0; i <= 1; i++)
				{
					if (Math.Abs(#eRe[i]) > num)
					{
						num = Math.Abs(#eRe[i]);
					}
				}
				if (num < #gRe)
				{
					#mRe = 1f;
				}
			}
			return #mRe;
		}

		// Token: 0x0600A825 RID: 43045 RVA: 0x0008268E File Offset: 0x0008088E
		public float #j8e(InputModel #hMe, RuntimeModel #iMe, float #k8e, float #l8e)
		{
			return this.#X8e(#iMe.SectionDimensionsForInvestigate, #hMe.Options, #hMe.DesignCode.Code, #l8e, #k8e);
		}

		// Token: 0x0600A826 RID: 43046 RVA: 0x000826B0 File Offset: 0x000808B0
		public void #m8e(float #USe, ref float #n8e, ref float #o8e)
		{
			#n8e *= #USe;
			#o8e *= #USe;
		}

		// Token: 0x0600A827 RID: 43047 RVA: 0x00082689 File Offset: 0x00080889
		public float #p8e(float #Qje, float #57e)
		{
			return #Qje * #57e;
		}

		// Token: 0x0600A828 RID: 43048 RVA: 0x00003375 File Offset: 0x00001575
		public bool #q8e(#K2 #OQ)
		{
			return true;
		}

		// Token: 0x0600A829 RID: 43049 RVA: 0x000826BE File Offset: 0x000808BE
		public float #r8e()
		{
			return 1.4f;
		}

		// Token: 0x0600A82A RID: 43050 RVA: 0x00003375 File Offset: 0x00001575
		public bool #F7e()
		{
			return true;
		}

		// Token: 0x0600A82B RID: 43051 RVA: 0x0008252B File Offset: 0x0008072B
		public #rXe #J7e(#l4e #Kwe, RuntimeModel #iMe)
		{
			return new #NXe(#Kwe, #iMe);
		}

		// Token: 0x0600A82C RID: 43052 RVA: 0x000826C5 File Offset: 0x000808C5
		public float #0je()
		{
			return 0.0035f;
		}

		// Token: 0x0600A82D RID: 43053 RVA: 0x002338F4 File Offset: 0x00231AF4
		public float #Wje(#D6e #6jb, float #3Q)
		{
			if (#3Q <= 0f)
			{
				return 0f;
			}
			float num = 0.85f - 0.0015f * #3Q * ((#6jb == #D6e.#a) ? 6.895f : 1f);
			if (num < 0.67f)
			{
				num = 0.67f;
			}
			return num * #3Q;
		}

		// Token: 0x0600A82E RID: 43054 RVA: 0x00233940 File Offset: 0x00231B40
		public float #Xje(#D6e #6jb, float #3Q)
		{
			if (#3Q <= 0f)
			{
				return 0f;
			}
			if (#6jb == #D6e.#a)
			{
				#3Q *= 6.895f;
			}
			float num = 3517.51f * #xke.#eke(#3Q) + 7354.864f;
			if (#6jb == #D6e.#a)
			{
				return num / 6.895f;
			}
			return num;
		}

		// Token: 0x0600A82F RID: 43055 RVA: 0x00233988 File Offset: 0x00231B88
		public float #Zje(#D6e #6jb, float #3Q)
		{
			if (#3Q == 0f)
			{
				return 0f;
			}
			float num = 0.97f - 0.0025f * #3Q * ((#6jb == #D6e.#a) ? 6.895f : 1f);
			if (num < 0.67f)
			{
				return 0.67f;
			}
			return num;
		}

		// Token: 0x0600A830 RID: 43056 RVA: 0x002339D0 File Offset: 0x00231BD0
		public float #Lje(float #Mje, float #qLe)
		{
			float result = 0.002f;
			if (#qLe > 0f)
			{
				return #Mje / #qLe;
			}
			return result;
		}

		// Token: 0x0600A831 RID: 43057 RVA: 0x00082414 File Offset: 0x00080614
		public NaNullableFloat #K7e(float #L7e, ref FactoredMoment.#wif #M7e)
		{
			return NaNullableFloat.#FSd();
		}

		// Token: 0x0600A832 RID: 43058 RVA: 0x002339F0 File Offset: 0x00231BF0
		public float? #s8e(float #e8e, float #2je, float #USe, float #f8e)
		{
			return null;
		}

		// Token: 0x0600A833 RID: 43059 RVA: 0x000826CC File Offset: 0x000808CC
		public void #t8e(#i5e #u8e, float #MSe, InputModel #hMe, bool #NSe)
		{
			#u8e.RedFactRho = new float?(#OSe.#bpb(#MSe, #hMe, #NSe, this));
		}

		// Token: 0x0600A834 RID: 43060 RVA: 0x00233A08 File Offset: 0x00231C08
		public void #v8e(#l4e #Kwe, #S0e #Rfb, int #4jb, #u3e.#zif #XXe, LoadsExt #ivb, float #c8e, #Fce #Vne)
		{
			BiaxialFactoredLoad biaxialFactoredLoad = new BiaxialFactoredLoad(new int?(#4jb + 1), new float?(#ivb.AxialLoad), new float?(#ivb.MomentX), new float?(#ivb.MomentY), new float?(#Rfb.UltimateMinMomentX), new float?(#Rfb.UltimateMinMomentY), null, new float?(#Rfb.NeutralAxisDepth), new float?(#Rfb.TensionDistance), new float?(#Rfb.BarMaximumStrain), null, new #u3e.#zif?(#XXe), null)
			{
				MinMax = #u3e.#xif.#b
			};
			#Rfb.#77c(biaxialFactoredLoad);
			#Kwe.#vzc(biaxialFactoredLoad);
			biaxialFactoredLoad = new BiaxialFactoredLoad(new float?(#Rfb.UltimateMaxMomentX), new float?(#Rfb.UltimateMaxMomentY), new float?(#Rfb.NeutralAxisDepth), new float?(#Rfb.TensionDistance), new float?(#Rfb.BarMaximumStrain), null)
			{
				MinMax = #u3e.#xif.#c
			};
			#Rfb.#77c(biaxialFactoredLoad);
			#Kwe.#vzc(biaxialFactoredLoad);
		}

		// Token: 0x0600A835 RID: 43061 RVA: 0x00233B10 File Offset: 0x00231D10
		public void #w8e(#l4e #Kwe, #S0e #Rfb, int #4jb, #u3e.#zif #XXe, LoadsExt #ivb, float #c8e, #Fce #Vne)
		{
			BiaxialFactoredLoad biaxialFactoredLoad = new BiaxialFactoredLoad(new int?(#4jb + 1), new float?(#ivb.AxialLoad), new float?(#ivb.MomentX), new float?(#ivb.MomentY), new float?(#Rfb.UltimateMomentX), new float?(#Rfb.UltimateMomentY), new float?(#Rfb.UltimateSafeFactor), new float?(#Rfb.NeutralAxisDepth), new float?(#Rfb.TensionDistance), new float?(#Rfb.BarMaximumStrain), null, new #u3e.#zif?(#XXe), null);
			#Rfb.#77c(biaxialFactoredLoad);
			#Kwe.#vzc(biaxialFactoredLoad);
		}

		// Token: 0x0600A836 RID: 43062 RVA: 0x00233BB8 File Offset: 0x00231DB8
		public void #x8e(#l4e #Kwe, #S0e #WXe, int #4jb, float #FYe, #u3e.#zif #XXe, LoadsExt #ivb, float #y8e, float #z8e, float #c8e, #Fce #Vne)
		{
			UniaxialFactoredLoad uniaxialFactoredLoad = new UniaxialFactoredLoad(new int?(#4jb + 1), new float?(#ivb.AxialLoad), new float?(#FYe), new float?(#y8e), null, new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), null, new #u3e.#zif?(#XXe), null)
			{
				MinMax = #u3e.#xif.#b
			};
			#WXe.#77c(uniaxialFactoredLoad);
			#Kwe.#vzc(uniaxialFactoredLoad);
			uniaxialFactoredLoad = new UniaxialFactoredLoad(new float?(#z8e), new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), null)
			{
				MinMax = #u3e.#xif.#c
			};
			#WXe.#77c(uniaxialFactoredLoad);
			#Kwe.#vzc(uniaxialFactoredLoad);
		}

		// Token: 0x0600A837 RID: 43063 RVA: 0x00233C94 File Offset: 0x00231E94
		public void #A8e(#S0e #WXe, int #4jb, float #FYe, #u3e.#zif #XXe, LoadsExt #ivb, float #lYe, #l4e #Kwe, float #c8e, #Fce #Vne)
		{
			UniaxialFactoredLoad uniaxialFactoredLoad = new UniaxialFactoredLoad(new int?(#4jb + 1), new float?(#ivb.AxialLoad), new float?(#FYe), new float?(#lYe), new float?(#WXe.UltimateSafeFactor), new float?(#WXe.NeutralAxisDepth), new float?(#WXe.TensionDistance), new float?(#WXe.BarMaximumStrain), null, new #u3e.#zif?(#XXe), null);
			#WXe.#77c(uniaxialFactoredLoad);
			#Kwe.#vzc(uniaxialFactoredLoad);
		}

		// Token: 0x0600A838 RID: 43064 RVA: 0x000826E3 File Offset: 0x000808E3
		public void #B8e(List<ControlPoint.#uif> #QLb)
		{
			#QLb.Remove(ControlPoint.#uif.#g);
		}

		// Token: 0x0600A839 RID: 43065 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #C8e(ControlPoint #c4e, float #c8e, #Fce #Vne)
		{
		}

		// Token: 0x0600A83A RID: 43066 RVA: 0x002335AC File Offset: 0x002317AC
		public bool #N7e(int #O7e, int #P7e, int #Q7e, #Lce[][] #R7e, int #S7e)
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

		// Token: 0x0600A83B RID: 43067 RVA: 0x000825B6 File Offset: 0x000807B6
		public NaNullableFloat #T7e(int #Lpb, #Lce #jdd, bool #U7e)
		{
			if (#U7e)
			{
				return new NaNullableFloat(new float?(#jdd.Kplur[#Lpb]));
			}
			return NaNullableFloat.#FSd();
		}

		// Token: 0x0600A83C RID: 43068 RVA: 0x000825D3 File Offset: 0x000807D3
		public bool #G7e(bool #H7e, int #I7e)
		{
			return #xke.#dke(#I7e & 512);
		}

		// Token: 0x0600A83D RID: 43069 RVA: 0x000826ED File Offset: 0x000808ED
		public #2Ye #D8e(#l4e #Od)
		{
			return new #YYe(#Od);
		}

		// Token: 0x0600A83E RID: 43070 RVA: 0x000826F5 File Offset: 0x000808F5
		public #2Ye #E8e(#l4e #Od)
		{
			return new #TYe(#Od, this);
		}

		// Token: 0x0600A83F RID: 43071 RVA: 0x000826FE File Offset: 0x000808FE
		public #2Ye #F8e()
		{
			return new #NYe();
		}

		// Token: 0x0600A840 RID: 43072 RVA: 0x00082705 File Offset: 0x00080905
		public #u3e.#yif? #G8e()
		{
			return new #u3e.#yif?(#u3e.#yif.#e);
		}

		// Token: 0x0600A841 RID: 43073 RVA: 0x0008270D File Offset: 0x0008090D
		public #u3e.#yif? #H8e()
		{
			return new #u3e.#yif?(#u3e.#yif.#c);
		}

		// Token: 0x0600A842 RID: 43074 RVA: 0x00082715 File Offset: 0x00080915
		public #u3e.#yif? #I8e()
		{
			return new #u3e.#yif?(#u3e.#yif.#g);
		}

		// Token: 0x0600A843 RID: 43075 RVA: 0x0008271E File Offset: 0x0008091E
		public #u3e.#Aif? #J8e()
		{
			return new #u3e.#Aif?(#u3e.#Aif.#e);
		}

		// Token: 0x0600A844 RID: 43076 RVA: 0x00082726 File Offset: 0x00080926
		public #u3e.#Aif? #K8e()
		{
			return new #u3e.#Aif?(#u3e.#Aif.#c);
		}

		// Token: 0x0600A845 RID: 43077 RVA: 0x000253E8 File Offset: 0x000235E8
		public #u3e.#Aif #L8e()
		{
			return #u3e.#Aif.#e;
		}

		// Token: 0x0600A846 RID: 43078 RVA: 0x0008272E File Offset: 0x0008092E
		public #u3e.#Aif #M8e()
		{
			return #u3e.#Aif.#c;
		}

		// Token: 0x0600A847 RID: 43079 RVA: 0x000253E8 File Offset: 0x000235E8
		public #u3e.#yif #N8e()
		{
			return #u3e.#yif.#e;
		}

		// Token: 0x0600A848 RID: 43080 RVA: 0x0008272E File Offset: 0x0008092E
		public #u3e.#yif #O8e()
		{
			return #u3e.#yif.#c;
		}

		// Token: 0x0600A849 RID: 43081 RVA: 0x00082731 File Offset: 0x00080931
		public #u3e.#yif #P8e()
		{
			return #u3e.#yif.#g;
		}

		// Token: 0x0600A84A RID: 43082 RVA: 0x00082735 File Offset: 0x00080935
		public float #R8e(#G6e #jce, float[] #S8e, float #l8e)
		{
			if (!this.#a.IsCodeCsa14Plus)
			{
				return 0f;
			}
			if (#jce == #G6e.#a)
			{
				return #xke.#rke(#S8e[0], #S8e[1]);
			}
			if (#jce == #G6e.#b)
			{
				return #S8e[0];
			}
			return #l8e;
		}

		// Token: 0x0600A84B RID: 43083 RVA: 0x00082639 File Offset: 0x00080839
		public float #WWi()
		{
			return 0f;
		}

		// Token: 0x0600A84C RID: 43084 RVA: 0x00082762 File Offset: 0x00080962
		private float #X8e(float[] #S8e, Options #mA, #A5e #3, float #l8e, float #Y8e)
		{
			if (#mA.Confinement == #H6e.#b)
			{
				return #Y8e;
			}
			return this.#Z8e(#3, #mA, #S8e, #l8e);
		}

		// Token: 0x0600A84D RID: 43085 RVA: 0x00233D1C File Offset: 0x00231F1C
		private float #Z8e(#A5e #3, Options #mA, float[] #S8e, float #l8e)
		{
			if (#3 == #A5e.#b || #3 == #A5e.#d)
			{
				if (#mA.Confinement != #H6e.#a)
				{
					return 0.85f;
				}
				return 0.8f;
			}
			else
			{
				if ((#3 == #A5e.#h || #3 == #A5e.#j) && #mA.Confinement == #H6e.#a)
				{
					float num = this.#R8e(#mA.SectionType, #S8e, #l8e);
					if (#mA.Unit == #D6e.#a)
					{
						num *= 25.4f;
					}
					return #xke.#rke(0.2f + 0.002f * num, 0.8f);
				}
				return 0.9f;
			}
		}

		// Token: 0x04004A3D RID: 19005
		private readonly #N5e #a;
	}
}
