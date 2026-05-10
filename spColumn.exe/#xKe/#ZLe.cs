using System;
using System.Collections.Generic;
using System.IO;
using #7hc;
using #coe;
using #Lme;
using #wje;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Current;
using StructurePoint.CoreAssets.AppManager.Column.Storage.ImportExport;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #xKe
{
	// Token: 0x0200128F RID: 4751
	internal sealed class #ZLe
	{
		// Token: 0x06009F3C RID: 40764 RVA: 0x0021CA88 File Offset: 0x0021AC88
		public #Xoe #GD(Stream #gp, SectionImportExportType #8Q)
		{
			switch (#8Q)
			{
			case SectionImportExportType.Section:
				return this.#3ie(#gp);
			case SectionImportExportType.OnlyGeometry:
				return this.#XLe(#gp);
			case SectionImportExportType.OnlyReinforcement:
				return this.#YLe(#gp);
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107313322), #8Q, null);
			}
		}

		// Token: 0x06009F3D RID: 40765 RVA: 0x0021CAD8 File Offset: 0x0021ACD8
		public void #xRb(Stream #gp, ColumnStorageModel #Od, SectionImportExportType #8Q)
		{
			SectionExporter sectionExporter = new SectionExporter();
			switch (#8Q)
			{
			case SectionImportExportType.Section:
				sectionExporter.#xRb(#gp, #Od);
				return;
			case SectionImportExportType.OnlyGeometry:
				sectionExporter.#Mme(#gp, #Od.Polygons);
				return;
			case SectionImportExportType.OnlyReinforcement:
				sectionExporter.#Nme(#gp, #Od.ReinforcementBars);
				return;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107313322), #8Q, null);
			}
		}

		// Token: 0x06009F3E RID: 40766 RVA: 0x0021CB3C File Offset: 0x0021AD3C
		private #Xoe #3ie(Stream #gp)
		{
			#Xoe #Xoe = new #Xoe();
			try
			{
				#1me #1me = new #1me(#gp);
				List<SectionPolygon> list = #1me.#Rme();
				List<SectionPolygon> list2 = #1me.#Sme();
				List<ReinforcementBar> list3 = #1me.#Tme();
				if (list == null && list2 == null && list3 == null)
				{
					throw new #ooe(Strings.StringImportFailedCannotLocateAnyKeyword.#z2d());
				}
				#Xoe.Geometry.AddRange(list ?? new List<SectionPolygon>());
				#Xoe.Geometry.AddRange(list2 ?? new List<SectionPolygon>());
				#Xoe.Reinforcement.AddRange(list3 ?? new List<ReinforcementBar>());
			}
			catch (EndOfStreamException)
			{
				throw new #ooe(Strings.StringUnexpectedEndOfFile.#z2d());
			}
			return #Xoe;
		}

		// Token: 0x06009F3F RID: 40767 RVA: 0x0021CBE8 File Offset: 0x0021ADE8
		private #Xoe #XLe(Stream #gp)
		{
			List<SectionPolygon> list = new List<SectionPolygon>();
			try
			{
				#1me #1me = new #1me(#gp);
				List<SectionPolygon> list2 = #1me.#Rme();
				List<SectionPolygon> list3 = #1me.#Sme();
				if (list2 == null && list3 == null)
				{
					if (#1me.#Ume() == null)
					{
						throw new #ooe(Strings.StringImportFailedCannotLocateAnyKeyword.#z2d());
					}
					Stream #gp2 = #1me.#zoe();
					list = new #bke().#8je(#gp2);
				}
				list.AddRange(list2 ?? new List<SectionPolygon>());
				list.AddRange(list3 ?? new List<SectionPolygon>());
			}
			catch (EndOfStreamException)
			{
				throw new #ooe(Strings.StringUnexpectedEndOfFile.#z2d());
			}
			return new #Xoe
			{
				Geometry = list
			};
		}

		// Token: 0x06009F40 RID: 40768 RVA: 0x0021CCA0 File Offset: 0x0021AEA0
		private #Xoe #YLe(Stream #gp)
		{
			List<ReinforcementBar> list;
			try
			{
				#1me #1me = new #1me(#gp);
				list = #1me.#Tme();
				if (list == null)
				{
					if (#1me.#Ume() == null)
					{
						throw new #ooe(Strings.StringCannotFind0Keyword.#D2d(new object[]
						{
							#Phc.#3hc(107290018)
						}).#z2d());
					}
					Stream #gp2 = #1me.#zoe();
					list = new #zke().#yke(#gp2);
				}
			}
			catch (EndOfStreamException)
			{
				throw new #ooe(Strings.StringUnexpectedEndOfFile.#z2d());
			}
			return new #Xoe
			{
				Reinforcement = (list ?? new List<ReinforcementBar>())
			};
		}

		// Token: 0x04004574 RID: 17780
		public const string #a = "SOLIDS";

		// Token: 0x04004575 RID: 17781
		public const string #b = "OPENINGS";

		// Token: 0x04004576 RID: 17782
		public const string #c = "REINFORCEMENT";
	}
}
