using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using #7hc;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RibbonView;

namespace StructurePoint.Products.Column.Controls
{
	// Token: 0x020006C4 RID: 1732
	internal sealed class ColumnRibbonDropdownButton : UserControl, IComponentConnector
	{
		// Token: 0x060039A8 RID: 14760 RVA: 0x0003209E File Offset: 0x0003029E
		public ColumnRibbonDropdownButton()
		{
			this.InitializeComponent();
			this.MenuItems = new ObservableCollection<RadMenuItem>();
			this.DropDownButton.DropDownOpening += this.DropDownButton_DropDownOpening;
		}

		// Token: 0x140000D7 RID: 215
		// (add) Token: 0x060039A9 RID: 14761 RVA: 0x00112708 File Offset: 0x00110908
		// (remove) Token: 0x060039AA RID: 14762 RVA: 0x0011274C File Offset: 0x0011094C
		public event EventHandler DropDownMenuOpening;

		// Token: 0x170011BD RID: 4541
		// (get) Token: 0x060039AB RID: 14763 RVA: 0x000320CE File Offset: 0x000302CE
		// (set) Token: 0x060039AC RID: 14764 RVA: 0x000320E8 File Offset: 0x000302E8
		public bool IsDropDownEnabled
		{
			get
			{
				return (bool)base.GetValue(ColumnRibbonDropdownButton.IsDropDownEnabledProperty);
			}
			set
			{
				base.SetValue(ColumnRibbonDropdownButton.IsDropDownEnabledProperty, value);
			}
		}

		// Token: 0x170011BE RID: 4542
		// (get) Token: 0x060039AD RID: 14765 RVA: 0x00032107 File Offset: 0x00030307
		// (set) Token: 0x060039AE RID: 14766 RVA: 0x0003211C File Offset: 0x0003031C
		public object TooltipContent
		{
			get
			{
				return base.GetValue(ColumnRibbonDropdownButton.TooltipContentProperty);
			}
			set
			{
				base.SetValue(ColumnRibbonDropdownButton.TooltipContentProperty, value);
			}
		}

		// Token: 0x170011BF RID: 4543
		// (get) Token: 0x060039AF RID: 14767 RVA: 0x00032136 File Offset: 0x00030336
		// (set) Token: 0x060039B0 RID: 14768 RVA: 0x00032150 File Offset: 0x00030350
		public bool IsBackgroundVisible
		{
			get
			{
				return (bool)base.GetValue(ColumnRibbonDropdownButton.IsBackgroundVisibleProperty);
			}
			set
			{
				base.SetValue(ColumnRibbonDropdownButton.IsBackgroundVisibleProperty, value);
			}
		}

		// Token: 0x170011C0 RID: 4544
		// (get) Token: 0x060039B1 RID: 14769 RVA: 0x0003216F File Offset: 0x0003036F
		// (set) Token: 0x060039B2 RID: 14770 RVA: 0x00032189 File Offset: 0x00030389
		public string Text
		{
			get
			{
				return (string)base.GetValue(ColumnRibbonDropdownButton.TextProperty);
			}
			set
			{
				base.SetValue(ColumnRibbonDropdownButton.TextProperty, value);
			}
		}

		// Token: 0x170011C1 RID: 4545
		// (get) Token: 0x060039B3 RID: 14771 RVA: 0x000321A3 File Offset: 0x000303A3
		// (set) Token: 0x060039B4 RID: 14772 RVA: 0x000321BD File Offset: 0x000303BD
		public ButtonSize Size
		{
			get
			{
				return (ButtonSize)base.GetValue(ColumnRibbonDropdownButton.SizeProperty);
			}
			set
			{
				base.SetValue(ColumnRibbonDropdownButton.SizeProperty, value);
			}
		}

		// Token: 0x170011C2 RID: 4546
		// (get) Token: 0x060039B5 RID: 14773 RVA: 0x000321DC File Offset: 0x000303DC
		// (set) Token: 0x060039B6 RID: 14774 RVA: 0x000321F6 File Offset: 0x000303F6
		public ObservableCollection<RadMenuItem> MenuItems
		{
			get
			{
				return (ObservableCollection<RadMenuItem>)base.GetValue(ColumnRibbonDropdownButton.MenuItemsProperty);
			}
			set
			{
				base.SetValue(ColumnRibbonDropdownButton.MenuItemsProperty, value);
			}
		}

		// Token: 0x170011C3 RID: 4547
		// (get) Token: 0x060039B7 RID: 14775 RVA: 0x00032210 File Offset: 0x00030410
		// (set) Token: 0x060039B8 RID: 14776 RVA: 0x0003222A File Offset: 0x0003042A
		public ImageSource Icon
		{
			get
			{
				return (ImageSource)base.GetValue(ColumnRibbonDropdownButton.IconProperty);
			}
			set
			{
				base.SetValue(ColumnRibbonDropdownButton.IconProperty, value);
			}
		}

		// Token: 0x170011C4 RID: 4548
		// (get) Token: 0x060039B9 RID: 14777 RVA: 0x00032244 File Offset: 0x00030444
		// (set) Token: 0x060039BA RID: 14778 RVA: 0x0003225E File Offset: 0x0003045E
		public DelegateCommand Command
		{
			get
			{
				return (DelegateCommand)base.GetValue(ColumnRibbonDropdownButton.CommandProperty);
			}
			set
			{
				base.SetValue(ColumnRibbonDropdownButton.CommandProperty, value);
			}
		}

		// Token: 0x170011C5 RID: 4549
		// (get) Token: 0x060039BB RID: 14779 RVA: 0x00032278 File Offset: 0x00030478
		// (set) Token: 0x060039BC RID: 14780 RVA: 0x0003228D File Offset: 0x0003048D
		public object CommandParameter
		{
			get
			{
				return base.GetValue(ColumnRibbonDropdownButton.CommandParameterProperty);
			}
			set
			{
				base.SetValue(ColumnRibbonDropdownButton.CommandParameterProperty, value);
			}
		}

		// Token: 0x170011C6 RID: 4550
		// (get) Token: 0x060039BD RID: 14781 RVA: 0x000322A7 File Offset: 0x000304A7
		// (set) Token: 0x060039BE RID: 14782 RVA: 0x000322C1 File Offset: 0x000304C1
		public Brush ButtonBackground
		{
			get
			{
				return (Brush)base.GetValue(ColumnRibbonDropdownButton.ButtonBackgroundProperty);
			}
			set
			{
				base.SetValue(ColumnRibbonDropdownButton.ButtonBackgroundProperty, value);
			}
		}

		// Token: 0x060039BF RID: 14783 RVA: 0x000322DB File Offset: 0x000304DB
		protected void OnDropDownMenuOpening()
		{
			EventHandler dropDownMenuOpening = this.DropDownMenuOpening;
			if (dropDownMenuOpening == null)
			{
				return;
			}
			dropDownMenuOpening(this, EventArgs.Empty);
		}

		// Token: 0x060039C0 RID: 14784 RVA: 0x000322FF File Offset: 0x000304FF
		private void DropDownButton_DropDownOpening(object sender, RoutedEventArgs e)
		{
			this.OnDropDownMenuOpening();
		}

		// Token: 0x060039C1 RID: 14785 RVA: 0x00112790 File Offset: 0x00110990
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107351008), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060039C2 RID: 14786 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060039C3 RID: 14787 RVA: 0x001127D4 File Offset: 0x001109D4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.MyButtonControl = (ColumnRibbonDropdownButton)target;
				return;
			case 2:
				this.Button = (RadRibbonButton)target;
				return;
			case 3:
				this.DropDownButton = (RadDropDownButton)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04001876 RID: 6262
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register(#Phc.#3hc(107350927), typeof(string), typeof(ColumnRibbonDropdownButton));

		// Token: 0x04001877 RID: 6263
		public static readonly DependencyProperty SizeProperty = DependencyProperty.Register(#Phc.#3hc(107397811), typeof(ButtonSize), typeof(ColumnRibbonDropdownButton));

		// Token: 0x04001878 RID: 6264
		public static readonly DependencyProperty MenuItemsProperty = DependencyProperty.Register(#Phc.#3hc(107350918), typeof(ObservableCollection<RadMenuItem>), typeof(ColumnRibbonDropdownButton), new PropertyMetadata(new ObservableCollection<RadMenuItem>()));

		// Token: 0x04001879 RID: 6265
		public static readonly DependencyProperty IconProperty = DependencyProperty.Register(#Phc.#3hc(107350937), typeof(ImageSource), typeof(ColumnRibbonDropdownButton));

		// Token: 0x0400187A RID: 6266
		public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(#Phc.#3hc(107350928), typeof(DelegateCommand), typeof(ColumnRibbonDropdownButton));

		// Token: 0x0400187B RID: 6267
		public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(#Phc.#3hc(107350883), typeof(object), typeof(ColumnRibbonDropdownButton), new PropertyMetadata(null));

		// Token: 0x0400187C RID: 6268
		public static readonly DependencyProperty IsBackgroundVisibleProperty = DependencyProperty.Register(#Phc.#3hc(107350858), typeof(bool), typeof(ColumnRibbonDropdownButton), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x0400187D RID: 6269
		public static readonly DependencyProperty ButtonBackgroundProperty = DependencyProperty.Register(#Phc.#3hc(107350829), typeof(Brush), typeof(ColumnRibbonDropdownButton), new PropertyMetadata(Brushes.Transparent));

		// Token: 0x0400187E RID: 6270
		public static readonly DependencyProperty TooltipContentProperty = DependencyProperty.Register(#Phc.#3hc(107381718), typeof(object), typeof(ColumnRibbonDropdownButton), new PropertyMetadata(null));

		// Token: 0x0400187F RID: 6271
		public static readonly DependencyProperty IsDropDownEnabledProperty = DependencyProperty.Register(#Phc.#3hc(107350836), typeof(bool), typeof(ColumnRibbonDropdownButton), new PropertyMetadata(true));

		// Token: 0x04001881 RID: 6273
		internal ColumnRibbonDropdownButton MyButtonControl;

		// Token: 0x04001882 RID: 6274
		internal RadRibbonButton Button;

		// Token: 0x04001883 RID: 6275
		internal RadDropDownButton DropDownButton;

		// Token: 0x04001884 RID: 6276
		private bool _contentLoaded;
	}
}
