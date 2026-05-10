using System;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Misc;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #4vc
{
	// Token: 0x0200080F RID: 2063
	internal sealed class #ewc
	{
		// Token: 0x0600423F RID: 16959 RVA: 0x0013619C File Offset: 0x0013439C
		public #ewc(Point #tEb, double #Udb, BoundingBoxData #fwc)
		{
			this.Location = #tEb;
			if (#Emc.#Amc(Math.Abs(#Udb), 180.0) || #Emc.#Amc(#Udb, 0.0))
			{
				#Udb = 0.0;
			}
			if (#Emc.#Amc(Math.Abs(#Udb), 90.0))
			{
				#Udb = 90.0;
			}
			this.Angle = #Udb;
			this.EditorWorkspaceSize = #fwc;
			this.#Ovc();
		}

		// Token: 0x06004240 RID: 16960 RVA: 0x00136220 File Offset: 0x00134420
		public #ewc(#ewc #gwc, BoundingBoxData #fwc)
		{
			#X0d.#V0d(#gwc, #Phc.#3hc(107458527), Component.Geometry, #Phc.#3hc(107458478));
			this.Angle = #gwc.Angle;
			this.Location = #gwc.Location;
			this.EditorWorkspaceSize = #fwc;
			this.#Ovc();
		}

		// Token: 0x1700138E RID: 5006
		// (get) Token: 0x06004241 RID: 16961 RVA: 0x00037A46 File Offset: 0x00035C46
		// (set) Token: 0x06004242 RID: 16962 RVA: 0x00037A52 File Offset: 0x00035C52
		public double Angle { get; private set; }

		// Token: 0x1700138F RID: 5007
		// (get) Token: 0x06004243 RID: 16963 RVA: 0x00037A63 File Offset: 0x00035C63
		// (set) Token: 0x06004244 RID: 16964 RVA: 0x00037A6F File Offset: 0x00035C6F
		public BoundingBoxData EditorWorkspaceSize { get; private set; }

		// Token: 0x17001390 RID: 5008
		// (get) Token: 0x06004245 RID: 16965 RVA: 0x00037A80 File Offset: 0x00035C80
		// (set) Token: 0x06004246 RID: 16966 RVA: 0x00037A8C File Offset: 0x00035C8C
		public Point Location { get; private set; }

		// Token: 0x17001391 RID: 5009
		// (get) Token: 0x06004247 RID: 16967 RVA: 0x00037A9D File Offset: 0x00035C9D
		public bool IsRightAngle
		{
			get
			{
				return this.Angle == 90.0;
			}
		}

		// Token: 0x17001392 RID: 5010
		// (get) Token: 0x06004248 RID: 16968 RVA: 0x00037AB8 File Offset: 0x00035CB8
		public bool IsZeroAngle
		{
			get
			{
				return this.Angle == 0.0;
			}
		}

		// Token: 0x17001393 RID: 5011
		// (get) Token: 0x06004249 RID: 16969 RVA: 0x00037AD3 File Offset: 0x00035CD3
		// (set) Token: 0x0600424A RID: 16970 RVA: 0x00037ADF File Offset: 0x00035CDF
		public GeneralLineEquation LineEquation { get; private set; }

		// Token: 0x17001394 RID: 5012
		// (get) Token: 0x0600424B RID: 16971 RVA: 0x00037AF0 File Offset: 0x00035CF0
		// (set) Token: 0x0600424C RID: 16972 RVA: 0x00037AFC File Offset: 0x00035CFC
		public SegmentData LineSegment { get; private set; }

		// Token: 0x0600424D RID: 16973 RVA: 0x00037B0D File Offset: 0x00035D0D
		public void #dwc(Point #tEb)
		{
			this.Location = #tEb;
			this.#Ovc();
		}

		// Token: 0x0600424E RID: 16974 RVA: 0x00037B30 File Offset: 0x00035D30
		public void #dwc(double #Udb)
		{
			this.Angle = #Udb;
			this.#Ovc();
		}

		// Token: 0x0600424F RID: 16975 RVA: 0x00136274 File Offset: 0x00134474
		private void #Ovc()
		{
			for (;;)
			{
				this.LineEquation = new GeneralLineEquation(this.Location, this.Angle, true);
				while (!false)
				{
					this.LineSegment = #jsc.#asc(this, this.EditorWorkspaceSize);
					if (8 != 0)
					{
						return;
					}
				}
			}
		}

		// Token: 0x04001DE3 RID: 7651
		[CompilerGenerated]
		private double #a;

		// Token: 0x04001DE4 RID: 7652
		[CompilerGenerated]
		private BoundingBoxData #b;

		// Token: 0x04001DE5 RID: 7653
		[CompilerGenerated]
		private Point #c;

		// Token: 0x04001DE6 RID: 7654
		[CompilerGenerated]
		private GeneralLineEquation #d;

		// Token: 0x04001DE7 RID: 7655
		[CompilerGenerated]
		private SegmentData #e;
	}
}
