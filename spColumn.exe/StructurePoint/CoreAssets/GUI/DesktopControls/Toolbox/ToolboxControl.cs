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

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Toolbox
{
	// Token: 0x020008EB RID: 2283
	public sealed class ToolboxControl : UserControl, IComponentConnector, IStyleConnector, IToolboxControl
	{
		// Token: 0x06004883 RID: 18563 RVA: 0x00143A1C File Offset: 0x00141C1C
		public ToolboxControl()
		{
			this.InitializeComponent();
			this.tools = new RadObservableCollection<IEditionToolData>();
			this.ToolsItemsControl.ItemsSource = this.tools;
			this.tools.CollectionChanging += this.ToolsOnCollectionChanging;
		}

		// Token: 0x06004884 RID: 18564 RVA: 0x0003D05D File Offset: 0x0003B25D
		public void AddTool(IEditionToolData editionToolData)
		{
			#X0d.#V0d(editionToolData, #Phc.#3hc(107451140), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107450607));
			this.tools.Add(editionToolData);
		}

		// Token: 0x06004885 RID: 18565 RVA: 0x00143A68 File Offset: 0x00141C68
		public void AddTools(IEnumerable<IEditionToolData> editionTools)
		{
			#X0d.#V0d(editionTools, #Phc.#3hc(107450586), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107450537));
			foreach (IEditionToolData editionToolData in editionTools)
			{
				this.AddTool(editionToolData);
			}
		}

		// Token: 0x06004886 RID: 18566 RVA: 0x0003D092 File Offset: 0x0003B292
		public void RemoveTool(IEditionToolData editionToolData)
		{
			#X0d.#V0d(editionToolData, #Phc.#3hc(107451140), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107450516));
			this.tools.Remove(editionToolData);
		}

		// Token: 0x06004887 RID: 18567 RVA: 0x00143AD8 File Offset: 0x00141CD8
		public void RemoveTools(IEnumerable<IEditionToolData> editionTools)
		{
			#X0d.#V0d(editionTools, #Phc.#3hc(107450586), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107450463));
			foreach (IEditionToolData editionToolData in editionTools)
			{
				this.RemoveTool(editionToolData);
			}
		}

		// Token: 0x06004888 RID: 18568 RVA: 0x00143B48 File Offset: 0x00141D48
		public void RemoveAllTools()
		{
			for (int i = this.tools.ToList<IEditionToolData>().Count - 1; i >= 0; i--)
			{
				this.tools.RemoveAt(i);
			}
		}

		// Token: 0x06004889 RID: 18569 RVA: 0x0003D0C8 File Offset: 0x0003B2C8
		public void ActivateTool(IEditionToolData editionToolData)
		{
			this.MySelectTool(editionToolData);
		}

		// Token: 0x17001536 RID: 5430
		// (get) Token: 0x0600488A RID: 18570 RVA: 0x0003D0DD File Offset: 0x0003B2DD
		public IEnumerable<IEditionToolData> Tools
		{
			get
			{
				return this.tools;
			}
		}

		// Token: 0x17001537 RID: 5431
		// (get) Token: 0x0600488B RID: 18571 RVA: 0x0003D0E9 File Offset: 0x0003B2E9
		// (set) Token: 0x0600488C RID: 18572 RVA: 0x0003D103 File Offset: 0x0003B303
		public IEditionToolData SelectedToolData
		{
			get
			{
				return (IEditionToolData)base.GetValue(ToolboxControl.SelectedToolDataProperty);
			}
			set
			{
				base.SetValue(ToolboxControl.SelectedToolDataProperty, value);
			}
		}

		// Token: 0x17001538 RID: 5432
		// (get) Token: 0x0600488D RID: 18573 RVA: 0x0003D11D File Offset: 0x0003B31D
		// (set) Token: 0x0600488E RID: 18574 RVA: 0x0003D137 File Offset: 0x0003B337
		public bool HideEmptyToolOptionsEditor
		{
			get
			{
				return (bool)base.GetValue(ToolboxControl.HideEmptyToolOptionsEditorProperty);
			}
			set
			{
				base.SetValue(ToolboxControl.HideEmptyToolOptionsEditorProperty, value);
			}
		}

		// Token: 0x140000F0 RID: 240
		// (add) Token: 0x0600488F RID: 18575 RVA: 0x00143B8C File Offset: 0x00141D8C
		// (remove) Token: 0x06004890 RID: 18576 RVA: 0x00143BD0 File Offset: 0x00141DD0
		public event EventHandler<SelectedItemChangedEventArgs<IEditionToolData>> SelectedToolChanged;

		// Token: 0x06004891 RID: 18577 RVA: 0x00143C14 File Offset: 0x00141E14
		protected void OnSelectedToolChanged(IEditionToolData previousToolData, IEditionToolData newToolData)
		{
			EventHandler<SelectedItemChangedEventArgs<IEditionToolData>> selectedToolChanged = this.SelectedToolChanged;
			if (selectedToolChanged != null)
			{
				selectedToolChanged(this, new SelectedItemChangedEventArgs<IEditionToolData>(previousToolData, newToolData));
			}
		}

		// Token: 0x06004892 RID: 18578 RVA: 0x0003D156 File Offset: 0x0003B356
		private static void SelectedToolDataPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			((ToolboxControl)dependencyObject).MyUpdateToolOptionsEditorVisibility();
		}

		// Token: 0x06004893 RID: 18579 RVA: 0x00143C48 File Offset: 0x00141E48
		private void MyUpdateToolOptionsEditorVisibility()
		{
			Visibility visibility = Visibility.Visible;
			if (this.HideEmptyToolOptionsEditor && (this.SelectedToolData == null || this.SelectedToolData.ToolOptionsEditor == null))
			{
				visibility = Visibility.Collapsed;
			}
			this.OptionsGroupBox.Visibility = visibility;
		}

		// Token: 0x06004894 RID: 18580 RVA: 0x0003D156 File Offset: 0x0003B356
		private static void HideEmptyToolOptionsEditorPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			((ToolboxControl)dependencyObject).MyUpdateToolOptionsEditorVisibility();
		}

		// Token: 0x06004895 RID: 18581 RVA: 0x00143C90 File Offset: 0x00141E90
		private void ToolsOnCollectionChanging(object sender, CollectionChangingEventArgs collectionChangingEventArgs)
		{
			if (collectionChangingEventArgs.Action == CollectionChangeAction.Remove)
			{
				RadRadioButton radRadioButton = this.ToolsItemsControl.ChildrenOfType<RadRadioButton>().FirstOrDefault((RadRadioButton item) => item.DataContext == collectionChangingEventArgs.Item);
				IEditionToolData selectedToolData = this.SelectedToolData;
				if (selectedToolData != null && radRadioButton != null && radRadioButton.IsChecked.GetValueOrDefault())
				{
					selectedToolData.IsSelected = false;
					radRadioButton.IsChecked = new bool?(false);
					this.OnSelectedToolChanged(selectedToolData, null);
					this.SelectedToolData = null;
				}
			}
		}

		// Token: 0x06004896 RID: 18582 RVA: 0x00143D30 File Offset: 0x00141F30
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

		// Token: 0x06004897 RID: 18583 RVA: 0x0003D16B File Offset: 0x0003B36B
		private void EditionTool_Deselected(object sender, RoutedEventArgs e)
		{
			if (!(sender is RadRadioButton))
			{
				return;
			}
			this.SelectedToolData = null;
		}

		// Token: 0x06004898 RID: 18584 RVA: 0x00143D6C File Offset: 0x00141F6C
		private void MySelectTool(IEditionToolData newSelectedTool)
		{
			IEditionToolData selectedToolData = this.SelectedToolData;
			this.SelectedToolData = newSelectedTool;
			this.OnSelectedToolChanged(selectedToolData, newSelectedTool);
		}

		// Token: 0x06004899 RID: 18585 RVA: 0x00143D9C File Offset: 0x00141F9C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107450378), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600489A RID: 18586 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600489B RID: 18587 RVA: 0x00143DE0 File Offset: 0x00141FE0
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
			case 2:
				this.ToolsItemsControl = (ItemsControl)target;
				return;
			case 3:
				this.OptionsGroupBox = (ContentControl)target;
				return;
			case 4:
				this.ToolOptionsPlaceHolder = (Grid)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x0600489C RID: 18588 RVA: 0x0003D189 File Offset: 0x0003B389
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

		// Token: 0x040020A9 RID: 8361
		private readonly RadObservableCollection<IEditionToolData> tools;

		// Token: 0x040020AA RID: 8362
		public static readonly DependencyProperty SelectedToolDataProperty = DependencyProperty.Register(#Phc.#3hc(107450825), typeof(IEditionToolData), typeof(ToolboxControl), new PropertyMetadata(null, new PropertyChangedCallback(ToolboxControl.SelectedToolDataPropertyChanged)));

		// Token: 0x040020AB RID: 8363
		public static readonly DependencyProperty HideEmptyToolOptionsEditorProperty = DependencyProperty.Register(#Phc.#3hc(107450832), typeof(bool), typeof(ToolboxControl), new UIPropertyMetadata(false, new PropertyChangedCallback(ToolboxControl.HideEmptyToolOptionsEditorPropertyChanged)));

		// Token: 0x040020AD RID: 8365
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ItemsControl ToolsItemsControl;

		// Token: 0x040020AE RID: 8366
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ContentControl OptionsGroupBox;

		// Token: 0x040020AF RID: 8367
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Grid ToolOptionsPlaceHolder;

		// Token: 0x040020B0 RID: 8368
		private bool _contentLoaded;
	}
}
