using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A8F RID: 2703
	public sealed class CustomRadDateTimePicker : RadDateTimePicker
	{
		// Token: 0x06005837 RID: 22583 RVA: 0x00048DF2 File Offset: 0x00046FF2
		public CustomRadDateTimePicker()
		{
			Validation.SetErrorTemplate(this, null);
		}

		// Token: 0x06005838 RID: 22584 RVA: 0x00048E0C File Offset: 0x0004700C
		protected override void OnParseDateTime(ParseDateTimeEventArgs e)
		{
			if (string.IsNullOrEmpty(e.TextToParse))
			{
				e.Result = new DateTime?(e.PreviousValue);
			}
			e.IsParsingSuccessful = true;
		}

		// Token: 0x06005839 RID: 22585 RVA: 0x00168FE0 File Offset: 0x001671E0
		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			List<DateTime> source = e.AddedItems.OfType<DateTime>().ToList<DateTime>();
			if (source.Any<DateTime>())
			{
				this.lastSelectedDateTime = source.First<DateTime>();
				return;
			}
			base.SelectedValue = new DateTime?(this.lastSelectedDateTime);
		}

		// Token: 0x040024ED RID: 9453
		private DateTime lastSelectedDateTime = DateTime.Now;
	}
}
