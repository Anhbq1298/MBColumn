using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using #54d;
using #7hc;
using #8Cc;
using #jDc;
using #N6c;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace #gCc
{
	// Token: 0x02000B61 RID: 2913
	internal sealed class #NCc : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, #bDc
	{
		// Token: 0x06005F00 RID: 24320 RVA: 0x00177EDC File Offset: 0x001760DC
		public #NCc()
		{
			this.#d = new Stack<#qDc>();
			this.#b = new Stack<#qDc>();
			this.#c = new CustomObservableCollection<#qDc>();
			this.#a = new CustomObservableCollection<#qDc>();
			this.IsEnabled = true;
		}

		// Token: 0x14000178 RID: 376
		// (add) Token: 0x06005F01 RID: 24321 RVA: 0x00177F30 File Offset: 0x00176130
		// (remove) Token: 0x06005F02 RID: 24322 RVA: 0x00177F88 File Offset: 0x00176188
		public event EventHandler<#JCc> UndoStackChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler<#JCc> eventHandler2;
					if (!false)
					{
						EventHandler<#JCc> eventHandler = this.#g;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler<#JCc> eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler<#JCc> eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler<#JCc> eventHandler5 = (EventHandler<#JCc>)Delegate.Combine(eventHandler4, value);
							EventHandler<#JCc> value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler<#JCc> eventHandler6 = Interlocked.CompareExchange<EventHandler<#JCc>>(ref this.#g, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler<#JCc> eventHandler2;
					if (!false)
					{
						EventHandler<#JCc> eventHandler = this.#g;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler<#JCc> eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler<#JCc> eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler<#JCc> eventHandler5 = (EventHandler<#JCc>)Delegate.Remove(eventHandler4, value);
							EventHandler<#JCc> value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler<#JCc> eventHandler6 = Interlocked.CompareExchange<EventHandler<#JCc>>(ref this.#g, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
		}

		// Token: 0x14000179 RID: 377
		// (add) Token: 0x06005F03 RID: 24323 RVA: 0x00177FE0 File Offset: 0x001761E0
		// (remove) Token: 0x06005F04 RID: 24324 RVA: 0x00178038 File Offset: 0x00176238
		public event EventHandler CompositeActionCompleted
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#h;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler eventHandler5 = (EventHandler)Delegate.Combine(eventHandler4, value);
							EventHandler value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#h, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#h;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler eventHandler5 = (EventHandler)Delegate.Remove(eventHandler4, value);
							EventHandler value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#h, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
		}

		// Token: 0x17001AF4 RID: 6900
		// (get) Token: 0x06005F05 RID: 24325 RVA: 0x0004EDB8 File Offset: 0x0004CFB8
		// (set) Token: 0x06005F06 RID: 24326 RVA: 0x0004EDC0 File Offset: 0x0004CFC0
		public #dDc Owner { get; set; }

		// Token: 0x17001AF5 RID: 6901
		// (get) Token: 0x06005F07 RID: 24327 RVA: 0x0004EDC9 File Offset: 0x0004CFC9
		// (set) Token: 0x06005F08 RID: 24328 RVA: 0x00178090 File Offset: 0x00176290
		public bool IsEnabled
		{
			get
			{
				return this.#f;
			}
			set
			{
				for (;;)
				{
					if (this.#f == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107408148);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#f = value;
						string propertyName2 = #Phc.#3hc(107408148);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001AF6 RID: 6902
		// (get) Token: 0x06005F09 RID: 24329 RVA: 0x0004EDD1 File Offset: 0x0004CFD1
		public bool CanUndo
		{
			get
			{
				return this.#d.Any<#qDc>();
			}
		}

		// Token: 0x17001AF7 RID: 6903
		// (get) Token: 0x06005F0A RID: 24330 RVA: 0x0004EDDE File Offset: 0x0004CFDE
		public bool CanRedo
		{
			get
			{
				return this.#b.Any<#qDc>();
			}
		}

		// Token: 0x17001AF8 RID: 6904
		// (get) Token: 0x06005F0B RID: 24331 RVA: 0x0004EDEB File Offset: 0x0004CFEB
		public #k8c<#qDc> UndoActions
		{
			get
			{
				return this.#c;
			}
		}

		// Token: 0x17001AF9 RID: 6905
		// (get) Token: 0x06005F0C RID: 24332 RVA: 0x0004EDF3 File Offset: 0x0004CFF3
		public #k8c<#qDc> RedoActions
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17001AFA RID: 6906
		// (get) Token: 0x06005F0D RID: 24333 RVA: 0x0004EDFB File Offset: 0x0004CFFB
		public bool CanPushMementoActions
		{
			get
			{
				return this.IsEnabled && this.CanSaveMementoSnapshots;
			}
		}

		// Token: 0x17001AFB RID: 6907
		// (get) Token: 0x06005F0E RID: 24334 RVA: 0x0004EE0D File Offset: 0x0004D00D
		public long TransactionDepth
		{
			get
			{
				return Interlocked.Read(ref this.#e);
			}
		}

		// Token: 0x17001AFC RID: 6908
		// (get) Token: 0x06005F0F RID: 24335 RVA: 0x0004EE1A File Offset: 0x0004D01A
		public #FCc TransactionInfo { get; } = new #FCc();

		// Token: 0x17001AFD RID: 6909
		// (get) Token: 0x06005F10 RID: 24336 RVA: 0x0004EE22 File Offset: 0x0004D022
		private bool CanSaveMementoSnapshots
		{
			get
			{
				return Interlocked.CompareExchange(ref this.#e, 0L, 0L) == 0L;
			}
		}

		// Token: 0x06005F11 RID: 24337 RVA: 0x001780E4 File Offset: 0x001762E4
		public void #yl()
		{
			do
			{
				bool flag = #44d.#d;
				do
				{
					string propertyName = null;
					if (7 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					for (;;)
					{
						Stack<#qDc> stack = this.#d;
						if (!false)
						{
							stack.Clear();
						}
						Stack<#qDc> stack2 = this.#b;
						if (6 != 0)
						{
							stack2.Clear();
						}
						Collection<#qDc> collection = this.#c;
						if (true)
						{
							collection.Clear();
						}
						while (!false)
						{
							Collection<#qDc> collection2 = this.#a;
							if (!false)
							{
								collection2.Clear();
							}
							#FCc #FCc = this.TransactionInfo;
							if (4 != 0)
							{
								#FCc.#yl();
							}
							if (!false)
							{
								goto Block_1;
							}
						}
					}
					Block_1:;
				}
				while (false);
				base.RaisePropertyChanged(null);
				this.#BCc(new #JCc(null, #JCc.#E8c.#a));
				CommandManager.InvalidateRequerySuggested();
			}
			while (4 == 0);
			bool flag2 = #44d.#d;
		}

		// Token: 0x06005F12 RID: 24338 RVA: 0x0017818C File Offset: 0x0017638C
		public void #uCc()
		{
			if (3 != 0)
			{
				bool flag = this.CanSaveMementoSnapshots;
				IL_09:
				while (flag)
				{
					while (this.IsEnabled)
					{
						flag = #44d.#d;
						if (!false)
						{
							if (false)
							{
								goto IL_09;
							}
							#cDc #cDc = this.Owner.#oi();
							#cDc #qi;
							if (!false)
							{
								#qi = #cDc;
							}
							#xDc #xDc = new #xDc(this.Owner, #qi);
							#xDc #xDc2;
							if (5 != 0)
							{
								#xDc2 = #xDc;
							}
							Interlocked.Increment(ref this.#e);
							#qDc #nd = #xDc2;
							if (6 != 0)
							{
								this.#MCc(#nd);
							}
							string empty = string.Empty;
							if (!false)
							{
								base.RaisePropertyChanged(empty);
							}
							bool flag2 = #44d.#d;
						}
						if (2 != 0)
						{
							return;
						}
					}
					return;
				}
			}
			Interlocked.Increment(ref this.#e);
		}

		// Token: 0x06005F13 RID: 24339 RVA: 0x00178220 File Offset: 0x00176420
		public void #vCc()
		{
			if (this.CanSaveMementoSnapshots)
			{
				return;
			}
			if (Interlocked.Decrement(ref this.#e) <= 0L)
			{
				goto IL_18;
			}
			do
			{
				IL_22:
				if (2 != 0)
				{
					this.#CCc();
				}
				bool flag = #44d.#d;
				string empty = string.Empty;
				if (5 != 0)
				{
					base.RaisePropertyChanged(empty);
				}
				if (false)
				{
					goto IL_18;
				}
			}
			while (false);
			return;
			IL_18:
			#FCc #FCc = this.TransactionInfo;
			if (6 == 0)
			{
				goto IL_22;
			}
			#FCc.#yl();
			goto IL_22;
		}

		// Token: 0x06005F14 RID: 24340 RVA: 0x0004EE37 File Offset: 0x0004D037
		public void #xCc(#qDc #nd)
		{
			if (4 != 0)
			{
				bool flag = #44d.#d;
				while (3 == 0 || this.IsEnabled)
				{
					bool flag2 = this.CanSaveMementoSnapshots;
					if (!false)
					{
						if (!flag2)
						{
							return;
						}
						if (false)
						{
							return;
						}
						this.#MCc(#nd);
						return;
					}
				}
				return;
			}
		}

		// Token: 0x06005F15 RID: 24341 RVA: 0x00178280 File Offset: 0x00176480
		public void #wCc()
		{
			bool flag = this.CanSaveMementoSnapshots;
			while (!flag)
			{
				#qDc #nd;
				if (!false)
				{
					bool flag2 = flag = this.#d.Any<#qDc>();
					if (false)
					{
						continue;
					}
					if (!flag2)
					{
						break;
					}
					if (-1 != 0)
					{
						bool flag3 = #44d.#d;
						#qDc #qDc = this.#d.Pop();
						if (!false)
						{
							#nd = #qDc;
						}
					}
				}
				do
				{
					CustomObservableCollection<#qDc> #G = this.#c;
					IEnumerable<#qDc> #Ic = this.#d;
					if (7 != 0)
					{
						#NCc.#LCc(#G, #Ic);
					}
					#JCc #JCc = new #JCc(#nd, #JCc.#E8c.#c);
					bool flag4 = true;
					if (4 != 0)
					{
						#JCc.Discard = flag4;
					}
					if (!false)
					{
						this.#BCc(#JCc);
					}
				}
				while (-1 == 0);
				string propertyName = null;
				if (!false)
				{
					base.RaisePropertyChanged(propertyName);
				}
				bool flag5 = #44d.#d;
				break;
			}
		}

		// Token: 0x06005F16 RID: 24342 RVA: 0x0004ECBB File Offset: 0x0004CEBB
		public IDisposable #AA()
		{
			return new #fCc(this);
		}

		// Token: 0x06005F17 RID: 24343 RVA: 0x00178314 File Offset: 0x00176514
		public void #yCc(#aDc #ri = #aDc.#b)
		{
			bool flag = #44d.#d;
			#qDc #qDc2;
			if (-1 != 0)
			{
				bool flag2 = #44d.#d;
				if (!this.IsEnabled || !this.#d.Any<#qDc>())
				{
					return;
				}
				string propertyName = null;
				if (-1 != 0)
				{
					base.RaisePropertyChanging(propertyName);
				}
				#qDc #qDc = this.#d.Pop();
				if (3 != 0)
				{
					#qDc2 = #qDc;
				}
				if (#ri.HasFlag(#aDc.#b))
				{
					if (false)
					{
						return;
					}
					Stack<#qDc> stack = this.#b;
					#qDc item = #qDc2;
					if (!false)
					{
						stack.Push(item);
					}
				}
				CustomObservableCollection<#qDc> #G = this.#c;
				IEnumerable<#qDc> #Ic = this.#d;
				if (5 != 0)
				{
					#NCc.#LCc(#G, #Ic);
				}
			}
			CustomObservableCollection<#qDc> #G2 = this.#a;
			IEnumerable<#qDc> #Ic2 = this.#b;
			if (3 != 0)
			{
				#NCc.#LCc(#G2, #Ic2);
			}
			#qDc #qDc3 = #qDc2;
			if (2 != 0)
			{
				#qDc3.#yCc(#ri);
			}
			this.#BCc(new #JCc(#qDc2, #JCc.#E8c.#c));
			base.RaisePropertyChanged(null);
			bool flag3 = #44d.#d;
			bool flag4 = #44d.#d;
		}

		// Token: 0x06005F18 RID: 24344 RVA: 0x0004EE68 File Offset: 0x0004D068
		public void #yCc(bool #ACc)
		{
			#aDc #ri = #ACc ? #aDc.#b : #aDc.#a;
			if (!false)
			{
				this.#yCc(#ri);
			}
		}

		// Token: 0x06005F19 RID: 24345 RVA: 0x001783F4 File Offset: 0x001765F4
		public void #zCc()
		{
			bool flag = #44d.#d;
			if (!this.IsEnabled || !this.#b.Any<#qDc>())
			{
				bool flag2 = #44d.#d;
				return;
			}
			string propertyName = null;
			if (!false)
			{
				base.RaisePropertyChanging(propertyName);
			}
			#qDc #qDc = this.#b.Pop();
			#qDc #qDc2;
			if (!false)
			{
				#qDc2 = #qDc;
			}
			Stack<#qDc> stack = this.#d;
			#qDc item = #qDc2;
			if (!false)
			{
				stack.Push(item);
			}
			CustomObservableCollection<#qDc> #G = this.#c;
			IEnumerable<#qDc> #Ic = this.#d;
			if (3 != 0)
			{
				#NCc.#LCc(#G, #Ic);
			}
			CustomObservableCollection<#qDc> #G2 = this.#a;
			IEnumerable<#qDc> #Ic2 = this.#b;
			if (3 != 0)
			{
				#NCc.#LCc(#G2, #Ic2);
			}
			#qDc #qDc3 = #qDc2;
			if (6 != 0)
			{
				#qDc3.#zCc();
			}
			base.RaisePropertyChanged(null);
			this.#BCc(new #JCc(#qDc2, #JCc.#E8c.#b));
			bool flag3 = #44d.#d;
		}

		// Token: 0x06005F1A RID: 24346 RVA: 0x0004EE7E File Offset: 0x0004D07E
		protected void #BCc(#JCc #He)
		{
			EventHandler<#JCc> eventHandler = this.#g;
			if (eventHandler == null)
			{
				return;
			}
			if (!false)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x06005F1B RID: 24347 RVA: 0x001784AC File Offset: 0x001766AC
		private static void #LCc(CustomObservableCollection<#qDc> #G, IEnumerable<#qDc> #Ic)
		{
			do
			{
				#07c #07c = new #07c(#G);
				#07c #07c2;
				if (3 != 0)
				{
					#07c2 = #07c;
					goto IL_0A;
				}
				try
				{
					for (;;)
					{
						IL_0A:
						if (2 != 0)
						{
							#G.Clear();
						}
						if (2 != 0)
						{
							if (true)
							{
								#G.#pR(#Ic);
							}
							if (!false)
							{
								break;
							}
						}
					}
				}
				finally
				{
					if (#07c2 != null)
					{
						((IDisposable)#07c2).Dispose();
					}
				}
			}
			while (8 == 0);
		}

		// Token: 0x06005F1C RID: 24348 RVA: 0x00178508 File Offset: 0x00176708
		private void #MCc(#qDc #nd)
		{
			string propertyName = #Phc.#3hc(107417628);
			if (-1 != 0)
			{
				base.RaisePropertyChanging(propertyName);
			}
			if (4 != 0)
			{
				Stack<#qDc> stack = this.#b;
				if (7 != 0)
				{
					stack.Clear();
				}
				if (-1 != 0)
				{
					Stack<#qDc> stack2 = this.#d;
					if (!false)
					{
						stack2.Push(#nd);
					}
					CustomObservableCollection<#qDc> #G = this.#c;
					IEnumerable<#qDc> #Ic = this.#d;
					if (6 != 0)
					{
						#NCc.#LCc(#G, #Ic);
					}
				}
			}
			CustomObservableCollection<#qDc> #G2 = this.#a;
			IEnumerable<#qDc> #Ic2 = this.#b;
			if (true)
			{
				#NCc.#LCc(#G2, #Ic2);
			}
			#JCc #He = new #JCc(#nd, #JCc.#E8c.#b);
			if (!false)
			{
				this.#BCc(#He);
			}
			base.RaisePropertyChanged(null);
			bool flag = #44d.#d;
		}

		// Token: 0x06005F1D RID: 24349 RVA: 0x0004EE9A File Offset: 0x0004D09A
		protected void #CCc()
		{
			EventHandler eventHandler = this.#h;
			if (eventHandler == null)
			{
				return;
			}
			EventArgs empty = EventArgs.Empty;
			if (!false)
			{
				eventHandler(this, empty);
			}
		}

		// Token: 0x04002747 RID: 10055
		private readonly CustomObservableCollection<#qDc> #a;

		// Token: 0x04002748 RID: 10056
		private readonly Stack<#qDc> #b;

		// Token: 0x04002749 RID: 10057
		private readonly CustomObservableCollection<#qDc> #c;

		// Token: 0x0400274A RID: 10058
		private readonly Stack<#qDc> #d;

		// Token: 0x0400274B RID: 10059
		private long #e;

		// Token: 0x0400274C RID: 10060
		private bool #f;

		// Token: 0x0400274D RID: 10061
		[CompilerGenerated]
		private EventHandler<#JCc> #g;

		// Token: 0x0400274E RID: 10062
		[CompilerGenerated]
		private EventHandler #h;

		// Token: 0x0400274F RID: 10063
		[CompilerGenerated]
		private #dDc #i;

		// Token: 0x04002750 RID: 10064
		[CompilerGenerated]
		private readonly #FCc #j;
	}
}
