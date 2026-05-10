using System;
using System.Runtime.CompilerServices;
using #7hc;
using #w1i;
using #x1i;

namespace StructurePoint.Kernel.CoreAssets.Importer.DataClasses
{
	// Token: 0x02000E4C RID: 3660
	public sealed class ETABSFactoredLoad
	{
		// Token: 0x17002769 RID: 10089
		// (get) Token: 0x06008323 RID: 33571 RVA: 0x0006B0AB File Offset: 0x000692AB
		// (set) Token: 0x06008324 RID: 33572 RVA: 0x0006B0B3 File Offset: 0x000692B3
		public string ObjectName { get; private set; }

		// Token: 0x1700276A RID: 10090
		// (get) Token: 0x06008325 RID: 33573 RVA: 0x0006B0BC File Offset: 0x000692BC
		// (set) Token: 0x06008326 RID: 33574 RVA: 0x0006B0C4 File Offset: 0x000692C4
		public string ObjectData { get; private set; }

		// Token: 0x1700276B RID: 10091
		// (get) Token: 0x06008327 RID: 33575 RVA: 0x0006B0CD File Offset: 0x000692CD
		// (set) Token: 0x06008328 RID: 33576 RVA: 0x0006B0D5 File Offset: 0x000692D5
		public string LoadCombination { get; private set; }

		// Token: 0x1700276C RID: 10092
		// (get) Token: 0x06008329 RID: 33577 RVA: 0x0006B0DE File Offset: 0x000692DE
		// (set) Token: 0x0600832A RID: 33578 RVA: 0x0006B0E6 File Offset: 0x000692E6
		public double Station { get; private set; }

		// Token: 0x1700276D RID: 10093
		// (get) Token: 0x0600832B RID: 33579 RVA: 0x0006B0EF File Offset: 0x000692EF
		// (set) Token: 0x0600832C RID: 33580 RVA: 0x0006B0F7 File Offset: 0x000692F7
		public string Location { get; private set; }

		// Token: 0x1700276E RID: 10094
		// (get) Token: 0x0600832D RID: 33581 RVA: 0x0006B100 File Offset: 0x00069300
		// (set) Token: 0x0600832E RID: 33582 RVA: 0x0006B108 File Offset: 0x00069308
		public string StepType { get; private set; }

		// Token: 0x1700276F RID: 10095
		// (get) Token: 0x0600832F RID: 33583 RVA: 0x001C4AEC File Offset: 0x001C2CEC
		public #o5h StepTypeValue
		{
			get
			{
				switch (this.EnvelopeType)
				{
				case EnvelopeType.NotAnEnvelope:
				{
					string text = this.StepType.ToLower();
					if (text == #Phc.#3hc(107270917))
					{
						return #o5h.#d;
					}
					if (text == #Phc.#3hc(107270912))
					{
						return #o5h.#c;
					}
					if ((text != null && text.Length == 0) || text == #Phc.#3hc(107270939))
					{
						return #o5h.#a;
					}
					if (!(text == #Phc.#3hc(107270378)) && !(text == #Phc.#3hc(107270369)))
					{
						throw new #C6h(string.Format(#Ab.SpImporterExceptionUnknownStepType, this.StepType), #z6h.#m);
					}
					return #o5h.#b;
				}
				case EnvelopeType.MinMinMin:
					return #o5h.#c;
				case EnvelopeType.MinMinMax:
				case EnvelopeType.MinMaxMin:
				case EnvelopeType.MinMaxMax:
				case EnvelopeType.MaxMinMin:
				case EnvelopeType.MaxMinMax:
				case EnvelopeType.MaxMaxMin:
					return #o5h.#e;
				case EnvelopeType.MaxMaxMax:
					return #o5h.#d;
				default:
					throw new #C6h(string.Format(#Ab.SpImporterExceptionUnknownStepType, this.EnvelopeType.ToString()), #z6h.#m);
				}
			}
		}

		// Token: 0x17002770 RID: 10096
		// (get) Token: 0x06008330 RID: 33584 RVA: 0x0006B111 File Offset: 0x00069311
		// (set) Token: 0x06008331 RID: 33585 RVA: 0x0006B119 File Offset: 0x00069319
		public double StepValue { get; private set; }

		// Token: 0x17002771 RID: 10097
		// (get) Token: 0x06008332 RID: 33586 RVA: 0x0006B122 File Offset: 0x00069322
		// (set) Token: 0x06008333 RID: 33587 RVA: 0x0006B12A File Offset: 0x0006932A
		public EnvelopeType EnvelopeType { get; private set; }

		// Token: 0x17002772 RID: 10098
		// (get) Token: 0x06008334 RID: 33588 RVA: 0x0006B133 File Offset: 0x00069333
		// (set) Token: 0x06008335 RID: 33589 RVA: 0x0006B13B File Offset: 0x0006933B
		public string ElementName { get; private set; }

		// Token: 0x17002773 RID: 10099
		// (get) Token: 0x06008336 RID: 33590 RVA: 0x0006B144 File Offset: 0x00069344
		// (set) Token: 0x06008337 RID: 33591 RVA: 0x0006B14C File Offset: 0x0006934C
		public double P { get; private set; }

		// Token: 0x17002774 RID: 10100
		// (get) Token: 0x06008338 RID: 33592 RVA: 0x0006B155 File Offset: 0x00069355
		// (set) Token: 0x06008339 RID: 33593 RVA: 0x0006B15D File Offset: 0x0006935D
		public double Mx { get; private set; }

		// Token: 0x17002775 RID: 10101
		// (get) Token: 0x0600833A RID: 33594 RVA: 0x0006B166 File Offset: 0x00069366
		// (set) Token: 0x0600833B RID: 33595 RVA: 0x0006B16E File Offset: 0x0006936E
		public double My { get; private set; }

		// Token: 0x0600833C RID: 33596 RVA: 0x001C4BF0 File Offset: 0x001C2DF0
		public ETABSFactoredLoad(string objectName, string objectData, string loadCombination, double station, string location, string stepType, double stepValue, EnvelopeType envelopeType, string elementName, double p, double mx, double my)
		{
			this.ObjectName = objectName;
			this.ObjectData = objectData;
			this.LoadCombination = loadCombination;
			this.Station = station;
			this.Location = location;
			this.StepType = stepType;
			this.StepValue = stepValue;
			this.EnvelopeType = envelopeType;
			this.ElementName = elementName;
			this.P = p;
			this.Mx = mx;
			this.My = my;
		}

		// Token: 0x0600833D RID: 33597 RVA: 0x0006B177 File Offset: 0x00069377
		public static void #C5h(double #D5h, double #E5h, double #F5h, out double #G5h, out double #H5h, out double #I5h)
		{
			#G5h = -#D5h;
			#H5h = -#F5h;
			#I5h = -#E5h;
		}

		// Token: 0x0600833E RID: 33598 RVA: 0x0006B177 File Offset: 0x00069377
		public static void #J5h(double #D5h, double #E5h, double #F5h, out double #G5h, out double #H5h, out double #I5h)
		{
			#G5h = -#D5h;
			#H5h = -#F5h;
			#I5h = -#E5h;
		}

		// Token: 0x040035CF RID: 13775
		[CompilerGenerated]
		private string #a;

		// Token: 0x040035D0 RID: 13776
		[CompilerGenerated]
		private string #b;

		// Token: 0x040035D1 RID: 13777
		[CompilerGenerated]
		private string #c;

		// Token: 0x040035D2 RID: 13778
		[CompilerGenerated]
		private double #d;

		// Token: 0x040035D3 RID: 13779
		[CompilerGenerated]
		private string #e;

		// Token: 0x040035D4 RID: 13780
		[CompilerGenerated]
		private string #f;

		// Token: 0x040035D5 RID: 13781
		[CompilerGenerated]
		private double #g;

		// Token: 0x040035D6 RID: 13782
		[CompilerGenerated]
		private EnvelopeType #h;

		// Token: 0x040035D7 RID: 13783
		[CompilerGenerated]
		private string #i;

		// Token: 0x040035D8 RID: 13784
		[CompilerGenerated]
		private double #j;

		// Token: 0x040035D9 RID: 13785
		[CompilerGenerated]
		private double #k;

		// Token: 0x040035DA RID: 13786
		[CompilerGenerated]
		private double #l;
	}
}
