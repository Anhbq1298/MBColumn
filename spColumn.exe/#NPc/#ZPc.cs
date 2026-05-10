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
using #Fmc;
using #IDc;
using #kXc;
using #NWc;
using #T0c;
using #UYd;
using #v1c;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;

namespace #NPc
{
	// Token: 0x02000C12 RID: 3090
	internal sealed class #ZPc : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #QPc
	{
		// Token: 0x06006480 RID: 25728 RVA: 0x00189F28 File Offset: 0x00188128
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by IoC.")]
		public #ZPc(#6Ic #JDc, #1Wc #2Nc, #MPc #0Pc) : base(#JDc)
		{
			#X0d.#V0d(#JDc, #Phc.#3hc(107444554), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107444569));
			#X0d.#V0d(#0Pc, #Phc.#3hc(107444484), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107443943));
			this.#c = #2Nc;
			base.Header = Strings.StringInsertNode;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.InsertCustomNode);
			this.#a = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			this.#b = #JDc.DrawingResultsFactory.CreateCrossIndicatorDrawingResult();
			this.#d = 1;
			this.InsertNodesInRow = false;
			this.#e = #ZPc.#qad.#a;
			#0Pc.DataContext = this;
			base.ToolOptionsEditor = #0Pc;
			this.#f = base.ToolContext.DrawingResultsFactory.CreatePolylineDrawingResult();
			this.#g = new Dictionary<#ZPc.#qad, string>();
			this.#g.Add(#ZPc.#qad.#a, Strings.StringSelectStartPoint);
			this.#g.Add(#ZPc.#qad.#b, Strings.StringSelectEndPoint);
			base.HelpId = HelpIdentifiers.ToolInsertCustomNode;
		}

		// Token: 0x17001C31 RID: 7217
		// (get) Token: 0x06006481 RID: 25729 RVA: 0x00051608 File Offset: 0x0004F808
		// (set) Token: 0x06006482 RID: 25730 RVA: 0x0018A040 File Offset: 0x00188240
		public int NumberOfNodesToInsertInARow
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d == value)
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
					this.#d = value;
					bool flag = value > 1;
					if (5 != 0)
					{
						this.InsertNodesInRow = flag;
					}
				}
				string propertyName2 = #Phc.#3hc(107443922);
				if (4 != 0)
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

		// Token: 0x17001C32 RID: 7218
		// (get) Token: 0x06006483 RID: 25731 RVA: 0x00051610 File Offset: 0x0004F810
		// (set) Token: 0x06006484 RID: 25732 RVA: 0x00051618 File Offset: 0x0004F818
		protected bool InsertNodesInRow { get; set; }

		// Token: 0x06006485 RID: 25733 RVA: 0x0018A0A8 File Offset: 0x001882A8
		public override void #5b()
		{
			if (2 != 0)
			{
				base.#5b();
			}
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[3];
			array[0] = ModelEditorControlEventType.MouseLeftButtonUp;
			array[1] = ModelEditorControlEventType.MouseLeftButtonDown;
			if (!false)
			{
				base.#FIc(array);
			}
			ISnapPointsMarker #IJc = base.SnapPointsMarker;
			#6Gc #JAc = base.SettingsProvider;
			if (6 != 0)
			{
				#8Ib.#HJc(#IJc, #JAc);
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#f;
			Color lineColor = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeColor;
			if (2 != 0)
			{
				linesDrawingResultBase.LineColor = lineColor;
			}
			ILinesDrawingResultBase linesDrawingResultBase2 = this.#f;
			double lineThickness = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeThickness;
			if (!false)
			{
				linesDrawingResultBase2.LineThickness = lineThickness;
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			Cursor cursor = this.#a;
			bool forceCursor = false;
			if (2 != 0)
			{
				modelEditorControl.SetCursor(cursor, forceCursor);
			}
			base.#AIc(this.#b);
		}

		// Token: 0x06006486 RID: 25734 RVA: 0x0018A158 File Offset: 0x00188358
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
			IDrawingResult drawingResult = this.#b;
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

		// Token: 0x06006487 RID: 25735 RVA: 0x0018A1D4 File Offset: 0x001883D4
		public override void #1kb()
		{
			if (4 != 0)
			{
				if (!false)
				{
					base.#1kb();
				}
				do
				{
					if (3 != 0)
					{
						this.#e = #ZPc.#qad.#a;
					}
				}
				while (7 == 0);
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#f;
				if (!false)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
				this.#h = null;
			}
		}

		// Token: 0x06006488 RID: 25736 RVA: 0x0018A224 File Offset: 0x00188424
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			if (this.#e != #ZPc.#qad.#a)
			{
				return;
			}
			Point3D? point3D2;
			do
			{
				#R2c #R2c = base.ToolContext.MouseAndKeyboardService;
				if (7 != 0)
				{
					#R2c.#mNb();
				}
				Point3D? point3D = base.#HIc(#4kb);
				if (true)
				{
					point3D2 = point3D;
				}
				if (point3D2 != null && -1 != 0 && 2 != 0)
				{
					Point3D? point3D3 = base.ToolOperationsHelper.#aEc(point3D2.Value);
					if (!false)
					{
						point3D2 = point3D3;
					}
					if (!false)
					{
						goto Block_5;
					}
				}
			}
			while (false);
			return;
			Block_5:
			if (point3D2 == null)
			{
				return;
			}
			Point3D? point3D4 = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D2.Value).#Dtc();
			Point3D? point3D5;
			if (-1 != 0)
			{
				point3D5 = point3D4;
			}
			if (point3D5 == null)
			{
				return;
			}
			bool isWorking = true;
			if (4 != 0)
			{
				base.IsWorking = isWorking;
			}
			Point3D value = point3D5.Value;
			bool #gzb = false;
			if (3 != 0)
			{
				this.#fzb(value, #gzb);
			}
		}

		// Token: 0x06006489 RID: 25737 RVA: 0x0018A2FC File Offset: 0x001884FC
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			if (this.#e != #ZPc.#qad.#b)
			{
				return;
			}
			#R2c #R2c = base.ToolContext.MouseAndKeyboardService;
			if (!false)
			{
				#R2c.#mNb();
			}
			Point3D? point3D = base.#HIc(#4kb);
			Point3D? point3D2;
			if (3 != 0)
			{
				point3D2 = point3D;
			}
			IL_2A:
			while (point3D2 != null)
			{
				Point3D? point3D3 = (this.#h != null) ? base.ToolOperationsHelper.#9Dc(this.#h.Value, point3D2.Value) : base.ToolOperationsHelper.#aEc(point3D2.Value);
				if (-1 != 0)
				{
					point3D2 = point3D3;
				}
				while (point3D2 != null)
				{
					if (-1 == 0)
					{
						goto IL_2A;
					}
					if (!false)
					{
						Point3D? point3D4 = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D2.Value).#Dtc();
						Point3D? point3D5;
						if (6 != 0)
						{
							point3D5 = point3D4;
						}
						if (point3D5 == null)
						{
							return;
						}
						Point3D value = point3D5.Value;
						bool #gzb = false;
						if (2 != 0)
						{
							this.#fzb(value, #gzb);
						}
						bool isWorking = false;
						if (!false)
						{
							base.IsWorking = isWorking;
						}
						return;
					}
				}
				return;
			}
		}

		// Token: 0x0600648A RID: 25738 RVA: 0x0018A3FC File Offset: 0x001885FC
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			Point3D? point3D2;
			for (;;)
			{
				if (!false)
				{
					base.#HEc(#IEc, #Kzb);
				}
				if (this.#e != #ZPc.#qad.#a)
				{
					goto IL_71;
				}
				Point3D? point3D = base.ToolOperationsHelper.#aEc(#Kzb);
				if (true)
				{
					point3D2 = point3D;
				}
				if (-1 == 0)
				{
					goto IL_D3;
				}
				if (point3D2 == null)
				{
					if (true)
					{
						break;
					}
					goto IL_71;
				}
				else
				{
					if (4 != 0)
					{
						goto Block_4;
					}
					goto IL_99;
				}
				IL_DF:
				if (true)
				{
					return;
				}
				continue;
				IL_71:
				if (this.#h == null)
				{
					goto IL_DF;
				}
				Point3D? point3D3 = base.ToolOperationsHelper.#9Dc(this.#h.Value, #Kzb);
				Point3D? point3D4;
				if (!false)
				{
					point3D4 = point3D3;
				}
				IL_99:
				if (point3D4 == null)
				{
					return;
				}
				#Atc #Atc = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D4.Value);
				#Atc #Atc2;
				if (4 != 0)
				{
					#Atc2 = #Atc;
				}
				base.SnapPointsMarker.Mark(#Atc2);
				if (#Atc2 == null)
				{
					goto IL_DF;
				}
				IL_D3:
				this.#NOc(#Atc2.Point);
				goto IL_DF;
			}
			return;
			Block_4:
			#Atc #Atc3 = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D2.Value);
			#Atc #Atc4;
			if (true)
			{
				#Atc4 = #Atc3;
			}
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = #Atc4;
			if (!false)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
		}

		// Token: 0x0600648B RID: 25739 RVA: 0x0018A514 File Offset: 0x00188714
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected errors catch.")]
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			Point3D? point3D = base.ToolOperationsHelper.#aEc(#HAb);
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			if (point3D2 == null)
			{
				return;
			}
			Point3D value = point3D2.Value;
			if (-1 != 0)
			{
				#HAb = value;
			}
			if (this.#e == #ZPc.#qad.#a && this.InsertNodesInRow)
			{
				this.#h = new Point3D?(#HAb);
				this.#e = #ZPc.#qad.#b;
				Point3D #HAb2 = #HAb;
				if (2 != 0)
				{
					base.#fzb(#HAb2, #gzb);
				}
				if (#gzb)
				{
					#jUc #jUc = base.PreciseInputProvider;
					PreciseInputParameters initializeInputParameters = this.#DNc(false, new Point3D?(#HAb));
					if (true)
					{
						#jUc.Update(initializeInputParameters);
					}
					return;
				}
			}
			else
			{
				IList<Point> list2;
				try
				{
					IList<Point> list = this.#XPc(#HAb);
					if (2 != 0)
					{
						list2 = list;
					}
				}
				catch (Exception #ob)
				{
					base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107443853), base.ToolInfo);
					return;
				}
				if (list2.Any<Point>())
				{
					IList<Point> #UPc = list2;
					Point3D #HAb3 = #HAb;
					if (5 != 0)
					{
						this.#QKc(#UPc, #gzb, #HAb3);
					}
				}
			}
		}

		// Token: 0x0600648C RID: 25740 RVA: 0x0018A60C File Offset: 0x0018880C
		protected override void #GIc()
		{
			if (4 != 0)
			{
				ICrossIndicatorDrawingResult #LIc = this.#b;
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

		// Token: 0x0600648D RID: 25741 RVA: 0x00051621 File Offset: 0x0004F821
		protected override void #hIc()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#b;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
		}

		// Token: 0x0600648E RID: 25742 RVA: 0x0018A654 File Offset: 0x00188854
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
			IDrawingResult drawingResult = this.#b;
			if (2 != 0)
			{
				modelEditorControl.AddToView(drawingResult);
			}
			ICrossIndicatorDrawingResult crossIndicatorDrawingResult = this.#b;
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

		// Token: 0x0600648F RID: 25743 RVA: 0x0018A6B4 File Offset: 0x001888B4
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

		// Token: 0x06006490 RID: 25744 RVA: 0x0005163B File Offset: 0x0004F83B
		protected override void #JEc(CameraDistanceChangedEventArgs #KEc)
		{
			if (#KEc == null)
			{
				return;
			}
			ICrossIndicatorDrawingResult #LIc = this.#b;
			if (!false)
			{
				base.#AIc(#LIc);
			}
		}

		// Token: 0x06006491 RID: 25745 RVA: 0x0018A708 File Offset: 0x00188908
		private PreciseInputParameters #DNc(bool #ENc, Point3D? #TPc)
		{
			if (-1 == 0)
			{
				goto IL_75;
			}
			#WWc #WWc = base.ProjectContext.MainModel;
			#WWc #WWc2;
			if (!false)
			{
				#WWc2 = #WWc;
			}
			bool flag2;
			MoveMode moveMode2;
			Point? point;
			EnabledPreciseInputSwitches enabledPreciseInputSwitches2;
			double? num;
			if (#WWc2 != null)
			{
				Point3D? point3D = #TPc;
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				bool flag = flag2 = (point3D2 != null);
				if (false)
				{
					goto IL_143;
				}
				Point3D? point3D3 = flag ? point3D2 : this.#KIc();
				if (!false)
				{
					#TPc = point3D3;
				}
				MoveMode moveMode = MoveMode.FreeDefault;
				if (!false)
				{
					moveMode2 = moveMode;
				}
				point = null;
				if (false)
				{
					goto IL_1F4;
				}
				EnabledPreciseInputSwitches enabledPreciseInputSwitches = EnabledPreciseInputSwitches.All;
				if (-1 != 0)
				{
					enabledPreciseInputSwitches2 = enabledPreciseInputSwitches;
				}
				num = null;
				if (#TPc != null)
				{
					goto IL_75;
				}
				goto IL_1DE;
			}
			IL_18:
			return null;
			IL_75:
			Point point2 = PointsConverter.#vsc(#TPc.Value);
			Point point3;
			if (!false)
			{
				point3 = point2;
			}
			#Atc #Atc = base.SnappingProvider.#bNb(#hvc.#b | #hvc.#c, #TPc.Value);
			if (#Atc != null)
			{
				point3 = PointsConverter.#vsc(#Atc.Point);
			}
			IList<SegmentData> list = base.StructuralModel.#jWc(point3);
			moveMode2 = #6Tc.#RTc(list);
			if (moveMode2 == MoveMode.FreeDefault)
			{
				goto IL_197;
			}
			SegmentData segmentData = list[0];
			num = new double?(GeometryHelper.#knc(segmentData.StartPoint.X, segmentData.StartPoint.Y, segmentData.EndPoint.X, segmentData.EndPoint.Y));
			if (false)
			{
				goto IL_18;
			}
			double? num2 = num;
			double num3 = 0.0;
			flag2 = (num2.GetValueOrDefault() < num3);
			IL_143:
			if (flag2 & num2 != null)
			{
				num3 = (double)360;
				num2 = num;
				num = num3 + num2;
			}
			if (segmentData.#Uwc())
			{
				enabledPreciseInputSwitches2 = (EnabledPreciseInputSwitches.XGlobalRadioButton | EnabledPreciseInputSwitches.XLocalRadioButton | EnabledPreciseInputSwitches.Radius);
			}
			if (segmentData.#Twc())
			{
				enabledPreciseInputSwitches2 = (EnabledPreciseInputSwitches.YGlobalRadioButton | EnabledPreciseInputSwitches.YLocalRadioButton | EnabledPreciseInputSwitches.Radius);
			}
			IL_197:
			#TPc = new Point3D?(PointsConverter.#vsc(point3));
			Point value;
			if (this.#e == #ZPc.#qad.#b)
			{
				Point3D? point3D2 = base.LastHandledPoint;
				if (point3D2 != null)
				{
					point3D2 = base.LastHandledPoint;
					value = PointsConverter.#vsc(point3D2.Value);
					goto IL_1D9;
				}
			}
			value = point3;
			IL_1D9:
			point = new Point?(value);
			IL_1DE:
			if (false)
			{
				goto IL_75;
			}
			if (point == null)
			{
				point = base.#IIc();
			}
			IL_1F4:
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
				Message = (this.InsertNodesInRow ? this.#g[this.#e] : Strings.StringSelectPoint),
				RelativeCoordinate = point,
				Angle = num,
				MoveMode = moveMode2,
				EnabledPreciseInputSwitches = enabledPreciseInputSwitches2,
				ProjectContext = base.ProjectContext
			});
		}

		// Token: 0x06006492 RID: 25746 RVA: 0x0018A9D8 File Offset: 0x00188BD8
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected errors catch.")]
		private void #QKc(IList<Point> #UPc, bool #gzb, Point3D #HAb)
		{
			try
			{
				#bDc #bDc = base.UndoManager;
				if (!false)
				{
					#bDc.#uCc();
				}
				#WWc #WWc = base.ProjectContext.MainModel;
				IEnumerable<NodeModel> #UVc = #UPc.Select(new Func<Point, NodeModel>(this.#YPc));
				if (4 != 0)
				{
					#WWc.#TVc(#UVc);
				}
				#V0c #V0c = base.ModelEditorViewModel;
				IEnumerable<NodeModel> #6W = base.ProjectContext.MainModel.Nodes;
				if (true)
				{
					#V0c.#8Zc(#6W);
				}
				base.ToolOperationsHelper.#bEc();
				if (!false)
				{
					base.#MIc();
				}
				do
				{
					if (!false)
					{
						this.#zIc();
					}
				}
				while (false);
			}
			catch (#vYd #3Pb)
			{
				base.#2Pb(#3Pb);
			}
			catch (ModelValidationException #PIc)
			{
				if (7 != 0)
				{
					base.#OIc(#PIc);
				}
			}
			catch (Exception #ob)
			{
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107443853), base.ToolInfo);
				base.UndoManager.#yCc(false);
			}
			finally
			{
				for (;;)
				{
					base.UndoManager.#vCc();
					for (;;)
					{
						this.#1kb();
						if (!#gzb)
						{
							break;
						}
						if (true)
						{
							goto Block_9;
						}
					}
					IL_F9:
					if (6 != 0)
					{
						break;
					}
					continue;
					Block_9:
					base.PreciseInputProvider.Update(this.#DNc(false, new Point3D?(#HAb)));
					goto IL_F9;
				}
				base.IsWorking = false;
			}
		}

		// Token: 0x06006493 RID: 25747 RVA: 0x0018AB20 File Offset: 0x00188D20
		private void #NOc(Point3D #Yrb)
		{
			if (-1 != 0)
			{
				bool flag2;
				bool flag = flag2 = (this.#h != null);
				if (!false)
				{
					if (!flag)
					{
						goto IL_72;
					}
					flag2 = #YIc.#Dzb(this.#h, #Yrb);
				}
				if (flag2 && this.NumberOfNodesToInsertInARow > 1)
				{
					ILinesDrawingResultBase linesDrawingResultBase = this.#f;
					List<Point3D> list = new List<Point3D>();
					list.Add(this.#h.Value);
					if (2 != 0)
					{
						list.Add(#Yrb);
					}
					IEnumerable<Point3D> positions = PointsConverter.#Csc(list, 0.032);
					if (6 != 0)
					{
						linesDrawingResultBase.Positions = positions;
					}
					IModelEditorControl modelEditorControl = base.ModelEditorControl;
					IDrawingResult drawingResult = this.#f;
					if (8 != 0)
					{
						modelEditorControl.AddToView(drawingResult);
					}
					return;
				}
			}
			IL_72:
			IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
			IDrawingResult drawingResult2 = this.#f;
			if (5 != 0)
			{
				modelEditorControl2.RemoveFromView(drawingResult2);
			}
		}

		// Token: 0x06006494 RID: 25748 RVA: 0x0018ABCC File Offset: 0x00188DCC
		private IList<Point> #VPc(Point3D #WPc)
		{
			List<Point> list2;
			Point point2;
			for (;;)
			{
				IL_00:
				List<Point> list = new List<Point>();
				if (!false)
				{
					list2 = list;
				}
				Point point = PointsConverter.#vsc(#WPc);
				if (7 != 0)
				{
					point2 = point;
				}
				Point3D? point3D = this.#h;
				Point3D? point3D2;
				if (3 != 0)
				{
					point3D2 = point3D;
				}
				IL_26:
				while (this.InsertNodesInRow)
				{
					IL_2E:
					while (point3D2 != null)
					{
						Point point4;
						Vector #4Bb;
						int i;
						if (true)
						{
							if (2 == 0)
							{
								goto IL_26;
							}
							if (!#YIc.#Dzb(this.#h, #WPc))
							{
								break;
							}
							Point point3 = PointsConverter.#vsc(point3D2.Value);
							if (!false)
							{
								point4 = point3;
							}
							Vector vector = Vector.#53d(Point.#H3d(point2, point4), (double)(this.NumberOfNodesToInsertInARow - 1));
							if (!false)
							{
								#4Bb = vector;
							}
							if (4 == 0)
							{
								goto IL_00;
							}
							i = 0;
						}
						while (i < this.NumberOfNodesToInsertInARow)
						{
							list2.Add(point4);
							point4 = Point.#G3d(point4, #4Bb);
							if (3 == 0)
							{
								goto IL_2E;
							}
							i++;
						}
						return list2;
					}
					break;
				}
				break;
			}
			List<Point> list3 = list2;
			Point item = point2;
			if (!false)
			{
				list3.Add(item);
			}
			return list2;
		}

		// Token: 0x06006495 RID: 25749 RVA: 0x0018ACAC File Offset: 0x00188EAC
		private IList<Point> #XPc(Point3D #HAb)
		{
			List<Point> list2;
			do
			{
				IEnumerable<Point> enumerable = this.#VPc(#HAb);
				List<Point> list = new List<Point>();
				if (8 != 0)
				{
					list2 = list;
				}
				IEnumerator<Point> enumerator = enumerable.GetEnumerator();
				IEnumerator<Point> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (!false)
					{
						bool flag2;
						bool flag = flag2 = enumerator2.MoveNext();
						if (-1 != 0)
						{
							if (!flag)
							{
								break;
							}
							goto IL_21;
						}
						IL_3C:
						if (flag2)
						{
							continue;
						}
						Point point;
						if (!false)
						{
							List<Point> list3 = list2;
							Point item = point;
							if (!true)
							{
								continue;
							}
							list3.Add(item);
							continue;
						}
						IL_21:
						Point point2 = enumerator2.Current;
						if (!false)
						{
							point = point2;
						}
						flag2 = base.ProjectContext.MainModel.#XVc(point);
						goto IL_3C;
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
			while (5 == 0);
			return list2;
		}

		// Token: 0x06006496 RID: 25750 RVA: 0x00051654 File Offset: 0x0004F854
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#a;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x06006497 RID: 25751 RVA: 0x00051669 File Offset: 0x0004F869
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

		// Token: 0x06006498 RID: 25752 RVA: 0x00051685 File Offset: 0x0004F885
		[CompilerGenerated]
		private NodeModel #YPc(Point #Rf)
		{
			return new NodeModel(base.UndoManager, this.#c, #Rf, #IXc.#b);
		}

		// Token: 0x04002933 RID: 10547
		private readonly Cursor #a;

		// Token: 0x04002934 RID: 10548
		private readonly ICrossIndicatorDrawingResult #b;

		// Token: 0x04002935 RID: 10549
		private readonly #1Wc #c;

		// Token: 0x04002936 RID: 10550
		private int #d;

		// Token: 0x04002937 RID: 10551
		private #ZPc.#qad #e;

		// Token: 0x04002938 RID: 10552
		private readonly IPolylineDrawingResult #f;

		// Token: 0x04002939 RID: 10553
		private readonly Dictionary<#ZPc.#qad, string> #g;

		// Token: 0x0400293A RID: 10554
		private Point3D? #h;

		// Token: 0x0400293B RID: 10555
		[CompilerGenerated]
		private bool #i;

		// Token: 0x02000C13 RID: 3091
		private enum #qad
		{
			// Token: 0x0400293D RID: 10557
			#a,
			// Token: 0x0400293E RID: 10558
			#b
		}
	}
}
