using System;
using #hZe;
using #wUe;
using #X7e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012CE RID: 4814
	internal sealed class #XSe
	{
		// Token: 0x0600A11E RID: 41246 RVA: 0x0007E68E File Offset: 0x0007C88E
		public #XSe(InputModel #hMe, RuntimeModel #iMe, #38e #jMe)
		{
			this.#b = #hMe;
			this.#c = #iMe;
			this.#d = #jMe;
		}

		// Token: 0x17002E61 RID: 11873
		// (get) Token: 0x0600A11F RID: 41247 RVA: 0x0007E6AB File Offset: 0x0007C8AB
		private #K2 MaterialProperties
		{
			get
			{
				return this.#b.MaterialProperties;
			}
		}

		// Token: 0x0600A120 RID: 41248 RVA: 0x0022547C File Offset: 0x0022367C
		public #E2e #PSe(float #QSe, ref #TZe #PQe)
		{
			float num = 100000f;
			if (#QSe > 0f)
			{
				num = this.MaterialProperties.Eps / #QSe;
			}
			float num2 = #QSe - (this.#c.Depth.OfConcrete[2] + this.#c.Coordinates.CoordinateZ);
			float num3 = this.MaterialProperties.Eps + 1f;
			ReinforcementBar[] array = this.#c.ReinforcementBars.Bars;
			int num4 = this.#c.ReinforcementBars.NumberOfBars;
			float num5 = #PQe.AxialLoad;
			float num6 = #PQe.MomentX;
			float num7 = this.#c.GeometryProperties.Ybar[2];
			float #USe = this.#c.ReductionFactors.B;
			float num8 = this.MaterialProperties.Fy;
			for (int i = 0; i < num4; i++)
			{
				ReinforcementBar reinforcementBar = array[i];
				float num9 = num * (num2 + reinforcementBar.Z);
				if (num9 < num3)
				{
					num3 = num9;
				}
				float num10;
				if ((double)#xke.#hke(num9) <= 1E-09)
				{
					num10 = 0f;
				}
				else
				{
					#K2 #K = this.MaterialProperties;
					float num11 = num9 * #K.Es;
					float num12 = num8;
					this.#d.#m8e(#USe, ref num11, ref num12);
					if (num11 > 0f)
					{
						if (num11 > num12)
						{
							num11 = num12;
						}
						if (reinforcementBar.IsWithinSection && num9 >= (1f - #K.Beta1) * #K.Eps)
						{
							num11 -= this.#d.#p8e(#K.Fc, this.#c.ReductionFactors.C);
						}
					}
					else if (num11 < -num12)
					{
						num11 = -num12;
					}
					num10 = num11;
				}
				float num13 = num10 * reinforcementBar.Area;
				num5 += num13;
				num6 += num13 * (reinforcementBar.Z - num7);
			}
			num3 = -num3;
			return new #E2e(num5, num6, num3);
		}

		// Token: 0x0600A121 RID: 41249 RVA: 0x00225660 File Offset: 0x00223860
		public #IZe #RSe(float #7Le, ref #TZe #PQe)
		{
			float num;
			if (#7Le > 1E-05f)
			{
				num = this.MaterialProperties.Eps / #7Le;
			}
			else
			{
				num = 100000f;
			}
			float num2 = this.MaterialProperties.Eps + 1f;
			float num3 = #7Le - (this.#c.Depth.OfConcrete[2] + this.#c.Coordinates.CoordinateZ);
			ReinforcementBar[] array = this.#c.ReinforcementBars.Bars;
			float num4 = #PQe.AxialLoad;
			float num5 = #PQe.MomentX;
			float num6 = #PQe.MomentY;
			float num7 = #PQe.AbsoluteMomentMagnitudeR;
			float #USe = this.#c.ReductionFactors.B;
			#x0e #x0e = this.#c.GeometryProperties;
			float num8 = #x0e.Ybar[0];
			float num9 = #x0e.Ybar[1];
			float num10 = #x0e.Ybar[2];
			int num11 = this.#c.ReinforcementBars.NumberOfBars;
			float num12 = this.MaterialProperties.Fy;
			for (int i = 0; i < num11; i++)
			{
				ReinforcementBar reinforcementBar = array[i];
				float num13 = num * (num3 + reinforcementBar.Z);
				if (num13 < num2)
				{
					num2 = num13;
				}
				float num14;
				if ((double)#xke.#hke(num13) <= 1E-09)
				{
					num14 = 0f;
				}
				else
				{
					#K2 #K = this.MaterialProperties;
					float num15 = num13 * #K.Es;
					float num16 = num12;
					this.#d.#m8e(#USe, ref num15, ref num16);
					if (num15 > 0f)
					{
						if (num15 > num16)
						{
							num15 = num16;
						}
						if (reinforcementBar.IsWithinSection && num13 >= (1f - #K.Beta1) * #K.Eps)
						{
							num15 -= this.#d.#p8e(#K.Fc, this.#c.ReductionFactors.C);
						}
					}
					else if (num15 < -num16)
					{
						num15 = -num16;
					}
					num14 = num15;
				}
				float num17 = num14 * reinforcementBar.Area;
				num4 += num17;
				num5 -= num17 * (reinforcementBar.Y - num9);
				num6 += num17 * (reinforcementBar.X - num8);
				num7 += num17 * (reinforcementBar.Z - num10);
			}
			num2 = -num2;
			return new #IZe(num4, num5, num6, num7, num2);
		}

		// Token: 0x04004672 RID: 18034
		private const double #a = 1E-09;

		// Token: 0x04004673 RID: 18035
		private readonly InputModel #b;

		// Token: 0x04004674 RID: 18036
		private readonly RuntimeModel #c;

		// Token: 0x04004675 RID: 18037
		private readonly #38e #d;
	}
}
