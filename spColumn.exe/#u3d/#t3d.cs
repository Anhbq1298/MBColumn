using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using #7hc;

namespace #u3d
{
	// Token: 0x02000EF7 RID: 3831
	[StructLayout(LayoutKind.Explicit, Pack = 2)]
	internal sealed class #t3d
	{
		// Token: 0x060087C5 RID: 34757 RVA: 0x001D1888 File Offset: 0x001CFA88
		public #t3d(int #v3d)
		{
			int num = #v3d % 4;
			#v3d = ((num == 0) ? #v3d : (#v3d + 4 - num));
			this.ByteBuffer = new byte[#v3d];
			this.#a = 0;
		}

		// Token: 0x060087C6 RID: 34758 RVA: 0x0006E5A6 File Offset: 0x0006C7A6
		public #t3d(byte[] #n3d)
		{
			this.#m3d(#n3d);
		}

		// Token: 0x1700283B RID: 10299
		// (get) Token: 0x060087C7 RID: 34759 RVA: 0x0006E5B5 File Offset: 0x0006C7B5
		// (set) Token: 0x060087C8 RID: 34760 RVA: 0x0006E5BD File Offset: 0x0006C7BD
		public byte[] ByteBuffer { get; private set; }

		// Token: 0x1700283C RID: 10300
		// (get) Token: 0x060087C9 RID: 34761 RVA: 0x0006E5C6 File Offset: 0x0006C7C6
		public float[] FloatBuffer { get; }

		// Token: 0x1700283D RID: 10301
		// (get) Token: 0x060087CA RID: 34762 RVA: 0x0006E5CE File Offset: 0x0006C7CE
		public short[] ShortBuffer { get; }

		// Token: 0x1700283E RID: 10302
		// (get) Token: 0x060087CB RID: 34763 RVA: 0x0006E5D6 File Offset: 0x0006C7D6
		public int[] IntBuffer { get; }

		// Token: 0x1700283F RID: 10303
		// (get) Token: 0x060087CC RID: 34764 RVA: 0x0006E5DE File Offset: 0x0006C7DE
		public int MaxSize
		{
			get
			{
				return this.ByteBuffer.Length;
			}
		}

		// Token: 0x17002840 RID: 10304
		// (get) Token: 0x060087CD RID: 34765 RVA: 0x0006E5E8 File Offset: 0x0006C7E8
		// (set) Token: 0x060087CE RID: 34766 RVA: 0x0006E5F0 File Offset: 0x0006C7F0
		public int ByteBufferCount
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.#a = this.#q3d(#Phc.#3hc(107224535), value, 1);
			}
		}

		// Token: 0x17002841 RID: 10305
		// (get) Token: 0x060087CF RID: 34767 RVA: 0x0006E60A File Offset: 0x0006C80A
		// (set) Token: 0x060087D0 RID: 34768 RVA: 0x0006E614 File Offset: 0x0006C814
		public int FloatBufferCount
		{
			get
			{
				return this.#a / 4;
			}
			set
			{
				this.#a = this.#q3d(#Phc.#3hc(107224482), value, 4);
			}
		}

		// Token: 0x17002842 RID: 10306
		// (get) Token: 0x060087D1 RID: 34769 RVA: 0x0006E62E File Offset: 0x0006C82E
		// (set) Token: 0x060087D2 RID: 34770 RVA: 0x0006E638 File Offset: 0x0006C838
		public int ShortBufferCount
		{
			get
			{
				return this.#a / 2;
			}
			set
			{
				this.#a = this.#q3d(#Phc.#3hc(107224457), value, 2);
			}
		}

		// Token: 0x17002843 RID: 10307
		// (get) Token: 0x060087D3 RID: 34771 RVA: 0x0006E60A File Offset: 0x0006C80A
		// (set) Token: 0x060087D4 RID: 34772 RVA: 0x0006E652 File Offset: 0x0006C852
		public int IntBufferCount
		{
			get
			{
				return this.#a / 4;
			}
			set
			{
				this.#a = this.#q3d(#Phc.#3hc(107224464), value, 4);
			}
		}

		// Token: 0x060087D5 RID: 34773 RVA: 0x0006E66C File Offset: 0x0006C86C
		public void #m3d(byte[] #n3d)
		{
			if (7 != 0)
			{
				this.ByteBuffer = #n3d;
			}
			this.#a = 0;
		}

		// Token: 0x060087D6 RID: 34774 RVA: 0x0006E683 File Offset: 0x0006C883
		public static byte[] #2Hc(#t3d #o3d)
		{
			return #o3d.ByteBuffer;
		}

		// Token: 0x060087D7 RID: 34775 RVA: 0x0006E68B File Offset: 0x0006C88B
		public static float[] #2Hc(#t3d #o3d)
		{
			return #o3d.FloatBuffer;
		}

		// Token: 0x060087D8 RID: 34776 RVA: 0x0006E693 File Offset: 0x0006C893
		public static int[] #2Hc(#t3d #o3d)
		{
			return #o3d.IntBuffer;
		}

		// Token: 0x060087D9 RID: 34777 RVA: 0x0006E69B File Offset: 0x0006C89B
		public static short[] #2Hc(#t3d #o3d)
		{
			return #o3d.ShortBuffer;
		}

		// Token: 0x060087DA RID: 34778 RVA: 0x0006E6A3 File Offset: 0x0006C8A3
		public void #yl()
		{
			Array array = this.ByteBuffer;
			int index = 0;
			int length = this.ByteBuffer.Length;
			if (4 != 0)
			{
				Array.Clear(array, index, length);
			}
		}

		// Token: 0x060087DB RID: 34779 RVA: 0x0006E6C1 File Offset: 0x0006C8C1
		public void #Yfd(Array #p3d)
		{
			Array sourceArray = this.ByteBuffer;
			int length = this.#a;
			if (7 != 0)
			{
				Array.Copy(sourceArray, #p3d, length);
			}
		}

		// Token: 0x060087DC RID: 34780 RVA: 0x001D18C0 File Offset: 0x001CFAC0
		private int #q3d(string #r3d, int #f, int #s3d)
		{
			int num = #f * #s3d;
			int num2;
			if (-1 != 0)
			{
				num2 = num;
			}
			if (num2 % 4 != 0)
			{
				throw new ArgumentOutOfRangeException(#r3d, string.Format(#Phc.#3hc(107224443), #r3d, num2));
			}
			if (#f < 0 || #f > this.ByteBuffer.Length / #s3d)
			{
				throw new ArgumentOutOfRangeException(#r3d, string.Format(#Phc.#3hc(107224334), #r3d, this.ByteBuffer.Length / #s3d));
			}
			return num2;
		}

		// Token: 0x04003802 RID: 14338
		[FieldOffset(0)]
		public int #a;

		// Token: 0x04003803 RID: 14339
		[CompilerGenerated]
		[FieldOffset(8)]
		private byte[] #b;

		// Token: 0x04003804 RID: 14340
		[CompilerGenerated]
		[FieldOffset(8)]
		private readonly float[] #c;

		// Token: 0x04003805 RID: 14341
		[CompilerGenerated]
		[FieldOffset(8)]
		private readonly short[] #d;

		// Token: 0x04003806 RID: 14342
		[CompilerGenerated]
		[FieldOffset(8)]
		private readonly int[] #e;
	}
}
