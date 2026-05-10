using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #c1d;
using #coe;
using #eU;
using #LQc;
using #v1c;
using #zW;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Storage.ImportExport;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Services.Section
{
	// Token: 0x020002DA RID: 730
	internal sealed class SectionImportService : #AW
	{
		// Token: 0x06001963 RID: 6499 RVA: 0x000B7C70 File Offset: 0x000B5E70
		public SectionImportService(IExtendedServices services, IEditorService editorService)
		{
			if (services == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107407561));
			}
			this.#a = services;
			if (editorService == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107401352));
			}
			this.#b = editorService;
			#v2c #v2c = services.FileSystem;
			if (#v2c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107400838));
			}
			this.#c = #v2c;
			#8Sc #8Sc = services.DialogService;
			if (#8Sc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107400853));
			}
			this.#d = #8Sc;
			#oW #oW = services.Project;
			if (#oW == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107400800));
			}
			this.#e = #oW;
		}

		// Token: 0x06001964 RID: 6500 RVA: 0x000B7D1C File Offset: 0x000B5F1C
		public bool #0(SectionImportExportType #8Q)
		{
			SectionImportService.#ITb #ITb = new SectionImportService.#ITb();
			#ITb.#a = this;
			#ITb.#b = #8Q;
			try
			{
				Window window = this.#a.WindowLocator.#6();
				if (this.#9Q(#ITb.#b, window) != MessageBoxResult.OK)
				{
					return false;
				}
				List<#L1c> #m2c = new List<#L1c>
				{
					new #L1c(#Phc.#3hc(107400819), #b1d.TextExtension)
				};
				#12c #R1c = new #12c(#m2c, #b1d.TextExtension, null);
				string #So = this.#c.#S1c(#R1c);
				if (!this.#c.#V1c(#So))
				{
					return false;
				}
				string text = string.Empty;
				try
				{
					using (Stream stream = this.#c.#U1c(#So))
					{
						#ITb.#c = this.#a.Storage.#3ie(stream, #ITb.#b);
						if (#ITb.#b == SectionImportExportType.OnlyReinforcement || #ITb.#b == SectionImportExportType.Section)
						{
							List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar> list = #ITb.#c.Reinforcement;
							text = ImportHelper.#wLe(ref list);
							if (#ITb.#c.Reinforcement.Count > list.Count)
							{
								#ITb.#c.Reinforcement.Clear();
								#ITb.#c.Reinforcement.AddRange(list);
							}
						}
					}
				}
				catch (#ooe #ooe)
				{
					string #SSc = this.#d.#5Sc(Strings.StringImportOperationAborted, #ooe.Message.#A2d());
					this.#d.#qn(window, #SSc);
					return false;
				}
				if (#ITb.#c == null || (#ITb.#b == SectionImportExportType.Section && #ITb.#c.Geometry.Count == 0 && #ITb.#c.Reinforcement.Count == 0) || (#ITb.#b == SectionImportExportType.OnlyGeometry && #ITb.#c.Geometry.Count == 0) || (#ITb.#b == SectionImportExportType.OnlyReinforcement && #ITb.#c.Reinforcement.Count == 0))
				{
					this.#d.#pn(window, Strings.StringNothingToImport.#z2d());
					return false;
				}
				this.#b.#0Pb(new Action(#ITb.#bVb));
				if (!string.IsNullOrWhiteSpace(text))
				{
					string #hvb = Strings.StringDataImportingReport.#z2d().#Tm() + text;
					this.#d.#pn(window, #hvb);
				}
				return true;
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
			return false;
		}

		// Token: 0x06001965 RID: 6501 RVA: 0x000B7FEC File Offset: 0x000B61EC
		private MessageBoxResult #9Q(SectionImportExportType #8Q, Window #aR)
		{
			if (this.#e.Model.Options.SectionType != SectionType.Irregular)
			{
				return MessageBoxResult.OK;
			}
			if (#8Q == SectionImportExportType.Section && (this.#e.Model.Shapes.Any<ShapeModel>() || this.#e.Model.ReinforcementBars.Any<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>()))
			{
				return this.#d.#0Sc(#aR, Strings.StringExistingIrregularSectionsWillBeDiscarded.#z2d());
			}
			if (#8Q == SectionImportExportType.OnlyGeometry && this.#e.Model.Shapes.Any<ShapeModel>())
			{
				return this.#d.#0Sc(#aR, Strings.StringExistingIrregularShapesWillBeDiscarded.#z2d());
			}
			if (#8Q == SectionImportExportType.OnlyReinforcement && this.#e.Model.ReinforcementBars.Any<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>())
			{
				return this.#d.#0Sc(#aR, Strings.StringExistingIrregularReinforcementWillBeDiscarded.#z2d());
			}
			return MessageBoxResult.OK;
		}

		// Token: 0x040009AD RID: 2477
		private readonly IExtendedServices #a;

		// Token: 0x040009AE RID: 2478
		private readonly IEditorService #b;

		// Token: 0x040009AF RID: 2479
		private readonly #v2c #c;

		// Token: 0x040009B0 RID: 2480
		private readonly #8Sc #d;

		// Token: 0x040009B1 RID: 2481
		private readonly #oW #e;

		// Token: 0x020002DC RID: 732
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x0600196B RID: 6507 RVA: 0x000B80E0 File Offset: 0x000B62E0
			internal void #bVb()
			{
				if (this.#a.#e.Model.Options.SectionType != SectionType.Irregular || this.#a.#e.Model.Options.InvestigationReinforcement != ReinforcementType.Irregular)
				{
					this.#a.#e.Model.#JY(SectionType.Irregular, true);
					ColumnModelHelper.#1W(this.#a.#a.StorageModelConverter, this.#a.#e.Model);
				}
				if (this.#b == SectionImportExportType.OnlyGeometry || this.#b == SectionImportExportType.Section)
				{
					this.#a.#e.Model.Shapes.Clear();
					this.#a.#e.Model.Shapes.AddRange(this.#c.Geometry.Select(new Func<SectionPolygon, ShapeModel>(SectionImportService.<>c.<>9.#w0b)));
					this.#a.#e.#3O();
				}
				if (this.#b == SectionImportExportType.OnlyReinforcement || this.#b == SectionImportExportType.Section)
				{
					this.#a.#e.Model.ReinforcementBars.Clear();
					this.#a.#e.Model.ReinforcementBars.AddRange(this.#c.Reinforcement.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar, StructurePoint.Products.Column.Model.Entities.ReinforcementBar>(SectionImportService.<>c.<>9.#x0b)));
				}
				ColumnModelHelper.#VW(this.#a.#e);
				this.#a.#a.SnappingCache.#uP(this.#a.#e);
			}

			// Token: 0x040009B5 RID: 2485
			public SectionImportService #a;

			// Token: 0x040009B6 RID: 2486
			public SectionImportExportType #b;

			// Token: 0x040009B7 RID: 2487
			public #Xoe #c;
		}
	}
}
