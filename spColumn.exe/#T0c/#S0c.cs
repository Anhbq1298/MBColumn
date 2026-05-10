using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #T0c
{
	// Token: 0x02000CA1 RID: 3233
	internal interface #S0c
	{
		// Token: 0x060068CF RID: 26831
		void #ZXc(VisibilityLayer #0Xc, IMultilineDrawingResult #YQc, IEnumerable<GridLineDefinitionModel> #atc);

		// Token: 0x060068D0 RID: 26832
		void #ZXc(VisibilityLayer #0Xc, IMultilineDrawingResult #1Xc, IMultilineDrawingResult #2Xc, IEnumerable<GridLineDefinitionModel> #atc);

		// Token: 0x060068D1 RID: 26833
		void #3Xc(VisibilityLayer #0Xc, IMultilineDrawingResult #YQc, HashSet<GridLineDefinitionModel> #4Xc);

		// Token: 0x060068D2 RID: 26834
		void #5Xc(VisibilityLayer #0Xc, IMultilineDrawingResult #6Xc, IPointsDrawingResult #7Xc, IEnumerable<LinearObject> #iEc);

		// Token: 0x060068D3 RID: 26835
		void #8Xc(VisibilityLayer #0Xc, IDashedMultilineDrawingResult #6Xc, IEnumerable<LinearObject> #iEc);

		// Token: 0x060068D4 RID: 26836
		void #9Xc(VisibilityLayer #0Xc, IMultilineDrawingResult #YQc, HashSet<LinearObject> #aYc);

		// Token: 0x060068D5 RID: 26837
		void #bYc(VisibilityLayer #0Xc, IPointsDrawingResult #YQc, IList<NodeModel> #cYc);

		// Token: 0x060068D6 RID: 26838
		void #dEc(VisibilityLayer #0Xc, IPointsDrawingResult #YQc);

		// Token: 0x060068D7 RID: 26839
		void #dYc(VisibilityLayer #0Xc, IPointsDrawingResult #YQc, IList<NodeModel> #cYc);

		// Token: 0x060068D8 RID: 26840
		void #eYc(VisibilityLayer #0Xc, IPointsDrawingResult #YQc, HashSet<Point> #fYc);

		// Token: 0x060068D9 RID: 26841
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
		PolygonsDrawingData #gYc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc);

		// Token: 0x060068DA RID: 26842
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
		PolygonsDrawingData #mYc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc);

		// Token: 0x060068DB RID: 26843
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z")]
		PolygonsDrawingData #nYc(ShapeDataModel #XDc, double #hYc, double #iYc, double #jYc, Color? #kYc, Color? #lYc);

		// Token: 0x060068DC RID: 26844
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		void #oYc(IEnumerable<Tuple<Point3D, Point3D>> #pYc, bool #JS, IMultilineDrawingResult #YQc, VisibilityLayer #0Xc);

		// Token: 0x060068DD RID: 26845
		Tuple<Point3D, Point3D> #sYc(GridLineDefinitionModel #qoc, bool #JS, VisibilityLayer #0Xc, double #PJc, HashSet<IAnnotationDrawingResult> #tYc, HashSet<IAnnotationDrawingResult> #uYc);

		// Token: 0x060068DE RID: 26846
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		void #oYc(IEnumerable<Tuple<Point3D, Point3D>> #pYc, IEnumerable<Tuple<Point3D, Point3D>> #qYc, bool #JS, IMultilineDrawingResult #YQc, IMultilineDrawingResult #rYc, VisibilityLayer #0Xc);
	}
}
