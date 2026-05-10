using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Units.Formatters;

namespace #Aae
{
	// Token: 0x02000FB0 RID: 4016
	internal class #zae : #Kae, IUnitValueFormatter
	{
		// Token: 0x06008BB6 RID: 35766 RVA: 0x00071A83 File Offset: 0x0006FC83
		private #zae()
		{
			this.#a = 1000000.0;
			this.GridAlignment = UnitValueAlignment.#b;
		}

		// Token: 0x06008BB7 RID: 35767 RVA: 0x00071AA1 File Offset: 0x0006FCA1
		public #zae(int #8W, string #vVh = null) : this()
		{
			this.#f = #8W;
			this.#c = #vVh;
			this.#xae(this.#f, #vVh);
		}

		// Token: 0x06008BB8 RID: 35768 RVA: 0x00071AC4 File Offset: 0x0006FCC4
		public #zae(int #8W, double #Bae, string #vVh = null)
		{
			this.#f = #8W;
			this.#a = #Bae;
			this.#c = #vVh;
			this.#xae(this.#f, #vVh);
		}

		// Token: 0x06008BB9 RID: 35769 RVA: 0x00071AEE File Offset: 0x0006FCEE
		public #zae(int #8W, bool #Cae, string #vVh = null) : this()
		{
			this.#f = #8W;
			this.#b = #Cae;
			this.#c = #vVh;
			this.#xae(this.#f, #vVh);
		}

		// Token: 0x170028D6 RID: 10454
		// (get) Token: 0x06008BBA RID: 35770 RVA: 0x00071B18 File Offset: 0x0006FD18
		// (set) Token: 0x06008BBB RID: 35771 RVA: 0x00071B24 File Offset: 0x0006FD24
		public int Precision
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					this.#xae(value, this.#c);
					this.#Fkb(#Phc.#3hc(107380928));
				}
			}
		}

		// Token: 0x170028D7 RID: 10455
		// (get) Token: 0x06008BBC RID: 35772 RVA: 0x00071B58 File Offset: 0x0006FD58
		// (set) Token: 0x06008BBD RID: 35773 RVA: 0x00071B64 File Offset: 0x0006FD64
		public UnitValueAlignment GridAlignment { get; set; }

		// Token: 0x06008BBE RID: 35774 RVA: 0x00071B75 File Offset: 0x0006FD75
		public double Round(double value)
		{
			return Math.Round(value, this.Precision);
		}

		// Token: 0x06008BBF RID: 35775 RVA: 0x001DD644 File Offset: 0x001DB844
		public virtual string CreateDisplayValue(string boundValue)
		{
			double num;
			string text = double.TryParse(boundValue, out num) ? this.CreateDisplayValue(num) : boundValue;
			if (!this.#b || num >= this.#a)
			{
				return text;
			}
			return text.#02d();
		}

		// Token: 0x06008BC0 RID: 35776 RVA: 0x001DD68C File Offset: 0x001DB88C
		public virtual string CreateDisplayValue(double value)
		{
			if (Math.Abs(value) < this.#a)
			{
				if (!string.IsNullOrWhiteSpace(this.#d))
				{
					return value.ToString(this.#d, CultureInfo.CurrentCulture);
				}
				return value.ToString(CultureInfo.CurrentCulture);
			}
			else
			{
				if (!string.IsNullOrWhiteSpace(this.#e))
				{
					return value.ToString(this.#e, CultureInfo.CurrentCulture);
				}
				return value.ToString(CultureInfo.CurrentCulture);
			}
		}

		// Token: 0x06008BC1 RID: 35777 RVA: 0x000143CE File Offset: 0x000125CE
		public string CreateBoundValue(string displayValue)
		{
			return displayValue;
		}

		// Token: 0x06008BC2 RID: 35778 RVA: 0x001DD70C File Offset: 0x001DB90C
		private void #xae(int #yae, string #vVh)
		{
			this.#f = #yae;
			this.#d = #Phc.#3hc(107455038) + #yae.ToString(CultureInfo.InvariantCulture);
			this.#e = (string.IsNullOrWhiteSpace(#vVh) ? (#Phc.#3hc(107386851) + #yae.ToString(CultureInfo.InvariantCulture)) : #vVh);
		}

		// Token: 0x040039FD RID: 14845
		private readonly double #a;

		// Token: 0x040039FE RID: 14846
		private readonly bool #b;

		// Token: 0x040039FF RID: 14847
		private string #c;

		// Token: 0x04003A00 RID: 14848
		private string #d;

		// Token: 0x04003A01 RID: 14849
		private string #e;

		// Token: 0x04003A02 RID: 14850
		private int #f;

		// Token: 0x04003A03 RID: 14851
		[CompilerGenerated]
		private UnitValueAlignment #g;
	}
}
