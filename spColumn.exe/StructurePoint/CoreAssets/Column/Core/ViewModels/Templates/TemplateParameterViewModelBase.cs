using System;
using System.Runtime.CompilerServices;
using #7hc;
using #cYd;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.Formatters;
using StructurePoint.CoreAssets.Units.UnitSets;

namespace StructurePoint.CoreAssets.Column.Core.ViewModels.Templates
{
	// Token: 0x0200082A RID: 2090
	public abstract class TemplateParameterViewModelBase : NotifyPropertyChangedObjectWithValidation
	{
		// Token: 0x060042E6 RID: 17126 RVA: 0x00136FD4 File Offset: 0x001351D4
		protected TemplateParameterViewModelBase(TemplateEngine engine, ParameterRuntime parameter)
		{
			this.Parameter = parameter;
			this.Engine = engine;
			this.UnitValueFormatter = ((engine.Model.UnitSystem == UnitSystem.SIMetric) ? new FloatingPointUnitValueFormatter(0) : new FloatingPointUnitValueFormatter(2));
			this.name = parameter.Name;
		}

		// Token: 0x140000DC RID: 220
		// (add) Token: 0x060042E7 RID: 17127 RVA: 0x00137024 File Offset: 0x00135224
		// (remove) Token: 0x060042E8 RID: 17128 RVA: 0x0013705C File Offset: 0x0013525C
		public event EventHandler<TemplateParameterValueChangedEventArgs> ParameterValueChanged;

		// Token: 0x170013C5 RID: 5061
		// (get) Token: 0x060042E9 RID: 17129 RVA: 0x000382AB File Offset: 0x000364AB
		// (set) Token: 0x060042EA RID: 17130 RVA: 0x000382B3 File Offset: 0x000364B3
		public IUnitValueFormatter UnitValueFormatter
		{
			get
			{
				return this.unitValueFormatter;
			}
			set
			{
				if (this.unitValueFormatter != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107456546));
					this.unitValueFormatter = value;
					base.RaisePropertyChanged(#Phc.#3hc(107456546));
				}
			}
		}

		// Token: 0x170013C6 RID: 5062
		// (get) Token: 0x060042EB RID: 17131 RVA: 0x000382E5 File Offset: 0x000364E5
		// (set) Token: 0x060042EC RID: 17132 RVA: 0x000382ED File Offset: 0x000364ED
		public bool IsFirst { get; set; }

		// Token: 0x170013C7 RID: 5063
		// (get) Token: 0x060042ED RID: 17133 RVA: 0x000382F6 File Offset: 0x000364F6
		public ParameterRuntime Parameter { get; }

		// Token: 0x170013C8 RID: 5064
		// (get) Token: 0x060042EE RID: 17134 RVA: 0x000382FE File Offset: 0x000364FE
		public TemplateParameterType ParameterType
		{
			get
			{
				return this.Parameter.Definition.Type;
			}
		}

		// Token: 0x170013C9 RID: 5065
		// (get) Token: 0x060042EF RID: 17135 RVA: 0x00038310 File Offset: 0x00036510
		// (set) Token: 0x060042F0 RID: 17136 RVA: 0x00038318 File Offset: 0x00036518
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (this.name != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107409209));
					this.name = value;
					base.RaisePropertyChanged(#Phc.#3hc(107409209));
				}
			}
		}

		// Token: 0x170013CA RID: 5066
		// (get) Token: 0x060042F1 RID: 17137 RVA: 0x0003834F File Offset: 0x0003654F
		public TemplateEngine Engine { get; }

		// Token: 0x170013CB RID: 5067
		// (get) Token: 0x060042F2 RID: 17138 RVA: 0x00038357 File Offset: 0x00036557
		// (set) Token: 0x060042F3 RID: 17139 RVA: 0x0003835F File Offset: 0x0003655F
		public bool IsReadOnly
		{
			get
			{
				return this.isReadOnly;
			}
			set
			{
				if (this.isReadOnly != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107456521));
					this.isReadOnly = value;
					base.RaisePropertyChanged(#Phc.#3hc(107456521));
				}
			}
		}

		// Token: 0x170013CC RID: 5068
		// (get) Token: 0x060042F4 RID: 17140 RVA: 0x00038391 File Offset: 0x00036591
		// (set) Token: 0x060042F5 RID: 17141 RVA: 0x00038399 File Offset: 0x00036599
		public IUnit Unit
		{
			get
			{
				return this.unit;
			}
			set
			{
				if (this.unit != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398174));
					this.unit = value;
					base.RaisePropertyChanged(#Phc.#3hc(107398174));
				}
			}
		}

		// Token: 0x060042F6 RID: 17142 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void LoadValue(object newValue)
		{
		}

		// Token: 0x060042F7 RID: 17143
		public abstract object GetEffectiveValue();

		// Token: 0x060042F8 RID: 17144
		public abstract string GetSerializedValue();

		// Token: 0x060042F9 RID: 17145 RVA: 0x000383CB File Offset: 0x000365CB
		protected virtual void OnParameterValueChanged(TemplateParameterValueChangedEventArgs e)
		{
			EventHandler<TemplateParameterValueChangedEventArgs> parameterValueChanged = this.ParameterValueChanged;
			if (parameterValueChanged == null)
			{
				return;
			}
			parameterValueChanged(this, e);
		}

		// Token: 0x060042FA RID: 17146 RVA: 0x00137094 File Offset: 0x00135294
		protected virtual bool ValidateParameter(object value, [CallerMemberName] string propertyName = null)
		{
			bool result;
			try
			{
				base.RemoveError(propertyName);
				this.Engine.#rge(this.Parameter.Definition.Key, value);
				string error;
				if (this.Engine.#IH(this.Parameter.Definition.Key, value, out error))
				{
					base.RemoveError(propertyName);
					result = true;
				}
				else
				{
					this.AddError(propertyName, error);
					result = false;
				}
			}
			catch (Exception #ob)
			{
				this.AddError(propertyName, #sYd.#oYd(#ob));
				result = false;
			}
			return result;
		}

		// Token: 0x04001E24 RID: 7716
		private IUnitValueFormatter unitValueFormatter;

		// Token: 0x04001E25 RID: 7717
		private string name;

		// Token: 0x04001E26 RID: 7718
		private bool isReadOnly;

		// Token: 0x04001E27 RID: 7719
		private IUnit unit;
	}
}
