using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008A4 RID: 2212
	public sealed class RibbonToggleButton : RibbonButton
	{
		// Token: 0x060045C8 RID: 17864 RVA: 0x0003A4B7 File Offset: 0x000386B7
		public RibbonToggleButton(Image image, string text, bool large, object toggleValue, bool isChecked, string tooltipHeader, string tooltipMessage) : base(image, text, large, null, null, true)
		{
			this.toggleValue = toggleValue;
			this.isChecked = isChecked;
			base.TooltipMessage = tooltipMessage;
			base.TooltipHeader = tooltipHeader;
		}

		// Token: 0x17001466 RID: 5222
		// (get) Token: 0x060045C9 RID: 17865 RVA: 0x0003A4E5 File Offset: 0x000386E5
		// (set) Token: 0x060045CA RID: 17866 RVA: 0x0003A4F1 File Offset: 0x000386F1
		public bool IsChecked
		{
			get
			{
				return this.isChecked;
			}
			set
			{
				if (this.isChecked != value)
				{
					this.isChecked = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407606));
					this.RaiseIsCheckedChanged();
				}
			}
		}

		// Token: 0x17001467 RID: 5223
		// (get) Token: 0x060045CB RID: 17867 RVA: 0x0003A525 File Offset: 0x00038725
		public object ToggleValue
		{
			get
			{
				return this.toggleValue;
			}
		}

		// Token: 0x140000E0 RID: 224
		// (add) Token: 0x060045CC RID: 17868 RVA: 0x0013D2F8 File Offset: 0x0013B4F8
		// (remove) Token: 0x060045CD RID: 17869 RVA: 0x0013D33C File Offset: 0x0013B53C
		internal event EventHandler<IsCheckedChangedEventArgs<object>> IsCheckedChanged;

		// Token: 0x060045CE RID: 17870 RVA: 0x0003A531 File Offset: 0x00038731
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		protected void RaiseIsCheckedChanged()
		{
			if (this.IsCheckedChanged != null)
			{
				this.IsCheckedChanged(this, new IsCheckedChangedEventArgs<object>(this.isChecked, this.toggleValue));
			}
		}

		// Token: 0x04001FAD RID: 8109
		private readonly object toggleValue;

		// Token: 0x04001FAE RID: 8110
		private bool isChecked;
	}
}
