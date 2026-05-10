using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using #7hc;
using #9pe;
using #gfe;
using #Nhe;
using #vhe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;
using StructurePoint.CoreAssets.Column.Core.Templates.Rendering;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.Column.Core.ViewModels.Templates
{
	// Token: 0x0200082C RID: 2092
	public sealed class TemplateRuntimeViewModel : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060042FC RID: 17148 RVA: 0x001371D4 File Offset: 0x001353D4
		public TemplateRuntimeViewModel(TemplateEngine engine)
		{
			TemplateEngine templateEngine = engine;
			if (templateEngine == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107456536));
			}
			this.engine = templateEngine;
			this.Model = engine.Model;
			this.ReinforcementParameterGroups.#pR(from item in this.Model.ReinforcementParameterGroups
			select new TemplateParameterGroupViewModel(engine, item));
			if (this.ReinforcementParameterGroups.Any<TemplateParameterGroupViewModel>())
			{
				this.ReinforcementParameterGroups[0].IsFirst = true;
			}
			this.SectionParameterGroups.#pR(from item in this.Model.SectionParameterGroups
			select new TemplateParameterGroupViewModel(engine, item));
			if (this.SectionParameterGroups.Any<TemplateParameterGroupViewModel>())
			{
				this.SectionParameterGroups[0].IsFirst = true;
			}
			this.OptionsParameterGroups.#pR(from item in this.Model.OptionsParameterGroups
			select new TemplateParameterGroupViewModel(engine, item));
			if (this.OptionsParameterGroups.Any<TemplateParameterGroupViewModel>())
			{
				this.OptionsParameterGroups[0].IsFirst = true;
			}
			this.SectionImage = #Afe.#zfe(this.Model.Definition, TemplateFileType.Section);
			this.ReinforcementImage = #Afe.#zfe(this.Model.Definition, TemplateFileType.Reinforcement);
			this.SelectorImage = #Afe.#zfe(this.Model.Definition, TemplateFileType.Selector);
			this.Setup();
		}

		// Token: 0x140000DD RID: 221
		// (add) Token: 0x060042FD RID: 17149 RVA: 0x00137380 File Offset: 0x00135580
		// (remove) Token: 0x060042FE RID: 17150 RVA: 0x001373B8 File Offset: 0x001355B8
		public event EventHandler<TemplateParameterValueChangedEventArgs> ParameterValueChanged;

		// Token: 0x170013CD RID: 5069
		// (get) Token: 0x060042FF RID: 17151 RVA: 0x000383DF File Offset: 0x000365DF
		public string DisplayName
		{
			get
			{
				return Strings.StringSection_UPPER.#F2d() + this.Model.Name;
			}
		}

		// Token: 0x170013CE RID: 5070
		// (get) Token: 0x06004300 RID: 17152 RVA: 0x000383FB File Offset: 0x000365FB
		public ImageSource SectionImage { get; }

		// Token: 0x170013CF RID: 5071
		// (get) Token: 0x06004301 RID: 17153 RVA: 0x00038403 File Offset: 0x00036603
		public ImageSource ReinforcementImage { get; }

		// Token: 0x170013D0 RID: 5072
		// (get) Token: 0x06004302 RID: 17154 RVA: 0x0003840B File Offset: 0x0003660B
		public ImageSource SelectorImage { get; }

		// Token: 0x170013D1 RID: 5073
		// (get) Token: 0x06004303 RID: 17155 RVA: 0x00038413 File Offset: 0x00036613
		public List<TemplateParameterViewModelBase> AllParameters { get; } = new List<TemplateParameterViewModelBase>();

		// Token: 0x170013D2 RID: 5074
		// (get) Token: 0x06004304 RID: 17156 RVA: 0x0003841B File Offset: 0x0003661B
		public TemplateEngineModel Model { get; }

		// Token: 0x170013D3 RID: 5075
		// (get) Token: 0x06004305 RID: 17157 RVA: 0x00038423 File Offset: 0x00036623
		public CustomObservableCollection<TemplateParameterGroupViewModel> ReinforcementParameterGroups { get; } = new CustomObservableCollection<TemplateParameterGroupViewModel>();

		// Token: 0x170013D4 RID: 5076
		// (get) Token: 0x06004306 RID: 17158 RVA: 0x0003842B File Offset: 0x0003662B
		public CustomObservableCollection<TemplateParameterGroupViewModel> SectionParameterGroups { get; } = new CustomObservableCollection<TemplateParameterGroupViewModel>();

		// Token: 0x170013D5 RID: 5077
		// (get) Token: 0x06004307 RID: 17159 RVA: 0x00038433 File Offset: 0x00036633
		public CustomObservableCollection<TemplateParameterGroupViewModel> OptionsParameterGroups { get; } = new CustomObservableCollection<TemplateParameterGroupViewModel>();

		// Token: 0x170013D6 RID: 5078
		// (get) Token: 0x06004308 RID: 17160 RVA: 0x0003843B File Offset: 0x0003663B
		public Visibility OptionsTabVisibility
		{
			get
			{
				if (!this.OptionsParameterGroups.Any<TemplateParameterGroupViewModel>())
				{
					return Visibility.Collapsed;
				}
				return Visibility.Visible;
			}
		}

		// Token: 0x06004309 RID: 17161 RVA: 0x001373F0 File Offset: 0x001355F0
		protected void OnParameterValueChanged(TemplateParameterValueChangedEventArgs e)
		{
			if (!this.raiseOnParameterValueChanged)
			{
				return;
			}
			try
			{
				this.raiseOnParameterValueChanged = false;
				this.UpdateIsReadOnly();
				this.OverrideValues();
				EventHandler<TemplateParameterValueChangedEventArgs> parameterValueChanged = this.ParameterValueChanged;
				if (parameterValueChanged != null)
				{
					parameterValueChanged(this, e);
				}
			}
			finally
			{
				this.raiseOnParameterValueChanged = true;
			}
		}

		// Token: 0x0600430A RID: 17162 RVA: 0x00137448 File Offset: 0x00135648
		public void ClearColoredZones()
		{
			foreach (TemplateParameterGroupViewModel templateParameterGroupViewModel in this.ReinforcementParameterGroups.Union(this.SectionParameterGroups).Union(this.OptionsParameterGroups).ToList<TemplateParameterGroupViewModel>())
			{
				templateParameterGroupViewModel.ShowColoredZoneIndicator = false;
			}
		}

		// Token: 0x0600430B RID: 17163 RVA: 0x001374B4 File Offset: 0x001356B4
		public IList<ZoneInfo> RefreshColoredZones(IList<SectionPolygon> zones)
		{
			this.ClearColoredZones();
			List<TemplateParameterGroupViewModel> source = this.ReinforcementParameterGroups.Union(this.SectionParameterGroups).Union(this.OptionsParameterGroups).ToList<TemplateParameterGroupViewModel>();
			List<int> list = (from z in (from item in zones
			select item.Id).Distinct<int>()
			orderby z
			select z).ToList<int>();
			int num = 0;
			using (List<int>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int zoneId = enumerator.Current;
					System.Windows.Media.Color? groupMediaColor = ColoredZoneColors.GetGroupMediaColor(num);
					if (groupMediaColor != null)
					{
						TemplateParameterGroupViewModel templateParameterGroupViewModel = source.FirstOrDefault((TemplateParameterGroupViewModel gr) => gr.ZoneId == zoneId);
						if (templateParameterGroupViewModel != null)
						{
							templateParameterGroupViewModel.ShowColoredZoneIndicator = true;
							templateParameterGroupViewModel.ZoneColor = groupMediaColor.Value;
							templateParameterGroupViewModel.ColorIndex = num;
							num++;
						}
					}
				}
			}
			this.RefreshGroups(this.ReinforcementParameterGroups);
			return (from gr in source
			where gr.ShowColoredZoneIndicator
			select new ZoneInfo
			{
				GroupColor = System.Drawing.Color.FromArgb((int)gr.ZoneColor.A, (int)gr.ZoneColor.R, (int)gr.ZoneColor.G, (int)gr.ZoneColor.B),
				Id = gr.ZoneId,
				ColorIndex = gr.ColorIndex,
				ShapeColor = (ColoredZoneColors.GetShapeDrawingColor(gr.ColorIndex) ?? System.Drawing.Color.Transparent)
			}).ToList<ZoneInfo>();
		}

		// Token: 0x0600430C RID: 17164 RVA: 0x00137628 File Offset: 0x00135828
		public void UpdateParameterNames(IList<TemplateParameterName> parameterNames)
		{
			foreach (TemplateParameterName templateParameterName in parameterNames)
			{
				TemplateParameterViewModelBase templateParameterViewModelBase = this.FindParameter(templateParameterName.Key);
				if (templateParameterViewModelBase != null)
				{
					templateParameterViewModelBase.Name = templateParameterName.EvaluatedName;
				}
			}
		}

		// Token: 0x0600430D RID: 17165 RVA: 0x00137688 File Offset: 0x00135888
		public void LoadParameterValues(IList<#cqe> parameterValues)
		{
			foreach (#cqe #cqe in parameterValues)
			{
				TemplateParameterViewModelBase templateParameterViewModelBase = this.FindParameter(#cqe.Key);
				#0he #0he;
				if (templateParameterViewModelBase == null)
				{
					this.engine.#rge(#cqe.Key, #cqe.Value);
				}
				else if (#Hhe.#Fhe(templateParameterViewModelBase.ParameterType, #cqe.Value, out #0he))
				{
					templateParameterViewModelBase.LoadValue(#0he.#Yhe(templateParameterViewModelBase.ParameterType));
					this.engine.#rge(#cqe.Key, #0he.#Yhe(templateParameterViewModelBase.ParameterType));
				}
				else
				{
					this.engine.#rge(#cqe.Key, #cqe.Value);
				}
			}
		}

		// Token: 0x0600430E RID: 17166 RVA: 0x0003844D File Offset: 0x0003664D
		private void Parameter_ParameterValueChanged(object sender, TemplateParameterValueChangedEventArgs e)
		{
			this.OnParameterValueChanged(e);
		}

		// Token: 0x0600430F RID: 17167 RVA: 0x00137758 File Offset: 0x00135958
		private void RefreshGroups(IList<TemplateParameterGroupViewModel> groups)
		{
			using (IEnumerator<TemplateParameterGroupViewModel> enumerator = groups.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					TemplateParameterGroupViewModel templateParameterGroup = enumerator.Current;
					if (templateParameterGroup.Parameters.All((TemplateParameterViewModelBase item) => item.IsReadOnly))
					{
						templateParameterGroup.Visibility = Visibility.Collapsed;
						Func<TemplateParameterViewModelBase, bool> <>9__2;
						TemplateParameterGroupViewModel templateParameterGroupViewModel = groups.FirstOrDefault(delegate(TemplateParameterGroupViewModel item)
						{
							IEnumerable<TemplateParameterViewModelBase> parameters = item.Parameters;
							Func<TemplateParameterViewModelBase, bool> predicate;
							if ((predicate = <>9__2) == null)
							{
								predicate = (<>9__2 = ((TemplateParameterViewModelBase p) => templateParameterGroup.Parameters.Any((TemplateParameterViewModelBase p2) => p2.Parameter.Definition.OverridingParameterKey == p.Parameter.Definition.Key)));
							}
							return parameters.Any(predicate);
						});
						if (templateParameterGroupViewModel != null)
						{
							templateParameterGroup.ColorIndex = templateParameterGroupViewModel.ColorIndex;
							templateParameterGroup.ZoneColor = templateParameterGroupViewModel.ZoneColor;
						}
					}
					else
					{
						templateParameterGroup.Visibility = Visibility.Visible;
					}
				}
			}
		}

		// Token: 0x06004310 RID: 17168 RVA: 0x00137830 File Offset: 0x00135A30
		private void OverrideValues()
		{
			foreach (TemplateParameterViewModelBase templateParameterViewModelBase in this.AllParameters)
			{
				if (templateParameterViewModelBase.IsReadOnly)
				{
					ParameterRuntime parameter = templateParameterViewModelBase.Parameter;
					if (!string.IsNullOrWhiteSpace(parameter.Definition.OverridingParameterKey))
					{
						TemplateParameterViewModelBase templateParameterViewModelBase2 = this.FindParameter(parameter.Definition.OverridingParameterKey);
						if (templateParameterViewModelBase2 != null)
						{
							object effectiveValue = templateParameterViewModelBase2.GetEffectiveValue();
							templateParameterViewModelBase.LoadValue(effectiveValue);
						}
					}
				}
			}
		}

		// Token: 0x06004311 RID: 17169 RVA: 0x001378C4 File Offset: 0x00135AC4
		private void UpdateIsReadOnly()
		{
			foreach (TemplateParameterViewModelBase templateParameterViewModelBase in this.AllParameters)
			{
				ParameterRuntime parameter = templateParameterViewModelBase.Parameter;
				templateParameterViewModelBase.IsReadOnly = (!string.IsNullOrWhiteSpace(parameter.Definition.IsReadOnlyExpression) && this.engine.#KA(parameter.Definition.IsReadOnlyExpression));
			}
		}

		// Token: 0x06004312 RID: 17170 RVA: 0x00038456 File Offset: 0x00036656
		private TemplateParameterViewModelBase FindParameter(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				return null;
			}
			key = key.Trim();
			return this.allParametersCache.#F1d(key);
		}

		// Token: 0x06004313 RID: 17171 RVA: 0x00137948 File Offset: 0x00135B48
		private void Setup()
		{
			this.AllParameters.AddRange(this.SectionParameterGroups.SelectMany((TemplateParameterGroupViewModel item) => item.Parameters));
			this.AllParameters.AddRange(this.ReinforcementParameterGroups.SelectMany((TemplateParameterGroupViewModel item) => item.Parameters));
			this.AllParameters.AddRange(this.OptionsParameterGroups.SelectMany((TemplateParameterGroupViewModel item) => item.Parameters));
			this.allParametersCache.#pR(this.AllParameters, delegate(TemplateParameterViewModelBase item)
			{
				string key = item.Parameter.Definition.Key;
				if (key == null)
				{
					return null;
				}
				return key.Trim();
			});
			foreach (TemplateParameterViewModelBase templateParameterViewModelBase in this.AllParameters)
			{
				templateParameterViewModelBase.ParameterValueChanged += this.Parameter_ParameterValueChanged;
			}
			int num = 1;
			foreach (TemplateParameterGroupViewModel templateParameterGroupViewModel in this.ReinforcementParameterGroups)
			{
				templateParameterGroupViewModel.ZoneId = num++;
			}
			foreach (TemplateParameterGroupViewModel templateParameterGroupViewModel2 in this.SectionParameterGroups)
			{
				templateParameterGroupViewModel2.ZoneId = num++;
			}
			foreach (TemplateParameterGroupViewModel templateParameterGroupViewModel3 in this.OptionsParameterGroups)
			{
				templateParameterGroupViewModel3.ZoneId = num++;
			}
		}

		// Token: 0x04001E2C RID: 7724
		private readonly TemplateEngine engine;

		// Token: 0x04001E2D RID: 7725
		private bool raiseOnParameterValueChanged = true;

		// Token: 0x04001E2E RID: 7726
		private readonly Dictionary<string, TemplateParameterViewModelBase> allParametersCache = new Dictionary<string, TemplateParameterViewModelBase>();
	}
}
