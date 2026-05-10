using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Views.Definitions
{
	// Token: 0x0200007E RID: 126
	internal sealed class DataGridControlBarDefinitions : ColumnBaseView, IComponentConnector, IView
	{
		// Token: 0x0600045C RID: 1116 RVA: 0x00009483 File Offset: 0x00007683
		public DataGridControlBarDefinitions()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x00009491 File Offset: 0x00007691
		// (set) Token: 0x0600045E RID: 1118 RVA: 0x000094AB File Offset: 0x000076AB
		public Visibility AdjustmentButtonsVisibility
		{
			get
			{
				return (Visibility)base.GetValue(DataGridControlBarDefinitions.AdjustmentButtonsVisibilityProperty);
			}
			set
			{
				base.SetValue(DataGridControlBarDefinitions.AdjustmentButtonsVisibilityProperty, value);
			}
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x000094CA File Offset: 0x000076CA
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x000094E4 File Offset: 0x000076E4
		public DelegateCommand ApplyDefaultsCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(DataGridControlBarDefinitions.ApplyDefaultsCommandProperty);
			}
			set
			{
				base.SetValue(DataGridControlBarDefinitions.ApplyDefaultsCommandProperty, value);
			}
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00087DF0 File Offset: 0x00085FF0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107385800), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x000094FE File Offset: 0x000076FE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.RemoveRowButton = (RadButton)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.ExpanderButton = (RadToggleButton)target;
		}

		// Token: 0x040000BE RID: 190
		public static readonly DependencyProperty AdjustmentButtonsVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107386093), typeof(Visibility), typeof(DataGridControlBarDefinitions));

		// Token: 0x040000BF RID: 191
		public static readonly DependencyProperty ApplyDefaultsCommandProperty = DependencyProperty.Register(#Phc.#3hc(107385870), typeof(DelegateCommand), typeof(DataGridControlBarDefinitions));

		// Token: 0x040000C0 RID: 192
		internal RadButton RemoveRowButton;

		// Token: 0x040000C1 RID: 193
		internal RadToggleButton ExpanderButton;

		// Token: 0x040000C2 RID: 194
		private bool _contentLoaded;
	}
}
