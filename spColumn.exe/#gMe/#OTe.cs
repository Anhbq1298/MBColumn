using System;
using #wUe;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;

namespace #gMe
{
	// Token: 0x020012D7 RID: 4823
	internal static class #OTe
	{
		// Token: 0x0600A147 RID: 41287 RVA: 0x00226980 File Offset: 0x00224B80
		public static void #DTe(#X3 #U6, float #ETe, float #FTe)
		{
			#COe #COe = new #COe();
			#U6.Kbraced = #COe.#bpb((double)#ETe, (double)#FTe, #K6e.#a);
			if (#U6.Kbraced < 0f)
			{
				#U6.Kbraced = 1f;
			}
			#U6.Ksway = #COe.#bpb((double)#ETe, (double)#FTe, #K6e.#b);
			if (#U6.Ksway < 0f)
			{
				#U6.Ksway = 30f;
			}
		}

		// Token: 0x0600A148 RID: 41288 RVA: 0x002269E8 File Offset: 0x00224BE8
		public static float #GTe(SlendernessOfBeams #9r, float #zTe, float #BTe, SlendernessOfColumn #HTe, float #ITe, float #JTe, float #KTe)
		{
			float num = 0f;
			float num2 = 0f;
			if (#xke.#dke(#9r.BelowLeft.Length) && !#9r.BelowLeft.NoBeam)
			{
				num = #9r.BelowLeft.MofI * #9r.BelowLeft.Ec / #9r.BelowLeft.Length;
			}
			if (#xke.#dke(#9r.BelowRight.Length) && !#9r.BelowRight.NoBeam)
			{
				num += #9r.BelowRight.MofI * #9r.BelowRight.Ec / #9r.BelowRight.Length;
			}
			if (#xke.#dke(#KTe))
			{
				num2 = #zTe / #KTe;
			}
			if (#xke.#dke(#HTe.Height) && !#HTe.IsNoColumnPresent)
			{
				num2 += #BTe / #HTe.Height;
			}
			if (#xke.#dke(num * #ITe))
			{
				return num2 * #JTe / (num * #ITe);
			}
			return 999f;
		}

		// Token: 0x0600A149 RID: 41289 RVA: 0x00226AD4 File Offset: 0x00224CD4
		public static float #LTe(SlendernessOfBeams #9r, float #zTe, float #ATe, SlendernessOfColumn #MTe, float #ITe, float #JTe, float #KTe)
		{
			float num = 0f;
			float num2 = 0f;
			if (#xke.#dke(#9r.AboveLeft.Length) && !#9r.AboveLeft.NoBeam)
			{
				num = #9r.AboveLeft.MofI * #9r.AboveLeft.Ec / #9r.AboveLeft.Length;
			}
			if (#xke.#dke(#9r.AboveRight.Length) && !#9r.AboveRight.NoBeam)
			{
				num += #9r.AboveRight.MofI * #9r.AboveRight.Ec / #9r.AboveRight.Length;
			}
			if (#xke.#dke(#KTe))
			{
				num2 = #zTe / #KTe;
			}
			if (#xke.#dke(#MTe.Height) && !#MTe.IsNoColumnPresent)
			{
				num2 += #ATe / #MTe.Height;
			}
			if (#xke.#dke(num * #ITe))
			{
				return num2 * #JTe / (num * #ITe);
			}
			return 999f;
		}

		// Token: 0x0600A14A RID: 41290 RVA: 0x00226BC0 File Offset: 0x00224DC0
		public static float #NTe(#X3 #U6, SlendernessOfBeams #9r, #D6e #6jb)
		{
			float num = 0f;
			if (#xke.#dke(#9r.AboveLeft.Length) && !#9r.AboveLeft.NoBeam)
			{
				num = #xke.#ske(num, #9r.AboveLeft.Depth);
			}
			if (#xke.#dke(#9r.AboveRight.Length) && !#9r.AboveRight.NoBeam)
			{
				num = #xke.#ske(num, #9r.AboveRight.Depth);
			}
			float num2 = 0f;
			if (#xke.#dke(#9r.BelowLeft.Length) && !#9r.BelowLeft.NoBeam)
			{
				num2 = #xke.#ske(num2, #9r.BelowLeft.Depth);
			}
			if (#xke.#dke(#9r.BelowRight.Length) && !#9r.BelowRight.NoBeam)
			{
				num2 = #xke.#ske(num2, #9r.BelowRight.Depth);
			}
			num = 0.5f * (num + num2);
			if (#6jb == #D6e.#a)
			{
				num /= 12f;
			}
			else
			{
				num /= 1000f;
			}
			return #U6.Height + num;
		}
	}
}
