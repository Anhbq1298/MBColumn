using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using #7hc;
using #rCe;
using #v1c;
using #wdd;
using #Wse;
using #xBe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.FailureSurface;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.ImportExport
{
	// Token: 0x0200120D RID: 4621
	public sealed class DiagramExporter : #ned, #yBe
	{
		// Token: 0x06009AEC RID: 39660 RVA: 0x0007A981 File Offset: 0x00078B81
		public DiagramExporter(#v2c fileSystemService)
		{
			this.#a = fileSystemService;
		}

		// Token: 0x06009AED RID: 39661 RVA: 0x0020E89C File Offset: 0x0020CA9C
		public bool #KAe(#lte #Od, #qCe #Gfb, ExportDiagramType #2bb)
		{
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			if (#Gfb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107376321));
			}
			if (#Gfb.Diagram2DType == null)
			{
				return false;
			}
			string text = this.#yRb(#Od, #2bb, false);
			if (string.IsNullOrWhiteSpace(text))
			{
				return false;
			}
			Diagram2DType? diagram2DType = #Gfb.Diagram2DType;
			Diagram2DType diagram2DType2 = Diagram2DType.DiagramPM;
			bool flag;
			if (!(diagram2DType.GetValueOrDefault() == diagram2DType2 & diagram2DType != null))
			{
				diagram2DType = #Gfb.Diagram2DType;
				diagram2DType2 = Diagram2DType.DiagramPMMinus;
				flag = (diagram2DType.GetValueOrDefault() == diagram2DType2 & diagram2DType != null);
			}
			else
			{
				flag = true;
			}
			bool flag2 = flag;
			diagram2DType = #Gfb.Diagram2DType;
			diagram2DType2 = Diagram2DType.DiagramPM;
			bool flag3;
			if (!(diagram2DType.GetValueOrDefault() == diagram2DType2 & diagram2DType != null))
			{
				diagram2DType = #Gfb.Diagram2DType;
				diagram2DType2 = Diagram2DType.DiagramPMPlus;
				flag3 = (diagram2DType.GetValueOrDefault() == diagram2DType2 & diagram2DType != null);
			}
			else
			{
				flag3 = true;
			}
			bool flag4 = flag3;
			List<string> list = new List<string>();
			if (flag4 || flag2)
			{
				#dEe #Rf = (#2bb == ExportDiagramType.Factored) ? #Gfb.Diagram2DPMFactored : #Gfb.Diagram2DPMNominal;
				this.#QAe(#Rf, #Od.Input.Options.IsACI(), flag2, flag4, list, #LBe.#EBe(text));
			}
			else
			{
				diagram2DType = #Gfb.Diagram2DType;
				diagram2DType2 = Diagram2DType.DiagramMM;
				if (diagram2DType.GetValueOrDefault() == diagram2DType2 & diagram2DType != null)
				{
					#aEe #NAe = (#2bb == ExportDiagramType.Factored) ? #Gfb.Diagram2DMMFactored : #Gfb.Diagram2DMMNominal;
					this.#MAe(#NAe, #Od.Input.Options.IsACI(), #LBe.#EBe(text), list);
				}
			}
			if (list.Any<string>())
			{
				this.#a.#41c(text, list, Encoding.ASCII);
			}
			return true;
		}

		// Token: 0x06009AEE RID: 39662 RVA: 0x0020EA2C File Offset: 0x0020CC2C
		public bool #LAe(#lte #Od, #qCe #Gfb, ExportDiagramType #2bb)
		{
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			if (#Gfb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107376321));
			}
			string text = this.#yRb(#Od, #2bb, true);
			if (string.IsNullOrWhiteSpace(text))
			{
				return false;
			}
			List<string> list = new List<string>();
			List<FailureSurfaceData> #Od2 = (#2bb == ExportDiagramType.Factored) ? #Gfb.Diagram3D.FactoredFailureSurfaceData : #Gfb.Diagram3D.NominalFailureSurfaceData;
			this.#PAe(#Od2, #Od.Input.Options.IsACI(), #LBe.#EBe(text), list);
			if (list.Any<string>())
			{
				this.#a.#41c(text, list, Encoding.ASCII);
			}
			return true;
		}

		// Token: 0x06009AEF RID: 39663 RVA: 0x0007A990 File Offset: 0x00078B90
		private string #JAe(float #f)
		{
			return #ned.#qp(new float?(#f), NativeNumberFormat.F8_6, #Phc.#3hc(107381628));
		}

		// Token: 0x06009AF0 RID: 39664 RVA: 0x0020EAD0 File Offset: 0x0020CCD0
		private void #MAe(#aEe #NAe, bool #OAe, string #C6c, List<string> #En)
		{
			int num = 6;
			string #f = #LBe.#HBe(#OAe ? 8 : 7, #C6c, new int[]
			{
				num,
				num,
				num,
				num,
				num,
				num,
				num,
				num
			});
			string item = #LBe.#GBe(#C6c, #OAe);
			#En.Add(item);
			BiCurve biCurve = #NAe.BiCurve;
			for (int i = 0; i < #NAe.BiCurve.AngleOfNeutralAxisC.Length; i++)
			{
				#En.Add(#f.#D2d(new object[]
				{
					this.#JAe(biCurve.AxialLoad),
					this.#JAe(biCurve.MomentX[i]),
					this.#JAe(biCurve.MomentY[i]),
					this.#JAe(biCurve.DepthOfNeutralAxisC[i]),
					this.#JAe(biCurve.AngleOfNeutralAxisC[i]),
					this.#JAe(biCurve.Dt[i]),
					this.#JAe(biCurve.BarMaximumStrainEps[i]),
					this.#JAe(biCurve.PhiFactor[i])
				}));
			}
			if (#NAe.BiCurve.AngleOfNeutralAxisC.Length != 0)
			{
				int num2 = 0;
				#En.Add(#f.#D2d(new object[]
				{
					this.#JAe(biCurve.AxialLoad),
					this.#JAe(biCurve.MomentX[num2]),
					this.#JAe(biCurve.MomentY[num2]),
					this.#JAe(biCurve.DepthOfNeutralAxisC[num2]),
					this.#JAe(biCurve.AngleOfNeutralAxisC[num2]),
					this.#JAe(biCurve.Dt[num2]),
					this.#JAe(biCurve.BarMaximumStrainEps[num2]),
					this.#JAe(biCurve.PhiFactor[num2])
				}));
			}
		}

		// Token: 0x06009AF1 RID: 39665 RVA: 0x0020ECA0 File Offset: 0x0020CEA0
		private void #PAe(List<FailureSurfaceData> #Od, bool #OAe, string #C6c, List<string> #En)
		{
			int num = 6;
			string #f = #LBe.#HBe(#OAe ? 8 : 7, #C6c, new int[]
			{
				num,
				num,
				num,
				num,
				num,
				num,
				num,
				num
			});
			#En.Add(#f.#D2d(new object[]
			{
				#Phc.#3hc(107283000),
				#Phc.#3hc(107282951),
				#Phc.#3hc(107282970),
				#Phc.#3hc(107283437),
				#Phc.#3hc(107283452),
				#Phc.#3hc(107283403),
				#Phc.#3hc(107252016),
				#Phc.#3hc(107283398)
			}));
			foreach (FailureSurfaceData failureSurfaceData in #Od)
			{
				#En.Add(#f.#D2d(new object[]
				{
					this.#JAe(failureSurfaceData.AxialForceOriginal),
					this.#JAe(failureSurfaceData.MomentX),
					this.#JAe(failureSurfaceData.MomentY),
					this.#JAe(failureSurfaceData.NADepth),
					this.#JAe(failureSurfaceData.NAAngle),
					this.#JAe(failureSurfaceData.Dt),
					this.#JAe(failureSurfaceData.Epst),
					this.#JAe(failureSurfaceData.PhiFactor)
				}));
			}
		}

		// Token: 0x06009AF2 RID: 39666 RVA: 0x0020EE34 File Offset: 0x0020D034
		private void #QAe(#dEe #Rf, bool #OAe, bool #RAe, bool #SAe, List<string> #En, string #C6c)
		{
			int num = 6;
			string #cA = #LBe.#HBe(#OAe ? 6 : 5, #C6c, new int[]
			{
				num,
				num,
				num,
				0,
				num,
				num
			});
			string item = #LBe.#FBe(#C6c, #OAe);
			#En.Add(item);
			if (#SAe)
			{
				this.#TAe(#Rf.UniCurve, new Func<UniCurve, UniCurveData>(DiagramExporter.<>c.<>9.#Wbi), #cA, #En);
			}
			if (#RAe)
			{
				this.#TAe(#Rf.UniCurve, new Func<UniCurve, UniCurveData>(DiagramExporter.<>c.<>9.#Xbi), #cA, #En);
			}
		}

		// Token: 0x06009AF3 RID: 39667 RVA: 0x0020EEE0 File Offset: 0x0020D0E0
		private void #TAe(ICollection<UniCurve> #UAe, Func<UniCurve, UniCurveData> #VAe, string #cA, List<string> #En)
		{
			foreach (UniCurve uniCurve in #UAe.Where(new Func<UniCurve, bool>(DiagramExporter.<>c.<>9.#Ybi)))
			{
				UniCurveData uniCurveData = #VAe(uniCurve);
				float #f = ((double)Math.Abs(uniCurveData.Moment) < 0.0001) ? 0f : uniCurveData.Moment;
				#En.Add(#cA.#D2d(new object[]
				{
					this.#JAe(#f),
					this.#JAe(uniCurve.AxialLoad),
					this.#JAe(uniCurveData.DepthOfNeutralAxisC),
					this.#JAe(uniCurveData.AngleOfNeutralAxisCAngle),
					this.#JAe(uniCurveData.BarMaximumStrainEps),
					this.#JAe(uniCurveData.ReductionFactorPhi)
				}));
			}
		}

		// Token: 0x06009AF4 RID: 39668 RVA: 0x0020EFE0 File Offset: 0x0020D1E0
		private string #yRb(#lte #Od, ExportDiagramType #2bb, bool #WAe)
		{
			string directoryName = Path.GetDirectoryName(#Od.GeneralInfo.FileName);
			string #f = Path.GetFileNameWithoutExtension(#Od.GeneralInfo.FileName) + #Phc.#3hc(107408434) + #2bb.ToString() + #Phc.#3hc(107283413);
			#62c #21c = new #62c(this.#XAe(#Od.Input.Options.ConsideredAxis, #WAe), #Phc.#3hc(107408483), directoryName)
			{
				InitialFileName = #f
			};
			return this.#a.#11c(#21c);
		}

		// Token: 0x06009AF5 RID: 39669 RVA: 0x0007A9A9 File Offset: 0x00078BA9
		private #L1c[] #XAe(ConsideredAxis #Tye, bool #WAe)
		{
			if (!#WAe)
			{
			}
			return new #L1c[]
			{
				new #L1c(Strings.StringCommaSeparatedValueFiles, #Phc.#3hc(107408483)),
				new #L1c(Strings.StringTabDelimitedTextFiles, #Phc.#3hc(107413479))
			};
		}

		// Token: 0x040042B3 RID: 17075
		private readonly #v2c #a;
	}
}
