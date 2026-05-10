using System;
using System.Windows;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B0D RID: 2829
	public sealed class DynamicInputValueConfiguration : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17001A6C RID: 6764
		// (get) Token: 0x06005C98 RID: 23704 RVA: 0x0004D3FF File Offset: 0x0004B5FF
		// (set) Token: 0x06005C99 RID: 23705 RVA: 0x0004D407 File Offset: 0x0004B607
		public string Label
		{
			get
			{
				return this.label;
			}
			set
			{
				if (this.label != value)
				{
					this.label = value;
					base.RaisePropertyChanged(#Phc.#3hc(107420885));
				}
			}
		}

		// Token: 0x17001A6D RID: 6765
		// (get) Token: 0x06005C9A RID: 23706 RVA: 0x0004D42E File Offset: 0x0004B62E
		// (set) Token: 0x06005C9B RID: 23707 RVA: 0x0004D436 File Offset: 0x0004B636
		public string Unit
		{
			get
			{
				return this.unit;
			}
			set
			{
				if (this.unit != value)
				{
					this.unit = value;
					base.RaisePropertyChanged(#Phc.#3hc(107398174));
				}
			}
		}

		// Token: 0x17001A6E RID: 6766
		// (get) Token: 0x06005C9C RID: 23708 RVA: 0x0004D45D File Offset: 0x0004B65D
		// (set) Token: 0x06005C9D RID: 23709 RVA: 0x0004D465 File Offset: 0x0004B665
		public bool Enabled
		{
			get
			{
				return this.enabled;
			}
			set
			{
				if (this.enabled != value)
				{
					this.enabled = value;
					base.RaisePropertyChanged(#Phc.#3hc(107398111));
				}
			}
		}

		// Token: 0x17001A6F RID: 6767
		// (get) Token: 0x06005C9E RID: 23710 RVA: 0x0004D487 File Offset: 0x0004B687
		// (set) Token: 0x06005C9F RID: 23711 RVA: 0x0004D48F File Offset: 0x0004B68F
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
					this.visibility = value;
					base.RaisePropertyChanged(#Phc.#3hc(107384000));
				}
			}
		}

		// Token: 0x17001A70 RID: 6768
		// (get) Token: 0x06005CA0 RID: 23712 RVA: 0x0004D4B1 File Offset: 0x0004B6B1
		public bool IsVisible
		{
			get
			{
				return this.Visibility == Visibility.Visible;
			}
		}

		// Token: 0x17001A71 RID: 6769
		// (get) Token: 0x06005CA1 RID: 23713 RVA: 0x0004D4BC File Offset: 0x0004B6BC
		public bool EnabledAndVisible
		{
			get
			{
				return this.Enabled && this.IsVisible;
			}
		}

		// Token: 0x0400268B RID: 9867
		private string label;

		// Token: 0x0400268C RID: 9868
		private string unit;

		// Token: 0x0400268D RID: 9869
		private bool enabled = true;

		// Token: 0x0400268E RID: 9870
		private Visibility visibility;
	}
}
