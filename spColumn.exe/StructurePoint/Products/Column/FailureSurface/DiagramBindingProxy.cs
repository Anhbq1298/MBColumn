using System;
using System.Windows;
using #7hc;
using #S9;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.FailureSurface
{
	// Token: 0x020003C7 RID: 967
	internal sealed class DiagramBindingProxy : Freezable
	{
		// Token: 0x17000B88 RID: 2952
		// (get) Token: 0x0600211E RID: 8478 RVA: 0x00020451 File Offset: 0x0001E651
		// (set) Token: 0x0600211F RID: 8479 RVA: 0x0002046B File Offset: 0x0001E66B
		public #vbb Manager
		{
			get
			{
				return (#vbb)base.GetValue(DiagramBindingProxy.ManagerProperty);
			}
			set
			{
				base.SetValue(DiagramBindingProxy.ManagerProperty, value);
			}
		}

		// Token: 0x17000B89 RID: 2953
		// (get) Token: 0x06002120 RID: 8480 RVA: 0x00020485 File Offset: 0x0001E685
		// (set) Token: 0x06002121 RID: 8481 RVA: 0x0002049F File Offset: 0x0001E69F
		public ICoreServices Services
		{
			get
			{
				return (ICoreServices)base.GetValue(DiagramBindingProxy.ServicesProperty);
			}
			set
			{
				base.SetValue(DiagramBindingProxy.ServicesProperty, value);
			}
		}

		// Token: 0x06002122 RID: 8482 RVA: 0x000204B9 File Offset: 0x0001E6B9
		protected override Freezable CreateInstanceCore()
		{
			return new DiagramBindingProxy();
		}

		// Token: 0x04000D49 RID: 3401
		public static readonly DependencyProperty ManagerProperty = DependencyProperty.Register(#Phc.#3hc(107397910), typeof(#vbb), typeof(DiagramBindingProxy), new PropertyMetadata(null));

		// Token: 0x04000D4A RID: 3402
		public static readonly DependencyProperty ServicesProperty = DependencyProperty.Register(#Phc.#3hc(107397353), typeof(ICoreServices), typeof(DiagramBindingProxy), new PropertyMetadata(null));
	}
}
