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
	// Token: 0x02000B30 RID: 2864
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class #azc : InternalTypeHelper
	{
		// Token: 0x06005DC3 RID: 24003 RVA: 0x00038011 File Offset: 0x00036211
		protected object #B(Type #C, CultureInfo #D)
		{
			return Activator.CreateInstance(#C, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, null, #D);
		}

		// Token: 0x06005DC4 RID: 24004 RVA: 0x00038021 File Offset: 0x00036221
		protected object #E(PropertyInfo #F, object #G, CultureInfo #D)
		{
			return #F.GetValue(#G, BindingFlags.Default, null, null, #D);
		}

		// Token: 0x06005DC5 RID: 24005 RVA: 0x0004E278 File Offset: 0x0004C478
		protected void #H(PropertyInfo #F, object #G, object #f, CultureInfo #D)
		{
			BindingFlags invokeAttr = BindingFlags.Default;
			Binder binder = null;
			object[] index = null;
			if (4 != 0)
			{
				#F.SetValue(#G, #f, invokeAttr, binder, index, #D);
			}
		}

		// Token: 0x06005DC6 RID: 24006 RVA: 0x00136DF8 File Offset: 0x00134FF8
		protected Delegate #I(Type #J, object #G, string #K)
		{
			return (Delegate)#G.GetType().InvokeMember(#Phc.#3hc(107396164), BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, #G, new object[]
			{
				#J,
				#K
			}, null);
		}

		// Token: 0x06005DC7 RID: 24007 RVA: 0x0004E293 File Offset: 0x0004C493
		protected void #L(EventInfo #M, object #G, Delegate #K)
		{
			if (2 != 0)
			{
				#M.AddEventHandler(#G, #K);
			}
		}
	}
}
