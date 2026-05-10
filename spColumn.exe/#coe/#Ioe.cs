using System;
using System.Collections.Generic;
using System.IO;
using #bne;
using #Jie;
using StructurePoint.CoreAssets.AppManager.Column.Storage.ImportExport;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #coe
{
	// Token: 0x020010AF RID: 4271
	internal interface #Ioe
	{
		// Token: 0x140001B4 RID: 436
		// (add) Token: 0x060091BB RID: 37307
		// (remove) Token: 0x060091BC RID: 37308
		event EventHandler OnUnsupportedInputProjectCreatedWithNewerApplication;

		// Token: 0x140001B5 RID: 437
		// (add) Token: 0x060091BD RID: 37309
		// (remove) Token: 0x060091BE RID: 37310
		event EventHandler OnUnsupportedInputFileNoDataFound;

		// Token: 0x140001B6 RID: 438
		// (add) Token: 0x060091BF RID: 37311
		// (remove) Token: 0x060091C0 RID: 37312
		event EventHandler OnOpenInputFileWithNewerFileVersions;

		// Token: 0x140001B7 RID: 439
		// (add) Token: 0x060091C1 RID: 37313
		// (remove) Token: 0x060091C2 RID: 37314
		event EventHandler<#foe> OnOverwriteOfInputProjectCreatedWithNewerApplicationVersion;

		// Token: 0x140001B8 RID: 440
		// (add) Token: 0x060091C3 RID: 37315
		// (remove) Token: 0x060091C4 RID: 37316
		event EventHandler<#Mie> OnLateralLoadsCompatibilityModeRequested;

		// Token: 0x060091C5 RID: 37317
		#9oe #Cjc(string #So, #ape #mA);

		// Token: 0x060091C6 RID: 37318
		#9oe #Cjc(Stream #gp, #ape #mA, #Hoe #cA);

		// Token: 0x060091C7 RID: 37319
		#9oe #9ie(Stream #gp);

		// Token: 0x060091C8 RID: 37320
		void #zl(ColumnStorageModel #Od, string #So, #3oe #mA);

		// Token: 0x060091C9 RID: 37321
		void #zl(ColumnStorageModel #Od, Stream #gp, #3oe #mA, #Hoe #cA);

		// Token: 0x060091CA RID: 37322
		void #1ie(Stream #gp, #boe #2ie);

		// Token: 0x060091CB RID: 37323
		#boe #0ie(Stream #gp);

		// Token: 0x060091CC RID: 37324
		#Xoe #3ie(Stream #gp, SectionImportExportType #8Q);

		// Token: 0x060091CD RID: 37325
		void #4ie(ColumnStorageModel #Od, Stream #gp, SectionImportExportType #8Q);

		// Token: 0x060091CE RID: 37326
		void #5ie(ColumnStorageModel #Od, Stream #gp);

		// Token: 0x060091CF RID: 37327
		#Uoe #6ie(Stream #gp, #dai #mA);

		// Token: 0x060091D0 RID: 37328
		List<FactoredLoad> #ZE(Stream #gp);

		// Token: 0x060091D1 RID: 37329
		List<ServiceLoad> #7ie(Stream #gp);

		// Token: 0x060091D2 RID: 37330
		void #8ie(ColumnStorageModel #Od, LoadType #GB, Stream #gp);
	}
}
