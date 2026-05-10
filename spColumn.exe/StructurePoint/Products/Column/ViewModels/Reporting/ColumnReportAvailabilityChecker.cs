using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using #8Cc;
using #eU;
using #kB;
using #LPd;

namespace StructurePoint.Products.Column.ViewModels.Reporting
{
	// Token: 0x020001CD RID: 461
	internal sealed class ColumnReportAvailabilityChecker : #jB
	{
		// Token: 0x06001029 RID: 4137 RVA: 0x000A5FD8 File Offset: 0x000A41D8
		public ColumnReportAvailabilityChecker(#bDc undoManager, #oW projectContext, #qW designEngineService)
		{
			this.#a = undoManager;
			this.#b = projectContext;
			this.#c = designEngineService;
			if (Application.Current != null)
			{
				this.#d = new DispatcherTimer(DispatcherPriority.Normal, Application.Current.Dispatcher ?? Dispatcher.CurrentDispatcher);
				this.#d.Interval = TimeSpan.FromSeconds(1.0);
				this.#d.Tick += this.#FA;
			}
		}

		// Token: 0x14000030 RID: 48
		// (add) Token: 0x0600102A RID: 4138 RVA: 0x000A6064 File Offset: 0x000A4264
		// (remove) Token: 0x0600102B RID: 4139 RVA: 0x000A60A8 File Offset: 0x000A42A8
		public event EventHandler ReportSourceBecameInvalid
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#l;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#l, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#l;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#l, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x0600102C RID: 4140 RVA: 0x000A60EC File Offset: 0x000A42EC
		// (remove) Token: 0x0600102D RID: 4141 RVA: 0x000A6130 File Offset: 0x000A4330
		public event EventHandler<#OPd> ReportAvailabilityChecked
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#OPd> eventHandler = this.#m;
				EventHandler<#OPd> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#OPd> value2 = (EventHandler<#OPd>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#OPd>>(ref this.#m, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#OPd> eventHandler = this.#m;
				EventHandler<#OPd> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#OPd> value2 = (EventHandler<#OPd>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#OPd>>(ref this.#m, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x0600102E RID: 4142 RVA: 0x00012819 File Offset: 0x00010A19
		// (set) Token: 0x0600102F RID: 4143 RVA: 0x000A6174 File Offset: 0x000A4374
		public bool IsEnabled
		{
			get
			{
				return this.#i && (this.#k == null || this.#k.IsEnabled);
			}
			set
			{
				if (this.#i != value)
				{
					this.#i = value;
					if (value)
					{
						if (this.#d != null && !this.#d.IsEnabled)
						{
							this.#d.Start();
							return;
						}
					}
					else
					{
						DispatcherTimer dispatcherTimer = this.#d;
						if (dispatcherTimer == null)
						{
							return;
						}
						dispatcherTimer.Stop();
					}
				}
			}
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x06001030 RID: 4144 RVA: 0x00012846 File Offset: 0x00010A46
		// (set) Token: 0x06001031 RID: 4145 RVA: 0x00012852 File Offset: 0x00010A52
		public bool IsAvailable { get; private set; }

		// Token: 0x06001032 RID: 4146 RVA: 0x00012863 File Offset: 0x00010A63
		public IDisposable #AA()
		{
			return new ColumnReportAvailabilityChecker.#AXb(this);
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x000A61D4 File Offset: 0x000A43D4
		public void #BA(TimeSpan #CA)
		{
			this.#e = new DateTime?(DateTime.Now.Add(#CA));
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x000A6208 File Offset: 0x000A4408
		public void #DA()
		{
			this.#g = this.#b.LoadedFilePath;
			this.#f = new int?(this.#a.UndoActions.Count);
			this.#h = new int?(this.#a.RedoActions.Count);
			this.#j.ForEach(new Action<ColumnReportAvailabilityChecker>(ColumnReportAvailabilityChecker.<>c.<>9.#xXh));
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x000A6294 File Offset: 0x000A4494
		public #jB #EA()
		{
			ColumnReportAvailabilityChecker columnReportAvailabilityChecker = new ColumnReportAvailabilityChecker(this.#a, this.#b, this.#c)
			{
				#k = this
			};
			this.#j.Add(columnReportAvailabilityChecker);
			return columnReportAvailabilityChecker;
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x00012873 File Offset: 0x00010A73
		public void #1()
		{
			DispatcherTimer dispatcherTimer = this.#d;
			if (dispatcherTimer == null)
			{
				return;
			}
			dispatcherTimer.Stop();
		}

		// Token: 0x06001037 RID: 4151 RVA: 0x000A62DC File Offset: 0x000A44DC
		private void #FA(object #GA, EventArgs #HA)
		{
			if (!this.IsEnabled)
			{
				return;
			}
			DateTime? dateTime = this.#e;
			if (dateTime != null && DateTime.Now < dateTime.Value)
			{
				return;
			}
			bool flag = this.#KA();
			this.IsAvailable = flag;
			if (!this.IsEnabled)
			{
				return;
			}
			if (!flag)
			{
				this.#IA();
			}
			this.#JA(new #OPd(flag));
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x000A6350 File Offset: 0x000A4550
		private void #IA()
		{
			EventHandler eventHandler = this.#l;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
			}
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x000A6380 File Offset: 0x000A4580
		private void #JA(#OPd #He)
		{
			EventHandler<#OPd> eventHandler = this.#m;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x000A63AC File Offset: 0x000A45AC
		private bool #KA()
		{
			if (string.Equals(this.#g, this.#b.LoadedFilePath))
			{
				int? num = this.#f;
				int num2 = this.#a.UndoActions.Count;
				if (num.GetValueOrDefault() == num2 & num != null)
				{
					num = this.#h;
					num2 = this.#a.RedoActions.Count;
					if (num.GetValueOrDefault() == num2 & num != null)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0400064F RID: 1615
		private readonly #bDc #a;

		// Token: 0x04000650 RID: 1616
		private readonly #oW #b;

		// Token: 0x04000651 RID: 1617
		private readonly #qW #c;

		// Token: 0x04000652 RID: 1618
		private readonly DispatcherTimer #d;

		// Token: 0x04000653 RID: 1619
		private DateTime? #e;

		// Token: 0x04000654 RID: 1620
		private int? #f;

		// Token: 0x04000655 RID: 1621
		private string #g;

		// Token: 0x04000656 RID: 1622
		private int? #h;

		// Token: 0x04000657 RID: 1623
		private bool #i;

		// Token: 0x04000658 RID: 1624
		private readonly List<ColumnReportAvailabilityChecker> #j = new List<ColumnReportAvailabilityChecker>();

		// Token: 0x04000659 RID: 1625
		private ColumnReportAvailabilityChecker #k;

		// Token: 0x0400065A RID: 1626
		[CompilerGenerated]
		private EventHandler #l;

		// Token: 0x0400065B RID: 1627
		[CompilerGenerated]
		private EventHandler<#OPd> #m;

		// Token: 0x0400065C RID: 1628
		[CompilerGenerated]
		private bool #n;

		// Token: 0x020001CE RID: 462
		private sealed class #AXb : IDisposable
		{
			// Token: 0x0600103B RID: 4155 RVA: 0x0001288D File Offset: 0x00010A8D
			public #AXb(ColumnReportAvailabilityChecker #BXb)
			{
				this.#a = #BXb;
				this.#a.IsEnabled = false;
			}

			// Token: 0x0600103C RID: 4156 RVA: 0x000128A8 File Offset: 0x00010AA8
			public void #1()
			{
				this.#a.IsEnabled = true;
			}

			// Token: 0x0400065D RID: 1629
			private readonly ColumnReportAvailabilityChecker #a;
		}
	}
}
