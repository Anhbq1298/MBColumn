using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #LQc
{
	// Token: 0x02000C3D RID: 3133
	internal sealed class #MRc : #IRc
	{
		// Token: 0x17001C54 RID: 7252
		// (get) Token: 0x0600658D RID: 25997 RVA: 0x00051E60 File Offset: 0x00050060
		// (set) Token: 0x0600658E RID: 25998 RVA: 0x00051E68 File Offset: 0x00050068
		public Color MarkerColor
		{
			get
			{
				return this.#h;
			}
			set
			{
				for (;;)
				{
					if (!false && !(this.#h != value))
					{
						goto IL_20;
					}
					IL_11:
					if (false)
					{
						continue;
					}
					this.#h = value;
					if (!false)
					{
						this.#JRc();
					}
					IL_20:
					if (!false)
					{
						break;
					}
					goto IL_11;
				}
			}
		}

		// Token: 0x17001C55 RID: 7253
		// (get) Token: 0x0600658F RID: 25999 RVA: 0x00051E94 File Offset: 0x00050094
		// (set) Token: 0x06006590 RID: 26000 RVA: 0x00051E9C File Offset: 0x0005009C
		public bool Enabled { get; set; }

		// Token: 0x06006591 RID: 26001 RVA: 0x00051EA5 File Offset: 0x000500A5
		public #MRc()
		{
			this.#h = Colors.Navy;
			this.Enabled = true;
		}

		// Token: 0x06006592 RID: 26002 RVA: 0x0018EA44 File Offset: 0x0018CC44
		public void #QQc(IModelEditorControl #RQc, IDrawingResultsFactory #SQc)
		{
			string #R0d = #Phc.#3hc(107444019);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107443108);
			if (!false)
			{
				#X0d.#V0d(#RQc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107443393);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107443055);
			if (4 != 0)
			{
				#X0d.#V0d(#SQc, #R0d2, #x6c2, #Qic2);
			}
			this.#c = #RQc;
			this.#b = #SQc;
			this.#d = true;
			IModelEditorControl modelEditorControl = this.#c;
			EventHandler value = new EventHandler(this.#QEc);
			if (!false)
			{
				modelEditorControl.CameraChanged += value;
			}
		}

		// Token: 0x06006593 RID: 26003 RVA: 0x00051EBF File Offset: 0x000500BF
		public void #TQc(Point3D? #HAb, double? #HS)
		{
			if (!this.Enabled)
			{
				return;
			}
			for (;;)
			{
				this.#f = #HAb;
				this.#g = #HS;
				if (true && !this.#d && !false)
				{
					break;
				}
				if (8 != 0)
				{
					goto Block_5;
				}
			}
			return;
			Block_5:
			if (!false)
			{
				this.#JRc();
			}
		}

		// Token: 0x06006594 RID: 26004 RVA: 0x0018EAD0 File Offset: 0x0018CCD0
		public void #TQc(Point3D #HAb)
		{
			if (!false && this.Enabled)
			{
				Point3D? #HAb2 = new Point3D?(#HAb);
				double? #HS = null;
				if (!false)
				{
					this.#TQc(#HAb2, #HS);
				}
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x06006595 RID: 26005 RVA: 0x00051EF6 File Offset: 0x000500F6
		public void #yl()
		{
			this.#f = null;
			this.#g = null;
			if (4 != 0)
			{
				this.#JRc();
			}
		}

		// Token: 0x06006596 RID: 26006 RVA: 0x00051F1C File Offset: 0x0005011C
		private void #QEc(object #Ge, EventArgs #He)
		{
			if (this.#d && !false)
			{
				this.#JRc();
			}
		}

		// Token: 0x06006597 RID: 26007 RVA: 0x0018EB0C File Offset: 0x0018CD0C
		private void #JRc()
		{
			if (3 == 0)
			{
				goto IL_34;
			}
			Point3D? point3D = this.#f;
			Point3D? point3D2;
			if (!false)
			{
				point3D2 = point3D;
			}
			IL_10:
			double? #HS;
			if (6 != 0)
			{
				if (3 == 0)
				{
					goto IL_49;
				}
				double? num = this.#g;
				if (7 != 0)
				{
					#HS = num;
				}
			}
			if (point3D2 == null)
			{
				if (this.#e != null)
				{
					goto IL_34;
				}
				return;
			}
			IL_49:
			if (!this.Enabled)
			{
				return;
			}
			if (this.#e == null)
			{
				this.#e = this.#b.CreateMultilineDrawingResult();
				ILinesDrawingResultBase linesDrawingResultBase = this.#e;
				Color lineColor = this.MarkerColor;
				if (!false)
				{
					linesDrawingResultBase.LineColor = lineColor;
				}
			}
			IMultilineDrawingResult multilineDrawingResult = this.#e;
			IMultilineDrawingResult #YQc;
			if (!false)
			{
				#YQc = multilineDrawingResult;
			}
			double num2 = this.#c.CalculateViewScale();
			double #LRc;
			if (true)
			{
				#LRc = num2;
			}
			Point3D value = point3D2.Value;
			this.#KRc(#YQc, value, #LRc, #HS);
			return;
			IL_34:
			if (false)
			{
				goto IL_10;
			}
			IModelEditorControl modelEditorControl = this.#c;
			IDrawingResult drawingResult = this.#e;
			if (!false)
			{
				modelEditorControl.RemoveFromView(drawingResult);
			}
		}

		// Token: 0x06006598 RID: 26008 RVA: 0x0018EBE8 File Offset: 0x0018CDE8
		private void #KRc(IMultilineDrawingResult #YQc, Point3D #Wjc, double #LRc, double? #HS)
		{
			IModelEditorControl modelEditorControl = this.#c;
			if (!false)
			{
				modelEditorControl.AddToView(#YQc);
			}
			double num2;
			double num = num2 = 1.0;
			double num4;
			double num6;
			if (!false)
			{
				double num3 = num / #LRc;
				if (!false)
				{
					num4 = num3;
				}
				if (#HS == null)
				{
					double value = 8.0 * num4;
					if (!false)
					{
						#HS = new double?(value);
					}
					goto IL_79;
				}
				double num5 = #LRc * #HS.Value;
				if (7 != 0)
				{
					num6 = num5;
				}
				num2 = Math.Max(num6, 8.0);
			}
			if (true)
			{
				num6 = num2;
			}
			double value2 = num6 * num4;
			if (3 != 0)
			{
				#HS = new double?(value2);
			}
			IL_79:
			double num7 = #HS.Value * 1.3;
			double num8 = num7 * 0.5;
			Point3D? point3D = this.#i;
			Point3D #ncb = #Wjc;
			if (point3D != null && (point3D == null || Point3D.#E3d(point3D.GetValueOrDefault(), #ncb)))
			{
				double? num9 = this.#j;
				bool flag2;
				bool flag = flag2 = (num9.GetValueOrDefault() == #LRc);
				bool flag5;
				do
				{
					bool flag4;
					bool flag3 = flag4 = (num9 != null);
					if (!false)
					{
						if (!flag2 || !flag3)
						{
							goto IL_123;
						}
						if (false)
						{
							goto IL_143;
						}
						num9 = this.#k;
						double? num10 = #HS;
						flag = (num9.GetValueOrDefault() == num10.GetValueOrDefault());
						flag4 = (num9 != null == (num10 != null));
					}
					flag5 = (flag2 = (flag = (flag && flag4)));
				}
				while (7 == 0);
				if (flag5)
				{
					return;
				}
			}
			IL_123:
			this.#i = new Point3D?(#Wjc);
			this.#j = new double?(#LRc);
			this.#k = #HS;
			IL_143:
			List<Point3D> list;
			double #xsc;
			if (2 != 0)
			{
				list = new List<Point3D>();
				#xsc = 0.1;
				list.#vzc(#Wjc.X - num7, #Wjc.Y - num7, #xsc);
			}
			list.#vzc(#Wjc.X - num7, #Wjc.Y - num7 + num8, #xsc);
			list.#vzc(#Wjc.X - num7, #Wjc.Y - num7, #xsc);
			list.#vzc(#Wjc.X - num7 + num8, #Wjc.Y - num7, #xsc);
			list.#vzc(#Wjc.X + num7, #Wjc.Y + num7, #xsc);
			list.#vzc(#Wjc.X + num7, #Wjc.Y + num7 - num8, #xsc);
			list.#vzc(#Wjc.X + num7, #Wjc.Y + num7, #xsc);
			list.#vzc(#Wjc.X + num7 - num8, #Wjc.Y + num7, #xsc);
			list.#vzc(#Wjc.X - num7, #Wjc.Y + num7, #xsc);
			list.#vzc(#Wjc.X - num7 + num8, #Wjc.Y + num7, #xsc);
			list.#vzc(#Wjc.X - num7, #Wjc.Y + num7, #xsc);
			list.#vzc(#Wjc.X - num7, #Wjc.Y + num7 - num8, #xsc);
			list.#vzc(#Wjc.X + num7, #Wjc.Y - num7, #xsc);
			list.#vzc(#Wjc.X + num7 - num8, #Wjc.Y - num7, #xsc);
			list.#vzc(#Wjc.X + num7, #Wjc.Y - num7, #xsc);
			list.#vzc(#Wjc.X + num7, #Wjc.Y - num7 + num8, #xsc);
			#YQc.Positions = list;
		}

		// Token: 0x040029AC RID: 10668
		private const double #a = 8.0;

		// Token: 0x040029AD RID: 10669
		private IDrawingResultsFactory #b;

		// Token: 0x040029AE RID: 10670
		private IModelEditorControl #c;

		// Token: 0x040029AF RID: 10671
		private bool #d;

		// Token: 0x040029B0 RID: 10672
		private IMultilineDrawingResult #e;

		// Token: 0x040029B1 RID: 10673
		private Point3D? #f;

		// Token: 0x040029B2 RID: 10674
		private double? #g;

		// Token: 0x040029B3 RID: 10675
		private Color #h;

		// Token: 0x040029B4 RID: 10676
		private Point3D? #i;

		// Token: 0x040029B5 RID: 10677
		private double? #j;

		// Token: 0x040029B6 RID: 10678
		private double? #k;

		// Token: 0x040029B7 RID: 10679
		[CompilerGenerated]
		private bool #l;
	}
}
