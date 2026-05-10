using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #58e;
using #7hc;
using #v1c;
using #xBe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.FailureSurface;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.DataExchange.CSV;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.ImportExport
{
	// Token: 0x02001210 RID: 4624
	public sealed class DiagramImporter : #zBe
	{
		// Token: 0x06009AFD RID: 39677 RVA: 0x0007AA0A File Offset: 0x00078C0A
		public DiagramImporter(#v2c fileSystemService, #48e initialPathProvider)
		{
			this.#a = fileSystemService;
			this.#b = initialPathProvider;
		}

		// Token: 0x06009AFE RID: 39678 RVA: 0x0007AA20 File Offset: 0x00078C20
		public IReadOnlyList<#DBe> #YAe()
		{
			return this.#0Ae(new Action<List<#DBe>, string>(this.#4Ae), true);
		}

		// Token: 0x06009AFF RID: 39679 RVA: 0x0007AA35 File Offset: 0x00078C35
		public IReadOnlyList<#DBe> #ZAe()
		{
			return this.#0Ae(new Action<List<#DBe>, string>(this.#3Ae), false);
		}

		// Token: 0x06009B00 RID: 39680 RVA: 0x0020F070 File Offset: 0x0020D270
		private IReadOnlyList<#DBe> #0Ae(Action<List<#DBe>, string> #1Ae, bool #2Ae)
		{
			List<#DBe> list = new List<#DBe>();
			foreach (string arg in this.#vcb())
			{
				#1Ae(list, arg);
			}
			return list;
		}

		// Token: 0x06009B01 RID: 39681 RVA: 0x0020F0A8 File Offset: 0x0020D2A8
		private void #3Ae(List<#DBe> #PE, string #4Hc)
		{
			string #Ukc = this.#a.#f2c(#4Hc);
			string text = #LBe.#EBe(#4Hc);
			List<CSVRow> list = CSVHelper.#Tkc(#Ukc, new string[]
			{
				text
			}).Skip(1).ToList<CSVRow>();
			if (list.Count != 2520)
			{
				throw new InvalidDataException(Strings.StringSolutionIsBiaxialCannotSuperimpose2DDiagram);
			}
			FailureSurfaceData[] array = this.#bBe(list);
			BiCurve[] #f = #wBe.#uBe(array);
			#DBe item = new #DBe
			{
				FailureSurface = array,
				BiCurves = #f,
				FilePath = #4Hc,
				RunAxis = ConsideredAxis.Both
			};
			#PE.Add(item);
		}

		// Token: 0x06009B02 RID: 39682 RVA: 0x0020F138 File Offset: 0x0020D338
		private void #4Ae(List<#DBe> #PE, string #4Hc)
		{
			string #Ukc = this.#a.#f2c(#4Hc);
			string text = #LBe.#EBe(#4Hc);
			IList<CSVRow> list = CSVHelper.#Tkc(#Ukc, new string[]
			{
				text
			});
			List<CSVRow> #6Ae = list.Skip(1).ToList<CSVRow>();
			Diagram2DType diagram2DType = this.#iBe(list);
			if (diagram2DType - Diagram2DType.DiagramPM <= 2)
			{
				#PE.Add(this.#5Ae(#6Ae, diagram2DType, #4Hc));
				return;
			}
			throw new InvalidDataException(Strings.StringCannotSuperimposeImportedDiagramHasDifferentRunAxis);
		}

		// Token: 0x06009B03 RID: 39683 RVA: 0x0020F1A0 File Offset: 0x0020D3A0
		private #DBe #5Ae(IList<CSVRow> #6Ae, Diagram2DType #7Ae, string #4Hc)
		{
			bool flag = #7Ae == Diagram2DType.DiagramPMPlus || #7Ae == Diagram2DType.DiagramPM;
			bool flag2 = #7Ae == Diagram2DType.DiagramPMMinus || #7Ae == Diagram2DType.DiagramPM;
			UniCurve[] array = this.#8Ae(#6Ae, flag, flag2);
			ConsideredAxis #f = this.#kBe(array, flag, flag2);
			return new #DBe
			{
				UniCurve = array,
				FilePath = #4Hc,
				RunAxis = #f
			};
		}

		// Token: 0x06009B04 RID: 39684 RVA: 0x0020F1F4 File Offset: 0x0020D3F4
		private UniCurve[] #8Ae(IList<CSVRow> #6Ae, bool #9Ae, bool #aBe)
		{
			bool flag = #9Ae && #aBe;
			int num = flag ? (#6Ae.Count / 2) : #6Ae.Count;
			UniCurve[] array = this.#cBe(num, #9Ae, #aBe);
			if (#9Ae)
			{
				IList<CSVRow> list;
				if (!flag)
				{
					list = #6Ae;
				}
				else
				{
					IList<CSVRow> list2 = #6Ae.Take(num).ToList<CSVRow>();
					list = list2;
				}
				IList<CSVRow> #Zgb = list;
				this.#fBe(array, #Zgb, new Func<UniCurve, UniCurveData>(DiagramImporter.<>c.<>9.#Zbi));
			}
			if (#aBe)
			{
				IList<CSVRow> list3;
				if (!flag)
				{
					list3 = #6Ae;
				}
				else
				{
					IList<CSVRow> list2 = #6Ae.Skip(num).ToList<CSVRow>();
					list3 = list2;
				}
				IList<CSVRow> #Zgb2 = list3;
				this.#fBe(array, #Zgb2, new Func<UniCurve, UniCurveData>(DiagramImporter.<>c.<>9.#0bi));
			}
			return array;
		}

		// Token: 0x06009B05 RID: 39685 RVA: 0x0020F2A8 File Offset: 0x0020D4A8
		private FailureSurfaceData[] #bBe(IList<CSVRow> #6Ae)
		{
			FailureSurfaceData[] array = new FailureSurfaceData[#6Ae.Count];
			for (int i = 0; i < #6Ae.Count; i++)
			{
				CSVRow csvrow = #6Ae[i];
				float #f = this.#hBe(csvrow.Cells[0].Value);
				float #f2 = this.#hBe(csvrow.Cells[1].Value);
				float #f3 = this.#hBe(csvrow.Cells[2].Value);
				float #f4 = this.#hBe(csvrow.Cells[3].Value);
				float #f5 = this.#hBe(csvrow.Cells[4].Value);
				float #f6 = this.#hBe(csvrow.Cells[5].Value);
				float #f7 = this.#hBe(csvrow.Cells[6].Value);
				float #f8 = (csvrow.Cells.Count == 8) ? this.#hBe(csvrow.Cells[7].Value) : 0f;
				array[i].AxialForce = #f;
				array[i].AxialForceOriginal = #f;
				array[i].MomentX = #f2;
				array[i].MomentY = #f3;
				array[i].NADepth = #f4;
				array[i].NAAngle = #f5;
				array[i].Dt = #f6;
				array[i].Epst = #f7;
				array[i].PhiFactor = #f8;
			}
			return array;
		}

		// Token: 0x06009B06 RID: 39686 RVA: 0x0020F43C File Offset: 0x0020D63C
		private UniCurve[] #cBe(int #1f, bool #dBe, bool #eBe)
		{
			UniCurve[] array = new UniCurve[#1f];
			for (int i = 0; i < #1f; i++)
			{
				array[i] = new UniCurve
				{
					PlotPoint = true,
					PositiveSide = (#dBe ? new UniCurveData() : null),
					NegativeSide = (#eBe ? new UniCurveData() : null)
				};
			}
			return array;
		}

		// Token: 0x06009B07 RID: 39687 RVA: 0x0020F490 File Offset: 0x0020D690
		private void #fBe(UniCurve[] #NAe, IList<CSVRow> #Zgb, Func<UniCurve, UniCurveData> #VAe)
		{
			for (int i = 0; i < #Zgb.Count; i++)
			{
				CSVRow #uI = #Zgb[i];
				UniCurve #NAe2 = #NAe[i];
				this.#gBe(#NAe2, #uI, #VAe);
			}
		}

		// Token: 0x06009B08 RID: 39688 RVA: 0x0020F4C4 File Offset: 0x0020D6C4
		private void #gBe(UniCurve #NAe, CSVRow #uI, Func<UniCurve, UniCurveData> #VAe)
		{
			UniCurveData uniCurveData = #VAe(#NAe);
			float #f = this.#hBe(#uI.Cells[0].Value);
			float #f2 = this.#hBe(#uI.Cells[1].Value);
			float #f3 = this.#hBe(#uI.Cells[2].Value);
			float #f4 = this.#hBe(#uI.Cells[3].Value);
			float #f5 = this.#hBe(#uI.Cells[4].Value);
			float #f6 = (#uI.Cells.Count == 6) ? this.#hBe(#uI.Cells[5].Value) : 0f;
			uniCurveData.Moment = #f;
			#NAe.AxialLoad = #f2;
			uniCurveData.DepthOfNeutralAxisC = #f3;
			uniCurveData.AngleOfNeutralAxisCAngle = #f4;
			uniCurveData.BarMaximumStrainEps = #f5;
			uniCurveData.ReductionFactorPhi = #f6;
		}

		// Token: 0x06009B09 RID: 39689 RVA: 0x0007AA4A File Offset: 0x00078C4A
		private float #hBe(string #f)
		{
			return float.Parse(#f, CultureInfo.InvariantCulture);
		}

		// Token: 0x06009B0A RID: 39690 RVA: 0x0020F5AC File Offset: 0x0020D7AC
		private Diagram2DType #iBe(IList<CSVRow> #Zgb)
		{
			CSVRow csvrow = #Zgb.FirstOrDefault<CSVRow>();
			int? num = (csvrow != null) ? new int?(csvrow.Cells.Count) : null;
			if (num != null)
			{
				int valueOrDefault = num.GetValueOrDefault();
				if (valueOrDefault - 5 <= 1)
				{
					return this.#jBe(#Zgb);
				}
				if (valueOrDefault - 7 <= 1)
				{
					return Diagram2DType.DiagramMM;
				}
			}
			throw new InvalidDataException(Strings.StringCouldNotImportDiagramIncompatibleDiagramFormat);
		}

		// Token: 0x06009B0B RID: 39691 RVA: 0x0020F610 File Offset: 0x0020D810
		private Diagram2DType #jBe(IList<CSVRow> #Zgb)
		{
			List<float> source = #Zgb.Skip(1).ToList<CSVRow>().Select(new Func<CSVRow, string>(DiagramImporter.<>c.<>9.#1bi)).Select(new Func<string, float>(DiagramImporter.<>c.<>9.#2bi)).Where(new Func<float, bool>(this.#Xai)).ToList<float>();
			IEnumerable<float> source2 = source.Where(new Func<float, bool>(DiagramImporter.<>c.<>9.#3bi));
			IEnumerable<float> source3 = source.Where(new Func<float, bool>(DiagramImporter.<>c.<>9.#4bi));
			if (!source2.Any<float>())
			{
				return Diagram2DType.DiagramPMMinus;
			}
			if (!source3.Any<float>())
			{
				return Diagram2DType.DiagramPMPlus;
			}
			return Diagram2DType.DiagramPM;
		}

		// Token: 0x06009B0C RID: 39692 RVA: 0x0020F6E8 File Offset: 0x0020D8E8
		private ConsideredAxis #kBe(UniCurve[] #UAe, bool #lBe, bool #mBe)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = (#lBe && #mBe) ? 140 : 70;
			if (#lBe)
			{
				num += #UAe.Where(new Func<UniCurve, bool>(DiagramImporter.<>c.<>9.#5bi)).Count(new Func<UniCurve, bool>(this.#Yai));
				num2 += #UAe.Where(new Func<UniCurve, bool>(DiagramImporter.<>c.<>9.#6bi)).Count(new Func<UniCurve, bool>(this.#Zai));
			}
			if (#mBe)
			{
				num3 += #UAe.Where(new Func<UniCurve, bool>(DiagramImporter.<>c.<>9.#7bi)).Count(new Func<UniCurve, bool>(this.#0ai));
				num4 += #UAe.Where(new Func<UniCurve, bool>(DiagramImporter.<>c.<>9.#8bi)).Count(new Func<UniCurve, bool>(this.#1ai));
			}
			if (num + num3 == num5)
			{
				return ConsideredAxis.X;
			}
			if (num2 + num4 == num5)
			{
				return ConsideredAxis.Y;
			}
			return ConsideredAxis.Both;
		}

		// Token: 0x06009B0D RID: 39693 RVA: 0x0007AA57 File Offset: 0x00078C57
		private bool #uC(float #5Gb, float #6Gb)
		{
			return Math.Abs(#5Gb - #6Gb) < 0.01f;
		}

		// Token: 0x06009B0E RID: 39694 RVA: 0x0020F80C File Offset: 0x0020DA0C
		private string[] #vcb()
		{
			string #Ao = this.#b.InitialPathForDiagramImportExport;
			#12c #R1c = new #12c(this.#XAe(), #Phc.#3hc(107408483), #Ao);
			string[] array = this.#a.#Q1c(#R1c);
			if (array == null)
			{
				return new string[0];
			}
			this.#nBe(array);
			return array;
		}

		// Token: 0x06009B0F RID: 39695 RVA: 0x0020F85C File Offset: 0x0020DA5C
		private void #nBe(string[] #oBe)
		{
			string directoryName = Path.GetDirectoryName(#oBe[0]);
			this.#b.InitialPathForDiagramImportExport = directoryName;
		}

		// Token: 0x06009B10 RID: 39696 RVA: 0x0007AA68 File Offset: 0x00078C68
		private bool #U3(float #f)
		{
			return Math.Abs(#f) < 0.001f;
		}

		// Token: 0x06009B11 RID: 39697 RVA: 0x0007AA77 File Offset: 0x00078C77
		private #L1c[] #XAe()
		{
			return new #L1c[]
			{
				new #L1c(Strings.StringCommaSeparatedValueFiles, #Phc.#3hc(107408483)),
				new #L1c(Strings.StringTabDelimitedTextFiles, #Phc.#3hc(107413479))
			};
		}

		// Token: 0x06009B12 RID: 39698 RVA: 0x0007AAAD File Offset: 0x00078CAD
		[CompilerGenerated]
		private bool #Xai(float #9o)
		{
			return !this.#U3(#9o);
		}

		// Token: 0x06009B13 RID: 39699 RVA: 0x0007AAB9 File Offset: 0x00078CB9
		[CompilerGenerated]
		private bool #Yai(UniCurve #b3b)
		{
			return this.#uC(#b3b.PositiveSide.AngleOfNeutralAxisCAngle, 0f);
		}

		// Token: 0x06009B14 RID: 39700 RVA: 0x0007AAD1 File Offset: 0x00078CD1
		[CompilerGenerated]
		private bool #Zai(UniCurve #b3b)
		{
			return this.#uC(#b3b.PositiveSide.AngleOfNeutralAxisCAngle, 90f);
		}

		// Token: 0x06009B15 RID: 39701 RVA: 0x0007AAE9 File Offset: 0x00078CE9
		[CompilerGenerated]
		private bool #0ai(UniCurve #b3b)
		{
			return this.#uC(#b3b.NegativeSide.AngleOfNeutralAxisCAngle, 180f);
		}

		// Token: 0x06009B16 RID: 39702 RVA: 0x0007AB01 File Offset: 0x00078D01
		[CompilerGenerated]
		private bool #1ai(UniCurve #b3b)
		{
			return this.#uC(#b3b.NegativeSide.AngleOfNeutralAxisCAngle, 270f);
		}

		// Token: 0x040042B8 RID: 17080
		private readonly #v2c #a;

		// Token: 0x040042B9 RID: 17081
		private readonly #48e #b;
	}
}
