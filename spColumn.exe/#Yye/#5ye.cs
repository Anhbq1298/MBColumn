using System;
using #3Rd;
using #7hc;
using #owe;
using #Qcd;
using #Rwe;
using #wdd;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.GraphicalReport;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #Yye
{
	// Token: 0x020011C7 RID: 4551
	internal sealed class #5ye : #nwe
	{
		// Token: 0x06009979 RID: 39289 RVA: 0x00079E04 File Offset: 0x00078004
		public #5ye(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x0600997A RID: 39290 RVA: 0x00209C64 File Offset: 0x00207E64
		public override void #pEd()
		{
			Option option = base.Options.SectionFigure;
			if (!option.#ISd() || !base.Renderer.#hdd())
			{
				return;
			}
			base.Renderer.#fdd();
			#ldd #ldd = base.Renderer;
			string stringSectionFigure = Localization.StringSectionFigure;
			StyleIdentifier #4cd = StyleIdentifier.Heading2;
			string #Tcd = option.BookmarkName;
			#ldd.#3cd(stringSectionFigure, #4cd, null, #Tcd, null);
			Size size = base.Renderer.#idd(0.7, false);
			#sTd #sTd = new SectionPreviewGenerator(size.Width, size.Height, base.Model.ColorSettings, true).#fp(base.Model);
			if (#sTd == null)
			{
				return;
			}
			BoundingBoxData boundingBoxData = SectionPreviewGenerator.#Gue(base.Model, false);
			if (boundingBoxData == null)
			{
				return;
			}
			string text = #ned.#qp(new float?((float)boundingBoxData.Width), NativeNumberFormat.G, #Phc.#3hc(107381628));
			string text2 = #ned.#qp(new float?((float)boundingBoxData.Height), NativeNumberFormat.G, #Phc.#3hc(107381628));
			string text3 = base.Model.GeneralInfo.UnitStringD;
			string text4 = #yhe.#Qwe(base.Model.Input.Options.SectionType);
			string #Ycd = string.Format(#Phc.#3hc(107351431), new object[]
			{
				text,
				text2,
				text3,
				text4
			});
			string #Zcd = #ned.#qp(new float?(base.Model.BasicProperties.GeomProperties.Rho), NativeNumberFormat.F10_2, #Phc.#3hc(107381628)) + Localization.StringPercentReinf.#z2d();
			double value = 144.0;
			base.Renderer.#Ucd(#sTd, false, 0.87, #Ycd, Localization.StringColumnSection, null, #Zcd, null, new double?(value));
			base.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
		}
	}
}
