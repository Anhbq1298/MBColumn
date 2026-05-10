using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using #7hc;
using devDept.Geometry;
using devDept.Graphics;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B08 RID: 2824
	public sealed class DrawingHelper
	{
		// Token: 0x06005C0E RID: 23566 RVA: 0x00171BBC File Offset: 0x0016FDBC
		public DrawingHelper(EyeshotEditor editor)
		{
			if (editor == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107351888));
			}
			this.editor = editor;
			this.coordinateOriginFont = FontsCache.GetOrCreate(#Phc.#3hc(107421227), 12f);
			this.coordinateOriginSafeFont = FontsCache.GetOrCreate(EyeshotEditor.SafeFontName, 11f);
		}

		// Token: 0x17001A3E RID: 6718
		// (get) Token: 0x06005C0F RID: 23567 RVA: 0x0004CF17 File Offset: 0x0004B117
		private RenderContextBase Context
		{
			get
			{
				return this.editor.renderContext;
			}
		}

		// Token: 0x06005C10 RID: 23568 RVA: 0x00171C58 File Offset: 0x0016FE58
		public void DrawLineIndicator(Point3D start, Point3D end, System.Drawing.Color color, double sideSize, float lineThickness, float mainLineThickness)
		{
			this.Context.SetColorWireframe(color, false);
			this.Context.SetLineSizeExt(lineThickness);
			this.DrawCross(start, color, sideSize, lineThickness);
			this.Context.SetLineSizeExt(mainLineThickness);
			this.Context.DrawLine(start, end);
		}

		// Token: 0x06005C11 RID: 23569 RVA: 0x00171CA8 File Offset: 0x0016FEA8
		public void DrawMeasureLineIndicator(Point3D start, Point3D end, System.Drawing.Color color, double sideSize, float lineThickness, float mainLineThickness)
		{
			this.Context.SetColorWireframe(color, false);
			this.Context.SetLineSizeExt(lineThickness);
			this.DrawCross(start, color, sideSize, lineThickness);
			this.DrawArrowHead(start, end, new System.Drawing.Color?(color), null, null, sideSize * 3.0, sideSize);
			this.Context.SetLineSizeExt(mainLineThickness);
			this.Context.DrawLine(start, end);
		}

		// Token: 0x06005C12 RID: 23570 RVA: 0x00171CA8 File Offset: 0x0016FEA8
		public void DrawMoveIndicator(Point3D start, Point3D end, System.Drawing.Color color, double sideSize, float lineThickness, float mainLineThickness)
		{
			this.Context.SetColorWireframe(color, false);
			this.Context.SetLineSizeExt(lineThickness);
			this.DrawCross(start, color, sideSize, lineThickness);
			this.DrawArrowHead(start, end, new System.Drawing.Color?(color), null, null, sideSize * 3.0, sideSize);
			this.Context.SetLineSizeExt(mainLineThickness);
			this.Context.DrawLine(start, end);
		}

		// Token: 0x06005C13 RID: 23571 RVA: 0x00171D24 File Offset: 0x0016FF24
		public System.Drawing.Size MeasureStringForLabel(string candidate, string fontName, double fontSize)
		{
			if (string.IsNullOrEmpty(candidate))
			{
				return default(System.Drawing.Size);
			}
			string key = string.Format(#Phc.#3hc(107421242), candidate.Length, fontName, fontSize);
			System.Drawing.Size size;
			if (this.measureStringForLabelCache.TryGetValue(key, out size) && this.lastMeasureFontName == fontName && Math.Abs(this.lastMeasureFontSize - fontSize) < 0.001)
			{
				return size;
			}
			this.lastMeasureFontSize = fontSize;
			this.lastMeasureFontName = fontName;
			Typeface typeface = new Typeface(new System.Windows.Media.FontFamily(fontName), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
			FormattedText formattedText = new FormattedText(candidate, CultureInfo.CurrentUICulture, System.Windows.FlowDirection.LeftToRight, typeface, fontSize, System.Windows.Media.Brushes.Black, new NumberSubstitution(), TextFormattingMode.Ideal, 1.0);
			double num = 1.5;
			size = new System.Drawing.Size((int)Math.Ceiling(formattedText.Width * num), (int)Math.Ceiling(formattedText.Height * num));
			this.measureStringForLabelCache[key] = size;
			return size;
		}

		// Token: 0x06005C14 RID: 23572 RVA: 0x00171E28 File Offset: 0x00170028
		public void DrawTextInCircle(Point3D textPosition, string text, ContentAlignment alignment, System.Drawing.Color textColor, float fontSize, string fontName, System.Drawing.Color background)
		{
			Font orCreate = FontsCache.GetOrCreate(fontName, fontSize);
			System.Drawing.Size size = this.MeasureStringForLabel(text, fontName, (double)fontSize);
			Point3D topLeftCorner = DrawingHelper.GetTopLeftCorner(textPosition, new System.Drawing.Size(size.Width, size.Height), alignment);
			Point3D[] array = EyeshotHelper.ConstructRegularPolygon(new Point3D(topLeftCorner.X + (double)size.Width / 2.0, topLeftCorner.Y - (double)size.Height / 2.0), (double)Math.Max(size.Width, size.Height) / 2.0 + 2.0, 40, 0.0, true).ToArray();
			this.Context.SetColorWireframe(textColor, false);
			this.Context.SetLineSizeExt(1f);
			this.Context.DrawLineStrip(array);
			this.editor.DrawTextExt((int)textPosition.X, (int)textPosition.Y, text, orCreate, textColor, background, alignment, false);
			this.DrawTrianglesFan(array, background);
			this.Context.EndDrawBufferedLines();
		}

		// Token: 0x06005C15 RID: 23573 RVA: 0x00171F40 File Offset: 0x00170140
		public Rectangle DrawTextInBorder(Point3D textPosition, string text, ContentAlignment alignment, Thickness padding, System.Drawing.Color backgroundColor, System.Drawing.Color textColor, System.Drawing.Color borderColor, Font font, int? minWidth = null, int? minHeight = null)
		{
			System.Drawing.Size size = TextRenderer.MeasureText(text, font);
			size.Width -= 6;
			if (minWidth != null)
			{
				size.Width = Math.Max(size.Width, minWidth.Value);
			}
			if (minHeight != null)
			{
				size.Height = Math.Max(size.Height, minHeight.Value);
			}
			Point3D topLeftCorner = DrawingHelper.GetTopLeftCorner(textPosition, size, alignment);
			Point3D bottomLeft = new Point3D(topLeftCorner.X, topLeftCorner.Y - (double)size.Height - padding.Bottom - padding.Top);
			Point3D point3D = new Point3D(topLeftCorner.X + (double)size.Width + padding.Left + padding.Right, topLeftCorner.Y);
			Point3D bottomRight = new Point3D(point3D.X, point3D.Y - (double)size.Height - padding.Bottom - padding.Top);
			this.DrawBorder(backgroundColor, borderColor, topLeftCorner, bottomLeft, point3D, bottomRight);
			System.Drawing.Point location = new System.Drawing.Point((int)(textPosition.X + padding.Left), (int)(textPosition.Y - padding.Top));
			Rectangle result = new Rectangle(location, size);
			this.editor.DrawTextExt(location.X, location.Y, text, font, textColor, System.Drawing.Color.Transparent, alignment, true);
			return result;
		}

		// Token: 0x06005C16 RID: 23574 RVA: 0x00172098 File Offset: 0x00170298
		public void DrawCross(Point3D point, System.Drawing.Color color, double wing, float lineThickness)
		{
			this.Context.SetColorWireframe(color, false);
			this.Context.SetLineSizeExt(lineThickness);
			this.Context.DrawLine((float)(point.X - wing), (float)point.Y, 0f, (float)(point.X + wing), (float)point.Y, 0f);
			this.Context.DrawLine((float)point.X, (float)(point.Y + wing), 0f, (float)point.X, (float)(point.Y - wing), 0f);
		}

		// Token: 0x06005C17 RID: 23575 RVA: 0x0017212C File Offset: 0x0017032C
		public void DrawTrianglesFan(Point3D[] points, System.Drawing.Color background)
		{
			this.Context.PushBlendState();
			this.Context.PushRasterizerState();
			this.Context.SetState(blendStateType.Blend);
			this.Context.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceFront_NoPolygonOffset);
			this.Context.SetColorMaterial(background, false);
			this.Context.DrawTrianglesFan(points, Vector3D.AxisZ);
			this.Context.PopRasterizerState();
			this.Context.PopBlendState();
		}

		// Token: 0x06005C18 RID: 23576 RVA: 0x001721A4 File Offset: 0x001703A4
		public void FillTriangles(Point3D[] points, System.Drawing.Color filColor)
		{
			this.Context.PushBlendState();
			this.Context.PushRasterizerState();
			this.Context.SetState(blendStateType.Blend);
			this.Context.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceFront_NoPolygonOffset);
			this.Context.SetColorMaterial(filColor, false);
			this.Context.DrawTriangles(points, Vector3D.AxisZ);
			this.Context.PopRasterizerState();
			this.Context.PopBlendState();
		}

		// Token: 0x06005C19 RID: 23577 RVA: 0x0017221C File Offset: 0x0017041C
		public void DrawTriangle(Point3D pointA, Point3D pointB, Point3D pointC, System.Drawing.Color? fillColor, System.Drawing.Color? strokeColor, float? strokeThickness)
		{
			if (fillColor != null)
			{
				this.FillTriangles(new Point3D[]
				{
					pointA,
					pointB,
					pointC
				}, fillColor.Value);
			}
			if (strokeColor != null && strokeThickness != null)
			{
				this.Context.SetColorWireframe(strokeColor.Value, false);
				this.Context.SetLineSizeExt(strokeThickness.Value);
				this.Context.DrawLine(pointB, pointA);
				this.Context.DrawLine(pointC, pointA);
				this.Context.DrawLine(pointB, pointC);
			}
		}

		// Token: 0x06005C1A RID: 23578 RVA: 0x001722B0 File Offset: 0x001704B0
		public void DrawRect(Point3D start, Point3D end, System.Drawing.Color? fillColor, System.Drawing.Color? strokeColor)
		{
			double x = Math.Min(start.X, end.X);
			double y = Math.Min(start.Y, end.Y);
			double x2 = Math.Max(start.X, end.X);
			double y2 = Math.Max(start.Y, end.Y);
			if (fillColor != null)
			{
				Point3D[] points = this.editor.WorldToScreen(new Point3D[]
				{
					new Point3D(x, y),
					new Point3D(x, y2),
					new Point3D(x2, y),
					new Point3D(x, y2),
					new Point3D(x2, y2),
					new Point3D(x2, y)
				});
				this.FillTriangles(points, fillColor.Value);
			}
			if (strokeColor != null)
			{
				this.Context.SetColorWireframe(strokeColor.Value, false);
				this.DrawLineUsingModelCoordinates(new Point3D(x, y), new Point3D(x, y2));
				this.DrawLineUsingModelCoordinates(new Point3D(x, y), new Point3D(x2, y));
				this.DrawLineUsingModelCoordinates(new Point3D(x, y2), new Point3D(x2, y2));
				this.DrawLineUsingModelCoordinates(new Point3D(x2, y), new Point3D(x2, y2));
			}
		}

		// Token: 0x06005C1B RID: 23579 RVA: 0x001723D8 File Offset: 0x001705D8
		public void DrawArrowHead(Point3D from, Point3D to, System.Drawing.Color? fillColor, System.Drawing.Color? strokeColor, float? strokeThickness, double headLength, double headWidth)
		{
			Vector3D vector3D = Vector3D.Subtract(to, from);
			if (vector3D.Length <= 0.0)
			{
				return;
			}
			Vector3D vector3D2 = new Vector3D(-vector3D.Y, vector3D.X, vector3D.Z);
			if (!vector3D2.Normalize())
			{
				return;
			}
			if (!vector3D.Normalize())
			{
				return;
			}
			Point3D a = to - vector3D * headLength;
			Point3D pointB = a - vector3D2 * headWidth;
			Point3D pointC = a + vector3D2 * headWidth;
			this.DrawTriangle(to, pointB, pointC, fillColor, strokeColor, strokeThickness);
		}

		// Token: 0x06005C1C RID: 23580 RVA: 0x00172464 File Offset: 0x00170664
		public void DrawCoordinateOrigin()
		{
			this.Context.PushBlendState();
			this.Context.SetState(blendStateType.Blend);
			this.Context.SetLineSizeExt(this.coordinateOriginLinesThickness);
			this.Context.SetColorWireframe(this.coordinateOriginColor, false);
			this.Context.PushShader();
			this.Context.SetShader(shaderType.NoLights, null, true);
			double z = 0.0;
			Point3D point3D = this.editor.WorldToScreen(new Point3D(-20.0, 0.0, z));
			Point3D point3D2 = this.editor.WorldToScreen(new Point3D(20.0, 0.0, z));
			Point3D point3D3 = this.editor.WorldToScreen(new Point3D(0.0, 0.0, z));
			Point3D point3D4 = this.editor.WorldToScreen(new Point3D(0.0, -20.0, z));
			Point3D point3D5 = this.editor.WorldToScreen(new Point3D(0.0, 20.0, z));
			if (this.editor.IsCameraInDefaultPosition())
			{
				point3D.Z = (point3D2.Z = (point3D3.Z = (point3D4.Z = (point3D5.Z = z))));
			}
			this.Context.DrawLine(point3D3, EyeshotHelper.PointInDirection(point3D, point3D3, this.CoordinateOriginBiggerLinePartLength));
			this.Context.DrawLine(point3D3, EyeshotHelper.PointInDirection(point3D4, point3D3, this.CoordinateOriginBiggerLinePartLength));
			this.Context.DrawLine(point3D3, EyeshotHelper.PointInDirection(point3D2, point3D3, this.CoordinateOriginSmallerLinePartLength));
			this.Context.DrawLine(point3D3, EyeshotHelper.PointInDirection(point3D5, point3D3, this.CoordinateOriginSmallerLinePartLength));
			Point3D point3D6 = EyeshotHelper.PointInDirection(point3D4, point3D3, this.CoordinateOriginBiggerLinePartLength);
			Point3D point3D7 = EyeshotHelper.PointInDirection(point3D, point3D3, this.CoordinateOriginBiggerLinePartLength);
			Font textFont = this.editor.IsHardwareAccelerated ? this.coordinateOriginFont : this.coordinateOriginSafeFont;
			this.editor.DrawTextExt((int)point3D6.X + 2, (int)point3D6.Y + 25, #Phc.#3hc(107427359), textFont, this.coordinateOriginColor, System.Drawing.Color.Transparent, ContentAlignment.TopLeft, false);
			this.editor.DrawTextExt((int)point3D7.X, (int)point3D7.Y, #Phc.#3hc(107380695), textFont, this.coordinateOriginColor, System.Drawing.Color.Transparent, ContentAlignment.BottomLeft, false);
			this.Context.PopShader();
			this.Context.PopBlendState();
		}

		// Token: 0x06005C1D RID: 23581 RVA: 0x001726F8 File Offset: 0x001708F8
		internal static Point3D GetTopLeftCorner(Point3D textPosition, System.Drawing.Size textSize, ContentAlignment alignment)
		{
			Point3D point3D = (Point3D)textPosition.Clone();
			if (alignment <= ContentAlignment.MiddleCenter)
			{
				switch (alignment)
				{
				case ContentAlignment.TopLeft:
					return point3D;
				case ContentAlignment.TopCenter:
					point3D.X += -(double)textSize.Width / 2.0;
					return point3D;
				case (ContentAlignment)3:
					break;
				case ContentAlignment.TopRight:
					point3D.X += (double)(-(double)textSize.Width);
					return point3D;
				default:
					if (alignment == ContentAlignment.MiddleLeft)
					{
						point3D.Y += (double)textSize.Height / 2.0;
						return point3D;
					}
					if (alignment == ContentAlignment.MiddleCenter)
					{
						point3D.X += -(double)textSize.Width / 2.0;
						point3D.Y += (double)textSize.Height / 2.0;
						return point3D;
					}
					break;
				}
			}
			else if (alignment <= ContentAlignment.BottomLeft)
			{
				if (alignment == ContentAlignment.MiddleRight)
				{
					point3D.X += -(double)textSize.Width;
					point3D.Y += (double)textSize.Height / 2.0;
					return point3D;
				}
				if (alignment == ContentAlignment.BottomLeft)
				{
					point3D.Y += (double)textSize.Height;
					return point3D;
				}
			}
			else
			{
				if (alignment == ContentAlignment.BottomCenter)
				{
					point3D.X += -(double)textSize.Width / 2.0;
					point3D.Y += (double)textSize.Height;
					return point3D;
				}
				if (alignment == ContentAlignment.BottomRight)
				{
					point3D.X += (double)(-(double)textSize.Width);
					point3D.Y += (double)textSize.Height;
					return point3D;
				}
			}
			throw new NotImplementedException(string.Format(#Phc.#3hc(107421189), alignment, #Phc.#3hc(107421632), #Phc.#3hc(107421611)));
		}

		// Token: 0x06005C1E RID: 23582 RVA: 0x00172908 File Offset: 0x00170B08
		private void DrawBorder(System.Drawing.Color backgroundColor, System.Drawing.Color borderColor, Point3D topLeft, Point3D bottomLeft, Point3D topRight, Point3D bottomRight)
		{
			this.Context.SetLineSizeExt(1f);
			this.Context.SetColorWireframe(backgroundColor, false);
			this.Context.DrawQuad(new RectangleF((float)bottomLeft.X, (float)bottomLeft.Y, (float)(bottomRight.X - bottomLeft.X), (float)(topLeft.Y - bottomLeft.Y)));
			this.Context.SetColorWireframe(borderColor, false);
			this.Context.DrawLine(topLeft, topRight);
			this.Context.DrawLine(topLeft, bottomLeft);
			bottomLeft.X -= 1.0;
			this.Context.DrawLine(bottomLeft, bottomRight);
			this.Context.DrawLine(topRight, bottomRight);
		}

		// Token: 0x06005C1F RID: 23583 RVA: 0x0004CF24 File Offset: 0x0004B124
		private void DrawLineUsingModelCoordinates(Point3D pointA, Point3D pointB)
		{
			pointA = this.editor.WorldToScreen(pointA);
			pointB = this.editor.WorldToScreen(pointB);
			this.Context.DrawLine(pointA, pointB);
		}

		// Token: 0x04002646 RID: 9798
		private readonly EyeshotEditor editor;

		// Token: 0x04002647 RID: 9799
		private readonly Dictionary<string, System.Drawing.Size> measureStringForLabelCache = new Dictionary<string, System.Drawing.Size>();

		// Token: 0x04002648 RID: 9800
		private string lastMeasureFontName;

		// Token: 0x04002649 RID: 9801
		private double lastMeasureFontSize;

		// Token: 0x0400264A RID: 9802
		private readonly double CoordinateOriginBiggerLinePartLength = 30.0;

		// Token: 0x0400264B RID: 9803
		private readonly double CoordinateOriginSmallerLinePartLength = 15.0;

		// Token: 0x0400264C RID: 9804
		private readonly Font coordinateOriginFont;

		// Token: 0x0400264D RID: 9805
		private readonly Font coordinateOriginSafeFont;

		// Token: 0x0400264E RID: 9806
		private readonly float coordinateOriginLinesThickness = 1.2f;

		// Token: 0x0400264F RID: 9807
		private readonly System.Drawing.Color coordinateOriginColor = System.Drawing.Color.Black;
	}
}
