using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #12e;
using #3ve;
using #hZe;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #Wse
{
	// Token: 0x02001171 RID: 4465
	internal sealed class #lte
	{
		// Token: 0x17002BE1 RID: 11233
		// (get) Token: 0x06009733 RID: 38707 RVA: 0x00078506 File Offset: 0x00076706
		// (set) Token: 0x06009734 RID: 38708 RVA: 0x0007850E File Offset: 0x0007670E
		public ColumnStorageModel Input { get; set; }

		// Token: 0x17002BE2 RID: 11234
		// (get) Token: 0x06009735 RID: 38709 RVA: 0x00078517 File Offset: 0x00076717
		// (set) Token: 0x06009736 RID: 38710 RVA: 0x0007851F File Offset: 0x0007671F
		public #l4e Output { get; set; }

		// Token: 0x17002BE3 RID: 11235
		// (get) Token: 0x06009737 RID: 38711 RVA: 0x00078528 File Offset: 0x00076728
		// (set) Token: 0x06009738 RID: 38712 RVA: 0x00078530 File Offset: 0x00076730
		public #hwe FailureSurface { get; set; }

		// Token: 0x17002BE4 RID: 11236
		// (get) Token: 0x06009739 RID: 38713 RVA: 0x00078539 File Offset: 0x00076739
		// (set) Token: 0x0600973A RID: 38714 RVA: 0x00078541 File Offset: 0x00076741
		public GeneralInformation GeneralInfo { get; set; } = new GeneralInformation();

		// Token: 0x17002BE5 RID: 11237
		// (get) Token: 0x0600973B RID: 38715 RVA: 0x0007854A File Offset: 0x0007674A
		public #Vse BasicProperties { get; } = new #Vse();

		// Token: 0x17002BE6 RID: 11238
		// (get) Token: 0x0600973C RID: 38716 RVA: 0x00078552 File Offset: 0x00076752
		public #3se ColorSettings { get; } = new #3se();

		// Token: 0x17002BE7 RID: 11239
		// (get) Token: 0x0600973D RID: 38717 RVA: 0x0007855A File Offset: 0x0007675A
		// (set) Token: 0x0600973E RID: 38718 RVA: 0x00078562 File Offset: 0x00076762
		public bool IsReportSourceValid { get; set; }

		// Token: 0x17002BE8 RID: 11240
		// (get) Token: 0x0600973F RID: 38719 RVA: 0x0007856B File Offset: 0x0007676B
		public List<ReporterImage> Images { get; } = new List<ReporterImage>();

		// Token: 0x17002BE9 RID: 11241
		// (get) Token: 0x06009740 RID: 38720 RVA: 0x00078573 File Offset: 0x00076773
		public float? AsMin
		{
			get
			{
				#l4e #l4e = this.Output;
				return new float?(((#l4e != null) ? #l4e.Variables.SectionPropAg : this.BasicProperties.GeomProperties.Ag) * this.Input.ReinforcementRatios.MinReinforcementRatio);
			}
		}

		// Token: 0x17002BEA RID: 11242
		// (get) Token: 0x06009741 RID: 38721 RVA: 0x000785B1 File Offset: 0x000767B1
		public float? AsMax
		{
			get
			{
				#l4e #l4e = this.Output;
				return new float?(((#l4e != null) ? #l4e.Variables.SectionPropAg : this.BasicProperties.GeomProperties.Ag) * this.Input.ReinforcementRatios.MaxReinforcementRatio);
			}
		}

		// Token: 0x17002BEB RID: 11243
		// (get) Token: 0x06009742 RID: 38722 RVA: 0x000785EF File Offset: 0x000767EF
		public List<string> ModelValidationErrors { get; } = new List<string>();

		// Token: 0x17002BEC RID: 11244
		// (get) Token: 0x06009743 RID: 38723 RVA: 0x000785F7 File Offset: 0x000767F7
		public List<string> ModelValidationWarnings { get; } = new List<string>();

		// Token: 0x17002BED RID: 11245
		// (get) Token: 0x06009744 RID: 38724 RVA: 0x000785FF File Offset: 0x000767FF
		public List<string> DesignEngineWarningsAndErrors { get; } = new List<string>();

		// Token: 0x17002BEE RID: 11246
		// (get) Token: 0x06009745 RID: 38725 RVA: 0x00078607 File Offset: 0x00076807
		public #4se TestOptions { get; } = new #4se();

		// Token: 0x17002BEF RID: 11247
		// (get) Token: 0x06009746 RID: 38726 RVA: 0x0007860F File Offset: 0x0007680F
		public List<SolverMessage> SolverMessages { get; } = new List<SolverMessage>();

		// Token: 0x06009747 RID: 38727 RVA: 0x00078617 File Offset: 0x00076817
		public bool #ite()
		{
			return this.Output != null;
		}

		// Token: 0x06009748 RID: 38728 RVA: 0x001FC798 File Offset: 0x001FA998
		internal float[] #jte()
		{
			if (this.Output != null && this.Output.SolveCompleted)
			{
				return this.Output.InvestigationDimensions;
			}
			ProblemType problemType = this.Input.Options.ProblemType;
			if (problemType == ProblemType.Investigation)
			{
				return this.Input.InvestigationDimensions.ToArray();
			}
			if (problemType != ProblemType.Design)
			{
				throw new ArgumentOutOfRangeException();
			}
			return this.Input.DesignDimensions.ToArray();
		}

		// Token: 0x06009749 RID: 38729 RVA: 0x001FC808 File Offset: 0x001FAA08
		internal #A0e #kte()
		{
			if (this.Output != null && this.Output.SolveCompleted)
			{
				return this.Output.InvestigationReinforcement;
			}
			ProblemType problemType = this.Input.Options.ProblemType;
			if (problemType == ProblemType.Investigation)
			{
				return new #A0e(this.Input.InvestigationReinforcement, this.Input);
			}
			if (problemType != ProblemType.Design)
			{
				throw new ArgumentOutOfRangeException();
			}
			return new #A0e(this.Input.DesignReinforcement, this.Input);
		}

		// Token: 0x040040F1 RID: 16625
		[CompilerGenerated]
		private ColumnStorageModel #a;

		// Token: 0x040040F2 RID: 16626
		[CompilerGenerated]
		private #l4e #b;

		// Token: 0x040040F3 RID: 16627
		[CompilerGenerated]
		private #hwe #c;

		// Token: 0x040040F4 RID: 16628
		[CompilerGenerated]
		private GeneralInformation #d;

		// Token: 0x040040F5 RID: 16629
		[CompilerGenerated]
		private readonly #Vse #e;

		// Token: 0x040040F6 RID: 16630
		[CompilerGenerated]
		private readonly #3se #f;

		// Token: 0x040040F7 RID: 16631
		[CompilerGenerated]
		private bool #g;

		// Token: 0x040040F8 RID: 16632
		[CompilerGenerated]
		private readonly List<ReporterImage> #h;

		// Token: 0x040040F9 RID: 16633
		[CompilerGenerated]
		private readonly List<string> #i;

		// Token: 0x040040FA RID: 16634
		[CompilerGenerated]
		private readonly List<string> #j;

		// Token: 0x040040FB RID: 16635
		[CompilerGenerated]
		private readonly List<string> #k;

		// Token: 0x040040FC RID: 16636
		[CompilerGenerated]
		private readonly #4se #l;

		// Token: 0x040040FD RID: 16637
		[CompilerGenerated]
		private readonly List<SolverMessage> #m;
	}
}
