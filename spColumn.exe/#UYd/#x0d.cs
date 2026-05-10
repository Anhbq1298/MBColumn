using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #UYd
{
	// Token: 0x02000ED4 RID: 3796
	internal static class #x0d<#Fu>
	{
		// Token: 0x060086D1 RID: 34513 RVA: 0x001CE994 File Offset: 0x001CCB94
		[SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static PropertyInfo #XYd<#d3c>(Expression<Func<#Fu, #d3c>> #b3c)
		{
			while (!false)
			{
				string #R0d = #Phc.#3hc(107430759);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107227070);
				if (!false)
				{
					#X0d.#V0d(#b3c, #R0d, #x6c, #Qic);
				}
				if (3 == 0)
				{
				}
				if (!false)
				{
					if (!false)
					{
						if (#b3c != null)
						{
							Expression body = #b3c.Body;
							if (4 == 0)
							{
								break;
							}
							Expression expression = body;
							break;
						}
						else
						{
							Expression expression;
							if (!false)
							{
								expression = #b3c;
							}
							IL_3F:
							if (expression.NodeType == ExpressionType.MemberAccess)
							{
								return (PropertyInfo)((MemberExpression)expression).Member;
							}
						}
					}
					throw new InvalidOperationException();
				}
			}
			goto IL_3F;
		}
	}
}
