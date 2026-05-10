using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #2be;
using #5Z;
using #7hc;
using #f7;
using #npe;
using #o1d;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Model.Entities.Units;

namespace StructurePoint.Products.Column.Model
{
	// Token: 0x0200032A RID: 810
	internal sealed class ColumnModel : NotifyPropertyChangedObjectBase, #Xpe
	{
		// Token: 0x06001BF3 RID: 7155 RVA: 0x000BF7A8 File Offset: 0x000BD9A8
		public ColumnModel()
		{
			this.InvestigateInputFlag = #ope.#a;
			this.DesignInputFlag = #ope.#a;
			this.SlendernessInputFlag = #ppe.#a;
			this.Options = new #k3();
			this.Ties = new #53();
			this.DesignDimensions = new #f1();
			this.InvestigationDimensions = new #Q1();
			this.MaterialProperties = new #K2();
			this.StiffnessReductionFactorPhi = 0f;
			this.Bars = new CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.StandardBar>();
			this.ReinforcementRatios = new StructurePoint.Products.Column.Model.Entities.ReinforcementRatios();
			this.MinRebarClearSpacing = 0f;
			this.DesignToRequiredRatio = 0f;
			this.DesignedColumnX = new #X3();
			this.DesignedColumnY = new #X3();
			this.DesignReinforcement = new #k1();
			this.InvestigationReinforcement = new #T1();
			this.BeamX = new #W3();
			this.BeamY = new #W3();
			this.SustainedLoadFactors = new #Y3();
			this.LoadFactors = new List<StructurePoint.Products.Column.Model.Entities.LoadFactor>();
			this.ServiceLoads = new List<StructurePoint.Products.Column.Model.Entities.ServiceLoad>();
			this.CrackedIBeams = 0f;
			this.CrackedIColumn = 0f;
			this.ColumnAbove = new StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn();
			this.ColumnBelow = new StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn();
			this.ReinforcementBars = new List<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>();
			this.Shapes = new List<ShapeModel>();
			this.FactoredLoads = new List<StructurePoint.Products.Column.Model.Entities.FactoredLoad>();
			this.ReductionFactors = new StructurePoint.Products.Column.Model.Entities.ReductionFactors();
			this.ProjectInfo = new #r3();
			this.IrregularOptions = new #E2();
			this.#t = new UnitValueGroups(UnitSystem.USCustomary);
			this.#u = new UnitValueGroups(UnitSystem.SIMetric);
			this.DraftingSettings = #e7.#c7(StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other.DraftingSettings.Default(UnitSystem.USCustomary));
			this.AxialLoads = new List<StructurePoint.Products.Column.Model.Entities.AxialLoad>();
			this.TemplateData = new TemplateDataEntity();
		}

		// Token: 0x06001BF4 RID: 7156 RVA: 0x000BF964 File Offset: 0x000BDB64
		public ColumnModel(ColumnStorageModel model)
		{
			this.InvestigateInputFlag = (#ope)model.InvestigateInputFlag;
			this.DesignInputFlag = (#ope)model.DesignInputFlag;
			this.SlendernessInputFlag = (#ppe)model.SlendernessInputFlag;
			this.Options = new #k3(model.Options);
			this.Ties = new #53(model.Ties);
			this.DesignDimensions = new #f1(model.DesignDimensions);
			this.InvestigationDimensions = new #Q1(model.InvestigationDimensions);
			this.MaterialProperties = new #K2(model.MaterialProperties);
			this.StiffnessReductionFactorPhi = model.StiffnessReductionFactorPhi;
			this.Bars = new CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.StandardBar>(model.Bars.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar, StructurePoint.Products.Column.Model.Entities.StandardBar>(ColumnModel.<>c.<>9.#z2b)));
			this.BarGroupType = model.BarGroupType;
			this.ReinforcementRatios = new StructurePoint.Products.Column.Model.Entities.ReinforcementRatios(model.ReinforcementRatios);
			this.MinRebarClearSpacing = model.MinRebarClearSpacing;
			this.DesignToRequiredRatio = model.DesignToRequiredRatio;
			this.AreSlendenessFactorsCodeDefault = (model.SlendernessOptFactor == 0);
			this.DesignedColumnX = new #X3(model.DesignedColumnX);
			this.DesignedColumnY = new #X3(model.DesignedColumnY);
			this.DesignReinforcement = new #k1(model.DesignReinforcement);
			this.InvestigationReinforcement = new #T1(model.InvestigationReinforcement);
			this.BeamX = new #W3(model.BeamX);
			this.BeamY = new #W3(model.BeamY);
			this.SustainedLoadFactors = new #Y3(model.SustainedLoadFactors);
			this.LoadFactors = new List<StructurePoint.Products.Column.Model.Entities.LoadFactor>(model.LoadFactors.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.LoadFactor, StructurePoint.Products.Column.Model.Entities.LoadFactor>(ColumnModel.<>c.<>9.#A2b)));
			this.ServiceLoads = new List<StructurePoint.Products.Column.Model.Entities.ServiceLoad>(model.ServiceLoads.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ServiceLoad, StructurePoint.Products.Column.Model.Entities.ServiceLoad>(ColumnModel.<>c.<>9.#B2b)));
			this.CrackedIBeams = model.CrackedIBeams;
			this.CrackedIColumn = model.CrackedIColumn;
			this.ColumnAbove = new StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn(model.ColumnAbove);
			this.ColumnBelow = new StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn(model.ColumnBelow);
			this.StiffnessX = model.StiffnessX;
			this.StiffnessY = model.StiffnessY;
			this.ReinforcementBars = new List<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>(model.ReinforcementBars.Where(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar, bool>(ColumnModel.<>c.<>9.#C2b)).Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar, StructurePoint.Products.Column.Model.Entities.ReinforcementBar>(ColumnModel.<>c.<>9.#D2b)));
			this.Shapes = new List<ShapeModel>(model.Polygons.Select(new Func<SectionPolygon, ShapeModel>(ColumnModel.<>c.<>9.#E2b)));
			this.FactoredLoads = new List<StructurePoint.Products.Column.Model.Entities.FactoredLoad>(model.FactoredLoads.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.FactoredLoad, StructurePoint.Products.Column.Model.Entities.FactoredLoad>(ColumnModel.<>c.<>9.#F2b)));
			this.ReductionFactors = new StructurePoint.Products.Column.Model.Entities.ReductionFactors(model.ReductionFactors);
			this.ProjectInfo = new #r3(model.ProjectInfo);
			this.IrregularOptions = new #E2(model.IrregularOptions);
			this.#t = new UnitValueGroups(UnitSystem.USCustomary);
			this.#u = new UnitValueGroups(UnitSystem.SIMetric);
			this.DraftingSettings = #e7.#c7(model.DraftingSettings);
			this.#q = new List<SectionTypeDependentValuesCacheItem>();
			this.SectionTypeCacheItems.AddRange(model.SectionTypeCacheItems.Select(new Func<SectionTypeDependentValuesCacheItem, SectionTypeDependentValuesCacheItem>(ColumnModel.<>c.<>9.#G2b)));
			this.AxialLoads = new List<StructurePoint.Products.Column.Model.Entities.AxialLoad>(model.AxialLoads.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.AxialLoad, StructurePoint.Products.Column.Model.Entities.AxialLoad>(ColumnModel.<>c.<>9.#xBf)));
			this.TemplateData = new TemplateDataEntity(model.TemplateData);
			if (!this.SectionTypeCacheItems.Any<SectionTypeDependentValuesCacheItem>())
			{
				this.SectionTypeCacheItems.Add(this.#NY());
			}
		}

		// Token: 0x170009D9 RID: 2521
		// (get) Token: 0x06001BF5 RID: 7157 RVA: 0x0001B32E File Offset: 0x0001952E
		// (set) Token: 0x06001BF6 RID: 7158 RVA: 0x0001B33A File Offset: 0x0001953A
		public #r3 ProjectInfo { get; set; }

		// Token: 0x170009DA RID: 2522
		// (get) Token: 0x06001BF7 RID: 7159 RVA: 0x0001B34B File Offset: 0x0001954B
		public List<SectionTypeDependentValuesCacheItem> SectionTypeCacheItems { get; }

		// Token: 0x170009DB RID: 2523
		// (get) Token: 0x06001BF8 RID: 7160 RVA: 0x0001B357 File Offset: 0x00019557
		// (set) Token: 0x06001BF9 RID: 7161 RVA: 0x0001B363 File Offset: 0x00019563
		public #ope InvestigateInputFlag
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<#ope>(ref this.#a, value, #Phc.#3hc(107399777));
			}
		}

		// Token: 0x170009DC RID: 2524
		// (get) Token: 0x06001BFA RID: 7162 RVA: 0x0001B389 File Offset: 0x00019589
		// (set) Token: 0x06001BFB RID: 7163 RVA: 0x0001B395 File Offset: 0x00019595
		public #ope DesignInputFlag
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<#ope>(ref this.#b, value, #Phc.#3hc(107399748));
			}
		}

		// Token: 0x170009DD RID: 2525
		// (get) Token: 0x06001BFC RID: 7164 RVA: 0x0001B3BB File Offset: 0x000195BB
		// (set) Token: 0x06001BFD RID: 7165 RVA: 0x0001B3C7 File Offset: 0x000195C7
		public #ppe SlendernessInputFlag
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<#ppe>(ref this.#c, value, #Phc.#3hc(107399727));
			}
		}

		// Token: 0x170009DE RID: 2526
		// (get) Token: 0x06001BFE RID: 7166 RVA: 0x0001B3ED File Offset: 0x000195ED
		// (set) Token: 0x06001BFF RID: 7167 RVA: 0x0001B3F9 File Offset: 0x000195F9
		public #k3 Options { get; set; }

		// Token: 0x170009DF RID: 2527
		// (get) Token: 0x06001C00 RID: 7168 RVA: 0x0001B40A File Offset: 0x0001960A
		// (set) Token: 0x06001C01 RID: 7169 RVA: 0x0001B416 File Offset: 0x00019616
		public #E2 IrregularOptions { get; set; }

		// Token: 0x170009E0 RID: 2528
		// (get) Token: 0x06001C02 RID: 7170 RVA: 0x0001B427 File Offset: 0x00019627
		public UnitValueGroups Units
		{
			get
			{
				if (this.Options.Unit != UnitSystem.SIMetric)
				{
					return this.EnglishUnits;
				}
				return this.MetricUnits;
			}
		}

		// Token: 0x170009E1 RID: 2529
		// (get) Token: 0x06001C03 RID: 7171 RVA: 0x0001B450 File Offset: 0x00019650
		public UnitValueGroups EnglishUnits { get; }

		// Token: 0x170009E2 RID: 2530
		// (get) Token: 0x06001C04 RID: 7172 RVA: 0x0001B45C File Offset: 0x0001965C
		public UnitValueGroups MetricUnits { get; }

		// Token: 0x170009E3 RID: 2531
		// (get) Token: 0x06001C05 RID: 7173 RVA: 0x0001B468 File Offset: 0x00019668
		// (set) Token: 0x06001C06 RID: 7174 RVA: 0x0001B474 File Offset: 0x00019674
		public #53 Ties { get; set; }

		// Token: 0x170009E4 RID: 2532
		// (get) Token: 0x06001C07 RID: 7175 RVA: 0x0001B485 File Offset: 0x00019685
		// (set) Token: 0x06001C08 RID: 7176 RVA: 0x0001B491 File Offset: 0x00019691
		public #k1 DesignReinforcement
		{
			get
			{
				return this.#m;
			}
			set
			{
				this.SetProperty<#k1>(ref this.#m, value, #Phc.#3hc(107399730));
			}
		}

		// Token: 0x170009E5 RID: 2533
		// (get) Token: 0x06001C09 RID: 7177 RVA: 0x0001B4B7 File Offset: 0x000196B7
		// (set) Token: 0x06001C0A RID: 7178 RVA: 0x0001B4C3 File Offset: 0x000196C3
		public #T1 InvestigationReinforcement
		{
			get
			{
				return this.#n;
			}
			set
			{
				this.SetProperty<#T1>(ref this.#n, value, #Phc.#3hc(107399701));
			}
		}

		// Token: 0x170009E6 RID: 2534
		// (get) Token: 0x06001C0B RID: 7179 RVA: 0x0001B4E9 File Offset: 0x000196E9
		// (set) Token: 0x06001C0C RID: 7180 RVA: 0x0001B4F5 File Offset: 0x000196F5
		public #f1 DesignDimensions
		{
			get
			{
				return this.#o;
			}
			set
			{
				this.SetProperty<#f1>(ref this.#o, value, #Phc.#3hc(107400176));
			}
		}

		// Token: 0x170009E7 RID: 2535
		// (get) Token: 0x06001C0D RID: 7181 RVA: 0x0001B51B File Offset: 0x0001971B
		// (set) Token: 0x06001C0E RID: 7182 RVA: 0x0001B527 File Offset: 0x00019727
		public #Q1 InvestigationDimensions
		{
			get
			{
				return this.#l;
			}
			set
			{
				this.SetProperty<#Q1>(ref this.#l, value, #Phc.#3hc(107400151));
			}
		}

		// Token: 0x170009E8 RID: 2536
		// (get) Token: 0x06001C0F RID: 7183 RVA: 0x0001B54D File Offset: 0x0001974D
		// (set) Token: 0x06001C10 RID: 7184 RVA: 0x0001B559 File Offset: 0x00019759
		public #K2 MaterialProperties { get; set; }

		// Token: 0x170009E9 RID: 2537
		// (get) Token: 0x06001C11 RID: 7185 RVA: 0x0001B56A File Offset: 0x0001976A
		// (set) Token: 0x06001C12 RID: 7186 RVA: 0x0001B576 File Offset: 0x00019776
		public StructurePoint.Products.Column.Model.Entities.ReductionFactors ReductionFactors { get; set; }

		// Token: 0x170009EA RID: 2538
		// (get) Token: 0x06001C13 RID: 7187 RVA: 0x0001B587 File Offset: 0x00019787
		// (set) Token: 0x06001C14 RID: 7188 RVA: 0x0001B593 File Offset: 0x00019793
		public float MinRebarClearSpacing
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<float>(ref this.#h, value, #Phc.#3hc(107407980));
			}
		}

		// Token: 0x170009EB RID: 2539
		// (get) Token: 0x06001C15 RID: 7189 RVA: 0x0001B5B9 File Offset: 0x000197B9
		// (set) Token: 0x06001C16 RID: 7190 RVA: 0x0001B5C5 File Offset: 0x000197C5
		public float DesignToRequiredRatio
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<float>(ref this.#i, value, #Phc.#3hc(107400118));
			}
		}

		// Token: 0x170009EC RID: 2540
		// (get) Token: 0x06001C17 RID: 7191 RVA: 0x0001B5EB File Offset: 0x000197EB
		// (set) Token: 0x06001C18 RID: 7192 RVA: 0x0001B5F7 File Offset: 0x000197F7
		public StructurePoint.Products.Column.Model.Entities.ReinforcementRatios ReinforcementRatios { get; set; }

		// Token: 0x170009ED RID: 2541
		// (get) Token: 0x06001C19 RID: 7193 RVA: 0x0001B608 File Offset: 0x00019808
		// (set) Token: 0x06001C1A RID: 7194 RVA: 0x0001B614 File Offset: 0x00019814
		public List<ShapeModel> Shapes { get; set; }

		// Token: 0x170009EE RID: 2542
		// (get) Token: 0x06001C1B RID: 7195 RVA: 0x0001B625 File Offset: 0x00019825
		// (set) Token: 0x06001C1C RID: 7196 RVA: 0x0001B631 File Offset: 0x00019831
		public List<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> ReinforcementBars { get; set; }

		// Token: 0x170009EF RID: 2543
		// (get) Token: 0x06001C1D RID: 7197 RVA: 0x0001B642 File Offset: 0x00019842
		// (set) Token: 0x06001C1E RID: 7198 RVA: 0x0001B64E File Offset: 0x0001984E
		public List<StructurePoint.Products.Column.Model.Entities.FactoredLoad> FactoredLoads { get; set; }

		// Token: 0x170009F0 RID: 2544
		// (get) Token: 0x06001C1F RID: 7199 RVA: 0x0001B65F File Offset: 0x0001985F
		// (set) Token: 0x06001C20 RID: 7200 RVA: 0x0001B66B File Offset: 0x0001986B
		public #X3 DesignedColumnX { get; set; }

		// Token: 0x170009F1 RID: 2545
		// (get) Token: 0x06001C21 RID: 7201 RVA: 0x0001B67C File Offset: 0x0001987C
		// (set) Token: 0x06001C22 RID: 7202 RVA: 0x0001B688 File Offset: 0x00019888
		public #X3 DesignedColumnY { get; set; }

		// Token: 0x170009F2 RID: 2546
		// (get) Token: 0x06001C23 RID: 7203 RVA: 0x0001B699 File Offset: 0x00019899
		// (set) Token: 0x06001C24 RID: 7204 RVA: 0x0001B6A5 File Offset: 0x000198A5
		public StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn ColumnAbove { get; set; }

		// Token: 0x170009F3 RID: 2547
		// (get) Token: 0x06001C25 RID: 7205 RVA: 0x0001B6B6 File Offset: 0x000198B6
		// (set) Token: 0x06001C26 RID: 7206 RVA: 0x0001B6C2 File Offset: 0x000198C2
		public StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn ColumnBelow { get; set; }

		// Token: 0x170009F4 RID: 2548
		// (get) Token: 0x06001C27 RID: 7207 RVA: 0x0001B6D3 File Offset: 0x000198D3
		// (set) Token: 0x06001C28 RID: 7208 RVA: 0x0001B6DF File Offset: 0x000198DF
		public float StiffnessX
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<float>(ref this.#d, value, #Phc.#3hc(107400089));
			}
		}

		// Token: 0x170009F5 RID: 2549
		// (get) Token: 0x06001C29 RID: 7209 RVA: 0x0001B705 File Offset: 0x00019905
		// (set) Token: 0x06001C2A RID: 7210 RVA: 0x0001B711 File Offset: 0x00019911
		public float StiffnessY
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<float>(ref this.#e, value, #Phc.#3hc(107400040));
			}
		}

		// Token: 0x170009F6 RID: 2550
		// (get) Token: 0x06001C2B RID: 7211 RVA: 0x0001B737 File Offset: 0x00019937
		// (set) Token: 0x06001C2C RID: 7212 RVA: 0x0001B743 File Offset: 0x00019943
		public #W3 BeamX { get; set; }

		// Token: 0x170009F7 RID: 2551
		// (get) Token: 0x06001C2D RID: 7213 RVA: 0x0001B754 File Offset: 0x00019954
		// (set) Token: 0x06001C2E RID: 7214 RVA: 0x0001B760 File Offset: 0x00019960
		public #W3 BeamY { get; set; }

		// Token: 0x170009F8 RID: 2552
		// (get) Token: 0x06001C2F RID: 7215 RVA: 0x0001B771 File Offset: 0x00019971
		// (set) Token: 0x06001C30 RID: 7216 RVA: 0x0001B77D File Offset: 0x0001997D
		public float StiffnessReductionFactorPhi
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<float>(ref this.#f, value, #Phc.#3hc(107412890));
			}
		}

		// Token: 0x170009F9 RID: 2553
		// (get) Token: 0x06001C31 RID: 7217 RVA: 0x0001B7A3 File Offset: 0x000199A3
		// (set) Token: 0x06001C32 RID: 7218 RVA: 0x0001B7AF File Offset: 0x000199AF
		public bool AreSlendenessFactorsCodeDefault
		{
			get
			{
				return this.#g;
			}
			set
			{
				this.SetProperty<bool>(ref this.#g, value, #Phc.#3hc(107400055));
			}
		}

		// Token: 0x170009FA RID: 2554
		// (get) Token: 0x06001C33 RID: 7219 RVA: 0x0001B7D5 File Offset: 0x000199D5
		// (set) Token: 0x06001C34 RID: 7220 RVA: 0x0001B7E1 File Offset: 0x000199E1
		public float CrackedIBeams
		{
			get
			{
				return this.#j;
			}
			set
			{
				this.SetProperty<float>(ref this.#j, value, #Phc.#3hc(107412853));
			}
		}

		// Token: 0x170009FB RID: 2555
		// (get) Token: 0x06001C35 RID: 7221 RVA: 0x0001B807 File Offset: 0x00019A07
		// (set) Token: 0x06001C36 RID: 7222 RVA: 0x0001B813 File Offset: 0x00019A13
		public float CrackedIColumn
		{
			get
			{
				return this.#k;
			}
			set
			{
				this.SetProperty<float>(ref this.#k, value, #Phc.#3hc(107412800));
			}
		}

		// Token: 0x170009FC RID: 2556
		// (get) Token: 0x06001C37 RID: 7223 RVA: 0x0001B839 File Offset: 0x00019A39
		// (set) Token: 0x06001C38 RID: 7224 RVA: 0x0001B845 File Offset: 0x00019A45
		public List<StructurePoint.Products.Column.Model.Entities.ServiceLoad> ServiceLoads { get; set; }

		// Token: 0x170009FD RID: 2557
		// (get) Token: 0x06001C39 RID: 7225 RVA: 0x0001B856 File Offset: 0x00019A56
		// (set) Token: 0x06001C3A RID: 7226 RVA: 0x0001B862 File Offset: 0x00019A62
		public List<StructurePoint.Products.Column.Model.Entities.LoadFactor> LoadFactors { get; set; }

		// Token: 0x170009FE RID: 2558
		// (get) Token: 0x06001C3B RID: 7227 RVA: 0x0001B873 File Offset: 0x00019A73
		// (set) Token: 0x06001C3C RID: 7228 RVA: 0x0001B87F File Offset: 0x00019A7F
		public BarGroupType BarGroupType { get; set; }

		// Token: 0x170009FF RID: 2559
		// (get) Token: 0x06001C3D RID: 7229 RVA: 0x0001B890 File Offset: 0x00019A90
		// (set) Token: 0x06001C3E RID: 7230 RVA: 0x0001B89C File Offset: 0x00019A9C
		public CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.StandardBar> Bars { get; set; }

		// Token: 0x17000A00 RID: 2560
		// (get) Token: 0x06001C3F RID: 7231 RVA: 0x0001B8AD File Offset: 0x00019AAD
		// (set) Token: 0x06001C40 RID: 7232 RVA: 0x0001B8B9 File Offset: 0x00019AB9
		public #Y3 SustainedLoadFactors { get; set; }

		// Token: 0x17000A01 RID: 2561
		// (get) Token: 0x06001C41 RID: 7233 RVA: 0x0001B8CA File Offset: 0x00019ACA
		// (set) Token: 0x06001C42 RID: 7234 RVA: 0x0001B8D6 File Offset: 0x00019AD6
		public #e7 DraftingSettings { get; set; }

		// Token: 0x17000A02 RID: 2562
		// (get) Token: 0x06001C43 RID: 7235 RVA: 0x0001B8E7 File Offset: 0x00019AE7
		public #4Z EndConditionCache { get; }

		// Token: 0x17000A03 RID: 2563
		// (get) Token: 0x06001C44 RID: 7236 RVA: 0x0001B8F3 File Offset: 0x00019AF3
		// (set) Token: 0x06001C45 RID: 7237 RVA: 0x0001B8FF File Offset: 0x00019AFF
		public List<StructurePoint.Products.Column.Model.Entities.AxialLoad> AxialLoads { get; set; }

		// Token: 0x17000A04 RID: 2564
		// (get) Token: 0x06001C46 RID: 7238 RVA: 0x0001B910 File Offset: 0x00019B10
		// (set) Token: 0x06001C47 RID: 7239 RVA: 0x0001B91C File Offset: 0x00019B1C
		public TemplateDataEntity TemplateData { get; private set; }

		// Token: 0x06001C48 RID: 7240 RVA: 0x000BFD84 File Offset: 0x000BDF84
		public #ice #BY()
		{
			return new #ice(this.Options.Unit, this.Options.SectionType, this.Options.ProblemType, this.Options.InvestigationLoad, this.Options.ConsideredAxis, this.Options.ConsiderSlenderness, this.Options.InvestigationReinforcement, this.Options.DesignReinforcement, this.Bars.Count - 1, this.Options.ReinforcementLayout, this.Options.Code, this.Options.DesignLoad, this.Options.ConfinementType, this.InvestigationDimensions, this.DesignDimensions);
		}

		// Token: 0x06001C49 RID: 7241 RVA: 0x000BFE54 File Offset: 0x000BE054
		public ColumnStorageModel #CY()
		{
			ColumnStorageModel columnStorageModel = new ColumnStorageModel();
			#E2 #E = this.IrregularOptions;
			IrregularOptions irregularOptions;
			if ((irregularOptions = ((#E != null) ? #E.#CY() : null)) == null)
			{
				irregularOptions = new IrregularOptions();
			}
			columnStorageModel.IrregularOptions = irregularOptions;
			#k3 #k = this.Options;
			Options options;
			if ((options = ((#k != null) ? #k.#CY() : null)) == null)
			{
				options = new Options();
			}
			columnStorageModel.Options = options;
			#T1 #T = this.InvestigationReinforcement;
			InvestigationReinforcement investigationReinforcement;
			if ((investigationReinforcement = ((#T != null) ? #T.#CY() : null)) == null)
			{
				investigationReinforcement = new InvestigationReinforcement();
			}
			columnStorageModel.InvestigationReinforcement = investigationReinforcement;
			#k1 #k2 = this.DesignReinforcement;
			columnStorageModel.DesignReinforcement = (((#k2 != null) ? #k2.#CY() : null) ?? new DesignReinforcement());
			StructurePoint.Products.Column.Model.Entities.ReductionFactors reductionFactors = this.ReductionFactors;
			columnStorageModel.ReductionFactors = (((reductionFactors != null) ? reductionFactors.#CY() : null) ?? new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReductionFactors());
			#f1 #f = this.DesignDimensions;
			columnStorageModel.DesignDimensions = (((#f != null) ? #f.#CY() : null) ?? new DesignDimensions());
			#Y3 #Y = this.SustainedLoadFactors;
			columnStorageModel.SustainedLoadFactors = (((#Y != null) ? #Y.#CY() : null) ?? new SustainedLoadFactors());
			columnStorageModel.Polygons = this.Shapes.Select(new Func<ShapeModel, SectionPolygon>(ColumnModel.<>c.<>9.#CZh)).ToList<SectionPolygon>();
			#K2 #K = this.MaterialProperties;
			columnStorageModel.MaterialProperties = (((#K != null) ? #K.#CY() : null) ?? new MaterialProperties());
			#Q1 #Q = this.InvestigationDimensions;
			columnStorageModel.InvestigationDimensions = (((#Q != null) ? #Q.#CY() : null) ?? new InvestigationDimensions());
			#r3 #r = this.ProjectInfo;
			columnStorageModel.ProjectInfo = (((#r != null) ? #r.#CY() : null) ?? new ProjectInfo());
			StructurePoint.Products.Column.Model.Entities.ReinforcementRatios reinforcementRatios = this.ReinforcementRatios;
			columnStorageModel.ReinforcementRatios = (((reinforcementRatios != null) ? reinforcementRatios.#CY() : null) ?? new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementRatios());
			#53 # = this.Ties;
			columnStorageModel.Ties = (((# != null) ? #.#CY() : null) ?? new Ties());
			columnStorageModel.BarGroupType = this.BarGroupType;
			columnStorageModel.Bars = this.Bars.Select(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar>(ColumnModel.<>c.<>9.#DZh)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar>();
			#W3 #W = this.BeamX;
			columnStorageModel.BeamX = (((#W != null) ? #W.#CY() : null) ?? new SlendernessOfBeams());
			#W3 #W2 = this.BeamY;
			columnStorageModel.BeamY = (((#W2 != null) ? #W2.#CY() : null) ?? new SlendernessOfBeams());
			StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn slendernessOfColumn = this.ColumnAbove;
			columnStorageModel.ColumnAbove = (((slendernessOfColumn != null) ? slendernessOfColumn.#CY() : null) ?? new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.SlendernessOfColumn());
			StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn slendernessOfColumn2 = this.ColumnBelow;
			columnStorageModel.ColumnBelow = (((slendernessOfColumn2 != null) ? slendernessOfColumn2.#CY() : null) ?? new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.SlendernessOfColumn());
			columnStorageModel.CrackedIColumn = this.CrackedIColumn;
			columnStorageModel.CrackedIBeams = this.CrackedIBeams;
			columnStorageModel.DesignInputFlag = (int)this.DesignInputFlag;
			columnStorageModel.SerializedModel = null;
			columnStorageModel.FactoredLoads = this.FactoredLoads.Select(new Func<StructurePoint.Products.Column.Model.Entities.FactoredLoad, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.FactoredLoad>(ColumnModel.<>c.<>9.#EZh)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.FactoredLoad>();
			columnStorageModel.ServiceLoads = this.ServiceLoads.Select(new Func<StructurePoint.Products.Column.Model.Entities.ServiceLoad, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ServiceLoad>(ColumnModel.<>c.<>9.#FZh)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ServiceLoad>();
			columnStorageModel.ReinforcementBars = this.ReinforcementBars.Where(new Func<StructurePoint.Products.Column.Model.Entities.ReinforcementBar, bool>(ColumnModel.<>c.<>9.#GZh)).Select(new Func<StructurePoint.Products.Column.Model.Entities.ReinforcementBar, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>(ColumnModel.<>c.<>9.#HZh)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>();
			columnStorageModel.DesignToRequiredRatio = this.DesignToRequiredRatio;
			columnStorageModel.MinRebarClearSpacing = this.MinRebarClearSpacing;
			#X3 #X = this.DesignedColumnY;
			columnStorageModel.DesignedColumnY = (((#X != null) ? #X.#CY() : null) ?? new SlendernessOfDesignedColumn());
			#X3 #X2 = this.DesignedColumnX;
			columnStorageModel.DesignedColumnX = (((#X2 != null) ? #X2.#CY() : null) ?? new SlendernessOfDesignedColumn());
			columnStorageModel.StiffnessReductionFactorPhi = this.StiffnessReductionFactorPhi;
			columnStorageModel.LoadFactors = this.LoadFactors.Select(new Func<StructurePoint.Products.Column.Model.Entities.LoadFactor, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.LoadFactor>(ColumnModel.<>c.<>9.#IZh)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.LoadFactor>();
			columnStorageModel.SlendernessInputFlag = (int)this.SlendernessInputFlag;
			columnStorageModel.InvestigateInputFlag = (int)this.InvestigateInputFlag;
			columnStorageModel.SlendernessOptFactor = (this.AreSlendenessFactorsCodeDefault ? 0 : 1);
			columnStorageModel.StiffnessX = this.StiffnessX;
			columnStorageModel.StiffnessY = this.StiffnessY;
			columnStorageModel.DraftingSettings = this.DraftingSettings.#CY();
			columnStorageModel.SectionTypeCacheItems = this.SectionTypeCacheItems.Select(new Func<SectionTypeDependentValuesCacheItem, SectionTypeDependentValuesCacheItem>(ColumnModel.<>c.<>9.#JZh)).ToList<SectionTypeDependentValuesCacheItem>();
			columnStorageModel.AxialLoads = this.AxialLoads.Select(new Func<StructurePoint.Products.Column.Model.Entities.AxialLoad, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.AxialLoad>(ColumnModel.<>c.<>9.#KZh)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.AxialLoad>();
			columnStorageModel.TemplateData = this.TemplateData.#CY();
			return columnStorageModel;
		}

		// Token: 0x06001C4A RID: 7242 RVA: 0x0001B92D File Offset: 0x00019B2D
		public void #DY(UnitSystem #Qg)
		{
			base.RaisePropertyChanging(#Phc.#3hc(107399978));
			this.Options.Unit = #Qg;
			base.RaisePropertyChanged(#Phc.#3hc(107399978));
		}

		// Token: 0x06001C4B RID: 7243 RVA: 0x0001B967 File Offset: 0x00019B67
		public void #EY(#ope #FY)
		{
			this.InvestigateInputFlag |= #FY;
		}

		// Token: 0x06001C4C RID: 7244 RVA: 0x0001B983 File Offset: 0x00019B83
		public void #GY(#ope #FY)
		{
			this.DesignInputFlag |= #FY;
		}

		// Token: 0x06001C4D RID: 7245 RVA: 0x0001B99F File Offset: 0x00019B9F
		public void #HY(#ope #FY)
		{
			if (this.Options.ProblemType == ProblemType.Design)
			{
				this.#GY(#FY);
				return;
			}
			if (this.Options.ProblemType == ProblemType.Investigation)
			{
				this.#EY(#FY);
			}
		}

		// Token: 0x06001C4E RID: 7246 RVA: 0x000C0364 File Offset: 0x000BE564
		public bool #IY()
		{
			SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem = this.SectionTypeCacheItems.FirstOrDefault(new Func<SectionTypeDependentValuesCacheItem, bool>(ColumnModel.<>c.<>9.#LZh));
			object obj;
			if (sectionTypeDependentValuesCacheItem == null)
			{
				obj = null;
			}
			else
			{
				TemplateData templateData = sectionTypeDependentValuesCacheItem.TemplateData;
				obj = ((templateData != null) ? templateData.Definition : null);
			}
			return obj != null;
		}

		// Token: 0x06001C4F RID: 7247 RVA: 0x000C03C4 File Offset: 0x000BE5C4
		public bool #JY(SectionType #KY, bool #LY = true)
		{
			ColumnModel.#NYh #NYh = new ColumnModel.#NYh();
			#NYh.#c = #KY;
			#NYh.#a = this.Options.SectionType;
			#NYh.#b = this.Options.ProblemType;
			this.SectionTypeCacheItems.RemoveAll(new Predicate<SectionTypeDependentValuesCacheItem>(#NYh.#Y2b));
			this.SectionTypeCacheItems.Add(this.#NY());
			this.Options.PreviousSectionType = #NYh.#a;
			SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem = this.SectionTypeCacheItems.FirstOrDefault(new Func<SectionTypeDependentValuesCacheItem, bool>(#NYh.#Z2b));
			if (sectionTypeDependentValuesCacheItem != null)
			{
				if (#LY)
				{
					this.#MY(sectionTypeDependentValuesCacheItem);
				}
				return true;
			}
			SectionType sectionType = #NYh.#c;
			if (sectionType > SectionType.Circle)
			{
				if (sectionType == SectionType.Irregular)
				{
					this.ReinforcementBars.Clear();
					this.Shapes.Clear();
				}
			}
			else
			{
				this.ReinforcementBars.Clear();
				this.Shapes.Clear();
				if (#NYh.#b == ProblemType.Investigation)
				{
					if (this.Options.InvestigationReinforcement == ReinforcementType.Undefined || this.Options.InvestigationReinforcement == ReinforcementType.Irregular || #NYh.#c == SectionType.Circle)
					{
						this.Options.InvestigationReinforcement = ReinforcementType.AllEqual;
					}
				}
				else if (this.Options.DesignReinforcement == ReinforcementType.Undefined || this.Options.DesignReinforcement == ReinforcementType.Irregular || #NYh.#c == SectionType.Circle)
				{
					this.Options.DesignReinforcement = ReinforcementType.AllEqual;
				}
				if (#NYh.#c == SectionType.Circle)
				{
					this.Options.ReinforcementLayout = ReinforcementLayout.Circle;
				}
			}
			return false;
		}

		// Token: 0x06001C50 RID: 7248 RVA: 0x000C0544 File Offset: 0x000BE744
		public void #3O()
		{
			List<ShapeModel> source = this.Shapes.Where(new Func<ShapeModel, bool>(ColumnModel.<>c.<>9.#MZh)).ToList<ShapeModel>();
			List<ShapeModel> source2 = this.Shapes.Where(new Func<ShapeModel, bool>(ColumnModel.<>c.<>9.#NZh)).ToList<ShapeModel>();
			int num;
			if (!source.Any<ShapeModel>())
			{
				num = 1;
			}
			else
			{
				num = source.Max(new Func<ShapeModel, int>(ColumnModel.<>c.<>9.#OZh)) + 1;
			}
			int num2 = num;
			int num3;
			if (!source2.Any<ShapeModel>())
			{
				num3 = 1;
			}
			else
			{
				num3 = source2.Max(new Func<ShapeModel, int>(ColumnModel.<>c.<>9.#PZh)) + 1;
			}
			int num4 = num3;
			foreach (ShapeModel shapeModel in this.Shapes)
			{
				if (shapeModel.Application == PolygonApplication.Solid && shapeModel.Id <= 0)
				{
					shapeModel.Id = num2++;
				}
				else if (shapeModel.Application == PolygonApplication.Opening && shapeModel.Id <= 0)
				{
					shapeModel.Id = num4++;
				}
			}
		}

		// Token: 0x06001C51 RID: 7249 RVA: 0x000C06B8 File Offset: 0x000BE8B8
		public bool #gVh()
		{
			List<int> list = this.Shapes.Where(new Func<ShapeModel, bool>(ColumnModel.<>c.<>9.#QZh)).Select(new Func<ShapeModel, int>(ColumnModel.<>c.<>9.#RZh)).ToList<int>();
			if (list.Count != list.Distinct<int>().Count<int>())
			{
				return false;
			}
			list = this.Shapes.Where(new Func<ShapeModel, bool>(ColumnModel.<>c.<>9.#SZh)).Select(new Func<ShapeModel, int>(ColumnModel.<>c.<>9.#TZh)).ToList<int>();
			return list.Count == list.Distinct<int>().Count<int>();
		}

		// Token: 0x06001C52 RID: 7250 RVA: 0x000C07B8 File Offset: 0x000BE9B8
		public bool #hVh()
		{
			List<ShapeModel> list = this.Shapes.Where(new Func<ShapeModel, bool>(ColumnModel.<>c.<>9.#VZh)).OrderBy(new Func<ShapeModel, int>(ColumnModel.<>c.<>9.#WZh)).ToList<ShapeModel>();
			list = list.OrderBy(new Func<ShapeModel, bool>(ColumnModel.<>c.<>9.#XZh)).ToList<ShapeModel>();
			List<ShapeModel> list2 = this.Shapes.Where(new Func<ShapeModel, bool>(ColumnModel.<>c.<>9.#YZh)).OrderBy(new Func<ShapeModel, int>(ColumnModel.<>c.<>9.#ZZh)).ToList<ShapeModel>();
			list2 = list2.OrderBy(new Func<ShapeModel, bool>(ColumnModel.<>c.<>9.#0Zh)).ToList<ShapeModel>();
			bool result = false;
			if (!ColumnModel.#iVh(list))
			{
				ColumnModel.#jVh(list);
				result = true;
			}
			if (!ColumnModel.#iVh(list2))
			{
				ColumnModel.#jVh(list2);
				result = true;
			}
			return result;
		}

		// Token: 0x06001C53 RID: 7251 RVA: 0x000C0904 File Offset: 0x000BEB04
		public void #1Uh(ShapeModel #rP)
		{
			ColumnModel.#4Zh #4Zh = new ColumnModel.#4Zh();
			#4Zh.#a = #rP;
			List<ShapeModel> source = this.Shapes.Where(new Func<ShapeModel, bool>(#4Zh.#3Zh)).ToList<ShapeModel>();
			ShapeModel shapeModel = #4Zh.#a;
			int num;
			if (!source.Any<ShapeModel>())
			{
				num = 1;
			}
			else
			{
				num = source.Max(new Func<ShapeModel, int>(ColumnModel.<>c.<>9.#1Zh)) + 1;
			}
			shapeModel.Id = num;
			this.#hVh();
		}

		// Token: 0x06001C54 RID: 7252 RVA: 0x000C099C File Offset: 0x000BEB9C
		private void #MY(SectionTypeDependentValuesCacheItem #Rf)
		{
			List<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> list = this.ReinforcementBars;
			if (true)
			{
				list.Clear();
			}
			this.ReinforcementBars.AddRange(#Rf.Bars.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar, StructurePoint.Products.Column.Model.Entities.ReinforcementBar>(ColumnModel.<>c.<>9.#U2b)));
			this.Shapes.Clear();
			this.Shapes.AddRange(#Rf.Polygons.Select(new Func<SectionPolygon, ShapeModel>(ColumnModel.<>c.<>9.#V2b)));
			this.Options.InvestigationReinforcement = #Rf.InvestigationReinforcementType;
			this.TemplateData = new TemplateDataEntity(#Rf.TemplateData);
			if (#Rf.SectionOnly)
			{
				return;
			}
			this.Options.DesignReinforcement = #Rf.DesignReinforcementType;
			this.Options.DesignClearCover = #Rf.DesignCoverType;
			this.Options.InvestigationClearCover = #Rf.InvestigationCoverType;
			this.DesignDimensions = new #f1(#Rf.DesignDimensions);
			this.InvestigationDimensions = new #Q1(#Rf.InvestigationDimensions);
			if (#Rf.SectionType == SectionType.Rectangle)
			{
				this.Options.ReinforcementLayout = ReinforcementLayout.Rectangle;
			}
			else if (#Rf.SectionType == SectionType.Circle)
			{
				this.Options.ReinforcementLayout = ReinforcementLayout.Circle;
			}
			this.InvestigationReinforcement = new #T1(new InvestigationReinforcement(#Rf.InvestigationReinforcement)
			{
				AllEqual = this.InvestigationReinforcement.AllEqual.#CY()
			});
			this.DesignReinforcement = new #k1(new DesignReinforcement(#Rf.DesignReinforcement)
			{
				AllEqual = this.DesignReinforcement.AllEqual.#CY()
			});
			this.Ties = new #53(#Rf.Ties);
		}

		// Token: 0x06001C55 RID: 7253 RVA: 0x000C0B64 File Offset: 0x000BED64
		private SectionTypeDependentValuesCacheItem #NY()
		{
			SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem = new SectionTypeDependentValuesCacheItem();
			sectionTypeDependentValuesCacheItem.Bars = this.ReinforcementBars.Select(new Func<StructurePoint.Products.Column.Model.Entities.ReinforcementBar, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>(ColumnModel.<>c.<>9.#W2b)).ToList<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>();
			sectionTypeDependentValuesCacheItem.SectionType = this.Options.SectionType;
			sectionTypeDependentValuesCacheItem.ReinforcementLayout = this.Options.ReinforcementLayout;
			sectionTypeDependentValuesCacheItem.DesignReinforcementType = this.Options.DesignReinforcement;
			sectionTypeDependentValuesCacheItem.InvestigationReinforcementType = this.Options.InvestigationReinforcement;
			sectionTypeDependentValuesCacheItem.ProblemType = this.Options.ProblemType;
			sectionTypeDependentValuesCacheItem.DesignReinforcement = this.DesignReinforcement.#CY();
			sectionTypeDependentValuesCacheItem.InvestigationDimensions = this.InvestigationDimensions.#CY();
			sectionTypeDependentValuesCacheItem.DesignDimensions = this.DesignDimensions.#CY();
			sectionTypeDependentValuesCacheItem.InvestigationReinforcement = this.InvestigationReinforcement.#CY();
			sectionTypeDependentValuesCacheItem.InvestigationCoverType = this.Options.InvestigationClearCover;
			sectionTypeDependentValuesCacheItem.DesignCoverType = this.Options.DesignClearCover;
			sectionTypeDependentValuesCacheItem.Ties = this.Ties.#CY();
			sectionTypeDependentValuesCacheItem.Polygons = this.Shapes.Select(new Func<ShapeModel, SectionPolygon>(ColumnModel.<>c.<>9.#X2b)).ToList<SectionPolygon>();
			sectionTypeDependentValuesCacheItem.TemplateData = this.TemplateData.#CY();
			return sectionTypeDependentValuesCacheItem;
		}

		// Token: 0x06001C56 RID: 7254 RVA: 0x000C0CDC File Offset: 0x000BEEDC
		[CompilerGenerated]
		internal static bool #iVh(IList<ShapeModel> #8f)
		{
			if (!#8f.Any<ShapeModel>())
			{
				return true;
			}
			List<int> list = #8f.Select(new Func<ShapeModel, int>(ColumnModel.<>c.<>9.#UZh)).Distinct<int>().ToList<int>();
			return list.Count == #8f.Count && list[0] == 1 && list.Last<int>() == list.Count;
		}

		// Token: 0x06001C57 RID: 7255 RVA: 0x000C0D58 File Offset: 0x000BEF58
		[CompilerGenerated]
		internal static void #jVh(IList<ShapeModel> #8f)
		{
			ColumnModel.#02b #02b = new ColumnModel.#02b();
			#02b.#a = 1;
			#8f.#I1d(new Action<ShapeModel>(#02b.#2Zh));
		}

		// Token: 0x04000B08 RID: 2824
		private #ope #a;

		// Token: 0x04000B09 RID: 2825
		private #ope #b;

		// Token: 0x04000B0A RID: 2826
		private #ppe #c;

		// Token: 0x04000B0B RID: 2827
		private float #d;

		// Token: 0x04000B0C RID: 2828
		private float #e;

		// Token: 0x04000B0D RID: 2829
		private float #f;

		// Token: 0x04000B0E RID: 2830
		private bool #g;

		// Token: 0x04000B0F RID: 2831
		private float #h;

		// Token: 0x04000B10 RID: 2832
		private float #i;

		// Token: 0x04000B11 RID: 2833
		private float #j;

		// Token: 0x04000B12 RID: 2834
		private float #k;

		// Token: 0x04000B13 RID: 2835
		private #Q1 #l;

		// Token: 0x04000B14 RID: 2836
		private #k1 #m;

		// Token: 0x04000B15 RID: 2837
		private #T1 #n;

		// Token: 0x04000B16 RID: 2838
		private #f1 #o;

		// Token: 0x04000B17 RID: 2839
		[CompilerGenerated]
		private #r3 #p;

		// Token: 0x04000B18 RID: 2840
		[CompilerGenerated]
		private readonly List<SectionTypeDependentValuesCacheItem> #q = new List<SectionTypeDependentValuesCacheItem>();

		// Token: 0x04000B19 RID: 2841
		[CompilerGenerated]
		private #k3 #r;

		// Token: 0x04000B1A RID: 2842
		[CompilerGenerated]
		private #E2 #s;

		// Token: 0x04000B1B RID: 2843
		[CompilerGenerated]
		private readonly UnitValueGroups #t;

		// Token: 0x04000B1C RID: 2844
		[CompilerGenerated]
		private readonly UnitValueGroups #u;

		// Token: 0x04000B1D RID: 2845
		[CompilerGenerated]
		private #53 #v;

		// Token: 0x04000B1E RID: 2846
		[CompilerGenerated]
		private #K2 #w;

		// Token: 0x04000B1F RID: 2847
		[CompilerGenerated]
		private StructurePoint.Products.Column.Model.Entities.ReductionFactors #x;

		// Token: 0x04000B20 RID: 2848
		[CompilerGenerated]
		private StructurePoint.Products.Column.Model.Entities.ReinforcementRatios #y;

		// Token: 0x04000B21 RID: 2849
		[CompilerGenerated]
		private List<ShapeModel> #z;

		// Token: 0x04000B22 RID: 2850
		[CompilerGenerated]
		private List<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #A;

		// Token: 0x04000B23 RID: 2851
		[CompilerGenerated]
		private List<StructurePoint.Products.Column.Model.Entities.FactoredLoad> #B;

		// Token: 0x04000B24 RID: 2852
		[CompilerGenerated]
		private #X3 #C;

		// Token: 0x04000B25 RID: 2853
		[CompilerGenerated]
		private #X3 #D;

		// Token: 0x04000B26 RID: 2854
		[CompilerGenerated]
		private StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn #E;

		// Token: 0x04000B27 RID: 2855
		[CompilerGenerated]
		private StructurePoint.Products.Column.Model.Entities.SlendernessOfColumn #F;

		// Token: 0x04000B28 RID: 2856
		[CompilerGenerated]
		private #W3 #G;

		// Token: 0x04000B29 RID: 2857
		[CompilerGenerated]
		private #W3 #H;

		// Token: 0x04000B2A RID: 2858
		[CompilerGenerated]
		private List<StructurePoint.Products.Column.Model.Entities.ServiceLoad> #I;

		// Token: 0x04000B2B RID: 2859
		[CompilerGenerated]
		private List<StructurePoint.Products.Column.Model.Entities.LoadFactor> #J;

		// Token: 0x04000B2C RID: 2860
		[CompilerGenerated]
		private BarGroupType #K;

		// Token: 0x04000B2D RID: 2861
		[CompilerGenerated]
		private CustomObservableCollection<StructurePoint.Products.Column.Model.Entities.StandardBar> #L;

		// Token: 0x04000B2E RID: 2862
		[CompilerGenerated]
		private #Y3 #M;

		// Token: 0x04000B2F RID: 2863
		[CompilerGenerated]
		private #e7 #N;

		// Token: 0x04000B30 RID: 2864
		[CompilerGenerated]
		private readonly #4Z #O = new #4Z();

		// Token: 0x04000B31 RID: 2865
		[CompilerGenerated]
		private List<StructurePoint.Products.Column.Model.Entities.AxialLoad> #P;

		// Token: 0x04000B32 RID: 2866
		[CompilerGenerated]
		private TemplateDataEntity #Q;

		// Token: 0x0200032C RID: 812
		[CompilerGenerated]
		private sealed class #NYh
		{
			// Token: 0x06001C82 RID: 7298 RVA: 0x0001BA82 File Offset: 0x00019C82
			internal bool #Y2b(SectionTypeDependentValuesCacheItem #Rf)
			{
				return #Rf.SectionType == this.#a && #Rf.ProblemType == this.#b;
			}

			// Token: 0x06001C83 RID: 7299 RVA: 0x0001BAAE File Offset: 0x00019CAE
			internal bool #Z2b(SectionTypeDependentValuesCacheItem #Rf)
			{
				return #Rf.SectionType == this.#c && #Rf.ProblemType == this.#b;
			}

			// Token: 0x04000B5B RID: 2907
			public SectionType #a;

			// Token: 0x04000B5C RID: 2908
			public ProblemType #b;

			// Token: 0x04000B5D RID: 2909
			public SectionType #c;
		}

		// Token: 0x0200032D RID: 813
		[CompilerGenerated]
		private sealed class #02b
		{
			// Token: 0x06001C85 RID: 7301 RVA: 0x000C0D90 File Offset: 0x000BEF90
			internal void #2Zh(ShapeModel #bF)
			{
				int num = this.#a;
				this.#a = num + 1;
				#bF.Id = num;
			}

			// Token: 0x04000B5E RID: 2910
			public int #a;
		}

		// Token: 0x0200032E RID: 814
		[CompilerGenerated]
		private sealed class #4Zh
		{
			// Token: 0x06001C87 RID: 7303 RVA: 0x0001BADA File Offset: 0x00019CDA
			internal bool #3Zh(ShapeModel #bF)
			{
				return #bF != this.#a && #bF.Application == this.#a.Application;
			}

			// Token: 0x04000B5F RID: 2911
			public ShapeModel #a;
		}
	}
}
