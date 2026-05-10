using System;
using FluentValidation;
using FluentValidation.Internal;

namespace #5Z
{
	// Token: 0x02000397 RID: 919
	internal static class #U0
	{
		// Token: 0x06001DDD RID: 7645 RVA: 0x000C202C File Offset: 0x000C022C
		public static IValidationContext #ul(Type #R0, object #S0, PropertyChain #T0)
		{
			Type typeFromHandle = typeof(ValidationContext<>);
			Type[] typeArguments = new Type[]
			{
				#R0
			};
			Type type = typeFromHandle.MakeGenericType(typeArguments);
			return (IValidationContext)Activator.CreateInstance(type, new object[]
			{
				#S0,
				#T0,
				new DefaultValidatorSelector()
			});
		}
	}
}
