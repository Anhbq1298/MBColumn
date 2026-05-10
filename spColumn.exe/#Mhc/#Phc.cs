using System;
using System.Reflection;
using System.Reflection.Emit;
using \u0001;
using #7hc;
using #nhc;
using #Rhc;

namespace #Mhc
{
	// Token: 0x0200073C RID: 1852
	[#Vhc]
	[#Uhc]
	internal static class #Phc
	{
		// Token: 0x06003CAC RID: 15532 RVA: 0x0011AB20 File Offset: 0x00118D20
		[#Vhc]
		[#Uhc]
		[global::\u0001.\u0001]
		public static void #Nhc(Type #Ohc)
		{
			FieldInfo[] fields = #Ohc.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			FieldInfo[] array;
			if (!false)
			{
				array = fields;
			}
			foreach (FieldInfo fieldInfo in array)
			{
				try
				{
					if (fieldInfo.FieldType == typeof(#Qhc))
					{
						DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(string), new Type[]
						{
							typeof(int)
						}, #Ohc.Module, true);
						ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
						ilgenerator.Emit(OpCodes.Ldarg_0);
						foreach (MethodInfo methodInfo in typeof(#Phc.#fKg).GetMethods(BindingFlags.Static | BindingFlags.Public))
						{
							if (methodInfo.ReturnType == typeof(string))
							{
								ilgenerator.Emit(OpCodes.Ldc_I4, fieldInfo.MetadataToken & 16777215);
								ilgenerator.Emit(OpCodes.Sub);
								ilgenerator.Emit(OpCodes.Call, methodInfo);
								break;
							}
						}
						ilgenerator.Emit(OpCodes.Ret);
						fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeof(#Qhc)));
						break;
					}
				}
				catch
				{
				}
			}
		}
	}
}
