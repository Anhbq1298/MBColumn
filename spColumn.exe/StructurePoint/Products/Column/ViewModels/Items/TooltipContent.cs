using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StructurePoint.Products.Column.ViewModels.Items
{
	// Token: 0x020000FA RID: 250
	internal sealed class TooltipContent : INotifyPropertyChanged
	{
		// Token: 0x060007EA RID: 2026 RVA: 0x0000C0B4 File Offset: 0x0000A2B4
		public TooltipContent(string description)
		{
			this.Description = description;
			this.<IsSimpleText>k__BackingField = true;
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0000C0CA File Offset: 0x0000A2CA
		public TooltipContent(string title, string description)
		{
			this.Title = title;
			this.Description = description;
		}

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060007EC RID: 2028 RVA: 0x0009223C File Offset: 0x0009043C
		// (remove) Token: 0x060007ED RID: 2029 RVA: 0x00092280 File Offset: 0x00090480
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x060007EE RID: 2030 RVA: 0x0000C0E0 File Offset: 0x0000A2E0
		// (set) Token: 0x060007EF RID: 2031 RVA: 0x0000C0EC File Offset: 0x0000A2EC
		public string Title { get; set; }

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x060007F0 RID: 2032 RVA: 0x0000C0FD File Offset: 0x0000A2FD
		// (set) Token: 0x060007F1 RID: 2033 RVA: 0x0000C109 File Offset: 0x0000A309
		public string Description { get; set; }

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x060007F2 RID: 2034 RVA: 0x0000C11A File Offset: 0x0000A31A
		public bool IsSimpleText { get; }

		// Token: 0x060007F3 RID: 2035 RVA: 0x000922C4 File Offset: 0x000904C4
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
