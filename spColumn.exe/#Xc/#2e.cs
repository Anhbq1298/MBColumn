using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using #7hc;
using #hg;
using #lH;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;

namespace #Xc
{
	// Token: 0x020000BF RID: 191
	internal sealed class #2e : #HH<IViewportOverlayView>, IViewModel<IViewportOverlayView>, INotifyPropertyChanged, IViewModel, #ig
	{
		// Token: 0x060005E3 RID: 1507 RVA: 0x0000A556 File Offset: 0x00008756
		public #2e(Lazy<IViewportOverlayView> #Ee, ICoreServices #0c) : base(#Ee, #0c)
		{
			this.#f = new DelegateCommand(new Action<object>(this.#1e), new Predicate<object>(this.#0e));
		}

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060005E4 RID: 1508 RVA: 0x0008B32C File Offset: 0x0008952C
		// (remove) Token: 0x060005E5 RID: 1509 RVA: 0x0008B370 File Offset: 0x00089570
		public event EventHandler CommandExecuted
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

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x0000A58A File Offset: 0x0000878A
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0000A59A File Offset: 0x0000879A
		// (set) Token: 0x060005E8 RID: 1512 RVA: 0x0000A5A6 File Offset: 0x000087A6
		public Visibility ButtonVisibility
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107384057));
				}
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x060005E9 RID: 1513 RVA: 0x0000A5D4 File Offset: 0x000087D4
		// (set) Token: 0x060005EA RID: 1514 RVA: 0x0000A5E0 File Offset: 0x000087E0
		public Visibility Visibility
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
					base.RaisePropertyChanged(#Phc.#3hc(107384000));
				}
			}
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x0000A60E File Offset: 0x0000880E
		// (set) Token: 0x060005EC RID: 1516 RVA: 0x0000A61A File Offset: 0x0000881A
		public string Message
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
					base.RaisePropertyChanged(#Phc.#3hc(107383983));
				}
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x0000A64D File Offset: 0x0000884D
		// (set) Token: 0x060005EE RID: 1518 RVA: 0x0000A659 File Offset: 0x00008859
		public string ButtonText
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
					base.RaisePropertyChanged(#Phc.#3hc(107383970));
				}
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x0000A68C File Offset: 0x0000888C
		public DelegateCommand ButtonCommand { get; }

		// Token: 0x060005F0 RID: 1520 RVA: 0x0000A698 File Offset: 0x00008898
		protected void #Ze()
		{
			EventHandler eventHandler = this.#e;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x00003375 File Offset: 0x00001575
		private bool #0e(object #Sb)
		{
			return true;
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0000A6BC File Offset: 0x000088BC
		private void #1e(object #Sb)
		{
			this.#Ze();
		}

		// Token: 0x0400014F RID: 335
		private Visibility #a = Visibility.Collapsed;

		// Token: 0x04000150 RID: 336
		private string #b;

		// Token: 0x04000151 RID: 337
		private Visibility #c;

		// Token: 0x04000152 RID: 338
		private string #d;

		// Token: 0x04000153 RID: 339
		[CompilerGenerated]
		private EventHandler #e;

		// Token: 0x04000154 RID: 340
		[CompilerGenerated]
		private readonly DelegateCommand #f;
	}
}
