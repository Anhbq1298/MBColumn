using System;
using System.Globalization;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Kernel.CoreAssets.Importer.DataClasses;

namespace StructurePoint.Products.Column.ViewModels.Etabs
{
	// Token: 0x0200022F RID: 559
	internal sealed class PreviewItem : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060012DE RID: 4830 RVA: 0x000ACEBC File Offset: 0x000AB0BC
		public PreviewItem(ETABSFactoredLoad load, LabelSectionType labelSectionType, string section = "-")
		{
			this.<Member>k__BackingField = load.ObjectData;
			this.<LoadCombination>k__BackingField = load.LoadCombination;
			if (labelSectionType == LabelSectionType.PierLabel)
			{
				this.<Station>k__BackingField = ((load.Station == 0.0) ? Strings.StringBottom : Strings.StringTop);
			}
			else
			{
				this.<Station>k__BackingField = load.Station.ToString(#Phc.#3hc(107408848), CultureInfo.InvariantCulture);
			}
			this.<Step>k__BackingField = ((load.StepValue > -1.0) ? load.StepValue.ToString(#Phc.#3hc(107408848), CultureInfo.CurrentCulture) : load.StepType);
			this.<P>k__BackingField = load.P.ToString(#Phc.#3hc(107408811), CultureInfo.InvariantCulture);
			this.<Mx>k__BackingField = load.Mx.ToString(#Phc.#3hc(107408811), CultureInfo.InvariantCulture);
			this.<My>k__BackingField = load.My.ToString(#Phc.#3hc(107408811), CultureInfo.InvariantCulture);
			this.<Load>k__BackingField = load;
			this.<Section>k__BackingField = section;
			this.<PValue>k__BackingField = load.P;
			this.<MyValue>k__BackingField = load.My;
			this.<MxValue>k__BackingField = load.Mx;
			this.<StationValue>k__BackingField = GenericSortableCellValue.Parse(this.Station);
			this.<StepValue>k__BackingField = GenericSortableCellValue.Parse(this.Step);
		}

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x060012DF RID: 4831 RVA: 0x00014738 File Offset: 0x00012938
		public static string MxValueColumn { get; } = #Phc.#3hc(107408806);

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x060012E0 RID: 4832 RVA: 0x0001473F File Offset: 0x0001293F
		public static string MyValueColumn { get; } = #Phc.#3hc(107408825);

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x060012E1 RID: 4833 RVA: 0x00014746 File Offset: 0x00012946
		public static string PValueColumn { get; } = #Phc.#3hc(107408780);

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x060012E2 RID: 4834 RVA: 0x0001474D File Offset: 0x0001294D
		public static string StationColumn { get; } = #Phc.#3hc(107408771);

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x060012E3 RID: 4835 RVA: 0x00014754 File Offset: 0x00012954
		public static string StepColumn { get; } = #Phc.#3hc(107408786);

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x060012E4 RID: 4836 RVA: 0x0001475B File Offset: 0x0001295B
		public string Member { get; }

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x060012E5 RID: 4837 RVA: 0x00014767 File Offset: 0x00012967
		public ETABSFactoredLoad Load { get; }

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x060012E6 RID: 4838 RVA: 0x00014773 File Offset: 0x00012973
		public string Section { get; }

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x060012E7 RID: 4839 RVA: 0x0001477F File Offset: 0x0001297F
		public string LoadCombination { get; }

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x060012E8 RID: 4840 RVA: 0x0001478B File Offset: 0x0001298B
		public string Station { get; }

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x060012E9 RID: 4841 RVA: 0x00014797 File Offset: 0x00012997
		public string Step { get; }

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x060012EA RID: 4842 RVA: 0x000147A3 File Offset: 0x000129A3
		public string P { get; }

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x060012EB RID: 4843 RVA: 0x000147AF File Offset: 0x000129AF
		public string Mx { get; }

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x060012EC RID: 4844 RVA: 0x000147BB File Offset: 0x000129BB
		public string My { get; }

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x060012ED RID: 4845 RVA: 0x000147C7 File Offset: 0x000129C7
		public GenericSortableCellValue StationValue { get; }

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x060012EE RID: 4846 RVA: 0x000147D3 File Offset: 0x000129D3
		public GenericSortableCellValue StepValue { get; }

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x060012EF RID: 4847 RVA: 0x000147DF File Offset: 0x000129DF
		public double MxValue { get; }

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x060012F0 RID: 4848 RVA: 0x000147EB File Offset: 0x000129EB
		public double MyValue { get; }

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x060012F1 RID: 4849 RVA: 0x000147F7 File Offset: 0x000129F7
		public double PValue { get; }
	}
}
