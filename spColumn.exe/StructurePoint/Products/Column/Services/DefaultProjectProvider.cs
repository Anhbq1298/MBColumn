using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #coe;
using #eU;
using #ezc;
using #IDc;
using #npe;
using #oKe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Services
{
	// Token: 0x020002B1 RID: 689
	internal sealed class DefaultProjectProvider : #xU
	{
		// Token: 0x060017FF RID: 6143 RVA: 0x000B55FC File Offset: 0x000B37FC
		public DefaultProjectProvider(#yU templatesLoader, ISettingsManager settingsManager, #nKe localizationService, ILogger logger, #xAc applicationInfoProvider, #5Ic notificationService, #Ioe storageProvider, #bDc undoManager, #qW designEngineService)
		{
			if (templatesLoader == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107401879));
			}
			this.#a = templatesLoader;
			if (settingsManager == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381742));
			}
			this.#b = settingsManager;
			if (localizationService == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107401826));
			}
			this.#c = localizationService;
			if (logger == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107408919));
			}
			this.#d = logger;
			if (applicationInfoProvider == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107408977));
			}
			this.#e = applicationInfoProvider;
			if (notificationService == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107401797));
			}
			this.#f = notificationService;
			if (storageProvider == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107401768));
			}
			this.#g = storageProvider;
			if (undoManager == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404911));
			}
			this.#h = undoManager;
			if (designEngineService == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107401779));
			}
			this.#i = designEngineService;
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x000B5708 File Offset: 0x000B3908
		public ColumnStorageModel #4N()
		{
			using (this.#h.#AA())
			{
				ColumnStorageModel columnStorageModel = this.#5N();
				if (columnStorageModel != null)
				{
					return this.#W(columnStorageModel);
				}
			}
			return this.#W(new ColumnStorageModel
			{
				BarGroupType = this.#b.StartupDefaultBarGroupType,
				Options = 
				{
					Code = this.#b.StartupDefaultDesignCode,
					Unit = this.#b.StartupDefaultUnitSystem
				}
			});
		}

		// Token: 0x06001801 RID: 6145 RVA: 0x000B57BC File Offset: 0x000B39BC
		private ColumnStorageModel #W(ColumnStorageModel #X)
		{
			#X.DraftingSettings = DraftingSettings.Default(#X.Options.Unit);
			#wpe.#xkb(#X);
			#Wpe.#xkb(#X);
			#wpe.#qpe(#X);
			#Wpe.#tai(#X);
			#Wpe.#sai(#X);
			IEnumerable<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar> collection = this.#i.#CQ(#X).Select(new Func<StructurePoint.Products.Column.Model.Entities.ReinforcementBar, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>(DefaultProjectProvider.<>c.<>9.#b0b));
			#X.ReinforcementBars.Clear();
			#X.ReinforcementBars.AddRange(collection);
			return #X;
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x000B5864 File Offset: 0x000B3A64
		private ColumnStorageModel #5N()
		{
			Stream stream = null;
			try
			{
				stream = this.#a.#aO(this.#b.StartupDefaultUnitSystem, this.#b.StartupDefaultDesignCode);
				if (stream == null)
				{
					this.#6N(Strings.StringCouldNotFindTheDefaultProjectTemplateForUnitSystemXAndDesignCodeY, null);
					return null;
				}
			}
			catch (Exception #ob)
			{
				this.#6N(Strings.StringCouldNotFindTheDefaultProjectTemplateForUnitSystemXAndDesignCodeY, #ob);
			}
			try
			{
				using (stream)
				{
					#9oe #9oe = this.#g.#9ie(stream);
					if (#9oe.IsValid)
					{
						#9oe.Model.BarGroupType = this.#b.StartupDefaultBarGroupType;
						#9oe.Model.Options.SectionCapacityMethod = this.#b.StartupDefaultSectionCapacity;
						return #9oe.Model;
					}
				}
			}
			catch (Exception #ob2)
			{
				this.#6N(Strings.StringCouldNotLoadTheDefaultProjectTemplateForUnitSystemXAndDesignCodeY, #ob2);
			}
			return null;
		}

		// Token: 0x06001803 RID: 6147 RVA: 0x000B5970 File Offset: 0x000B3B70
		private void #6N(string #7N, Exception #ob)
		{
			DefaultProjectProvider.#BUb #BUb = new DefaultProjectProvider.#BUb();
			#BUb.#a = #7N.#D2d(new object[]
			{
				this.#9N(),
				this.#8N()
			}).#z2d();
			this.#d.Log(LoggingLevel.Warning, new Func<string>(#BUb.#c0b), #ob);
			#3Hc #Ic = new #3Hc(this.#e.ApplicationName.#F2d() + Strings.StringProjectTemplate, this.#a.#cO(this.#b.StartupDefaultUnitSystem, this.#b.StartupDefaultDesignCode));
			this.#f.#1Ic(#Ic, #BUb.#a, #ob);
		}

		// Token: 0x06001804 RID: 6148 RVA: 0x00018808 File Offset: 0x00016A08
		private string #8N()
		{
			return this.#c.AvailableDesignCodes[this.#b.StartupDefaultDesignCode];
		}

		// Token: 0x06001805 RID: 6149 RVA: 0x00018831 File Offset: 0x00016A31
		private string #9N()
		{
			return this.#c.AvailableUnitSystems[this.#b.StartupDefaultUnitSystem];
		}

		// Token: 0x04000925 RID: 2341
		private readonly #yU #a;

		// Token: 0x04000926 RID: 2342
		private readonly ISettingsManager #b;

		// Token: 0x04000927 RID: 2343
		private readonly #nKe #c;

		// Token: 0x04000928 RID: 2344
		private readonly ILogger #d;

		// Token: 0x04000929 RID: 2345
		private readonly #xAc #e;

		// Token: 0x0400092A RID: 2346
		private readonly #5Ic #f;

		// Token: 0x0400092B RID: 2347
		private readonly #Ioe #g;

		// Token: 0x0400092C RID: 2348
		private readonly #bDc #h;

		// Token: 0x0400092D RID: 2349
		private readonly #qW #i;

		// Token: 0x020002B3 RID: 691
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x0600180A RID: 6154 RVA: 0x0001887A File Offset: 0x00016A7A
			internal string #c0b()
			{
				return this.#a;
			}

			// Token: 0x04000930 RID: 2352
			public string #a;
		}
	}
}
