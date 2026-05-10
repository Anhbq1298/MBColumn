using System;
using System.Globalization;
using System.Linq;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace StructurePoint.CoreAssets.Column.Core.ViewModels.Templates.Parameters
{
	// Token: 0x02000835 RID: 2101
	internal sealed class DoubleListTemplateParameterViewModel : TemplateParameterViewModelBase
	{
		// Token: 0x0600433A RID: 17210 RVA: 0x00137E10 File Offset: 0x00136010
		public DoubleListTemplateParameterViewModel(ParameterRuntime parameter, TemplateEngine engine) : base(engine, parameter)
		{
			this.Values.#pR(from item in parameter.SelectOptions
			select new ComboItem<double>((double)item.Value, item.DisplayValue));
			this.LoadValue(parameter.EffectiveValue);
		}

		// Token: 0x170013DA RID: 5082
		// (get) Token: 0x0600433B RID: 17211 RVA: 0x000385BF File Offset: 0x000367BF
		public CustomObservableCollection<ComboItem<double>> Values { get; } = new CustomObservableCollection<ComboItem<double>>();

		// Token: 0x170013DB RID: 5083
		// (get) Token: 0x0600433C RID: 17212 RVA: 0x000385C7 File Offset: 0x000367C7
		// (set) Token: 0x0600433D RID: 17213 RVA: 0x00137E74 File Offset: 0x00136074
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

		// Token: 0x0600433E RID: 17214 RVA: 0x000385CF File Offset: 0x000367CF
		public override void LoadValue(object newValue)
		{
			this.value = (double)newValue;
			base.RaisePropertyChanged(#Phc.#3hc(107399374));
			base.ClearErrors();
			base.LoadValue(newValue);
		}

		// Token: 0x0600433F RID: 17215 RVA: 0x000385FA File Offset: 0x000367FA
		public override object GetEffectiveValue()
		{
			return this.Value;
		}

		// Token: 0x06004340 RID: 17216 RVA: 0x00137EEC File Offset: 0x001360EC
		public override string GetSerializedValue()
		{
			return this.Value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x04001E4C RID: 7756
		private double value;
	}
}
