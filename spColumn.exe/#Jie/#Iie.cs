using System;
using System.Globalization;
using System.IO;
using System.Text;
using #7hc;
using #coe;
using #npe;
using #o1d;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Current.CTI;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.CTI;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #Jie
{
	// Token: 0x020010A9 RID: 4265
	internal sealed class #Iie
	{
		// Token: 0x06009180 RID: 37248 RVA: 0x001ECDAC File Offset: 0x001EAFAC
		public #9oe #Cjc(Stream #gp)
		{
			if (#gp == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107377314));
			}
			#Iie.#Waf #Waf = this.#Hie(#gp);
			ColumnStorageModel columnStorageModel = null;
			switch (#Waf)
			{
			case #Iie.#Waf.#a:
				return #9oe.#4oe(Strings.StringCouldNotDetermineCTIFormatVersion.#z2d());
			case #Iie.#Waf.#b:
				columnStorageModel = new LegacyCtiFormatReader(#gp).#Cjc();
				break;
			case #Iie.#Waf.#c:
				columnStorageModel = new CurrentCtiFormatReader(#gp).#Cjc();
				break;
			}
			if (columnStorageModel != null)
			{
				#9oe #9oe = new #9oe(columnStorageModel, true);
				#9oe.OriginalLoadType = columnStorageModel.Options.ActiveLoad;
				#wpe.#spe(columnStorageModel);
				#wpe.#tpe(columnStorageModel);
				#Wpe.#tpe(columnStorageModel);
				#wpe.#rpe(columnStorageModel);
				return #9oe;
			}
			return #9oe.#4oe();
		}

		// Token: 0x06009181 RID: 37249 RVA: 0x001ECE50 File Offset: 0x001EB050
		private #Iie.#Waf #Hie(Stream #gp)
		{
			#gp.#i2d();
			try
			{
				using (StreamReader streamReader = new StreamReader(#gp, Encoding.UTF8, true, 1024, true))
				{
					streamReader.ReadLine();
					string text = streamReader.ReadLine();
					string b = (text != null) ? text.Trim() : null;
					if (string.Equals(#Phc.#3hc(107290874), b))
					{
						string text2 = streamReader.ReadLine();
						float num;
						if (float.TryParse((text2 != null) ? text2.Trim() : null, NumberStyles.Any, CultureInfo.InvariantCulture, out num))
						{
							return (num >= 10f) ? #Iie.#Waf.#c : #Iie.#Waf.#b;
						}
					}
				}
			}
			finally
			{
				#gp.#i2d();
			}
			return #Iie.#Waf.#a;
		}

		// Token: 0x020010AA RID: 4266
		private enum #Waf
		{
			// Token: 0x04003D2E RID: 15662
			#a,
			// Token: 0x04003D2F RID: 15663
			#b,
			// Token: 0x04003D30 RID: 15664
			#c
		}
	}
}
