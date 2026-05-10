using System;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace #2hc
{
	// Token: 0x02000747 RID: 1863
	internal sealed class #1hc
	{
		// Token: 0x06003CB9 RID: 15545 RVA: 0x0011ACA4 File Offset: 0x00118EA4
		internal static void \u0001()
		{
			try
			{
				AppDomain.CurrentDomain.ResourceResolve += #1hc.\u0001;
			}
			catch
			{
			}
		}

		// Token: 0x06003CBA RID: 15546 RVA: 0x0011ACE4 File Offset: 0x00118EE4
		private static Assembly \u0001(object A_0, ResolveEventArgs A_1)
		{
			if (#1hc.\u0001 == null)
			{
				string[] u = #1hc.\u0001;
				bool flag = false;
				bool flag2;
				if (true)
				{
					flag2 = flag;
				}
				try
				{
					Monitor.Enter(u, ref flag2);
					#1hc.\u0001 = Assembly.Load("{656bf1f0-d819-4bda-9983-c89f7f000f80}, PublicKeyToken=3e56350693f7355e");
					if (#1hc.\u0001 != null)
					{
						#1hc.\u0001 = #1hc.\u0001.GetManifestResourceNames();
					}
				}
				finally
				{
					if (flag2)
					{
						Monitor.Exit(u);
					}
				}
			}
			if (!#1hc.\u0001.Contains(A_1.Name))
			{
				return null;
			}
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (!A_1.RequestingAssembly.Equals(executingAssembly))
			{
				return null;
			}
			return #1hc.\u0001;
		}

		// Token: 0x04001B71 RID: 7025
		private static Assembly \u0001;

		// Token: 0x04001B72 RID: 7026
		private static string[] \u0001 = new string[0];
	}
}
