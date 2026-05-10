using System;
using System.Windows;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #LQc
{
	// Token: 0x02000C38 RID: 3128
	internal sealed class #pRc : #zRc
	{
		// Token: 0x17001C4C RID: 7244
		// (get) Token: 0x06006569 RID: 25961 RVA: 0x00051D1E File Offset: 0x0004FF1E
		// (set) Token: 0x0600656A RID: 25962 RVA: 0x00051D26 File Offset: 0x0004FF26
		public Color ForegroundColor
		{
			get
			{
				return this.#j;
			}
			set
			{
				while (this.#j != value)
				{
					if (5 != 0)
					{
						this.#j = value;
					}
					if (false || this.#f == null)
					{
						break;
					}
					if (3 != 0)
					{
						IBillboardTextDrawingResult billboardTextDrawingResult = this.#f;
						Brush foreground = new SolidColorBrush(value);
						if (4 == 0)
						{
							break;
						}
						billboardTextDrawingResult.Foreground = foreground;
						break;
					}
				}
			}
		}

		// Token: 0x0600656B RID: 25963 RVA: 0x0018E470 File Offset: 0x0018C670
		public void #QQc(IModelEditorControl #RQc, IDrawingResultsFactory #SQc)
		{
			for (;;)
			{
				string #R0d = #Phc.#3hc(107444019);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107442840);
				if (7 != 0)
				{
					#X0d.#V0d(#RQc, #R0d, #x6c, #Qic);
				}
				do
				{
					string #R0d2 = #Phc.#3hc(107443393);
					Component #x6c2 = Component.GUIFramework;
					string #Qic2 = #Phc.#3hc(107442755);
					if (!false)
					{
						#X0d.#V0d(#SQc, #R0d2, #x6c2, #Qic2);
					}
				}
				while (false);
				this.#d = #RQc;
				do
				{
					this.#c = #SQc;
				}
				while (false);
				if (!false)
				{
					this.#e = true;
					IModelEditorControl modelEditorControl = this.#d;
					EventHandler value = new EventHandler(this.#QEc);
					if (6 != 0)
					{
						modelEditorControl.CameraChanged += value;
					}
					if (4 != 0)
					{
						break;
					}
				}
			}
			if (true)
			{
				this.#kRc();
			}
		}

		// Token: 0x0600656C RID: 25964 RVA: 0x0018E518 File Offset: 0x0018C718
		public void #TQc(Point3D #0bb, string #hvb)
		{
			this.#g = new Point3D?(#0bb);
			this.#k = #hvb;
			if (!this.#e)
			{
				return;
			}
			try
			{
				IBillboardTextDrawingResult billboardTextDrawingResult = this.#f;
				if (5 != 0)
				{
					billboardTextDrawingResult.BeginUpdate();
				}
				IBillboardTextDrawingResult billboardTextDrawingResult2 = this.#f;
				HorizontalAlignment horizontalAlignment = HorizontalAlignment.Center;
				if (!false)
				{
					billboardTextDrawingResult2.HorizontalAlignment = horizontalAlignment;
				}
				IBillboardTextDrawingResult billboardTextDrawingResult3 = this.#f;
				VerticalAlignment verticalAlignment = VerticalAlignment.Center;
				if (!false)
				{
					billboardTextDrawingResult3.VerticalAlignment = verticalAlignment;
				}
				if (6 != 0)
				{
					this.#mRc();
				}
			}
			finally
			{
				this.#f.EndUpdate();
			}
		}

		// Token: 0x0600656D RID: 25965 RVA: 0x0018E5A4 File Offset: 0x0018C7A4
		public void #TQc(StructurePoint.CoreAssets.Infrastructure.Data.Point #Xrb, StructurePoint.CoreAssets.Infrastructure.Data.Point #Yrb, string #hvb)
		{
			if (!this.#e)
			{
				return;
			}
			this.#h = new StructurePoint.CoreAssets.Infrastructure.Data.Point?(#Xrb);
			this.#i = new StructurePoint.CoreAssets.Infrastructure.Data.Point?(#Yrb);
			if (!false)
			{
				this.#lRc();
			}
			this.#k = #hvb;
			try
			{
				IBillboardTextDrawingResult billboardTextDrawingResult = this.#f;
				if (!false)
				{
					billboardTextDrawingResult.BeginUpdate();
				}
				StructurePoint.CoreAssets.Infrastructure.Data.Vector vector = StructurePoint.CoreAssets.Infrastructure.Data.Point.#H3d(#Yrb, #Xrb);
				StructurePoint.CoreAssets.Infrastructure.Data.Vector vector2;
				if (true)
				{
					vector2 = vector;
				}
				double num2;
				double num = num2 = vector2.X;
				if (!false)
				{
					if (num < 0.0001)
					{
						goto IL_95;
					}
					num2 = vector2.Y;
				}
				if (num2 >= 0.0001)
				{
					IBillboardTextDrawingResult billboardTextDrawingResult2 = this.#f;
					HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;
					if (-1 != 0)
					{
						billboardTextDrawingResult2.HorizontalAlignment = horizontalAlignment;
					}
					IBillboardTextDrawingResult billboardTextDrawingResult3 = this.#f;
					VerticalAlignment verticalAlignment = VerticalAlignment.Bottom;
					if (!false)
					{
						billboardTextDrawingResult3.VerticalAlignment = verticalAlignment;
					}
					goto IL_15C;
				}
				IL_95:
				double num4;
				double num3 = num4 = vector2.X;
				double num6;
				double num7;
				do
				{
					double num5 = num6 = 0.0001;
					if (6 == 0)
					{
						goto IL_142;
					}
					if (num4 <= num5)
					{
						goto IL_DF;
					}
					num7 = (num4 = (num3 = vector2.Y));
				}
				while (false);
				if (num7 < 0.0001)
				{
					IBillboardTextDrawingResult billboardTextDrawingResult4 = this.#f;
					HorizontalAlignment horizontalAlignment2 = HorizontalAlignment.Left;
					if (!false)
					{
						billboardTextDrawingResult4.HorizontalAlignment = horizontalAlignment2;
					}
					this.#f.VerticalAlignment = VerticalAlignment.Top;
					goto IL_15C;
				}
				IL_DF:
				if (vector2.X <= 0.0001 && vector2.Y >= 0.0001)
				{
					this.#f.HorizontalAlignment = HorizontalAlignment.Right;
				}
				else if (2 != 0)
				{
					if (vector2.X <= 0.0001)
					{
						num3 = vector2.Y;
						num6 = 0.0001;
						goto IL_142;
					}
					goto IL_15C;
				}
				this.#f.VerticalAlignment = VerticalAlignment.Bottom;
				goto IL_15C;
				IL_142:
				if (num3 < num6)
				{
					this.#f.HorizontalAlignment = HorizontalAlignment.Right;
					this.#f.VerticalAlignment = VerticalAlignment.Top;
				}
				IL_15C:
				this.#mRc();
			}
			finally
			{
				this.#f.EndUpdate();
			}
		}

		// Token: 0x0600656E RID: 25966 RVA: 0x00051D66 File Offset: 0x0004FF66
		public void #TQc(Point3D #Xrb, Point3D #Yrb, string #hvb)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point #Xrb2 = PointsConverter.#vsc(#Xrb);
			StructurePoint.CoreAssets.Infrastructure.Data.Point #Yrb2 = PointsConverter.#vsc(#Yrb);
			if (!false)
			{
				this.#TQc(#Xrb2, #Yrb2, #hvb);
			}
		}

		// Token: 0x0600656F RID: 25967 RVA: 0x00051D84 File Offset: 0x0004FF84
		public void #yl()
		{
			if (!false)
			{
				this.#g = null;
			}
			do
			{
				if (this.#f != null)
				{
					IModelEditorControl modelEditorControl = this.#d;
					IDrawingResult drawingResult = this.#f;
					if (!false)
					{
						modelEditorControl.RemoveFromView(drawingResult);
					}
				}
			}
			while (false);
		}

		// Token: 0x06006570 RID: 25968 RVA: 0x0018E778 File Offset: 0x0018C978
		private void #kRc()
		{
			if (this.#f == null)
			{
				this.#f = this.#c.CreateBillboardTextDrawingResult();
				IBillboardTextDrawingResult billboardTextDrawingResult = this.#f;
				Brush foreground = new SolidColorBrush(this.ForegroundColor);
				if (2 != 0)
				{
					billboardTextDrawingResult.Foreground = foreground;
				}
				IBillboardTextDrawingResult billboardTextDrawingResult2 = this.#f;
				Brush background = new SolidColorBrush(Colors.White);
				if (!false)
				{
					billboardTextDrawingResult2.Background = background;
				}
				IBillboardTextDrawingResult billboardTextDrawingResult3 = this.#f;
				Brush borderBrush = new SolidColorBrush(Colors.Black);
				if (6 != 0)
				{
					billboardTextDrawingResult3.BorderBrush = borderBrush;
				}
				IBillboardTextDrawingResult billboardTextDrawingResult4 = this.#f;
				Thickness padding = new Thickness(7.5, 1.0, 7.5, 1.0);
				if (2 != 0)
				{
					billboardTextDrawingResult4.Padding = padding;
				}
				IBillboardTextDrawingResult billboardTextDrawingResult5 = this.#f;
				double fontSize = 12.0;
				if (!false)
				{
					billboardTextDrawingResult5.FontSize = fontSize;
				}
				IBillboardTextDrawingResult billboardTextDrawingResult6 = this.#f;
				Thickness margin = new Thickness(0.0);
				if (2 != 0)
				{
					billboardTextDrawingResult6.Margin = margin;
				}
			}
		}

		// Token: 0x06006571 RID: 25969 RVA: 0x0018E87C File Offset: 0x0018CA7C
		private void #lRc()
		{
			if (this.#h == null || this.#i == null)
			{
				return;
			}
			double num2;
			double num = num2 = this.#oRc();
			if (!false)
			{
				double num3;
				if (!false)
				{
					num3 = num;
				}
				num2 = 10.0 / num3;
			}
			double #8Bb;
			if (-1 != 0)
			{
				#8Bb = num2;
			}
			StructurePoint.CoreAssets.Infrastructure.Data.Point value = this.#h.Value;
			StructurePoint.CoreAssets.Infrastructure.Data.Point point;
			if (3 != 0)
			{
				point = value;
			}
			double #8mc = point.X;
			StructurePoint.CoreAssets.Infrastructure.Data.Point value2 = this.#h.Value;
			if (!false)
			{
				point = value2;
			}
			double #9mc = point.Y;
			StructurePoint.CoreAssets.Infrastructure.Data.Point value3 = this.#i.Value;
			if (5 != 0)
			{
				point = value3;
			}
			double #anc = point.X;
			StructurePoint.CoreAssets.Infrastructure.Data.Point value4 = this.#i.Value;
			if (3 != 0)
			{
				point = value4;
			}
			double #Udb = GeometryHelper.#knc(#8mc, #9mc, #anc, point.Y);
			StructurePoint.CoreAssets.Infrastructure.Data.Point #Ng = GeometryHelper.#Jnc(this.#i.Value, #Udb, #8Bb);
			this.#g = new Point3D?(PointsConverter.#vsc(#Ng));
		}

		// Token: 0x06006572 RID: 25970 RVA: 0x0018E96C File Offset: 0x0018CB6C
		private void #QEc(object #Ge, EventArgs #He)
		{
			bool flag2;
			bool flag = flag2 = this.#e;
			if (false)
			{
				goto IL_2F;
			}
			if (!flag)
			{
				goto IL_3B;
			}
			this.#l = new double?(this.#d.CalculateViewScale());
			IL_21:
			if (false)
			{
				goto IL_31;
			}
			flag2 = (this.#g != null);
			IL_2F:
			if (!flag2)
			{
				goto IL_36;
			}
			IL_31:
			if (!false)
			{
				this.#lRc();
			}
			IL_36:
			if (true)
			{
				this.#mRc();
			}
			IL_3B:
			if (!false)
			{
				return;
			}
			goto IL_21;
		}

		// Token: 0x06006573 RID: 25971 RVA: 0x00051DB8 File Offset: 0x0004FFB8
		private void #mRc()
		{
			do
			{
				if (this.#g != null)
				{
					IBillboardTextDrawingResult #YQc = this.#f;
					Point3D value = this.#g.Value;
					if (2 != 0)
					{
						this.#nRc(#YQc, value);
					}
					if (!false)
					{
						return;
					}
				}
			}
			while (6 == 0);
		}

		// Token: 0x06006574 RID: 25972 RVA: 0x0018E9C8 File Offset: 0x0018CBC8
		private void #nRc(IBillboardTextDrawingResult #YQc, Point3D #UQc)
		{
			IModelEditorControl modelEditorControl = this.#d;
			if (!false)
			{
				modelEditorControl.AddToView(#YQc);
			}
			double num2;
			if (!false)
			{
				double num = this.#oRc();
				if (!false)
				{
					num2 = num;
				}
			}
			double num3 = 0.44999999999999996 + 2.0 / num2;
			if (!false)
			{
				#UQc.Z = num3;
			}
			do
			{
				if (3 != 0)
				{
					Point3D position = #UQc;
					if (6 != 0)
					{
						#YQc.Position = position;
					}
				}
			}
			while (false);
			string text = this.#k;
			if (!false)
			{
				#YQc.Text = text;
			}
		}

		// Token: 0x06006575 RID: 25973 RVA: 0x00051DED File Offset: 0x0004FFED
		private double #oRc()
		{
			if (4 != 0 && this.#l == null)
			{
				this.#l = new double?(this.#d.CalculateViewScale());
			}
			return this.#l.Value;
		}

		// Token: 0x0400299E RID: 10654
		private const double #a = 0.0001;

		// Token: 0x0400299F RID: 10655
		private const double #b = 10.0;

		// Token: 0x040029A0 RID: 10656
		private IDrawingResultsFactory #c;

		// Token: 0x040029A1 RID: 10657
		private IModelEditorControl #d;

		// Token: 0x040029A2 RID: 10658
		private bool #e;

		// Token: 0x040029A3 RID: 10659
		private IBillboardTextDrawingResult #f;

		// Token: 0x040029A4 RID: 10660
		private Point3D? #g;

		// Token: 0x040029A5 RID: 10661
		private StructurePoint.CoreAssets.Infrastructure.Data.Point? #h;

		// Token: 0x040029A6 RID: 10662
		private StructurePoint.CoreAssets.Infrastructure.Data.Point? #i;

		// Token: 0x040029A7 RID: 10663
		private Color #j;

		// Token: 0x040029A8 RID: 10664
		private string #k;

		// Token: 0x040029A9 RID: 10665
		private double? #l;
	}
}
