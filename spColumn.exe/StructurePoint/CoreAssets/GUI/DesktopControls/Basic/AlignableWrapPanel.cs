using System;
using System.Windows;
using System.Windows.Controls;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A77 RID: 2679
	public sealed class AlignableWrapPanel : Panel
	{
		// Token: 0x170018F6 RID: 6390
		// (get) Token: 0x0600577A RID: 22394 RVA: 0x00048237 File Offset: 0x00046437
		// (set) Token: 0x0600577B RID: 22395 RVA: 0x00048251 File Offset: 0x00046451
		public HorizontalAlignment HorizontalContentAlignment
		{
			get
			{
				return (HorizontalAlignment)base.GetValue(AlignableWrapPanel.HorizontalContentAlignmentProperty);
			}
			set
			{
				base.SetValue(AlignableWrapPanel.HorizontalContentAlignmentProperty, value);
			}
		}

		// Token: 0x0600577C RID: 22396 RVA: 0x00166B08 File Offset: 0x00164D08
		protected override Size MeasureOverride(Size availableSize)
		{
			Size size = default(Size);
			Size result = default(Size);
			UIElementCollection internalChildren = base.InternalChildren;
			UIElementCollection uielementCollection;
			if (!false)
			{
				uielementCollection = internalChildren;
			}
			for (int i = 0; i < uielementCollection.Count; i++)
			{
				UIElement uielement = uielementCollection[i];
				uielement.Measure(availableSize);
				Size desiredSize = uielement.DesiredSize;
				if (size.Width + desiredSize.Width > availableSize.Width)
				{
					result.Width = Math.Max(size.Width, result.Width);
					result.Height += size.Height;
					size = desiredSize;
					if (desiredSize.Width > availableSize.Width)
					{
						result.Width = Math.Max(desiredSize.Width, result.Width);
						result.Height += desiredSize.Height;
						size = default(Size);
					}
				}
				else
				{
					size.Width += desiredSize.Width;
					size.Height = Math.Max(desiredSize.Height, size.Height);
				}
			}
			result.Width = Math.Max(size.Width, result.Width);
			result.Height += size.Height;
			return result;
		}

		// Token: 0x0600577D RID: 22397 RVA: 0x00166C6C File Offset: 0x00164E6C
		protected override Size ArrangeOverride(Size finalSize)
		{
			int num = 0;
			int num2;
			if (4 != 0)
			{
				num2 = num;
			}
			Size lineSize = default(Size);
			double num3 = 0.0;
			UIElementCollection internalChildren = base.InternalChildren;
			for (int i = 0; i < internalChildren.Count; i++)
			{
				Size desiredSize = internalChildren[i].DesiredSize;
				if (lineSize.Width + desiredSize.Width > finalSize.Width)
				{
					this.ArrangeLine(num3, lineSize, finalSize.Width, num2, i);
					num3 += lineSize.Height;
					lineSize = desiredSize;
					if (desiredSize.Width > finalSize.Width)
					{
						this.ArrangeLine(num3, desiredSize, finalSize.Width, i, ++i);
						num3 += desiredSize.Height;
						lineSize = default(Size);
					}
					num2 = i;
				}
				else
				{
					lineSize.Width += desiredSize.Width;
					lineSize.Height = Math.Max(desiredSize.Height, lineSize.Height);
				}
			}
			if (num2 < internalChildren.Count)
			{
				this.ArrangeLine(num3, lineSize, finalSize.Width, num2, internalChildren.Count);
			}
			return finalSize;
		}

		// Token: 0x0600577E RID: 22398 RVA: 0x00166DA4 File Offset: 0x00164FA4
		private void ArrangeLine(double y, Size lineSize, double boundsWidth, int start, int end)
		{
			double num = 0.0;
			if (this.HorizontalContentAlignment == HorizontalAlignment.Center)
			{
				num = (boundsWidth - lineSize.Width) / 2.0;
			}
			else if (this.HorizontalContentAlignment == HorizontalAlignment.Right)
			{
				num = boundsWidth - lineSize.Width;
			}
			UIElementCollection internalChildren = base.InternalChildren;
			for (int i = start; i < end; i++)
			{
				UIElement uielement = internalChildren[i];
				uielement.Arrange(new Rect(num, y, uielement.DesiredSize.Width, lineSize.Height));
				num += uielement.DesiredSize.Width;
			}
		}

		// Token: 0x040024AE RID: 9390
		public static readonly DependencyProperty HorizontalContentAlignmentProperty = DependencyProperty.Register(#Phc.#3hc(107429320), typeof(HorizontalAlignment), typeof(AlignableWrapPanel), new FrameworkPropertyMetadata(HorizontalAlignment.Left, FrameworkPropertyMetadataOptions.AffectsArrange));
	}
}
