using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #aAb;
using #ABb;
using #aHb;
using #cMb;
using #gOb;
using #LFb;
using #RJb;
using devDept.Eyeshot;
using devDept.Geometry;
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
	// Token: 0x02000568 RID: 1384
	internal sealed class SelectObjectsToolImpl : BaseToolWithChildren, #uNb, IMultiToolChild
	{
		// Token: 0x06003137 RID: 12599 RVA: 0x000FB840 File Offset: 0x000F9A40
		public SelectObjectsToolImpl(IExtendedServices services, #2Fb mergeSlabsTool, #5Fb splitSlabsTool, #4Fb offsetSlabsTool, #6Fb verticalNodesAlignmentTool, #0Fb horizontalNodesAlignmentTool, #ZFb copyModelTool, #3Fb moveModelTool, #TFb rotateModelTool, #SFb mirrorModelTool, #UFb contextsSelectStateInvalidator, #VFb clipboardService, #1Fb columnLimitsService, IEditorService editorService, #oCb selectionPropertiesViewModel) : base(services)
		{
			this.#a = contextsSelectStateInvalidator;
			base.ChildTools.#pR(new IChildColumnEditorTool[]
			{
				moveModelTool,
				copyModelTool,
				rotateModelTool,
				mirrorModelTool,
				mergeSlabsTool,
				splitSlabsTool,
				offsetSlabsTool,
				verticalNodesAlignmentTool,
				horizontalNodesAlignmentTool
			});
			this.#p = copyModelTool;
			this.#l = clipboardService;
			this.#m = columnLimitsService;
			this.#n = editorService;
			this.#o = selectionPropertiesViewModel;
		}

		// Token: 0x17000FD6 RID: 4054
		// (get) Token: 0x06003138 RID: 12600 RVA: 0x000FB8E0 File Offset: 0x000F9AE0
		public bool IsWorking
		{
			get
			{
				if (this.#b == SelectObjectsToolImpl.#s6b.#a)
				{
					return base.ChildTools.Any(new Func<IChildColumnEditorTool, bool>(SelectObjectsToolImpl.<>c.<>9.#B9b));
				}
				return true;
			}
		}

		// Token: 0x17000FD7 RID: 4055
		// (get) Token: 0x06003139 RID: 12601 RVA: 0x0002BA21 File Offset: 0x00029C21
		protected #ZFb CopyModelTool { get; }

		// Token: 0x0600313A RID: 12602 RVA: 0x000FB930 File Offset: 0x000F9B30
		public override void #1kb()
		{
			base.#1kb();
			if (base.#fMb())
			{
				return;
			}
			SelectObjectsToolImpl.#s6b #s6b = this.#b;
			this.#b = SelectObjectsToolImpl.#s6b.#a;
			base.#JMb();
			if (#s6b == SelectObjectsToolImpl.#s6b.#a)
			{
				if (base.Selection.#sOb())
				{
					this.#DDb();
				}
				base.#fMb();
			}
			base.#vf();
		}

		// Token: 0x0600313B RID: 12603 RVA: 0x000FB990 File Offset: 0x000F9B90
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			if (!base.#WMb(false))
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			base.Services.GuiController.EditorStatusBar.Section.#uP(planePosition);
			if (base.#gMb(data, screenPosition, planePosition))
			{
				return;
			}
			if (this.#b == SelectObjectsToolImpl.#s6b.#c && base.Selection.#aPb() && base.#4Mb(this.#j, planePosition, base.EditorContext.Snapping.#NLb()))
			{
				devDept.Geometry.Point3D #qAb = new devDept.Geometry.Point3D(planePosition.X - this.#h.X, planePosition.Y - this.#h.Y);
				ColumnDisplayHelper.#nHb(base.EditorContext, base.Editor, #qAb);
				base.#8Mb(this.#h, planePosition);
				base.#cNb(#LLb.#n, planePosition);
			}
			else
			{
				if (base.Selection.Shapes.Hovered.Count == 1)
				{
					ShapeModel shapeModel = base.Selection.Shapes.Hovered.Last<ShapeModel>();
					List<devDept.Geometry.Point3D> #AHb = ColumnShapesHelper.#DHb(base.Project, base.Settings, shapeModel, null);
					ColumnShapesHelper.#IHb(#AHb, base.EditorContext, #qHb.#c, shapeModel.Application);
				}
				if (base.Selection.Bars.Hovered.Count == 1)
				{
					List<ReinforcementBar> #KJ = new List<ReinforcementBar>
					{
						base.Selection.Bars.Hovered.Last<ReinforcementBar>()
					};
					ColumnShapesHelper.#HHb(#KJ, base.EditorContext, #qHb.#c, null);
				}
			}
			if (this.#c && this.#b == SelectObjectsToolImpl.#s6b.#b)
			{
				this.#k = #8Ib.#0Ib(this.#d, this.#e, base.Editor, base.Renderer);
			}
		}

		// Token: 0x0600313C RID: 12604 RVA: 0x000FBB68 File Offset: 0x000F9D68
		public override void HandleMouseDown(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			if (base.#iMb(args, screenPosition, planePosition))
			{
				return;
			}
			if (this.#hzb(args) || !base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			planePosition = base.#bNb(#LLb.#n, planePosition);
			this.#f = planePosition;
			this.#CDb();
			if (this.#HDb() && !base.#IMb())
			{
				this.#b = SelectObjectsToolImpl.#s6b.#c;
				this.#j = planePosition;
				this.#h = this.#yDb(planePosition);
				this.#fzb(this.#h, false);
				if (!base.#IMb())
				{
					this.#zDb();
				}
				return;
			}
			this.#b = SelectObjectsToolImpl.#s6b.#b;
			this.#c = true;
			this.#d = screenPosition;
			#8Ib.#0Ib(this.#d, this.#e, base.Editor, base.Renderer);
			if (!base.#IMb())
			{
				base.Selection.#7Ob();
			}
		}

		// Token: 0x0600313D RID: 12605 RVA: 0x000FBC70 File Offset: 0x000F9E70
		public override void HandleMouseMove(MouseEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#e = screenPosition;
			this.#g = new devDept.Geometry.Point3D(planePosition.X, planePosition.Y);
			if (!base.#WMb(false))
			{
				return;
			}
			if (base.#kMb(args, screenPosition, planePosition))
			{
				return;
			}
			planePosition = new devDept.Geometry.Point3D(planePosition.X, planePosition.Y);
			base.Selection.#9Ob();
			if (this.#b == SelectObjectsToolImpl.#s6b.#a)
			{
				#oOb #RBb = base.Selection.Selector.#TOb(planePosition);
				base.Selection.#cPb(#RBb);
				base.Renderer.#cg();
				return;
			}
			if (this.#b == SelectObjectsToolImpl.#s6b.#b && this.#f != null)
			{
				if (base.#IMb())
				{
					base.Selection.#8Ob();
				}
				#oOb #RBb2 = base.Selection.Selector.#TOb(this.#k);
				base.Selection.#cPb(#RBb2);
				base.Renderer.#cg();
				return;
			}
			if (this.#b == SelectObjectsToolImpl.#s6b.#c && base.#4Mb(this.#j, planePosition, base.EditorContext.Snapping.#NLb()))
			{
				this.#j = base.LastInputPoint;
				if (!base.EditorContext.Settings.DynamicInput.Enabled)
				{
					base.Viewports.#vf();
				}
				base.#SMb(Strings.StringSpecifyTranslation, true, true, true);
			}
		}

		// Token: 0x0600313E RID: 12606 RVA: 0x000FBDE8 File Offset: 0x000F9FE8
		public override void HandleMouseUp(MouseButtonEventArgs args, System.Drawing.Point screenPosition, devDept.Geometry.Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (!base.#WMb(true) || args.ChangedButton != System.Windows.Input.MouseButton.Left)
			{
				return;
			}
			if (base.#lMb(args, screenPosition, planePosition))
			{
				return;
			}
			if (this.#b == SelectObjectsToolImpl.#s6b.#b)
			{
				this.#EDb();
			}
			else if (this.#b == SelectObjectsToolImpl.#s6b.#c && base.Selection.#aPb())
			{
				if (base.#4Mb(this.#j, planePosition, base.EditorContext.Snapping.#NLb()))
				{
					planePosition = base.#bNb(#LLb.#n, planePosition);
					this.#i = planePosition;
					this.#iAb();
				}
				else
				{
					base.Renderer.#cg();
				}
				base.#JMb();
			}
			this.#c = false;
			this.#b = SelectObjectsToolImpl.#s6b.#a;
		}

		// Token: 0x0600313F RID: 12607 RVA: 0x000FBEBC File Offset: 0x000FA0BC
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			if (base.#mMb(args))
			{
				return;
			}
			this.#i = args.Point;
			this.#iAb();
			base.#JMb();
			this.#b = SelectObjectsToolImpl.#s6b.#a;
			args.Handled = true;
		}

		// Token: 0x06003140 RID: 12608 RVA: 0x0002BA2D File Offset: 0x00029C2D
		public override void HandleKeyUp(KeyEventArgs args)
		{
			if (base.#nMb(args))
			{
				return;
			}
			base.HandleKeyUp(args);
			if (args.Key == Key.Delete)
			{
				this.#GDb();
			}
		}

		// Token: 0x06003141 RID: 12609 RVA: 0x0002BA5C File Offset: 0x00029C5C
		public override void HandleChangedState()
		{
			base.HandleChangedState();
			this.#b = SelectObjectsToolImpl.#s6b.#a;
			this.#c = false;
		}

		// Token: 0x06003142 RID: 12610 RVA: 0x000FBF0C File Offset: 0x000FA10C
		public override void HandleKeyDown(KeyEventArgs args)
		{
			base.HandleKeyDown(args);
			if (base.#qMb(args))
			{
				return;
			}
			if (base.#IMb() && args.Key == Key.A)
			{
				this.#FDb();
			}
			if (base.#IMb() && args.Key == Key.C)
			{
				this.#wDb();
			}
			if (base.#IMb() && args.Key == Key.V)
			{
				this.#xDb(this.#g);
			}
			if (base.#IMb() && args.Key == Key.X && base.EditorContext.Selection.#jAb())
			{
				this.#wDb();
				this.#vDb();
			}
		}

		// Token: 0x06003143 RID: 12611 RVA: 0x0002BA7E File Offset: 0x00029C7E
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			if (base.#nWh(args))
			{
				return;
			}
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06003144 RID: 12612 RVA: 0x0002BAB4 File Offset: 0x00029CB4
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			if (this.#eMb(args))
			{
				return;
			}
			base.HandleDynamicInputCoordinateChange(args);
			this.#eMb(args);
		}

		// Token: 0x06003145 RID: 12613 RVA: 0x0002BADB File Offset: 0x00029CDB
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			if (base.#jMb(args))
			{
				return;
			}
			base.HandleDynamicInputCoordinateValidation(args);
			base.#jMb(args);
		}

		// Token: 0x06003146 RID: 12614 RVA: 0x0002BB02 File Offset: 0x00029D02
		public override void OnActivated()
		{
			base.OnActivated();
			this.#b = SelectObjectsToolImpl.#s6b.#a;
			this.#JDb();
			this.#IDb();
		}

		// Token: 0x06003147 RID: 12615 RVA: 0x0002BB29 File Offset: 0x00029D29
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#1kb();
			this.#JDb();
		}

		// Token: 0x06003148 RID: 12616 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #XBb()
		{
		}

		// Token: 0x06003149 RID: 12617 RVA: 0x0002BB49 File Offset: 0x00029D49
		protected override bool #hzb(MouseButtonEventArgs #Lg)
		{
			if (#Lg.ChangedButton == System.Windows.Input.MouseButton.Right && this.#b == SelectObjectsToolImpl.#s6b.#a)
			{
				return false;
			}
			#Lg.Handled = base.#hzb(#Lg);
			return #Lg.Handled;
		}

		// Token: 0x0600314A RID: 12618 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #7j(object #Ge, PropertyChangedEventArgs #He)
		{
		}

		// Token: 0x0600314B RID: 12619 RVA: 0x0002BB7D File Offset: 0x00029D7D
		private void #uDb(object #Ge, EventArgs #He)
		{
			this.#DDb();
			base.Services.MessageBus.#MV();
			this.#o.#nCb();
		}

		// Token: 0x0600314C RID: 12620 RVA: 0x000FBFC8 File Offset: 0x000FA1C8
		private void #vDb()
		{
			if (!base.EditorContext.Selection.#jAb())
			{
				return;
			}
			this.#n.#0Pb(new Action(this.#KDb));
			base.Viewports.Renderer.#9f(false, false);
			base.Services.MessageBus.#MV();
		}

		// Token: 0x0600314D RID: 12621 RVA: 0x000FC030 File Offset: 0x000FA230
		private void #wDb()
		{
			bool flag = base.Selection.Shapes.Empty && base.Selection.Bars.Empty;
			if (flag)
			{
				return;
			}
			this.#l.#yl();
			this.#l.#QBb(base.Selection);
		}

		// Token: 0x0600314E RID: 12622 RVA: 0x000FC090 File Offset: 0x000FA290
		private void #xDb(devDept.Geometry.Point3D #dAb)
		{
			if (!this.#l.ContainsAnyItem || #dAb == null)
			{
				return;
			}
			int #1f = this.#l.Nodes.Distinct<ReinforcementBar>().Count<ReinforcementBar>();
			if (!this.#m.#wAb(#1f))
			{
				return;
			}
			devDept.Geometry.Point3D #cAb = this.#l.#SBb();
			this.CopyModelTool.#bAb(#cAb, #dAb, this.#l.Nodes, this.#l.Slabs, true);
		}

		// Token: 0x0600314F RID: 12623 RVA: 0x000FC118 File Offset: 0x000FA318
		private devDept.Geometry.Point3D #yDb(devDept.Geometry.Point3D #jzb)
		{
			ReinforcementBar reinforcementBar = base.Selection.Bars.Hovered.LastOrDefault<ReinforcementBar>();
			ShapeModel shapeModel = base.Selection.Shapes.Hovered.LastOrDefault<ShapeModel>();
			if (reinforcementBar != null)
			{
				return reinforcementBar.Location.#TW();
			}
			if (shapeModel != null)
			{
				return #jzb;
			}
			return null;
		}

		// Token: 0x06003150 RID: 12624 RVA: 0x000FC174 File Offset: 0x000FA374
		private void #iAb()
		{
			base.Services.MouseAndKeyboard.#M2c();
			StructurePoint.CoreAssets.Infrastructure.Data.Point #qAb = (this.#i - this.#h).#QW();
			#RAb.#OAb(base.EditorContext, base.Selection.Shapes.SelectedObjects.ToList<ShapeModel>(), base.Selection.Bars.SelectedObjects.ToList<ReinforcementBar>(), #qAb);
			ColumnModelHelper.#VW(base.Project);
			base.EditorContext.SnappingCache.#uP(base.Project);
			this.#b = SelectObjectsToolImpl.#s6b.#a;
			base.Services.MessageBus.#LV();
			base.Renderer.#9f(false, false);
			base.Selection.#bPb();
			base.Services.Renderer.#cg();
		}

		// Token: 0x06003151 RID: 12625 RVA: 0x000FC25C File Offset: 0x000FA45C
		private void #zDb()
		{
			ReinforcementBar reinforcementBar = this.#ADb<ReinforcementBar>(base.Selection.Bars);
			ShapeModel shapeModel = this.#ADb<ShapeModel>(base.Selection.Shapes);
			bool flag = reinforcementBar == null && shapeModel == null;
			if (reinforcementBar != null)
			{
				base.Selection.Bars.#HOb(reinforcementBar);
			}
			if (shapeModel != null)
			{
				base.Selection.Shapes.#HOb(shapeModel);
			}
			if (flag)
			{
				this.#EDb();
			}
		}

		// Token: 0x06003152 RID: 12626 RVA: 0x000FC2D8 File Offset: 0x000FA4D8
		private #Fu #ADb<#Fu>(#QOb<#Fu> #BDb)
		{
			SelectObjectsToolImpl<#Fu>.#D9b #D9b = new SelectObjectsToolImpl<!!0>.#D9b();
			#D9b.#a = #BDb.Hovered.FirstOrDefault<#Fu>();
			#Fu result = #BDb.SelectedObjects.FirstOrDefault(new Func<!!0, bool>(#D9b.#C9b));
			if (#D9b.#a == null)
			{
				return default(!!0);
			}
			return result;
		}

		// Token: 0x06003153 RID: 12627 RVA: 0x0002BBAC File Offset: 0x00029DAC
		private void #CDb()
		{
			base.Selection.#CDb();
		}

		// Token: 0x06003154 RID: 12628 RVA: 0x000FC338 File Offset: 0x000FA538
		private void #DDb()
		{
			base.Services.MouseAndKeyboard.#M2c();
			#oDb.#nDb(base.Services, this.#a);
			base.Services.Renderer.#dg();
			base.Services.Renderer.#cg();
		}

		// Token: 0x06003155 RID: 12629 RVA: 0x0002BBC5 File Offset: 0x00029DC5
		private void #EDb()
		{
			base.Selection.#EDb(base.#IMb(), this.#b == SelectObjectsToolImpl.#s6b.#b);
			this.#DDb();
		}

		// Token: 0x06003156 RID: 12630 RVA: 0x0002BBF3 File Offset: 0x00029DF3
		private void #FDb()
		{
			base.Selection.#FDb();
			this.#DDb();
		}

		// Token: 0x06003157 RID: 12631 RVA: 0x0002BC13 File Offset: 0x00029E13
		private void #GDb()
		{
			base.Services.MessageBus.#NV();
		}

		// Token: 0x06003158 RID: 12632 RVA: 0x000FC394 File Offset: 0x000FA594
		private bool #HDb()
		{
			ReinforcementBar item = base.Selection.Bars.Hovered.LastOrDefault<ReinforcementBar>();
			ShapeModel item2 = base.Selection.Shapes.Hovered.LastOrDefault<ShapeModel>();
			return base.Selection.Bars.SelectedObjects.Contains(item) || base.Selection.Shapes.SelectedObjects.Contains(item2);
		}

		// Token: 0x06003159 RID: 12633 RVA: 0x000FC40C File Offset: 0x000FA60C
		private void #IDb()
		{
			base.UndoManager.PropertyChanged -= this.#7j;
			base.UndoManager.PropertyChanged += this.#7j;
			base.Selection.AnySelectionCleared -= this.#uDb;
			base.Selection.AnySelectionCleared += this.#uDb;
		}

		// Token: 0x0600315A RID: 12634 RVA: 0x0002BC31 File Offset: 0x00029E31
		private void #JDb()
		{
			base.UndoManager.PropertyChanged -= this.#7j;
			base.Selection.AnySelectionCleared -= this.#uDb;
		}

		// Token: 0x0600315B RID: 12635 RVA: 0x0002BC6D File Offset: 0x00029E6D
		[CompilerGenerated]
		private void #KDb()
		{
			ColumnModelHelper.#aX(base.EditorContext, this.#a);
			this.#1kb();
		}

		// Token: 0x04001400 RID: 5120
		private readonly #UFb #a;

		// Token: 0x04001401 RID: 5121
		private SelectObjectsToolImpl.#s6b #b;

		// Token: 0x04001402 RID: 5122
		private bool #c;

		// Token: 0x04001403 RID: 5123
		private System.Drawing.Point #d;

		// Token: 0x04001404 RID: 5124
		private System.Drawing.Point #e;

		// Token: 0x04001405 RID: 5125
		private devDept.Geometry.Point3D #f;

		// Token: 0x04001406 RID: 5126
		private devDept.Geometry.Point3D #g;

		// Token: 0x04001407 RID: 5127
		private devDept.Geometry.Point3D #h;

		// Token: 0x04001408 RID: 5128
		private devDept.Geometry.Point3D #i;

		// Token: 0x04001409 RID: 5129
		private devDept.Geometry.Point3D #j;

		// Token: 0x0400140A RID: 5130
		private RectangleF #k = new RectangleF(0f, 0f, 0f, 0f);

		// Token: 0x0400140B RID: 5131
		private readonly #VFb #l;

		// Token: 0x0400140C RID: 5132
		private readonly #1Fb #m;

		// Token: 0x0400140D RID: 5133
		private readonly IEditorService #n;

		// Token: 0x0400140E RID: 5134
		private readonly #oCb #o;

		// Token: 0x0400140F RID: 5135
		[CompilerGenerated]
		private readonly #ZFb #p;

		// Token: 0x02000569 RID: 1385
		private enum #s6b
		{
			// Token: 0x04001411 RID: 5137
			#a,
			// Token: 0x04001412 RID: 5138
			#b,
			// Token: 0x04001413 RID: 5139
			#c
		}

		// Token: 0x0200056B RID: 1387
		[CompilerGenerated]
		private sealed class #D9b<#Fu>
		{
			// Token: 0x06003160 RID: 12640 RVA: 0x0002BCA2 File Offset: 0x00029EA2
			internal bool #C9b(#Fu #Rf)
			{
				return #Rf.Equals(this.#a);
			}

			// Token: 0x04001416 RID: 5142
			public #Fu #a;
		}
	}
}
