using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #aHb;
using #cMb;
using #hR;
using #LFb;
using #RJb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select.Core
{
	// Token: 0x02000551 RID: 1361
	internal sealed class MoveVertexToolImpl : #tNb, #uNb, IMultiToolChild
	{
		// Token: 0x06003076 RID: 12406 RVA: 0x0002B08E File Offset: 0x0002928E
		public MoveVertexToolImpl(IExtendedServices services, #3Fb moveModelTool, IEditorService editorService) : base(services)
		{
			this.#h = moveModelTool;
			this.#i = editorService;
		}

		// Token: 0x17000FB3 RID: 4019
		// (get) Token: 0x06003077 RID: 12407 RVA: 0x0002B0BB File Offset: 0x000292BB
		public bool IsWorking
		{
			get
			{
				return this.#c > MoveVertexToolImpl.#s6b.#a;
			}
		}

		// Token: 0x06003078 RID: 12408 RVA: 0x000F87FC File Offset: 0x000F69FC
		public void #XBb()
		{
			this.#a.Clear();
			this.#b.Clear();
			if (this.#1Bb())
			{
				this.#a.AddRange(this.#e.Points2D.OrderBy(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, double>(MoveVertexToolImpl.<>c.<>9.#d9b)).ThenBy(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, double>(MoveVertexToolImpl.<>c.<>9.#e9b)));
				this.#a.#31d<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
				this.#b.AddRange(this.#e.Points2D.Select(new Func<StructurePoint.CoreAssets.Infrastructure.Data.Point, devDept.Geometry.Point3D>(MoveVertexToolImpl.<>c.<>9.#f9b)));
			}
		}

		// Token: 0x06003079 RID: 12409 RVA: 0x000F88EC File Offset: 0x000F6AEC
		public override void #1kb()
		{
			bool flag = this.IsWorking;
			this.#d = -1;
			this.#c = MoveVertexToolImpl.#s6b.#a;
			this.#f = null;
			this.#g = null;
			if (flag)
			{
				base.Services.Renderer.#cg();
			}
			base.#JMb();
			base.#1kb();
		}

		// Token: 0x0600307A RID: 12410 RVA: 0x000F8948 File Offset: 0x000F6B48
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (this.#hzb(args) || !base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			if (!this.#1Bb())
			{
				return;
			}
			this.#XBb();
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D? point3D = SnappingProviderHelper.#Uqc(this.#a, new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(planePosition.X, planePosition.Y), base.EditorContext.Snapping.#NLb());
			if (point3D != null)
			{
				planePosition = new devDept.Geometry.Point3D(point3D.Value.X, point3D.Value.Y);
				this.#d = this.#b.IndexOf(planePosition);
				if (this.#d >= 0)
				{
					this.#f = planePosition;
					this.#c = MoveVertexToolImpl.#s6b.#b;
					base.#SMb(Strings.StringSpecifyTranslation, true, true, true);
					base.Editor.DynamicInput.Config.LastInputPoint = planePosition;
					return;
				}
			}
			else
			{
				this.#1kb();
			}
		}

		// Token: 0x0600307B RID: 12411 RVA: 0x000F8A58 File Offset: 0x000F6C58
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			if (!base.#WMb(false))
			{
				return;
			}
			if (this.#c == MoveVertexToolImpl.#s6b.#a)
			{
				StructurePoint.CoreAssets.Infrastructure.Data.Point3D? point3D = SnappingProviderHelper.#Uqc(this.#a, new StructurePoint.CoreAssets.Infrastructure.Data.Point3D(planePosition.X, planePosition.Y), base.EditorContext.Snapping.#NLb());
				this.#g = ((point3D != null) ? new devDept.Geometry.Point3D(point3D.Value.X, point3D.Value.Y) : null);
				planePosition = (this.#g ?? planePosition);
			}
			else
			{
				planePosition = base.#bNb(#LLb.#n, planePosition);
				this.#g = planePosition;
			}
			if (base.#Dzb(planePosition, this.#f, base.EditorContext.Snapping.#NLb()))
			{
				this.#c = MoveVertexToolImpl.#s6b.#c;
			}
			if (this.#c == MoveVertexToolImpl.#s6b.#c)
			{
				base.Viewports.#vf();
			}
		}

		// Token: 0x0600307C RID: 12412 RVA: 0x000F8B60 File Offset: 0x000F6D60
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			devDept.Geometry.Point3D #2Mb = base.#bNb(#LLb.#h, planePosition);
			if (base.#Dzb(#2Mb, this.#f, base.EditorContext.Snapping.#NLb()))
			{
				this.#fzb(planePosition, false);
				return;
			}
			base.#SMb(Strings.StringSpecifyTranslation, true, false, true);
			base.Editor.DynamicInput.Config.LastInputPoint = planePosition;
			if (base.Editor.DynamicInput.OpenInputDirectly(new devDept.Geometry.Point3D()) != DynamicInputResultState.Commited)
			{
				this.#1kb();
			}
			base.#JMb();
		}

		// Token: 0x0600307D RID: 12413 RVA: 0x000F8C34 File Offset: 0x000F6E34
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (!this.#1Bb())
			{
				return;
			}
			List<devDept.Geometry.Point3D> list = this.#0Bb(this.#g);
			base.#lNb(list, #KT.#E, 7f);
			base.#lNb(list, #KT.#D, 5f);
			if (this.#c != MoveVertexToolImpl.#s6b.#a)
			{
				base.#cNb(#LLb.#n, planePosition);
				List<devDept.Geometry.Point3D> list2;
				#qHb #GHb = this.#IH(this.#g, out list2) ? #qHb.#d : #qHb.#e;
				ColumnShapesHelper.#IHb(list, base.EditorContext, #GHb, PolygonApplication.Solid);
			}
			else
			{
				base.#gNb(this.#g, #KT.#F, 5f, null);
			}
			if (this.#c == MoveVertexToolImpl.#s6b.#c)
			{
				base.#8Mb(this.#f, this.#g);
			}
		}

		// Token: 0x0600307E RID: 12414 RVA: 0x000F8D14 File Offset: 0x000F6F14
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			MoveVertexToolImpl.#i9b #i9b = new MoveVertexToolImpl.#i9b();
			#i9b.#a = this;
			bool result = base.#fzb(#Ng, #gzb);
			if (this.#c == MoveVertexToolImpl.#s6b.#c)
			{
				if (!this.#IH(#Ng, out #i9b.#b))
				{
					return false;
				}
				this.#i.#0Pb(new Func<bool>(#i9b.#h9b));
				this.#1kb();
			}
			return result;
		}

		// Token: 0x0600307F RID: 12415 RVA: 0x0002B0CA File Offset: 0x000292CA
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			this.#c = MoveVertexToolImpl.#s6b.#c;
			this.#g = args.Point;
			this.#fzb(this.#g, true);
			args.Handled = true;
		}

		// Token: 0x06003080 RID: 12416 RVA: 0x000F8D7C File Offset: 0x000F6F7C
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			if (this.#c != MoveVertexToolImpl.#s6b.#a)
			{
				devDept.Geometry.Point3D #jzb = base.Editor.DynamicInput.Config.LastInputPoint + (args.FinalPoint ?? new devDept.Geometry.Point3D());
				List<devDept.Geometry.Point3D> #BP = this.#0Bb(#jzb);
				bool flag = ColumnModelHelper.#9W(#BP);
				this.#g = #jzb;
				if (!flag)
				{
					args.ErrorMessage = Strings.StringInvalidGeometry;
					base.Renderer.#cg();
				}
			}
		}

		// Token: 0x06003081 RID: 12417 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06003082 RID: 12418 RVA: 0x0002B107 File Offset: 0x00029307
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			if (!false)
			{
				base.HandleDynamicInputCoordinateChange(args);
			}
			if (this.#c != MoveVertexToolImpl.#s6b.#a)
			{
				this.#g = args.Point;
				base.Viewports.#vf();
			}
		}

		// Token: 0x06003083 RID: 12419 RVA: 0x0002A154 File Offset: 0x00028354
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			#Lg.Handled = base.#hzb(#Lg);
			return #Lg.Handled;
		}

		// Token: 0x06003084 RID: 12420 RVA: 0x000F8E00 File Offset: 0x000F7000
		private bool #IH(devDept.Geometry.Point3D #YBb, out List<devDept.Geometry.Point3D> #ZBb)
		{
			#ZBb = null;
			#ZBb = this.#0Bb(#YBb);
			if (!ColumnModelHelper.#9W(#ZBb))
			{
				return false;
			}
			if (this.#c != MoveVertexToolImpl.#s6b.#a && #YBb != null)
			{
				List<devDept.Geometry.Point3D> list = this.#b.ToList<devDept.Geometry.Point3D>();
				HashSet<int> hashSet = new HashSet<int>
				{
					this.#d
				};
				if (this.#d == 0)
				{
					hashSet.Add(list.Count - 1);
				}
				if (this.#d == list.Count - 1)
				{
					hashSet.Add(0);
				}
				for (int i = 1; i < list.Count; i++)
				{
					if (!hashSet.Contains(i) && !hashSet.Contains(i - 1) && EyeshotGeometry.DoesLieOnSegment(list[i], list[i - 1], #YBb, true))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06003085 RID: 12421 RVA: 0x000F8EE8 File Offset: 0x000F70E8
		private List<devDept.Geometry.Point3D> #0Bb(devDept.Geometry.Point3D #jzb)
		{
			List<devDept.Geometry.Point3D> list = this.#b.ToList<devDept.Geometry.Point3D>();
			if (this.#c != MoveVertexToolImpl.#s6b.#a && #jzb != null)
			{
				list[this.#d] = #jzb;
				if (this.#d == 0)
				{
					list[list.Count - 1] = #jzb;
				}
				if (this.#d == this.#b.Count - 1)
				{
					list[0] = #jzb;
				}
			}
			return list;
		}

		// Token: 0x06003086 RID: 12422 RVA: 0x000F8F60 File Offset: 0x000F7160
		private bool #1Bb()
		{
			if (base.EditorContext == null)
			{
				return false;
			}
			bool flag = this.#h.IsEnabled;
			if (base.EditorContext.Selection.State.Slabs.OnlySelected && base.EditorContext.Selection.Shapes.NoOfSelectedObjects == 1 && !flag)
			{
				ShapeModel shapeModel = base.EditorContext.Selection.Shapes.SelectedObjects.FirstOrDefault<ShapeModel>();
				if (shapeModel != null && shapeModel.FigureType != PolygonFigureType.Circle)
				{
					this.#e = shapeModel.#cxc(0);
					if (this.#e != null)
					{
						return true;
					}
				}
			}
			this.#e = null;
			if (this.#c != MoveVertexToolImpl.#s6b.#a)
			{
				this.#1kb();
			}
			return false;
		}

		// Token: 0x040013A4 RID: 5028
		private readonly List<StructurePoint.CoreAssets.Infrastructure.Data.Point> #a = new List<StructurePoint.CoreAssets.Infrastructure.Data.Point>();

		// Token: 0x040013A5 RID: 5029
		private readonly List<devDept.Geometry.Point3D> #b = new List<devDept.Geometry.Point3D>();

		// Token: 0x040013A6 RID: 5030
		private MoveVertexToolImpl.#s6b #c;

		// Token: 0x040013A7 RID: 5031
		private int #d;

		// Token: 0x040013A8 RID: 5032
		private PolygonData #e;

		// Token: 0x040013A9 RID: 5033
		private devDept.Geometry.Point3D #f;

		// Token: 0x040013AA RID: 5034
		private devDept.Geometry.Point3D #g;

		// Token: 0x040013AB RID: 5035
		private readonly #3Fb #h;

		// Token: 0x040013AC RID: 5036
		private readonly IEditorService #i;

		// Token: 0x02000552 RID: 1362
		private enum #s6b
		{
			// Token: 0x040013AE RID: 5038
			#a,
			// Token: 0x040013AF RID: 5039
			#b,
			// Token: 0x040013B0 RID: 5040
			#c
		}

		// Token: 0x02000554 RID: 1364
		[CompilerGenerated]
		private sealed class #i9b
		{
			// Token: 0x0600308E RID: 12430 RVA: 0x000F902C File Offset: 0x000F722C
			internal bool #h9b()
			{
				this.#a.#e.#dwc(this.#b.Select(new Func<devDept.Geometry.Point3D, StructurePoint.CoreAssets.Infrastructure.Data.Point>(MoveVertexToolImpl.<>c.<>9.#g9b)));
				ColumnModelHelper.#VW(this.#a.Project);
				this.#a.Services.SnappingCache.#uP(this.#a.Project);
				this.#a.Renderer.#9f(false, false);
				return true;
			}

			// Token: 0x040013B6 RID: 5046
			public MoveVertexToolImpl #a;

			// Token: 0x040013B7 RID: 5047
			public List<devDept.Geometry.Point3D> #b;
		}
	}
}
