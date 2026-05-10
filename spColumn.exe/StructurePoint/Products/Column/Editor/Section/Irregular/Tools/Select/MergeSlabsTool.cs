using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using #cMb;
using #LFb;
using #o1d;
using #pXd;
using NetTopologySuite.Geometries;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Core.Selection;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Model.Validation.Section;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select
{
	// Token: 0x02000514 RID: 1300
	internal sealed class MergeSlabsTool : #tNb, #uNb, IChildColumnEditorTool, #2Fb
	{
		// Token: 0x06002F17 RID: 12055 RVA: 0x0002A20D File Offset: 0x0002840D
		public MergeSlabsTool(IExtendedServices services, IEditorService editorService) : base(services)
		{
			this.#a = editorService;
		}

		// Token: 0x17000F7D RID: 3965
		// (get) Token: 0x06002F18 RID: 12056 RVA: 0x0002A21D File Offset: 0x0002841D
		// (set) Token: 0x06002F19 RID: 12057 RVA: 0x000F3174 File Offset: 0x000F1374
		public bool IsEnabled
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					bool flag = false;
					if (this.#b)
					{
						flag = this.#yAb();
					}
					if (!flag && value)
					{
						base.#KMb(Strings.StringSelectReferenceObject, true, true, false);
					}
				}
			}
		}

		// Token: 0x06002F1A RID: 12058 RVA: 0x0002A229 File Offset: 0x00028429
		public override void #1kb()
		{
			base.#1kb();
			base.#JMb();
			base.#vf();
			base.Services.MessageBus.#uV(this);
		}

		// Token: 0x06002F1B RID: 12059 RVA: 0x000F2718 File Offset: 0x000F0918
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			bool result = base.#hzb(#Lg);
			#Lg.Handled = true;
			return result;
		}

		// Token: 0x06002F1C RID: 12060 RVA: 0x000F31C4 File Offset: 0x000F13C4
		private bool #yAb()
		{
			ShapesSelectionManager shapesSelectionManager = base.EditorContext.Selection.Shapes;
			if (shapesSelectionManager.Any)
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#EAb));
				return true;
			}
			return false;
		}

		// Token: 0x06002F1D RID: 12061 RVA: 0x000F320C File Offset: 0x000F140C
		private bool #zAb(IList<Geometry> #AAb, IList<Geometry> #BAb, IList<Geometry> #CAb, List<ShapeModel> #DAb)
		{
			HashSet<Geometry> hashSet = new HashSet<Geometry>();
			for (int i = 0; i < #AAb.Count; i++)
			{
				Geometry geometry = #AAb[i];
				Geometry geometry2 = geometry;
				bool? flag = null;
				for (int j = i + 1; j < #AAb.Count; j++)
				{
					Geometry geometry3 = #AAb[j];
					Geometry geometry4 = geometry3;
					flag = new bool?(flag.GetValueOrDefault());
					ColumnGeometryHelper.#DKe(ref geometry, ref geometry3);
					#AAb.#27c(geometry2, geometry, false);
					#AAb.#27c(geometry4, geometry3, true);
					#BAb.#27c(geometry2, geometry, false);
					#BAb.#27c(geometry4, geometry3, true);
					#CAb.#27c(geometry2, geometry, false);
					#CAb.#27c(geometry4, geometry3, true);
					if (geometry.Intersects(geometry3) || geometry.Touches(geometry3) || geometry.Distance(geometry3) <= ColumnGeometryHelper.#b)
					{
						hashSet.Remove(geometry2);
						hashSet.Remove(geometry4);
						hashSet.Add(geometry);
						hashSet.Add(geometry3);
					}
					geometry2 = geometry;
				}
			}
			List<Geometry> list = #BAb.Intersect(hashSet).ToList<Geometry>();
			List<Geometry> list2 = #CAb.Intersect(hashSet).ToList<Geometry>();
			#BAb.Clear();
			#BAb.#pR(new ICollection<Geometry>[]
			{
				list
			});
			#CAb.Clear();
			#CAb.#pR(new ICollection<Geometry>[]
			{
				list2
			});
			#DAb.AddRange(#AAb.Except(list2).Except(list).Select(new Func<Geometry, ShapeModel>(MergeSlabsTool.<>c.<>9.#C8b)).Where(new Func<ShapeModel, bool>(MergeSlabsTool.<>c.<>9.#D8b)));
			return hashSet.Any<Geometry>();
		}

		// Token: 0x06002F1E RID: 12062 RVA: 0x000F33E4 File Offset: 0x000F15E4
		private void #EAb()
		{
			MergeSlabsTool.#iZb #iZb = new MergeSlabsTool.#iZb();
			#iZb.#a = this;
			#iZb.#d = null;
			#iZb.#e = new List<ShapeModel>();
			try
			{
				this.#FAb();
				ColumnModelHelper.#UW(base.Project);
				#iZb.#b = GeometryConverter.#Uxb(this.#c);
				#iZb.#c = GeometryConverter.#Uxb(this.#d);
				if (!this.#zAb(#iZb.#b.Union(#iZb.#c).ToList<Geometry>(), #iZb.#b, #iZb.#c, #iZb.#e))
				{
					this.#1kb();
					return;
				}
				if (#iZb.#b.Any<Geometry>())
				{
					Geometry geometry = ColumnGeometryHelper.#Tlc(#iZb.#b);
					if (#iZb.#c.Any<Geometry>())
					{
						geometry = ColumnGeometryHelper.#5lc(new #OXd(CancellationToken.None), #iZb.#c, geometry);
					}
					if (geometry != null)
					{
						geometry = GeometrySimplifier.#aLe(geometry);
						#iZb.#d = GeometryConverter.#Wxb(geometry);
					}
				}
				else if (#iZb.#c.Any<Geometry>())
				{
					Geometry #Xxb = ColumnGeometryHelper.#Tlc(#iZb.#c);
					#Xxb = GeometrySimplifier.#aLe(#Xxb);
					IList<ShapeModel> source = GeometryConverter.#Wxb(#Xxb);
					if (!source.All(new Func<ShapeModel, bool>(MergeSlabsTool.<>c.<>9.#E8b)))
					{
						base.Services.DialogService.#qn(base.Services.WindowLocator.#6(), Strings.StringInvalidGeometry.#z2d());
						this.#1kb();
						return;
					}
					#iZb.#d = source;
					#iZb.#d.#I1d(new Action<ShapeModel>(MergeSlabsTool.<>c.<>9.#F8b));
				}
			}
			catch (Exception #ob)
			{
				base.Services.ExceptionHandler.#3Ab(#ob);
				this.#1kb();
				return;
			}
			if (#iZb.#d == null)
			{
				this.#1kb();
				return;
			}
			base.Services.MouseAndKeyboard.#M2c();
			SectionValidationHelper sectionValidationHelper = new SectionValidationHelper(base.Services.DialogService, base.Project);
			if (!sectionValidationHelper.#IH(#iZb.#d, true))
			{
				return;
			}
			this.#a.#0Pb(new Action(#iZb.#K8b));
			base.Renderer.#9f(false, false);
			this.#1kb();
			base.Services.MessageBus.#tV();
		}

		// Token: 0x06002F1F RID: 12063 RVA: 0x000F3678 File Offset: 0x000F1878
		private void #FAb()
		{
			this.#c = base.EditorContext.Selection.Shapes.SelectedObjects.Where(new Func<ShapeModel, bool>(MergeSlabsTool.<>c.<>9.#I8b)).ToList<ShapeModel>();
			this.#d = base.EditorContext.Selection.Shapes.SelectedObjects.Where(new Func<ShapeModel, bool>(MergeSlabsTool.<>c.<>9.#J8b)).ToList<ShapeModel>();
		}

		// Token: 0x040012E8 RID: 4840
		private readonly IEditorService #a;

		// Token: 0x040012E9 RID: 4841
		private bool #b;

		// Token: 0x040012EA RID: 4842
		private List<ShapeModel> #c;

		// Token: 0x040012EB RID: 4843
		private List<ShapeModel> #d;

		// Token: 0x02000516 RID: 1302
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06002F2B RID: 12075 RVA: 0x000F372C File Offset: 0x000F192C
			internal void #K8b()
			{
				this.#a.Project.Model.Shapes.#F7c(this.#b.Union(this.#c).Select(new Func<Geometry, ShapeModel>(MergeSlabsTool.<>c.<>9.#G8b)).Where(new Func<ShapeModel, bool>(MergeSlabsTool.<>c.<>9.#H8b)));
				this.#a.Project.Model.Shapes.AddRange(this.#d);
				this.#a.EditorContext.Selection.Shapes.#sOb();
				this.#a.EditorContext.Selection.Shapes.#HOb(this.#d.Union(this.#e));
				ColumnModelHelper.#VW(this.#a.Project);
				this.#a.EditorContext.SnappingCache.#uP(this.#a.Project);
				IList<ShapeModel> #7p = this.#d;
				Action<ShapeModel> #nd;
				if ((#nd = this.#f) == null)
				{
					#nd = (this.#f = new Action<ShapeModel>(this.#J0h));
				}
				#7p.#I1d(#nd);
			}

			// Token: 0x06002F2C RID: 12076 RVA: 0x0002A2E2 File Offset: 0x000284E2
			internal void #J0h(ShapeModel #9o)
			{
				this.#a.Project.#1Uh(#9o);
			}

			// Token: 0x040012F5 RID: 4853
			public MergeSlabsTool #a;

			// Token: 0x040012F6 RID: 4854
			public List<Geometry> #b;

			// Token: 0x040012F7 RID: 4855
			public List<Geometry> #c;

			// Token: 0x040012F8 RID: 4856
			public IList<ShapeModel> #d;

			// Token: 0x040012F9 RID: 4857
			public List<ShapeModel> #e;

			// Token: 0x040012FA RID: 4858
			public Action<ShapeModel> #f;
		}
	}
}
