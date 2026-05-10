using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009CE RID: 2510
	internal sealed class GridControlColorFilteringControl : FilteringControl, IComponentConnector, IFilteringControl
	{
		// Token: 0x060051BE RID: 20926 RVA: 0x00043ED2 File Offset: 0x000420D2
		public GridControlColorFilteringControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x060051BF RID: 20927 RVA: 0x00160390 File Offset: 0x0015E590
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "It is called in xaml.")]
		private static void GridControlColorButton_Click(object sender, RoutedEventArgs e)
		{
			Grid grid = (sender as GridControlColorButton).ParentOfType<Grid>();
			if (grid == null)
			{
				return;
			}
			CheckBox checkBox = grid.ChildrenOfType<CheckBox>().FirstOrDefault<CheckBox>();
			if (checkBox != null)
			{
				checkBox.IsChecked = !checkBox.IsChecked;
			}
		}

		// Token: 0x060051C0 RID: 20928 RVA: 0x001603F8 File Offset: 0x0015E5F8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107464423), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060051C1 RID: 20929 RVA: 0x00043EE0 File Offset: 0x000420E0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040023AB RID: 9131
		private bool _contentLoaded;
	}
}
