using System;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.DataExchange.CSV
{
	// Token: 0x02000784 RID: 1924
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class CSVColumnNameAttribute : Attribute
	{
		// Token: 0x06003DED RID: 15853 RVA: 0x00034EF5 File Offset: 0x000330F5
		public CSVColumnNameAttribute(string name)
		{
			this.Name = name;
		}

		// Token: 0x170012DF RID: 4831
		// (get) Token: 0x06003DEE RID: 15854 RVA: 0x00034F04 File Offset: 0x00033104
		// (set) Token: 0x06003DEF RID: 15855 RVA: 0x00034F0C File Offset: 0x0003310C
		public string Name { get; private set; }

		// Token: 0x04001C24 RID: 7204
		[CompilerGenerated]
		private string #a;
	}
}
