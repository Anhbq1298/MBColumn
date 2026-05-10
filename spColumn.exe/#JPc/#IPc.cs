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
using #hTb;
using #IDc;
using #NWc;
using #T0c;
using #v1c;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Framework;
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

namespace #JPc
{
	// Token: 0x02000C0B RID: 3083
	internal sealed class #IPc : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #9Tc, #LPc
	{
		// Token: 0x06006447 RID: 25671 RVA: 0x00188E24 File Offset: 0x00187024
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "IoC")]
		public #IPc(#6Ic #JDc) : base(#JDc)
		{
			base.Header = Strings.StringDrawCircleBySelectingTwoPointsOnDiameter;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.DrawCircleBySelectingTwoPointsOnDiameter);
			this.ToolState = #IPc.#kad.#a;
			this.PlanarApproximatedCircleVisual3D = base.ToolContext.DrawingResultsFactory.CreatePlanarCircleDrawingResult(true);
			this.#a = base.ToolContext.DrawingResultsFactory.CreateCrossIndicatorDrawingResult();
			this.#d = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			this.#f = new Dictionary<#IPc.#kad, string>();
			this.#f[#IPc.#kad.#a] = Strings.StringSelectStartPoint.#z2d();
			this.#f[#IPc.#kad.#b] = Strings.StringSelectEndPoint.#z2d();
			base.HelpId = HelpIdentifiers.ToolDrawCircleOnDiameter;
			this.DrawOnlyInWorkspace = true;
			this.DrawPreviewToSnappedPoint = false;
			base.IsOrthogonalModeSupported = true;
		}

		// Token: 0x17001C28 RID: 7208
		// (get) Token: 0x06006448 RID: 25672 RVA: 0x00051472 File Offset: 0x0004F672
		// (set) Token: 0x06006449 RID: 25673 RVA: 0x0005147A File Offset: 0x0004F67A
		protected IPlanarCircleDrawingResult PlanarApproximatedCircleVisual3D { get; set; }

		// Token: 0x17001C29 RID: 7209
		// (get) Token: 0x0600644A RID: 25674 RVA: 0x00051483 File Offset: 0x0004F683
		// (set) Token: 0x0600644B RID: 25675 RVA: 0x0005148B File Offset: 0x0004F68B
		private protected #IPc.#kad ToolState { protected get; private set; }

		// Token: 0x17001C2A RID: 7210
		// (get) Token: 0x0600644C RID: 25676 RVA: 0x00051494 File Offset: 0x0004F694
		// (set) Token: 0x0600644D RID: 25677 RVA: 0x0005149C File Offset: 0x0004F69C
		private protected Point3D? SelectedStartPoint { protected get; private set; }

		// Token: 0x17001C2B RID: 7211
		// (get) Token: 0x0600644E RID: 25678 RVA: 0x000514A5 File Offset: 0x0004F6A5
		// (set) Token: 0x0600644F RID: 25679 RVA: 0x000514AD File Offset: 0x0004F6AD
		protected Point3D LastSnappedPosition { get; set; }

		// Token: 0x17001C2C RID: 7212
		// (get) Token: 0x06006450 RID: 25680 RVA: 0x000514B6 File Offset: 0x0004F6B6
		// (set) Token: 0x06006451 RID: 25681 RVA: 0x000514BE File Offset: 0x0004F6BE
		protected bool DrawPreviewToSnappedPoint { get; set; }

		// Token: 0x17001C2D RID: 7213
		// (get) Token: 0x06006452 RID: 25682 RVA: 0x000514C7 File Offset: 0x0004F6C7
		// (set) Token: 0x06006453 RID: 25683 RVA: 0x000514CF File Offset: 0x0004F6CF
		protected bool DrawOnlyInWorkspace { get; set; }

		// Token: 0x06006454 RID: 25684 RVA: 0x00188F1C File Offset: 0x0018711C
		public override void #5b()
		{
			if (!false)
			{
				base.#5b();
			}
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[4];
			RuntimeFieldHandle fldHandle = fieldof(#l8c.#c).FieldHandle;
			if (4 != 0)
			{
				RuntimeHelpers.InitializeArray(array, fldHandle);
			}
			if (4 != 0)
			{
				base.#FIc(array);
			}
			IPlanarCircleDrawingResult planarCircleDrawingResult = this.PlanarApproximatedCircleVisual3D;
			Color? lineColor = new Color?(base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeColor);
			if (!false)
			{
				planarCircleDrawingResult.LineColor = lineColor;
			}
			IPlanarCircleDrawingResult planarCircleDrawingResult2 = this.PlanarApproximatedCircleVisual3D;
			Color color = base.SettingsProvider.VisualizationDrawingToolNewFigureFillColor;
			if (4 != 0)
			{
				planarCircleDrawingResult2.Color = color;
			}
			IPlanarCircleDrawingResult planarCircleDrawingResult3 = this.PlanarApproximatedCircleVisual3D;
			double lineThickness = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeThickness;
			if (4 != 0)
			{
				planarCircleDrawingResult3.LineThickness = lineThickness;
			}
			this.PlanarApproximatedCircleVisual3D.NumberOfSides = this.NumberOfSides;
			#8Ib.#HJc(base.SnapPointsMarker, base.SettingsProvider);
			base.#AIc(this.#a);
			base.ModelEditorControl.SetCursor(this.#d, false);
			base.RaisePropertyChanged(null);
		}

		// Token: 0x06006455 RID: 25685 RVA: 0x00189020 File Offset: 0x00187220
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
			IDrawingResult drawingResult = this.#a;
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

		// Token: 0x06006456 RID: 25686 RVA: 0x0018908C File Offset: 0x0018728C
		public override void #1kb()
		{
			#IPc.#kad #kad = #IPc.#kad.#a;
			if (8 != 0)
			{
				this.ToolState = #kad;
			}
			this.#b = null;
			Point3D? point3D = null;
			if (!false)
			{
				this.SelectedStartPoint = point3D;
			}
			bool isWorking = false;
			if (!false)
			{
				base.IsWorking = isWorking;
			}
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = null;
			if (!false)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.PlanarApproximatedCircleVisual3D;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			#V0c #V0c = base.ModelEditorViewModel;
			if (true)
			{
				#V0c.#l0c();
			}
			base.#1kb();
		}

		// Token: 0x06006457 RID: 25687 RVA: 0x0018911C File Offset: 0x0018731C
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			if (!false)
			{
				base.#fzb(#HAb, #gzb);
			}
			bool flag2;
			while (5 != 0)
			{
				bool flag = false;
				if (!false)
				{
					flag2 = flag;
				}
				if (this.ToolState == #IPc.#kad.#a)
				{
					if (!false)
					{
						this.#wzb(#HAb, #gzb);
					}
					if (!false)
					{
						bool flag3 = true;
						if (!false)
						{
							flag2 = flag3;
						}
						break;
					}
				}
				else
				{
					bool flag4 = this.#jOc(#HAb);
					if (7 == 0)
					{
						break;
					}
					flag2 = flag4;
					break;
				}
			}
			if (#gzb && flag2 && 6 != 0)
			{
				#jUc #jUc = base.PreciseInputProvider;
				PreciseInputParameters initializeInputParameters = this.#DNc(false);
				if (!false)
				{
					#jUc.Update(initializeInputParameters);
				}
			}
		}

		// Token: 0x06006458 RID: 25688 RVA: 0x00189198 File Offset: 0x00187398
		protected void #wzb(Point3D #HAb, bool #gzb)
		{
			Point3D? point3D = new Point3D?(#HAb);
			if (!false)
			{
				this.SelectedStartPoint = point3D;
			}
			this.#b = new Point?(PointsConverter.#vsc(#HAb));
			IPlanarCircleDrawingResult planarCircleDrawingResult = this.PlanarApproximatedCircleVisual3D;
			Point3D? point3D2 = this.SelectedStartPoint;
			Point3D? point3D3;
			if (!false)
			{
				point3D3 = point3D2;
			}
			Point3D center = PointsConverter.#Bsc(point3D3.Value, 0.032);
			if (!false)
			{
				planarCircleDrawingResult.Center = center;
			}
			#IPc.#kad #kad = #IPc.#kad.#b;
			if (3 != 0)
			{
				this.ToolState = #kad;
			}
			if (#gzb)
			{
				Point3D #HAb2 = new Point3D(#HAb.X + 0.0001, #HAb.Y, #HAb.Z);
				if (3 != 0)
				{
					this.#5Oc(#HAb2);
				}
			}
			if (base.IsOrthogonalModeEnabled)
			{
				#V0c #V0c = base.ModelEditorViewModel;
				Point3D #k0c = #HAb;
				BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
				if (6 != 0)
				{
					#V0c.#j0c(#k0c, #Prc);
				}
			}
		}

		// Token: 0x06006459 RID: 25689 RVA: 0x000514D8 File Offset: 0x0004F6D8
		protected bool #jOc(Point3D #HAb)
		{
			if (this.#3Oc(#HAb))
			{
				if (!false)
				{
					this.#nOc();
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600645A RID: 25690 RVA: 0x00189270 File Offset: 0x00187470
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			while (!false)
			{
				this.#g = true;
				if (7 != 0)
				{
					if (this.ToolState != #IPc.#kad.#a)
					{
						if (8 != 0)
						{
							return;
						}
						return;
					}
					else
					{
						#R2c #R2c = base.ToolContext.MouseAndKeyboardService;
						if (false)
						{
							break;
						}
						#R2c.#mNb();
						break;
					}
				}
			}
			Point3D? point3D = base.#HIc(#4kb);
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			if (point3D2 == null)
			{
				return;
			}
			Point3D? point3D3 = this.#aPc(point3D2.Value);
			Point3D? #HAb;
			if (!false)
			{
				#HAb = point3D3;
			}
			bool flag2;
			bool flag = flag2 = (#HAb != null);
			if (4 != 0)
			{
				if (!flag)
				{
					return;
				}
				flag2 = this.DrawOnlyInWorkspace;
			}
			if (flag2 && !base.ToolOperationsHelper.#8Dc(#HAb))
			{
				return;
			}
			Point3D value = #HAb.Value;
			bool #gzb = false;
			if (5 != 0)
			{
				this.#fzb(value, #gzb);
			}
			bool isWorking = true;
			if (!false)
			{
				base.IsWorking = isWorking;
			}
		}

		// Token: 0x0600645B RID: 25691 RVA: 0x00189324 File Offset: 0x00187524
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			while (this.#g)
			{
				this.#g = false;
				if (!false)
				{
					if (this.ToolState != #IPc.#kad.#b)
					{
						return;
					}
					Point3D? point3D7;
					if (4 != 0)
					{
						#R2c #R2c = base.ToolContext.MouseAndKeyboardService;
						if (-1 != 0)
						{
							#R2c.#mNb();
						}
						Point3D? point3D = this.SelectedStartPoint;
						Point3D? point3D2;
						if (4 != 0)
						{
							point3D2 = point3D;
						}
						bool flag = point3D2 != null;
						while (flag)
						{
							Point3D? point3D3 = base.#HIc(#4kb);
							Point3D? point3D4;
							if (!false)
							{
								point3D4 = point3D3;
							}
							if (point3D4 == null)
							{
								return;
							}
							if (this.DrawOnlyInWorkspace)
							{
								Point3D? point3D5 = base.ToolOperationsHelper.#9Dc(this.PlanarApproximatedCircleVisual3D.Center, point3D4.Value);
								if (2 != 0)
								{
									point3D4 = point3D5;
								}
								if (point3D4 == null)
								{
									goto IL_93;
								}
							}
							Point3D? point3D6 = this.#aPc(point3D4.Value);
							if (6 != 0)
							{
								point3D7 = point3D6;
							}
							bool flag2 = flag = (point3D7 != null);
							if (3 != 0)
							{
								if (!flag2)
								{
									return;
								}
								goto IL_B8;
							}
						}
						return;
					}
					IL_93:
					if (!false)
					{
						return;
					}
					IL_B8:
					Point3D value = point3D7.Value;
					bool #gzb = false;
					if (-1 != 0)
					{
						this.#fzb(value, #gzb);
					}
					return;
				}
			}
		}

		// Token: 0x0600645C RID: 25692 RVA: 0x0018941C File Offset: 0x0018761C
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			if (7 != 0)
			{
				base.#HEc(#IEc, #Kzb);
			}
			if (!this.DrawOnlyInWorkspace || base.ToolOperationsHelper.#8Dc(new Point3D?(#Kzb)))
			{
				this.#aPc(#Kzb);
			}
			if (!false)
			{
				if (this.ToolState == #IPc.#kad.#b)
				{
					Point3D? point3D = this.SelectedStartPoint;
					Point3D? point3D2;
					if (3 != 0)
					{
						point3D2 = point3D;
					}
					bool flag = point3D2 != null;
					while (flag)
					{
						Point3D? point3D3;
						do
						{
							Point3D value = this.DrawPreviewToSnappedPoint ? this.LastSnappedPosition : #Kzb;
							if (!false)
							{
								point3D3 = new Point3D?(value);
							}
						}
						while (false);
						if (this.DrawOnlyInWorkspace)
						{
							Point3D? point3D4 = base.ToolOperationsHelper.#aEc(this.PlanarApproximatedCircleVisual3D.Center, point3D3.Value);
							if (!false)
							{
								point3D3 = point3D4;
							}
							bool flag2 = flag = (point3D3 != null);
							if (false)
							{
								continue;
							}
							if (!flag2)
							{
								return;
							}
						}
						Point3D value2 = point3D3.Value;
						if (false)
						{
							return;
						}
						this.#5Oc(value2);
						return;
					}
				}
				return;
			}
		}

		// Token: 0x0600645D RID: 25693 RVA: 0x001894F8 File Offset: 0x001876F8
		protected override void #fIc(PreciseInputChangedEventArgs #gIc)
		{
			if (!false)
			{
				Point3D? point3D = #aJc.#9Ic(#gIc);
				Point3D? point3D2;
				if (6 != 0)
				{
					point3D2 = point3D;
				}
				bool flag = point3D2 != null;
				if (8 != 0)
				{
					if (flag)
					{
						IModelEditorControl modelEditorControl = base.ModelEditorControl;
						IDrawingResult drawingResult = this.#a;
						if (6 != 0)
						{
							modelEditorControl.AddToView(drawingResult);
						}
						ICrossIndicatorDrawingResult crossIndicatorDrawingResult = this.#a;
						Point3D value = point3D2.Value;
						if (4 != 0)
						{
							crossIndicatorDrawingResult.CenterPoint = value;
						}
						if (!false)
						{
							if (this.ToolState == #IPc.#kad.#b)
							{
								this.#3Oc(point3D2.Value);
								goto IL_56;
							}
							return;
						}
					}
					return;
				}
				IL_56:;
			}
		}

		// Token: 0x0600645E RID: 25694 RVA: 0x00181EF4 File Offset: 0x001800F4
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

		// Token: 0x0600645F RID: 25695 RVA: 0x000514F2 File Offset: 0x0004F6F2
		protected override void #GIc()
		{
			do
			{
				if (true && !false)
				{
					ICrossIndicatorDrawingResult #LIc = this.#a;
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

		// Token: 0x06006460 RID: 25696 RVA: 0x00051529 File Offset: 0x0004F729
		protected override void #hIc()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#a;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
		}

		// Token: 0x06006461 RID: 25697 RVA: 0x00051543 File Offset: 0x0004F743
		protected override void #JEc(CameraDistanceChangedEventArgs #KEc)
		{
			if (#KEc == null)
			{
				return;
			}
			ICrossIndicatorDrawingResult #LIc = this.#a;
			if (!false)
			{
				base.#AIc(#LIc);
			}
		}

		// Token: 0x06006462 RID: 25698 RVA: 0x00189570 File Offset: 0x00187770
		protected override void #cIc()
		{
			if (this.ToolState == #IPc.#kad.#b)
			{
				Point3D? point3D2;
				if (!false)
				{
					Point3D? point3D = this.SelectedStartPoint;
					if (!false)
					{
						point3D2 = point3D;
					}
				}
				while (point3D2 != null)
				{
					if (!false)
					{
						#V0c #V0c = base.ModelEditorViewModel;
						Point3D? point3D3 = this.SelectedStartPoint;
						if (!false)
						{
							point3D2 = point3D3;
						}
						Point3D value = point3D2.Value;
						BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
						if (false)
						{
							break;
						}
						#V0c.#j0c(value, #Prc);
						break;
					}
				}
			}
		}

		// Token: 0x06006463 RID: 25699 RVA: 0x00050FF1 File Offset: 0x0004F1F1
		protected override void #dIc()
		{
			#V0c #V0c = base.ModelEditorViewModel;
			if (!false)
			{
				#V0c.#l0c();
			}
		}

		// Token: 0x06006464 RID: 25700 RVA: 0x001895D4 File Offset: 0x001877D4
		protected override void #eIc()
		{
			if (4 == 0)
			{
				goto IL_24;
			}
			if (!false)
			{
				base.#eIc();
			}
			IL_08:
			while (!false && base.SettingsProvider.IsOrthogonalModeEnabled)
			{
				if (!false)
				{
					if (this.ToolState == #IPc.#kad.#b)
					{
						goto IL_24;
					}
					break;
				}
			}
			goto IL_63;
			IL_24:
			Point3D? point3D = this.SelectedStartPoint;
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			if (point3D2 != null)
			{
				if (!false)
				{
					#V0c #V0c = base.ModelEditorViewModel;
					Point3D? point3D3 = this.SelectedStartPoint;
					if (7 != 0)
					{
						point3D2 = point3D3;
					}
					Point3D value = point3D2.Value;
					BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
					if (4 != 0)
					{
						#V0c.#j0c(value, #Prc);
					}
					return;
				}
				goto IL_08;
			}
			IL_63:
			#V0c #V0c2 = base.ModelEditorViewModel;
			if (!false)
			{
				#V0c2.#l0c();
			}
		}

		// Token: 0x06006465 RID: 25701 RVA: 0x0018966C File Offset: 0x0018786C
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catch unexpected errors.")]
		protected void #nOc()
		{
			List<Point3D> list2;
			if (8 != 0)
			{
				List<Point3D> list = null;
				if (!false)
				{
					list2 = list;
				}
				try
				{
					List<Point3D> list3 = PointsConverter.#Csc(this.PlanarApproximatedCircleVisual3D.CalculatePoints().ToList<Point3D>(), 0.0).ToList<Point3D>();
					if (6 != 0)
					{
						list2 = list3;
					}
				}
				catch (Exception #ob)
				{
					if (5 != 0)
					{
						base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107445117), base.ToolInfo);
					}
				}
			}
			if (list2 == null || list2.Count < PolygonData.MinNumberOfPoints)
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
				if (this.ToolDrawingMode == ToolDrawingMode.Union)
				{
					if (!base.ToolOperationsHelper.#0Dc(list2, PolygonType.Circle))
					{
						throw new #vYd(#Phc.#3hc(107445191), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
					}
				}
				else
				{
					if (false)
					{
						goto IL_F0;
					}
					if (this.ToolDrawingMode == ToolDrawingMode.Cut && !base.ToolOperationsHelper.#VDc(list2, base.ToolContext.ToolsConfiguration.LeaveCuttingPolygon, PolygonType.Circle) && !false)
					{
						throw new #vYd(#Phc.#3hc(107445170), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
					}
				}
				if (!false)
				{
					this.#zIc();
				}
				base.ToolOperationsHelper.#bEc();
				IL_F0:
				if (!false)
				{
					base.#MIc();
				}
			}
			catch (ModelValidationException #PIc)
			{
				base.#OIc(#PIc);
			}
			catch (#vYd #3Pb)
			{
				if (6 != 0)
				{
					base.#2Pb(#3Pb);
				}
			}
			catch (Exception #ob2)
			{
				base.ErrorsHandlingService.#bzc(#ob2, #Phc.#3hc(107445032), base.ToolInfo);
				base.UndoManager.#yCc(false);
			}
			finally
			{
				base.UndoManager.#vCc();
				this.#1kb();
			}
		}

		// Token: 0x06006466 RID: 25702 RVA: 0x00189824 File Offset: 0x00187A24
		protected bool #3Oc(Point3D #HAb)
		{
			int num2;
			Point point3;
			Point point5;
			double num4;
			if (this.#b == null)
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.PlanarApproximatedCircleVisual3D;
				if (2 != 0)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
				int num = num2 = 0;
				if (num == 0)
				{
					return num != 0;
				}
			}
			else
			{
				if (!true)
				{
					goto IL_111;
				}
				if (6 != 0)
				{
					Point point = PointsConverter.#vsc(#HAb);
					Point point2;
					if (!false)
					{
						point2 = point;
					}
					Point value = this.#b.Value;
					if (!false)
					{
						point3 = value;
					}
					Vector vector = Vector.#53d(Point.#H3d(point3, point2), 2.0);
					Vector #4Bb;
					if (3 != 0)
					{
						#4Bb = vector;
					}
					Point point4 = Point.#G3d(point2, #4Bb);
					if (-1 != 0)
					{
						point5 = point4;
					}
					double num3 = #4Bb.Length;
					double num5;
					do
					{
						if (!false)
						{
							num4 = num3;
						}
						num5 = (num3 = num4);
					}
					while (false);
					if (num5 <= PointsConverter.#b)
					{
						base.ModelEditorControl.RemoveFromView(this.PlanarApproximatedCircleVisual3D);
					}
					else if (!false)
					{
						num2 = (this.DrawOnlyInWorkspace ? 1 : 0);
						goto IL_B4;
					}
					return false;
				}
				goto IL_CB;
			}
			IL_B4:
			if (num2 == 0 || GeometryHelper.#coc(base.ModelEditorControl.EditorWorkspaceSize, point5, num4))
			{
				goto IL_111;
			}
			IL_CB:
			Point? point6;
			double? num6;
			if (!this.#6Oc(point3, point5, out point6, out num6) || num6 == null || point6 == null)
			{
				base.ModelEditorControl.RemoveFromView(this.PlanarApproximatedCircleVisual3D);
				return false;
			}
			num4 = num6.Value;
			point5 = point6.Value;
			IL_111:
			base.ModelEditorControl.AddToView(this.PlanarApproximatedCircleVisual3D);
			this.PlanarApproximatedCircleVisual3D.BeginEdit();
			this.PlanarApproximatedCircleVisual3D.Radius = num4;
			this.PlanarApproximatedCircleVisual3D.Center = PointsConverter.#vsc(point5, 0.032);
			this.PlanarApproximatedCircleVisual3D.EndEdit();
			return true;
		}

		// Token: 0x06006467 RID: 25703 RVA: 0x00050E8C File Offset: 0x0004F08C
		protected #Atc #bNb(Point3D #Kzb)
		{
			return base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, #Kzb);
		}

		// Token: 0x17001C2E RID: 7214
		// (get) Token: 0x06006468 RID: 25704 RVA: 0x0005155C File Offset: 0x0004F75C
		// (set) Token: 0x06006469 RID: 25705 RVA: 0x001899BC File Offset: 0x00187BBC
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "IoC")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "IoC")]
		public int NumberOfSides
		{
			get
			{
				return base.SettingsProvider.VisualizationCircleByDiameterToolNumberOfSides;
			}
			set
			{
				if (base.SettingsProvider.VisualizationCircleByDiameterToolNumberOfSides != value)
				{
					string propertyName = #Phc.#3hc(107453324);
					if (3 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					if (this.PlanarApproximatedCircleVisual3D != null)
					{
						IPlanarCircleDrawingResult planarCircleDrawingResult = this.PlanarApproximatedCircleVisual3D;
						if (8 != 0)
						{
							planarCircleDrawingResult.NumberOfSides = value;
						}
					}
					#6Gc #6Gc = base.SettingsProvider;
					if (4 != 0)
					{
						#6Gc.VisualizationCircleByDiameterToolNumberOfSides = value;
					}
					string propertyName2 = #Phc.#3hc(107453324);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001C2F RID: 7215
		// (get) Token: 0x0600646A RID: 25706 RVA: 0x00051569 File Offset: 0x0004F769
		// (set) Token: 0x0600646B RID: 25707 RVA: 0x00189A34 File Offset: 0x00187C34
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public ToolDrawingMode ToolDrawingMode
		{
			get
			{
				return this.#c;
			}
			set
			{
				for (;;)
				{
					if (this.#c == value)
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
						this.#c = value;
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

		// Token: 0x0600646C RID: 25708 RVA: 0x00051571 File Offset: 0x0004F771
		private void #5Oc(Point3D #HAb)
		{
			if (this.ToolState != #IPc.#kad.#b)
			{
				return;
			}
			this.#3Oc(#HAb);
		}

		// Token: 0x0600646D RID: 25709 RVA: 0x00189A88 File Offset: 0x00187C88
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
			#GJc.Message = this.#f[this.ToolState];
			#oW #oW = base.ProjectContext;
			if (8 != 0)
			{
				#GJc.ProjectContext = #oW;
			}
			return #aJc.#7Ic(#GJc);
		}

		// Token: 0x0600646E RID: 25710 RVA: 0x00188818 File Offset: 0x00186A18
		private static Point #qPc(Point #tEb, Point #Ng, double #rPc)
		{
			Vector vector = Point.#H3d(#tEb, #Ng);
			Vector #4Bb;
			if (!false)
			{
				#4Bb = vector;
			}
			return Point.#G3d(#Ng, Vector.#33d(#4Bb, #rPc));
		}

		// Token: 0x0600646F RID: 25711 RVA: 0x00189B38 File Offset: 0x00187D38
		private int #GPc(Point #tEb, Point #Ng)
		{
			#IPc.#T4b #T4b2;
			for (;;)
			{
				#IPc.#T4b #T4b = new #IPc.#T4b();
				if (7 != 0)
				{
					#T4b2 = #T4b;
				}
				while (!false)
				{
					#T4b2.#a = this;
					if (4 != 0)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
			#T4b2.#b = #tEb;
			#T4b2.#c = #Ng;
			return this.#e.#01d(new Func<int, int>(#T4b2.#pad));
		}

		// Token: 0x06006470 RID: 25712 RVA: 0x00189B84 File Offset: 0x00187D84
		private Point? #yPc(Point #tEb, Point #Ng)
		{
			int num = this.#GPc(#tEb, #Ng);
			int num2;
			if (!false)
			{
				num2 = num;
			}
			Vector #4Bb;
			if (num2 >= 0)
			{
				Vector vector = Point.#H3d(#tEb, #Ng);
				if (8 != 0)
				{
					#4Bb = vector;
				}
			}
			else
			{
				Point? result = null;
				if (3 != 0)
				{
					return result;
				}
			}
			return new Point?(Point.#G3d(#Ng, Vector.#33d(#4Bb, (double)num2 / (double)this.#e.Length)));
		}

		// Token: 0x06006471 RID: 25713 RVA: 0x00051585 File Offset: 0x0004F785
		private bool #6Oc(Point #Xrb, Point #Wjc, out Point? #8Oc, out double? #9Oc)
		{
			#8Oc = this.#yPc(#Xrb, #Wjc);
			if (#8Oc != null)
			{
				#9Oc = new double?(GeometryHelper.#lcb(#8Oc.Value, #Xrb));
				return true;
			}
			#9Oc = null;
			return false;
		}

		// Token: 0x06006472 RID: 25714 RVA: 0x00189BDC File Offset: 0x00187DDC
		private static Point #HPc(Point #mcb, Point #ncb)
		{
			Vector vector = Vector.#53d(Point.#H3d(#mcb, #ncb), 2.0);
			Vector #4Bb;
			if (!false)
			{
				#4Bb = vector;
			}
			return Point.#G3d(#ncb, #4Bb);
		}

		// Token: 0x06006473 RID: 25715 RVA: 0x00189C0C File Offset: 0x00187E0C
		private Point3D? #aPc(Point3D #Ng)
		{
			#Atc #Atc2;
			if ((false || base.IsOrthogonalModeEnabled) && this.ToolState == #IPc.#kad.#b)
			{
				Point3D? point3D = this.SelectedStartPoint;
				Point3D? point3D2;
				if (6 != 0)
				{
					point3D2 = point3D;
				}
				if (point3D2 != null)
				{
					#Qrc #Qrc = base.SnappingProvider;
					#hvc #Irc = base.ProjectContext.SnappingModes;
					Point3D? point3D3 = this.SelectedStartPoint;
					if (8 != 0)
					{
						point3D2 = point3D3;
					}
					#Atc #Atc = #Qrc.#Mrc(#Irc, #Ng, point3D2.Value, base.ProjectContext.MainModel.WorkspaceBoundingBoxData);
					if (5 != 0)
					{
						#Atc2 = #Atc;
					}
					goto IL_73;
				}
			}
			#Atc #Atc3 = this.#bNb(#Ng);
			if (3 != 0)
			{
				#Atc2 = #Atc3;
			}
			IL_73:
			Point3D point3D4 = #Atc2.Point;
			if (2 != 0)
			{
				this.LastSnappedPosition = point3D4;
			}
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = #Atc2;
			if (7 != 0)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			return new Point3D?(PointsConverter.#Csc(#Atc2.Point, 0.0));
		}

		// Token: 0x06006474 RID: 25716 RVA: 0x00189CDC File Offset: 0x00187EDC
		public string #vNc(#ivc #rmc, Point #Ng)
		{
			Point3D? point3D = this.SelectedStartPoint;
			Point3D? point3D2;
			if (8 != 0)
			{
				point3D2 = point3D;
			}
			if (!true)
			{
				goto IL_3D;
			}
			bool flag2;
			bool flag = flag2 = (point3D2 != null);
			if (false)
			{
				goto IL_6F;
			}
			Point #wob;
			if (flag && this.#b != null)
			{
				Point point = #IPc.#HPc(this.#b.Value, #Ng);
				if (false)
				{
					goto IL_3D;
				}
				#wob = point;
				goto IL_3D;
			}
			IL_26:
			return null;
			IL_3D:
			bool flag4;
			bool flag3 = flag4 = this.DrawOnlyInWorkspace;
			if (7 != 0)
			{
				if (!flag3)
				{
					goto IL_5D;
				}
				flag4 = CircleHelper.#qmc(#rmc, #wob, #Ng, base.StructuralModel.WorkspaceBoundingBoxData);
			}
			if (!flag4)
			{
				goto IL_71;
			}
			IL_5D:
			if (false)
			{
				goto IL_26;
			}
			if (this.DrawOnlyInWorkspace)
			{
				goto IL_7C;
			}
			flag2 = CircleHelper.#qmc(#wob, #Ng);
			IL_6F:
			if (flag2)
			{
				goto IL_7C;
			}
			IL_71:
			return Strings.StringCouldNotCreateCirleFromTheGivenParameters.#z2d();
			IL_7C:
			return null;
		}

		// Token: 0x06006475 RID: 25717 RVA: 0x000515C0 File Offset: 0x0004F7C0
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#d;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x06006476 RID: 25718 RVA: 0x000515D5 File Offset: 0x0004F7D5
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

		// Token: 0x0400291F RID: 10527
		private readonly ICrossIndicatorDrawingResult #a;

		// Token: 0x04002920 RID: 10528
		private Point? #b;

		// Token: 0x04002921 RID: 10529
		private ToolDrawingMode #c;

		// Token: 0x04002922 RID: 10530
		private readonly Cursor #d;

		// Token: 0x04002923 RID: 10531
		private readonly int[] #e = Enumerable.Range(0, 50000).ToArray<int>();

		// Token: 0x04002924 RID: 10532
		private readonly IDictionary<#IPc.#kad, string> #f;

		// Token: 0x04002925 RID: 10533
		private bool #g;

		// Token: 0x04002926 RID: 10534
		[CompilerGenerated]
		private IPlanarCircleDrawingResult #h;

		// Token: 0x04002927 RID: 10535
		[CompilerGenerated]
		private #IPc.#kad #i;

		// Token: 0x04002928 RID: 10536
		[CompilerGenerated]
		private Point3D? #j;

		// Token: 0x04002929 RID: 10537
		[CompilerGenerated]
		private Point3D #k;

		// Token: 0x0400292A RID: 10538
		[CompilerGenerated]
		private bool #l;

		// Token: 0x0400292B RID: 10539
		[CompilerGenerated]
		private bool #m;

		// Token: 0x02000C0C RID: 3084
		protected enum #kad
		{
			// Token: 0x0400292D RID: 10541
			#a,
			// Token: 0x0400292E RID: 10542
			#b
		}

		// Token: 0x02000C0D RID: 3085
		[CompilerGenerated]
		private sealed class #T4b
		{
			// Token: 0x06006478 RID: 25720 RVA: 0x00189D70 File Offset: 0x00187F70
			internal int #pad(int #4jb)
			{
				if (#4jb >= 1)
				{
					Point point2;
					if (4 != 0)
					{
						if (#4jb >= this.#a.#e.Length - 1)
						{
							return 0;
						}
						Point point = #IPc.#qPc(this.#b, this.#c, (double)(#4jb - 1) / (double)this.#a.#e.Length);
						if (!false)
						{
							point2 = point;
						}
					}
					bool flag = GeometryHelper.#coc(this.#a.ModelEditorControl.EditorWorkspaceSize, point2, GeometryHelper.#lcb(point2, this.#b));
					bool flag2;
					if (!false)
					{
						flag2 = flag;
					}
					Point point3 = #IPc.#qPc(this.#b, this.#c, (double)#4jb / (double)this.#a.#e.Length);
					if (!false)
					{
						point2 = point3;
					}
					bool flag3 = GeometryHelper.#coc(this.#a.ModelEditorControl.EditorWorkspaceSize, point2, GeometryHelper.#lcb(point2, this.#b));
					bool flag4;
					if (-1 != 0)
					{
						flag4 = flag3;
					}
					Point point4 = #IPc.#qPc(this.#b, this.#c, (double)(#4jb + 1) / (double)this.#a.#e.Length);
					if (!false)
					{
						point2 = point4;
					}
					bool flag5 = GeometryHelper.#coc(this.#a.ModelEditorControl.EditorWorkspaceSize, point2, GeometryHelper.#lcb(point2, this.#b));
					bool flag6;
					if (!false)
					{
						flag6 = flag5;
					}
					bool flag7 = flag2;
					while (flag7 || flag4 || flag6)
					{
						int num;
						if (!flag2)
						{
							num = ((!flag4) ? 1 : 0);
						}
						else
						{
							if (4 == 0)
							{
								goto IL_137;
							}
							num = 0;
						}
						IL_125:
						if ((num & (flag6 ? 1 : 0)) != 0)
						{
							break;
						}
						bool flag8 = flag7 = (flag2 && flag4);
						if (2 == 0)
						{
							continue;
						}
						if (flag8 && flag6)
						{
							return 1;
						}
						IL_137:
						if (false)
						{
							break;
						}
						int num2 = num = 0;
						if (num2 == 0)
						{
							return num2;
						}
						goto IL_125;
					}
					return -1;
				}
				return 0;
			}

			// Token: 0x0400292F RID: 10543
			public #IPc #a;

			// Token: 0x04002930 RID: 10544
			public Point #b;

			// Token: 0x04002931 RID: 10545
			public Point #c;
		}
	}
}
