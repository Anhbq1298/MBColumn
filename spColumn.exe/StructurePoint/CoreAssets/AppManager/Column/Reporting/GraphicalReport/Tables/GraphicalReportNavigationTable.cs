using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;
using #9Ue;
using #FCd;
using #gMe;
using #hye;
using #owe;
using #Qcd;
using #Rwe;
using #wdd;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.GraphicalReport.Tables
{
	// Token: 0x02001183 RID: 4483
	internal sealed class GraphicalReportNavigationTable : #qwe
	{
		// Token: 0x0600980A RID: 38922 RVA: 0x00200834 File Offset: 0x001FEA34
		public GraphicalReportNavigationTable(#lte model, Diagram2DData data, double availableWidth) : base(model)
		{
			this.#a = data;
			this.#b = availableWidth;
			this.#g = new LoadCombinationIndexCache(model);
		}

		// Token: 0x17002C21 RID: 11297
		// (get) Token: 0x0600980B RID: 38923 RVA: 0x00078C50 File Offset: 0x00076E50
		// (set) Token: 0x0600980C RID: 38924 RVA: 0x00078C58 File Offset: 0x00076E58
		public int TotalItemsCount { get; set; }

		// Token: 0x17002C22 RID: 11298
		// (get) Token: 0x0600980D RID: 38925 RVA: 0x00078C61 File Offset: 0x00076E61
		public int MaxItems { get; } = 15;

		// Token: 0x17002C23 RID: 11299
		// (get) Token: 0x0600980E RID: 38926 RVA: 0x00078C69 File Offset: 0x00076E69
		// (set) Token: 0x0600980F RID: 38927 RVA: 0x00078C71 File Offset: 0x00076E71
		public string OverallCapacityRatio { get; set; }

		// Token: 0x06009810 RID: 38928 RVA: 0x00200880 File Offset: 0x001FEA80
		public override void #npb(#6Dd #opb)
		{
			this.#vve();
			if (this.TotalItemsCount <= 0)
			{
				return;
			}
			LoadType activeLoad = base.Model.Input.Options.ActiveLoad;
			double[] array = this.#upb(activeLoad, base.Model.Input.Options.ConsideredAxis);
			using (#5Dd #5Dd = #opb.#ul(2, array))
			{
				#5Dd.#VDd(ParagraphAlignment.Right, Array.Empty<int>());
				switch (activeLoad)
				{
				case LoadType.Factored:
					this.#Opb(#5Dd);
					goto IL_8C;
				case LoadType.Service:
					this.#Npb(#5Dd);
					goto IL_8C;
				case LoadType.Axial:
				case LoadType.NoLoads:
					goto IL_8C;
				}
				throw new ArgumentOutOfRangeException();
				IL_8C:
				this.#eCd(#5Dd, array.Length);
				#5Dd.PreferredWidth = (float)this.#b;
				#5Dd.TableWidthType = #rdd.#b;
			}
		}

		// Token: 0x06009811 RID: 38929 RVA: 0x00200954 File Offset: 0x001FEB54
		public void #eCd(#5Dd #Ipb, int #rve)
		{
			#Ipb.#Fhd(#rve, Array.Empty<string>());
			#Ipb.#Fhd(#rve / 2 + 1, ParagraphAlignment.Left, new string[]
			{
				this.#sve()
			});
			#Ipb.#Fhd(#rve - #rve / 2 - 1, ParagraphAlignment.Right, new string[]
			{
				this.#tve()
			});
			#Ipb.#Fhd(#rve, Array.Empty<string>());
		}

		// Token: 0x06009812 RID: 38930 RVA: 0x002009B4 File Offset: 0x001FEBB4
		private string #sve()
		{
			if (this.TotalItemsCount <= 0)
			{
				return #Phc.#3hc(107288282).#z2d();
			}
			if (this.TotalItemsCount > this.MaxItems)
			{
				return #Phc.#3hc(107288201) + string.Format(#Phc.#3hc(107288216), this.MaxItems, this.TotalItemsCount).#z2d();
			}
			return string.Empty;
		}

		// Token: 0x06009813 RID: 38931 RVA: 0x00078C7A File Offset: 0x00076E7A
		private string #tve()
		{
			if (!string.IsNullOrEmpty(this.OverallCapacityRatio))
			{
				return #Phc.#3hc(107288131) + this.OverallCapacityRatio + #6xe.NonBreakingSpace;
			}
			return string.Empty;
		}

		// Token: 0x06009814 RID: 38932 RVA: 0x00200A28 File Offset: 0x001FEC28
		private void #uve(ServiceLoadItem #Rf)
		{
			string text = (#Rf.ServiceLoadIndex != null && #Rf.LoadCombinationIndex != null) ? Strings.StringTop : Localization.StringBot;
			int? num = #Rf.ServiceLoadIndex;
			int? num2 = (num != null) ? num : this.#f;
			num = #Rf.LoadCombinationIndex;
			int? num3 = (num != null) ? num : this.#e;
			int value;
			int value2;
			FactoredMoment.#vif #vif;
			if (#Rf.Index != null && this.#g.#3hc(#Rf.Index.Value - 1, out value, out value2, out #vif))
			{
				num2 = new int?(value);
				num3 = new int?(value2);
				text = ((#vif == FactoredMoment.#vif.#a) ? Strings.StringTop : Localization.StringBot);
			}
			#Rf.ServiceLoadIndex = num2;
			#Rf.LoadCombinationIndex = num3;
			#Rf.TopBottom = text;
			this.#f = num2;
			this.#e = num3;
		}

		// Token: 0x06009815 RID: 38933 RVA: 0x00200B10 File Offset: 0x001FED10
		private void #Hpb(#5Dd #Ipb, ServiceLoadItem #Rf)
		{
			#Ipb.#QDd(#Rf.ServiceLoadIndex);
			#Ipb.#QDd(new string[]
			{
				#Phc.#3hc(107360079),
				#Rf.LoadCombinationIndex.GetValueOrDefault().ToString()
			});
			#Ipb.#QDd(new string[]
			{
				#Rf.TopBottom
			});
		}

		// Token: 0x06009816 RID: 38934 RVA: 0x00200B70 File Offset: 0x001FED70
		private void #vve()
		{
			this.#c.Clear();
			this.#d.Clear();
			bool flag = base.Model.Input.Options.ConsideredAxis == ConsideredAxis.Both;
			if (base.Model.Input.Options.ActiveLoad == LoadType.Service)
			{
				GraphicalReportNavigationTable.#9Vb #9Vb = new GraphicalReportNavigationTable.#9Vb();
				List<ServiceLoadItem> list = new List<ServiceLoadItem>();
				List<ServiceLoadItem> list2 = list;
				IEnumerable<ServiceLoadItem> collection;
				if (!flag)
				{
					collection = base.Model.Output.UniaxialServiceLoads.Where(new Func<UniaxialServiceLoad, bool>(GraphicalReportNavigationTable.<>c.<>9.#2bf)).Select(new Func<UniaxialServiceLoad, ServiceLoadItem>(this.#Bve));
				}
				else
				{
					collection = base.Model.Output.BiaxialServiceLoads.Where(new Func<BiaxialServiceLoad, bool>(GraphicalReportNavigationTable.<>c.<>9.#1bf)).Select(new Func<BiaxialServiceLoad, ServiceLoadItem>(this.#Ave));
				}
				list2.AddRange(collection);
				#9Vb.#a = new HashSet<int>(this.#a.DrawnLoadPoints.Select(new Func<LoadPointDrawingData, int>(GraphicalReportNavigationTable.<>c.<>9.#3bf)));
				for (int i = 0; i < list.Count; i++)
				{
					ServiceLoadItem #Rf = list[i];
					this.#uve(#Rf);
				}
				list = list.Where(new Func<ServiceLoadItem, bool>(#9Vb.#Ybf)).ToList<ServiceLoadItem>();
				this.TotalItemsCount = list.Count;
				this.#c.AddRange(list.OrderByDescending(new Func<ServiceLoadItem, double>(GraphicalReportNavigationTable.<>c.<>9.#4bf)).Take(this.MaxItems));
				this.OverallCapacityRatio = (this.#c.Any<ServiceLoadItem>() ? base.Model.Output.CapacityData.OverallCapacity : string.Empty);
				return;
			}
			if (base.Model.Input.Options.ActiveLoad == LoadType.Factored)
			{
				GraphicalReportNavigationTable.#0bf #0bf = new GraphicalReportNavigationTable.#0bf();
				List<FactoredLoadItem> list3 = new List<FactoredLoadItem>();
				List<FactoredLoadItem> list4 = list3;
				IEnumerable<FactoredLoadItem> collection2;
				if (!flag)
				{
					collection2 = base.Model.Output.UniaxialFactoredLoads.Where(new Func<UniaxialFactoredLoad, bool>(GraphicalReportNavigationTable.<>c.<>9.#6bf)).Select(new Func<UniaxialFactoredLoad, FactoredLoadItem>(this.#Dve));
				}
				else
				{
					collection2 = base.Model.Output.BiaxialFactoredLoads.Where(new Func<BiaxialFactoredLoad, bool>(GraphicalReportNavigationTable.<>c.<>9.#5bf)).Select(new Func<BiaxialFactoredLoad, FactoredLoadItem>(this.#Cve));
				}
				list4.AddRange(collection2);
				#0bf.#a = new HashSet<int>(this.#a.DrawnLoadPoints.Select(new Func<LoadPointDrawingData, int>(GraphicalReportNavigationTable.<>c.<>9.#7bf)));
				list3 = list3.Where(new Func<FactoredLoadItem, bool>(#0bf.#Zbf)).ToList<FactoredLoadItem>();
				this.TotalItemsCount = list3.Count;
				this.#d.AddRange(list3.OrderByDescending(new Func<FactoredLoadItem, double>(GraphicalReportNavigationTable.<>c.<>9.#8bf)).Take(this.MaxItems));
				this.OverallCapacityRatio = (this.#d.Any<FactoredLoadItem>() ? base.Model.Output.CapacityData.OverallCapacity : string.Empty);
			}
		}

		// Token: 0x06009817 RID: 38935 RVA: 0x00200EE0 File Offset: 0x001FF0E0
		private void #Npb(#5Dd #Ipb)
		{
			Options options = base.Model.Input.Options;
			bool flag = options.ConsideredAxis == ConsideredAxis.Both;
			this.#Ppb(#Ipb);
			foreach (ServiceLoadItem serviceLoadItem in this.#c)
			{
				#Ipb.#QDd(serviceLoadItem.Index);
				this.#Hpb(#Ipb, serviceLoadItem);
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(serviceLoadItem.Pu, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
				});
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(serviceLoadItem.Mux, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
				});
				if (flag)
				{
					#Ipb.#QDd(new string[]
					{
						#ned.#qp(serviceLoadItem.Muy, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
					});
				}
				float? #yve = serviceLoadItem.PhiMnx;
				float? #zve = serviceLoadItem.PhiMny;
				if (!flag)
				{
					#yve = (options.ConsiderXAxis() ? serviceLoadItem.PhiMnx : null);
					#zve = (options.ConsiderYAxis() ? serviceLoadItem.PhiMnx : null);
				}
				this.#Mpb(#Ipb, serviceLoadItem.Parameters, serviceLoadItem.MinMax, serviceLoadItem.CapacityRatio, #yve, #zve);
			}
		}

		// Token: 0x06009818 RID: 38936 RVA: 0x00201050 File Offset: 0x001FF250
		private void #Mpb(#5Dd #Ipb, #xVe #Pc, #u3e.#xif #wve, CapacityRatioCalculation #xve, float? #yve, float? #zve)
		{
			#YNe #YNe = #xve.Flags;
			string text = #jye.#iye(#YNe);
			#Ipb.#QDd(new string[]
			{
				string.IsNullOrWhiteSpace(text) ? #ned.#qp(#xve.PhiPn, NativeNumberFormat.F11_2, #Phc.#3hc(107381628)) : text
			});
			Options options = base.Model.Input.Options;
			bool flag = options.SectionCapacityMethod == SectionCapacityMethodType.CriticalCapacity;
			if ((#YNe.HasFlag(#YNe.#b) || #YNe.HasFlag(#YNe.#g) || #YNe.HasFlag(#YNe.#h) || !string.IsNullOrWhiteSpace(text) || #wve == #u3e.#xif.#b || #wve == #u3e.#xif.#c || #Pc.Flags.HasFlag(#FVe.#f) || #Pc.Flags.HasFlag(#FVe.#g)) && !flag)
			{
				#Ipb.#QDd(new string[]
				{
					#Phc.#3hc(107253318)
				});
				if (options.ConsideredAxis == ConsideredAxis.Both)
				{
					#Ipb.#QDd(new string[]
					{
						string.Empty
					});
				}
			}
			else if (options.SectionCapacityMethod == SectionCapacityMethodType.MomentCapacity)
			{
				#Ipb.#jDd(options.ConsiderXAxis(), #ned.#qp(#yve, NativeNumberFormat.F11_2, #Phc.#3hc(107381628)));
				#Ipb.#jDd(options.ConsiderYAxis(), #ned.#qp(#zve, NativeNumberFormat.F11_2, #Phc.#3hc(107381628)));
			}
			else
			{
				#Ipb.#jDd(options.ConsiderXAxis(), #ned.#qp(#xve.PhiMnx, NativeNumberFormat.F11_2, #Phc.#3hc(107381628)));
				#Ipb.#jDd(options.ConsiderYAxis(), #ned.#qp(#xve.PhiMny, NativeNumberFormat.F11_2, #Phc.#3hc(107381628)));
			}
			#Ipb.#QDd(new string[]
			{
				#xve.DisplayValue
			});
		}

		// Token: 0x06009819 RID: 38937 RVA: 0x00201220 File Offset: 0x001FF420
		private void #Opb(#5Dd #Ipb)
		{
			Options options = base.Model.Input.Options;
			bool flag = options.ConsideredAxis == ConsideredAxis.Both;
			this.#Ppb(#Ipb);
			foreach (FactoredLoadItem factoredLoadItem in this.#d)
			{
				#Ipb.#QDd(factoredLoadItem.Index);
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(factoredLoadItem.Pu, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
				});
				#Ipb.#QDd(new string[]
				{
					#ned.#qp(factoredLoadItem.Mux, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
				});
				if (flag)
				{
					#Ipb.#QDd(new string[]
					{
						#ned.#qp(factoredLoadItem.Muy, NativeNumberFormat.F10_1, #Phc.#3hc(107381628))
					});
				}
				float? #yve = factoredLoadItem.PhiMnx;
				float? #zve = factoredLoadItem.PhiMny;
				if (!flag)
				{
					#yve = (options.ConsiderXAxis() ? factoredLoadItem.PhiMnx : null);
					#zve = (options.ConsiderYAxis() ? factoredLoadItem.PhiMnx : null);
				}
				this.#Mpb(#Ipb, factoredLoadItem.Parameters, factoredLoadItem.MinMax, factoredLoadItem.CapacityRatio, #yve, #zve);
			}
		}

		// Token: 0x0600981A RID: 38938 RVA: 0x00201388 File Offset: 0x001FF588
		private double[] #upb(LoadType #GB, ConsideredAxis #6gb)
		{
			if (#GB == LoadType.Factored)
			{
				return ((#6gb == ConsideredAxis.Both) ? new #aed(new double[]
				{
					2.0,
					3.0,
					3.0,
					3.0,
					3.0,
					3.0,
					3.0,
					3.0
				}) : new #aed(new double[]
				{
					2.0,
					3.0,
					3.0,
					3.0,
					3.0,
					3.0
				})).#7dd();
			}
			return ((#6gb == ConsideredAxis.Both) ? new #aed(new double[]
			{
				2.0,
				2.0,
				2.0,
				2.5,
				4.0,
				4.0,
				4.0,
				4.0,
				4.0,
				4.0,
				4.0
			}) : new #aed(new double[]
			{
				2.0,
				2.0,
				2.0,
				2.5,
				4.0,
				4.0,
				4.0,
				4.0,
				4.0
			})).#7dd();
		}

		// Token: 0x0600981B RID: 38939 RVA: 0x0020140C File Offset: 0x001FF60C
		private void #Ppb(#5Dd #Ipb)
		{
			Options options = base.Model.Input.Options;
			int activeLoad = (int)options.ActiveLoad;
			GeneralInformation generalInformation = base.Model.GeneralInfo;
			bool #nDd = activeLoad == 1;
			bool #nDd2 = options.IsCSA();
			#Ipb.#QDd(new string[]
			{
				#Phc.#3hc(107288102)
			});
			#Ipb.#pDd(#nDd, 3, #Phc.#3hc(107288097), ParagraphAlignment.Center);
			#Ipb.#jDd(#nDd2, #Yxe.Pf, #Yxe.Pu);
			#Ipb.#jDd(options.ConsiderXAxis(), #nDd2, #Yxe.Mfx, #Yxe.Mux);
			#Ipb.#jDd(options.ConsiderYAxis(), #nDd2, #Yxe.Mfy, #Yxe.Muy);
			#Ipb.#jDd(#nDd2, #Yxe.Pr, #Yxe.PhiPn);
			#Ipb.#RDd(true, new int[]
			{
				#Ipb.CurrentCellIndex - 1
			});
			#Ipb.#jDd(options.ConsiderXAxis(), #nDd2, #Yxe.Mrx, #Yxe.#Xxe(#Phc.#3hc(107380695)));
			#Ipb.#jDd(options.ConsiderYAxis(), #nDd2, #Yxe.Mry, #Yxe.#Xxe(#Phc.#3hc(107427359)));
			#Ipb.#QDd(new string[]
			{
				#Phc.#3hc(107288112)
			});
			#Ipb.#QDd(new string[]
			{
				string.Empty
			});
			#Ipb.#qDd(#nDd, 3);
			#Ipb.#QDd(new string[]
			{
				generalInformation.UnitStringF
			});
			#Ipb.#jDd(options.ConsiderXAxis(), generalInformation.UnitStringM);
			#Ipb.#jDd(options.ConsiderYAxis(), generalInformation.UnitStringM);
			#Ipb.#QDd(new string[]
			{
				generalInformation.UnitStringF
			});
			#Ipb.#jDd(options.ConsiderXAxis(), generalInformation.UnitStringM);
			#Ipb.#jDd(options.ConsiderYAxis(), generalInformation.UnitStringM);
			#Ipb.#QDd(new string[]
			{
				#Phc.#3hc(107288067)
			});
		}

		// Token: 0x0600981C RID: 38940 RVA: 0x00078CA9 File Offset: 0x00076EA9
		[CompilerGenerated]
		private ServiceLoadItem #Ave(BiaxialServiceLoad #Rf)
		{
			return new ServiceLoadItem(base.Model, #Rf);
		}

		// Token: 0x0600981D RID: 38941 RVA: 0x00078CB7 File Offset: 0x00076EB7
		[CompilerGenerated]
		private ServiceLoadItem #Bve(UniaxialServiceLoad #Rf)
		{
			return new ServiceLoadItem(base.Model, #Rf);
		}

		// Token: 0x0600981E RID: 38942 RVA: 0x00078CC5 File Offset: 0x00076EC5
		[CompilerGenerated]
		private FactoredLoadItem #Cve(BiaxialFactoredLoad #Rf)
		{
			return new FactoredLoadItem(base.Model, #Rf);
		}

		// Token: 0x0600981F RID: 38943 RVA: 0x00078CD3 File Offset: 0x00076ED3
		[CompilerGenerated]
		private FactoredLoadItem #Dve(UniaxialFactoredLoad #Rf)
		{
			return new FactoredLoadItem(base.Model, #Rf);
		}

		// Token: 0x04004164 RID: 16740
		private readonly Diagram2DData #a;

		// Token: 0x04004165 RID: 16741
		private readonly double #b;

		// Token: 0x04004166 RID: 16742
		private readonly List<ServiceLoadItem> #c = new List<ServiceLoadItem>();

		// Token: 0x04004167 RID: 16743
		private readonly List<FactoredLoadItem> #d = new List<FactoredLoadItem>();

		// Token: 0x04004168 RID: 16744
		private int? #e;

		// Token: 0x04004169 RID: 16745
		private int? #f;

		// Token: 0x0400416A RID: 16746
		private readonly LoadCombinationIndexCache #g;

		// Token: 0x0400416B RID: 16747
		[CompilerGenerated]
		private int #h;

		// Token: 0x0400416C RID: 16748
		[CompilerGenerated]
		private readonly int #i;

		// Token: 0x0400416D RID: 16749
		[CompilerGenerated]
		private string #j;

		// Token: 0x02001185 RID: 4485
		[CompilerGenerated]
		private sealed class #9Vb
		{
			// Token: 0x0600982B RID: 38955 RVA: 0x002015E0 File Offset: 0x001FF7E0
			internal bool #Ybf(ServiceLoadItem #Rf)
			{
				return this.#a.Contains(#Rf.Index.GetValueOrDefault(-1));
			}

			// Token: 0x04004177 RID: 16759
			public HashSet<int> #a;
		}

		// Token: 0x02001186 RID: 4486
		[CompilerGenerated]
		private sealed class #0bf
		{
			// Token: 0x0600982D RID: 38957 RVA: 0x00201608 File Offset: 0x001FF808
			internal bool #Zbf(FactoredLoadItem #Rf)
			{
				return this.#a.Contains(#Rf.Index.GetValueOrDefault(-1));
			}

			// Token: 0x04004178 RID: 16760
			public HashSet<int> #a;
		}
	}
}
