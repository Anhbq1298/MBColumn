using System;
using System.Drawing;
using System.Windows.Input;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using Telerik.Windows.Controls.RibbonView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008A1 RID: 2209
	public class RibbonButton : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06004594 RID: 17812 RVA: 0x0000C5B9 File Offset: 0x0000A7B9
		protected RibbonButton()
		{
		}

		// Token: 0x06004595 RID: 17813 RVA: 0x0003A0C3 File Offset: 0x000382C3
		public RibbonButton(Image image, string text, bool isLarge, ICommand command, object commandParameter, bool isEnabled)
		{
			this.SmallImage = image;
			if (isLarge)
			{
				this.LargeImage = image;
				this.Size = ButtonSize.Large;
			}
			this.Text = text;
			this.command = command;
			this.commandParameter = commandParameter;
			this.isEnabled = isEnabled;
		}

		// Token: 0x17001450 RID: 5200
		// (get) Token: 0x06004596 RID: 17814 RVA: 0x0003A102 File Offset: 0x00038302
		// (set) Token: 0x06004597 RID: 17815 RVA: 0x0013D0E0 File Offset: 0x0013B2E0
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				if (this.text != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107350927));
					this.text = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350927));
				}
			}
		}

		// Token: 0x17001451 RID: 5201
		// (get) Token: 0x06004598 RID: 17816 RVA: 0x0003A10E File Offset: 0x0003830E
		// (set) Token: 0x06004599 RID: 17817 RVA: 0x0003A11A File Offset: 0x0003831A
		public ButtonSize Size
		{
			get
			{
				return this.size;
			}
			set
			{
				if (this.size != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397811));
					this.size = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397811));
				}
			}
		}

		// Token: 0x17001452 RID: 5202
		// (get) Token: 0x0600459A RID: 17818 RVA: 0x0003A158 File Offset: 0x00038358
		// (set) Token: 0x0600459B RID: 17819 RVA: 0x0003A164 File Offset: 0x00038364
		public object SmallImage
		{
			get
			{
				return this.smallImage;
			}
			set
			{
				if (this.smallImage != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453551));
					this.smallImage = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453551));
				}
			}
		}

		// Token: 0x17001453 RID: 5203
		// (get) Token: 0x0600459C RID: 17820 RVA: 0x0003A1A2 File Offset: 0x000383A2
		// (set) Token: 0x0600459D RID: 17821 RVA: 0x0003A1AE File Offset: 0x000383AE
		public object LargeImage
		{
			get
			{
				return this.largeImage;
			}
			set
			{
				if (this.largeImage != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453566));
					this.largeImage = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453566));
				}
			}
		}

		// Token: 0x17001454 RID: 5204
		// (get) Token: 0x0600459E RID: 17822 RVA: 0x0003A1EC File Offset: 0x000383EC
		// (set) Token: 0x0600459F RID: 17823 RVA: 0x0003A1F8 File Offset: 0x000383F8
		public ICommand Command
		{
			get
			{
				return this.command;
			}
			set
			{
				if (this.command != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107350928));
					this.command = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350928));
				}
			}
		}

		// Token: 0x17001455 RID: 5205
		// (get) Token: 0x060045A0 RID: 17824 RVA: 0x0003A236 File Offset: 0x00038436
		// (set) Token: 0x060045A1 RID: 17825 RVA: 0x0003A242 File Offset: 0x00038442
		public object CommandParameter
		{
			get
			{
				return this.commandParameter;
			}
			set
			{
				if (this.commandParameter != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107350883));
					this.commandParameter = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350883));
				}
			}
		}

		// Token: 0x17001456 RID: 5206
		// (get) Token: 0x060045A2 RID: 17826 RVA: 0x0003A280 File Offset: 0x00038480
		// (set) Token: 0x060045A3 RID: 17827 RVA: 0x0013D130 File Offset: 0x0013B330
		public string TooltipHeader
		{
			get
			{
				return this.tooltipHeader;
			}
			set
			{
				if (this.tooltipHeader != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453517));
					this.tooltipHeader = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453517));
				}
			}
		}

		// Token: 0x17001457 RID: 5207
		// (get) Token: 0x060045A4 RID: 17828 RVA: 0x0003A28C File Offset: 0x0003848C
		// (set) Token: 0x060045A5 RID: 17829 RVA: 0x0013D180 File Offset: 0x0013B380
		public string TooltipMessage
		{
			get
			{
				return this.tooltipMessage;
			}
			set
			{
				if (this.tooltipMessage != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453528));
					this.tooltipMessage = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453528));
				}
			}
		}

		// Token: 0x17001458 RID: 5208
		// (get) Token: 0x060045A6 RID: 17830 RVA: 0x0003A298 File Offset: 0x00038498
		// (set) Token: 0x060045A7 RID: 17831 RVA: 0x0003A2A4 File Offset: 0x000384A4
		public bool IsEnabled
		{
			get
			{
				return this.isEnabled;
			}
			set
			{
				if (this.isEnabled != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107408148));
					this.isEnabled = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408148));
				}
			}
		}

		// Token: 0x04001F96 RID: 8086
		private string text;

		// Token: 0x04001F97 RID: 8087
		private ButtonSize size;

		// Token: 0x04001F98 RID: 8088
		private object smallImage;

		// Token: 0x04001F99 RID: 8089
		private object largeImage;

		// Token: 0x04001F9A RID: 8090
		private ICommand command;

		// Token: 0x04001F9B RID: 8091
		private object commandParameter;

		// Token: 0x04001F9C RID: 8092
		private string tooltipHeader;

		// Token: 0x04001F9D RID: 8093
		private string tooltipMessage;

		// Token: 0x04001F9E RID: 8094
		private bool isEnabled;
	}
}
