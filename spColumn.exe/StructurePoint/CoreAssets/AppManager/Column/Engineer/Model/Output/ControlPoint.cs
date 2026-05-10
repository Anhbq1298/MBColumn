using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using #hZe;
using #wUe;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output
{
	// Token: 0x0200134B RID: 4939
	public sealed class ControlPoint
	{
		// Token: 0x0600A552 RID: 42322 RVA: 0x002307CC File Offset: 0x0022E9CC
		public ControlPoint(ControlPoint.#uif type, float p, float xm, float ym, float c, float dt, float eps, float? angle)
		{
			this.Type = type;
			this.P = p;
			this.Xm = xm;
			this.Ym = ym;
			this.C = c;
			this.Dt = dt;
			this.Eps = eps;
			this.Phi = null;
			if (angle != null)
			{
				this.ControlPointAxis = (#xke.#dke((int)angle.Value % 180) ? ControlPoint.#tif.#b : ControlPoint.#tif.#a);
				float? num = angle;
				float num2 = (float)180;
				this.IsNegative = (num.GetValueOrDefault() >= num2 & num != null);
			}
		}

		// Token: 0x0600A553 RID: 42323 RVA: 0x00230870 File Offset: 0x0022EA70
		public ControlPoint(ControlPoint.#uif type, #TZe columnLoad, float c, float dt, float eps, float? phi) : this(type, columnLoad.AxialLoad, columnLoad.MomentX, columnLoad.MomentY, c, dt, eps, phi)
		{
		}

		// Token: 0x17002FA1 RID: 12193
		// (get) Token: 0x0600A554 RID: 42324 RVA: 0x00080F8E File Offset: 0x0007F18E
		public float P { get; }

		// Token: 0x17002FA2 RID: 12194
		// (get) Token: 0x0600A555 RID: 42325 RVA: 0x00080F96 File Offset: 0x0007F196
		public float Xm { get; }

		// Token: 0x17002FA3 RID: 12195
		// (get) Token: 0x0600A556 RID: 42326 RVA: 0x00080F9E File Offset: 0x0007F19E
		public float Ym { get; }

		// Token: 0x17002FA4 RID: 12196
		// (get) Token: 0x0600A557 RID: 42327 RVA: 0x00080FA6 File Offset: 0x0007F1A6
		public float C { get; }

		// Token: 0x17002FA5 RID: 12197
		// (get) Token: 0x0600A558 RID: 42328 RVA: 0x00080FAE File Offset: 0x0007F1AE
		public float Dt { get; }

		// Token: 0x17002FA6 RID: 12198
		// (get) Token: 0x0600A559 RID: 42329 RVA: 0x00080FB6 File Offset: 0x0007F1B6
		public float Eps { get; }

		// Token: 0x17002FA7 RID: 12199
		// (get) Token: 0x0600A55A RID: 42330 RVA: 0x00080FBE File Offset: 0x0007F1BE
		// (set) Token: 0x0600A55B RID: 42331 RVA: 0x00080FC6 File Offset: 0x0007F1C6
		public float? Phi { get; set; }

		// Token: 0x17002FA8 RID: 12200
		// (get) Token: 0x0600A55C RID: 42332 RVA: 0x00080FCF File Offset: 0x0007F1CF
		// (set) Token: 0x0600A55D RID: 42333 RVA: 0x00080FD7 File Offset: 0x0007F1D7
		public ControlPoint.#tif ControlPointAxis { get; set; }

		// Token: 0x17002FA9 RID: 12201
		// (get) Token: 0x0600A55E RID: 42334 RVA: 0x00080FE0 File Offset: 0x0007F1E0
		// (set) Token: 0x0600A55F RID: 42335 RVA: 0x00080FE8 File Offset: 0x0007F1E8
		public bool IsNegative { get; set; }

		// Token: 0x17002FAA RID: 12202
		// (get) Token: 0x0600A560 RID: 42336 RVA: 0x00080FF1 File Offset: 0x0007F1F1
		public string Label
		{
			get
			{
				return this.#g3e();
			}
		}

		// Token: 0x17002FAB RID: 12203
		// (get) Token: 0x0600A561 RID: 42337 RVA: 0x00080FF9 File Offset: 0x0007F1F9
		// (set) Token: 0x0600A562 RID: 42338 RVA: 0x00081001 File Offset: 0x0007F201
		public bool HasPhiParadox { get; set; }

		// Token: 0x17002FAC RID: 12204
		// (get) Token: 0x0600A563 RID: 42339 RVA: 0x0008100A File Offset: 0x0007F20A
		public ControlPoint.#uif Type { get; }

		// Token: 0x0600A564 RID: 42340 RVA: 0x002308A0 File Offset: 0x0022EAA0
		private string #g3e()
		{
			string arg = this.IsNegative ? #Phc.#3hc(107408434) : string.Empty;
			return string.Format(#Phc.#3hc(107311285), arg, this.#h3e(), this.#i3e());
		}

		// Token: 0x0600A565 RID: 42341 RVA: 0x002308E4 File Offset: 0x0022EAE4
		private string #h3e()
		{
			ControlPoint.#tif #tif = this.ControlPointAxis;
			if (#tif == ControlPoint.#tif.#a)
			{
				return #Phc.#3hc(107408964);
			}
			if (#tif != ControlPoint.#tif.#b)
			{
				throw new ArgumentOutOfRangeException();
			}
			return #Phc.#3hc(107408991);
		}

		// Token: 0x0600A566 RID: 42342 RVA: 0x0023091C File Offset: 0x0022EB1C
		private string #i3e()
		{
			switch (this.Type)
			{
			case ControlPoint.#uif.#a:
				return #Phc.#3hc(107286793);
			case ControlPoint.#uif.#b:
				return #Phc.#3hc(107286804);
			case ControlPoint.#uif.#c:
				return #Phc.#3hc(107311236);
			case ControlPoint.#uif.#d:
				return #Phc.#3hc(107311255);
			case ControlPoint.#uif.#e:
				return #Phc.#3hc(107286217);
			case ControlPoint.#uif.#f:
				return #Phc.#3hc(107311206);
			case ControlPoint.#uif.#g:
				return #Phc.#3hc(107286228);
			case ControlPoint.#uif.#h:
				return #Phc.#3hc(107286207);
			case ControlPoint.#uif.#i:
				return #Phc.#3hc(107286158);
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x0600A567 RID: 42343 RVA: 0x002309C4 File Offset: 0x0022EBC4
		public string #j3e()
		{
			string arg = this.IsNegative ? #Phc.#3hc(107408434) : #Phc.#3hc(107381628);
			return string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107226561), arg, this.#h3e());
		}

		// Token: 0x04004895 RID: 18581
		[CompilerGenerated]
		private readonly float #a;

		// Token: 0x04004896 RID: 18582
		[CompilerGenerated]
		private readonly float #b;

		// Token: 0x04004897 RID: 18583
		[CompilerGenerated]
		private readonly float #c;

		// Token: 0x04004898 RID: 18584
		[CompilerGenerated]
		private readonly float #d;

		// Token: 0x04004899 RID: 18585
		[CompilerGenerated]
		private readonly float #e;

		// Token: 0x0400489A RID: 18586
		[CompilerGenerated]
		private readonly float #f;

		// Token: 0x0400489B RID: 18587
		[CompilerGenerated]
		private float? #g;

		// Token: 0x0400489C RID: 18588
		[CompilerGenerated]
		private ControlPoint.#tif #h;

		// Token: 0x0400489D RID: 18589
		[CompilerGenerated]
		private bool #i;

		// Token: 0x0400489E RID: 18590
		[CompilerGenerated]
		private bool #j;

		// Token: 0x0400489F RID: 18591
		[CompilerGenerated]
		private readonly ControlPoint.#uif #k;

		// Token: 0x0200134C RID: 4940
		public enum #tif
		{
			// Token: 0x040048A1 RID: 18593
			#a,
			// Token: 0x040048A2 RID: 18594
			#b
		}

		// Token: 0x0200134D RID: 4941
		public enum #uif
		{
			// Token: 0x040048A4 RID: 18596
			#a,
			// Token: 0x040048A5 RID: 18597
			#b,
			// Token: 0x040048A6 RID: 18598
			#c,
			// Token: 0x040048A7 RID: 18599
			#d,
			// Token: 0x040048A8 RID: 18600
			#e,
			// Token: 0x040048A9 RID: 18601
			#f,
			// Token: 0x040048AA RID: 18602
			#g,
			// Token: 0x040048AB RID: 18603
			#h,
			// Token: 0x040048AC RID: 18604
			#i
		}
	}
}
