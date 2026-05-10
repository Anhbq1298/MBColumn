using System;
using System.Linq;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x0200085A RID: 2138
	public sealed class TemplateLeadersRenderer : TemplatesCoreRenderer
	{
		// Token: 0x060043F9 RID: 17401 RVA: 0x00139F18 File Offset: 0x00138118
		public override void DrawForeground()
		{
			foreach (CustomLeaderAndText customLeaderAndText in base.Editor.Labels.OfType<CustomLeaderAndText>())
			{
				customLeaderAndText.UpdateAnchorPoint();
			}
		}

		// Token: 0x060043FA RID: 17402 RVA: 0x00139F6C File Offset: 0x0013816C
		private string Max(string val1, string val2)
		{
			int? num = (val1 != null) ? new int?(val1.Length) : null;
			int? num2 = (val2 != null) ? new int?(val2.Length) : null;
			if (!(num.GetValueOrDefault() > num2.GetValueOrDefault() & (num != null & num2 != null)))
			{
				return val2;
			}
			return val1;
		}
	}
}
