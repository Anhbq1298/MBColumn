using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Controls;
using #7hc;
using #8Cc;
using #ezc;
using #NWc;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #IDc
{
	// Token: 0x02000B8F RID: 2959
	internal class #RHc : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, IEditionToolData, IGroupingEditionToolData, #8Hc, #ZIc
	{
		// Token: 0x0600610E RID: 24846 RVA: 0x0004FA03 File Offset: 0x0004DC03
		public #RHc()
		{
			this.#b = new CustomObservableCollection<#8Hc>();
		}

		// Token: 0x17001BA3 RID: 7075
		// (get) Token: 0x0600610F RID: 24847 RVA: 0x0004FA16 File Offset: 0x0004DC16
		// (set) Token: 0x06006110 RID: 24848 RVA: 0x0017C03C File Offset: 0x0017A23C
		public bool IsEnabled
		{
			get
			{
				if (!false)
				{
					this.#KHc();
				}
				return this.#a.IsEnabled;
			}
			set
			{
				if (-1 != 0)
				{
					this.#KHc();
				}
				if (this.#a.IsEnabled != value)
				{
					string propertyName = #Phc.#3hc(107408148);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IEditionToolData editionToolData = this.#a;
					if (5 != 0)
					{
						editionToolData.IsEnabled = value;
					}
					string propertyName2 = #Phc.#3hc(107408148);
					if (-1 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001BA4 RID: 7076
		// (get) Token: 0x06006111 RID: 24849 RVA: 0x0004FA2F File Offset: 0x0004DC2F
		// (set) Token: 0x06006112 RID: 24850 RVA: 0x0017C0A4 File Offset: 0x0017A2A4
		public bool IsWorking
		{
			get
			{
				if (!false)
				{
					this.#KHc();
				}
				return this.#a.IsWorking;
			}
			set
			{
				if (-1 != 0)
				{
					this.#KHc();
				}
				if (this.#a.IsWorking != value)
				{
					string propertyName = #Phc.#3hc(107412993);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IEditionToolData editionToolData = this.#a;
					if (5 != 0)
					{
						editionToolData.IsWorking = value;
					}
					string propertyName2 = #Phc.#3hc(107412993);
					if (-1 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001BA5 RID: 7077
		// (get) Token: 0x06006113 RID: 24851 RVA: 0x0004FA48 File Offset: 0x0004DC48
		// (set) Token: 0x06006114 RID: 24852 RVA: 0x0017C10C File Offset: 0x0017A30C
		public string Header
		{
			get
			{
				if (!false)
				{
					this.#KHc();
				}
				return this.#a.Header;
			}
			set
			{
				if (2 != 0)
				{
					this.#KHc();
				}
				if (!(this.#a.Header != value))
				{
					goto IL_47;
				}
				IL_18:
				if (!false)
				{
					string propertyName = #Phc.#3hc(107450197);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IEditionToolData editionToolData = this.#a;
					if (4 != 0)
					{
						editionToolData.Header = value;
					}
				}
				string propertyName2 = #Phc.#3hc(107450197);
				if (6 != 0)
				{
					base.RaisePropertyChanged(propertyName2);
				}
				IL_47:
				if (!false && !false)
				{
					return;
				}
				goto IL_18;
			}
		}

		// Token: 0x17001BA6 RID: 7078
		// (get) Token: 0x06006115 RID: 24853 RVA: 0x0004FA61 File Offset: 0x0004DC61
		// (set) Token: 0x06006116 RID: 24854 RVA: 0x0017C184 File Offset: 0x0017A384
		public Image IconImage
		{
			get
			{
				if (!false)
				{
					this.#KHc();
				}
				return this.#a.IconImage;
			}
			set
			{
				if (2 != 0)
				{
					this.#KHc();
				}
				if (object.Equals(this.#a.IconImage, value))
				{
					goto IL_47;
				}
				IL_18:
				if (!false)
				{
					string propertyName = #Phc.#3hc(107415578);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IEditionToolData editionToolData = this.#a;
					if (4 != 0)
					{
						editionToolData.IconImage = value;
					}
				}
				string propertyName2 = #Phc.#3hc(107415578);
				if (6 != 0)
				{
					base.RaisePropertyChanged(propertyName2);
				}
				IL_47:
				if (!false && !false)
				{
					return;
				}
				goto IL_18;
			}
		}

		// Token: 0x17001BA7 RID: 7079
		// (get) Token: 0x06006117 RID: 24855 RVA: 0x0004FA7A File Offset: 0x0004DC7A
		// (set) Token: 0x06006118 RID: 24856 RVA: 0x0017C1FC File Offset: 0x0017A3FC
		public object ToolOptionsEditor
		{
			get
			{
				if (!false)
				{
					this.#KHc();
				}
				return this.#a.ToolOptionsEditor;
			}
			set
			{
				if (-1 != 0)
				{
					this.#KHc();
				}
				if (this.#a.ToolOptionsEditor != value)
				{
					string propertyName = #Phc.#3hc(107416045);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IEditionToolData editionToolData = this.#a;
					if (5 != 0)
					{
						editionToolData.ToolOptionsEditor = value;
					}
					string propertyName2 = #Phc.#3hc(107416045);
					if (-1 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001BA8 RID: 7080
		// (get) Token: 0x06006119 RID: 24857 RVA: 0x0004FA93 File Offset: 0x0004DC93
		// (set) Token: 0x0600611A RID: 24858 RVA: 0x0017C264 File Offset: 0x0017A464
		public object ToolCommandsPanel
		{
			get
			{
				if (!false)
				{
					this.#KHc();
				}
				return this.#a.ToolCommandsPanel;
			}
			set
			{
				if (-1 != 0)
				{
					this.#KHc();
				}
				if (this.#a.ToolCommandsPanel != value)
				{
					string propertyName = #Phc.#3hc(107416052);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IEditionToolData editionToolData = this.#a;
					if (5 != 0)
					{
						editionToolData.ToolCommandsPanel = value;
					}
					string propertyName2 = #Phc.#3hc(107416052);
					if (-1 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001BA9 RID: 7081
		// (get) Token: 0x0600611B RID: 24859 RVA: 0x0004FAAC File Offset: 0x0004DCAC
		// (set) Token: 0x0600611C RID: 24860 RVA: 0x0017C2CC File Offset: 0x0017A4CC
		public bool IsSelected
		{
			get
			{
				if (!false)
				{
					this.#KHc();
				}
				return this.#a.IsSelected;
			}
			set
			{
				if (-1 != 0)
				{
					this.#KHc();
				}
				if (this.#a.IsSelected != value)
				{
					string propertyName = #Phc.#3hc(107407591);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IEditionToolData editionToolData = this.#a;
					if (5 != 0)
					{
						editionToolData.IsSelected = value;
					}
					string propertyName2 = #Phc.#3hc(107407591);
					if (-1 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001BAA RID: 7082
		// (get) Token: 0x0600611D RID: 24861 RVA: 0x0004FAC5 File Offset: 0x0004DCC5
		public bool IsOrthogonalModeSupported
		{
			get
			{
				if (!false)
				{
					this.#KHc();
				}
				return this.#a.IsOrthogonalModeSupported;
			}
		}

		// Token: 0x17001BAB RID: 7083
		// (get) Token: 0x0600611E RID: 24862 RVA: 0x0004FADE File Offset: 0x0004DCDE
		// (set) Token: 0x0600611F RID: 24863 RVA: 0x0017C334 File Offset: 0x0017A534
		public HelpID HelpId
		{
			get
			{
				if (!false)
				{
					this.#KHc();
				}
				return this.SelectedEditionTool.HelpId;
			}
			set
			{
				if (-1 != 0)
				{
					this.#KHc();
				}
				if (this.SelectedEditionTool.HelpId != value)
				{
					string propertyName = #Phc.#3hc(107466474);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IEditionToolData editionToolData = this.SelectedEditionTool;
					if (5 != 0)
					{
						editionToolData.HelpId = value;
					}
					string propertyName2 = #Phc.#3hc(107466474);
					if (-1 != 0)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001BAC RID: 7084
		// (get) Token: 0x06006120 RID: 24864 RVA: 0x0004FAF7 File Offset: 0x0004DCF7
		public RichToolTipContent ToolTipContent
		{
			get
			{
				if (!false)
				{
					this.#KHc();
				}
				return this.SelectedEditionTool.ToolTipContent;
			}
		}

		// Token: 0x17001BAD RID: 7085
		// (get) Token: 0x06006121 RID: 24865 RVA: 0x0004FB10 File Offset: 0x0004DD10
		public IEnumerable<IEditionToolData> ChildTools
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x17001BAE RID: 7086
		// (get) Token: 0x06006122 RID: 24866 RVA: 0x0004FB18 File Offset: 0x0004DD18
		// (set) Token: 0x06006123 RID: 24867 RVA: 0x0004FB20 File Offset: 0x0004DD20
		protected #8Hc SelectedEditionTool { get; set; }

		// Token: 0x17001BAF RID: 7087
		// (get) Token: 0x06006124 RID: 24868 RVA: 0x0004FB29 File Offset: 0x0004DD29
		// (set) Token: 0x06006125 RID: 24869 RVA: 0x0017C39C File Offset: 0x0017A59C
		public IEditionToolData SelectedEditionToolData
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (false || this.#a != value)
				{
					while (value != null)
					{
						#8Hc #8Hc = this.SelectedEditionTool;
						#8Hc #8Hc2;
						if (3 != 0)
						{
							#8Hc2 = #8Hc;
						}
						if (!false)
						{
							string propertyName = #Phc.#3hc(107415942);
							if (6 != 0)
							{
								base.RaisePropertyChanging(propertyName);
							}
							this.#a = value;
							if (7 != 0)
							{
								#8Hc #8Hc3 = value as #8Hc;
								#8Hc #8Hc4;
								if (!false)
								{
									#8Hc4 = #8Hc3;
								}
								#8Hc #8Hc5 = #8Hc4;
								if (true)
								{
									this.SelectedEditionTool = #8Hc5;
								}
								#8Hc #MHc = #8Hc2;
								#8Hc #NHc = #8Hc4;
								if (!false)
								{
									this.#LHc(#MHc, #NHc);
								}
							}
							string propertyName2 = #Phc.#3hc(107415942);
							if (6 != 0)
							{
								base.RaisePropertyChanged(propertyName2);
							}
							base.RaisePropertyChanged(null);
							break;
						}
					}
				}
			}
		}

		// Token: 0x17001BB0 RID: 7088
		// (get) Token: 0x06006126 RID: 24870 RVA: 0x0004FB31 File Offset: 0x0004DD31
		// (set) Token: 0x06006127 RID: 24871 RVA: 0x0004FB39 File Offset: 0x0004DD39
		public #WWc StructuralModel { get; protected set; }

		// Token: 0x17001BB1 RID: 7089
		// (get) Token: 0x06006128 RID: 24872 RVA: 0x0004FB42 File Offset: 0x0004DD42
		// (set) Token: 0x06006129 RID: 24873 RVA: 0x0004FB4A File Offset: 0x0004DD4A
		public #bDc UndoManager { get; protected set; }

		// Token: 0x17001BB2 RID: 7090
		// (get) Token: 0x0600612A RID: 24874 RVA: 0x0004FB53 File Offset: 0x0004DD53
		// (set) Token: 0x0600612B RID: 24875 RVA: 0x0004FB5B File Offset: 0x0004DD5B
		public #rBc ErrorsHandlingService { get; protected set; }

		// Token: 0x0600612C RID: 24876 RVA: 0x0004FB64 File Offset: 0x0004DD64
		public void #5b()
		{
			if (!false)
			{
				this.#KHc();
			}
			#8Hc #8Hc = this.SelectedEditionTool;
			if (!false)
			{
				#8Hc.#5b();
			}
		}

		// Token: 0x0600612D RID: 24877 RVA: 0x0004FB83 File Offset: 0x0004DD83
		public void #0kb()
		{
			if (!false)
			{
				this.#KHc();
			}
			#8Hc #8Hc = this.SelectedEditionTool;
			if (!false)
			{
				#8Hc.#0kb();
			}
		}

		// Token: 0x0600612E RID: 24878 RVA: 0x0004FBA2 File Offset: 0x0004DDA2
		public void #1kb()
		{
			if (!false)
			{
				this.#KHc();
			}
			#8Hc #8Hc = this.SelectedEditionTool;
			if (!false)
			{
				#8Hc.#1kb();
			}
		}

		// Token: 0x0600612F RID: 24879 RVA: 0x0004FBC1 File Offset: 0x0004DDC1
		public void AddTool(IEditionToolData editionToolData)
		{
			Collection<#8Hc> collection = this.#b;
			#8Hc item = (#8Hc)editionToolData;
			if (!false)
			{
				collection.Add(item);
			}
		}

		// Token: 0x06006130 RID: 24880 RVA: 0x0004FBDB File Offset: 0x0004DDDB
		public void RemoveTool(IEditionToolData editionToolData)
		{
			this.#b.Remove((#8Hc)editionToolData);
		}

		// Token: 0x06006131 RID: 24881 RVA: 0x0017C434 File Offset: 0x0017A634
		public void #fzb(Point3D #HAb, bool #gzb)
		{
			#8Hc #8Hc = this.SelectedEditionTool;
			#8Hc #8Hc2;
			if (!false)
			{
				#8Hc2 = #8Hc;
			}
			if (#8Hc2 != null)
			{
				#8Hc #8Hc3 = #8Hc2;
				if (!false)
				{
					#8Hc3.#fzb(#HAb, #gzb);
				}
			}
		}

		// Token: 0x1400017C RID: 380
		// (add) Token: 0x06006132 RID: 24882 RVA: 0x0017C464 File Offset: 0x0017A664
		// (remove) Token: 0x06006133 RID: 24883 RVA: 0x0017C4BC File Offset: 0x0017A6BC
		public event EventHandler StartedWorking
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#g;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#g, value2, eventHandler4);
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
						EventHandler eventHandler = this.#g;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#g, value2, eventHandler4);
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

		// Token: 0x1400017D RID: 381
		// (add) Token: 0x06006134 RID: 24884 RVA: 0x0017C514 File Offset: 0x0017A714
		// (remove) Token: 0x06006135 RID: 24885 RVA: 0x0017C56C File Offset: 0x0017A76C
		public event EventHandler FinishedWorking
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

		// Token: 0x1400017E RID: 382
		// (add) Token: 0x06006136 RID: 24886 RVA: 0x0017C5C4 File Offset: 0x0017A7C4
		// (remove) Token: 0x06006137 RID: 24887 RVA: 0x0017C61C File Offset: 0x0017A81C
		public event EventHandler<CancelEventArgs> PreviewStartedWorking
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler<CancelEventArgs> eventHandler2;
					if (!false)
					{
						EventHandler<CancelEventArgs> eventHandler = this.#i;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler<CancelEventArgs> eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler<CancelEventArgs> eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler<CancelEventArgs> eventHandler5 = (EventHandler<CancelEventArgs>)Delegate.Combine(eventHandler4, value);
							EventHandler<CancelEventArgs> value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler<CancelEventArgs> eventHandler6 = Interlocked.CompareExchange<EventHandler<CancelEventArgs>>(ref this.#i, value2, eventHandler4);
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
					EventHandler<CancelEventArgs> eventHandler2;
					if (!false)
					{
						EventHandler<CancelEventArgs> eventHandler = this.#i;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler<CancelEventArgs> eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler<CancelEventArgs> eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler<CancelEventArgs> eventHandler5 = (EventHandler<CancelEventArgs>)Delegate.Remove(eventHandler4, value);
							EventHandler<CancelEventArgs> value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler<CancelEventArgs> eventHandler6 = Interlocked.CompareExchange<EventHandler<CancelEventArgs>>(ref this.#i, value2, eventHandler4);
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

		// Token: 0x06006138 RID: 24888 RVA: 0x0017C674 File Offset: 0x0017A874
		protected virtual void #IHc()
		{
			EventHandler eventHandler = this.#g;
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

		// Token: 0x06006139 RID: 24889 RVA: 0x0017C6A8 File Offset: 0x0017A8A8
		protected virtual void #JHc()
		{
			EventHandler eventHandler = this.#h;
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

		// Token: 0x0600613A RID: 24890 RVA: 0x0017C6DC File Offset: 0x0017A8DC
		protected virtual void #0Ec(CancelEventArgs #He)
		{
			EventHandler<CancelEventArgs> eventHandler = this.#i;
			EventHandler<CancelEventArgs> eventHandler2;
			if (!false)
			{
				eventHandler2 = eventHandler;
			}
			if (eventHandler2 != null)
			{
				EventHandler<CancelEventArgs> eventHandler3 = eventHandler2;
				if (!false)
				{
					eventHandler3(this, #He);
				}
			}
		}

		// Token: 0x0600613B RID: 24891 RVA: 0x0004FBEF File Offset: 0x0004DDEF
		private void #KHc()
		{
			if (this.#a == null || this.SelectedEditionTool == null)
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x0600613C RID: 24892 RVA: 0x0017C70C File Offset: 0x0017A90C
		private void #LHc(#8Hc #MHc, #8Hc #NHc)
		{
			for (;;)
			{
				if (#MHc == null)
				{
					goto IL_4D;
				}
				IL_03:
				if (false)
				{
					continue;
				}
				EventHandler value = new EventHandler(this.#QHc);
				if (7 != 0)
				{
					#MHc.StartedWorking -= value;
				}
				EventHandler value2 = new EventHandler(this.#PHc);
				if (!false)
				{
					#MHc.FinishedWorking -= value2;
				}
				EventHandler<CancelEventArgs> value3 = new EventHandler<CancelEventArgs>(this.#OHc);
				if (!true)
				{
					goto IL_45;
				}
				#MHc.PreviewStartedWorking -= value3;
				goto IL_45;
				IL_4D:
				if (#NHc == null)
				{
					return;
				}
				EventHandler value4 = new EventHandler(this.#QHc);
				if (8 != 0)
				{
					#NHc.StartedWorking -= value4;
				}
				EventHandler value5 = new EventHandler(this.#PHc);
				if (4 != 0)
				{
					#NHc.FinishedWorking -= value5;
				}
				#NHc.PreviewStartedWorking -= this.#OHc;
				#NHc.StartedWorking += this.#QHc;
				if (false)
				{
					return;
				}
				#NHc.FinishedWorking += this.#PHc;
				if (5 == 0)
				{
					goto IL_03;
				}
				if (!false)
				{
					break;
				}
				IL_45:
				if (false)
				{
					goto IL_4D;
				}
				#MHc.#0kb();
				goto IL_4D;
			}
			#NHc.PreviewStartedWorking += this.#OHc;
			if (this.IsSelected)
			{
				#NHc.#5b();
			}
		}

		// Token: 0x0600613D RID: 24893 RVA: 0x0004FC07 File Offset: 0x0004DE07
		private void #OHc(object #Ge, CancelEventArgs #He)
		{
			if (!false)
			{
				this.#0Ec(#He);
			}
		}

		// Token: 0x0600613E RID: 24894 RVA: 0x0004FC17 File Offset: 0x0004DE17
		private void #PHc(object #Ge, EventArgs #He)
		{
			if (6 != 0)
			{
				this.#JHc();
			}
		}

		// Token: 0x0600613F RID: 24895 RVA: 0x0004FC25 File Offset: 0x0004DE25
		private void #QHc(object #Ge, EventArgs #He)
		{
			if (6 != 0)
			{
				this.#IHc();
			}
		}

		// Token: 0x040027C5 RID: 10181
		private IEditionToolData #a;

		// Token: 0x040027C6 RID: 10182
		private readonly CustomObservableCollection<#8Hc> #b;

		// Token: 0x040027C7 RID: 10183
		[CompilerGenerated]
		private #8Hc #c;

		// Token: 0x040027C8 RID: 10184
		[CompilerGenerated]
		private #WWc #d;

		// Token: 0x040027C9 RID: 10185
		[CompilerGenerated]
		private #bDc #e;

		// Token: 0x040027CA RID: 10186
		[CompilerGenerated]
		private #rBc #f;

		// Token: 0x040027CB RID: 10187
		[CompilerGenerated]
		private EventHandler #g;

		// Token: 0x040027CC RID: 10188
		[CompilerGenerated]
		private EventHandler #h;

		// Token: 0x040027CD RID: 10189
		[CompilerGenerated]
		private EventHandler<CancelEventArgs> #i;
	}
}
