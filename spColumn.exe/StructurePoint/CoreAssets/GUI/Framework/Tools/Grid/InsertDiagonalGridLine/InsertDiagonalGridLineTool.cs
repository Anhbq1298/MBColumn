using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using #4vc;
using #7hc;
using #7Tc;
using #bJc;
using #EWc;
using #Fmc;
using #IDc;
using #NWc;
using #OKc;
using #T0c;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework.Model;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Grid.InsertDiagonalGridLine
{
	// Token: 0x02000BB4 RID: 2996
	public sealed class InsertDiagonalGridLineTool : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #NKc
	{
		// Token: 0x0600623F RID: 25151 RVA: 0x0018077C File Offset: 0x0017E97C
		public InsertDiagonalGridLineTool(#6Ic toolContext) : base(toolContext)
		{
			#X0d.#V0d(toolContext, #Phc.#3hc(107415858), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107414894));
			base.Header = Strings.StringInsertDiagonalGridLine;
			base.IconImage = toolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.InsertDiagonalGridLine);
			this.#a = toolContext.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#b = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			this.#e = new Dictionary<InsertDiagonalGridLineTool.#t9c, string>();
			this.#e.Add(InsertDiagonalGridLineTool.#t9c.#a, Strings.StringSelectStartPoint);
			this.#e.Add(InsertDiagonalGridLineTool.#t9c.#b, Strings.StringSelectEndPoint);
			base.HelpId = HelpIdentifiers.ToolInsertDiagonalGridLine;
		}

		// Token: 0x06006240 RID: 25152 RVA: 0x00180834 File Offset: 0x0017EA34
		public override void #5b()
		{
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[2];
			array[0] = ModelEditorControlEventType.MouseLeftButtonUp;
			if (!false)
			{
				base.#FIc(array);
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#a;
			Color lineColor = base.SettingsProvider.VisualizationNewGridLineColor;
			if (-1 != 0)
			{
				linesDrawingResultBase.LineColor = lineColor;
			}
			ILinesDrawingResultBase linesDrawingResultBase2 = this.#a;
			double lineThickness = base.SettingsProvider.VisualizationNewGridLineThickness;
			if (!false)
			{
				linesDrawingResultBase2.LineThickness = lineThickness;
			}
			ISnapPointsMarker #IJc = base.SnapPointsMarker;
			#6Gc #JAc = base.SettingsProvider;
			if (!false)
			{
				#8Ib.#HJc(#IJc, #JAc);
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			Cursor cursor = this.#b;
			bool forceCursor = false;
			if (6 != 0)
			{
				modelEditorControl.SetCursor(cursor, forceCursor);
			}
			this.#c = InsertDiagonalGridLineTool.#t9c.#a;
			if (!false)
			{
				base.#5b();
			}
		}

		// Token: 0x06006241 RID: 25153 RVA: 0x001808D8 File Offset: 0x0017EAD8
		public override void #0kb()
		{
			if (8 != 0)
			{
				this.#1kb();
			}
			ModelEditorControlEventType[] #MEc = null;
			if (!false)
			{
				base.#LEc(#MEc);
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			Cursor arrow = System.Windows.Input.Cursors.Arrow;
			bool forceCursor = false;
			if (!false)
			{
				modelEditorControl.SetCursor(arrow, forceCursor);
			}
			if (!false)
			{
				base.#0kb();
			}
		}

		// Token: 0x06006242 RID: 25154 RVA: 0x00180924 File Offset: 0x0017EB24
		public override void #1kb()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#a;
			if (2 != 0)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = null;
			if (!false)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			this.#d = null;
			this.#c = InsertDiagonalGridLineTool.#t9c.#a;
			if (8 != 0)
			{
				base.#1kb();
			}
		}

		// Token: 0x06006243 RID: 25155 RVA: 0x0018097C File Offset: 0x0017EB7C
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			if (this.#c == InsertDiagonalGridLineTool.#t9c.#a)
			{
				this.#d = new Point3D?(#HAb);
				this.#c = InsertDiagonalGridLineTool.#t9c.#b;
			}
			else if (this.#c == InsertDiagonalGridLineTool.#t9c.#b && this.#d != null)
			{
				Point3D value = this.#d.Value;
				if (!false)
				{
					this.#QKc(value, #HAb);
				}
			}
			if (-1 != 0)
			{
				base.#fzb(#HAb, #gzb);
			}
			if (#gzb)
			{
				#jUc #jUc = base.PreciseInputProvider;
				PreciseInputParameters initializeInputParameters = this.#PKc();
				if (!false)
				{
					#jUc.Update(initializeInputParameters);
				}
			}
		}

		// Token: 0x06006244 RID: 25156 RVA: 0x00180A04 File Offset: 0x0017EC04
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			if (!false)
			{
				if (!false && !false)
				{
					base.#5kb(#4kb);
				}
				Point3D? #SKc;
				if (7 != 0)
				{
					Point3D? point3D = base.#HIc(#4kb);
					if (3 != 0)
					{
						#SKc = point3D;
					}
					Point3D? point3D2 = this.#RKc(#SKc);
					if (-1 != 0)
					{
						#SKc = point3D2;
					}
					if (#SKc == null)
					{
						return;
					}
				}
				Point3D value = #SKc.Value;
				bool #gzb = false;
				if (6 != 0)
				{
					this.#fzb(value, #gzb);
				}
			}
		}

		// Token: 0x06006245 RID: 25157 RVA: 0x00180A64 File Offset: 0x0017EC64
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			if (!false)
			{
				base.#HEc(#IEc, #Kzb);
			}
			Point3D? point3D = this.#RKc(new Point3D?(#Kzb));
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			if (point3D2 != null)
			{
				Point3D value = point3D2.Value;
				if (4 != 0)
				{
					this.#EKc(value);
				}
			}
		}

		// Token: 0x06006246 RID: 25158 RVA: 0x00180AB4 File Offset: 0x0017ECB4
		protected override void #fIc(PreciseInputChangedEventArgs #gIc)
		{
			if (!true || (!false && #gIc != null))
			{
				Point3D point3D = PointsConverter.#vsc(#gIc.Point);
				Point3D point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				Point3D #HAb = point3D2;
				if (!false)
				{
					this.#EKc(#HAb);
				}
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x06006247 RID: 25159 RVA: 0x00050471 File Offset: 0x0004E671
		protected override void #GIc()
		{
			#jUc #jUc = base.PreciseInputProvider;
			PreciseInputParameters initializeInputParameters = this.#PKc();
			if (!false)
			{
				#jUc.Show(initializeInputParameters);
			}
		}

		// Token: 0x06006248 RID: 25160 RVA: 0x0017FCD4 File Offset: 0x0017DED4
		protected override void #iIc(PreciseInputCompletedEventArgs #jIc)
		{
			while (#jIc != null)
			{
				Point3D point3D = PointsConverter.#vsc(#jIc.Point);
				Point3D point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				if (!false)
				{
					Point3D #HAb = point3D2;
					bool #gzb = true;
					if (4 != 0)
					{
						this.#fzb(#HAb, #gzb);
					}
					if (!false)
					{
						return;
					}
					break;
				}
			}
		}

		// Token: 0x06006249 RID: 25161 RVA: 0x00180AF0 File Offset: 0x0017ECF0
		private PreciseInputParameters #PKc()
		{
			#WWc #WWc = base.ProjectContext.MainModel;
			#WWc #WWc2;
			if (6 != 0)
			{
				#WWc2 = #WWc;
			}
			#GJc #GJc = new #GJc();
			#GJc.WorkspaceSize = #WWc2.WorkspaceBoundingBoxData;
			#GJc.OwnerControl = base.ModelEditorViewModel.View.ParentControl;
			#GJc.CoordinateValidator = null;
			#GJc.VisualCoordinate = this.#KIc();
			#GJc.ResetCurrentValues = true;
			#GJc.Message = this.#e[this.#c];
			#oW #f = base.ProjectContext;
			if (!false)
			{
				#GJc.ProjectContext = #f;
			}
			return #aJc.#7Ic(#GJc);
		}

		// Token: 0x0600624A RID: 25162 RVA: 0x00180B80 File Offset: 0x0017ED80
		private void #EKc(Point3D #HAb)
		{
			Point3D? point3D = this.#d;
			Point3D? point3D2;
			if (6 != 0)
			{
				point3D2 = point3D;
			}
			if (this.#c == InsertDiagonalGridLineTool.#t9c.#b && point3D2 != null)
			{
				List<Point3D> list = PointsConverter.#Csc(new Point3D[]
				{
					point3D2.Value,
					#HAb
				}, 0.032);
				List<Point3D> list2;
				if (!false)
				{
					list2 = list;
				}
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#a;
				if (!false)
				{
					modelEditorControl.AddToView(drawingResult);
				}
				List<Point3D> list3 = PointsConverter.#Csc(list2, 0.064);
				if (true)
				{
					list2 = list3;
				}
				ILinesDrawingResultBase linesDrawingResultBase = this.#a;
				IEnumerable<Point3D> positions = list2;
				if (!false)
				{
					linesDrawingResultBase.Positions = positions;
				}
			}
		}

		// Token: 0x0600624B RID: 25163 RVA: 0x00180C24 File Offset: 0x0017EE24
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected exceptions catch.")]
		private void #QKc(Point3D #Suc, Point3D #Mzb)
		{
			Point point = PointsConverter.#vsc(#Suc);
			Point point2;
			if (8 != 0)
			{
				point2 = point;
			}
			Point point3 = PointsConverter.#vsc(#Mzb);
			Point #mcb;
			if (!false)
			{
				#mcb = point3;
			}
			#ewc #ewc = null;
			#ewc #ewc2;
			if (8 != 0)
			{
				#ewc2 = #ewc;
			}
			try
			{
				double num = GeometryHelper.#knc(#mcb.X, #mcb.Y, point2.X, point2.Y);
				double #Udb;
				if (6 != 0)
				{
					#Udb = num;
				}
				#ewc #ewc3 = new #ewc(Point.#G3d(point2, Vector.#53d(Point.#H3d(#mcb, point2), 2.0)), #Udb, base.ToolContext.ModelEditorControl.EditorWorkspaceBoundingBoxData);
				if (!false)
				{
					#ewc2 = #ewc3;
				}
			}
			catch (Exception #ob)
			{
				this.#1kb();
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107414873), base.ToolInfo);
			}
			if (#ewc2 == null)
			{
				return;
			}
			GridLineDefinitionModel gridLineDefinitionModel = new GridLineDefinitionModel(#ewc2);
			GridLineDefinitionModel gridLineDefinitionModel2;
			if (!false)
			{
				gridLineDefinitionModel2 = gridLineDefinitionModel;
			}
			if (base.ProjectContext.MainModel.#2Vc(gridLineDefinitionModel2))
			{
				return;
			}
			try
			{
				base.IsWorking = true;
				base.UndoManager.#uCc();
				string #f = GridLinesHelper.#qWc(base.StructuralModel.GridLines.Where(new Func<GridLineDefinitionModel, bool>(InsertDiagonalGridLineTool.<>c.<>9.#u9c)).Select(new Func<GridLineDefinitionModel, string>(InsertDiagonalGridLineTool.<>c.<>9.#v9c)).ToList<string>(), #HWc.#c);
				gridLineDefinitionModel2.Label = #f;
				base.ProjectContext.MainModel.#YVc(gridLineDefinitionModel2);
				this.#HKc(base.ProjectContext.MainModel.GridLines.ToList<GridLineDefinitionModel>());
				this.#zIc();
			}
			catch (ModelValidationException #PIc)
			{
				base.#OIc(#PIc);
			}
			catch (Exception #ob2)
			{
				base.UndoManager.#yCc(false);
				base.ToolContext.ErrorsHandlingService.#bzc(#ob2, #Phc.#3hc(107415032), base.ToolInfo);
			}
			finally
			{
				base.UndoManager.#vCc();
				this.#1kb();
				base.IsWorking = false;
			}
		}

		// Token: 0x0600624C RID: 25164 RVA: 0x0005034C File Offset: 0x0004E54C
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		private void #HKc(IList<GridLineDefinitionModel> #IKc)
		{
			#PWc #PWc = base.ToolContext.SnappingPointsUpdater;
			#Qrc #NDc = base.SnappingProvider;
			if (8 != 0)
			{
				#PWc.#NIc(#NDc, #IKc);
			}
			#V0c #V0c = base.ModelEditorViewModel;
			bool #GZc = false;
			if (!false)
			{
				#V0c.#FZc(#IKc, #GZc);
			}
		}

		// Token: 0x0600624D RID: 25165 RVA: 0x00180E58 File Offset: 0x0017F058
		private Point3D? #RKc(Point3D? #SKc)
		{
			Point3D? result;
			if (#SKc == null)
			{
				if (5 == 0)
				{
					return result;
				}
				result = null;
				if (!false)
				{
					if (!false)
					{
						return result;
					}
					goto IL_82;
				}
			}
			Point3D? point3D = base.ToolOperationsHelper.#aEc(#SKc.Value);
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			#Atc #Atc2;
			if (point3D2 == null)
			{
				result = null;
				if (5 != 0)
				{
					return result;
				}
			}
			else
			{
				#Atc #Atc = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D2.Value);
				if (!false)
				{
					#Atc2 = #Atc;
				}
				ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
				#Atc snapToPointResult = #Atc2;
				if (-1 != 0)
				{
					snapPointsMarker.Mark(snapToPointResult);
				}
				if (#Atc2 != null)
				{
					goto IL_82;
				}
			}
			result = null;
			return result;
			IL_82:
			return new Point3D?(#Atc2.Point);
		}

		// Token: 0x0600624E RID: 25166 RVA: 0x0005048B File Offset: 0x0004E68B
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#b;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x0600624F RID: 25167 RVA: 0x000504A0 File Offset: 0x0004E6A0
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

		// Token: 0x0400285D RID: 10333
		private readonly IMultilineDrawingResult #a;

		// Token: 0x0400285E RID: 10334
		private readonly Cursor #b;

		// Token: 0x0400285F RID: 10335
		private InsertDiagonalGridLineTool.#t9c #c;

		// Token: 0x04002860 RID: 10336
		private Point3D? #d;

		// Token: 0x04002861 RID: 10337
		private readonly Dictionary<InsertDiagonalGridLineTool.#t9c, string> #e;

		// Token: 0x02000BB5 RID: 2997
		private enum #t9c
		{
			// Token: 0x04002863 RID: 10339
			#a,
			// Token: 0x04002864 RID: 10340
			#b
		}
	}
}
