using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #6re;
using #7hc;
using #o1d;
using #owe;
using #Oze;
using #rCe;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams
{
	// Token: 0x02001205 RID: 4613
	public sealed class ReportDiagramsHandler
	{
		// Token: 0x06009A99 RID: 39577 RVA: 0x0020DC24 File Offset: 0x0020BE24
		public void #sAe(#uwe #mA, #lte #Od, #yse #iw, DesignEngine #rj)
		{
			ReportDiagramsHandler.#GTb #GTb = new ReportDiagramsHandler.#GTb();
			#GTb.#a = #mA;
			if (#GTb.#a == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			if (#iw == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381742));
			}
			if (!#Od.IsReportSourceValid || #rj == null)
			{
				return;
			}
			IList<ReporterImage> #7p = new ReportDiagramsHandler().#fp(#iw, #Od, #rj);
			#GTb.#a.Screenshots.Children.Clear();
			#7p.#I1d(new Action<ReporterImage>(#GTb.#jdf));
		}

		// Token: 0x06009A9A RID: 39578 RVA: 0x0020DCC0 File Offset: 0x0020BEC0
		public bool #Dcb(DesignEngine #rj, #LCe #Pc, bool #Ecb)
		{
			if (#Pc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107395311));
			}
			if (!#Pc.ReportingModel.IsReportSourceValid || #rj == null)
			{
				return false;
			}
			UniCurve[] array = #rj.#rOe(true, #Pc.Parameter);
			UniCurve[] array2 = #rj.#rOe(false, #Pc.Parameter);
			if (array2 != null)
			{
				#Pc.FactoredDiagram = new #vCe
				{
					UniCurve = new #dEe
					{
						UniCurve = array2,
						SpliceLines = #Pc.ReportingModel.Output.FactoredInteractionDiagram.SpliceLines,
						DrawOptions = this.#tAe(#Pc)
					}
				};
			}
			if (array != null)
			{
				#Pc.NominalDiagram = new #vCe
				{
					UniCurve = new #dEe
					{
						SpliceLines = #Pc.ReportingModel.Output.NominalInteractionDiagram.SpliceLines,
						UniCurve = array,
						DrawOptions = this.#tAe(#Pc)
					}
				};
			}
			return true;
		}

		// Token: 0x06009A9B RID: 39579 RVA: 0x0020DDA0 File Offset: 0x0020BFA0
		public bool #Fcb(DesignEngine #rj, #LCe #Pc)
		{
			if (#Pc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107395311));
			}
			if (!#Pc.ReportingModel.IsReportSourceValid || #rj == null)
			{
				return false;
			}
			BiCurve biCurve = #rj.#sOe(true, #Pc.Parameter);
			BiCurve biCurve2 = #rj.#sOe(false, #Pc.Parameter);
			if (biCurve2 != null)
			{
				#Pc.FactoredDiagram = new #vCe
				{
					BiCurve = new #aEe
					{
						BiCurve = biCurve2,
						DrawOptions = this.#tAe(#Pc)
					}
				};
			}
			if (biCurve != null)
			{
				#Pc.NominalDiagram = new #vCe
				{
					BiCurve = new #aEe
					{
						BiCurve = biCurve,
						DrawOptions = this.#tAe(#Pc)
					}
				};
			}
			return true;
		}

		// Token: 0x06009A9C RID: 39580 RVA: 0x0020DE4C File Offset: 0x0020C04C
		public IList<ReporterImage> #fp(#yse #iw, #lte #Od, DesignEngine #rj)
		{
			if (#iw == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381742));
			}
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			Stopwatch stopwatch = Stopwatch.StartNew();
			List<ReporterImage> list = new List<ReporterImage>();
			if (!#Od.IsReportSourceValid || #rj == null)
			{
				return list;
			}
			#l4e #l4e = #Od.Output;
			if (((#l4e != null) ? #l4e.FactoredInteractionDiagram : null) == null)
			{
				#l4e #l4e2 = #Od.Output;
				if (((#l4e2 != null) ? #l4e2.NominalInteractionDiagram : null) == null)
				{
					return list;
				}
			}
			#xse #xAe = #iw.#hJ();
			#Gse #wAe = #iw.#kJ();
			#5re #vAe = #iw.#jJ();
			IEnumerable<Diagram2DData> source = (#Od.Input.Options.ConsideredAxis != ConsideredAxis.Both) ? this.#zAe(#vAe, #wAe, #Od, #rj) : this.#uAe(#vAe, #wAe, #xAe, #Od, #rj);
			list.AddRange(source.Select(new Func<Diagram2DData, ReporterImage>(ReportDiagramsHandler.<>c.<>9.#kdf)));
			list.AddRange(#Od.Images);
			list = list.Where(new Func<ReporterImage, bool>(ReportDiagramsHandler.<>c.<>9.#ldf)).ToList<ReporterImage>();
			stopwatch.Stop();
			return this.#AAe(list);
		}

		// Token: 0x06009A9D RID: 39581 RVA: 0x0007A61C File Offset: 0x0007881C
		private #7De #tAe(#LCe #Pc)
		{
			return new #7De
			{
				Parameter = (float)#Pc.Parameter,
				AxialLoadUnit = #Pc.ReportingModel.GeneralInfo.UnitStringF,
				MomentUnit = #Pc.ReportingModel.GeneralInfo.UnitStringM
			};
		}

		// Token: 0x06009A9E RID: 39582 RVA: 0x0007A65C File Offset: 0x0007885C
		private IEnumerable<Diagram2DData> #uAe(#5re #vAe, #8re #wAe, #xse #xAe, #lte #Od, DesignEngine #rj)
		{
			LoadPointsHelper loadPointsHelper = new LoadPointsHelper(#Od, #xAe);
			foreach (double #Sb in loadPointsHelper.#oAe().OrderBy(new Func<double, double>(ReportDiagramsHandler.<>c.<>9.#mdf)))
			{
				yield return this.#yAe(#rj, #vAe, #wAe, #Od, Diagram2DType.DiagramPM, #Sb);
			}
			IEnumerator<double> enumerator = null;
			foreach (double #Sb2 in loadPointsHelper.#Yne().OrderBy(new Func<double, double>(ReportDiagramsHandler.<>c.<>9.#ndf)))
			{
				yield return this.#yAe(#rj, #vAe, #wAe, #Od, Diagram2DType.DiagramMM, #Sb2);
			}
			enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06009A9F RID: 39583 RVA: 0x0020DF78 File Offset: 0x0020C178
		private Diagram2DData #yAe(DesignEngine #rj, #5re #vAe, #8re #wAe, #lte #Od, Diagram2DType #C, double #Sb)
		{
			bool flag = #Od.Input.Options.ConsideredAxis == ConsideredAxis.Both;
			#LCe #LCe = new #LCe(#Od, #vAe, #C, #Sb);
			#LCe.Filters = #wAe;
			#LCe.ViewportHeight = 1000.0;
			#LCe.ViewportWidth = 1000.0;
			if (#C == Diagram2DType.DiagramMM)
			{
				if (!this.#Fcb(#rj, #LCe))
				{
					return null;
				}
			}
			else if (!this.#Dcb(#rj, #LCe, flag))
			{
				return null;
			}
			return new Diagram2DData
			{
				DiagramType = #C,
				Parameters = #LCe,
				IsCustom = flag,
				Description = #Qze.#Pze(#Od, #C, #Sb, false),
				FactoredIncluded = #vAe.ShowFactored,
				NominalIncluded = #vAe.ShowNominal
			};
		}

		// Token: 0x06009AA0 RID: 39584 RVA: 0x0007A691 File Offset: 0x00078891
		private IEnumerable<Diagram2DData> #zAe(#5re #vAe, #8re #wAe, #lte #Od, DesignEngine #rj)
		{
			if (#Od.Input.Options.ConsideredAxis != ConsideredAxis.Both)
			{
				yield return this.#yAe(#rj, #vAe, #wAe, #Od, Diagram2DType.DiagramPM, 0.0);
			}
			yield break;
		}

		// Token: 0x06009AA1 RID: 39585 RVA: 0x00038482 File Offset: 0x00036682
		private IList<ReporterImage> #AAe(IList<ReporterImage> #aLb)
		{
			return #aLb;
		}

		// Token: 0x02001207 RID: 4615
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06009AAA RID: 39594 RVA: 0x0007A6D2 File Offset: 0x000788D2
			internal void #jdf(ReporterImage #Rf)
			{
				#Rf.#Fte(this.#a);
			}

			// Token: 0x04004282 RID: 17026
			public #uwe #a;
		}
	}
}
