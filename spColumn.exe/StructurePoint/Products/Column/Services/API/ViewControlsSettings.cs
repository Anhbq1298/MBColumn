using System;
using System.Runtime.Serialization;

namespace StructurePoint.Products.Column.Services.API
{
	// Token: 0x02000310 RID: 784
	[DataContract(Namespace = "https://structurepoint.org/schemas/xml/settings/column/201902", Name = "ColumnViewControlsSettings")]
	internal sealed class ViewControlsSettings
	{
		// Token: 0x06001AF9 RID: 6905 RVA: 0x0001A97A File Offset: 0x00018B7A
		public ViewControlsSettings()
		{
			this.Init();
		}

		// Token: 0x170009C7 RID: 2503
		// (get) Token: 0x06001AFA RID: 6906 RVA: 0x0001A988 File Offset: 0x00018B88
		public static ViewControlsSettings Default
		{
			get
			{
				return new ViewControlsSettings();
			}
		}

		// Token: 0x170009C8 RID: 2504
		// (get) Token: 0x06001AFB RID: 6907 RVA: 0x0001A993 File Offset: 0x00018B93
		// (set) Token: 0x06001AFC RID: 6908 RVA: 0x0001A99F File Offset: 0x00018B9F
		[DataMember(Order = 10)]
		public bool IsViewCubeVisible { get; set; }

		// Token: 0x170009C9 RID: 2505
		// (get) Token: 0x06001AFD RID: 6909 RVA: 0x0001A9B0 File Offset: 0x00018BB0
		// (set) Token: 0x06001AFE RID: 6910 RVA: 0x0001A9BC File Offset: 0x00018BBC
		[DataMember(Order = 20)]
		public bool IsCoordinateSignVisible { get; set; }

		// Token: 0x06001AFF RID: 6911 RVA: 0x0001A9CD File Offset: 0x00018BCD
		[OnDeserializing]
		internal void OnDeserializingMethod(StreamingContext context)
		{
			this.Init();
		}

		// Token: 0x06001B00 RID: 6912 RVA: 0x0001A9DD File Offset: 0x00018BDD
		private void Init()
		{
			this.IsCoordinateSignVisible = false;
			this.IsViewCubeVisible = true;
		}
	}
}
