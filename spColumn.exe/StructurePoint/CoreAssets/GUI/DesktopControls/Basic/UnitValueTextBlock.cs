using System;
using System.Windows;
using System.Windows.Controls;
using #7hc;
using StructurePoint.CoreAssets.Units.Formatters;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AD0 RID: 2768
	public sealed class UnitValueTextBlock : TextBlock
	{
		// Token: 0x06005A18 RID: 23064 RVA: 0x0016E14C File Offset: 0x0016C34C
		private void MyChangeDisplayValue(string newValue)
		{
			IUnitValueFormatter unitValueFormatter = this.UnitValueFormatter;
			base.Text = ((unitValueFormatter != null) ? unitValueFormatter.CreateDisplayValue(newValue) : newValue);
		}

		// Token: 0x06005A19 RID: 23065 RVA: 0x0004AD9F File Offset: 0x00048F9F
		private static void MyOnBoundValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			((UnitValueTextBlock)sender).MyChangeDisplayValue(e.NewValue as string);
		}

		// Token: 0x06005A1A RID: 23066 RVA: 0x0004ADC4 File Offset: 0x00048FC4
		private static void MyOnUnitValueFormatterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			UnitValueTextBlock unitValueTextBlock = (UnitValueTextBlock)sender;
			unitValueTextBlock.MyChangeDisplayValue(unitValueTextBlock.UnitValue);
		}

		// Token: 0x1700196F RID: 6511
		// (get) Token: 0x06005A1B RID: 23067 RVA: 0x0004ADDF File Offset: 0x00048FDF
		// (set) Token: 0x06005A1C RID: 23068 RVA: 0x0004ADF9 File Offset: 0x00048FF9
		public string UnitValue
		{
			get
			{
				return (string)base.GetValue(UnitValueTextBlock.UnitValueProperty);
			}
			set
			{
				base.SetValue(UnitValueTextBlock.UnitValueProperty, value);
			}
		}

		// Token: 0x17001970 RID: 6512
		// (get) Token: 0x06005A1D RID: 23069 RVA: 0x0004AE13 File Offset: 0x00049013
		// (set) Token: 0x06005A1E RID: 23070 RVA: 0x0004AE2D File Offset: 0x0004902D
		public IUnitValueFormatter UnitValueFormatter
		{
			get
			{
				return (IUnitValueFormatter)base.GetValue(UnitValueTextBlock.UnitValueFormatterProperty);
			}
			set
			{
				base.SetValue(UnitValueTextBlock.UnitValueFormatterProperty, value);
			}
		}

		// Token: 0x04002599 RID: 9625
		public static readonly DependencyProperty UnitValueProperty = DependencyProperty.Register(#Phc.#3hc(107426656), typeof(string), typeof(UnitValueTextBlock), new PropertyMetadata(null, new PropertyChangedCallback(UnitValueTextBlock.MyOnBoundValueChanged)));

		// Token: 0x0400259A RID: 9626
		public static readonly DependencyProperty UnitValueFormatterProperty = DependencyProperty.Register(#Phc.#3hc(107456546), typeof(IUnitValueFormatter), typeof(UnitValueTextBlock), new FrameworkPropertyMetadata(new PropertyChangedCallback(UnitValueTextBlock.MyOnUnitValueFormatterChanged)));
	}
}
