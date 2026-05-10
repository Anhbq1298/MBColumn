using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #Qlc
{
	// Token: 0x020007B0 RID: 1968
	[DebuggerDisplay("y = {A}*x + {B}")]
	internal sealed class #Plc
	{
		// Token: 0x06003F15 RID: 16149 RVA: 0x00122AF4 File Offset: 0x00120CF4
		public #Plc(Point #mcb, Point #ncb)
		{
			this.A = (#ncb.Y - #mcb.Y) / (#ncb.X - #mcb.X);
			this.B = #mcb.Y - this.A * #mcb.X;
		}

		// Token: 0x06003F16 RID: 16150 RVA: 0x0003595B File Offset: 0x00033B5B
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "a", Justification = "Maths.")]
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "b", Justification = "Maths.")]
		public #Plc(double #5Gb, double #6Gb)
		{
			this.A = #5Gb;
			this.B = #6Gb;
		}

		// Token: 0x06003F17 RID: 16151 RVA: 0x00122B48 File Offset: 0x00120D48
		public #Plc(Point #tEb, double #Udb)
		{
			double num = Math.Tan(GeometryHelper.#Qmc(#Udb));
			this.A = num;
			this.B = -num * #tEb.X + #tEb.Y;
		}

		// Token: 0x06003F18 RID: 16152 RVA: 0x00035971 File Offset: 0x00033B71
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Maths.")]
		public Point #nlc(double #9o)
		{
			return new Point(#9o, this.A * #9o + this.B);
		}

		// Token: 0x06003F19 RID: 16153 RVA: 0x00122B88 File Offset: 0x00120D88
		public Point? #Klc(#Plc #Llc)
		{
			double num;
			do
			{
				#X0d.#V0d(#Llc, #Phc.#3hc(107372257), Component.Geometry, #Phc.#3hc(107372272));
				num = this.A - #Llc.A;
			}
			while (false);
			if (num == 0.0)
			{
				return null;
			}
			return new Point?(this.#nlc((#Llc.B - this.B) / num));
		}

		// Token: 0x06003F1A RID: 16154 RVA: 0x000359A4 File Offset: 0x00033BA4
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y")]
		public double #llc(double #7W)
		{
			return (this.B - #7W) / -this.A;
		}

		// Token: 0x06003F1B RID: 16155 RVA: 0x00122C1C File Offset: 0x00120E1C
		public unsafe #Plc #Mlc(Point #Ng)
		{
			void* ptr = stackalloc byte[16];
			for (;;)
			{
				*(double*)ptr = -1.0 / this.A;
				while (3 != 0)
				{
					*(double*)(ptr + 8) = #Ng.Y - #Ng.X * *(double*)ptr;
					if (6 != 0)
					{
						goto Block_2;
					}
				}
			}
			Block_2:
			return new #Plc(*(double*)ptr, *(double*)((byte*)ptr + 8));
		}

		// Token: 0x17001324 RID: 4900
		// (get) Token: 0x06003F1C RID: 16156 RVA: 0x000359CA File Offset: 0x00033BCA
		// (set) Token: 0x06003F1D RID: 16157 RVA: 0x000359D6 File Offset: 0x00033BD6
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "A", Justification = "Maths.")]
		public double A { get; private set; }

		// Token: 0x17001325 RID: 4901
		// (get) Token: 0x06003F1E RID: 16158 RVA: 0x000359E7 File Offset: 0x00033BE7
		// (set) Token: 0x06003F1F RID: 16159 RVA: 0x000359F3 File Offset: 0x00033BF3
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "B", Justification = "Maths.")]
		public double B { get; private set; }

		// Token: 0x04001CB8 RID: 7352
		[CompilerGenerated]
		private double #a;

		// Token: 0x04001CB9 RID: 7353
		[CompilerGenerated]
		private double #b;
	}
}
