using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Tree;

namespace #00c
{
	// Token: 0x02000CB5 RID: 3253
	[DebuggerDisplay("TreeItem: {Header} | IsExpanded: {IsExpanded} | IsSelected: {IsSelected} | IsContextMenuEnabled: {IsContextMenuEnabled}")]
	internal class #o1c : NotifyPropertyChangedObjectBase, ITreeItemData
	{
		// Token: 0x06006A12 RID: 27154 RVA: 0x00053E07 File Offset: 0x00052007
		public #o1c(string #Ae)
		{
			this.#a = #Ae;
			this.#d = new ObservableCollection<IContextMenuItemData>();
			this.#b = false;
			this.#n = false;
		}

		// Token: 0x17001D39 RID: 7481
		// (get) Token: 0x06006A13 RID: 27155 RVA: 0x00053E2F File Offset: 0x0005202F
		// (set) Token: 0x06006A14 RID: 27156 RVA: 0x0019BEC4 File Offset: 0x0019A0C4
		public string Header
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					string propertyName = #Phc.#3hc(107450197);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#a = value;
					string propertyName2 = #Phc.#3hc(107450197);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D3A RID: 7482
		// (get) Token: 0x06006A15 RID: 27157 RVA: 0x00053E37 File Offset: 0x00052037
		// (set) Token: 0x06006A16 RID: 27158 RVA: 0x0019BF14 File Offset: 0x0019A114
		public ICommand Command
		{
			get
			{
				return this.#e;
			}
			set
			{
				for (;;)
				{
					if (this.#e == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107350928);
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
						this.#e = value;
						string propertyName2 = #Phc.#3hc(107350928);
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

		// Token: 0x17001D3B RID: 7483
		// (get) Token: 0x06006A17 RID: 27159 RVA: 0x00053E3F File Offset: 0x0005203F
		// (set) Token: 0x06006A18 RID: 27160 RVA: 0x0019BF68 File Offset: 0x0019A168
		public object CommandParameter
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
					string propertyName = #Phc.#3hc(107350883);
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
						string propertyName2 = #Phc.#3hc(107350883);
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

		// Token: 0x17001D3C RID: 7484
		// (get) Token: 0x06006A19 RID: 27161 RVA: 0x00053E47 File Offset: 0x00052047
		// (set) Token: 0x06006A1A RID: 27162 RVA: 0x0019BFBC File Offset: 0x0019A1BC
		public IEnumerable Items
		{
			get
			{
				return this.#c;
			}
			set
			{
				for (;;)
				{
					if (this.#c == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107453085);
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
						this.#c = value;
						string propertyName2 = #Phc.#3hc(107453085);
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

		// Token: 0x17001D3D RID: 7485
		// (get) Token: 0x06006A1B RID: 27163 RVA: 0x00053E4F File Offset: 0x0005204F
		// (set) Token: 0x06006A1C RID: 27164 RVA: 0x0019C010 File Offset: 0x0019A210
		public bool IsExpanded
		{
			get
			{
				return this.#g;
			}
			set
			{
				for (;;)
				{
					if (this.#g == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107408133);
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
						this.#g = value;
						string propertyName2 = #Phc.#3hc(107408133);
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

		// Token: 0x17001D3E RID: 7486
		// (get) Token: 0x06006A1D RID: 27165 RVA: 0x00053E57 File Offset: 0x00052057
		// (set) Token: 0x06006A1E RID: 27166 RVA: 0x0019C064 File Offset: 0x0019A264
		public bool IsSelected
		{
			get
			{
				return this.#h;
			}
			set
			{
				for (;;)
				{
					if (this.#h == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107407591);
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
						this.#h = value;
						string propertyName2 = #Phc.#3hc(107407591);
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

		// Token: 0x17001D3F RID: 7487
		// (get) Token: 0x06006A1F RID: 27167 RVA: 0x00053E5F File Offset: 0x0005205F
		// (set) Token: 0x06006A20 RID: 27168 RVA: 0x0019C0B8 File Offset: 0x0019A2B8
		public bool IsContextMenuEnabled
		{
			get
			{
				return this.#b;
			}
			set
			{
				for (;;)
				{
					if (this.#b == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107431397);
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
						this.#b = value;
						string propertyName2 = #Phc.#3hc(107431397);
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

		// Token: 0x17001D40 RID: 7488
		// (get) Token: 0x06006A21 RID: 27169 RVA: 0x00053E67 File Offset: 0x00052067
		public ICollection<IContextMenuItemData> ContextMenuItemsSource
		{
			get
			{
				return this.#d;
			}
		}

		// Token: 0x17001D41 RID: 7489
		// (get) Token: 0x06006A22 RID: 27170 RVA: 0x00053E6F File Offset: 0x0005206F
		// (set) Token: 0x06006A23 RID: 27171 RVA: 0x0019C10C File Offset: 0x0019A30C
		public bool IsMarkerEnabled
		{
			get
			{
				return this.#i;
			}
			set
			{
				for (;;)
				{
					if (this.#i == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107431368);
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
						this.#i = value;
						string propertyName2 = #Phc.#3hc(107431368);
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

		// Token: 0x17001D42 RID: 7490
		// (get) Token: 0x06006A24 RID: 27172 RVA: 0x00053E77 File Offset: 0x00052077
		// (set) Token: 0x06006A25 RID: 27173 RVA: 0x0019C160 File Offset: 0x0019A360
		public Color MarkerColor
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					string propertyName = #Phc.#3hc(107431379);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#j = value;
					string propertyName2 = #Phc.#3hc(107431379);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D43 RID: 7491
		// (get) Token: 0x06006A26 RID: 27174 RVA: 0x00053E7F File Offset: 0x0005207F
		// (set) Token: 0x06006A27 RID: 27175 RVA: 0x0019C1B0 File Offset: 0x0019A3B0
		public object Tag
		{
			get
			{
				return this.#k;
			}
			set
			{
				for (;;)
				{
					if (this.#k == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107431330);
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
						this.#k = value;
						string propertyName2 = #Phc.#3hc(107431330);
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

		// Token: 0x17001D44 RID: 7492
		// (get) Token: 0x06006A28 RID: 27176 RVA: 0x00053E87 File Offset: 0x00052087
		// (set) Token: 0x06006A29 RID: 27177 RVA: 0x0019C204 File Offset: 0x0019A404
		public bool ShrinkIconColumn
		{
			get
			{
				return this.#l;
			}
			set
			{
				for (;;)
				{
					if (this.#l == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107431357);
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
						this.#l = value;
						string propertyName2 = #Phc.#3hc(107431357);
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

		// Token: 0x17001D45 RID: 7493
		// (get) Token: 0x06006A2A RID: 27178 RVA: 0x00053E8F File Offset: 0x0005208F
		// (set) Token: 0x06006A2B RID: 27179 RVA: 0x0019C258 File Offset: 0x0019A458
		public object Icon
		{
			get
			{
				return this.#m;
			}
			set
			{
				for (;;)
				{
					if (this.#m == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107350937);
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
						this.#m = value;
						string propertyName2 = #Phc.#3hc(107350937);
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

		// Token: 0x17001D46 RID: 7494
		// (get) Token: 0x06006A2C RID: 27180 RVA: 0x00053E97 File Offset: 0x00052097
		// (set) Token: 0x06006A2D RID: 27181 RVA: 0x0019C2AC File Offset: 0x0019A4AC
		public bool IsIconVisible
		{
			get
			{
				return this.#n;
			}
			set
			{
				for (;;)
				{
					if (this.#n == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107431300);
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
						this.#n = value;
						string propertyName2 = #Phc.#3hc(107431300);
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

		// Token: 0x17001D47 RID: 7495
		// (get) Token: 0x06006A2E RID: 27182 RVA: 0x00053E9F File Offset: 0x0005209F
		// (set) Token: 0x06006A2F RID: 27183 RVA: 0x0019C300 File Offset: 0x0019A500
		public bool IsCheckable
		{
			get
			{
				return this.#o;
			}
			set
			{
				for (;;)
				{
					if (this.#o == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107466465);
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
						this.#o = value;
						string propertyName2 = #Phc.#3hc(107466465);
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

		// Token: 0x17001D48 RID: 7496
		// (get) Token: 0x06006A30 RID: 27184 RVA: 0x00053EA7 File Offset: 0x000520A7
		// (set) Token: 0x06006A31 RID: 27185 RVA: 0x0019C354 File Offset: 0x0019A554
		public bool IsChecked
		{
			get
			{
				return this.#p;
			}
			set
			{
				if (this.#p != value)
				{
					string propertyName = #Phc.#3hc(107407606);
					if (2 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#p = value;
					if (!false)
					{
						this.#n1c();
					}
					string propertyName2 = #Phc.#3hc(107407606);
					if (8 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D49 RID: 7497
		// (get) Token: 0x06006A32 RID: 27186 RVA: 0x00053EAF File Offset: 0x000520AF
		// (set) Token: 0x06006A33 RID: 27187 RVA: 0x0019C3AC File Offset: 0x0019A5AC
		public bool StaysOpenOnClick
		{
			get
			{
				return this.#q;
			}
			set
			{
				for (;;)
				{
					if (this.#q == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107431279);
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
						this.#q = value;
						string propertyName2 = #Phc.#3hc(107431279);
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

		// Token: 0x17001D4A RID: 7498
		// (get) Token: 0x06006A34 RID: 27188 RVA: 0x00053EB7 File Offset: 0x000520B7
		// (set) Token: 0x06006A35 RID: 27189 RVA: 0x0019C400 File Offset: 0x0019A600
		public bool IsSeparator
		{
			get
			{
				return this.#r;
			}
			set
			{
				for (;;)
				{
					if (this.#r == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107466480);
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
						this.#r = value;
						string propertyName2 = #Phc.#3hc(107466480);
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

		// Token: 0x1400019B RID: 411
		// (add) Token: 0x06006A36 RID: 27190 RVA: 0x0019C454 File Offset: 0x0019A654
		// (remove) Token: 0x06006A37 RID: 27191 RVA: 0x0019C4AC File Offset: 0x0019A6AC
		public event EventHandler IsCheckedChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#s;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#s, value2, eventHandler4);
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
						EventHandler eventHandler = this.#s;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#s, value2, eventHandler4);
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

		// Token: 0x06006A38 RID: 27192 RVA: 0x0019C504 File Offset: 0x0019A704
		protected virtual void #n1c()
		{
			EventHandler eventHandler = this.#s;
			EventHandler eventHandler2;
			if (!false)
			{
				eventHandler2 = eventHandler;
			}
			if (eventHandler2 != null)
			{
				EventHandler eventHandler3 = eventHandler2;
				EventArgs empty = EventArgs.Empty;
				if (!false)
				{
					eventHandler3(this, empty);
				}
			}
		}

		// Token: 0x04002B68 RID: 11112
		private string #a;

		// Token: 0x04002B69 RID: 11113
		private bool #b;

		// Token: 0x04002B6A RID: 11114
		private IEnumerable #c;

		// Token: 0x04002B6B RID: 11115
		private readonly ObservableCollection<IContextMenuItemData> #d;

		// Token: 0x04002B6C RID: 11116
		private ICommand #e;

		// Token: 0x04002B6D RID: 11117
		private object #f;

		// Token: 0x04002B6E RID: 11118
		private bool #g;

		// Token: 0x04002B6F RID: 11119
		private bool #h;

		// Token: 0x04002B70 RID: 11120
		private bool #i;

		// Token: 0x04002B71 RID: 11121
		private Color #j;

		// Token: 0x04002B72 RID: 11122
		private object #k;

		// Token: 0x04002B73 RID: 11123
		private bool #l;

		// Token: 0x04002B74 RID: 11124
		private object #m;

		// Token: 0x04002B75 RID: 11125
		private bool #n;

		// Token: 0x04002B76 RID: 11126
		private bool #o;

		// Token: 0x04002B77 RID: 11127
		private bool #p;

		// Token: 0x04002B78 RID: 11128
		private bool #q;

		// Token: 0x04002B79 RID: 11129
		private bool #r;

		// Token: 0x04002B7A RID: 11130
		[CompilerGenerated]
		private EventHandler #s;
	}
}
