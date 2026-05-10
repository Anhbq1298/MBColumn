using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using #7Tc;
using #8Cc;
using #bJc;
using #cYd;
using #dQc;
using #ezc;
using #Fmc;
using #hTb;
using #IDc;
using #NWc;
using #o1d;
using #T0c;
using #UYd;
using #v1c;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.InsertNodeOnEdge
{
	// Token: 0x02000C1F RID: 3103
	public sealed class InsertNodeOnEdgeTool : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #iQc
	{
		// Token: 0x060064CA RID: 25802 RVA: 0x0018BA0C File Offset: 0x00189C0C
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by IoC.")]
		public InsertNodeOnEdgeTool(#6Ic toolContext, #1Wc assignmentsFactory, #fQc insertNodeOptionsView) : base(toolContext)
		{
			#X0d.#V0d(toolContext, #Phc.#3hc(107444554), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107444569));
			#X0d.#V0d(insertNodeOptionsView, #Phc.#3hc(107444484), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107443943));
			this.#h = assignmentsFactory;
			base.Header = Strings.StringInsertNodeOnEdge;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.InsertNodeOnEdge);
			this.#f = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			this.#g = toolContext.DrawingResultsFactory.CreateCrossIndicatorDrawingResult();
			this.#o = toolContext.DrawingResultsFactory.CreatePointsDrawingResult();
			this.#o.PointColor = Colors.Green;
			this.#o.PointSize = base.SettingsProvider.VisualizationDefaultCustomNodeSize;
			this.InsertCustomNodesOnShapeEdge = true;
			this.#i = 1;
			this.#j = false;
			this.EditionState = InsertNodeOnEdgeTool.#qad.#a;
			insertNodeOptionsView.DataContext = this;
			base.ToolOptionsEditor = insertNodeOptionsView;
			this.#l = base.ToolContext.DrawingResultsFactory.CreatePolylineDrawingResult();
			this.#m = new Dictionary<InsertNodeOnEdgeTool.#qad, string>
			{
				{
					InsertNodeOnEdgeTool.#qad.#a,
					Strings.StringSelectStartPoint
				},
				{
					InsertNodeOnEdgeTool.#qad.#b,
					Strings.StringSelectEndPoint
				}
			};
			base.HelpId = HelpIdentifiers.ToolInsertNodeOnEdge;
		}

		// Token: 0x17001C38 RID: 7224
		// (get) Token: 0x060064CB RID: 25803 RVA: 0x000517D0 File Offset: 0x0004F9D0
		// (set) Token: 0x060064CC RID: 25804 RVA: 0x000517D8 File Offset: 0x0004F9D8
		public bool InsertCustomNodesOnShapeEdge { get; set; }

		// Token: 0x17001C39 RID: 7225
		// (get) Token: 0x060064CD RID: 25805 RVA: 0x000517E1 File Offset: 0x0004F9E1
		// (set) Token: 0x060064CE RID: 25806 RVA: 0x0018BB78 File Offset: 0x00189D78
		public int NumberOfNodesToInsertInARow
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i == value)
				{
					goto IL_3D;
				}
				string propertyName = #Phc.#3hc(107443922);
				if (2 != 0)
				{
					base.RaisePropertyChanging(propertyName);
				}
				IL_19:
				if (!false)
				{
					this.#i = value;
					this.#j = (value > 1);
				}
				string propertyName2 = #Phc.#3hc(107443922);
				if (5 != 0)
				{
					base.RaisePropertyChanged(propertyName2);
				}
				IL_3D:
				if (!false && !false)
				{
					return;
				}
				goto IL_19;
			}
		}

		// Token: 0x17001C3A RID: 7226
		// (get) Token: 0x060064CF RID: 25807 RVA: 0x000517E9 File Offset: 0x0004F9E9
		public int MaxNumberOfItemsToInsertAtOnce
		{
			get
			{
				return 100000;
			}
		}

		// Token: 0x17001C3B RID: 7227
		// (get) Token: 0x060064D0 RID: 25808 RVA: 0x000517F0 File Offset: 0x0004F9F0
		protected Point3D? StartPoint3D
		{
			get
			{
				return this.#n;
			}
		}

		// Token: 0x17001C3C RID: 7228
		// (get) Token: 0x060064D1 RID: 25809 RVA: 0x000517F8 File Offset: 0x0004F9F8
		// (set) Token: 0x060064D2 RID: 25810 RVA: 0x00051800 File Offset: 0x0004FA00
		private protected int NumberOfNodesOnPreview { protected get; private set; }

		// Token: 0x060064D3 RID: 25811 RVA: 0x0018BBD8 File Offset: 0x00189DD8
		public override void #5b()
		{
			if (-1 == 0)
			{
				goto IL_7A;
			}
			if (2 != 0)
			{
				base.#5b();
			}
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[4];
			RuntimeFieldHandle fldHandle = fieldof(#l8c.#b).FieldHandle;
			if (6 != 0)
			{
				RuntimeHelpers.InitializeArray(array, fldHandle);
			}
			if (8 != 0)
			{
				base.#FIc(array);
			}
			ISnapPointsMarker #IJc = base.SnapPointsMarker;
			#6Gc #JAc = base.SettingsProvider;
			if (5 != 0)
			{
				#8Ib.#HJc(#IJc, #JAc);
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#l;
			Color lineColor = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeColor;
			if (!false)
			{
				linesDrawingResultBase.LineColor = lineColor;
			}
			ILinesDrawingResultBase linesDrawingResultBase2 = this.#l;
			double lineThickness = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeThickness;
			if (!false)
			{
				linesDrawingResultBase2.LineThickness = lineThickness;
			}
			base.ModelEditorControl.SetCursor(this.#f, false);
			IL_74:
			this.#AQc();
			IL_7A:
			if (3 != 0)
			{
				base.#AIc(this.#g);
				return;
			}
			goto IL_74;
		}

		// Token: 0x060064D4 RID: 25812 RVA: 0x0018BCA4 File Offset: 0x00189EA4
		public override void #0kb()
		{
			ModelEditorControlEventType[] #MEc = null;
			if (5 != 0)
			{
				base.#LEc(#MEc);
			}
			if (!false)
			{
				ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
				#Atc snapToPointResult = null;
				if (!false)
				{
					snapPointsMarker.Mark(snapToPointResult);
				}
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			Cursor arrow = System.Windows.Input.Cursors.Arrow;
			bool forceCursor = false;
			if (6 != 0)
			{
				modelEditorControl.SetCursor(arrow, forceCursor);
			}
			IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#g;
			if (5 != 0)
			{
				modelEditorControl2.RemoveFromView(drawingResult);
			}
			if (7 != 0)
			{
				this.#1kb();
			}
			if (!false)
			{
				base.#0kb();
			}
		}

		// Token: 0x060064D5 RID: 25813 RVA: 0x0018BD20 File Offset: 0x00189F20
		public override void #1kb()
		{
			if (4 != 0)
			{
				base.#1kb();
			}
			InsertNodeOnEdgeTool.#qad #qad = InsertNodeOnEdgeTool.#qad.#a;
			if (!false)
			{
				this.EditionState = #qad;
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#l;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
			IDrawingResult drawingResult2 = this.#o;
			if (!false)
			{
				modelEditorControl2.RemoveFromView(drawingResult2);
			}
			this.#n = null;
			int num = 0;
			if (8 != 0)
			{
				this.NumberOfNodesOnPreview = num;
			}
			if (!false)
			{
				this.#AQc();
			}
		}

		// Token: 0x060064D6 RID: 25814 RVA: 0x0018BDA0 File Offset: 0x00189FA0
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected errors catch.")]
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			Point3D? point3D = base.ToolOperationsHelper.#aEc(#HAb);
			Point3D? point3D2;
			if (3 != 0)
			{
				point3D2 = point3D;
			}
			while (point3D2 != null)
			{
				Point3D value = point3D2.Value;
				if (!false)
				{
					#HAb = value;
				}
				if (this.EditionState == InsertNodeOnEdgeTool.#qad.#a && this.#j)
				{
					this.#n = new Point3D?(#HAb);
					InsertNodeOnEdgeTool.#qad #qad = InsertNodeOnEdgeTool.#qad.#b;
					if (6 != 0)
					{
						this.EditionState = #qad;
					}
					Point3D #HAb2 = #HAb;
					if (!false)
					{
						base.#fzb(#HAb2, #gzb);
					}
					if (#gzb)
					{
						#jUc #jUc = base.PreciseInputProvider;
						PreciseInputParameters initializeInputParameters = this.#DNc(false, new Point3D?(#HAb));
						if (3 != 0)
						{
							#jUc.Update(initializeInputParameters);
						}
						return;
					}
				}
				else if (3 != 0 && this.EditionState == InsertNodeOnEdgeTool.#qad.#b)
				{
					IList<NodeToInsert> list2;
					try
					{
						do
						{
							IList<NodeToInsert> list = this.#XPc(#HAb);
							if (6 != 0)
							{
								list2 = list;
							}
						}
						while (3 == 0);
					}
					catch (Exception #ob)
					{
						base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107443853), base.ToolInfo);
						goto IL_D9;
					}
					if (list2.Any<NodeToInsert>())
					{
						this.#QKc(list2, #gzb, #HAb);
						if (6 != 0)
						{
							return;
						}
						continue;
					}
				}
				else
				{
					this.EditionState = InsertNodeOnEdgeTool.#qad.#b;
				}
				IL_D9:
				if (5 != 0)
				{
					return;
				}
				break;
			}
		}

		// Token: 0x060064D7 RID: 25815 RVA: 0x0018BEC8 File Offset: 0x0018A0C8
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			Point3D? point3D5;
			for (;;)
			{
				Point3D? point3D2;
				if (!false)
				{
					if (this.EditionState != InsertNodeOnEdgeTool.#qad.#a)
					{
						break;
					}
					#R2c #R2c = base.ToolContext.MouseAndKeyboardService;
					if (!false)
					{
						#R2c.#mNb();
					}
					Point3D? point3D = base.#HIc(#4kb);
					if (!false)
					{
						point3D2 = point3D;
					}
				}
				if (point3D2 == null)
				{
					return;
				}
				for (;;)
				{
					Point3D? point3D3 = base.ToolOperationsHelper.#aEc(point3D2.Value);
					if (!false)
					{
						point3D2 = point3D3;
					}
					if (point3D2 == null)
					{
						return;
					}
					Point3D? point3D4 = this.#6qc(point3D2.Value).#Dtc();
					if (!false)
					{
						point3D5 = point3D4;
					}
					if (point3D5 == null)
					{
						return;
					}
					bool isWorking = true;
					if (5 != 0)
					{
						base.IsWorking = isWorking;
					}
					if (false)
					{
						break;
					}
					if (5 != 0 && !false)
					{
						goto Block_7;
					}
				}
			}
			return;
			Block_7:
			Point3D value = point3D5.Value;
			bool #gzb = false;
			if (!false)
			{
				this.#fzb(value, #gzb);
			}
		}

		// Token: 0x060064D8 RID: 25816 RVA: 0x0018BF94 File Offset: 0x0018A194
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			while (this.EditionState == InsertNodeOnEdgeTool.#qad.#b)
			{
				bool flag = false;
				bool flag2;
				if (3 != 0)
				{
					flag2 = flag;
				}
				#R2c #R2c = base.ToolContext.MouseAndKeyboardService;
				if (!false)
				{
					#R2c.#mNb();
				}
				try
				{
					if (7 == 0)
					{
						goto IL_93;
					}
					Point3D? point3D = base.#HIc(#4kb);
					Point3D? point3D2;
					if (6 != 0)
					{
						point3D2 = point3D;
					}
					IL_35:
					if (point3D2 == null)
					{
						goto IL_FC;
					}
					Point3D? point3D3 = (this.#n != null) ? base.ToolOperationsHelper.#9Dc(this.#n.Value, point3D2.Value) : base.ToolOperationsHelper.#aEc(point3D2.Value);
					if (!false)
					{
						point3D2 = point3D3;
					}
					if (point3D2 == null)
					{
						goto IL_FC;
					}
					IL_93:
					Point3D? point3D4 = this.#6qc(point3D2.Value).#Dtc();
					Point3D? point3D5;
					if (3 != 0)
					{
						point3D5 = point3D4;
					}
					if (3 == 0)
					{
						goto IL_35;
					}
					if (point3D5 != null)
					{
						Point3D value = point3D5.Value;
						bool #gzb = false;
						if (6 != 0)
						{
							this.#fzb(value, #gzb);
						}
						flag2 = true;
						base.IsWorking = false;
					}
				}
				finally
				{
					bool flag3 = this.#j;
					while (!flag3)
					{
						bool flag4 = flag3 = flag2;
						if (6 != 0)
						{
							if (!flag4)
							{
								this.#1kb();
								break;
							}
							break;
						}
					}
				}
				IL_FC:
				if (5 != 0)
				{
					return;
				}
			}
		}

		// Token: 0x060064D9 RID: 25817 RVA: 0x0018C0C4 File Offset: 0x0018A2C4
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			do
			{
				if (!false)
				{
					base.#HEc(#IEc, #Kzb);
				}
				if (this.EditionState == InsertNodeOnEdgeTool.#qad.#a)
				{
					goto IL_24;
				}
			}
			while (false);
			if (this.#n != null)
			{
				if (this.#n != null)
				{
					Point3D? point3D2;
					do
					{
						Point3D? point3D = base.ToolOperationsHelper.#9Dc(this.#n.Value, #Kzb);
						if (4 != 0)
						{
							point3D2 = point3D;
						}
						if (point3D2 != null)
						{
							goto IL_9A;
						}
					}
					while (5 == 0);
					return;
					IL_9A:
					#Atc #Atc = this.#6qc(point3D2.Value);
					#Atc #Atc2;
					if (!false)
					{
						#Atc2 = #Atc;
					}
					base.SnapPointsMarker.Mark(#Atc2);
					this.#tQc(point3D2.Value, #Atc2.#Dtc());
				}
				return;
			}
			IL_24:
			Point3D? point3D3 = base.ToolOperationsHelper.#aEc(#Kzb);
			Point3D? point3D4;
			if (!false)
			{
				point3D4 = point3D3;
			}
			if (point3D4 == null)
			{
				return;
			}
			#Atc #Atc3 = this.#6qc(point3D4.Value);
			#Atc #Atc4;
			if (3 != 0)
			{
				#Atc4 = #Atc3;
			}
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = #Atc4;
			if (-1 != 0)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
		}

		// Token: 0x060064DA RID: 25818 RVA: 0x00051809 File Offset: 0x0004FA09
		protected override #hvc #JIc()
		{
			return #hvc.#c;
		}

		// Token: 0x060064DB RID: 25819 RVA: 0x0018C1C4 File Offset: 0x0018A3C4
		protected override void #GIc()
		{
			if (4 != 0)
			{
				ICrossIndicatorDrawingResult #LIc = this.#g;
				if (!false)
				{
					base.#AIc(#LIc);
				}
				#jUc #jUc = base.PreciseInputProvider;
				PreciseInputParameters initializeInputParameters = this.#DNc(true, null);
				if (!false)
				{
					#jUc.Show(initializeInputParameters);
				}
			}
		}

		// Token: 0x060064DC RID: 25820 RVA: 0x0005180C File Offset: 0x0004FA0C
		protected override void #hIc()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#g;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
		}

		// Token: 0x060064DD RID: 25821 RVA: 0x0018C20C File Offset: 0x0018A40C
		protected override void #fIc(PreciseInputChangedEventArgs #gIc)
		{
			if (2 == 0)
			{
				goto IL_3D;
			}
			Point3D? point3D = #aJc.#9Ic(#gIc);
			Point3D? point3D2;
			if (true)
			{
				point3D2 = point3D;
			}
			if (point3D2 != null)
			{
				goto IL_1A;
			}
			IL_16:
			if (!false)
			{
				return;
			}
			IL_1A:
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#g;
			if (2 != 0)
			{
				modelEditorControl.AddToView(drawingResult);
			}
			ICrossIndicatorDrawingResult crossIndicatorDrawingResult = this.#g;
			Point3D value = point3D2.Value;
			if (2 != 0)
			{
				crossIndicatorDrawingResult.CenterPoint = value;
			}
			IL_3D:
			if (!false)
			{
				return;
			}
			goto IL_16;
		}

		// Token: 0x060064DE RID: 25822 RVA: 0x0018A6B4 File Offset: 0x001888B4
		protected override void #iIc(PreciseInputCompletedEventArgs #jIc)
		{
			Point3D? point3D = #aJc.#9Ic(#jIc);
			Point3D? point3D2;
			if (5 != 0)
			{
				point3D2 = point3D;
			}
			if (point3D2 == null)
			{
				return;
			}
			for (;;)
			{
				if (!false)
				{
					Point3D value = point3D2.Value;
					bool #gzb = true;
					if (false)
					{
						goto IL_26;
					}
					this.#fzb(value, #gzb);
					goto IL_26;
				}
				IL_2D:
				if (!false)
				{
					if (true)
					{
						break;
					}
					continue;
				}
				IL_26:
				if (false)
				{
					goto IL_2D;
				}
				base.#iIc(#jIc);
				goto IL_2D;
			}
		}

		// Token: 0x060064DF RID: 25823 RVA: 0x00051826 File Offset: 0x0004FA26
		protected override void #JEc(CameraDistanceChangedEventArgs #KEc)
		{
			if (#KEc == null)
			{
				return;
			}
			ICrossIndicatorDrawingResult #LIc = this.#g;
			if (!false)
			{
				base.#AIc(#LIc);
			}
		}

		// Token: 0x060064E0 RID: 25824 RVA: 0x0005183F File Offset: 0x0004FA3F
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		protected #hvc #nQc()
		{
			return base.ProjectContext.SnappingModes;
		}

		// Token: 0x060064E1 RID: 25825 RVA: 0x0005184C File Offset: 0x0004FA4C
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		protected IReadOnlyCollection<ShapeDataModel> #oQc()
		{
			return base.ProjectContext.MainModel.Shapes;
		}

		// Token: 0x060064E2 RID: 25826 RVA: 0x0005185E File Offset: 0x0004FA5E
		protected void #pQc(ShapeDataModel #rP)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			if (4 != 0)
			{
				#V0c.#8ob(#rP);
			}
			#V0c #V0c2 = base.ModelEditorViewModel;
			if (4 != 0)
			{
				#V0c2.#QZc(#rP);
			}
		}

		// Token: 0x060064E3 RID: 25827 RVA: 0x00009E6A File Offset: 0x0000806A
		protected void #qQc()
		{
		}

		// Token: 0x060064E4 RID: 25828 RVA: 0x0018C26C File Offset: 0x0018A46C
		protected void #rQc(Point3D? #sQc)
		{
			if (#sQc == null)
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#o;
				if (!false)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
				this.NumberOfNodesOnPreview = 0;
				return;
			}
			IList<NodeToInsert> list = this.#XPc(#sQc.Value);
			IList<NodeToInsert> list2;
			if (true)
			{
				list2 = list;
			}
			int count = list2.Count;
			if (!false)
			{
				this.NumberOfNodesOnPreview = count;
			}
			if (list2.Any<NodeToInsert>())
			{
				IPointsDrawingResult pointsDrawingResult = this.#o;
				IEnumerable<Point3D> points = list2.Select(new Func<NodeToInsert, Point3D>(InsertNodeOnEdgeTool.<>c.<>9.#tad)).ToList<Point3D>();
				if (-1 != 0)
				{
					pointsDrawingResult.Points = points;
				}
				IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
				IDrawingResult drawingResult2 = this.#o;
				if (!false)
				{
					modelEditorControl2.AddToView(drawingResult2);
				}
				return;
			}
			IModelEditorControl modelEditorControl3 = base.ModelEditorControl;
			IDrawingResult drawingResult3 = this.#o;
			if (!false)
			{
				modelEditorControl3.RemoveFromView(drawingResult3);
			}
		}

		// Token: 0x060064E5 RID: 25829 RVA: 0x0018C350 File Offset: 0x0018A550
		protected void #tQc(Point3D #Yrb, Point3D? #sQc)
		{
			while (this.#n == null)
			{
				if (false)
				{
					IL_54:
					if (!false)
					{
						this.#rQc(#sQc);
					}
					return;
				}
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#l;
				if (!false)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
				if (!false)
				{
					return;
				}
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#l;
			List<Point3D> list = new List<Point3D>();
			list.Add(this.#n.Value);
			if (!false)
			{
				list.Add(#Yrb);
			}
			IEnumerable<Point3D> positions = PointsConverter.#Csc(list, 0.032);
			if (5 != 0)
			{
				linesDrawingResultBase.Positions = positions;
			}
			IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
			IDrawingResult drawingResult2 = this.#l;
			if (!true)
			{
				goto IL_54;
			}
			modelEditorControl2.AddToView(drawingResult2);
			goto IL_54;
		}

		// Token: 0x060064E6 RID: 25830 RVA: 0x0018C3F8 File Offset: 0x0018A5F8
		private #Atc #6qc(Point3D #f)
		{
			if (4 == 0)
			{
				goto IL_46;
			}
			#Atc #Atc = base.SnappingProvider.#bNb(#hvc.#b | #hvc.#c | #hvc.#d | #hvc.#h, #f);
			#Atc #Atc2;
			if (3 != 0)
			{
				#Atc2 = #Atc;
			}
			if (#Atc2 != null)
			{
				#Atc #Atc3 = #Atc2;
				#huc[] array = new #huc[4];
				RuntimeFieldHandle fldHandle = fieldof(#l8c.#d).FieldHandle;
				if (!false)
				{
					RuntimeHelpers.InitializeArray(array, fldHandle);
				}
				if (#Atc3.#otc(array))
				{
					return #Atc2;
				}
			}
			#fuc #fuc = base.SnappingProvider.#Jrc(#f);
			if (false)
			{
				goto IL_46;
			}
			#fuc #fuc2 = #fuc;
			IL_46:
			if (8 == 0)
			{
				return #Atc2;
			}
			if (#fuc2 != null && #fuc2.SnapToEdgeOrigin == #iuc.#c)
			{
				return new #Atc(#huc.#e, PointsConverter.#vsc(#fuc2.Point));
			}
			return null;
		}

		// Token: 0x060064E7 RID: 25831 RVA: 0x0018C47C File Offset: 0x0018A67C
		private PreciseInputParameters #DNc(bool #ENc, Point3D? #TPc)
		{
			#WWc #WWc = base.ProjectContext.MainModel;
			#WWc #WWc2;
			if (!false)
			{
				#WWc2 = #WWc;
			}
			if (#WWc2 == null)
			{
				return null;
			}
			Point3D? point3D = #TPc;
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			Point3D? point3D3 = (point3D2 != null) ? point3D2 : this.#KIc();
			if (!false)
			{
				#TPc = point3D3;
			}
			MoveMode moveMode = MoveMode.FreeDefault;
			MoveMode moveMode2;
			if (8 != 0)
			{
				moveMode2 = moveMode;
			}
			Point? point = null;
			double? num = null;
			EnabledPreciseInputSwitches enabledPreciseInputSwitches = EnabledPreciseInputSwitches.All;
			EnabledPreciseInputSwitches enabledPreciseInputSwitches2;
			if (!false)
			{
				enabledPreciseInputSwitches2 = enabledPreciseInputSwitches;
			}
			while (#TPc != null)
			{
				Point point2 = PointsConverter.#vsc(#TPc.Value);
				Point point3;
				if (7 != 0)
				{
					point3 = point2;
				}
				if (false)
				{
					goto IL_186;
				}
				#Atc #Atc = base.SnappingProvider.#bNb(#hvc.#b | #hvc.#c, #TPc.Value);
				if (#Atc != null)
				{
					point3 = PointsConverter.#vsc(#Atc.Point);
				}
				IL_A6:
				IList<SegmentData> list = base.StructuralModel.#jWc(point3);
				moveMode2 = #6Tc.#RTc(list);
				if (moveMode2 == MoveMode.FreeDefault)
				{
					goto IL_196;
				}
				SegmentData segmentData = list[0];
				num = new double?(GeometryHelper.#knc(segmentData.StartPoint.X, segmentData.StartPoint.Y, segmentData.EndPoint.X, segmentData.EndPoint.Y));
				double? num2 = num;
				double num3 = 0.0;
				int num4;
				if (num2.GetValueOrDefault() < num3 & num2 != null)
				{
					if (8 != 0)
					{
						num4 = 360;
						goto IL_148;
					}
					continue;
				}
				IL_173:
				if (5 == 0)
				{
					goto IL_A6;
				}
				if (segmentData.#Uwc())
				{
					enabledPreciseInputSwitches2 = (EnabledPreciseInputSwitches.XGlobalRadioButton | EnabledPreciseInputSwitches.XLocalRadioButton | EnabledPreciseInputSwitches.Radius);
					goto IL_186;
				}
				goto IL_186;
				IL_148:
				num = (double)num4 + num;
				goto IL_173;
				IL_186:
				bool flag = (num4 = (segmentData.#Twc() ? 1 : 0)) != 0;
				if (-1 == 0)
				{
					goto IL_148;
				}
				if (flag)
				{
					enabledPreciseInputSwitches2 = (EnabledPreciseInputSwitches.YGlobalRadioButton | EnabledPreciseInputSwitches.YLocalRadioButton | EnabledPreciseInputSwitches.Radius);
				}
				IL_196:
				#TPc = new Point3D?(PointsConverter.#vsc(point3));
				Point value;
				if (this.EditionState == InsertNodeOnEdgeTool.#qad.#b)
				{
					point3D2 = base.LastHandledPoint;
					if (point3D2 != null)
					{
						point3D2 = base.LastHandledPoint;
						value = PointsConverter.#vsc(point3D2.Value);
						goto IL_1D8;
					}
				}
				value = point3;
				IL_1D8:
				point = new Point?(value);
				break;
			}
			return #aJc.#7Ic(new #GJc
			{
				WorkspaceSize = #WWc2.WorkspaceBoundingBoxData,
				OwnerControl = base.ModelEditorViewModel.View.ParentControl,
				CoordinateValidator = null,
				VisualCoordinate = #TPc,
				IsInitialCoordinate = true,
				ResetCurrentValues = #ENc,
				EnableXCoordinate = true,
				EnableYCoordinate = true,
				Message = (this.#j ? this.#m[this.EditionState] : Strings.StringSelectPoint),
				RelativeCoordinate = point,
				Angle = num,
				MoveMode = moveMode2,
				ProjectContext = base.ProjectContext,
				EnabledPreciseInputSwitches = enabledPreciseInputSwitches2
			});
		}

		// Token: 0x060064E8 RID: 25832 RVA: 0x0018C734 File Offset: 0x0018A934
		private List<LinearObject> #uQc(Point #doc)
		{
			List<LinearObject> list = new List<LinearObject>();
			List<LinearObject> list2;
			if (!false)
			{
				list2 = list;
			}
			IEnumerator<LinearObject> enumerator = base.StructuralModel.LinearObjects.GetEnumerator();
			IEnumerator<LinearObject> enumerator2;
			if (6 != 0)
			{
				enumerator2 = enumerator;
				goto IL_1D;
			}
			try
			{
				for (;;)
				{
					IL_1D:
					for (;;)
					{
						LinearObject linearObject2;
						if (!enumerator2.MoveNext())
						{
							if (5 != 0)
							{
								goto Block_7;
							}
						}
						else
						{
							LinearObject linearObject = enumerator2.Current;
							if (!false)
							{
								linearObject2 = linearObject;
							}
							if (false)
							{
								break;
							}
							if (!#jsc.#Src(linearObject2.Segment, #doc, true) || false || PointsConverter.#uC(linearObject2.StartPoint, #doc) || PointsConverter.#uC(linearObject2.EndPoint, #doc))
							{
								break;
							}
						}
						List<LinearObject> list3 = list2;
						LinearObject item = linearObject2;
						if (7 != 0)
						{
							list3.Add(item);
						}
					}
				}
				Block_7:;
			}
			finally
			{
				if (false || enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			return list2;
		}

		// Token: 0x060064E9 RID: 25833 RVA: 0x0018C7E4 File Offset: 0x0018A9E4
		private void #vQc(NodeToInsert #wQc)
		{
			IEnumerator<LinearObject> enumerator = #wQc.LinearObjects.GetEnumerator();
			IEnumerator<LinearObject> enumerator2;
			if (4 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				if (!false)
				{
					goto IL_EF;
				}
				IL_1A:
				if (2 == 0)
				{
					goto IL_C0;
				}
				LinearObject linearObject = enumerator2.Current;
				LinearObject linearObject2;
				if (!false)
				{
					linearObject2 = linearObject;
				}
				IL_2D:
				Point? point = #jsc.#gsc(linearObject2.Segment, #wQc.LogicalPoint);
				Point? point2;
				if (!false)
				{
					point2 = point;
				}
				if (point2 == null)
				{
					goto IL_EF;
				}
				#WWc #WWc = base.StructuralModel;
				LinearObject #NNc = linearObject2;
				if (!false)
				{
					#WWc.#aWc(#NNc);
				}
				LinearObject linearObject3 = new LinearObject(base.UndoManager, this.#h);
				linearObject3.StartPoint = linearObject2.StartPoint;
				Point value = point2.Value;
				if (6 != 0)
				{
					linearObject3.EndPoint = value;
				}
				LinearObject #NNc2;
				if (!false)
				{
					#NNc2 = linearObject3;
				}
				LinearObject #NNc3 = new LinearObject(base.UndoManager, this.#h)
				{
					StartPoint = point2.Value,
					EndPoint = linearObject2.EndPoint
				};
				IL_C0:
				base.StructuralModel.#9Vc(#NNc2);
				base.StructuralModel.#9Vc(#NNc3);
				base.ModelEditorViewModel.#e0c(base.StructuralModel.LinearObjects);
				IL_EF:
				if (!true)
				{
					goto IL_2D;
				}
				if (enumerator2.MoveNext())
				{
					goto IL_1A;
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
		}

		// Token: 0x060064EA RID: 25834 RVA: 0x0018C948 File Offset: 0x0018AB48
		private void #xQc(IList<NodeToInsert> #UPc)
		{
			IList<NodeToInsert> list = #UPc.Where(new Func<NodeToInsert, bool>(InsertNodeOnEdgeTool.<>c.<>9.#uad)).ToList<NodeToInsert>();
			if (7 != 0)
			{
				#UPc = list;
			}
			if (!#UPc.Any<NodeToInsert>())
			{
				return;
			}
			IEnumerator<IGrouping<SegmentData, NodeToInsert>> enumerator = #UPc.AsEnumerable<NodeToInsert>().GroupBy(new Func<NodeToInsert, SegmentData>(InsertNodeOnEdgeTool.<>c.<>9.#vad)).GetEnumerator();
			IEnumerator<IGrouping<SegmentData, NodeToInsert>> enumerator2;
			if (4 != 0)
			{
				enumerator2 = enumerator;
				goto IL_70;
			}
			try
			{
				for (;;)
				{
					IL_70:
					while (enumerator2.MoveNext())
					{
						IGrouping<SegmentData, NodeToInsert> grouping = enumerator2.Current;
						IGrouping<SegmentData, NodeToInsert> source;
						if (!false)
						{
							source = grouping;
						}
						NodeToInsert nodeToInsert = source.First<NodeToInsert>();
						NodeToInsert nodeToInsert2;
						if (!false)
						{
							nodeToInsert2 = nodeToInsert;
						}
						if (!false)
						{
							PolygonData #JP = nodeToInsert2.Polygon;
							SegmentData #PP = nodeToInsert2.PolygonSegment;
							IList<Point> #BP = source.Select(new Func<NodeToInsert, Point>(InsertNodeOnEdgeTool.<>c.<>9.#wad)).ToList<Point>();
							if (!false)
							{
								PolygonOperationsHelper.#Esc(#JP, #PP, #BP);
							}
						}
					}
					break;
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			ShapeDataModel shapeDataModel = #UPc.First<NodeToInsert>().Shape;
			ShapeDataModel #rP;
			if (6 != 0)
			{
				#rP = shapeDataModel;
			}
			if (!false)
			{
				this.#pQc(#rP);
			}
			base.StructuralModel.#KVc();
		}

		// Token: 0x060064EB RID: 25835 RVA: 0x0018CA80 File Offset: 0x0018AC80
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected errors catch.")]
		private void #QKc(IList<NodeToInsert> #UPc, bool #gzb, Point3D #HAb)
		{
			try
			{
				#bDc #bDc = base.UndoManager;
				if (true)
				{
					#bDc.#uCc();
				}
				#PBc #PBc = base.ProjectContext.MainModel.Shapes;
				if (!false)
				{
					#PBc.#NBc();
				}
				#PBc #PBc2 = base.ProjectContext.MainModel.LinearObjects;
				if (!false)
				{
					#PBc2.#NBc();
				}
				IEnumerator<IGrouping<ShapeDataModel, NodeToInsert>> enumerator = #UPc.GroupBy(new Func<NodeToInsert, ShapeDataModel>(InsertNodeOnEdgeTool.<>c.<>9.#xad)).GetEnumerator();
				IEnumerator<IGrouping<ShapeDataModel, NodeToInsert>> enumerator2;
				if (true)
				{
					enumerator2 = enumerator;
				}
				try
				{
					if (7 != 0)
					{
						goto IL_D8;
					}
					IL_7E:
					IGrouping<ShapeDataModel, NodeToInsert> grouping;
					IEnumerator<NodeToInsert> enumerator3 = grouping.GetEnumerator();
					IEnumerator<NodeToInsert> enumerator4;
					if (!false)
					{
						enumerator4 = enumerator3;
					}
					try
					{
						while (enumerator4.MoveNext())
						{
							NodeToInsert nodeToInsert = enumerator4.Current;
							if (nodeToInsert.LinearObjects != null && nodeToInsert.LinearObjects.Any<LinearObject>())
							{
								this.#vQc(nodeToInsert);
							}
						}
					}
					finally
					{
						if (enumerator4 != null)
						{
							enumerator4.Dispose();
						}
					}
					if (grouping.Key != null)
					{
						this.#xQc(grouping.ToList<NodeToInsert>());
					}
					IL_D8:
					if (enumerator2.MoveNext())
					{
						IGrouping<ShapeDataModel, NodeToInsert> grouping2 = enumerator2.Current;
						if (4 == 0)
						{
							goto IL_7E;
						}
						grouping = grouping2;
						goto IL_7E;
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				base.ToolOperationsHelper.#bEc();
				base.#MIc();
				this.#qQc();
				this.#zIc();
				this.#AQc();
			}
			catch (#vYd #3Pb)
			{
				base.#2Pb(#3Pb);
			}
			catch (ModelValidationException #PIc)
			{
				base.#OIc(#PIc);
			}
			catch (Exception #ob)
			{
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107443853), base.ToolInfo);
				base.UndoManager.#yCc(false);
			}
			finally
			{
				base.UndoManager.#vCc();
				base.ProjectContext.MainModel.Shapes.#OBc();
				base.ProjectContext.MainModel.LinearObjects.#OBc();
				this.#1kb();
				if (#gzb)
				{
					base.PreciseInputProvider.Update(this.#DNc(false, new Point3D?(#HAb)));
				}
				base.IsWorking = false;
			}
		}

		// Token: 0x060064EC RID: 25836 RVA: 0x0018CD14 File Offset: 0x0018AF14
		private IList<NodeToInsert> #XPc(Point3D #HAb)
		{
			List<NodeToInsert> list2;
			if (2 != 0)
			{
				IEnumerable<Point> enumerable = this.#VPc(#HAb);
				List<NodeToInsert> list = new List<NodeToInsert>();
				if (!false)
				{
					list2 = list;
				}
				IEnumerator<Point> enumerator = enumerable.GetEnumerator();
				IEnumerator<Point> enumerator2;
				if (6 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					for (;;)
					{
						if (false)
						{
							goto IL_34;
						}
						Point point2;
						if (!enumerator2.MoveNext())
						{
							if (2 != 0)
							{
								break;
							}
							goto IL_42;
						}
						else
						{
							if (false)
							{
								goto IL_65;
							}
							Point point = enumerator2.Current;
							if (!true)
							{
								goto IL_34;
							}
							point2 = point;
							goto IL_34;
						}
						IL_51:
						List<LinearObject> list3 = this.#uQc(point2);
						List<LinearObject> source;
						if (!false)
						{
							source = list3;
						}
						if (source.Any<LinearObject>())
						{
							goto IL_65;
						}
						continue;
						IL_34:
						IList<NodeToInsert> list4 = this.#yQc(point2);
						IList<NodeToInsert> list5;
						if (4 != 0)
						{
							list5 = list4;
						}
						if (list5 != null)
						{
							goto IL_42;
						}
						goto IL_51;
						IL_65:
						list2.Add(new NodeToInsert
						{
							LinearObjects = source,
							LogicalPoint = point2
						});
						continue;
						IL_42:
						if (!list5.Any<NodeToInsert>())
						{
							goto IL_51;
						}
						List<NodeToInsert> list6 = list2;
						IEnumerable<NodeToInsert> collection = list5;
						if (false)
						{
							goto IL_51;
						}
						list6.AddRange(collection);
						goto IL_51;
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
			}
			return list2;
		}

		// Token: 0x060064ED RID: 25837 RVA: 0x0018CDEC File Offset: 0x0018AFEC
		private IList<Point> #VPc(Point3D #WPc)
		{
			List<Point> list2;
			Point point4;
			Vector #4Bb;
			int num2;
			int num3;
			if (true)
			{
				List<Point> list = new List<Point>();
				if (5 != 0)
				{
					list2 = list;
				}
				Point point = PointsConverter.#vsc(#WPc);
				Point point2;
				if (7 != 0)
				{
					point2 = point;
				}
				if (false)
				{
					goto IL_4E;
				}
				if (!this.#j)
				{
					goto IL_45;
				}
				bool flag = this.#n != null;
				IL_35:
				if (flag && #YIc.#Dzb(this.#n, #WPc))
				{
					goto IL_4E;
				}
				IL_45:
				List<Point> list3 = list2;
				Point item = point2;
				if (-1 != 0)
				{
					list3.Add(item);
				}
				return list2;
				IL_4E:
				if (this.#n == null)
				{
					return list2;
				}
				Point point3 = PointsConverter.#vsc(this.#n.Value);
				if (!false)
				{
					point4 = point3;
				}
				Vector vector = Vector.#53d(Point.#H3d(point2, point4), (double)(this.NumberOfNodesToInsertInARow - 1));
				if (!false)
				{
					#4Bb = vector;
				}
				int num = num2 = 0;
				if (num != 0)
				{
					goto IL_A8;
				}
				flag = (num != 0);
				if (num != 0)
				{
					goto IL_35;
				}
				if (5 != 0)
				{
					num3 = num;
				}
			}
			goto IL_AC;
			IL_A8:
			num3 = num2 + 1;
			IL_AC:
			if (num3 >= this.NumberOfNodesToInsertInARow)
			{
				return list2;
			}
			list2.Add(point4);
			point4 = Point.#G3d(point4, #4Bb);
			num2 = num3;
			goto IL_A8;
		}

		// Token: 0x060064EE RID: 25838 RVA: 0x0018CED0 File Offset: 0x0018B0D0
		private IList<NodeToInsert> #yQc(Point #zQc)
		{
			List<#cQc> list = this.#CQc(#zQc);
			List<#cQc> list2;
			if (true)
			{
				list2 = list;
			}
			if (list2 == null || !list2.Any<#cQc>())
			{
				return null;
			}
			List<NodeToInsert> list3 = new List<NodeToInsert>(list2.Count);
			List<NodeToInsert> list4;
			if (2 != 0)
			{
				list4 = list3;
			}
			List<#cQc>.Enumerator enumerator = list2.GetEnumerator();
			List<#cQc>.Enumerator enumerator2;
			if (4 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				for (;;)
				{
					int num;
					bool flag = (num = (enumerator2.MoveNext() ? 1 : 0)) != 0;
					#cQc #cQc2;
					if (!false)
					{
						if (!flag)
						{
							break;
						}
						#cQc #cQc = enumerator2.Current;
						if (!false)
						{
							#cQc2 = #cQc;
						}
						if (#cQc2.Shape != null && #cQc2.Polygon != null)
						{
							num = ((#cQc2.PolygonSegment != null) ? 1 : 0);
						}
						else
						{
							num = 0;
						}
					}
					IL_66:
					if (num != 0)
					{
						NodeToInsert nodeToInsert = new NodeToInsert();
						nodeToInsert.LogicalPoint = #zQc;
						nodeToInsert.Polygon = #cQc2.Polygon;
						nodeToInsert.PolygonSegment = #cQc2.PolygonSegment;
						ShapeDataModel shapeDataModel = #cQc2.Shape;
						if (3 != 0)
						{
							nodeToInsert.Shape = shapeDataModel;
						}
						NodeToInsert item;
						if (4 != 0)
						{
							item = nodeToInsert;
						}
						list4.Add(item);
						continue;
					}
					continue;
					goto IL_66;
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			return list4;
		}

		// Token: 0x060064EF RID: 25839 RVA: 0x00051886 File Offset: 0x0004FA86
		private void #AQc()
		{
			List<SnappingSegmentData> list = this.#a;
			if (7 != 0)
			{
				list.Clear();
			}
			HashSet<ShapeDataModel> hashSet = this.#b;
			if (!false)
			{
				hashSet.Clear();
			}
		}

		// Token: 0x060064F0 RID: 25840 RVA: 0x0018CFD4 File Offset: 0x0018B1D4
		private List<SnappingSegmentData> #BQc()
		{
			IReadOnlyCollection<ShapeDataModel> readOnlyCollection = this.#oQc();
			IReadOnlyCollection<ShapeDataModel> readOnlyCollection2;
			if (!false)
			{
				readOnlyCollection2 = readOnlyCollection;
			}
			int num2;
			int num;
			bool flag = (num = (num2 = (this.#b.SetEquals(readOnlyCollection2) ? 1 : 0))) != 0;
			if (false)
			{
				goto IL_97;
			}
			if (false)
			{
				goto IL_BA;
			}
			if (flag)
			{
				goto IL_CB;
			}
			do
			{
				HashSet<ShapeDataModel> hashSet = this.#b;
				if (!false)
				{
					hashSet.Clear();
				}
			}
			while (false);
			ISet<ShapeDataModel> #H1d = this.#b;
			IEnumerable<ShapeDataModel> #8f = readOnlyCollection2;
			if (4 != 0)
			{
				#H1d.#pR(#8f);
			}
			List<SnappingSegmentData> list = this.#a;
			if (!false)
			{
				list.Clear();
			}
			List<SnappingSegmentData> list2 = this.#a;
			IEnumerable<SnappingSegmentData> collection = base.ProjectContext.MainModel.#mWc();
			if (!false)
			{
				list2.AddRange(collection);
			}
			List<BoundingBoxDataLight> list3 = this.#c;
			if (!false)
			{
				list3.Clear();
			}
			IL_7E:
			this.#c.Capacity = this.#a.Count + 1;
			num = 0;
			IL_97:
			int num3 = num;
			goto IL_BD;
			IL_BA:
			num3 = num2 + 1;
			IL_BD:
			if (num3 < this.#a.Count)
			{
				if (!false)
				{
					this.#c.Add(this.#a[num3].BoundingBox);
					num2 = num3;
					goto IL_BA;
				}
				goto IL_7E;
			}
			IL_CB:
			return this.#a;
		}

		// Token: 0x060064F1 RID: 25841 RVA: 0x0018D0EC File Offset: 0x0018B2EC
		private List<#cQc> #CQc(Point #doc)
		{
			List<#cQc> list = new List<#cQc>();
			List<#cQc> list2;
			if (!false)
			{
				list2 = list;
			}
			List<SnappingSegmentData> list3 = this.#BQc();
			List<SnappingSegmentData> list4;
			if (5 != 0)
			{
				list4 = list3;
			}
			List<SnappingSegmentData> list5 = new List<SnappingSegmentData>();
			List<SnappingSegmentData> list6;
			if (!false)
			{
				list6 = list5;
			}
			int num = 0;
			int num2;
			if (!false)
			{
				num2 = num;
			}
			for (;;)
			{
				IL_77:
				int i = num2;
				while (i < list4.Count)
				{
					SnappingSegmentData snappingSegmentData = list4[num2];
					SnappingSegmentData snappingSegmentData2;
					if (!false)
					{
						snappingSegmentData2 = snappingSegmentData;
					}
					if (this.#c[num2].#Zvc(#doc, 0.01) && #jsc.#Src(snappingSegmentData2, #doc, true))
					{
						List<SnappingSegmentData> list7 = list6;
						SnappingSegmentData item = snappingSegmentData2;
						if (!false)
						{
							list7.Add(item);
						}
					}
					int num3 = i = num2;
					if (3 != 0)
					{
						num2 = num3 + 1;
						goto IL_77;
					}
				}
				break;
			}
			foreach (SnappingSegmentData snappingSegmentData3 in list6)
			{
				if (snappingSegmentData3.SourceShape != null && snappingSegmentData3.SourcePolygon != null && !PointsConverter.#uC(snappingSegmentData3.StartPoint, #doc) && !PointsConverter.#uC(snappingSegmentData3.EndPoint, #doc))
				{
					list2.Add(new #cQc((ShapeDataModel)snappingSegmentData3.SourceShape, snappingSegmentData3.SourcePolygon, snappingSegmentData3.SourceSegment));
				}
			}
			return list2;
		}

		// Token: 0x17001C3D RID: 7229
		// (get) Token: 0x060064F2 RID: 25842 RVA: 0x000518AA File Offset: 0x0004FAAA
		// (set) Token: 0x060064F3 RID: 25843 RVA: 0x000518B2 File Offset: 0x0004FAB2
		private protected InsertNodeOnEdgeTool.#qad EditionState { protected get; private set; }

		// Token: 0x060064F4 RID: 25844 RVA: 0x000518BB File Offset: 0x0004FABB
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#f;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x060064F5 RID: 25845 RVA: 0x000518D0 File Offset: 0x0004FAD0
		public void #1()
		{
			bool #POb = true;
			if (!false)
			{
				this.#1(#POb);
			}
			if (!false)
			{
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x04002953 RID: 10579
		private readonly List<SnappingSegmentData> #a = new List<SnappingSegmentData>();

		// Token: 0x04002954 RID: 10580
		private readonly HashSet<ShapeDataModel> #b = new HashSet<ShapeDataModel>();

		// Token: 0x04002955 RID: 10581
		private readonly List<BoundingBoxDataLight> #c = new List<BoundingBoxDataLight>();

		// Token: 0x04002956 RID: 10582
		[CompilerGenerated]
		private bool #d;

		// Token: 0x04002957 RID: 10583
		[CompilerGenerated]
		private int #e;

		// Token: 0x04002958 RID: 10584
		private readonly Cursor #f;

		// Token: 0x04002959 RID: 10585
		private readonly ICrossIndicatorDrawingResult #g;

		// Token: 0x0400295A RID: 10586
		private readonly #1Wc #h;

		// Token: 0x0400295B RID: 10587
		private int #i;

		// Token: 0x0400295C RID: 10588
		private bool #j;

		// Token: 0x0400295D RID: 10589
		[CompilerGenerated]
		private InsertNodeOnEdgeTool.#qad #k;

		// Token: 0x0400295E RID: 10590
		private readonly IPolylineDrawingResult #l;

		// Token: 0x0400295F RID: 10591
		private readonly Dictionary<InsertNodeOnEdgeTool.#qad, string> #m;

		// Token: 0x04002960 RID: 10592
		private Point3D? #n;

		// Token: 0x04002961 RID: 10593
		private readonly IPointsDrawingResult #o;

		// Token: 0x02000C20 RID: 3104
		protected enum #qad
		{
			// Token: 0x04002963 RID: 10595
			#a,
			// Token: 0x04002964 RID: 10596
			#b
		}
	}
}
