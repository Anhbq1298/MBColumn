using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #cMb;
using #LFb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Core.Selection;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select.Core;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;

namespace #ABb
{
	// Token: 0x02000566 RID: 1382
	internal sealed class #qDb : BaseToolWithChildren, #uNb, #XFb
	{
		// Token: 0x06003123 RID: 12579 RVA: 0x000FB624 File Offset: 0x000F9824
		public #qDb(IExtendedServices #0c, #2Fb #Lyb, #5Fb #Nyb, #4Fb #Myb, #6Fb #Syb, #0Fb #Ryb, #ZFb #Oyb, #3Fb #Kyb, #TFb #Pyb, #SFb #Qyb, #UFb #bX, #VFb #rDb, #1Fb #lAb, IEditorService #wj, #oCb #sDb) : base(#0c)
		{
			this.#a = #bX;
			this.#b = #wj;
			this.#c = #sDb;
			base.ChildTools.#pR(new IChildColumnEditorTool[]
			{
				#Kyb,
				#Oyb,
				#Pyb,
				#Qyb,
				#Lyb,
				#Nyb,
				#Myb,
				#Syb,
				#Ryb
			});
			SelectObjectsToolImpl primary = new SelectObjectsToolImpl(#0c, #Lyb, #Nyb, #Myb, #Syb, #Ryb, #Oyb, #Kyb, #Pyb, #Qyb, #bX, #rDb, #lAb, #wj, #sDb);
			OffsetSlabEdgeToolImpl offsetSlabEdgeToolImpl = new OffsetSlabEdgeToolImpl(#0c, #Kyb, #wj);
			MoveVertexToolImpl moveVertexToolImpl = new MoveVertexToolImpl(#0c, #Kyb, #wj);
			this.#d = new MultiToolManager(primary, new IMultiToolChild[]
			{
				moveVertexToolImpl,
				offsetSlabEdgeToolImpl
			});
			base.UndoManager.PropertyChanged += this.#7j;
		}

		// Token: 0x17000FD3 RID: 4051
		// (get) Token: 0x06003124 RID: 12580 RVA: 0x0002B829 File Offset: 0x00029A29
		public override IView ParametersView
		{
			get
			{
				return this.#c.View;
			}
		}

		// Token: 0x17000FD4 RID: 4052
		// (get) Token: 0x06003125 RID: 12581 RVA: 0x0002B83E File Offset: 0x00029A3E
		public bool IsChildWorking
		{
			get
			{
				return this.#d.#GNb();
			}
		}

		// Token: 0x06003126 RID: 12582 RVA: 0x0002B853 File Offset: 0x00029A53
		public override void #1kb()
		{
			base.#1kb();
			this.#d.#1kb();
			this.#c.#nCb();
		}

		// Token: 0x06003127 RID: 12583 RVA: 0x0002B87D File Offset: 0x00029A7D
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, Point screenPosition, Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			this.#d.HandleDrawOverlay(data, screenPosition, planePosition);
		}

		// Token: 0x06003128 RID: 12584 RVA: 0x0002B8A2 File Offset: 0x00029AA2
		public override void HandleMouseDown(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			this.#d.HandleMouseDown(args, screenPosition, planePosition);
		}

		// Token: 0x06003129 RID: 12585 RVA: 0x0002B8C7 File Offset: 0x00029AC7
		public override void HandleMouseMove(MouseEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			this.#d.HandleMouseMove(args, screenPosition, planePosition);
		}

		// Token: 0x0600312A RID: 12586 RVA: 0x0002B8EC File Offset: 0x00029AEC
		public override void HandleMouseUp(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			this.#d.HandleMouseUp(args, screenPosition, planePosition);
		}

		// Token: 0x0600312B RID: 12587 RVA: 0x0002B911 File Offset: 0x00029B11
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			this.#d.HandleDynamicInputCoordinateCommited(args);
		}

		// Token: 0x0600312C RID: 12588 RVA: 0x0002B932 File Offset: 0x00029B32
		public override void HandleKeyUp(KeyEventArgs args)
		{
			if (!this.#d.#GNb())
			{
				base.HandleKeyUp(args);
			}
			this.#d.HandleKeyUp(args);
		}

		// Token: 0x0600312D RID: 12589 RVA: 0x0002B960 File Offset: 0x00029B60
		public override void HandleChangedState()
		{
			base.HandleChangedState();
			this.#d.#ENb();
		}

		// Token: 0x0600312E RID: 12590 RVA: 0x000FB6F8 File Offset: 0x000F98F8
		public override void HandleKeyDown(KeyEventArgs args)
		{
			base.HandleKeyDown(args);
			if (args.Key != Key.Delete)
			{
				this.#d.HandleKeyDown(args);
				return;
			}
			if (!base.EditorContext.Selection.#jAb())
			{
				return;
			}
			if (this.IsChildWorking)
			{
				base.#fMb();
			}
			this.#b.#0Pb(new Action(this.#gYi));
		}

		// Token: 0x0600312F RID: 12591 RVA: 0x0002B97F File Offset: 0x00029B7F
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			base.HandleDynamicInputCoordinateSnapRequested(args);
			this.#d.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06003130 RID: 12592 RVA: 0x0002B9A0 File Offset: 0x00029BA0
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateChange(args);
			this.#d.HandleDynamicInputCoordinateChange(args);
		}

		// Token: 0x06003131 RID: 12593 RVA: 0x0002B9C1 File Offset: 0x00029BC1
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			this.#d.HandleDynamicInputCoordinateValidation(args);
		}

		// Token: 0x06003132 RID: 12594 RVA: 0x0002B9E2 File Offset: 0x00029BE2
		public override void OnActivated()
		{
			base.OnActivated();
			this.#d.#2B();
			this.#c.#5b();
		}

		// Token: 0x06003133 RID: 12595 RVA: 0x000FB76C File Offset: 0x000F996C
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#d.#1kb();
			this.#d.#3B();
			SelectionManager selectionManager = base.Selection;
			if (selectionManager != null)
			{
				selectionManager.#sOb();
			}
			#oDb.#nDb(base.Services, this.#a);
			this.#c.#nCb();
		}

		// Token: 0x06003134 RID: 12596 RVA: 0x0002BA0C File Offset: 0x00029C0C
		private void #7j(object #Ge, PropertyChangedEventArgs #He)
		{
			this.#d.#FNb();
		}

		// Token: 0x06003135 RID: 12597 RVA: 0x000FB7D0 File Offset: 0x000F99D0
		[CompilerGenerated]
		private void #gYi()
		{
			ColumnModelHelper.#aX(base.EditorContext, this.#a);
			this.#1kb();
			base.Services.MessageBus.#KV();
			base.Services.MessageBus.#tV();
			base.Services.MessageBus.#MV();
			base.Renderer.#9f(false, false);
		}

		// Token: 0x040013FC RID: 5116
		private readonly #UFb #a;

		// Token: 0x040013FD RID: 5117
		private readonly IEditorService #b;

		// Token: 0x040013FE RID: 5118
		private readonly #oCb #c;

		// Token: 0x040013FF RID: 5119
		private readonly MultiToolManager #d;
	}
}
