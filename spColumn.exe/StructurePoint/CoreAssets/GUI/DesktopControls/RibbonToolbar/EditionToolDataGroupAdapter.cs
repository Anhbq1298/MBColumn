using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008F8 RID: 2296
	public sealed class EditionToolDataGroupAdapter : EditionToolDataAdapter, IRibbonToolbarButton, IRibbonToolbarRadioButton, IRibbonToolbarDropDownRadioButton
	{
		// Token: 0x06004930 RID: 18736 RVA: 0x00144CC8 File Offset: 0x00142EC8
		public EditionToolDataGroupAdapter(IGroupingEditionToolData groupingEditionToolData, Visibility textVisibility, ButtonTextPosition textPosition) : base(groupingEditionToolData, textVisibility, textPosition)
		{
			#X0d.#V0d(groupingEditionToolData, #Phc.#3hc(107450325), Component.DesktopControls, #Phc.#3hc(107450292));
			this.groupingEditionToolData = groupingEditionToolData;
			this.childButtons = (from item in this.groupingEditionToolData.ChildTools
			select new EditionToolDataAdapter(item, textVisibility, textPosition)).ToList<EditionToolDataAdapter>();
		}

		// Token: 0x1700156C RID: 5484
		// (get) Token: 0x06004931 RID: 18737 RVA: 0x0003D859 File Offset: 0x0003BA59
		public IGroupingEditionToolData GroupingEditionToolData
		{
			get
			{
				return this.groupingEditionToolData;
			}
		}

		// Token: 0x1700156D RID: 5485
		// (get) Token: 0x06004932 RID: 18738 RVA: 0x0003D865 File Offset: 0x0003BA65
		public IEnumerable<IRibbonToolbarRadioButton> ChildButtons
		{
			get
			{
				return this.childButtons;
			}
		}

		// Token: 0x1700156E RID: 5486
		// (get) Token: 0x06004933 RID: 18739 RVA: 0x0003D871 File Offset: 0x0003BA71
		// (set) Token: 0x06004934 RID: 18740 RVA: 0x00144D48 File Offset: 0x00142F48
		public IRibbonToolbarRadioButton SelectedButton
		{
			get
			{
				return this.childButtons.FirstOrDefault((EditionToolDataAdapter item) => item.EditionToolData.Equals(this.groupingEditionToolData.SelectedEditionToolData));
			}
			set
			{
				EditionToolDataAdapter editionToolDataAdapter = value as EditionToolDataAdapter;
				if (editionToolDataAdapter != null && this.groupingEditionToolData.SelectedEditionToolData != editionToolDataAdapter.EditionToolData)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450239));
					this.groupingEditionToolData.SelectedEditionToolData = editionToolDataAdapter.EditionToolData;
					base.RaisePropertyChanged(#Phc.#3hc(107450239));
				}
			}
		}

		// Token: 0x1700156F RID: 5487
		// (get) Token: 0x06004935 RID: 18741 RVA: 0x0003D896 File Offset: 0x0003BA96
		// (set) Token: 0x06004936 RID: 18742 RVA: 0x00144DB0 File Offset: 0x00142FB0
		public override string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				if (this.text != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107350927));
					this.text = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350927));
				}
			}
		}

		// Token: 0x040020D4 RID: 8404
		private IGroupingEditionToolData groupingEditionToolData;

		// Token: 0x040020D5 RID: 8405
		private IEnumerable<EditionToolDataAdapter> childButtons;

		// Token: 0x040020D6 RID: 8406
		private string text;
	}
}
