using System;
using System.Drawing;
using System.Windows.Forms;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AA9 RID: 2729
	public static class TextAlignmentHelper
	{
		// Token: 0x060058FF RID: 22783 RVA: 0x0016B89C File Offset: 0x00169A9C
		public static string Justify(IDeviceContext context, string text, Font font)
		{
			string[] array = text.Split(new string[]
			{
				Environment.NewLine
			}, StringSplitOptions.None);
			if (array.Length > 1)
			{
				int width = TextRenderer.MeasureText(array.#q1d((string l) => TextRenderer.MeasureText(context, l, font).Width), font).Width;
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.Equals(array[i], text))
					{
						array[i] = TextAlignmentHelper.Align(context, array[i], font, (double)width);
					}
				}
			}
			text = string.Join(Environment.NewLine, array);
			return text;
		}

		// Token: 0x06005900 RID: 22784 RVA: 0x0016B964 File Offset: 0x00169B64
		private static string Align(IDeviceContext context, string text, Font font, double width)
		{
			while ((double)TextRenderer.MeasureText(context, text, font).Width < width)
			{
				text = #Phc.#3hc(107399922) + text + #Phc.#3hc(107399922);
			}
			return text;
		}
	}
}
