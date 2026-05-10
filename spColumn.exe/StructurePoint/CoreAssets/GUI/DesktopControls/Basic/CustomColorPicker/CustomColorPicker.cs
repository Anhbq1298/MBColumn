using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic.CustomColorPicker
{
	// Token: 0x02000ADB RID: 2779
	public sealed class CustomColorPicker : UserControl, IComponentConnector
	{
		// Token: 0x06005A77 RID: 23159 RVA: 0x0004B47E File Offset: 0x0004967E
		public CustomColorPicker()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700197E RID: 6526
		// (get) Token: 0x06005A78 RID: 23160 RVA: 0x0004B48C File Offset: 0x0004968C
		// (set) Token: 0x06005A79 RID: 23161 RVA: 0x0004B4A6 File Offset: 0x000496A6
		public Color SelectedColor
		{
			get
			{
				return (Color)base.GetValue(CustomColorPicker.SelectedColorProperty);
			}
			set
			{
				base.SetValue(CustomColorPicker.SelectedColorProperty, value);
			}
		}

		// Token: 0x1700197F RID: 6527
		// (get) Token: 0x06005A7A RID: 23162 RVA: 0x0004B4C5 File Offset: 0x000496C5
		// (set) Token: 0x06005A7B RID: 23163 RVA: 0x0004B4DF File Offset: 0x000496DF
		public ColorPickerSize ColorPickerSize
		{
			get
			{
				return (ColorPickerSize)base.GetValue(CustomColorPicker.ColorPickerSizeProperty);
			}
			set
			{
				base.SetValue(CustomColorPicker.ColorPickerSizeProperty, value);
			}
		}

		// Token: 0x17001980 RID: 6528
		// (get) Token: 0x06005A7C RID: 23164 RVA: 0x0004B4FE File Offset: 0x000496FE
		public bool IsDropDownOpen
		{
			get
			{
				return this.ColorPicker.IsDropDownOpen;
			}
		}

		// Token: 0x06005A7D RID: 23165 RVA: 0x0016F288 File Offset: 0x0016D488
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107423320), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06005A7E RID: 23166 RVA: 0x0004B513 File Offset: 0x00049713
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.ColorPicker = (RadColorPicker)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x040025C8 RID: 9672
		public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register(#Phc.#3hc(107411106), typeof(Color), typeof(CustomColorPicker), new PropertyMetadata(default(Color)));

		// Token: 0x040025C9 RID: 9673
		public static readonly DependencyProperty ColorPickerSizeProperty = DependencyProperty.Register(#Phc.#3hc(107423743), typeof(ColorPickerSize), typeof(CustomColorPicker), new PropertyMetadata(ColorPickerSize.Normal));

		// Token: 0x040025CA RID: 9674
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadColorPicker ColorPicker;

		// Token: 0x040025CB RID: 9675
		private bool _contentLoaded;
	}
}
