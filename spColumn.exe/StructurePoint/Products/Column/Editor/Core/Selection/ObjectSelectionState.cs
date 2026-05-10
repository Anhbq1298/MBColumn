using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.Products.Column.Editor.Core.Selection
{
	// Token: 0x0200068F RID: 1679
	[DebuggerDisplay("Any: {AnySelected}, Only: {OnlySelected}, Single: {SingleSelected}")]
	internal class ObjectSelectionState : NotifyPropertyChangedObjectBase
	{
		// Token: 0x1700115F RID: 4447
		// (get) Token: 0x06003845 RID: 14405 RVA: 0x00030EFF File Offset: 0x0002F0FF
		// (set) Token: 0x06003846 RID: 14406 RVA: 0x00030F0B File Offset: 0x0002F10B
		public bool AnySelected
		{
			get
			{
				return this.#a;
			}
			private set
			{
				if (this.#a != value)
				{
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107351216));
				}
			}
		}

		// Token: 0x17001160 RID: 4448
		// (get) Token: 0x06003847 RID: 14407 RVA: 0x00030F39 File Offset: 0x0002F139
		// (set) Token: 0x06003848 RID: 14408 RVA: 0x00030F45 File Offset: 0x0002F145
		public bool OnlySelected
		{
			get
			{
				return this.#b;
			}
			private set
			{
				if (this.#b != value)
				{
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107351199));
				}
			}
		}

		// Token: 0x17001161 RID: 4449
		// (get) Token: 0x06003849 RID: 14409 RVA: 0x00030F73 File Offset: 0x0002F173
		// (set) Token: 0x0600384A RID: 14410 RVA: 0x00030F7F File Offset: 0x0002F17F
		public bool SingleSelected
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
					base.RaisePropertyChanged(#Phc.#3hc(107351150));
				}
			}
		}

		// Token: 0x0600384B RID: 14411 RVA: 0x0010F530 File Offset: 0x0010D730
		public virtual void #cg(IObjectsSelectionManager #dOb, IReadOnlyCollection<IObjectsSelectionManager> #eOb)
		{
			ObjectSelectionState.#iZb #iZb = new ObjectSelectionState.#iZb();
			#iZb.#a = #dOb;
			this.AnySelected = #iZb.#a.Any;
			bool #f;
			if (this.AnySelected)
			{
				#f = !#eOb.Where(new Func<IObjectsSelectionManager, bool>(#iZb.#Kcc)).Any(new Func<IObjectsSelectionManager, bool>(ObjectSelectionState.<>c.<>9.#Lcc));
			}
			else
			{
				#f = false;
			}
			this.OnlySelected = #f;
			this.SingleSelected = (this.OnlySelected && #iZb.#a.NoOfSelectedObjects == 1);
		}

		// Token: 0x0400179A RID: 6042
		private bool #a;

		// Token: 0x0400179B RID: 6043
		private bool #b;

		// Token: 0x0400179C RID: 6044
		private bool #c;

		// Token: 0x02000691 RID: 1681
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06003851 RID: 14417 RVA: 0x00030FCD File Offset: 0x0002F1CD
			internal bool #Kcc(IObjectsSelectionManager #Rf)
			{
				return #Rf != this.#a;
			}

			// Token: 0x0400179F RID: 6047
			public IObjectsSelectionManager #a;
		}
	}
}
