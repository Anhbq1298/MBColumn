using System;
using #7hc;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.Infrastructure.Data
{
	// Token: 0x02000F03 RID: 3843
	public struct Rect : IFormattable
	{
		// Token: 0x1700284E RID: 10318
		// (get) Token: 0x0600883E RID: 34878 RVA: 0x0006EDAD File Offset: 0x0006CFAD
		public static Rect Empty
		{
			get
			{
				return Rect.EmptyRect;
			}
		}

		// Token: 0x1700284F RID: 10319
		// (get) Token: 0x0600883F RID: 34879 RVA: 0x0006EDB4 File Offset: 0x0006CFB4
		public bool IsEmpty
		{
			get
			{
				return this.WidthField < 0.0;
			}
		}

		// Token: 0x17002850 RID: 10320
		// (get) Token: 0x06008840 RID: 34880 RVA: 0x0006EDC7 File Offset: 0x0006CFC7
		// (set) Token: 0x06008841 RID: 34881 RVA: 0x0006EDDA File Offset: 0x0006CFDA
		public Point Location
		{
			get
			{
				return new Point(this.XField, this.YField);
			}
			set
			{
				if (this.IsEmpty)
				{
					throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
				}
				for (;;)
				{
					if (!false)
					{
						this.XField = value.XField;
						goto IL_27;
					}
					IL_33:
					if (!false)
					{
						if (true)
						{
							break;
						}
						continue;
					}
					IL_27:
					this.YField = value.YField;
					goto IL_33;
				}
			}
		}

		// Token: 0x17002851 RID: 10321
		// (get) Token: 0x06008842 RID: 34882 RVA: 0x0006EE15 File Offset: 0x0006D015
		// (set) Token: 0x06008843 RID: 34883 RVA: 0x001D2018 File Offset: 0x001D0218
		public Size Size
		{
			get
			{
				if (true && !false && this.IsEmpty && !false)
				{
					return Size.Empty;
				}
				return new Size(this.WidthField, this.HeightField);
			}
			set
			{
				bool flag = value.IsEmpty;
				while (!flag)
				{
					bool flag2 = flag = this.IsEmpty;
					if (!false)
					{
						if (flag2 && true)
						{
							throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
						}
						do
						{
							this.WidthField = value.#a;
							this.HeightField = value.#b;
						}
						while (2 == 0);
						return;
					}
				}
				this = Rect.EmptyRect;
			}
		}

		// Token: 0x17002852 RID: 10322
		// (get) Token: 0x06008844 RID: 34884 RVA: 0x0006EE3F File Offset: 0x0006D03F
		// (set) Token: 0x06008845 RID: 34885 RVA: 0x0006EE47 File Offset: 0x0006D047
		public double X
		{
			get
			{
				return this.XField;
			}
			set
			{
				if (!true || (!false && !this.IsEmpty))
				{
					this.XField = value;
					if (!false)
					{
						return;
					}
				}
				throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
			}
		}

		// Token: 0x17002853 RID: 10323
		// (get) Token: 0x06008846 RID: 34886 RVA: 0x0006EE71 File Offset: 0x0006D071
		// (set) Token: 0x06008847 RID: 34887 RVA: 0x0006EE79 File Offset: 0x0006D079
		public double Y
		{
			get
			{
				return this.YField;
			}
			set
			{
				if (!true || (!false && !this.IsEmpty))
				{
					this.YField = value;
					if (!false)
					{
						return;
					}
				}
				throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
			}
		}

		// Token: 0x17002854 RID: 10324
		// (get) Token: 0x06008848 RID: 34888 RVA: 0x0006EEA3 File Offset: 0x0006D0A3
		// (set) Token: 0x06008849 RID: 34889 RVA: 0x001D2074 File Offset: 0x001D0274
		public double Width
		{
			get
			{
				return this.WidthField;
			}
			set
			{
				if (2 != 0)
				{
					if (!this.IsEmpty && !false)
					{
						if (value < 0.0)
						{
							throw new ArgumentException(Strings.StringWidthCannotBeNegative.#z2d());
						}
						this.WidthField = value;
					}
					else if (4 != 0)
					{
						throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
					}
				}
			}
		}

		// Token: 0x17002855 RID: 10325
		// (get) Token: 0x0600884A RID: 34890 RVA: 0x0006EEAB File Offset: 0x0006D0AB
		// (set) Token: 0x0600884B RID: 34891 RVA: 0x001D20C8 File Offset: 0x001D02C8
		public double Height
		{
			get
			{
				return this.HeightField;
			}
			set
			{
				if (2 != 0)
				{
					if (!this.IsEmpty && !false)
					{
						if (value < 0.0)
						{
							throw new ArgumentException(Strings.StringHeightCannotBeNegative.#z2d());
						}
						this.HeightField = value;
					}
					else if (4 != 0)
					{
						throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
					}
				}
			}
		}

		// Token: 0x17002856 RID: 10326
		// (get) Token: 0x0600884C RID: 34892 RVA: 0x0006EE3F File Offset: 0x0006D03F
		public double Left
		{
			get
			{
				return this.XField;
			}
		}

		// Token: 0x17002857 RID: 10327
		// (get) Token: 0x0600884D RID: 34893 RVA: 0x0006EE71 File Offset: 0x0006D071
		public double Top
		{
			get
			{
				return this.YField;
			}
		}

		// Token: 0x17002858 RID: 10328
		// (get) Token: 0x0600884E RID: 34894 RVA: 0x0006EEB3 File Offset: 0x0006D0B3
		public double Right
		{
			get
			{
				if (!false && this.IsEmpty && !false)
				{
					return double.NegativeInfinity;
				}
				double result;
				double num = result = this.XField;
				if (!false)
				{
					result = num + this.WidthField;
				}
				return result;
			}
		}

		// Token: 0x17002859 RID: 10329
		// (get) Token: 0x0600884F RID: 34895 RVA: 0x0006EEDD File Offset: 0x0006D0DD
		public double Bottom
		{
			get
			{
				if (!false && this.IsEmpty && !false)
				{
					return double.NegativeInfinity;
				}
				double result;
				double num = result = this.YField;
				if (!false)
				{
					result = num + this.HeightField;
				}
				return result;
			}
		}

		// Token: 0x1700285A RID: 10330
		// (get) Token: 0x06008850 RID: 34896 RVA: 0x0006EF07 File Offset: 0x0006D107
		public Point TopLeft
		{
			get
			{
				return new Point(this.Left, this.Top);
			}
		}

		// Token: 0x1700285B RID: 10331
		// (get) Token: 0x06008851 RID: 34897 RVA: 0x0006EF1A File Offset: 0x0006D11A
		public Point TopRight
		{
			get
			{
				return new Point(this.Right, this.Top);
			}
		}

		// Token: 0x1700285C RID: 10332
		// (get) Token: 0x06008852 RID: 34898 RVA: 0x0006EF2D File Offset: 0x0006D12D
		public Point BottomLeft
		{
			get
			{
				return new Point(this.Left, this.Bottom);
			}
		}

		// Token: 0x1700285D RID: 10333
		// (get) Token: 0x06008853 RID: 34899 RVA: 0x0006EF40 File Offset: 0x0006D140
		public Point BottomRight
		{
			get
			{
				return new Point(this.Right, this.Bottom);
			}
		}

		// Token: 0x06008855 RID: 34901 RVA: 0x001D211C File Offset: 0x001D031C
		public Rect(Point location, Size size)
		{
			if (size.IsEmpty)
			{
				this = Rect.EmptyRect;
				return;
			}
			this.XField = location.XField;
			this.YField = location.YField;
			this.WidthField = size.#a;
			this.HeightField = size.#b;
		}

		// Token: 0x06008856 RID: 34902 RVA: 0x001D2170 File Offset: 0x001D0370
		public Rect(double xField, double yField, double widthField, double heightField)
		{
			if (widthField < 0.0 || heightField < 0.0)
			{
				throw new ArgumentException(#Phc.#3hc(107223721));
			}
			this.XField = xField;
			this.YField = yField;
			this.WidthField = widthField;
			this.HeightField = heightField;
		}

		// Token: 0x06008857 RID: 34903 RVA: 0x001D21C4 File Offset: 0x001D03C4
		public Rect(Point point1, Point point2)
		{
			this.XField = Math.Min(point1.XField, point2.XField);
			this.YField = Math.Min(point1.YField, point2.YField);
			this.WidthField = Math.Max(Math.Max(point1.XField, point2.XField) - this.XField, 0.0);
			this.HeightField = Math.Max(Math.Max(point1.YField, point2.YField) - this.YField, 0.0);
		}

		// Token: 0x06008858 RID: 34904 RVA: 0x0006EF5F File Offset: 0x0006D15F
		public Rect(Point point, Vector vector)
		{
			this = new Rect(point, Point.#G3d(point, vector));
		}

		// Token: 0x06008859 RID: 34905 RVA: 0x001D2258 File Offset: 0x001D0458
		public Rect(Size size)
		{
			if (size.IsEmpty)
			{
				this = Rect.EmptyRect;
				return;
			}
			this.XField = (this.YField = 0.0);
			this.WidthField = size.Width;
			this.HeightField = size.Height;
		}

		// Token: 0x0600885A RID: 34906 RVA: 0x001D22AC File Offset: 0x001D04AC
		public static bool operator ==(Rect rect1, Rect rect2)
		{
			double num3;
			for (;;)
			{
				IL_00:
				double num = rect1.X;
				IL_07:
				while (num == rect2.X)
				{
					double num2 = rect1.Y;
					while (num2 == rect2.Y && rect1.Width == rect2.Width)
					{
						if (7 == 0)
						{
							goto IL_00;
						}
						num3 = (num = (num2 = rect1.Height));
						if (4 != 0)
						{
							if (!false)
							{
								goto Block_5;
							}
							goto IL_07;
						}
					}
					break;
				}
				return false;
			}
			Block_5:
			return num3 == rect2.Height;
		}

		// Token: 0x0600885B RID: 34907 RVA: 0x0006EF74 File Offset: 0x0006D174
		public static bool operator !=(Rect rect1, Rect rect2)
		{
			return !(rect1 == rect2);
		}

		// Token: 0x0600885C RID: 34908 RVA: 0x001D2304 File Offset: 0x001D0504
		public static bool Equals(Rect rect1, Rect rect2)
		{
			int num = rect1.IsEmpty ? 1 : 0;
			while (num == 0)
			{
				double x = rect1.X;
				double num2;
				if (!false)
				{
					num2 = x;
				}
				if (num2.Equals(rect2.X))
				{
					double num3 = rect1.Y;
					for (;;)
					{
						IL_33:
						if (!false)
						{
							num2 = num3;
						}
						while (num2.Equals(rect2.Y))
						{
							do
							{
								double num4 = num3 = rect1.Width;
								if (-1 == 0)
								{
									goto IL_33;
								}
								if (5 != 0)
								{
									num2 = num4;
								}
								if (!num2.Equals(rect2.Width))
								{
									goto IL_85;
								}
							}
							while (false);
							double height = rect1.Height;
							if (!false)
							{
								num2 = height;
							}
							if (-1 != 0)
							{
								goto Block_6;
							}
						}
						goto IL_85;
					}
					Block_6:
					return num2.Equals(rect2.Height);
				}
				IL_85:
				int num5 = num = 0;
				if (num5 == 0)
				{
					return num5 != 0;
				}
			}
			return rect2.IsEmpty;
		}

		// Token: 0x0600885D RID: 34909 RVA: 0x0006EF80 File Offset: 0x0006D180
		public override bool Equals(object obj)
		{
			return (!true || false || obj is Rect || false) && Rect.Equals(this, (Rect)obj);
		}

		// Token: 0x0600885E RID: 34910 RVA: 0x0006EFA6 File Offset: 0x0006D1A6
		public bool Equals(Rect value)
		{
			return Rect.Equals(this, value);
		}

		// Token: 0x0600885F RID: 34911 RVA: 0x001D23AC File Offset: 0x001D05AC
		public override int GetHashCode()
		{
			if (this.IsEmpty)
			{
				return 0;
			}
			double num;
			do
			{
				double x = this.X;
				if (!false)
				{
					num = x;
				}
			}
			while (8 == 0);
			int num2 = num.GetHashCode();
			int result;
			int num4;
			do
			{
				double y = this.Y;
				if (true)
				{
					num = y;
				}
				int num3 = result = (num2 ^ num.GetHashCode());
				if (-1 == 0)
				{
					return result;
				}
				double width = this.Width;
				if (8 != 0)
				{
					num = width;
				}
				num4 = (num2 = (num3 ^ num.GetHashCode()));
				double height = this.Height;
				if (4 != 0)
				{
					num = height;
				}
			}
			while (false);
			result = (num4 ^ num.GetHashCode());
			return result;
		}

		// Token: 0x06008860 RID: 34912 RVA: 0x0006EFB4 File Offset: 0x0006D1B4
		public override string ToString()
		{
			return this.ConvertToString(null, null);
		}

		// Token: 0x06008861 RID: 34913 RVA: 0x0006EFBE File Offset: 0x0006D1BE
		public string ToString(IFormatProvider provider)
		{
			return this.ConvertToString(null, provider);
		}

		// Token: 0x06008862 RID: 34914 RVA: 0x0006EFC8 File Offset: 0x0006D1C8
		string IFormattable.ToString(string format, IFormatProvider provider)
		{
			return this.ConvertToString(format, provider);
		}

		// Token: 0x06008863 RID: 34915 RVA: 0x001D2420 File Offset: 0x001D0620
		internal string ConvertToString(string format, IFormatProvider provider)
		{
			if (this.IsEmpty)
			{
				return #Phc.#3hc(107223704);
			}
			char c = #C3d.#B3d(provider);
			char c2;
			if (5 != 0)
			{
				c2 = c;
			}
			return string.Format(provider, string.Concat(new string[]
			{
				#Phc.#3hc(107223757),
				format,
				#Phc.#3hc(107223752),
				format,
				#Phc.#3hc(107223766),
				format,
				#Phc.#3hc(107223663),
				format,
				#Phc.#3hc(107223771)
			}), new object[]
			{
				c2,
				this.XField,
				this.YField,
				this.WidthField,
				this.HeightField
			});
		}

		// Token: 0x06008864 RID: 34916 RVA: 0x0006EFD2 File Offset: 0x0006D1D2
		public bool Contains(Point point)
		{
			return this.Contains(point.XField, point.YField);
		}

		// Token: 0x06008865 RID: 34917 RVA: 0x0006EFE6 File Offset: 0x0006D1E6
		public bool Contains(double x, double y)
		{
			return !this.IsEmpty && this.MyContains(x, y);
		}

		// Token: 0x06008866 RID: 34918 RVA: 0x001D2500 File Offset: 0x001D0700
		public bool Contains(Rect rect)
		{
			if (!this.IsEmpty)
			{
				bool result;
				bool flag = result = rect.IsEmpty;
				if (!false)
				{
					if (flag)
					{
						return false;
					}
					double num2;
					double num = num2 = this.XField;
					if (6 == 0)
					{
						goto IL_40;
					}
					double num3 = rect.XField;
					IL_23:
					if (num2 > num3 || this.YField > rect.YField)
					{
						return false;
					}
					num = (num2 = this.XField + this.WidthField);
					IL_40:
					double num4 = num3 = rect.XField + rect.WidthField;
					if (false)
					{
						goto IL_23;
					}
					if (num < num4)
					{
						return false;
					}
					double num5 = num2 = this.YField + this.HeightField;
					double num6 = num3 = rect.YField;
					if (8 == 0)
					{
						goto IL_23;
					}
					result = (num5 >= num6 + rect.HeightField);
				}
				return result;
			}
			return false;
		}

		// Token: 0x06008867 RID: 34919 RVA: 0x001D2584 File Offset: 0x001D0784
		public bool IntersectsWith(Rect rect)
		{
			if (!this.IsEmpty && !rect.IsEmpty && (8 == 0 || (rect.Left <= this.Right && rect.Right >= this.Left)))
			{
				double num = rect.Top;
				while (num <= this.Bottom)
				{
					double num2 = num = rect.Bottom;
					if (!false)
					{
						bool result;
						bool flag = result = (num2 < this.Top);
						if (!false)
						{
							result = !flag;
						}
						return result;
					}
				}
			}
			return false;
		}

		// Token: 0x06008868 RID: 34920 RVA: 0x001D25EC File Offset: 0x001D07EC
		public void Intersect(Rect rect)
		{
			while (!false && this.IntersectsWith(rect))
			{
				double val;
				double num = val = Math.Max(this.Left, rect.Left);
				double num2;
				if (!false)
				{
					if (2 != 0)
					{
						num2 = num;
					}
					val = this.Top;
				}
				double num3;
				do
				{
					num3 = (val = Math.Max(val, rect.Top));
				}
				while (false);
				double num4;
				if (7 != 0)
				{
					num4 = num3;
				}
				this.WidthField = Math.Max(Math.Min(this.Right, rect.Right) - num2, 0.0);
				this.HeightField = Math.Max(Math.Min(this.Bottom, rect.Bottom) - num4, 0.0);
				if (!false)
				{
					this.XField = num2;
					this.YField = num4;
					return;
				}
			}
			this = Rect.Empty;
		}

		// Token: 0x06008869 RID: 34921 RVA: 0x0006EFFA File Offset: 0x0006D1FA
		public static Rect Intersect(Rect rect1, Rect rect2)
		{
			if (2 != 0)
			{
				rect1.Intersect(rect2);
			}
			return rect1;
		}

		// Token: 0x0600886A RID: 34922 RVA: 0x001D26B0 File Offset: 0x001D08B0
		public void Union(Rect rect)
		{
			bool isEmpty = this.IsEmpty;
			while (!isEmpty)
			{
				bool flag = isEmpty = rect.IsEmpty;
				if (!false && true)
				{
					if (flag)
					{
						return;
					}
					double num2;
					double num4;
					if (7 != 0)
					{
						double num = Math.Min(this.Left, rect.Left);
						if (4 != 0)
						{
							num2 = num;
						}
						double num3 = Math.Min(this.Top, rect.Top);
						if (true)
						{
							num4 = num3;
						}
					}
					this.WidthField = ((rect.Width == double.PositiveInfinity || this.Width == double.PositiveInfinity) ? double.PositiveInfinity : Math.Max(Math.Max(this.Right, rect.Right) - num2, 0.0));
					this.HeightField = ((rect.Height == double.PositiveInfinity || this.Height == double.PositiveInfinity) ? double.PositiveInfinity : Math.Max(Math.Max(this.Bottom, rect.Bottom) - num4, 0.0));
					this.XField = num2;
					this.YField = num4;
					return;
				}
			}
			this = rect;
			if (4 != 0)
			{
				return;
			}
		}

		// Token: 0x0600886B RID: 34923 RVA: 0x0006F00C File Offset: 0x0006D20C
		public static Rect Union(Rect rect1, Rect rect2)
		{
			if (2 != 0)
			{
				rect1.Union(rect2);
			}
			return rect1;
		}

		// Token: 0x0600886C RID: 34924 RVA: 0x0006F01E File Offset: 0x0006D21E
		public void Union(Point point)
		{
			Rect rect = new Rect(point, point);
			if (!false)
			{
				this.Union(rect);
			}
		}

		// Token: 0x0600886D RID: 34925 RVA: 0x0006F034 File Offset: 0x0006D234
		public static Rect Union(Rect rect, Point point)
		{
			Rect rect2 = new Rect(point, point);
			if (7 != 0)
			{
				rect.Union(rect2);
			}
			return rect;
		}

		// Token: 0x0600886E RID: 34926 RVA: 0x001D27E0 File Offset: 0x001D09E0
		public void Offset(Vector offsetVector)
		{
			if (this.IsEmpty && !false)
			{
				throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
			}
			this.XField += offsetVector.#a;
			this.YField += offsetVector.#b;
		}

		// Token: 0x0600886F RID: 34927 RVA: 0x0006F04C File Offset: 0x0006D24C
		public void Offset(double offsetX, double offsetY)
		{
			if (!false)
			{
				if (false || this.IsEmpty)
				{
					if (7 != 0)
					{
						throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
					}
				}
				else
				{
					this.XField += offsetX;
				}
				this.YField += offsetY;
			}
		}

		// Token: 0x06008870 RID: 34928 RVA: 0x0006F08B File Offset: 0x0006D28B
		public static Rect Offset(Rect rect, Vector offsetVector)
		{
			double offsetX = offsetVector.X;
			double offsetY = offsetVector.Y;
			if (!false)
			{
				rect.Offset(offsetX, offsetY);
			}
			return rect;
		}

		// Token: 0x06008871 RID: 34929 RVA: 0x0006F0AB File Offset: 0x0006D2AB
		public static Rect Offset(Rect rect, double offsetX, double offsetY)
		{
			if (!false)
			{
				rect.Offset(offsetX, offsetY);
			}
			return rect;
		}

		// Token: 0x06008872 RID: 34930 RVA: 0x0006F0BF File Offset: 0x0006D2BF
		public void Inflate(Size size)
		{
			double #a = size.#a;
			double #b = size.#b;
			if (7 != 0)
			{
				this.Inflate(#a, #b);
			}
		}

		// Token: 0x06008873 RID: 34931 RVA: 0x001D2830 File Offset: 0x001D0A30
		public void Inflate(double width, double height)
		{
			if (this.IsEmpty)
			{
				throw new InvalidOperationException(Strings.StringCannotModifyEmptyRect.#z2d());
			}
			if (false)
			{
				goto IL_72;
			}
			this.XField -= width;
			IL_29:
			if (4 == 0)
			{
				goto IL_95;
			}
			this.YField -= height;
			this.WidthField += width;
			this.WidthField += width;
			IL_56:
			this.HeightField += height;
			this.HeightField += height;
			IL_72:
			if (this.WidthField >= 0.0 && this.HeightField >= 0.0)
			{
				return;
			}
			IL_95:
			this = Rect.EmptyRect;
			if (8 == 0)
			{
				goto IL_56;
			}
			if (4 != 0)
			{
				return;
			}
			goto IL_29;
		}

		// Token: 0x06008874 RID: 34932 RVA: 0x0006F0DB File Offset: 0x0006D2DB
		public static Rect Inflate(Rect rect, Size size)
		{
			double #a = size.#a;
			double #b = size.#b;
			if (!false)
			{
				rect.Inflate(#a, #b);
			}
			return rect;
		}

		// Token: 0x06008875 RID: 34933 RVA: 0x0006F0F9 File Offset: 0x0006D2F9
		public static Rect Inflate(Rect rect, double width, double height)
		{
			if (!false)
			{
				rect.Inflate(width, height);
			}
			return rect;
		}

		// Token: 0x06008876 RID: 34934 RVA: 0x001D28E8 File Offset: 0x001D0AE8
		public void Scale(double scaleX, double scaleY)
		{
			if (true && this.IsEmpty)
			{
				return;
			}
			this.XField *= scaleX;
			this.YField *= scaleY;
			this.WidthField *= scaleX;
			this.HeightField *= scaleY;
			double num = scaleX;
			do
			{
				if (num < 0.0)
				{
					this.XField += this.WidthField;
					this.WidthField *= -1.0;
				}
				num = scaleY;
			}
			while (5 == 0);
			if (scaleY >= 0.0)
			{
				return;
			}
			this.YField += this.HeightField;
			this.HeightField *= -1.0;
		}

		// Token: 0x06008877 RID: 34935 RVA: 0x001D29A8 File Offset: 0x001D0BA8
		private bool MyContains(double x, double y)
		{
			double num = x;
			double xfield = this.XField;
			while (num >= xfield)
			{
				double num2 = x;
				double num3;
				do
				{
					num3 = (num = (num2 -= this.WidthField));
				}
				while (false);
				double num4 = xfield = this.XField;
				if (!false)
				{
					if (num3 > num4 || y < this.YField)
					{
						break;
					}
					bool result;
					bool flag = result = (y - this.HeightField > this.YField);
					if (2 != 0)
					{
						return !flag;
					}
					return result;
				}
			}
			return false;
		}

		// Token: 0x06008878 RID: 34936 RVA: 0x001D29F8 File Offset: 0x001D0BF8
		private static Rect MyCreateEmptyRect()
		{
			Rect result;
			for (;;)
			{
				result = default(Rect);
				if (5 != 0)
				{
					result.XField = double.PositiveInfinity;
					result.YField = double.PositiveInfinity;
					if (3 == 0)
					{
						return result;
					}
					if (!false)
					{
						break;
					}
				}
			}
			result.WidthField = double.NegativeInfinity;
			result.HeightField = double.NegativeInfinity;
			return result;
		}

		// Token: 0x04003820 RID: 14368
		internal double XField;

		// Token: 0x04003821 RID: 14369
		internal double YField;

		// Token: 0x04003822 RID: 14370
		internal double WidthField;

		// Token: 0x04003823 RID: 14371
		internal double HeightField;

		// Token: 0x04003824 RID: 14372
		private static readonly Rect EmptyRect = Rect.MyCreateEmptyRect();
	}
}
