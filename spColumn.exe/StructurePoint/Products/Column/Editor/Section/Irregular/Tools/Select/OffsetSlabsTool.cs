using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #cMb;
using #LFb;
using #N6c;
using #RJb;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.Framework.UndoRedo;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Select
{
	// Token: 0x0200052B RID: 1323
	internal sealed class OffsetSlabsTool : #tNb, #uNb, IChildColumnEditorTool, #4Fb
	{
		// Token: 0x06002F95 RID: 12181 RVA: 0x00028AFF File Offset: 0x00026CFF
		public OffsetSlabsTool(IExtendedServices services) : base(services)
		{
		}

		// Token: 0x17000F84 RID: 3972
		// (get) Token: 0x06002F96 RID: 12182 RVA: 0x0002A63F File Offset: 0x0002883F
		// (set) Token: 0x06002F97 RID: 12183 RVA: 0x0002A64B File Offset: 0x0002884B
		public bool IsEnabled
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					this.#c = value;
					base.ForceOrthoDisabled = value;
					if (value)
					{
						this.#fzb(new devDept.Geometry.Point3D(), false);
					}
				}
			}
		}

		// Token: 0x06002F98 RID: 12184 RVA: 0x000F5C0C File Offset: 0x000F3E0C
		public override void #1kb()
		{
			base.#1kb();
			this.#d = OffsetSlabsTool.#s6b.#a;
			base.#JMb();
			this.#b = 0.0;
			base.#vf();
			base.Services.MessageBus.#uV(this);
		}

		// Token: 0x06002F99 RID: 12185 RVA: 0x0002A680 File Offset: 0x00028880
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			this.#b = args.Offset;
			args.Handled = true;
		}

		// Token: 0x06002F9A RID: 12186 RVA: 0x000F5C60 File Offset: 0x000F3E60
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			this.#b = args.CoordinateX.GetValueOrDefault(0.0);
			ShapeModel shapeModel = base.EditorContext.Selection.Shapes.SelectedObjects.FirstOrDefault<ShapeModel>();
			if (this.#d == OffsetSlabsTool.#s6b.#b && shapeModel != null)
			{
				IList<Point> list = BooleanOperationsHelper.#Rlc(shapeModel.#cxc(0).Points2D, this.#b, 30.0);
				if (list != null)
				{
					return;
				}
				args.ErrorMessage = Strings.StringInvalidGeometry;
			}
			this.#b = 0.0;
		}

		// Token: 0x06002F9B RID: 12187 RVA: 0x000F5D18 File Offset: 0x000F3F18
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.Editor.DynamicInput.ShouldFollowInsertionPoint = true;
			base.HandleDynamicInputCoordinateChange(args);
			this.#b = args.Offset;
			base.Editor.Invalidate();
			this.#Bzb();
		}

		// Token: 0x06002F9C RID: 12188 RVA: 0x00028A8D File Offset: 0x00026C8D
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			args.SnappedPoint = base.#bNb(#LLb.#n, args.InputPoint);
			base.HandleDynamicInputCoordinateSnapRequested(args);
		}

		// Token: 0x06002F9D RID: 12189 RVA: 0x0002A6A8 File Offset: 0x000288A8
		private void #YAb()
		{
			this.#d = OffsetSlabsTool.#s6b.#a;
			base.#JMb();
			base.Services.MessageBus.#uV(this);
		}

		// Token: 0x06002F9E RID: 12190 RVA: 0x000F5D68 File Offset: 0x000F3F68
		public override bool #fzb(devDept.Geometry.Point3D #Ng, bool #gzb = false)
		{
			#47c<ShapeModel> #47c = base.EditorContext.Selection.Shapes.SelectedObjects;
			if (!base.#WMb(true) || #47c.Count != 1)
			{
				this.#YAb();
				return false;
			}
			if (this.#d == OffsetSlabsTool.#s6b.#a)
			{
				base.#fzb(#Ng, #gzb);
				base.#VMb(Strings.StringSpecifyOffsetDistance, true, false, false);
				this.#d = OffsetSlabsTool.#s6b.#b;
				DynamicInputResultState dynamicInputResultState = base.Editor.DynamicInput.OpenInputDirectly(new devDept.Geometry.Point3D());
				if (dynamicInputResultState != DynamicInputResultState.Commited)
				{
					this.#YAb();
					return false;
				}
				base.Editor.DynamicInput.HandleEditorMousePositionChanged(#Ng);
			}
			this.#7Ab();
			base.Services.MessageBus.#tV();
			this.#YAb();
			return true;
		}

		// Token: 0x06002F9F RID: 12191 RVA: 0x0002A6D4 File Offset: 0x000288D4
		private void #6Ab()
		{
			ColumnModelHelper.#VW(base.Project);
			base.EditorContext.SnappingCache.#uP(base.Project);
			base.Renderer.#9f(false, false);
		}

		// Token: 0x06002FA0 RID: 12192 RVA: 0x000F5E3C File Offset: 0x000F403C
		private void #7Ab()
		{
			OffsetSlabsTool.#rWb #rWb = new OffsetSlabsTool.#rWb();
			#rWb.#b = this;
			#rWb.#c = base.EditorContext.Selection.Shapes.SelectedObjects.FirstOrDefault<ShapeModel>();
			if (this.#b == 0.0 || #rWb.#c == null)
			{
				return;
			}
			base.Services.MouseAndKeyboard.#M2c();
			#rWb.#a = #rWb.#c.#cxc(0).Points2D;
			UndoAction.#uRb(base.UndoManager, new Action(#rWb.#T8b));
		}

		// Token: 0x06002FA1 RID: 12193 RVA: 0x000293C1 File Offset: 0x000275C1
		private void #Bzb()
		{
			if (!base.EditorContext.Settings.DynamicInput.Enabled)
			{
				base.Viewports.#vf();
			}
		}

		// Token: 0x04001335 RID: 4917
		private const double #a = 30.0;

		// Token: 0x04001336 RID: 4918
		private double #b;

		// Token: 0x04001337 RID: 4919
		private bool #c;

		// Token: 0x04001338 RID: 4920
		private OffsetSlabsTool.#s6b #d;

		// Token: 0x0200052C RID: 1324
		private enum #s6b
		{
			// Token: 0x0400133A RID: 4922
			#a,
			// Token: 0x0400133B RID: 4923
			#b
		}

		// Token: 0x0200052E RID: 1326
		[CompilerGenerated]
		private sealed class #rWb
		{
			// Token: 0x06002FA6 RID: 12198 RVA: 0x000F5EEC File Offset: 0x000F40EC
			internal void #T8b()
			{
				IList<Point> list = BooleanOperationsHelper.#Rlc(this.#a, this.#b.#b, 30.0);
				if (list == null)
				{
					return;
				}
				PolygonData #JP = new PolygonData(list.Select(new Func<Point, StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(OffsetSlabsTool.<>c.<>9.#U8b)));
				this.#c.#8wc(#JP);
				if (this.#c.FigureType == PolygonFigureType.Circle && this.#c.CircleRadius != null)
				{
					double? num = this.#c.CircleRadius + this.#b.#b;
					this.#c.#q0(num.Value);
				}
				this.#b.#6Ab();
			}

			// Token: 0x0400133E RID: 4926
			public IReadOnlyList<Point> #a;

			// Token: 0x0400133F RID: 4927
			public OffsetSlabsTool #b;

			// Token: 0x04001340 RID: 4928
			public ShapeModel #c;
		}
	}
}
