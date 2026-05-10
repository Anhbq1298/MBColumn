using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #8Cc;
using #eU;
using #Fmc;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.Framework.UndoRedo;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace #aAb
{
	// Token: 0x02000528 RID: 1320
	internal sealed class #VAb
	{
		// Token: 0x06002F8E RID: 12174 RVA: 0x0002A5C9 File Offset: 0x000287C9
		public #VAb(#oW #xn, #bDc #DJ)
		{
			if (#xn == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404877));
			}
			this.#a = #xn;
			if (#DJ == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404911));
			}
			this.#b = #DJ;
		}

		// Token: 0x06002F8F RID: 12175 RVA: 0x000F5820 File Offset: 0x000F3A20
		public #9zb #UAb(IList<StructurePoint.Products.Column.Model.Entities.ReinforcementBar> #6W, IList<ShapeModel> #6Y, devDept.Geometry.Point3D #Akb, devDept.Geometry.Point3D #Bkb)
		{
			#VAb.#dZb #dZb = new #VAb.#dZb();
			#dZb.#b = this;
			#dZb.#d = new #9zb();
			if (!#6W.Any<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>() && !#6Y.Any<ShapeModel>())
			{
				return null;
			}
			#dZb.#a = new Dictionary<StructurePoint.Products.Column.Model.Entities.ReinforcementBar, StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			foreach (StructurePoint.Products.Column.Model.Entities.ReinforcementBar reinforcementBar in #6W)
			{
				if (!#jsc.#vlc(#Akb.#QW(), #Bkb.#QW(), reinforcementBar.Location, true))
				{
					StructurePoint.CoreAssets.Infrastructure.Data.Point? point = #jsc.#fsc(#Akb.#QW(), #Bkb.#QW(), reinforcementBar.Location);
					if (point == null)
					{
						return #dZb.#d;
					}
					#dZb.#a.Add(reinforcementBar, point.Value);
				}
			}
			#dZb.#c = new Dictionary<ShapeModel, StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			foreach (ShapeModel shapeModel in #6Y)
			{
				if (shapeModel.PolygonsCount > 0)
				{
					SectionPolygon item = shapeModel.#CY();
					devDept.Geometry.Point3D point3D = SectionGeometryHelper.#gxc(new List<SectionPolygon>
					{
						item
					}, new List<SectionPolygon>());
					if (!(point3D == null))
					{
						StructurePoint.CoreAssets.Infrastructure.Data.Point? point2 = #jsc.#fsc(#Akb.#QW(), #Bkb.#QW(), point3D.#QW());
						if (point2 != null)
						{
							Vector vector = StructurePoint.CoreAssets.Infrastructure.Data.Point.#H3d(point2.Value, point3D.#QW());
							#dZb.#c[shapeModel] = vector.#b4d();
						}
					}
				}
			}
			if (!#dZb.#a.Any<KeyValuePair<StructurePoint.Products.Column.Model.Entities.ReinforcementBar, StructurePoint.CoreAssets.Infrastructure.Data.Point>>() && !#dZb.#c.Any<KeyValuePair<ShapeModel, StructurePoint.CoreAssets.Infrastructure.Data.Point>>())
			{
				#dZb.#d.NothingToAlign = true;
				return #dZb.#d;
			}
			UndoAction.#uRb(this.#b, new Action(#dZb.#S8b));
			return #dZb.#d;
		}

		// Token: 0x0400132E RID: 4910
		private readonly #oW #a;

		// Token: 0x0400132F RID: 4911
		private readonly #bDc #b;

		// Token: 0x02000529 RID: 1321
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x06002F91 RID: 12177 RVA: 0x000F5A28 File Offset: 0x000F3C28
			internal void #S8b()
			{
				foreach (KeyValuePair<StructurePoint.Products.Column.Model.Entities.ReinforcementBar, StructurePoint.CoreAssets.Infrastructure.Data.Point> keyValuePair in this.#a)
				{
					keyValuePair.Key.Location = keyValuePair.Value;
				}
				#5Ab #5Ab = new #5Ab(this.#b.#a);
				#5Ab.#3Ab(this.#a.Keys.ToList<StructurePoint.Products.Column.Model.Entities.ReinforcementBar>());
				foreach (KeyValuePair<ShapeModel, StructurePoint.CoreAssets.Infrastructure.Data.Point> keyValuePair2 in this.#c)
				{
					ColumnShapesHelper.#vHb(this.#b.#a, keyValuePair2.Value, keyValuePair2.Key);
				}
				this.#d.Success = true;
			}

			// Token: 0x04001330 RID: 4912
			public Dictionary<StructurePoint.Products.Column.Model.Entities.ReinforcementBar, StructurePoint.CoreAssets.Infrastructure.Data.Point> #a;

			// Token: 0x04001331 RID: 4913
			public #VAb #b;

			// Token: 0x04001332 RID: 4914
			public Dictionary<ShapeModel, StructurePoint.CoreAssets.Infrastructure.Data.Point> #c;

			// Token: 0x04001333 RID: 4915
			public #9zb #d;
		}
	}
}
