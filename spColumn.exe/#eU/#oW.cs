using System;
using System.Collections.Generic;
using #qJ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.Column.Core.Templates.Rendering;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace #eU
{
	// Token: 0x020002BE RID: 702
	internal interface #oW
	{
		// Token: 0x1400003A RID: 58
		// (add) Token: 0x06001864 RID: 6244
		// (remove) Token: 0x06001865 RID: 6245
		event EventHandler<#7V> ModelChanged;

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x06001866 RID: 6246
		// (remove) Token: 0x06001867 RID: 6247
		event EventHandler<#7V> ModelChanging;

		// Token: 0x17000908 RID: 2312
		// (get) Token: 0x06001868 RID: 6248
		ColumnModel Model { get; }

		// Token: 0x17000909 RID: 2313
		// (get) Token: 0x06001869 RID: 6249
		bool IsChangingModel { get; }

		// Token: 0x1700090A RID: 2314
		// (get) Token: 0x0600186A RID: 6250
		// (set) Token: 0x0600186B RID: 6251
		bool IsChangingModelExtended { get; set; }

		// Token: 0x1700090B RID: 2315
		// (get) Token: 0x0600186C RID: 6252
		// (set) Token: 0x0600186D RID: 6253
		string LoadedFilePath { get; set; }

		// Token: 0x1700090C RID: 2316
		// (get) Token: 0x0600186E RID: 6254
		// (set) Token: 0x0600186F RID: 6255
		string LoadedTemplateName { get; set; }

		// Token: 0x1700090D RID: 2317
		// (get) Token: 0x06001870 RID: 6256
		#LO Metadata { get; }

		// Token: 0x1700090E RID: 2318
		// (get) Token: 0x06001871 RID: 6257
		// (set) Token: 0x06001872 RID: 6258
		TemplateExecutionResult TemplateExecutionResult { get; set; }

		// Token: 0x1700090F RID: 2319
		// (get) Token: 0x06001873 RID: 6259
		List<ZoneInfo> TemplateZoneInfos { get; }

		// Token: 0x06001874 RID: 6260
		bool #5O();

		// Token: 0x06001875 RID: 6261
		bool #6O(ColumnStorageModel #7O, bool #xi);

		// Token: 0x06001876 RID: 6262
		void #3O();

		// Token: 0x06001877 RID: 6263
		void #2O();

		// Token: 0x06001878 RID: 6264
		void #1Uh(ShapeModel #rP);
	}
}
