using System;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A85 RID: 2693
	public class CheckBoxData : NotifyPropertyChangedObjectBase, ICheckBoxData
	{
		// Token: 0x060057E8 RID: 22504 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void OnIsCheckedChanged(bool oldValue, bool newValue)
		{
		}

		// Token: 0x1700190E RID: 6414
		// (get) Token: 0x060057E9 RID: 22505 RVA: 0x000489AD File Offset: 0x00046BAD
		// (set) Token: 0x060057EA RID: 22506 RVA: 0x000489B9 File Offset: 0x00046BB9
		public object Content
		{
			get
			{
				return this.content;
			}
			set
			{
				if (this.content != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107470833));
					this.content = value;
					base.RaisePropertyChanged(#Phc.#3hc(107470833));
				}
			}
		}

		// Token: 0x1700190F RID: 6415
		// (get) Token: 0x060057EB RID: 22507 RVA: 0x000489F7 File Offset: 0x00046BF7
		// (set) Token: 0x060057EC RID: 22508 RVA: 0x00048A03 File Offset: 0x00046C03
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

		// Token: 0x17001910 RID: 6416
		// (get) Token: 0x060057ED RID: 22509 RVA: 0x00048A41 File Offset: 0x00046C41
		// (set) Token: 0x060057EE RID: 22510 RVA: 0x00168570 File Offset: 0x00166770
		public bool IsChecked
		{
			get
			{
				return this.isChecked;
			}
			set
			{
				bool flag = this.isChecked;
				if (flag != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107407606));
					this.isChecked = value;
					this.OnIsCheckedChanged(flag, value);
					base.RaisePropertyChanged(#Phc.#3hc(107407606));
				}
			}
		}

		// Token: 0x17001911 RID: 6417
		// (get) Token: 0x060057EF RID: 22511 RVA: 0x00048A4D File Offset: 0x00046C4D
		// (set) Token: 0x060057F0 RID: 22512 RVA: 0x00048A59 File Offset: 0x00046C59
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

		// Token: 0x17001912 RID: 6418
		// (get) Token: 0x060057F1 RID: 22513 RVA: 0x00048A97 File Offset: 0x00046C97
		// (set) Token: 0x060057F2 RID: 22514 RVA: 0x001685C4 File Offset: 0x001667C4
		public Color? Color
		{
			get
			{
				return this.color;
			}
			set
			{
				Color? color = this.color;
				Color? color2;
				if (2 != 0)
				{
					color2 = color;
				}
				if (color2 != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453335));
					this.color = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453335));
				}
			}
		}

		// Token: 0x040024D0 RID: 9424
		private object content;

		// Token: 0x040024D1 RID: 9425
		private bool isEnabled;

		// Token: 0x040024D2 RID: 9426
		private bool isChecked;

		// Token: 0x040024D3 RID: 9427
		private ICommand command;

		// Token: 0x040024D4 RID: 9428
		private Color? color;
	}
}
