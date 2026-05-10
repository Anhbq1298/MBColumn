using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using #7hc;
using #UYd;
using Microsoft.CSharp.RuntimeBinder;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.Infrastructure.Helpers
{
	// Token: 0x02000ED1 RID: 3793
	public static class ReflectionHelper
	{
		// Token: 0x060086B9 RID: 34489 RVA: 0x001CDF20 File Offset: 0x001CC120
		[SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags")]
		public static FieldInfo #f0d(this Type #C, string #wy, BindingFlags #g0d)
		{
			FieldInfo fieldInfo;
			if (7 != 0 && !false)
			{
				if (#C == null)
				{
					return null;
				}
				FieldInfo field = #C.GetField(#wy, #g0d);
				if (5 != 0)
				{
					fieldInfo = field;
				}
			}
			if (fieldInfo == null && #C.BaseType != null)
			{
				return #C.BaseType.#f0d(#wy, #g0d);
			}
			return fieldInfo;
		}

		// Token: 0x060086BA RID: 34490 RVA: 0x0006D9F9 File Offset: 0x0006BBF9
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "item", Justification = "Required for the ease of use of the generics.")]
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Required for the ease of use of the generics.")]
		[SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Required for the ease of use of the generics.")]
		public static string #h0d<#Zoc, #j0d>(this #Zoc #Rf, Expression<Func<#Zoc, #j0d>> #i0d)
		{
			return ReflectionHelper.#h0d(#i0d);
		}

		// Token: 0x060086BB RID: 34491 RVA: 0x001CDF74 File Offset: 0x001CC174
		public static MemberExpression #k0d(Expression #i0d)
		{
			MemberExpression memberExpression = #i0d as MemberExpression;
			MemberExpression memberExpression2;
			if (5 != 0)
			{
				memberExpression2 = memberExpression;
			}
			if (memberExpression2 != null)
			{
				return memberExpression2;
			}
			LambdaExpression lambdaExpression = #i0d as LambdaExpression;
			LambdaExpression lambdaExpression2;
			if (3 != 0)
			{
				lambdaExpression2 = lambdaExpression;
			}
			if (lambdaExpression2 != null)
			{
				if (2 != 0)
				{
					MemberExpression memberExpression3 = lambdaExpression2.Body as MemberExpression;
					if (2 != 0)
					{
						memberExpression2 = memberExpression3;
					}
					if (memberExpression2 != null)
					{
						return memberExpression2;
					}
				}
				UnaryExpression unaryExpression = lambdaExpression2.Body as UnaryExpression;
				UnaryExpression unaryExpression2;
				if (!false)
				{
					unaryExpression2 = unaryExpression;
				}
				if (unaryExpression2 != null)
				{
					return (MemberExpression)unaryExpression2.Operand;
				}
			}
			return null;
		}

		// Token: 0x060086BC RID: 34492 RVA: 0x001CDFE0 File Offset: 0x001CC1E0
		public static string #h0d(Expression #i0d)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2;
			if (!false)
			{
				stringBuilder2 = stringBuilder;
			}
			MemberExpression memberExpression = ReflectionHelper.#k0d(#i0d);
			MemberExpression memberExpression2;
			if (6 != 0)
			{
				memberExpression2 = memberExpression;
			}
			for (;;)
			{
				if (stringBuilder2.Length > 0)
				{
					stringBuilder2.Insert(0, string.Empty.#z2d());
				}
				stringBuilder2.Insert(0, memberExpression2.Member.Name);
				MemberExpression memberExpression3 = ReflectionHelper.#k0d(memberExpression2.Expression);
				if (!false)
				{
					memberExpression2 = memberExpression3;
				}
				while (memberExpression2 == null)
				{
					if (!false)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			return stringBuilder2.ToString();
		}

		// Token: 0x060086BD RID: 34493 RVA: 0x001CE054 File Offset: 0x001CC254
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static string #M4c(LambdaExpression #l0d)
		{
			MemberExpression memberExpression2;
			if (#l0d == null)
			{
				if (!false)
				{
					throw new ArgumentNullException(#Phc.#3hc(107451006));
				}
			}
			else if (6 != 0)
			{
				MemberExpression memberExpression = #l0d.Body as MemberExpression;
				if (!false)
				{
					memberExpression2 = memberExpression;
				}
				if (!(((memberExpression2 != null || false) ? memberExpression2.Expression : null) is ConstantExpression))
				{
					return null;
				}
			}
			return memberExpression2.Member.Name;
		}

		// Token: 0x060086BE RID: 34494 RVA: 0x001CE0B0 File Offset: 0x001CC2B0
		[SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static string #M4c<#d3c>(Expression<Func<#d3c>> #b3c)
		{
			if (#b3c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107430759));
			}
			do
			{
				if (false)
				{
				}
				if (false)
				{
					goto IL_21;
				}
			}
			while (false);
			Expression expression;
			if (#b3c == null)
			{
				if (4 == 0)
				{
					goto IL_35;
				}
				expression = #b3c;
				goto IL_35;
			}
			IL_21:
			Expression body = #b3c.Body;
			if (!false)
			{
				expression = body;
			}
			if (!true)
			{
				goto IL_3F;
			}
			IL_35:
			if (expression.NodeType != ExpressionType.MemberAccess)
			{
				throw new InvalidOperationException();
			}
			IL_3F:
			return ((MemberExpression)expression).Member.Name;
		}

		// Token: 0x060086BF RID: 34495 RVA: 0x001CE11C File Offset: 0x001CC31C
		public static object #E(object #Rf, string #So)
		{
			if (#Rf != null)
			{
				if (#So == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107226730));
				}
				Type type = #Rf.GetType();
				Type type2;
				if (4 != 0)
				{
					type2 = type;
				}
				string[] array = #So.Split(new char[]
				{
					'.'
				});
				string[] array2;
				if (!false)
				{
					array2 = array;
				}
				if (false)
				{
					goto IL_9D;
				}
				int num = 0;
				int num2;
				if (7 != 0)
				{
					num2 = num;
				}
				IL_56:
				if (-1 != 0)
				{
					goto IL_F1;
				}
				goto IL_03;
				IL_9D:
				CallSite<Func<CallSite, object, object>> callSite;
				IDynamicMetaObjectProvider dynamicMetaObjectProvider;
				#Rf = callSite.Target(callSite, dynamicMetaObjectProvider);
				IL_DD:
				if (!true)
				{
					goto IL_56;
				}
				if (#Rf == null)
				{
					return #Rf;
				}
				IL_E6:
				type2 = #Rf.GetType();
				num2++;
				IL_F1:
				if (num2 < array2.Length)
				{
					string text = array2[num2];
					string name;
					if (!false)
					{
						name = text;
					}
					IDynamicMetaObjectProvider dynamicMetaObjectProvider2 = #Rf as IDynamicMetaObjectProvider;
					if (-1 != 0)
					{
						dynamicMetaObjectProvider = dynamicMetaObjectProvider2;
					}
					if (dynamicMetaObjectProvider != null)
					{
						CallSite<Func<CallSite, object, object>> callSite2 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, name, type2, new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
						if (false)
						{
							goto IL_9D;
						}
						callSite = callSite2;
						goto IL_9D;
					}
					else
					{
						PropertyInfo property = type2.GetProperty(name);
						if (!false)
						{
							if (property == null)
							{
								property = type2.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic);
							}
							#Rf = property.GetValue(#Rf, null);
							goto IL_DD;
						}
						goto IL_E6;
					}
				}
				return #Rf;
			}
			IL_03:
			throw new ArgumentNullException(#Phc.#3hc(107398878));
		}

		// Token: 0x060086C0 RID: 34496 RVA: 0x001CE24C File Offset: 0x001CC44C
		public static object #E(object #Rf, string #So, bool #m0d)
		{
			if (#Rf == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107398878));
			}
			if (false)
			{
				goto IL_65;
			}
			Type type2;
			string[] array2;
			int num2;
			if (#So != null)
			{
				Type type = #Rf.GetType();
				if (8 != 0)
				{
					type2 = type;
				}
				string[] array = #So.Split(new char[]
				{
					'.'
				});
				if (3 != 0)
				{
					array2 = array;
				}
				int num = 0;
				if (2 != 0)
				{
					num2 = num;
				}
				goto IL_115;
			}
			IL_19:
			throw new ArgumentNullException(#Phc.#3hc(107226730));
			IL_65:
			IDynamicMetaObjectProvider dynamicMetaObjectProvider = #Rf as IDynamicMetaObjectProvider;
			IDynamicMetaObjectProvider dynamicMetaObjectProvider2;
			if (!false)
			{
				dynamicMetaObjectProvider2 = dynamicMetaObjectProvider;
			}
			int num5;
			int num4;
			string text;
			if (dynamicMetaObjectProvider2 != null)
			{
				int num3 = num4 = (num5 = 0);
				if (num3 == 0)
				{
					CallSite<Func<CallSite, object, object>> callSite = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember((CSharpBinderFlags)num3, text, type2, new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
					CallSite<Func<CallSite, object, object>> callSite2;
					if (!false)
					{
						callSite2 = callSite;
					}
					#Rf = callSite2.Target(callSite2, dynamicMetaObjectProvider2);
					goto IL_107;
				}
			}
			else
			{
				if (!#m0d || !ReflectionHelper.#u0d(text))
				{
					#Rf = type2.GetProperty(text).GetValue(#Rf, null);
					goto IL_107;
				}
				num5 = (num4 = ReflectionHelper.#v0d(text));
			}
			if (8 == 0)
			{
				goto IL_114;
			}
			int index = num4;
			string name = ReflectionHelper.#w0d(text);
			if (7 == 0)
			{
				goto IL_19;
			}
			#Rf = type2.GetProperty(name).GetValue(#Rf, null);
			#Rf = ((IList)#Rf)[index];
			IL_107:
			if (#Rf == null)
			{
				return #Rf;
			}
			type2 = #Rf.GetType();
			num5 = num2 + 1;
			IL_114:
			num2 = num5;
			IL_115:
			int num6 = num2;
			int num7 = array2.Length;
			int num8;
			do
			{
				num8 = (num7 = num7);
			}
			while (false);
			if (num6 < num8)
			{
				string text2 = array2[num2];
				if (false)
				{
					goto IL_65;
				}
				text = text2;
				goto IL_65;
			}
			return #Rf;
		}

		// Token: 0x060086C1 RID: 34497 RVA: 0x001CE3A4 File Offset: 0x001CC5A4
		public static void #H(object #Rf, string #So, object #f)
		{
			if (#Rf != null)
			{
				Type type2;
				if (#So == null)
				{
					if (false)
					{
						goto IL_5C;
					}
					if (4 != 0)
					{
						throw new ArgumentNullException(#Phc.#3hc(107226730));
					}
					goto IL_B1;
				}
				else
				{
					Type type = #Rf.GetType();
					if (8 != 0)
					{
						type2 = type;
					}
				}
				IL_3C:
				string[] array = #So.Split(new char[]
				{
					'.'
				});
				string[] array2;
				if (!false)
				{
					array2 = array;
				}
				string[] array3 = array2;
				string[] array4;
				if (4 != 0)
				{
					array4 = array3;
				}
				IL_5C:
				int num = 0;
				int num2;
				if (!false)
				{
					num2 = num;
				}
				goto IL_B5;
				IL_B1:
				num2++;
				IL_B5:
				if (num2 < array4.Length)
				{
					string text = array4[num2];
					string text2;
					if (5 != 0)
					{
						text2 = text;
					}
					object obj = #Rf;
					object obj2;
					if (!false)
					{
						obj2 = obj;
					}
					PropertyInfo property = type2.GetProperty(text2);
					#Rf = property.GetValue(#Rf, null);
					if (text2 == array2.Last<string>())
					{
						property.SetValue(obj2, #f, null);
					}
					if (#Rf != null)
					{
						if (6 != 0)
						{
							type2 = #Rf.GetType();
							goto IL_B1;
						}
						goto IL_03;
					}
				}
				if (!false)
				{
					return;
				}
				goto IL_3C;
			}
			IL_03:
			throw new ArgumentNullException(#Phc.#3hc(107398878));
		}

		// Token: 0x060086C2 RID: 34498 RVA: 0x001CE494 File Offset: 0x001CC694
		public static void #H(object #Rf, string #So, object #f, bool #m0d)
		{
			if (false)
			{
				goto IL_6D;
			}
			if (#Rf == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107398878));
			}
			if (#So == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107226730));
			}
			Type type = #Rf.GetType();
			Type type2;
			if (2 != 0)
			{
				type2 = type;
			}
			string[] array = #So.Split(new char[]
			{
				'.'
			});
			string[] array2;
			if (!false)
			{
				array2 = array;
			}
			string[] array3 = array2;
			string[] array4;
			if (!false)
			{
				array4 = array3;
			}
			int num = 0;
			IL_57:
			int num2;
			if (!false)
			{
				num2 = num;
			}
			goto IL_FF;
			IL_6D:
			object obj = #Rf;
			object obj2;
			if (!false)
			{
				obj2 = obj;
			}
			num = (#m0d ? 1 : 0);
			if (2 == 0)
			{
				goto IL_57;
			}
			string text;
			PropertyInfo property;
			if (#m0d && ReflectionHelper.#u0d(text))
			{
				int index = ReflectionHelper.#v0d(text);
				string name = ReflectionHelper.#w0d(text);
				property = type2.GetProperty(name);
				#Rf = property.GetValue(#Rf, null);
				#Rf = ((IList)#Rf)[index];
			}
			else
			{
				property = type2.GetProperty(text);
				#Rf = property.GetValue(#Rf, null);
			}
			if (text == array2.Last<string>())
			{
				property.SetValue(obj2, #f, null);
			}
			if (#Rf == null)
			{
				return;
			}
			type2 = #Rf.GetType();
			int num3 = num2;
			IL_F9:
			int num4 = 1;
			IL_FA:
			int num5 = num3 += num4;
			if (5 == 0)
			{
				goto IL_F9;
			}
			num2 = num5;
			IL_FF:
			int num6 = num3 = num2;
			int num7 = num4 = array4.Length;
			if (!true)
			{
				goto IL_FA;
			}
			if (num6 < num7)
			{
				string text2 = array4[num2];
				if (false)
				{
					goto IL_6D;
				}
				text = text2;
				goto IL_6D;
			}
		}

		// Token: 0x060086C3 RID: 34499 RVA: 0x001CE5D4 File Offset: 0x001CC7D4
		public static PropertyInfo #n0d(object #Rf, string #So)
		{
			object #Rf2 = #Rf;
			string #R0d = #Phc.#3hc(107398878);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107226721);
			if (8 != 0)
			{
				#X0d.#V0d(#Rf2, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107226730);
			Component #x6c2 = Component.Infrastructure;
			string #Qic2 = #Phc.#3hc(107226668);
			if (!false)
			{
				#X0d.#V0d(#So, #R0d2, #x6c2, #Qic2);
			}
			Type type = #Rf.GetType();
			Type type2;
			if (3 != 0)
			{
				type2 = type;
			}
			PropertyInfo propertyInfo = null;
			PropertyInfo propertyInfo2;
			if (2 != 0)
			{
				propertyInfo2 = propertyInfo;
			}
			string[] array = #So.Split(new char[]
			{
				'.'
			});
			string[] array2;
			if (!false)
			{
				array2 = array;
			}
			int num = 0;
			int i;
			if (!false)
			{
				i = num;
			}
			while (i < array2.Length)
			{
				string name = array2[i];
				propertyInfo2 = type2.GetProperty(name);
				#Rf = propertyInfo2.GetValue(#Rf, null);
				if (#Rf == null)
				{
					break;
				}
				type2 = #Rf.GetType();
				i++;
			}
			return propertyInfo2;
		}

		// Token: 0x060086C4 RID: 34500 RVA: 0x001CE694 File Offset: 0x001CC894
		public static bool #o0d(this object #Rf, string #p0d)
		{
			int num;
			int num2;
			if (#Rf != null)
			{
				if (#p0d == null)
				{
					num = 107226647;
					goto IL_1E;
				}
				if (!false)
				{
					bool result = (num2 = ((#Rf.GetType().GetMethod(#p0d) != null) ? 1 : 0)) != 0;
					if (!false)
					{
						return result;
					}
					goto IL_08;
				}
			}
			num2 = 107398878;
			IL_08:
			int num3 = num = num2;
			if (num3 != 0)
			{
				throw new ArgumentNullException(#Phc.#3hc(num3));
			}
			IL_1E:
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x060086C5 RID: 34501 RVA: 0x001CE6E4 File Offset: 0x001CC8E4
		public static object #q0d(this object #Rf, string #p0d, params object[] #Pc)
		{
			if (#Rf == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107398878));
			}
			while (#p0d != null)
			{
				if (!false)
				{
					MethodInfo method = #Rf.GetType().GetMethod(#p0d);
					if (method == null)
					{
						throw new InvalidOperationException(#Phc.#3hc(107227110) + #p0d + #Phc.#3hc(107416684));
					}
					if (method.GetParameters().Length == 0)
					{
						object[] array = null;
						if (true)
						{
							#Pc = array;
						}
					}
					return method.Invoke(#Rf, #Pc);
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(107226647));
		}

		// Token: 0x060086C6 RID: 34502 RVA: 0x001CE768 File Offset: 0x001CC968
		public static object #q0d(this object #Rf, string #p0d, BindingFlags #ri, params object[] #Pc)
		{
			ReflectionHelper.#BUb #BUb2;
			if (!false)
			{
				ReflectionHelper.#BUb #BUb = new ReflectionHelper.#BUb();
				if (6 != 0)
				{
					#BUb2 = #BUb;
				}
			}
			#BUb2.#a = #p0d;
			int num;
			if (#Rf == null)
			{
				num = 107398878;
			}
			else if (#BUb2.#a == null)
			{
				int num2 = num = 107226647;
				if (num2 != 0)
				{
					throw new ArgumentNullException(#Phc.#3hc(num2));
				}
			}
			else
			{
				MethodInfo methodInfo = #Rf.GetType().GetMethods(#ri).FirstOrDefault(new Func<MethodInfo, bool>(#BUb2.#n4d));
				if (methodInfo == null)
				{
					throw new InvalidOperationException(#Phc.#3hc(107227110) + #BUb2.#a + #Phc.#3hc(107416684));
				}
				if (methodInfo.GetParameters().Length == 0)
				{
					object[] array = null;
					if (8 != 0)
					{
						#Pc = array;
					}
				}
				return methodInfo.Invoke(#Rf, #Pc);
			}
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x060086C7 RID: 34503 RVA: 0x001CE824 File Offset: 0x001CCA24
		public static IList<string> #r0d<#Fu>(bool #s0d)
		{
			Type typeFromHandle = typeof(!!0);
			if (!typeFromHandle.IsInterface)
			{
				throw new InvalidOperationException(#Phc.#3hc(107227129).#z2d());
			}
			List<string> list = new List<string>();
			List<string> list2;
			if (!false)
			{
				list2 = list;
			}
			List<string> #En = list2;
			if (!false)
			{
				ReflectionHelper.#t0d(typeFromHandle, #s0d, #En);
			}
			return list2;
		}

		// Token: 0x060086C8 RID: 34504 RVA: 0x001CE874 File Offset: 0x001CCA74
		private static void #t0d(Type #C, bool #s0d, List<string> #En)
		{
			int num;
			int num2;
			Type[] array;
			int num4;
			if (-1 != 0)
			{
				IEnumerable<string> collection = #C.GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(new Func<PropertyInfo, string>(ReflectionHelper.<>c.<>9.#o4d));
				if (!false)
				{
					#En.AddRange(collection);
				}
				num = (#s0d ? 1 : 0);
				num2 = (#s0d ? 1 : 0);
				if (false)
				{
					goto IL_62;
				}
				if (!#s0d)
				{
					return;
				}
				if (!false)
				{
					Type[] interfaces = #C.GetInterfaces();
					if (!false)
					{
						array = interfaces;
					}
					int num3 = 0;
					if (!false)
					{
						num4 = num3;
					}
				}
			}
			IL_61:
			num = (num2 = num4);
			IL_62:
			if (3 != 0)
			{
				if (num2 >= array.Length)
				{
					return;
				}
				Type #C2 = array[num4];
				bool #s0d2 = true;
				if (5 != 0)
				{
					ReflectionHelper.#t0d(#C2, #s0d2, #En);
				}
				num = num4 + 1;
			}
			if (false)
			{
				goto IL_61;
			}
			num4 = num;
			goto IL_61;
		}

		// Token: 0x060086C9 RID: 34505 RVA: 0x001CE904 File Offset: 0x001CCB04
		private static bool #u0d(string #em)
		{
			string text = #Phc.#3hc(107227096);
			string pattern;
			if (7 != 0)
			{
				pattern = text;
			}
			return Regex.IsMatch(#em, pattern);
		}

		// Token: 0x060086CA RID: 34506 RVA: 0x001CE92C File Offset: 0x001CCB2C
		private static int #v0d(string #em)
		{
			if (false)
			{
				goto IL_14;
			}
			int num = 107227051;
			IL_08:
			int result;
			int num2 = num = (result = num);
			if (num2 == 0)
			{
				goto IL_30;
			}
			string text = #Phc.#3hc(num2);
			string pattern;
			if (!false)
			{
				pattern = text;
			}
			IL_14:
			result = (num = int.Parse(Regex.Match(#em, pattern).Groups[1].Value));
			IL_30:
			if (!false)
			{
				return result;
			}
			goto IL_08;
		}

		// Token: 0x060086CB RID: 34507 RVA: 0x001CE970 File Offset: 0x001CCB70
		private static string #w0d(string #em)
		{
			int num = #em.IndexOf('[');
			int length;
			if (4 != 0)
			{
				length = num;
			}
			return #em.Substring(0, length);
		}

		// Token: 0x02000ED3 RID: 3795
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x060086D0 RID: 34512 RVA: 0x0006DA15 File Offset: 0x0006BC15
			internal bool #n4d(MethodInfo #dq)
			{
				if (4 != 0 && string.Equals(#dq.Name, this.#a, StringComparison.Ordinal) && !false)
				{
					bool result;
					bool flag = result = #dq.IsGenericMethod;
					if (3 != 0)
					{
						result = !flag;
					}
					return result;
				}
				return false;
			}

			// Token: 0x040037B7 RID: 14263
			public string #a;
		}
	}
}
