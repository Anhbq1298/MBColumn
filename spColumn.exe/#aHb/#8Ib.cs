using System;
using System.Collections.Generic;
using System.Drawing;
using #hR;
using #RJb;
using #Xc;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.Products.Column.Editor.Core;

namespace #aHb
{
	// Token: 0x0200061E RID: 1566
	internal static class #8Ib
	{
		// Token: 0x06003547 RID: 13639 RVA: 0x00107998 File Offset: 0x00105B98
		public static void #ZIb(Point3D[] #AHb, #cLb #FR)
		{
			if (#AHb[0] == #AHb[1])
			{
				return;
			}
			EyeshotEditor editor = #FR.Editor;
			RenderContextBase renderContext = #FR.Editor.renderContext;
			Point3D[] array = editor.WorldToScreen(#AHb);
			Mesh mesh = UtilityEx.Triangulate(array, null, null, null);
			Point3D[] vertices = mesh.Vertices;
			List<Point3D> list = new List<Point3D>();
			foreach (IndexTriangle indexTriangle in mesh.Triangles)
			{
				list.Add(vertices[indexTriangle.V1]);
				list.Add(vertices[indexTriangle.V2]);
				list.Add(vertices[indexTriangle.V3]);
			}
			renderContext.PushBlendState();
			renderContext.SetState(blendStateType.Blend);
			renderContext.SetColorWireframe(#KT.#H, false);
			renderContext.SetLineSizeExt(#KT.#I);
			renderContext.DrawTriangles(list.ToArray(), new Vector3D(0.0, 0.0, 1.0));
			renderContext.SetColorWireframe(#KT.#G, false);
			for (int j = 1; j < array.Length; j++)
			{
				renderContext.DrawLine(array[j - 1], array[j]);
			}
			renderContext.PopBlendState();
		}

		// Token: 0x06003548 RID: 13640 RVA: 0x00107AE4 File Offset: 0x00105CE4
		public static RectangleF #0Ib(System.Drawing.Point #1Ib, System.Drawing.Point #Kzb, ColumnEditor #iBb, #Gd #hL)
		{
			System.Drawing.Point #mcb = new System.Drawing.Point(#1Ib.X, (int)(#iBb.DpiScaleUpY(#iBb.ActualHeight) - (double)#1Ib.Y));
			System.Drawing.Point #ncb = new System.Drawing.Point(#Kzb.X, (int)(#iBb.DpiScaleUpY(#iBb.ActualHeight) - (double)#Kzb.Y));
			return #8Ib.#2Ib(#mcb, #ncb, #iBb, #hL, 3855, true, null);
		}

		// Token: 0x06003549 RID: 13641 RVA: 0x00107B60 File Offset: 0x00105D60
		public static RectangleF #2Ib(System.Drawing.Point #mcb, System.Drawing.Point #ncb, ColumnEditor #iBb, #Gd #hL, ushort #3Ib = 65535, bool #4f = true, Color? #4Ib = null)
		{
			#8Ib.#5Ib(ref #mcb, ref #ncb);
			RenderContextBase renderContext = #iBb.renderContext;
			int[] viewFrame = #iBb.ActiveViewport.GetViewFrame();
			int num = viewFrame[0];
			int num2 = viewFrame[1] + viewFrame[3];
			int num3 = num + viewFrame[2];
			int num4 = viewFrame[1];
			if (#ncb.X > num3 - 1)
			{
				#ncb.X = num3 - 1;
			}
			if (#ncb.Y > num2 - 1)
			{
				#ncb.Y = num2 - 1;
			}
			if (#mcb.X < num + 1)
			{
				#mcb.X = num + 1;
			}
			if (#mcb.Y < num4 + 1)
			{
				#mcb.Y = num4 + 1;
			}
			renderContext.PushBlendState();
			renderContext.SetState(blendStateType.Blend);
			renderContext.SetColorWireframe(#KT.#H, false);
			renderContext.SetLineSizeExt(#KT.#I);
			int num5 = #ncb.X - #mcb.X;
			int num6 = #ncb.Y - #mcb.Y;
			RectangleF rectangleF = new RectangleF((float)(#mcb.X + 1), (float)(#mcb.Y + 1), (float)(num5 - 1), (float)(num6 - 1));
			renderContext.DrawQuad(rectangleF);
			renderContext.PopBlendState();
			#8Ib.#6Ib(#mcb, #ncb, #iBb, renderContext, #3Ib, #4Ib);
			if (#4f)
			{
				#hL.#cg();
			}
			return rectangleF;
		}

		// Token: 0x0600354A RID: 13642 RVA: 0x00107CB4 File Offset: 0x00105EB4
		private static void #5Ib(ref System.Drawing.Point #mcb, ref System.Drawing.Point #ncb)
		{
			int x = Math.Min(#mcb.X, #ncb.X);
			int y = Math.Min(#mcb.Y, #ncb.Y);
			int x2 = Math.Max(#mcb.X, #ncb.X);
			int y2 = Math.Max(#mcb.Y, #ncb.Y);
			#mcb.X = x;
			#mcb.Y = y;
			#ncb.X = x2;
			#ncb.Y = y2;
		}

		// Token: 0x0600354B RID: 13643 RVA: 0x00107D34 File Offset: 0x00105F34
		private static void #6Ib(System.Drawing.Point #mcb, System.Drawing.Point #ncb, ColumnEditor #iBb, RenderContextBase #7Ib, ushort #3Ib, Color? #BR = null)
		{
			#7Ib.SetColorWireframe(#BR ?? #KT.#G, false);
			#7Ib.SetLineStipple(1, #3Ib, #iBb.Viewports[0].Camera);
			#7Ib.EnableLineStipple(true);
			int num = #mcb.X;
			int num2 = #ncb.X;
			if (#7Ib.IsDirect3D)
			{
				num++;
				num2++;
			}
			List<Point3D> list = new List<Point3D>(new Point3D[]
			{
				new Point3D((double)num, (double)#mcb.Y),
				new Point3D((double)#ncb.X, (double)#mcb.Y),
				new Point3D((double)num2, (double)#mcb.Y),
				new Point3D((double)num2, (double)#ncb.Y),
				new Point3D((double)num2, (double)#ncb.Y),
				new Point3D((double)num, (double)#ncb.Y),
				new Point3D((double)num, (double)#ncb.Y),
				new Point3D((double)num, (double)#mcb.Y)
			});
			#7Ib.DrawLines(list.ToArray());
			#7Ib.EnableLineStipple(false);
		}
	}
}
