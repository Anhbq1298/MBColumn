using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Documentation
{
	// Token: 0x020010A7 RID: 4263
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates/Documentation")]
	public sealed class MemberDocumentation
	{
		// Token: 0x0600916F RID: 37231 RVA: 0x001ECD58 File Offset: 0x001EAF58
		public MemberDocumentation(MemberType memberType, string name, string description, params ParameterDocumentation[] parameters)
		{
			this.MemberType = memberType;
			this.Name = name;
			this.Description = description;
			if (parameters != null)
			{
				this.Parameters.AddRange(parameters);
			}
		}

		// Token: 0x06009170 RID: 37232 RVA: 0x000752BD File Offset: 0x000734BD
		public MemberDocumentation()
		{
		}

		// Token: 0x17002A54 RID: 10836
		// (get) Token: 0x06009171 RID: 37233 RVA: 0x000752DB File Offset: 0x000734DB
		// (set) Token: 0x06009172 RID: 37234 RVA: 0x000752E3 File Offset: 0x000734E3
		[XmlAttribute]
		public MemberType MemberType { get; set; }

		// Token: 0x17002A55 RID: 10837
		// (get) Token: 0x06009173 RID: 37235 RVA: 0x000752EC File Offset: 0x000734EC
		// (set) Token: 0x06009174 RID: 37236 RVA: 0x000752F4 File Offset: 0x000734F4
		[XmlAttribute]
		public string Name { get; set; }

		// Token: 0x17002A56 RID: 10838
		// (get) Token: 0x06009175 RID: 37237 RVA: 0x000752FD File Offset: 0x000734FD
		// (set) Token: 0x06009176 RID: 37238 RVA: 0x00075305 File Offset: 0x00073505
		[XmlElement]
		public DescriptionItem Description { get; set; } = new DescriptionItem();

		// Token: 0x17002A57 RID: 10839
		// (get) Token: 0x06009177 RID: 37239 RVA: 0x0007530E File Offset: 0x0007350E
		[XmlArrayItem("Parameter")]
		[XmlArray]
		public List<ParameterDocumentation> Parameters { get; } = new List<ParameterDocumentation>();

		// Token: 0x17002A58 RID: 10840
		// (get) Token: 0x06009178 RID: 37240 RVA: 0x00075316 File Offset: 0x00073516
		// (set) Token: 0x06009179 RID: 37241 RVA: 0x0007531E File Offset: 0x0007351E
		[XmlElement]
		public DescriptionItem ResultDescription { get; set; }
	}
}
