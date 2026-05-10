using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using #c1d;
using #coe;
using #ID;
using #IW;
using #OT;
using #v1c;
using StructurePoint.CoreAssets.AppManager.Column.Storage.ImportExport;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Services.Loads
{
	// Token: 0x02000303 RID: 771
	internal sealed class ImportLoadsService : #JW
	{
		// Token: 0x06001AB8 RID: 6840 RVA: 0x0001A695 File Offset: 0x00018895
		public ImportLoadsService(ICoreServices services, #nF etabsImportService)
		{
			this.#a = services;
			this.#b = etabsImportService;
		}

		// Token: 0x06001AB9 RID: 6841 RVA: 0x000BD884 File Offset: 0x000BBA84
		public bool #UT(LoadsImportType #8Q)
		{
			switch (#8Q)
			{
			case LoadsImportType.FactoredLoads:
			case LoadsImportType.ETABS:
				return !this.#a.Project.Model.Options.ConsiderSlenderness;
			case LoadsImportType.ServiceLoads:
				return true;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06001ABA RID: 6842 RVA: 0x000BD8D8 File Offset: 0x000BBAD8
		public #TT #VT(LoadsImportType #8Q)
		{
			try
			{
				if (#8Q <= LoadsImportType.ServiceLoads)
				{
					return this.#XT(#8Q);
				}
				if (#8Q == LoadsImportType.ETABS)
				{
					return this.#WT();
				}
				throw new ArgumentOutOfRangeException();
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
			return new #TT();
		}

		// Token: 0x06001ABB RID: 6843 RVA: 0x000BD940 File Offset: 0x000BBB40
		private #TT #WT()
		{
			#TT #TT = this.#b.#GD();
			if (#TT.IsSuccess && !#TT.ImportedFactoredLoads.Any<StructurePoint.Products.Column.Model.Entities.FactoredLoad>())
			{
				this.#ZT();
			}
			return #TT;
		}

		// Token: 0x06001ABC RID: 6844 RVA: 0x000BD984 File Offset: 0x000BBB84
		private #TT #XT(LoadsImportType #8Q)
		{
			string #So = this.#YT();
			if (!this.#a.FileSystem.#V1c(#So))
			{
				return new #TT();
			}
			#TT #TT = new #TT();
			using (Stream stream = this.#a.FileSystem.#U1c(#So))
			{
				try
				{
					int num = 0;
					if (#8Q == LoadsImportType.ServiceLoads)
					{
						List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ServiceLoad> list = this.#a.Storage.#7ie(stream);
						num = list.Count;
						#TT.ImportedServiceLoads.AddRange(list.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ServiceLoad, StructurePoint.Products.Column.Model.Entities.ServiceLoad>(ImportLoadsService.<>c.<>9.#l2b)));
					}
					if (#8Q == LoadsImportType.FactoredLoads)
					{
						List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.FactoredLoad> list2 = this.#a.Storage.#ZE(stream);
						num = list2.Count;
						#TT.ImportedFactoredLoads.AddRange(list2.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad>(ImportLoadsService.<>c.<>9.#m2b)));
					}
					if (num == 0)
					{
						this.#ZT();
					}
					#TT.IsSuccess = true;
				}
				catch (#ooe #ooe)
				{
					#TT.IsSuccess = false;
					string #SSc = this.#a.DialogService.#5Sc(Strings.StringImportOperationAborted, #ooe.Message.#A2d());
					this.#a.DialogService.#qn(this.#a.WindowLocator.#6(), #SSc);
				}
			}
			return #TT;
		}

		// Token: 0x06001ABD RID: 6845 RVA: 0x000BDB2C File Offset: 0x000BBD2C
		private string #YT()
		{
			#12c #R1c = new #12c(this.#c, #b1d.TextExtension, null);
			return this.#a.FileSystem.#S1c(#R1c);
		}

		// Token: 0x06001ABE RID: 6846 RVA: 0x0001A6CB File Offset: 0x000188CB
		private void #ZT()
		{
			this.#a.DialogService.#pn(this.#a.WindowLocator.#6(), Strings.StringNothingToImport.#z2d());
		}

		// Token: 0x04000AA9 RID: 2729
		private readonly ICoreServices #a;

		// Token: 0x04000AAA RID: 2730
		private readonly #nF #b;

		// Token: 0x04000AAB RID: 2731
		private readonly List<#L1c> #c = new List<#L1c>
		{
			new #L1c(Strings.StringDataExchangeFormat, #b1d.TextExtension)
		};
	}
}
