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
using #8Cc;
using #bJc;
using #CKc;
using #EWc;
using #Fmc;
using #IDc;
using #NWc;
using #T0c;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework.Model;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.GUI.SharedResources;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Grid.InsertVerticalGridLine
{
	// Token: 0x02000BAC RID: 2988
	[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Used by IoC.")]
	public sealed class InsertVerticalGridLineTool : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #BKc
	{
		// Token: 0x06006213 RID: 25107 RVA: 0x0017FA28 File Offset: 0x0017DC28
		public InsertVerticalGridLineTool(#6Ic toolContext, IResourcesHelper resourcesHelper) : base(toolContext)
		{
			#X0d.#V0d(resourcesHelper, #Phc.#3hc(107415318), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107414594));
			base.Header = Strings.StringInsertVerticalGridLine;
			base.IconImage = resourcesHelper.ImageFromResourceBitmap(ToolsIcons.InsertVerticalGridLine);
			this.#b = InsertVerticalGridLineTool.#p9c.#a;
			this.#a = base.ToolContext.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#c = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			base.HelpId = HelpIdentifiers.ToolInsertVerticalGridLine;
		}

		// Token: 0x06006214 RID: 25108 RVA: 0x0017FAB8 File Offset: 0x0017DCB8
		public override void #5b()
		{
			ILinesDrawingResultBase linesDrawingResultBase = this.#a;
			Color lineColor = base.SettingsProvider.VisualizationNewGridLineColor;
			if (!false)
			{
				linesDrawingResultBase.LineColor = lineColor;
			}
			ILinesDrawingResultBase linesDrawingResultBase2 = this.#a;
			double lineThickness = base.SettingsProvider.VisualizationNewGridLineThickness;
			if (!false)
			{
				linesDrawingResultBase2.LineThickness = lineThickness;
			}
			if (false)
			{
				goto IL_67;
			}
			ISnapPointsMarker #IJc = base.SnapPointsMarker;
			#6Gc #JAc = base.SettingsProvider;
			if (!false)
			{
				#8Ib.#HJc(#IJc, #JAc);
			}
			IL_40:
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			Cursor cursor = this.#c;
			bool forceCursor = false;
			if (!false)
			{
				modelEditorControl.SetCursor(cursor, forceCursor);
			}
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[3];
			array[0] = ModelEditorControlEventType.MouseLeftButtonDown;
			array[1] = ModelEditorControlEventType.MouseLeftButtonUp;
			if (2 != 0)
			{
				base.#FIc(array);
			}
			IL_67:
			if (2 != 0)
			{
				if (8 != 0)
				{
					base.#5b();
				}
				return;
			}
			goto IL_40;
		}

		// Token: 0x06006215 RID: 25109 RVA: 0x0017FB60 File Offset: 0x0017DD60
		public override void #0kb()
		{
			do
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#a;
				if (5 != 0)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
			}
			while (false);
			if (7 != 0)
			{
				this.#1kb();
			}
			do
			{
				ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
				#Atc snapToPointResult = null;
				if (!false)
				{
					snapPointsMarker.Mark(snapToPointResult);
				}
				IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
				Cursor arrow = System.Windows.Input.Cursors.Arrow;
				bool forceCursor = false;
				if (!false)
				{
					modelEditorControl2.SetCursor(arrow, forceCursor);
				}
			}
			while (3 == 0);
			if (!false)
			{
				ModelEditorControlEventType[] #MEc = null;
				if (!false)
				{
					base.#LEc(#MEc);
				}
				if (!false)
				{
					base.#0kb();
				}
			}
		}

		// Token: 0x06006216 RID: 25110 RVA: 0x000502EA File Offset: 0x0004E4EA
		public override void #1kb()
		{
			this.#b = InsertVerticalGridLineTool.#p9c.#a;
			if (!false)
			{
				base.#1kb();
			}
		}

		// Token: 0x06006217 RID: 25111 RVA: 0x000502FF File Offset: 0x0004E4FF
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			if (this.#b == InsertVerticalGridLineTool.#p9c.#a)
			{
				this.#b = InsertVerticalGridLineTool.#p9c.#b;
			}
		}

		// Token: 0x06006218 RID: 25112 RVA: 0x0017FBE0 File Offset: 0x0017DDE0
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			if (this.#b != InsertVerticalGridLineTool.#p9c.#b)
			{
				goto IL_36;
			}
			if (6 == 0)
			{
				return;
			}
			Point3D? point3D = base.#HIc(#4kb);
			Point3D? point3D2;
			if (3 != 0)
			{
				point3D2 = point3D;
			}
			IL_17:
			if (point3D2 != null)
			{
				Point3D value = point3D2.Value;
				bool #gzb = false;
				if (!false)
				{
					this.#fzb(value, #gzb);
				}
			}
			this.#b = InsertVerticalGridLineTool.#p9c.#a;
			IL_36:
			if (5 == 0)
			{
				goto IL_17;
			}
			if (true)
			{
				base.#5kb(#4kb);
			}
		}

		// Token: 0x06006219 RID: 25113 RVA: 0x0017FC40 File Offset: 0x0017DE40
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			if (2 != 0)
			{
				this.#EKc(#Kzb);
			}
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, #Kzb);
			if (!false)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			if (8 != 0)
			{
				base.#HEc(#IEc, #Kzb);
			}
		}

		// Token: 0x0600621A RID: 25114 RVA: 0x0017FC94 File Offset: 0x0017DE94
		protected override void #fIc(PreciseInputChangedEventArgs #gIc)
		{
			for (;;)
			{
				IL_00:
				Point3D? point3D = #aJc.#9Ic(#gIc);
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				while (point3D2 != null)
				{
					if (false)
					{
						goto IL_00;
					}
					Point3D value = point3D2.Value;
					if (4 != 0)
					{
						this.#EKc(value);
					}
					if (!false)
					{
						return;
					}
				}
				break;
			}
		}

		// Token: 0x0600621B RID: 25115 RVA: 0x00050310 File Offset: 0x0004E510
		protected override void #GIc()
		{
			#jUc #jUc = base.PreciseInputProvider;
			PreciseInputParameters initializeInputParameters = this.#DKc();
			if (!false)
			{
				#jUc.Show(initializeInputParameters);
			}
		}

		// Token: 0x0600621C RID: 25116 RVA: 0x0005032A File Offset: 0x0004E52A
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			if (4 != 0)
			{
				base.#fzb(#HAb, #gzb);
			}
			if (4 != 0)
			{
				this.#GKc(#HAb, #gzb);
			}
		}

		// Token: 0x0600621D RID: 25117 RVA: 0x0017FCD4 File Offset: 0x0017DED4
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

		// Token: 0x0600621E RID: 25118 RVA: 0x0017FD10 File Offset: 0x0017DF10
		private PreciseInputParameters #DKc()
		{
			#WWc #WWc = base.ProjectContext.MainModel;
			#WWc #WWc2;
			if (4 != 0)
			{
				#WWc2 = #WWc;
			}
			#GJc #GJc = new #GJc();
			#GJc.WorkspaceSize = #WWc2.WorkspaceBoundingBoxData;
			#GJc.OwnerControl = base.ModelEditorViewModel.View.ParentControl;
			#GJc.CoordinateValidator = null;
			#GJc.VisualCoordinate = this.#KIc();
			#GJc.EnableYCoordinate = false;
			#GJc.ResetCurrentValues = true;
			#GJc.IsPolarSystemEnabled = false;
			#GJc.Message = Strings.StringSelectXCoordinate;
			#oW #f = base.ProjectContext;
			if (!false)
			{
				#GJc.ProjectContext = #f;
			}
			return #aJc.#7Ic(#GJc);
		}

		// Token: 0x0600621F RID: 25119 RVA: 0x0017FDA4 File Offset: 0x0017DFA4
		private void #EKc(Point3D #Kzb)
		{
			BoundingBoxData editorWorkspaceBoundingBoxData = base.ModelEditorControl.EditorWorkspaceBoundingBoxData;
			BoundingBoxData boundingBoxData;
			if (!false)
			{
				boundingBoxData = editorWorkspaceBoundingBoxData;
			}
			double num = this.#FKc(#Kzb);
			double x;
			if (4 != 0)
			{
				x = num;
			}
			List<Point3D> list = new List<Point3D>();
			list.Add(new Point3D(x, boundingBoxData.MinY, 0.032));
			Point3D item = new Point3D(x, boundingBoxData.MaxY, 0.032);
			if (7 != 0)
			{
				list.Add(item);
			}
			List<Point3D> list2;
			if (-1 != 0)
			{
				list2 = list;
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#a;
			IEnumerable<Point3D> positions = list2;
			if (true)
			{
				linesDrawingResultBase.Positions = positions;
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#a;
			if (!false)
			{
				modelEditorControl.AddToView(drawingResult);
			}
		}

		// Token: 0x06006220 RID: 25120 RVA: 0x0017FE48 File Offset: 0x0017E048
		private double #FKc(Point3D #Kzb)
		{
			BoundingBoxData boundingBoxData;
			if (8 != 0 && 5 != 0)
			{
				BoundingBoxData editorWorkspaceBoundingBoxData = base.ModelEditorControl.EditorWorkspaceBoundingBoxData;
				if (-1 != 0)
				{
					boundingBoxData = editorWorkspaceBoundingBoxData;
				}
			}
			double result;
			double val = result = #Kzb.X;
			if (2 != 0)
			{
				result = Math.Max(Math.Min(val, boundingBoxData.MaxX), boundingBoxData.MinX);
			}
			return result;
		}

		// Token: 0x06006221 RID: 25121 RVA: 0x0017FE90 File Offset: 0x0017E090
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		private void #GKc(Point3D #Ng, bool #gzb)
		{
			Point3D #HAb = #Ng;
			bool #gzb2 = true;
			if (!false)
			{
				base.#fzb(#HAb, #gzb2);
			}
			GridLineDefinitionModel gridLineDefinitionModel2;
			try
			{
				if (!#gzb)
				{
					#Atc #Atc = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, #Ng);
					#Atc #Atc2;
					if (true)
					{
						#Atc2 = #Atc;
					}
					if (#Atc2 != null)
					{
						Point3D point3D = #Atc2.Point;
						if (4 != 0)
						{
							#Ng = point3D;
						}
					}
				}
				GridLineDefinitionModel gridLineDefinitionModel = new GridLineDefinitionModel(new #ewc(new Point(this.#FKc(#Ng), #Ng.Y), 90.0, base.ModelEditorControl.EditorWorkspaceSize));
				if (!false)
				{
					gridLineDefinitionModel2 = gridLineDefinitionModel;
				}
				if (base.ProjectContext.MainModel.#2Vc(gridLineDefinitionModel2))
				{
					return;
				}
			}
			catch (Exception #ob)
			{
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107414541), base.ToolInfo);
				return;
			}
			try
			{
				bool isWorking = true;
				if (7 != 0)
				{
					base.IsWorking = isWorking;
				}
				#bDc #bDc = base.UndoManager;
				if (7 != 0)
				{
					#bDc.#uCc();
				}
				string #f = GridLinesHelper.#qWc(base.StructuralModel.GridLines.Where(new Func<GridLineDefinitionModel, bool>(InsertVerticalGridLineTool.<>c.<>9.#q9c)).Select(new Func<GridLineDefinitionModel, string>(InsertVerticalGridLineTool.<>c.<>9.#r9c)).ToList<string>(), #HWc.#b);
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
			if (#gzb)
			{
				base.PreciseInputProvider.Update(this.#DKc());
			}
		}

		// Token: 0x06006222 RID: 25122 RVA: 0x0005034C File Offset: 0x0004E54C
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

		// Token: 0x06006223 RID: 25123 RVA: 0x00050382 File Offset: 0x0004E582
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#c;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x06006224 RID: 25124 RVA: 0x00050397 File Offset: 0x0004E597
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

		// Token: 0x0400284B RID: 10315
		private readonly IMultilineDrawingResult #a;

		// Token: 0x0400284C RID: 10316
		private InsertVerticalGridLineTool.#p9c #b;

		// Token: 0x0400284D RID: 10317
		private readonly Cursor #c;

		// Token: 0x02000BAD RID: 2989
		private enum #p9c
		{
			// Token: 0x0400284F RID: 10319
			#a,
			// Token: 0x04002850 RID: 10320
			#b
		}
	}
}
