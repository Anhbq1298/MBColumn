using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using #pXd;
using #UYd;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Labels;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Resources.Cursors;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.CoreAssets.Units;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor
{
	// Token: 0x0200064C RID: 1612
	public class EyeshotEditor : Model
	{
		// Token: 0x06003618 RID: 13848 RVA: 0x0002F64D File Offset: 0x0002D84D
		public EyeshotEditor() : this(false)
		{
		}

		// Token: 0x06003619 RID: 13849 RVA: 0x0002F656 File Offset: 0x0002D856
		public EyeshotEditor(bool is2DViewport) : this(is2DViewport, EditorHardwareAccelerationHelper.TopViewport.IsHardwareAccelerationEnabled)
		{
		}

		// Token: 0x0600361A RID: 13850 RVA: 0x00109E30 File Offset: 0x00108030
		public EyeshotEditor(bool is2DViewport, bool enableHardwareAcceleration)
		{
			this.Is2DViewport = is2DViewport;
			base.Unlock(#Phc.#3hc(107423690));
			this.DynamicInput = new DynamicInputProvider
			{
				Editor = this
			};
			base.ProgressBar = new ProgressBar(ProgressBar.styleType.Circular, 0, #Phc.#3hc(107423653), System.Drawing.Color.Black, System.Drawing.Color.White, System.Drawing.Color.Green, 1.0, false)
			{
				Lighting = false,
				ShowPercentText = false,
				DrawScale = 0.6,
				CancelButton = 
				{
					Visible = false
				}
			};
			this.DynamicInput.CoordinateChanged += this.HandleDynamicInputCoordinateChange;
			this.DynamicInput.CoordinateCommited += this.HandleDynamicInputCoordinateCommited;
			this.DynamicInput.ValidatingCoordinate += this.HandleDynamicInputCoordinateValidation;
			this.DynamicInput.CoordinateSnapRequested += this.DynamicInputCoordinateSnapRequested;
			this.Configure();
			base.Renderer = rendererType.OpenGL;
			this.DisplayMode = displayType.Flat;
			base.AskForHardwareAcceleration = enableHardwareAcceleration;
			base.AccurateTransparency = true;
			base.WaitCursorMode = waitCursorType.Never;
			base.Rendered = new DisplayModeSettingsRendered
			{
				RealisticShadowQuality = realisticShadowQualityType.High,
				EnvironmentMapping = false,
				SilhouettesDrawingMode = silhouettesDrawingType.Never,
				ShadowMode = shadowType.None,
				ShowEdges = true
			};
			base.Flat = new DisplayModeSettingsFlat
			{
				SilhouettesDrawingMode = silhouettesDrawingType.Never,
				ShowEdges = true,
				ColorMethod = flatColorMethodType.EntityMaterial,
				ShowInternalWires = true
			};
			base.PlanarShadowOpacity = 0.0;
			this.activeTools = ArrayList.Synchronized(new List<EyeshotEditorTool>());
			this.editionPlane = Plane.XY;
			base.ViewportBorder.Visible = false;
			base.ViewportBorder.Color = System.Windows.Media.Brushes.White;
			this.drawingHelper = new DrawingHelper(this);
			this.BusyMessageFont = FontsCache.GetOrCreate(#Phc.#3hc(107399885), 12f);
			base.Loaded += this.EyeshotEditorLoaded;
			base.Unloaded += this.EyeshotEditor_Unloaded;
			base.SizeChanged += this.EyeshotEditorSizeChanged;
			base.ErrorOccurred += this.EyeshotEditor_ErrorOccurred;
		}

		// Token: 0x140000CE RID: 206
		// (add) Token: 0x0600361B RID: 13851 RVA: 0x0010A184 File Offset: 0x00108384
		// (remove) Token: 0x0600361C RID: 13852 RVA: 0x0010A1BC File Offset: 0x001083BC
		public event EventHandler<ActionModeChangedEventArgs> ActionModeChanged;

		// Token: 0x140000CF RID: 207
		// (add) Token: 0x0600361D RID: 13853 RVA: 0x0010A1F4 File Offset: 0x001083F4
		// (remove) Token: 0x0600361E RID: 13854 RVA: 0x0010A22C File Offset: 0x0010842C
		public event EventHandler CameraMoved;

		// Token: 0x140000D0 RID: 208
		// (add) Token: 0x0600361F RID: 13855 RVA: 0x0010A264 File Offset: 0x00108464
		// (remove) Token: 0x06003620 RID: 13856 RVA: 0x0010A29C File Offset: 0x0010849C
		public event EventHandler ViewFitted;

		// Token: 0x170010DF RID: 4319
		// (get) Token: 0x06003621 RID: 13857 RVA: 0x0002F669 File Offset: 0x0002D869
		public RenderContextBase RenderContext
		{
			get
			{
				return base.renderContext;
			}
		}

		// Token: 0x170010E0 RID: 4320
		// (get) Token: 0x06003622 RID: 13858 RVA: 0x0002F671 File Offset: 0x0002D871
		// (set) Token: 0x06003623 RID: 13859 RVA: 0x0002F683 File Offset: 0x0002D883
		public bool ZoomToModelButtonVisibility
		{
			get
			{
				return this.ViewPortConfigurator.ZoomToModelButton.Visible;
			}
			set
			{
				this.ViewPortConfigurator.ZoomToModelButton.Visible = value;
			}
		}

		// Token: 0x170010E1 RID: 4321
		// (get) Token: 0x06003624 RID: 13860 RVA: 0x0002F696 File Offset: 0x0002D896
		// (set) Token: 0x06003625 RID: 13861 RVA: 0x0002F6A3 File Offset: 0x0002D8A3
		public displayType DisplayMode
		{
			get
			{
				return base.ActiveViewport.DisplayMode;
			}
			set
			{
				base.ActiveViewport.DisplayMode = value;
			}
		}

		// Token: 0x170010E2 RID: 4322
		// (get) Token: 0x06003626 RID: 13862 RVA: 0x0002F6B1 File Offset: 0x0002D8B1
		// (set) Token: 0x06003627 RID: 13863 RVA: 0x0002F6BE File Offset: 0x0002D8BE
		public Camera Camera
		{
			get
			{
				return base.ActiveViewport.Camera;
			}
			set
			{
				base.ActiveViewport.Camera = value;
			}
		}

		// Token: 0x170010E3 RID: 4323
		// (get) Token: 0x06003628 RID: 13864 RVA: 0x0002F6CC File Offset: 0x0002D8CC
		// (set) Token: 0x06003629 RID: 13865 RVA: 0x0002F6D9 File Offset: 0x0002D8D9
		public ZoomSettings Zoom
		{
			get
			{
				return base.ActiveViewport.Zoom;
			}
			set
			{
				base.ActiveViewport.Zoom = value;
			}
		}

		// Token: 0x170010E4 RID: 4324
		// (get) Token: 0x0600362A RID: 13866 RVA: 0x0002F6E7 File Offset: 0x0002D8E7
		// (set) Token: 0x0600362B RID: 13867 RVA: 0x0002F6F4 File Offset: 0x0002D8F4
		public PanSettings Pan
		{
			get
			{
				return base.ActiveViewport.Pan;
			}
			set
			{
				base.ActiveViewport.Pan = value;
			}
		}

		// Token: 0x170010E5 RID: 4325
		// (get) Token: 0x0600362C RID: 13868 RVA: 0x0002F702 File Offset: 0x0002D902
		// (set) Token: 0x0600362D RID: 13869 RVA: 0x0002F70F File Offset: 0x0002D90F
		public RotateSettings Rotate
		{
			get
			{
				return base.ActiveViewport.Rotate;
			}
			set
			{
				base.ActiveViewport.Rotate = value;
			}
		}

		// Token: 0x170010E6 RID: 4326
		// (get) Token: 0x0600362E RID: 13870 RVA: 0x0002F71D File Offset: 0x0002D91D
		// (set) Token: 0x0600362F RID: 13871 RVA: 0x0002F72A File Offset: 0x0002D92A
		public LabelList Labels
		{
			get
			{
				return base.ActiveViewport.Labels;
			}
			set
			{
				base.ActiveViewport.Labels = value;
			}
		}

		// Token: 0x170010E7 RID: 4327
		// (get) Token: 0x06003630 RID: 13872 RVA: 0x0002F738 File Offset: 0x0002D938
		public ITextTextureCache TextTextureCache { get; } = new TextTextureCache();

		// Token: 0x170010E8 RID: 4328
		// (get) Token: 0x06003631 RID: 13873 RVA: 0x0002F740 File Offset: 0x0002D940
		public bool Is2DViewport { get; }

		// Token: 0x170010E9 RID: 4329
		// (get) Token: 0x06003632 RID: 13874 RVA: 0x0002F748 File Offset: 0x0002D948
		// (set) Token: 0x06003633 RID: 13875 RVA: 0x0002F750 File Offset: 0x0002D950
		public ILogger Logger { get; set; }

		// Token: 0x170010EA RID: 4330
		// (get) Token: 0x06003634 RID: 13876 RVA: 0x0002F759 File Offset: 0x0002D959
		public List<string> OsdMessages { get; } = new List<string>();

		// Token: 0x170010EB RID: 4331
		// (get) Token: 0x06003635 RID: 13877 RVA: 0x0002F761 File Offset: 0x0002D961
		// (set) Token: 0x06003636 RID: 13878 RVA: 0x0002F769 File Offset: 0x0002D969
		public string BusyText { get; set; }

		// Token: 0x170010EC RID: 4332
		// (get) Token: 0x06003637 RID: 13879 RVA: 0x0002F772 File Offset: 0x0002D972
		public static string SafeFontName { get; } = #Phc.#3hc(107422912);

		// Token: 0x170010ED RID: 4333
		// (get) Token: 0x06003638 RID: 13880 RVA: 0x0002F779 File Offset: 0x0002D979
		// (set) Token: 0x06003639 RID: 13881 RVA: 0x0002F781 File Offset: 0x0002D981
		public DefaultViewPortConfigurator ViewPortConfigurator { get; private set; }

		// Token: 0x170010EE RID: 4334
		// (get) Token: 0x0600363A RID: 13882 RVA: 0x0002F78A File Offset: 0x0002D98A
		// (set) Token: 0x0600363B RID: 13883 RVA: 0x0002F792 File Offset: 0x0002D992
		public Plane EditionPlane
		{
			get
			{
				return this.editionPlane;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107386484));
				}
				this.editionPlane = value;
			}
		}

		// Token: 0x170010EF RID: 4335
		// (get) Token: 0x0600363C RID: 13884 RVA: 0x0002F7AF File Offset: 0x0002D9AF
		// (set) Token: 0x0600363D RID: 13885 RVA: 0x0002F7B7 File Offset: 0x0002D9B7
		public System.Drawing.Point ScreenPosition { get; private set; }

		// Token: 0x170010F0 RID: 4336
		// (get) Token: 0x0600363E RID: 13886 RVA: 0x0002F7C0 File Offset: 0x0002D9C0
		// (set) Token: 0x0600363F RID: 13887 RVA: 0x0002F7C8 File Offset: 0x0002D9C8
		public Point3D PlanePosition { get; private set; }

		// Token: 0x170010F1 RID: 4337
		// (get) Token: 0x06003640 RID: 13888 RVA: 0x0002F7D1 File Offset: 0x0002D9D1
		public Viewport DefaultViewport { get; } = new Viewport();

		// Token: 0x170010F2 RID: 4338
		// (get) Token: 0x06003641 RID: 13889 RVA: 0x0002F7D9 File Offset: 0x0002D9D9
		public DynamicInputProvider DynamicInput { get; }

		// Token: 0x170010F3 RID: 4339
		// (get) Token: 0x06003642 RID: 13890 RVA: 0x0002F7E1 File Offset: 0x0002D9E1
		// (set) Token: 0x06003643 RID: 13891 RVA: 0x0002F7E9 File Offset: 0x0002D9E9
		public Point3D UpperRightWorldCoord { get; private set; } = new Point3D();

		// Token: 0x170010F4 RID: 4340
		// (get) Token: 0x06003644 RID: 13892 RVA: 0x0002F7F2 File Offset: 0x0002D9F2
		// (set) Token: 0x06003645 RID: 13893 RVA: 0x0002F7FA File Offset: 0x0002D9FA
		public Point3D LowerLeftWorldCoord { get; private set; } = new Point3D();

		// Token: 0x170010F5 RID: 4341
		// (get) Token: 0x06003646 RID: 13894 RVA: 0x0002F803 File Offset: 0x0002DA03
		// (set) Token: 0x06003647 RID: 13895 RVA: 0x0002F80B File Offset: 0x0002DA0B
		public bool IsMouseWithEditor { get; private set; }

		// Token: 0x170010F6 RID: 4342
		// (get) Token: 0x06003648 RID: 13896 RVA: 0x0002F814 File Offset: 0x0002DA14
		// (set) Token: 0x06003649 RID: 13897 RVA: 0x0002F81C File Offset: 0x0002DA1C
		public bool IgnoreNextMouseDown { get; set; }

		// Token: 0x170010F7 RID: 4343
		// (get) Token: 0x0600364A RID: 13898 RVA: 0x0002F825 File Offset: 0x0002DA25
		// (set) Token: 0x0600364B RID: 13899 RVA: 0x0002F82D File Offset: 0x0002DA2D
		public DateTime IgnoreNextMouseDownTimestamp { get; set; } = DateTime.MinValue;

		// Token: 0x170010F8 RID: 4344
		// (get) Token: 0x0600364C RID: 13900 RVA: 0x0002F836 File Offset: 0x0002DA36
		// (set) Token: 0x0600364D RID: 13901 RVA: 0x0002F83E File Offset: 0x0002DA3E
		public TimeSpan IgnoreNextMouseDownTimestampThreshold { get; set; } = TimeSpan.FromMilliseconds(350.0);

		// Token: 0x170010F9 RID: 4345
		// (get) Token: 0x0600364E RID: 13902 RVA: 0x0002F847 File Offset: 0x0002DA47
		// (set) Token: 0x0600364F RID: 13903 RVA: 0x0002F84F File Offset: 0x0002DA4F
		private protected RectangleF ToolbarExtent { protected get; private set; }

		// Token: 0x170010FA RID: 4346
		// (get) Token: 0x06003650 RID: 13904 RVA: 0x0002F858 File Offset: 0x0002DA58
		// (set) Token: 0x06003651 RID: 13905 RVA: 0x0002F860 File Offset: 0x0002DA60
		private protected RectangleF ViewCubeExtent { protected get; private set; }

		// Token: 0x170010FB RID: 4347
		// (get) Token: 0x06003652 RID: 13906 RVA: 0x0002F869 File Offset: 0x0002DA69
		// (set) Token: 0x06003653 RID: 13907 RVA: 0x0002F871 File Offset: 0x0002DA71
		public bool DrawToolsOverlay { get; set; } = true;

		// Token: 0x170010FC RID: 4348
		// (get) Token: 0x06003654 RID: 13908 RVA: 0x0002F87A File Offset: 0x0002DA7A
		// (set) Token: 0x06003655 RID: 13909 RVA: 0x0002F882 File Offset: 0x0002DA82
		public bool CheckTextIsInView { get; set; } = true;

		// Token: 0x170010FD RID: 4349
		// (get) Token: 0x06003656 RID: 13910 RVA: 0x0002F88B File Offset: 0x0002DA8B
		// (set) Token: 0x06003657 RID: 13911 RVA: 0x0002F893 File Offset: 0x0002DA93
		public int ZoomFitMarginAddition
		{
			get
			{
				return this.zoomFitMarginAddition;
			}
			set
			{
				this.zoomFitMarginAddition = value;
				this.RecalculateZoomFitMargin();
			}
		}

		// Token: 0x170010FE RID: 4350
		// (get) Token: 0x06003658 RID: 13912 RVA: 0x0002F8A2 File Offset: 0x0002DAA2
		// (set) Token: 0x06003659 RID: 13913 RVA: 0x0002F8AA File Offset: 0x0002DAAA
		public double DpiScaleX { get; private set; }

		// Token: 0x170010FF RID: 4351
		// (get) Token: 0x0600365A RID: 13914 RVA: 0x0002F8B3 File Offset: 0x0002DAB3
		// (set) Token: 0x0600365B RID: 13915 RVA: 0x0002F8BB File Offset: 0x0002DABB
		public double DpiScaleY { get; private set; }

		// Token: 0x17001100 RID: 4352
		// (get) Token: 0x0600365C RID: 13916 RVA: 0x0002F8C4 File Offset: 0x0002DAC4
		// (set) Token: 0x0600365D RID: 13917 RVA: 0x0002F8CC File Offset: 0x0002DACC
		public Action ZoomToWorkspaceOverride { get; set; }

		// Token: 0x17001101 RID: 4353
		// (get) Token: 0x0600365E RID: 13918 RVA: 0x0002F8D5 File Offset: 0x0002DAD5
		// (set) Token: 0x0600365F RID: 13919 RVA: 0x0002F8DD File Offset: 0x0002DADD
		public Action ViewHomeOverride { get; set; }

		// Token: 0x17001102 RID: 4354
		// (get) Token: 0x06003660 RID: 13920 RVA: 0x0002F8E6 File Offset: 0x0002DAE6
		// (set) Token: 0x06003661 RID: 13921 RVA: 0x0002F8EE File Offset: 0x0002DAEE
		public bool SupportBeginMouseMove { get; set; } = true;

		// Token: 0x17001103 RID: 4355
		// (get) Token: 0x06003662 RID: 13922 RVA: 0x0002F8F7 File Offset: 0x0002DAF7
		// (set) Token: 0x06003663 RID: 13923 RVA: 0x0002F8FF File Offset: 0x0002DAFF
		public Font BusyMessageFont { get; set; }

		// Token: 0x17001104 RID: 4356
		// (get) Token: 0x06003664 RID: 13924 RVA: 0x0002F908 File Offset: 0x0002DB08
		// (set) Token: 0x06003665 RID: 13925 RVA: 0x0002F910 File Offset: 0x0002DB10
		public System.Drawing.Color BusyMessageBackground { get; set; } = System.Drawing.Color.FromArgb(153, 255, 255, 255);

		// Token: 0x17001105 RID: 4357
		// (get) Token: 0x06003666 RID: 13926 RVA: 0x0002F919 File Offset: 0x0002DB19
		// (set) Token: 0x06003667 RID: 13927 RVA: 0x0002F921 File Offset: 0x0002DB21
		public System.Drawing.Color BusyMessageForeground { get; set; } = System.Drawing.Color.Black;

		// Token: 0x17001106 RID: 4358
		// (get) Token: 0x06003668 RID: 13928 RVA: 0x0002F92A File Offset: 0x0002DB2A
		// (set) Token: 0x06003669 RID: 13929 RVA: 0x0002F932 File Offset: 0x0002DB32
		public System.Drawing.Color BusyMessageBorder { get; set; } = System.Drawing.Color.FromArgb(255, 132, 132, 132);

		// Token: 0x0600366A RID: 13930 RVA: 0x0010A2D4 File Offset: 0x001084D4
		public CameraSettings GetCurrentCameraSettings()
		{
			return new CameraSettings
			{
				ZoomFactor = this.Camera.ZoomFactor,
				Rotation = (Quaternion)this.Camera.Rotation.Clone(),
				Distance = this.Camera.Distance,
				Location = (Point3D)this.Camera.Location.Clone(),
				Target = (Point3D)this.Camera.Target.Clone()
			};
		}

		// Token: 0x0600366B RID: 13931 RVA: 0x0010A35C File Offset: 0x0010855C
		public void RestoreCameraSettings(CameraSettings settings)
		{
			if (settings == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382678));
			}
			this.Camera.Rotation = settings.Rotation;
			this.Camera.Location = settings.Location;
			this.Camera.Target = settings.Target;
			if (this.Camera.ProjectionMode == projectionType.Orthographic)
			{
				this.Camera.ZoomFactor = settings.ZoomFactor;
			}
			else
			{
				this.Camera.Distance = settings.Distance;
			}
			this.Camera.UpdateLocation();
			this.Camera.UpdateMatrices();
			base.AdjustNearAndFarPlanes();
			base.Invalidate();
		}

		// Token: 0x0600366C RID: 13932 RVA: 0x0002F93B File Offset: 0x0002DB3B
		public double DpiScaleUpX(double value)
		{
			return value * this.DpiScaleX;
		}

		// Token: 0x0600366D RID: 13933 RVA: 0x0002F945 File Offset: 0x0002DB45
		public double DpiScaleUpY(double value)
		{
			return value * this.DpiScaleY;
		}

		// Token: 0x0600366E RID: 13934 RVA: 0x0002F94F File Offset: 0x0002DB4F
		public System.Windows.Point DpiScaleDown(System.Windows.Point point)
		{
			point.X /= this.DpiScaleX;
			point.Y /= this.DpiScaleY;
			return point;
		}

		// Token: 0x0600366F RID: 13935 RVA: 0x0002F97C File Offset: 0x0002DB7C
		public TPoint DpiScaleDown<TPoint>(TPoint point) where TPoint : Point2D
		{
			point.X /= this.DpiScaleX;
			point.Y /= this.DpiScaleY;
			return point;
		}

		// Token: 0x06003670 RID: 13936 RVA: 0x0010A404 File Offset: 0x00108604
		public void ResetActionMode()
		{
			actionType actionMode = base.ActionMode;
			if (actionMode != actionType.None)
			{
				base.ActionMode = actionType.None;
				this.ViewPortConfigurator.DisableToggleButton(actionMode);
				base.CompileUserInterfaceElements();
				base.Invalidate();
			}
		}

		// Token: 0x06003671 RID: 13937 RVA: 0x0002F9B9 File Offset: 0x0002DBB9
		public void EmptyTextureCache()
		{
			this.TextTextureCache.EmptyCache();
		}

		// Token: 0x06003672 RID: 13938 RVA: 0x0002F9C6 File Offset: 0x0002DBC6
		public bool HasFocusExt()
		{
			return this.hasFocus;
		}

		// Token: 0x06003673 RID: 13939 RVA: 0x0002F9CE File Offset: 0x0002DBCE
		public void SetFocusExt()
		{
			if (!this.hasFocus && !this.isDisposed)
			{
				Ignore.#14d<NullReferenceException>(delegate()
				{
					base.SetFocus(null);
				}, null);
			}
		}

		// Token: 0x06003674 RID: 13940 RVA: 0x0010A43C File Offset: 0x0010863C
		public override void Dispose()
		{
			if (this.isDisposed)
			{
				return;
			}
			this.isDisposed = true;
			#uzc #uzc = new #uzc(#Phc.#3hc(107423664));
			base.Entities.Clear();
			base.AdjustNearAndFarPlanes();
			base.UpdateBoundingBox();
			this.ZoomFit();
			#uzc.#szc(#Phc.#3hc(107423635));
			base.RemoveMessageFilter();
			#uzc.#szc(#Phc.#3hc(107423610));
			WindowsFormsHost windowsFormsHost = this.ParentOfType<WindowsFormsHost>();
			if (windowsFormsHost != null)
			{
				windowsFormsHost.#DXd();
			}
			#uzc.#szc(#Phc.#3hc(107423581));
			foreach (EyeshotEditorTool eyeshotEditorTool in this.activeTools.OfType<EyeshotEditorTool>().ToList<EyeshotEditorTool>())
			{
				try
				{
					this.DeactivateTool(eyeshotEditorTool);
					#uzc.#szc(#Phc.#3hc(107423548) + eyeshotEditorTool.GetType().Name);
				}
				catch (Exception value)
				{
					Console.WriteLine(value);
				}
			}
			this.activeTools.Clear();
			base.Dispose();
			#uzc.#szc(#Phc.#3hc(107423491));
			base.RemoveMessageFilter();
			#uzc.#szc(#Phc.#3hc(107423610));
			base.Loaded -= this.EyeshotEditorLoaded;
			base.SizeChanged -= this.EyeshotEditorSizeChanged;
			this.TextTextureCache.Dispose();
			#uzc.#szc(#Phc.#3hc(107423506));
			base.EnableToolTip(false);
			#uzc.#szc(#Phc.#3hc(107422965));
			base.RemoveMessageFilter();
			#uzc.#szc(#Phc.#3hc(107423610));
		}

		// Token: 0x06003675 RID: 13941 RVA: 0x0010A5F8 File Offset: 0x001087F8
		public virtual void InitBatchImageExport(System.Windows.Size size)
		{
			this.drawToolbarBackground = false;
			CoordinateSystemIcon coordinateSystemIcon = base.ActiveViewport.CoordinateSystemIcon;
			if (coordinateSystemIcon != null)
			{
				coordinateSystemIcon.Visible = false;
			}
			this.CheckTextIsInView = false;
			base.Size = new System.Drawing.Size((int)size.Width, (int)size.Height);
			base.Width = size.Width;
			base.Height = size.Height;
			this.InitializeViewports();
			base.CreateControl();
			base.WaitCursorMode = waitCursorType.Never;
		}

		// Token: 0x06003676 RID: 13942 RVA: 0x0010A674 File Offset: 0x00108874
		public byte[] ExportToPngForReporter(bool crop = true)
		{
			Bitmap bitmap = base.RenderToBitmap(base.Size, 1.0, false, false);
			if (crop)
			{
				System.Drawing.Color transparentColorThreshold = System.Drawing.Color.FromArgb(255, 250, 250, 250);
				bitmap = BitmapHelper.CropMargins(bitmap, System.Drawing.Color.White, transparentColorThreshold);
			}
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bitmap.Save(memoryStream, ImageFormat.Png);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x06003677 RID: 13943 RVA: 0x0010A6FC File Offset: 0x001088FC
		public byte[] ExportToPng(System.Drawing.Size exportBitmapSize, Action callback = null, bool invalidateOnFinish = true)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed || Mouse.RightButton == MouseButtonState.Pressed || Mouse.MiddleButton == MouseButtonState.Pressed || Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
			{
				return null;
			}
			double width = base.Width / this.DpiScaleX;
			double height = base.Height / this.DpiScaleY;
			System.Drawing.Size size = base.Size;
			CoordinateSystemIcon coordinateSystemIcon = base.ActiveViewport.CoordinateSystemIcon;
			bool visible = coordinateSystemIcon != null && coordinateSystemIcon.Visible;
			bool checkTextIsInView = this.CheckTextIsInView;
			bool drawToolsOverlay = this.DrawToolsOverlay;
			byte[] result;
			try
			{
				this.drawToolbarBackground = false;
				this.CheckTextIsInView = false;
				this.DrawToolsOverlay = false;
				if (coordinateSystemIcon != null)
				{
					coordinateSystemIcon.Visible = false;
				}
				System.Drawing.Size size2 = base.IsHardwareAccelerated ? DesktopSizeHelper.Fit(exportBitmapSize, base.Size) : base.Size;
				if (base.IsHardwareAccelerated)
				{
					base.Size = size2;
				}
				base.Invalidate();
				Bitmap bitmap = base.RenderToBitmap(size2, 1.0, true, true);
				if (callback != null)
				{
					callback();
				}
				bitmap = BitmapHelper.CropMargins(bitmap, System.Drawing.Color.White, System.Drawing.Color.White);
				using (MemoryStream memoryStream = new MemoryStream())
				{
					bitmap.Save(memoryStream, ImageFormat.Png);
					result = memoryStream.ToArray();
				}
			}
			finally
			{
				size.Width = (int)((double)size.Width / this.DpiScaleX);
				size.Height = (int)((double)size.Height / this.DpiScaleY);
				base.Size = size;
				this.CheckTextIsInView = checkTextIsInView;
				base.Width = width;
				base.Height = height;
				this.drawToolbarBackground = true;
				this.DrawToolsOverlay = drawToolsOverlay;
				if (coordinateSystemIcon != null)
				{
					coordinateSystemIcon.Visible = visible;
				}
				base.CompileUserInterfaceElements();
				if (invalidateOnFinish)
				{
					base.Invalidate();
				}
			}
			return result;
		}

		// Token: 0x06003678 RID: 13944 RVA: 0x0010A8C8 File Offset: 0x00108AC8
		public System.Drawing.Size DrawTextExt(int x, int y, string text, Font textFont, System.Drawing.Color textColor, System.Drawing.Color fillColor, ContentAlignment textAlign, RotateFlipType rotateFlip, float angle, bool noCache = false)
		{
			System.Drawing.Size result;
			try
			{
				if (!this.IsWithinView(x, y, this.defaultTextSize))
				{
					result = this.defaultTextSize;
				}
				else if (noCache)
				{
					TextureBase textureBase = this.TextTextureCache.CreateTexture(this, text, textFont, textColor, fillColor, textAlign, rotateFlip, angle);
					if (textureBase.IsValid())
					{
						this.DrawTextTexture(textureBase, x, y, textAlign);
					}
					result = textureBase.Size;
				}
				else
				{
					TextureBase orCreate = this.TextTextureCache.GetOrCreate(this, text, textFont, textColor, fillColor, ContentAlignment.BottomLeft, rotateFlip, angle);
					if (orCreate != null)
					{
						this.DrawTextTexture(orCreate, x, y, textAlign);
						result = orCreate.Size;
					}
					else
					{
						result = base.DrawText(x, y, text, textFont, textColor, fillColor, ContentAlignment.BottomLeft, rotateFlip);
					}
				}
			}
			catch (OutOfMemoryException)
			{
				result = System.Drawing.Size.Empty;
			}
			return result;
		}

		// Token: 0x06003679 RID: 13945 RVA: 0x0010A994 File Offset: 0x00108B94
		public System.Drawing.Size DrawTextExt(int x, int y, string text, Font textFont, System.Drawing.Color textColor, System.Drawing.Color fillColor, ContentAlignment textAlign, RotateFlipType rotateFlip, bool noCache = false)
		{
			return this.DrawTextExt(x, y, text, textFont, textColor, fillColor, textAlign, rotateFlip, 0f, noCache);
		}

		// Token: 0x0600367A RID: 13946 RVA: 0x0010A9BC File Offset: 0x00108BBC
		public System.Drawing.Size DrawTextExt(int x, int y, string text, Font textFont, System.Drawing.Color textColor, System.Drawing.Color fillColor, ContentAlignment textAlign, bool noCache = false)
		{
			System.Drawing.Size result;
			try
			{
				if (noCache)
				{
					TextureBase textureBase = this.TextTextureCache.CreateTexture(this, text, textFont, textColor, fillColor, textAlign, RotateFlipType.Rotate180FlipX, 0f);
					if (textureBase.IsValid())
					{
						this.DrawTextTexture(textureBase, x, y, textAlign);
					}
					result = textureBase.Size;
				}
				else if (!this.IsWithinView(x, y, this.defaultTextSize))
				{
					result = this.defaultTextSize;
				}
				else
				{
					TextureBase orCreate = this.TextTextureCache.GetOrCreate(this, text, textFont, textColor, fillColor, ContentAlignment.BottomLeft, RotateFlipType.Rotate180FlipX, 0f);
					if (orCreate != null)
					{
						this.DrawTextTexture(orCreate, x, y, textAlign);
						result = orCreate.Size;
					}
					else
					{
						result = base.DrawText(x, y, text, textFont, textColor, fillColor, textAlign);
					}
				}
			}
			catch (OutOfMemoryException)
			{
				result = System.Drawing.Size.Empty;
			}
			return result;
		}

		// Token: 0x0600367B RID: 13947 RVA: 0x0010AA84 File Offset: 0x00108C84
		public System.Drawing.Size DrawTextExt(int x, int y, string text, Font textFont, System.Drawing.Color textColor, ContentAlignment textAlign)
		{
			System.Drawing.Size result;
			try
			{
				TextureBase orCreate = this.TextTextureCache.GetOrCreate(this, text, textFont, textColor, System.Drawing.Color.Transparent, ContentAlignment.BottomLeft, RotateFlipType.RotateNoneFlipNone, 0f);
				if (!this.IsWithinView(x, y, this.defaultTextSize))
				{
					result = this.defaultTextSize;
				}
				else if (orCreate != null)
				{
					this.DrawTextTexture(orCreate, x, y, textAlign);
					result = orCreate.Size;
				}
				else
				{
					result = base.DrawText(x, y, text, textFont, textColor, System.Drawing.Color.Transparent, textAlign);
				}
			}
			catch (OutOfMemoryException)
			{
				result = System.Drawing.Size.Empty;
			}
			return result;
		}

		// Token: 0x0600367C RID: 13948 RVA: 0x0002F9F3 File Offset: 0x0002DBF3
		public void ActivateTool(EyeshotEditorTool tool)
		{
			if (tool == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351828));
			}
			if (!this.activeTools.Contains(tool))
			{
				this.activeTools.Add(tool);
				tool.OnActivated();
			}
		}

		// Token: 0x0600367D RID: 13949 RVA: 0x0002FA29 File Offset: 0x0002DC29
		public void DeactivateTool(EyeshotEditorTool tool)
		{
			if (tool == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351828));
			}
			if (this.activeTools.Contains(tool))
			{
				this.activeTools.Remove(tool);
				tool.OnDeactivated();
			}
		}

		// Token: 0x0600367E RID: 13950 RVA: 0x0002FA5E File Offset: 0x0002DC5E
		public void PaintBackBufferAndSwapBuffers()
		{
			base.PaintBackBuffer();
			base.SwapBuffers();
		}

		// Token: 0x0600367F RID: 13951 RVA: 0x0010AB14 File Offset: 0x00108D14
		public bool IsMouseWithinVisualObjects()
		{
			if (this.ToolbarExtent.Contains(this.ScreenPosition))
			{
				ToolBar toolBar = base.ActiveViewport.ToolBar;
				if (((toolBar != null) ? new bool?(toolBar.Visible) : null).GetValueOrDefault())
				{
					return true;
				}
			}
			if (this.ViewCubeExtent.Contains(this.ScreenPosition))
			{
				ViewCubeIcon viewCubeIcon = base.ActiveViewport.ViewCubeIcon;
				return ((viewCubeIcon != null) ? new bool?(viewCubeIcon.Visible) : null).GetValueOrDefault();
			}
			return false;
		}

		// Token: 0x06003680 RID: 13952 RVA: 0x0010ABB8 File Offset: 0x00108DB8
		public static bool IsCameraInDefaultPosition(Quaternion quaternion)
		{
			return quaternion.Normalize() && (Math.Abs(0.5 - quaternion.W) <= 0.001 && Math.Abs(0.5 - quaternion.X) <= 0.001 && Math.Abs(0.5 - quaternion.Y) <= 0.001) && Math.Abs(0.5 - quaternion.Z) <= 0.001;
		}

		// Token: 0x06003681 RID: 13953 RVA: 0x0010AC54 File Offset: 0x00108E54
		public bool IsCameraInDefaultPosition()
		{
			Camera camera = this.Camera;
			return camera != null && EyeshotEditor.IsCameraInDefaultPosition((Quaternion)camera.Rotation.Clone());
		}

		// Token: 0x06003682 RID: 13954 RVA: 0x0002FA6C File Offset: 0x0002DC6C
		public bool IsCameraSetSideways()
		{
			return this.Camera.Location.Z < 0.01;
		}

		// Token: 0x06003683 RID: 13955 RVA: 0x0002FA89 File Offset: 0x0002DC89
		public void ZoomToWorkspace(System.Drawing.Point point1, System.Drawing.Point point2)
		{
			this.ZoomWindow(point1, point2);
			base.Invalidate();
			this.OnViewFitted();
		}

		// Token: 0x06003684 RID: 13956 RVA: 0x0002FA9F File Offset: 0x0002DC9F
		public void ZoomToWorkspace()
		{
			this.DefaultViewport.ZoomFit(base.Entities, false, Camera.perspectiveFitType.Accurate, this.Zoom.FitMargin, true);
			base.Invalidate();
			this.OnViewFitted();
		}

		// Token: 0x06003685 RID: 13957 RVA: 0x0002FACC File Offset: 0x0002DCCC
		public void ZoomToWorkspace(int margin)
		{
			this.DefaultViewport.ZoomFit(base.Entities, false, Camera.perspectiveFitType.Accurate, margin, true);
			base.Invalidate();
			this.OnViewFitted();
		}

		// Token: 0x06003686 RID: 13958 RVA: 0x0002FAEF File Offset: 0x0002DCEF
		public bool ViewportHasSingleFakeEntity()
		{
			return base.Entities.Count == 1 && base.Entities.First<Entity>().GetType() == typeof(devDept.Eyeshot.Entities.Point);
		}

		// Token: 0x06003687 RID: 13959 RVA: 0x0010AC84 File Offset: 0x00108E84
		public void AddFakeEntityIfEmpty()
		{
			if (this.ViewportHasSingleFakeEntity())
			{
				return;
			}
			if (base.Entities.Count > 1)
			{
				base.Entities.Remove(this.fakeEntity);
				return;
			}
			if (base.Entities.Count == 0)
			{
				base.Entities.Add(this.fakeEntity);
			}
		}

		// Token: 0x06003688 RID: 13960 RVA: 0x0010ACDC File Offset: 0x00108EDC
		public double? GetDistanceInModelCoordinates(double pixels)
		{
			this.UpdateExtremeCoordinates();
			if (this.LowerLeftWorldCoord == null || this.UpperRightWorldCoord == null)
			{
				return null;
			}
			double num = Math.Abs(this.UpperRightWorldCoord.X - this.LowerLeftWorldCoord.X);
			double actualWidth = base.ActualWidth;
			return new double?(pixels * num / actualWidth);
		}

		// Token: 0x06003689 RID: 13961 RVA: 0x0010AD44 File Offset: 0x00108F44
		public void ZoomFitExt(bool animate, int margin)
		{
			if (this.ViewportHasSingleFakeEntity())
			{
				this.ResetCameraParameters();
				base.Invalidate();
				this.OnViewFitted();
				return;
			}
			base.SetView(viewType.Top, true, animate);
			this.DefaultViewport.ZoomFit(base.Entities, false, Camera.perspectiveFitType.Accurate, margin, true);
			base.Invalidate();
			this.OnViewFitted();
		}

		// Token: 0x0600368A RID: 13962 RVA: 0x0002FB20 File Offset: 0x0002DD20
		public void ZoomFitExt(bool animate)
		{
			this.ZoomFitExt(animate, this.Zoom.FitMargin);
		}

		// Token: 0x0600368B RID: 13963 RVA: 0x0010AD98 File Offset: 0x00108F98
		public void ZoomFit3D(viewType viewType = viewType.vcFrontFaceTopLeft, bool animate = true)
		{
			EyeshotEditor.<>c__DisplayClass204_0 CS$<>8__locals1 = new EyeshotEditor.<>c__DisplayClass204_0();
			CS$<>8__locals1.<>4__this = this;
			EyeshotEditor.<>c__DisplayClass204_0 CS$<>8__locals2 = CS$<>8__locals1;
			IList<Entity> entities;
			if (!this.ViewportHasSingleFakeEntity())
			{
				IList<Entity> list = base.Entities;
				entities = list;
			}
			else
			{
				IList<Entity> list = new List<Entity>();
				entities = list;
			}
			CS$<>8__locals2.entities = entities;
			base.CameraMoveEnd -= CS$<>8__locals1.<ZoomFit3D>g__EyeshotEditorCameraMoveEnd|0;
			base.CameraMoveEnd += CS$<>8__locals1.<ZoomFit3D>g__EyeshotEditorCameraMoveEnd|0;
			base.SetView(viewType, false, animate);
			base.Invalidate();
			this.OnViewFitted();
		}

		// Token: 0x0600368C RID: 13964 RVA: 0x0010AE0C File Offset: 0x0010900C
		public void ResetCameraParameters(LengthUnit modelUnit)
		{
			LengthUnit #K7d = LengthUnit.Inch;
			this.Camera.FocalLength = 50.0;
			this.Camera.Distance = this.lengthConverter.#Pb(#K7d, modelUnit, 70.0);
			this.Camera.Target = new Point3D(this.lengthConverter.#Pb(#K7d, modelUnit, 21.5), this.lengthConverter.#Pb(#K7d, modelUnit, 10.0), 0.0);
			this.Camera.Rotation = new Quaternion(0.5, 0.5, 0.5, 0.5);
		}

		// Token: 0x0600368D RID: 13965 RVA: 0x0010AECC File Offset: 0x001090CC
		public void ResetCameraParameters()
		{
			this.Camera.FocalLength = 50.0;
			this.Camera.Distance = 70.0;
			this.Camera.Target = new Point3D(21.5, 10.0, 0.0);
			this.Camera.Rotation = new Quaternion(0.5, 0.5, 0.5, 0.5);
		}

		// Token: 0x0600368E RID: 13966 RVA: 0x0010AF60 File Offset: 0x00109160
		public override void ZoomCamera(System.Drawing.Point mousePos, int dy)
		{
			if (dy > 0 && !this.CanZoomIn())
			{
				return;
			}
			this.HandleZoomException(delegate
			{
				this.<>n__0(mousePos, dy);
			});
		}

		// Token: 0x0600368F RID: 13967 RVA: 0x0010AFAC File Offset: 0x001091AC
		public override void ZoomCamera(System.Drawing.Point mousePos, int dy, bool animate)
		{
			if (dy > 0 && !this.CanZoomIn())
			{
				return;
			}
			this.HandleZoomException(delegate
			{
				this.<>n__1(mousePos, dy, animate);
			});
		}

		// Token: 0x06003690 RID: 13968 RVA: 0x0010B000 File Offset: 0x00109200
		public override void ZoomCamera(int dy)
		{
			if (dy > 0 && !this.CanZoomIn())
			{
				return;
			}
			this.HandleZoomException(delegate
			{
				this.<>n__2(dy);
			});
		}

		// Token: 0x06003691 RID: 13969 RVA: 0x0010B048 File Offset: 0x00109248
		public override void ZoomCamera(int dy, bool animate)
		{
			if (dy > 0 && !this.CanZoomIn())
			{
				return;
			}
			this.HandleZoomException(delegate
			{
				this.<>n__3((dy > 0) ? 32 : -32, animate);
			});
		}

		// Token: 0x06003692 RID: 13970 RVA: 0x0010B094 File Offset: 0x00109294
		public override void ZoomCamera(int dy, double zoomSpeed)
		{
			if (dy > 0 && !this.CanZoomIn())
			{
				return;
			}
			this.HandleZoomException(delegate
			{
				this.<>n__4(dy, zoomSpeed);
			});
		}

		// Token: 0x06003693 RID: 13971 RVA: 0x0010B0E0 File Offset: 0x001092E0
		public override void ZoomCamera(int dy, double zoomSpeed, bool animate)
		{
			if (dy > 0 && !this.CanZoomIn())
			{
				return;
			}
			this.HandleZoomException(delegate
			{
				this.<>n__5(dy, zoomSpeed, animate);
			});
		}

		// Token: 0x06003694 RID: 13972 RVA: 0x0010B134 File Offset: 0x00109334
		public override void ZoomWindow(System.Drawing.Point p1, System.Drawing.Point p2)
		{
			if (!this.CanZoomIn(p1, p2))
			{
				return;
			}
			this.HandleZoomException(delegate
			{
				this.<>n__6(p1, p2);
			});
		}

		// Token: 0x06003695 RID: 13973 RVA: 0x0002FB34 File Offset: 0x0002DD34
		public virtual void OnActionModeChanged(actionType oldActionType, actionType newActionType)
		{
			EventHandler<ActionModeChangedEventArgs> actionModeChanged = this.ActionModeChanged;
			if (actionModeChanged == null)
			{
				return;
			}
			actionModeChanged(this, new ActionModeChangedEventArgs(oldActionType, newActionType));
		}

		// Token: 0x06003696 RID: 13974 RVA: 0x0002FB4E File Offset: 0x0002DD4E
		internal void OnCameraMoved(object sender, EventArgs e)
		{
			EventHandler cameraMoved = this.CameraMoved;
			if (cameraMoved == null)
			{
				return;
			}
			cameraMoved(sender, e);
		}

		// Token: 0x06003697 RID: 13975 RVA: 0x0002FB62 File Offset: 0x0002DD62
		public void SetCursor(cursorType cursorType, byte[] cursor)
		{
			if (cursor == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107471906));
			}
			base.SetCursor(cursorType, new MemoryStream(cursor));
		}

		// Token: 0x06003698 RID: 13976 RVA: 0x0010B184 File Offset: 0x00109384
		public void InvalidateCursor()
		{
			this.SetCursor(cursorType.Rotate, EditorCursors.Rotate3D_CursorData);
			this.SetCursor(cursorType.Pan, EditorCursors.Pan_CursorData);
			this.SetCursor(cursorType.ZoomWindow, EditorCursors.Rectangle_CursorData);
			if (base.ActionMode != actionType.None)
			{
				actionType actionMode = base.ActionMode;
				base.ActionMode = actionType.None;
				base.ActionMode = actionMode;
			}
		}

		// Token: 0x06003699 RID: 13977 RVA: 0x0002FB84 File Offset: 0x0002DD84
		public void SetCursor(byte[] cursor)
		{
			if (cursor == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107471906));
			}
			base.SetCursor(new MemoryStream(cursor));
		}

		// Token: 0x0600369A RID: 13978 RVA: 0x0002FBA5 File Offset: 0x0002DDA5
		public IEnumerable<DependencyObject> GetLogicalParents()
		{
			DependencyObject element = this;
			while ((element = this.GetLogicalParent(element)) != null)
			{
				yield return element;
			}
			yield break;
		}

		// Token: 0x0600369B RID: 13979 RVA: 0x0010B1D4 File Offset: 0x001093D4
		protected override void OnLostFocus(EventArgs e)
		{
			try
			{
				base.OnLostFocus(e);
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
		}

		// Token: 0x0600369C RID: 13980 RVA: 0x0010B1D4 File Offset: 0x001093D4
		protected override void OnLostFocus(RoutedEventArgs e)
		{
			try
			{
				base.OnLostFocus(e);
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
		}

		// Token: 0x0600369D RID: 13981 RVA: 0x0010B204 File Offset: 0x00109404
		protected override void OnKeyDown(KeyEventArgs e)
		{
			this.lastEscapeKeyDown = null;
			if (e.Key == Key.Escape && base.ActionMode != actionType.None)
			{
				e.Handled = true;
				return;
			}
			if (e.Key == Key.Escape)
			{
				this.lastEscapeKeyDown = new DateTime?(DateTime.Now);
			}
			base.OnKeyDown(e);
			this.ForEachTool(delegate(EyeshotEditorTool item)
			{
				item.HandleKeyDown(e);
			});
			if (!e.Handled)
			{
				this.DynamicInput.HandleEditorKeyDown(e);
			}
		}

		// Token: 0x0600369E RID: 13982 RVA: 0x0010B2AC File Offset: 0x001094AC
		protected override void OnKeyUp(KeyEventArgs e)
		{
			bool flag = this.lastEscapeKeyDown != null && DateTime.Now - this.lastEscapeKeyDown.Value < TimeSpan.FromSeconds(1.0);
			if (e.Key == Key.Escape && base.ActionMode != actionType.None)
			{
				actionType actionMode = base.ActionMode;
				DefaultViewPortConfigurator viewPortConfigurator = this.ViewPortConfigurator;
				if (viewPortConfigurator != null)
				{
					viewPortConfigurator.DisableToggleButton(base.ActionMode);
				}
				base.ActionMode = actionType.None;
				e.Handled = true;
				this.OnActionModeChanged(actionMode, base.ActionMode);
				return;
			}
			base.OnKeyUp(e);
			if (e.Key == Key.Escape && !flag)
			{
				return;
			}
			this.lastEscapeKeyDown = null;
			this.ForEachTool(delegate(EyeshotEditorTool item)
			{
				item.HandleKeyUp(e);
			});
		}

		// Token: 0x0600369F RID: 13983 RVA: 0x0010B394 File Offset: 0x00109594
		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			bool flag = this.IsParentPanelActive();
			base.OnMouseDown(e);
			DateTime utcNow = DateTime.UtcNow;
			if (!flag || (this.IgnoreNextMouseDown && utcNow - this.IgnoreNextMouseDownTimestamp < this.IgnoreNextMouseDownTimestampThreshold))
			{
				this.IgnoreNextMouseDown = false;
				this.wasFocusChangedOnMouseDown = true;
				return;
			}
			this.wasFocusChangedOnMouseDown = false;
			this.mouseDownHandledByTool = false;
			if (e.ChangedButton == System.Windows.Input.MouseButton.Right && base.ActionMode != actionType.None)
			{
				e.Handled = true;
				return;
			}
			if (this.ProcessMousePosition(e) && !this.IsMouseWithinVisualObjects())
			{
				this.mouseDownHandledByTool = true;
				this.ForEachTool(delegate(EyeshotEditorTool item)
				{
					item.HandleMouseDown(e, this.ScreenPosition, this.PlanePosition);
				});
			}
		}

		// Token: 0x060036A0 RID: 13984 RVA: 0x00003375 File Offset: 0x00001575
		protected virtual bool ShouldDrawDynamicInput()
		{
			return true;
		}

		// Token: 0x060036A1 RID: 13985 RVA: 0x0010B460 File Offset: 0x00109660
		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			base.OnMouseUp(e);
			if (this.wasFocusChangedOnMouseDown)
			{
				this.wasFocusChangedOnMouseDown = false;
				return;
			}
			bool flag = this.mouseDownHandledByTool;
			this.mouseDownHandledByTool = false;
			if (e.ChangedButton == System.Windows.Input.MouseButton.Right && base.ActionMode != actionType.None)
			{
				actionType actionMode = base.ActionMode;
				DefaultViewPortConfigurator viewPortConfigurator = this.ViewPortConfigurator;
				if (viewPortConfigurator != null)
				{
					viewPortConfigurator.DisableToggleButton(base.ActionMode);
				}
				base.ActionMode = actionType.None;
				this.OnActionModeChanged(actionMode, base.ActionMode);
				return;
			}
			if (this.ProcessMousePosition(e))
			{
				if (this.IsMouseWithinVisualObjects() || !flag)
				{
					this.ForEachTool(delegate(EyeshotEditorTool item)
					{
						item.HandleChangedState();
					});
					return;
				}
				if (this.PlanePosition != null)
				{
					this.ForEachTool(delegate(EyeshotEditorTool item)
					{
						item.HandleMouseUp(e, this.ScreenPosition, this.PlanePosition);
					});
				}
			}
		}

		// Token: 0x060036A2 RID: 13986 RVA: 0x0010B554 File Offset: 0x00109754
		protected void DrawToolbarBackground()
		{
			this.CalculateViewCubeExtent();
			Viewport activeViewport = base.ActiveViewport;
			ToolBar toolBar = base.ActiveViewport.ToolBars.FirstOrDefault<ToolBar>();
			int num = 0;
			if (toolBar != null)
			{
				int num2 = toolBar.Buttons.Count((ToolBarButton item) => item.Visible && !(item is CancelToolBarButton));
				int gap = base.ButtonStyle.Gap;
				int num3 = 8;
				num = (num2 - 1) * gap + num3 + 1;
				this.toolbarSize.Height = num2 * 24 + num;
			}
			int height = activeViewport.Size.Height;
			int width = activeViewport.Size.Width;
			double num4 = (double)this.toolbarSize.Width * this.DpiScaleX;
			double num5 = (double)num + (double)(this.toolbarSize.Height - num) * this.DpiScaleY;
			Point3D point3D = new Point3D((double)width - num4 - 1.0, (double)(height - 2));
			Point3D point3D2 = new Point3D((double)(width - 1), (double)(height - 2));
			Point3D point3D3 = new Point3D((double)width - num4, (double)height - num5);
			Point3D p = new Point3D((double)(width - 1), (double)height - num5);
			this.ToolbarExtent = new RectangleF(new PointF((float)point3D.X, 2f), new SizeF((float)this.toolbarSize.Width, (float)this.toolbarSize.Height));
			if (!this.DefaultViewport.ToolBar.Visible)
			{
				return;
			}
			base.renderContext.PushBlendState();
			base.renderContext.SetState(blendStateType.Blend);
			base.renderContext.SetLineSizeExt(1f);
			base.renderContext.PushShader();
			base.renderContext.SetShader(shaderType.NoLights, null, true);
			base.renderContext.SetColorWireframe(System.Drawing.Color.FromArgb(246, 246, 246), false);
			base.renderContext.DrawQuad(new RectangleF((float)point3D3.X, (float)point3D3.Y, (float)((int)num4 - 1), (float)((int)num5 - 1)));
			base.renderContext.SetColorWireframe(System.Drawing.Color.FromArgb(204, 206, 219), false);
			base.renderContext.SetLineSizeExt(1f);
			base.renderContext.DrawLine(point3D, point3D2);
			base.renderContext.DrawLine(point3D3, p);
			base.renderContext.DrawLine(point3D, point3D3);
			base.renderContext.DrawLine(point3D2, p);
			base.renderContext.PopShader();
			base.renderContext.PopBlendState();
		}

		// Token: 0x060036A3 RID: 13987 RVA: 0x0010B7D4 File Offset: 0x001099D4
		protected override void DrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data)
		{
			base.DrawOverlay(data);
			if (this.IsMouseWithEditor && this.DrawToolsOverlay && this.PlanePosition != null && this.ShouldDrawDynamicInput() && this.DynamicInput.DrawLocation != null)
			{
				this.ForEachTool(delegate(EyeshotEditorTool item)
				{
					item.HandleDrawOverlay(data, this.ScreenPosition, this.PlanePosition);
				});
				this.DynamicInput.Draw(this.ScreenPosition, this.PlanePosition);
			}
			if (this.drawToolbarBackground)
			{
				this.DrawToolbarBackground();
			}
			string busyText = this.BusyText;
			if (!string.IsNullOrWhiteSpace(busyText))
			{
				int num = base.Size.Width / 2;
				int num2 = base.Size.Height / 2;
				this.drawingHelper.DrawTextInBorder(new Point3D((double)num, (double)num2), busyText, ContentAlignment.MiddleCenter, new Thickness(5.0), this.BusyMessageBackground, this.BusyMessageForeground, this.BusyMessageBorder, this.BusyMessageFont, new int?(200), new int?(100));
			}
			this.DrawOsdMessages();
		}

		// Token: 0x060036A4 RID: 13988 RVA: 0x0010B8FC File Offset: 0x00109AFC
		protected void ForEachTool(Action<EyeshotEditorTool> action)
		{
			foreach (EyeshotEditorTool obj in this.activeTools.OfType<EyeshotEditorTool>().ToList<EyeshotEditorTool>())
			{
				action(obj);
			}
		}

		// Token: 0x060036A5 RID: 13989 RVA: 0x0010B95C File Offset: 0x00109B5C
		protected override void OnMouseMove(MouseEventArgs e)
		{
			this.IsMouseWithEditor = !this.IsMouseWithinVisualObjects();
			DateTime now = DateTime.Now;
			TimeSpan t = now - this.lastMouseMove;
			this.lastMouseMove = now;
			base.OnMouseMove(e);
			this.DynamicInput.DrawLocation = this.PlanePosition;
			if (this.ProcessMousePosition(e) && this.IsMouseWithEditor && this.PlanePosition != null)
			{
				if (this.DynamicInput.Config.EnabledAndActiveOverride)
				{
					this.DynamicInput.HandleEditorMousePositionChanged(this.PlanePosition);
				}
				if (this.SupportBeginMouseMove && t > EyeshotEditor.BeginMouseMoveThreshold)
				{
					this.ForEachTool(delegate(EyeshotEditorTool tool)
					{
						tool.HandleBeginMouseMove(e, this.ScreenPosition, this.PlanePosition);
					});
				}
				this.ForEachTool(delegate(EyeshotEditorTool tool)
				{
					tool.HandleMouseMove(e, this.ScreenPosition, this.PlanePosition);
				});
				if (this.DynamicInput.Config.EnabledAndActiveOverride)
				{
					base.Invalidate();
				}
			}
		}

		// Token: 0x060036A6 RID: 13990 RVA: 0x0010BA64 File Offset: 0x00109C64
		public void UpdateExtremeCoordinates()
		{
			Point3D upperRightWorldCoord;
			base.ScreenToPlane(new System.Drawing.Point(base.Size.Width, 0), this.EditionPlane, out upperRightWorldCoord);
			Point3D lowerLeftWorldCoord;
			base.ScreenToPlane(new System.Drawing.Point(0, base.Size.Height), this.EditionPlane, out lowerLeftWorldCoord);
			this.UpperRightWorldCoord = upperRightWorldCoord;
			this.LowerLeftWorldCoord = lowerLeftWorldCoord;
		}

		// Token: 0x060036A7 RID: 13991 RVA: 0x0010BAC8 File Offset: 0x00109CC8
		protected override void DrawViewport(devDept.Eyeshot.Environment.DrawSceneParams myParams)
		{
			this.UpdateExtremeCoordinates();
			List<Entity> entities = myParams.Entities.OrderBy(delegate(Entity item)
			{
				IVisuallyOrderedEntity visuallyOrderedEntity = item as IVisuallyOrderedEntity;
				if (visuallyOrderedEntity != null)
				{
					return visuallyOrderedEntity.VisualOrder;
				}
				return -1.0;
			}).ToList<Entity>();
			myParams.Entities = entities;
			myParams.Env.ProcessSemiTransparent();
			base.DrawViewport(myParams);
		}

		// Token: 0x060036A8 RID: 13992 RVA: 0x0002FBB5 File Offset: 0x0002DDB5
		protected override void OnDpiChanged(DpiScale oldDpi, DpiScale newDpi)
		{
			base.OnDpiChanged(oldDpi, newDpi);
			this.DpiScaleX = newDpi.DpiScaleX;
			this.DpiScaleY = newDpi.DpiScaleY;
		}

		// Token: 0x060036A9 RID: 13993 RVA: 0x0010BB24 File Offset: 0x00109D24
		internal Bitmap GetTextImageExt(string text, Font font, System.Drawing.Color color, System.Drawing.Color fillColor, ContentAlignment textAlign, RotateFlipType rotateFlip, float angle, bool antialias = true)
		{
			Bitmap textImage = base.GetTextImage(text, font, color, fillColor, textAlign, rotateFlip, antialias);
			if (angle != 0f)
			{
				return BitmapHelper.RotateBitmap(textImage, angle);
			}
			return textImage;
		}

		// Token: 0x060036AA RID: 13994 RVA: 0x0002FBD9 File Offset: 0x0002DDD9
		internal Bitmap GetTextImageExt(string text, Font font, System.Drawing.Color color, System.Drawing.Color fillColor, ContentAlignment textAlign, RotateFlipType rotateFlip, bool antialias = true)
		{
			return base.GetTextImage(text, font, color, fillColor, textAlign, rotateFlip, antialias);
		}

		// Token: 0x060036AB RID: 13995 RVA: 0x0002FBEC File Offset: 0x0002DDEC
		public virtual void OnViewFitted()
		{
			EventHandler viewFitted = this.ViewFitted;
			if (viewFitted == null)
			{
				return;
			}
			viewFitted(this, EventArgs.Empty);
		}

		// Token: 0x060036AC RID: 13996 RVA: 0x0010BB58 File Offset: 0x00109D58
		protected virtual void RecalculateZoomFitMargin()
		{
			double actualWidth = base.ActualWidth;
			double actualHeight = base.ActualHeight;
			if (actualWidth > 0.0 && actualHeight > 0.0)
			{
				double num = (actualWidth + actualHeight) / 2.0;
				this.Zoom.FitMargin = (int)(0.03 * num) + this.ZoomFitMarginAddition;
				return;
			}
			if (this.ZoomFitMarginAddition > 0)
			{
				this.Zoom.FitMargin = this.ZoomFitMarginAddition;
			}
		}

		// Token: 0x060036AD RID: 13997 RVA: 0x0010BBD4 File Offset: 0x00109DD4
		private void EyeshotEditor_ErrorOccurred(object sender, devDept.Eyeshot.Environment.ErrorOccurredEventArgs args)
		{
			ILogger logger = this.Logger;
			if (logger == null)
			{
				return;
			}
			logger.Log(LoggingLevel.Error, () => args.Message);
		}

		// Token: 0x060036AE RID: 13998 RVA: 0x0002FC04 File Offset: 0x0002DE04
		private void EyeshotEditor_Unloaded(object sender, RoutedEventArgs e)
		{
			this.EmptyTextureCache();
		}

		// Token: 0x060036AF RID: 13999 RVA: 0x0002FC0C File Offset: 0x0002DE0C
		private void EyeshotEditorSizeChanged(object sender, SizeChangedEventArgs e)
		{
			this.RecalculateZoomFitMargin();
		}

		// Token: 0x060036B0 RID: 14000 RVA: 0x0010BC0C File Offset: 0x00109E0C
		private void DynamicInputCoordinateSnapRequested(object sender, DynamicInputCoordinateSnapEventArgs e)
		{
			this.ForEachTool(delegate(EyeshotEditorTool item)
			{
				item.HandleDynamicInputCoordinateSnapRequested(e);
			});
		}

		// Token: 0x060036B1 RID: 14001 RVA: 0x0010BC38 File Offset: 0x00109E38
		private void HandleDynamicInputCoordinateChange(object sender, DynamicInputCoordinateEventArgs args)
		{
			if (this.DynamicInput.Config.EnabledAndActiveOverride)
			{
				this.ForEachTool(delegate(EyeshotEditorTool tool)
				{
					tool.HandleDynamicInputCoordinateChange(args);
				});
			}
		}

		// Token: 0x060036B2 RID: 14002 RVA: 0x0010BC78 File Offset: 0x00109E78
		private void HandleDynamicInputCoordinateCommited(object sender, DynamicInputCoordinateEventArgs args)
		{
			if (this.DynamicInput.Config.EnabledAndActiveOverride)
			{
				this.ForEachTool(delegate(EyeshotEditorTool tool)
				{
					tool.HandleDynamicInputCoordinateCommited(args);
				});
			}
		}

		// Token: 0x060036B3 RID: 14003 RVA: 0x0010BCB8 File Offset: 0x00109EB8
		private void HandleDynamicInputCoordinateValidation(object sender, DynamicInputValueValidationEventArgs args)
		{
			if (this.DynamicInput.Config.EnabledAndActiveOverride)
			{
				this.ForEachTool(delegate(EyeshotEditorTool tool)
				{
					tool.HandleDynamicInputCoordinateValidation(args);
				});
			}
		}

		// Token: 0x060036B4 RID: 14004 RVA: 0x0010BCF8 File Offset: 0x00109EF8
		private void EyeshotEditorLoaded(object sender, RoutedEventArgs e)
		{
			try
			{
				this.InvalidateCursor();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060036B5 RID: 14005 RVA: 0x0010BD20 File Offset: 0x00109F20
		private void HandleZoomException(Action action)
		{
			Camera cameraClone = (Camera)base.ActiveViewport.Camera.Clone();
			try
			{
				action();
			}
			catch (OverflowException exception)
			{
				ILogger logger = this.Logger;
				if (logger != null)
				{
					logger.Log(LoggingLevel.Warning, exception);
				}
				Ignore.#14d<Exception>(delegate()
				{
					this.renderContext.EndReadDepthValues();
				}, null);
				Ignore.#14d<Exception>(delegate()
				{
					this.Camera = cameraClone;
				}, null);
				base.Refresh();
				base.Invalidate();
			}
			catch (Exception exception2)
			{
				ILogger logger2 = this.Logger;
				if (logger2 != null)
				{
					logger2.Log(LoggingLevel.Warning, exception2);
				}
			}
		}

		// Token: 0x060036B6 RID: 14006 RVA: 0x0010BDD8 File Offset: 0x00109FD8
		private void DrawOsdMessages()
		{
			if (!this.OsdMessages.Any<string>())
			{
				return;
			}
			Font orCreate = FontsCache.GetOrCreate(#Phc.#3hc(107399885), 10f);
			int num = 15;
			System.Drawing.Size size = default(System.Drawing.Size);
			foreach (string text in this.OsdMessages)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					num += size.Height;
					size = this.DrawTextExt(15, num, text, orCreate, System.Drawing.Color.Black, System.Drawing.Color.Transparent, ContentAlignment.BottomLeft, true);
				}
				else
				{
					num += 8;
				}
			}
		}

		// Token: 0x060036B7 RID: 14007 RVA: 0x0010BE8C File Offset: 0x0010A08C
		private bool IsWithinView(int x, int y, System.Drawing.Size size)
		{
			if (!this.CheckTextIsInView)
			{
				return true;
			}
			double num = base.ActualWidth * this.DpiScaleX;
			double num2 = base.ActualHeight * this.DpiScaleY;
			return x >= -size.Width && (double)x <= num + (double)size.Width && x >= -size.Height && (double)y <= num2 + (double)size.Height;
		}

		// Token: 0x060036B8 RID: 14008 RVA: 0x0002FC14 File Offset: 0x0002DE14
		private void DrawTextTexture(TextureBase texture, int x, int y, ContentAlignment textAlign)
		{
			if (!this.IsWithinView(x, y, texture.BitmapSize))
			{
				return;
			}
			base.DrawTexture(texture, x, y, textAlign, false);
		}

		// Token: 0x060036B9 RID: 14009 RVA: 0x0010BEFC File Offset: 0x0010A0FC
		private DependencyObject GetLogicalParent(DependencyObject element)
		{
			DependencyObject dependencyObject;
			try
			{
				dependencyObject = LogicalTreeHelper.GetParent(element);
			}
			catch (InvalidOperationException)
			{
				dependencyObject = null;
			}
			if (dependencyObject == null)
			{
				FrameworkElement frameworkElement = element as FrameworkElement;
				if (frameworkElement != null)
				{
					dependencyObject = frameworkElement.Parent;
				}
				FrameworkContentElement frameworkContentElement = element as FrameworkContentElement;
				if (frameworkContentElement != null)
				{
					dependencyObject = frameworkContentElement.Parent;
				}
			}
			return dependencyObject;
		}

		// Token: 0x060036BA RID: 14010 RVA: 0x0010BF50 File Offset: 0x0010A150
		private bool IsParentPanelActive()
		{
			RadPane radPane = this.GetLogicalParents().OfType<RadPane>().FirstOrDefault<RadPane>();
			return radPane != null && radPane.IsActive;
		}

		// Token: 0x060036BB RID: 14011 RVA: 0x0010BF7C File Offset: 0x0010A17C
		private void CalculateViewCubeExtent()
		{
			System.Drawing.Size size = new System.Drawing.Size(86, 86);
			Margins margins = new Margins(0, 16, 0, 16);
			int height = base.ActiveViewport.Size.Height;
			int num = base.ActiveViewport.Size.Width - size.Width - margins.Right;
			int num2 = height - size.Height - margins.Bottom;
			this.ViewCubeExtent = new RectangleF((float)num, (float)num2, (float)size.Width, (float)size.Height);
		}

		// Token: 0x060036BC RID: 14012 RVA: 0x0002FC33 File Offset: 0x0002DE33
		private void Configure()
		{
			this.SetupStartupDpi();
			this.ViewPortConfigurator = new DefaultViewPortConfigurator(this, this.Is2DViewport);
			this.ViewPortConfigurator.Configure();
		}

		// Token: 0x060036BD RID: 14013 RVA: 0x0010C008 File Offset: 0x0010A208
		private void SetupStartupDpi()
		{
			DpiScale dpi = VisualTreeHelper.GetDpi(this);
			this.DpiScaleX = dpi.DpiScaleX;
			this.DpiScaleY = dpi.DpiScaleY;
		}

		// Token: 0x060036BE RID: 14014 RVA: 0x0010C038 File Offset: 0x0010A238
		private bool ProcessMousePosition(MouseEventArgs args)
		{
			this.ScreenPosition = RenderContextUtility.ConvertPoint(base.GetMousePosition(args));
			Point3D planePosition;
			bool result = base.ScreenToPlane(this.ScreenPosition, this.EditionPlane, out planePosition);
			this.PlanePosition = planePosition;
			return result;
		}

		// Token: 0x060036BF RID: 14015 RVA: 0x0002FC58 File Offset: 0x0002DE58
		private bool CanZoomIn()
		{
			return Math.Abs(this.Camera.Location.Z) > 2.5;
		}

		// Token: 0x060036C0 RID: 14016 RVA: 0x0010C074 File Offset: 0x0010A274
		private bool CanZoomIn(System.Drawing.Point p1, System.Drawing.Point p2)
		{
			Point3D point3D;
			Point3D point3D2;
			return !base.ScreenToPlane(p1, this.EditionPlane, out point3D) || !base.ScreenToPlane(p2, this.EditionPlane, out point3D2) || Math.Min(Math.Abs(point3D.X - point3D2.X), Math.Abs(point3D.Y - point3D2.Y)) > 1.0;
		}

		// Token: 0x04001688 RID: 5768
		private const ContentAlignment TextureAlignment = ContentAlignment.BottomLeft;

		// Token: 0x04001689 RID: 5769
		private readonly DrawingHelper drawingHelper;

		// Token: 0x0400168A RID: 5770
		private static readonly TimeSpan BeginMouseMoveThreshold = TimeSpan.FromMilliseconds(100.0);

		// Token: 0x0400168B RID: 5771
		private readonly IList activeTools;

		// Token: 0x0400168C RID: 5772
		private System.Drawing.Size toolbarSize = new System.Drawing.Size(32, 236);

		// Token: 0x0400168D RID: 5773
		private readonly System.Drawing.Size defaultTextSize = new System.Drawing.Size(50, 22);

		// Token: 0x0400168E RID: 5774
		private Plane editionPlane;

		// Token: 0x0400168F RID: 5775
		private bool drawToolbarBackground = true;

		// Token: 0x04001690 RID: 5776
		private bool mouseDownHandledByTool;

		// Token: 0x04001691 RID: 5777
		private bool wasFocusChangedOnMouseDown;

		// Token: 0x04001692 RID: 5778
		private DateTime lastMouseMove = DateTime.MinValue;

		// Token: 0x04001693 RID: 5779
		private readonly devDept.Eyeshot.Entities.Point fakeEntity = new devDept.Eyeshot.Entities.Point(0.0, 0.0, 0.0, 1f)
		{
			ColorMethod = colorMethodType.byEntity,
			Color = System.Drawing.Color.Black
		};

		// Token: 0x04001694 RID: 5780
		private int zoomFitMarginAddition;

		// Token: 0x04001695 RID: 5781
		private DateTime? lastEscapeKeyDown;

		// Token: 0x04001696 RID: 5782
		private bool isDisposed;

		// Token: 0x04001697 RID: 5783
		private readonly StructurePoint.CoreAssets.Units.LengthConverter lengthConverter = new StructurePoint.CoreAssets.Units.LengthConverter();
	}
}
