using System;
using System.Runtime.CompilerServices;
using System.Threading;
using #8Cc;
using #eU;
using #gCc;

namespace #qJ
{
	// Token: 0x02000299 RID: 665
	internal sealed class #CJ : #zJ
	{
		// Token: 0x060015BD RID: 5565 RVA: 0x000B325C File Offset: 0x000B145C
		public #CJ(#bDc #DJ, #oW #Yc, #qW #1c)
		{
			this.#a = #DJ;
			this.#b = #Yc;
			this.#c = #1c;
			this.#a.UndoStackChanged += this.#1g;
			this.#a.CompositeActionCompleted += this.#Lh;
		}

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x060015BE RID: 5566 RVA: 0x000B32BC File Offset: 0x000B14BC
		// (remove) Token: 0x060015BF RID: 5567 RVA: 0x000B3300 File Offset: 0x000B1500
		public event EventHandler StateChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#h;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#h, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#h;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#h, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x060015C0 RID: 5568 RVA: 0x00016BF4 File Offset: 0x00014DF4
		// (set) Token: 0x060015C1 RID: 5569 RVA: 0x00016C00 File Offset: 0x00014E00
		public bool IsEnabled { get; private set; }

		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x060015C2 RID: 5570 RVA: 0x00016C11 File Offset: 0x00014E11
		// (set) Token: 0x060015C3 RID: 5571 RVA: 0x00016C1D File Offset: 0x00014E1D
		public #tJ State
		{
			get
			{
				return this.#d;
			}
			private set
			{
				if (this.#d != value)
				{
					this.#d = value;
					if (value == #tJ.#c)
					{
						this.#c.#DQ();
					}
					this.#BJ();
				}
			}
		}

		// Token: 0x060015C4 RID: 5572 RVA: 0x00016C50 File Offset: 0x00014E50
		public IDisposable #AA()
		{
			return new #CJ.#3Zb(this);
		}

		// Token: 0x060015C5 RID: 5573 RVA: 0x000B3344 File Offset: 0x000B1544
		public void #xJ()
		{
			this.#g = this.#b.LoadedFilePath;
			this.#e = new int?(this.#a.UndoActions.Count);
			this.#f = new int?(this.#a.RedoActions.Count);
			this.State = #tJ.#b;
		}

		// Token: 0x060015C6 RID: 5574 RVA: 0x00016C60 File Offset: 0x00014E60
		public void #yJ()
		{
			this.#e = null;
			this.#f = null;
			this.#g = null;
			this.State = #tJ.#a;
		}

		// Token: 0x060015C7 RID: 5575 RVA: 0x00016C94 File Offset: 0x00014E94
		protected void #BJ()
		{
			EventHandler eventHandler = this.#h;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x060015C8 RID: 5576 RVA: 0x000B33AC File Offset: 0x000B15AC
		public void #KA()
		{
			bool flag;
			if (!(this.#g != this.#b.LoadedFilePath))
			{
				int? num = this.#e;
				int num2 = this.#a.UndoActions.Count;
				if (num.GetValueOrDefault() == num2 & num != null)
				{
					num = this.#f;
					num2 = this.#a.RedoActions.Count;
					flag = !(num.GetValueOrDefault() == num2 & num != null);
					goto IL_7C;
				}
			}
			flag = true;
			IL_7C:
			if (!flag)
			{
				return;
			}
			if (this.State == #tJ.#b || this.#c.DesignEngine != null)
			{
				this.State = #tJ.#c;
				this.#c.#DQ();
			}
		}

		// Token: 0x060015C9 RID: 5577 RVA: 0x00016CB8 File Offset: 0x00014EB8
		private void #Lh(object #Ge, EventArgs #He)
		{
			if (this.IsEnabled)
			{
				this.#KA();
			}
		}

		// Token: 0x060015CA RID: 5578 RVA: 0x00016CB8 File Offset: 0x00014EB8
		private void #1g(object #Ge, #JCc #He)
		{
			if (this.IsEnabled)
			{
				this.#KA();
			}
		}

		// Token: 0x040008AD RID: 2221
		private readonly #bDc #a;

		// Token: 0x040008AE RID: 2222
		private readonly #oW #b;

		// Token: 0x040008AF RID: 2223
		private readonly #qW #c;

		// Token: 0x040008B0 RID: 2224
		private #tJ #d;

		// Token: 0x040008B1 RID: 2225
		private int? #e;

		// Token: 0x040008B2 RID: 2226
		private int? #f;

		// Token: 0x040008B3 RID: 2227
		private string #g;

		// Token: 0x040008B4 RID: 2228
		[CompilerGenerated]
		private EventHandler #h;

		// Token: 0x040008B5 RID: 2229
		[CompilerGenerated]
		private bool #i = true;

		// Token: 0x0200029A RID: 666
		private sealed class #3Zb : IDisposable
		{
			// Token: 0x060015CB RID: 5579 RVA: 0x00016CD4 File Offset: 0x00014ED4
			public #3Zb(#CJ #BXb)
			{
				this.#a = #BXb;
				#BXb.IsEnabled = false;
			}

			// Token: 0x060015CC RID: 5580 RVA: 0x00016CEA File Offset: 0x00014EEA
			public void #1()
			{
				this.#a.IsEnabled = true;
			}

			// Token: 0x040008B6 RID: 2230
			private readonly #CJ #a;
		}
	}
}
