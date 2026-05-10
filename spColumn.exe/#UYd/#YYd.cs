using System;
using System.Management;
using #7hc;

namespace #UYd
{
	// Token: 0x02000EC7 RID: 3783
	internal static class #YYd
	{
		// Token: 0x06008661 RID: 34401 RVA: 0x001CC9A8 File Offset: 0x001CABA8
		public static string #VYd()
		{
			if (4 != 0)
			{
				bool flag = string.IsNullOrWhiteSpace(#YYd.#a);
				while (flag)
				{
					bool flag2 = flag = (107227143 != 0);
					if (flag2)
					{
						flag = #YYd.#XYd(#Phc.#3hc(flag2 ? 1 : 0), #Phc.#3hc(107227154), out #YYd.#a);
					}
					if (!false)
					{
						goto IL_3A;
					}
				}
				return #YYd.#a;
			}
			IL_3A:
			return #YYd.#a;
		}

		// Token: 0x06008662 RID: 34402 RVA: 0x0006D648 File Offset: 0x0006B848
		public static bool #WYd()
		{
			return string.Equals(#YYd.#VYd(), #Phc.#3hc(107227617));
		}

		// Token: 0x06008663 RID: 34403 RVA: 0x001CC9F4 File Offset: 0x001CABF4
		public static bool #XYd(string #6cc, string #em, out string #f)
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(#Phc.#3hc(107227632) + #6cc);
			ManagementObjectSearcher managementObjectSearcher2;
			if (!false)
			{
				managementObjectSearcher2 = managementObjectSearcher;
			}
			try
			{
				#f = null;
				ManagementObjectCollection managementObjectCollection = managementObjectSearcher2.Get();
				try
				{
					ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							ManagementBaseObject managementBaseObject = enumerator.Current;
							PropertyDataCollection.PropertyDataEnumerator enumerator2 = managementBaseObject.Properties.GetEnumerator();
							PropertyDataCollection.PropertyDataEnumerator propertyDataEnumerator;
							if (8 != 0)
							{
								propertyDataEnumerator = enumerator2;
							}
							try
							{
								int num;
								PropertyData propertyData2;
								do
								{
									bool flag = (num = (propertyDataEnumerator.MoveNext() ? 1 : 0)) != 0;
									if (3 == 0)
									{
										goto IL_77;
									}
									if (!flag)
									{
										goto Block_11;
									}
									PropertyData propertyData = propertyDataEnumerator.Current;
									if (2 != 0)
									{
										propertyData2 = propertyData;
									}
								}
								while (!(propertyData2.Name == #em));
								object value = propertyData2.Value;
								#f = ((value != null) ? value.ToString() : null);
								num = 1;
								IL_77:
								bool result;
								if (6 != 0)
								{
									result = (num != 0);
								}
								return result;
								Block_11:;
							}
							finally
							{
								do
								{
									IDisposable disposable = propertyDataEnumerator as IDisposable;
									if (disposable != null)
									{
										disposable.Dispose();
									}
								}
								while (false);
							}
						}
					}
					finally
					{
						if (false || enumerator != null)
						{
							((IDisposable)enumerator).Dispose();
						}
					}
				}
				finally
				{
					if (managementObjectCollection != null && -1 != 0)
					{
						((IDisposable)managementObjectCollection).Dispose();
					}
				}
			}
			finally
			{
				if (managementObjectSearcher2 != null)
				{
					((IDisposable)managementObjectSearcher2).Dispose();
				}
			}
			return false;
		}

		// Token: 0x040037A6 RID: 14246
		private static string #a;
	}
}
