using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using #1b;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace StructurePoint.Products.Column.Views
{
	// Token: 0x02000034 RID: 52
	internal sealed class MainWindow : RadRibbonWindow, IComponentConnector, IColumnWindow, IView, #6b
	{
		// Token: 0x0600036B RID: 875 RVA: 0x000864DC File Offset: 0x000846DC
		public MainWindow(ISettingsManager settings)
		{
			this.settings = settings;
			this.InitializeComponent();
			Validation.AddErrorHandler(this, new EventHandler<ValidationErrorEventArgs>(this.Validation_OnError));
			Application.Current.MainWindow = this;
			base.Drop += this.OnDrop;
			this.EditorDocking.PreviewDrop += this.OnDrop;
			this.DiagramsDocking.PreviewDrop += this.OnDrop;
			base.DragEnter += this.MainWindow_HandleDrag;
			base.DragOver += this.MainWindow_HandleDrag;
			this.DiagramsDocking.DragEnter += this.MainWindow_HandleDrag;
			this.DiagramsDocking.DragOver += this.MainWindow_HandleDrag;
			this.EditorDocking.DragEnter += this.MainWindow_HandleDrag;
			this.EditorDocking.DragOver += this.MainWindow_HandleDrag;
			this.InitProgressBar.IsVisibleChanged += this.InitProgressBar_IsVisibleChanged;
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600036C RID: 876 RVA: 0x000865F0 File Offset: 0x000847F0
		// (remove) Token: 0x0600036D RID: 877 RVA: 0x00086634 File Offset: 0x00084834
		public event EventHandler<ValidationErrorEventArgs> BindingValidationOccurred;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x0600036E RID: 878 RVA: 0x00086678 File Offset: 0x00084878
		// (remove) Token: 0x0600036F RID: 879 RVA: 0x000866BC File Offset: 0x000848BC
		public event EventHandler<DragEventArgs> DropOccurred;

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000370 RID: 880 RVA: 0x0000888B File Offset: 0x00006A8B
		// (set) Token: 0x06000371 RID: 881 RVA: 0x000088A0 File Offset: 0x00006AA0
		public double LastColumnWidth
		{
			get
			{
				return this.settings.LeftPanelWidth;
			}
			set
			{
				this.settings.LeftPanelWidth = value;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000372 RID: 882 RVA: 0x000088BA File Offset: 0x00006ABA
		public RadDocking EditorDocking
		{
			get
			{
				return this.MyEditorEditorDocking;
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000373 RID: 883 RVA: 0x000088C6 File Offset: 0x00006AC6
		public RadDocking DiagramsDocking
		{
			get
			{
				return this.MyDiagramsDocking;
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00086700 File Offset: 0x00084900
		public void StartInitAnimation()
		{
			DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames
			{
				BeginTime = new TimeSpan?(TimeSpan.Zero),
				Duration = new Duration(TimeSpan.FromMilliseconds(200.0)),
				RepeatBehavior = RepeatBehavior.Forever
			};
			doubleAnimationUsingKeyFrames.KeyFrames.Add(new LinearDoubleKeyFrame(0.0, KeyTime.FromPercent(0.0)));
			doubleAnimationUsingKeyFrames.KeyFrames.Add(new LinearDoubleKeyFrame(100.0, KeyTime.FromPercent(1.0)));
			this.InitProgressBar.BeginAnimation(RangeBase.ValueProperty, doubleAnimationUsingKeyFrames);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x000088D2 File Offset: 0x00006AD2
		public void StopInitAnimation()
		{
			this.InitProgressBar.BeginAnimation(RangeBase.ValueProperty, null);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x000088ED File Offset: 0x00006AED
		public void FocusRibbon()
		{
			this.RibbonViewPresenter.Focus();
		}

		// Token: 0x06000377 RID: 887 RVA: 0x000867C8 File Offset: 0x000849C8
		public void UpdateLeftColumn(bool contentVisible)
		{
			if (this.wasContentVisible == contentVisible)
			{
				return;
			}
			if (contentVisible)
			{
				this.EditorLeftColumn.Width = new GridLength(this.LastColumnWidth);
				this.EditorLeftColumn.MinWidth = 406.0;
				this.EditorLeftColumn.MaxWidth = 461.0;
			}
			else
			{
				this.SaveLastColumnWidth();
				this.EditorLeftColumn.MinWidth = 0.0;
				this.EditorLeftColumn.Width = GridLength.Auto;
			}
			this.wasContentVisible = contentVisible;
			this.EditorGridSplitter.IsEnabled = contentVisible;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00008903 File Offset: 0x00006B03
		public void SetOwner(object owner)
		{
			base.Owner = (owner as Window);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00086880 File Offset: 0x00084A80
		public void RegisterGlobalCommand(CommandBinding binding)
		{
			if (binding == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107388671));
			}
			CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
			CommandManager.RegisterClassCommandBinding(typeof(ToolWindow), binding);
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000891D File Offset: 0x00006B1D
		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			this.SaveLastColumnWidth();
			Application.Current.Shutdown();
		}

		// Token: 0x0600037B RID: 891 RVA: 0x00008942 File Offset: 0x00006B42
		protected void OnBindingValidationOccurred(ValidationErrorEventArgs e)
		{
			EventHandler<ValidationErrorEventArgs> bindingValidationOccurred = this.BindingValidationOccurred;
			if (bindingValidationOccurred == null)
			{
				return;
			}
			bindingValidationOccurred(this, e);
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00008962 File Offset: 0x00006B62
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new FakeWindowAutomationPeer(this, AutomationControlType.Window);
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00008974 File Offset: 0x00006B74
		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
			this.FixPopups();
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000898F File Offset: 0x00006B8F
		protected override void OnStateChanged(EventArgs e)
		{
			base.OnStateChanged(e);
			LayoutHelper.BeginInvokeOnApplicationThread(delegate()
			{
				this.FixPopups();
			});
		}

		// Token: 0x0600037F RID: 895 RVA: 0x000089B6 File Offset: 0x00006BB6
		private void InitProgressBar_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.InitProgressBar.IsVisible)
			{
				this.StartInitAnimation();
			}
		}

		// Token: 0x06000380 RID: 896 RVA: 0x000089D7 File Offset: 0x00006BD7
		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			this.StartInitAnimation();
		}

		// Token: 0x06000381 RID: 897 RVA: 0x000089E7 File Offset: 0x00006BE7
		private void MainWindow_HandleDrag(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Handled = true;
				e.Effects = DragDropEffects.None;
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00008A15 File Offset: 0x00006C15
		private void Validation_OnError(object sender, ValidationErrorEventArgs e)
		{
			this.OnBindingValidationOccurred(e);
		}

		// Token: 0x06000383 RID: 899 RVA: 0x000868CC File Offset: 0x00084ACC
		private void OnDrop(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Handled = true;
				e.Effects = DragDropEffects.None;
				return;
			}
			EventHandler<DragEventArgs> dropOccurred = this.DropOccurred;
			if (dropOccurred == null)
			{
				return;
			}
			dropOccurred(sender, e);
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00086918 File Offset: 0x00084B18
		private void FixPopups()
		{
			IEnumerable<Popup> enumerable = this.ChildrenOfType<Popup>();
			IEnumerable<Popup> enumerable2;
			if (enumerable == null)
			{
				enumerable2 = null;
			}
			else
			{
				enumerable2 = from popup in enumerable
				where popup.IsOpen
				select popup;
			}
			IEnumerable<Popup> enumerable3 = enumerable2 ?? new List<Popup>();
			foreach (Popup popup4 in enumerable3)
			{
				Popup popup2 = popup4;
				double horizontalOffset = popup2.HorizontalOffset;
				popup2.HorizontalOffset = horizontalOffset + 1.0;
				Popup popup3 = popup4;
				horizontalOffset = popup3.HorizontalOffset;
				popup3.HorizontalOffset = horizontalOffset - 1.0;
			}
		}

		// Token: 0x06000385 RID: 901 RVA: 0x000869E8 File Offset: 0x00084BE8
		private void SaveLastColumnWidth()
		{
			if (!double.IsNaN(this.EditorLeftColumn.ActualWidth) && this.EditorLeftColumn.ActualWidth > 0.0)
			{
				this.LastColumnWidth = this.EditorLeftColumn.ActualWidth;
			}
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00086A3C File Offset: 0x00084C3C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388658), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x00086A80 File Offset: 0x00084C80
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.RootGrid = (Grid)target;
				return;
			case 2:
				this.RibbonViewPresenter = (ContentPresenter)target;
				return;
			case 3:
				this.EditorLeftColumn = (ColumnDefinition)target;
				return;
			case 4:
				this.LeftPanelPresenter = (ContentPresenter)target;
				return;
			case 5:
				this.EditorGridSplitter = (GridSplitter)target;
				return;
			case 6:
				this.MyEditorEditorDocking = (RadDocking)target;
				return;
			case 7:
				this.MyDiagramsDocking = (RadDocking)target;
				return;
			case 8:
				this.InitProgressBar = (ProgressBar)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00008A2A File Offset: 0x00006C2A
		bool #6b.get_IsActive()
		{
			return base.IsActive;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00008A3A File Offset: 0x00006C3A
		WindowState #6b.get_WindowState()
		{
			return base.WindowState;
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00008A4A File Offset: 0x00006C4A
		void #6b.set_WindowState(WindowState value)
		{
			base.WindowState = value;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x00008A5F File Offset: 0x00006C5F
		bool #6b.Activate()
		{
			return base.Activate();
		}

		// Token: 0x0600038C RID: 908 RVA: 0x00008A6F File Offset: 0x00006C6F
		void IColumnWindow.add_Closing(CancelEventHandler value)
		{
			base.Closing += value;
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00008A84 File Offset: 0x00006C84
		void IColumnWindow.remove_Closing(CancelEventHandler value)
		{
			base.Closing -= value;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00008A99 File Offset: 0x00006C99
		void IColumnWindow.add_Loaded(RoutedEventHandler value)
		{
			base.Loaded += value;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00008AAE File Offset: 0x00006CAE
		void IColumnWindow.remove_Loaded(RoutedEventHandler value)
		{
			base.Loaded -= value;
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00008AC3 File Offset: 0x00006CC3
		void IColumnWindow.add_Activated(EventHandler value)
		{
			base.Activated += value;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00008AD8 File Offset: 0x00006CD8
		void IColumnWindow.remove_Activated(EventHandler value)
		{
			base.Activated -= value;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00008AED File Offset: 0x00006CED
		bool? IColumnWindow.get_DialogResult()
		{
			return base.DialogResult;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00008AFD File Offset: 0x00006CFD
		void IColumnWindow.set_DialogResult(bool? value)
		{
			base.DialogResult = value;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00008B12 File Offset: 0x00006D12
		void IColumnWindow.Show()
		{
			base.Show();
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00008B22 File Offset: 0x00006D22
		bool? IColumnWindow.ShowDialog()
		{
			return base.ShowDialog();
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00008B32 File Offset: 0x00006D32
		void IColumnWindow.Close()
		{
			base.Close();
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00008A99 File Offset: 0x00006C99
		void IView.add_Loaded(RoutedEventHandler value)
		{
			base.Loaded += value;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00008AAE File Offset: 0x00006CAE
		void IView.remove_Loaded(RoutedEventHandler value)
		{
			base.Loaded -= value;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00008B42 File Offset: 0x00006D42
		void IView.add_PreviewMouseDown(MouseButtonEventHandler value)
		{
			base.PreviewMouseDown += value;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00008B57 File Offset: 0x00006D57
		void IView.remove_PreviewMouseDown(MouseButtonEventHandler value)
		{
			base.PreviewMouseDown -= value;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00008B6C File Offset: 0x00006D6C
		Visibility IView.get_Visibility()
		{
			return base.Visibility;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00008B7C File Offset: 0x00006D7C
		void IView.set_Visibility(Visibility value)
		{
			base.Visibility = value;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00008B91 File Offset: 0x00006D91
		double IView.get_ActualWidth()
		{
			return base.ActualWidth;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00008BA1 File Offset: 0x00006DA1
		double IView.get_ActualHeight()
		{
			return base.ActualHeight;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00008BB1 File Offset: 0x00006DB1
		bool IView.get_IsVisible()
		{
			return base.IsVisible;
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00008BC1 File Offset: 0x00006DC1
		object IView.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00008BD1 File Offset: 0x00006DD1
		void IView.set_DataContext(object value)
		{
			base.DataContext = value;
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00008BE6 File Offset: 0x00006DE6
		CommandBindingCollection IView.get_CommandBindings()
		{
			return base.CommandBindings;
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00008BF6 File Offset: 0x00006DF6
		InputBindingCollection IView.get_InputBindings()
		{
			return base.InputBindings;
		}

		// Token: 0x04000066 RID: 102
		private const double ButtonsBarWidth = 36.0;

		// Token: 0x04000067 RID: 103
		private const double MinLeftColumnWidth = 406.0;

		// Token: 0x04000068 RID: 104
		private const double MaxLeftColumnWidth = 461.0;

		// Token: 0x04000069 RID: 105
		private readonly ISettingsManager settings;

		// Token: 0x0400006A RID: 106
		private bool wasContentVisible;

		// Token: 0x0400006D RID: 109
		internal Grid RootGrid;

		// Token: 0x0400006E RID: 110
		internal ContentPresenter RibbonViewPresenter;

		// Token: 0x0400006F RID: 111
		internal ColumnDefinition EditorLeftColumn;

		// Token: 0x04000070 RID: 112
		internal ContentPresenter LeftPanelPresenter;

		// Token: 0x04000071 RID: 113
		internal GridSplitter EditorGridSplitter;

		// Token: 0x04000072 RID: 114
		internal RadDocking MyEditorEditorDocking;

		// Token: 0x04000073 RID: 115
		internal RadDocking MyDiagramsDocking;

		// Token: 0x04000074 RID: 116
		internal ProgressBar InitProgressBar;

		// Token: 0x04000075 RID: 117
		private bool _contentLoaded;
	}
}
