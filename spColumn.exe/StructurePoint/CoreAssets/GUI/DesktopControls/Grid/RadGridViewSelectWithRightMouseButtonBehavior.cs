using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009B8 RID: 2488
	public sealed class RadGridViewSelectWithRightMouseButtonBehavior : Behavior<DataControl>
	{
		// Token: 0x060050AB RID: 20651 RVA: 0x000433CF File Offset: 0x000415CF
		protected override void OnAttached()
		{
			base.OnAttached();
			base.AssociatedObject.MouseRightButtonUp += this.AssociatedObject_MouseRightButtonUp;
		}

		// Token: 0x060050AC RID: 20652 RVA: 0x000433FA File Offset: 0x000415FA
		protected override void OnDetaching()
		{
			base.OnDetaching();
			base.AssociatedObject.MouseRightButtonUp -= this.AssociatedObject_MouseRightButtonUp;
		}

		// Token: 0x060050AD RID: 20653 RVA: 0x0015ED40 File Offset: 0x0015CF40
		private void AssociatedObject_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			FrameworkElement frameworkElement = e.OriginalSource as FrameworkElement;
			GridViewRow gridViewRow = (frameworkElement != null) ? frameworkElement.ParentOfType<GridViewRow>() : null;
			if (!((gridViewRow != null) ? new bool?(gridViewRow.IsSelected) : null).GetValueOrDefault() && !Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl))
			{
				foreach (GridViewRow gridViewRow2 in base.AssociatedObject.ChildrenOfType<GridViewRow>().ToList<GridViewRow>())
				{
					if (gridViewRow2.IsSelected)
					{
						gridViewRow2.SetValue(RadRowItem.IsSelectedProperty, false);
					}
				}
			}
			if (gridViewRow != null)
			{
				gridViewRow.SetValue(RadRowItem.IsSelectedProperty, true);
			}
		}
	}
}
