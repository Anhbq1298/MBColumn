using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using #5Fd;
using #mKd;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Navigation
{
	// Token: 0x02000E0A RID: 3594
	[DebuggerDisplay("{Name}")]
	public sealed class ResultsContentOption : ReportContentVisibilityOption
	{
		// Token: 0x06008173 RID: 33139 RVA: 0x001C2D68 File Offset: 0x001C0F68
		public ResultsContentOption(Option option, #7Fd deformatter, string name, ResultsContentOption parent = null, bool isHeader = false) : base(option, name, parent, isHeader)
		{
			if (!isHeader)
			{
				this.Renderer = new #XKd(option, deformatter, null);
			}
			base.IsCheckable = false;
		}

		// Token: 0x17002696 RID: 9878
		// (get) Token: 0x06008174 RID: 33140 RVA: 0x00069732 File Offset: 0x00067932
		// (set) Token: 0x06008175 RID: 33141 RVA: 0x0006973E File Offset: 0x0006793E
		public #XKd Renderer { get; set; }

		// Token: 0x17002697 RID: 9879
		// (get) Token: 0x06008176 RID: 33142 RVA: 0x0006974F File Offset: 0x0006794F
		// (set) Token: 0x06008177 RID: 33143 RVA: 0x0006975B File Offset: 0x0006795B
		public DocumentContentOptionsCore Options { get; set; }

		// Token: 0x04003524 RID: 13604
		[CompilerGenerated]
		private #XKd #a;

		// Token: 0x04003525 RID: 13605
		[CompilerGenerated]
		private DocumentContentOptionsCore #b;
	}
}
