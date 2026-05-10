using System;
using System.Windows;
using #7hc;
using #eU;
using StructurePoint.Products.Column.Model;

namespace StructurePoint.Products.Column.ViewModels.Core
{
	// Token: 0x0200028A RID: 650
	internal sealed class ModelBindingProxy : Freezable
	{
		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x060014FC RID: 5372 RVA: 0x00016199 File Offset: 0x00014399
		// (set) Token: 0x060014FD RID: 5373 RVA: 0x000161B3 File Offset: 0x000143B3
		public #oW Context
		{
			get
			{
				return (#oW)base.GetValue(ModelBindingProxy.ContextProperty);
			}
			set
			{
				base.SetValue(ModelBindingProxy.ContextProperty, value);
			}
		}

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x060014FE RID: 5374 RVA: 0x000161CD File Offset: 0x000143CD
		// (set) Token: 0x060014FF RID: 5375 RVA: 0x000161E7 File Offset: 0x000143E7
		public ColumnModel Model
		{
			get
			{
				return (ColumnModel)base.GetValue(ModelBindingProxy.ModelProperty);
			}
			set
			{
				base.SetValue(ModelBindingProxy.ModelProperty, value);
			}
		}

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x06001500 RID: 5376 RVA: 0x00016201 File Offset: 0x00014401
		// (set) Token: 0x06001501 RID: 5377 RVA: 0x00016216 File Offset: 0x00014416
		public object Data
		{
			get
			{
				return base.GetValue(ModelBindingProxy.DataProperty);
			}
			set
			{
				base.SetValue(ModelBindingProxy.DataProperty, value);
			}
		}

		// Token: 0x06001502 RID: 5378 RVA: 0x00016230 File Offset: 0x00014430
		protected override Freezable CreateInstanceCore()
		{
			return new ModelBindingProxy();
		}

		// Token: 0x06001503 RID: 5379 RVA: 0x00009E6A File Offset: 0x0000806A
		private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		// Token: 0x0400088E RID: 2190
		public static readonly DependencyProperty ModelProperty = DependencyProperty.Register(#Phc.#3hc(107407457), typeof(ColumnModel), typeof(ModelBindingProxy), new PropertyMetadata(null, new PropertyChangedCallback(ModelBindingProxy.PropertyChangedCallback)));

		// Token: 0x0400088F RID: 2191
		public static readonly DependencyProperty ContextProperty = DependencyProperty.Register(#Phc.#3hc(107407480), typeof(#oW), typeof(ModelBindingProxy), new PropertyMetadata(null));

		// Token: 0x04000890 RID: 2192
		public static readonly DependencyProperty DataProperty = DependencyProperty.Register(#Phc.#3hc(107407435), typeof(object), typeof(ModelBindingProxy), new PropertyMetadata(null));
	}
}
