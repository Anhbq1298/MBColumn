using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.DataExchange.CSV;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Helpers;

namespace StructurePoint.CoreAssets.GUI.Framework.Definitions
{
	// Token: 0x02000CC9 RID: 3273
	public static class DefinitionGridHelper
	{
		// Token: 0x06006AEF RID: 27375 RVA: 0x0019E438 File Offset: 0x0019C638
		public static string #72c(string #82c, PropertyInfo[] #92c)
		{
			DefinitionGridHelper.#GTb #GTb2;
			bool flag2;
			do
			{
				DefinitionGridHelper.#GTb #GTb = new DefinitionGridHelper.#GTb();
				if (5 != 0)
				{
					#GTb2 = #GTb;
				}
				#GTb2.#a = #82c;
				bool flag = string.IsNullOrWhiteSpace(#GTb2.#a);
				while (!flag)
				{
					PropertyInfo propertyInfo = #92c.Select(new Func<PropertyInfo, <>f__AnonymousType1<PropertyInfo, CSVColumnNameAttribute>>(DefinitionGridHelper.<>c.<>9.#4bd)).Where(new Func<<>f__AnonymousType1<PropertyInfo, CSVColumnNameAttribute>, bool>(#GTb2.#3bd)).Select(new Func<<>f__AnonymousType1<PropertyInfo, CSVColumnNameAttribute>, PropertyInfo>(DefinitionGridHelper.<>c.<>9.#5bd)).FirstOrDefault<PropertyInfo>();
					PropertyInfo propertyInfo2;
					if (3 != 0)
					{
						propertyInfo2 = propertyInfo;
					}
					flag2 = (flag = (propertyInfo2 != null));
					if (!false)
					{
						goto Block_4;
					}
				}
			}
			while (false);
			return #GTb2.#a;
			Block_4:
			if (flag2)
			{
				PropertyInfo propertyInfo2;
				return propertyInfo2.Name;
			}
			return #GTb2.#a;
		}

		// Token: 0x06006AF0 RID: 27376 RVA: 0x0019E4F8 File Offset: 0x0019C6F8
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		[SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
		public static string #a3c<#c3c, #d3c>(Expression<Func<#c3c, #d3c>> #b3c)
		{
			string #R0d = #Phc.#3hc(107430759);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107430778);
			if (4 != 0)
			{
				#X0d.#V0d(#b3c, #R0d, #x6c, #Qic);
			}
			string name = #x0d<!!0>.#XYd<#d3c>(#b3c).Name;
			string text;
			if (!false)
			{
				text = name;
			}
			CSVColumnNameAttribute customAttribute = typeof(!!0).GetProperty(text).GetCustomAttribute<CSVColumnNameAttribute>();
			CSVColumnNameAttribute csvcolumnNameAttribute;
			if (!false)
			{
				csvcolumnNameAttribute = customAttribute;
			}
			if (csvcolumnNameAttribute != null)
			{
				return csvcolumnNameAttribute.Name;
			}
			return text;
		}

		// Token: 0x06006AF1 RID: 27377 RVA: 0x0019E564 File Offset: 0x0019C764
		public static bool #e3c<#c3c>(#c3c #f3c, IDictionary<string, object> #g3c)
		{
			if (#f3c == null || #g3c == null)
			{
				return false;
			}
			IEnumerator<KeyValuePair<string, object>> enumerator = #g3c.GetEnumerator();
			IEnumerator<KeyValuePair<string, object>> enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					KeyValuePair<string, object> keyValuePair = enumerator2.Current;
					KeyValuePair<string, object> keyValuePair2;
					if (-1 != 0)
					{
						keyValuePair2 = keyValuePair;
					}
					string key = keyValuePair2.Key;
					string #So;
					if (true)
					{
						#So = key;
					}
					object obj = ReflectionHelper.#E(#f3c, #So);
					object objB;
					if (!false)
					{
						objB = obj;
					}
					if (!object.Equals(keyValuePair2.Value, objB))
					{
						bool flag = true;
						bool result;
						if (7 != 0)
						{
							result = flag;
						}
						return result;
					}
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			return false;
		}

		// Token: 0x02000CCB RID: 3275
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06006AF7 RID: 27383 RVA: 0x0005437F File Offset: 0x0005257F
			internal bool #3bd(<>f__AnonymousType1<PropertyInfo, CSVColumnNameAttribute> #M8c)
			{
				int result;
				if (!false && #M8c.dataExchangeAttribute == null && 3 != 0)
				{
					int num = result = 0;
					if (num == 0)
					{
						return num != 0;
					}
				}
				else
				{
					result = (string.Equals(#M8c.dataExchangeAttribute.Name, this.#a) ? 1 : 0);
				}
				return result != 0;
			}

			// Token: 0x04002BB2 RID: 11186
			public string #a;
		}
	}
}
