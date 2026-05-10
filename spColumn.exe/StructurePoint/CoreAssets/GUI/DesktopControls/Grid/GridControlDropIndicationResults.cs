using System;
using System.ComponentModel;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009DD RID: 2525
	public sealed class GridControlDropIndicationResults : INotifyPropertyChanged
	{
		// Token: 0x1700179C RID: 6044
		// (get) Token: 0x060052CF RID: 21199 RVA: 0x000447AA File Offset: 0x000429AA
		// (set) Token: 0x060052D0 RID: 21200 RVA: 0x000447B6 File Offset: 0x000429B6
		public object CurrentDraggedOverItem
		{
			get
			{
				return this.currentDraggedOverItem;
			}
			set
			{
				if (this.currentDraggedOverItem != value)
				{
					this.currentDraggedOverItem = value;
					this.OnPropertyChanged(#Phc.#3hc(107463405));
				}
			}
		}

		// Token: 0x1700179D RID: 6045
		// (get) Token: 0x060052D1 RID: 21201 RVA: 0x000447E4 File Offset: 0x000429E4
		// (set) Token: 0x060052D2 RID: 21202 RVA: 0x000447F0 File Offset: 0x000429F0
		public int DropIndex
		{
			get
			{
				return this.index;
			}
			set
			{
				this.index = value;
			}
		}

		// Token: 0x1700179E RID: 6046
		// (get) Token: 0x060052D3 RID: 21203 RVA: 0x00044801 File Offset: 0x00042A01
		// (set) Token: 0x060052D4 RID: 21204 RVA: 0x0004480D File Offset: 0x00042A0D
		public DropPosition CurrentDropPosition
		{
			get
			{
				return this.currentDropPosition;
			}
			set
			{
				if (this.currentDropPosition != value)
				{
					this.currentDropPosition = value;
					this.OnPropertyChanged(#Phc.#3hc(107463372));
				}
			}
		}

		// Token: 0x1700179F RID: 6047
		// (get) Token: 0x060052D5 RID: 21205 RVA: 0x0004483B File Offset: 0x00042A3B
		// (set) Token: 0x060052D6 RID: 21206 RVA: 0x00044847 File Offset: 0x00042A47
		public object CurrentDraggedItem
		{
			get
			{
				return this.currentDraggedItem;
			}
			set
			{
				if (this.currentDraggedItem != value)
				{
					this.currentDraggedItem = value;
					this.OnPropertyChanged(#Phc.#3hc(107463343));
				}
			}
		}

		// Token: 0x060052D7 RID: 21207 RVA: 0x00162380 File Offset: 0x00160580
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		// Token: 0x14000157 RID: 343
		// (add) Token: 0x060052D8 RID: 21208 RVA: 0x001623B0 File Offset: 0x001605B0
		// (remove) Token: 0x060052D9 RID: 21209 RVA: 0x001623F4 File Offset: 0x001605F4
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x040023DF RID: 9183
		private object currentDraggedItem;

		// Token: 0x040023E0 RID: 9184
		private DropPosition currentDropPosition;

		// Token: 0x040023E1 RID: 9185
		private object currentDraggedOverItem;

		// Token: 0x040023E2 RID: 9186
		private int index;
	}
}
