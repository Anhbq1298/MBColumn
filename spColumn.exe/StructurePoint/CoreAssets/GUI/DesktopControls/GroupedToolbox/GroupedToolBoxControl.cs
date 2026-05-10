using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.GroupedToolbox
{
	// Token: 0x02000996 RID: 2454
	public sealed class GroupedToolBoxControl : UserControl, IComponentConnector, IStyleConnector, IGroupedToolBoxControl
	{
		// Token: 0x06004FC3 RID: 20419 RVA: 0x0004292E File Offset: 0x00040B2E
		public GroupedToolBoxControl()
		{
			this.InitializeComponent();
			this.toolsGroups = new RadObservableCollection<GroupedToolBoxItem>();
			this.GroupsContainer.ItemsSource = this.toolsGroups;
		}

		// Token: 0x06004FC4 RID: 20420 RVA: 0x00042958 File Offset: 0x00040B58
		public void AddToolsGroup(GroupedToolBoxItem toolsGroup)
		{
			#X0d.#V0d(toolsGroup, #Phc.#3hc(107466348), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107466363));
			this.toolsGroups.Add(toolsGroup);
		}

		// Token: 0x06004FC5 RID: 20421 RVA: 0x0004298D File Offset: 0x00040B8D
		public void ActivateTool(IEditionToolData editionToolData)
		{
			this.MySelectTool(editionToolData);
		}

		// Token: 0x06004FC6 RID: 20422 RVA: 0x0015C924 File Offset: 0x0015AB24
		public void RemoveAllTools()
		{
			RadRadioButton radRadioButton = this.GroupsContainer.ChildrenOfType<RadRadioButton>().FirstOrDefault((RadRadioButton item) => item.DataContext == this.SelectedToolData);
			if (this.SelectedToolData != null && radRadioButton != null && radRadioButton.IsChecked.GetValueOrDefault())
			{
				this.SelectedToolData.IsSelected = false;
				radRadioButton.IsChecked = new bool?(false);
				this.OnSelectedToolChanged(this.SelectedToolData, null);
				this.SelectedToolData = null;
			}
			this.toolsGroups.Clear();
		}

		// Token: 0x06004FC7 RID: 20423 RVA: 0x0015C9B8 File Offset: 0x0015ABB8
		public void RemoveToolsGroup(GroupedToolBoxItem toolsGroup)
		{
			#X0d.#V0d(toolsGroup, #Phc.#3hc(107466348), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107466278));
			if (!this.toolsGroups.Contains(toolsGroup))
			{
				return;
			}
			if (this.SelectedToolData != null && toolsGroup.Tools.Contains(this.SelectedToolData))
			{
				RadRadioButton radRadioButton = this.GroupsContainer.ChildrenOfType<RadRadioButton>().FirstOrDefault((RadRadioButton item) => item.DataContext == this.SelectedToolData);
				if (radRadioButton != null && radRadioButton.IsChecked.GetValueOrDefault())
				{
					this.SelectedToolData.IsSelected = false;
					radRadioButton.IsChecked = new bool?(false);
					this.OnSelectedToolChanged(this.SelectedToolData, null);
					this.SelectedToolData = null;
				}
			}
			this.toolsGroups.Remove(toolsGroup);
		}

		// Token: 0x170016F6 RID: 5878
		// (get) Token: 0x06004FC8 RID: 20424 RVA: 0x000429A2 File Offset: 0x00040BA2
		// (set) Token: 0x06004FC9 RID: 20425 RVA: 0x000429BC File Offset: 0x00040BBC
		public IEditionToolData SelectedToolData
		{
			get
			{
				return (IEditionToolData)base.GetValue(GroupedToolBoxControl.SelectedToolDataProperty);
			}
			set
			{
				base.SetValue(GroupedToolBoxControl.SelectedToolDataProperty, value);
			}
		}

		// Token: 0x170016F7 RID: 5879
		// (get) Token: 0x06004FCA RID: 20426 RVA: 0x000429D6 File Offset: 0x00040BD6
		public IEnumerable<GroupedToolBoxItem> ToolsGroups
		{
			get
			{
				return this.toolsGroups;
			}
		}

		// Token: 0x1400012C RID: 300
		// (add) Token: 0x06004FCB RID: 20427 RVA: 0x0015CA94 File Offset: 0x0015AC94
		// (remove) Token: 0x06004FCC RID: 20428 RVA: 0x0015CAD8 File Offset: 0x0015ACD8
		public event EventHandler<SelectedItemChangedEventArgs<IEditionToolData>> SelectedToolChanged;

		// Token: 0x06004FCD RID: 20429 RVA: 0x0015CB1C File Offset: 0x0015AD1C
		protected void OnSelectedToolChanged(IEditionToolData previousToolData, IEditionToolData newToolData)
		{
			EventHandler<SelectedItemChangedEventArgs<IEditionToolData>> selectedToolChanged = this.SelectedToolChanged;
			if (selectedToolChanged != null)
			{
				selectedToolChanged(this, new SelectedItemChangedEventArgs<IEditionToolData>(previousToolData, newToolData));
			}
		}

		// Token: 0x06004FCE RID: 20430 RVA: 0x0015CB50 File Offset: 0x0015AD50
		private void EditionTool_Selected(object sender, RoutedEventArgs e)
		{
			RadRadioButton radRadioButton = sender as RadRadioButton;
			RadRadioButton radRadioButton2;
			if (!false)
			{
				radRadioButton2 = radRadioButton;
			}
			if (radRadioButton2 == null)
			{
				return;
			}
			IEditionToolData newSelectedTool = radRadioButton2.DataContext as IEditionToolData;
			this.MySelectTool(newSelectedTool);
		}

		// Token: 0x06004FCF RID: 20431 RVA: 0x000429E2 File Offset: 0x00040BE2
		private void EditionTool_Deselected(object sender, RoutedEventArgs e)
		{
			if (!(sender is RadRadioButton))
			{
				return;
			}
			this.SelectedToolData = null;
		}

		// Token: 0x06004FD0 RID: 20432 RVA: 0x0015CB8C File Offset: 0x0015AD8C
		private void MySelectTool(IEditionToolData newSelectedTool)
		{
			IEditionToolData selectedToolData = this.SelectedToolData;
			this.SelectedToolData = newSelectedTool;
			this.OnSelectedToolChanged(selectedToolData, newSelectedTool);
		}

		// Token: 0x06004FD1 RID: 20433 RVA: 0x0015CBBC File Offset: 0x0015ADBC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107466257), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004FD2 RID: 20434 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06004FD3 RID: 20435 RVA: 0x00042A00 File Offset: 0x00040C00
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 2)
			{
				this.GroupsContainer = (ItemsControl)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x06004FD4 RID: 20436 RVA: 0x00042A26 File Offset: 0x00040C26
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((RadRadioButton)target).Checked += this.EditionTool_Selected;
				((RadRadioButton)target).Unchecked += this.EditionTool_Deselected;
			}
		}

		// Token: 0x04002338 RID: 9016
		private readonly RadObservableCollection<GroupedToolBoxItem> toolsGroups;

		// Token: 0x04002339 RID: 9017
		public static readonly DependencyProperty SelectedToolDataProperty = DependencyProperty.Register(#Phc.#3hc(107450825), typeof(IEditionToolData), typeof(GroupedToolBoxControl), new PropertyMetadata(null));

		// Token: 0x0400233B RID: 9019
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ItemsControl GroupsContainer;

		// Token: 0x0400233C RID: 9020
		private bool _contentLoaded;
	}
}
