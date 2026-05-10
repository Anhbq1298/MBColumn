using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #g7e;
using #Gke;
using #hZe;
using #P6e;
using #wUe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime
{
	// Token: 0x02001339 RID: 4921
	public sealed class RuntimeModel
	{
		// Token: 0x0600A478 RID: 42104 RVA: 0x000807E8 File Offset: 0x0007E9E8
		public RuntimeModel()
		{
			this.MessageBus = new #nW();
		}

		// Token: 0x17002F3E RID: 12094
		// (get) Token: 0x0600A479 RID: 42105 RVA: 0x0008081C File Offset: 0x0007EA1C
		internal #dAe DiagramsCache { get; } = new #dAe();

		// Token: 0x17002F3F RID: 12095
		// (get) Token: 0x0600A47A RID: 42106 RVA: 0x00080824 File Offset: 0x0007EA24
		// (set) Token: 0x0600A47B RID: 42107 RVA: 0x0008082C File Offset: 0x0007EA2C
		internal #y0e CachedFactoredInteractionDiagram { get; set; }

		// Token: 0x17002F40 RID: 12096
		// (get) Token: 0x0600A47C RID: 42108 RVA: 0x00080835 File Offset: 0x0007EA35
		public #nW MessageBus { get; }

		// Token: 0x17002F41 RID: 12097
		// (get) Token: 0x0600A47D RID: 42109 RVA: 0x0008083D File Offset: 0x0007EA3D
		// (set) Token: 0x0600A47E RID: 42110 RVA: 0x00080845 File Offset: 0x0007EA45
		public #J6e RunFlag { get; private set; }

		// Token: 0x17002F42 RID: 12098
		// (get) Token: 0x0600A47F RID: 42111 RVA: 0x0008084E File Offset: 0x0007EA4E
		// (set) Token: 0x0600A480 RID: 42112 RVA: 0x00080856 File Offset: 0x0007EA56
		public bool SilentRun { get; private set; }

		// Token: 0x17002F43 RID: 12099
		// (get) Token: 0x0600A481 RID: 42113 RVA: 0x0008085F File Offset: 0x0007EA5F
		// (set) Token: 0x0600A482 RID: 42114 RVA: 0x00080867 File Offset: 0x0007EA67
		public bool NominalInteraction { get; set; }

		// Token: 0x17002F44 RID: 12100
		// (get) Token: 0x0600A483 RID: 42115 RVA: 0x00080870 File Offset: 0x0007EA70
		// (set) Token: 0x0600A484 RID: 42116 RVA: 0x00080878 File Offset: 0x0007EA78
		public float Fc { get; set; }

		// Token: 0x17002F45 RID: 12101
		// (get) Token: 0x0600A485 RID: 42117 RVA: 0x00080881 File Offset: 0x0007EA81
		// (set) Token: 0x0600A486 RID: 42118 RVA: 0x00080889 File Offset: 0x0007EA89
		public #K1e ReinforcementBars { get; private set; }

		// Token: 0x17002F46 RID: 12102
		// (get) Token: 0x0600A487 RID: 42119 RVA: 0x00080892 File Offset: 0x0007EA92
		// (set) Token: 0x0600A488 RID: 42120 RVA: 0x0008089A File Offset: 0x0007EA9A
		public float[] SectionDimensionsForInvestigate { get; private set; }

		// Token: 0x17002F47 RID: 12103
		// (get) Token: 0x0600A489 RID: 42121 RVA: 0x000808A3 File Offset: 0x0007EAA3
		// (set) Token: 0x0600A48A RID: 42122 RVA: 0x000808AB File Offset: 0x0007EAAB
		public #Fce ReductionFactors { get; private set; }

		// Token: 0x17002F48 RID: 12104
		// (get) Token: 0x0600A48B RID: 42123 RVA: 0x000808B4 File Offset: 0x0007EAB4
		// (set) Token: 0x0600A48C RID: 42124 RVA: 0x000808BC File Offset: 0x0007EABC
		public Figures Solids { get; private set; }

		// Token: 0x17002F49 RID: 12105
		// (get) Token: 0x0600A48D RID: 42125 RVA: 0x000808C5 File Offset: 0x0007EAC5
		// (set) Token: 0x0600A48E RID: 42126 RVA: 0x000808CD File Offset: 0x0007EACD
		public Figures Openings { get; private set; }

		// Token: 0x17002F4A RID: 12106
		// (get) Token: 0x0600A48F RID: 42127 RVA: 0x000808D6 File Offset: 0x0007EAD6
		// (set) Token: 0x0600A490 RID: 42128 RVA: 0x000808DE File Offset: 0x0007EADE
		public #b0e FactoredLoads { get; private set; }

		// Token: 0x17002F4B RID: 12107
		// (get) Token: 0x0600A491 RID: 42129 RVA: 0x000808E7 File Offset: 0x0007EAE7
		// (set) Token: 0x0600A492 RID: 42130 RVA: 0x000808EF File Offset: 0x0007EAEF
		public #x0e GeometryProperties { get; private set; }

		// Token: 0x17002F4C RID: 12108
		// (get) Token: 0x0600A493 RID: 42131 RVA: 0x000808F8 File Offset: 0x0007EAF8
		// (set) Token: 0x0600A494 RID: 42132 RVA: 0x00080900 File Offset: 0x0007EB00
		public #3Ze Depth { get; private set; }

		// Token: 0x17002F4D RID: 12109
		// (get) Token: 0x0600A495 RID: 42133 RVA: 0x00080909 File Offset: 0x0007EB09
		// (set) Token: 0x0600A496 RID: 42134 RVA: 0x00080911 File Offset: 0x0007EB11
		public #y0e FactoredInteractionDiagram { get; set; }

		// Token: 0x17002F4E RID: 12110
		// (get) Token: 0x0600A497 RID: 42135 RVA: 0x0008091A File Offset: 0x0007EB1A
		// (set) Token: 0x0600A498 RID: 42136 RVA: 0x00080922 File Offset: 0x0007EB22
		public #y0e NominalInteractionDiagram { get; set; }

		// Token: 0x17002F4F RID: 12111
		// (get) Token: 0x0600A499 RID: 42137 RVA: 0x0008092B File Offset: 0x0007EB2B
		// (set) Token: 0x0600A49A RID: 42138 RVA: 0x00080933 File Offset: 0x0007EB33
		public #G0e Coordinates { get; private set; }

		// Token: 0x17002F50 RID: 12112
		// (get) Token: 0x0600A49B RID: 42139 RVA: 0x0008093C File Offset: 0x0007EB3C
		// (set) Token: 0x0600A49C RID: 42140 RVA: 0x00080944 File Offset: 0x0007EB44
		public #YZe BalancedCondition { get; private set; }

		// Token: 0x17002F51 RID: 12113
		// (get) Token: 0x0600A49D RID: 42141 RVA: 0x0008094D File Offset: 0x0007EB4D
		// (set) Token: 0x0600A49E RID: 42142 RVA: 0x00080955 File Offset: 0x0007EB55
		public #YZe YieldSteelStrengthFyEqualToHalf { get; private set; }

		// Token: 0x17002F52 RID: 12114
		// (get) Token: 0x0600A49F RID: 42143 RVA: 0x0008095E File Offset: 0x0007EB5E
		// (set) Token: 0x0600A4A0 RID: 42144 RVA: 0x00080966 File Offset: 0x0007EB66
		public #YZe MaxCompression { get; private set; }

		// Token: 0x17002F53 RID: 12115
		// (get) Token: 0x0600A4A1 RID: 42145 RVA: 0x0008096F File Offset: 0x0007EB6F
		// (set) Token: 0x0600A4A2 RID: 42146 RVA: 0x00080977 File Offset: 0x0007EB77
		public #YZe MaxTension { get; private set; }

		// Token: 0x17002F54 RID: 12116
		// (get) Token: 0x0600A4A3 RID: 42147 RVA: 0x00080980 File Offset: 0x0007EB80
		// (set) Token: 0x0600A4A4 RID: 42148 RVA: 0x00080988 File Offset: 0x0007EB88
		public #YZe YieldSteelStrengthFyEqualToZero { get; private set; }

		// Token: 0x17002F55 RID: 12117
		// (get) Token: 0x0600A4A5 RID: 42149 RVA: 0x00080991 File Offset: 0x0007EB91
		// (set) Token: 0x0600A4A6 RID: 42150 RVA: 0x00080999 File Offset: 0x0007EB99
		public #YZe ZeroCompression { get; private set; }

		// Token: 0x17002F56 RID: 12118
		// (get) Token: 0x0600A4A7 RID: 42151 RVA: 0x000809A2 File Offset: 0x0007EBA2
		// (set) Token: 0x0600A4A8 RID: 42152 RVA: 0x000809AA File Offset: 0x0007EBAA
		public #vZe AxialLoads { get; private set; }

		// Token: 0x17002F57 RID: 12119
		// (get) Token: 0x0600A4A9 RID: 42153 RVA: 0x000809B3 File Offset: 0x0007EBB3
		// (set) Token: 0x0600A4AA RID: 42154 RVA: 0x000809BB File Offset: 0x0007EBBB
		public #A0e InvestigateReinforcement { get; private set; }

		// Token: 0x17002F58 RID: 12120
		// (get) Token: 0x0600A4AB RID: 42155 RVA: 0x000809C4 File Offset: 0x0007EBC4
		// (set) Token: 0x0600A4AC RID: 42156 RVA: 0x000809CC File Offset: 0x0007EBCC
		public #s5e SlendernessX { get; set; } = new #s5e();

		// Token: 0x17002F59 RID: 12121
		// (get) Token: 0x0600A4AD RID: 42157 RVA: 0x000809D5 File Offset: 0x0007EBD5
		// (set) Token: 0x0600A4AE RID: 42158 RVA: 0x000809DD File Offset: 0x0007EBDD
		public #s5e SlendernessY { get; set; } = new #s5e();

		// Token: 0x17002F5A RID: 12122
		// (get) Token: 0x0600A4AF RID: 42159 RVA: 0x000809E6 File Offset: 0x0007EBE6
		// (set) Token: 0x0600A4B0 RID: 42160 RVA: 0x000809EE File Offset: 0x0007EBEE
		public #Lce[][] SlendernessFactors { get; private set; }

		// Token: 0x17002F5B RID: 12123
		// (get) Token: 0x0600A4B1 RID: 42161 RVA: 0x000809F7 File Offset: 0x0007EBF7
		// (set) Token: 0x0600A4B2 RID: 42162 RVA: 0x000809FF File Offset: 0x0007EBFF
		public float StiffnessX { get; set; }

		// Token: 0x17002F5C RID: 12124
		// (get) Token: 0x0600A4B3 RID: 42163 RVA: 0x00080A08 File Offset: 0x0007EC08
		// (set) Token: 0x0600A4B4 RID: 42164 RVA: 0x00080A10 File Offset: 0x0007EC10
		public float StiffnessY { get; set; }

		// Token: 0x17002F5D RID: 12125
		// (get) Token: 0x0600A4B5 RID: 42165 RVA: 0x00080A19 File Offset: 0x0007EC19
		// (set) Token: 0x0600A4B6 RID: 42166 RVA: 0x00080A21 File Offset: 0x0007EC21
		public #Q6e Configuration { get; private set; }

		// Token: 0x0600A4B7 RID: 42167 RVA: 0x00080A2A File Offset: 0x0007EC2A
		public void #Fci()
		{
			this.DiagramsCache.#yl();
			this.CachedFactoredInteractionDiagram = null;
		}

		// Token: 0x0600A4B8 RID: 42168 RVA: 0x0022FC08 File Offset: 0x0022DE08
		public void #eb(ColumnStorageModel #mSc, #Q6e #AQ)
		{
			this.Configuration = #AQ;
			ReinforcementBar[] #KJ = #mSc.ReinforcementBars.Select(new Func<ReinforcementBar, ReinforcementBar>(RuntimeModel.<>c.<>9.#Gci)).ToArray<ReinforcementBar>();
			this.ReinforcementBars = new #K1e(#KJ, #mSc.ReinforcementBars.Count);
			this.SectionDimensionsForInvestigate = #mSc.InvestigationDimensions.ToArray();
			this.ReductionFactors = new #Fce(#mSc.ReductionFactors);
			List<SectionPolygon> polygons = #mSc.Polygons.Where(new Func<SectionPolygon, bool>(RuntimeModel.<>c.<>9.#Hci)).ToList<SectionPolygon>();
			List<SectionPolygon> polygons2 = #mSc.Polygons.Where(new Func<SectionPolygon, bool>(RuntimeModel.<>c.<>9.#Ici)).ToList<SectionPolygon>();
			this.Solids = new Figures(polygons);
			this.Openings = new Figures(polygons2);
			this.FactoredLoads = new #b0e(new LoadsExt[0], 0);
			if (#mSc.Options.ActiveLoad == LoadType.Factored)
			{
				LoadsExt[] #tk = #mSc.FactoredLoads.Select(new Func<FactoredLoad, LoadsExt>(RuntimeModel.<>c.<>9.#Jci)).ToArray<LoadsExt>();
				this.FactoredLoads = new #b0e(#tk, #mSc.FactoredLoads.Count);
			}
			else if (#mSc.Options.ActiveLoad == LoadType.Axial)
			{
				LoadsExt[] #tk2 = #mSc.AxialLoads.Select(new Func<AxialLoad, LoadsExt>(RuntimeModel.<>c.<>9.#Kci)).ToArray<LoadsExt>();
				this.FactoredLoads = new #b0e(#tk2, #mSc.AxialLoads.Count);
			}
			this.StiffnessX = #mSc.StiffnessX;
			this.StiffnessY = #mSc.StiffnessY;
			this.InvestigateReinforcement = new #A0e(#mSc.InvestigationReinforcement, #mSc);
			this.#eb(#AQ);
		}

		// Token: 0x0600A4B9 RID: 42169 RVA: 0x0022FDF0 File Offset: 0x0022DFF0
		internal void #eb(#Hle #mSc, #Q6e #AQ)
		{
			IEnumerable<IRREG> source = #mSc.RfBars;
			Func<IRREG, ReinforcementBar> selector;
			if ((selector = RuntimeModel.#2Ui.#a) == null)
			{
				selector = (RuntimeModel.#2Ui.#a = new Func<IRREG, ReinforcementBar>(ReinforcementBar.#Dge));
			}
			ReinforcementBar[] #KJ = source.Select(selector).ToArray<ReinforcementBar>();
			this.ReinforcementBars = new #K1e(#KJ, (int)#mSc.Options.#o);
			this.SectionDimensionsForInvestigate = (float[])#mSc.InvDim.Clone();
			this.ReductionFactors = #Fce.#Dge(#mSc.RedFactors);
			IEnumerable<FPOINT> source2 = #mSc.ExteriorPoints;
			Func<FPOINT, Point> selector2;
			if ((selector2 = RuntimeModel.#2Ui.#b) == null)
			{
				selector2 = (RuntimeModel.#2Ui.#b = new Func<FPOINT, Point>(Point.#Dge));
			}
			Point[] initialPoints = source2.Select(selector2).ToArray<Point>();
			IEnumerable<FPOINT> source3 = #mSc.InteriorPoints;
			Func<FPOINT, Point> selector3;
			if ((selector3 = RuntimeModel.#2Ui.#b) == null)
			{
				selector3 = (RuntimeModel.#2Ui.#b = new Func<FPOINT, Point>(Point.#Dge));
			}
			Point[] initialPoints2 = source3.Select(selector3).ToArray<Point>();
			this.Solids = new Figures(initialPoints, (int)#mSc.Options.#r);
			this.Openings = new Figures(initialPoints2, (int)#mSc.Options.#s);
			IEnumerable<LOADS> source4 = #mSc.FactLoads;
			Func<LOADS, LoadsExt> selector4;
			if ((selector4 = RuntimeModel.#2Ui.#c) == null)
			{
				selector4 = (RuntimeModel.#2Ui.#c = new Func<LOADS, LoadsExt>(LoadsExt.#Dge));
			}
			LoadsExt[] #tk = source4.Select(selector4).ToArray<LoadsExt>();
			this.FactoredLoads = new #b0e(#tk, (int)#mSc.Options.#p);
			float[] array = (float[])#mSc.EI.Clone();
			this.StiffnessX = array[0];
			this.StiffnessY = array[1];
			this.InvestigateReinforcement = new #A0e();
			this.InvestigateReinforcement.#mg(#mSc.InvRein);
			this.#eb(#AQ);
		}

		// Token: 0x0600A4BA RID: 42170 RVA: 0x0022FF7C File Offset: 0x0022E17C
		private void #eb(#Q6e #AQ)
		{
			this.GeometryProperties = new #x0e();
			this.Depth = new #3Ze();
			this.Coordinates = new #G0e();
			this.BalancedCondition = new #YZe();
			this.YieldSteelStrengthFyEqualToHalf = new #YZe();
			this.MaxCompression = new #YZe();
			this.MaxTension = new #YZe();
			this.YieldSteelStrengthFyEqualToZero = new #YZe();
			this.ZeroCompression = new #YZe();
			this.AxialLoads = new #vZe();
			this.SlendernessFactors = #vje.#sje<#Lce>(50, 2);
			this.SilentRun = #AQ.#kp();
			if (#AQ.#hp())
			{
				this.RunFlag |= #J6e.#b;
			}
			if (#AQ.#ip())
			{
				this.RunFlag |= #J6e.#a;
			}
		}

		// Token: 0x04004812 RID: 18450
		private const int #a = 50;

		// Token: 0x04004813 RID: 18451
		[CompilerGenerated]
		private readonly #dAe #b;

		// Token: 0x04004814 RID: 18452
		[CompilerGenerated]
		private #y0e #c;

		// Token: 0x04004815 RID: 18453
		[CompilerGenerated]
		private readonly #nW #d;

		// Token: 0x04004816 RID: 18454
		[CompilerGenerated]
		private #J6e #e;

		// Token: 0x04004817 RID: 18455
		[CompilerGenerated]
		private bool #f;

		// Token: 0x04004818 RID: 18456
		[CompilerGenerated]
		private bool #g;

		// Token: 0x04004819 RID: 18457
		[CompilerGenerated]
		private float #h;

		// Token: 0x0400481A RID: 18458
		[CompilerGenerated]
		private #K1e #i;

		// Token: 0x0400481B RID: 18459
		[CompilerGenerated]
		private float[] #j;

		// Token: 0x0400481C RID: 18460
		[CompilerGenerated]
		private #Fce #k;

		// Token: 0x0400481D RID: 18461
		[CompilerGenerated]
		private Figures #l;

		// Token: 0x0400481E RID: 18462
		[CompilerGenerated]
		private Figures #m;

		// Token: 0x0400481F RID: 18463
		[CompilerGenerated]
		private #b0e #n;

		// Token: 0x04004820 RID: 18464
		[CompilerGenerated]
		private #x0e #o;

		// Token: 0x04004821 RID: 18465
		[CompilerGenerated]
		private #3Ze #p;

		// Token: 0x04004822 RID: 18466
		[CompilerGenerated]
		private #y0e #q;

		// Token: 0x04004823 RID: 18467
		[CompilerGenerated]
		private #y0e #r;

		// Token: 0x04004824 RID: 18468
		[CompilerGenerated]
		private #G0e #s;

		// Token: 0x04004825 RID: 18469
		[CompilerGenerated]
		private #YZe #t;

		// Token: 0x04004826 RID: 18470
		[CompilerGenerated]
		private #YZe #u;

		// Token: 0x04004827 RID: 18471
		[CompilerGenerated]
		private #YZe #v;

		// Token: 0x04004828 RID: 18472
		[CompilerGenerated]
		private #YZe #w;

		// Token: 0x04004829 RID: 18473
		[CompilerGenerated]
		private #YZe #x;

		// Token: 0x0400482A RID: 18474
		[CompilerGenerated]
		private #YZe #y;

		// Token: 0x0400482B RID: 18475
		[CompilerGenerated]
		private #vZe #z;

		// Token: 0x0400482C RID: 18476
		[CompilerGenerated]
		private #A0e #A;

		// Token: 0x0400482D RID: 18477
		[CompilerGenerated]
		private #s5e #B;

		// Token: 0x0400482E RID: 18478
		[CompilerGenerated]
		private #s5e #C;

		// Token: 0x0400482F RID: 18479
		[CompilerGenerated]
		private #Lce[][] #D;

		// Token: 0x04004830 RID: 18480
		[CompilerGenerated]
		private float #E;

		// Token: 0x04004831 RID: 18481
		[CompilerGenerated]
		private float #F;

		// Token: 0x04004832 RID: 18482
		[CompilerGenerated]
		private #Q6e #G;

		// Token: 0x0200133A RID: 4922
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04004833 RID: 18483
			public static Func<IRREG, ReinforcementBar> #a;

			// Token: 0x04004834 RID: 18484
			public static Func<FPOINT, Point> #b;

			// Token: 0x04004835 RID: 18485
			public static Func<LOADS, LoadsExt> #c;
		}
	}
}
