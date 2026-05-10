using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #3ve;
using #7hc;
using #u3d;
using #Vob;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.FailureSurface;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.FailureSurface.Model
{
	// Token: 0x0200044F RID: 1103
	internal sealed class FailureSurface : NotifyPropertyChangedObjectBase
	{
		// Token: 0x0600285A RID: 10330 RVA: 0x000DB1B8 File Offset: 0x000D93B8
		public FailureSurface(IDrawingResultsFactory drawingResultsFactory, IEventManagerFactory eventManagerFactory, ISettingsManager settingsManager)
		{
			this.#c = drawingResultsFactory;
			this.#d = eventManagerFactory;
			this.#e = settingsManager;
			this.#v = new List<ITextDrawingResult>();
			this.#w = new List<IMultilineDrawingResult>();
			this.#B = new List<FailureSurfaceData>();
			this.#C = new List<FailureSurfaceData>();
			this.#D = new List<LoadPointDrawingData>();
			this.NominalPositions = new List<Point3D>();
			this.NominalIndexes = new List<int>();
			this.#j = new List<Point3D>();
			this.FactoredPositions = new List<Point3D>();
			this.FactoredIndexes = new List<int>();
			this.#n = new List<Point3D>();
			this.LoadPoints = new List<LoadPointData>();
			this.#o = new List<double>();
			this.#p = new List<double>();
			this.#y = new #apb();
			this.#x = new #apb();
			this.#z = new #apb();
			this.#A = new #apb();
		}

		// Token: 0x17000D88 RID: 3464
		// (get) Token: 0x0600285B RID: 10331 RVA: 0x00025386 File Offset: 0x00023586
		public IDrawingResultsFactory DrawingResultsFactory { get; }

		// Token: 0x17000D89 RID: 3465
		// (get) Token: 0x0600285C RID: 10332 RVA: 0x00025392 File Offset: 0x00023592
		public IEventManagerFactory EventManagerFactory { get; }

		// Token: 0x17000D8A RID: 3466
		// (get) Token: 0x0600285D RID: 10333 RVA: 0x0002539E File Offset: 0x0002359E
		public ISettingsManager SettingsManager { get; }

		// Token: 0x17000D8B RID: 3467
		// (get) Token: 0x0600285E RID: 10334 RVA: 0x000253AA File Offset: 0x000235AA
		public static int RowLength
		{
			get
			{
				return 36;
			}
		}

		// Token: 0x17000D8C RID: 3468
		// (get) Token: 0x0600285F RID: 10335 RVA: 0x000253AE File Offset: 0x000235AE
		// (set) Token: 0x06002860 RID: 10336 RVA: 0x000253BA File Offset: 0x000235BA
		public int RowCount { get; set; }

		// Token: 0x17000D8D RID: 3469
		// (get) Token: 0x06002861 RID: 10337 RVA: 0x000253CB File Offset: 0x000235CB
		// (set) Token: 0x06002862 RID: 10338 RVA: 0x000253D7 File Offset: 0x000235D7
		public int VertexCount { get; set; }

		// Token: 0x17000D8E RID: 3470
		// (get) Token: 0x06002863 RID: 10339 RVA: 0x000253E8 File Offset: 0x000235E8
		public static int ColumnCount
		{
			get
			{
				return 8;
			}
		}

		// Token: 0x17000D8F RID: 3471
		// (get) Token: 0x06002864 RID: 10340 RVA: 0x000253EB File Offset: 0x000235EB
		public int SizeX
		{
			get
			{
				return (int)this.SettingsManager.BoundingBoxSizeX;
			}
		}

		// Token: 0x17000D90 RID: 3472
		// (get) Token: 0x06002865 RID: 10341 RVA: 0x00025405 File Offset: 0x00023605
		public int SizeY
		{
			get
			{
				return (int)this.SettingsManager.BoundingBoxSizeY;
			}
		}

		// Token: 0x17000D91 RID: 3473
		// (get) Token: 0x06002866 RID: 10342 RVA: 0x0002541F File Offset: 0x0002361F
		public int SizeZ
		{
			get
			{
				return (int)this.SettingsManager.BoundingBoxSizeZ;
			}
		}

		// Token: 0x17000D92 RID: 3474
		// (get) Token: 0x06002867 RID: 10343 RVA: 0x00025439 File Offset: 0x00023639
		// (set) Token: 0x06002868 RID: 10344 RVA: 0x00025445 File Offset: 0x00023645
		public IList<LoadPointData> LoadPoints { get; private set; }

		// Token: 0x17000D93 RID: 3475
		// (get) Token: 0x06002869 RID: 10345 RVA: 0x00025456 File Offset: 0x00023656
		// (set) Token: 0x0600286A RID: 10346 RVA: 0x00025462 File Offset: 0x00023662
		public IList<Point3D> NominalPositions { get; private set; }

		// Token: 0x17000D94 RID: 3476
		// (get) Token: 0x0600286B RID: 10347 RVA: 0x00025473 File Offset: 0x00023673
		public IList<Point3D> NominalTransformedPositions { get; }

		// Token: 0x17000D95 RID: 3477
		// (get) Token: 0x0600286C RID: 10348 RVA: 0x0002547F File Offset: 0x0002367F
		// (set) Token: 0x0600286D RID: 10349 RVA: 0x0002548B File Offset: 0x0002368B
		public IList<int> NominalIndexes { get; private set; }

		// Token: 0x17000D96 RID: 3478
		// (get) Token: 0x0600286E RID: 10350 RVA: 0x0002549C File Offset: 0x0002369C
		// (set) Token: 0x0600286F RID: 10351 RVA: 0x000254A8 File Offset: 0x000236A8
		public IList<Point3D> FactoredPositions { get; private set; }

		// Token: 0x17000D97 RID: 3479
		// (get) Token: 0x06002870 RID: 10352 RVA: 0x000254B9 File Offset: 0x000236B9
		// (set) Token: 0x06002871 RID: 10353 RVA: 0x000254C5 File Offset: 0x000236C5
		public IList<int> FactoredIndexes { get; private set; }

		// Token: 0x17000D98 RID: 3480
		// (get) Token: 0x06002872 RID: 10354 RVA: 0x000254D6 File Offset: 0x000236D6
		public IList<Point3D> FactoredTransformedPositions { get; }

		// Token: 0x17000D99 RID: 3481
		// (get) Token: 0x06002873 RID: 10355 RVA: 0x000254E2 File Offset: 0x000236E2
		public IList<double> NominalHeights { get; }

		// Token: 0x17000D9A RID: 3482
		// (get) Token: 0x06002874 RID: 10356 RVA: 0x000254EE File Offset: 0x000236EE
		public IList<double> FactoredHeights { get; }

		// Token: 0x17000D9B RID: 3483
		// (get) Token: 0x06002875 RID: 10357 RVA: 0x000254FA File Offset: 0x000236FA
		// (set) Token: 0x06002876 RID: 10358 RVA: 0x00025506 File Offset: 0x00023706
		public Point3D MinPoint { get; set; }

		// Token: 0x17000D9C RID: 3484
		// (get) Token: 0x06002877 RID: 10359 RVA: 0x00025517 File Offset: 0x00023717
		// (set) Token: 0x06002878 RID: 10360 RVA: 0x00025523 File Offset: 0x00023723
		public Point3D MaxPoint { get; set; }

		// Token: 0x17000D9D RID: 3485
		// (get) Token: 0x06002879 RID: 10361 RVA: 0x00025534 File Offset: 0x00023734
		// (set) Token: 0x0600287A RID: 10362 RVA: 0x00025540 File Offset: 0x00023740
		public #c4d ScaleVector { get; set; }

		// Token: 0x17000D9E RID: 3486
		// (get) Token: 0x0600287B RID: 10363 RVA: 0x00025551 File Offset: 0x00023751
		// (set) Token: 0x0600287C RID: 10364 RVA: 0x0002555D File Offset: 0x0002375D
		public #c4d TranslateVector { get; set; }

		// Token: 0x17000D9F RID: 3487
		// (get) Token: 0x0600287D RID: 10365 RVA: 0x0002556E File Offset: 0x0002376E
		// (set) Token: 0x0600287E RID: 10366 RVA: 0x0002557A File Offset: 0x0002377A
		public IMultilineDrawingResult BoundingBoxDrawingResult { get; set; }

		// Token: 0x17000DA0 RID: 3488
		// (get) Token: 0x0600287F RID: 10367 RVA: 0x0002558B File Offset: 0x0002378B
		public IList<ITextDrawingResult> AxesTexts { get; }

		// Token: 0x17000DA1 RID: 3489
		// (get) Token: 0x06002880 RID: 10368 RVA: 0x00025597 File Offset: 0x00023797
		public IList<IMultilineDrawingResult> AxisLines { get; }

		// Token: 0x17000DA2 RID: 3490
		// (get) Token: 0x06002881 RID: 10369 RVA: 0x000255A3 File Offset: 0x000237A3
		public #apb FactoredSurface { get; }

		// Token: 0x17000DA3 RID: 3491
		// (get) Token: 0x06002882 RID: 10370 RVA: 0x000255AF File Offset: 0x000237AF
		public #apb NominalSurface { get; }

		// Token: 0x17000DA4 RID: 3492
		// (get) Token: 0x06002883 RID: 10371 RVA: 0x000255BB File Offset: 0x000237BB
		public #apb FactoredCrossSectionSurface { get; }

		// Token: 0x17000DA5 RID: 3493
		// (get) Token: 0x06002884 RID: 10372 RVA: 0x000255C7 File Offset: 0x000237C7
		public #apb NominalCrossSectionSurface { get; }

		// Token: 0x17000DA6 RID: 3494
		// (get) Token: 0x06002885 RID: 10373 RVA: 0x000255D3 File Offset: 0x000237D3
		// (set) Token: 0x06002886 RID: 10374 RVA: 0x000DB2A8 File Offset: 0x000D94A8
		public string ForceUnitString
		{
			get
			{
				return this.#E;
			}
			set
			{
				if (this.#E != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107359816));
					this.#E = value;
					base.RaisePropertyChanged(#Phc.#3hc(107359816));
				}
			}
		}

		// Token: 0x17000DA7 RID: 3495
		// (get) Token: 0x06002887 RID: 10375 RVA: 0x000255DF File Offset: 0x000237DF
		// (set) Token: 0x06002888 RID: 10376 RVA: 0x000DB2F8 File Offset: 0x000D94F8
		public string MomentUnitString
		{
			get
			{
				return this.#F;
			}
			set
			{
				if (this.#F != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107359827));
					this.#F = value;
					base.RaisePropertyChanged(#Phc.#3hc(107359827));
				}
			}
		}

		// Token: 0x17000DA8 RID: 3496
		// (get) Token: 0x06002889 RID: 10377 RVA: 0x000255EB File Offset: 0x000237EB
		// (set) Token: 0x0600288A RID: 10378 RVA: 0x000DB348 File Offset: 0x000D9548
		public string AngleUnitString
		{
			get
			{
				return this.#G;
			}
			set
			{
				if (this.#G != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107359802));
					this.#G = value;
					base.RaisePropertyChanged(#Phc.#3hc(107359802));
				}
			}
		}

		// Token: 0x17000DA9 RID: 3497
		// (get) Token: 0x0600288B RID: 10379 RVA: 0x000255F7 File Offset: 0x000237F7
		// (set) Token: 0x0600288C RID: 10380 RVA: 0x000DB398 File Offset: 0x000D9598
		public string LengthUnitString
		{
			get
			{
				return this.#H;
			}
			set
			{
				if (this.#H != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107359749));
					this.#H = value;
					base.RaisePropertyChanged(#Phc.#3hc(107359749));
				}
			}
		}

		// Token: 0x17000DAA RID: 3498
		// (get) Token: 0x0600288D RID: 10381 RVA: 0x00025603 File Offset: 0x00023803
		public string GeneralLengthUnitString
		{
			get
			{
				if (this.#H.Equals(#Phc.#3hc(107360236), StringComparison.OrdinalIgnoreCase))
				{
					return #Phc.#3hc(107360227);
				}
				return this.#H;
			}
		}

		// Token: 0x17000DAB RID: 3499
		// (get) Token: 0x0600288E RID: 10382 RVA: 0x0002563A File Offset: 0x0002383A
		// (set) Token: 0x0600288F RID: 10383 RVA: 0x000DB3E8 File Offset: 0x000D95E8
		public string CurrentDesignCodeString
		{
			get
			{
				return this.#I;
			}
			set
			{
				if (this.#I != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107360254));
					this.#I = value;
					base.RaisePropertyChanged(#Phc.#3hc(107360254));
				}
			}
		}

		// Token: 0x06002890 RID: 10384 RVA: 0x000DB438 File Offset: 0x000D9638
		public Point3D #vob(Point3D #wob)
		{
			return new Point3D
			{
				X = #wob.X / this.ScaleVector.X + this.TranslateVector.X,
				Y = #wob.Y / this.ScaleVector.Y + this.TranslateVector.X,
				Z = #wob.Z / this.ScaleVector.Z + this.TranslateVector.Z
			};
		}

		// Token: 0x06002891 RID: 10385 RVA: 0x000DB4F0 File Offset: 0x000D96F0
		public void #xob(#lte #Wdb)
		{
			#hwe #hwe = #Wdb.FailureSurface;
			this.#B = #hwe.FactoredFailureSurfaceData;
			this.#C = #hwe.NominalFailureSurfaceData;
			this.#D = #Wdb.Output.CapacityData.LoadPoints.ToList<LoadPointDrawingData>();
			this.ForceUnitString = #hwe.ForceUnitString;
			this.MomentUnitString = #hwe.MomentUnitString;
			this.LengthUnitString = #hwe.LengthUnitString;
			this.CurrentDesignCodeString = FailureSurface.#Aob(#Wdb.Input.Options.Code);
			this.AngleUnitString = #Phc.#3hc(107360221);
			this.RowCount = this.#B.Count / FailureSurface.RowLength;
			this.VertexCount = this.#B.Count;
		}

		// Token: 0x06002892 RID: 10386 RVA: 0x000DB5CC File Offset: 0x000D97CC
		public void #yob()
		{
			if (this.#C != null && this.#C.Count > 0)
			{
				if (this.NominalPositions == null || !this.NominalPositions.Any<Point3D>())
				{
					this.NominalPositions = this.#Mob();
					this.NominalIndexes = this.#Oob();
					this.#Pob(this.NominalPositions);
					this.#Rob();
					this.#Eob();
				}
				this.NominalSurface.#9ob();
				this.NominalSurface.FailureSurface = this.#Bob(this.NominalTransformedPositions, this.NominalIndexes, this.SettingsManager.FailureSurfaceNominalSurfaceColor);
				this.NominalSurface.Wireframe.AddRange(this.#Gob(this.NominalTransformedPositions, this.SettingsManager.FailureSurfaceNominalWireframeLineColor, this.SettingsManager.FailureSurfaceNominalWireframeLineThickness));
			}
		}

		// Token: 0x06002893 RID: 10387 RVA: 0x000DB6C0 File Offset: 0x000D98C0
		public void #zob()
		{
			if (this.FactoredPositions == null || !this.FactoredPositions.Any<Point3D>())
			{
				this.FactoredPositions = this.#Nob();
				this.FactoredIndexes = this.#Oob();
				if (this.#C == null)
				{
					this.#Pob(this.FactoredPositions);
				}
				if (this.#C == null || this.#C.Count == 0)
				{
					this.#Pob(this.FactoredPositions);
				}
				this.#Sob();
				this.#Fob();
				this.#Qob();
			}
			this.FactoredSurface.#9ob();
			this.FactoredSurface.FailureSurface = this.#Bob(this.FactoredTransformedPositions, this.FactoredIndexes, this.SettingsManager.FailureSurfaceFactoredSurfaceColor);
			this.FactoredSurface.Wireframe.AddRange(this.#Gob(this.FactoredTransformedPositions, this.SettingsManager.FailureSurfaceFactoredWireframeLineColor, this.SettingsManager.FailureSurfaceFactoredWireframeLineThickness));
		}

		// Token: 0x06002894 RID: 10388 RVA: 0x000DB7C4 File Offset: 0x000D99C4
		public void #yl()
		{
			IList<Point3D> list = null;
			if (!false)
			{
				this.FactoredPositions = list;
			}
			this.NominalPositions = null;
			this.NominalTransformedPositions.Clear();
			this.FactoredTransformedPositions.Clear();
			this.NominalIndexes = null;
			this.FactoredIndexes = null;
			this.NominalHeights.Clear();
			this.FactoredHeights.Clear();
			this.FactoredSurface.#9ob();
			this.NominalSurface.#9ob();
			this.AxesTexts.Clear();
			this.AxisLines.Clear();
		}

		// Token: 0x06002895 RID: 10389 RVA: 0x000DB860 File Offset: 0x000D9A60
		private static string #Aob(DesignCodes #3)
		{
			switch (#3)
			{
			case DesignCodes.ACI02:
				return Strings.StringACI31802;
			case DesignCodes.CSA94:
				return Strings.StringCSAA23394;
			case DesignCodes.ACI05:
				return Strings.StringACI31805;
			case DesignCodes.CSA04:
				return Strings.StringCSAA23304;
			case DesignCodes.ACI08:
				return Strings.StringACI31808;
			case DesignCodes.ACI11:
				return Strings.StringACI31811;
			case DesignCodes.ACI14:
				return Strings.StringACI31814;
			case DesignCodes.CSA14:
				return Strings.StringCSAA23314;
			case DesignCodes.ACI19:
				return Strings.StringACI31819;
			case DesignCodes.CSA19:
				return Strings.StringCSAA23319;
			default:
				return string.Empty;
			}
		}

		// Token: 0x06002896 RID: 10390 RVA: 0x000DB8EC File Offset: 0x000D9AEC
		private IMeshDrawingResult #Bob(IList<Point3D> #Cob, IList<int> #Dob, Color #BR)
		{
			IMeshDrawingResult meshDrawingResult = this.DrawingResultsFactory.CreateMeshDrawingResult();
			meshDrawingResult.SetContent(#Cob, #Dob);
			meshDrawingResult.SetColor(#BR, null);
			meshDrawingResult.Freeze();
			return meshDrawingResult;
		}

		// Token: 0x06002897 RID: 10391 RVA: 0x000DB930 File Offset: 0x000D9B30
		private void #Eob()
		{
			this.NominalHeights.Clear();
			for (int i = 0; i < this.VertexCount; i += 36)
			{
				this.NominalHeights.Add(this.NominalTransformedPositions[i].Z);
			}
		}

		// Token: 0x06002898 RID: 10392 RVA: 0x000DB988 File Offset: 0x000D9B88
		private void #Fob()
		{
			this.FactoredHeights.Clear();
			for (int i = 0; i < this.VertexCount; i += 36)
			{
				this.FactoredHeights.Add(this.FactoredTransformedPositions[i].Z);
			}
		}

		// Token: 0x06002899 RID: 10393 RVA: 0x000DB9E0 File Offset: 0x000D9BE0
		private List<IMultiPolyLineDrawingResult> #Gob(IList<Point3D> #Hob, Color #Iob, double #Job)
		{
			IMultiPolyLineDrawingResult item = this.#Kob(#Hob, #Iob, #Job);
			IMultiPolyLineDrawingResult item2 = this.#Lob(#Hob, #Iob, #Job);
			return new List<IMultiPolyLineDrawingResult>
			{
				item,
				item2
			};
		}

		// Token: 0x0600289A RID: 10394 RVA: 0x000DBA20 File Offset: 0x000D9C20
		private IMultiPolyLineDrawingResult #Kob(IList<Point3D> #Hob, Color #Iob, double #Job)
		{
			List<List<Point3D>> list = new List<List<Point3D>>();
			for (int i = 0; i < this.RowCount; i++)
			{
				List<Point3D> list2 = new List<Point3D>();
				for (int j = 0; j < FailureSurface.RowLength; j++)
				{
					int index = i * FailureSurface.RowLength + j;
					list2.Add(#Hob[index]);
				}
				list.Add(list2);
			}
			IMultiPolyLineDrawingResult multiPolyLineDrawingResult = this.DrawingResultsFactory.CreateMulitPolyLineDrawingResult();
			multiPolyLineDrawingResult.Positions = list;
			multiPolyLineDrawingResult.LineColor = #Iob;
			multiPolyLineDrawingResult.LineThickness = #Job;
			multiPolyLineDrawingResult.IsClosed = true;
			return multiPolyLineDrawingResult;
		}

		// Token: 0x0600289B RID: 10395 RVA: 0x000DBAC4 File Offset: 0x000D9CC4
		private IMultiPolyLineDrawingResult #Lob(IList<Point3D> #Hob, Color #Iob, double #Job)
		{
			List<List<Point3D>> list = new List<List<Point3D>>();
			for (int i = 0; i < FailureSurface.RowLength; i++)
			{
				List<Point3D> list2 = new List<Point3D>();
				for (int j = 0; j < this.RowCount; j++)
				{
					int index = i + j * 36;
					list2.Add(#Hob[index]);
				}
				list.Add(list2);
			}
			IMultiPolyLineDrawingResult multiPolyLineDrawingResult = this.DrawingResultsFactory.CreateMulitPolyLineDrawingResult();
			multiPolyLineDrawingResult.Positions = list;
			multiPolyLineDrawingResult.LineColor = #Iob;
			multiPolyLineDrawingResult.LineThickness = #Job;
			return multiPolyLineDrawingResult;
		}

		// Token: 0x0600289C RID: 10396 RVA: 0x000DBB60 File Offset: 0x000D9D60
		private IList<Point3D> #Mob()
		{
			List<Point3D> list = new List<Point3D>();
			for (int i = 0; i < this.VertexCount; i++)
			{
				list.Add(new Point3D((double)this.#C[i].MomentX, (double)this.#C[i].MomentY, (double)this.#C[i].AxialForce));
			}
			return list;
		}

		// Token: 0x0600289D RID: 10397 RVA: 0x000DBBDC File Offset: 0x000D9DDC
		private IList<Point3D> #Nob()
		{
			List<Point3D> list = new List<Point3D>();
			for (int i = 0; i < this.VertexCount; i++)
			{
				list.Add(new Point3D((double)this.#B[i].MomentX, (double)this.#B[i].MomentY, (double)this.#B[i].AxialForce));
			}
			return list;
		}

		// Token: 0x0600289E RID: 10398 RVA: 0x000DBC58 File Offset: 0x000D9E58
		private IList<int> #Oob()
		{
			List<int> list = new List<int>();
			int num = FailureSurface.RowLength;
			int num2 = this.VertexCount - FailureSurface.RowLength;
			for (int i = 0; i < num2; i++)
			{
				bool flag = (i + 1) % FailureSurface.RowLength == 0;
				list.Add(i);
				list.Add(1 + i);
				list.Add(num + i);
				if (flag)
				{
					list.Add(i + 1 - num);
					list.Add(1 + i);
					list.Add(i);
				}
				else
				{
					list.Add(1 + i);
					list.Add(num + 1 + i);
					list.Add(num + i);
				}
			}
			return list;
		}

		// Token: 0x0600289F RID: 10399 RVA: 0x000DBD10 File Offset: 0x000D9F10
		private void #Pob(IList<Point3D> #Hob)
		{
			if (!#Hob.Any<Point3D>())
			{
				return;
			}
			Point3D point3D = default(Point3D);
			point3D.X = #Hob.Min(new Func<Point3D, double>(FailureSurface.<>c.<>9.#F6b));
			point3D.Y = #Hob.Min(new Func<Point3D, double>(FailureSurface.<>c.<>9.#G6b));
			point3D.Z = #Hob.Min(new Func<Point3D, double>(FailureSurface.<>c.<>9.#H6b));
			this.MinPoint = point3D;
			Point3D point3D2 = default(Point3D);
			point3D2.X = #Hob.Max(new Func<Point3D, double>(FailureSurface.<>c.<>9.#I6b));
			point3D2.Y = #Hob.Max(new Func<Point3D, double>(FailureSurface.<>c.<>9.#J6b));
			point3D2.Z = #Hob.Max(new Func<Point3D, double>(FailureSurface.<>c.<>9.#K6b));
			this.MaxPoint = point3D2;
			this.TranslateVector = new #c4d
			{
				X = (point3D2.X + point3D.X) / 2.0,
				Y = (point3D2.Y + point3D.Y) / 2.0,
				Z = (point3D2.Z + point3D.Z) / 2.0
			};
			#c4d #c4d = default(#c4d);
			double num = ((double)this.SizeX / (this.MaxPoint.X - this.MinPoint.X) < (double)this.SizeY / (this.MaxPoint.Y - this.MinPoint.Y)) ? ((double)this.SizeX / (this.MaxPoint.X - this.MinPoint.X)) : ((double)this.SizeY / (this.MaxPoint.Y - this.MinPoint.Y));
			#c4d.X = num;
			#c4d.Y = num;
			#c4d.Z = (double)this.SizeZ / (this.MaxPoint.Z - this.MinPoint.Z);
			this.ScaleVector = #c4d;
		}

		// Token: 0x060028A0 RID: 10400 RVA: 0x000DBFCC File Offset: 0x000DA1CC
		private void #Qob()
		{
			List<LoadPointData> list = new List<LoadPointData>();
			for (int i = 0; i < this.#D.Count; i++)
			{
				LoadPointDrawingData loadPointDrawingData = this.#D[i];
				Point3D point3D = new Point3D((double)loadPointDrawingData.MomentX * this.ScaleVector.X + -this.TranslateVector.X * this.ScaleVector.X, (double)loadPointDrawingData.MomentY * this.ScaleVector.Y + -this.TranslateVector.Y * this.ScaleVector.Y, (double)loadPointDrawingData.AxialLoad * this.ScaleVector.Z + -this.TranslateVector.Z * this.ScaleVector.Z);
				list.Add(new LoadPointData(loadPointDrawingData)
				{
					Center = point3D
				});
			}
			this.LoadPoints = list;
		}

		// Token: 0x060028A1 RID: 10401 RVA: 0x000DC0F0 File Offset: 0x000DA2F0
		private void #Rob()
		{
			this.NominalTransformedPositions.Clear();
			for (int i = 0; i < this.NominalPositions.Count; i++)
			{
				this.NominalTransformedPositions.Add(new Point3D((this.NominalPositions[i].X - this.TranslateVector.X) * this.ScaleVector.X, (this.NominalPositions[i].Y - this.TranslateVector.Y) * this.ScaleVector.Y, (this.NominalPositions[i].Z - this.TranslateVector.Z) * this.ScaleVector.Z));
			}
		}

		// Token: 0x060028A2 RID: 10402 RVA: 0x000DC1E8 File Offset: 0x000DA3E8
		private void #Sob()
		{
			this.FactoredTransformedPositions.Clear();
			for (int i = 0; i < this.FactoredPositions.Count; i++)
			{
				this.FactoredTransformedPositions.Add(new Point3D((this.FactoredPositions[i].X - this.TranslateVector.X) * this.ScaleVector.X, (this.FactoredPositions[i].Y - this.TranslateVector.Y) * this.ScaleVector.Y, (this.FactoredPositions[i].Z - this.TranslateVector.Z) * this.ScaleVector.Z));
			}
		}

		// Token: 0x04000FF9 RID: 4089
		private const string #a = "[mm]";

		// Token: 0x04000FFA RID: 4090
		private const string #b = "[m]";

		// Token: 0x04000FFB RID: 4091
		[CompilerGenerated]
		private readonly IDrawingResultsFactory #c;

		// Token: 0x04000FFC RID: 4092
		[CompilerGenerated]
		private readonly IEventManagerFactory #d;

		// Token: 0x04000FFD RID: 4093
		[CompilerGenerated]
		private readonly ISettingsManager #e;

		// Token: 0x04000FFE RID: 4094
		[CompilerGenerated]
		private int #f;

		// Token: 0x04000FFF RID: 4095
		[CompilerGenerated]
		private int #g;

		// Token: 0x04001000 RID: 4096
		[CompilerGenerated]
		private IList<LoadPointData> #h;

		// Token: 0x04001001 RID: 4097
		[CompilerGenerated]
		private IList<Point3D> #i;

		// Token: 0x04001002 RID: 4098
		[CompilerGenerated]
		private readonly IList<Point3D> #j;

		// Token: 0x04001003 RID: 4099
		[CompilerGenerated]
		private IList<int> #k;

		// Token: 0x04001004 RID: 4100
		[CompilerGenerated]
		private IList<Point3D> #l;

		// Token: 0x04001005 RID: 4101
		[CompilerGenerated]
		private IList<int> #m;

		// Token: 0x04001006 RID: 4102
		[CompilerGenerated]
		private readonly IList<Point3D> #n;

		// Token: 0x04001007 RID: 4103
		[CompilerGenerated]
		private readonly IList<double> #o;

		// Token: 0x04001008 RID: 4104
		[CompilerGenerated]
		private readonly IList<double> #p;

		// Token: 0x04001009 RID: 4105
		[CompilerGenerated]
		private Point3D #q;

		// Token: 0x0400100A RID: 4106
		[CompilerGenerated]
		private Point3D #r;

		// Token: 0x0400100B RID: 4107
		[CompilerGenerated]
		private #c4d #s;

		// Token: 0x0400100C RID: 4108
		[CompilerGenerated]
		private #c4d #t;

		// Token: 0x0400100D RID: 4109
		[CompilerGenerated]
		private IMultilineDrawingResult #u;

		// Token: 0x0400100E RID: 4110
		[CompilerGenerated]
		private readonly IList<ITextDrawingResult> #v;

		// Token: 0x0400100F RID: 4111
		[CompilerGenerated]
		private readonly IList<IMultilineDrawingResult> #w;

		// Token: 0x04001010 RID: 4112
		[CompilerGenerated]
		private readonly #apb #x;

		// Token: 0x04001011 RID: 4113
		[CompilerGenerated]
		private readonly #apb #y;

		// Token: 0x04001012 RID: 4114
		[CompilerGenerated]
		private readonly #apb #z;

		// Token: 0x04001013 RID: 4115
		[CompilerGenerated]
		private readonly #apb #A;

		// Token: 0x04001014 RID: 4116
		private List<FailureSurfaceData> #B;

		// Token: 0x04001015 RID: 4117
		private List<FailureSurfaceData> #C;

		// Token: 0x04001016 RID: 4118
		private List<LoadPointDrawingData> #D;

		// Token: 0x04001017 RID: 4119
		private string #E;

		// Token: 0x04001018 RID: 4120
		private string #F;

		// Token: 0x04001019 RID: 4121
		private string #G;

		// Token: 0x0400101A RID: 4122
		private string #H;

		// Token: 0x0400101B RID: 4123
		private string #I;
	}
}
