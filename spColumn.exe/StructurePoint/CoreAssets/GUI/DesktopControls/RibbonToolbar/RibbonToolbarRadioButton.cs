using System;
using System.Windows.Controls;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008FE RID: 2302
	public class RibbonToolbarRadioButton : RibbonToolbarButton, IRibbonToolbarButton, IRibbonToolbarRadioButton
	{
		// Token: 0x06004963 RID: 18787 RVA: 0x0003DD93 File Offset: 0x0003BF93
		public RibbonToolbarRadioButton()
		{
		}

		// Token: 0x06004964 RID: 18788 RVA: 0x0003DD9B File Offset: 0x0003BF9B
		public RibbonToolbarRadioButton(Image smallImage, string groupName) : base(smallImage)
		{
			this.GroupName = groupName;
		}

		// Token: 0x06004965 RID: 18789 RVA: 0x0003DDAB File Offset: 0x0003BFAB
		public RibbonToolbarRadioButton(Image smallImage, string groupName, string text) : base(smallImage, text)
		{
			this.GroupName = groupName;
		}

		// Token: 0x06004966 RID: 18790 RVA: 0x0003DDBC File Offset: 0x0003BFBC
		public RibbonToolbarRadioButton(Image smallImage, string groupName, string text, ButtonTextPosition textPosition) : base(smallImage, text, textPosition)
		{
			this.GroupName = groupName;
		}

		// Token: 0x17001581 RID: 5505
		// (get) Token: 0x06004967 RID: 18791 RVA: 0x0003DDCF File Offset: 0x0003BFCF
		// (set) Token: 0x06004968 RID: 18792 RVA: 0x0003DDDB File Offset: 0x0003BFDB
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

		// Token: 0x17001582 RID: 5506
		// (get) Token: 0x06004969 RID: 18793 RVA: 0x0003DE19 File Offset: 0x0003C019
		// (set) Token: 0x0600496A RID: 18794 RVA: 0x00144EEC File Offset: 0x001430EC
		public string GroupName
		{
			get
			{
				return this.groupName;
			}
			set
			{
				if (this.groupName != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453596));
					this.groupName = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453596));
				}
			}
		}

		// Token: 0x040020E8 RID: 8424
		private bool isChecked;

		// Token: 0x040020E9 RID: 8425
		private string groupName;
	}
}
