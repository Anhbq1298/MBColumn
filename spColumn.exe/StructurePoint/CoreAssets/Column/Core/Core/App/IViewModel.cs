using System;
using System.ComponentModel;

namespace StructurePoint.CoreAssets.Column.Core.Core.App
{
	// Token: 0x020000C9 RID: 201
	public interface IViewModel<out TView> : INotifyPropertyChanged, IViewModel where TView : IView
	{
		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000647 RID: 1607
		TView View { get; }

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000648 RID: 1608
		bool IsViewCreated { get; }
	}
}
