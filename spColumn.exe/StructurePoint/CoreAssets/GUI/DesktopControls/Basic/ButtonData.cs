using System;
using System.Windows.Input;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A81 RID: 2689
	public class ButtonData : NotifyPropertyChangedObjectBase, IButtonData
	{
		// Token: 0x17001903 RID: 6403
		// (get) Token: 0x060057CA RID: 22474 RVA: 0x000487B5 File Offset: 0x000469B5
		// (set) Token: 0x060057CB RID: 22475 RVA: 0x000487C1 File Offset: 0x000469C1
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

		// Token: 0x17001904 RID: 6404
		// (get) Token: 0x060057CC RID: 22476 RVA: 0x000487FF File Offset: 0x000469FF
		// (set) Token: 0x060057CD RID: 22477 RVA: 0x0004880B File Offset: 0x00046A0B
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

		// Token: 0x17001905 RID: 6405
		// (get) Token: 0x060057CE RID: 22478 RVA: 0x00048849 File Offset: 0x00046A49
		// (set) Token: 0x060057CF RID: 22479 RVA: 0x00048855 File Offset: 0x00046A55
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

		// Token: 0x17001906 RID: 6406
		// (get) Token: 0x060057D0 RID: 22480 RVA: 0x00048893 File Offset: 0x00046A93
		// (set) Token: 0x060057D1 RID: 22481 RVA: 0x0004889F File Offset: 0x00046A9F
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

		// Token: 0x040024C7 RID: 9415
		private object content;

		// Token: 0x040024C8 RID: 9416
		private bool isEnabled;

		// Token: 0x040024C9 RID: 9417
		private ICommand command;

		// Token: 0x040024CA RID: 9418
		private object commandParameter;
	}
}
