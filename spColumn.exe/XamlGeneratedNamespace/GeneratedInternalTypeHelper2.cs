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
	// Token: 0x02000822 RID: 2082
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class GeneratedInternalTypeHelper2 : InternalTypeHelper
	{
		// Token: 0x060042B3 RID: 17075 RVA: 0x00038011 File Offset: 0x00036211
		protected override object CreateInstance(Type type, CultureInfo culture)
		{
			return Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, null, culture);
		}

		// Token: 0x060042B4 RID: 17076 RVA: 0x00038021 File Offset: 0x00036221
		protected override object GetPropertyValue(PropertyInfo propertyInfo, object target, CultureInfo culture)
		{
			return propertyInfo.GetValue(target, BindingFlags.Default, null, null, culture);
		}

		// Token: 0x060042B5 RID: 17077 RVA: 0x0003802E File Offset: 0x0003622E
		protected override void SetPropertyValue(PropertyInfo propertyInfo, object target, object value, CultureInfo culture)
		{
			propertyInfo.SetValue(target, value, BindingFlags.Default, null, null, culture);
		}

		// Token: 0x060042B6 RID: 17078 RVA: 0x00136DF8 File Offset: 0x00134FF8
		protected override Delegate CreateDelegate(Type delegateType, object target, string handler)
		{
			return (Delegate)target.GetType().InvokeMember(#Phc.#3hc(107396164), BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, target, new object[]
			{
				delegateType,
				handler
			}, null);
		}

		// Token: 0x060042B7 RID: 17079 RVA: 0x0003803D File Offset: 0x0003623D
		protected override void AddEventHandler(EventInfo eventInfo, object target, Delegate handler)
		{
			eventInfo.AddEventHandler(target, handler);
		}
	}
}
