using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine
{
	// Token: 0x02001088 RID: 4232
	[Serializable]
	public sealed class TemplateEvaluatorException : Exception
	{
		// Token: 0x060090AD RID: 37037 RVA: 0x0004ED35 File Offset: 0x0004CF35
		public TemplateEvaluatorException()
		{
		}

		// Token: 0x060090AE RID: 37038 RVA: 0x0003326E File Offset: 0x0003146E
		public TemplateEvaluatorException(string message) : base(message)
		{
		}

		// Token: 0x060090AF RID: 37039 RVA: 0x0004ED3D File Offset: 0x0004CF3D
		public TemplateEvaluatorException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x060090B0 RID: 37040 RVA: 0x00053021 File Offset: 0x00051221
		protected TemplateEvaluatorException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
