using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Utils
{
	// Token: 0x020008D9 RID: 2265
	public sealed class BindingHelperParametersContainer<T>
	{
		// Token: 0x170014FB RID: 5371
		// (get) Token: 0x060047B4 RID: 18356 RVA: 0x0003C85F File Offset: 0x0003AA5F
		// (set) Token: 0x060047B5 RID: 18357 RVA: 0x0003C86B File Offset: 0x0003AA6B
		public DependencyObject Target { get; set; }

		// Token: 0x170014FC RID: 5372
		// (get) Token: 0x060047B6 RID: 18358 RVA: 0x0003C87C File Offset: 0x0003AA7C
		// (set) Token: 0x060047B7 RID: 18359 RVA: 0x0003C888 File Offset: 0x0003AA88
		public DependencyProperty TargetProperty { get; set; }

		// Token: 0x170014FD RID: 5373
		// (get) Token: 0x060047B8 RID: 18360 RVA: 0x0003C899 File Offset: 0x0003AA99
		// (set) Token: 0x060047B9 RID: 18361 RVA: 0x0003C8A5 File Offset: 0x0003AAA5
		public object Source { get; set; }

		// Token: 0x170014FE RID: 5374
		// (get) Token: 0x060047BA RID: 18362 RVA: 0x0003C8B6 File Offset: 0x0003AAB6
		// (set) Token: 0x060047BB RID: 18363 RVA: 0x0003C8C2 File Offset: 0x0003AAC2
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public Expression<Func<T>> PropertyExpression { get; set; }

		// Token: 0x170014FF RID: 5375
		// (get) Token: 0x060047BC RID: 18364 RVA: 0x0003C8D3 File Offset: 0x0003AAD3
		// (set) Token: 0x060047BD RID: 18365 RVA: 0x0003C8DF File Offset: 0x0003AADF
		public BindingMode BindingMode { get; set; }

		// Token: 0x17001500 RID: 5376
		// (get) Token: 0x060047BE RID: 18366 RVA: 0x0003C8F0 File Offset: 0x0003AAF0
		// (set) Token: 0x060047BF RID: 18367 RVA: 0x0003C8FC File Offset: 0x0003AAFC
		public object FallbackValue { get; set; }

		// Token: 0x17001501 RID: 5377
		// (get) Token: 0x060047C0 RID: 18368 RVA: 0x0003C90D File Offset: 0x0003AB0D
		// (set) Token: 0x060047C1 RID: 18369 RVA: 0x0003C919 File Offset: 0x0003AB19
		public IValueConverter Converter { get; set; }

		// Token: 0x17001502 RID: 5378
		// (get) Token: 0x060047C2 RID: 18370 RVA: 0x0003C92A File Offset: 0x0003AB2A
		// (set) Token: 0x060047C3 RID: 18371 RVA: 0x0003C936 File Offset: 0x0003AB36
		public object ConverterParameter { get; set; }

		// Token: 0x17001503 RID: 5379
		// (get) Token: 0x060047C4 RID: 18372 RVA: 0x0003C947 File Offset: 0x0003AB47
		// (set) Token: 0x060047C5 RID: 18373 RVA: 0x0003C953 File Offset: 0x0003AB53
		public string Format { get; set; }
	}
}
