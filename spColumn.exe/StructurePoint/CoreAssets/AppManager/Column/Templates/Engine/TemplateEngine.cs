using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using #2be;
using #6he;
using #7hc;
using #cYd;
using #gfe;
using #Gfe;
using #Nhe;
using #vhe;
using devDept.Geometry;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine
{
	// Token: 0x0200107D RID: 4221
	public sealed class TemplateEngine
	{
		// Token: 0x0600903E RID: 36926 RVA: 0x000748F8 File Offset: 0x00072AF8
		public TemplateEngine(TemplateEngineModel model)
		{
			this.Model = model;
			this.#a = new TemplateEvaluator(model.StandardBars, new Func<UnitSystem>(this.#8Zb));
		}

		// Token: 0x170029F9 RID: 10745
		// (get) Token: 0x0600903F RID: 36927 RVA: 0x00074924 File Offset: 0x00072B24
		public TemplateEngineModel Model { get; }

		// Token: 0x06009040 RID: 36928 RVA: 0x001E8254 File Offset: 0x001E6454
		public TemplateExecutionResult #oge()
		{
			TemplateExecutionResult templateExecutionResult = new TemplateExecutionResult();
			#Lge #Lge = this.#a.#oge();
			templateExecutionResult.Errors.AddRange(#Lge.Errors);
			templateExecutionResult.DebugMesages.AddRange(#Lge.DebugMesages);
			return templateExecutionResult;
		}

		// Token: 0x06009041 RID: 36929 RVA: 0x001E8294 File Offset: 0x001E6494
		public TemplateExecutionResult #0(#xie #pge)
		{
			this.#a.#eb();
			#Lge #Lge = this.#a.#0(this.Model.Definition.Geometry.Code);
			TemplateExecutionResult templateExecutionResult = new TemplateExecutionResult();
			templateExecutionResult.Polygons.AddRange(#Lge.Polygons);
			templateExecutionResult.ColoredZones.AddRange(#Lge.ColoredZones);
			templateExecutionResult.Texts.AddRange(#Lge.Texts);
			templateExecutionResult.Bars.AddRange(this.#uge(#Lge.Bars));
			templateExecutionResult.Errors.AddRange(#Lge.Errors);
			templateExecutionResult.DebugMesages.AddRange(#Lge.DebugMesages);
			templateExecutionResult.Dimensions.AddRange(#Lge.Dimensions);
			templateExecutionResult.ParameterNames.AddRange(this.Model.AllParameters.Select(new Func<ParameterRuntime, TemplateParameterName>(TemplateEngine.<>c.<>9.#Aaf)));
			templateExecutionResult.ShapeLabels.AddRange(#Lge.ShapeLabels);
			templateExecutionResult.DimTexts.AddRange(#Lge.DimTexts);
			if (#pge != null)
			{
				new TransformationsHelper(#pge).#Zub(templateExecutionResult);
			}
			this.#bxb(templateExecutionResult);
			return templateExecutionResult;
		}

		// Token: 0x06009042 RID: 36930 RVA: 0x001E83C4 File Offset: 0x001E65C4
		public void #qge()
		{
			foreach (ParameterRuntime parameterRuntime in this.Model.AllParameters)
			{
				this.#rge(parameterRuntime.Definition.Key, parameterRuntime.EffectiveValue);
			}
		}

		// Token: 0x06009043 RID: 36931 RVA: 0x0007492C File Offset: 0x00072B2C
		public void #rge(string #6cc, object #f)
		{
			this.#a.#Mge(#6cc, #f);
		}

		// Token: 0x06009044 RID: 36932 RVA: 0x0007493B File Offset: 0x00072B3B
		public bool #KA(string #i0d)
		{
			return this.#a.#KA(#i0d);
		}

		// Token: 0x06009045 RID: 36933 RVA: 0x001E8428 File Offset: 0x001E6628
		public bool #IH(string #sge, object #f, out string #nzb)
		{
			TemplateEngine.#oWb #oWb = new TemplateEngine.#oWb();
			#oWb.#a = #sge;
			#nzb = null;
			ParameterRuntime parameterRuntime = this.Model.AllParameters.FirstOrDefault(new Func<ParameterRuntime, bool>(#oWb.#vaf));
			if (parameterRuntime == null)
			{
				return false;
			}
			this.#rge(#oWb.#a, #f);
			if (!this.#KBb(parameterRuntime, parameterRuntime.Definition.LowerRangeValidator.Code, out #nzb))
			{
				return false;
			}
			if (!this.#KBb(parameterRuntime, parameterRuntime.Definition.UpperRangeValidator.Code, out #nzb))
			{
				return false;
			}
			foreach (ValidatorDefinition validatorDefinition in parameterRuntime.Definition.Validators)
			{
				if (!this.#a.#KA(validatorDefinition.Code))
				{
					#nzb = validatorDefinition.Message.#ofe(this.Model.LanguageCode);
					return false;
				}
			}
			return true;
		}

		// Token: 0x06009046 RID: 36934 RVA: 0x00074949 File Offset: 0x00072B49
		public static #ice #tge()
		{
			return new ColumnStorageModel
			{
				Options = 
				{
					SectionType = SectionType.IrregularTemplate,
					ProblemType = ProblemType.Investigation,
					InvestigationReinforcement = ReinforcementType.Irregular
				}
			}.CreateContext();
		}

		// Token: 0x06009047 RID: 36935 RVA: 0x001E8524 File Offset: 0x001E6724
		private void #bxb(TemplateExecutionResult #PE)
		{
			#ice context = TemplateEngine.#tge();
			for (int i = 0; i < #PE.Polygons.Count; i++)
			{
				SectionPolygon instance = #PE.Polygons[i];
				try
				{
					ValidationResult validationResult = new SectionPolygonValidator(context, i).Validate(instance);
					#PE.ResultValidationFailures.AddRange(validationResult.Errors);
				}
				catch (Exception #ob)
				{
					#PE.Errors.Add(new TemplateMessage(#Phc.#3hc(107245058).#z2d(true) + #sYd.#oYd(#ob)));
				}
			}
		}

		// Token: 0x06009048 RID: 36936 RVA: 0x001E85BC File Offset: 0x001E67BC
		private bool #KBb(ParameterRuntime #Sb, string #3, out string #nzb)
		{
			#nzb = null;
			#Mhe #Mhe = new #uhe(this.Model.UnitSystem).#1vb(#Sb.Definition.Key, #3);
			if (#Mhe != null && !string.IsNullOrWhiteSpace(#Mhe.ExecutionCode) && !string.IsNullOrWhiteSpace(#Mhe.ErrorMessage) && !this.#a.#KA(new CodeItem(#Mhe.ExecutionCode)))
			{
				#nzb = #Mhe.ErrorMessage;
				return false;
			}
			return true;
		}

		// Token: 0x06009049 RID: 36937 RVA: 0x001E8630 File Offset: 0x001E6830
		private IList<TemplateReinforcementBar> #uge(IList<EvaluatedReinforcementBar> #vge)
		{
			List<TemplateReinforcementBar> list = new List<TemplateReinforcementBar>();
			HashSet<Point3D> hashSet = new HashSet<Point3D>();
			foreach (EvaluatedReinforcementBar evaluatedReinforcementBar in #vge)
			{
				TemplateEngine.#61b #61b = new TemplateEngine.#61b();
				#61b.#a = new Point3D(evaluatedReinforcementBar.X, evaluatedReinforcementBar.Y);
				if (!hashSet.Contains(#61b.#a) && !hashSet.Any(new Func<Point3D, bool>(#61b.#Baf)))
				{
					hashSet.Add(#61b.#a);
					int? num = StandardBarsProvider.#vCb(evaluatedReinforcementBar.BarSize);
					double? num2 = evaluatedReinforcementBar.Area;
					if (num != null)
					{
						StandardBar standardBar = this.Model.StandardBars.#whe(num.Value);
						float? num3 = (standardBar != null) ? new float?(standardBar.Area) : null;
						num2 = ((num3 != null) ? new double?((double)num3.GetValueOrDefault()) : null);
					}
					Color color = Color.Black;
					if (evaluatedReinforcementBar.Color != 0)
					{
						color = Color.FromArgb(evaluatedReinforcementBar.Color);
					}
					list.Add(new TemplateReinforcementBar((float)num2.GetValueOrDefault(), (float)evaluatedReinforcementBar.X, (float)evaluatedReinforcementBar.Y, 0f, color));
				}
			}
			return list;
		}

		// Token: 0x0600904A RID: 36938 RVA: 0x00074979 File Offset: 0x00072B79
		[CompilerGenerated]
		private UnitSystem #8Zb()
		{
			return this.Model.UnitSystem;
		}

		// Token: 0x04003C8C RID: 15500
		private readonly TemplateEvaluator #a;

		// Token: 0x04003C8D RID: 15501
		[CompilerGenerated]
		private readonly TemplateEngineModel #b;

		// Token: 0x0200107F RID: 4223
		[CompilerGenerated]
		private sealed class #oWb
		{
			// Token: 0x0600904F RID: 36943 RVA: 0x0007499A File Offset: 0x00072B9A
			internal bool #vaf(ParameterRuntime #Rf)
			{
				return #Rf.Definition.Key == this.#a;
			}

			// Token: 0x04003C90 RID: 15504
			public string #a;
		}

		// Token: 0x02001080 RID: 4224
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x06009051 RID: 36945 RVA: 0x000749B2 File Offset: 0x00072BB2
			internal bool #Baf(Point3D #Caf)
			{
				return #Caf.DistanceTo(this.#a) <= 0.001;
			}

			// Token: 0x04003C91 RID: 15505
			public Point3D #a;
		}
	}
}
