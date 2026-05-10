using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using #7Tc;
using #8Cc;
using #bJc;
using #Fmc;
using #IDc;
using #NWc;
using #UYd;
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
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #POc
{
	// Token: 0x02000BF9 RID: 3065
	internal sealed class #OOc : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #9Tc, #QOc
	{
		// Token: 0x060063B2 RID: 25522 RVA: 0x00185FE4 File Offset: 0x001841E4
		public #OOc(#6Ic #JDc, #1Wc #2Nc) : base(#JDc)
		{
			#X0d.#V0d(#JDc, #Phc.#3hc(107415858), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107444964));
			this.#g = #2Nc;
			base.Header = Strings.StringInsertLine;
			base.IconImage = #JDc.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.InsertLine);
			this.#a = base.ToolContext.DrawingResultsFactory.CreatePolylineDrawingResult();
			this.#e = base.ToolContext.DrawingResultsFactory.CreateCrossIndicatorDrawingResult();
			this.#f = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			this.#d = new Dictionary<#OOc.#jad, string>();
			this.#d[#OOc.#jad.#a] = Strings.StringSelectStartPoint.#z2d();
			this.#d[#OOc.#jad.#b] = Strings.StringSelectEndPoint.#z2d();
			base.IsPreciseInputEnabled = true;
			base.HelpId = HelpIdentifiers.ToolDrawLinearObject;
		}

		// Token: 0x060063B3 RID: 25523 RVA: 0x001860CC File Offset: 0x001842CC
		public override void #5b()
		{
			if (!false)
			{
				base.#5b();
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#a;
			Color lineColor = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeColor;
			if (!false)
			{
				linesDrawingResultBase.LineColor = lineColor;
			}
			do
			{
				ILinesDrawingResultBase linesDrawingResultBase2 = this.#a;
				double lineThickness = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeThickness;
				if (7 != 0)
				{
					linesDrawingResultBase2.LineThickness = lineThickness;
				}
				ISnapPointsMarker #IJc = base.SnapPointsMarker;
				#6Gc #JAc = base.SettingsProvider;
				if (3 != 0)
				{
					#8Ib.#HJc(#IJc, #JAc);
				}
				if (!false)
				{
					IModelEditorControl modelEditorControl = base.ModelEditorControl;
					Cursor cursor = this.#f;
					bool forceCursor = false;
					if (3 != 0)
					{
						modelEditorControl.SetCursor(cursor, forceCursor);
					}
				}
			}
			while (8 == 0);
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[3];
			array[0] = ModelEditorControlEventType.MouseLeftButtonDown;
			array[1] = ModelEditorControlEventType.MouseLeftButtonUp;
			if (!false)
			{
				base.#FIc(array);
			}
		}

		// Token: 0x060063B4 RID: 25524 RVA: 0x00186178 File Offset: 0x00184378
		public override void #0kb()
		{
			ModelEditorControlEventType[] #MEc = null;
			if (2 != 0)
			{
				base.#FIc(#MEc);
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			Cursor arrow = System.Windows.Input.Cursors.Arrow;
			bool forceCursor = false;
			if (-1 != 0)
			{
				modelEditorControl.SetCursor(arrow, forceCursor);
			}
			do
			{
				if (!false)
				{
					if (!false && 4 != 0)
					{
						this.#1kb();
					}
					if (true)
					{
						base.#0kb();
					}
				}
			}
			while (false);
		}

		// Token: 0x060063B5 RID: 25525 RVA: 0x001861D0 File Offset: 0x001843D0
		public override void #1kb()
		{
			do
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#a;
				if (4 != 0)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
				if (5 != 0)
				{
					this.#c = #OOc.#jad.#a;
				}
				if (false)
				{
					return;
				}
				this.#b = null;
			}
			while (3 == 0);
			bool isWorking = false;
			if (8 != 0)
			{
				base.IsWorking = isWorking;
			}
			if (-1 != 0)
			{
				base.#1kb();
			}
		}

		// Token: 0x060063B6 RID: 25526 RVA: 0x0018622C File Offset: 0x0018442C
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			Point3D? point3D = base.ToolOperationsHelper.#aEc(#HAb);
			Point3D? point3D2;
			if (2 != 0)
			{
				point3D2 = point3D;
			}
			if (point3D2 == null)
			{
				return;
			}
			Point3D value = point3D2.Value;
			if (!false)
			{
				#HAb = value;
			}
			Point3D #HAb2 = #HAb;
			if (5 != 0)
			{
				base.#fzb(#HAb2, #gzb);
			}
			if (this.#c == #OOc.#jad.#a)
			{
				this.#b = new Point3D?(PointsConverter.#Csc(#HAb, 0.032));
				double x = #HAb.X;
				double y = #HAb.Y;
				double z = 0.032;
				Point3D point3D3;
				if (6 != 0)
				{
					point3D3 = new Point3D(x, y, z);
				}
				Point3D #Yrb = point3D3;
				if (!false)
				{
					this.#NOc(#Yrb);
				}
				this.#c = #OOc.#jad.#b;
			}
			else if (this.#b != null)
			{
				Point3D value2 = this.#b.Value;
				Point3D #MOc = #HAb;
				if (!false)
				{
					this.#QKc(value2, #MOc);
				}
			}
			if (#gzb)
			{
				base.PreciseInputProvider.Update(this.#DNc(false));
			}
		}

		// Token: 0x060063B7 RID: 25527 RVA: 0x00186324 File Offset: 0x00184524
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			Point3D? point3D2;
			bool flag3;
			do
			{
				if (this.#c == #OOc.#jad.#a)
				{
					Point3D? point3D = base.#HIc(#4kb);
					if (!false)
					{
						point3D2 = point3D;
					}
					bool flag2;
					bool flag = flag2 = (flag3 = (point3D2 != null));
					if (!false)
					{
						if (!flag)
						{
							return;
						}
						Point3D? point3D3 = base.ToolOperationsHelper.#aEc(point3D2.Value);
						if (!false)
						{
							point3D2 = point3D3;
						}
						flag3 = (flag2 = (point3D2 != null));
					}
					if (7 == 0)
					{
						goto IL_77;
					}
					if (flag2)
					{
						goto IL_4A;
					}
					if (8 != 0)
					{
						return;
					}
				}
			}
			while (7 == 0);
			return;
			IL_4A:
			Point3D? point3D4 = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D2.Value).#Dtc();
			Point3D? point3D5;
			if (!false)
			{
				point3D5 = point3D4;
			}
			flag3 = (point3D5 != null);
			IL_77:
			if (!flag3)
			{
				return;
			}
			Point3D value = point3D5.Value;
			bool #gzb = false;
			if (4 != 0)
			{
				this.#fzb(value, #gzb);
			}
			bool isWorking = true;
			if (!false)
			{
				base.IsWorking = isWorking;
			}
		}

		// Token: 0x060063B8 RID: 25528 RVA: 0x001863DC File Offset: 0x001845DC
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			IL_00:
			while (!false)
			{
				if (this.#c != #OOc.#jad.#b)
				{
					return;
				}
				Point3D? point3D = base.#HIc(#4kb);
				Point3D? point3D2;
				if (-1 != 0)
				{
					point3D2 = point3D;
				}
				if (point3D2 == null)
				{
					break;
				}
				Point3D? point3D3 = base.ToolOperationsHelper.#aEc(point3D2.Value);
				if (!false)
				{
					point3D2 = point3D3;
				}
				bool flag = point3D2 != null;
				while (flag)
				{
					Point3D? point3D4 = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D2.Value).#Dtc();
					Point3D? point3D5;
					if (!false)
					{
						point3D5 = point3D4;
					}
					bool flag2 = flag = (point3D5 != null);
					if (true)
					{
						if (!flag2)
						{
							if (8 == 0)
							{
								goto IL_00;
							}
							if (3 != 0)
							{
								return;
							}
						}
						else
						{
							Point3D value = point3D5.Value;
							bool #gzb = false;
							if (6 != 0)
							{
								this.#fzb(value, #gzb);
							}
						}
						return;
					}
				}
				return;
			}
		}

		// Token: 0x060063B9 RID: 25529 RVA: 0x0018648C File Offset: 0x0018468C
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_1F;
				}
				if (!false)
				{
					base.#HEc(#IEc, #Kzb);
				}
			}
			Point3D? point3D = base.ToolOperationsHelper.#aEc(#Kzb);
			Point3D? point3D2;
			if (7 != 0)
			{
				point3D2 = point3D;
			}
			IL_1F:
			if (point3D2 == null)
			{
				return;
			}
			#Atc #Atc = base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, point3D2.Value);
			#Atc #Atc2;
			if (!false)
			{
				#Atc2 = #Atc;
			}
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = #Atc2;
			if (!false)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			if (this.#c != #OOc.#jad.#b)
			{
				return;
			}
			if (3 != 0)
			{
				this.#NOc(#Kzb);
			}
		}

		// Token: 0x060063BA RID: 25530 RVA: 0x00051081 File Offset: 0x0004F281
		protected override void #hIc()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#e;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
		}

		// Token: 0x060063BB RID: 25531 RVA: 0x00181EF4 File Offset: 0x001800F4
		protected override void #iIc(PreciseInputCompletedEventArgs #jIc)
		{
			while (8 != 0)
			{
				Point3D? point3D = #aJc.#9Ic(#jIc);
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				if (point3D2 == null && 2 != 0)
				{
					return;
				}
				if (5 != 0)
				{
					Point3D value = point3D2.Value;
					bool #gzb = true;
					if (!true)
					{
						break;
					}
					this.#fzb(value, #gzb);
					break;
				}
			}
		}

		// Token: 0x060063BC RID: 25532 RVA: 0x0018651C File Offset: 0x0018471C
		protected override void #fIc(PreciseInputChangedEventArgs #gIc)
		{
			Point3D? point3D = #aJc.#9Ic(#gIc);
			Point3D? point3D2;
			if (-1 != 0)
			{
				point3D2 = point3D;
			}
			if (2 == 0)
			{
				goto IL_3A;
			}
			if (point3D2 != null)
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#e;
				if (false)
				{
					goto IL_28;
				}
				modelEditorControl.AddToView(drawingResult);
				goto IL_28;
			}
			return;
			IL_28:
			ICrossIndicatorDrawingResult crossIndicatorDrawingResult = this.#e;
			Point3D value = point3D2.Value;
			if (!false)
			{
				crossIndicatorDrawingResult.CenterPoint = value;
			}
			IL_3A:
			Point3D value2 = point3D2.Value;
			if (!false)
			{
				this.#NOc(value2);
			}
			ICrossIndicatorDrawingResult #LIc = this.#e;
			if (4 != 0)
			{
				base.#AIc(#LIc);
			}
			if (false)
			{
				return;
			}
			if (7 != 0)
			{
				base.#fIc(#gIc);
			}
			if (5 != 0)
			{
				return;
			}
			goto IL_28;
		}

		// Token: 0x060063BD RID: 25533 RVA: 0x0005109B File Offset: 0x0004F29B
		protected override void #GIc()
		{
			do
			{
				if (true && !false)
				{
					ICrossIndicatorDrawingResult #LIc = this.#e;
					if (!false)
					{
						base.#AIc(#LIc);
					}
				}
				#jUc #jUc = base.PreciseInputProvider;
				PreciseInputParameters initializeInputParameters = this.#DNc(true);
				if (!false)
				{
					#jUc.Show(initializeInputParameters);
				}
			}
			while (false);
		}

		// Token: 0x060063BE RID: 25534 RVA: 0x001865B0 File Offset: 0x001847B0
		public string #vNc(#ivc #rmc, Point #Ng)
		{
			if (true)
			{
				if (this.#b != null)
				{
					Point point = PointsConverter.#vsc(this.#b.Value);
					Point #IOc;
					if (2 != 0)
					{
						#IOc = point;
					}
					if (!this.#KOc(#IOc, #Ng))
					{
						goto IL_2E;
					}
				}
				return null;
			}
			IL_2E:
			return Strings.StringCouldNotCreateLinearObjectFromTheGivenParameters.#z2d();
		}

		// Token: 0x060063BF RID: 25535 RVA: 0x001865FC File Offset: 0x001847FC
		private PreciseInputParameters #DNc(bool #ENc)
		{
			#WWc #WWc2;
			if (!false)
			{
				#WWc #WWc = base.ProjectContext.MainModel;
				if (6 != 0)
				{
					#WWc2 = #WWc;
				}
			}
			if (#WWc2 == null)
			{
				return null;
			}
			#GJc #GJc = new #GJc();
			#GJc.WorkspaceSize = #WWc2.WorkspaceBoundingBoxData;
			#GJc.OwnerControl = base.ModelEditorViewModel.View.ParentControl;
			#GJc.CoordinateValidator = this;
			#GJc.VisualCoordinate = this.#KIc();
			#GJc.IsInitialCoordinate = true;
			#GJc.ResetCurrentValues = #ENc;
			#GJc.RelativeCoordinate = base.#IIc();
			#GJc.Message = this.#d[this.#c];
			#oW #oW = base.ProjectContext;
			if (8 != 0)
			{
				#GJc.ProjectContext = #oW;
			}
			return #aJc.#7Ic(#GJc);
		}

		// Token: 0x060063C0 RID: 25536 RVA: 0x001866AC File Offset: 0x001848AC
		private static bool #HOc(Point #IOc, Point #JOc, LinearObject #NNc)
		{
			bool flag = #jsc.#Src(#NNc.Segment, #IOc);
			bool flag2;
			if (!false)
			{
				flag2 = flag;
			}
			bool flag3 = #jsc.#Src(#NNc.Segment, #JOc);
			bool flag4;
			if (!false)
			{
				flag4 = flag3;
			}
			if (!flag2 && !flag4)
			{
				return false;
			}
			bool flag6;
			bool flag8;
			bool flag12;
			int num;
			for (;;)
			{
				bool flag5 = #jsc.#Src(#NNc.StartPoint, #NNc.EndPoint, #IOc);
				if (3 != 0)
				{
					flag6 = flag5;
				}
				bool flag7 = #jsc.#Src(#NNc.StartPoint, #NNc.EndPoint, #JOc);
				if (!false)
				{
					flag8 = flag7;
				}
				bool flag9;
				if (!PointsConverter.#uC(#IOc, #NNc.StartPoint))
				{
					flag9 = PointsConverter.#uC(#IOc, #NNc.EndPoint);
				}
				else
				{
					flag9 = true;
				}
				IL_7D:
				bool flag10;
				if (-1 != 0)
				{
					flag10 = flag9;
				}
				bool flag11 = PointsConverter.#uC(#JOc, #NNc.StartPoint) || PointsConverter.#uC(#JOc, #NNc.EndPoint);
				if (!false)
				{
					flag12 = flag11;
				}
				if (false)
				{
					continue;
				}
				if (!flag2)
				{
					goto IL_BE;
				}
				if (5 == 0)
				{
					goto IL_CD;
				}
				bool flag13 = (num = (flag10 ? 1 : 0)) != 0;
				if (false)
				{
					break;
				}
				flag9 = ((num = ((!flag13) ? 1 : 0)) != 0);
				if (!false)
				{
					break;
				}
				goto IL_7D;
			}
			goto IL_BF;
			IL_BE:
			num = 0;
			IL_BF:
			if ((num & (flag8 ? 1 : 0)) != 0)
			{
				return true;
			}
			bool flag14;
			if (flag4)
			{
				flag14 = !flag12;
				goto IL_CE;
			}
			IL_CD:
			flag14 = false;
			IL_CE:
			if (!flag14 || !flag6)
			{
				return false;
			}
			return true;
		}

		// Token: 0x060063C1 RID: 25537 RVA: 0x001867B4 File Offset: 0x001849B4
		private bool #KOc(Point #IOc, Point #JOc)
		{
			int result;
			bool flag = (result = (PointsConverter.#uC(#IOc, #JOc) ? 1 : 0)) != 0;
			if (4 != 0)
			{
				if (flag)
				{
					result = 0;
				}
				else
				{
					if (base.StructuralModel.#cWc(#IOc, #JOc))
					{
						return false;
					}
					IEnumerator<LinearObject> enumerator = base.StructuralModel.LinearObjects.GetEnumerator();
					IEnumerator<LinearObject> enumerator2;
					if (!false)
					{
						enumerator2 = enumerator;
					}
					try
					{
						bool result2;
						while (8 != 0 && 3 != 0)
						{
							if (!enumerator2.MoveNext())
							{
								if (!false)
								{
									return true;
								}
							}
							else
							{
								LinearObject linearObject = enumerator2.Current;
								LinearObject #NNc;
								if (!false)
								{
									#NNc = linearObject;
								}
								if (!#OOc.#HOc(#IOc, #JOc, #NNc))
								{
									continue;
								}
							}
							bool flag2 = false;
							if (3 == 0)
							{
								break;
							}
							result2 = flag2;
							break;
						}
						return result2;
					}
					finally
					{
						if (enumerator2 != null)
						{
							enumerator2.Dispose();
						}
					}
					return true;
				}
			}
			return result != 0;
		}

		// Token: 0x060063C2 RID: 25538 RVA: 0x0018684C File Offset: 0x00184A4C
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected exceptions catch.")]
		private void #QKc(Point3D #LOc, Point3D #MOc)
		{
			Point point = PointsConverter.#vsc(#LOc);
			Point point2;
			if (!false)
			{
				point2 = point;
			}
			Point point3 = PointsConverter.#vsc(#MOc);
			Point point4;
			if (2 != 0)
			{
				point4 = point3;
			}
			if (!this.#KOc(point2, point4))
			{
				return;
			}
			try
			{
				#bDc #bDc = base.UndoManager;
				if (!false)
				{
					#bDc.#uCc();
				}
				LinearObject linearObject = new LinearObject(base.UndoManager, this.#g);
				LinearObject linearObject2;
				if (!false)
				{
					linearObject2 = linearObject;
				}
				LinearObject linearObject3 = linearObject2;
				Point point5 = point2;
				if (!false)
				{
					linearObject3.StartPoint = point5;
				}
				LinearObject linearObject4 = linearObject2;
				Point point6 = point4;
				if (2 != 0)
				{
					linearObject4.EndPoint = point6;
				}
				base.ProjectContext.MainModel.#9Vc(linearObject2);
				do
				{
					base.ModelEditorViewModel.#e0c(base.ProjectContext.MainModel.LinearObjects);
					base.#MIc();
				}
				while (false);
				if (!false)
				{
					this.#zIc();
				}
			}
			catch (ModelValidationException #PIc)
			{
				if (2 != 0)
				{
					base.#OIc(#PIc);
				}
			}
			catch (Exception #ob)
			{
				base.UndoManager.#yCc(true);
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107444911), base.ToolInfo);
			}
			finally
			{
				base.UndoManager.#vCc();
				this.#1kb();
			}
		}

		// Token: 0x060063C3 RID: 25539 RVA: 0x00186984 File Offset: 0x00184B84
		private void #NOc(Point3D #Yrb)
		{
			if (this.#b != null)
			{
				do
				{
					ILinesDrawingResultBase linesDrawingResultBase = this.#a;
					List<Point3D> list = new List<Point3D>();
					list.Add(this.#b.Value);
					if (8 != 0)
					{
						list.Add(#Yrb);
					}
					IEnumerable<Point3D> positions = PointsConverter.#Csc(list, 0.032);
					if (!false)
					{
						linesDrawingResultBase.Positions = positions;
					}
					if (6 == 0)
					{
						goto IL_5B;
					}
					IModelEditorControl modelEditorControl = base.ModelEditorControl;
					IDrawingResult drawingResult = this.#a;
					if (!false)
					{
						modelEditorControl.AddToView(drawingResult);
					}
				}
				while (false);
				return;
			}
			IL_5B:
			IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
			IDrawingResult drawingResult2 = this.#a;
			if (!false)
			{
				modelEditorControl2.RemoveFromView(drawingResult2);
			}
		}

		// Token: 0x060063C4 RID: 25540 RVA: 0x000510D2 File Offset: 0x0004F2D2
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#f;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x060063C5 RID: 25541 RVA: 0x000510E7 File Offset: 0x0004F2E7
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

		// Token: 0x040028E8 RID: 10472
		private readonly IPolylineDrawingResult #a;

		// Token: 0x040028E9 RID: 10473
		private Point3D? #b;

		// Token: 0x040028EA RID: 10474
		private #OOc.#jad #c;

		// Token: 0x040028EB RID: 10475
		private readonly Dictionary<#OOc.#jad, string> #d;

		// Token: 0x040028EC RID: 10476
		private readonly ICrossIndicatorDrawingResult #e;

		// Token: 0x040028ED RID: 10477
		private readonly Cursor #f;

		// Token: 0x040028EE RID: 10478
		private readonly #1Wc #g;

		// Token: 0x02000BFA RID: 3066
		private enum #jad
		{
			// Token: 0x040028F0 RID: 10480
			#a,
			// Token: 0x040028F1 RID: 10481
			#b
		}
	}
}
