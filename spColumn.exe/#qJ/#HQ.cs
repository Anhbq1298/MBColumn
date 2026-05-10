using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using #5Ve;
using #7hc;
using #eU;
using #g7e;
using #hZe;
using #P6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Model.Entities;

namespace #qJ
{
	// Token: 0x020002CE RID: 718
	internal sealed class #HQ : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, #qW
	{
		// Token: 0x060018D8 RID: 6360 RVA: 0x00018FB1 File Offset: 0x000171B1
		public #HQ(#oW #Yc, #9V #bP)
		{
			this.#a = #Yc;
			this.#b = #bP;
		}

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x060018D9 RID: 6361 RVA: 0x000B7648 File Offset: 0x000B5848
		// (remove) Token: 0x060018DA RID: 6362 RVA: 0x000B768C File Offset: 0x000B588C
		public event EventHandler<#pW> StartingCalculations
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pW> eventHandler = this.#f;
				EventHandler<#pW> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pW> value2 = (EventHandler<#pW>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pW>>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pW> eventHandler = this.#f;
				EventHandler<#pW> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pW> value2 = (EventHandler<#pW>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pW>>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x060018DB RID: 6363 RVA: 0x000B76D0 File Offset: 0x000B58D0
		// (remove) Token: 0x060018DC RID: 6364 RVA: 0x000B7714 File Offset: 0x000B5914
		public event EventHandler<#pW> FinishedCalculations
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pW> eventHandler = this.#g;
				EventHandler<#pW> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pW> value2 = (EventHandler<#pW>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pW>>(ref this.#g, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pW> eventHandler = this.#g;
				EventHandler<#pW> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pW> value2 = (EventHandler<#pW>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pW>>(ref this.#g, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000935 RID: 2357
		// (get) Token: 0x060018DD RID: 6365 RVA: 0x00018FD2 File Offset: 0x000171D2
		// (set) Token: 0x060018DE RID: 6366 RVA: 0x000B7758 File Offset: 0x000B5958
		public DesignEngine DesignEngine
		{
			get
			{
				return this.#e;
			}
			private set
			{
				if (this.#e != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107401616));
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107401599));
					base.RaisePropertyChanged(#Phc.#3hc(107401616));
				}
			}
		}

		// Token: 0x17000936 RID: 2358
		// (get) Token: 0x060018DF RID: 6367 RVA: 0x00018FDE File Offset: 0x000171DE
		public IList<#4Ve> TraceResults
		{
			get
			{
				return this.#c;
			}
		}

		// Token: 0x17000937 RID: 2359
		// (get) Token: 0x060018E0 RID: 6368 RVA: 0x00018FEA File Offset: 0x000171EA
		// (set) Token: 0x060018E1 RID: 6369 RVA: 0x00018FF6 File Offset: 0x000171F6
		public #4Ve CurrentTraceStep { get; private set; }

		// Token: 0x17000938 RID: 2360
		// (get) Token: 0x060018E2 RID: 6370 RVA: 0x00019007 File Offset: 0x00017207
		// (set) Token: 0x060018E3 RID: 6371 RVA: 0x000B77B4 File Offset: 0x000B59B4
		public int CurrentTraceStepIndex
		{
			get
			{
				return this.#d;
			}
			private set
			{
				value = Math.Min(value, this.#c.Count - 1);
				this.#d = value;
				this.CurrentTraceStep = this.TraceResults.ElementAtOrDefault(value);
				base.RaisePropertyChanged(#Phc.#3hc(107401599));
				base.RaisePropertyChanged(#Phc.#3hc(107401546));
				base.RaisePropertyChanged(#Phc.#3hc(107401517));
			}
		}

		// Token: 0x17000939 RID: 2361
		// (get) Token: 0x060018E4 RID: 6372 RVA: 0x00019013 File Offset: 0x00017213
		// (set) Token: 0x060018E5 RID: 6373 RVA: 0x00019021 File Offset: 0x00017221
		public int CurrentDisplayTraceStepIndex
		{
			get
			{
				return this.#d + 1;
			}
			set
			{
				if (this.CurrentDisplayTraceStepIndex != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107401517));
					this.CurrentTraceStepIndex = value - 1;
					base.RaisePropertyChanged(#Phc.#3hc(107401517));
				}
			}
		}

		// Token: 0x1700093A RID: 2362
		// (get) Token: 0x060018E6 RID: 6374 RVA: 0x00019061 File Offset: 0x00017261
		public int MaxDisplayTraceStepIndex
		{
			get
			{
				return this.TraceResults.Count;
			}
		}

		// Token: 0x1700093B RID: 2363
		// (get) Token: 0x060018E7 RID: 6375 RVA: 0x0001907A File Offset: 0x0001727A
		public string StepInfoMessage
		{
			get
			{
				return string.Format(#Phc.#3hc(107401476), this.TraceResults.Count);
			}
		}

		// Token: 0x1700093C RID: 2364
		// (get) Token: 0x060018E8 RID: 6376 RVA: 0x000190A7 File Offset: 0x000172A7
		// (set) Token: 0x060018E9 RID: 6377 RVA: 0x000190B3 File Offset: 0x000172B3
		public bool IsExecuting { get; private set; }

		// Token: 0x060018EA RID: 6378 RVA: 0x000190C4 File Offset: 0x000172C4
		public void #tQ()
		{
			if (!this.#c.Any<#4Ve>())
			{
				return;
			}
			this.CurrentTraceStepIndex = this.TraceResults.Count - 1;
		}

		// Token: 0x060018EB RID: 6379 RVA: 0x000190F3 File Offset: 0x000172F3
		public void #uQ()
		{
			if (!this.#c.Any<#4Ve>())
			{
				return;
			}
			this.CurrentTraceStepIndex = 0;
		}

		// Token: 0x060018EC RID: 6380 RVA: 0x000B782C File Offset: 0x000B5A2C
		public void #vQ()
		{
			if (!this.#c.Any<#4Ve>())
			{
				return;
			}
			int num = this.CurrentTraceStepIndex;
			this.CurrentTraceStepIndex = num - 1;
		}

		// Token: 0x060018ED RID: 6381 RVA: 0x000B7864 File Offset: 0x000B5A64
		public void #wQ()
		{
			if (!this.#c.Any<#4Ve>())
			{
				return;
			}
			int num = this.CurrentTraceStepIndex;
			this.CurrentTraceStepIndex = num + 1;
		}

		// Token: 0x060018EE RID: 6382 RVA: 0x00019116 File Offset: 0x00017316
		public void #xQ()
		{
			this.DesignEngine = null;
		}

		// Token: 0x060018EF RID: 6383 RVA: 0x00019127 File Offset: 0x00017327
		public bool #yQ()
		{
			if (this.#c.Any<#4Ve>())
			{
				this.CurrentTraceStepIndex = 0;
				return true;
			}
			this.CurrentTraceStepIndex = -1;
			return false;
		}

		// Token: 0x060018F0 RID: 6384 RVA: 0x00019153 File Offset: 0x00017353
		public void #zQ()
		{
			this.CurrentTraceStepIndex = this.TraceResults.Count - 1;
		}

		// Token: 0x060018F1 RID: 6385 RVA: 0x000B789C File Offset: 0x000B5A9C
		public void #0(#Q6e #AQ)
		{
			try
			{
				this.IsExecuting = true;
				this.#DQ();
				ColumnStorageModel storageModel = this.#b.#Pb(this.#a.Model);
				this.DesignEngine = new DesignEngine(storageModel, #AQ);
				this.#EQ(new #pW(this.DesignEngine));
				this.DesignEngine.#0();
			}
			finally
			{
				this.#FQ(new #pW(this.DesignEngine));
				this.IsExecuting = false;
			}
		}

		// Token: 0x060018F2 RID: 6386 RVA: 0x000B7930 File Offset: 0x000B5B30
		public #x0e #BQ()
		{
			ColumnStorageModel storageModel = this.#b.#Pb(this.#a.Model);
			DesignEngine designEngine = new DesignEngine(storageModel, new #O6e());
			designEngine.#tOe();
			return designEngine.GeometryProperties;
		}

		// Token: 0x060018F3 RID: 6387 RVA: 0x000B7978 File Offset: 0x000B5B78
		public IList<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #CQ()
		{
			ColumnStorageModel #Od = this.#b.#Pb(this.#a.Model);
			return this.#CQ(#Od);
		}

		// Token: 0x060018F4 RID: 6388 RVA: 0x000B79B0 File Offset: 0x000B5BB0
		public IList<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #CQ(ColumnStorageModel #Od)
		{
			DesignEngine designEngine = new DesignEngine(#Od, new #O6e());
			List<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> list = new List<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>();
			designEngine.#tOe();
			foreach (StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar reinforcementBar in designEngine.OutputModel.ReinforcementBars)
			{
				StructurePoint.Products.Column.Model.Entities.ReinforcementBar item = new StructurePoint.Products.Column.Model.Entities.ReinforcementBar(reinforcementBar.Area, reinforcementBar.X, reinforcementBar.Y, reinforcementBar.Z);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x060018F5 RID: 6389 RVA: 0x00019174 File Offset: 0x00017374
		public void #DQ()
		{
			DesignEngine designEngine = null;
			if (!false)
			{
				this.DesignEngine = designEngine;
			}
			this.#c.Clear();
			this.CurrentTraceStepIndex = -1;
			base.RaisePropertyChanged(#Phc.#3hc(107401499));
		}

		// Token: 0x060018F6 RID: 6390 RVA: 0x000191AE File Offset: 0x000173AE
		public bool #3Uh()
		{
			return this.CurrentTraceStepIndex == this.TraceResults.Count - 1;
		}

		// Token: 0x060018F7 RID: 6391 RVA: 0x000191D1 File Offset: 0x000173D1
		protected void #EQ(#pW #He)
		{
			#He.DesignEngine.MessageBus.DesignTrace += this.#GQ;
			EventHandler<#pW> eventHandler = this.#f;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x060018F8 RID: 6392 RVA: 0x000B7A50 File Offset: 0x000B5C50
		protected void #FQ(#pW #He)
		{
			DesignEngine designEngine = #He.DesignEngine;
			if (((designEngine != null) ? designEngine.MessageBus : null) != null)
			{
				#He.DesignEngine.MessageBus.DesignTrace -= this.#GQ;
			}
			base.RaisePropertyChanged(#Phc.#3hc(107401499));
			EventHandler<#pW> eventHandler = this.#g;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x060018F9 RID: 6393 RVA: 0x0001920D File Offset: 0x0001740D
		private void #GQ(object #Ge, #l7e #He)
		{
			if (#He.Data != null)
			{
				this.#c.Add(#He.Data);
			}
		}

		// Token: 0x04000990 RID: 2448
		private readonly #oW #a;

		// Token: 0x04000991 RID: 2449
		private readonly #9V #b;

		// Token: 0x04000992 RID: 2450
		private readonly List<#4Ve> #c = new List<#4Ve>();

		// Token: 0x04000993 RID: 2451
		private int #d;

		// Token: 0x04000994 RID: 2452
		private DesignEngine #e;

		// Token: 0x04000995 RID: 2453
		[CompilerGenerated]
		private EventHandler<#pW> #f;

		// Token: 0x04000996 RID: 2454
		[CompilerGenerated]
		private EventHandler<#pW> #g;

		// Token: 0x04000997 RID: 2455
		[CompilerGenerated]
		private #4Ve #h;

		// Token: 0x04000998 RID: 2456
		[CompilerGenerated]
		private bool #i;
	}
}
