using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using #4vc;
using #7hc;
using #8Cc;
using #bJc;
using #Fmc;
using #hLc;
using #IDc;
using #NWc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Grid;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Selection;
using StructurePoint.CoreAssets.GUI.SharedResources;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #cKc
{
	// Token: 0x02000B9F RID: 2975
	internal sealed class #AKc : SelectionToolBase, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #bKc
	{
		// Token: 0x0600619F RID: 24991 RVA: 0x0017D73C File Offset: 0x0017B93C
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by IoC.")]
		public #AKc(#6Ic #JDc, IResourcesHelper #Umb) : base(#JDc)
		{
			#X0d.#V0d(#Umb, #Phc.#3hc(107415318), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107414753));
			base.Header = Strings.StringModifyGridLine;
			base.IconImage = #Umb.ImageFromResourceBitmap(ToolsIcons.ModifyGridLine);
			this.CurrentToolState = #AKc.#o9c.#a;
			this.#c = base.ToolContext.DrawingResultsFactory.CreatePointsDrawingResult();
			this.#a = base.ToolContext.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#d = base.ToolContext.DrawingResultsFactory.CreateAnnotationDrawingResult();
			this.#f = #Umb.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Move);
			this.#g = #Umb.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.MoveEastWest);
			this.#h = #Umb.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.MoveNorthSouth);
			base.#qMc<#zLc>();
			base.HelpId = HelpIdentifiers.ToolModifyGridLine;
		}

		// Token: 0x17001BCF RID: 7119
		// (get) Token: 0x060061A0 RID: 24992 RVA: 0x0004FEFB File Offset: 0x0004E0FB
		// (set) Token: 0x060061A1 RID: 24993 RVA: 0x0004FF03 File Offset: 0x0004E103
		private #AKc.#o9c CurrentToolState { get; set; }

		// Token: 0x17001BD0 RID: 7120
		// (get) Token: 0x060061A2 RID: 24994 RVA: 0x0004FF0C File Offset: 0x0004E10C
		// (set) Token: 0x060061A3 RID: 24995 RVA: 0x0004FF14 File Offset: 0x0004E114
		private GridLineDefinitionModel SelectedGridLineDefinition { get; set; }

		// Token: 0x060061A4 RID: 24996 RVA: 0x0017D824 File Offset: 0x0017BA24
		public override void #5b()
		{
			IPointsDrawingResult pointsDrawingResult = this.#c;
			Color pointColor = base.SettingsProvider.VisualizationEditedGridLineLocationPointColor;
			if (!false)
			{
				pointsDrawingResult.PointColor = pointColor;
			}
			IPointsDrawingResult pointsDrawingResult2 = this.#c;
			double pointSize = base.SettingsProvider.VisualizationEditedGridLineLocationPointSize;
			if (5 != 0)
			{
				pointsDrawingResult2.PointSize = pointSize;
			}
			IAnnotationDrawingResult annotationDrawingResult = this.#d;
			Color annotationBackground = base.SettingsProvider.VisualizationSelectedGridLineAnnotationBackgroundColor;
			if (5 != 0)
			{
				annotationDrawingResult.SetAnnotationBackground(annotationBackground);
			}
			IAnnotationDrawingResult annotationDrawingResult2 = this.#d;
			Color annotationForeground = base.SettingsProvider.VisualizationSelectedGridLineAnnotationForegroundColor;
			if (!false)
			{
				annotationDrawingResult2.SetAnnotationForeground(annotationForeground);
			}
			IAnnotationDrawingResult annotationDrawingResult3 = this.#d;
			Color annotationBorder = base.SettingsProvider.VisualizationSelectedGridLineAnnotationBorderColor;
			if (!false)
			{
				annotationDrawingResult3.SetAnnotationBorder(annotationBorder);
			}
			ISnapPointsMarker #IJc = base.SnapPointsMarker;
			#6Gc #JAc = base.SettingsProvider;
			if (!false)
			{
				#8Ib.#HJc(#IJc, #JAc);
			}
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[3];
			array[0] = ModelEditorControlEventType.MouseLeftButtonDown;
			array[1] = ModelEditorControlEventType.MouseLeftButtonUp;
			base.#FIc(array);
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			EventHandler value;
			if ((value = #AKc.#2Ui.#a) == null)
			{
				value = (#AKc.#2Ui.#a = new EventHandler(#AKc.#QEc));
			}
			modelEditorControl.CameraChanged -= value;
			IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
			EventHandler value2;
			if ((value2 = #AKc.#2Ui.#a) == null)
			{
				value2 = (#AKc.#2Ui.#a = new EventHandler(#AKc.#QEc));
			}
			modelEditorControl2.CameraChanged += value2;
			base.#5b();
		}

		// Token: 0x060061A5 RID: 24997 RVA: 0x0017D964 File Offset: 0x0017BB64
		public override void #0kb()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#a;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			if (4 != 0)
			{
				this.#1kb();
			}
			ModelEditorControlEventType[] #MEc = null;
			if (7 != 0)
			{
				base.#LEc(#MEc);
			}
			IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
			Cursor arrow = System.Windows.Input.Cursors.Arrow;
			bool forceCursor = false;
			if (-1 != 0)
			{
				modelEditorControl2.SetCursor(arrow, forceCursor);
			}
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = null;
			if (true)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			IModelEditorControl modelEditorControl3 = base.ModelEditorControl;
			EventHandler value;
			if ((value = #AKc.#2Ui.#a) == null)
			{
				value = (#AKc.#2Ui.#a = new EventHandler(#AKc.#QEc));
			}
			if (!false)
			{
				modelEditorControl3.CameraChanged -= value;
			}
			base.#0kb();
		}

		// Token: 0x060061A6 RID: 24998 RVA: 0x0004FF1D File Offset: 0x0004E11D
		public override void #1kb()
		{
			if (2 != 0)
			{
				this.#iKc();
			}
			if (5 != 0)
			{
				base.#1kb();
			}
		}

		// Token: 0x060061A7 RID: 24999 RVA: 0x0017DA04 File Offset: 0x0017BC04
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catch for unexpected exceptions.")]
		protected override void #2kb(KeyEventArgs #HA)
		{
			bool flag3;
			bool flag2;
			bool flag = flag2 = (flag3 = base.ModelEditorViewModel.AreGridLinesVisible);
			if (!true)
			{
				goto IL_167;
			}
			if (!flag)
			{
				return;
			}
			if (#HA == null || #HA.Key != Key.Delete)
			{
				goto IL_161;
			}
			List<GridLineDefinitionModel> list = new List<GridLineDefinitionModel>();
			List<GridLineDefinitionModel> list2;
			if (6 != 0)
			{
				list2 = list;
			}
			if (this.SelectedGridLineDefinition != null)
			{
				IList<GridLineDefinitionModel> #7p = list2;
				GridLineDefinitionModel[] #8f = new GridLineDefinitionModel[]
				{
					this.SelectedGridLineDefinition
				};
				if (!false)
				{
					#7p.#pR(#8f);
				}
			}
			List<GridLineDefinitionModel> list3 = list2;
			IEnumerable<GridLineDefinitionModel> collection = base.SelectedObjects.OfType<GridLineDefinitionModel>();
			if (!false)
			{
				list3.AddRange(collection);
			}
			flag2 = list2.Any<GridLineDefinitionModel>();
			IL_6D:
			if (!flag2)
			{
				return;
			}
			try
			{
				if (-1 != 0)
				{
					bool isWorking = true;
					if (8 != 0)
					{
						base.IsWorking = isWorking;
					}
					#bDc #bDc = base.UndoManager;
					if (!false)
					{
						#bDc.#uCc();
					}
					List<GridLineDefinitionModel> list4 = list2;
					Action<GridLineDefinitionModel> action = new Action<GridLineDefinitionModel>(base.ProjectContext.MainModel.#1Vc);
					if (!false)
					{
						list4.ForEach(action);
					}
					base.ModelEditorViewModel.#FZc(base.ProjectContext.MainModel.GridLines, false);
				}
				base.ToolContext.SnappingPointsUpdater.#NIc(base.SnappingProvider, base.ProjectContext.MainModel.GridLines);
				this.#zIc();
				return;
			}
			catch (ModelValidationException #PIc)
			{
				base.#OIc(#PIc);
				return;
			}
			catch (Exception #ob)
			{
				base.UndoManager.#yCc(false);
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107414700), base.ToolInfo);
				return;
			}
			finally
			{
				base.UndoManager.#vCc();
				this.#1kb();
				this.#iLc();
				do
				{
					base.IsWorking = false;
				}
				while (false);
			}
			IL_161:
			flag3 = (flag2 = base.IsInExtendedSelectionMode);
			IL_167:
			if (false)
			{
				goto IL_6D;
			}
			if (flag3)
			{
				while (this.SelectedGridLineDefinition != null)
				{
					if (!false)
					{
						base.#jLc(this.SelectedGridLineDefinition, false);
						break;
					}
				}
			}
			base.#2kb(#HA);
		}

		// Token: 0x060061A8 RID: 25000 RVA: 0x0017DBE4 File Offset: 0x0017BDE4
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			if (#4kb == null || !base.ModelEditorViewModel.AreGridLinesVisible)
			{
				return;
			}
			bool flag = base.IsInExtendedSelectionMode;
			while (!flag)
			{
				if (8 != 0)
				{
					this.#iLc();
				}
				Point3D? point3D = base.#HIc(#4kb);
				Point3D? point3D2;
				if (8 != 0)
				{
					point3D2 = point3D;
				}
				bool flag2 = flag = (point3D2 != null);
				if (!false)
				{
					if (!flag2)
					{
						if (5 != 0)
						{
							this.#1kb();
						}
						return;
					}
					#fuc #fuc = base.SnappingProvider.#wqc(point3D2.Value, base.SnappingProvider.MaxDistance);
					#fuc #fuc2;
					if (!false)
					{
						#fuc2 = #fuc;
					}
					if (#fuc2 == null)
					{
						this.#1kb();
						base.#3kb(#4kb);
						return;
					}
					GridLineDefinitionModel gridLineDefinitionModel = base.ProjectContext.MainModel.#3Vc(#fuc2.Segment);
					if (gridLineDefinitionModel == null || gridLineDefinitionModel.GridLineData == null)
					{
						this.#1kb();
						base.#3kb(#4kb);
						return;
					}
					this.#i = point3D2;
					this.#jKc(gridLineDefinitionModel, point3D2.Value);
					return;
				}
			}
			if (!false)
			{
				this.#hKc();
			}
			if (6 != 0)
			{
				base.#3kb(#4kb);
			}
		}

		// Token: 0x060061A9 RID: 25001 RVA: 0x0017DCF8 File Offset: 0x0017BEF8
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			if (base.ModelEditorViewModel.AreGridLinesVisible)
			{
				#ewc #ewc = null;
				#ewc #ewc2;
				if (3 != 0)
				{
					#ewc2 = #ewc;
				}
				#AKc.#o9c #o9c = this.CurrentToolState;
				#AKc.#o9c #o9c2;
				if (2 != 0)
				{
					#o9c2 = #o9c;
				}
				if (#o9c2 != #AKc.#o9c.#b)
				{
					if (#o9c2 != #AKc.#o9c.#c)
					{
						goto IL_55;
					}
					if (false)
					{
						goto IL_95;
					}
					#ewc #ewc3 = this.#qKc(#HAb);
					if (6 == 0)
					{
						goto IL_55;
					}
					#ewc2 = #ewc3;
					goto IL_55;
				}
				else
				{
					#ewc #ewc4 = this.#sKc(#HAb);
					if (8 != 0)
					{
						#ewc2 = #ewc4;
					}
					PointsConverter.#vsc(#HAb);
				}
				IL_42:
				if (false)
				{
					return;
				}
				IL_55:
				if (#ewc2 != null)
				{
					#ewc #nKc = #ewc2;
					if (!false)
					{
						this.#mKc(#nKc);
					}
					if (!false)
					{
						if (8 != 0)
						{
							base.#fzb(#HAb, #gzb);
						}
						return;
					}
					goto IL_42;
				}
				else
				{
					this.#oKc(this.SelectedGridLineDefinition, (this.SelectedGridLineDefinition == null) ? null : this.SelectedGridLineDefinition.GridLineData);
					this.#DMc(#HAb);
				}
				IL_95:
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x060061AA RID: 25002 RVA: 0x0017DDC4 File Offset: 0x0017BFC4
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			bool flag = base.ModelEditorViewModel.AreGridLinesVisible;
			while (flag)
			{
				if (#4kb == null)
				{
					return;
				}
				bool flag2 = flag = base.IsInExtendedSelectionMode;
				while (!false)
				{
					if (flag2)
					{
						if (!false)
						{
							this.#hKc();
						}
						if (!false)
						{
							base.#5kb(#4kb);
						}
						return;
					}
					Point3D? point3D = base.#HIc(#4kb);
					Point3D? point3D2;
					if (!false)
					{
						point3D2 = point3D;
					}
					bool flag3 = flag = (flag2 = (point3D2 != null));
					if (!false)
					{
						#Atc #Atc2;
						if (!flag3)
						{
							if (!false)
							{
								return;
							}
						}
						else
						{
							if (false)
							{
								goto IL_77;
							}
							#Atc #Atc = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D2.Value);
							if (!false)
							{
								#Atc2 = #Atc;
							}
							if (#Atc2 == null)
							{
								return;
							}
						}
						Point3D point3D3 = #Atc2.Point;
						Point3D point3D4;
						if (4 != 0)
						{
							point3D4 = point3D3;
						}
						IL_77:
						Point3D #HAb = point3D4;
						bool #gzb = false;
						if (!false)
						{
							this.#fzb(#HAb, #gzb);
						}
						return;
					}
				}
			}
		}

		// Token: 0x060061AB RID: 25003 RVA: 0x0017DE78 File Offset: 0x0017C078
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			bool flag2;
			bool flag = flag2 = base.ModelEditorViewModel.AreGridLinesVisible;
			if (!false)
			{
				if (!flag)
				{
					return;
				}
				flag2 = base.IsSelectionRectangleDrawn;
			}
			#fuc #fuc;
			if (!flag2)
			{
				#fuc = base.SnappingProvider.#wqc(#Kzb, base.SnappingProvider.MaxDistance);
				goto IL_33;
			}
			IL_32:
			#fuc = null;
			IL_33:
			#fuc #fuc2;
			if (!false)
			{
				#fuc2 = #fuc;
			}
			SegmentData segmentData = (#fuc2 == null) ? null : #fuc2.Segment;
			SegmentData segmentData2;
			if (!false)
			{
				segmentData2 = segmentData;
			}
			GridLineDefinitionModel gridLineDefinitionModel2;
			if (5 != 0)
			{
				GridLineDefinitionModel gridLineDefinitionModel;
				if (segmentData2 != null)
				{
					if (false)
					{
						goto IL_32;
					}
					gridLineDefinitionModel = base.ProjectContext.MainModel.#3Vc(segmentData2);
				}
				else
				{
					gridLineDefinitionModel = null;
				}
				if (!false)
				{
					gridLineDefinitionModel2 = gridLineDefinitionModel;
				}
				#AKc.#o9c #o9c = this.CurrentToolState;
				#AKc.#o9c #o9c2;
				if (!false)
				{
					#o9c2 = #o9c;
				}
				switch (#o9c2)
				{
				case #AKc.#o9c.#a:
				{
					GridLineDefinitionModel #pKc = gridLineDefinitionModel2;
					SegmentData #PP = segmentData2;
					bool #yKc = true;
					if (7 != 0)
					{
						this.#xKc(#pKc, #PP, #yKc);
					}
					break;
				}
				case #AKc.#o9c.#b:
					this.#zKc(null, this.#sKc(#Kzb), false);
					this.#lKc(this.SelectedGridLineDefinition);
					goto IL_CF;
				case #AKc.#o9c.#c:
					goto IL_CF;
				default:
					goto IL_CF;
				}
			}
			IL_9D:
			GridLineDefinitionModel #bsc = gridLineDefinitionModel2;
			if (!false)
			{
				this.#lKc(#bsc);
			}
			if (segmentData2 == null)
			{
				base.#HEc(#IEc, #Kzb);
			}
			IL_CF:
			if (this.CurrentToolState != #AKc.#o9c.#a)
			{
				if (6 == 0)
				{
					goto IL_9D;
				}
				base.SnapPointsMarker.Mark(base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, #Kzb));
			}
		}

		// Token: 0x060061AC RID: 25004 RVA: 0x00009E6A File Offset: 0x0000806A
		private static void #QEc(object #Ge, EventArgs #He)
		{
		}

		// Token: 0x060061AD RID: 25005 RVA: 0x0017DFB0 File Offset: 0x0017C1B0
		private void #hKc()
		{
			for (;;)
			{
				GridLineDefinitionModel gridLineDefinitionModel2;
				if (!false)
				{
					GridLineDefinitionModel gridLineDefinitionModel = this.SelectedGridLineDefinition;
					if (!false)
					{
						gridLineDefinitionModel2 = gridLineDefinitionModel;
					}
				}
				for (;;)
				{
					if (!false)
					{
						this.#iKc();
					}
					if (false)
					{
						break;
					}
					if (gridLineDefinitionModel2 != null)
					{
						object #Rf = gridLineDefinitionModel2;
						if (!false)
						{
							base.#tMc(#Rf);
						}
					}
					if (!false)
					{
						return;
					}
				}
			}
		}

		// Token: 0x060061AE RID: 25006 RVA: 0x0017DFF0 File Offset: 0x0017C1F0
		private void #iKc()
		{
			#AKc.#o9c #o9c = #AKc.#o9c.#a;
			if (4 != 0)
			{
				this.CurrentToolState = #o9c;
			}
			if (!false)
			{
				this.#uKc();
			}
			List<Point> list = this.#b;
			if (!false)
			{
				list.Clear();
			}
			GridLineDefinitionModel gridLineDefinitionModel = null;
			if (!false)
			{
				this.SelectedGridLineDefinition = gridLineDefinitionModel;
			}
			this.#i = null;
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = null;
			if (8 != 0)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			Cursor arrow = System.Windows.Input.Cursors.Arrow;
			bool forceCursor = false;
			if (!false)
			{
				modelEditorControl.SetCursor(arrow, forceCursor);
			}
		}

		// Token: 0x060061AF RID: 25007 RVA: 0x0017E070 File Offset: 0x0017C270
		private void #jKc(GridLineDefinitionModel #bsc, Point3D #kKc)
		{
			if (this.CurrentToolState == #AKc.#o9c.#a || this.CurrentToolState == #AKc.#o9c.#b)
			{
				#AKc.#o9c #o9c = #AKc.#o9c.#b;
				if (true)
				{
					this.CurrentToolState = #o9c;
				}
				if (!false)
				{
					this.SelectedGridLineDefinition = #bsc;
				}
				if (this.CurrentToolState == #AKc.#o9c.#b)
				{
					GridLineDefinitionModel #pKc = this.SelectedGridLineDefinition;
					#ewc #gwc = this.SelectedGridLineDefinition.GridLineData;
					bool #yKc = false;
					if (3 != 0)
					{
						this.#zKc(#pKc, #gwc, #yKc);
					}
				}
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				Cursor arrow = System.Windows.Input.Cursors.Arrow;
				bool forceCursor = false;
				if (8 != 0)
				{
					modelEditorControl.SetCursor(arrow, forceCursor);
				}
				bool isWorking = this.SelectedGridLineDefinition != null;
				if (4 != 0)
				{
					base.IsWorking = isWorking;
				}
				return;
			}
			if (this.CurrentToolState == #AKc.#o9c.#c)
			{
				Point3D? point3D = base.SnappingProvider.#bNb(this.#b, #kKc, base.SnappingProvider.MaxDistance);
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				if (point3D2 == null && #bsc != this.SelectedGridLineDefinition)
				{
					this.SelectedGridLineDefinition = #bsc;
					this.CurrentToolState = #AKc.#o9c.#b;
					this.#uKc();
					this.#zKc(this.SelectedGridLineDefinition, this.SelectedGridLineDefinition.GridLineData, false);
					return;
				}
				if (point3D2 == null)
				{
					this.#1kb();
					return;
				}
				PointsConverter.#vsc(point3D2.Value);
				this.CurrentToolState = #AKc.#o9c.#c;
				this.#lKc(null);
				base.IsWorking = (this.SelectedGridLineDefinition != null);
			}
		}

		// Token: 0x060061B0 RID: 25008 RVA: 0x0017E1D4 File Offset: 0x0017C3D4
		private void #lKc(GridLineDefinitionModel #bsc)
		{
			if (#bsc == null)
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				Cursor arrow = System.Windows.Input.Cursors.Arrow;
				bool forceCursor = false;
				if (!false)
				{
					modelEditorControl.SetCursor(arrow, forceCursor);
				}
				return;
			}
			if (!base.ModelEditorControl.IsCameraInDefault2DPosition())
			{
				IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
				Cursor cursor = this.#f;
				bool forceCursor2 = false;
				if (4 != 0)
				{
					modelEditorControl2.SetCursor(cursor, forceCursor2);
				}
				return;
			}
			if (#bsc.GridLineData.IsRightAngle)
			{
				IModelEditorControl modelEditorControl3 = base.ModelEditorControl;
				Cursor cursor2 = this.#g;
				bool forceCursor3 = false;
				if (!false)
				{
					modelEditorControl3.SetCursor(cursor2, forceCursor3);
				}
				return;
			}
			if (#bsc.GridLineData.IsZeroAngle)
			{
				IModelEditorControl modelEditorControl4 = base.ModelEditorControl;
				Cursor cursor3 = this.#h;
				bool forceCursor4 = false;
				if (!false)
				{
					modelEditorControl4.SetCursor(cursor3, forceCursor4);
				}
				return;
			}
			IModelEditorControl modelEditorControl5 = base.ModelEditorControl;
			Cursor cursor4 = this.#f;
			bool forceCursor5 = false;
			if (!false)
			{
				modelEditorControl5.SetCursor(cursor4, forceCursor5);
			}
		}

		// Token: 0x060061B1 RID: 25009 RVA: 0x0017E294 File Offset: 0x0017C494
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catch for unexpected exceptions.")]
		private void #mKc(#ewc #nKc)
		{
			if (#nKc == null)
			{
				if (5 != 0)
				{
					this.#1kb();
				}
				return;
			}
			try
			{
				#bDc #bDc = base.UndoManager;
				if (!false)
				{
					#bDc.#uCc();
				}
				GridLineDefinitionModel gridLineDefinitionModel = base.ProjectContext.MainModel.#3Vc(#nKc.LineSegment);
				GridLineDefinitionModel gridLineDefinitionModel2;
				if (!false)
				{
					gridLineDefinitionModel2 = gridLineDefinitionModel;
				}
				GridLineDefinitionModel gridLineDefinitionModel4;
				if (gridLineDefinitionModel2 != null && gridLineDefinitionModel2 != this.SelectedGridLineDefinition)
				{
					#ewc #ewc = gridLineDefinitionModel2.GridLineData;
					if (!false)
					{
						#nKc = #ewc;
					}
					#WWc #WWc = base.ProjectContext.MainModel;
					GridLineDefinitionModel #bsc = this.SelectedGridLineDefinition;
					if (3 != 0)
					{
						#WWc.#1Vc(#bsc);
					}
					GridLineDefinitionModel gridLineDefinitionModel3 = null;
					if (6 != 0)
					{
						gridLineDefinitionModel4 = gridLineDefinitionModel3;
					}
				}
				else
				{
					GridLineDefinitionModel gridLineDefinitionModel5 = new GridLineDefinitionModel(#nKc, this.SelectedGridLineDefinition.Label);
					base.ProjectContext.MainModel.#5Vc(gridLineDefinitionModel5, this.SelectedGridLineDefinition);
					this.SelectedGridLineDefinition = gridLineDefinitionModel5;
					gridLineDefinitionModel4 = gridLineDefinitionModel5;
				}
				base.ModelEditorViewModel.#FZc(base.ProjectContext.MainModel.GridLines, false);
				this.#oKc(gridLineDefinitionModel4, #nKc);
				if (gridLineDefinitionModel4 != null)
				{
					Point3D? #NJc = base.ModelEditorViewModel.#MZc(gridLineDefinitionModel4);
					this.#vKc(gridLineDefinitionModel4, #NJc, true);
				}
				else
				{
					base.ModelEditorControl.RemoveFromView(this.#a);
					base.ModelEditorControl.RemoveFromView(this.#d);
				}
				if (this.SelectedGridLineDefinition != null)
				{
					this.SelectedGridLineDefinition = gridLineDefinitionModel4;
				}
				base.ToolContext.SnappingPointsUpdater.#NIc(base.SnappingProvider, base.ProjectContext.MainModel.GridLines);
				this.#zIc();
			}
			catch (ModelValidationException #PIc)
			{
				base.#OIc(#PIc);
			}
			catch (Exception #ob)
			{
				base.UndoManager.#yCc(false);
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107414679), base.ToolInfo);
			}
			finally
			{
				base.UndoManager.#vCc();
				base.ModelEditorControl.SetCursor(System.Windows.Input.Cursors.Arrow, false);
				base.SnapPointsMarker.Mark(null);
				base.IsWorking = false;
			}
		}

		// Token: 0x060061B2 RID: 25010 RVA: 0x0017E4D0 File Offset: 0x0017C6D0
		private void #oKc(GridLineDefinitionModel #pKc, #ewc #bsc)
		{
			if (this.CurrentToolState == #AKc.#o9c.#b)
			{
				#AKc.#o9c #o9c = #AKc.#o9c.#a;
				if (-1 != 0)
				{
					this.CurrentToolState = #o9c;
				}
				GridLineDefinitionModel gridLineDefinitionModel = null;
				if (7 != 0)
				{
					this.SelectedGridLineDefinition = gridLineDefinitionModel;
				}
			}
			if (this.CurrentToolState == #AKc.#o9c.#b && !false)
			{
				bool #yKc = false;
				if (!false)
				{
					this.#zKc(#pKc, #bsc, #yKc);
				}
			}
		}

		// Token: 0x060061B3 RID: 25011 RVA: 0x0017E520 File Offset: 0x0017C720
		private #ewc #qKc(Point3D #rKc)
		{
			Point point = PointsConverter.#vsc(#rKc);
			Point point2;
			if (2 != 0)
			{
				point2 = point;
			}
			Point? point4;
			for (;;)
			{
				IL_0A:
				Point? point3 = #jsc.#gsc(this.SelectedGridLineDefinition.GridLineData.LineSegment, point2);
				if (8 != 0)
				{
					point4 = point3;
				}
				while (point4 != null)
				{
					double num = GeometryHelper.#lcb(point2, point4.Value);
					double num3;
					double num2 = num3 = base.SnappingProvider.MaxDistance;
					if (4 != 0)
					{
						num3 = num2 * 2.0;
					}
					if (num <= num3)
					{
						goto IL_5E;
					}
					if (8 != 0)
					{
						if (!false)
						{
							goto Block_5;
						}
						goto IL_0A;
					}
				}
				break;
			}
			return null;
			Block_5:
			return null;
			IL_5E:
			return new #ewc(point4.Value, this.SelectedGridLineDefinition.Angle, this.SelectedGridLineDefinition.GridLineData.EditorWorkspaceSize);
		}

		// Token: 0x060061B4 RID: 25012 RVA: 0x0017E5BC File Offset: 0x0017C7BC
		private #ewc #sKc(Point3D #tKc)
		{
			Point3D? point3D = base.ToolOperationsHelper.#aEc(#tKc);
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			if (point3D2 != null)
			{
				Point3D value = point3D2.Value;
				if (8 != 0)
				{
					#tKc = value;
				}
				if (!false)
				{
					return new #ewc(PointsConverter.#vsc(#tKc), this.SelectedGridLineDefinition.Angle, this.SelectedGridLineDefinition.GridLineData.EditorWorkspaceSize);
				}
			}
			return null;
		}

		// Token: 0x060061B5 RID: 25013 RVA: 0x0017E620 File Offset: 0x0017C820
		private void #uKc()
		{
			do
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#c;
				if (!false)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
				IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
				IDrawingResult drawingResult2 = this.#a;
				if (4 != 0)
				{
					modelEditorControl2.RemoveFromView(drawingResult2);
				}
				do
				{
					if (!false)
					{
						IModelEditorControl modelEditorControl3 = base.ModelEditorControl;
						IDrawingResult drawingResult3 = this.#d;
						if (!false)
						{
							modelEditorControl3.RemoveFromView(drawingResult3);
						}
					}
				}
				while (false);
			}
			while (false);
		}

		// Token: 0x060061B6 RID: 25014 RVA: 0x0017E680 File Offset: 0x0017C880
		private void #vKc(GridLineDefinitionModel #pKc, Point3D? #NJc, bool #wKc)
		{
			if (base.IsInExtendedSelectionMode)
			{
				return;
			}
			GridLineDefinitionModel gridLineDefinitionModel = this.#e;
			GridLineDefinitionModel gridLineDefinitionModel2;
			if (-1 != 0)
			{
				gridLineDefinitionModel2 = gridLineDefinitionModel;
			}
			if (#wKc || #pKc != gridLineDefinitionModel2)
			{
				if (#pKc != null && #NJc != null)
				{
					IAnnotationDrawingResult annotationDrawingResult = this.#d;
					string text = #pKc.Label;
					if (!false)
					{
						annotationDrawingResult.Text = text;
					}
					IModelEditorControl modelEditorControl = base.ModelEditorControl;
					IDrawingResult drawingResult = this.#d;
					if (4 != 0)
					{
						modelEditorControl.AddToView(drawingResult);
					}
					IAnnotationDrawingResult annotationDrawingResult2 = this.#d;
					Point3D position = PointsConverter.#Csc(#NJc.Value, 0.09);
					if (!false)
					{
						annotationDrawingResult2.Position = position;
					}
					IAnnotationDrawingResult annotationDrawingResult3 = this.#d;
					double annotationRadius = base.ModelEditorViewModel.AnnotationsRadius;
					if (!false)
					{
						annotationDrawingResult3.SetAnnotationRadius(annotationRadius);
					}
				}
				this.#e = #pKc;
			}
		}

		// Token: 0x060061B7 RID: 25015 RVA: 0x0017E734 File Offset: 0x0017C934
		private void #xKc(GridLineDefinitionModel #pKc, SegmentData #PP, bool #yKc)
		{
			Tuple<Point3D, Point3D> tuple = null;
			Tuple<Point3D, Point3D> tuple2;
			if (6 != 0)
			{
				tuple2 = tuple;
			}
			Point3D? #NJc = null;
			if (#pKc != null)
			{
				Point3D? point3D = base.ModelEditorViewModel.#MZc(#pKc);
				if (3 != 0)
				{
					#NJc = point3D;
				}
				if (#NJc != null)
				{
					double num = AnnotationsHelper.#SJc(#pKc);
					double #OJc;
					if (!false)
					{
						#OJc = num;
					}
					Tuple<Point3D, Point3D> tuple3 = AnnotationsHelper.#MJc(#pKc, PointsConverter.#vsc(#NJc.Value), #OJc, base.ModelEditorViewModel.AnnotationsRadius);
					if (5 != 0)
					{
						tuple2 = tuple3;
					}
				}
			}
			if (#PP != null)
			{
				List<Point3D> list = new List<Point3D>();
				list.Add(PointsConverter.#vsc(#PP.StartPoint, 0.032));
				Point3D item = PointsConverter.#vsc(#PP.EndPoint, 0.032);
				if (!false)
				{
					list.Add(item);
				}
				List<Point3D> list2;
				if (2 != 0)
				{
					list2 = list;
				}
				if (tuple2 != null)
				{
					list2.#pR(new Point3D[]
					{
						PointsConverter.#Csc(tuple2.Item1, 0.09),
						PointsConverter.#Csc(tuple2.Item2, 0.09)
					});
				}
				this.#a.Positions = list2;
				if (#yKc)
				{
					this.#a.LineColor = base.SettingsProvider.VisualizationSelectedGridLineColor;
					this.#a.LineThickness = base.SettingsProvider.VisualizationSelectedGridLineThickness;
				}
				else
				{
					this.#a.LineColor = base.SettingsProvider.VisualizationHighlightedGridLineColor;
					this.#a.LineThickness = base.SettingsProvider.VisualizationHighlightedGridLineThickness;
				}
				base.ModelEditorControl.AddToView(this.#a);
				if (!false)
				{
					goto IL_190;
				}
			}
			base.ModelEditorControl.RemoveFromView(this.#a);
			base.ModelEditorControl.RemoveFromView(this.#d);
			IL_190:
			this.#vKc(#pKc, #NJc, false);
		}

		// Token: 0x060061B8 RID: 25016 RVA: 0x0004FF37 File Offset: 0x0004E137
		private void #zKc(GridLineDefinitionModel #pKc, #ewc #gwc, bool #yKc)
		{
			SegmentData #PP = #gwc.LineSegment;
			if (7 != 0)
			{
				this.#xKc(#pKc, #PP, #yKc);
			}
		}

		// Token: 0x060061B9 RID: 25017 RVA: 0x0004FF50 File Offset: 0x0004E150
		protected void #1(bool #POb)
		{
			for (;;)
			{
				if (!false)
				{
					goto IL_05;
				}
				IL_0F:
				Cursor cursor = this.#g;
				if (!false)
				{
					cursor.Dispose();
				}
				if (7 == 0)
				{
					continue;
				}
				Cursor cursor2 = this.#h;
				if (-1 != 0)
				{
					cursor2.Dispose();
				}
				if (!false)
				{
					break;
				}
				IL_05:
				Cursor cursor3 = this.#f;
				if (false)
				{
					goto IL_0F;
				}
				cursor3.Dispose();
				goto IL_0F;
			}
		}

		// Token: 0x060061BA RID: 25018 RVA: 0x0004FF90 File Offset: 0x0004E190
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

		// Token: 0x04002818 RID: 10264
		private readonly IMultilineDrawingResult #a;

		// Token: 0x04002819 RID: 10265
		private readonly List<Point> #b = new List<Point>();

		// Token: 0x0400281A RID: 10266
		private readonly IPointsDrawingResult #c;

		// Token: 0x0400281B RID: 10267
		private readonly IAnnotationDrawingResult #d;

		// Token: 0x0400281C RID: 10268
		private GridLineDefinitionModel #e;

		// Token: 0x0400281D RID: 10269
		private readonly Cursor #f;

		// Token: 0x0400281E RID: 10270
		private readonly Cursor #g;

		// Token: 0x0400281F RID: 10271
		private readonly Cursor #h;

		// Token: 0x04002820 RID: 10272
		private Point3D? #i;

		// Token: 0x04002821 RID: 10273
		[CompilerGenerated]
		private #AKc.#o9c #j;

		// Token: 0x04002822 RID: 10274
		[CompilerGenerated]
		private GridLineDefinitionModel #k;

		// Token: 0x02000BA0 RID: 2976
		private enum #o9c
		{
			// Token: 0x04002824 RID: 10276
			#a,
			// Token: 0x04002825 RID: 10277
			#b,
			// Token: 0x04002826 RID: 10278
			#c
		}

		// Token: 0x02000BA1 RID: 2977
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04002827 RID: 10279
			public static EventHandler #a;
		}
	}
}
