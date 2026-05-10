using System;
using System.ComponentModel;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #eU
{
	// Token: 0x0200030F RID: 783
	internal sealed class #uU : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, #dU
	{
		// Token: 0x170009C5 RID: 2501
		// (get) Token: 0x06001AF4 RID: 6900 RVA: 0x0001A916 File Offset: 0x00018B16
		// (set) Token: 0x06001AF5 RID: 6901 RVA: 0x0001A922 File Offset: 0x00018B22
		public bool ToolsBlockedByErrorsInLeftPanel
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<bool>(ref this.#a, value, #Phc.#3hc(107399872));
			}
		}

		// Token: 0x170009C6 RID: 2502
		// (get) Token: 0x06001AF6 RID: 6902 RVA: 0x0001A948 File Offset: 0x00018B48
		// (set) Token: 0x06001AF7 RID: 6903 RVA: 0x0001A954 File Offset: 0x00018B54
		public bool ToolsBlockedByPropertiesPanel
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<bool>(ref this.#b, value, #Phc.#3hc(107399859));
			}
		}

		// Token: 0x04000ABD RID: 2749
		private bool #a;

		// Token: 0x04000ABE RID: 2750
		private bool #b;
	}
}
