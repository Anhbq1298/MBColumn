using System;
using System.Globalization;
using System.IO;
using System.Text;
using #7hc;
using CsvHelper;
using CsvHelper.Configuration;

namespace #xKe
{
	// Token: 0x0200126E RID: 4718
	internal sealed class #1Ke : IDisposable, #fLe
	{
		// Token: 0x06009E59 RID: 40537 RVA: 0x00219420 File Offset: 0x00217620
		public #1Ke(string #So, string #2Ke = ",")
		{
			if (#So == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107226730));
			}
			if (#2Ke == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107313384));
			}
			this.#b = new StreamWriter(new FileStream(#So, FileMode.Create, FileAccess.ReadWrite, FileShare.None), Encoding.ASCII, 15359);
			CsvSerializer serializer = new CsvSerializer(this.#b, this.#ZKe(#2Ke), false);
			this.#a = new CsvWriter(serializer);
		}

		// Token: 0x06009E5A RID: 40538 RVA: 0x00219498 File Offset: 0x00217698
		public #1Ke(Stream #gp, string #2Ke = ",")
		{
			if (#gp == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107377314));
			}
			if (#2Ke == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107313384));
			}
			this.#b = new StreamWriter(#gp, Encoding.ASCII, 15359);
			CsvSerializer serializer = new CsvSerializer(this.#b, this.#ZKe(#2Ke), true);
			this.#a = new CsvWriter(serializer);
		}

		// Token: 0x06009E5B RID: 40539 RVA: 0x00219508 File Offset: 0x00217708
		public void #npb(params string[] #Qb)
		{
			if (#Qb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107377120));
			}
			foreach (string field in #Qb)
			{
				this.#a.WriteField(field);
			}
			this.#a.NextRecord();
		}

		// Token: 0x06009E5C RID: 40540 RVA: 0x00219554 File Offset: 0x00217754
		public void #npb(params float[] #Qb)
		{
			if (#Qb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107377120));
			}
			foreach (float num in #Qb)
			{
				this.#a.WriteField(num.ToString(#Phc.#3hc(107313756), CultureInfo.InvariantCulture));
			}
			this.#a.NextRecord();
		}

		// Token: 0x06009E5D RID: 40541 RVA: 0x0007CAAD File Offset: 0x0007ACAD
		protected void #1(bool #POb)
		{
			if (#POb)
			{
				this.#b.Flush();
				this.#a.Dispose();
			}
		}

		// Token: 0x06009E5E RID: 40542 RVA: 0x0007CAC8 File Offset: 0x0007ACC8
		public void #1()
		{
			this.#1(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06009E5F RID: 40543 RVA: 0x0007CAD7 File Offset: 0x0007ACD7
		private CsvConfiguration #ZKe(string #0Ke)
		{
			return new CsvConfiguration
			{
				Delimiter = #0Ke,
				HasHeaderRecord = false,
				Encoding = Encoding.ASCII,
				CultureInfo = CultureInfo.InvariantCulture
			};
		}

		// Token: 0x0400446E RID: 17518
		private readonly CsvWriter #a;

		// Token: 0x0400446F RID: 17519
		private readonly StreamWriter #b;

		// Token: 0x04004470 RID: 17520
		private const int #c = 15359;
	}
}
