using System;
using System.Collections.Generic;
using System.Linq;
using #12e;
using #7hc;
using #9Ue;
using #FCd;
using #gMe;
using #hye;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using #y6e;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables
{
	// Token: 0x020011A2 RID: 4514
	internal sealed class FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosTable : #qwe
	{
		// Token: 0x06009918 RID: 39192 RVA: 0x00079C60 File Offset: 0x00077E60
		public FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosTable(#lte model) : base(model)
		{
			this.#c = new LoadCombinationIndexCache(model);
		}

		// Token: 0x06009919 RID: 39193 RVA: 0x0020413C File Offset: 0x0020233C
		public override void #npb(#6Dd #opb)
		{
			using (#5Dd #5Dd = #opb.#ul(3, this.#qye()))
			{
				this.#Ppb(#5Dd);
				this.#UVb(#5Dd);
			}
		}

		// Token: 0x0600991A RID: 39194 RVA: 0x00079C75 File Offset: 0x00077E75
		private void #UVb(#5Dd #Ipb)
		{
			if (base.Model.Input.Options.ActiveLoad == LoadType.Factored)
			{
				this.#lye(#Ipb);
				return;
			}
			if (base.Model.Input.Options.ActiveLoad == LoadType.Service)
			{
				this.#kye(#Ipb);
			}
		}

		// Token: 0x0600991B RID: 39195 RVA: 0x00204184 File Offset: 0x00202384
		private void #kye(#5Dd #Ipb)
		{
			if (base.Model.Input.Options.ConsideredAxis == ConsideredAxis.Both)
			{
				using (IEnumerator<BiaxialServiceLoad> enumerator = base.Model.Output.BiaxialServiceLoads.Where(new Func<BiaxialServiceLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosTable.<>c.<>9.#ucf)).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						BiaxialServiceLoad biaxialServiceLoad = enumerator.Current;
						#Ipb.#QDd(biaxialServiceLoad.Index);
						this.#Hpb(#Ipb, biaxialServiceLoad.Index, biaxialServiceLoad.ServiceLoadIndex, biaxialServiceLoad.LoadCombinationIndex);
						#Ipb.#QDd(new string[]
						{
							#ned.#qp(biaxialServiceLoad.AppLoad, NativeNumberFormat.F11_2, #Phc.#3hc(107381628))
						});
						#Ipb.#QDd(new string[]
						{
							#ned.#qp(biaxialServiceLoad.FactLoad2, NativeNumberFormat.F11_2, #Phc.#3hc(107381628))
						});
						#Ipb.#QDd(new string[]
						{
							#ned.#qp(biaxialServiceLoad.FactLoad3, NativeNumberFormat.F11_2, #Phc.#3hc(107381628))
						});
						this.#Mpb(#Ipb, new LoadPointDrawingData(biaxialServiceLoad), new #u3e.#xif?(biaxialServiceLoad.MinMax), biaxialServiceLoad.Nadepth, biaxialServiceLoad.Eps, biaxialServiceLoad.Phi, biaxialServiceLoad.UltimateMomentX, biaxialServiceLoad.UltimateMomentY);
					}
					return;
				}
			}
			foreach (UniaxialServiceLoad uniaxialServiceLoad in base.Model.Output.UniaxialServiceLoads.Where(new Func<UniaxialServiceLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosTable.<>c.<>9.#vcf)))
			{
				#Ipb.#QDd(uniaxialServiceLoad.Index);
				this.#Hpb(#Ipb, uniaxialServiceLoad.Index, uniaxialServiceLoad.ServiceLoadIndex, uniaxialServiceLoad.LoadCombinationIndex);
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(uniaxialServiceLoad.AppLoad, NativeNumberFormat.F11_2, #Phc.#3hc(107381628))
				});
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(uniaxialServiceLoad.AppMoment, NativeNumberFormat.F11_2, #Phc.#3hc(107381628))
				});
				float? #yve = (base.Model.Output.ConsideredAxis == #C6e.#a) ? uniaxialServiceLoad.UltimateMoment : null;
				float? #zve = (base.Model.Output.ConsideredAxis == #C6e.#b) ? uniaxialServiceLoad.UltimateMoment : null;
				this.#Mpb(#Ipb, new LoadPointDrawingData(uniaxialServiceLoad, base.Model.Output.ConsideredAxis), new #u3e.#xif?(uniaxialServiceLoad.MinMax), uniaxialServiceLoad.Nadepth, uniaxialServiceLoad.Eps, uniaxialServiceLoad.Phi, #yve, #zve);
			}
		}

		// Token: 0x0600991C RID: 39196 RVA: 0x00204468 File Offset: 0x00202668
		private void #lye(#5Dd #Ipb)
		{
			if (base.Model.Input.Options.ConsideredAxis == ConsideredAxis.Both)
			{
				using (IEnumerator<BiaxialFactoredLoad> enumerator = base.Model.Output.BiaxialFactoredLoads.Where(new Func<BiaxialFactoredLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosTable.<>c.<>9.#wcf)).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						BiaxialFactoredLoad biaxialFactoredLoad = enumerator.Current;
						#Ipb.#QDd(biaxialFactoredLoad.Index);
						#Ipb.#QDd(new string[]
						{
							#ned.#qp(biaxialFactoredLoad.AppLoad, NativeNumberFormat.F11_2, #Phc.#3hc(107381628))
						});
						#Ipb.#QDd(new string[]
						{
							#ned.#qp(biaxialFactoredLoad.FactLoad1, NativeNumberFormat.F11_2, #Phc.#3hc(107381628))
						});
						#Ipb.#QDd(new string[]
						{
							#ned.#qp(biaxialFactoredLoad.FactLoad2, NativeNumberFormat.F11_2, #Phc.#3hc(107381628))
						});
						this.#Mpb(#Ipb, new LoadPointDrawingData(biaxialFactoredLoad), new #u3e.#xif?(biaxialFactoredLoad.MinMax), biaxialFactoredLoad.Nadepth, biaxialFactoredLoad.Eps, biaxialFactoredLoad.Phi, biaxialFactoredLoad.UltimateMomentX, biaxialFactoredLoad.UltimateMomentY);
					}
					return;
				}
			}
			foreach (UniaxialFactoredLoad uniaxialFactoredLoad in base.Model.Output.UniaxialFactoredLoads.Where(new Func<UniaxialFactoredLoad, bool>(FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosTable.<>c.<>9.#xcf)))
			{
				#Ipb.#QDd(uniaxialFactoredLoad.Index);
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(uniaxialFactoredLoad.AppLoad, NativeNumberFormat.F11_2, #Phc.#3hc(107381628))
				});
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(uniaxialFactoredLoad.AppMoment, NativeNumberFormat.F11_2, #Phc.#3hc(107381628))
				});
				float? #yve = (base.Model.Output.ConsideredAxis == #C6e.#a) ? uniaxialFactoredLoad.UltimateMoment : null;
				float? #zve = (base.Model.Output.ConsideredAxis == #C6e.#b) ? uniaxialFactoredLoad.UltimateMoment : null;
				this.#Mpb(#Ipb, new LoadPointDrawingData(uniaxialFactoredLoad, base.Model.Output.ConsideredAxis), new #u3e.#xif?(uniaxialFactoredLoad.MinMax), uniaxialFactoredLoad.Nadepth, uniaxialFactoredLoad.Eps, uniaxialFactoredLoad.Phi, #yve, #zve);
			}
		}

		// Token: 0x0600991D RID: 39197 RVA: 0x00204704 File Offset: 0x00202904
		private void #Mpb(#5Dd #Ipb, #xVe #Pc, #u3e.#xif? #mye, float? #nye, float? #oye, float? #pye, float? #yve, float? #zve)
		{
			CapacityRatioCalculation capacityRatioCalculation = base.Model.Output.CapacityData.#3hc(#Pc.Index).CapacityRatio;
			bool flag = base.Model.Input.Options.IsACI();
			NativeNumberFormat #cA = (base.Model.Input.Options.Unit == UnitSystem.USCustomary) ? NativeNumberFormat.F12_2 : NativeNumberFormat.F12_0;
			#YNe #YNe = capacityRatioCalculation.Flags;
			string text = #jye.#iye(#YNe);
			int num = (base.Model.Input.Options.ConsideredAxis == ConsideredAxis.Both) ? 0 : -1;
			#Ipb.#QDd(new string[]
			{
				string.IsNullOrWhiteSpace(text) ? #ned.#qp(capacityRatioCalculation.PhiPn, NativeNumberFormat.F11_2, #Phc.#3hc(107381628)) : text
			});
			bool flag2 = base.Model.Input.Options.SectionCapacityMethod == SectionCapacityMethodType.CriticalCapacity;
			if (!#YNe.HasFlag(#YNe.#b) && !#YNe.HasFlag(#YNe.#g) && !#YNe.HasFlag(#YNe.#h) && !#Pc.Flags.HasFlag(#FVe.#f) && !#Pc.Flags.HasFlag(#FVe.#g))
			{
				#u3e.#xif? #xif = #mye;
				#u3e.#xif #xif2 = #u3e.#xif.#b;
				if (!(#xif.GetValueOrDefault() == #xif2 & #xif != null))
				{
					#xif = #mye;
					#xif2 = #u3e.#xif.#c;
					if (!(#xif.GetValueOrDefault() == #xif2 & #xif != null) && string.IsNullOrWhiteSpace(text))
					{
						goto IL_1C1;
					}
				}
			}
			if (!flag2)
			{
				#Ipb.#QDd(new string[]
				{
					#Phc.#3hc(107253318)
				});
				#Ipb.#Fhd((flag ? 4 : 3) + num, ParagraphAlignment.Left, new string[]
				{
					string.Empty
				});
				goto IL_369;
			}
			IL_1C1:
			if (base.Model.Input.Options.SectionCapacityMethod == SectionCapacityMethodType.MomentCapacity)
			{
				#Ipb.#jDd(base.Model.Input.Options.ConsiderXAxis(), #ned.#qp(#yve, NativeNumberFormat.F11_2, #Phc.#3hc(107381628)));
				#Ipb.#jDd(base.Model.Input.Options.ConsiderYAxis(), #ned.#qp(#zve, NativeNumberFormat.F11_2, #Phc.#3hc(107381628)));
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(#nye, #cA, #Phc.#3hc(107381628))
				});
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(#oye, NativeNumberFormat.F8_5, #Phc.#3hc(107381628))
				});
				#Ipb.#jDd(flag, #ned.#qp(#pye, NativeNumberFormat.F6_3, #Phc.#3hc(107381628)));
			}
			else
			{
				#Ipb.#jDd(base.Model.Input.Options.ConsiderXAxis(), #ned.#qp(capacityRatioCalculation.PhiMnx, NativeNumberFormat.F11_2, #Phc.#3hc(107381628)));
				#Ipb.#jDd(base.Model.Input.Options.ConsiderYAxis(), #ned.#qp(capacityRatioCalculation.PhiMny, NativeNumberFormat.F11_2, #Phc.#3hc(107381628)));
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(#Pc.Nadepth, #cA, #Phc.#3hc(107381628))
				});
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(#Pc.Eps, NativeNumberFormat.F8_5, #Phc.#3hc(107381628))
				});
				#Ipb.#jDd(flag, #ned.#qp(#Pc.Phi, NativeNumberFormat.F6_3, #Phc.#3hc(107381628)));
			}
			IL_369:
			#Ipb.#QDd(new string[]
			{
				capacityRatioCalculation.DisplayValue
			});
			#Ipb.#jDd(#Pc.IsLoadCapacityExceeded, #Phc.#3hc(107378801), string.Empty);
		}

		// Token: 0x0600991E RID: 39198 RVA: 0x00204AAC File Offset: 0x00202CAC
		private void #Hpb(#5Dd #Ipb, int? #Jpb, int? #Kpb, int? #Lpb)
		{
			string text = (#Kpb != null && #Lpb != null) ? Strings.StringTop : Localization.StringBot;
			int? num = #Kpb;
			int? #f = (num != null) ? num : this.#b;
			num = #Lpb;
			int? num2 = (num != null) ? num : this.#a;
			int value;
			int value2;
			FactoredMoment.#vif #vif;
			if (#Jpb != null && this.#c.#3hc(#Jpb.Value - 1, out value, out value2, out #vif))
			{
				#f = new int?(value);
				num2 = new int?(value2);
				text = ((#vif == FactoredMoment.#vif.#a) ? Strings.StringTop : Localization.StringBot);
			}
			#Ipb.#QDd(#f);
			#Ipb.#QDd(new string[]
			{
				#Phc.#3hc(107360079),
				num2.GetValueOrDefault().ToString()
			});
			#Ipb.#QDd(new string[]
			{
				text
			});
			this.#b = #f;
			this.#a = num2;
		}

		// Token: 0x0600991F RID: 39199 RVA: 0x00204B9C File Offset: 0x00202D9C
		private void #Ppb(#5Dd #Ipb)
		{
			#Ipb.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
			bool flag = base.Model.Input.Options.ConsideredAxis == ConsideredAxis.Both;
			int num = flag ? 0 : -1;
			bool flag2 = base.Model.Input.Options.IsACI();
			bool flag3 = base.Model.Input.Options.ActiveLoad == LoadType.Service;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			#Ipb.#QDd(new string[]
			{
				#Phc.#3hc(107288102)
			});
			#Ipb.#pDd(flag3, 3, Localization.StringLoad, ParagraphAlignment.Left);
			#Ipb.#Fhd(flag ? 3 : 2, ParagraphAlignment.Center, new string[]
			{
				#Phc.#3hc(107286173)
			});
			#Ipb.#Fhd(flag ? 3 : 2, ParagraphAlignment.Center, new string[]
			{
				#Phc.#3hc(107288112)
			});
			#Ipb.#WDd(#2dd.#d, new int[]
			{
				#Ipb.CurrentCellIndex - 1
			});
			#Ipb.#Fhd(flag2 ? 3 : 2, ParagraphAlignment.Center, new string[]
			{
				#Phc.#3hc(107286164)
			});
			#Ipb.#ODd(new string[]
			{
				#Phc.#3hc(107288112),
				string.Empty
			});
			#Ipb.#QDd(new string[]
			{
				string.Empty
			});
			#Ipb.#pDd(flag3, 3, Localization.StringCombo, ParagraphAlignment.Left);
			#Ipb.#jDd(flag2, #Yxe.Pu, #Yxe.Pf);
			#Ipb.#jDd(base.Model.Input.Options.ConsiderXAxis(), flag2, #Yxe.Mux, #Yxe.Mfx);
			#Ipb.#jDd(base.Model.Input.Options.ConsiderYAxis(), flag2, #Yxe.Muy, #Yxe.Mfy);
			#Ipb.#jDd(flag2, #Yxe.PhiPn, #Yxe.Pr);
			#Ipb.#RDd(true, new int[]
			{
				#Ipb.CurrentCellIndex - 1
			});
			#Ipb.#jDd(base.Model.Input.Options.ConsiderXAxis(), flag2, #Yxe.#Xxe(#Phc.#3hc(107380695)), #Yxe.Mrx);
			#Ipb.#jDd(base.Model.Input.Options.ConsiderYAxis(), flag2, #Yxe.#Xxe(#Phc.#3hc(107427359)), #Yxe.Mry);
			#Ipb.#ODd(new string[]
			{
				Localization.StringNADepth,
				#Yxe.EpsT
			});
			#Ipb.#jDd(flag2, #Yxe.Phi);
			#Ipb.#ODd(new string[]
			{
				#Phc.#3hc(107288067),
				string.Empty
			});
			#Ipb.#QDd(new string[]
			{
				string.Empty
			});
			#Ipb.#qDd(flag3, 3);
			#Ipb.#QDd(new string[]
			{
				generalInformation.UnitStringF
			});
			#Ipb.#jDd(base.Model.Input.Options.ConsiderXAxis(), generalInformation.UnitStringM);
			#Ipb.#jDd(base.Model.Input.Options.ConsiderYAxis(), generalInformation.UnitStringM);
			#Ipb.#QDd(new string[]
			{
				generalInformation.UnitStringF
			});
			#Ipb.#jDd(base.Model.Input.Options.ConsiderXAxis(), generalInformation.UnitStringM);
			#Ipb.#jDd(base.Model.Input.Options.ConsiderYAxis(), generalInformation.UnitStringM);
			#Ipb.#ODd(new string[]
			{
				generalInformation.UnitStringD,
				string.Empty
			});
			#Ipb.#jDd(flag2, string.Empty);
			#Ipb.#ODd(new string[]
			{
				string.Empty,
				string.Empty
			});
			List<int> list = new List<int>();
			int num2 = flag2 ? 0 : -1;
			list.Add(flag3 ? 3 : 0);
			list.Add((flag3 ? 6 : 3) + num);
			list.Add((flag3 ? 12 : 9) + num2 + num * 2);
			#Ipb.#WDd(#2dd.#d, list.ToArray());
		}

		// Token: 0x06009920 RID: 39200 RVA: 0x00204F98 File Offset: 0x00203198
		private double[] #qye()
		{
			#aed #aed = null;
			bool flag = base.Model.Input.Options.ConsideredAxis == ConsideredAxis.Both;
			bool flag2 = base.Model.Input.Options.IsACI();
			if (base.Model.Input.Options.ActiveLoad == LoadType.Service)
			{
				if (flag)
				{
					#aed = (flag2 ? new #aed(new double[]
					{
						3.0,
						2.5,
						4.0,
						4.0,
						10.0,
						10.0,
						10.0,
						9.5,
						8.0,
						8.0,
						8.0,
						8.0,
						8.0,
						6.0,
						2.0
					}) : new #aed(new double[]
					{
						3.0,
						2.5,
						4.0,
						4.0,
						10.0,
						10.0,
						10.0,
						9.5,
						8.0,
						8.0,
						8.0,
						8.0,
						6.0,
						2.0
					}));
				}
				else
				{
					#aed = (flag2 ? new #aed(new double[]
					{
						3.0,
						2.5,
						4.0,
						4.0,
						10.0,
						10.0,
						8.0,
						8.0,
						8.0,
						8.0,
						8.0,
						6.0,
						2.0
					}) : new #aed(new double[]
					{
						3.0,
						2.5,
						4.0,
						4.0,
						10.0,
						10.0,
						8.0,
						8.0,
						8.0,
						8.0,
						6.0,
						2.0
					}));
				}
			}
			else if (base.Model.Input.Options.ActiveLoad == LoadType.Factored)
			{
				if (flag)
				{
					#aed = (flag2 ? new #aed(new double[]
					{
						3.0,
						10.0,
						10.0,
						10.0,
						8.0,
						8.0,
						8.0,
						8.0,
						8.0,
						8.0,
						6.0,
						2.0
					}) : new #aed(new double[]
					{
						3.0,
						10.0,
						10.0,
						10.0,
						8.0,
						8.0,
						8.0,
						8.0,
						8.0,
						6.0,
						2.0
					}));
				}
				else
				{
					#aed = (flag2 ? new #aed(new double[]
					{
						3.0,
						10.0,
						10.0,
						8.0,
						8.0,
						8.0,
						8.0,
						8.0,
						6.0,
						2.0
					}) : new #aed(new double[]
					{
						3.0,
						10.0,
						10.0,
						8.0,
						8.0,
						8.0,
						8.0,
						6.0,
						2.0
					}));
				}
			}
			if (#aed == null)
			{
				throw new InvalidOperationException();
			}
			return #aed.#7dd();
		}

		// Token: 0x06009921 RID: 39201 RVA: 0x002050F8 File Offset: 0x002032F8
		private bool #rye(CapacityRatioCalculation #sye)
		{
			if (base.Model.Input.Options.ProblemType == ProblemType.Investigation)
			{
				return #sye.IsExceeded;
			}
			if (!#sye.IsExceeded)
			{
				double? num = #sye.NumericValue;
				double num2 = (double)base.Model.Input.DesignToRequiredRatio;
				return num.GetValueOrDefault() >= num2 & num != null;
			}
			return true;
		}

		// Token: 0x040041BB RID: 16827
		private int? #a;

		// Token: 0x040041BC RID: 16828
		private int? #b;

		// Token: 0x040041BD RID: 16829
		private readonly LoadCombinationIndexCache #c;
	}
}
