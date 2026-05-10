using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #5Kd;
using #ezc;
using #qPd;
using #sUd;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.Logger;

namespace #uLd
{
	// Token: 0x02000DE2 RID: 3554
	internal sealed class #LNd : #CBc<#8Kd>, INotifyPropertyChanged, #RBc<#8Kd>, IViewModel, #xPd
	{
		// Token: 0x06008085 RID: 32901 RVA: 0x00068A73 File Offset: 0x00066C73
		public #LNd(#GBc #2x, #8Kd #Ee, ILogger #3x, #rUd #Hj) : base(#2x, #Ee, #3x)
		{
			this.ApplicationContext = #Hj;
			base.View.SetViewModel(this);
		}

		// Token: 0x1700265E RID: 9822
		// (get) Token: 0x06008086 RID: 32902 RVA: 0x00068A92 File Offset: 0x00066C92
		// (set) Token: 0x06008087 RID: 32903 RVA: 0x00068A9E File Offset: 0x00066C9E
		public #rUd ApplicationContext { get; private set; }

		// Token: 0x040034B4 RID: 13492
		[CompilerGenerated]
		private #rUd #a;
	}
}
