using System;
using System.Runtime.CompilerServices;
using #wUe;

namespace #hZe
{
	// Token: 0x0200132B RID: 4907
	internal sealed class #x0e
	{
		// Token: 0x0600A3D2 RID: 41938 RVA: 0x0007FF7F File Offset: 0x0007E17F
		public #x0e()
		{
			this.SecondMomentOfInertia = new float[3];
			this.Ybar = new float[3];
			this.RadiusOfGyration = new float[2];
		}

		// Token: 0x0600A3D3 RID: 41939 RVA: 0x0022EF54 File Offset: 0x0022D154
		public #x0e(#x0e #L0)
		{
			this.SecondMomentOfInertia = (float[])#L0.SecondMomentOfInertia.Clone();
			this.Ybar = (float[])#L0.Ybar.Clone();
			this.RadiusOfGyration = (float[])#L0.RadiusOfGyration.Clone();
			this.Ag = #L0.Ag;
			this.AreaOfSteel = #L0.AreaOfSteel;
			this.AreaOfSteelWithinSection = #L0.AreaOfSteelWithinSection;
			this.Rho = #L0.Rho;
			this.Space = #L0.Space;
			this.Cover = #L0.Cover;
		}

		// Token: 0x17002EFD RID: 12029
		// (get) Token: 0x0600A3D4 RID: 41940 RVA: 0x0007FFAB File Offset: 0x0007E1AB
		// (set) Token: 0x0600A3D5 RID: 41941 RVA: 0x0007FFB3 File Offset: 0x0007E1B3
		public float Ag { get; set; }

		// Token: 0x17002EFE RID: 12030
		// (get) Token: 0x0600A3D6 RID: 41942 RVA: 0x0007FFBC File Offset: 0x0007E1BC
		// (set) Token: 0x0600A3D7 RID: 41943 RVA: 0x0007FFC4 File Offset: 0x0007E1C4
		public float AreaOfSteel { get; set; }

		// Token: 0x17002EFF RID: 12031
		// (get) Token: 0x0600A3D8 RID: 41944 RVA: 0x0007FFCD File Offset: 0x0007E1CD
		// (set) Token: 0x0600A3D9 RID: 41945 RVA: 0x0007FFD5 File Offset: 0x0007E1D5
		public float AreaOfSteelWithinSection { get; set; }

		// Token: 0x17002F00 RID: 12032
		// (get) Token: 0x0600A3DA RID: 41946 RVA: 0x0007FFDE File Offset: 0x0007E1DE
		// (set) Token: 0x0600A3DB RID: 41947 RVA: 0x0007FFE6 File Offset: 0x0007E1E6
		public float Rho { get; private set; }

		// Token: 0x17002F01 RID: 12033
		// (get) Token: 0x0600A3DC RID: 41948 RVA: 0x0007FFEF File Offset: 0x0007E1EF
		// (set) Token: 0x0600A3DD RID: 41949 RVA: 0x0007FFF7 File Offset: 0x0007E1F7
		public float Space { get; set; }

		// Token: 0x17002F02 RID: 12034
		// (get) Token: 0x0600A3DE RID: 41950 RVA: 0x00080000 File Offset: 0x0007E200
		// (set) Token: 0x0600A3DF RID: 41951 RVA: 0x00080008 File Offset: 0x0007E208
		public float Cover { get; set; }

		// Token: 0x17002F03 RID: 12035
		// (get) Token: 0x0600A3E0 RID: 41952 RVA: 0x00080011 File Offset: 0x0007E211
		public float[] SecondMomentOfInertia { get; }

		// Token: 0x17002F04 RID: 12036
		// (get) Token: 0x0600A3E1 RID: 41953 RVA: 0x00080019 File Offset: 0x0007E219
		public float[] Ybar { get; }

		// Token: 0x17002F05 RID: 12037
		// (get) Token: 0x0600A3E2 RID: 41954 RVA: 0x00080021 File Offset: 0x0007E221
		public float[] RadiusOfGyration { get; }

		// Token: 0x0600A3E3 RID: 41955 RVA: 0x0022EFF4 File Offset: 0x0022D1F4
		public void #q0e()
		{
			if (this.Ag > 0f)
			{
				this.Rho = 100f * this.AreaOfSteel / this.Ag;
				return;
			}
			if (this.AreaOfSteel > 0f)
			{
				this.Rho = 100f;
				return;
			}
			this.Rho = 0f;
		}

		// Token: 0x0600A3E4 RID: 41956 RVA: 0x00080029 File Offset: 0x0007E229
		public void #zPe()
		{
			this.RadiusOfGyration[0] = #xke.#eke(this.SecondMomentOfInertia[0] / this.Ag);
			this.RadiusOfGyration[1] = #xke.#eke(this.SecondMomentOfInertia[1] / this.Ag);
		}

		// Token: 0x0600A3E5 RID: 41957 RVA: 0x0022F04C File Offset: 0x0022D24C
		public void #r0e(float #Udb)
		{
			#Udb = #Udb * 3.1415927f / 180f;
			float num = #xke.#oke(#Udb);
			float num2 = #xke.#qke(#Udb);
			this.Ybar[2] = -this.Ybar[0] * num2 + this.Ybar[1] * num;
		}

		// Token: 0x0600A3E6 RID: 41958 RVA: 0x0022F094 File Offset: 0x0022D294
		public void #s0e(#x0e #L0)
		{
			this.Ag = #L0.Ag;
			this.SecondMomentOfInertia[0] = #L0.SecondMomentOfInertia[0];
			this.SecondMomentOfInertia[1] = #L0.SecondMomentOfInertia[1];
			this.SecondMomentOfInertia[2] = #L0.SecondMomentOfInertia[2];
			this.Ybar[0] = #L0.Ybar[0];
			this.Ybar[1] = #L0.Ybar[1];
			this.Ybar[2] = #L0.Ybar[2];
		}

		// Token: 0x0600A3E7 RID: 41959 RVA: 0x0022F110 File Offset: 0x0022D310
		public void #t0e()
		{
			this.Ag = 0f;
			this.SecondMomentOfInertia[0] = (this.SecondMomentOfInertia[1] = 0f);
			this.Ybar[0] = (this.Ybar[1] = (this.Ybar[2] = 0f));
		}

		// Token: 0x0600A3E8 RID: 41960 RVA: 0x0022F164 File Offset: 0x0022D364
		public void #vzc(#x0e #u0e)
		{
			float num = this.Ag + #u0e.Ag;
			float[] array = new float[3];
			for (int i = 0; i < 3; i++)
			{
				float num2 = (this.Ag * this.Ybar[i] + #u0e.Ag * #u0e.Ybar[i]) / num;
				array[i] = num2;
			}
			float num3 = this.SecondMomentOfInertia[0] + #u0e.SecondMomentOfInertia[0];
			num3 += this.Ag * #xke.#fke(this.Ybar[1] - array[1], 2f) + #u0e.Ag * #xke.#fke(#u0e.Ybar[1] - array[1], 2f);
			this.SecondMomentOfInertia[0] = num3;
			num3 = this.SecondMomentOfInertia[1] + #u0e.SecondMomentOfInertia[1];
			num3 += this.Ag * #xke.#fke(this.Ybar[0] - array[0], 2f) + #u0e.Ag * #xke.#fke(#u0e.Ybar[0] - array[0], 2f);
			this.SecondMomentOfInertia[1] = num3;
			this.Ybar[0] = array[0];
			this.Ybar[1] = array[1];
			this.Ybar[2] = array[1];
			this.Ag = num;
		}

		// Token: 0x0600A3E9 RID: 41961 RVA: 0x0022F294 File Offset: 0x0022D494
		public void #v0e(#x0e #w0e)
		{
			float num = this.Ag - #w0e.Ag;
			float[] array = new float[3];
			for (int i = 0; i < 3; i++)
			{
				float num2 = (this.Ag * this.Ybar[i] - #w0e.Ag * #w0e.Ybar[i]) / num;
				array[i] = num2;
			}
			float num3 = this.SecondMomentOfInertia[0] - #w0e.SecondMomentOfInertia[0];
			num3 += this.Ag * #xke.#fke(this.Ybar[1] - array[1], 2f) - #w0e.Ag * #xke.#fke(#w0e.Ybar[1] - array[1], 2f);
			this.SecondMomentOfInertia[0] = num3;
			num3 = this.SecondMomentOfInertia[1] - #w0e.SecondMomentOfInertia[1];
			num3 += this.Ag * #xke.#fke(this.Ybar[0] - array[0], 2f) - #w0e.Ag * #xke.#fke(#w0e.Ybar[0] - array[0], 2f);
			this.SecondMomentOfInertia[1] = num3;
			this.Ybar[0] = array[0];
			this.Ybar[1] = array[1];
			this.Ybar[2] = array[1];
			this.Ag = num;
		}

		// Token: 0x040047C7 RID: 18375
		[CompilerGenerated]
		private float #a;

		// Token: 0x040047C8 RID: 18376
		[CompilerGenerated]
		private float #b;

		// Token: 0x040047C9 RID: 18377
		[CompilerGenerated]
		private float #c;

		// Token: 0x040047CA RID: 18378
		[CompilerGenerated]
		private float #d;

		// Token: 0x040047CB RID: 18379
		[CompilerGenerated]
		private float #e;

		// Token: 0x040047CC RID: 18380
		[CompilerGenerated]
		private float #f;

		// Token: 0x040047CD RID: 18381
		[CompilerGenerated]
		private readonly float[] #g;

		// Token: 0x040047CE RID: 18382
		[CompilerGenerated]
		private readonly float[] #h;

		// Token: 0x040047CF RID: 18383
		[CompilerGenerated]
		private readonly float[] #i;
	}
}
