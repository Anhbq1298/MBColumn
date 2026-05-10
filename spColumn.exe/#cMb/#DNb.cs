using System;
using System.ComponentModel;
using #RJb;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace #cMb
{
	// Token: 0x020004C3 RID: 1219
	internal interface #DNb : INotifyPropertyChanged
	{
		// Token: 0x140000C8 RID: 200
		// (add) Token: 0x06002C96 RID: 11414
		// (remove) Token: 0x06002C97 RID: 11415
		event EventHandler<#NNb> ToolActivated;

		// Token: 0x140000C9 RID: 201
		// (add) Token: 0x06002C98 RID: 11416
		// (remove) Token: 0x06002C99 RID: 11417
		event EventHandler<#NNb> ToolDeactivated;

		// Token: 0x17000EF6 RID: 3830
		// (get) Token: 0x06002C9A RID: 11418
		#cLb Context { get; }

		// Token: 0x17000EF7 RID: 3831
		// (get) Token: 0x06002C9B RID: 11419
		RadObservableCollection<#uNb> Tools { get; }

		// Token: 0x17000EF8 RID: 3832
		// (get) Token: 0x06002C9C RID: 11420
		bool IsActive { get; }

		// Token: 0x17000EF9 RID: 3833
		// (get) Token: 0x06002C9D RID: 11421
		DelegateCommand ActivateToolCommand { get; }

		// Token: 0x17000EFA RID: 3834
		// (get) Token: 0x06002C9E RID: 11422
		#cOb ActiveTool { get; }

		// Token: 0x17000EFB RID: 3835
		// (get) Token: 0x06002C9F RID: 11423
		bool IsInSelectMode { get; }

		// Token: 0x06002CA0 RID: 11424
		void #5b();

		// Token: 0x06002CA1 RID: 11425
		void #0kb();

		// Token: 0x06002CA2 RID: 11426
		void #8vb(#cOb #Ph);

		// Token: 0x06002CA3 RID: 11427
		void #CNb();
	}
}
