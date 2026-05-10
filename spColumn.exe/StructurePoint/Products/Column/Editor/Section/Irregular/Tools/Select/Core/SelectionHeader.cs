using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using StructurePoint.Products.Column.Editor.Core.Selection;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select.Core
{
	// Token: 0x0200055B RID: 1371
	internal sealed class SelectionHeader : UserControl, IComponentConnector
	{
		// Token: 0x060030BE RID: 12478 RVA: 0x0002B2CA File Offset: 0x000294CA
		public SelectionHeader()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000FB7 RID: 4023
		// (get) Token: 0x060030BF RID: 12479 RVA: 0x0002B2D8 File Offset: 0x000294D8
		// (set) Token: 0x060030C0 RID: 12480 RVA: 0x0002B2F2 File Offset: 0x000294F2
		public string HeaderText
		{
			get
			{
				return (string)base.GetValue(SelectionHeader.HeaderTextProperty);
			}
			set
			{
				base.SetValue(SelectionHeader.HeaderTextProperty, value);
			}
		}

		// Token: 0x17000FB8 RID: 4024
		// (get) Token: 0x060030C1 RID: 12481 RVA: 0x0002B30C File Offset: 0x0002950C
		// (set) Token: 0x060030C2 RID: 12482 RVA: 0x0002B326 File Offset: 0x00029526
		public bool RemoveFromSelectionButtonVisible
		{
			get
			{
				return (bool)base.GetValue(SelectionHeader.RemoveFromSelectionButtonVisibleProperty);
			}
			set
			{
				base.SetValue(SelectionHeader.RemoveFromSelectionButtonVisibleProperty, value);
			}
		}

		// Token: 0x17000FB9 RID: 4025
		// (get) Token: 0x060030C3 RID: 12483 RVA: 0x0002B345 File Offset: 0x00029545
		// (set) Token: 0x060030C4 RID: 12484 RVA: 0x0002B35F File Offset: 0x0002955F
		public DelegateCommand RemoveFromSelectionCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(SelectionHeader.RemoveFromSelectionCommandProperty);
			}
			set
			{
				base.SetValue(SelectionHeader.RemoveFromSelectionCommandProperty, value);
			}
		}

		// Token: 0x17000FBA RID: 4026
		// (get) Token: 0x060030C5 RID: 12485 RVA: 0x0002B379 File Offset: 0x00029579
		// (set) Token: 0x060030C6 RID: 12486 RVA: 0x0002B393 File Offset: 0x00029593
		public SelectionObjectType SelectionObjectType
		{
			get
			{
				return (SelectionObjectType)base.GetValue(SelectionHeader.SelectionObjectTypeProperty);
			}
			set
			{
				base.SetValue(SelectionHeader.SelectionObjectTypeProperty, value);
			}
		}

		// Token: 0x060030C7 RID: 12487 RVA: 0x000F9FFC File Offset: 0x000F81FC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107355687), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060030C8 RID: 12488 RVA: 0x0002B3B2 File Offset: 0x000295B2
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040013CD RID: 5069
		public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register(#Phc.#3hc(107356118), typeof(string), typeof(SelectionHeader), new PropertyMetadata(null));

		// Token: 0x040013CE RID: 5070
		public static readonly DependencyProperty RemoveFromSelectionButtonVisibleProperty = DependencyProperty.Register(#Phc.#3hc(107356069), typeof(bool), typeof(SelectionHeader), new PropertyMetadata(false));

		// Token: 0x040013CF RID: 5071
		public static readonly DependencyProperty RemoveFromSelectionCommandProperty = DependencyProperty.Register(#Phc.#3hc(107356056), typeof(DelegateCommand), typeof(SelectionHeader), new PropertyMetadata(null));

		// Token: 0x040013D0 RID: 5072
		public static readonly DependencyProperty SelectionObjectTypeProperty = DependencyProperty.Register(#Phc.#3hc(107356019), typeof(SelectionObjectType), typeof(SelectionHeader), new PropertyMetadata(SelectionObjectType.Bars));

		// Token: 0x040013D1 RID: 5073
		private bool _contentLoaded;
	}
}
