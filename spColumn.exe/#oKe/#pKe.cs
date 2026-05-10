using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;

namespace #oKe
{
	// Token: 0x02001269 RID: 4713
	internal sealed class #pKe : #nKe
	{
		// Token: 0x17002DA6 RID: 11686
		// (get) Token: 0x06009E2F RID: 40495 RVA: 0x00218F24 File Offset: 0x00217124
		public IDictionary<DesignCodes, string> AvailableDesignCodes
		{
			get
			{
				return new Dictionary<DesignCodes, string>
				{
					{
						DesignCodes.ACI19,
						#Phc.#3hc(107313706)
					},
					{
						DesignCodes.ACI14,
						#Phc.#3hc(107313721)
					},
					{
						DesignCodes.ACI11,
						#Phc.#3hc(107313672)
					},
					{
						DesignCodes.ACI08,
						#Phc.#3hc(107313687)
					},
					{
						DesignCodes.ACI05,
						#Phc.#3hc(107314150)
					},
					{
						DesignCodes.ACI02,
						#Phc.#3hc(107314165)
					},
					{
						DesignCodes.CSA19,
						#Phc.#3hc(107314116)
					},
					{
						DesignCodes.CSA14,
						#Phc.#3hc(107314131)
					},
					{
						DesignCodes.CSA04,
						#Phc.#3hc(107314082)
					},
					{
						DesignCodes.CSA94,
						#Phc.#3hc(107314097)
					}
				};
			}
		}

		// Token: 0x17002DA7 RID: 11687
		// (get) Token: 0x06009E30 RID: 40496 RVA: 0x0007C72D File Offset: 0x0007A92D
		public IDictionary<UnitSystem, string> AvailableUnitSystems
		{
			get
			{
				return new Dictionary<UnitSystem, string>
				{
					{
						UnitSystem.USCustomary,
						Strings.StringEnglish
					},
					{
						UnitSystem.SIMetric,
						Strings.StringMetric
					}
				};
			}
		}

		// Token: 0x17002DA8 RID: 11688
		// (get) Token: 0x06009E31 RID: 40497 RVA: 0x00218FE4 File Offset: 0x002171E4
		public IDictionary<BarGroupType, string> AvailableBarGroupTypes
		{
			get
			{
				return new Dictionary<BarGroupType, string>
				{
					{
						BarGroupType.ASTM615,
						Strings.StringASTMA615
					},
					{
						BarGroupType.ASTM615M,
						Strings.StringASTMA615M
					},
					{
						BarGroupType.CSA,
						Strings.StringCSAG3018
					},
					{
						BarGroupType.PREN10080,
						Strings.StringPREN10080
					},
					{
						BarGroupType.UserDefined,
						Strings.StringUserDefined
					}
				};
			}
		}

		// Token: 0x17002DA9 RID: 11689
		// (get) Token: 0x06009E32 RID: 40498 RVA: 0x0007C74C File Offset: 0x0007A94C
		public IDictionary<ConfinementType, string> AvailableConfinementTypes
		{
			get
			{
				return new Dictionary<ConfinementType, string>
				{
					{
						ConfinementType.Tied,
						Strings.StringTied
					},
					{
						ConfinementType.Spiral,
						Strings.StringSpiral
					},
					{
						ConfinementType.Other,
						Strings.StringOther
					}
				};
			}
		}

		// Token: 0x17002DAA RID: 11690
		// (get) Token: 0x06009E33 RID: 40499 RVA: 0x0007C777 File Offset: 0x0007A977
		public IDictionary<ProblemType, string> AvailableProblemTypes
		{
			get
			{
				return new Dictionary<ProblemType, string>
				{
					{
						ProblemType.Investigation,
						Strings.StringInvestigation
					},
					{
						ProblemType.Design,
						Strings.StringDesign
					}
				};
			}
		}

		// Token: 0x17002DAB RID: 11691
		// (get) Token: 0x06009E34 RID: 40500 RVA: 0x0007C796 File Offset: 0x0007A996
		public IDictionary<ConsideredAxis, string> AvailableConsideredAxes
		{
			get
			{
				return new Dictionary<ConsideredAxis, string>
				{
					{
						ConsideredAxis.X,
						Strings.StringAboutXAxis
					},
					{
						ConsideredAxis.Y,
						Strings.StringAboutYAxis
					},
					{
						ConsideredAxis.Both,
						Strings.StringBiaxial
					}
				};
			}
		}

		// Token: 0x17002DAC RID: 11692
		// (get) Token: 0x06009E35 RID: 40501 RVA: 0x0007C7C1 File Offset: 0x0007A9C1
		public IDictionary<SectionCapacityMethodType, string> AvailableSectionCapacity
		{
			get
			{
				return new Dictionary<SectionCapacityMethodType, string>
				{
					{
						SectionCapacityMethodType.MomentCapacity,
						Strings.StringMomentCapacity
					},
					{
						SectionCapacityMethodType.CriticalCapacity,
						Strings.StringCriticalCapacity
					}
				};
			}
		}

		// Token: 0x17002DAD RID: 11693
		// (get) Token: 0x06009E36 RID: 40502 RVA: 0x00219034 File Offset: 0x00217234
		public IDictionary<LoadType, string> AvailableLoadTypes
		{
			get
			{
				return new Dictionary<LoadType, string>
				{
					{
						LoadType.Undefined,
						Strings.StringLoadNotDefined
					},
					{
						LoadType.Factored,
						Strings.StringFactoredLoads
					},
					{
						LoadType.Axial,
						Strings.StringAxialLoadPoints
					},
					{
						LoadType.Service,
						Strings.StringServiceLoads
					},
					{
						LoadType.NoLoads,
						Strings.StringNoLoads_PASCAL
					}
				};
			}
		}

		// Token: 0x17002DAE RID: 11694
		// (get) Token: 0x06009E37 RID: 40503 RVA: 0x0007C7E0 File Offset: 0x0007A9E0
		public IDictionary<bool, string> YesNo
		{
			get
			{
				return new Dictionary<bool, string>
				{
					{
						true,
						Strings.StringYes
					},
					{
						false,
						Strings.StringNo
					}
				};
			}
		}

		// Token: 0x17002DAF RID: 11695
		// (get) Token: 0x06009E38 RID: 40504 RVA: 0x0007C7FF File Offset: 0x0007A9FF
		public IEnumerable<int> AvailableLabelSizes { get; } = new List<int>
		{
			8,
			9,
			10,
			11,
			12,
			14,
			16,
			18,
			20,
			22,
			24,
			26,
			28,
			36,
			48,
			72
		};

		// Token: 0x17002DB0 RID: 11696
		// (get) Token: 0x06009E39 RID: 40505 RVA: 0x0007C807 File Offset: 0x0007AA07
		public IDictionary<Diagram2DTextSize, string> AvailableDiagram2DTextSize
		{
			get
			{
				return new Dictionary<Diagram2DTextSize, string>
				{
					{
						Diagram2DTextSize.Small,
						#Phc.#3hc(107314048)
					},
					{
						Diagram2DTextSize.Medium,
						#Phc.#3hc(107314075)
					},
					{
						Diagram2DTextSize.Large,
						#Phc.#3hc(107314070)
					}
				};
			}
		}

		// Token: 0x17002DB1 RID: 11697
		// (get) Token: 0x06009E3A RID: 40506 RVA: 0x0007C841 File Offset: 0x0007AA41
		public IDictionary<Diagram2DLoadPointSize, string> AvailableDiagram2DLoadPointSize
		{
			get
			{
				return new Dictionary<Diagram2DLoadPointSize, string>
				{
					{
						Diagram2DLoadPointSize.Small,
						#Phc.#3hc(107314065)
					},
					{
						Diagram2DLoadPointSize.Medium,
						#Phc.#3hc(107314024)
					},
					{
						Diagram2DLoadPointSize.Large,
						#Phc.#3hc(107314047)
					}
				};
			}
		}

		// Token: 0x17002DB2 RID: 11698
		// (get) Token: 0x06009E3B RID: 40507 RVA: 0x0007C87B File Offset: 0x0007AA7B
		public IDictionary<Diagram2DAspectRatio, string> AvailableDiagram2DAspectRatio
		{
			get
			{
				return new Dictionary<Diagram2DAspectRatio, string>
				{
					{
						Diagram2DAspectRatio.Proportional,
						#Phc.#3hc(107314038)
					},
					{
						Diagram2DAspectRatio.Auto,
						#Phc.#3hc(107380616)
					}
				};
			}
		}

		// Token: 0x17002DB3 RID: 11699
		// (get) Token: 0x06009E3C RID: 40508 RVA: 0x0007C8A4 File Offset: 0x0007AAA4
		public IDictionary<Diagram2DLineType, string> AvailableDiagram2DLineType
		{
			get
			{
				return new Dictionary<Diagram2DLineType, string>
				{
					{
						Diagram2DLineType.Dashed,
						#Phc.#3hc(107313989)
					},
					{
						Diagram2DLineType.Solid,
						#Phc.#3hc(107314012)
					}
				};
			}
		}

		// Token: 0x17002DB4 RID: 11700
		// (get) Token: 0x06009E3D RID: 40509 RVA: 0x0007C8CD File Offset: 0x0007AACD
		public IDictionary<Diagram2DLineThickness, string> AvailableDiagram2DLineThickness
		{
			get
			{
				return new Dictionary<Diagram2DLineThickness, string>
				{
					{
						Diagram2DLineThickness.Thin,
						#Phc.#3hc(107314003)
					},
					{
						Diagram2DLineThickness.Medium,
						#Phc.#3hc(107314024)
					},
					{
						Diagram2DLineThickness.Thick,
						#Phc.#3hc(107313962)
					}
				};
			}
		}

		// Token: 0x17002DB5 RID: 11701
		// (get) Token: 0x06009E3E RID: 40510 RVA: 0x0007C907 File Offset: 0x0007AB07
		public IDictionary<ValuesOnAxesType, string> AvailableDiagram2DValuesOnAxesType
		{
			get
			{
				return new Dictionary<ValuesOnAxesType, string>
				{
					{
						ValuesOnAxesType.Auto,
						#Phc.#3hc(107380616)
					},
					{
						ValuesOnAxesType.MaxOnly,
						#Phc.#3hc(107313953)
					}
				};
			}
		}

		// Token: 0x17002DB6 RID: 11702
		// (get) Token: 0x06009E3F RID: 40511 RVA: 0x0007C930 File Offset: 0x0007AB30
		public IDictionary<CameraType, string> AvailableDiagram3DCameraTypes
		{
			get
			{
				return new Dictionary<CameraType, string>
				{
					{
						CameraType.Perspective,
						Strings.StringPerspective
					},
					{
						CameraType.Orthographic,
						Strings.StringIsometric
					}
				};
			}
		}

		// Token: 0x17002DB7 RID: 11703
		// (get) Token: 0x06009E40 RID: 40512 RVA: 0x00219084 File Offset: 0x00217284
		public IDictionary<double, string> AvailableLinesThickness
		{
			get
			{
				return new Dictionary<double, string>
				{
					{
						0.5,
						Strings.StringThin
					},
					{
						1.0,
						Strings.StringMedium
					},
					{
						1.5,
						Strings.StringThick
					}
				};
			}
		}

		// Token: 0x17002DB8 RID: 11704
		// (get) Token: 0x06009E41 RID: 40513 RVA: 0x002190D4 File Offset: 0x002172D4
		public IDictionary<double, string> AvailableLoadPointSize
		{
			get
			{
				return new Dictionary<double, string>
				{
					{
						3.0,
						Strings.StringSmall
					},
					{
						4.0,
						Strings.StringMedium
					},
					{
						5.0,
						Strings.StringLarge
					}
				};
			}
		}

		// Token: 0x04004465 RID: 17509
		[CompilerGenerated]
		private readonly IEnumerable<int> #a;
	}
}
