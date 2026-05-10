using System;
using #hZe;
using #wUe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Geometry;

namespace #gMe
{
	// Token: 0x02001295 RID: 4757
	internal sealed class #fMe
	{
		// Token: 0x06009F5A RID: 40794 RVA: 0x0007D34A File Offset: 0x0007B54A
		public #fMe(InputModel #hMe, RuntimeModel #iMe, #38e #jMe)
		{
			this.#c = #hMe;
			this.#f = #iMe;
			this.#b = new #uNe(#hMe, #iMe);
			this.#e = new #XSe(#hMe, #iMe, #jMe);
			this.#d = new #RQe(#hMe, #iMe, #jMe);
		}

		// Token: 0x17002DD7 RID: 11735
		// (get) Token: 0x06009F5B RID: 40795 RVA: 0x0007D389 File Offset: 0x0007B589
		private Figures Solids
		{
			get
			{
				return this.#f.Solids;
			}
		}

		// Token: 0x17002DD8 RID: 11736
		// (get) Token: 0x06009F5C RID: 40796 RVA: 0x0007D396 File Offset: 0x0007B596
		private Figures Openings
		{
			get
			{
				return this.#f.Openings;
			}
		}

		// Token: 0x17002DD9 RID: 11737
		// (get) Token: 0x06009F5D RID: 40797 RVA: 0x0007D3A3 File Offset: 0x0007B5A3
		private #G6e SectionType
		{
			get
			{
				return this.#c.Options.SectionType;
			}
		}

		// Token: 0x06009F5E RID: 40798 RVA: 0x0021D284 File Offset: 0x0021B484
		public #D2e #6Le(float #7Le)
		{
			#TZe #s1e = this.#cMe(#7Le);
			#E2e #E2e = this.#e.#PSe(#7Le, ref #s1e);
			float num = #E2e.MaxSteelStrain;
			#s1e.#SWi(ref #E2e);
			this.#d.#NQe(num, ref #s1e);
			num = Math.Min(9.99999f, num);
			num = Math.Max(-9.99999f, num);
			return new #D2e(num, #s1e);
		}

		// Token: 0x06009F5F RID: 40799 RVA: 0x0021D2E8 File Offset: 0x0021B4E8
		public #D2e #8Le(float #7Le, float #Udb)
		{
			#TZe #s1e = this.#9Le(#7Le, #Udb);
			#IZe #IZe = this.#e.#RSe(#7Le, ref #s1e);
			float num = #IZe.MaxSteelStrain;
			#s1e.#SWi(ref #IZe);
			this.#d.#NQe(num, ref #s1e);
			num = #xke.#rke(9.99999f, num);
			num = #xke.#ske(-9.99999f, num);
			return new #D2e(num, #s1e);
		}

		// Token: 0x06009F60 RID: 40800 RVA: 0x0007D3B5 File Offset: 0x0007B5B5
		private #TZe #9Le(float #7Le, float #Udb)
		{
			if (this.SectionType == #G6e.#b)
			{
				return this.#bMe(#7Le, #Udb);
			}
			return this.#aMe(#7Le, #Udb);
		}

		// Token: 0x06009F61 RID: 40801 RVA: 0x0021D34C File Offset: 0x0021B54C
		private #TZe #aMe(float #7Le, float #Udb)
		{
			#TZe result = default(#TZe);
			for (int i = 0; i < this.Solids.SectionFigures.Count; i++)
			{
				Points points = this.Solids.SectionFigures[i];
				#IZe #IZe = this.#b.#rNe(#7Le, points.TransformedPoints, points.NumberOfPoints, #Udb);
				result.#vzc(ref #IZe);
			}
			for (int j = 0; j < this.Openings.SectionFigures.Count; j++)
			{
				Points points2 = this.Openings.SectionFigures[j];
				#IZe #IZe2 = this.#b.#rNe(#7Le, points2.TransformedPoints, points2.NumberOfPoints, #Udb);
				result.#M3d(ref #IZe2);
			}
			return result;
		}

		// Token: 0x06009F62 RID: 40802 RVA: 0x0007D3D1 File Offset: 0x0007B5D1
		private #TZe #bMe(float #7Le, float #Udb)
		{
			return #TZe.#Dge(this.#b.#tNe(#7Le), #Udb);
		}

		// Token: 0x06009F63 RID: 40803 RVA: 0x0007D3E5 File Offset: 0x0007B5E5
		private #TZe #cMe(float #7Le)
		{
			if (this.SectionType == #G6e.#b)
			{
				return this.#dMe(#7Le);
			}
			return this.#eMe(#7Le);
		}

		// Token: 0x06009F64 RID: 40804 RVA: 0x0007D3FF File Offset: 0x0007B5FF
		private #TZe #dMe(float #7Le)
		{
			return #TZe.#Dge(this.#b.#tNe(#7Le));
		}

		// Token: 0x06009F65 RID: 40805 RVA: 0x0021D40C File Offset: 0x0021B60C
		private #TZe #eMe(float #7Le)
		{
			#TZe result = default(#TZe);
			for (int i = 0; i < this.Solids.SectionFigures.Count; i++)
			{
				Points points = this.Solids.SectionFigures[i];
				#E2e #E2e = this.#b.#sNe(#7Le, points.TransformedPoints, points.NumberOfPoints);
				result.#vzc(ref #E2e);
			}
			for (int j = 0; j < this.Openings.SectionFigures.Count; j++)
			{
				Points points2 = this.Openings.SectionFigures[j];
				#E2e #E2e2 = this.#b.#sNe(#7Le, points2.TransformedPoints, points2.NumberOfPoints);
				result.#M3d(ref #E2e2);
			}
			return result;
		}

		// Token: 0x0400458A RID: 17802
		private const float #a = 9.99999f;

		// Token: 0x0400458B RID: 17803
		private readonly #uNe #b;

		// Token: 0x0400458C RID: 17804
		private readonly InputModel #c;

		// Token: 0x0400458D RID: 17805
		private readonly #RQe #d;

		// Token: 0x0400458E RID: 17806
		private readonly #XSe #e;

		// Token: 0x0400458F RID: 17807
		private readonly RuntimeModel #f;
	}
}
