using System;
using System.Collections.ObjectModel;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008AE RID: 2222
	public sealed class RibbonGroup : NotifyPropertyChangedObjectBase
	{
		// Token: 0x0600460F RID: 17935 RVA: 0x0003A938 File Offset: 0x00038B38
		public RibbonGroup(string text)
		{
			this.Text = text;
			this.buttons = new ObservableCollection<RibbonButton>();
		}

		// Token: 0x17001480 RID: 5248
		// (get) Token: 0x06004610 RID: 17936 RVA: 0x0003A952 File Offset: 0x00038B52
		public ObservableCollection<RibbonButton> Buttons
		{
			get
			{
				return this.buttons;
			}
		}

		// Token: 0x17001481 RID: 5249
		// (get) Token: 0x06004611 RID: 17937 RVA: 0x0003A95E File Offset: 0x00038B5E
		// (set) Token: 0x06004612 RID: 17938 RVA: 0x0013D718 File Offset: 0x0013B918
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

		// Token: 0x04001FCC RID: 8140
		private string text;

		// Token: 0x04001FCD RID: 8141
		private readonly ObservableCollection<RibbonButton> buttons;
	}
}
