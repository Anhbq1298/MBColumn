using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Core;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #wje
{
	// Token: 0x020010B8 RID: 4280
	internal sealed class #bke : ImportBase
	{
		// Token: 0x060091F5 RID: 37365 RVA: 0x001F002C File Offset: 0x001EE22C
		public List<SectionPolygon> #8je(Stream #gp)
		{
			if (#gp == null)
			{
				return null;
			}
			if (#gp.Length == 0L)
			{
				return new List<SectionPolygon>();
			}
			List<SectionPolygon> list = new List<SectionPolygon>();
			try
			{
				this.#a = 0;
				#gp.Position = 0L;
				StreamReader #blc = new StreamReader(#gp);
				short num = this.#Fic(#blc);
				if (num > 0)
				{
					SectionPolygon sectionPolygon = new SectionPolygon
					{
						Application = PolygonApplication.Solid,
						FigureType = PolygonFigureType.Irregural,
						Points = this.#9je(#blc, num)
					};
					ImportHelper.#9W(sectionPolygon);
					list.Add(sectionPolygon);
				}
				short num2 = this.#Fic(#blc);
				if (num2 > 0)
				{
					SectionPolygon sectionPolygon2 = new SectionPolygon
					{
						Application = PolygonApplication.Opening,
						FigureType = PolygonFigureType.Irregural,
						Points = this.#9je(#blc, num2)
					};
					ImportHelper.#9W(sectionPolygon2);
					list.Add(sectionPolygon2);
				}
				return list;
			}
			catch (EndOfStreamException)
			{
				base.#ame(Strings.StringUnexpectedEndOfFile.#z2d());
			}
			return null;
		}

		// Token: 0x060091F6 RID: 37366 RVA: 0x001F0110 File Offset: 0x001EE310
		private List<Point> #9je(StreamReader #blc, short #ake)
		{
			List<Point> list = new List<Point>();
			for (int i = 0; i < (int)#ake; i++)
			{
				string #ioe = base.#Vle(#blc);
				double[] array = base.#zuc(#ioe, 2).Select(new Func<string, double>(base.#SAc)).ToArray<double>();
				list.Add(new Point(array[0], array[1]));
			}
			return list;
		}

		// Token: 0x060091F7 RID: 37367 RVA: 0x001F0168 File Offset: 0x001EE368
		private short #Fic(StreamReader #blc)
		{
			string #ioe = base.#Vle(#blc);
			short num = (short)base.#Gic(#ioe);
			if (num > 10000)
			{
				base.#ame(string.Format(Strings.StringTheMaximumNumberOfExteriorPointsDefiningTheColum.#z2d(), 10000));
			}
			if (num < 4 && num != 0)
			{
				base.#ame(Strings.StringTheMinimumNumberOfSectionsVerticesNnotAchieved.#D2d(new object[]
				{
					4
				}).#z2d());
			}
			return num;
		}

		// Token: 0x04003D66 RID: 15718
		public new const int #a = 10000;

		// Token: 0x04003D67 RID: 15719
		public const int #b = 4;
	}
}
