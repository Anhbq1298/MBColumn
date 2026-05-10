using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #7hc;
using #cYd;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #n6d
{
	// Token: 0x02000F34 RID: 3892
	[SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Class does not own the stream.")]
	[CLSCompliant(false)]
	internal sealed class #m6d : IDisposable
	{
		// Token: 0x060089DC RID: 35292 RVA: 0x0007033A File Offset: 0x0006E53A
		public #m6d(Stream #gp)
		{
			this.#b = new BinaryReader(#gp);
		}

		// Token: 0x17002895 RID: 10389
		// (get) Token: 0x060089DD RID: 35293 RVA: 0x0007035A File Offset: 0x0006E55A
		protected BinaryReader Reader { get; }

		// Token: 0x17002896 RID: 10390
		// (get) Token: 0x060089DE RID: 35294 RVA: 0x00070366 File Offset: 0x0006E566
		// (set) Token: 0x060089DF RID: 35295 RVA: 0x00070372 File Offset: 0x0006E572
		public ushort CurrentSchemaVersion { get; private set; }

		// Token: 0x060089E0 RID: 35296 RVA: 0x001D66A8 File Offset: 0x001D48A8
		public uint #b6d()
		{
			ushort num = this.#h6d();
			if (num != 65535)
			{
				return (uint)num;
			}
			return this.#i6d();
		}

		// Token: 0x060089E1 RID: 35297 RVA: 0x001D66D8 File Offset: 0x001D48D8
		public void #KAc(#E6d #c6d)
		{
			#X0d.#V0d(#c6d, #Phc.#3hc(107222646), Component.AppManager, #Phc.#3hc(107222593));
			ushort num = this.#h6d();
			if (num == 32767)
			{
				this.#i6d();
			}
			if (num == 65535)
			{
				this.CurrentSchemaVersion = this.#h6d();
				ushort #l6d = this.#h6d();
				byte[] array;
				this.#Cjc(out array, (int)#l6d);
				string @string = Encoding.UTF8.GetString(array, 0, array.Length);
				#q6d #q6d = #c6d.GetType().GetCustomAttributes(false).OfType<#q6d>().FirstOrDefault<#q6d>();
				string text = (#q6d != null) ? #q6d.ClassName : null;
				if (string.IsNullOrWhiteSpace(text))
				{
					throw new #B6d(#Phc.#3hc(107222540), #Phc.#3hc(107223027), Component.AppManager, #IYd.#e, #JYd.#a);
				}
				if (!string.Equals(text, @string))
				{
					throw new #B6d(#Phc.#3hc(107222974), #Phc.#3hc(107222861), Component.AppManager, #IYd.#b, #JYd.#b);
				}
			}
			#c6d.#C0d(this);
		}

		// Token: 0x060089E2 RID: 35298 RVA: 0x001D67E8 File Offset: 0x001D49E8
		public float #d6d()
		{
			byte[] array = new byte[4];
			byte[] array2;
			if (!false)
			{
				array2 = array;
			}
			this.Reader.Read(array2, 0, 4);
			return BitConverter.ToSingle(array2, 0);
		}

		// Token: 0x060089E3 RID: 35299 RVA: 0x00070383 File Offset: 0x0006E583
		public byte #e6d()
		{
			return this.Reader.ReadByte();
		}

		// Token: 0x060089E4 RID: 35300 RVA: 0x001D6820 File Offset: 0x001D4A20
		public int #Gic()
		{
			int result;
			this.#Cjc(out result);
			return result;
		}

		// Token: 0x060089E5 RID: 35301 RVA: 0x001D6844 File Offset: 0x001D4A44
		public string #IAc()
		{
			bool flag;
			ulong num = this.#f6d(out flag);
			string result;
			if (flag)
			{
				char[] array = new char[num];
				this.Reader.Read(array, 0, (int)num);
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(array);
				result = stringBuilder.ToString();
			}
			else
			{
				byte[] array2 = new byte[num];
				this.Reader.Read(array2, 0, (int)num);
				result = Encoding.UTF8.GetString(array2, 0, array2.Length);
			}
			return result;
		}

		// Token: 0x060089E6 RID: 35302 RVA: 0x001D68C4 File Offset: 0x001D4AC4
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed.")]
		public ulong #f6d(out bool #g6d)
		{
			#g6d = false;
			byte b = this.#e6d();
			if (b < 255)
			{
				return (ulong)b;
			}
			ushort num = this.#h6d();
			if (num == 65534)
			{
				#g6d = true;
				b = this.#e6d();
				if (b < 255)
				{
					return (ulong)b;
				}
				num = this.#h6d();
			}
			if (num < 65535)
			{
				return (ulong)num;
			}
			uint num2 = this.#i6d();
			if (num2 < 4294967295U)
			{
				return (ulong)num2;
			}
			ulong result;
			this.#Cjc(out result);
			return result;
		}

		// Token: 0x060089E7 RID: 35303 RVA: 0x0007039C File Offset: 0x0006E59C
		public ushort #h6d()
		{
			this.Reader.Read(this.#d, 0, 2);
			return BitConverter.ToUInt16(this.#d, 0);
		}

		// Token: 0x060089E8 RID: 35304 RVA: 0x000703CA File Offset: 0x0006E5CA
		public short #Fic()
		{
			this.Reader.Read(this.#d, 0, 2);
			return BitConverter.ToInt16(this.#d, 0);
		}

		// Token: 0x060089E9 RID: 35305 RVA: 0x001D6940 File Offset: 0x001D4B40
		public uint #i6d()
		{
			byte[] array = new byte[4];
			byte[] array2;
			if (!false)
			{
				array2 = array;
			}
			this.Reader.Read(array2, 0, 4);
			return BitConverter.ToUInt32(array2, 0);
		}

		// Token: 0x060089EA RID: 35306 RVA: 0x001D6978 File Offset: 0x001D4B78
		public void #Cjc(out int #f)
		{
			byte[] array = new byte[4];
			byte[] array2;
			if (!false)
			{
				array2 = array;
			}
			this.Reader.Read(array2, 0, 4);
			#f = BitConverter.ToInt32(array2, 0);
		}

		// Token: 0x060089EB RID: 35307 RVA: 0x001D69B4 File Offset: 0x001D4BB4
		public void #Cjc(out ulong #f)
		{
			byte[] array = new byte[8];
			byte[] array2;
			if (!false)
			{
				array2 = array;
			}
			this.Reader.Read(array2, 0, 8);
			#f = BitConverter.ToUInt64(array2, 0);
		}

		// Token: 0x060089EC RID: 35308 RVA: 0x001D69F0 File Offset: 0x001D4BF0
		public void #Cjc(out long #f)
		{
			byte[] array = new byte[8];
			byte[] array2;
			if (!false)
			{
				array2 = array;
			}
			this.Reader.Read(array2, 0, 8);
			#f = BitConverter.ToInt64(array2, 0);
		}

		// Token: 0x060089ED RID: 35309 RVA: 0x001D6A2C File Offset: 0x001D4C2C
		public double #SAc()
		{
			byte[] array = new byte[8];
			byte[] array2;
			if (!false)
			{
				array2 = array;
			}
			this.Reader.Read(array2, 0, 8);
			return BitConverter.ToDouble(array2, 0);
		}

		// Token: 0x060089EE RID: 35310 RVA: 0x000703F8 File Offset: 0x0006E5F8
		public DateTime #j6d()
		{
			this.#Gic();
			return new DateTime(#D6d.#C6d(this.#SAc()), DateTimeKind.Unspecified);
		}

		// Token: 0x060089EF RID: 35311 RVA: 0x001D6A64 File Offset: 0x001D4C64
		public bool #OAc()
		{
			byte[] array = new byte[1];
			byte[] array2;
			if (!false)
			{
				array2 = array;
			}
			this.Reader.Read(array2, 0, 1);
			return BitConverter.ToBoolean(array2, 0);
		}

		// Token: 0x060089F0 RID: 35312 RVA: 0x001D6A9C File Offset: 0x001D4C9C
		public void #Cjc(out Guid #f)
		{
			byte[] b;
			this.#Cjc(out b, 16);
			#f = new Guid(b);
		}

		// Token: 0x060089F1 RID: 35313 RVA: 0x0007041E File Offset: 0x0006E61E
		public void #Cjc(out byte[] #k6d, int #l6d)
		{
			#k6d = new byte[#l6d];
			this.Reader.Read(#k6d, 0, #l6d);
		}

		// Token: 0x060089F2 RID: 35314 RVA: 0x00070444 File Offset: 0x0006E644
		public void #Cjc(byte[] #k6d, int #1f)
		{
			this.Reader.Read(#k6d, 0, #1f);
		}

		// Token: 0x060089F3 RID: 35315 RVA: 0x00070461 File Offset: 0x0006E661
		protected void #1(bool #POb)
		{
			this.Reader.Dispose();
		}

		// Token: 0x060089F4 RID: 35316 RVA: 0x0007047C File Offset: 0x0006E67C
		public void #1()
		{
			this.#1(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x040038BA RID: 14522
		private const int #a = 0;

		// Token: 0x040038BB RID: 14523
		[CompilerGenerated]
		private readonly BinaryReader #b;

		// Token: 0x040038BC RID: 14524
		[CompilerGenerated]
		private ushort #c;

		// Token: 0x040038BD RID: 14525
		private readonly byte[] #d = new byte[8];
	}
}
