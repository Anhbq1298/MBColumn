using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using #7hc;
using #eU;
using #f7;
using devDept.Eyeshot;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.Diagnostics;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;

namespace #RJb
{
	// Token: 0x02000677 RID: 1655
	internal sealed class #KLb : Grid
	{
		// Token: 0x060037AD RID: 14253 RVA: 0x0010DB04 File Offset: 0x0010BD04
		public #KLb(ISettingsManager #iw, #oW #Yc)
		{
			this.#c = #iw;
			this.#d = #Yc;
			this.#f = new EntityGraphicsData();
			base.Step = double.MaxValue;
			base.AutoSize = false;
			base.AutoStep = false;
			base.MajorLinesEvery = 0;
			base.MaxNumberOfLines = 0;
		}

		// Token: 0x17001140 RID: 4416
		// (get) Token: 0x060037AE RID: 14254 RVA: 0x0003061F File Offset: 0x0002E81F
		private ColumnModel Model
		{
			get
			{
				return this.#d.Model;
			}
		}

		// Token: 0x060037AF RID: 14255 RVA: 0x0010DB5C File Offset: 0x0010BD5C
		protected void #6bb(RenderContextBase #ib, Viewport #fe)
		{
			if (this.#d.Model.Options.SectionType != SectionType.Irregular)
			{
				return;
			}
			#KLb.#GKb #GKb = this.#sKb();
			if (!#GKb.Enabled || !this.#c.RuntimeSettings.DrawSnappingGrid)
			{
				return;
			}
			try
			{
				this.#dKb(#ib, #GKb);
			}
			catch (OutOfMemoryException exception)
			{
				Logger.Warning(#Phc.#3hc(107351958), exception);
				return;
			}
			Color black = Color.Black;
			#ib.PushBlendState();
			#ib.PushShader();
			#ib.SetState(blendStateType.Blend);
			#ib.SetPointSize(1f, true, false);
			#ib.SetColorMaterial(black, false);
			#ib.Draw(this.#f, primitiveType.Undefined);
			#ib.PopShader();
			#ib.PopBlendState();
		}

		// Token: 0x060037B0 RID: 14256 RVA: 0x0010DC40 File Offset: 0x0010BE40
		private void #HLb(RenderContextBase #7Ib, object #Sb)
		{
			Point3D[] array = (Point3D[])#Sb;
			if (array.Length != 0)
			{
				#7Ib.DrawPoints(array);
			}
		}

		// Token: 0x060037B1 RID: 14257 RVA: 0x0010DC6C File Offset: 0x0010BE6C
		private void #ILb(List<Point3D> #En, #KLb.#GKb #eKb, bool #kKb, bool #JLb)
		{
			double num = #eKb.SpacingX;
			double num2 = #eKb.SpacingY;
			int num3 = (int)(#eKb.Size / num / 2.0);
			int num4 = (int)(#eKb.Size / num2 / 2.0);
			#En.EnsureTotalCapacity(Math.Min((num3 + 1) * (num4 + 1), int.MaxValue));
			double num5 = #kKb ? -1.0 : 1.0;
			double num6 = #JLb ? -1.0 : 1.0;
			for (int i = 0; i <= num3; i++)
			{
				double x = num * (double)i * num5;
				for (int j = 0; j <= num4; j++)
				{
					double y = num2 * (double)j * num6;
					#En.Add(new Point3D(x, y));
				}
			}
		}

		// Token: 0x060037B2 RID: 14258 RVA: 0x0010DD5C File Offset: 0x0010BF5C
		private List<Point3D> #rHb(#KLb.#GKb #eKb)
		{
			List<Point3D> list = new List<Point3D>(500);
			this.#ILb(list, #eKb, true, false);
			this.#ILb(list, #eKb, false, false);
			this.#ILb(list, #eKb, true, true);
			this.#ILb(list, #eKb, false, true);
			return list;
		}

		// Token: 0x060037B3 RID: 14259 RVA: 0x0010DDAC File Offset: 0x0010BFAC
		private void #dKb(RenderContextBase #ib, #KLb.#GKb #eKb)
		{
			if (!this.#tKb(#eKb, this.#e))
			{
				return;
			}
			Point3D[] myParams = this.#rHb(#eKb).ToArray();
			#ib.Compile(this.#f, new DrawEntityCallBack(this.#HLb), myParams);
			this.#e = #eKb;
			this.#qKb(#eKb);
		}

		// Token: 0x060037B4 RID: 14260 RVA: 0x0010DE0C File Offset: 0x0010C00C
		private bool #tKb(#KLb.#GKb #uKb, #KLb.#GKb #vKb)
		{
			return #uKb == null || #vKb == null || #uKb.Enabled != #vKb.Enabled || #uKb.SpacingX != #vKb.SpacingX || #uKb.SpacingY != #vKb.SpacingY || #uKb.Size != #vKb.Size;
		}

		// Token: 0x060037B5 RID: 14261 RVA: 0x0010DE6C File Offset: 0x0010C06C
		private void #qKb(#KLb.#GKb #eKb)
		{
			ValueTuple<Point2D, Point2D> valueTuple = this.#rKb(#eKb);
			Point2D item = valueTuple.Item1;
			Point2D item2 = valueTuple.Item2;
			base.Min = item;
			base.Max = item2;
		}

		// Token: 0x060037B6 RID: 14262 RVA: 0x0010DEA8 File Offset: 0x0010C0A8
		private ValueTuple<Point2D, Point2D> #rKb(#KLb.#GKb #eKb)
		{
			double num = #eKb.Size / 2.0;
			Point2D item = new Point2D(-num, -num);
			Point2D item2 = new Point2D(num, num);
			return new ValueTuple<Point2D, Point2D>(item, item2);
		}

		// Token: 0x060037B7 RID: 14263 RVA: 0x0010DEEC File Offset: 0x0010C0EC
		private #KLb.#GKb #sKb()
		{
			#KLb.#GKb #GKb = new #KLb.#GKb();
			#z7 #z = this.#c.SnappingSettings;
			#GKb.Enabled = #z.SnappingGridEnabled;
			#GKb.SpacingX = #z.SnapSpacingX;
			#GKb.SpacingY = #z.SnapSpacingY;
			#GKb.Size = DrawingGrid.#aKb(this.Model, #GKb.DefaultSize);
			int num = (int)(#GKb.Size / #GKb.SpacingX);
			int num2 = (int)(#GKb.Size / #GKb.SpacingY);
			while (num * num2 > 3600000)
			{
				#GKb.Size -= Math.Max(#GKb.SpacingX, #GKb.SpacingY);
				num = (int)(#GKb.Size / #GKb.SpacingX);
				num2 = (int)(#GKb.Size / #GKb.SpacingY);
			}
			return #GKb;
		}

		// Token: 0x04001745 RID: 5957
		private const float #a = 1f;

		// Token: 0x04001746 RID: 5958
		private const int #b = 3600000;

		// Token: 0x04001747 RID: 5959
		private readonly ISettingsManager #c;

		// Token: 0x04001748 RID: 5960
		private readonly #oW #d;

		// Token: 0x04001749 RID: 5961
		private #KLb.#GKb #e;

		// Token: 0x0400174A RID: 5962
		private readonly EntityGraphicsData #f;

		// Token: 0x02000678 RID: 1656
		internal sealed class #GKb
		{
			// Token: 0x17001141 RID: 4417
			// (get) Token: 0x060037B8 RID: 14264 RVA: 0x00030634 File Offset: 0x0002E834
			// (set) Token: 0x060037B9 RID: 14265 RVA: 0x00030640 File Offset: 0x0002E840
			public bool Enabled { get; set; }

			// Token: 0x17001142 RID: 4418
			// (get) Token: 0x060037BA RID: 14266 RVA: 0x00030651 File Offset: 0x0002E851
			// (set) Token: 0x060037BB RID: 14267 RVA: 0x0003065D File Offset: 0x0002E85D
			public double SpacingX { get; set; }

			// Token: 0x17001143 RID: 4419
			// (get) Token: 0x060037BC RID: 14268 RVA: 0x0003066E File Offset: 0x0002E86E
			// (set) Token: 0x060037BD RID: 14269 RVA: 0x0003067A File Offset: 0x0002E87A
			public double SpacingY { get; set; }

			// Token: 0x17001144 RID: 4420
			// (get) Token: 0x060037BE RID: 14270 RVA: 0x0003068B File Offset: 0x0002E88B
			// (set) Token: 0x060037BF RID: 14271 RVA: 0x00030697 File Offset: 0x0002E897
			public float LineWidth { get; set; }

			// Token: 0x17001145 RID: 4421
			// (get) Token: 0x060037C0 RID: 14272 RVA: 0x000306A8 File Offset: 0x0002E8A8
			// (set) Token: 0x060037C1 RID: 14273 RVA: 0x000306B4 File Offset: 0x0002E8B4
			public double Size { get; set; }

			// Token: 0x17001146 RID: 4422
			// (get) Token: 0x060037C2 RID: 14274 RVA: 0x000306C5 File Offset: 0x0002E8C5
			// (set) Token: 0x060037C3 RID: 14275 RVA: 0x000306D1 File Offset: 0x0002E8D1
			public double DefaultSize { get; set; }

			// Token: 0x17001147 RID: 4423
			// (get) Token: 0x060037C4 RID: 14276 RVA: 0x000306E2 File Offset: 0x0002E8E2
			// (set) Token: 0x060037C5 RID: 14277 RVA: 0x000306EE File Offset: 0x0002E8EE
			public int MainLineEvery { get; set; }

			// Token: 0x0400174B RID: 5963
			[CompilerGenerated]
			private bool #a;

			// Token: 0x0400174C RID: 5964
			[CompilerGenerated]
			private double #b = 5.0;

			// Token: 0x0400174D RID: 5965
			[CompilerGenerated]
			private double #c = 10.0;

			// Token: 0x0400174E RID: 5966
			[CompilerGenerated]
			private float #d = 1f;

			// Token: 0x0400174F RID: 5967
			[CompilerGenerated]
			private double #e = 500.0;

			// Token: 0x04001750 RID: 5968
			[CompilerGenerated]
			private double #f = 500.0;

			// Token: 0x04001751 RID: 5969
			[CompilerGenerated]
			private int #g = 5;
		}
	}
}
