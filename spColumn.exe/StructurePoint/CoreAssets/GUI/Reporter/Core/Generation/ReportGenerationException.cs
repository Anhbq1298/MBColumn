using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Generation
{
	// Token: 0x02000E15 RID: 3605
	[Serializable]
	public sealed class ReportGenerationException : Exception
	{
		// Token: 0x060081C8 RID: 33224 RVA: 0x0004ED35 File Offset: 0x0004CF35
		public ReportGenerationException()
		{
		}

		// Token: 0x060081C9 RID: 33225 RVA: 0x0003326E File Offset: 0x0003146E
		public ReportGenerationException(string message) : base(message)
		{
		}

		// Token: 0x060081CA RID: 33226 RVA: 0x0004ED3D File Offset: 0x0004CF3D
		public ReportGenerationException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x060081CB RID: 33227 RVA: 0x00053021 File Offset: 0x00051221
		protected ReportGenerationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
