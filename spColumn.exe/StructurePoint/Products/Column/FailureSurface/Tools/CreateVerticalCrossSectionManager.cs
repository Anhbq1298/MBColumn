using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using #Fmc;
using #S9;
using #u3d;
using #Zmb;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.FailureSurface.Core.Helpers;
using StructurePoint.Products.Column.FailureSurface.Model;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.FailureSurface.Tools
{
	// Token: 0x02000438 RID: 1080
	internal sealed class CreateVerticalCrossSectionManager : #1mb
	{
		// Token: 0x0600278C RID: 10124 RVA: 0x00024D3B File Offset: 0x00022F3B
		public CreateVerticalCrossSectionManager(#5mb failureSurfaceToolContext, ISettingsManager settingsManager)
		{
			this.#a = failureSurfaceToolContext;
			this.#b = settingsManager;
		}

		// Token: 0x0600278D RID: 10125 RVA: 0x000D8DA0 File Offset: 0x000D6FA0
		public void #Ikb(double #Alb, #ybb #Blb, Point3D #Clb)
		{
			#c4d #c4d = #Loc.#Goc(#Alb);
			#c4d = #Loc.#soc(#c4d);
			this.#olb(#c4d, #Blb, #Clb);
		}

		// Token: 0x0600278E RID: 10126 RVA: 0x000D8DD0 File Offset: 0x000D6FD0
		private static void #Mkb(FailureSurface #Jkb, IEnumerable<PolyLine3D> #Nkb, List<IMultiPolyLineDrawingResult> #En, Color #BR, double #Okb)
		{
			List<List<Point3D>> list = #Nkb.Where(new Func<PolyLine3D, bool>(CreateVerticalCrossSectionManager.<>c.<>9.#A6b)).Select(new Func<PolyLine3D, List<Point3D>>(CreateVerticalCrossSectionManager.<>c.<>9.#B6b)).ToList<List<Point3D>>();
			if (list.Any<List<Point3D>>())
			{
				IMultiPolyLineDrawingResult multiPolyLineDrawingResult = #Jkb.DrawingResultsFactory.CreateMulitPolyLineDrawingResult();
				multiPolyLineDrawingResult.LineThickness = #Okb;
				multiPolyLineDrawingResult.LineColor = #BR;
				multiPolyLineDrawingResult.Positions = list;
				#En.Add(multiPolyLineDrawingResult);
			}
		}

		// Token: 0x0600278F RID: 10127 RVA: 0x000D8E6C File Offset: 0x000D706C
		private void #olb(#c4d #Dlb, #ybb #Blb, Point3D #Clb)
		{
			this.#a.CommandsManager.RemoveSurfacesFromVisualizationCommand.Execute();
			FailureSurface failureSurface = this.#a.FailureSurfaceContext.FailureSurface;
			failureSurface.NominalCrossSectionSurface.#9ob();
			failureSurface.FactoredCrossSectionSurface.#9ob();
			if (failureSurface.NominalSurface.IsNotEmpty)
			{
				List<PolyLine3D> #Glb = new List<PolyLine3D>();
				this.#Elb(failureSurface, #Dlb, #Blb, #Glb, #Clb);
				this.#Hlb(failureSurface, #Dlb, #Blb, #Glb, #Clb);
			}
			List<PolyLine3D> #Glb2 = new List<PolyLine3D>();
			this.#Ilb(failureSurface, #Dlb, #Blb, #Glb2, #Clb);
			this.#Jlb(failureSurface, #Dlb, #Blb, #Glb2, #Clb);
			this.#a.CommandsManager.ShowCrossSectionCommand.Execute();
		}

		// Token: 0x06002790 RID: 10128 RVA: 0x000D8F30 File Offset: 0x000D7130
		private void #Elb(FailureSurface #Jkb, #c4d #Flb, #ybb #Qkb, List<PolyLine3D> #Glb, Point3D #Clb)
		{
			IList<Point3D> #BP = VerticalFailureSurfaceCrossSectionGenerator.#Ktb(#Jkb);
			IList<int> #Ptb = VerticalFailureSurfaceCrossSectionGenerator.#Ntb(#Jkb, #Qkb, #Flb, #BP, #Clb, #Glb);
			IMeshDrawingResult #f = VerticalFailureSurfaceCrossSectionGenerator.#Otb(#Jkb, #BP, #Ptb, this.#b.FailureSurfaceNominalSurfaceColor);
			#Jkb.NominalCrossSectionSurface.FailureSurface = #f;
		}

		// Token: 0x06002791 RID: 10129 RVA: 0x000D8F80 File Offset: 0x000D7180
		private void #Hlb(FailureSurface #Jkb, #c4d #Flb, #ybb #Qkb, List<PolyLine3D> #Glb, Point3D #Clb)
		{
			IList<Point3D> #BP = VerticalFailureSurfaceCrossSectionGenerator.#Ktb(#Jkb);
			IEnumerable<PolyLine3D> first = VerticalFailureSurfaceCrossSectionGenerator.#Qtb(#Jkb, #Qkb, #Flb, #BP, #Clb);
			IEnumerable<PolyLine3D> second = VerticalFailureSurfaceCrossSectionGenerator.#Rtb(#Jkb, #Qkb, #Flb, #BP, #Clb);
			IEnumerable<PolyLine3D> #Nkb = first.Union(second).Union(#Glb);
			CreateVerticalCrossSectionManager.#Mkb(#Jkb, #Nkb, #Jkb.NominalCrossSectionSurface.Wireframe, this.#b.FailureSurfaceNominalWireframeLineColor, this.#b.FailureSurfaceNominalWireframeLineThickness);
		}

		// Token: 0x06002792 RID: 10130 RVA: 0x000D8FF0 File Offset: 0x000D71F0
		private void #Ilb(FailureSurface #Jkb, #c4d #Flb, #ybb #Qkb, List<PolyLine3D> #Glb, Point3D #Clb)
		{
			List<Point3D> #0tb = new List<Point3D>();
			IList<Point3D> #BP = VerticalFailureSurfaceCrossSectionGenerator.#Mtb(#Jkb, #0tb);
			IList<int> #Ptb = VerticalFailureSurfaceCrossSectionGenerator.#Ntb(#Jkb, #Qkb, #Flb, #BP, #Clb, #Glb);
			IMeshDrawingResult #f = VerticalFailureSurfaceCrossSectionGenerator.#Otb(#Jkb, #BP, #Ptb, this.#b.FailureSurfaceFactoredSurfaceColor);
			#Jkb.FactoredCrossSectionSurface.FailureSurface = #f;
		}

		// Token: 0x06002793 RID: 10131 RVA: 0x000D9048 File Offset: 0x000D7248
		private void #Jlb(FailureSurface #Jkb, #c4d #Flb, #ybb #Qkb, List<PolyLine3D> #Glb, Point3D #Clb)
		{
			List<Point3D> #0tb = new List<Point3D>();
			IList<Point3D> #BP = VerticalFailureSurfaceCrossSectionGenerator.#Mtb(#Jkb, #0tb);
			IEnumerable<PolyLine3D> first = VerticalFailureSurfaceCrossSectionGenerator.#Qtb(#Jkb, #Qkb, #Flb, #BP, #Clb);
			IEnumerable<PolyLine3D> second = VerticalFailureSurfaceCrossSectionGenerator.#Rtb(#Jkb, #Qkb, #Flb, #BP, #Clb);
			IEnumerable<PolyLine3D> #Nkb = first.Union(second).Union(#Glb);
			CreateVerticalCrossSectionManager.#Mkb(#Jkb, #Nkb, #Jkb.FactoredCrossSectionSurface.Wireframe, this.#b.FailureSurfaceFactoredWireframeLineColor, this.#b.FailureSurfaceFactoredWireframeLineThickness);
		}

		// Token: 0x04000F9D RID: 3997
		private readonly #5mb #a;

		// Token: 0x04000F9E RID: 3998
		private readonly ISettingsManager #b;
	}
}
