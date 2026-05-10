using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x0200111A RID: 4378
	[DataContract(Name = "SectionTypeDependentValuesCacheItem", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class SectionTypeDependentValuesCacheItem
	{
		// Token: 0x0600943C RID: 37948 RVA: 0x000035C3 File Offset: 0x000017C3
		public SectionTypeDependentValuesCacheItem()
		{
		}

		// Token: 0x0600943D RID: 37949 RVA: 0x001FA418 File Offset: 0x001F8618
		public SectionTypeDependentValuesCacheItem(SectionTypeDependentValuesCacheItem other)
		{
			this.Polygons = new List<SectionPolygon>(from p in other.Polygons
			select new SectionPolygon(p));
			this.Bars = (from b in other.Bars
			select new ReinforcementBar(b)).ToList<ReinforcementBar>();
			this.SectionOnly = other.SectionOnly;
			this.SectionType = other.SectionType;
			this.ProblemType = other.ProblemType;
			this.InvestigationReinforcementType = other.InvestigationReinforcementType;
			this.TemplateData = ((other.TemplateData != null) ? new TemplateData(other.TemplateData) : new TemplateData());
			if (other.SectionOnly)
			{
				return;
			}
			this.ReinforcementLayout = other.ReinforcementLayout;
			this.DesignReinforcementType = other.DesignReinforcementType;
			this.InvestigationReinforcement = new InvestigationReinforcement(other.InvestigationReinforcement);
			this.DesignReinforcement = new DesignReinforcement(other.DesignReinforcement);
			this.InvestigationDimensions = new InvestigationDimensions(other.InvestigationDimensions);
			this.DesignDimensions = new DesignDimensions(other.DesignDimensions);
			this.DesignCoverType = other.DesignCoverType;
			this.InvestigationCoverType = other.InvestigationCoverType;
			this.Ties = new Ties(other.Ties);
		}

		// Token: 0x17002AB5 RID: 10933
		// (get) Token: 0x0600943E RID: 37950 RVA: 0x00076688 File Offset: 0x00074888
		// (set) Token: 0x0600943F RID: 37951 RVA: 0x00076690 File Offset: 0x00074890
		[DataMember(Name = "DesignCoverType", Order = 10)]
		public ClearCoverType DesignCoverType { get; set; }

		// Token: 0x17002AB6 RID: 10934
		// (get) Token: 0x06009440 RID: 37952 RVA: 0x00076699 File Offset: 0x00074899
		// (set) Token: 0x06009441 RID: 37953 RVA: 0x000766A1 File Offset: 0x000748A1
		[DataMember(Name = "InvestigationCoverType", Order = 20)]
		public ClearCoverType InvestigationCoverType { get; set; }

		// Token: 0x17002AB7 RID: 10935
		// (get) Token: 0x06009442 RID: 37954 RVA: 0x000766AA File Offset: 0x000748AA
		// (set) Token: 0x06009443 RID: 37955 RVA: 0x000766B2 File Offset: 0x000748B2
		[DataMember(Name = "DesignReinforcementType", Order = 30)]
		public ReinforcementType DesignReinforcementType { get; set; }

		// Token: 0x17002AB8 RID: 10936
		// (get) Token: 0x06009444 RID: 37956 RVA: 0x000766BB File Offset: 0x000748BB
		// (set) Token: 0x06009445 RID: 37957 RVA: 0x000766C3 File Offset: 0x000748C3
		[DataMember(Name = "InvestigationReinforcementType", Order = 40)]
		public ReinforcementType InvestigationReinforcementType { get; set; }

		// Token: 0x17002AB9 RID: 10937
		// (get) Token: 0x06009446 RID: 37958 RVA: 0x000766CC File Offset: 0x000748CC
		// (set) Token: 0x06009447 RID: 37959 RVA: 0x000766D4 File Offset: 0x000748D4
		[DataMember(Name = "Bars", Order = 50)]
		public List<ReinforcementBar> Bars { get; set; }

		// Token: 0x17002ABA RID: 10938
		// (get) Token: 0x06009448 RID: 37960 RVA: 0x000766DD File Offset: 0x000748DD
		// (set) Token: 0x06009449 RID: 37961 RVA: 0x000766E5 File Offset: 0x000748E5
		[DataMember(Name = "SectionType", Order = 60)]
		public SectionType SectionType { get; set; }

		// Token: 0x17002ABB RID: 10939
		// (get) Token: 0x0600944A RID: 37962 RVA: 0x000766EE File Offset: 0x000748EE
		// (set) Token: 0x0600944B RID: 37963 RVA: 0x000766F6 File Offset: 0x000748F6
		[DataMember(Name = "ProblemType", Order = 70)]
		public ProblemType ProblemType { get; set; }

		// Token: 0x17002ABC RID: 10940
		// (get) Token: 0x0600944C RID: 37964 RVA: 0x000766FF File Offset: 0x000748FF
		// (set) Token: 0x0600944D RID: 37965 RVA: 0x00076707 File Offset: 0x00074907
		[DataMember(Name = "ReinforcementLayout", Order = 80)]
		public ReinforcementLayout ReinforcementLayout { get; set; }

		// Token: 0x17002ABD RID: 10941
		// (get) Token: 0x0600944E RID: 37966 RVA: 0x00076710 File Offset: 0x00074910
		// (set) Token: 0x0600944F RID: 37967 RVA: 0x00076718 File Offset: 0x00074918
		[DataMember(Name = "InvestigationReinforcement", Order = 90)]
		public InvestigationReinforcement InvestigationReinforcement { get; set; }

		// Token: 0x17002ABE RID: 10942
		// (get) Token: 0x06009450 RID: 37968 RVA: 0x00076721 File Offset: 0x00074921
		// (set) Token: 0x06009451 RID: 37969 RVA: 0x00076729 File Offset: 0x00074929
		[DataMember(Name = "Polygons", Order = 100)]
		public List<SectionPolygon> Polygons { get; set; }

		// Token: 0x17002ABF RID: 10943
		// (get) Token: 0x06009452 RID: 37970 RVA: 0x00076732 File Offset: 0x00074932
		// (set) Token: 0x06009453 RID: 37971 RVA: 0x0007673A File Offset: 0x0007493A
		[DataMember(Name = "DesignReinforcement", Order = 110)]
		public DesignReinforcement DesignReinforcement { get; set; }

		// Token: 0x17002AC0 RID: 10944
		// (get) Token: 0x06009454 RID: 37972 RVA: 0x00076743 File Offset: 0x00074943
		// (set) Token: 0x06009455 RID: 37973 RVA: 0x0007674B File Offset: 0x0007494B
		[DataMember(Name = "InvestigationDimensions", Order = 120)]
		public InvestigationDimensions InvestigationDimensions { get; set; }

		// Token: 0x17002AC1 RID: 10945
		// (get) Token: 0x06009456 RID: 37974 RVA: 0x00076754 File Offset: 0x00074954
		// (set) Token: 0x06009457 RID: 37975 RVA: 0x0007675C File Offset: 0x0007495C
		[DataMember(Name = "DesignDimensions", Order = 130)]
		public DesignDimensions DesignDimensions { get; set; }

		// Token: 0x17002AC2 RID: 10946
		// (get) Token: 0x06009458 RID: 37976 RVA: 0x00076765 File Offset: 0x00074965
		// (set) Token: 0x06009459 RID: 37977 RVA: 0x0007676D File Offset: 0x0007496D
		[DataMember(Name = "Ties", Order = 140)]
		public Ties Ties { get; set; }

		// Token: 0x17002AC3 RID: 10947
		// (get) Token: 0x0600945A RID: 37978 RVA: 0x00076776 File Offset: 0x00074976
		// (set) Token: 0x0600945B RID: 37979 RVA: 0x0007677E File Offset: 0x0007497E
		[DataMember(Name = "SectionOnly", Order = 150)]
		public bool SectionOnly { get; set; }

		// Token: 0x17002AC4 RID: 10948
		// (get) Token: 0x0600945C RID: 37980 RVA: 0x00076787 File Offset: 0x00074987
		// (set) Token: 0x0600945D RID: 37981 RVA: 0x0007678F File Offset: 0x0007498F
		[DataMember(Name = "TemplateData", Order = 160)]
		public TemplateData TemplateData { get; set; }

		// Token: 0x0600945E RID: 37982 RVA: 0x00076798 File Offset: 0x00074998
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			if (this.TemplateData == null)
			{
				this.TemplateData = new TemplateData();
			}
		}
	}
}
