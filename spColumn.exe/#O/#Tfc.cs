using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Markup;
using #7hc;

namespace #O
{
	// Token: 0x0200071C RID: 1820
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class #Tfc : InternalTypeHelper
	{
		// Token: 0x06003BEB RID: 15339 RVA: 0x00033B64 File Offset: 0x00031D64
		protected object #B(Type #C, CultureInfo #D)
		{
			return \u0081.\u0082\u0002(#C, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, null, #D);
		}

		// Token: 0x06003BEC RID: 15340 RVA: 0x00033B85 File Offset: 0x00031D85
		protected object #E(PropertyInfo #F, object #G, CultureInfo #D)
		{
			return \u0082.~\u0083\u0002(#F, #G, BindingFlags.Default, null, null, #D);
		}

		// Token: 0x06003BED RID: 15341 RVA: 0x00033BA7 File Offset: 0x00031DA7
		protected void #H(PropertyInfo #F, object #G, object #f, CultureInfo #D)
		{
			\u0083.~\u0084\u0002(#F, #G, #f, BindingFlags.Default, null, null, #D);
		}

		// Token: 0x06003BEE RID: 15342 RVA: 0x00119114 File Offset: 0x00117314
		protected Delegate #I(Type #J, object #G, string #K)
		{
			return (Delegate)\u0086.~\u0089\u0002(\u0084.~\u0086\u0002(#G), #Phc.#3hc(107396164), BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, #G, new object[]
			{
				#J,
				#K
			}, null);
		}

		// Token: 0x06003BEF RID: 15343 RVA: 0x00033BCF File Offset: 0x00031DCF
		protected void #L(EventInfo #M, object #G, Delegate #K)
		{
			\u0087.~\u008A\u0002(#M, #G, #K);
		}
	}
}
