using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #Gke;
using #P6e;
using #wUe;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input
{
	// Token: 0x02001365 RID: 4965
	public sealed class InputModel
	{
		// Token: 0x1700303C RID: 12348
		// (get) Token: 0x0600A692 RID: 42642 RVA: 0x00081A8A File Offset: 0x0007FC8A
		// (set) Token: 0x0600A693 RID: 42643 RVA: 0x00081A92 File Offset: 0x0007FC92
		public int InvestigateInputFlag { get; private set; }

		// Token: 0x1700303D RID: 12349
		// (get) Token: 0x0600A694 RID: 42644 RVA: 0x00081A9B File Offset: 0x0007FC9B
		// (set) Token: 0x0600A695 RID: 42645 RVA: 0x00081AA3 File Offset: 0x0007FCA3
		public int DesignInputFlag { get; private set; }

		// Token: 0x1700303E RID: 12350
		// (get) Token: 0x0600A696 RID: 42646 RVA: 0x00081AAC File Offset: 0x0007FCAC
		// (set) Token: 0x0600A697 RID: 42647 RVA: 0x00081AB4 File Offset: 0x0007FCB4
		public int SlendernessInputFlag { get; private set; }

		// Token: 0x1700303F RID: 12351
		// (get) Token: 0x0600A698 RID: 42648 RVA: 0x00081ABD File Offset: 0x0007FCBD
		// (set) Token: 0x0600A699 RID: 42649 RVA: 0x00081AC5 File Offset: 0x0007FCC5
		public Options Options { get; private set; }

		// Token: 0x17003040 RID: 12352
		// (get) Token: 0x0600A69A RID: 42650 RVA: 0x00081ACE File Offset: 0x0007FCCE
		// (set) Token: 0x0600A69B RID: 42651 RVA: 0x00081AD6 File Offset: 0x0007FCD6
		public #N5e DesignCode { get; private set; }

		// Token: 0x17003041 RID: 12353
		// (get) Token: 0x0600A69C RID: 42652 RVA: 0x00081ADF File Offset: 0x0007FCDF
		// (set) Token: 0x0600A69D RID: 42653 RVA: 0x00081AE7 File Offset: 0x0007FCE7
		public #53 Ties { get; private set; }

		// Token: 0x17003042 RID: 12354
		// (get) Token: 0x0600A69E RID: 42654 RVA: 0x00081AF0 File Offset: 0x0007FCF0
		// (set) Token: 0x0600A69F RID: 42655 RVA: 0x00081AF8 File Offset: 0x0007FCF8
		public float[] DesignDimensions { get; private set; }

		// Token: 0x17003043 RID: 12355
		// (get) Token: 0x0600A6A0 RID: 42656 RVA: 0x00081B01 File Offset: 0x0007FD01
		// (set) Token: 0x0600A6A1 RID: 42657 RVA: 0x00081B09 File Offset: 0x0007FD09
		public #K2 MaterialProperties { get; private set; }

		// Token: 0x17003044 RID: 12356
		// (get) Token: 0x0600A6A2 RID: 42658 RVA: 0x00081B12 File Offset: 0x0007FD12
		// (set) Token: 0x0600A6A3 RID: 42659 RVA: 0x00081B1A File Offset: 0x0007FD1A
		public float StiffnessReductionFactorPhi { get; private set; }

		// Token: 0x17003045 RID: 12357
		// (get) Token: 0x0600A6A4 RID: 42660 RVA: 0x00081B23 File Offset: 0x0007FD23
		// (set) Token: 0x0600A6A5 RID: 42661 RVA: 0x00081B2B File Offset: 0x0007FD2B
		public StandardBar[] Bars { get; private set; }

		// Token: 0x17003046 RID: 12358
		// (get) Token: 0x0600A6A6 RID: 42662 RVA: 0x00081B34 File Offset: 0x0007FD34
		// (set) Token: 0x0600A6A7 RID: 42663 RVA: 0x00081B3C File Offset: 0x0007FD3C
		public #d6e ReinforcementRatios { get; private set; }

		// Token: 0x17003047 RID: 12359
		// (get) Token: 0x0600A6A8 RID: 42664 RVA: 0x00081B45 File Offset: 0x0007FD45
		// (set) Token: 0x0600A6A9 RID: 42665 RVA: 0x00081B4D File Offset: 0x0007FD4D
		public float MinRebarClearSpacing { get; private set; }

		// Token: 0x17003048 RID: 12360
		// (get) Token: 0x0600A6AA RID: 42666 RVA: 0x00081B56 File Offset: 0x0007FD56
		// (set) Token: 0x0600A6AB RID: 42667 RVA: 0x00081B5E File Offset: 0x0007FD5E
		public float DesignToRequiredRatio { get; private set; }

		// Token: 0x17003049 RID: 12361
		// (get) Token: 0x0600A6AC RID: 42668 RVA: 0x00081B67 File Offset: 0x0007FD67
		// (set) Token: 0x0600A6AD RID: 42669 RVA: 0x00081B6F File Offset: 0x0007FD6F
		public #c6e DesignReinforcement { get; private set; }

		// Token: 0x1700304A RID: 12362
		// (get) Token: 0x0600A6AE RID: 42670 RVA: 0x00081B78 File Offset: 0x0007FD78
		// (set) Token: 0x0600A6AF RID: 42671 RVA: 0x00081B80 File Offset: 0x0007FD80
		public #X3 DesignedColumnX { get; private set; }

		// Token: 0x1700304B RID: 12363
		// (get) Token: 0x0600A6B0 RID: 42672 RVA: 0x00081B89 File Offset: 0x0007FD89
		// (set) Token: 0x0600A6B1 RID: 42673 RVA: 0x00081B91 File Offset: 0x0007FD91
		public #X3 DesignedColumnY { get; private set; }

		// Token: 0x1700304C RID: 12364
		// (get) Token: 0x0600A6B2 RID: 42674 RVA: 0x00081B9A File Offset: 0x0007FD9A
		// (set) Token: 0x0600A6B3 RID: 42675 RVA: 0x00081BA2 File Offset: 0x0007FDA2
		public SlendernessOfBeams BeamX { get; private set; }

		// Token: 0x1700304D RID: 12365
		// (get) Token: 0x0600A6B4 RID: 42676 RVA: 0x00081BAB File Offset: 0x0007FDAB
		// (set) Token: 0x0600A6B5 RID: 42677 RVA: 0x00081BB3 File Offset: 0x0007FDB3
		public SlendernessOfBeams BeamY { get; private set; }

		// Token: 0x1700304E RID: 12366
		// (get) Token: 0x0600A6B6 RID: 42678 RVA: 0x00081BBC File Offset: 0x0007FDBC
		// (set) Token: 0x0600A6B7 RID: 42679 RVA: 0x00081BC4 File Offset: 0x0007FDC4
		public float[] SustainedLoadFactor { get; private set; }

		// Token: 0x1700304F RID: 12367
		// (get) Token: 0x0600A6B8 RID: 42680 RVA: 0x00081BCD File Offset: 0x0007FDCD
		// (set) Token: 0x0600A6B9 RID: 42681 RVA: 0x00081BD5 File Offset: 0x0007FDD5
		public float[][] LoadFactors { get; private set; }

		// Token: 0x17003050 RID: 12368
		// (get) Token: 0x0600A6BA RID: 42682 RVA: 0x00081BDE File Offset: 0x0007FDDE
		// (set) Token: 0x0600A6BB RID: 42683 RVA: 0x00081BE6 File Offset: 0x0007FDE6
		public float[][] ServiceLoads { get; private set; }

		// Token: 0x17003051 RID: 12369
		// (get) Token: 0x0600A6BC RID: 42684 RVA: 0x00081BEF File Offset: 0x0007FDEF
		// (set) Token: 0x0600A6BD RID: 42685 RVA: 0x00081BF7 File Offset: 0x0007FDF7
		public float CrackedIBeams { get; private set; }

		// Token: 0x17003052 RID: 12370
		// (get) Token: 0x0600A6BE RID: 42686 RVA: 0x00081C00 File Offset: 0x0007FE00
		// (set) Token: 0x0600A6BF RID: 42687 RVA: 0x00081C08 File Offset: 0x0007FE08
		public float CrackedIColumn { get; private set; }

		// Token: 0x17003053 RID: 12371
		// (get) Token: 0x0600A6C0 RID: 42688 RVA: 0x00081C11 File Offset: 0x0007FE11
		// (set) Token: 0x0600A6C1 RID: 42689 RVA: 0x00081C19 File Offset: 0x0007FE19
		public SlendernessOfColumn ColumnAbove { get; private set; }

		// Token: 0x17003054 RID: 12372
		// (get) Token: 0x0600A6C2 RID: 42690 RVA: 0x00081C22 File Offset: 0x0007FE22
		// (set) Token: 0x0600A6C3 RID: 42691 RVA: 0x00081C2A File Offset: 0x0007FE2A
		public SlendernessOfColumn ColumnBelow { get; private set; }

		// Token: 0x0600A6C4 RID: 42692 RVA: 0x00231D64 File Offset: 0x0022FF64
		public void #eb(ColumnStorageModel #mSc, #Q6e #AQ)
		{
			this.InvestigateInputFlag = #mSc.InvestigateInputFlag;
			this.DesignInputFlag = #mSc.DesignInputFlag;
			this.SlendernessInputFlag = #mSc.SlendernessInputFlag;
			this.Options = new Options(#mSc.Options, #mSc, #AQ);
			this.DesignCode = new #N5e((#A5e)#mSc.Options.Code);
			this.Ties = new #53(#mSc.Ties);
			this.DesignDimensions = #mSc.DesignDimensions.ToArray();
			this.MaterialProperties = new #K2(#mSc.MaterialProperties);
			this.StiffnessReductionFactorPhi = #mSc.StiffnessReductionFactorPhi;
			this.Bars = #mSc.Bars.Select(new Func<StandardBar, StandardBar>(InputModel.<>c.<>9.#Bif)).ToArray<StandardBar>();
			this.ReinforcementRatios = new #d6e(#mSc.ReinforcementRatios.MinReinforcementRatio, #mSc.ReinforcementRatios.MaxReinforcementRatio);
			this.MinRebarClearSpacing = #mSc.MinRebarClearSpacing;
			this.DesignToRequiredRatio = #mSc.DesignToRequiredRatio;
			this.DesignedColumnX = new #X3(#mSc.DesignedColumnX);
			this.DesignedColumnY = new #X3(#mSc.DesignedColumnY);
			this.DesignReinforcement = new #c6e(#mSc.DesignReinforcement, #mSc);
			this.BeamX = new SlendernessOfBeams(#mSc.BeamX);
			this.BeamY = new SlendernessOfBeams(#mSc.BeamY);
			this.SustainedLoadFactor = #mSc.SustainedLoadFactors.ToArray();
			this.LoadFactors = #mSc.LoadFactors.Select(new Func<LoadFactor, float[]>(InputModel.<>c.<>9.#Cif)).ToArray<float[]>();
			this.ServiceLoads = #mSc.ServiceLoads.Select(new Func<ServiceLoad, float[]>(InputModel.<>c.<>9.#Dif)).ToArray<float[]>();
			this.CrackedIBeams = #mSc.CrackedIBeams;
			this.CrackedIColumn = #mSc.CrackedIColumn;
			this.ColumnAbove = new SlendernessOfColumn(#mSc.ColumnAbove);
			this.ColumnBelow = new SlendernessOfColumn(#mSc.ColumnBelow);
		}

		// Token: 0x0600A6C5 RID: 42693 RVA: 0x00231F78 File Offset: 0x00230178
		internal void #eb(#Hle #mSc)
		{
			this.InvestigateInputFlag = (int)#mSc.InvInputFlag;
			this.DesignInputFlag = (int)#mSc.DesInputFlag;
			this.SlendernessInputFlag = (int)#mSc.SldInputFlag;
			this.Options = new Options(#mSc.Options);
			this.DesignCode = new #N5e((#A5e)#mSc.Options.#c);
			this.Ties = new #53(#mSc.Ties);
			this.DesignDimensions = (float[])#mSc.DesDim.Clone();
			#vje.#Yfd(#mSc.DesDim, this.DesignDimensions);
			this.MaterialProperties = new #K2(#mSc.MatProp);
			this.StiffnessReductionFactorPhi = #mSc.Phi_Delta;
			this.Bars = new StandardBar[16];
			STNDBAR[] #Ic = #mSc.Bar;
			StandardBar[] #dAb = this.Bars;
			Func<STNDBAR, StandardBar> #bP;
			if ((#bP = InputModel.#2Ui.#a) == null)
			{
				#bP = (InputModel.#2Ui.#a = new Func<STNDBAR, StandardBar>(StandardBar.#Dge));
			}
			#vje.#Yfd<STNDBAR, StandardBar>(#Ic, #dAb, #bP);
			this.ReinforcementRatios = new #d6e(#mSc.DesCrit[0], #mSc.DesCrit[1]);
			this.MinRebarClearSpacing = #mSc.DesCrit[2];
			this.DesignToRequiredRatio = #mSc.DesCrit[3];
			IEnumerable<SLDDESCOL> source = #mSc.SldDesCol;
			Func<SLDDESCOL, #X3> selector;
			if ((selector = InputModel.#2Ui.#b) == null)
			{
				selector = (InputModel.#2Ui.#b = new Func<SLDDESCOL, #X3>(#X3.#n6e));
			}
			#X3[] array = source.Select(selector).ToArray<#X3>();
			this.DesignedColumnX = array[0];
			this.DesignedColumnY = array[1];
			this.DesignReinforcement = new #c6e();
			this.DesignReinforcement.#mg(#mSc.DesRein);
			SlendernessOfBeams[] array2 = #mSc.SldBeam.Select(new Func<SLDBEAM, SlendernessOfBeams>(InputModel.<>c.<>9.#Eif)).ToArray<SlendernessOfBeams>();
			this.BeamX = array2[0];
			this.BeamY = array2[1];
			this.SustainedLoadFactor = (float[])#mSc.SustFact.Clone();
			this.LoadFactors = (float[][])#mSc.LoadFact.Clone();
			this.ServiceLoads = (float[][])#mSc.ServLoads.Clone();
			float[] array3 = (float[])#mSc.CrackedI.Clone();
			this.CrackedIBeams = array3[0];
			this.CrackedIColumn = array3[1];
			SlendernessOfColumn[] array4 = #mSc.SldAbvBlwCol.Select(new Func<SLDABVBLWCOL, SlendernessOfColumn>(InputModel.<>c.<>9.#Gif)).ToArray<SlendernessOfColumn>();
			this.ColumnAbove = array4[0];
			this.ColumnBelow = array4[1];
		}

		// Token: 0x0400495B RID: 18779
		private const int #a = 16;

		// Token: 0x0400495C RID: 18780
		[CompilerGenerated]
		private int #b;

		// Token: 0x0400495D RID: 18781
		[CompilerGenerated]
		private int #c;

		// Token: 0x0400495E RID: 18782
		[CompilerGenerated]
		private int #d;

		// Token: 0x0400495F RID: 18783
		[CompilerGenerated]
		private Options #e;

		// Token: 0x04004960 RID: 18784
		[CompilerGenerated]
		private #N5e #f;

		// Token: 0x04004961 RID: 18785
		[CompilerGenerated]
		private #53 #g;

		// Token: 0x04004962 RID: 18786
		[CompilerGenerated]
		private float[] #h;

		// Token: 0x04004963 RID: 18787
		[CompilerGenerated]
		private #K2 #i;

		// Token: 0x04004964 RID: 18788
		[CompilerGenerated]
		private float #j;

		// Token: 0x04004965 RID: 18789
		[CompilerGenerated]
		private StandardBar[] #k;

		// Token: 0x04004966 RID: 18790
		[CompilerGenerated]
		private #d6e #l;

		// Token: 0x04004967 RID: 18791
		[CompilerGenerated]
		private float #m;

		// Token: 0x04004968 RID: 18792
		[CompilerGenerated]
		private float #n;

		// Token: 0x04004969 RID: 18793
		[CompilerGenerated]
		private #c6e #o;

		// Token: 0x0400496A RID: 18794
		[CompilerGenerated]
		private #X3 #p;

		// Token: 0x0400496B RID: 18795
		[CompilerGenerated]
		private #X3 #q;

		// Token: 0x0400496C RID: 18796
		[CompilerGenerated]
		private SlendernessOfBeams #r;

		// Token: 0x0400496D RID: 18797
		[CompilerGenerated]
		private SlendernessOfBeams #s;

		// Token: 0x0400496E RID: 18798
		[CompilerGenerated]
		private float[] #t;

		// Token: 0x0400496F RID: 18799
		[CompilerGenerated]
		private float[][] #u;

		// Token: 0x04004970 RID: 18800
		[CompilerGenerated]
		private float[][] #v;

		// Token: 0x04004971 RID: 18801
		[CompilerGenerated]
		private float #w;

		// Token: 0x04004972 RID: 18802
		[CompilerGenerated]
		private float #x;

		// Token: 0x04004973 RID: 18803
		[CompilerGenerated]
		private SlendernessOfColumn #y;

		// Token: 0x04004974 RID: 18804
		[CompilerGenerated]
		private SlendernessOfColumn #z;

		// Token: 0x02001366 RID: 4966
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04004975 RID: 18805
			public static Func<STNDBAR, StandardBar> #a;

			// Token: 0x04004976 RID: 18806
			public static Func<SLDDESCOL, #X3> #b;
		}
	}
}
