using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using \u0001;
using \u0003;
using #nhc;

namespace #Mhc
{
	// Token: 0x0200073B RID: 1851
	[#Vhc]
	[#Uhc]
	internal static class #Lhc
	{
		// Token: 0x06003CAA RID: 15530 RVA: 0x0011A860 File Offset: 0x00118A60
		[#Vhc]
		[#Uhc]
		[global::\u0001.\u0001]
		public static void #Jhc(int #Khc)
		{
			Type typeFromHandle;
			try
			{
				typeFromHandle = Type.GetTypeFromHandle(#Lhc.\u0001.ResolveTypeHandle(33554433 + #Khc));
			}
			catch
			{
				return;
			}
			FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			int i = 0;
			while (i < fields.Length)
			{
				FieldInfo fieldInfo = fields[i];
				string name = fieldInfo.Name;
				bool flag = false;
				int num = 0;
				for (int j = name.Length - 1; j >= 0; j--)
				{
					char c = name[j];
					if (c == '~')
					{
						flag = true;
						break;
					}
					for (int k = 0; k < 58; k++)
					{
						if (#Lhc.\u0001[k] == c)
						{
							num = num * 58 + k;
							break;
						}
					}
				}
				MethodInfo methodInfo;
				try
				{
					methodInfo = (MethodInfo)MethodBase.GetMethodFromHandle(#Lhc.\u0001.ResolveMethodHandle(num + 167772161));
				}
				catch
				{
					goto IL_20D;
				}
				goto IL_CE;
				IL_20D:
				i++;
				continue;
				IL_CE:
				Delegate value;
				if (methodInfo.IsStatic)
				{
					try
					{
						value = Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo);
						goto IL_1FE;
					}
					catch (Exception)
					{
						goto IL_20D;
					}
				}
				ParameterInfo[] parameters = methodInfo.GetParameters();
				int num2 = parameters.Length + 1;
				Type[] array = new Type[num2];
				array[0] = typeof(object);
				for (int l = 1; l < num2; l++)
				{
					array[l] = parameters[l - 1].ParameterType;
				}
				DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array, typeFromHandle, true);
				ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
				ilgenerator.Emit(OpCodes.Ldarg_0);
				if (num2 > 1)
				{
					ilgenerator.Emit(OpCodes.Ldarg_1);
				}
				if (num2 > 2)
				{
					ilgenerator.Emit(OpCodes.Ldarg_2);
				}
				if (num2 > 3)
				{
					ilgenerator.Emit(OpCodes.Ldarg_3);
				}
				if (num2 > 4)
				{
					for (int m = 4; m < num2; m++)
					{
						ilgenerator.Emit(OpCodes.Ldarg_S, m);
					}
				}
				ilgenerator.Emit(OpCodes.Tailcall);
				ilgenerator.Emit(flag ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
				ilgenerator.Emit(OpCodes.Ret);
				try
				{
					value = dynamicMethod.CreateDelegate(typeFromHandle);
				}
				catch
				{
					goto IL_20D;
				}
				IL_1FE:
				try
				{
					fieldInfo.SetValue(null, value);
				}
				catch
				{
				}
				goto IL_20D;
			}
		}

		// Token: 0x06003CAB RID: 15531 RVA: 0x0011AAC8 File Offset: 0x00118CC8
		static #Lhc()
		{
			char[] array = new char[58];
			RuntimeFieldHandle fldHandle = fieldof(\u0003.\u0001.\u0001).FieldHandle;
			if (!false)
			{
				RuntimeHelpers.InitializeArray(array, fldHandle);
			}
			#Lhc.\u0001 = array;
			if (typeof(MulticastDelegate) != null)
			{
				#Lhc.\u0001 = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
			}
		}

		// Token: 0x04001B6E RID: 7022
		private static ModuleHandle \u0001;

		// Token: 0x04001B6F RID: 7023
		private static char[] \u0001;
	}
}
