using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #g7e;
using #Gke;
using #gMe;
using #hZe;
using #KUe;
using #P6e;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Output;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer
{
	// Token: 0x020012AC RID: 4780
	public sealed class DesignEngine
	{
		// Token: 0x0600A014 RID: 40980 RVA: 0x0007DB42 File Offset: 0x0007BD42
		public DesignEngine(ColumnStorageModel storageModel, #Q6e configuration)
		{
			this.InputModel = new InputModel();
			this.RuntimeModel = new RuntimeModel();
			this.InputModel.#eb(storageModel, configuration);
			this.RuntimeModel.#eb(storageModel, configuration);
			this.#eb();
		}

		// Token: 0x0600A015 RID: 40981 RVA: 0x0007DB80 File Offset: 0x0007BD80
		internal DesignEngine(#Hle mainModel, #Q6e configuration)
		{
			this.InputModel = new InputModel();
			this.RuntimeModel = new RuntimeModel();
			this.InputModel.#eb(mainModel);
			this.RuntimeModel.#eb(mainModel, configuration);
			this.#eb();
		}

		// Token: 0x17002E0B RID: 11787
		// (get) Token: 0x0600A016 RID: 40982 RVA: 0x0007DBBD File Offset: 0x0007BDBD
		// (set) Token: 0x0600A017 RID: 40983 RVA: 0x0007DBC5 File Offset: 0x0007BDC5
		public #dTe ReinforcementProperties { get; private set; }

		// Token: 0x17002E0C RID: 11788
		// (get) Token: 0x0600A018 RID: 40984 RVA: 0x0007DBCE File Offset: 0x0007BDCE
		// (set) Token: 0x0600A019 RID: 40985 RVA: 0x0007DBD6 File Offset: 0x0007BDD6
		public #l4e OutputModel { get; private set; }

		// Token: 0x17002E0D RID: 11789
		// (get) Token: 0x0600A01A RID: 40986 RVA: 0x0007DBDF File Offset: 0x0007BDDF
		public #nW MessageBus
		{
			get
			{
				return this.RuntimeModel.MessageBus;
			}
		}

		// Token: 0x17002E0E RID: 11790
		// (get) Token: 0x0600A01B RID: 40987 RVA: 0x0007DBEC File Offset: 0x0007BDEC
		// (set) Token: 0x0600A01C RID: 40988 RVA: 0x0007DBF4 File Offset: 0x0007BDF4
		internal #38e CodeExpert { get; private set; }

		// Token: 0x17002E0F RID: 11791
		// (get) Token: 0x0600A01D RID: 40989 RVA: 0x0007DBFD File Offset: 0x0007BDFD
		public #x0e GeometryProperties
		{
			get
			{
				return this.RuntimeModel.GeometryProperties;
			}
		}

		// Token: 0x17002E10 RID: 11792
		// (get) Token: 0x0600A01E RID: 40990 RVA: 0x0007DC0A File Offset: 0x0007BE0A
		internal InputModel InputModel { get; }

		// Token: 0x17002E11 RID: 11793
		// (get) Token: 0x0600A01F RID: 40991 RVA: 0x0007DC12 File Offset: 0x0007BE12
		internal RuntimeModel RuntimeModel { get; }

		// Token: 0x17002E12 RID: 11794
		// (get) Token: 0x0600A020 RID: 40992 RVA: 0x0007DC1A File Offset: 0x0007BE1A
		// (set) Token: 0x0600A021 RID: 40993 RVA: 0x0007DC22 File Offset: 0x0007BE22
		internal #3Qe MomentCapacityEx { get; set; }

		// Token: 0x17002E13 RID: 11795
		// (get) Token: 0x0600A022 RID: 40994 RVA: 0x0007DC2B File Offset: 0x0007BE2B
		public #b0e FactoredLoads
		{
			get
			{
				return this.RuntimeModel.FactoredLoads;
			}
		}

		// Token: 0x0600A023 RID: 40995 RVA: 0x00220420 File Offset: 0x0021E620
		public bool #qOe()
		{
			int #MOe = (this.InputModel.Options.ProblemType == #z6e.#a) ? this.InputModel.InvestigateInputFlag : this.InputModel.DesignInputFlag;
			return this.#d.#eTe(#MOe, this.InputModel.SlendernessInputFlag);
		}

		// Token: 0x0600A024 RID: 40996 RVA: 0x00220470 File Offset: 0x0021E670
		public void #0()
		{
			if (this.InputModel.Options.ProblemType == #z6e.#a)
			{
				this.#tOe();
				this.ReinforcementProperties.#bpb(true);
			}
			if (this.#qOe())
			{
				if (!this.#e.#PTe())
				{
					this.OutputModel.#vzc(Message.#qn(#M6e.#q, Array.Empty<object>()));
					return;
				}
				this.OutputModel.SolveCompleted = true;
				this.#vOe();
			}
		}

		// Token: 0x0600A025 RID: 40997 RVA: 0x002204E0 File Offset: 0x0021E6E0
		public UniCurve[] #rOe(bool #FJ, double #Udb)
		{
			#tPe #tPe = new #tPe(this.InputModel, this.RuntimeModel, this.CodeExpert, this.MomentCapacityEx);
			#y0e #y0e = #FJ ? this.OutputModel.NominalInteractionDiagram : this.OutputModel.FactoredInteractionDiagram;
			this.MessageBus.DebugContext.IsNominal = #FJ;
			if (#y0e == null)
			{
				return null;
			}
			if (this.InputModel.Options.ConsideredAxis != #C6e.#c)
			{
				return #y0e.UniCurve;
			}
			UniCurve[] result = #tPe.#3Oe(#y0e, (float)#Udb, false);
			this.MessageBus.DebugContext.IsNominal = false;
			return result;
		}

		// Token: 0x0600A026 RID: 40998 RVA: 0x00220574 File Offset: 0x0021E774
		public BiCurve #sOe(bool #FJ, double #Tdb)
		{
			if (this.InputModel.Options.ConsideredAxis != #C6e.#c)
			{
				return null;
			}
			#tPe #tPe = new #tPe(this.InputModel, this.RuntimeModel, this.CodeExpert, this.MomentCapacityEx);
			#y0e #y0e = #FJ ? this.OutputModel.NominalInteractionDiagram : this.OutputModel.FactoredInteractionDiagram;
			if (#y0e == null)
			{
				return null;
			}
			return #tPe.#2Oe(#y0e, (float)#Tdb);
		}

		// Token: 0x0600A027 RID: 40999 RVA: 0x002205E0 File Offset: 0x0021E7E0
		public void #tOe()
		{
			this.#e.#tOe();
			#K1e #K1e = this.RuntimeModel.ReinforcementBars;
			this.OutputModel.#cbi();
			for (int i = 0; i < #K1e.NumberOfBars; i++)
			{
				this.OutputModel.#vzc(new ReinforcementBar(#K1e.Bars[i]));
			}
		}

		// Token: 0x0600A028 RID: 41000 RVA: 0x0007DC38 File Offset: 0x0007BE38
		public void #uOe()
		{
			if (!this.InputModel.Options.ShouldConsiderSlenderness)
			{
				return;
			}
			this.#g.#uOe();
		}

		// Token: 0x0600A029 RID: 41001 RVA: 0x00220638 File Offset: 0x0021E838
		private void #vOe()
		{
			LoadPointDrawingDataHelper.#6Ve(this.InputModel, this.OutputModel);
			this.#f.#GVe(this.OutputModel);
			if (this.InputModel.Options.SectionType == #G6e.#c)
			{
				foreach (Points points in this.RuntimeModel.Solids.SectionFigures)
				{
					if (!points.IsEmpty)
					{
						IEnumerable<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point> source = points.InitialPoints.Take(points.NumberOfPoints);
						this.OutputModel.SectionPolygons.Add(new PolygonData(source.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point, Point3D>(DesignEngine.<>c.<>9.#kXi)), false));
					}
				}
				using (IEnumerator<Points> enumerator = this.RuntimeModel.Openings.SectionFigures.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Points points2 = enumerator.Current;
						if (!points2.IsEmpty)
						{
							IEnumerable<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point> source2 = points2.InitialPoints.Take(points2.NumberOfPoints);
							this.OutputModel.SectionPolygons.Add(new PolygonData(source2.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point, Point3D>(DesignEngine.<>c.<>9.#lXi)), true));
						}
					}
					return;
				}
			}
			if (this.InputModel.Options.SectionType == #G6e.#a)
			{
				float num = this.RuntimeModel.SectionDimensionsForInvestigate[0];
				float num2 = this.RuntimeModel.SectionDimensionsForInvestigate[1];
				List<Point3D> points3D = new List<Point3D>
				{
					new Point3D((double)(-(double)num / 2f), (double)(-(double)num2 / 2f)),
					new Point3D((double)(num / 2f), (double)(-(double)num2 / 2f)),
					new Point3D((double)(num / 2f), (double)(num2 / 2f)),
					new Point3D((double)(-(double)num / 2f), (double)(num2 / 2f)),
					new Point3D((double)(-(double)num / 2f), (double)(-(double)num2 / 2f))
				};
				this.OutputModel.SectionPolygons.Add(new PolygonData(points3D, PolygonType.Rectangle)
				{
					IsOpening = false
				});
				return;
			}
			if (this.InputModel.Options.SectionType == #G6e.#b)
			{
				float num3 = this.RuntimeModel.SectionDimensionsForInvestigate[0];
				List<Point3D> points3D2 = GeometryHelper.#2nc(default(Point3D), (double)num3, 80, 0.0, true);
				this.OutputModel.SectionPolygons.Add(new PolygonData(points3D2, PolygonType.Circle)
				{
					IsOpening = false
				});
			}
		}

		// Token: 0x0600A02A RID: 41002 RVA: 0x00220900 File Offset: 0x0021EB00
		private void #eb()
		{
			this.OutputModel = new #l4e(this.InputModel, this.RuntimeModel);
			this.CodeExpert = #28e.#18e(this.InputModel.DesignCode);
			this.ReinforcementProperties = new #dTe(this.InputModel, this.RuntimeModel);
			this.#g = new #jQe(this.InputModel, this.RuntimeModel, this.CodeExpert);
			this.#c = new #BNe(this.InputModel, this.RuntimeModel);
			#6Re #6Re = new #6Re(this.RuntimeModel);
			DepthComputation depthComputation = new DepthComputation(this.InputModel, this.RuntimeModel);
			#fNe #fNe = new #fNe(this.InputModel, this.RuntimeModel, this.CodeExpert);
			this.#d = new #gTe(this.OutputModel, this.InputModel, this.RuntimeModel, this.ReinforcementProperties, this.CodeExpert);
			#ISe #ISe = new #ISe(this.InputModel, this.RuntimeModel, this.ReinforcementProperties);
			#nUe #nUe = new #nUe(this.InputModel, this.RuntimeModel, depthComputation);
			#fMe #fMe = new #fMe(this.InputModel, this.RuntimeModel, this.CodeExpert);
			#VPe #VPe = new #VPe(this.InputModel, this.RuntimeModel, #6Re, #fNe, #fMe);
			this.MomentCapacityEx = new #3Qe(this.InputModel, this.RuntimeModel, #6Re, #nUe, #VPe, #fMe, this.CodeExpert);
			CriticalCapacity criticalCapacity = new CriticalCapacity(this.InputModel, this.RuntimeModel, #6Re, #nUe, #fMe, #VPe, #fNe, this.MomentCapacityEx, this.CodeExpert);
			Section #bLb = new Section(this.OutputModel, this.InputModel, this.RuntimeModel, #6Re, depthComputation, #ISe, this.#g, this.MomentCapacityEx, criticalCapacity, #fNe, #nUe, #VPe, #fMe, this.ReinforcementProperties, this.CodeExpert);
			#8Ue #1Te = new #8Ue(this.InputModel, this.RuntimeModel, this.#c, depthComputation, #bLb, #ISe);
			this.#e = new #WTe(this.InputModel, this.RuntimeModel, this.OutputModel, this.ReinforcementProperties, this.#c, #6Re, depthComputation, #ISe, #nUe, #bLb, #1Te, #fMe, #VPe, this.#g, #fNe, this.CodeExpert);
			this.#f = new NewCapacityRatioCalculator(this.InputModel, this.RuntimeModel, this.CodeExpert, this.MomentCapacityEx);
			this.#c.#bpb();
		}

		// Token: 0x040045FB RID: 17915
		public const int #a = 2;

		// Token: 0x040045FC RID: 17916
		public const float #b = 0.25f;

		// Token: 0x040045FD RID: 17917
		private #BNe #c;

		// Token: 0x040045FE RID: 17918
		private #gTe #d;

		// Token: 0x040045FF RID: 17919
		private #WTe #e;

		// Token: 0x04004600 RID: 17920
		private NewCapacityRatioCalculator #f;

		// Token: 0x04004601 RID: 17921
		private #jQe #g;

		// Token: 0x04004602 RID: 17922
		[CompilerGenerated]
		private #dTe #h;

		// Token: 0x04004603 RID: 17923
		[CompilerGenerated]
		private #l4e #i;

		// Token: 0x04004604 RID: 17924
		[CompilerGenerated]
		private #38e #j;

		// Token: 0x04004605 RID: 17925
		[CompilerGenerated]
		private readonly InputModel #k;

		// Token: 0x04004606 RID: 17926
		[CompilerGenerated]
		private readonly RuntimeModel #l;

		// Token: 0x04004607 RID: 17927
		[CompilerGenerated]
		private #3Qe #m;
	}
}
