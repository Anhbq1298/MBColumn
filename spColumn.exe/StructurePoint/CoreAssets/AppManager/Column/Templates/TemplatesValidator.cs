using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #cYd;
using #npe;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates
{
	// Token: 0x0200105F RID: 4191
	public static class TemplatesValidator
	{
		// Token: 0x06008F8E RID: 36750 RVA: 0x001E77C4 File Offset: 0x001E59C4
		public static IList<TemplateError> #IH(SectionTemplateDefinition #xS)
		{
			TemplatesValidator.#GTb #GTb = new TemplatesValidator.#GTb();
			#GTb.#a = #xS;
			List<TemplateError> list = new List<TemplateError>();
			foreach (UnitSystem unitSystem in new List<UnitSystem>
			{
				UnitSystem.USCustomary,
				UnitSystem.SIMetric
			})
			{
				string text = (unitSystem == UnitSystem.USCustomary) ? #Phc.#3hc(107245759) : #Phc.#3hc(107245788);
				List<StandardBar> list2 = #mpe.#bpe(#GTb.#a.DefaultBarGroupType, unitSystem);
				if (!list2.Any<StandardBar>())
				{
					list.Add(new TemplateError(#Phc.#3hc(107245698).#z2d(true) + text));
				}
				TemplateEngineModel templateEngineModel;
				try
				{
					templateEngineModel = TemplateEngineModel.#Dge(#GTb.#a, unitSystem, DesignCodes.CSA94, list2, #Phc.#3hc(107401382));
				}
				catch (Exception #ob)
				{
					list.Add(new TemplateError(#Phc.#3hc(107245633).#z2d(true) + text.#O2d() + #sYd.#oYd(#ob)));
					continue;
				}
				TemplateEngine templateEngine;
				try
				{
					templateEngine = new TemplateEngine(templateEngineModel);
				}
				catch (Exception #ob2)
				{
					list.Add(new TemplateError(#Phc.#3hc(107245624).#z2d(true) + text.#O2d() + #sYd.#oYd(#ob2)));
					continue;
				}
				try
				{
					templateEngine.#qge();
				}
				catch (Exception #ob3)
				{
					list.Add(new TemplateError(#Phc.#3hc(107246059).#z2d(true) + text.#O2d() + #sYd.#oYd(#ob3)));
				}
				using (IEnumerator<ParameterRuntime> enumerator2 = templateEngineModel.AllParameters.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						TemplatesValidator.#o7b #o7b = new TemplatesValidator.#o7b();
						#o7b.#a = enumerator2.Current;
						try
						{
							string str;
							if (!templateEngine.#IH(#o7b.#a.Definition.Key, #o7b.#a.EffectiveValue, out str))
							{
								list.Add(new TemplateError(string.Concat(new string[]
								{
									#Phc.#3hc(107246038),
									#o7b.#a.Name,
									#Phc.#3hc(107395499),
									#o7b.#a.Definition.Key,
									#Phc.#3hc(107245989)
								}).#z2d(true) + text.#O2d() + str));
							}
						}
						catch (Exception #ob4)
						{
							list.Add(new TemplateError(string.Concat(new string[]
							{
								#Phc.#3hc(107245920),
								#o7b.#a.Name,
								#Phc.#3hc(107395499),
								#o7b.#a.Definition.Key,
								#Phc.#3hc(107382694)
							}).#z2d(true) + text.#O2d() + #sYd.#oYd(#ob4)));
						}
						if (!string.IsNullOrWhiteSpace(#o7b.#a.Definition.OverridingParameterKey))
						{
							if (templateEngineModel.AllParameters.FirstOrDefault(new Func<ParameterRuntime, bool>(#o7b.#waf)) == null)
							{
								list.Add(new TemplateError(string.Concat(new string[]
								{
									#Phc.#3hc(107245911),
									#o7b.#a.Name,
									#Phc.#3hc(107395499),
									#o7b.#a.Definition.Key,
									#Phc.#3hc(107245862),
									#o7b.#a.Definition.OverridingParameterKey
								}).#z2d()));
							}
							if (!string.IsNullOrWhiteSpace(#o7b.#a.Definition.IsReadOnlyExpression))
							{
								try
								{
									templateEngine.#KA(#o7b.#a.Definition.IsReadOnlyExpression);
								}
								catch (Exception #ob5)
								{
									list.Add(new TemplateError(string.Concat(new string[]
									{
										#Phc.#3hc(107245281),
										#o7b.#a.Name,
										#Phc.#3hc(107395499),
										#o7b.#a.Definition.Key,
										#Phc.#3hc(107245296)
									}).#z2d(true) + text.#O2d() + #sYd.#oYd(#ob5)));
								}
							}
						}
					}
				}
				try
				{
					TemplateExecutionResult templateExecutionResult = templateEngine.#0(null);
					if (templateExecutionResult == null || !templateExecutionResult.Polygons.Any<SectionPolygon>())
					{
						list.Add(new TemplateError(#Phc.#3hc(107245235).#z2d(true) + text));
					}
					else if (templateExecutionResult.Errors.Any<TemplateMessage>())
					{
						string str2 = string.Join(Environment.NewLine, templateExecutionResult.Errors.Select(new Func<TemplateMessage, string>(TemplatesValidator.<>c.<>9.#xaf)));
						list.Add(new TemplateError(#Phc.#3hc(107356406).#z2d(true) + text + Environment.NewLine + str2));
					}
					else
					{
						ColumnStorageModel columnStorageModel = new ColumnStorageModel
						{
							Options = 
							{
								SectionType = SectionType.IrregularTemplate,
								ProblemType = ProblemType.Investigation,
								InvestigationReinforcement = ReinforcementType.Irregular
							}
						};
						columnStorageModel.Polygons.AddRange(templateExecutionResult.Polygons);
						columnStorageModel.ReinforcementBars.AddRange(templateExecutionResult.Bars.Select(new Func<TemplateReinforcementBar, ReinforcementBar>(TemplatesValidator.<>c.<>9.#yaf)));
						ValidationResult validationResult = new IrregularSectionValidator(columnStorageModel.CreateContext()).Validate(columnStorageModel);
						if (!validationResult.IsValid)
						{
							foreach (ValidationFailure validationFailure in validationResult.Errors)
							{
								list.Add(new TemplateError(validationFailure.ErrorMessage.#O2d() + text));
							}
						}
					}
				}
				catch (Exception #ob6)
				{
					list.Add(new TemplateError(#Phc.#3hc(107245134).#z2d(true) + text.#O2d() + #sYd.#oYd(#ob6)));
				}
			}
			list.ForEach(new Action<TemplateError>(#GTb.#vaf));
			return list;
		}

		// Token: 0x02001061 RID: 4193
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008F94 RID: 36756 RVA: 0x000740D6 File Offset: 0x000722D6
			internal void #vaf(TemplateError #Rf)
			{
				#Rf.TemplateName = this.#a.DisplayName.GetFirstMessage();
			}

			// Token: 0x04003C30 RID: 15408
			public SectionTemplateDefinition #a;
		}

		// Token: 0x02001062 RID: 4194
		[CompilerGenerated]
		private sealed class #o7b
		{
			// Token: 0x06008F96 RID: 36758 RVA: 0x000740EE File Offset: 0x000722EE
			internal bool #waf(ParameterRuntime #gsb)
			{
				return string.Equals(#gsb.Definition.Key, this.#a.Definition.OverridingParameterKey);
			}

			// Token: 0x04003C31 RID: 15409
			public ParameterRuntime #a;
		}
	}
}
