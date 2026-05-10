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
	// Token: 0x0200083A RID: 2106
	internal sealed class IntegerListTemplateParameterViewModel : TemplateParameterViewModelBase
	{
		// Token: 0x06004354 RID: 17236 RVA: 0x00138070 File Offset: 0x00136270
		public IntegerListTemplateParameterViewModel(ParameterRuntime parameter, TemplateEngine engine) : base(engine, parameter)
		{
			this.LoadValue(parameter.EffectiveValue);
			this.Values.#pR(from item in parameter.SelectOptions
			select new ComboItem<int>((int)item.Value, item.DisplayValue));
		}

		// Token: 0x170013DF RID: 5087
		// (get) Token: 0x06004355 RID: 17237 RVA: 0x000386D2 File Offset: 0x000368D2
		public CustomObservableCollection<ComboItem<int>> Values { get; } = new CustomObservableCollection<ComboItem<int>>();

		// Token: 0x170013E0 RID: 5088
		// (get) Token: 0x06004356 RID: 17238 RVA: 0x000386DA File Offset: 0x000368DA
		// (set) Token: 0x06004357 RID: 17239 RVA: 0x001380D4 File Offset: 0x001362D4
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

		// Token: 0x06004358 RID: 17240 RVA: 0x000386E2 File Offset: 0x000368E2
		public override void LoadValue(object newValue)
		{
			this.value = (int)newValue;
			base.RaisePropertyChanged(#Phc.#3hc(107399374));
			base.ClearErrors();
			base.LoadValue(newValue);
		}

		// Token: 0x06004359 RID: 17241 RVA: 0x0003870D File Offset: 0x0003690D
		public override object GetEffectiveValue()
		{
			return this.Value;
		}

		// Token: 0x0600435A RID: 17242 RVA: 0x0013814C File Offset: 0x0013634C
		public override string GetSerializedValue()
		{
			return this.Value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x04001E55 RID: 7765
		private int value;
	}
}
