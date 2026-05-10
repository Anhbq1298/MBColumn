using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #RJb;
using StructurePoint.CoreAssets.GUI.Framework.UndoRedo;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace #aAb
{
	// Token: 0x02000520 RID: 1312
	internal static class #RAb
	{
		// Token: 0x06002F5A RID: 12122 RVA: 0x000F4858 File Offset: 0x000F2A58
		public static void #OAb(#cLb #FR, List<ShapeModel> #pAb, List<ReinforcementBar> #oAb, Point #qAb)
		{
			#RAb.#GTb #GTb = new #RAb.#GTb();
			#GTb.#a = #FR;
			#GTb.#b = #pAb;
			#GTb.#c = #qAb;
			#GTb.#d = #oAb;
			UndoAction.#uRb(#GTb.#a.UndoManager, new Action(#GTb.#R8b));
		}

		// Token: 0x06002F5B RID: 12123 RVA: 0x000F48B0 File Offset: 0x000F2AB0
		private static void #PAb(#cLb #FR, List<ReinforcementBar> #6W, Point #qAb)
		{
			ColumnModel columnModel = #FR.ProjectContext.Model;
			HashSet<ReinforcementBar> hashSet = new HashSet<ReinforcementBar>();
			foreach (ReinforcementBar reinforcementBar in #6W)
			{
				Point point = new Point(reinforcementBar.Location.X + #qAb.X, reinforcementBar.Location.Y + #qAb.Y);
				ReinforcementBar reinforcementBar2 = ColumnModelHelper.#3W(columnModel, point);
				if (reinforcementBar2 == null || #6W.Contains(reinforcementBar2))
				{
					reinforcementBar.Location = point;
					hashSet.Add(reinforcementBar);
				}
				else
				{
					columnModel.ReinforcementBars.Remove(reinforcementBar2);
					reinforcementBar.Location = reinforcementBar2.Location;
					hashSet.Add(reinforcementBar);
				}
			}
			#FR.Selection.Bars.#sOb();
			#FR.Selection.Bars.#HOb(hashSet);
		}

		// Token: 0x06002F5C RID: 12124 RVA: 0x0002A450 File Offset: 0x00028650
		private static void #QAb(#cLb #FR, List<ShapeModel> #eAb, Point #qAb)
		{
			ColumnShapesHelper.#wHb(#FR, #eAb, #qAb);
		}

		// Token: 0x02000521 RID: 1313
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06002F5E RID: 12126 RVA: 0x000F49D0 File Offset: 0x000F2BD0
			internal void #R8b()
			{
				#RAb.#QAb(this.#a, this.#b, this.#c);
				#RAb.#PAb(this.#a, this.#d, this.#c);
				this.#a.Selection.#dPb();
				this.#a.Selection.State.#cg();
				this.#a.Selection.Bars.#tOb();
				this.#a.Selection.Shapes.#tOb();
			}

			// Token: 0x04001316 RID: 4886
			public #cLb #a;

			// Token: 0x04001317 RID: 4887
			public List<ShapeModel> #b;

			// Token: 0x04001318 RID: 4888
			public Point #c;

			// Token: 0x04001319 RID: 4889
			public List<ReinforcementBar> #d;
		}
	}
}
