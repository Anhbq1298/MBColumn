using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #N6c;
using #o1d;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Editor.Core.Selection;

namespace #gOb
{
	// Token: 0x02000694 RID: 1684
	[DebuggerDisplay("{GetDesription()}")]
	internal class #QOb<#Fu> : NotifyPropertyChangedObjectBase, IDisposable, IObjectsSelectionManager
	{
		// Token: 0x140000D3 RID: 211
		// (add) Token: 0x0600385E RID: 14430 RVA: 0x0010F5E4 File Offset: 0x0010D7E4
		// (remove) Token: 0x0600385F RID: 14431 RVA: 0x0010F628 File Offset: 0x0010D828
		public event EventHandler SelectionAdded
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#d;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#d;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140000D4 RID: 212
		// (add) Token: 0x06003860 RID: 14432 RVA: 0x0010F66C File Offset: 0x0010D86C
		// (remove) Token: 0x06003861 RID: 14433 RVA: 0x0010F6B0 File Offset: 0x0010D8B0
		public event EventHandler ObjectsSelectionCleared
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#e;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#e;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17001167 RID: 4455
		// (get) Token: 0x06003862 RID: 14434 RVA: 0x00031041 File Offset: 0x0002F241
		public #47c<#Fu> SelectedObjects
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17001168 RID: 4456
		// (get) Token: 0x06003863 RID: 14435 RVA: 0x0003104D File Offset: 0x0002F24D
		public #37c<#Fu> LastSelectedObjects
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x17001169 RID: 4457
		// (get) Token: 0x06003864 RID: 14436 RVA: 0x00031059 File Offset: 0x0002F259
		// (set) Token: 0x06003865 RID: 14437 RVA: 0x00031065 File Offset: 0x0002F265
		public int NoOfSelectedObjects
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<int>(ref this.#c, value, #Phc.#3hc(107351161));
			}
		}

		// Token: 0x1700116A RID: 4458
		// (get) Token: 0x06003866 RID: 14438 RVA: 0x0003108B File Offset: 0x0002F28B
		public ISet<#Fu> Hovered { get; }

		// Token: 0x1700116B RID: 4459
		// (get) Token: 0x06003867 RID: 14439 RVA: 0x00031097 File Offset: 0x0002F297
		public bool Empty
		{
			get
			{
				return this.#a.Count <= 0;
			}
		}

		// Token: 0x1700116C RID: 4460
		// (get) Token: 0x06003868 RID: 14440 RVA: 0x000310B2 File Offset: 0x0002F2B2
		public bool Any
		{
			get
			{
				return this.#a.Count > 0;
			}
		}

		// Token: 0x06003869 RID: 14441 RVA: 0x000310CA File Offset: 0x0002F2CA
		public void #sOb()
		{
			this.#uOb();
			this.#tOb();
		}

		// Token: 0x0600386A RID: 14442 RVA: 0x000310E4 File Offset: 0x0002F2E4
		public void #tOb()
		{
			this.Hovered.Clear();
			this.#NOb();
		}

		// Token: 0x0600386B RID: 14443 RVA: 0x00031103 File Offset: 0x0002F303
		public void #uOb()
		{
			this.#a.#yl();
			this.#NOb();
			EventHandler eventHandler = this.#e;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, new EventArgs());
		}

		// Token: 0x0600386C RID: 14444 RVA: 0x0010F6F4 File Offset: 0x0010D8F4
		public void #EOb(IEnumerable<#Fu> #8f)
		{
			foreach (#Fu #GOb in #8f)
			{
				this.#EOb(#GOb);
			}
			this.#NOb();
		}

		// Token: 0x0600386D RID: 14445 RVA: 0x00031138 File Offset: 0x0002F338
		public void #kCb(IEnumerable<#Fu> #FOb)
		{
			this.#a.#yl();
			this.#NOb();
			this.#HOb(#FOb);
		}

		// Token: 0x0600386E RID: 14446 RVA: 0x0003115E File Offset: 0x0002F35E
		public void #EOb(#Fu #GOb)
		{
			if (#GOb == null)
			{
				return;
			}
			this.#a.#F7c(#GOb);
			this.#NOb();
		}

		// Token: 0x0600386F RID: 14447 RVA: 0x00031188 File Offset: 0x0002F388
		public void #HOb(#Fu #GOb)
		{
			if (#GOb == null)
			{
				return;
			}
			this.#a.#F7c(#GOb);
			this.#a.Add(#GOb);
			this.#NOb();
			this.#MOb();
		}

		// Token: 0x06003870 RID: 14448 RVA: 0x0010F750 File Offset: 0x0010D950
		public void #HOb(IEnumerable<#Fu> #FOb)
		{
			List<#Fu> list = #FOb.ToList<#Fu>();
			this.#a.#pR(list);
			if (list.Any<#Fu>())
			{
				this.#HOb(list.First<#Fu>());
			}
			this.#NOb();
			this.#MOb();
		}

		// Token: 0x06003871 RID: 14449 RVA: 0x000311C5 File Offset: 0x0002F3C5
		public #Fu #IOb()
		{
			return this.#a.LastOrDefault<#Fu>();
		}

		// Token: 0x06003872 RID: 14450 RVA: 0x0010F79C File Offset: 0x0010D99C
		public void #JOb(List<#Fu> #KOb)
		{
			using (List<#Fu>.Enumerator enumerator = #KOb.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					#QOb<#Fu>.#AZb #AZb = new #QOb<!0>.#AZb();
					#AZb.#a = enumerator.Current;
					#Fu #Fu = this.SelectedObjects.FirstOrDefault(new Func<!0, bool>(#AZb.#Mcc));
					if (#Fu != null)
					{
						this.#EOb(#Fu);
					}
					else
					{
						this.#HOb(#AZb.#a);
					}
				}
			}
			this.#NOb();
		}

		// Token: 0x06003873 RID: 14451 RVA: 0x0010F844 File Offset: 0x0010DA44
		public void #EDb(bool #vOb, bool #wOb)
		{
			if (#vOb)
			{
				using (IEnumerator<#Fu> enumerator = this.Hovered.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						#QOb<#Fu>.#jac #jac = new #QOb<!0>.#jac();
						#jac.#a = enumerator.Current;
						if (this.SelectedObjects.Any(new Func<!0, bool>(#jac.#Ncc)) && #wOb)
						{
							this.#EOb(#jac.#a);
						}
						else
						{
							this.#HOb(#jac.#a);
						}
					}
					goto IL_99;
				}
			}
			if (!this.Hovered.SetEquals(this.SelectedObjects))
			{
				this.#uOb();
				this.#HOb(this.Hovered);
			}
			IL_99:
			this.#NOb();
		}

		// Token: 0x06003874 RID: 14452 RVA: 0x000311DA File Offset: 0x0002F3DA
		public void #LOb(IEnumerable<#Fu> #8f)
		{
			this.Hovered.#pR(#8f);
			this.#NOb();
		}

		// Token: 0x06003875 RID: 14453 RVA: 0x000311FA File Offset: 0x0002F3FA
		protected virtual void #MOb()
		{
			EventHandler eventHandler = this.#d;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06003876 RID: 14454 RVA: 0x0003121E File Offset: 0x0002F41E
		protected virtual void #NOb()
		{
			this.NoOfSelectedObjects = this.#a.Count;
		}

		// Token: 0x06003877 RID: 14455 RVA: 0x0003123D File Offset: 0x0002F43D
		internal string #OOb()
		{
			return string.Format(#Phc.#3hc(107351132), this.SelectedObjects.Count, this.Hovered.Count);
		}

		// Token: 0x06003878 RID: 14456 RVA: 0x0003127A File Offset: 0x0002F47A
		protected virtual void #1(bool #POb)
		{
			if (#POb)
			{
				this.#e = null;
				this.#d = null;
			}
		}

		// Token: 0x06003879 RID: 14457 RVA: 0x00031299 File Offset: 0x0002F499
		public void #1()
		{
			this.#1(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x040017A2 RID: 6050
		private readonly #f8c<#Fu> #a = new #f8c<!0>();

		// Token: 0x040017A3 RID: 6051
		private readonly #f8c<#Fu> #b = new #f8c<!0>();

		// Token: 0x040017A4 RID: 6052
		private int #c;

		// Token: 0x040017A5 RID: 6053
		[CompilerGenerated]
		private EventHandler #d;

		// Token: 0x040017A6 RID: 6054
		[CompilerGenerated]
		private EventHandler #e;

		// Token: 0x040017A7 RID: 6055
		[CompilerGenerated]
		private readonly ISet<#Fu> #f = new HashSet<!0>();

		// Token: 0x02000695 RID: 1685
		[CompilerGenerated]
		private sealed class #AZb
		{
			// Token: 0x0600387C RID: 14460 RVA: 0x000312DD File Offset: 0x0002F4DD
			internal bool #Mcc(#Fu #Rf)
			{
				return #Rf.Equals(this.#a);
			}

			// Token: 0x040017A8 RID: 6056
			public #Fu #a;
		}

		// Token: 0x02000696 RID: 1686
		[CompilerGenerated]
		private sealed class #jac
		{
			// Token: 0x0600387E RID: 14462 RVA: 0x000312FB File Offset: 0x0002F4FB
			internal bool #Ncc(#Fu #Rf)
			{
				return #Rf.Equals(this.#a);
			}

			// Token: 0x040017A9 RID: 6057
			public #Fu #a;
		}
	}
}
