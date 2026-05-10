using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Markup;
using #7hc;

namespace XamlGeneratedNamespace
{
	// Token: 0x0200087D RID: 2173
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class GeneratedInternalTypeHelper3 : InternalTypeHelper
	{
		// Token: 0x060044D9 RID: 17625 RVA: 0x00003259 File Offset: 0x00001459
		protected override object CreateInstance(Type type, CultureInfo culture)
		{
			return Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, null, culture);
		}

		// Token: 0x060044DA RID: 17626 RVA: 0x00003275 File Offset: 0x00001475
		protected override object GetPropertyValue(PropertyInfo propertyInfo, object target, CultureInfo culture)
		{
			return propertyInfo.GetValue(target, BindingFlags.Default, null, null, culture);
		}

		// Token: 0x060044DB RID: 17627 RVA: 0x0000328E File Offset: 0x0000148E
		protected override void SetPropertyValue(PropertyInfo propertyInfo, object target, object value, CultureInfo culture)
		{
			propertyInfo.SetValue(target, value, BindingFlags.Default, null, null, culture);
		}

		// Token: 0x060044DC RID: 17628 RVA: 0x00084DB0 File Offset: 0x00082FB0
		protected override Delegate CreateDelegate(Type delegateType, object target, string handler)
		{
			return (Delegate)target.GetType().InvokeMember(#Phc.#3hc(107396164), BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, target, new object[]
			{
				delegateType,
				handler
			}, null);
		}

		// Token: 0x060044DD RID: 17629 RVA: 0x000032A9 File Offset: 0x000014A9
		protected override void AddEventHandler(EventInfo eventInfo, object target, Delegate handler)
		{
			eventInfo.AddEventHandler(target, handler);
		}
	}
}
