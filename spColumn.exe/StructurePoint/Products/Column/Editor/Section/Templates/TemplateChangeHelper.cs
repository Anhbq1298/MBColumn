using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #npe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Column.Core.ViewModels.Templates;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.ViewModels.Definitions.Modules;

namespace StructurePoint.Products.Column.Editor.Section.Templates
{
	// Token: 0x020004A5 RID: 1189
	internal static class TemplateChangeHelper
	{
		// Token: 0x06002C09 RID: 11273 RVA: 0x000EB218 File Offset: 0x000E9418
		public static void #Owb(ColumnModel #Od, SectionTemplateDefinition #Pwb)
		{
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			if (#Pwb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107356739));
			}
			#Od.TemplateData.#P0(#Pwb);
			List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar> #Ege = #Od.Bars.Select(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar>(TemplateChangeHelper.<>c.<>9.#S7b)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar>();
			TemplateEngineModel model = TemplateEngineModel.#Dge(#Pwb, #Od.Options.Unit, #Od.Options.Code, #Ege, #Phc.#3hc(107401382));
			TemplateEngine engine = new TemplateEngine(model);
			TemplateRuntimeViewModel templateRuntimeViewModel = new TemplateRuntimeViewModel(engine);
			#Od.TemplateData.ParameterValues.AddRange(templateRuntimeViewModel.AllParameters.Select(new Func<TemplateParameterViewModelBase, TemplateParameterValueEntity>(TemplateChangeHelper.<>c.<>9.#T7b)));
			if (#Od.BarGroupType != #Pwb.DefaultBarGroupType)
			{
				List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF = #mpe.#bpe(#Pwb.DefaultBarGroupType, #Od.Options.Unit).Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar, StructurePoint.Products.Column.Model.Entities.StandardBar>(TemplateChangeHelper.<>c.<>9.#U7b)).ToList<StructurePoint.Products.Column.Model.Entities.StandardBar>();
				BarGroupChangeHelper.#2F(#Od, #YF, true, false);
			}
		}
	}
}
