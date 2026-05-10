using System;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Documentation
{
	// Token: 0x020010A8 RID: 4264
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates/Documentation")]
	public sealed class ParameterDocumentation
	{
		// Token: 0x0600917A RID: 37242 RVA: 0x00075327 File Offset: 0x00073527
		public ParameterDocumentation(string name, string description)
		{
			this.Name = name;
			this.Description.Value = description;
		}

		// Token: 0x0600917B RID: 37243 RVA: 0x0007534D File Offset: 0x0007354D
		public ParameterDocumentation()
		{
		}

		// Token: 0x17002A59 RID: 10841
		// (get) Token: 0x0600917C RID: 37244 RVA: 0x00075360 File Offset: 0x00073560
		// (set) Token: 0x0600917D RID: 37245 RVA: 0x00075368 File Offset: 0x00073568
		[XmlAttribute]
		public string Name { get; set; }

		// Token: 0x17002A5A RID: 10842
		// (get) Token: 0x0600917E RID: 37246 RVA: 0x00075371 File Offset: 0x00073571
		// (set) Token: 0x0600917F RID: 37247 RVA: 0x00075379 File Offset: 0x00073579
		[XmlElement]
		public DescriptionItem Description { get; set; } = new DescriptionItem();
	}
}
