using System;
using System.Globalization;

namespace #wUe
{
	// Token: 0x020012E2 RID: 4834
	internal static class #xUe
	{
		// Token: 0x0600A198 RID: 41368 RVA: 0x00227F34 File Offset: 0x00226134
		public static string #h(this float? #f, string #cA, CultureInfo #6h)
		{
			if (#f != null)
			{
				return #f.Value.ToString(#cA, #6h);
			}
			return string.Empty;
		}
	}
}
