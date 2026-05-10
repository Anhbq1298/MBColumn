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
using #UYd;
using #v1c;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Geometry.Misc;
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

namespace #DPc
{
	// Token: 0x02000C05 RID: 3077
	internal sealed class #CPc : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #9Tc, #FPc
	{
		// Token: 0x06006409 RID: 25609 RVA: 0x00187B24 File Offset: 0x00185D24
		public #CPc(#6Ic #JDc) : base(#JDc)
		{
			#X0d.#V0d(#JDc, #Phc.#3hc(107415858), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107444333));
			base.Header = Strings.StringDrawCircleWithThreeTangentPoints;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.DrawCircleWithThreeTangentPoints);
			this.PlanarCircleDrawingResult = #JDc.DrawingResultsFactory.CreatePlanarCircleDrawingResult(true);
			this.#b = #JDc.DrawingResultsFactory.CreateCrossIndicatorDrawingResult();
			this.#g = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			this.DrawCircleEditionState = #CPc.#nad.#a;
			this.#i = new Dictionary<#CPc.#nad, string>();
			this.#i[#CPc.#nad.#a] = Strings.StringSelectStartPoint.#z2d();
			this.#i[#CPc.#nad.#b] = Strings.StringSelectNextPoint.#z2d();
			this.#i[#CPc.#nad.#c] = Strings.StringSelectEndPoint.#z2d();
			base.HelpId = HelpIdentifiers.ToolDrawCircleWithTangentPoints;
			this.DrawSelectedPoints = true;
			this.DrawPreviewToSnappedPoint = false;
			this.DrawOnlyInWorkspace = true;
			base.IsOrthogonalModeSupported = true;
		}

		// Token: 0x17001C1F RID: 7199
		// (get) Token: 0x0600640A RID: 25610 RVA: 0x000512BC File Offset: 0x0004F4BC
		// (set) Token: 0x0600640B RID: 25611 RVA: 0x000512C4 File Offset: 0x0004F4C4
		protected IPlanarCircleDrawingResult PlanarCircleDrawingResult { get; set; }

		// Token: 0x17001C20 RID: 7200
		// (get) Token: 0x0600640C RID: 25612 RVA: 0x000512CD File Offset: 0x0004F4CD
		// (set) Token: 0x0600640D RID: 25613 RVA: 0x00187C60 File Offset: 0x00185E60
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "IoC")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "IoC")]
		public int NumberOfSides
		{
			get
			{
				return base.SettingsProvider.VisualizationCircleByTangentPointsToolNumberOfSides;
			}
			set
			{
				if (base.SettingsProvider.VisualizationCircleByTangentPointsToolNumberOfSides != value)
				{
					string propertyName = #Phc.#3hc(107453324);
					if (3 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					if (this.PlanarCircleDrawingResult != null)
					{
						IPlanarCircleDrawingResult planarCircleDrawingResult = this.PlanarCircleDrawingResult;
						if (8 != 0)
						{
							planarCircleDrawingResult.NumberOfSides = value;
						}
					}
					#6Gc #6Gc = base.SettingsProvider;
					if (4 != 0)
					{
						#6Gc.VisualizationCircleByTangentPointsToolNumberOfSides = value;
					}
					string propertyName2 = #Phc.#3hc(107453324);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001C21 RID: 7201
		// (get) Token: 0x0600640E RID: 25614 RVA: 0x000512DA File Offset: 0x0004F4DA
		// (set) Token: 0x0600640F RID: 25615 RVA: 0x000512E2 File Offset: 0x0004F4E2
		private protected #CPc.#nad DrawCircleEditionState { protected get; private set; }

		// Token: 0x17001C22 RID: 7202
		// (get) Token: 0x06006410 RID: 25616 RVA: 0x000512EB File Offset: 0x0004F4EB
		protected IReadOnlyList<Point3D> InputPoints3D
		{
			get
			{
				return this.#d;
			}
		}

		// Token: 0x17001C23 RID: 7203
		// (get) Token: 0x06006411 RID: 25617 RVA: 0x000512F3 File Offset: 0x0004F4F3
		// (set) Token: 0x06006412 RID: 25618 RVA: 0x000512FB File Offset: 0x0004F4FB
		private protected Point3D LastSnappedPosition { protected get; private set; }

		// Token: 0x17001C24 RID: 7204
		// (get) Token: 0x06006413 RID: 25619 RVA: 0x00051304 File Offset: 0x0004F504
		// (set) Token: 0x06006414 RID: 25620 RVA: 0x0005130C File Offset: 0x0004F50C
		protected bool DrawSelectedPoints { get; set; }

		// Token: 0x17001C25 RID: 7205
		// (get) Token: 0x06006415 RID: 25621 RVA: 0x00051315 File Offset: 0x0004F515
		// (set) Token: 0x06006416 RID: 25622 RVA: 0x0005131D File Offset: 0x0004F51D
		protected bool DrawPreviewToSnappedPoint { get; set; }

		// Token: 0x17001C26 RID: 7206
		// (get) Token: 0x06006417 RID: 25623 RVA: 0x00051326 File Offset: 0x0004F526
		// (set) Token: 0x06006418 RID: 25624 RVA: 0x0005132E File Offset: 0x0004F52E
		protected bool DrawOnlyInWorkspace { get; set; }

		// Token: 0x06006419 RID: 25625 RVA: 0x00187CD8 File Offset: 0x00185ED8
		public override void #5b()
		{
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[4];
			RuntimeFieldHandle fldHandle = fieldof(#l8c.#c).FieldHandle;
			if (!false)
			{
				RuntimeHelpers.InitializeArray(array, fldHandle);
			}
			if (!false)
			{
				base.#FIc(array);
			}
			if (this.#a == null)
			{
				this.#a = base.ToolContext.DrawingResultsFactory.CreatePointsDrawingResult();
			}
			IPlanarCircleDrawingResult planarCircleDrawingResult = this.PlanarCircleDrawingResult;
			Color? lineColor = new Color?(base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeColor);
			if (!false)
			{
				planarCircleDrawingResult.LineColor = lineColor;
			}
			IPlanarCircleDrawingResult planarCircleDrawingResult2 = this.PlanarCircleDrawingResult;
			Color color = base.SettingsProvider.VisualizationDrawingToolNewFigureFillColor;
			if (4 != 0)
			{
				planarCircleDrawingResult2.Color = color;
			}
			IPlanarCircleDrawingResult planarCircleDrawingResult3 = this.PlanarCircleDrawingResult;
			double lineThickness = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeThickness;
			if (2 != 0)
			{
				planarCircleDrawingResult3.LineThickness = lineThickness;
			}
			IPlanarCircleDrawingResult planarCircleDrawingResult4 = this.PlanarCircleDrawingResult;
			int numberOfSides = this.NumberOfSides;
			if (!false)
			{
				planarCircleDrawingResult4.NumberOfSides = numberOfSides;
			}
			if (!false)
			{
				this.#a.PointColor = base.SettingsProvider.VisualizationDrawCircleUsingTangentPointsPointColor;
				this.#a.PointSize = base.SettingsProvider.VisualizationDrawCircleUsingTangentPointsPointSize;
				this.DrawCircleEditionState = #CPc.#nad.#a;
				base.ModelEditorControl.SetCursor(this.#g, false);
				base.RaisePropertyChanged(string.Empty);
			}
			base.#5b();
		}

		// Token: 0x0600641A RID: 25626 RVA: 0x00187E1C File Offset: 0x0018601C
		public override void #0kb()
		{
			if (6 != 0)
			{
				base.#0kb();
			}
			if (2 != 0)
			{
				this.#1kb();
			}
			for (;;)
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				Cursor arrow = System.Windows.Input.Cursors.Arrow;
				bool forceCursor = false;
				if (5 != 0)
				{
					modelEditorControl.SetCursor(arrow, forceCursor);
				}
				for (;;)
				{
					ModelEditorControlEventType[] #MEc = null;
					if (4 != 0)
					{
						base.#LEc(#MEc);
					}
					IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
					IDrawingResult drawingResult = this.#b;
					if (6 != 0)
					{
						modelEditorControl2.RemoveFromView(drawingResult);
					}
					this.#a = null;
					if (false)
					{
						break;
					}
					if (!false)
					{
						return;
					}
				}
			}
		}

		// Token: 0x0600641B RID: 25627 RVA: 0x00187E90 File Offset: 0x00186090
		public override void #1kb()
		{
			if (this.#a != null && this.DrawSelectedPoints)
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#a;
				if (!false)
				{
					modelEditorControl.RemoveFromView(drawingResult);
				}
			}
			if (this.PlanarCircleDrawingResult != null)
			{
				IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
				IDrawingResult drawingResult2 = this.PlanarCircleDrawingResult;
				if (-1 != 0)
				{
					modelEditorControl2.RemoveFromView(drawingResult2);
				}
			}
			bool isWorking = false;
			if (!false)
			{
				base.IsWorking = isWorking;
			}
			#CPc.#nad #nad = #CPc.#nad.#a;
			if (!false)
			{
				this.DrawCircleEditionState = #nad;
			}
			List<Point> list = this.#c;
			if (6 != 0)
			{
				list.Clear();
			}
			List<Point3D> list2 = this.#d;
			if (!false)
			{
				list2.Clear();
			}
			base.ModelEditorViewModel.#l0c();
			base.#1kb();
		}

		// Token: 0x0600641C RID: 25628 RVA: 0x00187F34 File Offset: 0x00186134
		public string #vNc(#ivc #rmc, Point #Ng)
		{
			Point3D point3D = PointsConverter.#vsc(#Ng);
			Point3D #Ng2;
			if (!false)
			{
				#Ng2 = point3D;
			}
			if (!this.#uPc(#Ng2))
			{
				return Strings.StringCouldNotCreateCirleFromTheGivenParameters.#z2d();
			}
			return null;
		}

		// Token: 0x0600641D RID: 25629 RVA: 0x00051337 File Offset: 0x0004F537
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

		// Token: 0x0600641E RID: 25630 RVA: 0x00051350 File Offset: 0x0004F550
		protected override void #GIc()
		{
			do
			{
				if (true && !false)
				{
					ICrossIndicatorDrawingResult #LIc = this.#b;
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

		// Token: 0x0600641F RID: 25631 RVA: 0x00187F64 File Offset: 0x00186164
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
						IDrawingResult drawingResult = this.#b;
						if (6 != 0)
						{
							modelEditorControl.AddToView(drawingResult);
						}
						ICrossIndicatorDrawingResult crossIndicatorDrawingResult = this.#b;
						Point3D value = point3D2.Value;
						if (4 != 0)
						{
							crossIndicatorDrawingResult.CenterPoint = value;
						}
						int count = this.#c.Count;
						if (!false)
						{
							if (count >= 2)
							{
								this.#oPc(point3D2.Value);
							}
						}
					}
				}
			}
		}

		// Token: 0x06006420 RID: 25632 RVA: 0x00185BD8 File Offset: 0x00183DD8
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

		// Token: 0x06006421 RID: 25633 RVA: 0x00051387 File Offset: 0x0004F587
		protected override void #hIc()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#b;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
		}

		// Token: 0x06006422 RID: 25634 RVA: 0x00187FE0 File Offset: 0x001861E0
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			IL_00:
			while (this.#uPc(#HAb))
			{
				for (;;)
				{
					Point3D #HAb2 = #HAb;
					if (true)
					{
						base.#fzb(#HAb2, #gzb);
					}
					double num = 0.032;
					if (!false)
					{
						#HAb.Z = num;
					}
					if (this.#c.Count == 0)
					{
						if (5 == 0)
						{
							goto IL_AE;
						}
						Point3D #HAb3 = #HAb;
						if (!false)
						{
							this.#lPc(#HAb3);
						}
					}
					else
					{
						if (false)
						{
							goto IL_00;
						}
						if (this.#c.Count == 1)
						{
							Point3D #HAb4 = #HAb;
							if (4 != 0)
							{
								this.#mPc(#HAb4);
							}
						}
						else
						{
							Point3D #HAb5 = #HAb;
							if (!false)
							{
								this.#nPc(#HAb5);
							}
						}
					}
					IL_6C:
					if (false)
					{
						continue;
					}
					if (!this.InputPoints3D.Any<Point3D>() || !this.DrawSelectedPoints)
					{
						goto IL_AE;
					}
					IModelEditorControl modelEditorControl = base.ModelEditorControl;
					IDrawingResult drawingResult = this.#a;
					if (!false)
					{
						modelEditorControl.AddToView(drawingResult);
					}
					if (!false)
					{
						break;
					}
					goto IL_6C;
				}
				this.#a.Points = new List<Point3D>(this.InputPoints3D);
				IL_AE:
				if (#gzb)
				{
					base.PreciseInputProvider.Update(this.#DNc(false));
				}
				return;
			}
		}

		// Token: 0x06006423 RID: 25635 RVA: 0x001880EC File Offset: 0x001862EC
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			if (2 != 0)
			{
				base.#HEc(#IEc, #Kzb);
			}
			Point3D? point3D = this.#aPc(#Kzb);
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			if (-1 == 0)
			{
				goto IL_30;
			}
			int num = this.#c.Count;
			IL_22:
			if (8 == 0)
			{
				goto IL_45;
			}
			if (num < 2)
			{
				return;
			}
			Point3D point3D3;
			if (this.DrawPreviewToSnappedPoint)
			{
				point3D3 = point3D2.Value;
				goto IL_3A;
			}
			IL_30:
			point3D3 = #Kzb;
			IL_3A:
			Point3D #Kzb2;
			if (3 != 0)
			{
				#Kzb2 = point3D3;
			}
			num = (this.#oPc(#Kzb2) ? 1 : 0);
			IL_45:
			if (4 == 0)
			{
				goto IL_22;
			}
		}

		// Token: 0x06006424 RID: 25636 RVA: 0x000513A1 File Offset: 0x0004F5A1
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			if (7 != 0)
			{
				base.#3kb(#4kb);
			}
			this.#h = true;
		}

		// Token: 0x06006425 RID: 25637 RVA: 0x00188150 File Offset: 0x00186350
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			if (!this.#h)
			{
				return;
			}
			if (3 == 0)
			{
				goto IL_50;
			}
			this.#h = false;
			#R2c #R2c = base.ToolContext.MouseAndKeyboardService;
			if (2 != 0)
			{
				#R2c.#mNb();
			}
			Point3D? point3D = base.#HIc(#4kb);
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			bool flag2;
			bool flag = flag2 = (point3D2 != null);
			if (4 == 0)
			{
				goto IL_A4;
			}
			if (!flag)
			{
				return;
			}
			IL_40:
			Point3D? point3D3 = point3D2;
			Point3D? #HAb;
			if (!false)
			{
				#HAb = point3D3;
			}
			if (!this.DrawOnlyInWorkspace)
			{
				goto IL_73;
			}
			IL_50:
			if (false)
			{
				goto IL_40;
			}
			Point3D? point3D4 = base.ToolOperationsHelper.#aEc(point3D2.Value);
			if (!false)
			{
				#HAb = point3D4;
			}
			if (#HAb == null)
			{
				return;
			}
			IL_73:
			Point3D? point3D5 = this.#aPc(#HAb.Value);
			if (4 != 0)
			{
				#HAb = point3D5;
			}
			bool flag3 = flag2 = (#HAb != null);
			if (-1 != 0)
			{
				if (!flag3)
				{
					return;
				}
				if (!this.DrawOnlyInWorkspace)
				{
					goto IL_A7;
				}
				flag2 = base.ToolOperationsHelper.#8Dc(#HAb);
			}
			IL_A4:
			if (flag2)
			{
				goto IL_A7;
			}
			return;
			IL_A7:
			bool isWorking = true;
			if (!false)
			{
				base.IsWorking = isWorking;
			}
			this.#fzb(#HAb.Value, false);
		}

		// Token: 0x06006426 RID: 25638 RVA: 0x00188240 File Offset: 0x00186440
		protected override void #cIc()
		{
			Point3D? point3D = this.#BPc();
			Point3D? point3D2;
			if (5 != 0)
			{
				point3D2 = point3D;
			}
			if (point3D2 != null)
			{
				do
				{
					if (!false)
					{
						#V0c #V0c = base.ModelEditorViewModel;
						Point3D value = point3D2.Value;
						BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
						if (!false)
						{
							#V0c.#j0c(value, #Prc);
						}
					}
				}
				while (false);
				if (true)
				{
					return;
				}
			}
		}

		// Token: 0x06006427 RID: 25639 RVA: 0x00050FF1 File Offset: 0x0004F1F1
		protected override void #dIc()
		{
			#V0c #V0c = base.ModelEditorViewModel;
			if (!false)
			{
				#V0c.#l0c();
			}
		}

		// Token: 0x06006428 RID: 25640 RVA: 0x00188294 File Offset: 0x00186494
		protected override void #eIc()
		{
			if (!false)
			{
				base.#eIc();
			}
			for (;;)
			{
				IL_05:
				bool flag = base.SettingsProvider.IsOrthogonalModeEnabled;
				while (flag)
				{
					Point3D? point3D = this.#BPc();
					Point3D? point3D2;
					if (3 != 0)
					{
						point3D2 = point3D;
					}
					bool flag2 = flag = (point3D2 != null);
					if (!false)
					{
						if (flag2)
						{
							goto IL_2C;
						}
						if (4 != 0)
						{
							return;
						}
						goto IL_05;
					}
				}
				goto IL_4E;
			}
			return;
			IL_2C:
			if (!false)
			{
				#V0c #V0c = base.ModelEditorViewModel;
				Point3D? point3D2;
				Point3D value = point3D2.Value;
				BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
				if (2 != 0)
				{
					#V0c.#j0c(value, #Prc);
				}
				return;
			}
			return;
			IL_4E:
			#V0c #V0c2 = base.ModelEditorViewModel;
			if (true)
			{
				#V0c2.#l0c();
			}
		}

		// Token: 0x06006429 RID: 25641 RVA: 0x00188314 File Offset: 0x00186514
		protected void #lPc(Point3D #HAb)
		{
			List<Point3D> list = this.#d;
			if (!false)
			{
				list.Add(#HAb);
			}
			List<Point> list2 = this.#c;
			Point item = PointsConverter.#vsc(#HAb);
			if (!false)
			{
				list2.Add(item);
			}
			#CPc.#nad #nad = #CPc.#nad.#b;
			if (!false)
			{
				this.DrawCircleEditionState = #nad;
			}
			if (true)
			{
				this.#APc();
			}
		}

		// Token: 0x0600642A RID: 25642 RVA: 0x00188368 File Offset: 0x00186568
		protected void #mPc(Point3D #HAb)
		{
			List<Point3D> list = this.#d;
			if (!false)
			{
				list.Add(#HAb);
			}
			List<Point> list2 = this.#c;
			Point item = PointsConverter.#vsc(#HAb);
			if (!false)
			{
				list2.Add(item);
			}
			#CPc.#nad #nad = #CPc.#nad.#c;
			if (!false)
			{
				this.DrawCircleEditionState = #nad;
			}
			if (true)
			{
				this.#APc();
			}
		}

		// Token: 0x0600642B RID: 25643 RVA: 0x001883BC File Offset: 0x001865BC
		protected void #nPc(Point3D #HAb)
		{
			for (;;)
			{
				if (!this.#oPc(#HAb))
				{
					goto IL_31;
				}
				List<Point3D> list = this.#d;
				if (5 != 0)
				{
					list.Add(#HAb);
				}
				IL_15:
				if (3 != 0)
				{
					if (false)
					{
						continue;
					}
					List<Point> list2 = this.#c;
					Point item = PointsConverter.#vsc(#HAb);
					if (!false)
					{
						list2.Add(item);
					}
					if (!false)
					{
						this.#nOc();
					}
				}
				IL_31:
				if (true)
				{
					break;
				}
				goto IL_15;
			}
		}

		// Token: 0x0600642C RID: 25644 RVA: 0x00188414 File Offset: 0x00186614
		protected bool #oPc(Point3D #Kzb)
		{
			Point value = PointsConverter.#vsc(#Kzb);
			Point? point;
			if (!false)
			{
				point = new Point?(value);
			}
			CircleData circleData2;
			int result;
			if (!false)
			{
				CircleData circleData = this.#pPc(point.Value);
				if (4 != 0)
				{
					circleData2 = circleData;
				}
				if (circleData2 != null)
				{
					bool flag = (result = (this.#zPc(circleData2.Center, circleData2.Radius) ? 1 : 0)) != 0;
					if (7 == 0)
					{
						return result != 0;
					}
					if (flag)
					{
						goto IL_61;
					}
				}
				if (6 == 0)
				{
					return false;
				}
				Point? point2 = this.#yPc(point.Value);
				if (!false)
				{
					point = point2;
				}
				IL_61:
				bool flag2 = point != null;
				while (flag2)
				{
					CircleData circleData3 = this.#pPc(point.Value);
					if (5 != 0)
					{
						circleData2 = circleData3;
					}
					if (circleData2 == null)
					{
						break;
					}
					bool flag3 = flag2 = this.#zPc(circleData2.Center, circleData2.Radius);
					if (!false)
					{
						if (!flag3)
						{
							break;
						}
						IEditableObject editableObject = this.PlanarCircleDrawingResult;
						if (false)
						{
							goto IL_A8;
						}
						editableObject.BeginEdit();
						goto IL_A8;
					}
				}
				base.ModelEditorControl.RemoveFromView(this.PlanarCircleDrawingResult);
				return false;
			}
			IL_A8:
			IPlanarCircleDrawingResult planarCircleDrawingResult = this.PlanarCircleDrawingResult;
			Point3D center = PointsConverter.#vsc(circleData2.Center, 0.032);
			if (!false)
			{
				planarCircleDrawingResult.Center = center;
			}
			this.PlanarCircleDrawingResult.Radius = circleData2.Radius;
			this.PlanarCircleDrawingResult.EndEdit();
			base.ModelEditorControl.AddToView(this.PlanarCircleDrawingResult);
			this.#vPc();
			result = 1;
			return result != 0;
		}

		// Token: 0x0600642D RID: 25645 RVA: 0x000513B8 File Offset: 0x0004F5B8
		protected CircleData #pPc(Point #usc)
		{
			while (this.#c.Count >= 2)
			{
				if (!false)
				{
					return CircleHelper.#pmc(this.#c[0], this.#c[1], #usc);
				}
			}
			return null;
		}

		// Token: 0x0600642E RID: 25646 RVA: 0x00050E8C File Offset: 0x0004F08C
		protected #Atc #bNb(Point3D #Kzb)
		{
			return base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, #Kzb);
		}

		// Token: 0x17001C27 RID: 7207
		// (get) Token: 0x0600642F RID: 25647 RVA: 0x000513EB File Offset: 0x0004F5EB
		// (set) Token: 0x06006430 RID: 25648 RVA: 0x0018855C File Offset: 0x0018675C
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public ToolDrawingMode ToolDrawingMode
		{
			get
			{
				return this.#e;
			}
			set
			{
				for (;;)
				{
					if (this.#e == value)
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
						this.#e = value;
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

		// Token: 0x06006431 RID: 25649 RVA: 0x001885B0 File Offset: 0x001867B0
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
			#GJc.Message = this.#i[this.DrawCircleEditionState];
			#oW #oW = base.ProjectContext;
			if (8 != 0)
			{
				#GJc.ProjectContext = #oW;
			}
			return #aJc.#7Ic(#GJc);
		}

		// Token: 0x06006432 RID: 25650 RVA: 0x00188660 File Offset: 0x00186860
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unhandled errors catch.")]
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
					List<Point3D> list3 = PointsConverter.#Csc(this.PlanarCircleDrawingResult.CalculatePoints().ToList<Point3D>(), 0.0).ToList<Point3D>();
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
				base.ToolOperationsHelper.#bEc();
				if (!false)
				{
					base.#MIc();
				}
				IL_F0:
				if (!false)
				{
					this.#zIc();
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

		// Token: 0x06006433 RID: 25651 RVA: 0x00188818 File Offset: 0x00186A18
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

		// Token: 0x06006434 RID: 25652 RVA: 0x00188840 File Offset: 0x00186A40
		private bool #sPc(Point #mcb, Point #ncb, Point #Ckc)
		{
			CircleData circleData = CircleHelper.#pmc(#mcb, #ncb, #Ckc);
			CircleData circleData2;
			if (!false)
			{
				circleData2 = circleData;
			}
			int result;
			if (circleData2 != null && !false)
			{
				result = (this.#zPc(circleData2.Center, circleData2.Radius) ? 1 : 0);
			}
			else
			{
				int num = result = 0;
				if (num == 0)
				{
					result = num;
					if (num == 0)
					{
						return num != 0;
					}
				}
			}
			return result != 0;
		}

		// Token: 0x06006435 RID: 25653 RVA: 0x0018887C File Offset: 0x00186A7C
		private int #tPc(Point #mcb, Point #ncb, Point #Xrb, Point #Yrb)
		{
			#CPc.#h5b #h5b = new #CPc.#h5b();
			#CPc.#h5b #h5b2;
			if (4 != 0)
			{
				#h5b2 = #h5b;
			}
			#h5b2.#a = this;
			#h5b2.#b = #Xrb;
			#h5b2.#c = #Yrb;
			#h5b2.#d = #mcb;
			#h5b2.#e = #ncb;
			return this.#f.#01d(new Func<int, int>(#h5b2.#oad));
		}

		// Token: 0x06006436 RID: 25654 RVA: 0x000513F3 File Offset: 0x0004F5F3
		private bool #uPc(Point3D #Ng)
		{
			return !this.InputPoints3D.Contains(#Ng);
		}

		// Token: 0x06006437 RID: 25655 RVA: 0x001888D0 File Offset: 0x00186AD0
		private void #vPc()
		{
			for (;;)
			{
				if (-1 != 0)
				{
					if (!this.DrawSelectedPoints)
					{
						break;
					}
					IModelEditorControl modelEditorControl = base.ModelEditorControl;
					IDrawingResult drawingResult = this.#a;
					if (!false)
					{
						modelEditorControl.AddToView(drawingResult);
					}
				}
				do
				{
					IPointsDrawingResult pointsDrawingResult = this.#a;
					IEnumerable<Point3D> points = new List<Point3D>(this.InputPoints3D);
					if (!false)
					{
						pointsDrawingResult.Points = points;
					}
				}
				while (false);
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x06006438 RID: 25656 RVA: 0x00188924 File Offset: 0x00186B24
		private Point? #wPc(int #4jb, Point #Xrb, Point #Yrb, Point #mcb, Point #xPc)
		{
			while (!false && #4jb < 0)
			{
				if (7 != 0)
				{
					return null;
				}
			}
			Vector vector = Point.#H3d(#Xrb, #Yrb);
			Vector #4Bb;
			if (true)
			{
				#4Bb = vector;
			}
			Point point = Point.#G3d(#Yrb, Vector.#33d(#4Bb, (double)#4jb / (double)this.#f.Length));
			Point point2;
			if (!false)
			{
				point2 = point;
			}
			CircleData circleData = CircleHelper.#pmc(#mcb, #xPc, point2);
			CircleData circleData2;
			if (!false)
			{
				circleData2 = circleData;
			}
			if (circleData2 != null && this.#zPc(circleData2.Center, circleData2.Radius))
			{
				return new Point?(point2);
			}
			return null;
		}

		// Token: 0x06006439 RID: 25657 RVA: 0x001889AC File Offset: 0x00186BAC
		private Point? #yPc(Point #Ng)
		{
			int num = this.#tPc(this.#c[0], this.#c[1], this.#c[1], #Ng);
			int num2;
			if (6 != 0)
			{
				num2 = num;
			}
			if (num2 >= 0)
			{
				Point? point = this.#wPc(num2, this.#c[1], #Ng, this.#c[0], this.#c[1]);
				Point? result;
				if (!false)
				{
					result = point;
				}
				if (result != null)
				{
					return result;
				}
			}
			GeneralLineEquation generalLineEquation = new GeneralLineEquation(this.#c[0], this.#c[1]);
			GeneralLineEquation generalLineEquation2;
			if (!false)
			{
				generalLineEquation2 = generalLineEquation;
			}
			Point? point2 = generalLineEquation2.#rlc(#Ng).#plc(generalLineEquation2);
			Point? point3;
			if (-1 != 0)
			{
				point3 = point2;
			}
			if (point3 == null)
			{
				return null;
			}
			if (false)
			{
			}
			Point point4 = Point.#G3d(#Ng, Vector.#33d(Point.#H3d(#Ng, point3.Value), 3.0));
			Point #Xrb;
			if (6 != 0)
			{
				#Xrb = point4;
			}
			num2 = this.#tPc(this.#c[0], this.#c[1], #Xrb, #Ng);
			return this.#wPc(num2, #Xrb, #Ng, this.#c[0], this.#c[1]);
		}

		// Token: 0x0600643A RID: 25658 RVA: 0x00051406 File Offset: 0x0004F606
		private bool #zPc(Point #Wjc, double #HS)
		{
			if (!false)
			{
				bool flag = this.DrawOnlyInWorkspace;
				while (flag)
				{
					bool result = flag = GeometryHelper.#coc(base.ModelEditorControl.EditorWorkspaceSize, #Wjc, #HS);
					if (!false)
					{
						return result;
					}
				}
			}
			return true;
		}

		// Token: 0x0600643B RID: 25659 RVA: 0x00188B10 File Offset: 0x00186D10
		private void #APc()
		{
			if (!base.IsOrthogonalModeEnabled || this.DrawCircleEditionState == #CPc.#nad.#a)
			{
				return;
			}
			Point3D? point3D2;
			do
			{
				Point3D? point3D = this.#BPc();
				if (!false)
				{
					point3D2 = point3D;
				}
			}
			while (false);
			if (point3D2 != null)
			{
				goto IL_2B;
			}
			IL_27:
			if (!false)
			{
				return;
			}
			IL_2B:
			#V0c #V0c = base.ModelEditorViewModel;
			Point3D value = point3D2.Value;
			BoundingBoxData #Prc = base.StructuralModel.WorkspaceBoundingBoxData;
			if (true)
			{
				#V0c.#j0c(value, #Prc);
			}
			if (2 != 0)
			{
				return;
			}
			goto IL_27;
		}

		// Token: 0x0600643C RID: 25660 RVA: 0x00188B74 File Offset: 0x00186D74
		private Point3D? #aPc(Point3D #Ng)
		{
			#Atc #Atc;
			for (;;)
			{
				if (false)
				{
					goto IL_20;
				}
				Point3D? point3D = this.#BPc();
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				if (base.IsOrthogonalModeEnabled && this.DrawCircleEditionState != #CPc.#nad.#a)
				{
					goto IL_20;
				}
				goto IL_5D;
				IL_68:
				Point3D point3D3 = #Atc.Point;
				if (!false)
				{
					this.LastSnappedPosition = point3D3;
				}
				ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
				#Atc snapToPointResult = #Atc;
				if (5 != 0)
				{
					snapPointsMarker.Mark(snapToPointResult);
				}
				if (false)
				{
					continue;
				}
				if (5 != 0 && !false)
				{
					break;
				}
				IL_29:
				#Atc #Atc2 = base.SnappingProvider.#Mrc(base.ProjectContext.SnappingModes, #Ng, point3D2.Value, base.ProjectContext.MainModel.WorkspaceBoundingBoxData);
				if (!false)
				{
					#Atc = #Atc2;
				}
				goto IL_68;
				IL_20:
				if (point3D2 != null)
				{
					goto IL_29;
				}
				IL_5D:
				#Atc #Atc3 = this.#bNb(#Ng);
				if (false)
				{
					goto IL_68;
				}
				#Atc = #Atc3;
				goto IL_68;
			}
			return new Point3D?(PointsConverter.#Csc(#Atc.Point, 0.0));
		}

		// Token: 0x0600643D RID: 25661 RVA: 0x00188C40 File Offset: 0x00186E40
		private Point3D? #BPc()
		{
			for (;;)
			{
				#CPc.#nad #nad = this.DrawCircleEditionState;
				#CPc.#nad #nad2;
				if (2 != 0)
				{
					#nad2 = #nad;
				}
				if (#nad2 != #CPc.#nad.#b)
				{
					if (!false)
					{
						if (#nad2 == #CPc.#nad.#c)
						{
							goto IL_29;
						}
					}
					IL_3B:
					if (4 != 0)
					{
						Point3D? result = null;
						if (2 != 0)
						{
							return result;
						}
						continue;
					}
					goto IL_3B;
				}
				break;
			}
			return new Point3D?(this.#d.ElementAtOrDefault(0));
			IL_29:
			return new Point3D?(this.#d.ElementAtOrDefault(1));
		}

		// Token: 0x0600643E RID: 25662 RVA: 0x0005142A File Offset: 0x0004F62A
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#g;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x0600643F RID: 25663 RVA: 0x0005143F File Offset: 0x0004F63F
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

		// Token: 0x04002906 RID: 10502
		private IPointsDrawingResult #a;

		// Token: 0x04002907 RID: 10503
		private readonly ICrossIndicatorDrawingResult #b;

		// Token: 0x04002908 RID: 10504
		private readonly List<Point> #c = new List<Point>();

		// Token: 0x04002909 RID: 10505
		private readonly List<Point3D> #d = new List<Point3D>();

		// Token: 0x0400290A RID: 10506
		private ToolDrawingMode #e;

		// Token: 0x0400290B RID: 10507
		private readonly int[] #f = Enumerable.Range(0, 50000).ToArray<int>();

		// Token: 0x0400290C RID: 10508
		private readonly Cursor #g;

		// Token: 0x0400290D RID: 10509
		private bool #h;

		// Token: 0x0400290E RID: 10510
		private readonly IDictionary<#CPc.#nad, string> #i;

		// Token: 0x0400290F RID: 10511
		[CompilerGenerated]
		private IPlanarCircleDrawingResult #j;

		// Token: 0x04002910 RID: 10512
		[CompilerGenerated]
		private #CPc.#nad #k;

		// Token: 0x04002911 RID: 10513
		[CompilerGenerated]
		private Point3D #l;

		// Token: 0x04002912 RID: 10514
		[CompilerGenerated]
		private bool #m;

		// Token: 0x04002913 RID: 10515
		[CompilerGenerated]
		private bool #n;

		// Token: 0x04002914 RID: 10516
		[CompilerGenerated]
		private bool #o;

		// Token: 0x02000C06 RID: 3078
		protected enum #nad
		{
			// Token: 0x04002916 RID: 10518
			#a,
			// Token: 0x04002917 RID: 10519
			#b,
			// Token: 0x04002918 RID: 10520
			#c
		}

		// Token: 0x02000C07 RID: 3079
		[CompilerGenerated]
		private sealed class #h5b
		{
			// Token: 0x06006441 RID: 25665 RVA: 0x00188C9C File Offset: 0x00186E9C
			internal int #oad(int #4jb)
			{
				if (#4jb < 1 || #4jb >= this.#a.#f.Length - 1)
				{
					return 0;
				}
				Point point = #CPc.#qPc(this.#b, this.#c, (double)(#4jb - 1) / (double)this.#a.#f.Length);
				Point #Ckc;
				if (6 != 0)
				{
					#Ckc = point;
				}
				bool flag = this.#a.#sPc(this.#d, this.#e, #Ckc);
				bool flag2;
				if (!false)
				{
					flag2 = flag;
				}
				Point point2 = #CPc.#qPc(this.#b, this.#c, (double)#4jb / (double)this.#a.#f.Length);
				if (!false)
				{
					#Ckc = point2;
				}
				bool flag3 = this.#a.#sPc(this.#d, this.#e, #Ckc);
				bool flag4;
				if (5 != 0)
				{
					flag4 = flag3;
				}
				Point point3 = #CPc.#qPc(this.#b, this.#c, (double)(#4jb + 1) / (double)this.#a.#f.Length);
				if (!false)
				{
					#Ckc = point3;
				}
				bool flag5 = this.#a.#sPc(this.#d, this.#e, #Ckc);
				bool flag6;
				if (!false)
				{
					flag6 = flag5;
				}
				if ((!flag2 && !flag4 && !flag6) || (!flag2 && !flag4 && flag6))
				{
					return -1;
				}
				if (flag2 && flag4 && flag6)
				{
					return 1;
				}
				return 0;
			}

			// Token: 0x04002919 RID: 10521
			public #CPc #a;

			// Token: 0x0400291A RID: 10522
			public Point #b;

			// Token: 0x0400291B RID: 10523
			public Point #c;

			// Token: 0x0400291C RID: 10524
			public Point #d;

			// Token: 0x0400291D RID: 10525
			public Point #e;
		}
	}
}
