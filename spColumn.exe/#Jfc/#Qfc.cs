using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using #Cfc;
using #Ddc;
using #ufc;
using #yfc;

namespace #Jfc
{
	// Token: 0x0200071B RID: 1819
	internal sealed class #Qfc
	{
		// Token: 0x06003BE0 RID: 15328 RVA: 0x00118F34 File Offset: 0x00117134
		internal #Qfc(#zfc A_1)
		{
			this.#Lfc(A_1.#b);
			this.#b = A_1.#c;
			this.#c = A_1.#d;
			this.#SC(A_1.#m.#d);
			this.#Pfc(A_1.#m.#b);
			Marshal.SizeOf(typeof(#zfc));
			Marshal.SizeOf(typeof(#Afc));
			Marshal.SizeOf(typeof(#Ffc));
			try
			{
				#Afc #l = A_1.#l;
				this.#f = new uint?(#l.#i);
				this.#d = new DateTime?(#Gdc.#Edc(#l.#c));
				this.#e = new DateTime?(#Gdc.#Edc(#l.#b));
				this.#g = #l.#d;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06003BE1 RID: 15329 RVA: 0x00119024 File Offset: 0x00117224
		internal #Qfc(#vfc A_1)
		{
			this.#Lfc(A_1.#b);
			this.#b = A_1.#c;
			this.#c = A_1.#d;
			this.#SC(A_1.#m.#d);
			this.#Pfc(A_1.#m.#b);
			try
			{
				Marshal.SizeOf(typeof(#vfc));
				Marshal.SizeOf(typeof(#wfc));
				Marshal.SizeOf(typeof(#Ffc));
				#wfc #l = A_1.#l;
				this.#f = new uint?(#l.#i);
				this.#d = new DateTime?(#Gdc.#Edc((long)#l.#c));
				this.#e = new DateTime?(#Gdc.#Edc((long)#l.#b));
				this.#g = #l.#d;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06003BE2 RID: 15330 RVA: 0x00033AE0 File Offset: 0x00031CE0
		[CompilerGenerated]
		public int #Kfc()
		{
			return this.#a;
		}

		// Token: 0x06003BE3 RID: 15331 RVA: 0x00033AEC File Offset: 0x00031CEC
		[CompilerGenerated]
		public void #Lfc(int A_1)
		{
			this.#a = A_1;
		}

		// Token: 0x06003BE4 RID: 15332 RVA: 0x00033AFD File Offset: 0x00031CFD
		[CompilerGenerated]
		public int #Mfc()
		{
			return this.#b;
		}

		// Token: 0x06003BE5 RID: 15333 RVA: 0x00033B09 File Offset: 0x00031D09
		[CompilerGenerated]
		public int #Nfc()
		{
			return this.#c;
		}

		// Token: 0x06003BE6 RID: 15334 RVA: 0x00033B15 File Offset: 0x00031D15
		[CompilerGenerated]
		public string #x()
		{
			return this.#h;
		}

		// Token: 0x06003BE7 RID: 15335 RVA: 0x00033B21 File Offset: 0x00031D21
		[CompilerGenerated]
		public void #SC(string A_1)
		{
			this.#h = A_1;
		}

		// Token: 0x06003BE8 RID: 15336 RVA: 0x00033B32 File Offset: 0x00031D32
		[CompilerGenerated]
		public string #Ofc()
		{
			return this.#i;
		}

		// Token: 0x06003BE9 RID: 15337 RVA: 0x00033B3E File Offset: 0x00031D3E
		[CompilerGenerated]
		public void #Pfc(string A_1)
		{
			this.#i = A_1;
		}

		// Token: 0x06003BEA RID: 15338 RVA: 0x00033B4F File Offset: 0x00031D4F
		public string #h()
		{
			return \u007F.\u0011\u0002(this);
		}

		// Token: 0x04001B16 RID: 6934
		[CompilerGenerated]
		private int #a;

		// Token: 0x04001B17 RID: 6935
		[CompilerGenerated]
		private readonly int #b;

		// Token: 0x04001B18 RID: 6936
		[CompilerGenerated]
		private readonly int #c;

		// Token: 0x04001B19 RID: 6937
		[CompilerGenerated]
		private readonly DateTime? #d;

		// Token: 0x04001B1A RID: 6938
		[CompilerGenerated]
		private readonly DateTime? #e;

		// Token: 0x04001B1B RID: 6939
		[CompilerGenerated]
		private readonly uint? #f;

		// Token: 0x04001B1C RID: 6940
		[CompilerGenerated]
		private readonly int #g;

		// Token: 0x04001B1D RID: 6941
		[CompilerGenerated]
		private string #h;

		// Token: 0x04001B1E RID: 6942
		[CompilerGenerated]
		private string #i;
	}
}
