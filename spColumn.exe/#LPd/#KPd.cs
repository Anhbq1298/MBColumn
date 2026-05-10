using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace #LPd
{
	// Token: 0x02000DF3 RID: 3571
	internal sealed class #KPd
	{
		// Token: 0x060080DD RID: 32989 RVA: 0x00068F56 File Offset: 0x00067156
		public #KPd()
		{
			this.#a = new DispatcherTimer(TimeSpan.FromSeconds(1.0), DispatcherPriority.Normal, new EventHandler(this.#FA), Application.Current.Dispatcher);
			this.IsEnabled = true;
		}

		// Token: 0x140001AA RID: 426
		// (add) Token: 0x060080DE RID: 32990 RVA: 0x001C14E4 File Offset: 0x001BF6E4
		// (remove) Token: 0x060080DF RID: 32991 RVA: 0x001C152C File Offset: 0x001BF72C
		public event EventHandler ReportSourceBecameInvalid
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#d;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)\u008D.\u0097\u0002(eventHandler2, value);
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
					EventHandler value2 = (EventHandler)\u008D.\u0098\u0002(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140001AB RID: 427
		// (add) Token: 0x060080E0 RID: 32992 RVA: 0x001C1574 File Offset: 0x001BF774
		// (remove) Token: 0x060080E1 RID: 32993 RVA: 0x001C15B8 File Offset: 0x001BF7B8
		public event EventHandler<#OPd> ReportAvailabilityChecked
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#OPd> eventHandler = this.#e;
				EventHandler<#OPd> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#OPd> value2 = (EventHandler<#OPd>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#OPd>>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#OPd> eventHandler = this.#e;
				EventHandler<#OPd> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#OPd> value2 = (EventHandler<#OPd>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#OPd>>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17002676 RID: 9846
		// (get) Token: 0x060080E2 RID: 32994 RVA: 0x00068F96 File Offset: 0x00067196
		// (set) Token: 0x060080E3 RID: 32995 RVA: 0x00068FA2 File Offset: 0x000671A2
		public bool IsEnabled { get; set; }

		// Token: 0x060080E4 RID: 32996 RVA: 0x00068FB3 File Offset: 0x000671B3
		public IDisposable #AA()
		{
			return new #KPd.#AXb(this);
		}

		// Token: 0x060080E5 RID: 32997 RVA: 0x001C15FC File Offset: 0x001BF7FC
		public void #IPd(int #JPd)
		{
			if (#JPd == 0)
			{
				return;
			}
			if (this.#b == null)
			{
				this.#b = (#KPd.#uWd)\u008D\u0006.\u008E\u0010(new IntPtr(#JPd), \u001E.\u000F\u0002(typeof(#KPd.#uWd).TypeHandle));
				\u0007.~\u0087(this.#a);
			}
		}

		// Token: 0x060080E6 RID: 32998 RVA: 0x001C165C File Offset: 0x001BF85C
		public void #BA(TimeSpan #CA)
		{
			this.#c = new DateTime?(\u0008.\u008D().Add(#CA));
		}

		// Token: 0x060080E7 RID: 32999 RVA: 0x001C1694 File Offset: 0x001BF894
		protected void #IA()
		{
			EventHandler eventHandler = this.#d;
			if (eventHandler != null)
			{
				\u001C\u0005.~\u0010\u000F(eventHandler, this, EventArgs.Empty);
			}
		}

		// Token: 0x060080E8 RID: 33000 RVA: 0x001C16C8 File Offset: 0x001BF8C8
		protected void #JA(#OPd #He)
		{
			EventHandler<#OPd> eventHandler = this.#e;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060080E9 RID: 33001 RVA: 0x001C16F4 File Offset: 0x001BF8F4
		private void #FA(object #GA, EventArgs #HA)
		{
			if (!this.IsEnabled)
			{
				return;
			}
			DateTime? dateTime = this.#c;
			if (dateTime != null && \u008E\u0006.\u008F\u0010(\u0008.\u008D(), dateTime.Value))
			{
				return;
			}
			#KPd.#uWd #uWd = this.#b;
			if (#uWd != null)
			{
				bool flag = #uWd() != 0;
				if (!flag)
				{
					this.#IA();
				}
				this.#JA(new #OPd(flag));
			}
		}

		// Token: 0x040034DA RID: 13530
		private readonly DispatcherTimer #a;

		// Token: 0x040034DB RID: 13531
		private #KPd.#uWd #b;

		// Token: 0x040034DC RID: 13532
		private DateTime? #c;

		// Token: 0x040034DD RID: 13533
		[CompilerGenerated]
		private EventHandler #d;

		// Token: 0x040034DE RID: 13534
		[CompilerGenerated]
		private EventHandler<#OPd> #e;

		// Token: 0x040034DF RID: 13535
		[CompilerGenerated]
		private bool #f;

		// Token: 0x02000DF4 RID: 3572
		// (Invoke) Token: 0x060080EB RID: 33003
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		[return: MarshalAs(UnmanagedType.I2)]
		private delegate short #uWd();

		// Token: 0x02000DF5 RID: 3573
		private sealed class #AXb : IDisposable
		{
			// Token: 0x060080EE RID: 33006 RVA: 0x00068FC3 File Offset: 0x000671C3
			public #AXb(#KPd #BXb)
			{
				this.#a = #BXb;
				this.#a.IsEnabled = false;
			}

			// Token: 0x060080EF RID: 33007 RVA: 0x00068FDE File Offset: 0x000671DE
			public void #1()
			{
				this.#a.IsEnabled = true;
			}

			// Token: 0x040034E0 RID: 13536
			private readonly #KPd #a;
		}
	}
}
