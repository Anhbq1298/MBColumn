using System;
using System.Globalization;
using System.Linq;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace StructurePoint.CoreAssets.Column.Core.ViewModels.Templates.Parameters
{
	// Token: 0x02000832 RID: 2098
	internal sealed class BarSizeTemplateParameterViewModel : TemplateParameterViewModelBase
	{
		// Token: 0x0600432A RID: 17194 RVA: 0x00137C38 File Offset: 0x00135E38
		public BarSizeTemplateParameterViewModel(ParameterRuntime parameter, TemplateEngine engine) : base(engine, parameter)
		{
			this.Values.#pR(from item in engine.Model.StandardBars.Bars
			select new ComboItem<int>(item.Size, string.Format(#Phc.#3hc(107397780), item.Size)));
			object obj = parameter.EffectiveValue;
			int? num = StandardBarsProvider.#vCb((obj != null) ? obj.ToString() : null);
			int? num2 = num;
			int num3;
			if (num2 == null)
			{
				ComboItem<int> comboItem = this.Values.FirstOrDefault<ComboItem<int>>();
				num3 = ((comboItem != null) ? comboItem.Value : 0);
			}
			else
			{
				num3 = num2.GetValueOrDefault();
			}
			this.LoadValue(num3);
		}

		// Token: 0x170013D7 RID: 5079
		// (get) Token: 0x0600432B RID: 17195 RVA: 0x00038504 File Offset: 0x00036704
		public CustomObservableCollection<ComboItem<int>> Values { get; } = new CustomObservableCollection<ComboItem<int>>();

		// Token: 0x170013D8 RID: 5080
		// (get) Token: 0x0600432C RID: 17196 RVA: 0x0003850C File Offset: 0x0003670C
		// (set) Token: 0x0600432D RID: 17197 RVA: 0x00137CE8 File Offset: 0x00135EE8
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
					this.OnParameterValueChanged(new TemplateParameterValueChangedEventArgs(base.Parameter, this.GetEffectiveValue(), this.GetSerializedValue()));
					base.RaisePropertyChanged(#Phc.#3hc(107399374));
				}
			}
		}

		// Token: 0x0600432E RID: 17198 RVA: 0x00038514 File Offset: 0x00036714
		public override void LoadValue(object newValue)
		{
			this.value = (int)newValue;
			base.RaisePropertyChanged(#Phc.#3hc(107399374));
			base.ClearErrors();
			base.LoadValue(newValue);
		}

		// Token: 0x0600432F RID: 17199 RVA: 0x0003853F File Offset: 0x0003673F
		public override object GetEffectiveValue()
		{
			return this.Value;
		}

		// Token: 0x06004330 RID: 17200 RVA: 0x00137D5C File Offset: 0x00135F5C
		public override string GetSerializedValue()
		{
			return this.Value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x04001E47 RID: 7751
		private int value;
	}
}
