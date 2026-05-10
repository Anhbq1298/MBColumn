using System;
using #hZe;
using #wUe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Geometry;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer
{
	// Token: 0x020012AA RID: 4778
	internal sealed class DepthComputation
	{
		// Token: 0x06009FFA RID: 40954 RVA: 0x0007DA32 File Offset: 0x0007BC32
		public DepthComputation(InputModel inputModel, RuntimeModel runtimeModel)
		{
			this.#a = inputModel;
			this.#b = runtimeModel;
		}

		// Token: 0x17002E05 RID: 11781
		// (set) Token: 0x06009FFB RID: 40955 RVA: 0x0007DA48 File Offset: 0x0007BC48
		private float CoordinateZ
		{
			set
			{
				this.#b.Coordinates.CoordinateZ = value;
			}
		}

		// Token: 0x17002E06 RID: 11782
		// (get) Token: 0x06009FFC RID: 40956 RVA: 0x0007DA5B File Offset: 0x0007BC5B
		private float[] SectionDimensions
		{
			get
			{
				return this.#b.SectionDimensionsForInvestigate;
			}
		}

		// Token: 0x17002E07 RID: 11783
		// (get) Token: 0x06009FFD RID: 40957 RVA: 0x0007DA68 File Offset: 0x0007BC68
		private #3Ze Depth
		{
			get
			{
				return this.#b.Depth;
			}
		}

		// Token: 0x17002E08 RID: 11784
		// (get) Token: 0x06009FFE RID: 40958 RVA: 0x0007DA75 File Offset: 0x0007BC75
		private Figures Solids
		{
			get
			{
				return this.#b.Solids;
			}
		}

		// Token: 0x17002E09 RID: 11785
		// (get) Token: 0x06009FFF RID: 40959 RVA: 0x0007DA82 File Offset: 0x0007BC82
		private #K1e ReinforcementBars
		{
			get
			{
				return this.#b.ReinforcementBars;
			}
		}

		// Token: 0x17002E0A RID: 11786
		// (get) Token: 0x0600A000 RID: 40960 RVA: 0x0007DA8F File Offset: 0x0007BC8F
		private #G6e SectionType
		{
			get
			{
				return this.#a.Options.SectionType;
			}
		}

		// Token: 0x0600A001 RID: 40961 RVA: 0x0007DAA1 File Offset: 0x0007BCA1
		public void #fOe()
		{
			this.#gOe(#C6e.#a);
			this.#gOe(#C6e.#b);
			this.#gOe(#C6e.#d);
		}

		// Token: 0x0600A002 RID: 40962 RVA: 0x0007DAB8 File Offset: 0x0007BCB8
		public void #gOe(#C6e #6gb)
		{
			switch (#6gb)
			{
			case #C6e.#a:
				this.#hOe();
				return;
			case #C6e.#b:
				this.#iOe();
				return;
			case #C6e.#c:
				break;
			case #C6e.#d:
				this.#jOe();
				break;
			default:
				return;
			}
		}

		// Token: 0x0600A003 RID: 40963 RVA: 0x00220024 File Offset: 0x0021E224
		private void #hOe()
		{
			float num = #xke.#kke<ReinforcementBar>(this.ReinforcementBars.Bars, this.ReinforcementBars.NumberOfBars, new Func<ReinforcementBar, float>(DepthComputation.<>c.<>9.#6gf));
			if (this.SectionType != #G6e.#c)
			{
				if (this.SectionType == #G6e.#a)
				{
					this.Depth.OfConcrete[0] = this.SectionDimensions[1];
				}
				else
				{
					this.Depth.OfConcrete[0] = this.SectionDimensions[0];
				}
				this.Depth.OfReinforcement[0] = this.Depth.OfConcrete[0] / 2f - num;
				return;
			}
			this.Depth.OfConcrete[0] = #xke.#jke(this.Solids.SectionFigures, new Func<Points, int, float>(DepthComputation.<>c.<>9.#7gf));
			float num2 = #xke.#lke(this.Solids.SectionFigures, new Func<Points, int, float>(DepthComputation.<>c.<>9.#8gf));
			this.Depth.OfReinforcement[0] = num2 - num;
		}

		// Token: 0x0600A004 RID: 40964 RVA: 0x00220148 File Offset: 0x0021E348
		private void #iOe()
		{
			float num = #xke.#kke<ReinforcementBar>(this.ReinforcementBars.Bars, this.ReinforcementBars.NumberOfBars, new Func<ReinforcementBar, float>(DepthComputation.<>c.<>9.#ahf));
			if (this.SectionType != #G6e.#c)
			{
				this.Depth.OfConcrete[1] = this.SectionDimensions[0];
				this.Depth.OfReinforcement[1] = this.Depth.OfConcrete[1] / 2f - num;
				return;
			}
			this.Depth.OfConcrete[1] = #xke.#jke(this.Solids.SectionFigures, new Func<Points, int, float>(DepthComputation.<>c.<>9.#bhf));
			float num2 = #xke.#lke(this.Solids.SectionFigures, new Func<Points, int, float>(DepthComputation.<>c.<>9.#chf));
			this.Depth.OfReinforcement[1] = num2 - num;
		}

		// Token: 0x0600A005 RID: 40965 RVA: 0x00220250 File Offset: 0x0021E450
		private void #jOe()
		{
			float num = #xke.#kke<ReinforcementBar>(this.ReinforcementBars.Bars, this.ReinforcementBars.NumberOfBars, new Func<ReinforcementBar, float>(DepthComputation.<>c.<>9.#ehf));
			if (this.SectionType == #G6e.#c)
			{
				this.CoordinateZ = #xke.#kke(this.Solids.SectionFigures, new Func<Points, int, float>(DepthComputation.<>c.<>9.#khf));
				this.Depth.OfConcrete[2] = #xke.#jke(this.Solids.SectionFigures, new Func<Points, int, float>(DepthComputation.<>c.<>9.#ghf));
				float num2 = #xke.#lke(this.Solids.SectionFigures, new Func<Points, int, float>(DepthComputation.<>c.<>9.#hhf));
				this.Depth.OfReinforcement[2] = num2 - num;
				return;
			}
			if (this.SectionType == #G6e.#a)
			{
				this.CoordinateZ = #xke.#kke(this.Solids.SectionFigures, new Func<Points, int, float>(DepthComputation.<>c.<>9.#fhf));
				this.Depth.OfConcrete[2] = #xke.#jke(this.Solids.SectionFigures, new Func<Points, int, float>(DepthComputation.<>c.<>9.#jhf));
			}
			else
			{
				this.CoordinateZ = -this.SectionDimensions[0] / 2f;
				this.Depth.OfConcrete[2] = this.SectionDimensions[0];
			}
			this.Depth.OfReinforcement[2] = this.Depth.OfConcrete[2] / 2f - num;
		}

		// Token: 0x040045EC RID: 17900
		private readonly InputModel #a;

		// Token: 0x040045ED RID: 17901
		private readonly RuntimeModel #b;
	}
}
