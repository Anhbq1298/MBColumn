using System;

namespace StructurePoint.CoreAssets.Logger
{
	// Token: 0x02000F15 RID: 3861
	public static class Ignore
	{
		// Token: 0x06008977 RID: 35191 RVA: 0x001D5F4C File Offset: 0x001D414C
		public static bool #14d<#34d>(Action #nd, ILogger #24d = null) where #34d : Exception
		{
			bool result;
			try
			{
				#nd();
				bool flag = true;
				if (4 != 0)
				{
					result = flag;
				}
			}
			catch (!!0 !!)
			{
				#34d #34d = (!!0)((object)!!);
				if (#24d != null)
				{
					#24d.Log(LoggingLevel.Debug, new Func<string>(Ignore.<>c__0<!!0>.<>9.#c5d), #34d);
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06008978 RID: 35192 RVA: 0x001D5FBC File Offset: 0x001D41BC
		public static bool #14d<#34d, #d3c>(Func<#d3c> #4Xd, out #d3c #PE, ILogger #24d = null) where #34d : Exception
		{
			#PE = default(!!1);
			bool result;
			try
			{
				#PE = #4Xd();
				result = true;
			}
			catch (!!0 !!)
			{
				#34d #34d = (!!0)((object)!!);
				if (#24d != null)
				{
					#24d.Log(LoggingLevel.Debug, new Func<string>(Ignore.<>c__1<!!0, !!1>.<>9.#d5d), #34d);
				}
				result = false;
			}
			return result;
		}
	}
}
