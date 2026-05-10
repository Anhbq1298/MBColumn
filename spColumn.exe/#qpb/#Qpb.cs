using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;
using #FCd;
using #owe;
using #Rwe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #qpb
{
	// Token: 0x02000464 RID: 1124
	internal sealed class #Qpb : #qwe
	{
		// Token: 0x06002946 RID: 10566 RVA: 0x000DE514 File Offset: 0x000DC714
		public #Qpb(#lte #Od) : base(#Od)
		{
			LoadType activeLoad = base.Model.Input.Options.ActiveLoad;
			double[] array = #Qpb.#upb(activeLoad, base.Model.Input.Options.ConsideredAxis);
			this.#f = array.Length - 1;
			this.#d = new Dictionary<int?, CapacityRatioCalculation>();
			this.#e = new Dictionary<int?, LoadPointDrawingData>();
			this.#c = new LoadCombinationIndexCache(#Od);
		}

		// Token: 0x17000DED RID: 3565
		// (get) Token: 0x06002947 RID: 10567 RVA: 0x00025D8E File Offset: 0x00023F8E
		public IDictionary<int?, CapacityRatioCalculation> CapacityCache { get; }

		// Token: 0x17000DEE RID: 3566
		// (get) Token: 0x06002948 RID: 10568 RVA: 0x00025D9A File Offset: 0x00023F9A
		public IDictionary<int?, LoadPointDrawingData> ParametersCache { get; }

		// Token: 0x17000DEF RID: 3567
		// (get) Token: 0x06002949 RID: 10569 RVA: 0x00025DA6 File Offset: 0x00023FA6
		private int MaxColumnIndex { get; }

		// Token: 0x0600294A RID: 10570 RVA: 0x000DE588 File Offset: 0x000DC788
		public static double[] #upb(LoadType #GB, ConsideredAxis #6gb)
		{
			if (#GB == LoadType.Factored)
			{
				return ((#6gb == ConsideredAxis.Both) ? new #aed(new double[]
				{
					4.0,
					9.0,
					9.0,
					9.0,
					9.5
				}) : new #aed(new double[]
				{
					4.0,
					9.0,
					9.0,
					9.5
				})).#7dd();
			}
			return ((#6gb == ConsideredAxis.Both) ? new #aed(new double[]
			{
				6.0,
				6.0,
				6.0,
				6.5,
				9.0,
				9.0,
				9.0,
				9.5
			}) : new #aed(new double[]
			{
				4.0,
				4.0,
				4.0,
				4.0,
				9.0,
				9.0,
				9.5
			})).#7dd();
		}

		// Token: 0x0600294B RID: 10571 RVA: 0x000DE61C File Offset: 0x000DC81C
		public int? #vpb()
		{
			LoadType activeLoad = base.Model.Input.Options.ActiveLoad;
			if (activeLoad == LoadType.Factored)
			{
				return new int?(1);
			}
			if (activeLoad == LoadType.Service)
			{
				return new int?(4);
			}
			return null;
		}

		// Token: 0x0600294C RID: 10572 RVA: 0x00025DB2 File Offset: 0x00023FB2
		public int? #wpb(GridDataRowCore #uI)
		{
			return #uI.#Cfd(new int?(0));
		}

		// Token: 0x0600294D RID: 10573 RVA: 0x000DE66C File Offset: 0x000DC86C
		public int? #xpb(GridDataRowCore #uI)
		{
			if (base.Model.Input.Options.ActiveLoad != LoadType.Service)
			{
				return null;
			}
			return #uI.#Cfd(new int?(1));
		}

		// Token: 0x0600294E RID: 10574 RVA: 0x00025DCC File Offset: 0x00023FCC
		public string #ypb(GridDataRowCore #uI)
		{
			if (base.Model.Input.Options.ActiveLoad != LoadType.Service)
			{
				return null;
			}
			return #uI.#Afd(new int?(2));
		}

		// Token: 0x0600294F RID: 10575 RVA: 0x00025E00 File Offset: 0x00024000
		public string #zpb(GridDataRowCore #uI)
		{
			if (base.Model.Input.Options.ActiveLoad != LoadType.Service)
			{
				return null;
			}
			return #uI.#Afd(new int?(3));
		}

		// Token: 0x06002950 RID: 10576 RVA: 0x00025E34 File Offset: 0x00024034
		public double? #Apb(GridDataRowCore #uI)
		{
			return #uI.#Bfd(this.#vpb());
		}

		// Token: 0x06002951 RID: 10577 RVA: 0x00025E4E File Offset: 0x0002404E
		public double? #Bpb(GridDataRowCore #uI)
		{
			return #uI.#Bfd(this.#Fpb());
		}

		// Token: 0x06002952 RID: 10578 RVA: 0x00025E68 File Offset: 0x00024068
		public double? #Cpb(GridDataRowCore #uI)
		{
			return #uI.#Bfd(this.#Gpb());
		}

		// Token: 0x06002953 RID: 10579 RVA: 0x00025E82 File Offset: 0x00024082
		public string #Dpb(GridDataRowCore #uI)
		{
			return #uI.#Afd(new int?(this.MaxColumnIndex));
		}

		// Token: 0x06002954 RID: 10580 RVA: 0x00025EA1 File Offset: 0x000240A1
		public string #Epb(GridDataRowCore #uI)
		{
			return #uI.#nfd(this.MaxColumnIndex);
		}

		// Token: 0x06002955 RID: 10581 RVA: 0x000DE6B4 File Offset: 0x000DC8B4
		public int? #Fpb()
		{
			LoadType activeLoad = base.Model.Input.Options.ActiveLoad;
			ConsideredAxis consideredAxis = base.Model.Input.Options.ConsideredAxis;
			if (activeLoad == LoadType.Factored)
			{
				if (consideredAxis == ConsideredAxis.Both || consideredAxis == ConsideredAxis.X)
				{
					return new int?(2);
				}
			}
			else if (activeLoad == LoadType.Service && (consideredAxis == ConsideredAxis.Both || consideredAxis == ConsideredAxis.X))
			{
				return new int?(5);
			}
			return null;
		}

		// Token: 0x06002956 RID: 10582 RVA: 0x000DE728 File Offset: 0x000DC928
		public int? #Gpb()
		{
			LoadType activeLoad = base.Model.Input.Options.ActiveLoad;
			ConsideredAxis consideredAxis = base.Model.Input.Options.ConsideredAxis;
			if (activeLoad == LoadType.Factored)
			{
				if (consideredAxis == ConsideredAxis.Y)
				{
					return new int?(2);
				}
				if (consideredAxis == ConsideredAxis.Both)
				{
					return new int?(3);
				}
			}
			else if (activeLoad == LoadType.Service)
			{
				if (consideredAxis == ConsideredAxis.Y)
				{
					return new int?(5);
				}
				if (consideredAxis == ConsideredAxis.Both)
				{
					return new int?(6);
				}
			}
			return null;
		}

		// Token: 0x06002957 RID: 10583 RVA: 0x000DE7B4 File Offset: 0x000DC9B4
		public override void #npb(#6Dd #opb)
		{
			LoadType activeLoad = base.Model.Input.Options.ActiveLoad;
			double[] #Zpb = #Qpb.#upb(activeLoad, base.Model.Input.Options.ConsideredAxis);
			this.CapacityCache.Clear();
			this.ParametersCache.Clear();
			using (#5Dd #5Dd = #opb.#ul(2, #Zpb))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				this.#Ppb(#5Dd);
				if (base.Model.Output != null)
				{
					switch (activeLoad)
					{
					case LoadType.Factored:
						this.#Opb(#5Dd);
						break;
					case LoadType.Service:
						this.#Npb(#5Dd);
						break;
					}
				}
			}
		}

		// Token: 0x06002958 RID: 10584 RVA: 0x000DE89C File Offset: 0x000DCA9C
		private void #Hpb(#5Dd #Ipb, int? #Jpb, int? #Kpb, int? #Lpb)
		{
			string text = (#Kpb != null && #Lpb != null) ? Strings.StringTop : Localization.StringBot;
			int? num = #Kpb;
			int? num2 = (num != null) ? num : this.#b;
			num = #Lpb;
			int? num3 = (num != null) ? num : this.#a;
			int value;
			int value2;
			FactoredMoment.#vif #vif;
			if (#Jpb != null && this.#c.#3hc(#Jpb.Value - 1, out value, out value2, out #vif))
			{
				num2 = new int?(value);
				num3 = new int?(value2);
				text = ((#vif == FactoredMoment.#vif.#a) ? Strings.StringTop : Localization.StringBot);
			}
			#Ipb.#QDd(num2);
			#Ipb.#QDd(new string[]
			{
				#Phc.#3hc(107360079),
				num3.GetValueOrDefault().ToString()
			});
			#Ipb.#QDd(new string[]
			{
				text
			});
			this.#b = num2;
			this.#a = num3;
		}

		// Token: 0x06002959 RID: 10585 RVA: 0x000DE9AC File Offset: 0x000DCBAC
		private CapacityRatioCalculation #Mpb(#5Dd #Ipb, LoadPointDrawingData #ycb)
		{
			CapacityRatioCalculation capacityRatioCalculation = base.Model.Output.CapacityData.#3hc(#ycb.Index).CapacityRatio;
			#Ipb.#QDd(new string[]
			{
				capacityRatioCalculation.DisplayValue
			});
			return capacityRatioCalculation;
		}

		// Token: 0x0600295A RID: 10586 RVA: 0x000DE9FC File Offset: 0x000DCBFC
		private void #Npb(#5Dd #Ipb)
		{
			Options options = base.Model.Input.Options;
			if (options.ConsideredAxis == ConsideredAxis.Both)
			{
				for (int i = 0; i < base.Model.Output.BiaxialServiceLoads.Count; i++)
				{
					BiaxialServiceLoad biaxialServiceLoad = base.Model.Output.BiaxialServiceLoads[i];
					if (biaxialServiceLoad.MinMax != #u3e.#xif.#c)
					{
						#Ipb.#QDd(biaxialServiceLoad.Index);
						this.#Hpb(#Ipb, biaxialServiceLoad.Index, biaxialServiceLoad.ServiceLoadIndex, biaxialServiceLoad.LoadCombinationIndex);
						#Ipb.#QDd(new string[]
						{
							#ned.#qp(biaxialServiceLoad.AppLoad, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
						});
						#Ipb.#QDd(new string[]
						{
							#ned.#qp(biaxialServiceLoad.FactLoad2, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
						});
						#Ipb.#QDd(new string[]
						{
							#ned.#qp(biaxialServiceLoad.FactLoad3, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
						});
						LoadPointDrawingData loadPointDrawingData = new LoadPointDrawingData(biaxialServiceLoad);
						if (biaxialServiceLoad.Index != null)
						{
							this.ParametersCache[biaxialServiceLoad.Index] = loadPointDrawingData;
							this.CapacityCache[biaxialServiceLoad.Index] = this.#Mpb(#Ipb, loadPointDrawingData);
						}
					}
				}
				return;
			}
			for (int j = 0; j < base.Model.Output.UniaxialServiceLoads.Count; j++)
			{
				UniaxialServiceLoad uniaxialServiceLoad = base.Model.Output.UniaxialServiceLoads[j];
				if (uniaxialServiceLoad.MinMax != #u3e.#xif.#c)
				{
					#Ipb.#QDd(uniaxialServiceLoad.Index);
					this.#Hpb(#Ipb, uniaxialServiceLoad.Index, uniaxialServiceLoad.ServiceLoadIndex, uniaxialServiceLoad.LoadCombinationIndex);
					#Ipb.#QDd(new string[]
					{
						#ned.#qp(uniaxialServiceLoad.AppLoad, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
					});
					#Ipb.#QDd(new string[]
					{
						#ned.#qp(uniaxialServiceLoad.AppMoment, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
					});
					if (uniaxialServiceLoad.Index != null)
					{
						LoadPointDrawingData loadPointDrawingData2 = base.Model.Output.CapacityData.#3hc(uniaxialServiceLoad.Index.GetValueOrDefault());
						this.ParametersCache[uniaxialServiceLoad.Index] = loadPointDrawingData2;
						this.CapacityCache[uniaxialServiceLoad.Index] = this.#Mpb(#Ipb, loadPointDrawingData2);
					}
				}
			}
		}

		// Token: 0x0600295B RID: 10587 RVA: 0x000DEC94 File Offset: 0x000DCE94
		private void #Opb(#5Dd #Ipb)
		{
			Options options = base.Model.Input.Options;
			if (options.ConsideredAxis == ConsideredAxis.Both)
			{
				using (IEnumerator<BiaxialFactoredLoad> enumerator = base.Model.Output.BiaxialFactoredLoads.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						BiaxialFactoredLoad biaxialFactoredLoad = enumerator.Current;
						if (biaxialFactoredLoad.MinMax != #u3e.#xif.#c)
						{
							#Ipb.#QDd(biaxialFactoredLoad.Index);
							#Ipb.#QDd(new string[]
							{
								#ned.#qp(biaxialFactoredLoad.AppLoad, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
							});
							#Ipb.#QDd(new string[]
							{
								#ned.#qp(biaxialFactoredLoad.FactLoad1, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
							});
							#Ipb.#QDd(new string[]
							{
								#ned.#qp(biaxialFactoredLoad.FactLoad2, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
							});
							if (biaxialFactoredLoad.Index != null)
							{
								LoadPointDrawingData loadPointDrawingData = base.Model.Output.CapacityData.#3hc(biaxialFactoredLoad.Index.GetValueOrDefault());
								this.ParametersCache[biaxialFactoredLoad.Index] = loadPointDrawingData;
								this.CapacityCache[biaxialFactoredLoad.Index] = this.#Mpb(#Ipb, loadPointDrawingData);
							}
						}
					}
					return;
				}
			}
			foreach (UniaxialFactoredLoad uniaxialFactoredLoad in base.Model.Output.UniaxialFactoredLoads)
			{
				if (uniaxialFactoredLoad.MinMax != #u3e.#xif.#c)
				{
					#Ipb.#QDd(uniaxialFactoredLoad.Index);
					#Ipb.#QDd(new string[]
					{
						#ned.#qp(uniaxialFactoredLoad.AppLoad, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
					});
					#Ipb.#QDd(new string[]
					{
						#ned.#qp(uniaxialFactoredLoad.AppMoment, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
					});
					if (uniaxialFactoredLoad.Index != null)
					{
						LoadPointDrawingData loadPointDrawingData2 = base.Model.Output.CapacityData.#3hc(uniaxialFactoredLoad.Index.GetValueOrDefault());
						this.ParametersCache[uniaxialFactoredLoad.Index] = loadPointDrawingData2;
						this.CapacityCache[uniaxialFactoredLoad.Index] = this.#Mpb(#Ipb, loadPointDrawingData2);
					}
				}
			}
		}

		// Token: 0x0600295C RID: 10588 RVA: 0x000DEF40 File Offset: 0x000DD140
		private void #Ppb(#5Dd #Ipb)
		{
			Options options = base.Model.Input.Options;
			LoadType activeLoad = options.ActiveLoad;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			string text = options.IsCSA() ? #Yxe.Pf : #Yxe.Pu;
			string text2 = options.IsCSA() ? #Yxe.Mfx : #Yxe.Mux;
			string text3 = options.IsCSA() ? #Yxe.Mfy : #Yxe.Muy;
			if (activeLoad == LoadType.Factored)
			{
				#Ipb.#QDd(new string[]
				{
					Strings.StringNo.#z2d()
				});
				#Ipb.#QDd(new string[]
				{
					text
				});
				if (options.ConsiderXAxis())
				{
					#Ipb.#QDd(new string[]
					{
						text2
					});
				}
				if (options.ConsiderYAxis())
				{
					#Ipb.#QDd(new string[]
					{
						text3
					});
				}
				#Ipb.#QDd(new string[]
				{
					Strings.StringCapacity
				});
				#Ipb.#QDd(new string[]
				{
					string.Empty
				});
				#Ipb.#QDd(new string[]
				{
					generalInformation.UnitStringF
				});
				if (options.ConsiderXAxis())
				{
					#Ipb.#QDd(new string[]
					{
						generalInformation.UnitStringM
					});
				}
				if (options.ConsiderYAxis())
				{
					#Ipb.#QDd(new string[]
					{
						generalInformation.UnitStringM
					});
				}
				#Ipb.#QDd(new string[]
				{
					Strings.StringRatio
				});
				return;
			}
			if (activeLoad == LoadType.Service)
			{
				#Ipb.#QDd(new string[]
				{
					Strings.StringNo.#z2d()
				});
				#Ipb.#Fhd(3, new string[]
				{
					Strings.StringLoadCombo
				});
				#Ipb.#QDd(new string[]
				{
					text
				});
				if (options.ConsiderXAxis())
				{
					#Ipb.#QDd(new string[]
					{
						text2
					});
				}
				if (options.ConsiderYAxis())
				{
					#Ipb.#QDd(new string[]
					{
						text3
					});
				}
				#Ipb.#QDd(new string[]
				{
					Strings.StringCapacity
				});
				#Ipb.#ODd(new string[]
				{
					string.Empty,
					string.Empty,
					string.Empty,
					string.Empty
				});
				#Ipb.#QDd(new string[]
				{
					generalInformation.UnitStringF
				});
				if (options.ConsiderXAxis())
				{
					#Ipb.#QDd(new string[]
					{
						generalInformation.UnitStringM
					});
				}
				if (options.ConsiderYAxis())
				{
					#Ipb.#QDd(new string[]
					{
						generalInformation.UnitStringM
					});
				}
				#Ipb.#QDd(new string[]
				{
					Strings.StringRatio
				});
			}
		}

		// Token: 0x0400107E RID: 4222
		private int? #a;

		// Token: 0x0400107F RID: 4223
		private int? #b;

		// Token: 0x04001080 RID: 4224
		private readonly LoadCombinationIndexCache #c;

		// Token: 0x04001081 RID: 4225
		[CompilerGenerated]
		private readonly IDictionary<int?, CapacityRatioCalculation> #d;

		// Token: 0x04001082 RID: 4226
		[CompilerGenerated]
		private readonly IDictionary<int?, LoadPointDrawingData> #e;

		// Token: 0x04001083 RID: 4227
		[CompilerGenerated]
		private readonly int #f;
	}
}
