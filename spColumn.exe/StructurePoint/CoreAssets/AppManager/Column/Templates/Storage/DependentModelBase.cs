using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using #Cfe;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x02001069 RID: 4201
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public abstract class DependentModelBase : #Bfe, #Dfe, #Efe
	{
		// Token: 0x06008FA0 RID: 36768 RVA: 0x00074141 File Offset: 0x00072341
		protected DependentModelBase()
		{
		}

		// Token: 0x06008FA1 RID: 36769 RVA: 0x0007415B File Offset: 0x0007235B
		protected DependentModelBase(UnitSystemSpecs unitSystems)
		{
			this.UnitSystems = unitSystems;
		}

		// Token: 0x06008FA2 RID: 36770 RVA: 0x0007417C File Offset: 0x0007237C
		protected DependentModelBase(DesignCodeSpecs designCodes, UnitSystemSpecs unitSystems)
		{
			this.DesignCodes = designCodes;
			this.UnitSystems = unitSystems;
		}

		// Token: 0x170029C9 RID: 10697
		// (get) Token: 0x06008FA3 RID: 36771 RVA: 0x000741A4 File Offset: 0x000723A4
		// (set) Token: 0x06008FA4 RID: 36772 RVA: 0x000741AC File Offset: 0x000723AC
		[XmlIgnore]
		[IgnoreDataMember]
		public DesignCodeSpecs DesignCodes { get; set; } = DesignCodeSpecs.All;

		// Token: 0x170029CA RID: 10698
		// (get) Token: 0x06008FA5 RID: 36773 RVA: 0x000741B5 File Offset: 0x000723B5
		// (set) Token: 0x06008FA6 RID: 36774 RVA: 0x000741BD File Offset: 0x000723BD
		[XmlAttribute("ForUnitSystems")]
		[DataMember(Name = "ForUnitSystems", Order = 1)]
		public UnitSystemSpecs UnitSystems { get; set; } = UnitSystemSpecs.All;

		// Token: 0x06008FA7 RID: 36775 RVA: 0x000741C6 File Offset: 0x000723C6
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			this.DesignCodes = DesignCodeSpecs.All;
		}
	}
}
