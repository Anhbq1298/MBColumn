using System;
using System.Drawing;
using System.Windows.Media.Imaging;
using #3Qb;
using #3Rd;
using #7hc;
using #ezc;
using #Rwe;
using #wdd;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.GraphicalReport;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.Products.Column.Services.API;
using Svg;

namespace #qPb
{
	// Token: 0x020006AB RID: 1707
	internal static class #yPb
	{
		// Token: 0x06003900 RID: 14592 RVA: 0x00110F00 File Offset: 0x0010F100
		public static string #xPb(#lte #Od)
		{
			BoundingBoxData boundingBoxData = SectionPreviewGenerator.#Gue(#Od, false);
			BoundingBoxData boundingBoxData2;
			if (!false)
			{
				boundingBoxData2 = boundingBoxData;
			}
			if (boundingBoxData2 == null)
			{
				return string.Empty;
			}
			string text = #ned.#qp(new float?((float)boundingBoxData2.Width), NativeNumberFormat.G, #Phc.#3hc(107381628));
			string text2 = #ned.#qp(new float?((float)boundingBoxData2.Height), NativeNumberFormat.G, #Phc.#3hc(107381628));
			string text3 = #Od.GeneralInfo.UnitStringD;
			string text4 = #yhe.#Qwe(#Od.Input.Options.SectionType);
			return string.Format(#Phc.#3hc(107351431), new object[]
			{
				text,
				text2,
				text3,
				text4
			});
		}

		// Token: 0x06003901 RID: 14593 RVA: 0x00110FC4 File Offset: 0x0010F1C4
		public static BitmapSource #ul(#lte #Od, ISettingsManager #iw)
		{
			if (#Od == null)
			{
				return null;
			}
			#qRb #qRb = #iw.#ZN();
			#3se #3se = new #3se();
			#qRb.#oRb(#3se);
			SectionPreviewGenerator sectionPreviewGenerator = new SectionPreviewGenerator(1000.0, 1000.0, #3se, 2, false)
			{
				MagnifyCoordinateSystemSign = true
			};
			#sTd #sTd = sectionPreviewGenerator.#fp(#Od);
			SvgDocument svgDocument = #sTd.Document;
			Bitmap #Ic = svgDocument.Draw();
			return #0zc.#Qzc(#Ic);
		}
	}
}
