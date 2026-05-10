using System;
using System.Collections.Generic;
using System.IO;
using #c1d;
using #eU;
using #IW;
using #LQc;
using #v1c;
using #xKe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Services.API;

namespace #OT
{
	// Token: 0x02000300 RID: 768
	internal sealed class #NT : #HW
	{
		// Token: 0x06001AAE RID: 6830 RVA: 0x000BD728 File Offset: 0x000BB928
		public #NT(ICoreServices #0c)
		{
			this.#a = #0c;
			this.#c = #0c.Project;
			this.#d = #0c.DialogService;
		}

		// Token: 0x06001AAF RID: 6831 RVA: 0x0001A62E File Offset: 0x0001882E
		public bool #LT(LoadType #GB)
		{
			return #GB == LoadType.Service || #GB == LoadType.Factored;
		}

		// Token: 0x06001AB0 RID: 6832 RVA: 0x000BD77C File Offset: 0x000BB97C
		public void #MT(ColumnStorageModel #X, LoadType #GB)
		{
			try
			{
				#62c #62c = new #62c(this.#b, #b1d.TextExtension, null);
				#62c.InitialFileName = #CSd.#dy(this.#c.LoadedFilePath, #GB);
				string text = this.#a.FileSystem.#11c(#62c);
				if (!string.IsNullOrWhiteSpace(text))
				{
					using (Stream stream = this.#a.FileSystem.#T1c(text))
					{
						this.#a.Storage.#8ie(#X, #GB, stream);
						this.#d.#pn(this.#d.ActiveWindow, Strings.StringExportOperationWasSuccessful.#z2d());
					}
					this.#a.GuiController.IsBackstageOpen = false;
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x04000AA2 RID: 2722
		private readonly ICoreServices #a;

		// Token: 0x04000AA3 RID: 2723
		private readonly List<#L1c> #b = new List<#L1c>
		{
			new #L1c(Strings.StringDataExchangeFormat, #b1d.TextExtension)
		};

		// Token: 0x04000AA4 RID: 2724
		private readonly #oW #c;

		// Token: 0x04000AA5 RID: 2725
		private readonly #8Sc #d;
	}
}
