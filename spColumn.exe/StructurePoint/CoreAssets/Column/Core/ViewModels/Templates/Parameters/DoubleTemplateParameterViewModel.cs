using System;
using System.Globalization;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;

namespace StructurePoint.CoreAssets.Column.Core.ViewModels.Templates.Parameters
{
	// Token: 0x02000837 RID: 2103
	internal sealed class DoubleTemplateParameterViewModel : TemplateParameterViewModelBase
	{
		// Token: 0x06004344 RID: 17220 RVA: 0x0003857F File Offset: 0x0003677F
		public DoubleTemplateParameterViewModel(ParameterRuntime parameter, TemplateEngine engine) : base(engine, parameter)
		{
			this.LoadValue(parameter.EffectiveValue);
		}

		// Token: 0x170013DC RID: 5084
		// (get) Token: 0x06004345 RID: 17221 RVA: 0x0003862B File Offset: 0x0003682B
		// (set) Token: 0x06004346 RID: 17222 RVA: 0x00137F0C File Offset: 0x0013610C
		public double Value
		{
			get
			{
				return this.value;
			}
			set
			{
				if (this.ValidateParameter(value, #Phc.#3hc(107399374)) && this.value != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107399374));
					this.value = value;
					this.OnParameterValueChanged(new TemplateParameterValueChangedEventArgs(base.Parameter, value, value.ToString(CultureInfo.InvariantCulture)));
					base.RaisePropertyChanged(#Phc.#3hc(107399374));
				}
			}
		}

		// Token: 0x06004347 RID: 17223 RVA: 0x00038633 File Offset: 0x00036833
		public override void LoadValue(object newValue)
		{
			this.value = (double)newValue;
			base.RaisePropertyChanged(#Phc.#3hc(107399374));
			base.ClearErrors();
			base.LoadValue(newValue);
		}

		// Token: 0x06004348 RID: 17224 RVA: 0x0003865E File Offset: 0x0003685E
		public override object GetEffectiveValue()
		{
			return this.Value;
		}

		// Token: 0x06004349 RID: 17225 RVA: 0x00137F84 File Offset: 0x00136184
		public override string GetSerializedValue()
		{
			return this.Value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x04001E50 RID: 7760
		private double value;
	}
}
