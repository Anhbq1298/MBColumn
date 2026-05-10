using System;
using System.Reflection;

namespace #pXd
{
	// Token: 0x02000EA1 RID: 3745
	internal static class #IXd
	{
		// Token: 0x060085C5 RID: 34245 RVA: 0x001CBCF4 File Offset: 0x001C9EF4
		public static bool #ntb<#Fu>(#Fu #GXd, #Fu #HXd)
		{
			while (#HXd != null || #GXd != null)
			{
				int num2;
				PropertyInfo[] array;
				if (#GXd == null || #HXd == null)
				{
					int num = num2 = 0;
					if (num == 0)
					{
						return num != 0;
					}
				}
				else
				{
					PropertyInfo[] properties = typeof(!!0).GetProperties(BindingFlags.Instance | BindingFlags.Public);
					if (!false)
					{
						array = properties;
					}
					num2 = 0;
				}
				int i;
				if (3 != 0)
				{
					i = num2;
				}
				if (!false)
				{
					while (i < array.Length)
					{
						PropertyInfo propertyInfo = array[i];
						object value = propertyInfo.GetValue(#GXd, null);
						object obj;
						if (4 != 0)
						{
							obj = value;
						}
						object value2 = propertyInfo.GetValue(#HXd, null);
						object obj2;
						if (!false)
						{
							obj2 = value2;
						}
						if (obj != null || obj2 != null)
						{
							if (obj != null)
							{
								if (false)
								{
									goto IL_86;
								}
								if (obj2 != null)
								{
									if (!obj.Equals(obj2))
									{
										return false;
									}
									goto IL_86;
								}
							}
							return false;
						}
						IL_86:
						int num3 = i + 1;
						if (!false)
						{
							i = num3;
						}
					}
					return true;
				}
			}
			return true;
		}
	}
}
