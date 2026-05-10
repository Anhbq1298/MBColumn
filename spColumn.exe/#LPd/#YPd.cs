using System;
using #mKd;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Commands;
using Telerik.Windows.Documents.UI;

namespace #LPd
{
	// Token: 0x02000DF9 RID: 3577
	internal sealed class #YPd : FixedDocumentViewerCommandBase
	{
		// Token: 0x060080F7 RID: 33015 RVA: 0x00069075 File Offset: 0x00067275
		public #YPd(FixedDocumentViewerBase #ZPd) : base(#ZPd)
		{
			base.Viewer.ScaleFactorChanged += new EventHandler<ScaleFactorChangedEventArgs>(this.#XPd);
		}

		// Token: 0x060080F8 RID: 33016 RVA: 0x001C1770 File Offset: 0x001BF970
		public void #0(object #Sb)
		{
			double num = \u0012\u0002.\u008C\u0004(\u001B\u0002.~\u0003\u0005(\u008F\u0006.\u0090\u0010(this)) / #lKd.ZoomStep, 3);
			if (num < #lKd.MinScaleFactor)
			{
				num = #lKd.MinScaleFactor;
			}
			\u009F\u0002.~\u0095\u0006(\u008F\u0006.\u0090\u0010(this), num);
		}

		// Token: 0x060080F9 RID: 33017 RVA: 0x00069095 File Offset: 0x00067295
		public bool #WPd(object #Sb)
		{
			return \u001B\u0002.~\u0003\u0005(\u008F\u0006.\u0090\u0010(this)) > 0.1;
		}

		// Token: 0x060080FA RID: 33018 RVA: 0x000690C3 File Offset: 0x000672C3
		private void #XPd(object #Ge, EventArgs #He)
		{
			\u0007.\u0088(this);
		}
	}
}
