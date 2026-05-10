using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;

namespace #N7d
{
	// Token: 0x02000F68 RID: 3944
	internal sealed class #17d : #L8d<AngleUnit>, #07d
	{
		// Token: 0x06008AD6 RID: 35542 RVA: 0x001D92B4 File Offset: 0x001D74B4
		public double #Pb(AngleUnit #K7d, AngleUnit #B6, double #c4)
		{
			double num = #c4;
			if (#K7d != #B6)
			{
				num *= #17d.#L7d(#K7d, #B6);
			}
			return num;
		}

		// Token: 0x06008AD7 RID: 35543 RVA: 0x0007115F File Offset: 0x0006F35F
		private static double #L7d(AngleUnit #A6, AngleUnit #B6)
		{
			return #17d.#a[#A6][#B6];
		}

		// Token: 0x06008AD9 RID: 35545 RVA: 0x001D92E0 File Offset: 0x001D74E0
		// Note: this type is marked as 'beforefieldinit'.
		static #17d()
		{
			Dictionary<AngleUnit, Dictionary<AngleUnit, double>> dictionary = new Dictionary<AngleUnit, Dictionary<AngleUnit, double>>();
			dictionary.Add(AngleUnit.Degree, new Dictionary<AngleUnit, double>
			{
				{
					AngleUnit.Radian,
					0.0174532925199433
				}
			});
			AngleUnit key = AngleUnit.Radian;
			Dictionary<AngleUnit, double> dictionary2 = new Dictionary<AngleUnit, double>();
			dictionary2.Add(AngleUnit.Degree, 57.29577951308232);
			if (!false)
			{
				dictionary.Add(key, dictionary2);
			}
			#17d.#a = dictionary;
		}

		// Token: 0x0400392F RID: 14639
		private static readonly Dictionary<AngleUnit, Dictionary<AngleUnit, double>> #a;
	}
}
