using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows;
using System.Xml;
using #7hc;
using #cYd;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using Telerik.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Docking
{
	// Token: 0x020009A4 RID: 2468
	public sealed class DockingController : IDockingController
	{
		// Token: 0x0600500F RID: 20495 RVA: 0x0015D11C File Offset: 0x0015B31C
		public DockingController(DockingControl dockingControl)
		{
			#X0d.#V0d(dockingControl, #Phc.#3hc(107465935), Component.GUI, #Phc.#3hc(107465946));
			this.dockingControl = dockingControl;
			this.dockingControl.ElementLoading += this.DockingControl_ElementLoading;
			this.dockingControl.PaneStateChange += this.DockingControl_PaneStateChange;
			this.dockingControl.ElementLoaded += this.DockingControl_ElementLoaded;
			this.dockableViewControllers = new Dictionary<IDockableView, DockableViewController>();
		}

		// Token: 0x06005010 RID: 20496 RVA: 0x0015D1A4 File Offset: 0x0015B3A4
		public void SetTitle(IDockableView dockableView, string title)
		{
			DockableViewController dockableViewController;
			if (this.dockableViewControllers.TryGetValue(dockableView, out dockableViewController))
			{
				dockableViewController.Title = title;
				dockableViewController.RadPane.Header = title;
				dockableViewController.RadPane.Title = title;
			}
		}

		// Token: 0x06005011 RID: 20497 RVA: 0x0015D1EC File Offset: 0x0015B3EC
		public IDockableViewController GetOrOpenView(IDockableView dockableView, DockableViewStartOptions dockableViewStartOptions)
		{
			#X0d.#V0d(dockableView, #Phc.#3hc(107465861), Component.GUI, #Phc.#3hc(107465876));
			#X0d.#V0d(dockableViewStartOptions, #Phc.#3hc(107465823), Component.GUI, #Phc.#3hc(107465790));
			if (this.dockableViewControllers.ContainsKey(dockableView))
			{
				return this.dockableViewControllers[dockableView];
			}
			RadPane radPane;
			if (dockableViewStartOptions.DockPositionType == DockPositionType.Document)
			{
				radPane = new RadDocumentPane();
			}
			else
			{
				radPane = new RadPane();
			}
			radPane.Header = dockableViewStartOptions.Title;
			radPane.Title = dockableViewStartOptions.Title;
			radPane.CanDockInDocumentHost = (dockableViewStartOptions.DockPositionType == DockPositionType.Document);
			radPane.Content = dockableView;
			radPane.CanUserClose = dockableViewStartOptions.CanUserClose;
			RadDocking.SetSerializationTag(radPane, dockableViewStartOptions.UniqueIdentifier);
			radPane.MakeDockable();
			DockableViewController dockableViewController = new DockableViewController(dockableView, dockableViewStartOptions, radPane);
			this.dockableViewControllers.Add(dockableView, dockableViewController);
			this.MyAttachRadPane(radPane, dockableViewStartOptions.DockPositionType);
			return dockableViewController;
		}

		// Token: 0x06005012 RID: 20498 RVA: 0x0015D2F0 File Offset: 0x0015B4F0
		public void SaveLayout(Stream layoutData)
		{
			try
			{
				this.dockingControl.SaveLayout(layoutData);
			}
			catch (Exception innerException)
			{
				throw new LayoutException(Strings.StringAnErrorOccurredWhileSavingTheLayout.#z2d(), #Phc.#3hc(107466217), Component.DesktopControls, #IYd.#a, #JYd.#u, innerException);
			}
		}

		// Token: 0x06005013 RID: 20499 RVA: 0x0015D34C File Offset: 0x0015B54C
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "f")]
		public void LoadLayout(Stream layoutData)
		{
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				this.dockingControl.SaveLayout(memoryStream);
				this.dockingControl.LoadLayout(layoutData);
			}
			catch (XmlException #Uic)
			{
				memoryStream.Seek(0L, SeekOrigin.Begin);
				this.dockingControl.LoadLayout(memoryStream);
				throw new #KYd(Strings.StringTheProvidedLayoutDataAreIncorrect.#z2d(), #Phc.#3hc(107466196), Component.DesktopControls, #IYd.#b, #JYd.#v, #Uic);
			}
			catch (Exception innerException)
			{
				memoryStream.Seek(0L, SeekOrigin.Begin);
				this.dockingControl.LoadLayout(memoryStream);
				throw new LayoutException(Strings.StringAnErrorOccurredWhileLoadingTheLayout.#z2d(), #Phc.#3hc(107466143), Component.DesktopControls, #IYd.#a, #JYd.#u, innerException);
			}
			finally
			{
				memoryStream.Dispose();
			}
		}

		// Token: 0x06005014 RID: 20500 RVA: 0x0015D434 File Offset: 0x0015B634
		public void SelectView(IDockableView dockableView)
		{
			DockableViewController dockableViewController;
			if (this.dockableViewControllers.TryGetValue(dockableView, out dockableViewController))
			{
				Window window = dockableViewController.RadPane.ParentOfType<Window>();
				if (window != null)
				{
					if (window.WindowState == WindowState.Minimized)
					{
						window.WindowState = WindowState.Normal;
					}
					window.Topmost = true;
					window.Topmost = false;
				}
				this.dockingControl.ActivePane = dockableViewController.RadPane;
			}
		}

		// Token: 0x17001704 RID: 5892
		// (get) Token: 0x06005015 RID: 20501 RVA: 0x00042D04 File Offset: 0x00040F04
		public IEnumerable<DockableViewController> DockableViewControllers
		{
			get
			{
				return this.dockableViewControllers.Values;
			}
		}

		// Token: 0x06005016 RID: 20502 RVA: 0x00042D19 File Offset: 0x00040F19
		private void MyAttachRadPane(RadPane radPane, DockPositionType dockPositionType)
		{
			this.MyGetRadPaneGroup(dockPositionType).Items.Add(radPane);
		}

		// Token: 0x06005017 RID: 20503 RVA: 0x0015D49C File Offset: 0x0015B69C
		private RadPaneGroup MyGetRadPaneGroup(DockPositionType dockPositionType)
		{
			switch (dockPositionType)
			{
			case DockPositionType.Left:
				return this.dockingControl.LeftGroup;
			case DockPositionType.Right:
				return this.dockingControl.RightGroup;
			case DockPositionType.Bottom:
				return this.dockingControl.BottomGroup;
			case DockPositionType.Document:
				return this.dockingControl.DocumentsGroup;
			default:
				return null;
			}
		}

		// Token: 0x1400012E RID: 302
		// (add) Token: 0x06005018 RID: 20504 RVA: 0x0015D500 File Offset: 0x0015B700
		// (remove) Token: 0x06005019 RID: 20505 RVA: 0x0015D544 File Offset: 0x0015B744
		public event EventHandler<ViewLoadingEventArgs> ViewLoading;

		// Token: 0x1400012F RID: 303
		// (add) Token: 0x0600501A RID: 20506 RVA: 0x0015D588 File Offset: 0x0015B788
		// (remove) Token: 0x0600501B RID: 20507 RVA: 0x0015D5CC File Offset: 0x0015B7CC
		public event EventHandler<DockableViewStateChangedEventArgs> DockableViewStateChanged;

		// Token: 0x0600501C RID: 20508 RVA: 0x0015D610 File Offset: 0x0015B810
		protected void OnViewLoading(ViewLoadingEventArgs e)
		{
			EventHandler<ViewLoadingEventArgs> viewLoading = this.ViewLoading;
			if (viewLoading != null)
			{
				viewLoading(this, e);
			}
		}

		// Token: 0x0600501D RID: 20509 RVA: 0x0015D63C File Offset: 0x0015B83C
		protected void OnDockableViewStateChanged(DockableViewStateChangedEventArgs e)
		{
			EventHandler<DockableViewStateChangedEventArgs> dockableViewStateChanged = this.DockableViewStateChanged;
			if (dockableViewStateChanged != null)
			{
				dockableViewStateChanged(this, e);
			}
		}

		// Token: 0x0600501E RID: 20510 RVA: 0x0015D668 File Offset: 0x0015B868
		private void DockingControl_PaneStateChange(object sender, RadRoutedEventArgs e)
		{
			RadPane radPane = e.OriginalSource as RadPane;
			if (radPane == null || !radPane.IsFloating)
			{
				return;
			}
			IDockableView dockableView = radPane.Content as IDockableView;
			if (dockableView == null)
			{
				return;
			}
			DockableViewController dockableViewController = this.dockableViewControllers.#F1d(dockableView);
			if (dockableViewController == null)
			{
				return;
			}
			this.OnDockableViewStateChanged(new DockableViewStateChangedEventArgs(dockableViewController, dockableView));
			if (!(radPane is RadDocumentPane))
			{
				return;
			}
			ToolWindow toolWindow = radPane.ParentOfType<ToolWindow>();
			if (toolWindow != null)
			{
				if (dockableViewController.DockableViewStartOptions.MinFloatingWidth != null)
				{
					toolWindow.MinWidth = dockableViewController.DockableViewStartOptions.MinFloatingWidth.Value;
					toolWindow.Width = Math.Max(toolWindow.MinWidth, toolWindow.Width);
				}
				if (dockableViewController.DockableViewStartOptions.MinFloatingHeight != null)
				{
					toolWindow.MinHeight = dockableViewController.DockableViewStartOptions.MinFloatingHeight.Value;
					toolWindow.Height = Math.Max(toolWindow.MinHeight, toolWindow.Height);
				}
			}
		}

		// Token: 0x0600501F RID: 20511 RVA: 0x0015D780 File Offset: 0x0015B980
		private void DockingControl_ElementLoading(object sender, LayoutSerializationLoadingEventArgs e)
		{
			ViewLoadingEventArgs viewLoadingEventArgs = new ViewLoadingEventArgs(e.AffectedElementSerializationTag);
			this.OnViewLoading(viewLoadingEventArgs);
			RadPane radPane = viewLoadingEventArgs.ViewObject as RadPane;
			if (radPane != null)
			{
				RadPaneGroup radPaneGroup = radPane.Parent as RadPaneGroup;
				if (radPaneGroup == null)
				{
					return;
				}
				radPaneGroup.Items.Remove(radPane);
				e.SetAffectedElement(viewLoadingEventArgs.ViewObject as RadPane);
			}
		}

		// Token: 0x06005020 RID: 20512 RVA: 0x0015D7E8 File Offset: 0x0015B9E8
		private void DockingControl_ElementLoaded(object sender, LayoutSerializationEventArgs e)
		{
			RadPane radPane = e.AffectedElement as RadPane;
			if (radPane == null)
			{
				return;
			}
			IDockableView dockableView = radPane.Content as IDockableView;
			if (dockableView == null)
			{
				return;
			}
			DockableViewController dockableViewController = this.dockableViewControllers.#F1d(dockableView);
			if (dockableViewController == null)
			{
				return;
			}
			radPane.Title = dockableViewController.DockableViewStartOptions.Title;
			radPane.Header = dockableViewController.DockableViewStartOptions.Title;
		}

		// Token: 0x04002355 RID: 9045
		private readonly DockingControl dockingControl;

		// Token: 0x04002356 RID: 9046
		private readonly Dictionary<IDockableView, DockableViewController> dockableViewControllers;
	}
}
