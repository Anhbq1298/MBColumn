using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using #o1d;

namespace #wqe
{
	// Token: 0x0200115F RID: 4447
	internal sealed class #Yqe : IDisposable
	{
		// Token: 0x06009684 RID: 38532 RVA: 0x00077EFC File Offset: 0x000760FC
		public #Yqe()
		{
			this.#b = Path.GetTempFileName();
			this.#a = new Lazy<FileStream>(new Func<FileStream>(this.#NWb), LazyThreadSafetyMode.ExecutionAndPublication);
		}

		// Token: 0x17002B91 RID: 11153
		// (get) Token: 0x06009685 RID: 38533 RVA: 0x00077F27 File Offset: 0x00076127
		public Stream Stream
		{
			get
			{
				return this.#a.Value;
			}
		}

		// Token: 0x06009686 RID: 38534 RVA: 0x00077F34 File Offset: 0x00076134
		public void #yJ()
		{
			this.Stream.SetLength(0L);
			this.Stream.#i2d();
		}

		// Token: 0x06009687 RID: 38535 RVA: 0x00077F4F File Offset: 0x0007614F
		public void #1()
		{
			this.#Xqe();
			GC.SuppressFinalize(this);
		}

		// Token: 0x06009688 RID: 38536 RVA: 0x001FBE2C File Offset: 0x001FA02C
		public void #77c(Stream #L0)
		{
			long position = this.Stream.Position;
			this.Stream.#i2d();
			this.Stream.CopyTo(#L0);
			if (position >= 0L)
			{
				this.Stream.Seek(position, SeekOrigin.Begin);
			}
		}

		// Token: 0x06009689 RID: 38537 RVA: 0x001FBE70 File Offset: 0x001FA070
		private void #Xqe()
		{
			this.Stream.Dispose();
			try
			{
				if (File.Exists(this.#b))
				{
					File.Delete(this.#b);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600968A RID: 38538 RVA: 0x001FBEB8 File Offset: 0x001FA0B8
		protected void #o7d()
		{
			try
			{
				this.#Xqe();
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x0600968B RID: 38539 RVA: 0x00077F5D File Offset: 0x0007615D
		[CompilerGenerated]
		private FileStream #NWb()
		{
			return File.Open(this.#b, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
		}

		// Token: 0x04004081 RID: 16513
		private readonly Lazy<FileStream> #a;

		// Token: 0x04004082 RID: 16514
		private readonly string #b;
	}
}
