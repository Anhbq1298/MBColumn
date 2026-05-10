using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace #cYd
{
	// Token: 0x02000EB4 RID: 3764
	internal static class #sYd
	{
		// Token: 0x06008601 RID: 34305 RVA: 0x001CC020 File Offset: 0x001CA220
		public static string #nYd(Exception #ob)
		{
			IL_00:
			while (#ob != null)
			{
				#FYd #FYd = #ob as #FYd;
				#FYd #FYd2;
				if (4 != 0)
				{
					#FYd2 = #FYd;
				}
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringBuilder2;
				if (!false)
				{
					stringBuilder2 = stringBuilder;
				}
				while (!false)
				{
					if (#FYd2 == null)
					{
						return stringBuilder2.ToString().Trim();
					}
					if (-1 == 0)
					{
						goto IL_00;
					}
					stringBuilder2.AppendLine(#FYd2.Message);
					#FYd #FYd3 = #FYd2.InnerException as #FYd;
					if (3 != 0)
					{
						#FYd2 = #FYd3;
					}
				}
				break;
			}
			return null;
		}

		// Token: 0x06008602 RID: 34306 RVA: 0x001CC080 File Offset: 0x001CA280
		public static string #oYd(Exception #ob)
		{
			if (#ob != null)
			{
				List<string> list = new List<string>();
				List<string> list2;
				if (!false)
				{
					list2 = list;
				}
				if (true)
				{
					List<string> list3 = list2;
					string message = #ob.Message;
					if (!false)
					{
						list3.Add(message);
					}
					if (!false)
					{
						while (#ob.InnerException != null || 2 == 0)
						{
							List<string> list4 = list2;
							string message2 = #ob.InnerException.Message;
							if (!false)
							{
								list4.Add(message2);
							}
							Exception innerException = #ob.InnerException;
							if (!false)
							{
								#ob = innerException;
							}
						}
						return string.Join(Environment.NewLine, list2.Distinct<string>());
					}
				}
			}
			return null;
		}

		// Token: 0x06008603 RID: 34307 RVA: 0x0006D24E File Offset: 0x0006B44E
		public static IEnumerable<Exception> #pYd(Exception #ob)
		{
			for (;;)
			{
				int num;
				if (7 != 0)
				{
					int num2;
					num = num2;
				}
				if (num != 0)
				{
					if (false)
					{
						goto IL_43;
					}
					if (num != 1)
					{
						break;
					}
					goto IL_3C;
				}
				IL_54:
				if (#ob.InnerException == null)
				{
					goto Block_3;
				}
				yield return #ob.InnerException;
				if (!false)
				{
					continue;
				}
				IL_43:
				#ob = #ob.InnerException;
				goto IL_54;
				IL_3C:
				goto IL_43;
			}
			IL_14:
			yield break;
			Block_3:
			if (3 != 0)
			{
				yield break;
			}
			goto IL_14;
			yield break;
		}

		// Token: 0x06008604 RID: 34308 RVA: 0x001CC0FC File Offset: 0x001CA2FC
		public static string #oYd(Exception #ob, bool #qYd)
		{
			while (!false && (-1 == 0 || #ob != null))
			{
				string text;
				if (#qYd)
				{
					if (6 == 0)
					{
						continue;
					}
					if (#ob.InnerException != null)
					{
						text = string.Empty;
						goto IL_26;
					}
				}
				text = #ob.Message;
				IL_26:
				string text2;
				if (!false)
				{
					text2 = text;
				}
				while (#ob.InnerException != null)
				{
					string text3 = text2 + (string.IsNullOrEmpty(text2) ? string.Empty : Environment.NewLine) + #ob.InnerException.Message;
					if (!false)
					{
						text2 = text3;
					}
					Exception innerException = #ob.InnerException;
					if (8 != 0)
					{
						#ob = innerException;
					}
				}
				return text2;
			}
			return null;
		}

		// Token: 0x06008605 RID: 34309 RVA: 0x001CC17C File Offset: 0x001CA37C
		public static string #rYd(Exception #ob)
		{
			IL_00:
			while (#ob != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringBuilder2;
				if (5 != 0)
				{
					stringBuilder2 = stringBuilder;
				}
				while (#ob != null)
				{
					if (8 == 0)
					{
						goto IL_03;
					}
					bool flag = string.IsNullOrEmpty(#ob.Message);
					bool flag2;
					do
					{
						if (!flag)
						{
							stringBuilder2.AppendLine(#ob.Message);
						}
						if (false)
						{
							goto IL_00;
						}
						flag2 = (flag = string.IsNullOrEmpty(#ob.StackTrace));
					}
					while (2 == 0 || 3 == 0);
					if (!flag2)
					{
						stringBuilder2.AppendLine(#ob.StackTrace);
					}
					stringBuilder2.AppendLine();
					Exception innerException = #ob.InnerException;
					if (5 != 0)
					{
						#ob = innerException;
					}
				}
				return stringBuilder2.ToString();
			}
			IL_03:
			return null;
		}
	}
}
