using System;
using #hZe;
using #X7e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012B6 RID: 4790
	internal sealed class #tPe
	{
		// Token: 0x0600A051 RID: 41041 RVA: 0x0007DD5B File Offset: 0x0007BF5B
		public #tPe(InputModel #hMe, RuntimeModel #iMe, #38e #uPe, #3Qe #WMe)
		{
			this.#d = #hMe;
			this.#e = #iMe;
			this.#f = #uPe;
			this.#g = #WMe;
		}

		// Token: 0x17002E1D RID: 11805
		// (get) Token: 0x0600A052 RID: 41042 RVA: 0x0007DD80 File Offset: 0x0007BF80
		private float Eyt
		{
			get
			{
				return this.#d.MaterialProperties.Eyt;
			}
		}

		// Token: 0x17002E1E RID: 11806
		// (get) Token: 0x0600A053 RID: 41043 RVA: 0x0007DD92 File Offset: 0x0007BF92
		private #Fce ReductionFactors
		{
			get
			{
				return this.#e.ReductionFactors;
			}
		}

		// Token: 0x0600A054 RID: 41044 RVA: 0x00221B88 File Offset: 0x0021FD88
		public BiCurve #2Oe(#y0e #Jte, float #Tdb)
		{
			BiCurve result;
			if (this.#e.DiagramsCache.#abi(#Jte, #Tdb, out result))
			{
				return result;
			}
			BiCurve[] array = #Jte.BiCurve;
			BiCurve biCurve = new BiCurve();
			if (#Tdb > array[0].AxialLoad || #Tdb < array[69].AxialLoad)
			{
				biCurve.AxialLoad = #Tdb;
				for (int i = 0; i < 36; i++)
				{
					biCurve.MomentX[i] = 0f;
					biCurve.MomentY[i] = 0f;
				}
				this.#e.DiagramsCache.#9ai(#Jte, biCurve, #Tdb);
				return biCurve;
			}
			int num = 0;
			while (num < 69 && (array[num].AxialLoad < #Tdb || array[num + 1].AxialLoad > #Tdb))
			{
				num++;
			}
			if (num == 69)
			{
				num--;
			}
			if ((double)Math.Abs(array[num + 1].AxialLoad - array[num].AxialLoad) < 0.0)
			{
				biCurve.AxialLoad = #Tdb;
				for (int j = 0; j < 36; j++)
				{
					biCurve.MomentX[j] = 0f;
					biCurve.MomentY[j] = 0f;
				}
				this.#e.DiagramsCache.#9ai(#Jte, biCurve, #Tdb);
				return biCurve;
			}
			biCurve.AxialLoad = #Tdb;
			for (int k = 0; k < 36; k++)
			{
				BiCurve biCurve2 = array[num];
				float num2 = (#Tdb - biCurve2.AxialLoad) / (array[num + 1].AxialLoad - biCurve2.AxialLoad);
				float[] array2 = biCurve2.MomentX;
				biCurve.MomentX[k] = array2[k] + (array[num + 1].MomentX[k] - array2[k]) * num2;
				biCurve.MomentY[k] = biCurve2.MomentY[k] + (array[num + 1].MomentY[k] - biCurve2.MomentY[k]) * num2;
				biCurve.Dt[k] = biCurve2.Dt[k] + (array[num + 1].Dt[k] - biCurve2.Dt[k]) * num2;
				biCurve.DepthOfNeutralAxisC[k] = biCurve2.DepthOfNeutralAxisC[k] + (array[num + 1].DepthOfNeutralAxisC[k] - biCurve2.DepthOfNeutralAxisC[k]) * num2;
				biCurve.AngleOfNeutralAxisC[k] = biCurve2.AngleOfNeutralAxisC[k] + (array[num + 1].AngleOfNeutralAxisC[k] - biCurve2.AngleOfNeutralAxisC[k]) * num2;
				biCurve.BarMaximumStrainEps[k] = biCurve2.BarMaximumStrainEps[k] + (array[num + 1].BarMaximumStrainEps[k] - biCurve2.BarMaximumStrainEps[k]) * num2;
				biCurve.PhiFactor[k] = this.#8Oe(biCurve.BarMaximumStrainEps[k]);
			}
			this.#e.DiagramsCache.#9ai(#Jte, biCurve, #Tdb);
			return biCurve;
		}

		// Token: 0x0600A055 RID: 41045 RVA: 0x00221E3C File Offset: 0x0022003C
		public UniCurve[] #3Oe(#y0e #4Oe, float #PFe, bool #5Oe = false)
		{
			UniCurve[] result;
			try
			{
				this.#e.MessageBus.DebugContext.Interpolation2D = true;
				this.#e.MessageBus.DebugContext.Angle = new float?(#PFe);
				UniCurve[] array;
				if (this.#e.DiagramsCache.#8ai(#4Oe, #PFe, out array))
				{
					result = array;
				}
				else
				{
					float num = 0f;
					float #S2e = 0f;
					float #S2e2 = 0f;
					float #T2e = 0f;
					float #T2e2 = 0f;
					float num2 = 0f;
					float num3 = 0f;
					float num4 = 0f;
					float num5 = 0f;
					UniCurve[] array2 = new UniCurve[70];
					for (int i = 0; i < 70; i++)
					{
						this.#e.MessageBus.DebugContext.CurvePoint = new int?(i);
						array2[i] = UniCurve.#ul();
						UniCurve uniCurve = array2[i];
						BiCurve biCurve = #4Oe.BiCurve[i];
						uniCurve.AxialLoad = biCurve.AxialLoad;
						uniCurve.NegativeSide.Moment = 0f;
						uniCurve.PositiveSide.Moment = 0f;
						uniCurve.PlotPoint = false;
						float num6;
						float num7;
						bool flag;
						this.#pPe(biCurve, #PFe, out num6, out num7, out flag, out #S2e, out #S2e2, out #T2e, out #T2e2, out num2, out num3, out num4, out num5);
						uniCurve.PlotPoint = flag;
						uniCurve.PositiveSide.#R2e(num6, #S2e, #T2e, num2, this.#8Oe(num2));
						uniCurve.NegativeSide.#R2e(num7, #S2e2, #T2e2, num3, this.#8Oe(num3));
					}
					if (#5Oe)
					{
						this.#e.DiagramsCache.#7ai(#4Oe, array2, #PFe);
						result = array2;
					}
					else
					{
						int num8 = 0;
						for (int i = 0; i < 70; i++)
						{
							if (array2[i].PlotPoint)
							{
								num8 = i;
								break;
							}
						}
						if (num8 > 1)
						{
							this.#e.MessageBus.DebugContext.CurvePoint = new int?(num8);
							float num6 = array2[num8].PositiveSide.Moment;
							float num7 = array2[num8].NegativeSide.Moment;
							float num9 = Math.Abs(num6 - num7) * this.#d.Options.DiagramInterpolationConvergenceEpsilonPercentage;
							num9 = Math.Max(num9, 0.0009999999f);
							if (num6 - num7 >= num9)
							{
								float num10 = array2[num8 - 1].AxialLoad;
								float num11 = array2[num8].AxialLoad;
								float num12 = Math.Abs(num10 - num11) * this.#d.Options.DiagramInterpolationConvergenceEpsilonPercentage;
								num12 = Math.Max(num12, 0.1f);
								this.#oPe(num10, num11, #PFe, ref num, ref num6, ref num7, ref #S2e, ref #S2e2, ref #T2e, ref #T2e2, ref num2, ref num3, ref num4, ref num5, num9, num12);
								array2[num8 - 1].AxialLoad = num;
								array2[num8 - 1].PlotPoint = true;
								array2[num8 - 1].PositiveSide.#R2e(num6, #S2e, #T2e, num2, this.#8Oe(num2));
								array2[num8 - 1].NegativeSide.#R2e(num7, #S2e2, #T2e2, num3, this.#8Oe(num3));
							}
						}
						num8 = 0;
						for (int i = 69; i >= 0; i--)
						{
							if (array2[i].PlotPoint)
							{
								num8 = i;
								break;
							}
						}
						if (num8 < 68)
						{
							this.#e.MessageBus.DebugContext.CurvePoint = new int?(num8);
							float num6 = array2[num8].PositiveSide.Moment;
							float num7 = array2[num8].NegativeSide.Moment;
							float num13 = Math.Abs(num6 - num7) * this.#d.Options.DiagramInterpolationConvergenceEpsilonPercentage;
							num13 = Math.Max(num13, 0.0009999999f);
							if (num6 - num7 >= num13)
							{
								float num10 = array2[num8].AxialLoad;
								float num11 = array2[num8 + 1].AxialLoad;
								float num14 = Math.Abs(num11 - num10) * this.#d.Options.DiagramInterpolationConvergenceEpsilonPercentage;
								num14 = Math.Max(num14, 0.1f);
								this.#9Oe(num10, num11, #PFe, ref num, ref num6, ref num7, ref #S2e, ref #S2e2, ref #T2e, ref #T2e2, ref num2, ref num3, ref num4, ref num5, num13, num14);
								array2[num8 + 1].AxialLoad = num;
								array2[num8 + 1].PlotPoint = true;
								array2[num8 + 1].PositiveSide.#R2e(num6, #S2e, #T2e, num2, this.#8Oe(num2));
								array2[num8 + 1].NegativeSide.#R2e(num7, #S2e2, #T2e2, num3, this.#8Oe(num3));
							}
						}
						this.#e.DiagramsCache.#7ai(#4Oe, array2, #PFe);
						result = array2;
					}
				}
			}
			finally
			{
				this.#e.MessageBus.DebugContext.Interpolation2D = false;
			}
			return result;
		}

		// Token: 0x0600A056 RID: 41046 RVA: 0x0007578F File Offset: 0x0007398F
		private static float #6Oe(float #f)
		{
			return (float)Math.Cos((double)#f);
		}

		// Token: 0x0600A057 RID: 41047 RVA: 0x00075799 File Offset: 0x00073999
		private static float #7Oe(float #f)
		{
			return (float)Math.Sin((double)#f);
		}

		// Token: 0x0600A058 RID: 41048 RVA: 0x0007DD9F File Offset: 0x0007BF9F
		private float #8Oe(float #Tje)
		{
			return this.#f.#dYe(#Tje, this.Eyt, this.ReductionFactors.B, this.ReductionFactors.C);
		}

		// Token: 0x0600A059 RID: 41049 RVA: 0x002222E4 File Offset: 0x002204E4
		private void #9Oe(float #aPe, float #bPe, float #cPe, ref float #dPe, ref float #ePe, ref float #fPe, ref float #gPe, ref float #hPe, ref float #iPe, ref float #jPe, ref float #kPe, ref float #lPe, ref float #mPe, ref float #nPe, float #PWi, float #QWi)
		{
			#RMe #RMe = this.#g.BiaxialMomentCapacity;
			do
			{
				float num = 0.5f * (#aPe + #bPe);
				#a1e #a1e = #RMe.#GMe(num, #cPe);
				if (#a1e.ReturnValueI > 0)
				{
					#gPe = #a1e.CVal1;
					#hPe = #a1e.CVal2;
					#iPe = #a1e.CAngleVal1;
					#jPe = #a1e.CAngleVal2;
					#kPe = #a1e.EpsVal1;
					#lPe = #a1e.EpsVal2;
					#dPe = num;
					#ePe = #a1e.MomentMax;
					#fPe = #a1e.MomentMin;
					#dPe = num;
					#ePe = #a1e.MomentMax;
					#fPe = #a1e.MomentMin;
					#mPe = #a1e.DtVal1;
					#nPe = #a1e.DtVal2;
					if (#a1e.MomentMax - #a1e.MomentMin <= #PWi)
					{
						return;
					}
					#aPe = num;
				}
				else
				{
					#bPe = num;
				}
			}
			while (#aPe - #bPe > #QWi);
			#dPe = #bPe;
			#ePe = 0.5f * (#ePe + #fPe);
			#fPe = #ePe;
			#gPe = 0.5f * (#gPe + #hPe);
			#hPe = #gPe;
			#iPe = 0.5f * (#iPe + #jPe);
			#jPe = #iPe;
			#mPe = 0.5f * (#mPe + #nPe);
			#nPe = #mPe;
		}

		// Token: 0x0600A05A RID: 41050 RVA: 0x00222420 File Offset: 0x00220620
		private void #oPe(float #aPe, float #bPe, float #cPe, ref float #dPe, ref float #ePe, ref float #fPe, ref float #gPe, ref float #hPe, ref float #iPe, ref float #jPe, ref float #kPe, ref float #lPe, ref float #mPe, ref float #nPe, float #PWi, float #QWi)
		{
			#RMe #RMe = this.#g.BiaxialMomentCapacity;
			do
			{
				float num = 0.5f * (#aPe + #bPe);
				#a1e #a1e = #RMe.#GMe(num, #cPe);
				if (#a1e.ReturnValueI > 0)
				{
					#gPe = #a1e.CVal1;
					#hPe = #a1e.CVal2;
					#iPe = #a1e.CAngleVal1;
					#jPe = #a1e.CAngleVal2;
					#kPe = #a1e.EpsVal1;
					#lPe = #a1e.EpsVal2;
					#dPe = num;
					#ePe = #a1e.MomentMax;
					#fPe = #a1e.MomentMin;
					#mPe = #a1e.DtVal1;
					#nPe = #a1e.DtVal2;
					if (#a1e.MomentMax - #a1e.MomentMin <= #PWi)
					{
						return;
					}
					#bPe = num;
				}
				else
				{
					#aPe = num;
				}
			}
			while (#aPe - #bPe > #QWi);
			#dPe = #aPe;
			#ePe = 0.5f * (#ePe + #fPe);
			#fPe = #ePe;
			#gPe = 0.5f * (#gPe + #hPe);
			#hPe = #gPe;
			#iPe = 0.5f * (#iPe + #jPe);
			#jPe = #iPe;
			#kPe = 0.5f * (#kPe + #lPe);
			#lPe = #kPe;
			#mPe = 0.5f * (#mPe + #nPe);
			#nPe = #mPe;
		}

		// Token: 0x0600A05B RID: 41051 RVA: 0x0022255C File Offset: 0x0022075C
		private void #pPe(BiCurve #qPe, float #rPe, out float #ePe, out float #fPe, out bool #sPe, out float #gPe, out float #hPe, out float #iPe, out float #jPe, out float #kPe, out float #lPe, out float #mPe, out float #nPe)
		{
			#ePe = (#fPe = (#iPe = (#jPe = (#iPe = (#jPe = (#kPe = (#lPe = (#mPe = (#nPe = (#gPe = (#hPe = 0f)))))))))));
			#sPe = false;
			#ePe = -(float)Math.Pow(10.0, 30.0);
			#fPe = (float)Math.Pow(10.0, 30.0);
			int num = 0;
			float num2 = (float)((double)#rPe * 3.141592653589793 / 180.0);
			float num3 = #tPe.#7Oe(num2);
			float num4 = #tPe.#6Oe(num2);
			for (int i = 0; i < 36; i++)
			{
				int num5 = i;
				int num6 = (i == 35) ? 0 : (i + 1);
				float num7 = #qPe.MomentX[num5];
				float num8 = #qPe.MomentX[num6];
				float num9 = #qPe.MomentY[num5];
				float num10 = #qPe.MomentY[num6];
				float num11 = #qPe.DepthOfNeutralAxisC[num5];
				float num12 = #qPe.DepthOfNeutralAxisC[num6];
				float num13 = #qPe.AngleOfNeutralAxisC[num5];
				float num14 = #qPe.AngleOfNeutralAxisC[num6];
				float num15 = #qPe.BarMaximumStrainEps[num5];
				float num16 = #qPe.BarMaximumStrainEps[num6];
				float num17 = #qPe.Dt[num5];
				float num18 = #qPe.Dt[num6];
				float num19 = num7 * num4 + num9 * num3;
				float num20 = -num7 * num3 + num9 * num4;
				float num21 = num8 * num4 + num10 * num3;
				float num22 = -num8 * num3 + num10 * num4;
				if ((double)num20 >= 0.0 && num20 < 0.0001f)
				{
					num20 = 0.0001f;
				}
				else if ((double)num20 < 0.0 && num20 > -0.0001f)
				{
					num20 = -0.0001f;
				}
				if ((double)num22 >= 0.0 && num22 < 0.0001f)
				{
					num22 = 0.0001f;
				}
				else if ((double)num22 < 0.0 && num22 > -0.0001f)
				{
					num22 = -0.0001f;
				}
				if (((double)num20 > 0.0 && (double)num22 < 0.0) || ((double)num22 > 0.0 && (double)num20 < 0.0))
				{
					float num23 = (num19 * num22 - num21 * num20) / (num22 - num20);
					if (num23 > #ePe)
					{
						#ePe = num23;
						#gPe = (num11 * num22 - num12 * num20) / (num22 - num20);
						#iPe = (num13 * num22 - num14 * num20) / (num22 - num20);
						#kPe = (num15 * num22 - num16 * num20) / (num22 - num20);
						#mPe = (num17 * num22 - num18 * num20) / (num22 - num20);
					}
					if (num23 < #fPe)
					{
						#fPe = num23;
						#hPe = (num11 * num22 - num12 * num20) / (num22 - num20);
						#jPe = (num13 * num22 - num14 * num20) / (num22 - num20);
						#lPe = (num15 * num22 - num16 * num20) / (num22 - num20);
						#nPe = (num17 * num22 - num18 * num20) / (num22 - num20);
					}
					num++;
				}
			}
			#sPe = (num != 0);
			if (num == 0)
			{
				#ePe = 0f;
				#fPe = 0f;
				#gPe = 0f;
				#hPe = 0f;
				#iPe = 0f;
				#jPe = 0f;
				#kPe = 0f;
				#lPe = 0f;
				#mPe = 0f;
				#nPe = 0f;
			}
		}

		// Token: 0x04004630 RID: 17968
		private const int #a = 36;

		// Token: 0x04004631 RID: 17969
		private const float #b = 0.0001f;

		// Token: 0x04004632 RID: 17970
		private const int #c = 70;

		// Token: 0x04004633 RID: 17971
		private readonly InputModel #d;

		// Token: 0x04004634 RID: 17972
		private readonly RuntimeModel #e;

		// Token: 0x04004635 RID: 17973
		private readonly #38e #f;

		// Token: 0x04004636 RID: 17974
		private readonly #3Qe #g;
	}
}
