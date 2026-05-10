using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;
using #9Ue;
using #y6e;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output
{
	// Token: 0x02001360 RID: 4960
	[DebuggerDisplay("X = {MomentX}, Y = {MomentY}, P = {AxialLoad}}")]
	public sealed class LoadPointDrawingData : #xVe
	{
		// Token: 0x0600A629 RID: 42537 RVA: 0x00231190 File Offset: 0x0022F390
		public LoadPointDrawingData(UniaxialFactoredLoad load, #C6e consideredAxis)
		{
			if (load == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107311608));
			}
			this.Index = load.Index.GetValueOrDefault(0);
			this.AxialLoad = load.AppLoad.GetValueOrDefault(0f);
			this.MomentX = (this.MomentY = load.AppMoment.GetValueOrDefault(0f));
			this.Usf = new float?(load.Usf.GetValueOrDefault(0f));
			this.Nadepth = new float?(load.Nadepth.GetValueOrDefault(0f));
			this.Dt = new float?(load.Dt.GetValueOrDefault(0f));
			this.Eps = new float?(load.Eps.GetValueOrDefault(0f));
			this.Phi = new float?(load.Phi.GetValueOrDefault(0f));
			this.PhiPn = new float?(load.PhiPn.GetValueOrDefault(0f));
			this.PhiMn = new float?(load.PhiMn.GetValueOrDefault(0f));
			#u3e.#zif? #zif = load.Success;
			#u3e.#zif #zif2 = #u3e.#zif.#b;
			this.IsLoadCapacityExceeded = (#zif.GetValueOrDefault() == #zif2 & #zif != null);
			this.#l5e(load.Error);
			this.MinMax = new #u3e.#xif?(load.MinMax);
			this.PhiMnx = ((consideredAxis == #C6e.#a) ? load.UltimateMoment : new float?(0f));
			this.PhiMny = ((consideredAxis == #C6e.#b) ? load.UltimateMoment : new float?(0f));
			this.#eb();
		}

		// Token: 0x0600A62A RID: 42538 RVA: 0x00231360 File Offset: 0x0022F560
		public LoadPointDrawingData(BiaxialFactoredLoad load)
		{
			if (load == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107311608));
			}
			this.Index = load.Index.GetValueOrDefault(0);
			this.AxialLoad = load.AppLoad.GetValueOrDefault(0f);
			this.MomentX = load.FactLoad1.GetValueOrDefault(0f);
			this.MomentY = load.FactLoad2.GetValueOrDefault(0f);
			this.Usf = new float?(load.Usf.GetValueOrDefault(0f));
			this.Nadepth = new float?(load.Nadepth.GetValueOrDefault(0f));
			this.Dt = new float?(load.Dt.GetValueOrDefault(0f));
			this.Eps = new float?(load.Eps.GetValueOrDefault(0f));
			this.Phi = new float?(load.Phi.GetValueOrDefault(0f));
			this.PhiPn = new float?(load.PhiPn.GetValueOrDefault(0f));
			this.PhiMn = new float?(load.PhiMn.GetValueOrDefault(0f));
			#u3e.#zif? #zif = load.Success;
			#u3e.#zif #zif2 = #u3e.#zif.#b;
			this.IsLoadCapacityExceeded = (#zif.GetValueOrDefault() == #zif2 & #zif != null);
			this.#l5e(load.Error);
			this.MinMax = new #u3e.#xif?(load.MinMax);
			this.PhiMnx = load.UltimateMomentX;
			this.PhiMny = load.UltimateMomentY;
			this.#eb();
		}

		// Token: 0x0600A62B RID: 42539 RVA: 0x00231520 File Offset: 0x0022F720
		public LoadPointDrawingData(UniaxialServiceLoad load, #C6e consideredAxis)
		{
			if (load == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107311608));
			}
			this.Index = load.Index.GetValueOrDefault(0);
			this.AxialLoad = load.AppLoad.GetValueOrDefault(0f);
			this.MomentX = (this.MomentY = load.AppMoment.GetValueOrDefault(0f));
			this.Usf = new float?(load.Usf.GetValueOrDefault(0f));
			this.Nadepth = new float?(load.Nadepth.GetValueOrDefault(0f));
			this.Dt = new float?(load.Dt.GetValueOrDefault(0f));
			this.Eps = new float?(load.Eps.GetValueOrDefault(0f));
			this.Phi = new float?(load.Phi.GetValueOrDefault(0f));
			this.PhiPn = new float?(load.PhiPn.GetValueOrDefault(0f));
			this.PhiMn = new float?(load.PhiMn.GetValueOrDefault(0f));
			#u3e.#zif? #zif = load.Success;
			#u3e.#zif #zif2 = #u3e.#zif.#b;
			this.IsLoadCapacityExceeded = (#zif.GetValueOrDefault() == #zif2 & #zif != null);
			this.#l5e(load.Error);
			this.MinMax = new #u3e.#xif?(load.MinMax);
			this.PhiMnx = ((consideredAxis == #C6e.#a) ? load.UltimateMoment : new float?(0f));
			this.PhiMny = ((consideredAxis == #C6e.#b) ? load.UltimateMoment : new float?(0f));
			this.TopBottom = ((load.ServiceLoadIndex != null && load.LoadCombinationIndex != null) ? #Phc.#3hc(107361434) : #Phc.#3hc(107361429));
			this.#eb();
		}

		// Token: 0x0600A62C RID: 42540 RVA: 0x0023172C File Offset: 0x0022F92C
		public LoadPointDrawingData(BiaxialServiceLoad load)
		{
			if (load == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107311608));
			}
			this.Index = load.Index.GetValueOrDefault(0);
			this.AxialLoad = load.AppLoad.GetValueOrDefault(0f);
			this.MomentX = load.FactLoad2.GetValueOrDefault(0f);
			this.MomentY = load.FactLoad3.GetValueOrDefault(0f);
			this.Usf = new float?(load.Usf.GetValueOrDefault(0f));
			this.Nadepth = new float?(load.Nadepth.GetValueOrDefault(0f));
			this.Dt = new float?(load.Dt.GetValueOrDefault(0f));
			this.Eps = new float?(load.Eps.GetValueOrDefault(0f));
			this.Phi = new float?(load.Phi.GetValueOrDefault(0f));
			this.PhiPn = new float?(load.PhiPn.GetValueOrDefault(0f));
			this.PhiMn = new float?(load.PhiMn.GetValueOrDefault(0f));
			#u3e.#zif? #zif = load.Success;
			#u3e.#zif #zif2 = #u3e.#zif.#b;
			this.IsLoadCapacityExceeded = (#zif.GetValueOrDefault() == #zif2 & #zif != null);
			this.#l5e(load.Error);
			this.MinMax = new #u3e.#xif?(load.MinMax);
			this.PhiMnx = load.UltimateMomentX;
			this.PhiMny = load.UltimateMomentY;
			this.TopBottom = ((load.ServiceLoadIndex != null && load.LoadCombinationIndex != null) ? #Phc.#3hc(107361434) : #Phc.#3hc(107361429));
			this.#eb();
		}

		// Token: 0x0600A62D RID: 42541 RVA: 0x00231928 File Offset: 0x0022FB28
		private void #eb()
		{
			double num = Math.Atan2((double)this.MomentY, (double)this.MomentX);
			num = (num * 180.0 / 3.141592653589793 + 360.0) % 360.0;
			this.Angle = (float)num;
		}

		// Token: 0x17003012 RID: 12306
		// (get) Token: 0x0600A62E RID: 42542 RVA: 0x000816F8 File Offset: 0x0007F8F8
		// (set) Token: 0x0600A62F RID: 42543 RVA: 0x00081700 File Offset: 0x0007F900
		public int Index { get; set; }

		// Token: 0x17003013 RID: 12307
		// (get) Token: 0x0600A630 RID: 42544 RVA: 0x00081709 File Offset: 0x0007F909
		// (set) Token: 0x0600A631 RID: 42545 RVA: 0x00081711 File Offset: 0x0007F911
		public float AxialLoad { get; set; }

		// Token: 0x17003014 RID: 12308
		// (get) Token: 0x0600A632 RID: 42546 RVA: 0x0008171A File Offset: 0x0007F91A
		// (set) Token: 0x0600A633 RID: 42547 RVA: 0x00081722 File Offset: 0x0007F922
		public bool IsLoadCapacityExceeded { get; set; }

		// Token: 0x17003015 RID: 12309
		// (get) Token: 0x0600A634 RID: 42548 RVA: 0x0008172B File Offset: 0x0007F92B
		// (set) Token: 0x0600A635 RID: 42549 RVA: 0x00081733 File Offset: 0x0007F933
		public #FVe Flags { get; set; }

		// Token: 0x17003016 RID: 12310
		// (get) Token: 0x0600A636 RID: 42550 RVA: 0x0008173C File Offset: 0x0007F93C
		// (set) Token: 0x0600A637 RID: 42551 RVA: 0x00081744 File Offset: 0x0007F944
		public float MomentX { get; set; }

		// Token: 0x17003017 RID: 12311
		// (get) Token: 0x0600A638 RID: 42552 RVA: 0x0008174D File Offset: 0x0007F94D
		// (set) Token: 0x0600A639 RID: 42553 RVA: 0x00081755 File Offset: 0x0007F955
		public float MomentY { get; set; }

		// Token: 0x17003018 RID: 12312
		// (get) Token: 0x0600A63A RID: 42554 RVA: 0x0008175E File Offset: 0x0007F95E
		// (set) Token: 0x0600A63B RID: 42555 RVA: 0x00081766 File Offset: 0x0007F966
		public bool IsInner { get; set; }

		// Token: 0x17003019 RID: 12313
		// (get) Token: 0x0600A63C RID: 42556 RVA: 0x0008176F File Offset: 0x0007F96F
		// (set) Token: 0x0600A63D RID: 42557 RVA: 0x00081777 File Offset: 0x0007F977
		public float? AlternatePMMoment { get; set; }

		// Token: 0x1700301A RID: 12314
		// (get) Token: 0x0600A63E RID: 42558 RVA: 0x00081780 File Offset: 0x0007F980
		// (set) Token: 0x0600A63F RID: 42559 RVA: 0x00081788 File Offset: 0x0007F988
		public float? Usf { get; set; }

		// Token: 0x1700301B RID: 12315
		// (get) Token: 0x0600A640 RID: 42560 RVA: 0x00081791 File Offset: 0x0007F991
		// (set) Token: 0x0600A641 RID: 42561 RVA: 0x00081799 File Offset: 0x0007F999
		public float? Nadepth { get; set; }

		// Token: 0x1700301C RID: 12316
		// (get) Token: 0x0600A642 RID: 42562 RVA: 0x000817A2 File Offset: 0x0007F9A2
		// (set) Token: 0x0600A643 RID: 42563 RVA: 0x000817AA File Offset: 0x0007F9AA
		public float? Dt { get; set; }

		// Token: 0x1700301D RID: 12317
		// (get) Token: 0x0600A644 RID: 42564 RVA: 0x000817B3 File Offset: 0x0007F9B3
		// (set) Token: 0x0600A645 RID: 42565 RVA: 0x000817BB File Offset: 0x0007F9BB
		public float? Eps { get; set; }

		// Token: 0x1700301E RID: 12318
		// (get) Token: 0x0600A646 RID: 42566 RVA: 0x000817C4 File Offset: 0x0007F9C4
		// (set) Token: 0x0600A647 RID: 42567 RVA: 0x000817CC File Offset: 0x0007F9CC
		public float? Phi { get; set; }

		// Token: 0x1700301F RID: 12319
		// (get) Token: 0x0600A648 RID: 42568 RVA: 0x000817D5 File Offset: 0x0007F9D5
		// (set) Token: 0x0600A649 RID: 42569 RVA: 0x000817DD File Offset: 0x0007F9DD
		public float? PhiPn { get; set; }

		// Token: 0x17003020 RID: 12320
		// (get) Token: 0x0600A64A RID: 42570 RVA: 0x000817E6 File Offset: 0x0007F9E6
		// (set) Token: 0x0600A64B RID: 42571 RVA: 0x000817EE File Offset: 0x0007F9EE
		public float? PhiMn { get; set; }

		// Token: 0x17003021 RID: 12321
		// (get) Token: 0x0600A64C RID: 42572 RVA: 0x000817F7 File Offset: 0x0007F9F7
		// (set) Token: 0x0600A64D RID: 42573 RVA: 0x000817FF File Offset: 0x0007F9FF
		public #u3e.#xif? MinMax { get; set; }

		// Token: 0x17003022 RID: 12322
		// (get) Token: 0x0600A64E RID: 42574 RVA: 0x00081808 File Offset: 0x0007FA08
		// (set) Token: 0x0600A64F RID: 42575 RVA: 0x00081810 File Offset: 0x0007FA10
		public float? PhiMnx { get; set; }

		// Token: 0x17003023 RID: 12323
		// (get) Token: 0x0600A650 RID: 42576 RVA: 0x00081819 File Offset: 0x0007FA19
		// (set) Token: 0x0600A651 RID: 42577 RVA: 0x00081821 File Offset: 0x0007FA21
		public float? PhiMny { get; set; }

		// Token: 0x17003024 RID: 12324
		// (get) Token: 0x0600A652 RID: 42578 RVA: 0x0008182A File Offset: 0x0007FA2A
		public CapacityRatioCalculation CapacityRatio { get; } = new CapacityRatioCalculation();

		// Token: 0x17003025 RID: 12325
		// (get) Token: 0x0600A653 RID: 42579 RVA: 0x00081832 File Offset: 0x0007FA32
		// (set) Token: 0x0600A654 RID: 42580 RVA: 0x0008183A File Offset: 0x0007FA3A
		public float Angle { get; private set; }

		// Token: 0x17003026 RID: 12326
		// (get) Token: 0x0600A655 RID: 42581 RVA: 0x00081843 File Offset: 0x0007FA43
		// (set) Token: 0x0600A656 RID: 42582 RVA: 0x0008184B File Offset: 0x0007FA4B
		public string TopBottom { get; set; }

		// Token: 0x0600A657 RID: 42583 RVA: 0x0023197C File Offset: 0x0022FB7C
		public bool #Bjb(LoadPointDrawingData #ycb)
		{
			if (#ycb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107311567));
			}
			return #Emc.#Bjb(new double?((double)#ycb.AxialLoad), new double?((double)this.AxialLoad)) && #Emc.#Bjb(new double?((double)#ycb.MomentX), new double?((double)this.MomentX)) && #Emc.#Bjb(new double?((double)#ycb.MomentY), new double?((double)this.MomentY));
		}

		// Token: 0x0600A658 RID: 42584 RVA: 0x002319FC File Offset: 0x0022FBFC
		private void #l5e(#u3e.#Aif? #FY)
		{
			if (#FY == null)
			{
				return;
			}
			if (#FY.Value.HasFlag(#u3e.#Aif.#c))
			{
				this.Flags |= #FVe.#c;
			}
			if (#FY.Value.HasFlag(#u3e.#Aif.#e))
			{
				this.Flags |= #FVe.#e;
			}
			if (#FY.Value.HasFlag(#u3e.#Aif.#b))
			{
				this.Flags |= #FVe.#b;
			}
			if (#FY.Value.HasFlag(#u3e.#Aif.#d))
			{
				this.Flags |= #FVe.#d;
			}
		}

		// Token: 0x0600A659 RID: 42585 RVA: 0x00231AB0 File Offset: 0x0022FCB0
		private void #l5e(#u3e.#yif? #FY)
		{
			if (#FY == null)
			{
				return;
			}
			if (#FY.Value.HasFlag(#u3e.#yif.#c))
			{
				this.Flags |= #FVe.#c;
			}
			if (#FY.Value.HasFlag(#u3e.#yif.#e))
			{
				this.Flags |= #FVe.#e;
			}
			if (#FY.Value.HasFlag(#u3e.#yif.#b))
			{
				this.Flags |= #FVe.#b;
			}
			if (#FY.Value.HasFlag(#u3e.#yif.#d))
			{
				this.Flags |= #FVe.#d;
			}
			if (#FY.Value.HasFlag(#u3e.#yif.#f))
			{
				this.Flags |= #FVe.#f;
			}
			if (#FY.Value.HasFlag(#u3e.#yif.#g))
			{
				this.Flags |= #FVe.#g;
			}
		}

		// Token: 0x04004926 RID: 18726
		[CompilerGenerated]
		private int #a;

		// Token: 0x04004927 RID: 18727
		[CompilerGenerated]
		private float #b;

		// Token: 0x04004928 RID: 18728
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04004929 RID: 18729
		[CompilerGenerated]
		private #FVe #d;

		// Token: 0x0400492A RID: 18730
		[CompilerGenerated]
		private float #e;

		// Token: 0x0400492B RID: 18731
		[CompilerGenerated]
		private float #f;

		// Token: 0x0400492C RID: 18732
		[CompilerGenerated]
		private bool #g;

		// Token: 0x0400492D RID: 18733
		[CompilerGenerated]
		private float? #h;

		// Token: 0x0400492E RID: 18734
		[CompilerGenerated]
		private float? #i;

		// Token: 0x0400492F RID: 18735
		[CompilerGenerated]
		private float? #j;

		// Token: 0x04004930 RID: 18736
		[CompilerGenerated]
		private float? #k;

		// Token: 0x04004931 RID: 18737
		[CompilerGenerated]
		private float? #l;

		// Token: 0x04004932 RID: 18738
		[CompilerGenerated]
		private float? #m;

		// Token: 0x04004933 RID: 18739
		[CompilerGenerated]
		private float? #n;

		// Token: 0x04004934 RID: 18740
		[CompilerGenerated]
		private float? #o;

		// Token: 0x04004935 RID: 18741
		[CompilerGenerated]
		private #u3e.#xif? #p;

		// Token: 0x04004936 RID: 18742
		[CompilerGenerated]
		private float? #q;

		// Token: 0x04004937 RID: 18743
		[CompilerGenerated]
		private float? #r;

		// Token: 0x04004938 RID: 18744
		[CompilerGenerated]
		private readonly CapacityRatioCalculation #s;

		// Token: 0x04004939 RID: 18745
		[CompilerGenerated]
		private float #t;

		// Token: 0x0400493A RID: 18746
		[CompilerGenerated]
		private string #u;
	}
}
