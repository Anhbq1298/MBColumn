using System;
using #hZe;
using #wUe;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x0200129E RID: 4766
	internal sealed class #uNe
	{
		// Token: 0x06009FAC RID: 40876 RVA: 0x0007D7AC File Offset: 0x0007B9AC
		public #uNe(InputModel #hMe, RuntimeModel #iMe)
		{
			this.#a = #hMe;
			this.#b = #iMe;
		}

		// Token: 0x17002DF4 RID: 11764
		// (get) Token: 0x06009FAD RID: 40877 RVA: 0x0007D7C2 File Offset: 0x0007B9C2
		private #K2 MaterialProperties
		{
			get
			{
				return this.#a.MaterialProperties;
			}
		}

		// Token: 0x17002DF5 RID: 11765
		// (get) Token: 0x06009FAE RID: 40878 RVA: 0x0007D7CF File Offset: 0x0007B9CF
		private #3Ze Depth
		{
			get
			{
				return this.#b.Depth;
			}
		}

		// Token: 0x17002DF6 RID: 11766
		// (get) Token: 0x06009FAF RID: 40879 RVA: 0x0007D7DC File Offset: 0x0007B9DC
		private float CoordinateZ
		{
			get
			{
				return this.#b.Coordinates.CoordinateZ;
			}
		}

		// Token: 0x17002DF7 RID: 11767
		// (get) Token: 0x06009FB0 RID: 40880 RVA: 0x0007D7EE File Offset: 0x0007B9EE
		private #x0e GeometryProperties
		{
			get
			{
				return this.#b.GeometryProperties;
			}
		}

		// Token: 0x17002DF8 RID: 11768
		// (get) Token: 0x06009FB1 RID: 40881 RVA: 0x0007D7FB File Offset: 0x0007B9FB
		private float[] SectionDimensions
		{
			get
			{
				return this.#b.SectionDimensionsForInvestigate;
			}
		}

		// Token: 0x06009FB2 RID: 40882 RVA: 0x0021E168 File Offset: 0x0021C368
		public #IZe #rNe(float #7Le, Point[] #BP, int #kNe, float #Udb)
		{
			float num = this.Depth.OfConcrete[2];
			float num2 = this.CoordinateZ;
			float num3 = num + num2 - this.MaterialProperties.Beta1 * #7Le;
			if (num3 < num2)
			{
				num3 = num2;
			}
			#NWi #NWi = #mNe.#bpb(#BP, #kNe, num3);
			float num4 = #NWi.#a;
			if (!#xke.#dke(num4))
			{
				return #IZe.Empty;
			}
			float num5 = #NWi.#b;
			float #c = #NWi.#c;
			float num6 = #xke.#oke(-(#Udb + 180f) * 0.017453292f);
			float num7 = #xke.#qke(-(#Udb + 180f) * 0.017453292f);
			float num8 = num5 * num6 + #c * num7;
			float num9 = -num5 * num7 + #c * num6;
			float num10 = num4 * this.#b.Fc;
			float #1Xe = -num10 * (num9 - this.GeometryProperties.Ybar[1]);
			float #2Xe = num10 * (num8 - this.GeometryProperties.Ybar[0]);
			float #JZe = num10 * (#c - this.GeometryProperties.Ybar[2]);
			return new #IZe(num10, #1Xe, #2Xe, #JZe);
		}

		// Token: 0x06009FB3 RID: 40883 RVA: 0x0021E26C File Offset: 0x0021C46C
		public #E2e #sNe(float #7Le, Point[] #BP, int #kNe)
		{
			float num = this.Depth.OfConcrete[2];
			float num2 = this.CoordinateZ;
			float num3 = num + num2 - this.MaterialProperties.Beta1 * #7Le;
			if (num3 < num2)
			{
				num3 = num2;
			}
			#NWi #NWi = #mNe.#bpb(#BP, #kNe, num3);
			float num4 = this.GeometryProperties.Ybar[2];
			if (!#xke.#dke(#NWi.#a))
			{
				return #E2e.Empty;
			}
			float #c = #NWi.#c;
			float num5 = this.#b.Fc;
			float num6 = #NWi.#a * num5;
			float #cpb = num6 * (#c - num4);
			return new #E2e(num6, #cpb);
		}

		// Token: 0x06009FB4 RID: 40884 RVA: 0x0021E2FC File Offset: 0x0021C4FC
		public #E2e #tNe(float #5Gb)
		{
			#5Gb *= this.MaterialProperties.Beta1;
			float num;
			float num2;
			if (#5Gb >= this.SectionDimensions[0])
			{
				num = this.GeometryProperties.Ag;
				num2 = 0f;
			}
			else if (#5Gb <= 0.0001f)
			{
				num = 0f;
				num2 = 0f;
			}
			else
			{
				float num3 = this.SectionDimensions[0] / 2f;
				float num4 = #5Gb - num3;
				float num5 = #xke.#mke(num4 / num3);
				float num6 = 1.5707964f + num5;
				float num7 = num6 * num3 * num3;
				float num8 = num3 * num4 * #xke.#oke(num5);
				num = num7 + num8;
				float num9 = 2f * num3 * #xke.#oke(num5) / num6 / 3f;
				float num10 = 2f * num4 / 3f;
				num2 = (num7 * num9 - num8 * num10) / num;
			}
			float num11 = num * this.#b.Fc;
			float #cpb = num11 * num2;
			return new #E2e(num11, #cpb);
		}

		// Token: 0x040045B7 RID: 17847
		private readonly InputModel #a;

		// Token: 0x040045B8 RID: 17848
		private readonly RuntimeModel #b;
	}
}
