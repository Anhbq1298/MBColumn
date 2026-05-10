using System;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;

namespace #gMe
{
	// Token: 0x020012D6 RID: 4822
	internal static class #CTe
	{
		// Token: 0x0600A146 RID: 41286 RVA: 0x002268D4 File Offset: 0x00224AD4
		public static #xTe #yTe(#X3 #U6, SlendernessOfBeams #9r, float #zTe, float #ATe, float #BTe, InputModel #hMe)
		{
			if (#zTe == 0f || #U6.Height == 0f)
			{
				#U6.Kbraced = 0f;
				#U6.Ksway = 0f;
				return new #xTe();
			}
			float #KTe = #OTe.#NTe(#U6, #9r, #hMe.Options.Unit);
			float num = #OTe.#LTe(#9r, #zTe, #ATe, #hMe.ColumnAbove, #hMe.CrackedIBeams, #hMe.CrackedIColumn, #KTe);
			float num2 = #OTe.#GTe(#9r, #zTe, #BTe, #hMe.ColumnBelow, #hMe.CrackedIBeams, #hMe.CrackedIColumn, #KTe);
			#OTe.#DTe(#U6, num, num2);
			return new #xTe
			{
				Bottom = num2,
				Top = num
			};
		}
	}
}
