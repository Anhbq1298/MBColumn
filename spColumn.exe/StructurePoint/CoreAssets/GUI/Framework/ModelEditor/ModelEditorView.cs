using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using #ezc;
using #T0c;
using StructurePoint.CoreAssets.GUI.DesktopControls.Docking;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Localizer;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.Framework.ModelEditor
{
	// Token: 0x02000CA2 RID: 3234
	public sealed class ModelEditorView : UserControl, IComponentConnector, INotifyPropertyChanged, #QBc, IDockableView, #U0c, #W0c
	{
		// Token: 0x060068DF RID: 26847 RVA: 0x0005368A File Offset: 0x0005188A
		public ModelEditorView()
		{
			this.InitializeComponent();
			this.title = Strings.StringModelEditor;
		}

		// Token: 0x17001CF7 RID: 7415
		// (get) Token: 0x060068E0 RID: 26848 RVA: 0x000536A3 File Offset: 0x000518A3
		public IModelEditorControl ModelVisualizationControl
		{
			get
			{
				return this.EditorControl;
			}
		}

		// Token: 0x17001CF8 RID: 7416
		// (get) Token: 0x060068E1 RID: 26849 RVA: 0x000536AB File Offset: 0x000518AB
		public object ParentControl
		{
			get
			{
				return this.ParentOfType<Window>();
			}
		}

		// Token: 0x060068E2 RID: 26850 RVA: 0x00009E6A File Offset: 0x0000806A
		public void ShowContextMenu(StructurePoint.CoreAssets.Infrastructure.Data.Point position)
		{
		}

		// Token: 0x17001CF9 RID: 7417
		// (get) Token: 0x060068E3 RID: 26851 RVA: 0x000536B3 File Offset: 0x000518B3
		// (set) Token: 0x060068E4 RID: 26852 RVA: 0x000536BB File Offset: 0x000518BB
		public IViewModel ViewModel { get; private set; }

		// Token: 0x17001CFA RID: 7418
		// (get) Token: 0x060068E5 RID: 26853 RVA: 0x000536C4 File Offset: 0x000518C4
		// (set) Token: 0x060068E6 RID: 26854 RVA: 0x000536CC File Offset: 0x000518CC
		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				if (!(this.title != value))
				{
					goto IL_2B;
				}
				do
				{
					IL_0E:
					this.title = value;
					if (false)
					{
						goto IL_2B;
					}
				}
				while (false);
				string propertyName = #Phc.#3hc(107408142);
				if (2 != 0)
				{
					this.RaisePropertyChanged(propertyName);
				}
				IL_2B:
				if (!false)
				{
					return;
				}
				goto IL_0E;
			}
		}

		// Token: 0x060068E7 RID: 26855 RVA: 0x00053703 File Offset: 0x00051903
		public void SetViewModel(IViewModel viewModel)
		{
			if (7 != 0)
			{
				base.DataContext = viewModel;
			}
			if (!false)
			{
				this.ViewModel = viewModel;
			}
		}

		// Token: 0x14000194 RID: 404
		// (add) Token: 0x060068E8 RID: 26856 RVA: 0x0019801C File Offset: 0x0019621C
		// (remove) Token: 0x060068E9 RID: 26857 RVA: 0x00198074 File Offset: 0x00196274
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler;
					if (!false)
					{
						PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
						if (!false)
						{
							propertyChangedEventHandler = propertyChanged;
						}
					}
					PropertyChangedEventHandler propertyChangedEventHandler3;
					do
					{
						if (7 != 0)
						{
							PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
							if (3 != 0)
							{
								propertyChangedEventHandler3 = propertyChangedEventHandler2;
							}
							PropertyChangedEventHandler propertyChangedEventHandler4 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler3, value);
							PropertyChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangedEventHandler4;
							}
							PropertyChangedEventHandler propertyChangedEventHandler5 = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.PropertyChanged, value2, propertyChangedEventHandler3);
							if (6 != 0)
							{
								propertyChangedEventHandler = propertyChangedEventHandler5;
							}
						}
					}
					while (propertyChangedEventHandler != propertyChangedEventHandler3);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler;
					if (!false)
					{
						PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
						if (!false)
						{
							propertyChangedEventHandler = propertyChanged;
						}
					}
					PropertyChangedEventHandler propertyChangedEventHandler3;
					do
					{
						if (7 != 0)
						{
							PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
							if (3 != 0)
							{
								propertyChangedEventHandler3 = propertyChangedEventHandler2;
							}
							PropertyChangedEventHandler propertyChangedEventHandler4 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler3, value);
							PropertyChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangedEventHandler4;
							}
							PropertyChangedEventHandler propertyChangedEventHandler5 = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.PropertyChanged, value2, propertyChangedEventHandler3);
							if (6 != 0)
							{
								propertyChangedEventHandler = propertyChangedEventHandler5;
							}
						}
					}
					while (propertyChangedEventHandler != propertyChangedEventHandler3);
				}
			}
		}

		// Token: 0x060068EA RID: 26858 RVA: 0x001980CC File Offset: 0x001962CC
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
		{
			for (;;)
			{
				PropertyChangedEventHandler propertyChangedEventHandler;
				if (!false)
				{
					PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
					if (!false)
					{
						propertyChangedEventHandler = propertyChanged;
					}
				}
				for (;;)
				{
					if (propertyChangedEventHandler != null)
					{
						if (false)
						{
							break;
						}
						PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
						PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
						if (!false)
						{
							propertyChangedEventHandler2(this, e);
						}
					}
					if (!false)
					{
						return;
					}
				}
			}
		}

		// Token: 0x060068EB RID: 26859 RVA: 0x00198108 File Offset: 0x00196308
		protected void OnEditorContextMenuOpening(RoutedEventArgs e)
		{
			RoutedEventHandler editorContextMenuOpening = this.EditorContextMenuOpening;
			RoutedEventHandler routedEventHandler;
			if (!false)
			{
				routedEventHandler = editorContextMenuOpening;
			}
			if (routedEventHandler != null)
			{
				RoutedEventHandler routedEventHandler2 = routedEventHandler;
				if (!false)
				{
					routedEventHandler2(this, e);
				}
			}
		}

		// Token: 0x14000195 RID: 405
		// (add) Token: 0x060068EC RID: 26860 RVA: 0x00198138 File Offset: 0x00196338
		// (remove) Token: 0x060068ED RID: 26861 RVA: 0x00198190 File Offset: 0x00196390
		public event RoutedEventHandler EditorContextMenuOpening
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					RoutedEventHandler routedEventHandler;
					if (!false)
					{
						RoutedEventHandler editorContextMenuOpening = this.EditorContextMenuOpening;
						if (!false)
						{
							routedEventHandler = editorContextMenuOpening;
						}
					}
					RoutedEventHandler routedEventHandler3;
					do
					{
						if (7 != 0)
						{
							RoutedEventHandler routedEventHandler2 = routedEventHandler;
							if (3 != 0)
							{
								routedEventHandler3 = routedEventHandler2;
							}
							RoutedEventHandler routedEventHandler4 = (RoutedEventHandler)Delegate.Combine(routedEventHandler3, value);
							RoutedEventHandler value2;
							if (-1 != 0)
							{
								value2 = routedEventHandler4;
							}
							RoutedEventHandler routedEventHandler5 = Interlocked.CompareExchange<RoutedEventHandler>(ref this.EditorContextMenuOpening, value2, routedEventHandler3);
							if (6 != 0)
							{
								routedEventHandler = routedEventHandler5;
							}
						}
					}
					while (routedEventHandler != routedEventHandler3);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					RoutedEventHandler routedEventHandler;
					if (!false)
					{
						RoutedEventHandler editorContextMenuOpening = this.EditorContextMenuOpening;
						if (!false)
						{
							routedEventHandler = editorContextMenuOpening;
						}
					}
					RoutedEventHandler routedEventHandler3;
					do
					{
						if (7 != 0)
						{
							RoutedEventHandler routedEventHandler2 = routedEventHandler;
							if (3 != 0)
							{
								routedEventHandler3 = routedEventHandler2;
							}
							RoutedEventHandler routedEventHandler4 = (RoutedEventHandler)Delegate.Remove(routedEventHandler3, value);
							RoutedEventHandler value2;
							if (-1 != 0)
							{
								value2 = routedEventHandler4;
							}
							RoutedEventHandler routedEventHandler5 = Interlocked.CompareExchange<RoutedEventHandler>(ref this.EditorContextMenuOpening, value2, routedEventHandler3);
							if (6 != 0)
							{
								routedEventHandler = routedEventHandler5;
							}
						}
					}
					while (routedEventHandler != routedEventHandler3);
				}
			}
		}

		// Token: 0x060068EE RID: 26862 RVA: 0x001981E8 File Offset: 0x001963E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			int num = this._contentLoaded ? 1 : 0;
			IL_06:
			while (num == 0)
			{
				do
				{
					this._contentLoaded = true;
					if (!false)
					{
						int num2 = num = 107435690;
						if (num2 == 0)
						{
							goto IL_06;
						}
						Uri uri = new Uri(#Phc.#3hc(num2), UriKind.Relative);
						Uri uri2;
						if (!false)
						{
							uri2 = uri;
						}
						Uri resourceLocator = uri2;
						if (!false)
						{
							Application.LoadComponent(this, resourceLocator);
						}
					}
				}
				while (-1 == 0);
				return;
			}
		}

		// Token: 0x060068EF RID: 26863 RVA: 0x00053721 File Offset: 0x00051921
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			do
			{
				if (connectionId != 1)
				{
					if (7 == 0)
					{
						continue;
					}
					this._contentLoaded = true;
					if (!false)
					{
						return;
					}
				}
				this.EditorControl = (ModelEditorControl)target;
			}
			while (false);
		}

		// Token: 0x04002B15 RID: 11029
		private string title;

		// Token: 0x04002B19 RID: 11033
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ModelEditorControl EditorControl;

		// Token: 0x04002B1A RID: 11034
		private bool _contentLoaded;
	}
}
