using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #7Pb
{
	// Token: 0x020006B7 RID: 1719
	internal sealed class #nQb : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17001193 RID: 4499
		// (get) Token: 0x06003928 RID: 14632 RVA: 0x00031A4D File Offset: 0x0002FC4D
		public static #nQb Separator
		{
			get
			{
				return new #nQb
				{
					IsSeparator = true
				};
			}
		}

		// Token: 0x17001194 RID: 4500
		// (get) Token: 0x06003929 RID: 14633 RVA: 0x00031A5F File Offset: 0x0002FC5F
		// (set) Token: 0x0600392A RID: 14634 RVA: 0x00031A6B File Offset: 0x0002FC6B
		public HorizontalAlignment HorizontalAlignment { get; set; }

		// Token: 0x17001195 RID: 4501
		// (get) Token: 0x0600392B RID: 14635 RVA: 0x00031A7C File Offset: 0x0002FC7C
		// (set) Token: 0x0600392C RID: 14636 RVA: 0x00031A88 File Offset: 0x0002FC88
		public string Value
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107399374));
				}
			}
		}

		// Token: 0x17001196 RID: 4502
		// (get) Token: 0x0600392D RID: 14637 RVA: 0x00031ABB File Offset: 0x0002FCBB
		// (set) Token: 0x0600392E RID: 14638 RVA: 0x00031AC7 File Offset: 0x0002FCC7
		public bool IsSeparator { get; private set; }

		// Token: 0x17001197 RID: 4503
		// (get) Token: 0x0600392F RID: 14639 RVA: 0x00031AD8 File Offset: 0x0002FCD8
		// (set) Token: 0x06003930 RID: 14640 RVA: 0x00031AE4 File Offset: 0x0002FCE4
		public int Index
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350745));
				}
			}
		}

		// Token: 0x04001807 RID: 6151
		private string #a;

		// Token: 0x04001808 RID: 6152
		private int #b;

		// Token: 0x04001809 RID: 6153
		[CompilerGenerated]
		private HorizontalAlignment #c;

		// Token: 0x0400180A RID: 6154
		[CompilerGenerated]
		private bool #d;
	}
}
