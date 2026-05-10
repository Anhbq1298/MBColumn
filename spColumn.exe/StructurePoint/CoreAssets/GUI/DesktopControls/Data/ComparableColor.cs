using System;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A12 RID: 2578
	public sealed class ComparableColor : IComparable
	{
		// Token: 0x06005500 RID: 21760 RVA: 0x000466AE File Offset: 0x000448AE
		public ComparableColor(Color effectiveColor)
		{
			this.EffectiveColor = effectiveColor;
		}

		// Token: 0x1700187A RID: 6266
		// (get) Token: 0x06005501 RID: 21761 RVA: 0x000466BD File Offset: 0x000448BD
		// (set) Token: 0x06005502 RID: 21762 RVA: 0x000466C9 File Offset: 0x000448C9
		public Color EffectiveColor { get; private set; }

		// Token: 0x06005503 RID: 21763 RVA: 0x00164D2C File Offset: 0x00162F2C
		public int CompareTo(object obj)
		{
			ComparableColor comparableColor = obj as ComparableColor;
			if (comparableColor == null)
			{
				return -1;
			}
			int num = this.EffectiveColor.A.CompareTo(comparableColor.EffectiveColor.A);
			if (num != 0)
			{
				return num;
			}
			num = this.EffectiveColor.R.CompareTo(comparableColor.EffectiveColor.R);
			if (num != 0)
			{
				return num;
			}
			num = this.EffectiveColor.G.CompareTo(comparableColor.EffectiveColor.G);
			if (num != 0)
			{
				return num;
			}
			return this.EffectiveColor.B.CompareTo(comparableColor.EffectiveColor.B);
		}

		// Token: 0x06005504 RID: 21764 RVA: 0x00164E10 File Offset: 0x00163010
		protected bool Equals(ComparableColor other)
		{
			return other != null && other.EffectiveColor.Equals(this.EffectiveColor);
		}

		// Token: 0x06005505 RID: 21765 RVA: 0x000466DA File Offset: 0x000448DA
		public override bool Equals(object obj)
		{
			return obj != null && (this == obj || (!(obj.GetType() != base.GetType()) && this.Equals((ComparableColor)obj)));
		}

		// Token: 0x06005506 RID: 21766 RVA: 0x00164E48 File Offset: 0x00163048
		public override int GetHashCode()
		{
			return this.EffectiveColor.GetHashCode();
		}

		// Token: 0x06005507 RID: 21767 RVA: 0x00046714 File Offset: 0x00044914
		public static bool operator ==(ComparableColor color1, ComparableColor color2)
		{
			return (color1 == null && color2 == null) || color1 == color2 || (color1 != null && color1.Equals(color2));
		}

		// Token: 0x06005508 RID: 21768 RVA: 0x0004673C File Offset: 0x0004493C
		public static bool operator !=(ComparableColor color1, ComparableColor color2)
		{
			return !(color1 == color2);
		}

		// Token: 0x06005509 RID: 21769 RVA: 0x00046754 File Offset: 0x00044954
		public static bool operator <(ComparableColor color1, ComparableColor color2)
		{
			return color1 != color2 && color1 != null && color1.CompareTo(color2) == -1;
		}

		// Token: 0x0600550A RID: 21770 RVA: 0x00046777 File Offset: 0x00044977
		public static bool operator >(ComparableColor color1, ComparableColor color2)
		{
			return color1 != color2 && color1 != null && color1.CompareTo(color2) == 1;
		}
	}
}
