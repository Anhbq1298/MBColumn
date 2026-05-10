using System;
using #hZe;
using #wUe;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012B7 RID: 4791
	internal sealed class #GPe
	{
		// Token: 0x0600A05C RID: 41052 RVA: 0x0007DDC9 File Offset: 0x0007BFC9
		public #GPe(RuntimeModel #iMe, InputModel #hMe)
		{
			this.#b = #iMe;
			this.#a = #hMe;
		}

		// Token: 0x17002E1F RID: 11807
		// (get) Token: 0x0600A05D RID: 41053 RVA: 0x0007DDDF File Offset: 0x0007BFDF
		private #x0e GeometryProperties
		{
			get
			{
				return this.#b.GeometryProperties;
			}
		}

		// Token: 0x17002E20 RID: 11808
		// (get) Token: 0x0600A05E RID: 41054 RVA: 0x0007DDEC File Offset: 0x0007BFEC
		private #K2 MaterialProperties
		{
			get
			{
				return this.#a.MaterialProperties;
			}
		}

		// Token: 0x17002E21 RID: 11809
		// (get) Token: 0x0600A05F RID: 41055 RVA: 0x0007DDF9 File Offset: 0x0007BFF9
		private Options Options
		{
			get
			{
				return this.#a.Options;
			}
		}

		// Token: 0x17002E22 RID: 11810
		// (get) Token: 0x0600A060 RID: 41056 RVA: 0x0007DE06 File Offset: 0x0007C006
		private SlendernessOfBeams BeamX
		{
			get
			{
				return this.#a.BeamX;
			}
		}

		// Token: 0x17002E23 RID: 11811
		// (get) Token: 0x0600A061 RID: 41057 RVA: 0x0007DE13 File Offset: 0x0007C013
		private SlendernessOfBeams BeamY
		{
			get
			{
				return this.#a.BeamY;
			}
		}

		// Token: 0x17002E24 RID: 11812
		// (get) Token: 0x0600A062 RID: 41058 RVA: 0x0007DE20 File Offset: 0x0007C020
		private SlendernessOfColumn ColumnAbove
		{
			get
			{
				return this.#a.ColumnAbove;
			}
		}

		// Token: 0x17002E25 RID: 11813
		// (get) Token: 0x0600A063 RID: 41059 RVA: 0x0007DE2D File Offset: 0x0007C02D
		private SlendernessOfColumn ColumnBelow
		{
			get
			{
				return this.#a.ColumnBelow;
			}
		}

		// Token: 0x17002E26 RID: 11814
		// (get) Token: 0x0600A064 RID: 41060 RVA: 0x0007DE3A File Offset: 0x0007C03A
		private #X3 DesignedColumnX
		{
			get
			{
				return this.#a.DesignedColumnX;
			}
		}

		// Token: 0x17002E27 RID: 11815
		// (get) Token: 0x0600A065 RID: 41061 RVA: 0x0007DE47 File Offset: 0x0007C047
		private #X3 DesignedColumnY
		{
			get
			{
				return this.#a.DesignedColumnY;
			}
		}

		// Token: 0x0600A066 RID: 41062 RVA: 0x002228D4 File Offset: 0x00220AD4
		public #gZe #vPe()
		{
			float num = this.#zPe(#C6e.#a);
			if (num <= 0f)
			{
				return new #gZe(999f, this.DesignedColumnX.Ksway, this.DesignedColumnY.Kbraced);
			}
			float num2 = this.ColumnAbove.Dimension[0];
			float num3 = this.ColumnAbove.Dimension[1];
			float num4 = this.ColumnBelow.Dimension[0];
			float num5 = this.ColumnBelow.Dimension[1];
			float num6 = this.GeometryProperties.SecondMomentOfInertia[0];
			#xTe #xTe = new #xTe();
			if (this.DesignedColumnX.Kmode == 0)
			{
				#xTe = this.#APe(this.DesignedColumnX, this.BeamX, num2, num3, num6, num4, num5);
			}
			float #iZe = #MPe.#JPe(this.DesignedColumnX, num);
			float #lZe = this.#xPe(num6, num2, num3);
			float #mZe = this.#xPe(num6, num4, num5);
			return new #gZe(#iZe, #xTe.Top, #xTe.Bottom, num6, #lZe, #mZe, this.DesignedColumnX.Ksway, this.DesignedColumnX.Kbraced);
		}

		// Token: 0x0600A067 RID: 41063 RVA: 0x002229E0 File Offset: 0x00220BE0
		public #gZe #wPe()
		{
			float num = this.#zPe(#C6e.#b);
			if (num <= 0f)
			{
				return new #gZe(999f, this.DesignedColumnY.Ksway, this.DesignedColumnY.Kbraced);
			}
			float num2 = this.ColumnAbove.Dimension[1];
			float num3 = this.ColumnAbove.Dimension[0];
			float num4 = this.ColumnBelow.Dimension[1];
			float num5 = this.ColumnBelow.Dimension[0];
			if (#xke.#U3(num2) && #xke.#dke(num3))
			{
				num2 = num3;
				num3 = 0f;
			}
			if (#xke.#U3(num4) && #xke.#dke(num5))
			{
				num4 = num5;
				num5 = 0f;
			}
			float num6 = this.GeometryProperties.SecondMomentOfInertia[1];
			#xTe #xTe = new #xTe();
			if (this.DesignedColumnY.Kmode == 0)
			{
				#xTe = this.#APe(this.DesignedColumnY, this.BeamY, num2, num3, num6, num4, num5);
			}
			float #iZe = #MPe.#JPe(this.DesignedColumnY, num);
			float #lZe = this.#xPe(num6, num2, num3);
			float #mZe = this.#xPe(num6, num4, num5);
			return new #gZe(#iZe, #xTe.Top, #xTe.Bottom, num6, #lZe, #mZe, this.DesignedColumnY.Ksway, this.DesignedColumnY.Kbraced);
		}

		// Token: 0x0600A068 RID: 41064 RVA: 0x0007DE54 File Offset: 0x0007C054
		private float #xPe(float #yPe, float #6Q, float #5Q)
		{
			if (#6Q == 0f && #5Q == 0f)
			{
				return #yPe;
			}
			return #MPe.#LPe(#6Q, #5Q);
		}

		// Token: 0x0600A069 RID: 41065 RVA: 0x0007DE6F File Offset: 0x0007C06F
		private float #zPe(#C6e #6gb)
		{
			return this.GeometryProperties.RadiusOfGyration[(int)#6gb] / this.Options.#55e();
		}

		// Token: 0x0600A06A RID: 41066 RVA: 0x00222B1C File Offset: 0x00220D1C
		private #xTe #APe(#X3 #U6, SlendernessOfBeams #9r, float #BPe, float #CPe, float #DPe, float #EPe, float #FPe)
		{
			float num = #MPe.#HPe(#BPe, #CPe, #DPe);
			float num2 = #MPe.#HPe(#EPe, #FPe, #DPe);
			float #zTe = #DPe * this.MaterialProperties.Ec;
			float #ATe = num * this.ColumnAbove.Ec;
			float #BTe = num2 * this.ColumnBelow.Ec;
			return #CTe.#yTe(#U6, #9r, #zTe, #ATe, #BTe, this.#a);
		}

		// Token: 0x04004637 RID: 17975
		private readonly InputModel #a;

		// Token: 0x04004638 RID: 17976
		private readonly RuntimeModel #b;
	}
}
