using System;
using System.Runtime.Serialization;
using #7hc;

namespace StructurePoint.Products.Column.Core.Application.Misc
{
	// Token: 0x020006C1 RID: 1729
	[DataContract(Namespace = "https://structurepoint.org/schemas/xml/settings/column/201902", Name = "BatchProcessorSettings")]
	internal sealed class BatchProcessorSettings
	{
		// Token: 0x06003956 RID: 14678 RVA: 0x00031C06 File Offset: 0x0002FE06
		public BatchProcessorSettings()
		{
			this.Init();
		}

		// Token: 0x17001198 RID: 4504
		// (get) Token: 0x06003957 RID: 14679 RVA: 0x00031C14 File Offset: 0x0002FE14
		public static BatchProcessorSettings Default
		{
			get
			{
				return new BatchProcessorSettings();
			}
		}

		// Token: 0x17001199 RID: 4505
		// (get) Token: 0x06003958 RID: 14680 RVA: 0x00031C1F File Offset: 0x0002FE1F
		// (set) Token: 0x06003959 RID: 14681 RVA: 0x00031C2B File Offset: 0x0002FE2B
		[DataMember(Order = 0, Name = "GenerateTxtReport")]
		public bool GenerateTxtReport { get; set; }

		// Token: 0x1700119A RID: 4506
		// (get) Token: 0x0600395A RID: 14682 RVA: 0x00031C3C File Offset: 0x0002FE3C
		// (set) Token: 0x0600395B RID: 14683 RVA: 0x00031C48 File Offset: 0x0002FE48
		[DataMember(Order = 10, Name = "GenerateWordReport")]
		public bool GenerateWordReport { get; set; }

		// Token: 0x1700119B RID: 4507
		// (get) Token: 0x0600395C RID: 14684 RVA: 0x00031C59 File Offset: 0x0002FE59
		// (set) Token: 0x0600395D RID: 14685 RVA: 0x00031C65 File Offset: 0x0002FE65
		[DataMember(Order = 20, Name = "GeneratePdfReport")]
		public bool GeneratePdfReport { get; set; }

		// Token: 0x1700119C RID: 4508
		// (get) Token: 0x0600395E RID: 14686 RVA: 0x00031C76 File Offset: 0x0002FE76
		// (set) Token: 0x0600395F RID: 14687 RVA: 0x00031C82 File Offset: 0x0002FE82
		[DataMember(Order = 30, Name = "GenerateExcelReport")]
		public bool GenerateExcelReport { get; set; }

		// Token: 0x1700119D RID: 4509
		// (get) Token: 0x06003960 RID: 14688 RVA: 0x00031C93 File Offset: 0x0002FE93
		// (set) Token: 0x06003961 RID: 14689 RVA: 0x00031C9F File Offset: 0x0002FE9F
		[DataMember(Order = 40, Name = "GenerateCsvReport")]
		public bool GenerateCsvReport { get; set; }

		// Token: 0x1700119E RID: 4510
		// (get) Token: 0x06003962 RID: 14690 RVA: 0x00031CB0 File Offset: 0x0002FEB0
		// (set) Token: 0x06003963 RID: 14691 RVA: 0x00031CBC File Offset: 0x0002FEBC
		[DataMember(Order = 50, Name = "ConsiderArchitecturalColumn")]
		public bool ConsiderArchitecturalColumn { get; set; }

		// Token: 0x1700119F RID: 4511
		// (get) Token: 0x06003964 RID: 14692 RVA: 0x00031CCD File Offset: 0x0002FECD
		// (set) Token: 0x06003965 RID: 14693 RVA: 0x00031CD9 File Offset: 0x0002FED9
		[DataMember(Order = 60, Name = "DataFolder")]
		public string DataFolder { get; set; }

		// Token: 0x170011A0 RID: 4512
		// (get) Token: 0x06003966 RID: 14694 RVA: 0x00031CEA File Offset: 0x0002FEEA
		// (set) Token: 0x06003967 RID: 14695 RVA: 0x00031CF6 File Offset: 0x0002FEF6
		[DataMember(Order = 70, Name = "OutputFolder")]
		public string OutputFolder { get; set; }

		// Token: 0x170011A1 RID: 4513
		// (get) Token: 0x06003968 RID: 14696 RVA: 0x00031D07 File Offset: 0x0002FF07
		// (set) Token: 0x06003969 RID: 14697 RVA: 0x00031D13 File Offset: 0x0002FF13
		[Obsolete]
		[DataMember(Order = 80, Name = "SameAsOutputFolder")]
		public bool SameAsOutputFolder { get; set; }

		// Token: 0x170011A2 RID: 4514
		// (get) Token: 0x0600396A RID: 14698 RVA: 0x00031D24 File Offset: 0x0002FF24
		// (set) Token: 0x0600396B RID: 14699 RVA: 0x00031D30 File Offset: 0x0002FF30
		[DataMember(Order = 90, Name = "ContinueWhenRhoGreaterThan8", IsRequired = false)]
		public bool ContinueWhenRhoGreater8 { get; set; }

		// Token: 0x170011A3 RID: 4515
		// (get) Token: 0x0600396C RID: 14700 RVA: 0x00031D41 File Offset: 0x0002FF41
		// (set) Token: 0x0600396D RID: 14701 RVA: 0x00031D4D File Offset: 0x0002FF4D
		[DataMember(Order = 100, Name = "SectionToDXF", IsRequired = false)]
		public bool SectionToDXF { get; set; }

		// Token: 0x170011A4 RID: 4516
		// (get) Token: 0x0600396E RID: 14702 RVA: 0x00031D5E File Offset: 0x0002FF5E
		// (set) Token: 0x0600396F RID: 14703 RVA: 0x00031D6A File Offset: 0x0002FF6A
		[DataMember(Order = 110, Name = "EquivalentCTI", IsRequired = false)]
		public bool EquivalentCTI { get; set; }

		// Token: 0x170011A5 RID: 4517
		// (get) Token: 0x06003970 RID: 14704 RVA: 0x00031D7B File Offset: 0x0002FF7B
		// (set) Token: 0x06003971 RID: 14705 RVA: 0x00031D87 File Offset: 0x0002FF87
		[DataMember(Order = 120, Name = "AcceptedDataFilesFolder")]
		public string AcceptedDataFilesFolder { get; set; }

		// Token: 0x170011A6 RID: 4518
		// (get) Token: 0x06003972 RID: 14706 RVA: 0x00031D98 File Offset: 0x0002FF98
		// (set) Token: 0x06003973 RID: 14707 RVA: 0x00031DA4 File Offset: 0x0002FFA4
		[DataMember(Order = 130, Name = "AcceptedOutputsFolder")]
		public string AcceptedOutputsFolder { get; set; }

		// Token: 0x170011A7 RID: 4519
		// (get) Token: 0x06003974 RID: 14708 RVA: 0x00031DB5 File Offset: 0x0002FFB5
		// (set) Token: 0x06003975 RID: 14709 RVA: 0x00031DC1 File Offset: 0x0002FFC1
		[DataMember(Order = 140, Name = "SummaryFileName")]
		public string SummaryFileName { get; set; }

		// Token: 0x06003976 RID: 14710 RVA: 0x00031DD2 File Offset: 0x0002FFD2
		private void Init()
		{
			this.OnDeserialized(new StreamingContext(StreamingContextStates.Other));
		}

		// Token: 0x06003977 RID: 14711 RVA: 0x00112300 File Offset: 0x00110500
		public void CopyMutableSettings(BatchProcessorSettings other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399401));
			}
			this.GenerateTxtReport = other.GenerateTxtReport;
			this.GenerateCsvReport = other.GenerateCsvReport;
			this.GenerateExcelReport = other.GenerateExcelReport;
			this.GeneratePdfReport = other.GeneratePdfReport;
			this.GenerateWordReport = other.GenerateWordReport;
			this.ConsiderArchitecturalColumn = other.ConsiderArchitecturalColumn;
			this.DataFolder = other.DataFolder;
			this.ContinueWhenRhoGreater8 = other.ContinueWhenRhoGreater8;
			this.SectionToDXF = other.SectionToDXF;
			this.EquivalentCTI = other.EquivalentCTI;
		}

		// Token: 0x06003978 RID: 14712 RVA: 0x001123B8 File Offset: 0x001105B8
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			if (string.IsNullOrWhiteSpace(this.OutputFolder))
			{
				this.OutputFolder = #Phc.#3hc(107350600);
			}
			if (string.IsNullOrWhiteSpace(this.AcceptedDataFilesFolder))
			{
				this.AcceptedDataFilesFolder = #Phc.#3hc(107350623);
			}
			if (string.IsNullOrWhiteSpace(this.AcceptedOutputsFolder))
			{
				this.AcceptedOutputsFolder = #Phc.#3hc(107350562);
			}
			if (string.IsNullOrWhiteSpace(this.SummaryFileName))
			{
				this.SummaryFileName = #Phc.#3hc(107350537);
			}
		}
	}
}
