using System;
using System.Runtime.CompilerServices;
using System.Threading;
using #cMb;
using #RJb;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #eU
{
	// Token: 0x0200031A RID: 794
	internal sealed class #nW : #UV
	{
		// Token: 0x1400005A RID: 90
		// (add) Token: 0x06001B63 RID: 7011 RVA: 0x000BDE1C File Offset: 0x000BC01C
		// (remove) Token: 0x06001B64 RID: 7012 RVA: 0x000BDE60 File Offset: 0x000BC060
		public event EventHandler<#3V> LoadProjectRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#3V> eventHandler = this.#a;
				EventHandler<#3V> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#3V> value2 = (EventHandler<#3V>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#3V>>(ref this.#a, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#3V> eventHandler = this.#a;
				EventHandler<#3V> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#3V> value2 = (EventHandler<#3V>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#3V>>(ref this.#a, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400005B RID: 91
		// (add) Token: 0x06001B65 RID: 7013 RVA: 0x000BDEA4 File Offset: 0x000BC0A4
		// (remove) Token: 0x06001B66 RID: 7014 RVA: 0x000BDEE8 File Offset: 0x000BC0E8
		public event EventHandler<#cW> ProjectLoaded
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#cW> eventHandler = this.#b;
				EventHandler<#cW> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#cW> value2 = (EventHandler<#cW>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#cW>>(ref this.#b, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#cW> eventHandler = this.#b;
				EventHandler<#cW> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#cW> value2 = (EventHandler<#cW>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#cW>>(ref this.#b, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400005C RID: 92
		// (add) Token: 0x06001B67 RID: 7015 RVA: 0x000BDF2C File Offset: 0x000BC12C
		// (remove) Token: 0x06001B68 RID: 7016 RVA: 0x000BDF70 File Offset: 0x000BC170
		public event EventHandler UnitSystemChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#c;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#c, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#c;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#c, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400005D RID: 93
		// (add) Token: 0x06001B69 RID: 7017 RVA: 0x000BDFB4 File Offset: 0x000BC1B4
		// (remove) Token: 0x06001B6A RID: 7018 RVA: 0x000BDFF8 File Offset: 0x000BC1F8
		public event EventHandler DesignCodeChanged
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

		// Token: 0x1400005E RID: 94
		// (add) Token: 0x06001B6B RID: 7019 RVA: 0x000BE03C File Offset: 0x000BC23C
		// (remove) Token: 0x06001B6C RID: 7020 RVA: 0x000BE080 File Offset: 0x000BC280
		public event EventHandler LoadCombinationsChanged
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

		// Token: 0x1400005F RID: 95
		// (add) Token: 0x06001B6D RID: 7021 RVA: 0x000BE0C4 File Offset: 0x000BC2C4
		// (remove) Token: 0x06001B6E RID: 7022 RVA: 0x000BE108 File Offset: 0x000BC308
		public event EventHandler DefinitionChangesCommitted
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#f;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#f;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#f, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000060 RID: 96
		// (add) Token: 0x06001B6F RID: 7023 RVA: 0x000BE14C File Offset: 0x000BC34C
		// (remove) Token: 0x06001B70 RID: 7024 RVA: 0x000BE190 File Offset: 0x000BC390
		public event EventHandler DefinitionActivePanelsChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#g;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#g, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#g;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#g, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000061 RID: 97
		// (add) Token: 0x06001B71 RID: 7025 RVA: 0x000BE1D4 File Offset: 0x000BC3D4
		// (remove) Token: 0x06001B72 RID: 7026 RVA: 0x000BE218 File Offset: 0x000BC418
		public event EventHandler SettingsChanged
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

		// Token: 0x14000062 RID: 98
		// (add) Token: 0x06001B73 RID: 7027 RVA: 0x000BE25C File Offset: 0x000BC45C
		// (remove) Token: 0x06001B74 RID: 7028 RVA: 0x000BE2A0 File Offset: 0x000BC4A0
		public event EventHandler DisplayOptionsChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#i;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#i, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#i;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#i, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000063 RID: 99
		// (add) Token: 0x06001B75 RID: 7029 RVA: 0x000BE2E4 File Offset: 0x000BC4E4
		// (remove) Token: 0x06001B76 RID: 7030 RVA: 0x000BE328 File Offset: 0x000BC528
		public event EventHandler SectionPropertiesInvalidated
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

		// Token: 0x14000064 RID: 100
		// (add) Token: 0x06001B77 RID: 7031 RVA: 0x000BE36C File Offset: 0x000BC56C
		// (remove) Token: 0x06001B78 RID: 7032 RVA: 0x000BE3B0 File Offset: 0x000BC5B0
		public event EventHandler<#fW> SolveCompleted
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#fW> eventHandler = this.#k;
				EventHandler<#fW> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#fW> value2 = (EventHandler<#fW>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#fW>>(ref this.#k, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#fW> eventHandler = this.#k;
				EventHandler<#fW> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#fW> value2 = (EventHandler<#fW>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#fW>>(ref this.#k, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000065 RID: 101
		// (add) Token: 0x06001B79 RID: 7033 RVA: 0x000BE3F4 File Offset: 0x000BC5F4
		// (remove) Token: 0x06001B7A RID: 7034 RVA: 0x000BE438 File Offset: 0x000BC638
		public event EventHandler<#BU> ToggleToolRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#BU> eventHandler = this.#l;
				EventHandler<#BU> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#BU> value2 = (EventHandler<#BU>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#BU>>(ref this.#l, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#BU> eventHandler = this.#l;
				EventHandler<#BU> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#BU> value2 = (EventHandler<#BU>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#BU>>(ref this.#l, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000066 RID: 102
		// (add) Token: 0x06001B7B RID: 7035 RVA: 0x000BE47C File Offset: 0x000BC67C
		// (remove) Token: 0x06001B7C RID: 7036 RVA: 0x000BE4C0 File Offset: 0x000BC6C0
		public event EventHandler SelectionModeRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#m;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#m, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#m;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#m, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000067 RID: 103
		// (add) Token: 0x06001B7D RID: 7037 RVA: 0x000BE504 File Offset: 0x000BC704
		// (remove) Token: 0x06001B7E RID: 7038 RVA: 0x000BE548 File Offset: 0x000BC748
		public event EventHandler CancelToolsRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#n;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#n, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#n;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#n, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000068 RID: 104
		// (add) Token: 0x06001B7F RID: 7039 RVA: 0x000BE58C File Offset: 0x000BC78C
		// (remove) Token: 0x06001B80 RID: 7040 RVA: 0x000BE5D0 File Offset: 0x000BC7D0
		public event EventHandler EditorNodesSelectionChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#o;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#o, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#o;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#o, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000069 RID: 105
		// (add) Token: 0x06001B81 RID: 7041 RVA: 0x000BE614 File Offset: 0x000BC814
		// (remove) Token: 0x06001B82 RID: 7042 RVA: 0x000BE658 File Offset: 0x000BC858
		public event EventHandler EditorNodeMoved
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#p;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#p, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#p;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#p, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400006A RID: 106
		// (add) Token: 0x06001B83 RID: 7043 RVA: 0x000BE69C File Offset: 0x000BC89C
		// (remove) Token: 0x06001B84 RID: 7044 RVA: 0x000BE6E0 File Offset: 0x000BC8E0
		public event EventHandler EditorSelectionChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#q;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#q, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#q;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#q, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400006B RID: 107
		// (add) Token: 0x06001B85 RID: 7045 RVA: 0x000BE724 File Offset: 0x000BC924
		// (remove) Token: 0x06001B86 RID: 7046 RVA: 0x000BE768 File Offset: 0x000BC968
		public event EventHandler DeleteSelectedObjectsRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#r;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#r, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#r;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#r, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400006C RID: 108
		// (add) Token: 0x06001B87 RID: 7047 RVA: 0x000BE7AC File Offset: 0x000BC9AC
		// (remove) Token: 0x06001B88 RID: 7048 RVA: 0x000BE7F0 File Offset: 0x000BC9F0
		public event EventHandler SlabsEditorSelectionChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#s;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#s, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#s;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#s, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400006D RID: 109
		// (add) Token: 0x06001B89 RID: 7049 RVA: 0x000BE834 File Offset: 0x000BCA34
		// (remove) Token: 0x06001B8A RID: 7050 RVA: 0x000BE878 File Offset: 0x000BCA78
		public event EventHandler<#jW> DesignTraceStateChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#jW> eventHandler = this.#t;
				EventHandler<#jW> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#jW> value2 = (EventHandler<#jW>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#jW>>(ref this.#t, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#jW> eventHandler = this.#t;
				EventHandler<#jW> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#jW> value2 = (EventHandler<#jW>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#jW>>(ref this.#t, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400006E RID: 110
		// (add) Token: 0x06001B8B RID: 7051 RVA: 0x000BE8BC File Offset: 0x000BCABC
		// (remove) Token: 0x06001B8C RID: 7052 RVA: 0x000BE900 File Offset: 0x000BCB00
		public event EventHandler<#QJb> ActiveScopeChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#QJb> eventHandler = this.#u;
				EventHandler<#QJb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#QJb> value2 = (EventHandler<#QJb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#QJb>>(ref this.#u, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#QJb> eventHandler = this.#u;
				EventHandler<#QJb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#QJb> value2 = (EventHandler<#QJb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#QJb>>(ref this.#u, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400006F RID: 111
		// (add) Token: 0x06001B8D RID: 7053 RVA: 0x000BE944 File Offset: 0x000BCB44
		// (remove) Token: 0x06001B8E RID: 7054 RVA: 0x000BE988 File Offset: 0x000BCB88
		public event EventHandler SectionImportActivateIrregularSectionView
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#v;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#v, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#v;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#v, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000070 RID: 112
		// (add) Token: 0x06001B8F RID: 7055 RVA: 0x000BE9CC File Offset: 0x000BCBCC
		// (remove) Token: 0x06001B90 RID: 7056 RVA: 0x000BEA10 File Offset: 0x000BCC10
		public event EventHandler DiagramImposed
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#w;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#w, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#w;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#w, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000071 RID: 113
		// (add) Token: 0x06001B91 RID: 7057 RVA: 0x000BEA54 File Offset: 0x000BCC54
		// (remove) Token: 0x06001B92 RID: 7058 RVA: 0x000BEA98 File Offset: 0x000BCC98
		public event EventHandler SectionLeftPanelRefreshRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#x;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#x, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#x;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#x, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000072 RID: 114
		// (add) Token: 0x06001B93 RID: 7059 RVA: 0x000BEADC File Offset: 0x000BCCDC
		// (remove) Token: 0x06001B94 RID: 7060 RVA: 0x000BEB20 File Offset: 0x000BCD20
		public event EventHandler TemplateLoaded
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#y;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#y, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#y;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#y, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000073 RID: 115
		// (add) Token: 0x06001B95 RID: 7061 RVA: 0x000BEB64 File Offset: 0x000BCD64
		// (remove) Token: 0x06001B96 RID: 7062 RVA: 0x000BEBA8 File Offset: 0x000BCDA8
		public event EventHandler TrySelectTemplateRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#z;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#z, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#z;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#z, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x06001B97 RID: 7063 RVA: 0x0001AB28 File Offset: 0x00018D28
		public void #PV(#QJb #Lg)
		{
			EventHandler<#QJb> eventHandler = this.#u;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #Lg);
		}

		// Token: 0x06001B98 RID: 7064 RVA: 0x0001AB48 File Offset: 0x00018D48
		public void #OV(#jW #He)
		{
			EventHandler<#jW> eventHandler = this.#t;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x06001B99 RID: 7065 RVA: 0x0001AB68 File Offset: 0x00018D68
		public void #sV()
		{
			EventHandler eventHandler = this.#x;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001B9A RID: 7066 RVA: 0x0001AB8C File Offset: 0x00018D8C
		public void #tV()
		{
			EventHandler eventHandler = this.#s;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001B9B RID: 7067 RVA: 0x0001ABB0 File Offset: 0x00018DB0
		public void #yV()
		{
			EventHandler eventHandler = this.#n;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001B9C RID: 7068 RVA: 0x0001ABD4 File Offset: 0x00018DD4
		public void #zV(ColumnStorageModel #Od, bool #ZK, bool #AV = false)
		{
			EventHandler<#cW> eventHandler = this.#b;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, new #cW(#Od, #ZK, #AV));
		}

		// Token: 0x06001B9D RID: 7069 RVA: 0x0001ABFB File Offset: 0x00018DFB
		public void #uV(#uNb #Ph)
		{
			EventHandler<#BU> eventHandler = this.#l;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, new #BU(#Ph));
		}

		// Token: 0x06001B9E RID: 7070 RVA: 0x0001AC20 File Offset: 0x00018E20
		public void #vV()
		{
			EventHandler eventHandler = this.#m;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001B9F RID: 7071 RVA: 0x0001AC44 File Offset: 0x00018E44
		public void #wV(bool #xV, string #So)
		{
			EventHandler<#3V> eventHandler = this.#a;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, new #3V(#xV, #So));
		}

		// Token: 0x06001BA0 RID: 7072 RVA: 0x0001AC6A File Offset: 0x00018E6A
		public void #BV()
		{
			EventHandler eventHandler = this.#c;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BA1 RID: 7073 RVA: 0x0001AC8E File Offset: 0x00018E8E
		public void #DV()
		{
			EventHandler eventHandler = this.#e;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BA2 RID: 7074 RVA: 0x0001ACB2 File Offset: 0x00018EB2
		public void #CV()
		{
			EventHandler eventHandler = this.#d;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BA3 RID: 7075 RVA: 0x0001ACD6 File Offset: 0x00018ED6
		public void #EV()
		{
			EventHandler eventHandler = this.#f;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BA4 RID: 7076 RVA: 0x0001ACFA File Offset: 0x00018EFA
		public void #FV()
		{
			EventHandler eventHandler = this.#g;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BA5 RID: 7077 RVA: 0x0001AD1E File Offset: 0x00018F1E
		public void #GV()
		{
			EventHandler eventHandler = this.#h;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BA6 RID: 7078 RVA: 0x0001AD42 File Offset: 0x00018F42
		public void #HV()
		{
			EventHandler eventHandler = this.#j;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BA7 RID: 7079 RVA: 0x0001AD66 File Offset: 0x00018F66
		public void #IV()
		{
			EventHandler eventHandler = this.#i;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BA8 RID: 7080 RVA: 0x0001AD8A File Offset: 0x00018F8A
		public void #JV(#fW #Lg)
		{
			EventHandler<#fW> eventHandler = this.#k;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #Lg);
		}

		// Token: 0x06001BA9 RID: 7081 RVA: 0x0001ADAA File Offset: 0x00018FAA
		public void #KV()
		{
			EventHandler eventHandler = this.#o;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BAA RID: 7082 RVA: 0x0001ADCE File Offset: 0x00018FCE
		public void #LV()
		{
			EventHandler eventHandler = this.#p;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BAB RID: 7083 RVA: 0x0001ADF2 File Offset: 0x00018FF2
		public void #MV()
		{
			EventHandler eventHandler = this.#q;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BAC RID: 7084 RVA: 0x0001AE16 File Offset: 0x00019016
		public void #NV()
		{
			EventHandler eventHandler = this.#r;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BAD RID: 7085 RVA: 0x0001AE3A File Offset: 0x0001903A
		public void #QV()
		{
			EventHandler eventHandler = this.#v;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BAE RID: 7086 RVA: 0x0001AE5E File Offset: 0x0001905E
		public void #RV()
		{
			EventHandler eventHandler = this.#w;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BAF RID: 7087 RVA: 0x0001AE82 File Offset: 0x00019082
		public void #SV()
		{
			EventHandler eventHandler = this.#y;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x06001BB0 RID: 7088 RVA: 0x0001AEA6 File Offset: 0x000190A6
		public void #TV()
		{
			EventHandler eventHandler = this.#z;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, EventArgs.Empty);
		}

		// Token: 0x04000AD1 RID: 2769
		[CompilerGenerated]
		private EventHandler<#3V> #a;

		// Token: 0x04000AD2 RID: 2770
		[CompilerGenerated]
		private EventHandler<#cW> #b;

		// Token: 0x04000AD3 RID: 2771
		[CompilerGenerated]
		private EventHandler #c;

		// Token: 0x04000AD4 RID: 2772
		[CompilerGenerated]
		private EventHandler #d;

		// Token: 0x04000AD5 RID: 2773
		[CompilerGenerated]
		private EventHandler #e;

		// Token: 0x04000AD6 RID: 2774
		[CompilerGenerated]
		private EventHandler #f;

		// Token: 0x04000AD7 RID: 2775
		[CompilerGenerated]
		private EventHandler #g;

		// Token: 0x04000AD8 RID: 2776
		[CompilerGenerated]
		private EventHandler #h;

		// Token: 0x04000AD9 RID: 2777
		[CompilerGenerated]
		private EventHandler #i;

		// Token: 0x04000ADA RID: 2778
		[CompilerGenerated]
		private EventHandler #j;

		// Token: 0x04000ADB RID: 2779
		[CompilerGenerated]
		private EventHandler<#fW> #k;

		// Token: 0x04000ADC RID: 2780
		[CompilerGenerated]
		private EventHandler<#BU> #l;

		// Token: 0x04000ADD RID: 2781
		[CompilerGenerated]
		private EventHandler #m;

		// Token: 0x04000ADE RID: 2782
		[CompilerGenerated]
		private EventHandler #n;

		// Token: 0x04000ADF RID: 2783
		[CompilerGenerated]
		private EventHandler #o;

		// Token: 0x04000AE0 RID: 2784
		[CompilerGenerated]
		private EventHandler #p;

		// Token: 0x04000AE1 RID: 2785
		[CompilerGenerated]
		private EventHandler #q;

		// Token: 0x04000AE2 RID: 2786
		[CompilerGenerated]
		private EventHandler #r;

		// Token: 0x04000AE3 RID: 2787
		[CompilerGenerated]
		private EventHandler #s;

		// Token: 0x04000AE4 RID: 2788
		[CompilerGenerated]
		private EventHandler<#jW> #t;

		// Token: 0x04000AE5 RID: 2789
		[CompilerGenerated]
		private EventHandler<#QJb> #u;

		// Token: 0x04000AE6 RID: 2790
		[CompilerGenerated]
		private EventHandler #v;

		// Token: 0x04000AE7 RID: 2791
		[CompilerGenerated]
		private EventHandler #w;

		// Token: 0x04000AE8 RID: 2792
		[CompilerGenerated]
		private EventHandler #x;

		// Token: 0x04000AE9 RID: 2793
		[CompilerGenerated]
		private EventHandler #y;

		// Token: 0x04000AEA RID: 2794
		[CompilerGenerated]
		private EventHandler #z;
	}
}
