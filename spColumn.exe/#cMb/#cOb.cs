using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #cMb
{
	// Token: 0x0200068D RID: 1677
	[DebuggerDisplay("{GetDebuggerDescription()}")]
	internal sealed class #cOb : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06003835 RID: 14389 RVA: 0x00030D2A File Offset: 0x0002EF2A
		public #cOb(#uNb #Ph)
		{
			if (#Ph == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351828));
			}
			this.#f = #Ph;
		}

		// Token: 0x06003836 RID: 14390 RVA: 0x00030D62 File Offset: 0x0002EF62
		public #cOb()
		{
		}

		// Token: 0x17001159 RID: 4441
		// (get) Token: 0x06003837 RID: 14391 RVA: 0x00030D7F File Offset: 0x0002EF7F
		public #uNb Tool { get; }

		// Token: 0x1700115A RID: 4442
		// (get) Token: 0x06003838 RID: 14392 RVA: 0x00030D8B File Offset: 0x0002EF8B
		// (set) Token: 0x06003839 RID: 14393 RVA: 0x00030D97 File Offset: 0x0002EF97
		public bool IsEnabled
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
					base.RaisePropertyChanged(#Phc.#3hc(107408148));
				}
			}
		}

		// Token: 0x1700115B RID: 4443
		// (get) Token: 0x0600383A RID: 14394 RVA: 0x00030DC5 File Offset: 0x0002EFC5
		// (set) Token: 0x0600383B RID: 14395 RVA: 0x00030DD1 File Offset: 0x0002EFD1
		public bool IsSelected
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407591));
					base.RaisePropertyChanged(#Phc.#3hc(107407591));
				}
			}
		}

		// Token: 0x1700115C RID: 4444
		// (get) Token: 0x0600383C RID: 14396 RVA: 0x00030E0F File Offset: 0x0002F00F
		// (set) Token: 0x0600383D RID: 14397 RVA: 0x00030E1B File Offset: 0x0002F01B
		public bool IsVisible
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
					this.Visibility = (value ? Visibility.Visible : Visibility.Collapsed);
					base.RaisePropertyChanged(#Phc.#3hc(107351275));
				}
			}
		}

		// Token: 0x1700115D RID: 4445
		// (get) Token: 0x0600383E RID: 14398 RVA: 0x00030E56 File Offset: 0x0002F056
		// (set) Token: 0x0600383F RID: 14399 RVA: 0x00030E62 File Offset: 0x0002F062
		public Visibility Visibility
		{
			get
			{
				return this.#c;
			}
			private set
			{
				if (this.#c != value)
				{
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107384000));
				}
			}
		}

		// Token: 0x1700115E RID: 4446
		// (get) Token: 0x06003840 RID: 14400 RVA: 0x00030E90 File Offset: 0x0002F090
		// (set) Token: 0x06003841 RID: 14401 RVA: 0x00030E9C File Offset: 0x0002F09C
		public bool CanDeactivateFromUI
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107351294));
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107351294));
				}
			}
		}

		// Token: 0x06003842 RID: 14402 RVA: 0x0010F4C8 File Offset: 0x0010D6C8
		private string #bOb()
		{
			#uNb #uNb = this.Tool;
			string text;
			if ((text = ((#uNb != null) ? #uNb.GetType().Name : null)) == null)
			{
				text = #Phc.#3hc(107362262);
			}
			string arg = text;
			return string.Format(#Phc.#3hc(107351233), arg, this.IsSelected, this.IsEnabled);
		}

		// Token: 0x04001793 RID: 6035
		private bool #a = true;

		// Token: 0x04001794 RID: 6036
		private bool #b = true;

		// Token: 0x04001795 RID: 6037
		private Visibility #c;

		// Token: 0x04001796 RID: 6038
		private bool #d;

		// Token: 0x04001797 RID: 6039
		private bool #e = true;

		// Token: 0x04001798 RID: 6040
		[CompilerGenerated]
		private readonly #uNb #f;
	}
}
