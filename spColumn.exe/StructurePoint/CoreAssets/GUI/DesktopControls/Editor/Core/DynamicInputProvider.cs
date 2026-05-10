using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using devDept.Eyeshot;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.Geometry.Helpers;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B09 RID: 2825
	public sealed class DynamicInputProvider
	{
		// Token: 0x06005C20 RID: 23584 RVA: 0x001729D0 File Offset: 0x00170BD0
		public DynamicInputProvider()
		{
			Key[] array = new Key[26];
			RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>3.ADB93876F580EB6F802182C24292C1826D15041B27A20F9203EEA1C9618923D9).FieldHandle);
			this.EditModeTriggerKeys = new HashSet<Key>(array);
			this.Background = System.Drawing.Color.FromArgb(255, 242, 242, 242);
			this.TextColor = System.Drawing.Color.Black;
			this.TextBackground = System.Drawing.Color.White;
			this.BoxBorderColor = System.Drawing.Color.FromArgb(255, 204, 206, 219);
			this.ControlBorderColor = System.Drawing.Color.FromArgb(255, 210, 212, 233);
			this.DrawLocation = new Point3D();
			this.DisabledInputValueColor = System.Drawing.Color.FromArgb(255, 166, 166, 166);
			this.StopFollowingInsertionPointOnCancel = true;
			base..ctor();
			this.Prompt = #Phc.#3hc(107421618) + System.Environment.NewLine + #Phc.#3hc(107421593);
		}

		// Token: 0x14000164 RID: 356
		// (add) Token: 0x06005C21 RID: 23585 RVA: 0x00172B38 File Offset: 0x00170D38
		// (remove) Token: 0x06005C22 RID: 23586 RVA: 0x00172B70 File Offset: 0x00170D70
		public event EventHandler<DynamicInputValueValidationEventArgs> ValidatingCoordinate;

		// Token: 0x14000165 RID: 357
		// (add) Token: 0x06005C23 RID: 23587 RVA: 0x00172BA8 File Offset: 0x00170DA8
		// (remove) Token: 0x06005C24 RID: 23588 RVA: 0x00172BE0 File Offset: 0x00170DE0
		public event EventHandler<DynamicInputCoordinateEventArgs> CoordinateChanged;

		// Token: 0x14000166 RID: 358
		// (add) Token: 0x06005C25 RID: 23589 RVA: 0x00172C18 File Offset: 0x00170E18
		// (remove) Token: 0x06005C26 RID: 23590 RVA: 0x00172C50 File Offset: 0x00170E50
		public event EventHandler<DynamicInputCoordinateEventArgs> CoordinateCommited;

		// Token: 0x14000167 RID: 359
		// (add) Token: 0x06005C27 RID: 23591 RVA: 0x00172C88 File Offset: 0x00170E88
		// (remove) Token: 0x06005C28 RID: 23592 RVA: 0x00172CC0 File Offset: 0x00170EC0
		public event EventHandler<DynamicInputCoordinateSnapEventArgs> CoordinateSnapRequested;

		// Token: 0x17001A3F RID: 6719
		// (get) Token: 0x06005C29 RID: 23593 RVA: 0x0004CF4F File Offset: 0x0004B14F
		public DynamicInputProviderConfiguration Config { get; } = new DynamicInputProviderConfiguration();

		// Token: 0x17001A40 RID: 6720
		// (get) Token: 0x06005C2A RID: 23594 RVA: 0x0004CF57 File Offset: 0x0004B157
		// (set) Token: 0x06005C2B RID: 23595 RVA: 0x0004CF5F File Offset: 0x0004B15F
		public bool IsInEditMode { get; private set; }

		// Token: 0x17001A41 RID: 6721
		// (get) Token: 0x06005C2C RID: 23596 RVA: 0x0004CF68 File Offset: 0x0004B168
		// (set) Token: 0x06005C2D RID: 23597 RVA: 0x0004CF75 File Offset: 0x0004B175
		public string Prompt
		{
			get
			{
				return this.Config.Prompt;
			}
			set
			{
				this.Config.Prompt = value;
			}
		}

		// Token: 0x17001A42 RID: 6722
		// (get) Token: 0x06005C2E RID: 23598 RVA: 0x0004CF83 File Offset: 0x0004B183
		public FontData PromptFont { get; } = new FontData();

		// Token: 0x17001A43 RID: 6723
		// (get) Token: 0x06005C2F RID: 23599 RVA: 0x0004CF8B File Offset: 0x0004B18B
		public FontData InputFont { get; } = new FontData();

		// Token: 0x17001A44 RID: 6724
		// (get) Token: 0x06005C30 RID: 23600 RVA: 0x0004CF93 File Offset: 0x0004B193
		public FontData ValuesFont { get; } = new FontData();

		// Token: 0x17001A45 RID: 6725
		// (get) Token: 0x06005C31 RID: 23601 RVA: 0x0004CF9B File Offset: 0x0004B19B
		public ISet<Key> EditModeTriggerKeys { get; }

		// Token: 0x17001A46 RID: 6726
		// (get) Token: 0x06005C32 RID: 23602 RVA: 0x0004CFA3 File Offset: 0x0004B1A3
		// (set) Token: 0x06005C33 RID: 23603 RVA: 0x0004CFAB File Offset: 0x0004B1AB
		public System.Drawing.Color Background { get; set; }

		// Token: 0x17001A47 RID: 6727
		// (get) Token: 0x06005C34 RID: 23604 RVA: 0x0004CFB4 File Offset: 0x0004B1B4
		// (set) Token: 0x06005C35 RID: 23605 RVA: 0x0004CFBC File Offset: 0x0004B1BC
		public System.Drawing.Color TextColor { get; set; }

		// Token: 0x17001A48 RID: 6728
		// (get) Token: 0x06005C36 RID: 23606 RVA: 0x0004CFC5 File Offset: 0x0004B1C5
		// (set) Token: 0x06005C37 RID: 23607 RVA: 0x0004CFCD File Offset: 0x0004B1CD
		public System.Drawing.Color TextBackground { get; set; }

		// Token: 0x17001A49 RID: 6729
		// (get) Token: 0x06005C38 RID: 23608 RVA: 0x0004CFD6 File Offset: 0x0004B1D6
		// (set) Token: 0x06005C39 RID: 23609 RVA: 0x0004CFDE File Offset: 0x0004B1DE
		public System.Drawing.Color BoxBorderColor { get; set; }

		// Token: 0x17001A4A RID: 6730
		// (get) Token: 0x06005C3A RID: 23610 RVA: 0x0004CFE7 File Offset: 0x0004B1E7
		// (set) Token: 0x06005C3B RID: 23611 RVA: 0x0004CFEF File Offset: 0x0004B1EF
		public System.Drawing.Color ControlBorderColor { get; set; }

		// Token: 0x17001A4B RID: 6731
		// (get) Token: 0x06005C3C RID: 23612 RVA: 0x0004CFF8 File Offset: 0x0004B1F8
		// (set) Token: 0x06005C3D RID: 23613 RVA: 0x0004D000 File Offset: 0x0004B200
		public Point3D DrawLocation { get; set; }

		// Token: 0x17001A4C RID: 6732
		// (get) Token: 0x06005C3E RID: 23614 RVA: 0x0004D009 File Offset: 0x0004B209
		// (set) Token: 0x06005C3F RID: 23615 RVA: 0x0004D011 File Offset: 0x0004B211
		public Point3D InputValue
		{
			get
			{
				return this.inputValue;
			}
			private set
			{
				if (this.inputValue != value)
				{
					this.inputValue = value;
				}
			}
		}

		// Token: 0x17001A4D RID: 6733
		// (get) Token: 0x06005C40 RID: 23616 RVA: 0x0004D028 File Offset: 0x0004B228
		// (set) Token: 0x06005C41 RID: 23617 RVA: 0x0004D030 File Offset: 0x0004B230
		public System.Drawing.Color DisabledInputValueColor { get; set; }

		// Token: 0x17001A4E RID: 6734
		// (get) Token: 0x06005C42 RID: 23618 RVA: 0x0004D039 File Offset: 0x0004B239
		// (set) Token: 0x06005C43 RID: 23619 RVA: 0x0004D041 File Offset: 0x0004B241
		public bool ShouldFollowInsertionPoint
		{
			get
			{
				return this.shouldFollowInsertionPoint;
			}
			set
			{
				if (this.shouldFollowInsertionPoint != value)
				{
					this.shouldFollowInsertionPoint = value;
				}
			}
		}

		// Token: 0x17001A4F RID: 6735
		// (get) Token: 0x06005C44 RID: 23620 RVA: 0x0004D053 File Offset: 0x0004B253
		// (set) Token: 0x06005C45 RID: 23621 RVA: 0x0004D05B File Offset: 0x0004B25B
		internal EyeshotEditor Editor
		{
			get
			{
				return this.editor;
			}
			set
			{
				this.editor = value;
				if (value != null)
				{
					this.drawingHelper = new DrawingHelper(value);
				}
			}
		}

		// Token: 0x17001A50 RID: 6736
		// (get) Token: 0x06005C46 RID: 23622 RVA: 0x0004D073 File Offset: 0x0004B273
		internal RenderContextBase Context
		{
			get
			{
				EyeshotEditor eyeshotEditor = this.Editor;
				if (eyeshotEditor == null)
				{
					return null;
				}
				return eyeshotEditor.renderContext;
			}
		}

		// Token: 0x17001A51 RID: 6737
		// (get) Token: 0x06005C47 RID: 23623 RVA: 0x0004D086 File Offset: 0x0004B286
		// (set) Token: 0x06005C48 RID: 23624 RVA: 0x0004D08E File Offset: 0x0004B28E
		public bool StopFollowingInsertionPointOnCancel { get; set; }

		// Token: 0x06005C49 RID: 23625 RVA: 0x0004D097 File Offset: 0x0004B297
		public void SetPrompt(string propmpt)
		{
			this.Prompt = propmpt;
		}

		// Token: 0x06005C4A RID: 23626 RVA: 0x0004D0A0 File Offset: 0x0004B2A0
		public void SetInputValue(Point3D value)
		{
			this.InputValue = value;
		}

		// Token: 0x06005C4B RID: 23627 RVA: 0x00172CF8 File Offset: 0x00170EF8
		public void HandleEditorMousePositionChanged(Point3D planePosition)
		{
			if (planePosition == null)
			{
				return;
			}
			DynamicInputCoordinateSnapEventArgs dynamicInputCoordinateSnapEventArgs = new DynamicInputCoordinateSnapEventArgs(planePosition);
			this.OnCoordinateSnapRequested(dynamicInputCoordinateSnapEventArgs);
			if (dynamicInputCoordinateSnapEventArgs.SnappedPoint != null)
			{
				planePosition = dynamicInputCoordinateSnapEventArgs.SnappedPoint;
			}
			this.DrawLocation = planePosition;
			this.InputValue = this.GetInputValue(planePosition);
		}

		// Token: 0x06005C4C RID: 23628 RVA: 0x00172D48 File Offset: 0x00170F48
		public void Draw(System.Drawing.Point screenPosition, Point3D planePosition)
		{
			if (planePosition == null || this.DrawLocation == null)
			{
				return;
			}
			if (!this.Config.EnabledAndActive || this.IsInEditMode || this.Editor.ActionMode != actionType.None)
			{
				return;
			}
			this.ConfigureFonts();
			Point3D point3D;
			if (this.ShouldFollowInsertionPoint && this.InputValue != null)
			{
				Point3D basePoint = this.GetBasePoint(false);
				point3D = this.Editor.WorldToScreen(basePoint);
			}
			else
			{
				point3D = this.Editor.WorldToScreen(planePosition);
			}
			point3D.X += (double)this.cursorOffset.Width;
			point3D.Y += (double)this.cursorOffset.Height;
			Rectangle rectangle = new Rectangle((int)point3D.X, (int)point3D.Y, 0, 0);
			if (this.Config.ShowPrompt)
			{
				rectangle = this.DrawTextInBorder(point3D, this.Prompt, ContentAlignment.TopLeft, this.padding, System.Drawing.Color.White, System.Drawing.Color.Black, this.PromptFont, null);
				rectangle.Height += (int)(this.padding.Top + this.padding.Bottom);
			}
			Point3D point3D2 = new Point3D((double)rectangle.X - this.padding.Left + 1.0, (double)(rectangle.Top - rectangle.Height));
			if (this.Config.ShouldShowInputBoxes() && this.Config.XValue.IsVisible)
			{
				System.Drawing.Color textAndBorderColor = this.Config.XValue.Enabled ? System.Drawing.Color.Black : this.DisabledInputValueColor;
				System.Drawing.Color backgroundColor = (!this.Config.EnableDisplayOnly && this.Config.XValue.Enabled) ? System.Drawing.Color.FromArgb(100, 196, 222, 255) : System.Drawing.Color.White;
				Point3D textPosition = point3D2;
				DynamicInputValueConfiguration xvalue = this.Config.XValue;
				Point3D point3D3 = this.InputValue;
				rectangle = this.DrawTextInBorder(textPosition, this.Format(xvalue, (point3D3 != null) ? point3D3.X : 0.0), ContentAlignment.TopLeft, this.valuePadding, backgroundColor, textAndBorderColor, this.ValuesFont, null);
			}
			if (this.Config.ShouldShowInputBoxes() && this.Config.YValue.IsVisible)
			{
				System.Drawing.Color textAndBorderColor2 = this.Config.YValue.Enabled ? System.Drawing.Color.Black : this.DisabledInputValueColor;
				System.Drawing.Color backgroundColor2 = (!this.Config.EnableDisplayOnly && this.Config.YValue.Enabled && !this.Config.XValue.Enabled) ? System.Drawing.Color.FromArgb(100, 196, 222, 255) : System.Drawing.Color.White;
				point3D2 = new Point3D((double)(rectangle.X + rectangle.Width + 5), (double)(rectangle.Top + 1));
				Point3D textPosition2 = point3D2;
				DynamicInputValueConfiguration yvalue = this.Config.YValue;
				Point3D point3D4 = this.InputValue;
				this.DrawTextInBorder(textPosition2, this.Format(yvalue, (point3D4 != null) ? point3D4.Y : 0.0), ContentAlignment.TopLeft, this.valuePadding, backgroundColor2, textAndBorderColor2, this.ValuesFont, null);
			}
		}

		// Token: 0x06005C4D RID: 23629 RVA: 0x0004D0A9 File Offset: 0x0004B2A9
		protected void OnValidatingCoordinate(DynamicInputValueValidationEventArgs e)
		{
			EventHandler<DynamicInputValueValidationEventArgs> validatingCoordinate = this.ValidatingCoordinate;
			if (validatingCoordinate == null)
			{
				return;
			}
			validatingCoordinate(this, e);
		}

		// Token: 0x06005C4E RID: 23630 RVA: 0x00173090 File Offset: 0x00171290
		protected void OnCoordinateChanged(DynamicInputCoordinateEventArgs e)
		{
			if (this.inputWindow.CurrentState == DynamicInputResultState.Canceled)
			{
				return;
			}
			if (e.Point != null)
			{
				this.InputValue = e.Point;
			}
			else if (e.Angle != null)
			{
				this.InputValue = new Point3D(e.Angle.Value, 0.0);
			}
			if (e.IsRawInputPoint)
			{
				DynamicInputCoordinateSnapEventArgs dynamicInputCoordinateSnapEventArgs = new DynamicInputCoordinateSnapEventArgs(e.Point);
				this.OnCoordinateSnapRequested(dynamicInputCoordinateSnapEventArgs);
				e.Point = (dynamicInputCoordinateSnapEventArgs.SnappedPoint ?? dynamicInputCoordinateSnapEventArgs.InputPoint);
				this.InputValue = this.GetInputValue(e.Point);
			}
			EventHandler<DynamicInputCoordinateEventArgs> coordinateChanged = this.CoordinateChanged;
			if (coordinateChanged != null)
			{
				coordinateChanged(this, e);
			}
			if (this.ShouldFollowInsertionPoint && this.inputWindow.ShouldChangePosition)
			{
				this.FollowChangedCoordinate(true);
			}
			this.inputWindow.ShouldChangePosition = true;
		}

		// Token: 0x06005C4F RID: 23631 RVA: 0x0004D0BD File Offset: 0x0004B2BD
		protected void OnCoordinateCommited(DynamicInputCoordinateEventArgs e)
		{
			if (e.Point != null)
			{
				this.InputValue = e.Point;
			}
			EventHandler<DynamicInputCoordinateEventArgs> coordinateCommited = this.CoordinateCommited;
			if (coordinateCommited == null)
			{
				return;
			}
			coordinateCommited(this, e);
		}

		// Token: 0x06005C50 RID: 23632 RVA: 0x00173178 File Offset: 0x00171378
		internal void HandleEditorKeyDown(KeyEventArgs args)
		{
			if (this.Config.EnabledAndActive && !this.Config.EnableDisplayOnly && this.EditModeTriggerKeys.Contains(args.Key) && this.Editor.ActionMode == actionType.None)
			{
				this.IsInEditMode = true;
				this.EnsureInputWindow();
				this.Editor.Invalidate();
				try
				{
					this.inputWindow.ShowMe(this.InputValue, args.Key);
				}
				catch (InvalidOperationException)
				{
				}
			}
		}

		// Token: 0x06005C51 RID: 23633 RVA: 0x00173204 File Offset: 0x00171404
		public DynamicInputResultState OpenInputDirectly(Point3D coordinate)
		{
			this.Config.EnabledOverride = true;
			DynamicInputResultState result;
			try
			{
				result = this.OpenInput(coordinate);
			}
			catch (InvalidOperationException)
			{
				result = DynamicInputResultState.Canceled;
			}
			finally
			{
				this.Config.EnabledOverride = false;
			}
			return result;
		}

		// Token: 0x06005C52 RID: 23634 RVA: 0x00173258 File Offset: 0x00171458
		public DynamicInputResultState OpenInput(Point3D coordinate)
		{
			DynamicInputResultState result;
			try
			{
				this.IsInEditMode = true;
				this.ConfigureFonts();
				this.EnsureInputWindow();
				this.Editor.Invalidate();
				result = this.inputWindow.ShowMe(coordinate, Key.Return);
			}
			catch (InvalidOperationException)
			{
				result = DynamicInputResultState.Canceled;
			}
			return result;
		}

		// Token: 0x06005C53 RID: 23635 RVA: 0x0004D0EB File Offset: 0x0004B2EB
		public DynamicInputResultState OpenInput()
		{
			return this.OpenInput(this.InputValue);
		}

		// Token: 0x06005C54 RID: 23636 RVA: 0x0004D0F9 File Offset: 0x0004B2F9
		protected void OnCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs e)
		{
			EventHandler<DynamicInputCoordinateSnapEventArgs> coordinateSnapRequested = this.CoordinateSnapRequested;
			if (coordinateSnapRequested == null)
			{
				return;
			}
			coordinateSnapRequested(this, e);
		}

		// Token: 0x06005C55 RID: 23637 RVA: 0x001732AC File Offset: 0x001714AC
		public void SetWindowPosition(Point2D inputPointPosition)
		{
			if (inputPointPosition == null)
			{
				return;
			}
			inputPointPosition = this.Editor.WorldToScreen(new Point3D(inputPointPosition.X, inputPointPosition.Y));
			inputPointPosition = this.Editor.DpiScaleDown<Point2D>(inputPointPosition);
			System.Windows.Point point = this.Editor.PointToScreen(new System.Windows.Point(0.0, 0.0));
			double num = this.Editor.DpiScaleDown(point).Y + this.Editor.ActualHeight - inputPointPosition.Y;
			double num2 = this.Editor.PointToScreen(new System.Windows.Point(inputPointPosition.X, inputPointPosition.Y)).X / this.Editor.DpiScaleX;
			double top = num - (double)this.cursorOffset.Height;
			double left = num2 + (double)this.cursorOffset.Width - 1.0;
			this.EnsureInputWindowIsInWorkspace(ref top, ref left);
			this.inputWindow.Top = top;
			this.inputWindow.Left = left;
		}

		// Token: 0x06005C56 RID: 23638 RVA: 0x0004D10D File Offset: 0x0004B30D
		private void InputWindow_Closed(object sender, EventArgs e)
		{
			this.IsInEditMode = false;
			this.Editor.Invalidate();
		}

		// Token: 0x06005C57 RID: 23639 RVA: 0x0004D121 File Offset: 0x0004B321
		private void InputWindow_InputCancelled(object sender, EventArgs e)
		{
			if (this.StopFollowingInsertionPointOnCancel)
			{
				this.ShouldFollowInsertionPoint = false;
			}
			this.Editor.Invalidate();
		}

		// Token: 0x06005C58 RID: 23640 RVA: 0x001733BC File Offset: 0x001715BC
		private void ConfigureFonts()
		{
			EyeshotEditor eyeshotEditor = this.Editor;
			if (eyeshotEditor == null || eyeshotEditor.IsHardwareAccelerated)
			{
				this.ValuesFont.FontFamily = #Phc.#3hc(107421504);
				this.ValuesFont.Size = 10f;
				this.valuePadding = new Thickness(1.0);
				return;
			}
			this.ValuesFont.FontFamily = #Phc.#3hc(107422912);
			this.ValuesFont.Size = 9.5f;
			this.valuePadding = new Thickness(2.0, 1.0, 2.0, 1.0);
		}

		// Token: 0x06005C59 RID: 23641 RVA: 0x0017346C File Offset: 0x0017166C
		private Point3D GetBasePoint(bool inputWindowAlreadyShown)
		{
			if (inputWindowAlreadyShown && this.Config.Mode != DynamicInputMode.RelativeAngle && this.Config.Mode != DynamicInputMode.Angle)
			{
				return this.InputValue;
			}
			DynamicInputMode mode = this.Config.Mode;
			if (mode == DynamicInputMode.Regular)
			{
				return this.InputValue;
			}
			if (mode == DynamicInputMode.Angle)
			{
				return this.DrawLocation;
			}
			if (mode != DynamicInputMode.RelativeAngle)
			{
				return this.InputValue + this.Config.LastInputPoint;
			}
			Point3D point3D = this.Config.LastInputPoint - this.Config.LastOriginPoint;
			float num = GeometryHelper.#Knc(point3D.Y, point3D.X);
			double x = this.InputValue.X;
			double radius = Math.Abs(this.Config.LastOriginPoint.DistanceTo(this.Config.LastInputPoint));
			return EyeshotGeometry.ConstructPointDegree(this.Config.LastOriginPoint, radius, (double)num - x);
		}

		// Token: 0x06005C5A RID: 23642 RVA: 0x00173554 File Offset: 0x00171754
		private Point3D GetInputValue(Point3D planePosition)
		{
			switch (this.Config.Mode)
			{
			case DynamicInputMode.Regular:
				return planePosition;
			case DynamicInputMode.Relative:
			case DynamicInputMode.RelativeRectangle:
				return planePosition - (this.Config.LastInputPoint ?? Point3D.Origin);
			case DynamicInputMode.RelativeRadius:
			{
				Point3D point3D = planePosition - (this.Config.LastInputPoint ?? Point3D.Origin);
				return new Point3D(Math.Sqrt(Math.Pow(point3D.X, 2.0) + Math.Pow(point3D.Y, 2.0)), 0.0);
			}
			case DynamicInputMode.Angle:
			{
				double num = planePosition.X - (this.Config.LastInputPoint ?? Point3D.Origin).X;
				double num2 = planePosition.Y - (this.Config.LastInputPoint ?? Point3D.Origin).Y;
				if (Math.Abs(num) < 0.001 && Math.Abs(num2) < 0.001)
				{
					return new Point3D();
				}
				return new Point3D(Utility.RadToDeg(Utility.ArcTanProblem(num, num2)), 0.0);
			}
			case DynamicInputMode.RelativeAngle:
			{
				Point3D point3D2 = this.Config.LastInputPoint ?? Point3D.Origin;
				Point3D point3D3 = this.Config.LastOriginPoint ?? Point3D.Origin;
				Func<double, double> angleModifier = this.Config.AngleModifier;
				Vector vector = new Vector(point3D2.X - point3D3.X, point3D2.Y - point3D3.Y);
				Vector vector2 = new Vector(planePosition.X - point3D3.X, planePosition.Y - point3D3.Y);
				double num3 = (Vector.AngleBetween(vector, vector2) + 360.0) % 360.0;
				num3 = (num3.Equals(0.0) ? 0.0 : (360.0 - num3));
				num3 = ((angleModifier != null) ? angleModifier(num3) : num3);
				return new Point3D(num3, 0.0);
			}
			case DynamicInputMode.Offset:
				return planePosition;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06005C5B RID: 23643 RVA: 0x0004D13D File Offset: 0x0004B33D
		private string Format(DynamicInputValueConfiguration valueConfig, double value)
		{
			return this.Format((!valueConfig.EnabledAndVisible) ? 0.0 : value);
		}

		// Token: 0x06005C5C RID: 23644 RVA: 0x0004D159 File Offset: 0x0004B359
		private string Format(double value)
		{
			return this.Config.CoordinateFormatter.CreateDisplayValue(value);
		}

		// Token: 0x06005C5D RID: 23645 RVA: 0x0017377C File Offset: 0x0017197C
		private Rectangle DrawTextInBorder(Point3D textPosition, string text, ContentAlignment alignment, Thickness textPadding, System.Drawing.Color backgroundColor, System.Drawing.Color textAndBorderColor, FontData fontData, int? minWidth = null)
		{
			return this.drawingHelper.DrawTextInBorder(textPosition, text, alignment, textPadding, backgroundColor, textAndBorderColor, textAndBorderColor, fontData.Font, minWidth, null);
		}

		// Token: 0x06005C5E RID: 23646 RVA: 0x001737B4 File Offset: 0x001719B4
		private void EnsureInputWindow()
		{
			if (this.inputWindow == null)
			{
				this.inputWindow = new DynamicInputWindow();
				this.inputWindow.Config = this.Config;
				this.inputWindow.CustomClosed += this.InputWindow_Closed;
				this.inputWindow.InputCancelled += this.InputWindow_InputCancelled;
				this.inputWindow.CoordinateChanged += delegate(object sender, DynamicInputCoordinateEventArgs args)
				{
					this.OnCoordinateChanged(args);
				};
				this.inputWindow.ValidatingCoordinate += delegate(object sender, DynamicInputValueValidationEventArgs args)
				{
					this.OnValidatingCoordinate(args);
				};
				this.inputWindow.CoordinateCommited += delegate(object sender, DynamicInputCoordinateEventArgs args)
				{
					this.OnCoordinateCommited(args);
				};
				this.windowPositionContraint = new WindowPositionContraint(this.inputWindow, new Func<Rect?>(this.GetEditorScreenBounds));
			}
			this.inputWindow.PromptText.FontFamily = new System.Windows.Media.FontFamily(this.PromptFont.Font.FontFamily.Name);
			this.inputWindow.Owner = this.Editor.ParentOfType<Window>();
			if (this.ShouldFollowInsertionPoint)
			{
				this.FollowChangedCoordinate(false);
			}
			else
			{
				System.Windows.Point point = new System.Windows.Point((double)this.Editor.ScreenPosition.X, (double)this.Editor.ScreenPosition.Y);
				point.X /= this.editor.DpiScaleX;
				point.Y /= this.editor.DpiScaleY;
				point = this.Editor.PointToScreen(point);
				double top = (point.Y - (double)this.cursorOffset.Height) / this.editor.DpiScaleY;
				double left = (point.X + (double)(this.cursorOffset.Width - 1)) / this.editor.DpiScaleX;
				this.EnsureInputWindowIsInWorkspace(ref top, ref left);
				this.inputWindow.Top = top;
				this.inputWindow.Left = left;
			}
			this.inputWindow.InitialPosition = this.Editor.PlanePosition;
		}

		// Token: 0x06005C5F RID: 23647 RVA: 0x001739C0 File Offset: 0x00171BC0
		private Rect? GetEditorScreenBounds()
		{
			if (this.Editor == null)
			{
				return null;
			}
			System.Windows.Point point = this.Editor.PointToScreen(default(System.Windows.Point));
			System.Windows.Point point2 = this.Editor.PointToScreen(new System.Windows.Point(this.Editor.ActualWidth, this.Editor.ActualHeight));
			return new Rect?(new Rect(point, point2));
		}

		// Token: 0x06005C60 RID: 23648 RVA: 0x00173A28 File Offset: 0x00171C28
		private void FollowChangedCoordinate(bool inputWindowAlreadyShown)
		{
			try
			{
				Point3D basePoint = this.GetBasePoint(inputWindowAlreadyShown);
				this.SetWindowPosition(basePoint);
			}
			catch (InvalidOperationException)
			{
			}
		}

		// Token: 0x06005C61 RID: 23649 RVA: 0x00173A5C File Offset: 0x00171C5C
		private void EnsureInputWindowIsInWorkspace(ref double top, ref double left)
		{
			System.Windows.Point point = this.Editor.PointToScreen(new System.Windows.Point(0.0, 0.0));
			point = this.Editor.DpiScaleDown(point);
			double num = Math.Max((double)((this.Config.XValue.IsVisible && this.Config.YValue.IsVisible) ? 100 : 66), this.inputWindow.ActualHeight);
			double num2 = Math.Max(220.0, this.inputWindow.ActualWidth);
			if (top < point.Y)
			{
				top = point.Y;
			}
			if (top > point.Y + this.Editor.ActualHeight - num)
			{
				top = point.Y + this.Editor.ActualHeight - num;
			}
			if (left < point.X)
			{
				left = point.X;
			}
			if (left > point.X + this.Editor.ActualWidth - num2)
			{
				left = point.X + this.Editor.ActualWidth - num2;
			}
		}

		// Token: 0x04002650 RID: 9808
		public static IDictionary<Key, string> KeyMap = new Dictionary<Key, string>
		{
			{
				Key.OemMinus,
				#Phc.#3hc(107408434)
			},
			{
				Key.NumPad0,
				#Phc.#3hc(107426661)
			},
			{
				Key.NumPad1,
				#Phc.#3hc(107421527)
			},
			{
				Key.NumPad2,
				#Phc.#3hc(107360074)
			},
			{
				Key.NumPad3,
				#Phc.#3hc(107421522)
			},
			{
				Key.NumPad4,
				#Phc.#3hc(107421485)
			},
			{
				Key.NumPad5,
				#Phc.#3hc(107421480)
			},
			{
				Key.NumPad6,
				#Phc.#3hc(107421475)
			},
			{
				Key.NumPad7,
				#Phc.#3hc(107421502)
			},
			{
				Key.NumPad8,
				#Phc.#3hc(107421497)
			},
			{
				Key.NumPad9,
				#Phc.#3hc(107421492)
			},
			{
				Key.OemPeriod,
				#Phc.#3hc(107356879)
			},
			{
				Key.OemPlus,
				#Phc.#3hc(107421455)
			},
			{
				Key.Add,
				#Phc.#3hc(107421455)
			},
			{
				Key.Subtract,
				#Phc.#3hc(107408434)
			},
			{
				Key.D0,
				#Phc.#3hc(107426661)
			},
			{
				Key.D1,
				#Phc.#3hc(107421527)
			},
			{
				Key.D2,
				#Phc.#3hc(107360074)
			},
			{
				Key.D3,
				#Phc.#3hc(107421522)
			},
			{
				Key.D4,
				#Phc.#3hc(107421485)
			},
			{
				Key.D5,
				#Phc.#3hc(107421480)
			},
			{
				Key.D6,
				#Phc.#3hc(107421475)
			},
			{
				Key.D7,
				#Phc.#3hc(107421502)
			},
			{
				Key.D8,
				#Phc.#3hc(107421497)
			},
			{
				Key.D9,
				#Phc.#3hc(107421492)
			}
		};

		// Token: 0x04002651 RID: 9809
		private readonly System.Drawing.Size cursorOffset = new System.Drawing.Size(20, -20);

		// Token: 0x04002652 RID: 9810
		private DynamicInputWindow inputWindow;

		// Token: 0x04002653 RID: 9811
		private WindowPositionContraint windowPositionContraint;

		// Token: 0x04002654 RID: 9812
		private Point3D inputValue = new Point3D();

		// Token: 0x04002655 RID: 9813
		private DrawingHelper drawingHelper;

		// Token: 0x04002656 RID: 9814
		private EyeshotEditor editor;

		// Token: 0x04002657 RID: 9815
		private Thickness padding = new Thickness(3.0);

		// Token: 0x04002658 RID: 9816
		private Thickness valuePadding = new Thickness(1.0);

		// Token: 0x04002659 RID: 9817
		private bool shouldFollowInsertionPoint;
	}
}
