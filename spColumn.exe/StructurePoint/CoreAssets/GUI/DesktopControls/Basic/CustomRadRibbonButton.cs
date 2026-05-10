using System;
using System.Windows;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A92 RID: 2706
	public sealed class CustomRadRibbonButton : RadRibbonButton
	{
		// Token: 0x06005848 RID: 22600 RVA: 0x001691BC File Offset: 0x001673BC
		static CustomRadRibbonButton()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomRadRibbonButton), new FrameworkPropertyMetadata(typeof(CustomRadRibbonButton)));
		}

		// Token: 0x17001924 RID: 6436
		// (get) Token: 0x06005849 RID: 22601 RVA: 0x00048F59 File Offset: 0x00047159
		// (set) Token: 0x0600584A RID: 22602 RVA: 0x00048F73 File Offset: 0x00047173
		public bool OverrideIsEnabledCore
		{
			get
			{
				return (bool)base.GetValue(CustomRadRibbonButton.OverrideIsEnabledCoreProperty);
			}
			set
			{
				base.SetValue(CustomRadRibbonButton.OverrideIsEnabledCoreProperty, value);
			}
		}

		// Token: 0x17001925 RID: 6437
		// (get) Token: 0x0600584B RID: 22603 RVA: 0x00048F92 File Offset: 0x00047192
		protected override bool IsEnabledCore
		{
			get
			{
				return this.OverrideIsEnabledCore || base.IsEnabledCore;
			}
		}

		// Token: 0x040024F1 RID: 9457
		public static readonly DependencyProperty OverrideIsEnabledCoreProperty = DependencyProperty.Register(#Phc.#3hc(107427847), typeof(bool), typeof(CustomRadRibbonButton), new PropertyMetadata(false));
	}
}
