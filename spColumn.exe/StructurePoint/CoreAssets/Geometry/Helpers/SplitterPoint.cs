using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x02000803 RID: 2051
	[DebuggerDisplay("X = {X}, Y = {Y}, Marked = {Marked}")]
	public sealed class SplitterPoint
	{
		// Token: 0x060041CB RID: 16843 RVA: 0x00037324 File Offset: 0x00035524
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x")]
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y")]
		public SplitterPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
			this.Marked = false;
		}

		// Token: 0x060041CC RID: 16844 RVA: 0x000035C3 File Offset: 0x000017C3
		public SplitterPoint()
		{
		}

		// Token: 0x060041CD RID: 16845 RVA: 0x00134394 File Offset: 0x00132594
		public SplitterPoint(SplitterPoint splitterPoint)
		{
			#X0d.#V0d(splitterPoint, #Phc.#3hc(107459118), Component.Geometry, #Phc.#3hc(107459129));
			this.X = splitterPoint.X;
			this.Y = splitterPoint.Y;
			this.Marked = splitterPoint.Marked;
		}

		// Token: 0x17001372 RID: 4978
		// (get) Token: 0x060041CE RID: 16846 RVA: 0x00037341 File Offset: 0x00035541
		// (set) Token: 0x060041CF RID: 16847 RVA: 0x0003734D File Offset: 0x0003554D
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X")]
		public double X { get; set; }

		// Token: 0x17001373 RID: 4979
		// (get) Token: 0x060041D0 RID: 16848 RVA: 0x0003735E File Offset: 0x0003555E
		// (set) Token: 0x060041D1 RID: 16849 RVA: 0x0003736A File Offset: 0x0003556A
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y")]
		public double Y { get; set; }

		// Token: 0x17001374 RID: 4980
		// (get) Token: 0x060041D2 RID: 16850 RVA: 0x0003737B File Offset: 0x0003557B
		// (set) Token: 0x060041D3 RID: 16851 RVA: 0x00037387 File Offset: 0x00035587
		public bool Marked { get; set; }

		// Token: 0x060041D4 RID: 16852 RVA: 0x001343E8 File Offset: 0x001325E8
		public bool #e(SplitterPoint #Muc)
		{
			IL_00:
			while (#Muc != null)
			{
				if (5 != 0)
				{
					double #4gb = this.X;
					double #5gb = #Muc.X;
					while (PointsConverter.#qsc(#4gb, #5gb) && 3 != 0)
					{
						if (false)
						{
							goto IL_00;
						}
						double #4gb2 = #4gb = this.Y;
						double #5gb2 = #5gb = #Muc.Y;
						if (!false)
						{
							return PointsConverter.#qsc(#4gb2, #5gb2);
						}
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x04001DAF RID: 7599
		[CompilerGenerated]
		private double #a;

		// Token: 0x04001DB0 RID: 7600
		[CompilerGenerated]
		private double #b;

		// Token: 0x04001DB1 RID: 7601
		[CompilerGenerated]
		private bool #c;
	}
}
