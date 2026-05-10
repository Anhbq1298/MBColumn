using System;
using System.Linq;
using System.Windows.Media.Media3D;
using #7hc;
using #UYd;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000925 RID: 2341
	[CLSCompliant(false)]
	public static class VisualToScreenHelper
	{
		// Token: 0x06004C53 RID: 19539 RVA: 0x0014C6F8 File Offset: 0x0014A8F8
		public static double? ScaleRadiusToRemainFixedSizeOnscreen(IModelEditorControl modelEditorControl, IDrawingResult drawingResult, StructurePoint.CoreAssets.Infrastructure.Data.Point3D center, double screenRadius)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), Component.FailureSurfaceVisualization, #Phc.#3hc(107470583));
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.FailureSurfaceVisualization, #Phc.#3hc(107470498));
			Matrix3D? visualToScreenMatrix = modelEditorControl.GetVisualToScreenMatrix(drawingResult);
			if (visualToScreenMatrix == null)
			{
				return null;
			}
			Matrix3D value = visualToScreenMatrix.Value;
			Matrix3D matrix = value.Inverse();
			Point4D point4D = (Point4D)center.Convert() * value;
			double w = point4D.W;
			double x = point4D.X;
			double y = point4D.Y;
			double z = point4D.Z;
			Point3DCollection point3DCollection = new Point3DCollection();
			Point4D point4D2 = new Point4D(x + -screenRadius * w, y + -screenRadius * w, z, w) * matrix;
			double num = 1.0 / point4D2.W;
			point3DCollection.Add(new System.Windows.Media.Media3D.Point3D(point4D2.X * num, point4D2.Y * num, point4D2.Z * num));
			point4D2 = new Point4D(x + screenRadius * w, y + -screenRadius * w, z, w) * matrix;
			num = 1.0 / point4D2.W;
			point3DCollection.Add(new System.Windows.Media.Media3D.Point3D(point4D2.X * num, point4D2.Y * num, point4D2.Z * num));
			point4D2 = new Point4D(x + screenRadius * w, y + screenRadius * w, z, w) * matrix;
			num = 1.0 / point4D2.W;
			point3DCollection.Add(new System.Windows.Media.Media3D.Point3D(point4D2.X * num, point4D2.Y * num, point4D2.Z * num));
			point4D2 = new Point4D(x + -screenRadius * w, y + screenRadius * w, z, w) * matrix;
			num = 1.0 / point4D2.W;
			point3DCollection.Add(new System.Windows.Media.Media3D.Point3D(point4D2.X * num, point4D2.Y * num, point4D2.Z * num));
			return new double?(Math.Sqrt(Math.Pow(point3DCollection[0].X - point3DCollection.Average((System.Windows.Media.Media3D.Point3D item) => item.X), 2.0) + Math.Pow(point3DCollection[0].Y - point3DCollection.Average((System.Windows.Media.Media3D.Point3D item) => item.Y), 2.0) + Math.Pow(point3DCollection[0].Z - point3DCollection.Average((System.Windows.Media.Media3D.Point3D item) => item.Z), 2.0)));
		}

		// Token: 0x06004C54 RID: 19540 RVA: 0x0014CA10 File Offset: 0x0014AC10
		public static Matrix3D? GetVisualToScreenMatrix(IDrawingResult drawingResult)
		{
			Visual3D visual3D = drawingResult.RetrieveDisplayedObjects().OfType<Visual3D>().FirstOrDefault<Visual3D>();
			if (visual3D == null || !visual3D.IsAttachedToViewport3D())
			{
				return null;
			}
			Matrix3D viewportTransform = visual3D.GetViewportTransform();
			if (double.IsNaN(viewportTransform.M11) || !viewportTransform.HasInverse)
			{
				return null;
			}
			return new Matrix3D?(viewportTransform);
		}
	}
}
