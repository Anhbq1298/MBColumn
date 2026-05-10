using System;
using System.Drawing;
using #7hc;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x02000852 RID: 2130
	internal static class RendererConstants
	{
		// Token: 0x04001E89 RID: 7817
		public static readonly double ShapesLayersSpan = 0.0001;

		// Token: 0x04001E8A RID: 7818
		public static readonly double ReinforcementLayerShift = 0.001;

		// Token: 0x04001E8B RID: 7819
		public static readonly double CoverLayerShift = 0.001;

		// Token: 0x04001E8C RID: 7820
		public static readonly string DefaultFontName = #Phc.#3hc(107399885);

		// Token: 0x04001E8D RID: 7821
		public static Color SelectedBarColor = Color.FromArgb(255, 0, 176, 80);

		// Token: 0x04001E8E RID: 7822
		public static readonly Color ToolHighlightColor = Color.FromArgb(255, 0, 0, 128);

		// Token: 0x04001E8F RID: 7823
		public static readonly Color ToolIdleColor = Color.FromArgb(255, 128, 128, 128);

		// Token: 0x04001E90 RID: 7824
		public static readonly Color AddSlabBorderColor = Color.FromArgb(255, 46, 170, 51);

		// Token: 0x04001E91 RID: 7825
		public static readonly Color AddColumnBorderColor = Color.FromArgb(255, 46, 170, 51);

		// Token: 0x04001E92 RID: 7826
		public static readonly Color AddPileBorderColor = Color.FromArgb(255, 46, 170, 51);

		// Token: 0x04001E93 RID: 7827
		public static readonly Color AddSlabFillColor = Color.FromArgb(150, 247, 247, 247);

		// Token: 0x04001E94 RID: 7828
		public static readonly Color AddColumnFillColor = Color.FromArgb(150, 247, 247, 247);

		// Token: 0x04001E95 RID: 7829
		public static readonly Color AddPileFillColor = Color.FromArgb(150, 247, 247, 247);

		// Token: 0x04001E96 RID: 7830
		public static readonly Color HoveredSlabBorderColor = Color.FromArgb(255, 171, 206, 130);

		// Token: 0x04001E97 RID: 7831
		public static readonly Color HoveredNodeColor = Color.FromArgb(255, 171, 206, 130);

		// Token: 0x04001E98 RID: 7832
		public static readonly Color HoveredColumnBorderColor = Color.FromArgb(255, 171, 206, 130);

		// Token: 0x04001E99 RID: 7833
		public static readonly Color HoveredPileBorderColor = Color.FromArgb(255, 171, 206, 130);

		// Token: 0x04001E9A RID: 7834
		public static readonly float AddSlabBorderThickness = 1.5f;

		// Token: 0x04001E9B RID: 7835
		public static readonly float AddColumnBorderThickness = 1.5f;

		// Token: 0x04001E9C RID: 7836
		public static readonly float AddPileBorderThickness = 1.5f;

		// Token: 0x04001E9D RID: 7837
		public static readonly float MoveSlabBorderThickness = 1f;

		// Token: 0x04001E9E RID: 7838
		public static readonly float MoveColumnBorderThickness = 1f;

		// Token: 0x04001E9F RID: 7839
		public static readonly float MovePileBorderThickness = 1f;

		// Token: 0x04001EA0 RID: 7840
		public static readonly Color MoveSlabBorderColor = Color.Black;

		// Token: 0x04001EA1 RID: 7841
		public static readonly Color MoveColumnBorderColor = Color.Black;

		// Token: 0x04001EA2 RID: 7842
		public static readonly Color MovePileBorderColor = Color.Black;

		// Token: 0x04001EA3 RID: 7843
		public static readonly Color ValidSlabBorderColor = Color.FromArgb(255, 46, 170, 51);

		// Token: 0x04001EA4 RID: 7844
		public static readonly Color InvalidSlabBorderColor = Color.FromArgb(255, 255, 0, 0);

		// Token: 0x04001EA5 RID: 7845
		public static readonly float HoveredNodeSize = 7f;

		// Token: 0x04001EA6 RID: 7846
		public static readonly Color ObjectHandleFillColor = Color.White;

		// Token: 0x04001EA7 RID: 7847
		public static readonly Color ObjectHandleBorderColor = Color.FromArgb(255, 46, 170, 51);

		// Token: 0x04001EA8 RID: 7848
		public static readonly Color SelectedObjectHandleColor = Color.FromArgb(255, 46, 170, 51);

		// Token: 0x04001EA9 RID: 7849
		public static readonly Color SelectionBoxBorderColor = Color.FromArgb(255, 68, 68, 68);

		// Token: 0x04001EAA RID: 7850
		public static readonly Color SelectionBoxFillColor = Color.FromArgb(127, 247, 247, 247);

		// Token: 0x04001EAB RID: 7851
		public static readonly float SelectionBoxBorderThickness = 1f;

		// Token: 0x04001EAC RID: 7852
		public static readonly Color AddGridLineColor = Color.Green;

		// Token: 0x04001EAD RID: 7853
		public static readonly float AddGridLineThickness = 2f;

		// Token: 0x04001EAE RID: 7854
		public static readonly Color AlignNodesLineColor = Color.Green;

		// Token: 0x04001EAF RID: 7855
		public static readonly float AlignNodesLineThickness = 2f;

		// Token: 0x04001EB0 RID: 7856
		public static readonly Color NodesBorderColor = Color.Black;

		// Token: 0x04001EB1 RID: 7857
		public static readonly Color NodesSelectionColor = Color.FromArgb(255, 170, 205, 130);

		// Token: 0x04001EB2 RID: 7858
		public static readonly Color SplitSlabsLineColor = Color.FromArgb(255, 68, 68, 68);

		// Token: 0x04001EB3 RID: 7859
		public static readonly float ContoursLegendTitleFontSize = 10f;

		// Token: 0x04001EB4 RID: 7860
		public static readonly float ContoursLegendItemFontSize = 10f;

		// Token: 0x04001EB5 RID: 7861
		public static readonly Color ContoursLegendTextColor = Color.Black;

		// Token: 0x04001EB6 RID: 7862
		public static readonly Color ContoursElementOutlineColor = Color.FromArgb(255, 192, 192, 192);

		// Token: 0x04001EB7 RID: 7863
		public static readonly Color ContoursColor = Color.FromArgb(90, Color.Black);

		// Token: 0x04001EB8 RID: 7864
		public static readonly Color CursorTextBoxBorderColor = Color.FromArgb(153, Color.Black);

		// Token: 0x04001EB9 RID: 7865
		public static readonly Color CursorTextBoxBackgroundColor = Color.FromArgb(153, 255, 255, 255);

		// Token: 0x04001EBA RID: 7866
		public static readonly Color MeshLineColor = Color.FromArgb(255, 170, 170, 170);

		// Token: 0x04001EBB RID: 7867
		public static readonly float LineWeightOne = 1f;

		// Token: 0x04001EBC RID: 7868
		public static readonly Color SnapPointsColor = Color.FromArgb(255, 0, 155, 7);

		// Token: 0x04001EBD RID: 7869
		public static readonly Color BarsHighlightColor = Color.FromArgb(255, 0, 176, 80);

		// Token: 0x04001EBE RID: 7870
		public static readonly float BarPointSize = 3f;

		// Token: 0x04001EBF RID: 7871
		public static readonly Color SelectedSolidColor = Color.FromArgb(255, 192, 186, 167);

		// Token: 0x04001EC0 RID: 7872
		public static readonly Color SelectedOpeningColor = Color.FromArgb(255, 84, 142, 213);
	}
}
