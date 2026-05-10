using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using #5Ve;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;

namespace #g7e
{
	// Token: 0x0200138B RID: 5003
	internal sealed class #nW
	{
		// Token: 0x140001B9 RID: 441
		// (add) Token: 0x0600A768 RID: 42856 RVA: 0x00232A4C File Offset: 0x00230C4C
		// (remove) Token: 0x0600A769 RID: 42857 RVA: 0x00232A84 File Offset: 0x00230C84
		public event EventHandler<CancelEventArgs> SolveProcessStarted
		{
			[CompilerGenerated]
			add
			{
				EventHandler<CancelEventArgs> eventHandler = this.#a;
				EventHandler<CancelEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<CancelEventArgs> value2 = (EventHandler<CancelEventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<CancelEventArgs>>(ref this.#a, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<CancelEventArgs> eventHandler = this.#a;
				EventHandler<CancelEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<CancelEventArgs> value2 = (EventHandler<CancelEventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<CancelEventArgs>>(ref this.#a, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140001BA RID: 442
		// (add) Token: 0x0600A76A RID: 42858 RVA: 0x00232ABC File Offset: 0x00230CBC
		// (remove) Token: 0x0600A76B RID: 42859 RVA: 0x00232AF4 File Offset: 0x00230CF4
		public event EventHandler<#q7e> ProgressChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#q7e> eventHandler = this.#b;
				EventHandler<#q7e> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#q7e> value2 = (EventHandler<#q7e>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#q7e>>(ref this.#b, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#q7e> eventHandler = this.#b;
				EventHandler<#q7e> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#q7e> value2 = (EventHandler<#q7e>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#q7e>>(ref this.#b, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140001BB RID: 443
		// (add) Token: 0x0600A76C RID: 42860 RVA: 0x00232B2C File Offset: 0x00230D2C
		// (remove) Token: 0x0600A76D RID: 42861 RVA: 0x00232B64 File Offset: 0x00230D64
		public event EventHandler<#w7e> DialogRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#w7e> eventHandler = this.#c;
				EventHandler<#w7e> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#w7e> value2 = (EventHandler<#w7e>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#w7e>>(ref this.#c, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#w7e> eventHandler = this.#c;
				EventHandler<#w7e> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#w7e> value2 = (EventHandler<#w7e>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#w7e>>(ref this.#c, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140001BC RID: 444
		// (add) Token: 0x0600A76E RID: 42862 RVA: 0x00232B9C File Offset: 0x00230D9C
		// (remove) Token: 0x0600A76F RID: 42863 RVA: 0x00232BD4 File Offset: 0x00230DD4
		public event EventHandler<#k7e> NotificationOccurred
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#k7e> eventHandler = this.#d;
				EventHandler<#k7e> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#k7e> value2 = (EventHandler<#k7e>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#k7e>>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#k7e> eventHandler = this.#d;
				EventHandler<#k7e> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#k7e> value2 = (EventHandler<#k7e>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#k7e>>(ref this.#d, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x140001BD RID: 445
		// (add) Token: 0x0600A770 RID: 42864 RVA: 0x00232C0C File Offset: 0x00230E0C
		// (remove) Token: 0x0600A771 RID: 42865 RVA: 0x00232C44 File Offset: 0x00230E44
		public event EventHandler<#l7e> DesignTrace
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#l7e> eventHandler = this.#e;
				EventHandler<#l7e> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#l7e> value2 = (EventHandler<#l7e>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#l7e>>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#l7e> eventHandler = this.#e;
				EventHandler<#l7e> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#l7e> value2 = (EventHandler<#l7e>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#l7e>>(ref this.#e, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1700308F RID: 12431
		// (get) Token: 0x0600A772 RID: 42866 RVA: 0x00082222 File Offset: 0x00080422
		internal #kbi DebugContext { get; } = new #kbi();

		// Token: 0x0600A773 RID: 42867 RVA: 0x00232C7C File Offset: 0x00230E7C
		internal bool #66e()
		{
			if (this.#a != null)
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs();
				this.#a(this, cancelEventArgs);
				return !cancelEventArgs.Cancel;
			}
			return true;
		}

		// Token: 0x0600A774 RID: 42868 RVA: 0x0008222A File Offset: 0x0008042A
		internal void #76e(#q7e #Lg)
		{
			EventHandler<#q7e> eventHandler = this.#b;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #Lg);
		}

		// Token: 0x0600A775 RID: 42869 RVA: 0x0008223E File Offset: 0x0008043E
		internal void #76e(#q7e.#Mif #86e, int #96e, int #a7e)
		{
			this.#76e(new #q7e(#86e, #96e, #a7e));
		}

		// Token: 0x0600A776 RID: 42870 RVA: 0x0008224E File Offset: 0x0008044E
		internal void #76e(#q7e.#Mif #vp)
		{
			this.#76e(new #q7e(#vp));
		}

		// Token: 0x0600A777 RID: 42871 RVA: 0x00232CB0 File Offset: 0x00230EB0
		internal void #rne(Message #5, object[] #Pc = null)
		{
			if (this.#d != null)
			{
				#k7e e = new #k7e(#5, #Pc);
				this.#d(this, e);
			}
		}

		// Token: 0x0600A778 RID: 42872 RVA: 0x0008225C File Offset: 0x0008045C
		internal bool #b7e()
		{
			return this.#f7e(#w7e.#Nif.#b);
		}

		// Token: 0x0600A779 RID: 42873 RVA: 0x00082265 File Offset: 0x00080465
		internal bool #c7e()
		{
			return this.#f7e(#w7e.#Nif.#c);
		}

		// Token: 0x0600A77A RID: 42874 RVA: 0x0008226E File Offset: 0x0008046E
		internal bool #d7e()
		{
			return this.#f7e(#w7e.#Nif.#a);
		}

		// Token: 0x0600A77B RID: 42875 RVA: 0x00082277 File Offset: 0x00080477
		internal void #e7e(#4Ve #Gfb)
		{
			EventHandler<#l7e> eventHandler = this.#e;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, new #l7e(#Gfb));
		}

		// Token: 0x0600A77C RID: 42876 RVA: 0x00232CDC File Offset: 0x00230EDC
		private bool #f7e(#w7e.#Nif #sp)
		{
			if (this.#c != null)
			{
				#w7e #w7e = new #w7e(#sp);
				this.#c(this, #w7e);
				return #w7e.Response;
			}
			return false;
		}

		// Token: 0x04004A20 RID: 18976
		[CompilerGenerated]
		private EventHandler<CancelEventArgs> #a;

		// Token: 0x04004A21 RID: 18977
		[CompilerGenerated]
		private EventHandler<#q7e> #b;

		// Token: 0x04004A22 RID: 18978
		[CompilerGenerated]
		private EventHandler<#w7e> #c;

		// Token: 0x04004A23 RID: 18979
		[CompilerGenerated]
		private EventHandler<#k7e> #d;

		// Token: 0x04004A24 RID: 18980
		[CompilerGenerated]
		private EventHandler<#l7e> #e;

		// Token: 0x04004A25 RID: 18981
		[CompilerGenerated]
		private readonly #kbi #f;
	}
}
