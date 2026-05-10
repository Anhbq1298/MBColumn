using System;
using System.Windows.Controls;

namespace #tRb
{
	// Token: 0x020006C5 RID: 1733
	internal sealed class #sRb : TextBox
	{
		// Token: 0x060039C5 RID: 14789 RVA: 0x0003230F File Offset: 0x0003050F
		protected void #rRb(TextChangedEventArgs #He)
		{
			base.OnTextChanged(#He);
			base.CaretIndex = base.Text.Length;
			base.ScrollToEnd();
		}
	}
}
