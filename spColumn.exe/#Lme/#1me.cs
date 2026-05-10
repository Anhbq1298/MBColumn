using System;
using System.Collections.Generic;
using System.IO;
using #7hc;
using #coe;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #Lme
{
	// Token: 0x020010DE RID: 4318
	internal sealed class #1me : #Foe
	{
		// Token: 0x060092C2 RID: 37570 RVA: 0x00075C6B File Offset: 0x00073E6B
		public #1me(Stream #gp) : base(#gp)
		{
		}

		// Token: 0x060092C3 RID: 37571 RVA: 0x00075C74 File Offset: 0x00073E74
		public List<SectionPolygon> #Rme()
		{
			return this.#Yme(PolygonApplication.Solid, #Phc.#3hc(107290072));
		}

		// Token: 0x060092C4 RID: 37572 RVA: 0x00075C87 File Offset: 0x00073E87
		public List<SectionPolygon> #Sme()
		{
			return this.#Yme(PolygonApplication.Opening, #Phc.#3hc(107290031));
		}

		// Token: 0x060092C5 RID: 37573 RVA: 0x00075C9A File Offset: 0x00073E9A
		public List<ReinforcementBar> #Tme()
		{
			return this.#0me(#Phc.#3hc(107290018));
		}

		// Token: 0x060092C6 RID: 37574 RVA: 0x001F27C8 File Offset: 0x001F09C8
		public int? #Ume()
		{
			int? num = base.#uoe();
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (num2.GetValueOrDefault() >= num3 & num2 != null)
				{
					return num;
				}
			}
			return null;
		}

		// Token: 0x060092C7 RID: 37575 RVA: 0x001F280C File Offset: 0x001F0A0C
		private List<SectionPolygon> #Vme(PolygonApplication #Wme, string #Xme)
		{
			base.#roe(#Xme, true);
			List<SectionPolygon> list = new List<SectionPolygon>();
			int num = base.#toe(true);
			for (int i = 0; i < num; i++)
			{
				int num2 = base.#toe(true);
				if (num2 < 4)
				{
					base.#ame(Strings.StringTheMinimumNumberOfSectionsVerticesNnotAchieved.#D2d(new object[]
					{
						4
					}).#z2d());
				}
				if (num2 > 10000)
				{
					base.#ame(Strings.StringTheMaximumNumberOfExteriorPointsDefiningTheColum.#D2d(new object[]
					{
						10000
					}).#z2d());
				}
				SectionPolygon sectionPolygon = new SectionPolygon
				{
					Application = #Wme,
					FigureType = PolygonFigureType.Irregural,
					Points = new List<Point>()
				};
				for (int j = 0; j < num2; j++)
				{
					List<float> list2 = base.#voe(2, true);
					sectionPolygon.Points.Add(new Point(list2[0], list2[1]));
				}
				ImportHelper.#9W(sectionPolygon);
				list.Add(sectionPolygon);
			}
			return list;
		}

		// Token: 0x060092C8 RID: 37576 RVA: 0x00075CAC File Offset: 0x00073EAC
		private List<SectionPolygon> #Yme(PolygonApplication #Wme, string #Zme)
		{
			if (base.#qoe(#Zme))
			{
				return this.#Vme(#Wme, #Zme);
			}
			return null;
		}

		// Token: 0x060092C9 RID: 37577 RVA: 0x001F2910 File Offset: 0x001F0B10
		private List<ReinforcementBar> #0me(string #Zme)
		{
			if (!base.#qoe(#Zme))
			{
				return null;
			}
			base.#roe(#Phc.#3hc(107290018), true);
			int num = base.#toe(true);
			if (num > 10000)
			{
				throw new #ooe(Strings.StringTheMaximumNumberOfReinforcingBarsIsExceeded.#D2d(new object[]
				{
					10000
				}).#z2d());
			}
			List<ReinforcementBar> list = new List<ReinforcementBar>();
			for (int i = 0; i < num; i++)
			{
				List<float> list2 = base.#voe(3, true);
				ReinforcementBar item = new ReinforcementBar(list2[0], list2[1], list2[2], 0f);
				list.Add(item);
			}
			return list;
		}
	}
}
