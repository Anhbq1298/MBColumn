using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using #2be;
using #Gke;
using #npe;
using #o1d;
using Newtonsoft.Json;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x02000FC5 RID: 4037
	[DataContract(Name = "Model", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class ColumnStorageModel : #Xpe
	{
		// Token: 0x06008C22 RID: 35874 RVA: 0x001DDFEC File Offset: 0x001DC1EC
		public ColumnStorageModel()
		{
			this.InvestigateInputFlag = 0;
			this.DesignInputFlag = 0;
			this.SlendernessInputFlag = 0;
			this.Options = new Options();
			this.Ties = new Ties();
			this.DesignDimensions = new DesignDimensions();
			this.InvestigationDimensions = new InvestigationDimensions();
			this.MaterialProperties = new MaterialProperties();
			this.StiffnessReductionFactorPhi = 0f;
			this.Bars = new List<StandardBar>();
			this.ReinforcementRatios = new ReinforcementRatios();
			this.MinRebarClearSpacing = 0f;
			this.DesignToRequiredRatio = 0f;
			this.DesignedColumnX = new SlendernessOfDesignedColumn();
			this.DesignedColumnY = new SlendernessOfDesignedColumn();
			this.DesignReinforcement = new DesignReinforcement();
			this.InvestigationReinforcement = new InvestigationReinforcement();
			this.BeamX = new SlendernessOfBeams();
			this.BeamY = new SlendernessOfBeams();
			this.SustainedLoadFactors = new SustainedLoadFactors();
			this.LoadFactors = new List<LoadFactor>();
			this.ServiceLoads = new List<ServiceLoad>();
			this.CrackedIBeams = 0f;
			this.CrackedIColumn = 0f;
			this.ColumnAbove = new SlendernessOfColumn();
			this.ColumnBelow = new SlendernessOfColumn();
			this.ReinforcementBars = new List<ReinforcementBar>();
			this.Polygons = new List<SectionPolygon>();
			this.FactoredLoads = new List<FactoredLoad>();
			this.ReductionFactors = new ReductionFactors();
			this.ProjectInfo = new ProjectInfo();
			this.IrregularOptions = new IrregularOptions();
			this.DraftingSettings = DraftingSettings.Default(this.Options.Unit);
			this.SectionTypeCacheItems = new List<SectionTypeDependentValuesCacheItem>();
			this.AxialLoads = new List<AxialLoad>();
			this.TemplateData = new TemplateData();
		}

		// Token: 0x06008C23 RID: 35875 RVA: 0x001DE198 File Offset: 0x001DC398
		internal ColumnStorageModel(#Hle mainModel)
		{
			this.InvestigateInputFlag = (int)mainModel.InvInputFlag;
			this.DesignInputFlag = (int)mainModel.DesInputFlag;
			this.SlendernessInputFlag = (int)mainModel.SldInputFlag;
			this.Options = new Options(mainModel.Options);
			this.Ties = new Ties(mainModel.Ties);
			this.DesignDimensions = new DesignDimensions(mainModel.DesDim);
			this.InvestigationDimensions = new InvestigationDimensions(mainModel.InvDim);
			this.MaterialProperties = new MaterialProperties(mainModel.MatProp);
			this.StiffnessReductionFactorPhi = mainModel.Phi_Delta;
			this.Bars = new List<StandardBar>(from item in mainModel.Bar.Take((int)mainModel.NumOfBars)
			select new StandardBar(item));
			this.ReinforcementRatios = new ReinforcementRatios(mainModel.DesCrit[0], mainModel.DesCrit[1]);
			this.MinRebarClearSpacing = mainModel.DesCrit[2];
			this.DesignToRequiredRatio = mainModel.DesCrit[3];
			SlendernessOfDesignedColumn[] array = (from item in mainModel.SldDesCol
			select new SlendernessOfDesignedColumn(item)).ToArray<SlendernessOfDesignedColumn>();
			this.DesignedColumnX = array[0];
			this.DesignedColumnY = array[1];
			this.DesignReinforcement = new DesignReinforcement(this.Options.DesignReinforcement, mainModel.DesRein);
			this.InvestigationReinforcement = new InvestigationReinforcement(this.Options.InvestigationReinforcement, mainModel.InvRein);
			BeamsCalculatorCore beamsCalculatorCore = new BeamsCalculatorCore(this.Options.Unit, this.Options.Code);
			SlendernessOfBeams[] array2 = (from sldBeam in mainModel.SldBeam
			select new SlendernessOfBeams(sldBeam)).ToArray<SlendernessOfBeams>();
			this.BeamX = array2[0];
			this.BeamY = array2[1];
			this.SetIsStandard(beamsCalculatorCore, this.BeamX);
			this.SetIsStandard(beamsCalculatorCore, this.BeamY);
			this.SustainedLoadFactors = new SustainedLoadFactors(mainModel.SustFact);
			this.LoadFactors = new List<LoadFactor>(from item in mainModel.LoadFact.Take((int)mainModel.Options.#w)
			select new LoadFactor(item));
			this.ServiceLoads = new List<ServiceLoad>();
			this.ServiceLoads.AddRange(from item in mainModel.ServLoads.Take((int)mainModel.Options.#q)
			select new ServiceLoad(item));
			this.CrackedIBeams = mainModel.CrackedI[0];
			this.CrackedIColumn = mainModel.CrackedI[1];
			SlendernessOfColumn[] array3 = (from sldAbvBlwCol in mainModel.SldAbvBlwCol
			select new SlendernessOfColumn(sldAbvBlwCol)).ToArray<SlendernessOfColumn>();
			this.ColumnAbove = array3[0];
			this.ColumnBelow = array3[1];
			this.ColumnAbove.IsConcreteStandard = beamsCalculatorCore.#qKe(this.ColumnAbove.Fcp, this.ColumnAbove.Ec);
			this.ColumnBelow.IsConcreteStandard = beamsCalculatorCore.#qKe(this.ColumnBelow.Fcp, this.ColumnBelow.Ec);
			this.ReinforcementBars = new List<ReinforcementBar>(from item in mainModel.RfBars.Take((int)mainModel.Options.#o)
			select new ReinforcementBar(item));
			this.Polygons = new List<SectionPolygon>();
			if (mainModel.Options.#r > 0)
			{
				this.Polygons.Add(new SectionPolygon
				{
					Application = PolygonApplication.Solid,
					FigureType = PolygonFigureType.Irregural
				});
				this.Polygons.Last<SectionPolygon>().Points.AddRange(from item in mainModel.ExteriorPoints.Take((int)mainModel.Options.#r)
				select new Point(item));
			}
			if (mainModel.Options.#s > 0)
			{
				this.Polygons.Add(new SectionPolygon
				{
					Application = PolygonApplication.Opening,
					FigureType = PolygonFigureType.Irregural
				});
				this.Polygons.Last<SectionPolygon>().Points.AddRange(from item in mainModel.InteriorPoints.Take((int)mainModel.Options.#s)
				select new Point(item));
			}
			this.FactoredLoads = new List<FactoredLoad>();
			this.AxialLoads = new List<AxialLoad>();
			if (this.Options.ActiveLoad == LoadType.Axial)
			{
				this.AxialLoads.AddRange(from item in mainModel.FactLoads.Take((int)mainModel.Options.#p)
				select new AxialLoad(item));
			}
			else
			{
				this.FactoredLoads.AddRange(from item in mainModel.FactLoads.Take((int)mainModel.Options.#p)
				select new FactoredLoad(item));
			}
			this.ReductionFactors = new ReductionFactors(mainModel.RedFactors);
			this.StiffnessX = mainModel.EI[0];
			this.StiffnessY = mainModel.EI[1];
			this.ProjectInfo = new ProjectInfo
			{
				ColumnId = mainModel.ColumnId,
				Project = mainModel.Project,
				Engineer = mainModel.Engineer,
				FileVersion = mainModel.FileVersion
			};
			this.IrregularOptions = new IrregularOptions(mainModel.IrreggularOptions);
			this.SlendernessOptFactor = mainModel.SldOptFact;
			this.BarGroupType = #yhe.#Pb<BarGroupType>((int)mainModel.BarGroupType);
			this.DraftingSettings = DraftingSettings.Default(this.Options.Unit);
			this.TemplateData = new TemplateData();
		}

		// Token: 0x170028EC RID: 10476
		// (get) Token: 0x06008C24 RID: 35876 RVA: 0x000720EF File Offset: 0x000702EF
		// (set) Token: 0x06008C25 RID: 35877 RVA: 0x000720F7 File Offset: 0x000702F7
		[JsonIgnore]
		[XmlIgnore]
		[IgnoreDataMember]
		public string SerializedModel { get; set; }

		// Token: 0x170028ED RID: 10477
		// (get) Token: 0x06008C26 RID: 35878 RVA: 0x00072100 File Offset: 0x00070300
		// (set) Token: 0x06008C27 RID: 35879 RVA: 0x00072108 File Offset: 0x00070308
		[DataMember(Name = "ProjectInfo", Order = 10)]
		public ProjectInfo ProjectInfo { get; set; }

		// Token: 0x170028EE RID: 10478
		// (get) Token: 0x06008C28 RID: 35880 RVA: 0x00072111 File Offset: 0x00070311
		// (set) Token: 0x06008C29 RID: 35881 RVA: 0x00072119 File Offset: 0x00070319
		[DataMember(Name = "InvestigateInputFlag", Order = 20)]
		public int InvestigateInputFlag { get; set; }

		// Token: 0x170028EF RID: 10479
		// (get) Token: 0x06008C2A RID: 35882 RVA: 0x00072122 File Offset: 0x00070322
		// (set) Token: 0x06008C2B RID: 35883 RVA: 0x0007212A File Offset: 0x0007032A
		[DataMember(Name = "DesignInputFlag", Order = 30)]
		public int DesignInputFlag { get; set; }

		// Token: 0x170028F0 RID: 10480
		// (get) Token: 0x06008C2C RID: 35884 RVA: 0x00072133 File Offset: 0x00070333
		// (set) Token: 0x06008C2D RID: 35885 RVA: 0x0007213B File Offset: 0x0007033B
		[DataMember(Name = "SlendernessInputFlag", Order = 40)]
		public int SlendernessInputFlag { get; set; }

		// Token: 0x170028F1 RID: 10481
		// (get) Token: 0x06008C2E RID: 35886 RVA: 0x00072144 File Offset: 0x00070344
		// (set) Token: 0x06008C2F RID: 35887 RVA: 0x0007214C File Offset: 0x0007034C
		[DataMember(Name = "Options", Order = 50)]
		public Options Options { get; set; }

		// Token: 0x170028F2 RID: 10482
		// (get) Token: 0x06008C30 RID: 35888 RVA: 0x00072155 File Offset: 0x00070355
		// (set) Token: 0x06008C31 RID: 35889 RVA: 0x0007215D File Offset: 0x0007035D
		[DataMember(Name = "IrregularOptions", Order = 60)]
		public IrregularOptions IrregularOptions { get; set; }

		// Token: 0x170028F3 RID: 10483
		// (get) Token: 0x06008C32 RID: 35890 RVA: 0x00072166 File Offset: 0x00070366
		// (set) Token: 0x06008C33 RID: 35891 RVA: 0x0007216E File Offset: 0x0007036E
		[DataMember(Name = "Ties", Order = 70)]
		public Ties Ties { get; set; }

		// Token: 0x170028F4 RID: 10484
		// (get) Token: 0x06008C34 RID: 35892 RVA: 0x00072177 File Offset: 0x00070377
		// (set) Token: 0x06008C35 RID: 35893 RVA: 0x0007217F File Offset: 0x0007037F
		[DataMember(Name = "DesignReinforcement", Order = 80)]
		public DesignReinforcement DesignReinforcement { get; set; }

		// Token: 0x170028F5 RID: 10485
		// (get) Token: 0x06008C36 RID: 35894 RVA: 0x00072188 File Offset: 0x00070388
		// (set) Token: 0x06008C37 RID: 35895 RVA: 0x00072190 File Offset: 0x00070390
		[DataMember(Name = "InvestigationReinforcement", Order = 90)]
		public InvestigationReinforcement InvestigationReinforcement { get; set; }

		// Token: 0x170028F6 RID: 10486
		// (get) Token: 0x06008C38 RID: 35896 RVA: 0x00072199 File Offset: 0x00070399
		// (set) Token: 0x06008C39 RID: 35897 RVA: 0x000721A1 File Offset: 0x000703A1
		[DataMember(Name = "DesignDimensions", Order = 100)]
		public DesignDimensions DesignDimensions { get; set; }

		// Token: 0x170028F7 RID: 10487
		// (get) Token: 0x06008C3A RID: 35898 RVA: 0x000721AA File Offset: 0x000703AA
		// (set) Token: 0x06008C3B RID: 35899 RVA: 0x000721B2 File Offset: 0x000703B2
		[DataMember(Name = "InvestigationDimensions", Order = 110)]
		public InvestigationDimensions InvestigationDimensions { get; set; }

		// Token: 0x170028F8 RID: 10488
		// (get) Token: 0x06008C3C RID: 35900 RVA: 0x000721BB File Offset: 0x000703BB
		// (set) Token: 0x06008C3D RID: 35901 RVA: 0x000721C3 File Offset: 0x000703C3
		[DataMember(Name = "MaterialProperties", Order = 120)]
		public MaterialProperties MaterialProperties { get; set; }

		// Token: 0x170028F9 RID: 10489
		// (get) Token: 0x06008C3E RID: 35902 RVA: 0x000721CC File Offset: 0x000703CC
		// (set) Token: 0x06008C3F RID: 35903 RVA: 0x000721D4 File Offset: 0x000703D4
		[DataMember(Name = "ReductionFactors", Order = 130)]
		public ReductionFactors ReductionFactors { get; set; }

		// Token: 0x170028FA RID: 10490
		// (get) Token: 0x06008C40 RID: 35904 RVA: 0x000721DD File Offset: 0x000703DD
		// (set) Token: 0x06008C41 RID: 35905 RVA: 0x000721E5 File Offset: 0x000703E5
		[DataMember(Name = "MinRebarClearSpacing", Order = 140)]
		public float MinRebarClearSpacing { get; set; }

		// Token: 0x170028FB RID: 10491
		// (get) Token: 0x06008C42 RID: 35906 RVA: 0x000721EE File Offset: 0x000703EE
		// (set) Token: 0x06008C43 RID: 35907 RVA: 0x000721F6 File Offset: 0x000703F6
		[DataMember(Name = "DesignToRequiredRatio", Order = 150)]
		public float DesignToRequiredRatio { get; set; }

		// Token: 0x170028FC RID: 10492
		// (get) Token: 0x06008C44 RID: 35908 RVA: 0x000721FF File Offset: 0x000703FF
		// (set) Token: 0x06008C45 RID: 35909 RVA: 0x00072207 File Offset: 0x00070407
		[DataMember(Name = "ReinforcementRatios", Order = 160)]
		public ReinforcementRatios ReinforcementRatios { get; set; }

		// Token: 0x170028FD RID: 10493
		// (get) Token: 0x06008C46 RID: 35910 RVA: 0x00072210 File Offset: 0x00070410
		// (set) Token: 0x06008C47 RID: 35911 RVA: 0x00072218 File Offset: 0x00070418
		[DataMember(Name = "Polygons", Order = 170)]
		public List<SectionPolygon> Polygons { get; set; }

		// Token: 0x170028FE RID: 10494
		// (get) Token: 0x06008C48 RID: 35912 RVA: 0x00072221 File Offset: 0x00070421
		// (set) Token: 0x06008C49 RID: 35913 RVA: 0x00072229 File Offset: 0x00070429
		[DataMember(Name = "ReinforcementBars", Order = 180)]
		public List<ReinforcementBar> ReinforcementBars { get; set; }

		// Token: 0x170028FF RID: 10495
		// (get) Token: 0x06008C4A RID: 35914 RVA: 0x00072232 File Offset: 0x00070432
		// (set) Token: 0x06008C4B RID: 35915 RVA: 0x0007223A File Offset: 0x0007043A
		[DataMember(Name = "FactoredLoads", Order = 190)]
		public List<FactoredLoad> FactoredLoads { get; set; }

		// Token: 0x17002900 RID: 10496
		// (get) Token: 0x06008C4C RID: 35916 RVA: 0x00072243 File Offset: 0x00070443
		// (set) Token: 0x06008C4D RID: 35917 RVA: 0x0007224B File Offset: 0x0007044B
		[DataMember(Name = "DesignedColumnX", Order = 200)]
		public SlendernessOfDesignedColumn DesignedColumnX { get; set; }

		// Token: 0x17002901 RID: 10497
		// (get) Token: 0x06008C4E RID: 35918 RVA: 0x00072254 File Offset: 0x00070454
		// (set) Token: 0x06008C4F RID: 35919 RVA: 0x0007225C File Offset: 0x0007045C
		[DataMember(Name = "DesignedColumnY", Order = 210)]
		public SlendernessOfDesignedColumn DesignedColumnY { get; set; }

		// Token: 0x17002902 RID: 10498
		// (get) Token: 0x06008C50 RID: 35920 RVA: 0x00072265 File Offset: 0x00070465
		// (set) Token: 0x06008C51 RID: 35921 RVA: 0x0007226D File Offset: 0x0007046D
		[DataMember(Name = "ColumnAbove", Order = 220)]
		public SlendernessOfColumn ColumnAbove { get; set; }

		// Token: 0x17002903 RID: 10499
		// (get) Token: 0x06008C52 RID: 35922 RVA: 0x00072276 File Offset: 0x00070476
		// (set) Token: 0x06008C53 RID: 35923 RVA: 0x0007227E File Offset: 0x0007047E
		[DataMember(Name = "ColumnBelow", Order = 230)]
		public SlendernessOfColumn ColumnBelow { get; set; }

		// Token: 0x17002904 RID: 10500
		// (get) Token: 0x06008C54 RID: 35924 RVA: 0x00072287 File Offset: 0x00070487
		// (set) Token: 0x06008C55 RID: 35925 RVA: 0x0007228F File Offset: 0x0007048F
		[DataMember(Name = "StiffnessX", Order = 240)]
		public float StiffnessX { get; set; }

		// Token: 0x17002905 RID: 10501
		// (get) Token: 0x06008C56 RID: 35926 RVA: 0x00072298 File Offset: 0x00070498
		// (set) Token: 0x06008C57 RID: 35927 RVA: 0x000722A0 File Offset: 0x000704A0
		[DataMember(Name = "StiffnessY", Order = 250)]
		public float StiffnessY { get; set; }

		// Token: 0x17002906 RID: 10502
		// (get) Token: 0x06008C58 RID: 35928 RVA: 0x000722A9 File Offset: 0x000704A9
		// (set) Token: 0x06008C59 RID: 35929 RVA: 0x000722B1 File Offset: 0x000704B1
		[DataMember(Name = "BeamX", Order = 260)]
		public SlendernessOfBeams BeamX { get; set; }

		// Token: 0x17002907 RID: 10503
		// (get) Token: 0x06008C5A RID: 35930 RVA: 0x000722BA File Offset: 0x000704BA
		// (set) Token: 0x06008C5B RID: 35931 RVA: 0x000722C2 File Offset: 0x000704C2
		[DataMember(Name = "BeamY", Order = 270)]
		public SlendernessOfBeams BeamY { get; set; }

		// Token: 0x17002908 RID: 10504
		// (get) Token: 0x06008C5C RID: 35932 RVA: 0x000722CB File Offset: 0x000704CB
		// (set) Token: 0x06008C5D RID: 35933 RVA: 0x000722D3 File Offset: 0x000704D3
		[DataMember(Name = "StiffnessReductionFactorPhi", Order = 280)]
		public float StiffnessReductionFactorPhi { get; set; }

		// Token: 0x17002909 RID: 10505
		// (get) Token: 0x06008C5E RID: 35934 RVA: 0x000722DC File Offset: 0x000704DC
		// (set) Token: 0x06008C5F RID: 35935 RVA: 0x000722E4 File Offset: 0x000704E4
		[DataMember(Name = "SlendernessOptFactor", Order = 290)]
		public short SlendernessOptFactor { get; set; }

		// Token: 0x1700290A RID: 10506
		// (get) Token: 0x06008C60 RID: 35936 RVA: 0x000722ED File Offset: 0x000704ED
		// (set) Token: 0x06008C61 RID: 35937 RVA: 0x000722F5 File Offset: 0x000704F5
		[DataMember(Name = "CrackedIBeams", Order = 300)]
		public float CrackedIBeams { get; set; }

		// Token: 0x1700290B RID: 10507
		// (get) Token: 0x06008C62 RID: 35938 RVA: 0x000722FE File Offset: 0x000704FE
		// (set) Token: 0x06008C63 RID: 35939 RVA: 0x00072306 File Offset: 0x00070506
		[DataMember(Name = "CrackedIColumn", Order = 310)]
		public float CrackedIColumn { get; set; }

		// Token: 0x1700290C RID: 10508
		// (get) Token: 0x06008C64 RID: 35940 RVA: 0x0007230F File Offset: 0x0007050F
		// (set) Token: 0x06008C65 RID: 35941 RVA: 0x00072317 File Offset: 0x00070517
		[DataMember(Name = "ServiceLoads", Order = 320)]
		public List<ServiceLoad> ServiceLoads { get; set; }

		// Token: 0x1700290D RID: 10509
		// (get) Token: 0x06008C66 RID: 35942 RVA: 0x00072320 File Offset: 0x00070520
		// (set) Token: 0x06008C67 RID: 35943 RVA: 0x00072328 File Offset: 0x00070528
		[DataMember(Name = "LoadFactors", Order = 330)]
		public List<LoadFactor> LoadFactors { get; set; }

		// Token: 0x1700290E RID: 10510
		// (get) Token: 0x06008C68 RID: 35944 RVA: 0x00072331 File Offset: 0x00070531
		// (set) Token: 0x06008C69 RID: 35945 RVA: 0x00072339 File Offset: 0x00070539
		[DataMember(Name = "BarGroupType", Order = 340)]
		public BarGroupType BarGroupType { get; set; }

		// Token: 0x1700290F RID: 10511
		// (get) Token: 0x06008C6A RID: 35946 RVA: 0x00072342 File Offset: 0x00070542
		// (set) Token: 0x06008C6B RID: 35947 RVA: 0x0007234A File Offset: 0x0007054A
		[DataMember(Name = "Bars", Order = 350)]
		public List<StandardBar> Bars { get; set; }

		// Token: 0x17002910 RID: 10512
		// (get) Token: 0x06008C6C RID: 35948 RVA: 0x00072353 File Offset: 0x00070553
		// (set) Token: 0x06008C6D RID: 35949 RVA: 0x0007235B File Offset: 0x0007055B
		[DataMember(Name = "SustainedLoadFactors", Order = 360)]
		public SustainedLoadFactors SustainedLoadFactors { get; set; }

		// Token: 0x17002911 RID: 10513
		// (get) Token: 0x06008C6E RID: 35950 RVA: 0x00072364 File Offset: 0x00070564
		// (set) Token: 0x06008C6F RID: 35951 RVA: 0x0007236C File Offset: 0x0007056C
		[DataMember(Name = "DraftingSettings", Order = 370, IsRequired = false)]
		public DraftingSettings DraftingSettings { get; set; }

		// Token: 0x17002912 RID: 10514
		// (get) Token: 0x06008C70 RID: 35952 RVA: 0x00072375 File Offset: 0x00070575
		// (set) Token: 0x06008C71 RID: 35953 RVA: 0x0007237D File Offset: 0x0007057D
		[DataMember(Name = "SectionTypeCacheItems", Order = 380, IsRequired = false)]
		public List<SectionTypeDependentValuesCacheItem> SectionTypeCacheItems { get; set; } = new List<SectionTypeDependentValuesCacheItem>();

		// Token: 0x17002913 RID: 10515
		// (get) Token: 0x06008C72 RID: 35954 RVA: 0x00072386 File Offset: 0x00070586
		// (set) Token: 0x06008C73 RID: 35955 RVA: 0x0007238E File Offset: 0x0007058E
		[DataMember(Name = "AxialLoads", Order = 390, IsRequired = false)]
		public List<AxialLoad> AxialLoads { get; set; }

		// Token: 0x17002914 RID: 10516
		// (get) Token: 0x06008C74 RID: 35956 RVA: 0x00072397 File Offset: 0x00070597
		// (set) Token: 0x06008C75 RID: 35957 RVA: 0x0007239F File Offset: 0x0007059F
		[DataMember(Name = "TemplateData", Order = 400, IsRequired = false)]
		public TemplateData TemplateData { get; set; }

		// Token: 0x17002915 RID: 10517
		// (get) Token: 0x06008C76 RID: 35958 RVA: 0x000723A8 File Offset: 0x000705A8
		internal IList<IStandardBar> BarsInternal
		{
			get
			{
				return this.Bars.OfType<IStandardBar>().ToList<IStandardBar>();
			}
		}

		// Token: 0x06008C77 RID: 35959 RVA: 0x001DE7A4 File Offset: 0x001DC9A4
		public int? GetBarSize(int index)
		{
			StandardBar standardBar = this.Bars.ElementAtOrDefault(index);
			if (standardBar == null)
			{
				return null;
			}
			return new int?(standardBar.Size);
		}

		// Token: 0x06008C78 RID: 35960 RVA: 0x001DE7D8 File Offset: 0x001DC9D8
		public #ice CreateContext()
		{
			return new #ice(this.Options.Unit, this.Options.SectionType, this.Options.ProblemType, this.Options.InvestigationLoad, this.Options.ConsideredAxis, this.Options.ConsiderSlenderness, this.Options.InvestigationReinforcement, this.Options.DesignReinforcement, this.Bars.Count - 1, this.Options.ReinforcementLayout, this.Options.Code, this.Options.DesignLoad, this.Options.ConfinementType, this.InvestigationDimensions, this.DesignDimensions);
		}

		// Token: 0x06008C79 RID: 35961 RVA: 0x000723BA File Offset: 0x000705BA
		public void ReAssignShapeId()
		{
			ColumnStorageModel.ReAssignShapeId(this.Polygons);
		}

		// Token: 0x06008C7A RID: 35962 RVA: 0x001DE888 File Offset: 0x001DCA88
		public static void ReAssignShapeId(IList<SectionPolygon> polygons)
		{
			List<SectionPolygon> source = (from item in polygons
			where item.Application == PolygonApplication.Solid
			select item).ToList<SectionPolygon>();
			List<SectionPolygon> source2 = (from item in polygons
			where item.Application == PolygonApplication.Opening
			select item).ToList<SectionPolygon>();
			int num;
			if (!source.Any<SectionPolygon>())
			{
				num = 1;
			}
			else
			{
				num = source.Max((SectionPolygon item) => item.Id) + 1;
			}
			int num2 = num;
			int num3;
			if (!source2.Any<SectionPolygon>())
			{
				num3 = 1;
			}
			else
			{
				num3 = source2.Max((SectionPolygon item) => item.Id) + 1;
			}
			int num4 = num3;
			foreach (SectionPolygon sectionPolygon in polygons)
			{
				if (sectionPolygon.Application == PolygonApplication.Solid && sectionPolygon.Id <= 0)
				{
					sectionPolygon.Id = num2++;
				}
				else if (sectionPolygon.Application == PolygonApplication.Opening && sectionPolygon.Id <= 0)
				{
					sectionPolygon.Id = num4++;
				}
			}
		}

		// Token: 0x06008C7B RID: 35963 RVA: 0x001DE9CC File Offset: 0x001DCBCC
		public bool ReAssignShapeIdIfNeeded()
		{
			List<SectionPolygon> list = (from item in this.Polygons
			where item.Application == PolygonApplication.Solid
			select item into s
			orderby s.Id
			select s).ToList<SectionPolygon>();
			list = (from x in list
			orderby x.Id <= 0
			select x).ToList<SectionPolygon>();
			List<SectionPolygon> list2 = (from item in this.Polygons
			where item.Application == PolygonApplication.Opening
			select item into s
			orderby s.Id
			select s).ToList<SectionPolygon>();
			list2 = (from x in list2
			orderby x.Id <= 0
			select x).ToList<SectionPolygon>();
			bool result = false;
			if (!ColumnStorageModel.<ReAssignShapeIdIfNeeded>g__HasValidIds|172_0(list))
			{
				ColumnStorageModel.<ReAssignShapeIdIfNeeded>g__ReassignId|172_1(list);
				result = true;
			}
			if (!ColumnStorageModel.<ReAssignShapeIdIfNeeded>g__HasValidIds|172_0(list2))
			{
				ColumnStorageModel.<ReAssignShapeIdIfNeeded>g__ReassignId|172_1(list2);
				result = true;
			}
			return result;
		}

		// Token: 0x06008C7C RID: 35964 RVA: 0x001DEAFC File Offset: 0x001DCCFC
		public bool HasValidShapeIds()
		{
			List<int> list = (from x in this.Polygons
			where x.Application == PolygonApplication.Solid
			select x.Id).ToList<int>();
			if (list.Count != list.Distinct<int>().Count<int>())
			{
				return false;
			}
			list = (from x in this.Polygons
			where x.Application == PolygonApplication.Opening
			select x.Id).ToList<int>();
			return list.Count == list.Distinct<int>().Count<int>();
		}

		// Token: 0x06008C7D RID: 35965 RVA: 0x001DEBDC File Offset: 0x001DCDDC
		private void SetIsStandard(BeamsCalculatorCore calculator, SlendernessOfBeams slenderness)
		{
			ColumnStorageModel.<>c__DisplayClass174_0 CS$<>8__locals1;
			CS$<>8__locals1.calculator = calculator;
			ColumnStorageModel.<SetIsStandard>g__SetStandard|174_0(slenderness.AboveLeft, ref CS$<>8__locals1);
			ColumnStorageModel.<SetIsStandard>g__SetStandard|174_0(slenderness.BelowLeft, ref CS$<>8__locals1);
			ColumnStorageModel.<SetIsStandard>g__SetStandard|174_0(slenderness.AboveRight, ref CS$<>8__locals1);
			ColumnStorageModel.<SetIsStandard>g__SetStandard|174_0(slenderness.BelowRight, ref CS$<>8__locals1);
		}

		// Token: 0x06008C7E RID: 35966 RVA: 0x001DEC28 File Offset: 0x001DCE28
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			if (this.DraftingSettings == null)
			{
				this.DraftingSettings = DraftingSettings.Default(this.Options.Unit);
			}
			if (this.SectionTypeCacheItems == null)
			{
				this.SectionTypeCacheItems = new List<SectionTypeDependentValuesCacheItem>();
			}
			if (this.AxialLoads == null)
			{
				this.AxialLoads = new List<AxialLoad>();
				if (this.Options.ActiveLoad == LoadType.Axial)
				{
					this.AxialLoads.AddRange(from item in this.FactoredLoads
					select new AxialLoad(item));
					this.FactoredLoads.Clear();
				}
			}
			if (this.TemplateData == null)
			{
				this.TemplateData = new TemplateData();
			}
			if (this.Options.PreviousSectionType == SectionType.Undefined && this.SectionTypeCacheItems.Any<SectionTypeDependentValuesCacheItem>())
			{
				this.Options.PreviousSectionType = this.SectionTypeCacheItems[0].SectionType;
			}
		}

		// Token: 0x06008C7F RID: 35967 RVA: 0x001DED14 File Offset: 0x001DCF14
		[CompilerGenerated]
		internal static bool <ReAssignShapeIdIfNeeded>g__HasValidIds|172_0(IList<SectionPolygon> items)
		{
			if (!items.Any<SectionPolygon>())
			{
				return true;
			}
			List<int> list = (from s in items
			select s.Id).Distinct<int>().ToList<int>();
			return list.Count == items.Count && list[0] == 1 && list.Last<int>() == list.Count;
		}

		// Token: 0x06008C80 RID: 35968 RVA: 0x001DED84 File Offset: 0x001DCF84
		[CompilerGenerated]
		internal static void <ReAssignShapeIdIfNeeded>g__ReassignId|172_1(IList<SectionPolygon> items)
		{
			int start = 1;
			items.#I1d(delegate(SectionPolygon s)
			{
				int start = start;
				start++;
				s.Id = start;
			});
		}

		// Token: 0x06008C81 RID: 35969 RVA: 0x001DEDB0 File Offset: 0x001DCFB0
		[CompilerGenerated]
		internal static void <SetIsStandard>g__SetStandard|174_0(Beam beam, ref ColumnStorageModel.<>c__DisplayClass174_0 A_1)
		{
			beam.IsConcreteStandard = A_1.calculator.#qKe(beam.Fcp, beam.Ec);
			beam.IsInertiaStandard = A_1.calculator.#sKe(beam.Depth, beam.Width, beam.MofI);
		}
	}
}
