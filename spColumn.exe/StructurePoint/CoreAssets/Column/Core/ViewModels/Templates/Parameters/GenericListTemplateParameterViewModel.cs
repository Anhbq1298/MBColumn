using System;
using System.Linq;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace StructurePoint.CoreAssets.Column.Core.ViewModels.Templates.Parameters
{
	// Token: 0x02000838 RID: 2104
	internal sealed class GenericListTemplateParameterViewModel : TemplateParameterViewModelBase
	{
		// Token: 0x0600434A RID: 17226 RVA: 0x00137FA4 File Offset: 0x001361A4
		public GenericListTemplateParameterViewModel(ParameterRuntime parameter, TemplateEngine engine) : base(engine, parameter)
		{
			this.Values.#pR(from item in parameter.SelectOptions
			select new ComboItem<string>(item.Value as string, item.DisplayValue));
			this.LoadValue(parameter.EffectiveValue);
		}

		// Token: 0x170013DD RID: 5085
		// (get) Token: 0x0600434B RID: 17227 RVA: 0x0003866B File Offset: 0x0003686B
		public CustomObservableCollection<ComboItem<string>> Values { get; } = new CustomObservableCollection<ComboItem<string>>();

		// Token: 0x170013DE RID: 5086
		// (get) Token: 0x0600434C RID: 17228 RVA: 0x00038673 File Offset: 0x00036873
		// (set) Token: 0x0600434D RID: 17229 RVA: 0x00138008 File Offset: 0x00136208
		public string Value
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
					this.OnParameterValueChanged(new TemplateParameterValueChangedEventArgs(base.Parameter, value, value));
					base.RaisePropertyChanged(#Phc.#3hc(107399374));
				}
			}
		}

		// Token: 0x0600434E RID: 17230 RVA: 0x0003867B File Offset: 0x0003687B
		public override void LoadValue(object newValue)
		{
			this.value = (string)newValue;
			base.RaisePropertyChanged(#Phc.#3hc(107399374));
			base.ClearErrors();
			base.LoadValue(newValue);
		}

		// Token: 0x0600434F RID: 17231 RVA: 0x000386A6 File Offset: 0x000368A6
		public override object GetEffectiveValue()
		{
			return this.Value;
		}

		// Token: 0x06004350 RID: 17232 RVA: 0x000386A6 File Offset: 0x000368A6
		public override string GetSerializedValue()
		{
			return this.Value;
		}

		// Token: 0x04001E51 RID: 7761
		private string value;
	}
}
