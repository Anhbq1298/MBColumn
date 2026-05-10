using System;
using System.Globalization;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;

namespace StructurePoint.CoreAssets.Column.Core.ViewModels.Templates.Parameters
{
	// Token: 0x0200083C RID: 2108
	internal sealed class IntegerTemplateParameterViewModel : TemplateParameterViewModelBase
	{
		// Token: 0x0600435E RID: 17246 RVA: 0x0003857F File Offset: 0x0003677F
		public IntegerTemplateParameterViewModel(ParameterRuntime parameter, TemplateEngine engine) : base(engine, parameter)
		{
			this.LoadValue(parameter.EffectiveValue);
		}

		// Token: 0x170013E1 RID: 5089
		// (get) Token: 0x0600435F RID: 17247 RVA: 0x0003873E File Offset: 0x0003693E
		// (set) Token: 0x06004360 RID: 17248 RVA: 0x0013816C File Offset: 0x0013636C
		public int Value
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

		// Token: 0x06004361 RID: 17249 RVA: 0x00038746 File Offset: 0x00036946
		public override void LoadValue(object newValue)
		{
			this.value = (int)newValue;
			base.RaisePropertyChanged(#Phc.#3hc(107399374));
			base.ClearErrors();
			base.LoadValue(newValue);
		}

		// Token: 0x06004362 RID: 17250 RVA: 0x00038771 File Offset: 0x00036971
		public override object GetEffectiveValue()
		{
			return this.Value;
		}

		// Token: 0x06004363 RID: 17251 RVA: 0x001381E4 File Offset: 0x001363E4
		public override string GetSerializedValue()
		{
			return this.Value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x04001E59 RID: 7769
		private int value;
	}
}
