using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using #23i;
using #7hc;
using #w1i;
using #x1i;
using ETABSv1;
using StructurePoint.Kernel.CoreAssets.Importer.Core;

namespace StructurePoint.Kernel.CoreAssets.Importer.Business.Wrappers
{
	// Token: 0x02000E82 RID: 3714
	internal sealed class EtabsModelWrapper : cSapModel, #13i, #33i
	{
		// Token: 0x060084DA RID: 34010 RVA: 0x0006BFFE File Offset: 0x0006A1FE
		public EtabsModelWrapper(#13i etabsObject, cSapModel etabsModel)
		{
			this.#a = etabsObject;
			this.#b = etabsModel;
		}

		// Token: 0x170027C8 RID: 10184
		// (get) Token: 0x060084DB RID: 34011 RVA: 0x0006C014 File Offset: 0x0006A214
		public cAnalyze Analyze
		{
			get
			{
				return this.#K3i<cAnalyze>(new Func<cSapModel, cAnalyze>(EtabsModelWrapper.<>c.<>9.#v4i));
			}
		}

		// Token: 0x170027C9 RID: 10185
		// (get) Token: 0x060084DC RID: 34012 RVA: 0x0006C03B File Offset: 0x0006A23B
		public cAreaElm AreaElm
		{
			get
			{
				return this.#K3i<cAreaElm>(new Func<cSapModel, cAreaElm>(EtabsModelWrapper.<>c.<>9.#x4i));
			}
		}

		// Token: 0x170027CA RID: 10186
		// (get) Token: 0x060084DD RID: 34013 RVA: 0x0006C062 File Offset: 0x0006A262
		public cAreaObj AreaObj
		{
			get
			{
				return this.#K3i<cAreaObj>(new Func<cSapModel, cAreaObj>(EtabsModelWrapper.<>c.<>9.#y4i));
			}
		}

		// Token: 0x170027CB RID: 10187
		// (get) Token: 0x060084DE RID: 34014 RVA: 0x0006C089 File Offset: 0x0006A289
		public cConstraint ConstraintDef
		{
			get
			{
				return this.#K3i<cConstraint>(new Func<cSapModel, cConstraint>(EtabsModelWrapper.<>c.<>9.#z4i));
			}
		}

		// Token: 0x170027CC RID: 10188
		// (get) Token: 0x060084DF RID: 34015 RVA: 0x0006C0B0 File Offset: 0x0006A2B0
		public cDesignConcrete DesignConcrete
		{
			get
			{
				return this.#K3i<cDesignConcrete>(new Func<cSapModel, cDesignConcrete>(EtabsModelWrapper.<>c.<>9.#A4i));
			}
		}

		// Token: 0x170027CD RID: 10189
		// (get) Token: 0x060084E0 RID: 34016 RVA: 0x0006C0D7 File Offset: 0x0006A2D7
		public cDesignSteel DesignSteel
		{
			get
			{
				return this.#K3i<cDesignSteel>(new Func<cSapModel, cDesignSteel>(EtabsModelWrapper.<>c.<>9.#B4i));
			}
		}

		// Token: 0x170027CE RID: 10190
		// (get) Token: 0x060084E1 RID: 34017 RVA: 0x0006C0FE File Offset: 0x0006A2FE
		public cEditArea EditArea
		{
			get
			{
				return this.#K3i<cEditArea>(new Func<cSapModel, cEditArea>(EtabsModelWrapper.<>c.<>9.#C4i));
			}
		}

		// Token: 0x170027CF RID: 10191
		// (get) Token: 0x060084E2 RID: 34018 RVA: 0x0006C125 File Offset: 0x0006A325
		public cEditFrame EditFrame
		{
			get
			{
				return this.#K3i<cEditFrame>(new Func<cSapModel, cEditFrame>(EtabsModelWrapper.<>c.<>9.#D4i));
			}
		}

		// Token: 0x170027D0 RID: 10192
		// (get) Token: 0x060084E3 RID: 34019 RVA: 0x0006C14C File Offset: 0x0006A34C
		public cEditGeneral EditGeneral
		{
			get
			{
				return this.#K3i<cEditGeneral>(new Func<cSapModel, cEditGeneral>(EtabsModelWrapper.<>c.<>9.#E4i));
			}
		}

		// Token: 0x170027D1 RID: 10193
		// (get) Token: 0x060084E4 RID: 34020 RVA: 0x0006C173 File Offset: 0x0006A373
		public cEditPoint EditPoint
		{
			get
			{
				return this.#K3i<cEditPoint>(new Func<cSapModel, cEditPoint>(EtabsModelWrapper.<>c.<>9.#F4i));
			}
		}

		// Token: 0x170027D2 RID: 10194
		// (get) Token: 0x060084E5 RID: 34021 RVA: 0x0006C19A File Offset: 0x0006A39A
		public cFile File
		{
			get
			{
				return this.#K3i<cFile>(new Func<cSapModel, cFile>(EtabsModelWrapper.<>c.<>9.#G4i));
			}
		}

		// Token: 0x170027D3 RID: 10195
		// (get) Token: 0x060084E6 RID: 34022 RVA: 0x0006C1C1 File Offset: 0x0006A3C1
		public cFrameObj FrameObj
		{
			get
			{
				return this.#K3i<cFrameObj>(new Func<cSapModel, cFrameObj>(EtabsModelWrapper.<>c.<>9.#H4i));
			}
		}

		// Token: 0x170027D4 RID: 10196
		// (get) Token: 0x060084E7 RID: 34023 RVA: 0x0006C1E8 File Offset: 0x0006A3E8
		public cFunction Func
		{
			get
			{
				return this.#K3i<cFunction>(new Func<cSapModel, cFunction>(EtabsModelWrapper.<>c.<>9.#I4i));
			}
		}

		// Token: 0x170027D5 RID: 10197
		// (get) Token: 0x060084E8 RID: 34024 RVA: 0x0006C20F File Offset: 0x0006A40F
		public cGenDispl GDispl
		{
			get
			{
				return this.#K3i<cGenDispl>(new Func<cSapModel, cGenDispl>(EtabsModelWrapper.<>c.<>9.#J4i));
			}
		}

		// Token: 0x170027D6 RID: 10198
		// (get) Token: 0x060084E9 RID: 34025 RVA: 0x0006C236 File Offset: 0x0006A436
		public cGroup GroupDef
		{
			get
			{
				return this.#K3i<cGroup>(new Func<cSapModel, cGroup>(EtabsModelWrapper.<>c.<>9.#K4i));
			}
		}

		// Token: 0x170027D7 RID: 10199
		// (get) Token: 0x060084EA RID: 34026 RVA: 0x0006C25D File Offset: 0x0006A45D
		public cLineElm LineElm
		{
			get
			{
				return this.#K3i<cLineElm>(new Func<cSapModel, cLineElm>(EtabsModelWrapper.<>c.<>9.#L4i));
			}
		}

		// Token: 0x170027D8 RID: 10200
		// (get) Token: 0x060084EB RID: 34027 RVA: 0x0006C284 File Offset: 0x0006A484
		public cLinkElm LinkElm
		{
			get
			{
				return this.#K3i<cLinkElm>(new Func<cSapModel, cLinkElm>(EtabsModelWrapper.<>c.<>9.#M4i));
			}
		}

		// Token: 0x170027D9 RID: 10201
		// (get) Token: 0x060084EC RID: 34028 RVA: 0x0006C2AB File Offset: 0x0006A4AB
		public cLinkObj LinkObj
		{
			get
			{
				return this.#K3i<cLinkObj>(new Func<cSapModel, cLinkObj>(EtabsModelWrapper.<>c.<>9.#N4i));
			}
		}

		// Token: 0x170027DA RID: 10202
		// (get) Token: 0x060084ED RID: 34029 RVA: 0x0006C2D2 File Offset: 0x0006A4D2
		public cLoadCases LoadCases
		{
			get
			{
				return this.#K3i<cLoadCases>(new Func<cSapModel, cLoadCases>(EtabsModelWrapper.<>c.<>9.#O4i));
			}
		}

		// Token: 0x170027DB RID: 10203
		// (get) Token: 0x060084EE RID: 34030 RVA: 0x0006C2F9 File Offset: 0x0006A4F9
		public cLoadPatterns LoadPatterns
		{
			get
			{
				return this.#K3i<cLoadPatterns>(new Func<cSapModel, cLoadPatterns>(EtabsModelWrapper.<>c.<>9.#P4i));
			}
		}

		// Token: 0x170027DC RID: 10204
		// (get) Token: 0x060084EF RID: 34031 RVA: 0x0006C320 File Offset: 0x0006A520
		public cOptions Options
		{
			get
			{
				return this.#K3i<cOptions>(new Func<cSapModel, cOptions>(EtabsModelWrapper.<>c.<>9.#Q4i));
			}
		}

		// Token: 0x170027DD RID: 10205
		// (get) Token: 0x060084F0 RID: 34032 RVA: 0x0006C347 File Offset: 0x0006A547
		public cPattern PatternDef
		{
			get
			{
				return this.#K3i<cPattern>(new Func<cSapModel, cPattern>(EtabsModelWrapper.<>c.<>9.#R4i));
			}
		}

		// Token: 0x170027DE RID: 10206
		// (get) Token: 0x060084F1 RID: 34033 RVA: 0x0006C36E File Offset: 0x0006A56E
		public cPointElm PointElm
		{
			get
			{
				return this.#K3i<cPointElm>(new Func<cSapModel, cPointElm>(EtabsModelWrapper.<>c.<>9.#S4i));
			}
		}

		// Token: 0x170027DF RID: 10207
		// (get) Token: 0x060084F2 RID: 34034 RVA: 0x0006C395 File Offset: 0x0006A595
		public cPointObj PointObj
		{
			get
			{
				return this.#K3i<cPointObj>(new Func<cSapModel, cPointObj>(EtabsModelWrapper.<>c.<>9.#T4i));
			}
		}

		// Token: 0x170027E0 RID: 10208
		// (get) Token: 0x060084F3 RID: 34035 RVA: 0x0006C3BC File Offset: 0x0006A5BC
		public cPropArea PropArea
		{
			get
			{
				return this.#K3i<cPropArea>(new Func<cSapModel, cPropArea>(EtabsModelWrapper.<>c.<>9.#U4i));
			}
		}

		// Token: 0x170027E1 RID: 10209
		// (get) Token: 0x060084F4 RID: 34036 RVA: 0x0006C3E3 File Offset: 0x0006A5E3
		public cPropFrame PropFrame
		{
			get
			{
				return this.#K3i<cPropFrame>(new Func<cSapModel, cPropFrame>(EtabsModelWrapper.<>c.<>9.#V4i));
			}
		}

		// Token: 0x170027E2 RID: 10210
		// (get) Token: 0x060084F5 RID: 34037 RVA: 0x0006C40A File Offset: 0x0006A60A
		public cPropLink PropLink
		{
			get
			{
				return this.#K3i<cPropLink>(new Func<cSapModel, cPropLink>(EtabsModelWrapper.<>c.<>9.#W4i));
			}
		}

		// Token: 0x170027E3 RID: 10211
		// (get) Token: 0x060084F6 RID: 34038 RVA: 0x0006C431 File Offset: 0x0006A631
		public cPropMaterial PropMaterial
		{
			get
			{
				return this.#K3i<cPropMaterial>(new Func<cSapModel, cPropMaterial>(EtabsModelWrapper.<>c.<>9.#X4i));
			}
		}

		// Token: 0x170027E4 RID: 10212
		// (get) Token: 0x060084F7 RID: 34039 RVA: 0x0006C458 File Offset: 0x0006A658
		public cPropRebar PropRebar
		{
			get
			{
				return this.#K3i<cPropRebar>(new Func<cSapModel, cPropRebar>(EtabsModelWrapper.<>c.<>9.#Y4i));
			}
		}

		// Token: 0x170027E5 RID: 10213
		// (get) Token: 0x060084F8 RID: 34040 RVA: 0x0006C47F File Offset: 0x0006A67F
		public cPropTendon PropTendon
		{
			get
			{
				return this.#K3i<cPropTendon>(new Func<cSapModel, cPropTendon>(EtabsModelWrapper.<>c.<>9.#Z4i));
			}
		}

		// Token: 0x170027E6 RID: 10214
		// (get) Token: 0x060084F9 RID: 34041 RVA: 0x0006C4A6 File Offset: 0x0006A6A6
		public cCombo RespCombo
		{
			get
			{
				return this.#K3i<cCombo>(new Func<cSapModel, cCombo>(EtabsModelWrapper.<>c.<>9.#04i));
			}
		}

		// Token: 0x170027E7 RID: 10215
		// (get) Token: 0x060084FA RID: 34042 RVA: 0x0006C4CD File Offset: 0x0006A6CD
		public cAnalysisResults Results
		{
			get
			{
				return this.#K3i<cAnalysisResults>(new Func<cSapModel, cAnalysisResults>(EtabsModelWrapper.<>c.<>9.#14i));
			}
		}

		// Token: 0x170027E8 RID: 10216
		// (get) Token: 0x060084FB RID: 34043 RVA: 0x0006C4F4 File Offset: 0x0006A6F4
		public cSelect SelectObj
		{
			get
			{
				return this.#K3i<cSelect>(new Func<cSapModel, cSelect>(EtabsModelWrapper.<>c.<>9.#24i));
			}
		}

		// Token: 0x170027E9 RID: 10217
		// (get) Token: 0x060084FC RID: 34044 RVA: 0x0006C51B File Offset: 0x0006A71B
		public cTendonObj TendonObj
		{
			get
			{
				return this.#K3i<cTendonObj>(new Func<cSapModel, cTendonObj>(EtabsModelWrapper.<>c.<>9.#34i));
			}
		}

		// Token: 0x170027EA RID: 10218
		// (get) Token: 0x060084FD RID: 34045 RVA: 0x0006C542 File Offset: 0x0006A742
		public cView View
		{
			get
			{
				return this.#K3i<cView>(new Func<cSapModel, cView>(EtabsModelWrapper.<>c.<>9.#44i));
			}
		}

		// Token: 0x170027EB RID: 10219
		// (get) Token: 0x060084FE RID: 34046 RVA: 0x0006C569 File Offset: 0x0006A769
		public cDesignResults DesignResults
		{
			get
			{
				return this.#K3i<cDesignResults>(new Func<cSapModel, cDesignResults>(EtabsModelWrapper.<>c.<>9.#54i));
			}
		}

		// Token: 0x170027EC RID: 10220
		// (get) Token: 0x060084FF RID: 34047 RVA: 0x0006C590 File Offset: 0x0006A790
		public cDesignCompositeBeam DesignCompositeBeam
		{
			get
			{
				return this.#K3i<cDesignCompositeBeam>(new Func<cSapModel, cDesignCompositeBeam>(EtabsModelWrapper.<>c.<>9.#64i));
			}
		}

		// Token: 0x170027ED RID: 10221
		// (get) Token: 0x06008500 RID: 34048 RVA: 0x0006C5B7 File Offset: 0x0006A7B7
		public cGridSys GridSys
		{
			get
			{
				return this.#K3i<cGridSys>(new Func<cSapModel, cGridSys>(EtabsModelWrapper.<>c.<>9.#74i));
			}
		}

		// Token: 0x170027EE RID: 10222
		// (get) Token: 0x06008501 RID: 34049 RVA: 0x0006C5DE File Offset: 0x0006A7DE
		public cStory Story
		{
			get
			{
				return this.#K3i<cStory>(new Func<cSapModel, cStory>(EtabsModelWrapper.<>c.<>9.#84i));
			}
		}

		// Token: 0x170027EF RID: 10223
		// (get) Token: 0x06008502 RID: 34050 RVA: 0x0006C605 File Offset: 0x0006A805
		public cTower Tower
		{
			get
			{
				return this.#K3i<cTower>(new Func<cSapModel, cTower>(EtabsModelWrapper.<>c.<>9.#94i));
			}
		}

		// Token: 0x170027F0 RID: 10224
		// (get) Token: 0x06008503 RID: 34051 RVA: 0x0006C62C File Offset: 0x0006A82C
		public cDiaphragm Diaphragm
		{
			get
			{
				return this.#K3i<cDiaphragm>(new Func<cSapModel, cDiaphragm>(EtabsModelWrapper.<>c.<>9.#a5i));
			}
		}

		// Token: 0x170027F1 RID: 10225
		// (get) Token: 0x06008504 RID: 34052 RVA: 0x0006C653 File Offset: 0x0006A853
		public cPierLabel PierLabel
		{
			get
			{
				return this.#K3i<cPierLabel>(new Func<cSapModel, cPierLabel>(EtabsModelWrapper.<>c.<>9.#b5i));
			}
		}

		// Token: 0x170027F2 RID: 10226
		// (get) Token: 0x06008505 RID: 34053 RVA: 0x0006C67A File Offset: 0x0006A87A
		public cSpandrelLabel SpandrelLabel
		{
			get
			{
				return this.#K3i<cSpandrelLabel>(new Func<cSapModel, cSpandrelLabel>(EtabsModelWrapper.<>c.<>9.#c5i));
			}
		}

		// Token: 0x170027F3 RID: 10227
		// (get) Token: 0x06008506 RID: 34054 RVA: 0x0006C6A1 File Offset: 0x0006A8A1
		public cDetailing Detailing
		{
			get
			{
				return this.#K3i<cDetailing>(new Func<cSapModel, cDetailing>(EtabsModelWrapper.<>c.<>9.#d5i));
			}
		}

		// Token: 0x170027F4 RID: 10228
		// (get) Token: 0x06008507 RID: 34055 RVA: 0x0006C6C8 File Offset: 0x0006A8C8
		public cPropPointSpring PropPointSpring
		{
			get
			{
				return this.#K3i<cPropPointSpring>(new Func<cSapModel, cPropPointSpring>(EtabsModelWrapper.<>c.<>9.#e5i));
			}
		}

		// Token: 0x170027F5 RID: 10229
		// (get) Token: 0x06008508 RID: 34056 RVA: 0x0006C6EF File Offset: 0x0006A8EF
		public cPropLineSpring PropLineSpring
		{
			get
			{
				return this.#K3i<cPropLineSpring>(new Func<cSapModel, cPropLineSpring>(EtabsModelWrapper.<>c.<>9.#f5i));
			}
		}

		// Token: 0x170027F6 RID: 10230
		// (get) Token: 0x06008509 RID: 34057 RVA: 0x0006C716 File Offset: 0x0006A916
		public cPropAreaSpring PropAreaSpring
		{
			get
			{
				return this.#K3i<cPropAreaSpring>(new Func<cSapModel, cPropAreaSpring>(EtabsModelWrapper.<>c.<>9.#g5i));
			}
		}

		// Token: 0x170027F7 RID: 10231
		// (get) Token: 0x0600850A RID: 34058 RVA: 0x0006C73D File Offset: 0x0006A93D
		public cDesignConcreteSlab DesignConcreteSlab
		{
			get
			{
				return this.#K3i<cDesignConcreteSlab>(new Func<cSapModel, cDesignConcreteSlab>(EtabsModelWrapper.<>c.<>9.#h5i));
			}
		}

		// Token: 0x170027F8 RID: 10232
		// (get) Token: 0x0600850B RID: 34059 RVA: 0x0006C764 File Offset: 0x0006A964
		public cDesignShearWall DesignShearWall
		{
			get
			{
				return this.#K3i<cDesignShearWall>(new Func<cSapModel, cDesignShearWall>(EtabsModelWrapper.<>c.<>9.#i5i));
			}
		}

		// Token: 0x170027F9 RID: 10233
		// (get) Token: 0x0600850C RID: 34060 RVA: 0x0006C78B File Offset: 0x0006A98B
		public cDatabaseTables DatabaseTables
		{
			get
			{
				return this.#K3i<cDatabaseTables>(new Func<cSapModel, cDatabaseTables>(EtabsModelWrapper.<>c.<>9.#j5i));
			}
		}

		// Token: 0x170027FA RID: 10234
		// (get) Token: 0x0600850D RID: 34061 RVA: 0x0006C7B2 File Offset: 0x0006A9B2
		// (set) Token: 0x0600850E RID: 34062 RVA: 0x0006C7BA File Offset: 0x0006A9BA
		public bool Disconnected { get; private set; }

		// Token: 0x0600850F RID: 34063 RVA: 0x0006C7C3 File Offset: 0x0006A9C3
		public eUnits #92i()
		{
			return this.#K3i<eUnits>(new Func<cSapModel, eUnits>(EtabsModelWrapper.<>c.<>9.#k5i));
		}

		// Token: 0x06008510 RID: 34064 RVA: 0x001CB0D8 File Offset: 0x001C92D8
		public int #a3i(ref double #b3i)
		{
			EtabsModelWrapper.#EVd #EVd = new EtabsModelWrapper.#EVd();
			#EVd.#a = #b3i;
			int result = this.#K3i<int>(new Func<cSapModel, int>(#EVd.#q5i));
			#b3i = #EVd.#a;
			return result;
		}

		// Token: 0x06008511 RID: 34065 RVA: 0x001CB110 File Offset: 0x001C9310
		public string #c3i(bool #d3i = true)
		{
			EtabsModelWrapper.#BWb #BWb = new EtabsModelWrapper.#BWb();
			#BWb.#a = #d3i;
			return this.#K3i<string>(new Func<cSapModel, string>(#BWb.#r5i));
		}

		// Token: 0x06008512 RID: 34066 RVA: 0x0006C7EA File Offset: 0x0006A9EA
		public string #e3i()
		{
			return this.#K3i<string>(new Func<cSapModel, string>(EtabsModelWrapper.<>c.<>9.#l5i));
		}

		// Token: 0x06008513 RID: 34067 RVA: 0x0006C811 File Offset: 0x0006AA11
		public bool #f3i()
		{
			return this.#K3i<bool>(new Func<cSapModel, bool>(EtabsModelWrapper.<>c.<>9.#m5i));
		}

		// Token: 0x06008514 RID: 34068 RVA: 0x0006C838 File Offset: 0x0006AA38
		public string #g3i()
		{
			return this.#K3i<string>(new Func<cSapModel, string>(EtabsModelWrapper.<>c.<>9.#n5i));
		}

		// Token: 0x06008515 RID: 34069 RVA: 0x0006C85F File Offset: 0x0006AA5F
		public eUnits #h3i()
		{
			return this.#K3i<eUnits>(new Func<cSapModel, eUnits>(EtabsModelWrapper.<>c.<>9.#o5i));
		}

		// Token: 0x06008516 RID: 34070 RVA: 0x001CB13C File Offset: 0x001C933C
		public int #i3i(ref string #j3i, ref string #k3i, ref string #l3i)
		{
			EtabsModelWrapper.#aFg #aFg = new EtabsModelWrapper.#aFg();
			#aFg.#a = #j3i;
			#aFg.#b = #k3i;
			#aFg.#c = #l3i;
			int result = this.#K3i<int>(new Func<cSapModel, int>(#aFg.#s5i));
			#j3i = #aFg.#a;
			#k3i = #aFg.#b;
			#l3i = #aFg.#c;
			return result;
		}

		// Token: 0x06008517 RID: 34071 RVA: 0x001CB194 File Offset: 0x001C9394
		public int #m3i(ref int #n3i, ref string[] #o3i, ref string[] #p3i)
		{
			EtabsModelWrapper.#iJg #iJg = new EtabsModelWrapper.#iJg();
			#iJg.#a = #n3i;
			#iJg.#b = #o3i;
			#iJg.#c = #p3i;
			int result = this.#K3i<int>(new Func<cSapModel, int>(#iJg.#t5i));
			#n3i = #iJg.#a;
			#o3i = #iJg.#b;
			#p3i = #iJg.#c;
			return result;
		}

		// Token: 0x06008518 RID: 34072 RVA: 0x001CB1EC File Offset: 0x001C93EC
		public int #q3i(ref string #r3i, ref double #s3i)
		{
			EtabsModelWrapper.#IVb #IVb = new EtabsModelWrapper.#IVb();
			#IVb.#a = #r3i;
			#IVb.#b = #s3i;
			int result = this.#K3i<int>(new Func<cSapModel, int>(#IVb.#u5i));
			#r3i = #IVb.#a;
			#s3i = #IVb.#b;
			return result;
		}

		// Token: 0x06008519 RID: 34073 RVA: 0x001CB234 File Offset: 0x001C9434
		public int #t3i(eUnits #D6e = eUnits.kip_in_F)
		{
			EtabsModelWrapper.#dni #dni = new EtabsModelWrapper.#dni();
			#dni.#a = #D6e;
			return this.#K3i<int>(new Func<cSapModel, int>(#dni.#v5i));
		}

		// Token: 0x0600851A RID: 34074 RVA: 0x001CB260 File Offset: 0x001C9460
		public int #u3i(double #b3i)
		{
			EtabsModelWrapper.#l5b #l5b = new EtabsModelWrapper.#l5b();
			#l5b.#a = #b3i;
			return this.#K3i<int>(new Func<cSapModel, int>(#l5b.#w5i));
		}

		// Token: 0x0600851B RID: 34075 RVA: 0x001CB28C File Offset: 0x001C948C
		public int #v3i(bool #w3i)
		{
			EtabsModelWrapper.#y5i #y5i = new EtabsModelWrapper.#y5i();
			#y5i.#a = #w3i;
			return this.#K3i<int>(new Func<cSapModel, int>(#y5i.#x5i));
		}

		// Token: 0x0600851C RID: 34076 RVA: 0x001CB2B8 File Offset: 0x001C94B8
		public int #x3i(eUnits #D6e)
		{
			EtabsModelWrapper.#PVd #PVd = new EtabsModelWrapper.#PVd();
			#PVd.#a = #D6e;
			return this.#K3i<int>(new Func<cSapModel, int>(#PVd.#z5i));
		}

		// Token: 0x0600851D RID: 34077 RVA: 0x001CB2E4 File Offset: 0x001C94E4
		public int #y3i(string #o3i, string #p3i)
		{
			EtabsModelWrapper.#B5i #B5i = new EtabsModelWrapper.#B5i();
			#B5i.#a = #o3i;
			#B5i.#b = #p3i;
			return this.#K3i<int>(new Func<cSapModel, int>(#B5i.#A5i));
		}

		// Token: 0x0600851E RID: 34078 RVA: 0x001CB318 File Offset: 0x001C9518
		public int #z3i(ref eForce #A3i, ref eLength #B3i, ref eTemperature #C3i)
		{
			EtabsModelWrapper.#3Dg #3Dg = new EtabsModelWrapper.#3Dg();
			#3Dg.#a = #A3i;
			#3Dg.#b = #B3i;
			#3Dg.#c = #C3i;
			int result = this.#K3i<int>(new Func<cSapModel, int>(#3Dg.#C5i));
			#A3i = #3Dg.#a;
			#B3i = #3Dg.#b;
			#C3i = #3Dg.#c;
			return result;
		}

		// Token: 0x0600851F RID: 34079 RVA: 0x001CB370 File Offset: 0x001C9570
		public int #D3i(ref eForce #A3i, ref eLength #B3i, ref eTemperature #C3i)
		{
			EtabsModelWrapper.#jWd #jWd = new EtabsModelWrapper.#jWd();
			#jWd.#a = #A3i;
			#jWd.#b = #B3i;
			#jWd.#c = #C3i;
			int result = this.#K3i<int>(new Func<cSapModel, int>(#jWd.#D5i));
			#A3i = #jWd.#a;
			#B3i = #jWd.#b;
			#C3i = #jWd.#c;
			return result;
		}

		// Token: 0x06008520 RID: 34080 RVA: 0x001CB3C8 File Offset: 0x001C95C8
		public int #E3i(eForce #A3i, eLength #B3i, eTemperature #C3i)
		{
			EtabsModelWrapper.#8Xb #8Xb = new EtabsModelWrapper.#8Xb();
			#8Xb.#a = #A3i;
			#8Xb.#b = #B3i;
			#8Xb.#c = #C3i;
			return this.#K3i<int>(new Func<cSapModel, int>(#8Xb.#E5i));
		}

		// Token: 0x06008521 RID: 34081 RVA: 0x001CB404 File Offset: 0x001C9604
		public int #F3i(ref bool #G3i)
		{
			EtabsModelWrapper.#Uxc #Uxc = new EtabsModelWrapper.#Uxc();
			#Uxc.#a = #G3i;
			int result = this.#K3i<int>(new Func<cSapModel, int>(#Uxc.#F5i));
			#G3i = #Uxc.#a;
			return result;
		}

		// Token: 0x06008522 RID: 34082 RVA: 0x0006C886 File Offset: 0x0006AA86
		public int #H3i()
		{
			return this.#K3i<int>(new Func<cSapModel, int>(EtabsModelWrapper.<>c.<>9.#p5i));
		}

		// Token: 0x06008523 RID: 34083 RVA: 0x001CB43C File Offset: 0x001C963C
		public int #I3i(bool #J3i)
		{
			EtabsModelWrapper.#bYb #bYb = new EtabsModelWrapper.#bYb();
			#bYb.#a = #J3i;
			return this.#K3i<int>(new Func<cSapModel, int>(#bYb.#G5i));
		}

		// Token: 0x06008524 RID: 34084 RVA: 0x001CB468 File Offset: 0x001C9668
		public void #i2i(bool #j2i)
		{
			if (!this.Disconnected)
			{
				Logger.#DSi(string.Format(#Phc.#3hc(107229587), Environment.NewLine, #j2i).#Q1i(#Phc.#3hc(107464305), 1, true));
				this.Disconnected = true;
				if (#j2i)
				{
					this.#a.#i2i(true);
				}
			}
		}

		// Token: 0x06008525 RID: 34085 RVA: 0x001CB4C4 File Offset: 0x001C96C4
		private #Fu #K3i<#Fu>(Func<cSapModel, #Fu> #Thc)
		{
			if (this.Disconnected)
			{
				Logger.#qn(#Phc.#3hc(107267604));
				throw new #C6h(#Ab.SpImporterExceptionEtabsDisconnected_ObjectDisconnected, #z6h.#p);
			}
			#Fu result;
			try
			{
				result = #Thc(this.#b);
			}
			catch (RemotingException ex)
			{
				Logger.#qn(#Phc.#3hc(107229522), ex);
				this.#i2i(true);
				throw new #C6h(#Ab.SpImporterExceptionEtabsDisconnected_DisconnectingObject, #z6h.#p, ex);
			}
			return result;
		}

		// Token: 0x040036CF RID: 14031
		private readonly #13i #a;

		// Token: 0x040036D0 RID: 14032
		private readonly cSapModel #b;

		// Token: 0x040036D1 RID: 14033
		[CompilerGenerated]
		private bool #c;

		// Token: 0x02000E84 RID: 3716
		[CompilerGenerated]
		private sealed class #EVd
		{
			// Token: 0x06008561 RID: 34145 RVA: 0x0006CA79 File Offset: 0x0006AC79
			internal int #q5i(cSapModel #w4i)
			{
				return #w4i.GetMergeTol(ref this.#a);
			}

			// Token: 0x0400370B RID: 14091
			public double #a;
		}

		// Token: 0x02000E85 RID: 3717
		[CompilerGenerated]
		private sealed class #BWb
		{
			// Token: 0x06008563 RID: 34147 RVA: 0x0006CA87 File Offset: 0x0006AC87
			internal string #r5i(cSapModel #w4i)
			{
				return #w4i.GetModelFilename(this.#a);
			}

			// Token: 0x0400370C RID: 14092
			public bool #a;
		}

		// Token: 0x02000E86 RID: 3718
		[CompilerGenerated]
		private sealed class #aFg
		{
			// Token: 0x06008565 RID: 34149 RVA: 0x0006CA95 File Offset: 0x0006AC95
			internal int #s5i(cSapModel #w4i)
			{
				return #w4i.GetProgramInfo(ref this.#a, ref this.#b, ref this.#c);
			}

			// Token: 0x0400370D RID: 14093
			public string #a;

			// Token: 0x0400370E RID: 14094
			public string #b;

			// Token: 0x0400370F RID: 14095
			public string #c;
		}

		// Token: 0x02000E87 RID: 3719
		[CompilerGenerated]
		private sealed class #iJg
		{
			// Token: 0x06008567 RID: 34151 RVA: 0x0006CAAF File Offset: 0x0006ACAF
			internal int #t5i(cSapModel #w4i)
			{
				return #w4i.GetProjectInfo(ref this.#a, ref this.#b, ref this.#c);
			}

			// Token: 0x04003710 RID: 14096
			public int #a;

			// Token: 0x04003711 RID: 14097
			public string[] #b;

			// Token: 0x04003712 RID: 14098
			public string[] #c;
		}

		// Token: 0x02000E88 RID: 3720
		[CompilerGenerated]
		private sealed class #IVb
		{
			// Token: 0x06008569 RID: 34153 RVA: 0x0006CAC9 File Offset: 0x0006ACC9
			internal int #u5i(cSapModel #w4i)
			{
				return #w4i.GetVersion(ref this.#a, ref this.#b);
			}

			// Token: 0x04003713 RID: 14099
			public string #a;

			// Token: 0x04003714 RID: 14100
			public double #b;
		}

		// Token: 0x02000E89 RID: 3721
		[CompilerGenerated]
		private sealed class #dni
		{
			// Token: 0x0600856B RID: 34155 RVA: 0x0006CADD File Offset: 0x0006ACDD
			internal int #v5i(cSapModel #w4i)
			{
				return #w4i.InitializeNewModel(this.#a);
			}

			// Token: 0x04003715 RID: 14101
			public eUnits #a;
		}

		// Token: 0x02000E8A RID: 3722
		[CompilerGenerated]
		private sealed class #l5b
		{
			// Token: 0x0600856D RID: 34157 RVA: 0x0006CAEB File Offset: 0x0006ACEB
			internal int #w5i(cSapModel #w4i)
			{
				return #w4i.SetMergeTol(this.#a);
			}

			// Token: 0x04003716 RID: 14102
			public double #a;
		}

		// Token: 0x02000E8B RID: 3723
		[CompilerGenerated]
		private sealed class #y5i
		{
			// Token: 0x0600856F RID: 34159 RVA: 0x0006CAF9 File Offset: 0x0006ACF9
			internal int #x5i(cSapModel #w4i)
			{
				return #w4i.SetModelIsLocked(this.#a);
			}

			// Token: 0x04003717 RID: 14103
			public bool #a;
		}

		// Token: 0x02000E8C RID: 3724
		[CompilerGenerated]
		private sealed class #PVd
		{
			// Token: 0x06008571 RID: 34161 RVA: 0x0006CB07 File Offset: 0x0006AD07
			internal int #z5i(cSapModel #w4i)
			{
				return #w4i.SetPresentUnits(this.#a);
			}

			// Token: 0x04003718 RID: 14104
			public eUnits #a;
		}

		// Token: 0x02000E8D RID: 3725
		[CompilerGenerated]
		private sealed class #B5i
		{
			// Token: 0x06008573 RID: 34163 RVA: 0x0006CB15 File Offset: 0x0006AD15
			internal int #A5i(cSapModel #w4i)
			{
				return #w4i.SetProjectInfo(this.#a, this.#b);
			}

			// Token: 0x04003719 RID: 14105
			public string #a;

			// Token: 0x0400371A RID: 14106
			public string #b;
		}

		// Token: 0x02000E8E RID: 3726
		[CompilerGenerated]
		private sealed class #3Dg
		{
			// Token: 0x06008575 RID: 34165 RVA: 0x0006CB29 File Offset: 0x0006AD29
			internal int #C5i(cSapModel #w4i)
			{
				return #w4i.GetDatabaseUnits_2(ref this.#a, ref this.#b, ref this.#c);
			}

			// Token: 0x0400371B RID: 14107
			public eForce #a;

			// Token: 0x0400371C RID: 14108
			public eLength #b;

			// Token: 0x0400371D RID: 14109
			public eTemperature #c;
		}

		// Token: 0x02000E8F RID: 3727
		[CompilerGenerated]
		private sealed class #jWd
		{
			// Token: 0x06008577 RID: 34167 RVA: 0x0006CB43 File Offset: 0x0006AD43
			internal int #D5i(cSapModel #w4i)
			{
				return #w4i.GetPresentUnits_2(ref this.#a, ref this.#b, ref this.#c);
			}

			// Token: 0x0400371E RID: 14110
			public eForce #a;

			// Token: 0x0400371F RID: 14111
			public eLength #b;

			// Token: 0x04003720 RID: 14112
			public eTemperature #c;
		}

		// Token: 0x02000E90 RID: 3728
		[CompilerGenerated]
		private sealed class #8Xb
		{
			// Token: 0x06008579 RID: 34169 RVA: 0x0006CB5D File Offset: 0x0006AD5D
			internal int #E5i(cSapModel #w4i)
			{
				return #w4i.SetPresentUnits_2(this.#a, this.#b, this.#c);
			}

			// Token: 0x04003721 RID: 14113
			public eForce #a;

			// Token: 0x04003722 RID: 14114
			public eLength #b;

			// Token: 0x04003723 RID: 14115
			public eTemperature #c;
		}

		// Token: 0x02000E91 RID: 3729
		[CompilerGenerated]
		private sealed class #Uxc
		{
			// Token: 0x0600857B RID: 34171 RVA: 0x0006CB77 File Offset: 0x0006AD77
			internal int #F5i(cSapModel #w4i)
			{
				return #w4i.TreeIsUpdateSuspended(ref this.#a);
			}

			// Token: 0x04003724 RID: 14116
			public bool #a;
		}

		// Token: 0x02000E92 RID: 3730
		[CompilerGenerated]
		private sealed class #bYb
		{
			// Token: 0x0600857D RID: 34173 RVA: 0x0006CB85 File Offset: 0x0006AD85
			internal int #G5i(cSapModel #w4i)
			{
				return #w4i.TreeSuspendUpdateData(this.#a);
			}

			// Token: 0x04003725 RID: 14117
			public bool #a;
		}
	}
}
