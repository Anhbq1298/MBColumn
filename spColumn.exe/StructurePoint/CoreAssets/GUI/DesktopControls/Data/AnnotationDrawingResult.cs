using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A14 RID: 2580
	public sealed class AnnotationDrawingResult : DrawingResultBase, IDrawingResult, IAnnotationDrawingResult
	{
		// Token: 0x06005510 RID: 21776 RVA: 0x00164E78 File Offset: 0x00163078
		public AnnotationDrawingResult()
		{
			this.AnnotationVisual = new CircleTextVisual3D
			{
				IsUpdating = true,
				Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(#Phc.#3hc(107462995))),
				Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(#Phc.#3hc(107462950))),
				BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(#Phc.#3hc(107462969))),
				BorderThickness = new Thickness(1.0),
				Padding = new Thickness(9.0, 5.0, 9.0, 5.0),
				BorderCornerRadius = new CornerRadius(30.0),
				FontSize = 15.0,
				Normal = new Vector3D(0.0, 0.0, 1.0),
				UpDirection = new Vector3D(0.0, 1.0, 0.0),
				Radius = 1.0,
				IsUpdating = false
			};
		}

		// Token: 0x1700187D RID: 6269
		// (get) Token: 0x06005511 RID: 21777 RVA: 0x000467EA File Offset: 0x000449EA
		// (set) Token: 0x06005512 RID: 21778 RVA: 0x000467F6 File Offset: 0x000449F6
		internal CircleTextVisual3D AnnotationVisual { get; private set; }

		// Token: 0x06005513 RID: 21779 RVA: 0x00046807 File Offset: 0x00044A07
		public void SetAnnotationBackground(Color color)
		{
			this.AnnotationVisual.Background = new SolidColorBrush(color);
		}

		// Token: 0x06005514 RID: 21780 RVA: 0x00046826 File Offset: 0x00044A26
		public void SetAnnotationForeground(Color color)
		{
			this.AnnotationVisual.Foreground = new SolidColorBrush(color);
		}

		// Token: 0x06005515 RID: 21781 RVA: 0x00046845 File Offset: 0x00044A45
		public void SetAnnotationBorder(Color color)
		{
			this.AnnotationVisual.BorderBrush = new SolidColorBrush(color);
		}

		// Token: 0x06005516 RID: 21782 RVA: 0x00046864 File Offset: 0x00044A64
		public void SetAnnotationRadius(double radius)
		{
			this.AnnotationVisual.Radius = radius;
		}

		// Token: 0x06005517 RID: 21783 RVA: 0x0004687E File Offset: 0x00044A7E
		public void BeginInit()
		{
			this.AnnotationVisual.IsUpdating = true;
		}

		// Token: 0x06005518 RID: 21784 RVA: 0x00046898 File Offset: 0x00044A98
		public void EndInit()
		{
			this.AnnotationVisual.IsUpdating = false;
			this.AnnotationVisual.Update();
		}

		// Token: 0x1700187E RID: 6270
		// (get) Token: 0x06005519 RID: 21785 RVA: 0x000468BD File Offset: 0x00044ABD
		// (set) Token: 0x0600551A RID: 21786 RVA: 0x000468C9 File Offset: 0x00044AC9
		public StructurePoint.CoreAssets.Infrastructure.Data.Point3D Position
		{
			get
			{
				return this.position;
			}
			set
			{
				if (StructurePoint.CoreAssets.Infrastructure.Data.Point3D.#F3d(this.position, value))
				{
					this.position = value;
					this.AnnotationVisual.CenterPosition = this.position.Convert();
				}
			}
		}

		// Token: 0x1700187F RID: 6271
		// (get) Token: 0x0600551B RID: 21787 RVA: 0x00046902 File Offset: 0x00044B02
		// (set) Token: 0x0600551C RID: 21788 RVA: 0x0004690E File Offset: 0x00044B0E
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				if (this.text != value)
				{
					this.text = value;
					this.AnnotationVisual.Text = this.text;
				}
			}
		}

		// Token: 0x0600551D RID: 21789 RVA: 0x00046942 File Offset: 0x00044B42
		protected internal override object RetrieveDisplayedObject()
		{
			return this.AnnotationVisual;
		}

		// Token: 0x04002453 RID: 9299
		private string text;

		// Token: 0x04002454 RID: 9300
		private StructurePoint.CoreAssets.Infrastructure.Data.Point3D position;
	}
}
