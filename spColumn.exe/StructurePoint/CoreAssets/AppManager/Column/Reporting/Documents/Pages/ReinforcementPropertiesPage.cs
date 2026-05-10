using System;
using System.Collections.Generic;
using System.Linq;
using #12e;
using #7hc;
using #hye;
using #owe;
using #Qcd;
using #Rwe;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages
{
	// Token: 0x020011CE RID: 4558
	internal sealed class ReinforcementPropertiesPage : #nwe
	{
		// Token: 0x06009990 RID: 39312 RVA: 0x00079E04 File Offset: 0x00078004
		public ReinforcementPropertiesPage(#pwe context) : base(context)
		{
		}

		// Token: 0x06009991 RID: 39313 RVA: 0x00079ED2 File Offset: 0x000780D2
		public static IEnumerable<string> #bze(#lte #Od)
		{
			ReinforcementRatios reinforcementRatios = #Od.Input.ReinforcementRatios;
			#l4e #l4e = #Od.Output;
			#i5e #i5e = (#l4e != null) ? #l4e.Variables : null;
			int problemType = (int)#Od.Input.Options.ProblemType;
			string text = string.Empty;
			if (problemType == 1)
			{
				#i5e #i5e2 = #i5e;
				float? num = (#i5e2 != null) ? #i5e2.SectionPropTotalSteelArea : null;
				float? num2 = #Od.AsMin;
				if (num.GetValueOrDefault() < num2.GetValueOrDefault() & (num != null & num2 != null))
				{
					text = string.Format(Localization.StringNoteALessThanB, #Yxe.As, #Yxe.AsMin);
				}
				#i5e #i5e3 = #i5e;
				num2 = ((#i5e3 != null) ? #i5e3.SectionPropTotalSteelArea : null);
				num = #Od.AsMax;
				if (num2.GetValueOrDefault() > num.GetValueOrDefault() & (num2 != null & num != null))
				{
					text = string.Format(Localization.StringNoteAGreaterThanB, #Yxe.As, #Yxe.AsMax);
				}
				if (#Od.Output != null)
				{
					if (#Od.Output.Messages.Any(new Func<Message, bool>(ReinforcementPropertiesPage.<>c.<>9.#Gcf)))
					{
						yield return Localization.StringNoteBarSpacingLessThanAllowed;
					}
				}
			}
			else
			{
				#i5e #i5e4 = #i5e;
				float? num = (#i5e4 != null) ? #i5e4.SectionPropRho : null;
				double? num3 = (num != null) ? new double?((double)num.GetValueOrDefault()) : null;
				double num4 = 0.5;
				if (num3.GetValueOrDefault() < num4 & num3 != null)
				{
					text = string.Format(Localization.StringNoteALessThanB, Localization.StringRho, #Phc.#3hc(107309159));
				}
				else
				{
					#i5e #i5e5 = #i5e;
					bool flag;
					if (#i5e5 == null)
					{
						flag = false;
					}
					else
					{
						num = #i5e5.SectionPropRho;
						float num5 = (float)1;
						flag = (num.GetValueOrDefault() < num5 & num != null);
					}
					if (flag)
					{
						text = string.Format(Localization.StringNoteALessThanB, Localization.StringRho, #Phc.#3hc(107309182));
					}
					else
					{
						#i5e #i5e6 = #i5e;
						bool flag2;
						if (#i5e6 == null)
						{
							flag2 = false;
						}
						else
						{
							num = #i5e6.SectionPropRho;
							float num5 = (float)8;
							flag2 = (num.GetValueOrDefault() > num5 & num != null);
						}
						if (flag2)
						{
							text = string.Format(Localization.StringNoteAGreaterThanB, Localization.StringRho, #Phc.#3hc(107309173));
						}
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				yield return text;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				#i5e #i5e7 = #i5e;
				float? num = (#i5e7 != null) ? #i5e7.SectionPropRho : null;
				if (num != null)
				{
					#i5e #i5e8 = #i5e;
					num = ((#i5e8 != null) ? new float?(#i5e8.SectionPropRho.Value) : null);
					float num5 = reinforcementRatios.MinReinforcementRatio;
					if (num.GetValueOrDefault() < num5 & num != null)
					{
						yield return string.Format(Localization.StringNoteALessThanB, Localization.StringRho, #Phc.#3hc(107309182));
					}
				}
			}
			yield break;
		}

		// Token: 0x06009992 RID: 39314 RVA: 0x0020A50C File Offset: 0x0020870C
		public override void #pEd()
		{
			Option option = base.Options.ReinforcementProperties;
			if (!option.#ISd())
			{
				return;
			}
			#ldd #ldd = base.Renderer;
			string arrangement = Localization.Arrangement;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(arrangement, #4cd, null, #Tcd, null);
			base.#Rcd(new #Nye(base.Model, null, false));
			List<string> #wed = ReinforcementPropertiesPage.#bze(base.Model).ToList<string>();
			base.#eCd(#wed, true);
		}
	}
}
