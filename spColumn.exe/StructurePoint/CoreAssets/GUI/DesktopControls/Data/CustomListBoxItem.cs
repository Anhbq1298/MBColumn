using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using #7hc;
using Telerik.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x020009FF RID: 2559
	public sealed class CustomListBoxItem<TValue> : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17001822 RID: 6178
		// (get) Token: 0x06005430 RID: 21552 RVA: 0x00045BF1 File Offset: 0x00043DF1
		// (set) Token: 0x06005431 RID: 21553 RVA: 0x00045BFD File Offset: 0x00043DFD
		public string Name { get; set; }

		// Token: 0x17001823 RID: 6179
		// (get) Token: 0x06005432 RID: 21554 RVA: 0x00045C0E File Offset: 0x00043E0E
		// (set) Token: 0x06005433 RID: 21555 RVA: 0x00045C1A File Offset: 0x00043E1A
		public Color Color { get; set; }

		// Token: 0x17001824 RID: 6180
		// (get) Token: 0x06005434 RID: 21556 RVA: 0x00045C2B File Offset: 0x00043E2B
		// (set) Token: 0x06005435 RID: 21557 RVA: 0x00045C37 File Offset: 0x00043E37
		public bool IsVisible
		{
			get
			{
				return this.isVisible;
			}
			set
			{
				if (this.isVisible != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107351275));
					this.isVisible = value;
					base.RaisePropertyChanged(#Phc.#3hc(107351275));
				}
			}
		}

		// Token: 0x17001825 RID: 6181
		// (get) Token: 0x06005436 RID: 21558 RVA: 0x00045C75 File Offset: 0x00043E75
		// (set) Token: 0x06005437 RID: 21559 RVA: 0x00045C81 File Offset: 0x00043E81
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public RadObservableCollection<ComboItem<TValue>> ComboBoxItems
		{
			get
			{
				return this.comboBoxItems;
			}
			set
			{
				if (this.comboBoxItems != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107463062));
					this.comboBoxItems = value;
					base.RaisePropertyChanged(#Phc.#3hc(107463062));
				}
			}
		}

		// Token: 0x17001826 RID: 6182
		// (get) Token: 0x06005438 RID: 21560 RVA: 0x00045CBF File Offset: 0x00043EBF
		// (set) Token: 0x06005439 RID: 21561 RVA: 0x00045CCB File Offset: 0x00043ECB
		public ComboItem<TValue> SelectedComboBoxItem
		{
			get
			{
				return this.selectedComboBoxItem;
			}
			set
			{
				if (this.selectedComboBoxItem != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107463009));
					this.selectedComboBoxItem = value;
					base.RaisePropertyChanged(#Phc.#3hc(107463009));
				}
			}
		}

		// Token: 0x04002437 RID: 9271
		private bool isVisible;

		// Token: 0x04002438 RID: 9272
		private RadObservableCollection<ComboItem<TValue>> comboBoxItems;

		// Token: 0x04002439 RID: 9273
		private ComboItem<TValue> selectedComboBoxItem;
	}
}
