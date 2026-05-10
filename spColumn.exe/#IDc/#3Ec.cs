using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using #7hc;
using #YKc;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #IDc
{
	// Token: 0x02000434 RID: 1076
	internal abstract class #3Ec : NotifyPropertyChangedObjectWithValidation, INotifyPropertyChanged, IEditionToolData
	{
		// Token: 0x06002736 RID: 10038 RVA: 0x00024B72 File Offset: 0x00022D72
		protected #3Ec(IModelEditorControl #Smb)
		{
			this.#a = #Smb;
			this.IsOrthogonalModeSupported = false;
		}

		// Token: 0x17000D2E RID: 3374
		// (get) Token: 0x06002737 RID: 10039 RVA: 0x00024B88 File Offset: 0x00022D88
		// (set) Token: 0x06002738 RID: 10040 RVA: 0x00024B90 File Offset: 0x00022D90
		public RichToolTipContent ToolTipContent { get; protected set; }

		// Token: 0x17000D2F RID: 3375
		// (get) Token: 0x06002739 RID: 10041 RVA: 0x00024B99 File Offset: 0x00022D99
		// (set) Token: 0x0600273A RID: 10042 RVA: 0x000D84BC File Offset: 0x000D66BC
		public bool IsEnabled
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
						this.#b = value;
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

		// Token: 0x17000D30 RID: 3376
		// (get) Token: 0x0600273B RID: 10043 RVA: 0x00024BA1 File Offset: 0x00022DA1
		// (set) Token: 0x0600273C RID: 10044 RVA: 0x000D8510 File Offset: 0x000D6710
		public bool IsWorking
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (!true)
				{
					goto IL_33;
				}
				if (this.#c == value)
				{
					goto IL_3A;
				}
				IL_0C:
				string propertyName = #Phc.#3hc(107412993);
				if (!false)
				{
					base.RaisePropertyChanging(propertyName);
				}
				this.#c = value;
				string propertyName2 = #Phc.#3hc(107412993);
				if (!false)
				{
					base.RaisePropertyChanged(propertyName2);
				}
				IL_33:
				if (!false)
				{
					this.#1Ec(value);
				}
				IL_3A:
				if (!false)
				{
					return;
				}
				goto IL_0C;
			}
		}

		// Token: 0x17000D31 RID: 3377
		// (get) Token: 0x0600273D RID: 10045 RVA: 0x00024BA9 File Offset: 0x00022DA9
		// (set) Token: 0x0600273E RID: 10046 RVA: 0x000D8570 File Offset: 0x000D6770
		public string Header
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					string propertyName = #Phc.#3hc(107450197);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#d = value;
					string propertyName2 = #Phc.#3hc(107450197);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17000D32 RID: 3378
		// (get) Token: 0x0600273F RID: 10047 RVA: 0x00024BB1 File Offset: 0x00022DB1
		// (set) Token: 0x06002740 RID: 10048 RVA: 0x000D85C0 File Offset: 0x000D67C0
		public Image IconImage
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
					string propertyName = #Phc.#3hc(107415578);
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
						string propertyName2 = #Phc.#3hc(107415578);
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

		// Token: 0x17000D33 RID: 3379
		// (get) Token: 0x06002741 RID: 10049 RVA: 0x00024BB9 File Offset: 0x00022DB9
		// (set) Token: 0x06002742 RID: 10050 RVA: 0x000D8614 File Offset: 0x000D6814
		public object ToolOptionsEditor
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
					string propertyName = #Phc.#3hc(107416045);
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
						string propertyName2 = #Phc.#3hc(107416045);
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

		// Token: 0x17000D34 RID: 3380
		// (get) Token: 0x06002743 RID: 10051 RVA: 0x00024BC1 File Offset: 0x00022DC1
		// (set) Token: 0x06002744 RID: 10052 RVA: 0x000D8668 File Offset: 0x000D6868
		public bool IsSelected
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
						this.#g = value;
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

		// Token: 0x17000D35 RID: 3381
		// (get) Token: 0x06002745 RID: 10053 RVA: 0x00024BC9 File Offset: 0x00022DC9
		// (set) Token: 0x06002746 RID: 10054 RVA: 0x000D86BC File Offset: 0x000D68BC
		public HelpID HelpId
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					string propertyName = #Phc.#3hc(107466474);
					if (3 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#j = value;
					#9Kc #9Kc = this.ToolOptionsEditor as #9Kc;
					#9Kc #9Kc2;
					if (8 != 0)
					{
						#9Kc2 = #9Kc;
					}
					if (#9Kc2 != null)
					{
						#9Kc #9Kc3 = #9Kc2;
						if (4 != 0)
						{
							#9Kc3.HelpId = value;
						}
					}
					string propertyName2 = #Phc.#3hc(107466474);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17000D36 RID: 3382
		// (get) Token: 0x06002747 RID: 10055 RVA: 0x00024BD1 File Offset: 0x00022DD1
		// (set) Token: 0x06002748 RID: 10056 RVA: 0x000D872C File Offset: 0x000D692C
		public bool IsActive
		{
			get
			{
				return this.#h;
			}
			protected set
			{
				for (;;)
				{
					if (this.#h == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107362485);
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
						string propertyName2 = #Phc.#3hc(107362485);
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

		// Token: 0x17000D37 RID: 3383
		// (get) Token: 0x06002749 RID: 10057 RVA: 0x00024BD9 File Offset: 0x00022DD9
		// (set) Token: 0x0600274A RID: 10058 RVA: 0x000D8780 File Offset: 0x000D6980
		public object ToolCommandsPanel
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
					string propertyName = #Phc.#3hc(107416052);
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
						string propertyName2 = #Phc.#3hc(107416052);
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

		// Token: 0x17000D38 RID: 3384
		// (get) Token: 0x0600274B RID: 10059 RVA: 0x00024BE1 File Offset: 0x00022DE1
		// (set) Token: 0x0600274C RID: 10060 RVA: 0x00024BE9 File Offset: 0x00022DE9
		public bool IsOrthogonalModeSupported { get; protected set; }

		// Token: 0x0600274D RID: 10061 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #CEc(MouseButtonEventArgs #4kb)
		{
		}

		// Token: 0x0600274E RID: 10062 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #DEc(MouseButtonEventArgs #4kb)
		{
		}

		// Token: 0x0600274F RID: 10063 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #3kb(MouseButtonEventArgs #4kb)
		{
		}

		// Token: 0x06002750 RID: 10064 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #5kb(MouseButtonEventArgs #4kb)
		{
		}

		// Token: 0x06002751 RID: 10065 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #EEc(MouseEventArgs #FEc)
		{
		}

		// Token: 0x06002752 RID: 10066 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #GEc(KeyEventArgs #HA)
		{
		}

		// Token: 0x06002753 RID: 10067 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #2kb(KeyEventArgs #HA)
		{
		}

		// Token: 0x06002754 RID: 10068 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #HEc(Point3D #IEc, Point3D #Kzb)
		{
		}

		// Token: 0x06002755 RID: 10069 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #JEc(CameraDistanceChangedEventArgs #KEc)
		{
		}

		// Token: 0x06002756 RID: 10070 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #Emb(EventArgs #HA)
		{
		}

		// Token: 0x06002757 RID: 10071 RVA: 0x00024BF2 File Offset: 0x00022DF2
		protected void #LEc(params ModelEditorControlEventType[] #MEc)
		{
			IModelEditorControl modelEditorControl = this.#a;
			if (2 != 0)
			{
				modelEditorControl.UnregisterEvents(#MEc);
			}
		}

		// Token: 0x06002758 RID: 10072 RVA: 0x00009E6A File Offset: 0x0000806A
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		[Conditional("DEBUG")]
		protected void #NEc(string #5)
		{
		}

		// Token: 0x06002759 RID: 10073 RVA: 0x000D87D4 File Offset: 0x000D69D4
		public virtual void #5b()
		{
			if (this.IsActive)
			{
				return;
			}
			IModelEditorControl modelEditorControl = this.#a;
			EventHandler<MouseButtonEventArgs> value = new EventHandler<MouseButtonEventArgs>(this.#XEc);
			if (!false)
			{
				modelEditorControl.EditorMouseLeftButtonDown += value;
			}
			IModelEditorControl modelEditorControl2 = this.#a;
			EventHandler<MouseButtonEventArgs> value2 = new EventHandler<MouseButtonEventArgs>(this.#WEc);
			if (5 != 0)
			{
				modelEditorControl2.EditorMouseLeftButtonUp += value2;
			}
			IModelEditorControl modelEditorControl3 = this.#a;
			EventHandler<MouseEventArgs> value3 = new EventHandler<MouseEventArgs>(this.#VEc);
			if (!false)
			{
				modelEditorControl3.EditorMouseMove += value3;
			}
			IModelEditorControl modelEditorControl4 = this.#a;
			EventHandler<MouseButtonEventArgs> value4 = new EventHandler<MouseButtonEventArgs>(this.#ZEc);
			if (!false)
			{
				modelEditorControl4.EditorMouseRightButtonDown += value4;
			}
			do
			{
				IModelEditorControl modelEditorControl5 = this.#a;
				EventHandler<MouseButtonEventArgs> value5 = new EventHandler<MouseButtonEventArgs>(this.#YEc);
				if (6 != 0)
				{
					modelEditorControl5.EditorMouseRightButtonUp += value5;
				}
				IModelEditorControl modelEditorControl6 = this.#a;
				EventHandler<KeyEventArgs> value6 = new EventHandler<KeyEventArgs>(this.#UEc);
				if (!false)
				{
					modelEditorControl6.EditorKeyDown += value6;
				}
				this.#a.EditorKeyUp += this.#TEc;
				this.#a.EditorMousePositionChanged += this.#SEc;
				this.#a.CameraDistanceChanged += this.#REc;
				this.#a.CameraChanged += this.#QEc;
				this.#a.PreviewEditorMouseLeftButtonDown += this.#PEc;
				this.IsActive = true;
			}
			while (8 == 0);
			base.RaisePropertyChanged(null);
		}

		// Token: 0x0600275A RID: 10074 RVA: 0x000D894C File Offset: 0x000D6B4C
		public virtual void #0kb()
		{
			do
			{
				ModelEditorControlEventType[] #MEc = new ModelEditorControlEventType[0];
				if (!false)
				{
					this.#LEc(#MEc);
				}
				IModelEditorControl modelEditorControl = this.#a;
				EventHandler<MouseButtonEventArgs> value = new EventHandler<MouseButtonEventArgs>(this.#XEc);
				if (8 != 0)
				{
					modelEditorControl.EditorMouseLeftButtonDown -= value;
				}
				IModelEditorControl modelEditorControl2 = this.#a;
				EventHandler<MouseButtonEventArgs> value2 = new EventHandler<MouseButtonEventArgs>(this.#WEc);
				if (!false)
				{
					modelEditorControl2.EditorMouseLeftButtonUp -= value2;
				}
			}
			while (!true);
			IModelEditorControl modelEditorControl3 = this.#a;
			EventHandler<MouseEventArgs> value3 = new EventHandler<MouseEventArgs>(this.#VEc);
			if (!false)
			{
				modelEditorControl3.EditorMouseMove -= value3;
			}
			IModelEditorControl modelEditorControl4 = this.#a;
			EventHandler<MouseButtonEventArgs> value4 = new EventHandler<MouseButtonEventArgs>(this.#ZEc);
			if (4 != 0)
			{
				modelEditorControl4.EditorMouseRightButtonDown -= value4;
			}
			if (!false)
			{
				IModelEditorControl modelEditorControl5 = this.#a;
				EventHandler<MouseButtonEventArgs> value5 = new EventHandler<MouseButtonEventArgs>(this.#YEc);
				if (!false)
				{
					modelEditorControl5.EditorMouseRightButtonUp -= value5;
				}
				this.#a.EditorKeyDown -= this.#UEc;
			}
			this.#a.EditorKeyUp -= this.#TEc;
			this.#a.EditorMousePositionChanged -= this.#SEc;
			this.#a.CameraDistanceChanged -= this.#REc;
			this.#a.CameraChanged -= this.#QEc;
			this.#a.PreviewEditorMouseLeftButtonDown -= this.#PEc;
			this.IsActive = false;
		}

		// Token: 0x0600275B RID: 10075 RVA: 0x000D8AC0 File Offset: 0x000D6CC0
		public virtual void #OEc(MouseButtonEventArgs #4kb)
		{
			if (#4kb != null)
			{
				CancelEventArgs cancelEventArgs = new CancelEventArgs();
				CancelEventArgs cancelEventArgs2;
				if (3 != 0)
				{
					cancelEventArgs2 = cancelEventArgs;
				}
				if (2 != 0)
				{
					CancelEventArgs #He = cancelEventArgs2;
					if (2 != 0)
					{
						this.#0Ec(#He);
					}
					while (!false)
					{
						if (cancelEventArgs2.Cancel)
						{
							bool handled = true;
							if (true)
							{
								#4kb.Handled = handled;
							}
						}
						if (8 != 0)
						{
							return;
						}
					}
				}
			}
		}

		// Token: 0x0600275C RID: 10076 RVA: 0x00024C07 File Offset: 0x00022E07
		private void #PEc(object #Ge, MouseButtonEventArgs #He)
		{
			if (this.IsActive && 7 != 0)
			{
				this.#OEc(#He);
			}
		}

		// Token: 0x0600275D RID: 10077 RVA: 0x00024C1F File Offset: 0x00022E1F
		private void #QEc(object #Ge, EventArgs #He)
		{
			if (this.#h && 7 != 0)
			{
				this.#Emb(#He);
			}
		}

		// Token: 0x0600275E RID: 10078 RVA: 0x00024C37 File Offset: 0x00022E37
		private void #REc(object #Ge, CameraDistanceChangedEventArgs #He)
		{
			if (this.IsActive && 7 != 0)
			{
				this.#JEc(#He);
			}
		}

		// Token: 0x0600275F RID: 10079 RVA: 0x00024C4F File Offset: 0x00022E4F
		private void #SEc(object #Ge, SelectedItemChangedEventArgs<Point3D> #He)
		{
			if (this.IsActive)
			{
				Point3D previousItem = #He.PreviousItem;
				Point3D newItem = #He.NewItem;
				if (!false)
				{
					this.#HEc(previousItem, newItem);
				}
			}
		}

		// Token: 0x06002760 RID: 10080 RVA: 0x00024C73 File Offset: 0x00022E73
		private void #TEc(object #Ge, KeyEventArgs #He)
		{
			if (this.IsActive && 7 != 0)
			{
				this.#2kb(#He);
			}
		}

		// Token: 0x06002761 RID: 10081 RVA: 0x00024C8B File Offset: 0x00022E8B
		private void #UEc(object #Ge, KeyEventArgs #He)
		{
			if (this.IsActive && 7 != 0)
			{
				this.#GEc(#He);
			}
		}

		// Token: 0x06002762 RID: 10082 RVA: 0x00024CA3 File Offset: 0x00022EA3
		private void #VEc(object #Ge, MouseEventArgs #He)
		{
			if (this.IsActive && 7 != 0)
			{
				this.#EEc(#He);
			}
		}

		// Token: 0x06002763 RID: 10083 RVA: 0x00024CBB File Offset: 0x00022EBB
		private void #WEc(object #Ge, MouseButtonEventArgs #He)
		{
			if (this.IsActive && !#He.Handled && !false)
			{
				this.#5kb(#He);
			}
		}

		// Token: 0x06002764 RID: 10084 RVA: 0x00024CDB File Offset: 0x00022EDB
		private void #XEc(object #Ge, MouseButtonEventArgs #He)
		{
			if (this.IsActive && !#He.Handled && !false)
			{
				this.#3kb(#He);
			}
		}

		// Token: 0x06002765 RID: 10085 RVA: 0x00024CFB File Offset: 0x00022EFB
		private void #YEc(object #Ge, MouseButtonEventArgs #He)
		{
			if (this.IsActive && !#He.Handled && !false)
			{
				this.#DEc(#He);
			}
		}

		// Token: 0x06002766 RID: 10086 RVA: 0x00024D1B File Offset: 0x00022F1B
		private void #ZEc(object #Ge, MouseButtonEventArgs #He)
		{
			if (this.IsActive && !#He.Handled && !false)
			{
				this.#CEc(#He);
			}
		}

		// Token: 0x140000AE RID: 174
		// (add) Token: 0x06002767 RID: 10087 RVA: 0x000D8B0C File Offset: 0x000D6D0C
		// (remove) Token: 0x06002768 RID: 10088 RVA: 0x000D8B64 File Offset: 0x000D6D64
		public virtual event EventHandler<CancelEventArgs> PreviewStartedWorking
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler<CancelEventArgs> eventHandler2;
					if (!false)
					{
						EventHandler<CancelEventArgs> eventHandler = this.#m;
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
							EventHandler<CancelEventArgs> eventHandler6 = Interlocked.CompareExchange<EventHandler<CancelEventArgs>>(ref this.#m, value2, eventHandler4);
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
						EventHandler<CancelEventArgs> eventHandler = this.#m;
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
							EventHandler<CancelEventArgs> eventHandler6 = Interlocked.CompareExchange<EventHandler<CancelEventArgs>>(ref this.#m, value2, eventHandler4);
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

		// Token: 0x06002769 RID: 10089 RVA: 0x000D8BBC File Offset: 0x000D6DBC
		protected virtual void #0Ec(CancelEventArgs #He)
		{
			EventHandler<CancelEventArgs> eventHandler = this.#m;
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

		// Token: 0x140000AF RID: 175
		// (add) Token: 0x0600276A RID: 10090 RVA: 0x000D8BEC File Offset: 0x000D6DEC
		// (remove) Token: 0x0600276B RID: 10091 RVA: 0x000D8C44 File Offset: 0x000D6E44
		public virtual event EventHandler StartedWorking
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#n;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#n, value2, eventHandler4);
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
						EventHandler eventHandler = this.#n;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#n, value2, eventHandler4);
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

		// Token: 0x140000B0 RID: 176
		// (add) Token: 0x0600276C RID: 10092 RVA: 0x000D8C9C File Offset: 0x000D6E9C
		// (remove) Token: 0x0600276D RID: 10093 RVA: 0x000D8CF4 File Offset: 0x000D6EF4
		public virtual event EventHandler FinishedWorking
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler eventHandler2;
					if (!false)
					{
						EventHandler eventHandler = this.#o;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#o, value2, eventHandler4);
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
						EventHandler eventHandler = this.#o;
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
							EventHandler eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.#o, value2, eventHandler4);
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

		// Token: 0x0600276E RID: 10094 RVA: 0x000D8D4C File Offset: 0x000D6F4C
		private void #1Ec(bool #2Ec)
		{
			EventArgs eventArgs2;
			EventHandler eventHandler2;
			while (2 != 0)
			{
				EventArgs eventArgs = new EventArgs();
				if (true)
				{
					eventArgs2 = eventArgs;
				}
				if (!false)
				{
					if (#2Ec)
					{
						EventHandler eventHandler = this.#n;
						if (2 != 0)
						{
							eventHandler2 = eventHandler;
						}
					}
					else
					{
						EventHandler eventHandler3 = this.#o;
						if (2 != 0)
						{
							eventHandler2 = eventHandler3;
						}
					}
					IL_1C:
					if (eventHandler2 != null)
					{
						break;
					}
					IL_34:
					if (!false)
					{
						return;
					}
					goto IL_1C;
				}
			}
			EventHandler eventHandler4 = eventHandler2;
			EventArgs e = eventArgs2;
			if (2 == 0)
			{
				goto IL_34;
			}
			eventHandler4(this, e);
			goto IL_34;
		}

		// Token: 0x04000F8E RID: 3982
		private readonly IModelEditorControl #a;

		// Token: 0x04000F8F RID: 3983
		private bool #b;

		// Token: 0x04000F90 RID: 3984
		private bool #c;

		// Token: 0x04000F91 RID: 3985
		private string #d;

		// Token: 0x04000F92 RID: 3986
		private Image #e;

		// Token: 0x04000F93 RID: 3987
		private object #f;

		// Token: 0x04000F94 RID: 3988
		private bool #g;

		// Token: 0x04000F95 RID: 3989
		private bool #h;

		// Token: 0x04000F96 RID: 3990
		private object #i;

		// Token: 0x04000F97 RID: 3991
		private HelpID #j;

		// Token: 0x04000F98 RID: 3992
		[CompilerGenerated]
		private RichToolTipContent #k;

		// Token: 0x04000F99 RID: 3993
		[CompilerGenerated]
		private bool #l;

		// Token: 0x04000F9A RID: 3994
		[CompilerGenerated]
		private EventHandler<CancelEventArgs> #m;

		// Token: 0x04000F9B RID: 3995
		[CompilerGenerated]
		private EventHandler #n;

		// Token: 0x04000F9C RID: 3996
		[CompilerGenerated]
		private EventHandler #o;
	}
}
