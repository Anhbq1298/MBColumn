using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;

namespace #NHe
{
	// Token: 0x02001260 RID: 4704
	internal sealed class #OJe
	{
		// Token: 0x06009DEC RID: 40428 RVA: 0x00218ADC File Offset: 0x00216CDC
		public #OJe(LoadPointDrawingData #ivb, float #Udb)
		{
			this.DrawingAngle = (float)Math.Round((double)#Udb, 0);
			double? num = LoadPointsHelper.#0Tc(new double?(Math.Round((double)#ivb.MomentX, 1)), new double?(Math.Round((double)#ivb.MomentY, 1)));
			this.LoadAngle = ((num != null) ? ((float)num.Value) : 0f);
		}

		// Token: 0x17002D84 RID: 11652
		// (get) Token: 0x06009DED RID: 40429 RVA: 0x0007C528 File Offset: 0x0007A728
		// (set) Token: 0x06009DEE RID: 40430 RVA: 0x0007C530 File Offset: 0x0007A730
		public float DrawingAngle { get; set; }

		// Token: 0x17002D85 RID: 11653
		// (get) Token: 0x06009DEF RID: 40431 RVA: 0x0007C539 File Offset: 0x0007A739
		// (set) Token: 0x06009DF0 RID: 40432 RVA: 0x0007C541 File Offset: 0x0007A741
		public float LoadAngle { get; set; }

		// Token: 0x17002D86 RID: 11654
		// (get) Token: 0x06009DF1 RID: 40433 RVA: 0x0007C54A File Offset: 0x0007A74A
		public float OppositeDrawingAngle
		{
			get
			{
				return (this.DrawingAngle + 180f) % 360f;
			}
		}

		// Token: 0x17002D87 RID: 11655
		// (get) Token: 0x06009DF2 RID: 40434 RVA: 0x0007C55E File Offset: 0x0007A75E
		public float LowerBound
		{
			get
			{
				return this.DrawingAngle - 0.5f;
			}
		}

		// Token: 0x17002D88 RID: 11656
		// (get) Token: 0x06009DF3 RID: 40435 RVA: 0x0007C56C File Offset: 0x0007A76C
		public float UpperBound
		{
			get
			{
				return this.DrawingAngle + 0.5f;
			}
		}

		// Token: 0x17002D89 RID: 11657
		// (get) Token: 0x06009DF4 RID: 40436 RVA: 0x0007C57A File Offset: 0x0007A77A
		public float OppositeLowerBound
		{
			get
			{
				return this.OppositeDrawingAngle - 0.5f;
			}
		}

		// Token: 0x17002D8A RID: 11658
		// (get) Token: 0x06009DF5 RID: 40437 RVA: 0x0007C588 File Offset: 0x0007A788
		public float OppositeUpperBound
		{
			get
			{
				return this.OppositeDrawingAngle + 0.5f;
			}
		}

		// Token: 0x06009DF6 RID: 40438 RVA: 0x0007C596 File Offset: 0x0007A796
		public bool #MJe()
		{
			return this.LoadAngle >= this.LowerBound && this.LoadAngle < this.UpperBound;
		}

		// Token: 0x06009DF7 RID: 40439 RVA: 0x0007C5B6 File Offset: 0x0007A7B6
		public bool #NJe()
		{
			return this.LoadAngle >= this.OppositeLowerBound && this.LoadAngle < this.OppositeUpperBound;
		}

		// Token: 0x04004453 RID: 17491
		public const float #a = 0.5f;

		// Token: 0x04004454 RID: 17492
		[CompilerGenerated]
		private float #b;

		// Token: 0x04004455 RID: 17493
		[CompilerGenerated]
		private float #c;
	}
}
