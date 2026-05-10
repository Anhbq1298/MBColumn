using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using #7hc;
using #v1c;
using #yUi;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.Application.Misc;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.BatchExecution
{
	// Token: 0x020006DE RID: 1758
	internal sealed class BatchOrganizer : #xUi
	{
		// Token: 0x06003A92 RID: 14994 RVA: 0x00032D1C File Offset: 0x00030F1C
		public BatchOrganizer(#v2c fileSystem, ISettingsManager settings)
		{
			this.#a = fileSystem;
			this.#b = settings;
		}

		// Token: 0x06003A93 RID: 14995 RVA: 0x00115304 File Offset: 0x00113504
		public void #uUi(IList<BatchItemViewModel> #vUi, string #Yof, IList<string> #wUi)
		{
			List<BatchItemViewModel> list = #vUi.Where(new Func<BatchItemViewModel, bool>(BatchOrganizer.<>c.<>9.#WVi)).ToList<BatchItemViewModel>();
			if (!list.Any<BatchItemViewModel>())
			{
				return;
			}
			string text = this.#Io(#Yof);
			string text2 = this.#Ho(#Yof);
			this.#a.#k2c(text);
			this.#a.#k2c(text2);
			foreach (BatchItemViewModel batchItemViewModel in list)
			{
				string #i2c = Path.Combine(text2, batchItemViewModel.FileName);
				if (this.#a.#V1c(batchItemViewModel.FilePath))
				{
					this.#a.#g2c(batchItemViewModel.FilePath, #i2c, true);
				}
				foreach (string #So in #wUi)
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(batchItemViewModel.FilePath);
					string[] array = this.#a.#Ro(#So, fileNameWithoutExtension + #Phc.#3hc(107413100), SearchOption.TopDirectoryOnly);
					foreach (string text3 in array)
					{
						string #i2c2 = Path.Combine(text, Path.GetFileName(text3));
						this.#a.#g2c(text3, #i2c2, true);
					}
				}
			}
		}

		// Token: 0x06003A94 RID: 14996 RVA: 0x001154AC File Offset: 0x001136AC
		public void #eb(string #Yof)
		{
			string #So = this.#Io(#Yof);
			if (!this.#a.#X1c(#So))
			{
				try
				{
					this.#a.#k2c(#So);
				}
				catch (Exception innerException)
				{
					throw new Exception(Strings.StringCoundNotCreateAcceptedOutputDirectory.#z2d(), innerException);
				}
			}
			string #So2 = this.#Ho(#Yof);
			if (!this.#a.#X1c(#So2))
			{
				try
				{
					this.#a.#k2c(#So2);
				}
				catch (Exception innerException2)
				{
					throw new Exception(Strings.StringCoundNotCreateAcceptedDataFilesDirectory.#z2d(), innerException2);
				}
			}
		}

		// Token: 0x06003A95 RID: 14997 RVA: 0x00115558 File Offset: 0x00113758
		private string #Ho(string #Yof)
		{
			BatchProcessorSettings batchProcessorSettings = this.#b.BatchProcessorSettings;
			return Path.Combine(#Yof, batchProcessorSettings.AcceptedDataFilesFolder);
		}

		// Token: 0x06003A96 RID: 14998 RVA: 0x0011558C File Offset: 0x0011378C
		private string #Io(string #Yof)
		{
			BatchProcessorSettings batchProcessorSettings = this.#b.BatchProcessorSettings;
			return Path.Combine(#Yof, batchProcessorSettings.AcceptedOutputsFolder);
		}

		// Token: 0x040018F6 RID: 6390
		private readonly #v2c #a;

		// Token: 0x040018F7 RID: 6391
		private readonly ISettingsManager #b;
	}
}
