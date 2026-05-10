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
using #EWc;
using #Fmc;
using #IDc;
using #KKc;
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

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Grid.InsertHorizontalGridLine
{
	// Token: 0x02000BB0 RID: 2992
	[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Used by IoC.")]
	public sealed class InsertHorizontalGridLineTool : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #JKc
	{
		// Token: 0x06006229 RID: 25129 RVA: 0x001800F0 File Offset: 0x0017E2F0
		public InsertHorizontalGridLineTool(#6Ic toolContext, IResourcesHelper resourcesHelper) : base(toolContext)
		{
			#X0d.#V0d(resourcesHelper, #Phc.#3hc(107415318), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107414947));
			base.Header = Strings.StringInsertHorizontalGridLine;
			base.IconImage = resourcesHelper.ImageFromResourceBitmap(ToolsIcons.InsertHorizontalGridLine);
			this.#a = base.ToolContext.DrawingResultsFactory.CreateMultilineDrawingResult();
			this.#c = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			base.HelpId = HelpIdentifiers.ToolInsertHorizontalGridLine;
		}

		// Token: 0x0600622A RID: 25130 RVA: 0x00180178 File Offset: 0x0017E378
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

		// Token: 0x0600622B RID: 25131 RVA: 0x00180220 File Offset: 0x0017E420
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

		// Token: 0x0600622C RID: 25132 RVA: 0x000503D2 File Offset: 0x0004E5D2
		public override void #1kb()
		{
			this.#b = InsertHorizontalGridLineTool.#s9c.#a;
			if (!false)
			{
				base.#1kb();
			}
		}

		// Token: 0x0600622D RID: 25133 RVA: 0x000503E7 File Offset: 0x0004E5E7
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			if (this.#b == InsertHorizontalGridLineTool.#s9c.#a)
			{
				this.#b = InsertHorizontalGridLineTool.#s9c.#b;
			}
		}

		// Token: 0x0600622E RID: 25134 RVA: 0x001802A0 File Offset: 0x0017E4A0
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			if (this.#b != InsertHorizontalGridLineTool.#s9c.#b)
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
			this.#b = InsertHorizontalGridLineTool.#s9c.#a;
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

		// Token: 0x0600622F RID: 25135 RVA: 0x00180300 File Offset: 0x0017E500
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

		// Token: 0x06006230 RID: 25136 RVA: 0x00180354 File Offset: 0x0017E554
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

		// Token: 0x06006231 RID: 25137 RVA: 0x000503F8 File Offset: 0x0004E5F8
		protected override void #GIc()
		{
			#jUc #jUc = base.PreciseInputProvider;
			PreciseInputParameters initializeInputParameters = this.#DKc();
			if (!false)
			{
				#jUc.Show(initializeInputParameters);
			}
		}

		// Token: 0x06006232 RID: 25138 RVA: 0x0017FCD4 File Offset: 0x0017DED4
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

		// Token: 0x06006233 RID: 25139 RVA: 0x00050412 File Offset: 0x0004E612
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

		// Token: 0x06006234 RID: 25140 RVA: 0x00180394 File Offset: 0x0017E594
		private PreciseInputParameters #DKc()
		{
			#WWc #WWc = base.ProjectContext.MainModel;
			#WWc #WWc2;
			if (!false)
			{
				#WWc2 = #WWc;
			}
			#GJc #GJc = new #GJc();
			#GJc.WorkspaceSize = #WWc2.WorkspaceBoundingBoxData;
			#GJc.OwnerControl = base.ModelEditorViewModel.View.ParentControl;
			#GJc.CoordinateValidator = null;
			#GJc.VisualCoordinate = this.#KIc();
			#GJc.EnableYCoordinate = true;
			#GJc.EnableXCoordinate = false;
			#GJc.ResetCurrentValues = true;
			#GJc.IsPolarSystemEnabled = false;
			#GJc.Message = Strings.StringSelectYCoordinate;
			#oW #f = base.ProjectContext;
			if (-1 != 0)
			{
				#GJc.ProjectContext = #f;
			}
			return #aJc.#7Ic(#GJc);
		}

		// Token: 0x06006235 RID: 25141 RVA: 0x0018042C File Offset: 0x0017E62C
		private void #EKc(Point3D #Kzb)
		{
			BoundingBoxData editorWorkspaceBoundingBoxData = base.ModelEditorControl.EditorWorkspaceBoundingBoxData;
			BoundingBoxData boundingBoxData;
			if (!false)
			{
				boundingBoxData = editorWorkspaceBoundingBoxData;
			}
			double num = this.#LKc(#Kzb);
			double y;
			if (4 != 0)
			{
				y = num;
			}
			List<Point3D> list = new List<Point3D>();
			list.Add(new Point3D(boundingBoxData.MinX, y, 0.032));
			Point3D item = new Point3D(boundingBoxData.MaxX, y, 0.032);
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

		// Token: 0x06006236 RID: 25142 RVA: 0x001804D0 File Offset: 0x0017E6D0
		private double #LKc(Point3D #Kzb)
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
			double val = result = #Kzb.Y;
			if (2 != 0)
			{
				result = Math.Max(Math.Min(val, boundingBoxData.MaxY), boundingBoxData.MinY);
			}
			return result;
		}

		// Token: 0x06006237 RID: 25143 RVA: 0x00180518 File Offset: 0x0017E718
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		private void #GKc(Point3D #Ng, bool #MKc)
		{
			GridLineDefinitionModel gridLineDefinitionModel2;
			try
			{
				if (#MKc)
				{
					goto IL_2E;
				}
				if (-1 == 0)
				{
					goto IL_39;
				}
				#Atc #Atc = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, #Ng);
				#Atc #Atc2;
				if (8 != 0)
				{
					#Atc2 = #Atc;
				}
				if (#Atc2 == null)
				{
					goto IL_2E;
				}
				IL_24:
				Point3D point3D = #Atc2.Point;
				if (5 != 0)
				{
					#Ng = point3D;
				}
				IL_2E:
				double num = this.#LKc(#Ng);
				double yField;
				if (!false)
				{
					yField = num;
				}
				IL_39:
				GridLineDefinitionModel gridLineDefinitionModel = new GridLineDefinitionModel(new #ewc(new Point(#Ng.X, yField), 0.0, base.ModelEditorControl.EditorWorkspaceSize));
				if (3 != 0)
				{
					gridLineDefinitionModel2 = gridLineDefinitionModel;
				}
				if (6 == 0)
				{
					goto IL_24;
				}
				if (base.ProjectContext.MainModel.#2Vc(gridLineDefinitionModel2))
				{
					return;
				}
			}
			catch (Exception #ob)
			{
				if (7 != 0)
				{
					base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107414541), base.ToolInfo);
				}
				return;
			}
			try
			{
				bool isWorking = true;
				if (!false)
				{
					base.IsWorking = isWorking;
				}
				string #f;
				if (!false)
				{
					#bDc #bDc = base.UndoManager;
					if (3 != 0)
					{
						#bDc.#uCc();
					}
					#f = GridLinesHelper.#qWc(base.StructuralModel.GridLines.Where(new Func<GridLineDefinitionModel, bool>(InsertHorizontalGridLineTool.<>c.<>9.#q9c)).Select(new Func<GridLineDefinitionModel, string>(InsertHorizontalGridLineTool.<>c.<>9.#r9c)).ToList<string>(), #HWc.#a);
				}
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
				if (!false)
				{
					base.UndoManager.#vCc();
					this.#1kb();
				}
				base.IsWorking = false;
			}
			if (#MKc)
			{
				base.PreciseInputProvider.Update(this.#DKc());
			}
		}

		// Token: 0x06006238 RID: 25144 RVA: 0x0005034C File Offset: 0x0004E54C
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

		// Token: 0x06006239 RID: 25145 RVA: 0x00050434 File Offset: 0x0004E634
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#c;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x0600623A RID: 25146 RVA: 0x00050449 File Offset: 0x0004E649
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

		// Token: 0x04002854 RID: 10324
		private readonly IMultilineDrawingResult #a;

		// Token: 0x04002855 RID: 10325
		private InsertHorizontalGridLineTool.#s9c #b;

		// Token: 0x04002856 RID: 10326
		private readonly Cursor #c;

		// Token: 0x02000BB1 RID: 2993
		private enum #s9c
		{
			// Token: 0x04002858 RID: 10328
			#a,
			// Token: 0x04002859 RID: 10329
			#b
		}
	}
}
