using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Controls;
using System.Windows.Input;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x02000900 RID: 2304
	[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Toolbar")]
	public sealed class RibbonToolbarToggleButton : RibbonToolbarButton, IRibbonToolbarButton, IRibbonToolbarToggleButton
	{
		// Token: 0x06004976 RID: 18806 RVA: 0x0003DF5D File Offset: 0x0003C15D
		public RibbonToolbarToggleButton(Image mediumImage, string text, ICommand command) : base(mediumImage, text, command)
		{
			base.Command = command;
			base.Text = text;
			base.TextPosition = ButtonTextPosition.Bottom;
		}

		// Token: 0x17001587 RID: 5511
		// (get) Token: 0x06004977 RID: 18807 RVA: 0x0003DF7D File Offset: 0x0003C17D
		// (set) Token: 0x06004978 RID: 18808 RVA: 0x0003DF89 File Offset: 0x0003C189
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
					base.RaisePropertyChanging(#Phc.#3hc(107407606));
					this.isChecked = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407606));
				}
			}
		}

		// Token: 0x040020EE RID: 8430
		private bool isChecked;
	}
}
