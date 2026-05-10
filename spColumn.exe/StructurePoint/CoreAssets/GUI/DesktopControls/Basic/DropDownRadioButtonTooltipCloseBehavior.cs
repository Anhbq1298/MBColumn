using System;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A95 RID: 2709
	public sealed class DropDownRadioButtonTooltipCloseBehavior : Behavior<DropDownRadioButton>
	{
		// Token: 0x0600585C RID: 22620 RVA: 0x00049094 File Offset: 0x00047294
		protected override void OnAttached()
		{
			base.OnAttached();
			base.AssociatedObject.PopupOpened += this.AssociatedObject_PopupOpened;
		}

		// Token: 0x0600585D RID: 22621 RVA: 0x000490BF File Offset: 0x000472BF
		protected override void OnDetaching()
		{
			base.OnDetaching();
			base.AssociatedObject.PopupOpened -= this.AssociatedObject_PopupOpened;
		}

		// Token: 0x0600585E RID: 22622 RVA: 0x000490EA File Offset: 0x000472EA
		private void AssociatedObject_PopupOpened(object sender, EventArgs e)
		{
			RadToolTipService.HideTooltip(base.AssociatedObject);
		}
	}
}
