using System;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;

namespace StructurePoint.CoreAssets.Column.Core.ViewModels.Templates
{
	// Token: 0x02000829 RID: 2089
	public sealed class TemplateParameterValueChangedEventArgs : EventArgs
	{
		// Token: 0x060042E2 RID: 17122 RVA: 0x00038276 File Offset: 0x00036476
		public TemplateParameterValueChangedEventArgs(ParameterRuntime parameter, object value, string serializedValue)
		{
			this.Parameter = parameter;
			this.Value = value;
			this.SerializedValue = serializedValue;
		}

		// Token: 0x170013C2 RID: 5058
		// (get) Token: 0x060042E3 RID: 17123 RVA: 0x00038293 File Offset: 0x00036493
		public ParameterRuntime Parameter { get; }

		// Token: 0x170013C3 RID: 5059
		// (get) Token: 0x060042E4 RID: 17124 RVA: 0x0003829B File Offset: 0x0003649B
		public object Value { get; }

		// Token: 0x170013C4 RID: 5060
		// (get) Token: 0x060042E5 RID: 17125 RVA: 0x000382A3 File Offset: 0x000364A3
		public string SerializedValue { get; }
	}
}
