using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000ACA RID: 2762
	public sealed class RichToolTipControl : UserControl, IComponentConnector
	{
		// Token: 0x060059F6 RID: 23030 RVA: 0x0004AB6C File Offset: 0x00048D6C
		public RichToolTipControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700196C RID: 6508
		// (get) Token: 0x060059F7 RID: 23031 RVA: 0x0004AB7A File Offset: 0x00048D7A
		// (set) Token: 0x060059F8 RID: 23032 RVA: 0x0004AB94 File Offset: 0x00048D94
		public RichToolTipContent ToolTipContent
		{
			get
			{
				return (RichToolTipContent)base.GetValue(RichToolTipControl.ToolTipContentProperty);
			}
			set
			{
				base.SetValue(RichToolTipControl.ToolTipContentProperty, value);
			}
		}

		// Token: 0x060059F9 RID: 23033 RVA: 0x0016DEDC File Offset: 0x0016C0DC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107424502), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060059FA RID: 23034 RVA: 0x0016DF20 File Offset: 0x0016C120
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.MainGrid = (Grid)target;
				return;
			case 2:
				this.ContentColumn = (ColumnDefinition)target;
				return;
			case 3:
				this.TitleTextBlock = (TextBlock)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x0400258D RID: 9613
		public static readonly DependencyProperty ToolTipContentProperty = DependencyProperty.Register(#Phc.#3hc(107450186), typeof(RichToolTipContent), typeof(RichToolTipControl), new PropertyMetadata(null));

		// Token: 0x0400258E RID: 9614
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Grid MainGrid;

		// Token: 0x0400258F RID: 9615
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ColumnDefinition ContentColumn;

		// Token: 0x04002590 RID: 9616
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal TextBlock TitleTextBlock;

		// Token: 0x04002591 RID: 9617
		private bool _contentLoaded;
	}
}
