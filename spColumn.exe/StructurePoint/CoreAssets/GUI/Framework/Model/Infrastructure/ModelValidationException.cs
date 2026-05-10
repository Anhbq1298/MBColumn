using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.GUI.Framework.Model.Infrastructure
{
	// Token: 0x02000C8E RID: 3214
	[Serializable]
	public sealed class ModelValidationException : Exception
	{
		// Token: 0x06006813 RID: 26643 RVA: 0x0004ED35 File Offset: 0x0004CF35
		public ModelValidationException()
		{
		}

		// Token: 0x06006814 RID: 26644 RVA: 0x0003326E File Offset: 0x0003146E
		public ModelValidationException(string message) : base(message)
		{
		}

		// Token: 0x06006815 RID: 26645 RVA: 0x0004ED3D File Offset: 0x0004CF3D
		public ModelValidationException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06006816 RID: 26646 RVA: 0x00053021 File Offset: 0x00051221
		protected ModelValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
