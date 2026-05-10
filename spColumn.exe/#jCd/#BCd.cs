using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using #7hc;
using #Ded;
using #FCd;

namespace #jCd
{
	// Token: 0x020006E7 RID: 1767
	internal abstract class #BCd : #Led
	{
		// Token: 0x06003AA9 RID: 15017 RVA: 0x00032DBB File Offset: 0x00030FBB
		protected #BCd(#uCd #ib)
		{
			if (#ib == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107400797));
			}
			this.#b = #ib;
			this.#a = new #xCd(this.Context);
		}

		// Token: 0x170011F9 RID: 4601
		// (get) Token: 0x06003AAA RID: 15018 RVA: 0x00032DF6 File Offset: 0x00030FF6
		public #uCd Context { get; }

		// Token: 0x170011FA RID: 4602
		// (get) Token: 0x06003AAB RID: 15019 RVA: 0x00032E02 File Offset: 0x00031002
		// (set) Token: 0x06003AAC RID: 15020 RVA: 0x00032E0E File Offset: 0x0003100E
		public bool WriteEmptyHeaders { get; set; }

		// Token: 0x06003AAD RID: 15021 RVA: 0x00032E1F File Offset: 0x0003101F
		public void #bCd(Func<Stream> #En)
		{
			base.#Ked();
			this.#Jed();
			this.#zl(#En);
		}

		// Token: 0x06003AAE RID: 15022 RVA: 0x00032E40 File Offset: 0x00031040
		public void #bCd(Stream #gp)
		{
			base.#Ked();
			this.#Jed();
			if (#gp != null)
			{
				this.#zl(#gp);
			}
		}

		// Token: 0x06003AAF RID: 15023 RVA: 0x00115904 File Offset: 0x00113B04
		public void #zl(Func<Stream> #En)
		{
			base.#Ked();
			using (Stream stream = #En())
			{
				this.#zl(stream);
			}
		}

		// Token: 0x06003AB0 RID: 15024 RVA: 0x00032E64 File Offset: 0x00031064
		public void #zl(Stream #gp)
		{
			base.#Ked();
			this.Context.Sink.#fGd(#gp);
		}

		// Token: 0x06003AB1 RID: 15025 RVA: 0x00115950 File Offset: 0x00113B50
		protected override void #ved(#Red #bLb)
		{
			if (#bLb.IsNoteOnly)
			{
				this.#eCd(#bLb.Notes);
				return;
			}
			if (!\u0003.\u0004(#bLb.Header.Header) || this.WriteEmptyHeaders)
			{
				this.Context.Sink.#cGd(this.#ACd(#bLb.Header.HeaderPath));
			}
			this.#eCd(#bLb.Notes);
			this.#Rcd(#bLb.Header.HeaderPath, #bLb.Table);
			this.Context.Sink.#cGd();
		}

		// Token: 0x06003AB2 RID: 15026 RVA: 0x00032E89 File Offset: 0x00031089
		protected override void #Rcd(string #wy, #uDd #Xpb)
		{
			#Xpb.#npb(this.#a);
		}

		// Token: 0x06003AB3 RID: 15027 RVA: 0x00032EA3 File Offset: 0x000310A3
		private string #ACd(string #f)
		{
			return this.Context.#sCd(\u0015.\u009A(#Phc.#3hc(107251263), #f));
		}

		// Token: 0x06003AB4 RID: 15028 RVA: 0x00115A04 File Offset: 0x00113C04
		private void #eCd(IEnumerable<string> #wed)
		{
			if (#wed != null)
			{
				foreach (string text in #wed)
				{
					if (!string.Equals(text, Environment.NewLine, StringComparison.OrdinalIgnoreCase))
					{
						this.Context.Sink.#dGd(this.#ACd(this.Context.Deformatter.#NBd(text)));
					}
					this.Context.Sink.#cGd();
				}
			}
		}

		// Token: 0x040018FF RID: 6399
		private readonly #xCd #a;

		// Token: 0x04001900 RID: 6400
		[CompilerGenerated]
		private readonly #uCd #b;

		// Token: 0x04001901 RID: 6401
		[CompilerGenerated]
		private bool #c = true;
	}
}
