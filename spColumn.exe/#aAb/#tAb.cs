using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #eU;
using #RJb;
using StructurePoint.CoreAssets.GUI.Framework.UndoRedo;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace #aAb
{
	// Token: 0x0200050C RID: 1292
	internal static class #tAb
	{
		// Token: 0x06002EF9 RID: 12025 RVA: 0x000F2900 File Offset: 0x000F0B00
		public static void #mAb(#9V #nAb, #cLb #FR, List<ReinforcementBar> #oAb, List<ShapeModel> #pAb, Point #qAb)
		{
			#tAb.#GTb #GTb = new #tAb.#GTb();
			#GTb.#a = #FR;
			#GTb.#b = #pAb;
			#GTb.#c = #qAb;
			#GTb.#d = #oAb;
			#GTb.#e = #nAb;
			#GTb.#f = ColumnModelHelper.#cX(#GTb.#e.#Pb(#GTb.#a.ProjectContext.Model));
			UndoAction.#uRb(#GTb.#a.UndoManager, new Func<bool>(#GTb.#A8b));
		}

		// Token: 0x06002EFA RID: 12026 RVA: 0x000F2988 File Offset: 0x000F0B88
		private static void #rAb(#cLb #FR, List<ReinforcementBar> #6W, Point #qAb)
		{
			ColumnModel columnModel = #FR.ProjectContext.Model;
			List<ReinforcementBar> list = new List<ReinforcementBar>();
			foreach (ReinforcementBar reinforcementBar in #6W)
			{
				ReinforcementBar reinforcementBar2 = reinforcementBar.#EA();
				Point point = new Point(reinforcementBar2.Location.X + #qAb.X, reinforcementBar2.Location.Y + #qAb.Y);
				reinforcementBar2.Location = point;
				list.Add(reinforcementBar2);
				ReinforcementBar reinforcementBar3 = ColumnModelHelper.#3W(columnModel, point);
				if (reinforcementBar3 != null && !#6W.Contains(reinforcementBar3))
				{
					columnModel.ReinforcementBars.Remove(reinforcementBar3);
				}
				columnModel.ReinforcementBars.Add(reinforcementBar2);
			}
			#FR.Selection.Bars.#tOb();
			#FR.Selection.Bars.#kCb(list);
		}

		// Token: 0x06002EFB RID: 12027 RVA: 0x000F2AAC File Offset: 0x000F0CAC
		private static void #sAb(#cLb #FR, List<ShapeModel> #eAb, Point #qAb)
		{
			List<ShapeModel> list = new List<ShapeModel>();
			ColumnModel columnModel = #FR.ProjectContext.Model;
			foreach (ShapeModel shapeModel in #eAb)
			{
				ShapeModel shapeModel2 = shapeModel.#EA();
				#FR.ProjectContext.Model.Shapes.Add(shapeModel2);
				#FR.ProjectContext.#1Uh(shapeModel2);
				list.Add(shapeModel2);
			}
			ColumnShapesHelper.#wHb(#FR, list, #qAb);
			#FR.Selection.Shapes.#tOb();
			#FR.Selection.Shapes.#kCb(list);
		}

		// Token: 0x0200050D RID: 1293
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06002EFD RID: 12029 RVA: 0x000F2B80 File Offset: 0x000F0D80
			internal bool #A8b()
			{
				#tAb.#sAb(this.#a, this.#b, this.#c);
				#tAb.#rAb(this.#a, this.#d, this.#c);
				this.#a.Selection.#dPb();
				this.#a.Selection.State.#cg();
				string b = ColumnModelHelper.#cX(this.#e.#Pb(this.#a.ProjectContext.Model));
				return !string.Equals(this.#f, b, StringComparison.Ordinal);
			}

			// Token: 0x040012D8 RID: 4824
			public #cLb #a;

			// Token: 0x040012D9 RID: 4825
			public List<ShapeModel> #b;

			// Token: 0x040012DA RID: 4826
			public Point #c;

			// Token: 0x040012DB RID: 4827
			public List<ReinforcementBar> #d;

			// Token: 0x040012DC RID: 4828
			public #9V #e;

			// Token: 0x040012DD RID: 4829
			public string #f;
		}
	}
}
