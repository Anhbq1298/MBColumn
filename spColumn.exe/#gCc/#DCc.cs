using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using #8Cc;
using #fDc;
using #jDc;
using #N6c;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace #gCc
{
	// Token: 0x02000B58 RID: 2904
	internal sealed class #DCc : INotifyPropertyChanged, #7Cc, #bDc
	{
		// Token: 0x06005EB8 RID: 24248 RVA: 0x0004EC3E File Offset: 0x0004CE3E
		public #DCc()
		{
			this.Owner = new #gDc();
			this.RedoActions = new CustomObservableCollection<#qDc>();
			this.UndoActions = new CustomObservableCollection<#qDc>();
		}

		// Token: 0x14000173 RID: 371
		// (add) Token: 0x06005EB9 RID: 24249 RVA: 0x00177ADC File Offset: 0x00175CDC
		// (remove) Token: 0x06005EBA RID: 24250 RVA: 0x00177B34 File Offset: 0x00175D34
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler2;
					if (!false)
					{
						PropertyChangedEventHandler propertyChangedEventHandler = this.#b;
						if (!false)
						{
							propertyChangedEventHandler2 = propertyChangedEventHandler;
						}
					}
					PropertyChangedEventHandler propertyChangedEventHandler4;
					do
					{
						if (7 != 0)
						{
							PropertyChangedEventHandler propertyChangedEventHandler3 = propertyChangedEventHandler2;
							if (3 != 0)
							{
								propertyChangedEventHandler4 = propertyChangedEventHandler3;
							}
							PropertyChangedEventHandler propertyChangedEventHandler5 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler4, value);
							PropertyChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangedEventHandler5;
							}
							PropertyChangedEventHandler propertyChangedEventHandler6 = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#b, value2, propertyChangedEventHandler4);
							if (6 != 0)
							{
								propertyChangedEventHandler2 = propertyChangedEventHandler6;
							}
						}
					}
					while (propertyChangedEventHandler2 != propertyChangedEventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler2;
					if (!false)
					{
						PropertyChangedEventHandler propertyChangedEventHandler = this.#b;
						if (!false)
						{
							propertyChangedEventHandler2 = propertyChangedEventHandler;
						}
					}
					PropertyChangedEventHandler propertyChangedEventHandler4;
					do
					{
						if (7 != 0)
						{
							PropertyChangedEventHandler propertyChangedEventHandler3 = propertyChangedEventHandler2;
							if (3 != 0)
							{
								propertyChangedEventHandler4 = propertyChangedEventHandler3;
							}
							PropertyChangedEventHandler propertyChangedEventHandler5 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler4, value);
							PropertyChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangedEventHandler5;
							}
							PropertyChangedEventHandler propertyChangedEventHandler6 = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#b, value2, propertyChangedEventHandler4);
							if (6 != 0)
							{
								propertyChangedEventHandler2 = propertyChangedEventHandler6;
							}
						}
					}
					while (propertyChangedEventHandler2 != propertyChangedEventHandler4);
				}
			}
		}

		// Token: 0x14000174 RID: 372
		// (add) Token: 0x06005EBB RID: 24251 RVA: 0x00177B8C File Offset: 0x00175D8C
		// (remove) Token: 0x06005EBC RID: 24252 RVA: 0x00177BE4 File Offset: 0x00175DE4
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
						EventHandler<#JCc> eventHandler = this.#c;
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
							EventHandler<#JCc> eventHandler6 = Interlocked.CompareExchange<EventHandler<#JCc>>(ref this.#c, value2, eventHandler4);
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
						EventHandler<#JCc> eventHandler = this.#c;
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
							EventHandler<#JCc> eventHandler6 = Interlocked.CompareExchange<EventHandler<#JCc>>(ref this.#c, value2, eventHandler4);
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

		// Token: 0x14000175 RID: 373
		// (add) Token: 0x06005EBD RID: 24253 RVA: 0x00177C3C File Offset: 0x00175E3C
		// (remove) Token: 0x06005EBE RID: 24254 RVA: 0x00177C94 File Offset: 0x00175E94
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
						EventHandler eventHandler = this.#d;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler4);
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
						EventHandler eventHandler = this.#d;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#d, value2, eventHandler4);
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

		// Token: 0x17001ADD RID: 6877
		// (get) Token: 0x06005EBF RID: 24255 RVA: 0x0004EC72 File Offset: 0x0004CE72
		public static #7Cc Default
		{
			get
			{
				return #DCc.#a;
			}
		}

		// Token: 0x17001ADE RID: 6878
		// (get) Token: 0x06005EC0 RID: 24256 RVA: 0x0000C78B File Offset: 0x0000A98B
		public bool CanPushMementoActions
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17001ADF RID: 6879
		// (get) Token: 0x06005EC1 RID: 24257 RVA: 0x0004EC79 File Offset: 0x0004CE79
		public long TransactionDepth { get; }

		// Token: 0x17001AE0 RID: 6880
		// (get) Token: 0x06005EC2 RID: 24258 RVA: 0x0004EC81 File Offset: 0x0004CE81
		public #FCc TransactionInfo { get; } = new #FCc();

		// Token: 0x17001AE1 RID: 6881
		// (get) Token: 0x06005EC3 RID: 24259 RVA: 0x0000C78B File Offset: 0x0000A98B
		public bool CanRedo
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17001AE2 RID: 6882
		// (get) Token: 0x06005EC4 RID: 24260 RVA: 0x0000C78B File Offset: 0x0000A98B
		public bool CanUndo
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17001AE3 RID: 6883
		// (get) Token: 0x06005EC5 RID: 24261 RVA: 0x0004EC89 File Offset: 0x0004CE89
		// (set) Token: 0x06005EC6 RID: 24262 RVA: 0x0004EC91 File Offset: 0x0004CE91
		public bool IsEnabled { get; set; }

		// Token: 0x17001AE4 RID: 6884
		// (get) Token: 0x06005EC7 RID: 24263 RVA: 0x0004EC9A File Offset: 0x0004CE9A
		// (set) Token: 0x06005EC8 RID: 24264 RVA: 0x0004ECA2 File Offset: 0x0004CEA2
		public #dDc Owner { get; set; }

		// Token: 0x17001AE5 RID: 6885
		// (get) Token: 0x06005EC9 RID: 24265 RVA: 0x0004ECAB File Offset: 0x0004CEAB
		public #k8c<#qDc> RedoActions { get; }

		// Token: 0x17001AE6 RID: 6886
		// (get) Token: 0x06005ECA RID: 24266 RVA: 0x0004ECB3 File Offset: 0x0004CEB3
		public #k8c<#qDc> UndoActions { get; }

		// Token: 0x06005ECB RID: 24267 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #uCc()
		{
		}

		// Token: 0x06005ECC RID: 24268 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #yl()
		{
		}

		// Token: 0x06005ECD RID: 24269 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #vCc()
		{
		}

		// Token: 0x06005ECE RID: 24270 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #wCc()
		{
		}

		// Token: 0x06005ECF RID: 24271 RVA: 0x0004ECBB File Offset: 0x0004CEBB
		public IDisposable #AA()
		{
			return new #fCc(this);
		}

		// Token: 0x06005ED0 RID: 24272 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #xCc(#qDc #nd)
		{
		}

		// Token: 0x06005ED1 RID: 24273 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #yCc(#aDc #ri = #aDc.#b)
		{
		}

		// Token: 0x06005ED2 RID: 24274 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #zCc()
		{
		}

		// Token: 0x06005ED3 RID: 24275 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #yCc(bool #ACc)
		{
		}

		// Token: 0x06005ED4 RID: 24276 RVA: 0x0004ECC3 File Offset: 0x0004CEC3
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		protected void #Fkb([CallerMemberName] string #em = null)
		{
			do
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler = this.#b;
					if (propertyChangedEventHandler != null)
					{
						PropertyChangedEventArgs e = new PropertyChangedEventArgs(#em);
						if (!false)
						{
							propertyChangedEventHandler(this, e);
						}
						if (!false)
						{
							return;
						}
						continue;
					}
				}
			}
			while (false);
		}

		// Token: 0x06005ED5 RID: 24277 RVA: 0x0004ECED File Offset: 0x0004CEED
		protected void #BCc(#JCc #He)
		{
			EventHandler<#JCc> eventHandler = this.#c;
			if (eventHandler == null)
			{
				return;
			}
			if (!false)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x06005ED6 RID: 24278 RVA: 0x0004ED09 File Offset: 0x0004CF09
		protected void #CCc()
		{
			EventHandler eventHandler = this.#d;
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

		// Token: 0x04002733 RID: 10035
		private static readonly #DCc #a = new #DCc();

		// Token: 0x04002734 RID: 10036
		[CompilerGenerated]
		private PropertyChangedEventHandler #b;

		// Token: 0x04002735 RID: 10037
		[CompilerGenerated]
		private EventHandler<#JCc> #c;

		// Token: 0x04002736 RID: 10038
		[CompilerGenerated]
		private EventHandler #d;

		// Token: 0x04002737 RID: 10039
		[CompilerGenerated]
		private readonly long #e;

		// Token: 0x04002738 RID: 10040
		[CompilerGenerated]
		private readonly #FCc #f;

		// Token: 0x04002739 RID: 10041
		[CompilerGenerated]
		private bool #g;

		// Token: 0x0400273A RID: 10042
		[CompilerGenerated]
		private #dDc #h;

		// Token: 0x0400273B RID: 10043
		[CompilerGenerated]
		private readonly #k8c<#qDc> #i;

		// Token: 0x0400273C RID: 10044
		[CompilerGenerated]
		private readonly #k8c<#qDc> #j;
	}
}
