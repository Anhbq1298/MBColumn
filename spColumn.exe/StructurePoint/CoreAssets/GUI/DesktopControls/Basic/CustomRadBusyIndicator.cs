using System;
using System.Windows;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A8D RID: 2701
	public sealed class CustomRadBusyIndicator : RadBusyIndicator
	{
		// Token: 0x0600581B RID: 22555 RVA: 0x00168B64 File Offset: 0x00166D64
		static CustomRadBusyIndicator()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomRadBusyIndicator), new FrameworkPropertyMetadata(typeof(CustomRadBusyIndicator)));
		}

		// Token: 0x1700191B RID: 6427
		// (get) Token: 0x0600581C RID: 22556 RVA: 0x00048BE7 File Offset: 0x00046DE7
		// (set) Token: 0x0600581D RID: 22557 RVA: 0x00048C01 File Offset: 0x00046E01
		public DelegateCommand CancelCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(CustomRadBusyIndicator.CancelCommandProperty);
			}
			set
			{
				base.SetValue(CustomRadBusyIndicator.CancelCommandProperty, value);
			}
		}

		// Token: 0x1700191C RID: 6428
		// (get) Token: 0x0600581E RID: 22558 RVA: 0x00048C1B File Offset: 0x00046E1B
		// (set) Token: 0x0600581F RID: 22559 RVA: 0x00048C35 File Offset: 0x00046E35
		public string CancelText
		{
			get
			{
				return (string)base.GetValue(CustomRadBusyIndicator.CancelTextProperty);
			}
			set
			{
				base.SetValue(CustomRadBusyIndicator.CancelTextProperty, value);
			}
		}

		// Token: 0x1700191D RID: 6429
		// (get) Token: 0x06005820 RID: 22560 RVA: 0x00048C4F File Offset: 0x00046E4F
		// (set) Token: 0x06005821 RID: 22561 RVA: 0x00048C69 File Offset: 0x00046E69
		public bool IsCancellable
		{
			get
			{
				return (bool)base.GetValue(CustomRadBusyIndicator.IsCancellableProperty);
			}
			set
			{
				base.SetValue(CustomRadBusyIndicator.IsCancellableProperty, value);
			}
		}

		// Token: 0x040024E0 RID: 9440
		public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(#Phc.#3hc(107428688), typeof(DelegateCommand), typeof(CustomRadBusyIndicator), new PropertyMetadata(null));

		// Token: 0x040024E1 RID: 9441
		public static readonly DependencyProperty IsCancellableProperty = DependencyProperty.Register(#Phc.#3hc(107428667), typeof(bool), typeof(CustomRadBusyIndicator), new PropertyMetadata(false));

		// Token: 0x040024E2 RID: 9442
		public static readonly DependencyProperty CancelTextProperty = DependencyProperty.Register(#Phc.#3hc(107428614), typeof(string), typeof(CustomRadBusyIndicator), new PropertyMetadata(null));
	}
}
