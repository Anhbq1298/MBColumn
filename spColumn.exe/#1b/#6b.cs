using System;
using System.Windows;
using System.Windows.Input;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using Telerik.Windows.Controls;

namespace #1b
{
	// Token: 0x02000036 RID: 54
	internal interface #6b : IColumnWindow, IView
	{
		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060003A8 RID: 936
		// (remove) Token: 0x060003A9 RID: 937
		event EventHandler<DragEventArgs> DropOccurred;

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x060003AA RID: 938
		RadDocking EditorDocking { get; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x060003AB RID: 939
		RadDocking DiagramsDocking { get; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x060003AC RID: 940
		double LastColumnWidth { get; }

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x060003AD RID: 941
		bool IsActive { get; }

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x060003AE RID: 942
		// (set) Token: 0x060003AF RID: 943
		WindowState WindowState { get; set; }

		// Token: 0x060003B0 RID: 944
		bool #5b();

		// Token: 0x060003B1 RID: 945
		void RegisterGlobalCommand(CommandBinding binding);

		// Token: 0x060003B2 RID: 946
		void UpdateLeftColumn(bool contentVisible);

		// Token: 0x060003B3 RID: 947
		void StartInitAnimation();

		// Token: 0x060003B4 RID: 948
		void StopInitAnimation();

		// Token: 0x060003B5 RID: 949
		void FocusRibbon();
	}
}
