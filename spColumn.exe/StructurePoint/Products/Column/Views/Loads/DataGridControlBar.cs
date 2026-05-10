using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Views.Loads
{
	// Token: 0x0200006F RID: 111
	internal sealed class DataGridControlBar : UserControl, IComponentConnector
	{
		// Token: 0x0600041C RID: 1052 RVA: 0x00009001 File Offset: 0x00007201
		public DataGridControlBar()
		{
			this.InitializeComponent();
			this.<InvalidateRemoveDuplicatesCommand>k__BackingField = new DelegateCommand(new Action<object>(this.ExecuteInvalidateRemoveDuplicatesCommand));
		}

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x00009026 File Offset: 0x00007226
		// (set) Token: 0x0600041E RID: 1054 RVA: 0x00009040 File Offset: 0x00007240
		public bool IsExpanderActive
		{
			get
			{
				return (bool)base.GetValue(DataGridControlBar.IsExpanderActiveProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.IsExpanderActiveProperty, value);
			}
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x0000905F File Offset: 0x0000725F
		// (set) Token: 0x06000420 RID: 1056 RVA: 0x00009079 File Offset: 0x00007279
		public Visibility AdjustmentButtonsVisibility
		{
			get
			{
				return (Visibility)base.GetValue(DataGridControlBar.AdjustmentButtonsVisibilityProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.AdjustmentButtonsVisibilityProperty, value);
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x00009098 File Offset: 0x00007298
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x000090B2 File Offset: 0x000072B2
		public bool IsClearButtonVisible
		{
			get
			{
				return (bool)base.GetValue(DataGridControlBar.IsClearButtonVisibleProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.IsClearButtonVisibleProperty, value);
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x000090D1 File Offset: 0x000072D1
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x000090EB File Offset: 0x000072EB
		public bool IsOptionsButtonVisible
		{
			get
			{
				return (bool)base.GetValue(DataGridControlBar.IsOptionsButtonVisibleProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.IsOptionsButtonVisibleProperty, value);
			}
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x0000910A File Offset: 0x0000730A
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x00009124 File Offset: 0x00007324
		public bool IsFactoredLoadsMenuVisible
		{
			get
			{
				return (bool)base.GetValue(DataGridControlBar.IsFactoredLoadsMenuVisibleProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.IsFactoredLoadsMenuVisibleProperty, value);
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x00009143 File Offset: 0x00007343
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x0000915D File Offset: 0x0000735D
		public DelegateCommand ClearCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(DataGridControlBar.ClearCommandProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.ClearCommandProperty, value);
			}
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x00009177 File Offset: 0x00007377
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x00009191 File Offset: 0x00007391
		public DelegateCommand RemoveDuplicatesCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(DataGridControlBar.RemoveDuplicatesCommandProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.RemoveDuplicatesCommandProperty, value);
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x000091AB File Offset: 0x000073AB
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x000091C5 File Offset: 0x000073C5
		public DelegateCommand ServiceLoadsToFactoredLoads
		{
			get
			{
				return (DelegateCommand)base.GetValue(DataGridControlBar.ServiceLoadsToFactoredLoadsProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.ServiceLoadsToFactoredLoadsProperty, value);
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x000091DF File Offset: 0x000073DF
		public DelegateCommand InvalidateRemoveDuplicatesCommand { get; }

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x000091EB File Offset: 0x000073EB
		// (set) Token: 0x0600042F RID: 1071 RVA: 0x00009205 File Offset: 0x00007405
		public DelegateCommand ApplyDefaultsCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(DataGridControlBar.ApplyDefaultsCommandProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.ApplyDefaultsCommandProperty, value);
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x0000921F File Offset: 0x0000741F
		// (set) Token: 0x06000431 RID: 1073 RVA: 0x00009239 File Offset: 0x00007439
		public DelegateCommand ImportCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(DataGridControlBar.ImportCommandProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.ImportCommandProperty, value);
			}
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x00009253 File Offset: 0x00007453
		// (set) Token: 0x06000433 RID: 1075 RVA: 0x0000926D File Offset: 0x0000746D
		public DelegateCommand ExportCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(DataGridControlBar.ExportCommandProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.ExportCommandProperty, value);
			}
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x00009287 File Offset: 0x00007487
		// (set) Token: 0x06000435 RID: 1077 RVA: 0x000092A1 File Offset: 0x000074A1
		public string DropDownAdditionalText
		{
			get
			{
				return (string)base.GetValue(DataGridControlBar.DropDownAdditionalTextProperty);
			}
			set
			{
				base.SetValue(DataGridControlBar.DropDownAdditionalTextProperty, value);
			}
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x000092BB File Offset: 0x000074BB
		public override void EndInit()
		{
			base.EndInit();
			if (this.IsExpanderActive)
			{
				this.ExpanderButton.IsEnabled = true;
			}
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x000092E3 File Offset: 0x000074E3
		private void ExecuteInvalidateRemoveDuplicatesCommand(object parameter)
		{
			DelegateCommand removeDuplicatesCommand = this.RemoveDuplicatesCommand;
			if (removeDuplicatesCommand == null)
			{
				return;
			}
			removeDuplicatesCommand.InvalidateCanExecute();
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x000878E0 File Offset: 0x00085AE0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107386739), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x000092FD File Offset: 0x000074FD
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

		// Token: 0x0400009C RID: 156
		public static readonly DependencyProperty IsExpanderActiveProperty = DependencyProperty.Register(#Phc.#3hc(107386630), typeof(bool), typeof(DataGridControlBar));

		// Token: 0x0400009D RID: 157
		public static readonly DependencyProperty AdjustmentButtonsVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107386093), typeof(Visibility), typeof(DataGridControlBar));

		// Token: 0x0400009E RID: 158
		public static readonly DependencyProperty IsClearButtonVisibleProperty = DependencyProperty.Register(#Phc.#3hc(107386056), typeof(bool), typeof(DataGridControlBar));

		// Token: 0x0400009F RID: 159
		public static readonly DependencyProperty IsOptionsButtonVisibleProperty = DependencyProperty.Register(#Phc.#3hc(107386027), typeof(bool), typeof(DataGridControlBar));

		// Token: 0x040000A0 RID: 160
		public static readonly DependencyProperty IsFactoredLoadsMenuVisibleProperty = DependencyProperty.Register(#Phc.#3hc(107385994), typeof(bool), typeof(DataGridControlBar));

		// Token: 0x040000A1 RID: 161
		public static readonly DependencyProperty ClearCommandProperty = DependencyProperty.Register(#Phc.#3hc(107385957), typeof(DelegateCommand), typeof(DataGridControlBar));

		// Token: 0x040000A2 RID: 162
		public static readonly DependencyProperty RemoveDuplicatesCommandProperty = DependencyProperty.Register(#Phc.#3hc(107385972), typeof(DelegateCommand), typeof(DataGridControlBar));

		// Token: 0x040000A3 RID: 163
		public static readonly DependencyProperty ServiceLoadsToFactoredLoadsProperty = DependencyProperty.Register(#Phc.#3hc(107385939), typeof(DelegateCommand), typeof(DataGridControlBar));

		// Token: 0x040000A4 RID: 164
		public static readonly DependencyProperty ApplyDefaultsCommandProperty = DependencyProperty.Register(#Phc.#3hc(107385870), typeof(DelegateCommand), typeof(DataGridControlBar));

		// Token: 0x040000A5 RID: 165
		public static readonly DependencyProperty ImportCommandProperty = DependencyProperty.Register(#Phc.#3hc(107385873), typeof(DelegateCommand), typeof(DataGridControlBar));

		// Token: 0x040000A6 RID: 166
		public static readonly DependencyProperty ExportCommandProperty = DependencyProperty.Register(#Phc.#3hc(107386364), typeof(DelegateCommand), typeof(DataGridControlBar));

		// Token: 0x040000A7 RID: 167
		public static readonly DependencyProperty DropDownAdditionalTextProperty = DependencyProperty.Register(#Phc.#3hc(107386311), typeof(string), typeof(DataGridControlBar), new PropertyMetadata(null));

		// Token: 0x040000A9 RID: 169
		internal RadButton RemoveRowButton;

		// Token: 0x040000AA RID: 170
		internal RadToggleButton ExpanderButton;

		// Token: 0x040000AB RID: 171
		private bool _contentLoaded;
	}
}
