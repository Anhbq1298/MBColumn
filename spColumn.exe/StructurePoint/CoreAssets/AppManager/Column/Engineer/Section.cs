using System;
using System.Linq;
using #12e;
using #5Ve;
using #g7e;
using #gMe;
using #hZe;
using #IWe;
using #wUe;
using #X7e;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer
{
	// Token: 0x020012D2 RID: 4818
	internal sealed class Section
	{
		// Token: 0x0600A137 RID: 41271 RVA: 0x0022618C File Offset: 0x0022438C
		public Section(#l4e outputModel, InputModel inputModel, RuntimeModel runtimeModel, #6Re moments, DepthComputation depthComputation, #ISe placement, #jQe loadsAndSlenderness, #3Qe momentCapacityEx, CriticalCapacity criticalCapacity, #fNe compressionAndTension, #nUe transformations, #VPe loadMomentPairs, #fMe axialLoadAndMoment, #dTe reinforcementProperties, #38e codeExpert)
		{
			this.#l = outputModel;
			this.#f = inputModel;
			this.#n = runtimeModel;
			this.#k = moments;
			this.#e = depthComputation;
			this.#m = placement;
			this.#h = loadsAndSlenderness;
			this.#i = momentCapacityEx;
			this.#j = criticalCapacity;
			this.#d = compressionAndTension;
			this.#o = transformations;
			this.#g = loadMomentPairs;
			this.#a = axialLoadAndMoment;
			this.#b = reinforcementProperties;
			this.#c = codeExpert;
		}

		// Token: 0x0600A138 RID: 41272 RVA: 0x00226214 File Offset: 0x00224414
		public #OZe #jTe(int #Ece, int #kTe, float #lTe, float #Udb)
		{
			#4Ve #4Ve = new #4Ve
			{
				BarIndex = #Ece,
				TotalBarCount = #kTe,
				DimensionA = this.#n.SectionDimensionsForInvestigate[0],
				DimensionB = this.#n.SectionDimensionsForInvestigate[1],
				Reinforcement = #c6e.#Dge(this.#n.InvestigateReinforcement)
			};
			#OZe result;
			try
			{
				this.#m.#tOe();
				this.#e.#fOe();
				#4Ve.GeometryProperties = new #x0e(this.#n.GeometryProperties);
				#4Ve.Bars.AddRange(this.#n.ReinforcementBars.Bars.Take(this.#n.ReinforcementBars.NumberOfBars).Select(new Func<ReinforcementBar, ReinforcementBar>(Section.<>c.<>9.#thf)));
				#L6e #L6e = this.#h.#1Pe();
				#L6e = this.#c.#B7e(#L6e);
				if (#xke.#U3((int)#L6e))
				{
					#L6e = this.#oTe(#Ece, #kTe);
					#L6e |= #ZLe.#tTe(this.#c, this.#n.GeometryProperties.Space, this.#f.MinRebarClearSpacing, this.#f.Bars[#Ece].Diameter);
					if (#xke.#U3((int)#L6e))
					{
						#vZe #uZe = this.#d.#bpb();
						this.#n.AxialLoads.#tZe(#uZe);
						#OZe #OZe = this.#pTe(#Udb);
						#L6e = #OZe.Result;
						#lTe = #OZe.Usf;
						#4Ve.CapacityRatio = new float?(#lTe);
						if (#xke.#U3((int)#L6e))
						{
							#4Ve.IsFinalDesign = true;
							return new #OZe(#lTe, #L6e.#a);
						}
					}
				}
				#4Ve.Messages.AddRange(#TQe.#un(#L6e));
				result = new #OZe(#lTe, #L6e);
			}
			finally
			{
				if (this.#n.RunFlag.HasFlag(#J6e.#a))
				{
					this.#n.MessageBus.#e7e(#4Ve);
				}
			}
			return result;
		}

		// Token: 0x0600A139 RID: 41273 RVA: 0x00226420 File Offset: 0x00224620
		public void #mTe(bool #nTe, float #Udb)
		{
			if (this.#f.Options.ProblemType == #z6e.#a || !this.#n.RunFlag.HasFlag(#J6e.#a))
			{
				this.#n.MessageBus.#76e(#q7e.#Mif.#a);
			}
			new #AXe(this.#l, this.#f, this.#n, this.#c).#sWe();
			#JXe #JXe = new #JXe(this.#l, #Udb, this.#f, this.#n, this.#k, this.#i, this.#j, this.#d, this.#o, this.#g, this.#a, this.#c);
			this.#b.#0Se();
			#JXe.#GXe(this.#n.ReinforcementBars);
			#JXe.#FXe(this.#n.Solids, this.#n.Openings);
			this.#n.ReinforcementBars.#H1e(#I6e.#a);
			if (#nTe)
			{
				#JXe.ControlResults.#sWe();
				switch (this.#f.Options.Loads[(int)this.#f.Options.ProblemType])
				{
				case Load.Factored:
					#JXe.FactoredResults.#sWe();
					return;
				case Load.Service:
					#JXe.ServiceResults.#sWe();
					break;
				case Load.Controld:
					break;
				case Load.Axial:
					#JXe.AxialResults.#sWe();
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x0600A13A RID: 41274 RVA: 0x0022658C File Offset: 0x0022478C
		private #L6e #oTe(int #Ece, int #kTe)
		{
			if (#kTe > 10000)
			{
				return #L6e.#c;
			}
			this.#n.GeometryProperties.AreaOfSteel = this.#f.Bars[#Ece].Area * (float)#kTe;
			this.#n.GeometryProperties.#q0e();
			float num = this.#f.ReinforcementRatios.MinReinforcementRatio * this.#n.GeometryProperties.Ag;
			float num2 = this.#f.ReinforcementRatios.MaxReinforcementRatio * this.#n.GeometryProperties.Ag;
			if (this.#n.GeometryProperties.AreaOfSteel < num)
			{
				return #L6e.#b;
			}
			if (this.#n.GeometryProperties.AreaOfSteel > num2)
			{
				return #L6e.#c;
			}
			return #L6e.#a;
		}

		// Token: 0x0600A13B RID: 41275 RVA: 0x00226648 File Offset: 0x00224848
		private #OZe #pTe(float #Udb)
		{
			float num = #iTe.MinCapacityRatio;
			if (this.#f.Options.ConsideredAxis != #C6e.#c)
			{
				this.#o.#Zub(#Udb);
				this.#g.#bpb(#Udb);
			}
			#VMe #VMe = new #VMe(this.#i, this.#j);
			#y0e #y0e = null;
			#x6e #TMe = this.#f.Options.CapacityCalculationType;
			LoadsExt[] array = this.#n.FactoredLoads.Loads;
			for (int i = 0; i < this.#n.FactoredLoads.NumberOfLoads; i++)
			{
				if (this.#f.Options.ProblemType == #z6e.#a || !this.#n.RunFlag.HasFlag(#J6e.#a))
				{
					this.#n.MessageBus.#76e(#q7e.#Mif.#c, i + 1, this.#n.FactoredLoads.NumberOfLoads);
				}
				float num2 = this.#n.ReductionFactors.#E1e(this.#f, this.#n, this.#c);
				if (array[i].AxialLoad > num2 * this.#n.AxialLoads.Maximum)
				{
					return new #OZe(num, #L6e.#g);
				}
				if (array[i].AxialLoad < this.#n.AxialLoads.Minimum)
				{
					return new #OZe(num, #L6e.#g);
				}
				#y0e = (#y0e ?? #VMe.#YJe(#TMe));
				#S0e #S0e = #VMe.#bpb(#y0e, #TMe, array[i], 0f, 0f, 0f);
				if (#S0e.UltimateSafeFactor > 0f && num < #S0e.UltimateSafeFactor)
				{
					num = #S0e.UltimateSafeFactor;
				}
				#z6e #kce = this.#f.Options.ProblemType;
				if (#ZLe.#qTe(#S0e.Success, #S0e.UltimateSafeFactor, #kce, this.#f.DesignToRequiredRatio))
				{
					return new #OZe(num, #L6e.#g);
				}
			}
			this.#n.FactoredInteractionDiagram = #y0e;
			return new #OZe(num, #L6e.#a);
		}

		// Token: 0x0400467E RID: 18046
		private readonly #fMe #a;

		// Token: 0x0400467F RID: 18047
		private readonly #dTe #b;

		// Token: 0x04004680 RID: 18048
		private readonly #38e #c;

		// Token: 0x04004681 RID: 18049
		private readonly #fNe #d;

		// Token: 0x04004682 RID: 18050
		private readonly DepthComputation #e;

		// Token: 0x04004683 RID: 18051
		private readonly InputModel #f;

		// Token: 0x04004684 RID: 18052
		private readonly #VPe #g;

		// Token: 0x04004685 RID: 18053
		private readonly #jQe #h;

		// Token: 0x04004686 RID: 18054
		private readonly #3Qe #i;

		// Token: 0x04004687 RID: 18055
		private readonly CriticalCapacity #j;

		// Token: 0x04004688 RID: 18056
		private readonly #6Re #k;

		// Token: 0x04004689 RID: 18057
		private readonly #l4e #l;

		// Token: 0x0400468A RID: 18058
		private readonly #ISe #m;

		// Token: 0x0400468B RID: 18059
		private readonly RuntimeModel #n;

		// Token: 0x0400468C RID: 18060
		private readonly #nUe #o;
	}
}
