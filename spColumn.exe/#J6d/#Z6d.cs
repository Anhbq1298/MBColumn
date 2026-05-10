using System;
using System.Collections.Generic;
using #7hc;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #J6d
{
	// Token: 0x02000F42 RID: 3906
	internal static class #Z6d
	{
		// Token: 0x06008A2F RID: 35375 RVA: 0x001D70E0 File Offset: 0x001D52E0
		public static void #k2c(string #So)
		{
			if (string.IsNullOrEmpty(#So))
			{
				throw new ArgumentNullException(#Phc.#3hc(107226730));
			}
			if (Path.IsPathRooted(#So) && !Directory.Exists(Path.GetPathRoot(#So)))
			{
				throw new InvalidOperationException(Strings.StringRootElementOfThePathDoesNotExists.#z2d());
			}
			Stack<string> stack = new Stack<string>();
			while (#So != null && !Directory.Exists(#So))
			{
				string fileName = Path.GetFileName(#So);
				if (string.IsNullOrWhiteSpace(fileName))
				{
					break;
				}
				stack.Push(fileName);
				#So = Path.GetDirectoryName(#So);
			}
			if (string.IsNullOrWhiteSpace(#So) || !Directory.Exists(#So))
			{
				throw new InvalidOperationException(Strings.StringRootElementOfThePathDoesNotExists.#z2d());
			}
			while (stack.Count > 0)
			{
				#So = Path.Combine(new string[]
				{
					#So,
					stack.Pop()
				});
				if (!Directory.Exists(#So))
				{
					Directory.CreateDirectory(#So);
				}
			}
		}
	}
}
