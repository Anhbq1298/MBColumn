using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #LFb;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.ViewModels.Items;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.API
{
	// Token: 0x020005A2 RID: 1442
	internal sealed class CircleToolViewModel : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17000FFA RID: 4090
		// (get) Token: 0x06003271 RID: 12913 RVA: 0x0002CA25 File Offset: 0x0002AC25
		// (set) Token: 0x06003272 RID: 12914 RVA: 0x0002CA31 File Offset: 0x0002AC31
		public TooltipContent Tooltip { get; set; }

		// Token: 0x17000FFB RID: 4091
		// (get) Token: 0x06003273 RID: 12915 RVA: 0x0002CA42 File Offset: 0x0002AC42
		// (set) Token: 0x06003274 RID: 12916 RVA: 0x0002CA4E File Offset: 0x0002AC4E
		internal #MFb Tool { get; set; }

		// Token: 0x17000FFC RID: 4092
		// (get) Token: 0x06003275 RID: 12917 RVA: 0x0002CA5F File Offset: 0x0002AC5F
		// (set) Token: 0x06003276 RID: 12918 RVA: 0x0002CA6B File Offset: 0x0002AC6B
		public string Name { get; set; }

		// Token: 0x17000FFD RID: 4093
		// (get) Token: 0x06003277 RID: 12919 RVA: 0x0002CA7C File Offset: 0x0002AC7C
		// (set) Token: 0x06003278 RID: 12920 RVA: 0x0002CA88 File Offset: 0x0002AC88
		public ImageSource Icon { get; set; }

		// Token: 0x04001482 RID: 5250
		[CompilerGenerated]
		private TooltipContent #a;

		// Token: 0x04001483 RID: 5251
		[CompilerGenerated]
		private #MFb #b;

		// Token: 0x04001484 RID: 5252
		[CompilerGenerated]
		private string #c;

		// Token: 0x04001485 RID: 5253
		[CompilerGenerated]
		private ImageSource #d;
	}
}
