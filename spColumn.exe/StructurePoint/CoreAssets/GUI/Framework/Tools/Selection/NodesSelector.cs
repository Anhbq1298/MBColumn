using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #8Cc;
using #Fmc;
using #hLc;
using #NWc;
using #T0c;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Selection
{
	// Token: 0x02000BCB RID: 3019
	public sealed class NodesSelector : #OLc, IEntitiesSelector, #BLc
	{
		// Token: 0x060062A7 RID: 25255 RVA: 0x0005071E File Offset: 0x0004E91E
		public NodesSelector(#oW projectContext, #V0c modelEditorViewModel, #Qrc snappingProvider, #bDc undoManager, #GLc entitiesSelectorSettings) : base(projectContext, modelEditorViewModel, snappingProvider, entitiesSelectorSettings)
		{
			this.UndoManager = undoManager;
		}

		// Token: 0x17001BF2 RID: 7154
		// (get) Token: 0x060062A8 RID: 25256 RVA: 0x00050733 File Offset: 0x0004E933
		// (set) Token: 0x060062A9 RID: 25257 RVA: 0x0005073B File Offset: 0x0004E93B
		public #bDc UndoManager { get; private set; }

		// Token: 0x060062AA RID: 25258 RVA: 0x00050744 File Offset: 0x0004E944
		public override void #rLc(IEnumerable<object> #8f)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			IEnumerable<NodeModel> #6W = #8f.Cast<NodeModel>();
			if (!false)
			{
				#V0c.#b0c(#6W);
			}
		}

		// Token: 0x060062AB RID: 25259 RVA: 0x0005075E File Offset: 0x0004E95E
		public override void #rLc(object #Rf)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			NodeModel #uXb = (NodeModel)#Rf;
			if (!false)
			{
				#V0c.#a0c(#uXb);
			}
		}

		// Token: 0x060062AC RID: 25260 RVA: 0x00050778 File Offset: 0x0004E978
		public override IReadOnlyList<object> #qLc()
		{
			return base.ProjectContext.MainModel.Nodes.Union(NodeModel.#PXc(this.#QLc(), this.UndoManager, null)).ToList<NodeModel>().AsReadOnly();
		}

		// Token: 0x060062AD RID: 25261 RVA: 0x000507AB File Offset: 0x0004E9AB
		public override bool #sLc(object #Rf)
		{
			return #Rf != null && #Rf is NodeModel;
		}

		// Token: 0x060062AE RID: 25262 RVA: 0x00181308 File Offset: 0x0017F508
		public override IReadOnlyList<object> #wLc(bool #xLc, Point3D? #Xrb, Point3D #Yrb)
		{
			NodesSelector.#s0b #s0b = new NodesSelector.#s0b();
			NodesSelector.#s0b #s0b2;
			if (6 != 0)
			{
				#s0b2 = #s0b;
			}
			List<Point> list = new List<Point>();
			List<Point> list2;
			if (4 != 0)
			{
				list2 = list;
			}
			#s0b2.#a = base.#LLc(#xLc, #Xrb, #Yrb);
			IList<Point> list3 = this.#QLc();
			IList<Point> list4;
			if (4 != 0)
			{
				list4 = list3;
			}
			do
			{
				if (#s0b2.#a != null)
				{
					List<Point> list5 = list2;
					IEnumerable<Point> collection = this.#PLc().Where(new Func<Point, bool>(#s0b2.#w9c));
					if (!false)
					{
						list5.AddRange(collection);
					}
					List<Point> list6 = list2;
					IEnumerable<Point> collection2 = list4.Where(new Func<Point, bool>(#s0b2.#x9c));
					if (!false)
					{
						list6.AddRange(collection2);
					}
				}
				else
				{
					IList<Point> list7 = this.#RLc(#Yrb, list4);
					IList<Point> source;
					if (6 != 0)
					{
						source = list7;
					}
					list2.AddRange(source.ToArray<Point>());
				}
			}
			while (2 == 0);
			return NodeModel.#PXc(list2, this.UndoManager, null).ToList<NodeModel>().AsReadOnly();
		}

		// Token: 0x060062AF RID: 25263 RVA: 0x000507BB File Offset: 0x0004E9BB
		public override void #uR(IEnumerable<object> #8f)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			IEnumerable<NodeModel> #6W = #8f.Cast<NodeModel>();
			if (!false)
			{
				#V0c.#c0c(#6W);
			}
		}

		// Token: 0x060062B0 RID: 25264 RVA: 0x000507D5 File Offset: 0x0004E9D5
		public override void #ljb(object #Rf)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			NodeModel #uXb = (NodeModel)#Rf;
			if (!false)
			{
				#V0c.#9Zc(#uXb);
			}
		}

		// Token: 0x060062B1 RID: 25265 RVA: 0x000507EF File Offset: 0x0004E9EF
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		public IList<Point> #PLc()
		{
			return base.ProjectContext.MainModel.Nodes.Select(new Func<NodeModel, Point>(NodesSelector.<>c.<>9.#B9c)).ToList<Point>();
		}

		// Token: 0x060062B2 RID: 25266 RVA: 0x001813DC File Offset: 0x0017F5DC
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		public IList<Point> #QLc()
		{
			return base.ProjectContext.MainModel.Shapes.SelectMany(new Func<ShapeDataModel, IEnumerable<Point>>(NodesSelector.<>c.<>9.#C9c)).Union(base.ProjectContext.MainModel.LinearObjects.SelectMany(new Func<LinearObject, IEnumerable<Point>>(NodesSelector.<>c.<>9.#E9c))).Distinct<Point>().ToList<Point>();
		}

		// Token: 0x060062B3 RID: 25267 RVA: 0x00181460 File Offset: 0x0017F660
		private IList<Point> #RLc(Point3D #Yrb, IList<Point> #SLc)
		{
			Point3D? point3D = base.SnappingProvider.#Lrc(#Yrb, base.SnappingProvider.MaxDistance);
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			List<Point> list = new List<Point>();
			List<Point> list2;
			if (4 != 0)
			{
				list2 = list;
			}
			if (point3D2 != null)
			{
				NodesSelector.#61b #61b = new NodesSelector.#61b();
				NodesSelector.#61b #61b2;
				if (4 != 0)
				{
					#61b2 = #61b;
				}
				#61b2.#a = PointsConverter.#vsc(point3D2.Value);
				List<Point> list3 = list2;
				IEnumerable<Point> collection = base.ProjectContext.MainModel.Nodes.Where(new Func<NodeModel, bool>(#61b2.#G9c)).Select(new Func<NodeModel, Point>(NodesSelector.<>c.<>9.#F9c));
				if (!false)
				{
					list3.AddRange(collection);
				}
				if (!list2.Any<Point>())
				{
					List<Point> list4 = list2;
					IEnumerable<Point> collection2 = #SLc.Where(new Func<Point, bool>(#61b2.#H9c));
					if (4 != 0)
					{
						list4.AddRange(collection2);
					}
				}
			}
			return list2;
		}

		// Token: 0x04002884 RID: 10372
		[CompilerGenerated]
		private #bDc #a;

		// Token: 0x02000BCD RID: 3021
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x060062BC RID: 25276 RVA: 0x0005088C File Offset: 0x0004EA8C
			internal bool #G9c(NodeModel #Rf)
			{
				return PointsConverter.#uC(#Rf.Location, this.#a);
			}

			// Token: 0x060062BD RID: 25277 RVA: 0x0005089F File Offset: 0x0004EA9F
			internal bool #H9c(Point #Rf)
			{
				return PointsConverter.#uC(#Rf, this.#a);
			}

			// Token: 0x0400288B RID: 10379
			public Point #a;
		}

		// Token: 0x02000BCE RID: 3022
		[CompilerGenerated]
		private sealed class #s0b
		{
			// Token: 0x060062BF RID: 25279 RVA: 0x000508AD File Offset: 0x0004EAAD
			internal bool #w9c(Point #Rf)
			{
				return this.#a.BoundingBoxData.#Zvc(#Rf);
			}

			// Token: 0x060062C0 RID: 25280 RVA: 0x000508AD File Offset: 0x0004EAAD
			internal bool #x9c(Point #Rf)
			{
				return this.#a.BoundingBoxData.#Zvc(#Rf);
			}

			// Token: 0x0400288C RID: 10380
			public PolygonData #a;
		}
	}
}
