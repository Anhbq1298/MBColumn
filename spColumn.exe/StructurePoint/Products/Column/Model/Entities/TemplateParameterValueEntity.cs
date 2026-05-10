using System;
using System.Runtime.CompilerServices;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x02000392 RID: 914
	internal sealed class TemplateParameterValueEntity : NotifyPropertyChangedObjectBase, #cqe
	{
		// Token: 0x06001DB3 RID: 7603 RVA: 0x0001C854 File Offset: 0x0001AA54
		public TemplateParameterValueEntity(TemplateParameterValue other)
		{
			this.Key = other.Key;
			this.Value = other.Value;
		}

		// Token: 0x06001DB4 RID: 7604 RVA: 0x0001C874 File Offset: 0x0001AA74
		public TemplateParameterValueEntity(string key, string value)
		{
			this.Key = key;
			this.Value = value;
		}

		// Token: 0x06001DB5 RID: 7605 RVA: 0x0000C5B9 File Offset: 0x0000A7B9
		public TemplateParameterValueEntity()
		{
		}

		// Token: 0x17000A56 RID: 2646
		// (get) Token: 0x06001DB6 RID: 7606 RVA: 0x0001C88A File Offset: 0x0001AA8A
		// (set) Token: 0x06001DB7 RID: 7607 RVA: 0x0001C896 File Offset: 0x0001AA96
		public string Key { get; set; }

		// Token: 0x17000A57 RID: 2647
		// (get) Token: 0x06001DB8 RID: 7608 RVA: 0x0001C8A7 File Offset: 0x0001AAA7
		// (set) Token: 0x06001DB9 RID: 7609 RVA: 0x0001C8B3 File Offset: 0x0001AAB3
		public string Value { get; set; }

		// Token: 0x06001DBA RID: 7610 RVA: 0x0001C8C4 File Offset: 0x0001AAC4
		public TemplateParameterValue #CY()
		{
			return new TemplateParameterValue(this.Key, this.Value);
		}

		// Token: 0x04000BD6 RID: 3030
		[CompilerGenerated]
		private string #a;

		// Token: 0x04000BD7 RID: 3031
		[CompilerGenerated]
		private string #b;
	}
}
