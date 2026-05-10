using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008FB RID: 2299
	public class RibbonToolbarButton : NotifyPropertyChangedObjectBase, IRibbonToolbarButton
	{
		// Token: 0x0600493D RID: 18749 RVA: 0x0003D8E6 File Offset: 0x0003BAE6
		public RibbonToolbarButton()
		{
			this.IsEnabled = true;
		}

		// Token: 0x0600493E RID: 18750 RVA: 0x0003D8F5 File Offset: 0x0003BAF5
		public RibbonToolbarButton(Image mediumImage)
		{
			this.MediumImage = mediumImage;
			this.IsEnabled = true;
			this.TextVisibility = Visibility.Collapsed;
		}

		// Token: 0x0600493F RID: 18751 RVA: 0x0003D912 File Offset: 0x0003BB12
		public RibbonToolbarButton(Image mediumImage, string text, ICommand command) : this(mediumImage)
		{
			this.Command = command;
			this.Text = text;
			this.TextVisibility = Visibility.Visible;
			this.TextPosition = ButtonTextPosition.Right;
		}

		// Token: 0x06004940 RID: 18752 RVA: 0x0003D937 File Offset: 0x0003BB37
		public RibbonToolbarButton(Image mediumImage, string text)
		{
			this.MediumImage = mediumImage;
			this.IsEnabled = true;
			this.Text = text;
			this.TextVisibility = Visibility.Visible;
			this.TextPosition = ButtonTextPosition.Right;
		}

		// Token: 0x06004941 RID: 18753 RVA: 0x0003D962 File Offset: 0x0003BB62
		public RibbonToolbarButton(Image mediumImage, string text, ButtonTextPosition textPosition)
		{
			this.MediumImage = mediumImage;
			this.IsEnabled = true;
			this.Text = text;
			this.TextVisibility = Visibility.Visible;
			this.TextPosition = textPosition;
			this.Size = ButtonImageSize.Medium;
		}

		// Token: 0x06004942 RID: 18754 RVA: 0x0003D994 File Offset: 0x0003BB94
		public RibbonToolbarButton(Image image, string text, ButtonTextPosition textPosition, ButtonImageSize size)
		{
			this.IsEnabled = true;
			this.Text = text;
			this.TextVisibility = Visibility.Visible;
			this.TextPosition = textPosition;
			this.Size = size;
			if (size == ButtonImageSize.Medium)
			{
				this.MediumImage = image;
				return;
			}
			this.LargeImage = image;
		}

		// Token: 0x17001572 RID: 5490
		// (get) Token: 0x06004943 RID: 18755 RVA: 0x0003D9D3 File Offset: 0x0003BBD3
		// (set) Token: 0x06004944 RID: 18756 RVA: 0x00144E00 File Offset: 0x00143000
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

		// Token: 0x17001573 RID: 5491
		// (get) Token: 0x06004945 RID: 18757 RVA: 0x0003D9DF File Offset: 0x0003BBDF
		// (set) Token: 0x06004946 RID: 18758 RVA: 0x0003D9EB File Offset: 0x0003BBEB
		public Visibility TextVisibility
		{
			get
			{
				return this.textVisibility;
			}
			set
			{
				if (this.textVisibility != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450348));
					this.textVisibility = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450348));
				}
			}
		}

		// Token: 0x17001574 RID: 5492
		// (get) Token: 0x06004947 RID: 18759 RVA: 0x0003DA29 File Offset: 0x0003BC29
		// (set) Token: 0x06004948 RID: 18760 RVA: 0x0003DA35 File Offset: 0x0003BC35
		public ButtonTextPosition TextPosition
		{
			get
			{
				return this.textPosition;
			}
			set
			{
				if (this.textPosition != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450359));
					this.textPosition = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450359));
				}
			}
		}

		// Token: 0x17001575 RID: 5493
		// (get) Token: 0x06004949 RID: 18761 RVA: 0x0003DA73 File Offset: 0x0003BC73
		// (set) Token: 0x0600494A RID: 18762 RVA: 0x0003DA7F File Offset: 0x0003BC7F
		public ButtonImageSize Size
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

		// Token: 0x17001576 RID: 5494
		// (get) Token: 0x0600494B RID: 18763 RVA: 0x0003DABD File Offset: 0x0003BCBD
		// (set) Token: 0x0600494C RID: 18764 RVA: 0x0003DAC9 File Offset: 0x0003BCC9
		public Image MediumImage
		{
			get
			{
				return this.mediumImage;
			}
			set
			{
				if (this.mediumImage != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450310));
					this.mediumImage = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450310));
				}
			}
		}

		// Token: 0x17001577 RID: 5495
		// (get) Token: 0x0600494D RID: 18765 RVA: 0x0003DB07 File Offset: 0x0003BD07
		// (set) Token: 0x0600494E RID: 18766 RVA: 0x0003DB13 File Offset: 0x0003BD13
		public Image LargeImage
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

		// Token: 0x17001578 RID: 5496
		// (get) Token: 0x0600494F RID: 18767 RVA: 0x0003DB51 File Offset: 0x0003BD51
		// (set) Token: 0x06004950 RID: 18768 RVA: 0x0003DB5D File Offset: 0x0003BD5D
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

		// Token: 0x17001579 RID: 5497
		// (get) Token: 0x06004951 RID: 18769 RVA: 0x0003DB9B File Offset: 0x0003BD9B
		// (set) Token: 0x06004952 RID: 18770 RVA: 0x0003DBA7 File Offset: 0x0003BDA7
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

		// Token: 0x1700157A RID: 5498
		// (get) Token: 0x06004953 RID: 18771 RVA: 0x0003DBE5 File Offset: 0x0003BDE5
		// (set) Token: 0x06004954 RID: 18772 RVA: 0x0003DBF1 File Offset: 0x0003BDF1
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

		// Token: 0x1700157B RID: 5499
		// (get) Token: 0x06004955 RID: 18773 RVA: 0x0003DC2F File Offset: 0x0003BE2F
		// (set) Token: 0x06004956 RID: 18774 RVA: 0x0003DC3B File Offset: 0x0003BE3B
		public RichToolTipContent ToolTipContent
		{
			get
			{
				return this.toolTipContent;
			}
			set
			{
				if (this.toolTipContent != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450186));
					this.toolTipContent = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450186));
				}
			}
		}

		// Token: 0x1700157C RID: 5500
		// (get) Token: 0x06004957 RID: 18775 RVA: 0x0003DC79 File Offset: 0x0003BE79
		// (set) Token: 0x06004958 RID: 18776 RVA: 0x0003DC85 File Offset: 0x0003BE85
		public Visibility Visibility
		{
			get
			{
				return this.visibility;
			}
			set
			{
				if (this.visibility != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107384000));
					this.visibility = value;
					base.RaisePropertyChanged(#Phc.#3hc(107384000));
				}
			}
		}

		// Token: 0x040020D9 RID: 8409
		private string text;

		// Token: 0x040020DA RID: 8410
		private ButtonImageSize size;

		// Token: 0x040020DB RID: 8411
		private Image mediumImage;

		// Token: 0x040020DC RID: 8412
		private Image largeImage;

		// Token: 0x040020DD RID: 8413
		private ICommand command;

		// Token: 0x040020DE RID: 8414
		private object commandParameter;

		// Token: 0x040020DF RID: 8415
		private bool isEnabled;

		// Token: 0x040020E0 RID: 8416
		private RichToolTipContent toolTipContent;

		// Token: 0x040020E1 RID: 8417
		private Visibility textVisibility;

		// Token: 0x040020E2 RID: 8418
		private ButtonTextPosition textPosition;

		// Token: 0x040020E3 RID: 8419
		private Visibility visibility;
	}
}
