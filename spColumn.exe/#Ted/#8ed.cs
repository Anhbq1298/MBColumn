using System;
using System.Linq;
using #7hc;

namespace #Ted
{
	// Token: 0x02000D1D RID: 3357
	internal static class #8ed
	{
		// Token: 0x06006E7B RID: 28283 RVA: 0x00058FB4 File Offset: 0x000571B4
		public static string #2ed(int #4jb)
		{
			return #8ed.#d[#4jb];
		}

		// Token: 0x06006E7C RID: 28284 RVA: 0x00058FC1 File Offset: 0x000571C1
		public static string #3ed(int #4jb)
		{
			return #8ed.#b[#4jb];
		}

		// Token: 0x06006E7D RID: 28285 RVA: 0x00058FCE File Offset: 0x000571CE
		public static string #4ed(int #4jb)
		{
			return #8ed.#c[#4jb];
		}

		// Token: 0x06006E7E RID: 28286 RVA: 0x00058FDB File Offset: 0x000571DB
		private static string #5ed(int #4jb)
		{
			return \u0005\u0002.\u0005\u0004(\u0097\u0002.\u0008\u0006(), #Phc.#3hc(107253696), new object[]
			{
				#4jb
			});
		}

		// Token: 0x06006E7F RID: 28287 RVA: 0x00059016 File Offset: 0x00057216
		private static string #6ed(int #4jb)
		{
			return \u0005\u0002.\u0005\u0004(\u0097\u0002.\u0008\u0006(), #Phc.#3hc(107253695), new object[]
			{
				#4jb
			});
		}

		// Token: 0x06006E80 RID: 28288 RVA: 0x00059051 File Offset: 0x00057251
		private static string #7ed(int #4jb)
		{
			return \u0005\u0002.\u0005\u0004(\u0097\u0002.\u0008\u0006(), #Phc.#3hc(107253642), new object[]
			{
				#4jb
			});
		}

		// Token: 0x04002C71 RID: 11377
		private const int #a = 501;

		// Token: 0x04002C72 RID: 11378
		private static readonly string[] #b = \u008E\u0002.\u009A\u0005(0, 501).Select(new Func<int, string>(#8ed.#6ed)).ToArray<string>();

		// Token: 0x04002C73 RID: 11379
		private static readonly string[] #c = \u008E\u0002.\u009A\u0005(0, 501).Select(new Func<int, string>(#8ed.#5ed)).ToArray<string>();

		// Token: 0x04002C74 RID: 11380
		private static readonly string[] #d = \u008E\u0002.\u009A\u0005(0, 501).Select(new Func<int, string>(#8ed.#7ed)).ToArray<string>();
	}
}
