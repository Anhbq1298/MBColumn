using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #0be;
using #2be;
using #3wb;
using #6he;
using #7hc;
using #9pe;
using #eU;
using #Nhe;
using #vhe;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Column.Core.Templates.Rendering;
using StructurePoint.CoreAssets.Column.Core.ViewModels.Templates;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Section.Templates.ViewModels
{
	// Token: 0x020004B3 RID: 1203
	internal sealed class SectionTemplateService : NotifyPropertyChangedObjectBase, #2wb
	{
		// Token: 0x06002C2C RID: 11308 RVA: 0x00027BD3 File Offset: 0x00025DD3
		public SectionTemplateService(#oW projectContext, IExtendedServices extendedServices, IEditorService editorService)
		{
			this.#a = projectContext;
			this.#b = extendedServices;
			this.#c = editorService;
			extendedServices.MessageBus.DefinitionChangesCommitted += this.#owb;
		}

		// Token: 0x17000ED8 RID: 3800
		// (get) Token: 0x06002C2D RID: 11309 RVA: 0x00027C07 File Offset: 0x00025E07
		// (set) Token: 0x06002C2E RID: 11310 RVA: 0x000EB4D8 File Offset: 0x000E96D8
		public TemplateRuntimeViewModel RuntimeViewModel
		{
			get
			{
				return this.#e;
			}
			private set
			{
				if (this.#e != value)
				{
					if (this.#e != null)
					{
						this.#e.ParameterValueChanged -= this.#9wb;
					}
					base.RaisePropertyChanging(#Phc.#3hc(107356399));
					this.#e = value;
					if (value != null)
					{
						value.ParameterValueChanged += this.#9wb;
					}
					base.RaisePropertyChanged(#Phc.#3hc(107356399));
				}
			}
		}

		// Token: 0x06002C2F RID: 11311 RVA: 0x000EB558 File Offset: 0x000E9758
		public void #DY(UnitSystem #3r, UnitSystem #4r)
		{
			foreach (TemplateParameterValueEntity #Zwb in this.#a.Model.TemplateData.ParameterValues)
			{
				this.#Ywb(#3r, #4r, this.#a.Model.TemplateData.TemplateDefinition, #Zwb);
			}
			this.#0wb(true);
		}

		// Token: 0x06002C30 RID: 11312 RVA: 0x000EB5E4 File Offset: 0x000E97E4
		public void #Ywb(UnitSystem #3r, UnitSystem #4r, SectionTemplateDefinition #xS, #cqe #Zwb)
		{
			SectionTemplateService.#oWb #oWb = new SectionTemplateService.#oWb();
			#oWb.#a = #Zwb;
			TemplateParameterDefinition templateParameterDefinition = #xS.ReinforcementParameters.Union(#xS.SectionParameters).SelectMany(new Func<TemplateParameterGroupDefinition, IEnumerable<TemplateParameterDefinition>>(SectionTemplateService.<>c.<>9.#X7b)).FirstOrDefault(new Func<TemplateParameterDefinition, bool>(#oWb.#W7b));
			if (templateParameterDefinition != null && templateParameterDefinition.Type == TemplateParameterType.Double)
			{
				LengthUnit #K7d = (#3r == UnitSystem.USCustomary) ? LengthUnit.Inch : LengthUnit.Millimeter;
				LengthUnit #B = (#4r == UnitSystem.USCustomary) ? LengthUnit.Inch : LengthUnit.Millimeter;
				double num = LengthConverter.#18d(#K7d, #B);
				#0he #0he;
				if (#Hhe.#Fhe(TemplateParameterType.Double, #oWb.#a.Value, out #0he))
				{
					double num2 = #0he.DoubleValue;
					num2 *= num;
					#oWb.#a.Value = num2.ToString(CultureInfo.InvariantCulture);
				}
			}
		}

		// Token: 0x06002C31 RID: 11313 RVA: 0x000EB6C8 File Offset: 0x000E98C8
		public void #0wb(bool #8Vh = true)
		{
			try
			{
				SectionTemplateDefinition sectionTemplateDefinition = this.#a.Model.TemplateData.TemplateDefinition;
				if (this.#a.Model.Options.SectionType != SectionType.IrregularTemplate || sectionTemplateDefinition == null)
				{
					this.#d = null;
					this.RuntimeViewModel = null;
				}
				else
				{
					List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar> #Ege = this.#a.Model.Bars.Select(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar>(SectionTemplateService.<>c.<>9.#Y7b)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar>();
					TemplateEngineModel model = TemplateEngineModel.#Dge(sectionTemplateDefinition, this.#a.Model.Options.Unit, this.#a.Model.Options.Code, #Ege, #Phc.#3hc(107401382));
					this.#d = new TemplateEngine(model);
					this.RuntimeViewModel = new TemplateRuntimeViewModel(this.#d);
					this.#dxb();
					this.#1wb(false, #8Vh);
				}
			}
			catch (Exception #ob)
			{
				this.#b.ExceptionHandler.#3Ab(Strings.StringCouldNotLoadTheTemplate.#z2d(), #ob);
			}
		}

		// Token: 0x06002C32 RID: 11314 RVA: 0x000EB814 File Offset: 0x000E9A14
		public void #1wb(bool #ag, bool #8Vh = true)
		{
			try
			{
				this.#a.TemplateZoneInfos.Clear();
				if (this.#d != null)
				{
					this.#axb();
					TemplateExecutionResult templateExecutionResult = this.#d.#0(new #xie(this.#a.Model.TemplateData.Options.#CY()));
					if (!this.#bxb(templateExecutionResult))
					{
						this.#a.TemplateExecutionResult = null;
						if (#8Vh)
						{
							this.#b.Renderer.#9f(#ag, false);
						}
					}
					else
					{
						this.#a.TemplateExecutionResult = templateExecutionResult;
						this.RuntimeViewModel.UpdateParameterNames(templateExecutionResult.ParameterNames);
						this.RuntimeViewModel.ClearColoredZones();
						if (this.#a.Model.TemplateData.Options.ShowColoredZones)
						{
							IList<ZoneInfo> collection = this.RuntimeViewModel.RefreshColoredZones(templateExecutionResult.ColoredZones);
							this.#a.TemplateZoneInfos.AddRange(collection);
						}
						this.#a.Model.Shapes.Clear();
						this.#a.Model.ReinforcementBars.Clear();
						this.#a.Model.Shapes.AddRange(templateExecutionResult.Polygons.Select(new Func<SectionPolygon, ShapeModel>(SectionTemplateService.<>c.<>9.#Z7b)));
						this.#a.Model.ReinforcementBars.AddRange(templateExecutionResult.Bars.Select(new Func<TemplateReinforcementBar, StructurePoint.Products.Column.Model.Entities.ReinforcementBar>(SectionTemplateService.<>c.<>9.#07b)));
						if (#8Vh)
						{
							this.#b.Renderer.#9f(#ag, false);
						}
					}
				}
			}
			catch (Exception #ob)
			{
				this.#b.ExceptionHandler.#3Ab(Strings.StringCouldNotRunTheTemplate.#z2d(), #ob);
			}
		}

		// Token: 0x06002C33 RID: 11315 RVA: 0x00027C13 File Offset: 0x00025E13
		private void #owb(object #Ge, EventArgs #He)
		{
			if (this.#a.Model.Options.SectionType == SectionType.IrregularTemplate)
			{
				this.#dxb();
			}
		}

		// Token: 0x06002C34 RID: 11316 RVA: 0x00027C3F File Offset: 0x00025E3F
		private void #9wb(object #Ge, TemplateParameterValueChangedEventArgs #He)
		{
			this.#c.#0Pb(new Action(this.#exb));
		}

		// Token: 0x06002C35 RID: 11317 RVA: 0x000EBA1C File Offset: 0x000E9C1C
		private void #axb()
		{
			foreach (TemplateParameterViewModelBase templateParameterViewModelBase in this.RuntimeViewModel.AllParameters)
			{
				this.#d.#rge(templateParameterViewModelBase.Parameter.Definition.Key, templateParameterViewModelBase.GetEffectiveValue());
			}
		}

		// Token: 0x06002C36 RID: 11318 RVA: 0x000EBA9C File Offset: 0x000E9C9C
		private bool #bxb(TemplateExecutionResult #PE)
		{
			SectionTemplateService.#rWb #rWb = new SectionTemplateService.#rWb();
			List<string> list = new List<string>();
			list.AddRange(#PE.Errors.Select(new Func<TemplateMessage, string>(SectionTemplateService.<>c.<>9.#17b)));
			#rWb.#a = TemplateEngine.#tge();
			list.AddRange(#PE.ResultValidationFailures.Select(new Func<ValidationFailure, string>(#rWb.#37b)));
			if (list.Any<string>())
			{
				string str = string.Join(Environment.NewLine, list);
				this.#b.DialogService.#qn(this.#b.DialogService.ActiveWindow, #Phc.#3hc(107356406).#z2d() + Environment.NewLine + Environment.NewLine + str);
				return false;
			}
			return true;
		}

		// Token: 0x06002C37 RID: 11319 RVA: 0x000EBB84 File Offset: 0x000E9D84
		private void #cxb()
		{
			this.#a.Model.TemplateData.ParameterValues.Clear();
			this.#a.Model.TemplateData.ParameterValues.AddRange(this.RuntimeViewModel.AllParameters.Select(new Func<TemplateParameterViewModelBase, TemplateParameterValueEntity>(SectionTemplateService.<>c.<>9.#27b)));
		}

		// Token: 0x06002C38 RID: 11320 RVA: 0x000EBC00 File Offset: 0x000E9E00
		private void #dxb()
		{
			List<TemplateParameterValueEntity> source = this.#a.Model.TemplateData.ParameterValues;
			if (!source.Any<TemplateParameterValueEntity>())
			{
				this.#d.#qge();
				this.#cxb();
				return;
			}
			this.RuntimeViewModel.LoadParameterValues(source.OfType<#cqe>().ToList<#cqe>());
		}

		// Token: 0x06002C39 RID: 11321 RVA: 0x00027C65 File Offset: 0x00025E65
		[CompilerGenerated]
		private void #exb()
		{
			this.#cxb();
			this.#1wb(true, true);
		}

		// Token: 0x040011AD RID: 4525
		private readonly #oW #a;

		// Token: 0x040011AE RID: 4526
		private readonly IExtendedServices #b;

		// Token: 0x040011AF RID: 4527
		private readonly IEditorService #c;

		// Token: 0x040011B0 RID: 4528
		private TemplateEngine #d;

		// Token: 0x040011B1 RID: 4529
		private TemplateRuntimeViewModel #e;

		// Token: 0x020004B5 RID: 1205
		[CompilerGenerated]
		private sealed class #oWb
		{
			// Token: 0x06002C43 RID: 11331 RVA: 0x00027CC1 File Offset: 0x00025EC1
			internal bool #W7b(TemplateParameterDefinition #Rf)
			{
				return string.Equals(#Rf.Key, this.#a.Key);
			}

			// Token: 0x040011B9 RID: 4537
			public #cqe #a;
		}

		// Token: 0x020004B6 RID: 1206
		[CompilerGenerated]
		private sealed class #rWb
		{
			// Token: 0x06002C45 RID: 11333 RVA: 0x00027CE5 File Offset: 0x00025EE5
			internal string #37b(ValidationFailure #Rf)
			{
				return #Zbe.#qp(#Rf, this.#a);
			}

			// Token: 0x040011BA RID: 4538
			public #ice #a;
		}
	}
}
