using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using #S9;
using #wsb;
using #Zmb;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.FailureSurface.Model;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.FailureSurface.Tools
{
	// Token: 0x0200042B RID: 1067
	internal sealed class CreateHorizontalCrossSectionManager : #Ymb
	{
		// Token: 0x060026DD RID: 9949 RVA: 0x000247CA File Offset: 0x000229CA
		public CreateHorizontalCrossSectionManager(ISettingsManager settingsManager)
		{
			this.#a = settingsManager;
		}

		// Token: 0x060026DE RID: 9950 RVA: 0x000247D9 File Offset: 0x000229D9
		public void #Ikb(FailureSurface #Jkb, #xbb #Kkb, double #Lkb)
		{
			if (#Jkb.NominalSurface.IsNotEmpty)
			{
				this.#Pkb(#Jkb, #Lkb, #Kkb);
				this.#Rkb(#Jkb, #Lkb, #Kkb);
			}
			this.#Skb(#Jkb, #Lkb, #Kkb);
			this.#Tkb(#Jkb, #Lkb, #Kkb);
		}

		// Token: 0x060026DF RID: 9951 RVA: 0x000D6EB8 File Offset: 0x000D50B8
		private static void #Mkb(FailureSurface #Jkb, IEnumerable<PolyLine3D> #Nkb, List<IMultiPolyLineDrawingResult> #En, Color #BR, double #Okb)
		{
			List<List<Point3D>> list = #Nkb.Where(new Func<PolyLine3D, bool>(CreateHorizontalCrossSectionManager.<>c.<>9.#q6b)).Select(new Func<PolyLine3D, List<Point3D>>(CreateHorizontalCrossSectionManager.<>c.<>9.#r6b)).ToList<List<Point3D>>();
			if (list.Any<List<Point3D>>())
			{
				IMultiPolyLineDrawingResult multiPolyLineDrawingResult = #Jkb.DrawingResultsFactory.CreateMulitPolyLineDrawingResult();
				multiPolyLineDrawingResult.LineThickness = #Okb;
				multiPolyLineDrawingResult.LineColor = #BR;
				multiPolyLineDrawingResult.Positions = list;
				#En.Add(multiPolyLineDrawingResult);
			}
		}

		// Token: 0x060026E0 RID: 9952 RVA: 0x000D6F54 File Offset: 0x000D5154
		private void #Pkb(FailureSurface #Jkb, double #Lkb, #xbb #Qkb)
		{
			IList<Point3D> #BP = #Ztb.#Ktb(#Jkb);
			IList<int> #Ptb = #Ztb.#Ntb(#Jkb, #Qkb, #Lkb, #BP);
			IMeshDrawingResult #f = #Ztb.#Otb(#Jkb, #BP, #Ptb, this.#a.FailureSurfaceNominalSurfaceColor);
			#Jkb.NominalCrossSectionSurface.FailureSurface = #f;
		}

		// Token: 0x060026E1 RID: 9953 RVA: 0x000D6FA0 File Offset: 0x000D51A0
		private void #Rkb(FailureSurface #Jkb, double #Lkb, #xbb #Qkb)
		{
			IList<Point3D> #BP = #Ztb.#Ktb(#Jkb);
			IList<PolyLine3D> first = #Ztb.#Qtb(#Jkb, #Qkb, #Lkb, #BP);
			IList<PolyLine3D> second = #Ztb.#Rtb(#Jkb, #Qkb, #Lkb, #BP);
			IEnumerable<PolyLine3D> #Nkb = first.Union(second);
			CreateHorizontalCrossSectionManager.#Mkb(#Jkb, #Nkb, #Jkb.NominalCrossSectionSurface.Wireframe, this.#a.FailureSurfaceNominalWireframeLineColor, this.#a.FailureSurfaceNominalWireframeLineThickness);
		}

		// Token: 0x060026E2 RID: 9954 RVA: 0x000D7004 File Offset: 0x000D5204
		private void #Skb(FailureSurface #Jkb, double #Lkb, #xbb #Qkb)
		{
			IList<Point3D> #BP = #Ztb.#Mtb(#Jkb);
			IList<int> #Ptb = #Ztb.#Ntb(#Jkb, #Qkb, #Lkb, #BP);
			IMeshDrawingResult #f = #Ztb.#Otb(#Jkb, #BP, #Ptb, this.#a.FailureSurfaceFactoredSurfaceColor);
			#Jkb.FactoredCrossSectionSurface.FailureSurface = #f;
		}

		// Token: 0x060026E3 RID: 9955 RVA: 0x000D7050 File Offset: 0x000D5250
		private void #Tkb(FailureSurface #Jkb, double #Lkb, #xbb #Qkb)
		{
			IList<Point3D> #BP = #Ztb.#Mtb(#Jkb);
			IList<PolyLine3D> first = #Ztb.#Qtb(#Jkb, #Qkb, #Lkb, #BP);
			IList<PolyLine3D> second = #Ztb.#Rtb(#Jkb, #Qkb, #Lkb, #BP);
			IEnumerable<PolyLine3D> #Nkb = first.Union(second);
			CreateHorizontalCrossSectionManager.#Mkb(#Jkb, #Nkb, #Jkb.FactoredCrossSectionSurface.Wireframe, this.#a.FailureSurfaceFactoredWireframeLineColor, this.#a.FailureSurfaceFactoredWireframeLineThickness);
		}

		// Token: 0x04000F67 RID: 3943
		private readonly ISettingsManager #a;
	}
}
