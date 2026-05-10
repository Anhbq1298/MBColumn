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
using #FOc;
using #hTb;
using #IDc;
using #NWc;
using #T0c;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure;
using StructurePoint.CoreAssets.GUI.Framework.PreciseInput;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Infrastructure;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.DrawPolygon
{
	// Token: 0x02000BF4 RID: 3060
	public sealed class DrawPolygonTool : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #9Tc, #GOc
	{
		// Token: 0x0600637F RID: 25471 RVA: 0x00184D0C File Offset: 0x00182F0C
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public DrawPolygonTool(#6Ic toolContext) : base(toolContext)
		{
			base.Header = Strings.StringDrawPolygon;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.DrawPolygon);
			this.ToolState = DrawPolygonTool.#fad.#a;
			this.#d = base.ToolContext.DrawingResultsFactory.CreatePolylineDrawingResult();
			this.#a = base.ToolContext.DrawingResultsFactory.CreatePolylineDrawingResult();
			this.ToolDrawingMode = ToolDrawingMode.Union;
			base.IsPreciseInputEnabled = true;
			this.#c = base.ToolContext.DrawingResultsFactory.CreateCrossIndicatorDrawingResult();
			this.#h = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			this.#g = new Dictionary<DrawPolygonTool.#fad, string>();
			this.#g[DrawPolygonTool.#fad.#a] = Strings.StringSelectStartPoint.#z2d();
			this.#g[DrawPolygonTool.#fad.#b] = Strings.StringSelectNextPoint.#z2d();
			base.HelpId = HelpIdentifiers.ToolDrawPolygon;
			this.DrawPreview = true;
			this.DrawOnlyInWorkspace = true;
			base.IsOrthogonalModeSupported = true;
		}

		// Token: 0x17001C0E RID: 7182
		// (get) Token: 0x06006380 RID: 25472 RVA: 0x00050EF5 File Offset: 0x0004F0F5
		// (set) Token: 0x06006381 RID: 25473 RVA: 0x00184E1C File Offset: 0x0018301C
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public ToolDrawingMode ToolDrawingMode
		{
			get
			{
				return this.#f;
			}
			set
			{
				for (;;)
				{
					if (this.#f == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107414014);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#f = value;
						string propertyName2 = #Phc.#3hc(107414014);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001C0F RID: 7183
		// (get) Token: 0x06006382 RID: 25474 RVA: 0x00050EFD File Offset: 0x0004F0FD
		// (set) Token: 0x06006383 RID: 25475 RVA: 0x00050F05 File Offset: 0x0004F105
		protected bool DrawPreview { get; set; }

		// Token: 0x17001C10 RID: 7184
		// (get) Token: 0x06006384 RID: 25476 RVA: 0x00050F0E File Offset: 0x0004F10E
		protected IList<Point3D> SelectedPoints
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x17001C11 RID: 7185
		// (get) Token: 0x06006385 RID: 25477 RVA: 0x00050F16 File Offset: 0x0004F116
		// (set) Token: 0x06006386 RID: 25478 RVA: 0x00050F1E File Offset: 0x0004F11E
		private protected DrawPolygonTool.#fad ToolState { protected get; private set; }

		// Token: 0x17001C12 RID: 7186
		// (get) Token: 0x06006387 RID: 25479 RVA: 0x00050F27 File Offset: 0x0004F127
		// (set) Token: 0x06006388 RID: 25480 RVA: 0x00050F2F File Offset: 0x0004F12F
		private protected Point3D LastSnappedPosition { protected get; private set; }

		// Token: 0x17001C13 RID: 7187
		// (get) Token: 0x06006389 RID: 25481 RVA: 0x00050F38 File Offset: 0x0004F138
		// (set) Token: 0x0600638A RID: 25482 RVA: 0x00050F40 File Offset: 0x0004F140
		protected bool DrawOnlyInWorkspace { get; set; }

		// Token: 0x0600638B RID: 25483 RVA: 0x00184E70 File Offset: 0x00183070
		public override void #5b()
		{
			for (;;)
			{
				if (!false)
				{
					if (!true)
					{
						goto IL_0B;
					}
					base.#5b();
					goto IL_0B;
				}
				IL_41:
				if (!false)
				{
					if (false)
					{
						return;
					}
					ILinesDrawingResultBase linesDrawingResultBase = this.#d;
					double lineThickness = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeThickness;
					if (3 != 0)
					{
						linesDrawingResultBase.LineThickness = lineThickness;
					}
					ILinesDrawingResultBase linesDrawingResultBase2 = this.#a;
					Color lineColor = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeColor;
					if (true)
					{
						linesDrawingResultBase2.LineColor = lineColor;
					}
					this.#a.LineThickness = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeThickness;
					#8Ib.#HJc(base.SnapPointsMarker, base.SettingsProvider);
					base.#AIc(this.#c);
					if (!false)
					{
						break;
					}
					continue;
				}
				IL_0B:
				ModelEditorControlEventType[] array = new ModelEditorControlEventType[4];
				RuntimeFieldHandle fldHandle = fieldof(#l8c.#e).FieldHandle;
				if (!false)
				{
					RuntimeHelpers.InitializeArray(array, fldHandle);
				}
				if (-1 != 0)
				{
					base.#FIc(array);
				}
				ILinesDrawingResultBase linesDrawingResultBase3 = this.#d;
				Color lineColor2 = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeColor;
				if (4 == 0)
				{
					goto IL_41;
				}
				linesDrawingResultBase3.LineColor = lineColor2;
				goto IL_41;
			}
			base.ModelEditorControl.SetCursor(this.#h, false);
		}

		// Token: 0x0600638C RID: 25484 RVA: 0x00184F80 File Offset: 0x00183180
		public override void #0kb()
		{
			for (;;)
			{
				if (7 != 0)
				{
					base.#0kb();
				}
				while (!false)
				{
					ModelEditorControlEventType[] #MEc = null;
					if (!false)
					{
						base.#LEc(#MEc);
					}
					if (4 != 0)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
			if (true)
			{
				this.#1kb();
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#c;
			if (2 != 0)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
			Cursor arrow = System.Windows.Input.Cursors.Arrow;
			bool forceCursor = false;
			if (2 != 0)
			{
				modelEditorControl2.SetCursor(arrow, forceCursor);
			}
		}

		// Token: 0x0600638D RID: 25485 RVA: 0x00184FEC File Offset: 0x001831EC
		public override void #1kb()
		{
			IModelEditorControl modelEditorControl = base.ToolContext.ModelEditorControl;
			IDrawingResult drawingResult = this.#d;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			if (8 == 0)
			{
				goto IL_53;
			}
			IModelEditorControl modelEditorControl2 = base.ToolContext.ModelEditorControl;
			IDrawingResult drawingResult2 = this.#a;
			if (!false)
			{
				modelEditorControl2.RemoveFromView(drawingResult2);
			}
			DrawPolygonTool.#fad #fad = DrawPolygonTool.#fad.#a;
			if (!false)
			{
				this.ToolState = #fad;
			}
			List<Point3D> list = this.#b;
			if (!false)
			{
				list.Clear();
			}
			bool isWorking = false;
			if (!false)
			{
				base.IsWorking = isWorking;
			}
			IL_47:
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = null;
			if (7 != 0)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			IL_53:
			if (!false)
			{
				base.ModelEditorViewModel.#l0c();
				if (!false)
				{
					base.#1kb();
				}
				return;
			}
			goto IL_47;
		}

		// Token: 0x0600638E RID: 25486 RVA: 0x00185090 File Offset: 0x00183290
		public string #vNc(#ivc #rmc, Point #Ng)
		{
			Point3D point3D2;
			do
			{
				Point3D point3D = PointsConverter.#vsc(#Ng);
				if (-1 != 0)
				{
					point3D2 = point3D;
				}
				if (this.ToolState != DrawPolygonTool.#fad.#b)
				{
					goto IL_D1;
				}
			}
			while (false);
			if (this.#b.Count < 3 || 4 == 0)
			{
				goto IL_A6;
			}
			Point3D point3D3 = this.#b[0];
			Point3D point3D4;
			if (6 != 0)
			{
				point3D4 = point3D3;
			}
			IL_40:
			if (point3D4.X == point3D2.X)
			{
				Point3D point3D5 = this.#b[0];
				if (!false)
				{
					point3D4 = point3D5;
				}
				if (point3D4.Y == point3D2.Y)
				{
					if (!this.#zzb(this.#b.Last<Point3D>(), this.#b[0], null))
					{
						return Strings.StringCouldNotCreatePolygonFromGivenPoint.#z2d();
					}
					goto IL_D1;
				}
			}
			IL_A6:
			if (!this.#zzb(this.#b.Last<Point3D>(), point3D2, new Point3D?(point3D2)))
			{
				if (!false)
				{
					return Strings.StringCouldNotCreatePolygonFromGivenPoint.#z2d();
				}
				goto IL_40;
			}
			IL_D1:
			if (!false)
			{
				return null;
			}
			goto IL_A6;
		}

		// Token: 0x0600638F RID: 25487 RVA: 0x00185184 File Offset: 0x00183384
		protected void #wzb(Point3D #HAb)
		{
			if (7 != 0)
			{
				if (false)
				{
					goto IL_27;
				}
				List<Point3D> list = this.#b;
				if (5 != 0)
				{
					list.Add(#HAb);
				}
				if (!false)
				{
					this.#DOc(#HAb);
				}
				this.#e = #HAb;
			}
			DrawPolygonTool.#fad #fad = DrawPolygonTool.#fad.#b;
			if (3 != 0)
			{
				this.ToolState = #fad;
			}
			IL_27:
			bool isWorking = true;
			if (4 != 0)
			{
				base.IsWorking = isWorking;
			}
			if (!false && base.IsOrthogonalModeEnabled)
			{
				#V0c #V0c = base.ModelEditorViewModel;
				Point3D #k0c = this.#e;
				BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
				if (!false)
				{
					#V0c.#j0c(#k0c, #Prc);
				}
			}
		}

		// Token: 0x06006390 RID: 25488 RVA: 0x0018520C File Offset: 0x0018340C
		protected bool #yOc(Point3D #HAb)
		{
			int result;
			if (this.#b.Count >= 3)
			{
				Point3D point3D = this.#b[0];
				Point3D point3D2;
				if (6 != 0)
				{
					point3D2 = point3D;
				}
				if (point3D2.X == #HAb.X)
				{
					Point3D point3D3 = this.#b[0];
					if (2 != 0)
					{
						point3D2 = point3D3;
					}
					if (point3D2.Y == #HAb.Y)
					{
						bool flag = (result = (this.#zzb(this.#b.Last<Point3D>(), this.#b[0], null) ? 1 : 0)) != 0;
						if (8 == 0)
						{
							return result != 0;
						}
						if (!flag)
						{
							return false;
						}
						List<Point3D> list = this.#b;
						Point3D item = #HAb;
						if (5 != 0)
						{
							list.Add(item);
						}
						if (8 != 0)
						{
							this.#COc();
						}
						bool #AOc = false;
						if (!false)
						{
							this.#nOc(#AOc);
						}
						goto IL_10A;
					}
				}
			}
			int result2;
			if (!this.#zzb(this.#b.Last<Point3D>(), #HAb, new Point3D?(#HAb)))
			{
				result = 0;
			}
			else
			{
				List<Point3D> list2 = this.#b;
				Point3D item2 = #HAb;
				if (7 != 0)
				{
					list2.Add(item2);
				}
				this.#COc();
				this.#e = #HAb;
				this.#DOc(#HAb);
				bool flag2 = (result2 = (base.IsOrthogonalModeEnabled ? 1 : 0)) != 0;
				if (false)
				{
					return result2 != 0;
				}
				if (flag2)
				{
					base.ModelEditorViewModel.#j0c(this.#e, base.StructuralModel.WorkspaceBoundingBoxData);
					goto IL_10A;
				}
				goto IL_10A;
			}
			return result != 0;
			IL_10A:
			result2 = 1;
			return result2 != 0;
		}

		// Token: 0x06006391 RID: 25489 RVA: 0x00185358 File Offset: 0x00183558
		protected bool #zOc()
		{
			if (this.ToolState == DrawPolygonTool.#fad.#b)
			{
				int result;
				int num2;
				int num = num2 = (result = this.#b.Count);
				Point3D point3D2;
				if (!false)
				{
					if (false)
					{
						return result != 0;
					}
					if (num <= 2)
					{
						return false;
					}
					Point3D point3D = this.#b[0];
					if (2 != 0)
					{
						point3D2 = point3D;
					}
					num2 = (this.#zzb(this.#b.Last<Point3D>(), point3D2, null) ? 1 : 0);
				}
				if (num2 != 0)
				{
					if (this.DrawPreview)
					{
						ILinesDrawingResultBase linesDrawingResultBase = this.#a;
						IEnumerable<Point3D> positions = PointsConverter.#Bsc(new Point3D[]
						{
							this.#e,
							point3D2
						}, 0.032);
						if (!false)
						{
							linesDrawingResultBase.Positions = positions;
						}
					}
					List<Point3D> list = this.#b;
					Point3D item = point3D2;
					if (!false)
					{
						list.Add(item);
					}
					bool #AOc = false;
					if (5 != 0)
					{
						this.#nOc(#AOc);
					}
					bool isWorking = false;
					if (8 != 0)
					{
						base.IsWorking = isWorking;
					}
					return true;
				}
				result = 0;
				return result != 0;
			}
			return false;
		}

		// Token: 0x06006392 RID: 25490 RVA: 0x00185434 File Offset: 0x00183634
		protected bool #zzb(Point3D #Xrb, Point3D #Yrb, Point3D? #tzb)
		{
			DrawPolygonTool.#EZb #EZb = new DrawPolygonTool.#EZb();
			DrawPolygonTool.#EZb #EZb2;
			if (7 != 0)
			{
				#EZb2 = #EZb;
			}
			bool flag3;
			bool flag4;
			for (;;)
			{
				#EZb2.#a = #Xrb;
				#EZb2.#b = #Yrb;
				#EZb2.#c = this;
				bool flag = #tzb != null;
				for (;;)
				{
					IL_28:
					if (flag)
					{
						goto IL_2A;
					}
					IL_40:
					if (2 == 0)
					{
						break;
					}
					IList<Point> list = PointsConverter.#vsc(this.#b);
					IList<Point> list2;
					if (!false)
					{
						list2 = list;
					}
					Point point = PointsConverter.#vsc(#EZb2.#a);
					Point #Xrb2;
					if (2 != 0)
					{
						#Xrb2 = point;
					}
					Point point2 = PointsConverter.#vsc(#EZb2.#b);
					Point #Yrb2;
					if (!false)
					{
						#Yrb2 = point2;
					}
					IList<Point> list3 = #jsc.#7rc(list2, #Xrb2, #Yrb2);
					IList<Point> list4;
					if (5 != 0)
					{
						list4 = list3;
					}
					if (list4 != null && list4.Any<Point>())
					{
						while (DrawPolygonTool.#szb(#tzb, list2))
						{
							if (list4.Count > 2)
							{
								return false;
							}
							if (#tzb == null && list2.Count == 3 && #jsc.#Src(list2[0], list2[1], list2[2]))
							{
								return false;
							}
							bool flag2 = list4.All(new Func<Point, bool>(#EZb2.#gad));
							if (3 != 0)
							{
								flag3 = flag2;
							}
							if (!flag3 || list4.Count != 2)
							{
								return flag3;
							}
							if (!false)
							{
								flag4 = (flag = list4.Any(new Func<Point, bool>(#EZb2.#p8b)));
								if (!false)
								{
									goto Block_13;
								}
								goto IL_28;
							}
						}
						return false;
					}
					if (5 != 0)
					{
						return true;
					}
					IL_2A:
					if (this.#b.Contains(#tzb.Value))
					{
						return false;
					}
					goto IL_40;
				}
			}
			return false;
			Block_13:
			flag3 = flag4;
			return flag3;
		}

		// Token: 0x06006393 RID: 25491 RVA: 0x00185590 File Offset: 0x00183790
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catch unexpected errors.")]
		protected void #nOc(bool #AOc)
		{
			try
			{
				#bDc #bDc = base.UndoManager;
				if (!false)
				{
					#bDc.#uCc();
				}
				List<Point3D> list = PointsConverter.#Csc(this.#b, 0.0);
				List<Point3D> #wsc;
				if (!false)
				{
					#wsc = list;
				}
				if (this.ToolDrawingMode == ToolDrawingMode.Union)
				{
					if (!base.ToolOperationsHelper.#0Dc(#wsc, PolygonType.Undefined))
					{
						throw new #vYd(#Phc.#3hc(107445582), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
					}
				}
				else if (this.ToolDrawingMode == ToolDrawingMode.Cut && !base.ToolOperationsHelper.#VDc(#wsc, base.ToolContext.ToolsConfiguration.LeaveCuttingPolygon, PolygonType.Undefined))
				{
					throw new #vYd(#Phc.#3hc(107445561), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
				}
				if (3 != 0)
				{
					this.#zIc();
				}
				base.ToolOperationsHelper.#bEc();
				if (!false)
				{
					base.#MIc();
				}
			}
			catch (ModelValidationException #PIc)
			{
				do
				{
					base.#OIc(#PIc);
				}
				while (false);
			}
			catch (#vYd #3Pb)
			{
				base.#2Pb(#3Pb);
			}
			catch (Exception #ob)
			{
				do
				{
					base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107445780), base.ToolInfo);
				}
				while (-1 == 0);
				base.UndoManager.#yCc(false);
			}
			finally
			{
				this.#1kb();
				if (6 == 0)
				{
					goto IL_130;
				}
				if (!#AOc)
				{
					goto IL_125;
				}
				IL_113:
				base.PreciseInputProvider.Update(this.#DNc(false));
				IL_125:
				base.UndoManager.#vCc();
				IL_130:
				if (false)
				{
					goto IL_113;
				}
			}
		}

		// Token: 0x06006394 RID: 25492 RVA: 0x00185738 File Offset: 0x00183938
		protected #Atc #Mrc(Point3D #Kzb)
		{
			Point3D? point3D = base.SnappingProvider.#Mrc(PointsConverter.#vsc(this.SelectedPoints).OrderBy(new Func<Point, double>(DrawPolygonTool.<>c.<>9.#had)).ThenBy(new Func<Point, double>(DrawPolygonTool.<>c.<>9.#iad)).ToList<Point>(), #Kzb, base.SnappingProvider.MaxDistance, this.#e, base.ProjectContext.MainModel.WorkspaceBoundingBoxData);
			Point3D? point3D2;
			if (3 != 0)
			{
				point3D2 = point3D;
			}
			int num = (point3D2 != null) ? 1 : 0;
			while (num != 0)
			{
				int num2 = num = 2;
				if (num2 != 0)
				{
					return new #Atc((#huc)num2, point3D2.Value);
				}
			}
			return base.SnappingProvider.#Mrc(base.ProjectContext.SnappingModes, #Kzb, this.#e, base.ProjectContext.MainModel.WorkspaceBoundingBoxData);
		}

		// Token: 0x06006395 RID: 25493 RVA: 0x00185818 File Offset: 0x00183A18
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			if (7 != 0)
			{
				if (!false)
				{
					if (5 != 0)
					{
						base.#fzb(#HAb, #gzb);
					}
					if (this.ToolState == DrawPolygonTool.#fad.#a)
					{
						if (false)
						{
							goto IL_1E;
						}
						this.#wzb(#HAb);
						goto IL_1E;
					}
				}
				if (this.ToolState == DrawPolygonTool.#fad.#b)
				{
					this.#yOc(#HAb);
				}
			}
			IL_1E:
			if (#gzb)
			{
				#jUc #jUc = base.PreciseInputProvider;
				PreciseInputParameters initializeInputParameters = this.#DNc(false);
				if (3 != 0)
				{
					#jUc.Update(initializeInputParameters);
				}
			}
		}

		// Token: 0x06006396 RID: 25494 RVA: 0x00185880 File Offset: 0x00183A80
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			if (3 != 0)
			{
				base.#HEc(#IEc, #Kzb);
			}
			bool flag;
			Point3D? point3D;
			#Atc #Atc2;
			if (this.ToolState == DrawPolygonTool.#fad.#a)
			{
				flag = this.DrawOnlyInWorkspace;
			}
			else
			{
				if (true)
				{
					point3D = new Point3D?(#Kzb);
				}
				if (this.DrawOnlyInWorkspace)
				{
					Point3D? point3D2 = base.ToolOperationsHelper.#9Dc(this.#e, #Kzb);
					if (5 != 0)
					{
						point3D = point3D2;
					}
					bool flag2 = flag = (point3D != null);
					if (2 == 0)
					{
						goto IL_1A;
					}
					if (!flag2)
					{
						return;
					}
				}
				if (base.IsOrthogonalModeEnabled)
				{
					#Atc #Atc = this.#Mrc(point3D.Value);
					base.SnapPointsMarker.Mark(#Atc);
					this.LastSnappedPosition = #Atc.Point;
					this.#BOc(new Point3D(#Atc.Point.X, #Atc.Point.Y, 0.0));
					return;
				}
				#Atc2 = this.#bNb(point3D.Value);
				goto IL_10C;
			}
			IL_1A:
			if (!flag || base.ToolOperationsHelper.#8Dc(new Point3D?(#Kzb)))
			{
				if (false)
				{
					goto IL_10C;
				}
				#Atc #Atc3 = this.#bNb(#Kzb);
				#Atc #Atc4;
				if (!false)
				{
					#Atc4 = #Atc3;
				}
				ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
				#Atc snapToPointResult = #Atc4;
				if (-1 != 0)
				{
					snapPointsMarker.Mark(snapToPointResult);
				}
				Point3D point3D3 = #Atc4.Point;
				if (true)
				{
					this.LastSnappedPosition = point3D3;
				}
			}
			return;
			IL_10C:
			base.SnapPointsMarker.Mark(#Atc2);
			this.LastSnappedPosition = #Atc2.Point;
			this.#BOc(point3D.Value);
		}

		// Token: 0x06006397 RID: 25495 RVA: 0x00050F49 File Offset: 0x0004F149
		protected override void #CEc(MouseButtonEventArgs #4kb)
		{
			this.#zOc();
		}

		// Token: 0x06006398 RID: 25496 RVA: 0x001859F4 File Offset: 0x00183BF4
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			Point3D? point3D = base.#HIc(#4kb);
			Point3D? point3D2;
			if (5 != 0)
			{
				point3D2 = point3D;
			}
			if (point3D2 == null)
			{
				return;
			}
			bool flag2;
			if (this.ToolState == DrawPolygonTool.#fad.#b && this.DrawOnlyInWorkspace)
			{
				Point3D? point3D3 = base.ToolOperationsHelper.#9Dc(this.#b.Last<Point3D>(), point3D2.Value);
				if (2 != 0)
				{
					point3D2 = point3D3;
				}
				bool flag = flag2 = (point3D2 != null);
				if (3 == 0)
				{
					goto IL_D1;
				}
				if (!flag)
				{
					return;
				}
			}
			if (!base.IsOrthogonalModeEnabled)
			{
				goto IL_E5;
			}
			IL_65:
			if (this.ToolState != DrawPolygonTool.#fad.#b)
			{
				goto IL_E5;
			}
			#Atc #Atc = this.#Mrc(point3D2.Value);
			#Atc #Atc2;
			if (true)
			{
				#Atc2 = #Atc;
			}
			Point3D point3D4 = #Atc2.Point;
			Point3D point3D5;
			if (3 != 0)
			{
				point3D5 = point3D4;
			}
			double x = point3D5.X;
			Point3D point3D6 = #Atc2.Point;
			if (!false)
			{
				point3D5 = point3D6;
			}
			Point3D value = new Point3D(x, point3D5.Y, 0.0);
			Point3D? #HAb;
			if (!false)
			{
				#HAb = new Point3D?(value);
			}
			if (#HAb == null)
			{
				return;
			}
			flag2 = this.DrawOnlyInWorkspace;
			IL_D1:
			if (!flag2)
			{
				goto IL_118;
			}
			IL_D3:
			if (false)
			{
				goto IL_65;
			}
			if (base.ToolOperationsHelper.#8Dc(#HAb))
			{
				goto IL_118;
			}
			return;
			IL_E5:
			#HAb = this.#bNb(point3D2.Value).#Dtc();
			if (#HAb == null || (this.DrawOnlyInWorkspace && !base.ToolOperationsHelper.#8Dc(#HAb)))
			{
				return;
			}
			IL_118:
			if (-1 != 0)
			{
				this.LastSnappedPosition = #HAb.Value;
				if (6 == 0)
				{
					goto IL_D3;
				}
				Point3D value2 = #HAb.Value;
				this.#fzb(value2, false);
			}
		}

		// Token: 0x06006399 RID: 25497 RVA: 0x00185B68 File Offset: 0x00183D68
		protected override void #fIc(PreciseInputChangedEventArgs #gIc)
		{
			if (#gIc == null)
			{
				return;
			}
			Point3D? point3D = #aJc.#9Ic(#gIc);
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			if (6 != 0 && point3D2 != null)
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#c;
				if (!false)
				{
					modelEditorControl.AddToView(drawingResult);
				}
				ICrossIndicatorDrawingResult crossIndicatorDrawingResult = this.#c;
				Point3D value = point3D2.Value;
				if (8 != 0)
				{
					crossIndicatorDrawingResult.CenterPoint = value;
				}
				Point3D value2 = point3D2.Value;
				if (!false)
				{
					this.#BOc(value2);
				}
			}
		}

		// Token: 0x0600639A RID: 25498 RVA: 0x00185BD8 File Offset: 0x00183DD8
		protected override void #iIc(PreciseInputCompletedEventArgs #jIc)
		{
			Point3D? point3D2;
			if (!false)
			{
				Point3D? point3D = #aJc.#9Ic(#jIc);
				if (!false)
				{
					point3D2 = point3D;
				}
			}
			do
			{
				if (point3D2 != null)
				{
					Point3D value = point3D2.Value;
					bool #gzb = true;
					if (!false)
					{
						this.#fzb(value, #gzb);
					}
				}
			}
			while (false);
		}

		// Token: 0x0600639B RID: 25499 RVA: 0x00050F52 File Offset: 0x0004F152
		protected override void #GIc()
		{
			do
			{
				if (true && !false)
				{
					ICrossIndicatorDrawingResult #LIc = this.#c;
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

		// Token: 0x0600639C RID: 25500 RVA: 0x00050F89 File Offset: 0x0004F189
		protected override void #hIc()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#c;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
		}

		// Token: 0x0600639D RID: 25501 RVA: 0x00050FA3 File Offset: 0x0004F1A3
		protected override void #JEc(CameraDistanceChangedEventArgs #KEc)
		{
			if (#KEc == null)
			{
				return;
			}
			ICrossIndicatorDrawingResult #LIc = this.#c;
			if (!false)
			{
				base.#AIc(#LIc);
			}
		}

		// Token: 0x0600639E RID: 25502 RVA: 0x00050FBC File Offset: 0x0004F1BC
		protected override void #cIc()
		{
			for (;;)
			{
				if (this.ToolState != DrawPolygonTool.#fad.#b)
				{
					goto IL_29;
				}
				IL_09:
				if (6 == 0)
				{
					continue;
				}
				#V0c #V0c = base.ModelEditorViewModel;
				Point3D #k0c = this.#e;
				BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
				if (2 != 0)
				{
					#V0c.#j0c(#k0c, #Prc);
				}
				IL_29:
				if (!false)
				{
					break;
				}
				goto IL_09;
			}
		}

		// Token: 0x0600639F RID: 25503 RVA: 0x00050FF1 File Offset: 0x0004F1F1
		protected override void #dIc()
		{
			#V0c #V0c = base.ModelEditorViewModel;
			if (!false)
			{
				#V0c.#l0c();
			}
		}

		// Token: 0x060063A0 RID: 25504 RVA: 0x00185C18 File Offset: 0x00183E18
		protected override void #eIc()
		{
			if (!false)
			{
				base.#eIc();
			}
			if (!base.SettingsProvider.IsOrthogonalModeEnabled)
			{
				goto IL_3C;
			}
			IL_12:
			while (this.ToolState == DrawPolygonTool.#fad.#b)
			{
				if (!false)
				{
					#V0c #V0c = base.ModelEditorViewModel;
					Point3D #k0c = this.#e;
					BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
					if (!true)
					{
						return;
					}
					#V0c.#j0c(#k0c, #Prc);
					return;
				}
			}
			IL_3C:
			if (5 == 0)
			{
				goto IL_12;
			}
			#V0c #V0c2 = base.ModelEditorViewModel;
			if (!false)
			{
				#V0c2.#l0c();
			}
			if (2 != 0)
			{
				return;
			}
		}

		// Token: 0x060063A1 RID: 25505 RVA: 0x00050E8C File Offset: 0x0004F08C
		protected #Atc #bNb(Point3D #Kzb)
		{
			return base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, #Kzb);
		}

		// Token: 0x060063A2 RID: 25506 RVA: 0x00185C88 File Offset: 0x00183E88
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
			#GJc.VisualCoordinate = this.#KIc();
			#GJc.IsInitialCoordinate = true;
			#GJc.CoordinateValidator = this;
			#GJc.ResetCurrentValues = #ENc;
			#GJc.RelativeCoordinate = base.#IIc();
			#GJc.Message = this.#g[this.ToolState];
			#oW #oW = base.ProjectContext;
			if (8 != 0)
			{
				#GJc.ProjectContext = #oW;
			}
			return #aJc.#7Ic(#GJc);
		}

		// Token: 0x060063A3 RID: 25507 RVA: 0x00185D38 File Offset: 0x00183F38
		private void #BOc(Point3D #Ng)
		{
			if (this.DrawPreview && this.ToolState == DrawPolygonTool.#fad.#b)
			{
				ILinesDrawingResultBase linesDrawingResultBase = this.#a;
				IEnumerable<Point3D> positions = PointsConverter.#Bsc(new Point3D[]
				{
					this.#e,
					#Ng
				}, 0.032);
				if (4 != 0)
				{
					linesDrawingResultBase.Positions = positions;
				}
			}
		}

		// Token: 0x060063A4 RID: 25508 RVA: 0x00185D94 File Offset: 0x00183F94
		private static bool #szb(Point3D? #tzb, IList<Point> #uzb)
		{
			while (#tzb != null)
			{
				Point point = PointsConverter.#vsc(#tzb.Value);
				Point #Ng;
				if (5 != 0)
				{
					#Ng = point;
				}
				if (false)
				{
					break;
				}
				IEnumerator<SegmentData> enumerator = #jsc.#Rrc(#uzb).GetEnumerator();
				IEnumerator<SegmentData> enumerator2;
				if (5 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						SegmentData segmentData = enumerator2.Current;
						SegmentData segmentData2;
						if (4 != 0)
						{
							segmentData2 = segmentData;
						}
						if (#jsc.#Src(segmentData2, #Ng))
						{
							bool flag = false;
							if (3 != 0)
							{
								bool flag2 = flag;
							}
							goto IL_C4;
						}
						if (!false)
						{
							SegmentData #Urc = segmentData2;
							Point startPoint = #uzb.Last<Point>();
							Point3D value = #tzb.Value;
							Point3D point3D;
							if (true)
							{
								point3D = value;
							}
							double xField = point3D.X;
							Point3D value2 = #tzb.Value;
							if (!false)
							{
								point3D = value2;
							}
							if (!#jsc.#Trc(#Urc, new SegmentData(startPoint, new Point(xField, point3D.Y)), true))
							{
								continue;
							}
							bool flag2 = false;
						}
						goto IL_C4;
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				break;
				IL_C4:
				if (4 != 0)
				{
					bool flag2;
					bool result2;
					bool result = result2 = flag2;
					if (8 != 0)
					{
						return result;
					}
					return result2;
				}
			}
			return true;
		}

		// Token: 0x060063A5 RID: 25509 RVA: 0x00185E8C File Offset: 0x0018408C
		private void #COc()
		{
			if (this.#b.Count < 2)
			{
				if (!false)
				{
					return;
				}
			}
			else
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#d;
				if (true)
				{
					modelEditorControl.AddToView(drawingResult);
				}
				List<Point3D> list2;
				for (;;)
				{
					int num2;
					if (!false)
					{
						List<Point3D> list = new List<Point3D>();
						if (4 != 0)
						{
							list2 = list;
						}
						int num = 1;
						if (2 != 0)
						{
							num2 = num;
						}
					}
					for (;;)
					{
						while (3 != 0)
						{
							if (6 != 0)
							{
								if (num2 >= this.#b.Count)
								{
									goto Block_6;
								}
								List<Point3D> list3 = list2;
								Point3D item = this.#b[num2 - 1];
								if (true)
								{
									list3.Add(item);
								}
								List<Point3D> list4 = list2;
								Point3D item2 = this.#b[num2];
								if (!false)
								{
									list4.Add(item2);
								}
								int num3 = num2 + 1;
								if (6 != 0)
								{
									num2 = num3;
								}
							}
						}
						break;
					}
				}
				Block_6:
				this.#d.Positions = PointsConverter.#Bsc(list2, 0.032);
			}
		}

		// Token: 0x060063A6 RID: 25510 RVA: 0x00185F5C File Offset: 0x0018415C
		private void #DOc(Point3D #Xrb)
		{
			if (!this.DrawPreview)
			{
				return;
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#a;
			if (3 != 0)
			{
				modelEditorControl.AddToView(drawingResult);
			}
			ILinesDrawingResultBase linesDrawingResultBase = this.#a;
			IEnumerable<Point3D> positions = PointsConverter.#Bsc(new Point3D[]
			{
				#Xrb,
				new Point3D(#Xrb.X + 0.1, #Xrb.Y, #Xrb.Z)
			}, 0.032);
			if (!false)
			{
				linesDrawingResultBase.Positions = positions;
			}
		}

		// Token: 0x060063A7 RID: 25511 RVA: 0x00051004 File Offset: 0x0004F204
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#h;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x060063A8 RID: 25512 RVA: 0x00051019 File Offset: 0x0004F219
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

		// Token: 0x040028D3 RID: 10451
		private readonly IPolylineDrawingResult #a;

		// Token: 0x040028D4 RID: 10452
		private readonly List<Point3D> #b = new List<Point3D>();

		// Token: 0x040028D5 RID: 10453
		private readonly ICrossIndicatorDrawingResult #c;

		// Token: 0x040028D6 RID: 10454
		private readonly IPolylineDrawingResult #d;

		// Token: 0x040028D7 RID: 10455
		private Point3D #e;

		// Token: 0x040028D8 RID: 10456
		private ToolDrawingMode #f;

		// Token: 0x040028D9 RID: 10457
		private readonly IDictionary<DrawPolygonTool.#fad, string> #g;

		// Token: 0x040028DA RID: 10458
		private readonly Cursor #h;

		// Token: 0x040028DB RID: 10459
		[CompilerGenerated]
		private bool #i;

		// Token: 0x040028DC RID: 10460
		[CompilerGenerated]
		private DrawPolygonTool.#fad #j;

		// Token: 0x040028DD RID: 10461
		[CompilerGenerated]
		private Point3D #k;

		// Token: 0x040028DE RID: 10462
		[CompilerGenerated]
		private bool #l;

		// Token: 0x02000BF5 RID: 3061
		protected enum #fad
		{
			// Token: 0x040028E0 RID: 10464
			#a,
			// Token: 0x040028E1 RID: 10465
			#b
		}

		// Token: 0x02000BF7 RID: 3063
		[CompilerGenerated]
		private sealed class #EZb
		{
			// Token: 0x060063AE RID: 25518 RVA: 0x00051041 File Offset: 0x0004F241
			internal bool #gad(Point #Ng)
			{
				if (!false)
				{
					int num = PointsConverter.#uC(#Ng, this.#a) ? 1 : 0;
					while (num != 0 && 3 != 0)
					{
						int num2 = num = 1;
						if (num2 != 0)
						{
							return num2 != 0;
						}
					}
				}
				return PointsConverter.#uC(#Ng, this.#b);
			}

			// Token: 0x060063AF RID: 25519 RVA: 0x00051068 File Offset: 0x0004F268
			internal bool #p8b(Point #Ng)
			{
				return PointsConverter.#uC(#Ng, this.#c.#b[0]);
			}

			// Token: 0x040028E5 RID: 10469
			public Point3D #a;

			// Token: 0x040028E6 RID: 10470
			public Point3D #b;

			// Token: 0x040028E7 RID: 10471
			public DrawPolygonTool #c;
		}
	}
}
