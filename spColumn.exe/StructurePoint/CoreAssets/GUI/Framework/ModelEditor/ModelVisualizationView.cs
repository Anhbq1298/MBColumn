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
using StructurePoint.CoreAssets.Localizer;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.Framework.ModelEditor
{
	// Token: 0x02000CAD RID: 3245
	public sealed class ModelVisualizationView : UserControl, IComponentConnector, INotifyPropertyChanged, #QBc, IDockableView, #W0c, #X0c
	{
		// Token: 0x060069E6 RID: 27110 RVA: 0x00053C9B File Offset: 0x00051E9B
		public ModelVisualizationView()
		{
			this.InitializeComponent();
			this.title = Strings.StringModelEditor;
		}

		// Token: 0x17001D2C RID: 7468
		// (get) Token: 0x060069E7 RID: 27111 RVA: 0x00053CB4 File Offset: 0x00051EB4
		public IModelEditorControl ModelVisualizationControl
		{
			get
			{
				return this.VisualizationControl;
			}
		}

		// Token: 0x17001D2D RID: 7469
		// (get) Token: 0x060069E8 RID: 27112 RVA: 0x000536AB File Offset: 0x000518AB
		public object ParentControl
		{
			get
			{
				return this.ParentOfType<Window>();
			}
		}

		// Token: 0x17001D2E RID: 7470
		// (get) Token: 0x060069E9 RID: 27113 RVA: 0x00053CBC File Offset: 0x00051EBC
		// (set) Token: 0x060069EA RID: 27114 RVA: 0x00053CC4 File Offset: 0x00051EC4
		public IViewModel ViewModel { get; private set; }

		// Token: 0x17001D2F RID: 7471
		// (get) Token: 0x060069EB RID: 27115 RVA: 0x00053CCD File Offset: 0x00051ECD
		// (set) Token: 0x060069EC RID: 27116 RVA: 0x00053CD5 File Offset: 0x00051ED5
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

		// Token: 0x060069ED RID: 27117 RVA: 0x00053D0C File Offset: 0x00051F0C
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

		// Token: 0x1400019A RID: 410
		// (add) Token: 0x060069EE RID: 27118 RVA: 0x0019B7CC File Offset: 0x001999CC
		// (remove) Token: 0x060069EF RID: 27119 RVA: 0x0019B824 File Offset: 0x00199A24
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

		// Token: 0x060069F0 RID: 27120 RVA: 0x0019B87C File Offset: 0x00199A7C
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

		// Token: 0x060069F1 RID: 27121 RVA: 0x0019B8B8 File Offset: 0x00199AB8
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
						int num2 = num = 107432057;
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

		// Token: 0x060069F2 RID: 27122 RVA: 0x00053D2A File Offset: 0x00051F2A
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
				this.VisualizationControl = (ModelEditorControl)target;
			}
			while (false);
		}

		// Token: 0x04002B58 RID: 11096
		private string title;

		// Token: 0x04002B5B RID: 11099
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ModelEditorControl VisualizationControl;

		// Token: 0x04002B5C RID: 11100
		private bool _contentLoaded;
	}
}
