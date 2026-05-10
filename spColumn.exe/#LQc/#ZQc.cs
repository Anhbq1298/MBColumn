using System;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #LQc
{
	// Token: 0x02000C27 RID: 3111
	internal sealed class #ZQc : #wRc
	{
		// Token: 0x06006510 RID: 25872 RVA: 0x000519E4 File Offset: 0x0004FBE4
		public #ZQc()
		{
			this.#i = Colors.Navy;
		}

		// Token: 0x17001C43 RID: 7235
		// (get) Token: 0x06006511 RID: 25873 RVA: 0x000519F7 File Offset: 0x0004FBF7
		// (set) Token: 0x06006512 RID: 25874 RVA: 0x000519FF File Offset: 0x0004FBFF
		public Color MarkerColor
		{
			get
			{
				return this.#i;
			}
			set
			{
				for (;;)
				{
					if (!(this.#i != value))
					{
						goto IL_2F;
					}
					this.#i = value;
					IL_15:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						if (this.#f != null)
						{
							IArrowDrawingResult arrowDrawingResult = this.#f;
							if (5 != 0)
							{
								arrowDrawingResult.Color = value;
							}
						}
					}
					IL_2F:
					if (true)
					{
						break;
					}
					goto IL_15;
				}
			}
		}

		// Token: 0x06006513 RID: 25875 RVA: 0x0018D348 File Offset: 0x0018B548
		public void #QQc(IModelEditorControl #RQc, IDrawingResultsFactory #SQc)
		{
			string #R0d = #Phc.#3hc(107444019);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107443990);
			if (!false)
			{
				#X0d.#V0d(#RQc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107443393);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107443360);
			if (4 != 0)
			{
				#X0d.#V0d(#SQc, #R0d2, #x6c2, #Qic2);
			}
			this.#d = #RQc;
			this.#c = #SQc;
			this.#e = true;
			IModelEditorControl modelEditorControl = this.#d;
			EventHandler value = new EventHandler(this.#QEc);
			if (!false)
			{
				modelEditorControl.CameraChanged += value;
			}
		}

		// Token: 0x06006514 RID: 25876 RVA: 0x00051A3A File Offset: 0x0004FC3A
		public void #TQc(Point3D #UQc, Point3D #VQc)
		{
			this.#g = new Point3D?(#UQc);
			do
			{
				this.#h = new Point3D?(#VQc);
			}
			while (false);
			if (this.#e)
			{
				if (!false && !false)
				{
					this.#WQc();
				}
				if (8 != 0)
				{
					return;
				}
			}
		}

		// Token: 0x06006515 RID: 25877 RVA: 0x0018D3D4 File Offset: 0x0018B5D4
		public void #yl()
		{
			this.#g = null;
			do
			{
				if (8 != 0)
				{
					this.#h = null;
				}
				if (this.#f != null && 7 != 0)
				{
					IModelEditorControl modelEditorControl = this.#d;
					IDrawingResult drawingResult = this.#f;
					if (2 != 0)
					{
						modelEditorControl.RemoveFromView(drawingResult);
					}
				}
			}
			while (false);
		}

		// Token: 0x06006516 RID: 25878 RVA: 0x00051A72 File Offset: 0x0004FC72
		private void #QEc(object #Ge, EventArgs #He)
		{
			if (this.#e && !false)
			{
				this.#WQc();
			}
		}

		// Token: 0x06006517 RID: 25879 RVA: 0x0018D424 File Offset: 0x0018B624
		private void #WQc()
		{
			if (this.#g == null || this.#h == null)
			{
				return;
			}
			if (this.#f == null)
			{
				this.#f = this.#c.CreateArrowDrawingResult();
				IArrowDrawingResult arrowDrawingResult = this.#f;
				Color color = this.MarkerColor;
				if (3 != 0)
				{
					arrowDrawingResult.Color = color;
				}
			}
			IArrowDrawingResult #YQc = this.#f;
			Point3D value = this.#g.Value;
			Point3D value2 = this.#h.Value;
			if (!false)
			{
				this.#XQc(#YQc, value, value2);
			}
		}

		// Token: 0x06006518 RID: 25880 RVA: 0x0018D4A8 File Offset: 0x0018B6A8
		private void #XQc(IArrowDrawingResult #YQc, Point3D #UQc, Point3D #VQc)
		{
			IModelEditorControl modelEditorControl = this.#d;
			if (!false)
			{
				modelEditorControl.AddToView(#YQc);
			}
			double? num6;
			if (3 != 0)
			{
				double num = 0.1;
				if (!false)
				{
					#UQc.Z = num;
				}
				double num2 = 0.1;
				if (4 != 0)
				{
					#VQc.Z = num2;
				}
				double x = (#UQc.X + #VQc.X) / 2.0;
				double y = (#UQc.Y + #VQc.Y) / 2.0;
				double z = (#UQc.Z + #VQc.Z) / 2.0;
				Point3D center;
				if (4 != 0)
				{
					center = new Point3D(x, y, z);
				}
				double? num3 = VisualToScreenHelper.ScaleRadiusToRemainFixedSizeOnscreen(this.#d, #YQc, center, 4.0);
				double? num4;
				if (!false)
				{
					num4 = num3;
				}
				double? num5 = VisualToScreenHelper.ScaleRadiusToRemainFixedSizeOnscreen(this.#d, #YQc, center, 0.35);
				if (!false)
				{
					num6 = num5;
				}
				#YQc.StartPosition = #UQc;
				#YQc.EndPosition = #VQc;
				if (num4 != null)
				{
					#YQc.ArrowRadius = num4.Value;
				}
				if (num6 == null)
				{
					return;
				}
			}
			#YQc.Radius = num6.Value;
		}

		// Token: 0x04002973 RID: 10611
		private const double #a = 0.35;

		// Token: 0x04002974 RID: 10612
		private const double #b = 4.0;

		// Token: 0x04002975 RID: 10613
		private IDrawingResultsFactory #c;

		// Token: 0x04002976 RID: 10614
		private IModelEditorControl #d;

		// Token: 0x04002977 RID: 10615
		private bool #e;

		// Token: 0x04002978 RID: 10616
		private IArrowDrawingResult #f;

		// Token: 0x04002979 RID: 10617
		private Point3D? #g;

		// Token: 0x0400297A RID: 10618
		private Point3D? #h;

		// Token: 0x0400297B RID: 10619
		private Color #i;
	}
}
