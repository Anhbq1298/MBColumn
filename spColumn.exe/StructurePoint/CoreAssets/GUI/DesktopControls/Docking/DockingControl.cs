using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Docking
{
	// Token: 0x0200099B RID: 2459
	public sealed class DockingControl : RadDocking, IComponentConnector
	{
		// Token: 0x06004FEC RID: 20460 RVA: 0x00042B5E File Offset: 0x00040D5E
		public DockingControl()
		{
			this.InitializeComponent();
			EventHandler<PreviewShowCompassEventArgs> value;
			if ((value = DockingControl.<>O.<0>__Docking_PreviewShowCompass) == null)
			{
				value = (DockingControl.<>O.<0>__Docking_PreviewShowCompass = new EventHandler<PreviewShowCompassEventArgs>(DockingControl.Docking_PreviewShowCompass));
			}
			base.PreviewShowCompass += value;
		}

		// Token: 0x06004FED RID: 20461 RVA: 0x0015CD84 File Offset: 0x0015AF84
		private static void Docking_PreviewShowCompass(object sender, PreviewShowCompassEventArgs e)
		{
			RadSplitContainer dragged = e.DraggedElement as RadSplitContainer;
			if (e.TargetGroup != null)
			{
				e.Compass.IsCenterIndicatorVisible = DockingControl.MyCanDockIn(dragged, e.TargetGroup);
				e.Compass.IsLeftIndicatorVisible = DockingControl.MyCanDockIn(dragged, e.TargetGroup);
				e.Compass.IsTopIndicatorVisible = DockingControl.MyCanDockIn(dragged, e.TargetGroup);
				e.Compass.IsRightIndicatorVisible = DockingControl.MyCanDockIn(dragged, e.TargetGroup);
				e.Compass.IsBottomIndicatorVisible = DockingControl.MyCanDockIn(dragged, e.TargetGroup);
			}
			else
			{
				e.Compass.IsLeftIndicatorVisible = DockingControl.MyCanDock(dragged, DockPosition.Left);
				e.Compass.IsTopIndicatorVisible = DockingControl.MyCanDock(dragged, DockPosition.Top);
				e.Compass.IsRightIndicatorVisible = DockingControl.MyCanDock(dragged, DockPosition.Right);
				e.Compass.IsBottomIndicatorVisible = DockingControl.MyCanDock(dragged, DockPosition.Bottom);
			}
			e.Canceled = !DockingControl.MyCompassNeedsToShow(e.Compass);
		}

		// Token: 0x06004FEE RID: 20462 RVA: 0x00042B8D File Offset: 0x00040D8D
		private static bool MyCompassNeedsToShow(Compass compass)
		{
			return compass.IsLeftIndicatorVisible || compass.IsTopIndicatorVisible || compass.IsRightIndicatorVisible || compass.IsBottomIndicatorVisible || compass.IsCenterIndicatorVisible;
		}

		// Token: 0x06004FEF RID: 20463 RVA: 0x00042BC3 File Offset: 0x00040DC3
		private static DockingControl.PaneType MyGetPaneType(RadPane pane)
		{
			if (!(pane is RadDocumentPane))
			{
				return DockingControl.PaneType.Regular;
			}
			return DockingControl.PaneType.Document;
		}

		// Token: 0x06004FF0 RID: 20464 RVA: 0x0015CE94 File Offset: 0x0015B094
		private static bool MyCanDockIn(RadPane paneToDock, RadPane paneInTargetGroup)
		{
			DockingControl.PaneType paneType = DockingControl.MyGetPaneType(paneToDock);
			DockingControl.PaneType paneType2 = DockingControl.MyGetPaneType(paneInTargetGroup);
			if (paneType != DockingControl.PaneType.Document)
			{
				if (paneType == DockingControl.PaneType.Regular)
				{
					if (paneType2 == DockingControl.PaneType.Document)
					{
						return false;
					}
					if (paneType2 == DockingControl.PaneType.Regular)
					{
						return true;
					}
				}
			}
			else
			{
				if (paneType2 == DockingControl.PaneType.Document)
				{
					return true;
				}
				if (paneType2 == DockingControl.PaneType.Regular)
				{
					return false;
				}
			}
			return false;
		}

		// Token: 0x06004FF1 RID: 20465 RVA: 0x0015CEE0 File Offset: 0x0015B0E0
		private static bool MyCanDock(RadPane paneToDock, DockPosition position)
		{
			if (position == DockPosition.Top)
			{
				return false;
			}
			DockingControl.PaneType paneType = DockingControl.MyGetPaneType(paneToDock);
			if (paneType != DockingControl.PaneType.Document)
			{
				return paneType == DockingControl.PaneType.Regular && position != DockPosition.Center;
			}
			return position == DockPosition.Center;
		}

		// Token: 0x06004FF2 RID: 20466 RVA: 0x0015CF1C File Offset: 0x0015B11C
		private static bool MyCanDockIn(ISplitItem dragged, ISplitItem target)
		{
			DockingControl.<>c__DisplayClass7_0 CS$<>8__locals1 = new DockingControl.<>c__DisplayClass7_0();
			DockingControl.<>c__DisplayClass7_0 CS$<>8__locals2;
			if (!false)
			{
				CS$<>8__locals2 = CS$<>8__locals1;
			}
			CS$<>8__locals2.target = target;
			return !dragged.EnumeratePanes().Any((RadPane pane) => CS$<>8__locals2.target.EnumeratePanes().Any((RadPane pane1) => !DockingControl.MyCanDockIn(pane, pane1)));
		}

		// Token: 0x06004FF3 RID: 20467 RVA: 0x0015CF60 File Offset: 0x0015B160
		private static bool MyCanDock(ISplitItem dragged, DockPosition position)
		{
			DockingControl.<>c__DisplayClass8_0 CS$<>8__locals1 = new DockingControl.<>c__DisplayClass8_0();
			DockingControl.<>c__DisplayClass8_0 CS$<>8__locals2;
			if (!false)
			{
				CS$<>8__locals2 = CS$<>8__locals1;
			}
			CS$<>8__locals2.position = position;
			return !dragged.EnumeratePanes().Any((RadPane pane) => !DockingControl.MyCanDock(pane, CS$<>8__locals2.position));
		}

		// Token: 0x06004FF4 RID: 20468 RVA: 0x0015CFA4 File Offset: 0x0015B1A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107466684), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004FF5 RID: 20469 RVA: 0x0015CFE8 File Offset: 0x0015B1E8
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
				this.DocumentSplitContainer = (RadSplitContainer)target;
				return;
			case 2:
				this.DocumentsGroup = (RadPaneGroup)target;
				return;
			case 3:
				this.BottomGroup = (RadPaneGroup)target;
				return;
			case 4:
				this.LeftGroup = (RadPaneGroup)target;
				return;
			case 5:
				this.RightGroup = (RadPaneGroup)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04002341 RID: 9025
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadSplitContainer DocumentSplitContainer;

		// Token: 0x04002342 RID: 9026
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadPaneGroup DocumentsGroup;

		// Token: 0x04002343 RID: 9027
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadPaneGroup BottomGroup;

		// Token: 0x04002344 RID: 9028
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadPaneGroup LeftGroup;

		// Token: 0x04002345 RID: 9029
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadPaneGroup RightGroup;

		// Token: 0x04002346 RID: 9030
		private bool _contentLoaded;

		// Token: 0x0200099C RID: 2460
		private enum PaneType
		{
			// Token: 0x04002348 RID: 9032
			Document,
			// Token: 0x04002349 RID: 9033
			Regular
		}

		// Token: 0x0200099D RID: 2461
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0400234A RID: 9034
			public static EventHandler<PreviewShowCompassEventArgs> <0>__Docking_PreviewShowCompass;
		}
	}
}
