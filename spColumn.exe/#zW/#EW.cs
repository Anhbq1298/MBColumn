using System;
using System.Collections.Generic;
using System.IO;
using #7hc;
using #c1d;
using #eU;
using #v1c;
using #xKe;
using StructurePoint.CoreAssets.AppManager.Column.Storage.ImportExport;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Services;
using StructurePoint.Products.Column.Services.API;

namespace #zW
{
	// Token: 0x0200031E RID: 798
	internal sealed class #EW : #yW
	{
		// Token: 0x06001BB7 RID: 7095 RVA: 0x0001AEE5 File Offset: 0x000190E5
		public #EW(IExtendedServices #0c, #qW #1c)
		{
			this.#a = #0c;
			this.#b = #1c;
		}

		// Token: 0x06001BB8 RID: 7096 RVA: 0x000BEBEC File Offset: 0x000BCDEC
		public void #0(SectionImportExportType #xW)
		{
			try
			{
				List<#L1c> #m2c = new List<#L1c>
				{
					new #L1c(#Phc.#3hc(107400819), #b1d.TextExtension)
				};
				#62c #62c = new #62c(#m2c, #b1d.TextExtension, null);
				#62c.InitialFileName = #CSd.#dy(this.#a.Project.LoadedFilePath, #xW);
				string text = this.#a.FileSystem.#11c(#62c);
				if (!string.IsNullOrWhiteSpace(text))
				{
					using (Stream stream = this.#a.FileSystem.#T1c(text))
					{
						ColumnStorageModel #Od = this.#a.Project.Model.#CY();
						ExportModelHelper.#bJ(#Od, this.#b.DesignEngine);
						this.#a.Storage.#4ie(#Od, stream, #xW);
						this.#a.DialogService.#pn(this.#a.DialogService.ActiveWindow, Strings.StringSpColumn, Strings.StringExportOperationWasSuccessful.#z2d());
						this.#a.GuiController.IsBackstageOpen = false;
					}
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x04000AEC RID: 2796
		private readonly IExtendedServices #a;

		// Token: 0x04000AED RID: 2797
		private readonly #qW #b;
	}
}
