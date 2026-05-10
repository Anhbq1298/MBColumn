using System;
using System.Windows;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic.ExtendedColorPicker
{
	// Token: 0x02000AD5 RID: 2773
	public sealed class ExtendedColorEditor : RadColorEditor
	{
		// Token: 0x06005A50 RID: 23120 RVA: 0x0016EE5C File Offset: 0x0016D05C
		static ExtendedColorEditor()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtendedColorEditor), new FrameworkPropertyMetadata(typeof(ExtendedColorEditor)));
		}

		// Token: 0x17001975 RID: 6517
		// (get) Token: 0x06005A51 RID: 23121 RVA: 0x0004B180 File Offset: 0x00049380
		// (set) Token: 0x06005A52 RID: 23122 RVA: 0x0004B19A File Offset: 0x0004939A
		public Style SliderStyle
		{
			get
			{
				return (Style)base.GetValue(ExtendedColorEditor.SliderStyleProperty);
			}
			set
			{
				base.SetValue(ExtendedColorEditor.SliderStyleProperty, value);
			}
		}

		// Token: 0x040025B5 RID: 9653
		public static readonly DependencyProperty SliderStyleProperty = DependencyProperty.Register(#Phc.#3hc(107427177), typeof(Style), typeof(ExtendedColorEditor), new PropertyMetadata(null));
	}
}
