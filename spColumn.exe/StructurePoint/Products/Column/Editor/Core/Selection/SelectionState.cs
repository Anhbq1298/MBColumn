using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #gOb;
using #pXd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.Products.Column.Editor.Core.Selection
{
	// Token: 0x0200069E RID: 1694
	internal sealed class SelectionState : NotifyPropertyChangedObjectBase, IDisposable
	{
		// Token: 0x060038BD RID: 14525 RVA: 0x00110464 File Offset: 0x0010E664
		public SelectionState(SelectionManager selection)
		{
			this.#a = selection;
			this.#d = new #fOb(selection);
			this.#i = new #oPb(selection);
		}

		// Token: 0x140000D6 RID: 214
		// (add) Token: 0x060038BE RID: 14526 RVA: 0x001104C8 File Offset: 0x0010E6C8
		// (remove) Token: 0x060038BF RID: 14527 RVA: 0x0011050C File Offset: 0x0010E70C
		public event EventHandler SelectionChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#j;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#j, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#j;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#j, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17001178 RID: 4472
		// (get) Token: 0x060038C0 RID: 14528 RVA: 0x00110550 File Offset: 0x0010E750
		public #fOb Bars
		{
			get
			{
				if (!this.#g)
				{
					this.#g = true;
					this.#c.Add(Observable.FromEventPattern<EventArgs>(this.Bars, this.#f).Select(new Func<EventPattern<EventArgs>, EventArgs>(SelectionState.<>c.<>9.#0cc)).Throttle(this.#e).Subscribe(new Action<EventArgs>(this.#lPb)));
				}
				return this.#d;
			}
		}

		// Token: 0x17001179 RID: 4473
		// (get) Token: 0x060038C1 RID: 14529 RVA: 0x001105E0 File Offset: 0x0010E7E0
		public #oPb Slabs
		{
			get
			{
				if (!this.#h)
				{
					this.#h = true;
					this.#c.Add(Observable.FromEventPattern<EventArgs>(this.Slabs, this.#f).Select(new Func<EventPattern<EventArgs>, EventArgs>(SelectionState.<>c.<>9.#1cc)).Throttle(this.#e).Subscribe(new Action<EventArgs>(this.#mPb)));
				}
				return this.#i;
			}
		}

		// Token: 0x1700117A RID: 4474
		// (get) Token: 0x060038C2 RID: 14530 RVA: 0x00031651 File Offset: 0x0002F851
		// (set) Token: 0x060038C3 RID: 14531 RVA: 0x0003165D File Offset: 0x0002F85D
		public bool AnyObjectSelected
		{
			get
			{
				return this.#b;
			}
			private set
			{
				this.SetProperty<bool>(ref this.#b, value, #Phc.#3hc(107351061));
			}
		}

		// Token: 0x060038C4 RID: 14532 RVA: 0x00110670 File Offset: 0x0010E870
		public void #cg()
		{
			this.Bars.#cg(this.#a.Bars, this.#a.Managers);
			this.Slabs.#cg(this.#a.Shapes, this.#a.Managers);
			this.AnyObjectSelected = this.#a.Managers.Any(new Func<IObjectsSelectionManager, bool>(SelectionState.<>c.<>9.#2cc));
		}

		// Token: 0x060038C5 RID: 14533 RVA: 0x00031683 File Offset: 0x0002F883
		protected void #kPb()
		{
			EventHandler eventHandler = this.#j;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x060038C6 RID: 14534 RVA: 0x0011070C File Offset: 0x0010E90C
		public void #1()
		{
			foreach (IDisposable #EXd in this.#c)
			{
				#EXd.#DXd();
			}
		}

		// Token: 0x060038C7 RID: 14535 RVA: 0x000316A7 File Offset: 0x0002F8A7
		[CompilerGenerated]
		private void #lPb(EventArgs #Hi)
		{
			this.#kPb();
		}

		// Token: 0x060038C8 RID: 14536 RVA: 0x000316A7 File Offset: 0x0002F8A7
		[CompilerGenerated]
		private void #mPb(EventArgs #Hi)
		{
			this.#kPb();
		}

		// Token: 0x040017C4 RID: 6084
		private readonly SelectionManager #a;

		// Token: 0x040017C5 RID: 6085
		private bool #b;

		// Token: 0x040017C6 RID: 6086
		private readonly List<IDisposable> #c = new List<IDisposable>();

		// Token: 0x040017C7 RID: 6087
		private readonly #fOb #d;

		// Token: 0x040017C8 RID: 6088
		private readonly TimeSpan #e = TimeSpan.FromMilliseconds(50.0);

		// Token: 0x040017C9 RID: 6089
		private readonly string #f = #Phc.#3hc(107351050);

		// Token: 0x040017CA RID: 6090
		private bool #g;

		// Token: 0x040017CB RID: 6091
		private bool #h;

		// Token: 0x040017CC RID: 6092
		private readonly #oPb #i;

		// Token: 0x040017CD RID: 6093
		[CompilerGenerated]
		private EventHandler #j;
	}
}
