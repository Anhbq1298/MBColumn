using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using #7hc;
using devDept.Eyeshot;
using devDept.Graphics;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Resources.Images;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B02 RID: 2818
	public sealed class DefaultViewPortConfigurator
	{
		// Token: 0x06005BE8 RID: 23528 RVA: 0x001710DC File Offset: 0x0016F2DC
		public DefaultViewPortConfigurator(EyeshotEditor editor, bool is2DViewport = false)
		{
			if (editor == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351888));
			}
			this.editor = editor;
			this.is2DViewport = is2DViewport;
		}

		// Token: 0x17001A3C RID: 6716
		// (get) Token: 0x06005BE9 RID: 23529 RVA: 0x0004CD93 File Offset: 0x0004AF93
		private Viewport ViewPort
		{
			get
			{
				return this.editor.DefaultViewport;
			}
		}

		// Token: 0x17001A3D RID: 6717
		// (get) Token: 0x06005BEA RID: 23530 RVA: 0x0004CDA0 File Offset: 0x0004AFA0
		// (set) Token: 0x06005BEB RID: 23531 RVA: 0x0004CDA8 File Offset: 0x0004AFA8
		public devDept.Eyeshot.ToolBarButton ZoomToModelButton { get; private set; }

		// Token: 0x06005BEC RID: 23532 RVA: 0x001711B0 File Offset: 0x0016F3B0
		public void Configure()
		{
			this.ViewPort.SmallSizeRatio = 0.0;
			this.editor.Viewports.Add(this.ViewPort);
			this.editor.ActiveViewportIndex = 0;
			this.editor.Zoom.BoxColor = System.Drawing.Color.Transparent;
			this.ConfigureToolbar();
			this.ConfigureViewCubeAndCoordinateSystem();
			this.ConfigureCamera();
			this.ConfigureLights();
			this.ConfigureKeyboardShortcuts();
			this.editor.Invalidate();
			this.ViewPort.Invalidate();
		}

		// Token: 0x06005BED RID: 23533 RVA: 0x0017123C File Offset: 0x0016F43C
		public void DisableToggleButton(actionType actionType)
		{
			this.toggleButtons.First((devDept.Eyeshot.ToolBarButton item) => item.Tag.Equals(actionType)).Pushed = false;
		}

		// Token: 0x06005BEE RID: 23534 RVA: 0x00171274 File Offset: 0x0016F474
		private void ViewCubeIcon_Click(object sender, devDept.Eyeshot.Environment.ViewChangedEventArgs e)
		{
			this.ExecuteOnLock(delegate
			{
				this.editor.ZoomFit3D(e.ViewType, true);
			});
		}

		// Token: 0x06005BEF RID: 23535 RVA: 0x0004CDB1 File Offset: 0x0004AFB1
		private void ViewHomeButton_Click(object sender, EventArgs e)
		{
			this.ExecuteOnLock(delegate
			{
				if (this.editor.ViewHomeOverride != null)
				{
					this.editor.ViewHomeOverride();
					return;
				}
				this.editor.ZoomFitExt(false);
			});
		}

		// Token: 0x06005BF0 RID: 23536 RVA: 0x0004CDC5 File Offset: 0x0004AFC5
		private void View3DButton_Click(object sender, EventArgs e)
		{
			this.ExecuteOnLock(delegate
			{
				this.editor.ZoomFit3D(viewType.vcFrontFaceTopLeft, true);
			});
		}

		// Token: 0x06005BF1 RID: 23537 RVA: 0x0004CDD9 File Offset: 0x0004AFD9
		private void ZoomToWorkspace_Click(object sender, EventArgs e)
		{
			this.ExecuteOnLock(delegate
			{
				if (this.editor.ZoomToWorkspaceOverride != null)
				{
					this.editor.ZoomToWorkspaceOverride();
					return;
				}
				this.editor.ZoomToWorkspace();
			});
		}

		// Token: 0x06005BF2 RID: 23538 RVA: 0x001712A8 File Offset: 0x0016F4A8
		private void ExecuteOnLock(Action action)
		{
			if (this.toolbarButtonLock.#YXd())
			{
				try
				{
					action();
				}
				finally
				{
					this.toolbarButtonLock.#ZXd();
				}
			}
		}

		// Token: 0x06005BF3 RID: 23539 RVA: 0x001712E8 File Offset: 0x0016F4E8
		private void ConfigureViewCubeAndCoordinateSystem()
		{
			this.editor.Pan.MouseButton = new MouseButton(mouseButtonsZPR.Middle, modifierKeys.None);
			if (this.is2DViewport)
			{
				this.editor.Zoom.MouseButton = new MouseButton(mouseButtonsZPR.None, modifierKeys.None);
				this.editor.Rotate.MouseButton = new MouseButton(mouseButtonsZPR.None, modifierKeys.None);
				this.editor.Rotate.Enabled = false;
				return;
			}
			this.ViewPort.ViewCubeIcon = ViewCubeIcon.GetDefaultViewCubeIcon();
			this.ViewPort.ViewCubeIcon.Position = coordinateSystemPositionType.BottomRight;
			this.ViewPort.ViewCubeIcon.Lighting = true;
			this.ViewPort.ViewCubeIcon.BackColor = this.viewCubeBackground;
			this.ViewPort.ViewCubeIcon.FrontColor = this.viewCubeBackground;
			this.ViewPort.ViewCubeIcon.TopColor = this.viewCubeBackground;
			this.ViewPort.ViewCubeIcon.BottomColor = this.viewCubeBackground;
			this.ViewPort.ViewCubeIcon.LeftColor = this.viewCubeBackground;
			this.ViewPort.ViewCubeIcon.RightColor = this.viewCubeBackground;
			this.ViewPort.ViewCubeIcon.TextColor = this.viewCubeTextColor;
			this.ViewPort.ViewCubeIcon.EdgeColor = this.viewCubeTextColor;
			this.ViewPort.ViewCubeIcon.BackRingColor = this.viewCubeRingColor;
			this.ViewPort.ViewCubeIcon.FrontRingColor = this.viewCubeRingColor;
			this.ViewPort.ViewCubeIcon.LeftRingColor = this.viewCubeRingColor;
			this.ViewPort.ViewCubeIcon.RightRingColor = this.viewCubeRingColor;
			this.ViewPort.ViewCubeIcon.HighlightColor = this.viewCubeHighlightColor;
			this.ViewPort.ViewCubeIcon.Click += this.ViewCubeIcon_Click;
			this.ViewPort.Background = new BackgroundSettings
			{
				StyleMode = backgroundStyleType.Solid,
				BottomColor = System.Windows.Media.Brushes.White,
				TopColor = System.Windows.Media.Brushes.White,
				ColorTheme = colorThemeType.Light
			};
			this.ViewPort.InitialView = viewType.Top;
			System.Drawing.Color color = System.Drawing.Color.FromArgb(255, 80, 80, 80);
			System.Drawing.Color arrowColorZ = System.Drawing.Color.FromArgb(255, 255, 69, 0);
			this.ViewPort.CoordinateSystemIcon = new CustomCoordinateSystemIcon(System.Drawing.Color.Black, color, color, arrowColorZ, #Phc.#3hc(107421372), #Phc.#3hc(107408964), #Phc.#3hc(107408991), #Phc.#3hc(107397860), true, coordinateSystemPositionType.BottomLeft);
			this.ViewPort.CoordinateSystemIcon.Position = coordinateSystemPositionType.BottomLeft;
			this.editor.Rotate.MouseButton = new MouseButton(mouseButtonsZPR.Middle, modifierKeys.Shift);
		}

		// Token: 0x06005BF4 RID: 23540 RVA: 0x0017159C File Offset: 0x0016F79C
		private void ConfigureCamera()
		{
			this.editor.Zoom.PerspectiveFitMode = Camera.perspectiveFitType.Quick;
			this.editor.Zoom.ZoomStyle = zoomStyleType.AtCursorLocation;
			this.editor.Zoom.Speed = 1.0;
			CustomCamera customCamera = new CustomCamera
			{
				ProjectionMode = projectionType.Perspective
			};
			this.ViewPort.Camera = customCamera;
			customCamera.CameraMoved += this.editor.OnCameraMoved;
			this.editor.ResetCameraParameters();
		}

		// Token: 0x06005BF5 RID: 23541 RVA: 0x00171620 File Offset: 0x0016F820
		private void ConfigureLights()
		{
			this.editor.AmbientLight = System.Drawing.Color.White;
			List<LightSettings> list = new List<LightSettings>();
			list.Add(this.editor.Light1);
			list.Add(this.editor.Light2);
			list.Add(this.editor.Light3);
			list.Add(this.editor.Light4);
			list.Add(this.editor.Light5);
			list.Add(this.editor.Light6);
			list.Add(this.editor.Light7);
			list.Add(this.editor.Light8);
			list.ForEach(delegate(LightSettings light)
			{
				light.Active = false;
			});
		}

		// Token: 0x06005BF6 RID: 23542 RVA: 0x001716F0 File Offset: 0x0016F8F0
		private void ConfigureKeyboardShortcuts()
		{
			this.editor.ShortcutKeys = new ShortcutKeysSettings(Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None);
		}

		// Token: 0x06005BF7 RID: 23543 RVA: 0x00171728 File Offset: 0x0016F928
		private void ConfigureToolbar()
		{
			devDept.Eyeshot.ToolBar toolBar = new devDept.Eyeshot.ToolBar(devDept.Eyeshot.ToolBar.positionType.VerticalTopRight, true, new ObservableCollection<devDept.Eyeshot.ToolBarButton>());
			this.editor.ButtonStyle.Size = 24;
			toolBar.SnapsToDevicePixels = false;
			toolBar.UseLayoutRounding = false;
			devDept.Eyeshot.ToolBarButton toolBarButton = new devDept.Eyeshot.ToolBarButton(EditorImagesHelper.ViewHome_24X24, #Phc.#3hc(107421363), Strings.StringViewHome, devDept.Eyeshot.ToolBarButton.styleType.PushButton, true)
			{
				DownImage = EditorImagesHelper.ViewHome_Pushed_24X24,
				HoverImage = EditorImagesHelper.ViewHome_Pushed_24X24
			};
			toolBarButton.Click += this.ViewHomeButton_Click;
			toolBar.Buttons.Add(toolBarButton);
			if (!this.is2DViewport)
			{
				devDept.Eyeshot.ToolBarButton toolBarButton2 = new devDept.Eyeshot.ToolBarButton(EditorImagesHelper.View3DAxis_24X24, #Phc.#3hc(107421318), Strings.StringView3D, devDept.Eyeshot.ToolBarButton.styleType.PushButton, true)
				{
					DownImage = EditorImagesHelper.View3DAxis_Pushed_24X24,
					HoverImage = EditorImagesHelper.View3DAxis_Pushed_24X24
				};
				toolBarButton2.Click += this.View3DButton_Click;
				toolBar.Buttons.Add(toolBarButton2);
				toolBar.Buttons.Add(new devDept.Eyeshot.ToolBarButton(EditorImagesHelper.Rotate3D_24X24, #Phc.#3hc(107421341), Strings.StringRotate, devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true)
				{
					DownImage = EditorImagesHelper.Rotate3D_Pushed_24X24,
					HoverImage = EditorImagesHelper.Rotate3D_Pushed_24X24,
					Pushed = false,
					Tag = actionType.Rotate
				});
				toolBar.Buttons.Last<devDept.Eyeshot.ToolBarButton>().Click += delegate(object s, EventArgs e)
				{
					this.HandleToggleButtonClick(s, actionType.Rotate);
				};
				this.toggleButtons.Add(toolBar.Buttons.Last<devDept.Eyeshot.ToolBarButton>());
			}
			this.ZoomToModelButton = new devDept.Eyeshot.ToolBarButton(EditorImagesHelper.ZoomToWorkspace_24X24, #Phc.#3hc(107421328), Strings.StringZoomToModel, devDept.Eyeshot.ToolBarButton.styleType.PushButton, true)
			{
				DownImage = EditorImagesHelper.ZoomToWorkspace_Pushed_24X24,
				HoverImage = EditorImagesHelper.ZoomToWorkspace_Pushed_24X24
			};
			this.ZoomToModelButton.Click += this.ZoomToWorkspace_Click;
			toolBar.Buttons.Add(this.ZoomToModelButton);
			toolBar.Buttons.Add(new devDept.Eyeshot.ToolBarButton(EditorImagesHelper.ZoomToWindow_24X24, #Phc.#3hc(107421307), Strings.StringZoomToWindow, devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true)
			{
				DownImage = EditorImagesHelper.ZoomToWindow_Pushed_24X24,
				HoverImage = EditorImagesHelper.ZoomToWindow_Pushed_24X24,
				Tag = actionType.ZoomWindow
			});
			toolBar.Buttons.Last<devDept.Eyeshot.ToolBarButton>().Click += delegate(object s, EventArgs e)
			{
				this.HandleToggleButtonClick(s, actionType.ZoomWindow);
			};
			this.toggleButtons.Add(toolBar.Buttons.Last<devDept.Eyeshot.ToolBarButton>());
			toolBar.Buttons.Add(new devDept.Eyeshot.ToolBarButton(EditorImagesHelper.ZoomIn_24X24, #Phc.#3hc(107421262), Strings.StringZoomIn, devDept.Eyeshot.ToolBarButton.styleType.PushButton, true)
			{
				DownImage = EditorImagesHelper.ZoomIn_Pushed_24X24,
				HoverImage = EditorImagesHelper.ZoomIn_Pushed_24X24
			});
			toolBar.Buttons.Last<devDept.Eyeshot.ToolBarButton>().Click += delegate(object s, EventArgs e)
			{
				this.ExecuteOnLock(delegate
				{
					this.editor.ZoomIn(32);
				});
			};
			toolBar.Buttons.Add(new devDept.Eyeshot.ToolBarButton(EditorImagesHelper.ZoomOut_24X24, #Phc.#3hc(107421249), Strings.StringZoomOut, devDept.Eyeshot.ToolBarButton.styleType.PushButton, true)
			{
				DownImage = EditorImagesHelper.ZoomOut_Pushed_24X24,
				HoverImage = EditorImagesHelper.ZoomOut_Pushed_24X24
			});
			toolBar.Buttons.Last<devDept.Eyeshot.ToolBarButton>().Click += delegate(object s, EventArgs e)
			{
				this.ExecuteOnLock(delegate
				{
					this.editor.ZoomOut(32);
				});
			};
			toolBar.Buttons.Add(new devDept.Eyeshot.ToolBarButton(EditorImagesHelper.Pan_24X24, #Phc.#3hc(107421268), Strings.StringPan, devDept.Eyeshot.ToolBarButton.styleType.ToggleButton, true)
			{
				DownImage = EditorImagesHelper.Pan_Pushed_24X24,
				HoverImage = EditorImagesHelper.Pan_Pushed_24X24,
				Tag = actionType.Pan
			});
			toolBar.Buttons.Last<devDept.Eyeshot.ToolBarButton>().Click += delegate(object s, EventArgs e)
			{
				this.HandleToggleButtonClick(s, actionType.Pan);
			};
			this.toggleButtons.Add(toolBar.Buttons.Last<devDept.Eyeshot.ToolBarButton>());
			this.ViewPort.ToolBars.Add(toolBar);
		}

		// Token: 0x06005BF8 RID: 23544 RVA: 0x00171AA4 File Offset: 0x0016FCA4
		private void HandleToggleButtonClick(object sender, actionType actionType)
		{
			this.ExecuteOnLock(delegate
			{
				devDept.Eyeshot.ToolBarButton btn = (devDept.Eyeshot.ToolBarButton)sender;
				if (btn.Pushed)
				{
					actionType actionMode = this.editor.ActionMode;
					this.editor.ActionMode = actionType;
					this.editor.OnActionModeChanged(actionMode, this.editor.ActionMode);
					this.toggleButtons.ForEach(delegate(devDept.Eyeshot.ToolBarButton item)
					{
						item.Pushed = (item == btn);
					});
					return;
				}
				actionType actionMode2 = this.editor.ActionMode;
				this.editor.ActionMode = actionType.None;
				this.editor.OnActionModeChanged(actionMode2, this.editor.ActionMode);
			});
		}

		// Token: 0x04002634 RID: 9780
		private readonly EyeshotEditor editor;

		// Token: 0x04002635 RID: 9781
		private readonly SolidColorBrush viewCubeBackground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(byte.MaxValue, 254, 254, 254));

		// Token: 0x04002636 RID: 9782
		private readonly SolidColorBrush viewCubeTextColor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(byte.MaxValue, 162, 162, 162));

		// Token: 0x04002637 RID: 9783
		private readonly SolidColorBrush viewCubeRingColor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(byte.MaxValue, 162, 162, 162));

		// Token: 0x04002638 RID: 9784
		private readonly SolidColorBrush viewCubeHighlightColor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(byte.MaxValue, 0, 201, 75));

		// Token: 0x04002639 RID: 9785
		private readonly List<devDept.Eyeshot.ToolBarButton> toggleButtons = new List<devDept.Eyeshot.ToolBarButton>();

		// Token: 0x0400263A RID: 9786
		private readonly bool is2DViewport;

		// Token: 0x0400263B RID: 9787
		private readonly NonBlockingLock toolbarButtonLock = new NonBlockingLock();
	}
}
