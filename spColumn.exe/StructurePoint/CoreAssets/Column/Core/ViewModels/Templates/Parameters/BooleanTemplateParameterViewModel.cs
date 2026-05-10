using System;
using System.Globalization;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;

namespace StructurePoint.CoreAssets.Column.Core.ViewModels.Templates.Parameters
{
	// Token: 0x02000834 RID: 2100
	internal sealed class BooleanTemplateParameterViewModel : TemplateParameterViewModelBase
	{
		// Token: 0x06004334 RID: 17204 RVA: 0x0003857F File Offset: 0x0003677F
		public BooleanTemplateParameterViewModel(ParameterRuntime parameter, TemplateEngine engine) : base(engine, parameter)
		{
			this.LoadValue(parameter.EffectiveValue);
		}

		// Token: 0x170013D9 RID: 5081
		// (get) Token: 0x06004335 RID: 17205 RVA: 0x00038595 File Offset: 0x00036795
		// (set) Token: 0x06004336 RID: 17206 RVA: 0x00137D7C File Offset: 0x00135F7C
		public bool Value
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
					this.OnParameterValueChanged(new TemplateParameterValueChangedEventArgs(base.Parameter, this.GetEffectiveValue(), this.GetSerializedValue()));
					base.RaisePropertyChanged(#Phc.#3hc(107399374));
				}
			}
		}

		// Token: 0x06004337 RID: 17207 RVA: 0x0003859D File Offset: 0x0003679D
		public override void LoadValue(object newValue)
		{
			this.Value = (bool)newValue;
			base.LoadValue(newValue);
		}

		// Token: 0x06004338 RID: 17208 RVA: 0x000385B2 File Offset: 0x000367B2
		public override object GetEffectiveValue()
		{
			return this.Value;
		}

		// Token: 0x06004339 RID: 17209 RVA: 0x00137DF0 File Offset: 0x00135FF0
		public override string GetSerializedValue()
		{
			return this.Value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x04001E4B RID: 7755
		private bool value;
	}
}
