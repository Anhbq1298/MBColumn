using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008A3 RID: 2211
	public sealed class RibbonRadioButtonGroup : RibbonButton
	{
		// Token: 0x140000DF RID: 223
		// (add) Token: 0x060045BD RID: 17853 RVA: 0x0013D1D0 File Offset: 0x0013B3D0
		// (remove) Token: 0x060045BE RID: 17854 RVA: 0x0013D214 File Offset: 0x0013B414
		public event EventHandler<SelectedValueChangedEventArgs<object>> SelectedValueChanged;

		// Token: 0x060045BF RID: 17855 RVA: 0x0003A404 File Offset: 0x00038604
		public RibbonRadioButtonGroup(string groupName)
		{
			#X0d.#W0d(groupName, #Phc.#3hc(107454447), Component.DesktopControls, #Phc.#3hc(107454434));
			this.GroupName = groupName;
			this.buttons = new ObservableCollection<RibbonButton>();
		}

		// Token: 0x17001463 RID: 5219
		// (get) Token: 0x060045C0 RID: 17856 RVA: 0x0003A439 File Offset: 0x00038639
		public IEnumerable<RibbonButton> Buttons
		{
			get
			{
				return this.buttons;
			}
		}

		// Token: 0x17001464 RID: 5220
		// (get) Token: 0x060045C1 RID: 17857 RVA: 0x0003A445 File Offset: 0x00038645
		// (set) Token: 0x060045C2 RID: 17858 RVA: 0x0003A451 File Offset: 0x00038651
		public string GroupName { get; private set; }

		// Token: 0x17001465 RID: 5221
		// (get) Token: 0x060045C3 RID: 17859 RVA: 0x0003A462 File Offset: 0x00038662
		// (set) Token: 0x060045C4 RID: 17860 RVA: 0x0003A46E File Offset: 0x0003866E
		public object SelectedValue
		{
			get
			{
				return this.selectedValue;
			}
			private set
			{
				if (this.selectedValue != value)
				{
					this.selectedValue = value;
					this.RaiseSelectedValueChanged();
				}
			}
		}

		// Token: 0x060045C5 RID: 17861 RVA: 0x0013D258 File Offset: 0x0013B458
		public void AddButton(RibbonButton button)
		{
			#X0d.#V0d(button, #Phc.#3hc(107454381), Component.DesktopControls, #Phc.#3hc(107454372));
			RibbonRadioButton ribbonRadioButton = button as RibbonRadioButton;
			if (ribbonRadioButton != null)
			{
				ribbonRadioButton.GroupName = this.GroupName;
				ribbonRadioButton.IsCheckedChanged += this.OnRadioButtonIsCheckedChanged;
			}
			this.buttons.Add(button);
		}

		// Token: 0x060045C6 RID: 17862 RVA: 0x0003A492 File Offset: 0x00038692
		private void OnRadioButtonIsCheckedChanged(object sender, IsCheckedChangedEventArgs<object> e)
		{
			if (e != null && e.IsChecked)
			{
				this.SelectedValue = e.Value;
			}
		}

		// Token: 0x060045C7 RID: 17863 RVA: 0x0013D2C0 File Offset: 0x0013B4C0
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Raises an event.")]
		protected void RaiseSelectedValueChanged()
		{
			EventHandler<SelectedValueChangedEventArgs<object>> selectedValueChanged = this.SelectedValueChanged;
			if (selectedValueChanged != null)
			{
				selectedValueChanged(this, new SelectedValueChangedEventArgs<object>(this.selectedValue));
			}
		}

		// Token: 0x04001FA9 RID: 8105
		private readonly ObservableCollection<RibbonButton> buttons;

		// Token: 0x04001FAA RID: 8106
		private object selectedValue;
	}
}
