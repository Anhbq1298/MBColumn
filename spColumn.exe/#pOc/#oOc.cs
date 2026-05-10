using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
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
using #UYd;
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

namespace #pOc
{
	// Token: 0x02000BEF RID: 3055
	[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses")]
	internal sealed class #oOc : #YIc, IDisposable, INotifyPropertyChanged, IEditionToolData, #8Hc, #9Tc, #sOc
	{
		// Token: 0x06006353 RID: 25427 RVA: 0x00183F54 File Offset: 0x00182154
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public #oOc(#6Ic #JDc, #rOc #qOc) : base(#JDc)
		{
			#X0d.#V0d(#qOc, #Phc.#3hc(107445501), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107445468));
			base.Header = Strings.StringDrawRectangle;
			base.IconImage = base.ToolContext.ResourcesHelper.ImageFromResourceBitmap(ToolsIcons.DrawRectangle);
			#qOc.DataContext = this;
			base.ToolOptionsEditor = #qOc;
			this.ToolState = #oOc.#ead.#a;
			this.PlanarRectangleDrawingResult = base.ToolContext.DrawingResultsFactory.CreatePlanarRectangleDrawingResult(true);
			this.#b = base.ToolContext.DrawingResultsFactory.CreateCrossIndicatorDrawingResult();
			this.#d = new Dictionary<#oOc.#ead, string>();
			this.#d[#oOc.#ead.#a] = Strings.StringSelectStartPoint.#z2d();
			this.#d[#oOc.#ead.#b] = Strings.StringSelectEndPoint.#z2d();
			this.#c = base.ToolContext.ResourcesHelper.CreateCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Cross);
			base.HelpId = HelpIdentifiers.ToolDrawRectangle;
		}

		// Token: 0x17001C07 RID: 7175
		// (get) Token: 0x06006354 RID: 25428 RVA: 0x00050D69 File Offset: 0x0004EF69
		// (set) Token: 0x06006355 RID: 25429 RVA: 0x00050D71 File Offset: 0x0004EF71
		protected Point3D? SelectedStartPoint { get; set; }

		// Token: 0x17001C08 RID: 7176
		// (get) Token: 0x06006356 RID: 25430 RVA: 0x00050D7A File Offset: 0x0004EF7A
		// (set) Token: 0x06006357 RID: 25431 RVA: 0x00050D82 File Offset: 0x0004EF82
		private protected IPlanarRectangleDrawingResult PlanarRectangleDrawingResult { protected get; private set; }

		// Token: 0x17001C09 RID: 7177
		// (get) Token: 0x06006358 RID: 25432 RVA: 0x00050D8B File Offset: 0x0004EF8B
		// (set) Token: 0x06006359 RID: 25433 RVA: 0x00050D93 File Offset: 0x0004EF93
		private protected bool IsSquareModeEnabled { protected get; private set; }

		// Token: 0x17001C0A RID: 7178
		// (get) Token: 0x0600635A RID: 25434 RVA: 0x00050D9C File Offset: 0x0004EF9C
		// (set) Token: 0x0600635B RID: 25435 RVA: 0x00050DA4 File Offset: 0x0004EFA4
		private protected #oOc.#ead ToolState { protected get; private set; }

		// Token: 0x17001C0B RID: 7179
		// (get) Token: 0x0600635C RID: 25436 RVA: 0x00050DAD File Offset: 0x0004EFAD
		// (set) Token: 0x0600635D RID: 25437 RVA: 0x00050DB5 File Offset: 0x0004EFB5
		protected Point3D LastSnappedPosition { get; set; }

		// Token: 0x0600635E RID: 25438 RVA: 0x0018404C File Offset: 0x0018224C
		public override void #5b()
		{
			if (-1 != 0)
			{
				base.#5b();
			}
			ModelEditorControlEventType[] array = new ModelEditorControlEventType[4];
			RuntimeFieldHandle fldHandle = fieldof(#l8c.#c).FieldHandle;
			if (!false)
			{
				RuntimeHelpers.InitializeArray(array, fldHandle);
			}
			if (4 != 0)
			{
				base.#FIc(array);
			}
			IPlanarRectangleDrawingResult planarRectangleDrawingResult = this.PlanarRectangleDrawingResult;
			Color? lineColor = new Color?(base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeColor);
			if (!false)
			{
				planarRectangleDrawingResult.LineColor = lineColor;
			}
			IPlanarRectangleDrawingResult planarRectangleDrawingResult2 = this.PlanarRectangleDrawingResult;
			Color color = base.SettingsProvider.VisualizationDrawingToolNewFigureFillColor;
			if (!false)
			{
				planarRectangleDrawingResult2.Color = color;
			}
			IPlanarRectangleDrawingResult planarRectangleDrawingResult3 = this.PlanarRectangleDrawingResult;
			double lineThickness = base.SettingsProvider.VisualizationDrawingToolNewFigureEdgeThickness;
			if (!false)
			{
				planarRectangleDrawingResult3.LineThickness = lineThickness;
			}
			#8Ib.#HJc(base.SnapPointsMarker, base.SettingsProvider);
			base.#AIc(this.#b);
			base.ModelEditorControl.SetCursor(this.#c, false);
		}

		// Token: 0x0600635F RID: 25439 RVA: 0x0018412C File Offset: 0x0018232C
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
				ModelEditorControlEventType[] #MEc = null;
				if (5 != 0)
				{
					base.#LEc(#MEc);
				}
				for (;;)
				{
					IModelEditorControl modelEditorControl = base.ModelEditorControl;
					IDrawingResult drawingResult = this.#b;
					if (4 != 0)
					{
						modelEditorControl.RemoveFromView(drawingResult);
					}
					IModelEditorControl modelEditorControl2 = base.ModelEditorControl;
					Cursor arrow = System.Windows.Input.Cursors.Arrow;
					bool forceCursor = false;
					if (6 != 0)
					{
						modelEditorControl2.SetCursor(arrow, forceCursor);
					}
					bool flag = false;
					if (8 != 0)
					{
						this.IsSquareModeEnabled = flag;
					}
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

		// Token: 0x06006360 RID: 25440 RVA: 0x001841A4 File Offset: 0x001823A4
		public override void #1kb()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.PlanarRectangleDrawingResult;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
			Point3D? point3D = null;
			if (true)
			{
				this.SelectedStartPoint = point3D;
			}
			if (!false)
			{
				#oOc.#ead #ead = #oOc.#ead.#a;
				if (!false)
				{
					this.ToolState = #ead;
				}
			}
			if (false)
			{
				goto IL_45;
			}
			bool isWorking = false;
			if (!false)
			{
				base.IsWorking = isWorking;
			}
			IL_34:
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = null;
			if (!false)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			if (!false)
			{
				base.#1kb();
			}
			IL_45:
			if (2 != 0)
			{
				return;
			}
			goto IL_34;
		}

		// Token: 0x06006361 RID: 25441 RVA: 0x00184224 File Offset: 0x00182424
		public override void #fzb(Point3D #HAb, bool #gzb)
		{
			do
			{
				if (8 != 0)
				{
					base.#fzb(#HAb, #gzb);
				}
			}
			while (7 == 0);
			if (this.ToolState == #oOc.#ead.#a)
			{
				if (!false)
				{
					this.#wzb(#HAb);
				}
			}
			else
			{
				if (false)
				{
					return;
				}
				this.#jOc(#HAb);
			}
			IL_27:
			if (5 == 0)
			{
				goto IL_27;
			}
			if (#gzb)
			{
				#jUc #jUc = base.PreciseInputProvider;
				PreciseInputParameters initializeInputParameters = this.#DNc(false);
				if (!false)
				{
					#jUc.Update(initializeInputParameters);
				}
			}
		}

		// Token: 0x06006362 RID: 25442 RVA: 0x00184288 File Offset: 0x00182488
		protected void #wzb(Point3D #HAb)
		{
			Point3D? point3D = new Point3D?(#HAb);
			if (!false)
			{
				this.SelectedStartPoint = point3D;
			}
			if (4 != 0)
			{
				IPlanarRectangleDrawingResult planarRectangleDrawingResult = this.PlanarRectangleDrawingResult;
				Point3D startPoint = PointsConverter.#Csc(#HAb, 0.032);
				if (!false)
				{
					planarRectangleDrawingResult.StartPoint = startPoint;
				}
			}
			IPlanarRectangleDrawingResult planarRectangleDrawingResult2 = this.PlanarRectangleDrawingResult;
			Point3D endPoint = new Point3D(#HAb.X + 0.0001, #HAb.Y + 0.0001, 0.032);
			if (-1 != 0)
			{
				planarRectangleDrawingResult2.EndPoint = endPoint;
			}
			#oOc.#ead #ead = #oOc.#ead.#b;
			if (7 != 0)
			{
				this.ToolState = #ead;
			}
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.PlanarRectangleDrawingResult;
			if (!false)
			{
				modelEditorControl.AddToView(drawingResult);
			}
		}

		// Token: 0x06006363 RID: 25443 RVA: 0x00184338 File Offset: 0x00182538
		protected bool #jOc(Point3D #HAb)
		{
			Point3D point3D = this.#mOc(#HAb);
			if (3 != 0)
			{
				#HAb = point3D;
			}
			Point3D? point3D2 = this.SelectedStartPoint;
			Point3D? point3D3;
			if (!false)
			{
				point3D3 = point3D2;
			}
			if (point3D3 != null)
			{
				Point3D point3D4 = #HAb;
				Point3D #mcb;
				if (!false)
				{
					#mcb = point3D4;
				}
				Point3D? point3D5 = this.SelectedStartPoint;
				if (8 != 0)
				{
					point3D3 = point3D5;
				}
				for (;;)
				{
					IL_3C:
					int num = (point3D3 != null) ? 1 : 0;
					int num2;
					while (num == 0)
					{
						if ((num = (num2 = 1)) != 0)
						{
							IL_58:
							if (num2 == 0)
							{
								goto IL_D1;
							}
							Point3D? point3D6 = this.SelectedStartPoint;
							if (2 != 0)
							{
								point3D3 = point3D6;
							}
							if (6 == 0)
							{
								break;
							}
							if (GeometryHelper.#6nc(point3D3.Value, #HAb))
							{
								goto Block_6;
							}
							base.NotificationService.#1Ic(base.ToolInfo, Strings.StringTheResultingPolygonIsNotValid.#z2d(true) + Strings.StringOperationHasBeenCanceled.#z2d());
							if (!false)
							{
								goto Block_7;
							}
							goto IL_3C;
						}
					}
					num2 = (Point3D.#F3d(#mcb, point3D3.GetValueOrDefault()) ? 1 : 0);
					goto IL_58;
				}
				Block_6:
				IPlanarRectangleDrawingResult planarRectangleDrawingResult = this.PlanarRectangleDrawingResult;
				Point3D endPoint = PointsConverter.#Csc(#HAb, 0.032);
				if (false)
				{
					goto IL_93;
				}
				planarRectangleDrawingResult.EndPoint = endPoint;
				goto IL_93;
				Block_7:
				this.#1kb();
				goto IL_D1;
			}
			goto IL_D1;
			IL_93:
			return this.#nOc();
			IL_D1:
			if (!false)
			{
				return false;
			}
			goto IL_93;
		}

		// Token: 0x06006364 RID: 25444 RVA: 0x00184440 File Offset: 0x00182640
		protected override void #3kb(MouseButtonEventArgs #4kb)
		{
			if (6 == 0)
			{
				goto IL_55;
			}
			Point3D? point3D4;
			if (#4kb != null)
			{
				if (base.IsWorking || this.ToolState != #oOc.#ead.#a)
				{
					return;
				}
				Point3D? point3D = base.#HIc(#4kb);
				Point3D? point3D2;
				if (!false)
				{
					point3D2 = point3D;
				}
				if (point3D2 == null)
				{
					if (!false)
					{
						return;
					}
					return;
				}
				else
				{
					Point3D? point3D3 = this.#bNb(point3D2.Value).#Dtc();
					if (false)
					{
						goto IL_55;
					}
					point3D4 = point3D3;
					goto IL_55;
				}
			}
			IL_06:
			int num = 107465490;
			IL_0B:
			throw new ArgumentNullException(#Phc.#3hc(num));
			IL_55:
			if (false)
			{
				goto IL_06;
			}
			bool flag = (num = ((point3D4 != null) ? 1 : 0)) != 0;
			if (false)
			{
				goto IL_0B;
			}
			if (!flag)
			{
				return;
			}
			Point3D value = point3D4.Value;
			bool #gzb = false;
			if (5 != 0)
			{
				this.#fzb(value, #gzb);
			}
			bool isWorking = true;
			if (2 != 0)
			{
				base.IsWorking = isWorking;
			}
		}

		// Token: 0x06006365 RID: 25445 RVA: 0x001844DC File Offset: 0x001826DC
		protected override void #5kb(MouseButtonEventArgs #4kb)
		{
			if (#4kb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107465490));
			}
			if (this.ToolState != #oOc.#ead.#b)
			{
				return;
			}
			Point3D? point3D = base.#HIc(#4kb);
			Point3D? point3D2;
			if (5 != 0)
			{
				point3D2 = point3D;
			}
			if (point3D2 != null)
			{
				Point3D? point3D3 = this.SelectedStartPoint;
				Point3D? point3D4;
				if (!false)
				{
					point3D4 = point3D3;
				}
				if (point3D4 != null)
				{
					Point3D value = this.#mOc(point3D2.Value);
					if (!false)
					{
						point3D2 = new Point3D?(value);
					}
					Point3D? point3D5 = this.#bNb(point3D2.Value).#Dtc();
					Point3D? point3D6;
					if (!false)
					{
						point3D6 = point3D5;
					}
					if (point3D6 == null)
					{
						return;
					}
					Point3D value2 = point3D6.Value;
					bool #gzb = false;
					if (!false)
					{
						this.#fzb(value2, #gzb);
					}
					return;
				}
			}
		}

		// Token: 0x06006366 RID: 25446 RVA: 0x00184588 File Offset: 0x00182788
		protected override void #HEc(Point3D #IEc, Point3D #Kzb)
		{
			#Atc #Atc;
			for (;;)
			{
				Point3D #Kzb2 = #Kzb;
				if (!false)
				{
					base.#HEc(#IEc, #Kzb2);
				}
				if (this.ToolState != #oOc.#ead.#b)
				{
					break;
				}
				for (;;)
				{
					Point3D? point3D = this.SelectedStartPoint;
					Point3D? point3D2;
					if (true)
					{
						point3D2 = point3D;
					}
					if (point3D2 == null)
					{
						goto IL_2B;
					}
					if (false)
					{
						break;
					}
					Point3D point3D3 = this.#mOc(#Kzb);
					if (3 != 0)
					{
						#Kzb = point3D3;
					}
					#Atc = this.#bNb(#Kzb);
					base.SnapPointsMarker.Mark(#Atc);
					this.LastSnappedPosition = #Atc.Point;
					if (7 == 0)
					{
						goto IL_2B;
					}
					if (8 == 0)
					{
						return;
					}
					if (-1 != 0)
					{
						goto Block_3;
					}
				}
			}
			IL_2B:
			#Atc #Atc2 = this.#bNb(#Kzb);
			#Atc #Atc3;
			if (7 != 0)
			{
				#Atc3 = #Atc2;
			}
			ISnapPointsMarker snapPointsMarker = base.SnapPointsMarker;
			#Atc snapToPointResult = #Atc3;
			if (!false)
			{
				snapPointsMarker.Mark(snapToPointResult);
			}
			Point3D point3D4 = #Atc3.Point;
			if (5 != 0)
			{
				this.LastSnappedPosition = point3D4;
			}
			return;
			Block_3:
			this.#kOc(#Atc.Point);
		}

		// Token: 0x06006367 RID: 25447 RVA: 0x00184658 File Offset: 0x00182858
		protected override void #GEc(KeyEventArgs #HA)
		{
			for (;;)
			{
				if (!false)
				{
					bool flag = #HA != null && (#HA.Key == Key.RightCtrl || #HA.Key == Key.LeftCtrl);
					if (-1 != 0)
					{
						this.IsSquareModeEnabled = flag;
					}
				}
				while (!false)
				{
					if (6 != 0)
					{
						base.#GEc(#HA);
					}
					if (!false)
					{
						return;
					}
				}
			}
		}

		// Token: 0x06006368 RID: 25448 RVA: 0x00050DBE File Offset: 0x0004EFBE
		protected override void #2kb(KeyEventArgs #HA)
		{
			for (;;)
			{
				if (#HA == null || (#HA.Key != Key.RightCtrl && #HA.Key != Key.LeftCtrl))
				{
					goto IL_21;
				}
				if (true)
				{
					bool flag = false;
					if (false)
					{
						goto IL_21;
					}
					this.IsSquareModeEnabled = flag;
					goto IL_21;
				}
				IL_28:
				if (7 != 0)
				{
					break;
				}
				continue;
				IL_21:
				if (false)
				{
					goto IL_28;
				}
				base.#2kb(#HA);
				goto IL_28;
			}
		}

		// Token: 0x06006369 RID: 25449 RVA: 0x00050DF9 File Offset: 0x0004EFF9
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

		// Token: 0x0600636A RID: 25450 RVA: 0x001846A8 File Offset: 0x001828A8
		protected override void #fIc(PreciseInputChangedEventArgs #gIc)
		{
			Point3D? point3D = #aJc.#9Ic(#gIc);
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			if (point3D2 != null)
			{
				IModelEditorControl modelEditorControl = base.ModelEditorControl;
				IDrawingResult drawingResult = this.#b;
				if (!false)
				{
					modelEditorControl.AddToView(drawingResult);
				}
				ICrossIndicatorDrawingResult crossIndicatorDrawingResult = this.#b;
				Point3D value = point3D2.Value;
				if (8 != 0)
				{
					crossIndicatorDrawingResult.CenterPoint = value;
				}
				if (this.ToolState == #oOc.#ead.#b)
				{
					Point3D? point3D3 = point3D2;
					Point3D? point3D4;
					if (3 != 0)
					{
						point3D4 = point3D3;
					}
					Point3D? point3D5 = this.SelectedStartPoint;
					Point3D? point3D6;
					if (!false)
					{
						point3D6 = point3D5;
					}
					Point3D? point3D7;
					if (point3D4 != null != (point3D6 != null) || (point3D4 != null && !Point3D.#E3d(point3D4.GetValueOrDefault(), point3D6.GetValueOrDefault())))
					{
						point3D7 = point3D2;
					}
					else
					{
						Point3D value2 = point3D2.Value;
						Point3D point3D8;
						if (!false)
						{
							point3D8 = value2;
						}
						if (false)
						{
							return;
						}
						double num = point3D8.X;
						double x;
						do
						{
							x = (num += 0.0001);
						}
						while (2 == 0);
						point3D8 = point3D2.Value;
						double y;
						double num2 = y = point3D8.Y;
						double z;
						double num3 = z = 0.0001;
						if (!false && -1 != 0)
						{
							y = num2 + num3;
							z = 0.0;
						}
						point3D7 = new Point3D?(new Point3D(x, y, z));
					}
					point3D2 = point3D7;
					this.#kOc(point3D2.Value);
				}
				return;
			}
		}

		// Token: 0x0600636B RID: 25451 RVA: 0x00181EF4 File Offset: 0x001800F4
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

		// Token: 0x0600636C RID: 25452 RVA: 0x00050E30 File Offset: 0x0004F030
		protected override void #hIc()
		{
			IModelEditorControl modelEditorControl = base.ModelEditorControl;
			IDrawingResult drawingResult = this.#b;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
		}

		// Token: 0x0600636D RID: 25453 RVA: 0x00050E4A File Offset: 0x0004F04A
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

		// Token: 0x0600636E RID: 25454 RVA: 0x00050E63 File Offset: 0x0004F063
		protected void #kOc(Point3D #lOc)
		{
			IPlanarRectangleDrawingResult planarRectangleDrawingResult = this.PlanarRectangleDrawingResult;
			Point3D endPoint = PointsConverter.#Csc(this.#mOc(#lOc), 0.032);
			if (4 != 0)
			{
				planarRectangleDrawingResult.EndPoint = endPoint;
			}
		}

		// Token: 0x0600636F RID: 25455 RVA: 0x00050E8C File Offset: 0x0004F08C
		protected #Atc #bNb(Point3D #Kzb)
		{
			return base.SnappingProvider.#bNb(base.ProjectContext.SnappingModes, #Kzb);
		}

		// Token: 0x17001C0C RID: 7180
		// (get) Token: 0x06006370 RID: 25456 RVA: 0x00050EA5 File Offset: 0x0004F0A5
		// (set) Token: 0x06006371 RID: 25457 RVA: 0x001847E4 File Offset: 0x001829E4
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public ToolDrawingMode ToolDrawingMode
		{
			get
			{
				return this.#a;
			}
			set
			{
				for (;;)
				{
					if (this.#a == value)
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
						this.#a = value;
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

		// Token: 0x06006372 RID: 25458 RVA: 0x00184838 File Offset: 0x00182A38
		private Point3D #mOc(Point3D #Ng)
		{
			Point3D? point3D = this.SelectedStartPoint;
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			if (this.IsSquareModeEnabled && point3D2 != null)
			{
				double num = #Ng.X;
				Point3D value = point3D2.Value;
				Point3D point3D3;
				if (!false)
				{
					point3D3 = value;
				}
				double value2;
				double value4;
				double num7;
				double num8;
				double num10;
				double num9;
				int num12;
				double num13;
				for (;;)
				{
					double num2 = num - point3D3.X;
					if (3 != 0)
					{
						value2 = num2;
					}
					double num3 = #Ng.Y;
					Point3D value3 = point3D2.Value;
					if (7 != 0)
					{
						point3D3 = value3;
					}
					double num4 = point3D3.Y;
					for (;;)
					{
						double num5 = num3 - num4;
						if (!false)
						{
							value4 = num5;
						}
						Point3D value5 = point3D2.Value;
						if (4 != 0)
						{
							point3D3 = value5;
						}
						double num6 = num = point3D3.X;
						if (7 == 0)
						{
							break;
						}
						num7 = num6;
						point3D3 = point3D2.Value;
						num8 = point3D3.Y;
						if (5 == 0)
						{
							return #Ng;
						}
						if (Math.Abs(value2) > Math.Abs(value4))
						{
							goto Block_5;
						}
						num9 = (num3 = (num10 = num8));
						double num11 = (double)(num12 = Math.Sign(value4));
						if (false)
						{
							goto IL_AF;
						}
						num13 = (num4 = num11);
						if (6 != 0)
						{
							goto Block_7;
						}
					}
				}
				Block_5:
				num10 = num7;
				num12 = Math.Sign(value2);
				IL_AF:
				num7 = num10 + (double)num12 * Math.Abs(value4);
				num8 = #Ng.Y;
				goto IL_E8;
				Block_7:
				num8 = num9 + num13 * Math.Abs(value2);
				num7 = #Ng.X;
				IL_E8:
				#Ng = new Point3D(num7, num8, 0.0);
			}
			return #Ng;
		}

		// Token: 0x06006373 RID: 25459 RVA: 0x00184968 File Offset: 0x00182B68
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
			#GJc.Message = this.#d[this.ToolState];
			#oW #oW = base.ProjectContext;
			if (8 != 0)
			{
				#GJc.ProjectContext = #oW;
			}
			return #aJc.#7Ic(#GJc);
		}

		// Token: 0x06006374 RID: 25460 RVA: 0x00184A18 File Offset: 0x00182C18
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catch unexpected errors.")]
		protected bool #nOc()
		{
			IList<Point3D> list = null;
			IList<Point3D> list2;
			if (5 != 0)
			{
				list2 = list;
			}
			try
			{
				IList<Point3D> list3 = PointsConverter.#Csc(this.PlanarRectangleDrawingResult.CalculatePoints(), 0.0);
				if (!false)
				{
					list2 = list3;
				}
			}
			catch (Exception #ob)
			{
				base.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107445383), base.ToolInfo);
			}
			if (list2 == null || list2.Count < PolygonData.MinNumberOfPoints)
			{
				return false;
			}
			try
			{
				#bDc #bDc = base.UndoManager;
				if (2 != 0)
				{
					#bDc.#uCc();
				}
				PolygonType polygonType = this.IsSquareModeEnabled ? PolygonType.Square : PolygonType.Rectangle;
				int result;
				if (2 != 0)
				{
					PolygonType #ZDc;
					if (5 != 0)
					{
						#ZDc = polygonType;
					}
					for (;;)
					{
						if (this.ToolDrawingMode == ToolDrawingMode.Union)
						{
							if (!base.ToolOperationsHelper.#0Dc(list2, #ZDc))
							{
								break;
							}
						}
						else if (this.ToolDrawingMode == ToolDrawingMode.Cut && !base.ToolOperationsHelper.#VDc(list2, base.ToolContext.ToolsConfiguration.LeaveCuttingPolygon, #ZDc))
						{
							goto Block_12;
						}
						if (!false)
						{
							this.#zIc();
						}
						if (!false)
						{
							goto Block_14;
						}
					}
					throw new #vYd(#Phc.#3hc(107445362), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
					Block_12:
					int num = result = 107445309;
					if (num != 0)
					{
						throw new #vYd(#Phc.#3hc(num), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI);
					}
					goto IL_103;
					Block_14:
					base.ToolOperationsHelper.#bEc();
				}
				if (6 != 0)
				{
					base.#MIc();
				}
				result = 1;
				IL_103:
				return result != 0;
			}
			catch (ModelValidationException #PIc)
			{
				base.#OIc(#PIc);
			}
			catch (#vYd #3Pb)
			{
				base.#2Pb(#3Pb);
			}
			catch (Exception #ob2)
			{
				base.ErrorsHandlingService.#bzc(#ob2, #Phc.#3hc(107445736), base.ToolInfo);
				base.UndoManager.#yCc(false);
			}
			finally
			{
				base.UndoManager.#vCc();
				this.#1kb();
			}
			return false;
		}

		// Token: 0x06006375 RID: 25461 RVA: 0x00184C28 File Offset: 0x00182E28
		public string #vNc(#ivc #rmc, Point #Ng)
		{
			Point3D? point3D = this.SelectedStartPoint;
			Point3D? point3D2;
			if (true)
			{
				point3D2 = point3D;
			}
			if (!false)
			{
				if (point3D2 == null)
				{
					return null;
				}
				Point3D? point3D3 = this.SelectedStartPoint;
				if (!false)
				{
					point3D2 = point3D3;
				}
			}
			Point point = PointsConverter.#vsc(point3D2.Value);
			Point point2;
			if (!false)
			{
				point2 = point;
			}
			double num2;
			if (#rmc != #ivc.#a)
			{
				if (!false && #rmc != #ivc.#b)
				{
					goto IL_7A;
				}
				double num = num2 = point2.Y;
				if (!false && !false)
				{
					if (num == #Ng.Y)
					{
						return Strings.StringCouldNotCreateRectangleFromTheGivenParameters.#z2d();
					}
					goto IL_7A;
				}
			}
			else
			{
				num2 = point2.X;
			}
			if (num2 == #Ng.X)
			{
				return Strings.StringCouldNotCreateRectangleFromTheGivenParameters.#z2d();
			}
			IL_7A:
			return null;
		}

		// Token: 0x06006376 RID: 25462 RVA: 0x00050EAD File Offset: 0x0004F0AD
		protected void #1(bool #POb)
		{
			Cursor cursor = this.#c;
			if (!false)
			{
				cursor.Dispose();
			}
		}

		// Token: 0x06006377 RID: 25463 RVA: 0x00050EC2 File Offset: 0x0004F0C2
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

		// Token: 0x040028C6 RID: 10438
		private ToolDrawingMode #a;

		// Token: 0x040028C7 RID: 10439
		private readonly ICrossIndicatorDrawingResult #b;

		// Token: 0x040028C8 RID: 10440
		private readonly Cursor #c;

		// Token: 0x040028C9 RID: 10441
		private readonly IDictionary<#oOc.#ead, string> #d;

		// Token: 0x040028CA RID: 10442
		[CompilerGenerated]
		private Point3D? #e;

		// Token: 0x040028CB RID: 10443
		[CompilerGenerated]
		private IPlanarRectangleDrawingResult #f;

		// Token: 0x040028CC RID: 10444
		[CompilerGenerated]
		private bool #g;

		// Token: 0x040028CD RID: 10445
		[CompilerGenerated]
		private #oOc.#ead #h;

		// Token: 0x040028CE RID: 10446
		[CompilerGenerated]
		private Point3D #i;

		// Token: 0x02000BF0 RID: 3056
		protected enum #ead
		{
			// Token: 0x040028D0 RID: 10448
			#a,
			// Token: 0x040028D1 RID: 10449
			#b
		}
	}
}
