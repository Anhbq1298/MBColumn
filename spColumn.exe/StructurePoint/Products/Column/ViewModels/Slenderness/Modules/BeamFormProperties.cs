using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.ViewModels.Slenderness.Modules
{
	// Token: 0x02000135 RID: 309
	internal sealed class BeamFormProperties
	{
		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000A2E RID: 2606 RVA: 0x0000DC32 File Offset: 0x0000BE32
		// (set) Token: 0x06000A2F RID: 2607 RVA: 0x0000DC3E File Offset: 0x0000BE3E
		public DelegateCommand CopyToNextCommand { get; set; }

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06000A30 RID: 2608 RVA: 0x0000DC4F File Offset: 0x0000BE4F
		// (set) Token: 0x06000A31 RID: 2609 RVA: 0x0000DC5B File Offset: 0x0000BE5B
		public DelegateCommand CopyToPreviousCommand { get; set; }

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06000A32 RID: 2610 RVA: 0x0000DC6C File Offset: 0x0000BE6C
		// (set) Token: 0x06000A33 RID: 2611 RVA: 0x0000DC78 File Offset: 0x0000BE78
		public DelegateCommand CopyToAllCommand { get; set; }

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06000A34 RID: 2612 RVA: 0x0000DC89 File Offset: 0x0000BE89
		// (set) Token: 0x06000A35 RID: 2613 RVA: 0x0000DC95 File Offset: 0x0000BE95
		public ImageSource NextButtonImage { get; set; }

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06000A36 RID: 2614 RVA: 0x0000DCA6 File Offset: 0x0000BEA6
		// (set) Token: 0x06000A37 RID: 2615 RVA: 0x0000DCB2 File Offset: 0x0000BEB2
		public ImageSource PreviousButtonImage { get; set; }

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06000A38 RID: 2616 RVA: 0x0000DCC3 File Offset: 0x0000BEC3
		// (set) Token: 0x06000A39 RID: 2617 RVA: 0x0000DCCF File Offset: 0x0000BECF
		public HorizontalAlignment CopyButtonsAlignment { get; set; }

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06000A3A RID: 2618 RVA: 0x0000DCE0 File Offset: 0x0000BEE0
		// (set) Token: 0x06000A3B RID: 2619 RVA: 0x0000DCEC File Offset: 0x0000BEEC
		public CopyButtonsOrder CopyButtonsOrder { get; set; }

		// Token: 0x040003B3 RID: 947
		[CompilerGenerated]
		private DelegateCommand #a;

		// Token: 0x040003B4 RID: 948
		[CompilerGenerated]
		private DelegateCommand #b;

		// Token: 0x040003B5 RID: 949
		[CompilerGenerated]
		private DelegateCommand #c;

		// Token: 0x040003B6 RID: 950
		[CompilerGenerated]
		private ImageSource #d;

		// Token: 0x040003B7 RID: 951
		[CompilerGenerated]
		private ImageSource #e;

		// Token: 0x040003B8 RID: 952
		[CompilerGenerated]
		private HorizontalAlignment #f;

		// Token: 0x040003B9 RID: 953
		[CompilerGenerated]
		private CopyButtonsOrder #g;
	}
}
