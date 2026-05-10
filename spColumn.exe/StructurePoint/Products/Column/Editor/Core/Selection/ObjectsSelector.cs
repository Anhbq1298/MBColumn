using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using #eU;
using #gOb;
using #RJb;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using StructurePoint.CoreAssets.Column.Core.Templates.Rendering;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.Editor.Core.Selection
{
	// Token: 0x02000697 RID: 1687
	internal sealed class ObjectsSelector : NotifyPropertyChangedObjectBase
	{
		// Token: 0x0600387F RID: 14463 RVA: 0x00031319 File Offset: 0x0002F519
		public ObjectsSelector(#cLb editorContext)
		{
			this.#a = editorContext;
		}

		// Token: 0x1700116D RID: 4461
		// (get) Token: 0x06003880 RID: 14464 RVA: 0x00031328 File Offset: 0x0002F528
		public #8Jb RenderOptions
		{
			get
			{
				return this.#a.RenderOptions;
			}
		}

		// Token: 0x1700116E RID: 4462
		// (get) Token: 0x06003881 RID: 14465 RVA: 0x0003133D File Offset: 0x0002F53D
		internal bool IncludeReinforcement
		{
			get
			{
				return this.RenderOptions.SelectBars;
			}
		}

		// Token: 0x1700116F RID: 4463
		// (get) Token: 0x06003882 RID: 14466 RVA: 0x00003375 File Offset: 0x00001575
		internal bool IncludeShapes
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17001170 RID: 4464
		// (get) Token: 0x06003883 RID: 14467 RVA: 0x00031356 File Offset: 0x0002F556
		private EyeshotEditor Editor
		{
			get
			{
				return this.#a.Editor;
			}
		}

		// Token: 0x17001171 RID: 4465
		// (get) Token: 0x06003884 RID: 14468 RVA: 0x0003136B File Offset: 0x0002F56B
		internal #oW Project
		{
			get
			{
				return this.#a.ProjectContext;
			}
		}

		// Token: 0x06003885 RID: 14469 RVA: 0x0010F918 File Offset: 0x0010DB18
		public #oOb #FDb()
		{
			#oOb #oOb = new #oOb();
			if (this.IncludeReinforcement)
			{
				#oOb.Bars.AddRange(this.Project.Model.ReinforcementBars);
			}
			if (this.IncludeShapes)
			{
				#oOb.Shapes.AddRange(this.Editor.Entities.Where(new Func<Entity, bool>(ObjectsSelector.<>c.<>9.#Occ)).OfType<Mesh>().Select(new Func<Mesh, ShapeModel>(ObjectsSelector.<>c.<>9.#Pcc)));
			}
			return #oOb;
		}

		// Token: 0x06003886 RID: 14470 RVA: 0x0010F9D8 File Offset: 0x0010DBD8
		public #oOb #TOb(RectangleF #UOb)
		{
			ObjectsSelector.#BUb #BUb = new ObjectsSelector.#BUb();
			#BUb.#a = this;
			#BUb.#b = #UOb;
			#oOb #oOb = new #oOb();
			if (this.IncludeShapes)
			{
				List<Mesh> list = this.Editor.Entities.Where(new Func<Entity, bool>(ObjectsSelector.<>c.<>9.#Qcc)).OfType<Mesh>().ToList<Mesh>();
				foreach (Mesh mesh in list)
				{
					if (this.#WOb(mesh.BoxMin, mesh.BoxMax, #BUb.#b))
					{
						#oOb.Shapes.Add((ShapeModel)mesh.EntityData);
					}
				}
			}
			if (this.IncludeReinforcement)
			{
				List<ReinforcementBar> source = this.Project.Model.ReinforcementBars;
				#oOb.Bars.AddRange(source.Where(new Func<ReinforcementBar, bool>(#BUb.#Vcc)));
			}
			return #oOb;
		}

		// Token: 0x06003887 RID: 14471 RVA: 0x0010FB0C File Offset: 0x0010DD0C
		public #oOb #TOb(devDept.Geometry.Point3D #jzb)
		{
			#oOb #oOb = new #oOb();
			devDept.Geometry.Point3D point3D = #jzb;
			#jzb = this.#bNb(#jzb);
			if (this.IncludeReinforcement)
			{
				ReinforcementBar reinforcementBar = this.#VOb(#jzb);
				if (reinforcementBar != null)
				{
					#oOb.Bars.Add(reinforcementBar);
				}
				else
				{
					foreach (ReinforcementBar reinforcementBar2 in this.Project.Model.ReinforcementBars)
					{
						if ((double)reinforcementBar2.Area > TemplateModelRenderer.MinBarArea)
						{
							double num = CircleHelper.#wmc((double)reinforcementBar2.Area);
							if (#jzb.DistanceTo(reinforcementBar2.Point) <= num || point3D.DistanceTo(reinforcementBar2.Point) <= num)
							{
								#oOb.Bars.Add(reinforcementBar2);
								break;
							}
						}
					}
				}
			}
			if (this.IncludeShapes && !#oOb.#nOb())
			{
				ObjectsSelector.#61b #61b = new ObjectsSelector.#61b();
				IEnumerable<CustomMeshEntity> source = this.Editor.Entities.Where(new Func<Entity, bool>(ObjectsSelector.<>c.<>9.#Rcc)).OfType<CustomMeshEntity>().OrderByDescending(new Func<CustomMeshEntity, double>(ObjectsSelector.<>c.<>9.#Scc));
				#61b.#a = #jzb.#QW();
				source = source.Where(new Func<CustomMeshEntity, bool>(#61b.#Wcc));
				ShapeModel shapeModel = source.Select(new Func<CustomMeshEntity, ShapeModel>(ObjectsSelector.<>c.<>9.#Tcc)).OrderByDescending(new Func<ShapeModel, bool>(ObjectsSelector.<>c.<>9.#Ucc)).FirstOrDefault<ShapeModel>();
				if (shapeModel != null)
				{
					#oOb.Shapes.Add(shapeModel);
				}
			}
			return #oOb;
		}

		// Token: 0x06003888 RID: 14472 RVA: 0x0010FD08 File Offset: 0x0010DF08
		private ReinforcementBar #VOb(devDept.Geometry.Point3D #jzb)
		{
			double maxDistance = this.#a.Snapping.#NLb();
			devDept.Geometry.Point3D #Ng = this.#a.Snapping.PerformSnap(this.#a.SnappingCache.ReinforcementBars, #jzb, maxDistance);
			return ColumnModelHelper.#3W(this.Project.Model, #Ng);
		}

		// Token: 0x06003889 RID: 14473 RVA: 0x0010FD68 File Offset: 0x0010DF68
		private bool #WOb(devDept.Geometry.Point3D #XOb, devDept.Geometry.Point3D #YOb, RectangleF #UOb)
		{
			devDept.Geometry.Point3D point3D = this.Editor.WorldToScreen(#XOb);
			devDept.Geometry.Point3D point3D2 = this.Editor.WorldToScreen(#YOb);
			return #UOb.Contains(new System.Drawing.Point((int)point3D.X, (int)point3D.Y)) && #UOb.Contains(new System.Drawing.Point((int)point3D2.X, (int)point3D2.Y));
		}

		// Token: 0x0600388A RID: 14474 RVA: 0x00031380 File Offset: 0x0002F580
		private bool #WOb(EyeshotBoundingBoxDataLight #ZOb, RectangleF #UOb)
		{
			return this.#WOb(#ZOb.BottomLeft, #ZOb.TopRight, #UOb);
		}

		// Token: 0x0600388B RID: 14475 RVA: 0x000313A1 File Offset: 0x0002F5A1
		private devDept.Geometry.Point3D #bNb(devDept.Geometry.Point3D #jzb)
		{
			SnapToPointResult snapToPointResult = this.#a.Snapping.#fEb(this.#a.RenderOptions, #LLb.#n, #jzb);
			return ((snapToPointResult != null) ? snapToPointResult.Point : null) ?? #jzb;
		}

		// Token: 0x040017AA RID: 6058
		private readonly #cLb #a;

		// Token: 0x02000699 RID: 1689
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06003896 RID: 14486 RVA: 0x00031434 File Offset: 0x0002F634
			internal bool #Vcc(ReinforcementBar #Rf)
			{
				return this.#a.#WOb(#Rf.Point, #Rf.Point, this.#b);
			}

			// Token: 0x040017B3 RID: 6067
			public ObjectsSelector #a;

			// Token: 0x040017B4 RID: 6068
			public RectangleF #b;
		}

		// Token: 0x0200069A RID: 1690
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x06003898 RID: 14488 RVA: 0x0010FDE0 File Offset: 0x0010DFE0
			internal bool #Wcc(CustomMeshEntity #Rf)
			{
				ShapeModel shapeModel = (ShapeModel)#Rf.EntityData;
				return shapeModel.#Lnc(this.#a);
			}

			// Token: 0x040017B5 RID: 6069
			public StructurePoint.CoreAssets.Infrastructure.Data.Point #a;
		}
	}
}
