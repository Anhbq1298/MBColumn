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
	// Token: 0x02000010 RID: 16
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class #N : InternalTypeHelper
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00003259 File Offset: 0x00001459
		protected object #B(Type #C, CultureInfo #D)
		{
			return Activator.CreateInstance(#C, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, null, #D);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003275 File Offset: 0x00001475
		protected object #E(PropertyInfo #F, object #G, CultureInfo #D)
		{
			return #F.GetValue(#G, BindingFlags.Default, null, null, #D);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000328E File Offset: 0x0000148E
		protected void #H(PropertyInfo #F, object #G, object #f, CultureInfo #D)
		{
			#F.SetValue(#G, #f, BindingFlags.Default, null, null, #D);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00084DB0 File Offset: 0x00082FB0
		protected Delegate #I(Type #J, object #G, string #K)
		{
			return (Delegate)#G.GetType().InvokeMember(#Phc.#3hc(107396164), BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, #G, new object[]
			{
				#J,
				#K
			}, null);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000032A9 File Offset: 0x000014A9
		protected void #L(EventInfo #M, object #G, Delegate #K)
		{
			#M.AddEventHandler(#G, #K);
		}
	}
}
