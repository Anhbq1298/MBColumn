using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using #7hc;
using #u3d;
using #UYd;
using #wsb;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.Products.Column.FailureSurface.Model;

namespace StructurePoint.Products.Column.FailureSurface.Core.Helpers
{
	// Token: 0x0200047A RID: 1146
	internal static class CoordinateSystemHelper
	{
		// Token: 0x06002A63 RID: 10851 RVA: 0x000E23DC File Offset: 0x000E05DC
		public static void #xsb(FailureSurface #Jkb, IModelEditorControl #Smb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.FailureSurfaceVisualization, #Phc.#3hc(107358722));
			#X0d.#V0d(#Smb, #Phc.#3hc(107359181), Component.FailureSurfaceVisualization, #Phc.#3hc(107359188));
			List<Point3D> list = new List<Point3D>();
			CoordinateSystemHelper.#Esb(#Jkb, list);
			CoordinateSystemHelper.#Dsb(#Jkb, #Smb, #Jkb.DrawingResultsFactory, list);
			IList<#vsb> list2 = new List<#vsb>();
			if ((#Jkb.NominalSurface.IsNotEmpty && #Jkb.NominalPositions.Any<Point3D>()) || (#Jkb.FactoredSurface.IsNotEmpty && #Jkb.FactoredPositions.Any<Point3D>()))
			{
				CoordinateSystemHelper.#Isb(list2, #Jkb);
				CoordinateSystemHelper.#Lsb(list2, #Jkb);
				CoordinateSystemHelper.#Nsb(list2, #Jkb);
			}
			CoordinateSystemHelper.#Bsb(#Jkb, #Smb, #Jkb.DrawingResultsFactory, list2);
		}

		// Token: 0x06002A64 RID: 10852 RVA: 0x000E24B8 File Offset: 0x000E06B8
		public static void #ysb(FailureSurface #Jkb, IModelEditorControl #Smb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.FailureSurfaceVisualization, #Phc.#3hc(107359135));
			#X0d.#V0d(#Smb, #Phc.#3hc(107359181), Component.FailureSurfaceVisualization, #Phc.#3hc(107359050));
			CoordinateSystemHelper.#Asb(#Jkb, #Smb);
		}

		// Token: 0x06002A65 RID: 10853 RVA: 0x000E2510 File Offset: 0x000E0710
		internal static Point3D #zsb(FailureSurface #Jkb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.FailureSurfaceVisualization, #Phc.#3hc(107359029));
			return new Point3D((0.0 - #Jkb.TranslateVector.X) * #Jkb.ScaleVector.X, (0.0 - #Jkb.TranslateVector.Y) * #Jkb.ScaleVector.Y, (0.0 - #Jkb.TranslateVector.Z) * #Jkb.ScaleVector.Z);
		}

		// Token: 0x06002A66 RID: 10854 RVA: 0x000E25D4 File Offset: 0x000E07D4
		private static void #Asb(FailureSurface #Jkb, IModelEditorControl #Smb)
		{
			foreach (ITextDrawingResult drawingResult in #Jkb.AxesTexts)
			{
				#Smb.RemoveFromView(drawingResult);
			}
			foreach (IMultilineDrawingResult drawingResult2 in #Jkb.AxisLines)
			{
				#Smb.RemoveFromView(drawingResult2);
			}
			if (#Jkb.BoundingBoxDrawingResult != null)
			{
				#Smb.RemoveFromView(#Jkb.BoundingBoxDrawingResult);
			}
		}

		// Token: 0x06002A67 RID: 10855 RVA: 0x000E268C File Offset: 0x000E088C
		private static void #Bsb(FailureSurface #Jkb, IModelEditorControl #Smb, IDrawingResultsFactory #Tmb, IList<#vsb> #Csb)
		{
			foreach (ITextDrawingResult drawingResult in #Jkb.AxesTexts)
			{
				#Smb.RemoveFromView(drawingResult);
			}
			#Jkb.AxesTexts.Clear();
			foreach (IMultilineDrawingResult drawingResult2 in #Jkb.AxisLines)
			{
				#Smb.RemoveFromView(drawingResult2);
			}
			#Jkb.AxisLines.Clear();
			if (!#Csb.Any<#vsb>())
			{
				return;
			}
			foreach (#vsb #vsb in #Csb)
			{
				IMultilineDrawingResult multilineDrawingResult = #Tmb.CreateMultilineDrawingResult();
				multilineDrawingResult.Positions = new Point3D[]
				{
					#vsb.StartPosition,
					#vsb.EndPosition
				};
				multilineDrawingResult.LineColor = #Jkb.SettingsManager.CoordinateSystemColor;
				multilineDrawingResult.LineThickness = #vsb.LineThickness;
				#Jkb.AxisLines.Add(multilineDrawingResult);
				#Smb.AddToView(multilineDrawingResult);
				ITextDrawingResult textDrawingResult = #Tmb.CreateTextDrawingResult();
				textDrawingResult.Text = #vsb.Text;
				textDrawingResult.Position = #vsb.TextPosition;
				textDrawingResult.TextColor = #vsb.TextColor;
				textDrawingResult.FontSize = #vsb.FontSize;
				textDrawingResult.UpDirection = #vsb.UpDirection;
				textDrawingResult.TextDirection = #vsb.TextDirection;
				#Jkb.AxesTexts.Add(textDrawingResult);
				#Smb.AddToView(textDrawingResult);
			}
		}

		// Token: 0x06002A68 RID: 10856 RVA: 0x000E2868 File Offset: 0x000E0A68
		private static void #Dsb(FailureSurface #Jkb, IModelEditorControl #Smb, IDrawingResultsFactory #Tmb, IList<Point3D> #BP)
		{
			if (#Jkb.BoundingBoxDrawingResult != null)
			{
				#Smb.RemoveFromView(#Jkb.BoundingBoxDrawingResult);
				#Jkb.BoundingBoxDrawingResult = null;
			}
			IMultilineDrawingResult multilineDrawingResult = #Tmb.CreateMultilineDrawingResult();
			multilineDrawingResult.Positions = #BP;
			multilineDrawingResult.LineThickness = #Jkb.SettingsManager.BoundingBoxLineThickness;
			multilineDrawingResult.LineColor = #Jkb.SettingsManager.CoordinateSystemColor;
			#Jkb.BoundingBoxDrawingResult = multilineDrawingResult;
			#Smb.AddToView(multilineDrawingResult);
		}

		// Token: 0x06002A69 RID: 10857 RVA: 0x000267F3 File Offset: 0x000249F3
		private static void #Esb(FailureSurface #Jkb, List<Point3D> #En)
		{
			CoordinateSystemHelper.#Fsb(#Jkb, #En);
			CoordinateSystemHelper.#Gsb(#Jkb, #En);
			CoordinateSystemHelper.#Hsb(#Jkb, #En);
		}

		// Token: 0x06002A6A RID: 10858 RVA: 0x000E28DC File Offset: 0x000E0ADC
		private static void #Fsb(FailureSurface #Jkb, List<Point3D> #BP)
		{
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
		}

		// Token: 0x06002A6B RID: 10859 RVA: 0x000E2A48 File Offset: 0x000E0C48
		private static void #Gsb(FailureSurface #Jkb, List<Point3D> #BP)
		{
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(-(double)#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
		}

		// Token: 0x06002A6C RID: 10860 RVA: 0x000E2BB0 File Offset: 0x000E0DB0
		private static void #Hsb(FailureSurface #Jkb, List<Point3D> #BP)
		{
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(-(double)#Jkb.SizeZ / 2)));
			#BP.Add(new Point3D((double)(-(double)#Jkb.SizeX / 2), (double)(#Jkb.SizeY / 2), (double)(#Jkb.SizeZ / 2)));
		}

		// Token: 0x06002A6D RID: 10861 RVA: 0x000E2D14 File Offset: 0x000E0F14
		private static void #Isb(IList<#vsb> #En, FailureSurface #Jkb)
		{
			double #Ksb = 0.0;
			CoordinateSystemHelper.#Jsb(#En, #Jkb, #Ksb);
			double num;
			if (!#Jkb.NominalSurface.IsNotEmpty)
			{
				num = #Jkb.FactoredPositions.Max(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#a7b));
			}
			else
			{
				num = #Jkb.NominalPositions.Max(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#96b));
			}
			double #Ksb2 = num;
			CoordinateSystemHelper.#Jsb(#En, #Jkb, #Ksb2);
			double num2;
			if (!#Jkb.NominalSurface.IsNotEmpty)
			{
				num2 = #Jkb.FactoredPositions.Min(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#c7b));
			}
			else
			{
				num2 = #Jkb.NominalPositions.Min(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#b7b));
			}
			double #Ksb3 = num2;
			CoordinateSystemHelper.#Jsb(#En, #Jkb, #Ksb3);
		}

		// Token: 0x06002A6E RID: 10862 RVA: 0x000E2E2C File Offset: 0x000E102C
		private static void #Jsb(IList<#vsb> #En, FailureSurface #Jkb, double #Ksb)
		{
			int #Ssb = CoordinateSystemHelper.#Psb(#Ksb);
			long num = CoordinateSystemHelper.#Rsb(#Ksb, #Ssb);
			double x = ((double)num - #Jkb.TranslateVector.X) * #Jkb.ScaleVector.X;
			#En.Add(new #vsb
			{
				StartPosition = new Point3D(x, -25.0, -50.0),
				EndPosition = new Point3D(x, -25.0, -52.0),
				LineThickness = 1.0,
				Text = num.ToString(CoordinateSystemHelper.#a, CultureInfo.CurrentCulture),
				TextPosition = new Point3D(x, -25.0, -53.0),
				TextColor = #Jkb.SettingsManager.CoordinateSystemColor,
				FontSize = #Jkb.SettingsManager.AxisValueTextFontSize,
				UpDirection = new #c4d(0.0, 0.0, 1.0),
				TextDirection = new #c4d(1.0, 0.0, 0.0)
			});
		}

		// Token: 0x06002A6F RID: 10863 RVA: 0x000E2F80 File Offset: 0x000E1180
		private static void #Lsb(IList<#vsb> #En, FailureSurface #Jkb)
		{
			double #Ksb = 0.0;
			CoordinateSystemHelper.#Msb(#En, #Jkb, #Ksb);
			double num;
			if (!#Jkb.NominalSurface.IsNotEmpty)
			{
				num = #Jkb.FactoredPositions.Max(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#e7b));
			}
			else
			{
				num = #Jkb.NominalPositions.Max(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#d7b));
			}
			double #Ksb2 = num;
			CoordinateSystemHelper.#Msb(#En, #Jkb, #Ksb2);
			double num2;
			if (!#Jkb.NominalSurface.IsNotEmpty)
			{
				num2 = #Jkb.FactoredPositions.Min(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#g7b));
			}
			else
			{
				num2 = #Jkb.NominalPositions.Min(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#f7b));
			}
			double #Ksb3 = num2;
			CoordinateSystemHelper.#Msb(#En, #Jkb, #Ksb3);
		}

		// Token: 0x06002A70 RID: 10864 RVA: 0x000E3098 File Offset: 0x000E1298
		private static void #Msb(IList<#vsb> #En, FailureSurface #Jkb, double #Ksb)
		{
			int #Ssb = CoordinateSystemHelper.#Psb(#Ksb);
			long num = CoordinateSystemHelper.#Rsb(#Ksb, #Ssb);
			double y = ((double)num - #Jkb.TranslateVector.Y) * #Jkb.ScaleVector.Y;
			#En.Add(new #vsb
			{
				StartPosition = new Point3D(25.0, y, -50.0),
				EndPosition = new Point3D(25.0, y, -52.0),
				LineThickness = 1.0,
				Text = num.ToString(CoordinateSystemHelper.#a, CultureInfo.CurrentCulture),
				TextPosition = new Point3D(25.0, y, -53.0),
				TextColor = #Jkb.SettingsManager.CoordinateSystemColor,
				FontSize = #Jkb.SettingsManager.AxisValueTextFontSize,
				UpDirection = new #c4d(0.0, 0.0, 1.0),
				TextDirection = new #c4d(0.0, 1.0, 0.0)
			});
		}

		// Token: 0x06002A71 RID: 10865 RVA: 0x000E31EC File Offset: 0x000E13EC
		private static void #Nsb(IList<#vsb> #En, FailureSurface #Jkb)
		{
			double #Ksb = 0.0;
			CoordinateSystemHelper.#Osb(#En, #Jkb, #Ksb);
			double num;
			if (!#Jkb.NominalSurface.IsNotEmpty)
			{
				num = #Jkb.FactoredPositions.Max(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#i7b));
			}
			else
			{
				num = #Jkb.NominalPositions.Max(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#h7b));
			}
			double #Ksb2 = num;
			CoordinateSystemHelper.#Osb(#En, #Jkb, #Ksb2);
			double num2;
			if (!#Jkb.NominalSurface.IsNotEmpty)
			{
				num2 = #Jkb.FactoredPositions.Min(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#k7b));
			}
			else
			{
				num2 = #Jkb.NominalPositions.Min(new Func<Point3D, double>(CoordinateSystemHelper.<>c.<>9.#j7b));
			}
			double #Ksb3 = num2;
			CoordinateSystemHelper.#Osb(#En, #Jkb, #Ksb3);
		}

		// Token: 0x06002A72 RID: 10866 RVA: 0x000E3304 File Offset: 0x000E1504
		private static void #Osb(IList<#vsb> #En, FailureSurface #Jkb, double #Ksb)
		{
			int #Ssb = CoordinateSystemHelper.#Psb(#Ksb);
			long num = CoordinateSystemHelper.#Rsb(#Ksb, #Ssb);
			double z = ((double)num - #Jkb.TranslateVector.Z) * #Jkb.ScaleVector.Z;
			#En.Add(new #vsb
			{
				StartPosition = new Point3D(-25.0, -25.0, z),
				EndPosition = new Point3D(-27.0, -25.0, z),
				LineThickness = 1.0,
				Text = num.ToString(CoordinateSystemHelper.#a, CultureInfo.CurrentCulture),
				TextPosition = new Point3D(-32.0, -25.0, z),
				TextColor = #Jkb.SettingsManager.CoordinateSystemColor,
				FontSize = #Jkb.SettingsManager.AxisValueTextFontSize,
				UpDirection = new #c4d(0.0, 0.0, 1.0),
				TextDirection = new #c4d(1.0, 0.0, 0.0)
			});
		}

		// Token: 0x06002A73 RID: 10867 RVA: 0x00026816 File Offset: 0x00024A16
		private static int #Psb(double #Qsb)
		{
			if (#Qsb == 0.0)
			{
				return 1;
			}
			return (int)Math.Floor(Math.Log10(Math.Abs(#Qsb)) + 1.0);
		}

		// Token: 0x06002A74 RID: 10868 RVA: 0x000E3458 File Offset: 0x000E1658
		private static long #Rsb(double #Qsb, int #Ssb)
		{
			if (#Qsb >= 0.0)
			{
				return (long)(Math.Floor(#Qsb / Math.Pow(10.0, (double)(#Ssb - 1))) * Math.Pow(10.0, (double)(#Ssb - 1)));
			}
			return (long)(Math.Ceiling(#Qsb / Math.Pow(10.0, (double)(#Ssb - 1))) * Math.Pow(10.0, (double)(#Ssb - 1)));
		}

		// Token: 0x040010F1 RID: 4337
		private static readonly string #a = #Phc.#3hc(107408848);
	}
}
