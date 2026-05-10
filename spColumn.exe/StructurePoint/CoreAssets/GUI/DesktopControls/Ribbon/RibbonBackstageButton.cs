using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Input;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008A0 RID: 2208
	public sealed class RibbonBackstageButton : RibbonButton
	{
		// Token: 0x0600458A RID: 17802 RVA: 0x0013CFF8 File Offset: 0x0013B1F8
		public RibbonBackstageButton(Image image, string text, bool large, ICommand command, object commandParameter, bool closeOnClick, bool isEnabled) : this(new RibbonBackstageButtonParameters
		{
			Image = image,
			Text = text,
			Large = large,
			Command = command,
			CommandParameter = commandParameter,
			CloseOnClick = closeOnClick,
			IsEnabled = isEnabled,
			IsSelectable = false,
			IsSelected = true,
			SelectableContent = null
		})
		{
		}

		// Token: 0x0600458B RID: 17803 RVA: 0x0013D05C File Offset: 0x0013B25C
		[SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
		public RibbonBackstageButton(RibbonBackstageButtonParameters ribbonBackstageButtonParameters) : base(ribbonBackstageButtonParameters.Image, ribbonBackstageButtonParameters.Text, ribbonBackstageButtonParameters.Large, ribbonBackstageButtonParameters.Command, ribbonBackstageButtonParameters.CommandParameter, ribbonBackstageButtonParameters.IsEnabled)
		{
			#X0d.#V0d(ribbonBackstageButtonParameters, #Phc.#3hc(107454092), Component.GUI, #Phc.#3hc(107454079));
			this.IsSelectable = ribbonBackstageButtonParameters.IsSelectable;
			this.IsSelected = ribbonBackstageButtonParameters.IsSelected;
			this.SelectableContent = ribbonBackstageButtonParameters.SelectableContent;
			this.closeOnClick = ribbonBackstageButtonParameters.CloseOnClick;
		}

		// Token: 0x1700144C RID: 5196
		// (get) Token: 0x0600458C RID: 17804 RVA: 0x00039F9B File Offset: 0x0003819B
		// (set) Token: 0x0600458D RID: 17805 RVA: 0x00039FA7 File Offset: 0x000381A7
		public bool CloseOnClick
		{
			get
			{
				return this.closeOnClick;
			}
			set
			{
				if (this.closeOnClick != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453994));
					this.closeOnClick = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453994));
				}
			}
		}

		// Token: 0x1700144D RID: 5197
		// (get) Token: 0x0600458E RID: 17806 RVA: 0x00039FE5 File Offset: 0x000381E5
		// (set) Token: 0x0600458F RID: 17807 RVA: 0x00039FF1 File Offset: 0x000381F1
		public bool IsSelectable
		{
			get
			{
				return this.isSelectable;
			}
			set
			{
				if (this.isSelectable != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107454009));
					this.isSelectable = value;
					base.RaisePropertyChanged(#Phc.#3hc(107454009));
				}
			}
		}

		// Token: 0x1700144E RID: 5198
		// (get) Token: 0x06004590 RID: 17808 RVA: 0x0003A02F File Offset: 0x0003822F
		// (set) Token: 0x06004591 RID: 17809 RVA: 0x0003A03B File Offset: 0x0003823B
		public bool IsSelected
		{
			get
			{
				return this.isSelected;
			}
			set
			{
				if (this.isSelected != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107407591));
					this.isSelected = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407591));
				}
			}
		}

		// Token: 0x1700144F RID: 5199
		// (get) Token: 0x06004592 RID: 17810 RVA: 0x0003A079 File Offset: 0x00038279
		// (set) Token: 0x06004593 RID: 17811 RVA: 0x0003A085 File Offset: 0x00038285
		public object SelectableContent
		{
			get
			{
				return this.selectableContent;
			}
			set
			{
				if (this.selectableContent != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453960));
					this.selectableContent = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453960));
				}
			}
		}

		// Token: 0x04001F92 RID: 8082
		private bool closeOnClick;

		// Token: 0x04001F93 RID: 8083
		private bool isSelectable;

		// Token: 0x04001F94 RID: 8084
		private object selectableContent;

		// Token: 0x04001F95 RID: 8085
		private bool isSelected;
	}
}
